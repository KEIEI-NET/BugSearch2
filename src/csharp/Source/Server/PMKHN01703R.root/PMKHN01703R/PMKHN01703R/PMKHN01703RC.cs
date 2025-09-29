//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �����Y�Ə��i�݌Ƀ}�X�^�ϊ�����
// �v���O�����T�v   : �����𖞂������f�[�^���e�L�X�g�t�@�C���֏o�͂���
//----------------------------------------------------------------------------//
//                (c)Copyright  2015 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11003519-00 �쐬�S�� : �i�N
// �� �� ��  2015/01/26  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11003519-00 �쐬�S�� : ���V��
// �� �� ��  2015/02/26  �C�����e : Redmine#44209 ���b�Z�[�W�̕����Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11003519-00 �쐬�S�� : ���V��
// �� �� ��  2015/03/02  �C�����e : Redmine#44209 �u�d�l�ύX�v���i�}�X�^�A�݌Ƀ}�X�^�A���i�}�X�^�̃��O���P�ɏW�񂵂ďo�͂���Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11003519-00 �쐬�S�� : ���R
// �� �� ��  2015/04/15  �C�����e : Redmine#45436 ��78�݌Ɏ󕥗����f�[�^�o�^�s��̏C��
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11003519-00 �쐬�S�� : ���V��
// �� �� ��  2015/04/17  �C�����e : Redmine#45436 ���i���g�p���ă}�X�^�̍폜/�o�^�����s���Ă���ӏ����O�L���b�`����Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11003519-00 �쐬�S�� : ���R
// �� �� ��  2015/04/17  �C�����e : Redmine#45436 ��78�݌ɒ����쐬�����̏C��
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11003519-00 �쐬�S�� : ���V��
// �� �� ��  2015/04/27  �C�����e : ���r���[���ʑΉ�(status�ɂ�蔻�f�����̒ǉ�) 
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11003519-00 �쐬�S�� : �� �B
// �� �� ��  2015/06/20  �C�����e : �q�Ƀ}�X�^��1�����Ȃ��ꍇ�ɃG���[�ŏI�����Ă��܂��s��̏C��
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11670219-00 �쐬�S�� : 杍^
// �� �� ��  2020/06/18  �C�����e : PMKOBETSU-4005 �d�a�d�΍�
//----------------------------------------------------------------------------//

using System;
using System.Data;
using System.Text;
using System.Collections;
using System.Data.SqlClient;
using System.Collections.Generic;

using Broadleaf.Library.Data;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Data.SqlTypes;
using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using System.Text.RegularExpressions;
using Broadleaf.Library.Collections;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// �����Y�Ə��i�݌Ƀ}�X�^�ϊ�����DB�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note        : ���i�݌Ƀ}�X�^�ϊ������̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer  : �i�N</br>
    /// <br>Date        : 2015/01/26</br>
    /// <br>Update Note: PMKOBETSU-4005 �d�a�d�΍�</br>
    /// <br>Programmer : 杍^</br>
    /// <br>Date       : 2020/06/18</br>
    /// </remarks>
    [Serializable]
    public class MeijiGoodsStockDB : RemoteDB
    {
        # region ���b�Z�[�W
        //----- DEL 2015/02/26 ���V�� Redmine#44209 ���b�Z�[�W�̕����Ή�----->>>>>
        //// �r���`�F�b�N���b�Z�[�W
        //private const string EXISTMSG = "�ϊ���i�Ԃ����ɓo�^����܂���";
        //// �_���폜�`�F�b�N���b�Z�[�W
        //private const string DELETEMSG = "�_���폜�f�[�^";
        //// �X�V���s�̏ꍇ
        //private const string DELETEERRMSG = "�r���G���[�A�ϊ����i�Ԃ̍폜�Ɏ��s���܂���";
        //// �ϊ����ُ�G���[�̏ꍇ
        //private const string OLDEXCEPTIONMSG = "�폜�G���[�A�ϊ����i�Ԃ̍폜�Ɏ��s���܂���";
        //// �ϊ���ُ�G���[�̏ꍇ
        //private const string NEWEXCEPTIONMSG = "�o�^�G���[�A�ϊ���i�Ԃ̓o�^�Ɏ��s���܂���";
        ////�@���i�}�X�^�G���[����������ꍇ
        //private const string GOODSMSTERRMSG = "���i�}�X�^�G���[�ׁ̈A�����o���܂���ł����B���i�}�X�^�̃G���[���O���m�F���ĉ�����";
        ////�@���i�}�X�^�G���[����������ꍇ
        //private const string PRICEMSTERRMSG = "���i�}�X�^�G���[�ׁ̈A�����o���܂���ł����B���i�}�X�^�̃G���[���O���m�F���ĉ�����";
        ////�@�����i�ԁA���i�}�X�^�G���[����������ꍇ
        //private const string PRICEMSTERRMSG2 = "����i�Ԃ̉��i�ݒ�ŃG���[���������ׁA���Y�i�ԏ����o���܂���ł���";
        ////�@�݌Ƀ}�X�^�G���[����������ꍇ
        //private const string STOCKMSTERRMSG = "�݌Ƀ}�X�^�G���[�ׁ̈A�����o���܂���ł����B�݌Ƀ}�X�^�̃G���[���O���m�F���ĉ�����";
        ////�@�����i�ԁA�݌Ƀ}�X�^�G���[����������ꍇ
        //private const string STOCKMSTERRMSG2 = "����i�Ԃ̍݌ɐݒ�ŃG���[���������ׁA���Y�i�ԏ����o���܂���ł���";
        ////�@�s�����f�[�^������ꍇ
        //private const string UNNORMALDATA = "���i�}�X�^�����݂��Ȃ��ׁA���Y�i�ԏ����ł��܂���ł���";
        //----- DEL 2015/02/26 ���V�� Redmine#44209 ���b�Z�[�W�̕����Ή�-----<<<<<
        # endregion

        #region �����̃����[�g
        private GoodsPriceUDB _iGoodsPriceUDB;
        private StockAdjustDB _iStockAdjustDB;
        private GoodsUDB _iGoodsUDB;
        private GoodsNoChgCommonDB _iGoodsNoChgCommonDB;
        #endregion

        #region MeijiGoodsStockDB
        /// <summary>
        /// ���i�݌Ƀ}�X�^�ϊ������R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note        : ���ɂȂ�</br>
        /// <br>Programmer  : �i�N</br>
        /// <br>Date        : 2015/01/26</br>
        /// </remarks>
        public MeijiGoodsStockDB()
        {
            // ���i�}�X�^
            if (this._iGoodsUDB == null)
            {
                this._iGoodsUDB = new GoodsUDB();
            }
            // ���i�}�X�^
            if (this._iGoodsPriceUDB == null)
            {
                this._iGoodsPriceUDB = new GoodsPriceUDB();
            }
            // ���i�݌ɒ����}�X�^
            if (this._iStockAdjustDB == null)
            {
                this._iStockAdjustDB = new StockAdjustDB();
            }
            // �i�ԕϊ���������
            if (this._iGoodsNoChgCommonDB == null)
            {
                this._iGoodsNoChgCommonDB = new GoodsNoChgCommonDB();
            }
        }
        #endregion

        #region ���ʃ��\�b�h
        #region Main���b�\�[�h
        /// <summary>
        /// �i�ԕϊ�����
        /// </summary>
        /// <param name="goodsSuccessResultWork">���i�}�X�^�ϊ��������X�g</param>
        /// <param name="goodsErrorResultWork">���i�}�X�^�ϊ����s���X�g</param>
        /// <param name="goodsUpdateCount">���i�}�X�^�Ǎ�����</param>
        /// <param name="goodsPriceCount">���i�}�X�^�Ǎ�����</param>
        /// <param name="stockCount">�݌Ƀ}�X�^�Ǎ�����</param>
        /// <param name="updateMode">��ʂɏ����敪</param>
        /// <param name="enterPriseCode">��ƃR�[�h</param>
        /// <param name="goodsChangeAllCndWorkWork">�������[�N</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Programmer  : �i�N</br>
        /// <br>Date        : 2015/01/26</br>
        /// <br>UpdateNote : 2015/03/02 ���V�� </br>
        /// <br>           : Redmine#44209 ���i�}�X�^�A�݌Ƀ}�X�^�A���i�}�X�^�̃��O���P�ɏW�񂵂ďo�͂���Ή�</br>
        /// </remarks>
        //----- DEL 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���i�}�X�^�A�݌Ƀ}�X�^�A���i�}�X�^�̃��O���P�ɏW�񂵂ďo�͂���Ή�------>>>>>
        //public int WriteGoods(out object goodsSuccessResultWork, out object goodsErrorResultWork, out object priceSuccessResultWork, out object priceErrorResultWork,
        //    out object stockSuccessResultWork, out object stockErrorResultWork, out int goodsUpdateCount, out int goodsPriceCount, out int stockCount, int updateMode,
        //    string enterPriseCode, GoodsChangeAllCndWorkWork goodsChangeAllCndWorkWork)
        //----- DEL 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���i�}�X�^�A�݌Ƀ}�X�^�A���i�}�X�^�̃��O���P�ɏW�񂵂ďo�͂���Ή�------<<<<<
        //----- ADD 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���i�}�X�^�A�݌Ƀ}�X�^�A���i�}�X�^�̃��O���P�ɏW�񂵂ďo�͂���Ή�------>>>>>
        public int WriteGoods(out object goodsSuccessResultWork, out object goodsErrorResultWork, out int goodsUpdateCount, out int goodsPriceCount, out int stockCount, 
            int updateMode, string enterPriseCode, GoodsChangeAllCndWorkWork goodsChangeAllCndWorkWork)
        //----- ADD 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���i�}�X�^�A�݌Ƀ}�X�^�A���i�}�X�^�̃��O���P�ɏW�񂵂ďo�͂���Ή�------<<<<<
        {
            // �R�l�N�V����
            SqlConnection sqlConnection = null;
            // �g�����U�N�V����
            SqlTransaction sqlTransaction = null;
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            #region ���i�}�X�^
            // ���i�}�X�^���O
            goodsUpdateCount = 0;
            goodsSuccessResultWork = null;
            goodsErrorResultWork = null;
            ArrayList goodsSuccessResultWorkList = new ArrayList();
            ArrayList goodsErrorResultWorkList = new ArrayList();
            #endregion

            #region ���i���
            // ���i��񃍃O
            goodsPriceCount = 0;
            //----- DEL 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���i�}�X�^�A�݌Ƀ}�X�^�A���i�}�X�^�̃��O���P�ɏW�񂵂ďo�͂���Ή�------>>>>>
            //priceSuccessResultWork = null;
            //priceErrorResultWork = null;
            //ArrayList priceSuccessResultWorkList = new ArrayList();
            //ArrayList priceErrorResultWorkList = new ArrayList();
            //----- DEL 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���i�}�X�^�A�݌Ƀ}�X�^�A���i�}�X�^�̃��O���P�ɏW�񂵂ďo�͂���Ή�------<<<<<
            #endregion

            #region �݌Ƀ}�X�^
            // �݌Ƀ}�X�^���O
            stockCount = 0;
            //----- DEL 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���i�}�X�^�A�݌Ƀ}�X�^�A���i�}�X�^�̃��O���P�ɏW�񂵂ďo�͂���Ή�------>>>>>
            //stockSuccessResultWork = null;
            //stockErrorResultWork = null;
            //ArrayList stockSuccessResultWorkList = new ArrayList();
            //ArrayList stockErrorResultWorkList = new ArrayList();
            //----- DEL 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���i�}�X�^�A�݌Ƀ}�X�^�A���i�}�X�^�̃��O���P�ɏW�񂵂ďo�͂���Ή�------<<<<<
            #endregion

            try
            {
                // �R�l�N�V��������
                sqlConnection = this._iGoodsNoChgCommonDB.CreateSqlConnection(true);

                // �g�����U�N�V�����J�n
                sqlTransaction = this._iGoodsNoChgCommonDB.CreateTransaction(ref sqlConnection);

                // ���i�݌Ƀ}�X�^�ϊ�����
                //----- DEL 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���i�}�X�^�A�݌Ƀ}�X�^�A���i�}�X�^�̃��O���P�ɏW�񂵂ďo�͂���Ή�------>>>>>
                //status = WriteInProc(out goodsSuccessResultWorkList, out goodsErrorResultWorkList, out priceSuccessResultWorkList, out priceErrorResultWorkList,
                //    out stockSuccessResultWorkList, out stockErrorResultWorkList, out goodsUpdateCount, out goodsPriceCount, out stockCount, updateMode, enterPriseCode,
                //    goodsChangeAllCndWorkWork, ref sqlConnection, ref sqlTransaction);
                //----- DEL 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���i�}�X�^�A�݌Ƀ}�X�^�A���i�}�X�^�̃��O���P�ɏW�񂵂ďo�͂���Ή�------<<<<<
                //----- ADD 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���i�}�X�^�A�݌Ƀ}�X�^�A���i�}�X�^�̃��O���P�ɏW�񂵂ďo�͂���Ή�------>>>>>
                status = WriteInProc(out goodsSuccessResultWorkList, out goodsErrorResultWorkList, out goodsUpdateCount, out goodsPriceCount, out stockCount, 
                    updateMode, enterPriseCode, goodsChangeAllCndWorkWork, ref sqlConnection, ref sqlTransaction);
                //----- ADD 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���i�}�X�^�A�݌Ƀ}�X�^�A���i�}�X�^�̃��O���P�ɏW�񂵂ďo�͂���Ή�------<<<<<

                // �߂��郊�X�g
                // ���i�}�X�^
                goodsSuccessResultWork = goodsSuccessResultWorkList;
                goodsErrorResultWork = goodsErrorResultWorkList;
                //----- DEL 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���i�}�X�^�A�݌Ƀ}�X�^�A���i�}�X�^�̃��O���P�ɏW�񂵂ďo�͂���Ή�------>>>>>
                //// ���i���
                //priceSuccessResultWork = priceSuccessResultWorkList;
                //priceErrorResultWork = priceErrorResultWorkList;
                //// �݌Ƀ}�X�^
                //stockSuccessResultWork = stockSuccessResultWorkList;
                //stockErrorResultWork = stockErrorResultWorkList;
                //----- DEL 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���i�}�X�^�A�݌Ƀ}�X�^�A���i�}�X�^�̃��O���P�ɏW�񂵂ďo�͂���Ή�------<<<<<

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // �R�~�b�g
                    sqlTransaction.Commit();
                }
                else
                {
                    // ���[���o�b�N
                    sqlTransaction.Rollback();
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "MeijiGoodsStockDB.WriteIn");
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                // ���[���o�b�N
                if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
            }
            finally
            {
                if (sqlTransaction != null)
                {
                    sqlTransaction.Dispose();
                }

                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return status;
        }

        /// <summary>
        /// ���i�}�X�^�A���i�}�X�^�A�݌Ƀ}�X�^�ɕi�ԕϊ�����
        /// </summary>
        /// <param name="goodsSuccessResultWorkList">���i�捞�������X�g</param>
        /// <param name="goodsErrorResultWorkList">���i�捞���s���X�g</param>
        /// <param name="updateCountGoods">���i�}�X�^�Ǎ�����</param>
        /// <param name="updateCountPrice">���i�}�X�^�Ǎ�����</param>
        /// <param name="updateCountStock">�݌Ƀ}�X�^�Ǎ�����</param>
        /// <param name="updateMode">��ʂɏ����敪</param>
        /// <param name="enterPriseCode">��ƃR�[�h</param>
        /// <param name="goodsChangeAllCndWorkWork">�������[�N</param>
        /// <param name="sqlConnection">�R�l�N�V����</param>
        /// <param name="sqlTransaction">�g�����U�N�V����</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Programmer  : �i�N</br>
        /// <br>Date        : 2015/01/26</br>
        /// <br>UpdateNote  : 2015/03/02 ���V�� </br>
        /// <br>            : Redmine#44209 ���i�}�X�^�A�݌Ƀ}�X�^�A���i�}�X�^�̃��O���P�ɏW�񂵂ďo�͂���Ή�</br>
        /// </remarks>
        //----- DEL 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���i�}�X�^�A�݌Ƀ}�X�^�A���i�}�X�^�̃��O���P�ɏW�񂵂ďo�͂���Ή�------>>>>>
        //private int WriteInProc(out ArrayList goodsSuccessResultWorkList, out ArrayList goodsErrorResultWorkList, out ArrayList priceSuccessResultWorkList, out ArrayList priceErrorResultWorkList
        //    , out ArrayList stockSuccessResultWorkList, out ArrayList stockErrorResultWorkList, out int updateCountGoods, out int updateCountPrice, out int updateCountStock
        //    , int updateMode, string enterPriseCode, GoodsChangeAllCndWorkWork goodsChangeAllCndWorkWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        //----- DEL 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���i�}�X�^�A�݌Ƀ}�X�^�A���i�}�X�^�̃��O���P�ɏW�񂵂ďo�͂���Ή�------<<<<<
        //----- ADD 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���i�}�X�^�A�݌Ƀ}�X�^�A���i�}�X�^�̃��O���P�ɏW�񂵂ďo�͂���Ή�------>>>>>
        private int WriteInProc(out ArrayList goodsSuccessResultWorkList, out ArrayList goodsErrorResultWorkList, out int updateCountGoods, out int updateCountPrice, out int updateCountStock, 
            int updateMode, string enterPriseCode, GoodsChangeAllCndWorkWork goodsChangeAllCndWorkWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        //----- ADD 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���i�}�X�^�A�݌Ƀ}�X�^�A���i�}�X�^�̃��O���P�ɏW�񂵂ďo�͂���Ή�------<<<<<
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            // ���i�}�X�^
            goodsSuccessResultWorkList = new ArrayList();
            goodsErrorResultWorkList = new ArrayList();
            ArrayList goodsDataList = new ArrayList();
            updateCountGoods = 0;

            // ���i��� 
            //----- DEL 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���i�}�X�^�A�݌Ƀ}�X�^�A���i�}�X�^�̃��O���P�ɏW�񂵂ďo�͂���Ή�------>>>>>
            //priceSuccessResultWorkList = new ArrayList();
            //priceErrorResultWorkList = new ArrayList();
            //----- DEL 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���i�}�X�^�A�݌Ƀ}�X�^�A���i�}�X�^�̃��O���P�ɏW�񂵂ďo�͂���Ή�------<<<<<
            ArrayList priceDataList = new ArrayList();
            updateCountPrice = 0;

            // �݌Ƀ}�X�^
            //----- DEL 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���i�}�X�^�A�݌Ƀ}�X�^�A���i�}�X�^�̃��O���P�ɏW�񂵂ďo�͂���Ή�------>>>>>
            //stockSuccessResultWorkList = new ArrayList();
            //stockErrorResultWorkList = new ArrayList();
            //----- DEL 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���i�}�X�^�A�݌Ƀ}�X�^�A���i�}�X�^�̃��O���P�ɏW�񂵂ďo�͂���Ή�------<<<<<
            ArrayList stockDataList = new ArrayList();
            updateCountStock = 0;

            // �i�ԕϊ��G���[�f�[�^�A�X�V�ǉ�Dictionary
            Dictionary<string, GoodsNoChangeErrorDataWork> goodsNoChgErrDic = new Dictionary<string, GoodsNoChangeErrorDataWork>();

            // ���[�J�[Dictionary
            Dictionary<int, string> makerDic = new Dictionary<int, string>();
            // �q��Dictionary
            Dictionary<int, string> wareHouseDic = new Dictionary<int, string>();
            // BL���iDictionary
            Dictionary<int, string> blGoodsDic = new Dictionary<int, string>();
            // ���_Dictionary
            Dictionary<string, string> sectionDic = new Dictionary<string, string>();
            // �V���i�Ԃ�Dictionary
            Dictionary<string, MeijiGoodsStockWork> goodsNoAllDic = new Dictionary<string, MeijiGoodsStockWork>();

            try
            {
                // ���[�J�[�A�q�ɁABL���i���̌���
                status = this.SearchWorkDate(out makerDic, out wareHouseDic, out blGoodsDic, out sectionDic, enterPriseCode);

                #region ���i�}�X�^�A���i�}�X�^�A�݌Ƀ}�X�^�V���i�ԃf�[�^�擾
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    status = this.SearchGoodsPirceStockALL(out goodsDataList, out priceDataList, out stockDataList, out goodsNoAllDic, updateMode, enterPriseCode);
                }
                else
                {
                    return status;
                }
                #endregion �V���i�ԃf�[�^�擾

                #region �i�ԕϊ��G���[�f�[�^���폜����
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    status = this._iGoodsNoChgCommonDB.DeleteGoodsNoChangeErrorDataProc(enterPriseCode, GoodsNoChgCommonDB.GOODSMST, ref sqlConnection, ref sqlTransaction);
                }
                else
                {
                    return status;
                }
                #endregion

                #region ���i�}�X�^�̕i�Ԗ��ɁA�Ή����鏤�i�}�X�^�A���i�}�X�^�A�݌Ƀ}�X�^�V���i�ԕϊ�
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // �Ǎ������̃Z�b�g
                    updateCountGoods = goodsDataList.Count;
                    updateCountPrice = priceDataList.Count;
                    updateCountStock = stockDataList.Count;

                    //----- DEL 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���i�}�X�^�A�݌Ƀ}�X�^�A���i�}�X�^�̃��O���P�ɏW�񂵂ďo�͂���Ή�------>>>>>
                    //status = this.GoodsStockChgPrc(goodsDataList, priceDataList, stockDataList, makerDic, wareHouseDic, blGoodsDic, sectionDic, goodsNoAllDic,
                    //    out goodsNoChgErrDic, out goodsSuccessResultWorkList, out goodsErrorResultWorkList, out priceSuccessResultWorkList, out priceErrorResultWorkList,
                    //    out stockSuccessResultWorkList, out stockErrorResultWorkList, goodsChangeAllCndWorkWork, ref sqlConnection, ref sqlTransaction);
                    //----- DEL 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���i�}�X�^�A�݌Ƀ}�X�^�A���i�}�X�^�̃��O���P�ɏW�񂵂ďo�͂���Ή�------<<<<<
                    //----- ADD 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���i�}�X�^�A�݌Ƀ}�X�^�A���i�}�X�^�̃��O���P�ɏW�񂵂ďo�͂���Ή�------>>>>>
                    status = this.GoodsStockChgPrc(goodsDataList, priceDataList, stockDataList, makerDic, wareHouseDic, blGoodsDic, sectionDic, goodsNoAllDic, out goodsNoChgErrDic, 
                        out goodsSuccessResultWorkList, out goodsErrorResultWorkList, goodsChangeAllCndWorkWork, ref sqlConnection, ref sqlTransaction);
                    //----- ADD 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���i�}�X�^�A�݌Ƀ}�X�^�A���i�}�X�^�̃��O���P�ɏW�񂵂ďo�͂���Ή�------<<<<<
                }
                else
                {
                    return status;
                }
                #endregion ���i�}�X�^�̕i�Ԗ��ɁA�Ή����鏤�i�}�X�^�A���i�}�X�^�A�݌Ƀ}�X�^�V���i�ԕϊ�

                #region �i�ԕϊ��G���[�f�[�^��ǉ�����
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    status = this._iGoodsNoChgCommonDB.WriteGoodsNoChangeErrorDataProc(goodsNoChgErrDic, ref sqlConnection, ref sqlTransaction);
                }
                else
                {
                    return status;
                }
                #endregion
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "MeijiGoodsStockDB.WriteInProc Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            return status;
        }
        #endregion

        #region ��������
        /// <summary>
        /// �w�肳�ꂽ�����̏��i�}�X�^�A���i�}�X�^�A�݌Ƀ}�X�^���LIST��߂��܂�
        /// </summary>
        /// <param name="goodsuWorkList">���i��������</param>
        /// <param name="goodsPriceWorkList">���i��������</param>
        /// <param name="stockWorkList">�݌Ɍ�������</param>
        /// <param name="goodsNoAllDic">�V���i�Ԃ�Dictionary</param>
        /// <param name="updateMode">�X�V���[�h</param>
        /// <param name="enterPriseCode">��ƃR�[�h</param>
        /// <returns>STATUS</returns>
        /// <br>Note        : �w�肳�ꂽ�����̏��i�}�X�^�A���i�}�X�^�A�݌Ƀ}�X�^���LIST��߂��܂�</br>
        /// <br>Programmer  : �i�N</br>
        /// <br>Date        : 2015/01/26</br>
        private int SearchGoodsPirceStockALL(out ArrayList goodsuWorkList, out ArrayList goodsPriceWorkList, 
            out ArrayList stockWorkList, out Dictionary<string, MeijiGoodsStockWork> goodsNoAllDic, int updateMode, string enterPriseCode)
        {
            // �߂�p���[���^
            goodsuWorkList = new ArrayList();
            goodsPriceWorkList = new ArrayList();
            stockWorkList = new ArrayList();
            goodsNoAllDic = new Dictionary<string, MeijiGoodsStockWork>();
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            // �R�l�N�V����
            SqlConnection goodsStockConnection = null;

            try
            {
                goodsStockConnection = this._iGoodsNoChgCommonDB.CreateSqlConnection(true);

                // ���i�}�X�^����
                status = this.SearchGoodsUProcProc(out goodsuWorkList, ref goodsNoAllDic, updateMode, enterPriseCode, ref goodsStockConnection);
                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL &&
                    status != (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                {
                    return status;
                }

                // ���i�}�X�^����
                status = this.SearchGoodsPriceProc(out goodsPriceWorkList, ref goodsNoAllDic, updateMode, enterPriseCode, ref goodsStockConnection);
                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL &&
                    status != (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                {
                    return status;
                }

                // �݌Ƀ}�X�^����
                status = this.SearchStockInfoListProc(out stockWorkList, ref goodsNoAllDic, updateMode, enterPriseCode, ref goodsStockConnection);
                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL &&
                    status != (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                {
                    return status;
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "MeijiGoodsStockDB.SearchGoodsPirceStockALL");
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (goodsStockConnection != null)
                {
                    goodsStockConnection.Close();
                    goodsStockConnection.Dispose();
                }
            }
            return status;
        }
        #endregion

        #region �����ϊ�
        /// <summary>
        /// �w�肳�ꂽ�����̏��i�}�X�^�A���i�}�X�^�A�݌Ƀ}�X�^��ϊ�����
        /// </summary>
        /// <param name="goodsDataList">���i��������</param>
        /// <param name="priceDataList">���i��������</param>
        /// <param name="stockDataList">�݌Ɍ�������</param>
        /// <param name="makerDic">���[�J�[��Dictionary</param>
        /// <param name="wareHouseDic">�q�ɂ�Dictionary</param>
        /// <param name="blGoodsDic">�a�k�R�[�h��Dictionary</param>
        /// <param name="sectionDic">���_��Dictionary</param>
        /// <param name="goodsNoAllDic">�V���i�Ԃ�Dictionary</param>
        /// <param name="goodsNoChgErrDic">�i�ԕϊ����s��Dictionary</param>
        /// <param name="goodsSuccessResultWorkList">���i�捞�������X�g</param>
        /// <param name="goodsErrorResultWorkList">���i�捞���s���X�g</param>
        /// <param name="goodsChangeAllCndWorkWork">�������[�N</param>
        /// <param name="sqlConnection">�R�l�N�V����</param>
        /// <param name="sqlTransaction">�g�����U�N�V����</param>
        /// <returns>STATUS</returns>
        /// <br>Note        : �w�肳�ꂽ�����̏��i�}�X�^�A���i�}�X�^�A�݌Ƀ}�X�^���LIST��߂��܂�</br>
        /// <br>Programmer  : �i�N</br>
        /// <br>Date        : 2015/01/26</br>
        /// <br>UpdateNote : 2015/03/02 ���V�� </br>
        /// <br>           : Redmine#44209 ���i�}�X�^�A�݌Ƀ}�X�^�A���i�}�X�^�̃��O���P�ɏW�񂵂ďo�͂���Ή�</br>
        //----- DEL 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���i�}�X�^�A�݌Ƀ}�X�^�A���i�}�X�^�̃��O���P�ɏW�񂵂ďo�͂���Ή�------>>>>>
        //private int GoodsStockChgPrc(ArrayList goodsDataList, ArrayList priceDataList, ArrayList stockDataList, Dictionary<int, string> makerDic, Dictionary<int, string> wareHouseDic,
        //    Dictionary<int, string> blGoodsDic, Dictionary<string, string> sectionDic, Dictionary<string, MeijiGoodsStockWork> goodsNoAllDic,
        //    out Dictionary<string, GoodsNoChangeErrorDataWork> goodsNoChgErrDic, out ArrayList goodsSuccessResultWorkList, out ArrayList goodsErrorResultWorkList,
        //    out ArrayList priceSuccessResultWorkList, out ArrayList priceErrorResultWorkList, out ArrayList stockSuccessResultWorkList, out ArrayList stockErrorResultWorkList,
        //    GoodsChangeAllCndWorkWork goodsChangeAllCndWorkWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        //----- DEL 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���i�}�X�^�A�݌Ƀ}�X�^�A���i�}�X�^�̃��O���P�ɏW�񂵂ďo�͂���Ή�------<<<<<
        //----- ADD 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���i�}�X�^�A�݌Ƀ}�X�^�A���i�}�X�^�̃��O���P�ɏW�񂵂ďo�͂���Ή�------>>>>>
        private int GoodsStockChgPrc(ArrayList goodsDataList, ArrayList priceDataList, ArrayList stockDataList, Dictionary<int, string> makerDic, Dictionary<int, string> wareHouseDic,
            Dictionary<int, string> blGoodsDic, Dictionary<string, string> sectionDic, Dictionary<string, MeijiGoodsStockWork> goodsNoAllDic,
            out Dictionary<string, GoodsNoChangeErrorDataWork> goodsNoChgErrDic, out ArrayList goodsSuccessResultWorkList, out ArrayList goodsErrorResultWorkList,
            GoodsChangeAllCndWorkWork goodsChangeAllCndWorkWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        //----- ADD 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���i�}�X�^�A�݌Ƀ}�X�^�A���i�}�X�^�̃��O���P�ɏW�񂵂ďo�͂���Ή�------<<<<<
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            // ���O���X�g
            goodsSuccessResultWorkList = new ArrayList();
            goodsErrorResultWorkList = new ArrayList();
            //----- DEL 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���i�}�X�^�A�݌Ƀ}�X�^�A���i�}�X�^�̃��O���P�ɏW�񂵂ďo�͂���Ή�------>>>>>
            //priceSuccessResultWorkList = new ArrayList();
            //priceErrorResultWorkList = new ArrayList();
            //stockSuccessResultWorkList = new ArrayList();
            //stockErrorResultWorkList = new ArrayList();
            //----- DEL 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���i�}�X�^�A�݌Ƀ}�X�^�A���i�}�X�^�̃��O���P�ɏW�񂵂ďo�͂���Ή�------<<<<<
            // �e���X�g
            ArrayList chgPirceList = new ArrayList();
            ArrayList chgStockList = new ArrayList();
            ArrayList successLogList = null;

            string message = "";
            MeijiGoodsStockWork meijiGoodsStockWork = null;
            Object errorWork = new Object();
            GoodsPriceUWork priceResultWork;
            GoodsUWork goodsStockWork;
            GoodsUWork goodsChgWork;
            goodsNoChgErrDic = new Dictionary<string, GoodsNoChangeErrorDataWork>();
            Dictionary<string, string> goodsStockAllDic = new Dictionary<string, string>();

            // ���i�}�X�^�A���i�}�X�^�A�݌Ƀ}�X�^�ɑS�ĕi�Ԃ��쐬
            SetGoodsDic(goodsDataList, priceDataList, stockDataList, out goodsStockAllDic);

            #region ���i�}�X�^�A���i�}�X�^�A�݌Ƀ}�X�^�ɐV���i�Ԃ�ϊ�����
            foreach (string goodsNoKey in goodsStockAllDic.Keys)
            {
                // �i�ԑΉ��̏��i�}�X�^���X�g�A���i�}�X�^���X�g�A�݌Ƀ}�X�^���X�g���擾����
                GetGoodsWork(goodsNoKey, goodsDataList, out goodsChgWork);
                GetPriceList(goodsNoKey, priceDataList, out chgPirceList);
                GetStockList(goodsNoKey, stockDataList, out chgStockList);

                #region ���i�}�X�^�ɊY���i�Ԃ��Ȃ�
                if (goodsChgWork == null || 
                    goodsChgWork.GoodsMakerCd == 0 || string.IsNullOrEmpty(goodsChgWork.GoodsNo.Trim()))
                {
                    // �s�����f�[�^���O�̃Z�b�g
                    //SetUnNormalData(goodsNoKey, goodsNoAllDic[goodsNoKey], chgPirceList, chgStockList, ref priceErrorResultWorkList, ref stockErrorResultWorkList);// DEL 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���i�}�X�^�A�݌Ƀ}�X�^�A���i�}�X�^�̃��O���P�ɏW�񂵂ďo�͂���Ή�
                    SetUnNormalData(goodsNoKey, goodsNoAllDic[goodsNoKey], chgPirceList, chgStockList, ref goodsErrorResultWorkList);// ADD 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���i�}�X�^�A�݌Ƀ}�X�^�A���i�}�X�^�̃��O���P�ɏW�񂵂ďo�͂���Ή�

                    // �i�ԍX�V�G���[�f�[�^�̍쐬
                    GoodsNoChangeErrorDataWork goodsNoChangeErrorDataWork = this.GoodsNoChgErrData(goodsNoKey, goodsNoAllDic);
                    goodsNoChgErrDic.Add(goodsNoKey, goodsNoChangeErrorDataWork);
                    continue;
                }
                #endregion

                #region ���i�}�X�^�ɊY���i�Ԃ�����ꍇ
                successLogList = new ArrayList();
                goodsStockWork = this.CloneGoodsUWorkWork(goodsChgWork);
                sqlTransaction.Save("GoodsStockSavePoint");

                #region ���i�}�X�^�ɐV���i�Ԃ�ϊ�����
                status = this.GoodsMstChg(goodsNoKey, goodsChgWork, goodsNoAllDic,
                    out message, ref sqlConnection, ref sqlTransaction);
                // ���O�Z�b�g
                SetLog(goodsNoAllDic[goodsNoKey], null, message, out meijiGoodsStockWork);
                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // �G���[���[�N�Z�b�g
                    errorWork = goodsChgWork;
                }
                else
                {
                    // �����f�[�^�Z�b�g
                    successLogList.Add(meijiGoodsStockWork);
                }
                #endregion

                #region ���i�}�X�^�ɐV���i�Ԃ�ϊ�����
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    foreach (GoodsPriceUWork goodsPriceUWork in chgPirceList)
                    {
                        status = this.PriceMstChg(goodsNoKey, goodsChgWork, goodsPriceUWork, goodsNoAllDic,
                            out message, ref sqlConnection, ref sqlTransaction);

                        // ���O�Z�b�g
                        SetLog(goodsNoAllDic[goodsNoKey], goodsPriceUWork, message, out meijiGoodsStockWork);
                        if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            // �G���[���[�N�Z�b�g
                            errorWork = goodsPriceUWork;
                            break;
                        }
                        else
                        {
                            successLogList.Add(meijiGoodsStockWork);
                        }
                    }
                }
                #endregion

                #region �݌Ƀ}�X�^�ɐV���i�Ԃ�ϊ�����
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    int stockRowNo = 0;// �݌ɒ������ׂ̍s�ԍ�
                    // �݌ɒ����̉��i���Z�b�g���邽�߂ɁA�ŐV�̉��i���擾����
                    GetNewPrice(chgPirceList, out priceResultWork);

                    foreach (StockWork stockWork in chgStockList)
                    {
                        stockRowNo = stockRowNo + 1;
                        status = this.StockMstChg(goodsNoKey, goodsStockWork, priceResultWork,
                            stockWork, goodsNoAllDic, out message, makerDic, wareHouseDic, blGoodsDic, sectionDic,
                            goodsChangeAllCndWorkWork, stockRowNo, ref sqlConnection, ref sqlTransaction);

                        // ���O�Z�b�g
                        SetLog(goodsNoAllDic[goodsNoKey], stockWork, message, out meijiGoodsStockWork);
                        if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            // �G���[���[�N�Z�b�g
                            errorWork = stockWork;
                            break;
                        }
                        else
                        {
                            successLogList.Add(meijiGoodsStockWork);
                        }
                    }
                }
                #endregion

                #region ���O�̍쐬
                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // �G���[���O�̃Z�b�g
                    //----- DEL 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���i�}�X�^�A�݌Ƀ}�X�^�A���i�}�X�^�̃��O���P�ɏW�񂵂ďo�͂���Ή�------>>>>>
                    //SetErrLog(errorWork, meijiGoodsStockWork, goodsNoAllDic[goodsNoKey], goodsChgWork, chgPirceList, chgStockList,
                    //    ref goodsErrorResultWorkList, ref priceErrorResultWorkList, ref stockErrorResultWorkList);
                    //----- DEL 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���i�}�X�^�A�݌Ƀ}�X�^�A���i�}�X�^�̃��O���P�ɏW�񂵂ďo�͂���Ή�------<<<<<
                    //----- ADD 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���i�}�X�^�A�݌Ƀ}�X�^�A���i�}�X�^�̃��O���P�ɏW�񂵂ďo�͂���Ή�------>>>>>
                    SetErrLog(errorWork, meijiGoodsStockWork, goodsNoAllDic[goodsNoKey], goodsChgWork, chgPirceList, chgStockList, ref goodsErrorResultWorkList);
                    //----- ADD 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���i�}�X�^�A�݌Ƀ}�X�^�A���i�}�X�^�̃��O���P�ɏW�񂵂ďo�͂���Ή�------<<<<<

                    // �i�ԍX�V�G���[�f�[�^�̍쐬
                    GoodsNoChangeErrorDataWork goodsNoChangeErrorDataWork = this.GoodsNoChgErrData(goodsNoKey, goodsNoAllDic);
                    goodsNoChgErrDic.Add(goodsNoKey, goodsNoChangeErrorDataWork);

                    sqlTransaction.Rollback("GoodsStockSavePoint");
                }
                else
                {
                    // �������O�̃Z�b�g
                    //SetSuccessLog(successLogList, ref goodsSuccessResultWorkList, ref priceSuccessResultWorkList, ref stockSuccessResultWorkList);// DEL 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���i�}�X�^�A�݌Ƀ}�X�^�A���i�}�X�^�̃��O���P�ɏW�񂵂ďo�͂���Ή�
                    goodsSuccessResultWorkList.AddRange(successLogList);// ADD 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���i�}�X�^�A�݌Ƀ}�X�^�A���i�}�X�^�̃��O���P�ɏW�񂵂ďo�͂���Ή�
                }
                #endregion

                #endregion
            }

            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            #endregion
            return status;
        }
        #endregion

        #region ���i���[�N�擾
        /// <summary>
        /// ���i�J�n���ɂ���āA�Ή����鉿�i���[�N�擾
        /// </summary>
        /// <param name="priceDataList"></param>
        /// <param name="priceResultWork"></param>
        /// <returns></returns>
        /// <br>Note        : ���i�J�n���ɂ���āA�Ή����鉿�i���[�N�擾</br>
        /// <br>Programmer  : �i�N</br>
        /// <br>Date        : 2015/01/26</br>
        private void GetNewPrice(ArrayList priceDataList, out GoodsPriceUWork priceResultWork)
        {
            DateTime dateTime = DateTime.MinValue;
            priceResultWork = new GoodsPriceUWork();
            foreach (GoodsPriceUWork goodsPriceUWork in priceDataList)
            {
                if (DateTime.Compare(goodsPriceUWork.PriceStartDate, dateTime) > 0 &&
                    DateTime.Compare(goodsPriceUWork.PriceStartDate, DateTime.Now) <= 0)
                {
                    dateTime = goodsPriceUWork.PriceStartDate;
                    priceResultWork = goodsPriceUWork;
                }
            }
        }
        #endregion

        #region �S�ĕi��Dictionary�̍쐬
        /// <summary>
        /// ���i�A���i�A�݌Ƀ}�X�^�̖߂�l�ɏ]���ADictionary�̍쐬
        /// </summary>
        /// <param name="goodsDataList">���i���X�g</param>
        /// <param name="priceDataList">���i���X�g</param>
        /// <param name="stockDataList">�݌Ƀ��X�g</param>
        /// <param name="goodsStockAllDic">�S�ĕi��Dictionary</param>
        /// <returns></returns>
        /// <br>Note        : ���i�}�X�^�̖߂�l�ɏ]���ADictionary�̍쐬</br>
        /// <br>Programmer  : �i�N</br>
        /// <br>Date        : 2015/01/26</br>
        private void SetGoodsDic(ArrayList goodsDataList, ArrayList priceDataList, ArrayList stockDataList, out Dictionary<string, string> goodsStockAllDic)
        {
            goodsStockAllDic = new Dictionary<string, string>();
            string goodsKey = "";
            // ���i�}�X�^
            foreach (GoodsUWork goodsUWork in goodsDataList)
            {
                goodsKey = goodsUWork.GoodsMakerCd.ToString() + "-" + goodsUWork.GoodsNo.Trim();
                if (!goodsStockAllDic.ContainsKey(goodsKey))
                {
                    goodsStockAllDic.Add(goodsKey, goodsKey);
                }
            }
            // ���i�}�X�^
            foreach (GoodsPriceUWork goodsPriceUWork in priceDataList)
            {
                goodsKey = goodsPriceUWork.GoodsMakerCd.ToString() + "-" + goodsPriceUWork.GoodsNo.Trim();
                if (!goodsStockAllDic.ContainsKey(goodsKey))
                {

                    goodsStockAllDic.Add(goodsKey, goodsKey);
                }
            }
            // �݌Ƀ}�X�^
            foreach (StockWork stockWork in stockDataList)
            {
                goodsKey = stockWork.GoodsMakerCd.ToString() + "-" + stockWork.GoodsNo.Trim();
                if (!goodsStockAllDic.ContainsKey(goodsKey))
                {
                    goodsStockAllDic.Add(goodsKey, goodsKey);
                }
            }
        }
        #endregion

        //----- DEL 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���i�}�X�^�A�݌Ƀ}�X�^�A���i�}�X�^�̃��O���P�ɏW�񂵂ďo�͂���Ή�------>>>>>
        #region �������O�̃Z�b�g
        ///// <summary>
        ///// �������O�̍쐬
        ///// </summary>
        ///// <param name="successLogList">�������O���X�g</param>
        ///// <param name="goodsSuccessResultWorkList">���i���X�g</param>
        ///// <param name="priceSuccessResultWorkList">���i���X�g</param>
        ///// <param name="stockSuccessResultWorkList">�݌Ƀ��X�g</param>
        ///// <returns></returns>
        ///// <br>Note        : �������O�̍쐬</br>
        ///// <br>Programmer  : �i�N</br>
        ///// <br>Date        : 2015/01/26</br>
        //private void SetSuccessLog(ArrayList successLogList, ref ArrayList goodsSuccessResultWorkList, ref ArrayList priceSuccessResultWorkList, ref ArrayList stockSuccessResultWorkList)
        //{
        //    foreach (MeijiGoodsStockWork successLogWork in successLogList)
        //    {
        //        // ���i�}�X�^
        //        if (successLogWork.MstDiv == 0)
        //        {
        //            goodsSuccessResultWorkList.Add(successLogWork);
        //        }
        //        // ���i�}�X�^
        //        else if (successLogWork.MstDiv == 1)
        //        {
        //            priceSuccessResultWorkList.Add(successLogWork);
        //        }
        //        // �݌Ƀ}�X�^
        //        else if (successLogWork.MstDiv == 2)
        //        {
        //            stockSuccessResultWorkList.Add(successLogWork);
        //        }
        //        else
        //        {
        //            // �Ȃ�
        //        }
        //    }
        //}
        #endregion
        //----- DEL 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���i�}�X�^�A�݌Ƀ}�X�^�A���i�}�X�^�̃��O���P�ɏW�񂵂ďo�͂���Ή�------<<<<<

        #region �s�����f�[�^���O�Z�b�g
        /// <summary>
        /// �s�����f�[�^����
        /// </summary>
        /// <param name="goodsNoKey">�L�[</param>
        /// <param name="sinFuWork">�V���i�ԑΉ����郏�[�N</param>
        /// <param name="priceDataList">���i���X�g</param>
        /// <param name="stockDataList">�݌Ƀ��X�g</param>
        /// <param name="goodsErrorResultWorkList">���i�݌ɃG���[���X�g</param>
        /// <returns></returns>
        /// <br>Note        : �G���[���O�̍쐬</br>
        /// <br>Programmer  : �i�N</br>
        /// <br>Date        : 2015/01/26</br>
        private void SetUnNormalData(string goodsNoKey, MeijiGoodsStockWork sinFuWork, ArrayList priceDataList, ArrayList stockDataList, ref ArrayList goodsErrorResultWorkList)
        {
            string goodsKey = "";
            MeijiGoodsStockWork meijiGoodsStockWork;
            // ���i�}�X�^�A�s�����f�[�^�̃��O�o��
            foreach(GoodsPriceUWork priceWork in priceDataList)
            {
                goodsKey = priceWork.GoodsMakerCd.ToString() + "-" + priceWork.GoodsNo.Trim();
                if (goodsNoKey.Equals(goodsKey))
                {
                    //SetLog(sinFuWork, priceWork, UNNORMALDATA, out meijiGoodsStockWork); // DEL 2015/02/26 ���V�� Redmine#44209 ���b�Z�[�W�̕����Ή�
                    SetLog(sinFuWork, priceWork, string.Format(GoodsNoChgCommonDB.UNNORMALDATA, "���i�}�X�^"), out meijiGoodsStockWork); // DEL 2015/02/26 ���V�� Redmine#44209 ���b�Z�[�W�̕����Ή�
                    //priceErrorResultWorkList.Add(meijiGoodsStockWork);// DEL 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���i�}�X�^�A�݌Ƀ}�X�^�A���i�}�X�^�̃��O���P�ɏW�񂵂ďo�͂���Ή�
                    goodsErrorResultWorkList.Add(meijiGoodsStockWork);// ADD 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���i�}�X�^�A�݌Ƀ}�X�^�A���i�}�X�^�̃��O���P�ɏW�񂵂ďo�͂���Ή�
                }
            }
            // �q�Ƀ}�X�^�A�s�����f�[�^�̃��O�o��
            foreach (StockWork stockWork in stockDataList)
            {
                goodsKey = stockWork.GoodsMakerCd.ToString() + "-" + stockWork.GoodsNo.Trim();
                if (goodsNoKey.Equals(goodsKey))
                {
                    //SetLog(sinFuWork, stockWork, UNNORMALDATA, out meijiGoodsStockWork); // DEL 2015/02/26 ���V�� Redmine#44209 ���b�Z�[�W�̕����Ή�
                    SetLog(sinFuWork, stockWork, string.Format(GoodsNoChgCommonDB.UNNORMALDATA, "�݌Ƀ}�X�^"), out meijiGoodsStockWork); // ADD 2015/02/26 ���V�� Redmine#44209 ���b�Z�[�W�̕����Ή�
                    //stockErrorResultWorkList.Add(meijiGoodsStockWork);// DEL 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���i�}�X�^�A�݌Ƀ}�X�^�A���i�}�X�^�̃��O���P�ɏW�񂵂ďo�͂���Ή�
                    goodsErrorResultWorkList.Add(meijiGoodsStockWork);// ADD 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���i�}�X�^�A�݌Ƀ}�X�^�A���i�}�X�^�̃��O���P�ɏW�񂵂ďo�͂���Ή�
                }
            }
        }
        #endregion

        #region �G���[���O�̃Z�b�g
        /// <summary>
        /// �G���[���O�̃Z�b�g
        /// </summary>
        /// <param name="errorWork">�G���[���������郏�[�N</param>
        /// <param name="errorLogWork">�G���[���[�N</param>
        /// <param name="sinFuWork">�V���i�ԑΉ����郏�[�N</param>
        /// <param name="goodsWork">���i���[�N</param>
        /// <param name="priceDataList">���i���X�g</param>
        /// <param name="stockDataList">�݌Ƀ��X�g</param>
        /// <param name="goodsErrorResultWorkList">���i�G���[���X�g</param>
        /// <returns></returns>
        /// <br>Note        : �G���[���O�̍쐬</br>
        /// <br>Programmer  : �i�N</br>
        /// <br>Date        : 2015/01/26</br>
        /// <br>UpdateNote  : 2015/03/02 ���V�� </br>
        /// <br>            : Redmine#44209 ���i�}�X�^�A�݌Ƀ}�X�^�A���i�}�X�^�̃��O���P�ɏW�񂵂ďo�͂���Ή�</br>
        //----- DEL 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���i�}�X�^�A�݌Ƀ}�X�^�A���i�}�X�^�̃��O���P�ɏW�񂵂ďo�͂���Ή�------>>>>>
        //private void SetErrLog(object errorWork, MeijiGoodsStockWork errorLogWork, MeijiGoodsStockWork sinFuWork, GoodsUWork goodsWork, ArrayList priceDataList, ArrayList stockDataList,
        //    ref ArrayList goodsErrorResultWorkList, ref ArrayList priceErrorResultWorkList, ref ArrayList stockErrorResultWorkList)
        //----- DEL 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���i�}�X�^�A�݌Ƀ}�X�^�A���i�}�X�^�̃��O���P�ɏW�񂵂ďo�͂���Ή�------<<<<<
        //----- ADD 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���i�}�X�^�A�݌Ƀ}�X�^�A���i�}�X�^�̃��O���P�ɏW�񂵂ďo�͂���Ή�------>>>>>
        private void SetErrLog(object errorWork, MeijiGoodsStockWork errorLogWork, MeijiGoodsStockWork sinFuWork, GoodsUWork goodsWork, ArrayList priceDataList, ArrayList stockDataList,
            ref ArrayList goodsErrorResultWorkList)
        //----- ADD 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���i�}�X�^�A�݌Ƀ}�X�^�A���i�}�X�^�̃��O���P�ɏW�񂵂ďo�͂���Ή�------<<<<<
        {
            MeijiGoodsStockWork meijiGoodsStockWork = new MeijiGoodsStockWork();
            String errorMsg = "";
            int dbFlag = 0;
            Type wktype = errorWork.GetType();
            switch (wktype.Name)
            {
                case "GoodsUWork":
                    {
                        dbFlag = 0;
                        //errorMsg = GOODSMSTERRMSG; // DEL 2015/02/26 ���V�� Redmine#44209 ���b�Z�[�W�̕����Ή�
                        errorMsg = string.Format(GoodsNoChgCommonDB.GOODSMSTERRMSG, "���i�}�X�^"); // ADD 2015/02/26 ���V�� Redmine#44209 ���b�Z�[�W�̕����Ή�
                        break;
                    }
                case "GoodsPriceUWork":
                    {
                        dbFlag = 1;
                        //errorMsg = PRICEMSTERRMSG; // DEL 2015/02/26 ���V�� Redmine#44209 ���b�Z�[�W�̕����Ή�
                        errorMsg = string.Format(GoodsNoChgCommonDB.GOODSMSTERRMSG, "���i�}�X�^"); // ADD 2015/02/26 ���V�� Redmine#44209 ���b�Z�[�W�̕����Ή�
                        break;
                    }
                case "StockWork":
                    {
                        dbFlag = 2;
                        //errorMsg = STOCKMSTERRMSG; // DEL 2015/02/26 ���V�� Redmine#44209 ���b�Z�[�W�̕����Ή�
                        errorMsg = string.Format(GoodsNoChgCommonDB.GOODSMSTERRMSG, "�݌Ƀ}�X�^"); // ADD 2015/02/26 ���V�� Redmine#44209 ���b�Z�[�W�̕����Ή�
                        break;
                    }
            }

            // ���i�}�X�^�̃G���[���O�Z�b�g
            if (dbFlag == 0)
            {
                errorLogWork.MstDiv = 0; // ADD 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���i�}�X�^�A�݌Ƀ}�X�^�A���i�}�X�^�̃��O���P�ɏW�񂵂ďo�͂���Ή�
                goodsErrorResultWorkList.Add(errorLogWork);
            }
            else
            {
                SetLog(sinFuWork, goodsWork, errorMsg, out meijiGoodsStockWork);
                goodsErrorResultWorkList.Add(meijiGoodsStockWork);
            }

            // ���i�}�X�^�G���[���O�Z�b�g
            if (dbFlag == 1)
            {
                GoodsPriceUWork errWorkPrice = (GoodsPriceUWork)errorWork;
                foreach (GoodsPriceUWork goodsPriceUWork in priceDataList)
                {
                    if (errWorkPrice.GoodsMakerCd == goodsPriceUWork.GoodsMakerCd &&
                        errWorkPrice.GoodsNo.Trim().Equals(goodsPriceUWork.GoodsNo.Trim()) &&
                        errWorkPrice.PriceStartDate.ToString().Equals(goodsPriceUWork.PriceStartDate.ToString()))
                    {
                        errorLogWork.MstDiv = 1; // ADD 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���i�}�X�^�A�݌Ƀ}�X�^�A���i�}�X�^�̃��O���P�ɏW�񂵂ďo�͂���Ή�
                        //priceErrorResultWorkList.Add(errorLogWork);// DEL 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���i�}�X�^�A�݌Ƀ}�X�^�A���i�}�X�^�̃��O���P�ɏW�񂵂ďo�͂���Ή�
                        goodsErrorResultWorkList.Add(errorLogWork);// ADD 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���i�}�X�^�A�݌Ƀ}�X�^�A���i�}�X�^�̃��O���P�ɏW�񂵂ďo�͂���Ή�
                    }
                    else
                    {
                        //SetLog(sinFuWork, goodsPriceUWork, PRICEMSTERRMSG2, out meijiGoodsStockWork); // DEL 2015/02/26 ���V�� Redmine#44209 ���b�Z�[�W�̕����Ή�
                        SetLog(sinFuWork, goodsPriceUWork, string.Format(GoodsNoChgCommonDB.GOODSMSTERRMSG2, "���i�}�X�^"), out meijiGoodsStockWork); // ADD 2015/02/26 ���V�� Redmine#44209 ���b�Z�[�W�̕����Ή�
                        //priceErrorResultWorkList.Add(meijiGoodsStockWork);// DEL 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���i�}�X�^�A�݌Ƀ}�X�^�A���i�}�X�^�̃��O���P�ɏW�񂵂ďo�͂���Ή�
                        goodsErrorResultWorkList.Add(meijiGoodsStockWork);// ADD 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���i�}�X�^�A�݌Ƀ}�X�^�A���i�}�X�^�̃��O���P�ɏW�񂵂ďo�͂���Ή�
                    }
                }
            }
            else
            {
                foreach (GoodsPriceUWork goodsPriceUWork in priceDataList)
                {
                    SetLog(sinFuWork, goodsPriceUWork, errorMsg, out meijiGoodsStockWork);
                    //priceErrorResultWorkList.Add(meijiGoodsStockWork);// DEL 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���i�}�X�^�A�݌Ƀ}�X�^�A���i�}�X�^�̃��O���P�ɏW�񂵂ďo�͂���Ή�
                    goodsErrorResultWorkList.Add(meijiGoodsStockWork);// ADD 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���i�}�X�^�A�݌Ƀ}�X�^�A���i�}�X�^�̃��O���P�ɏW�񂵂ďo�͂���Ή�
                }
            }


            // �݌Ƀ}�X�^�G���[���O�Z�b�g
            if (dbFlag == 2)
            {
                StockWork errWorkStock = (StockWork)errorWork;
                foreach (StockWork stockWork in stockDataList)
                {
                    if (errWorkStock.GoodsMakerCd == stockWork.GoodsMakerCd &&
                        errWorkStock.GoodsNo.Trim().Equals(stockWork.GoodsNo.Trim()) &&
                        errWorkStock.WarehouseCode.Trim().Equals(stockWork.WarehouseCode.Trim()))
                    {
                        errorLogWork.MstDiv = 2; // ADD 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���i�}�X�^�A�݌Ƀ}�X�^�A���i�}�X�^�̃��O���P�ɏW�񂵂ďo�͂���Ή�
                        //stockErrorResultWorkList.Add(errorLogWork);// DEL 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���i�}�X�^�A�݌Ƀ}�X�^�A���i�}�X�^�̃��O���P�ɏW�񂵂ďo�͂���Ή�
                        goodsErrorResultWorkList.Add(errorLogWork);// ADD 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���i�}�X�^�A�݌Ƀ}�X�^�A���i�}�X�^�̃��O���P�ɏW�񂵂ďo�͂���Ή�
                    }
                    else
                    {
                        //SetLog(sinFuWork, stockWork, STOCKMSTERRMSG2, out meijiGoodsStockWork); // DEL 2015/02/26 ���V�� Redmine#44209 ���b�Z�[�W�̕����Ή�
                        SetLog(sinFuWork, stockWork, string.Format(GoodsNoChgCommonDB.GOODSMSTERRMSG2, "�݌Ƀ}�X�^"), out meijiGoodsStockWork); // ADD 2015/02/26 ���V�� Redmine#44209 ���b�Z�[�W�̕����Ή�
                        //stockErrorResultWorkList.Add(meijiGoodsStockWork);// DEL 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���i�}�X�^�A�݌Ƀ}�X�^�A���i�}�X�^�̃��O���P�ɏW�񂵂ďo�͂���Ή�
                        goodsErrorResultWorkList.Add(meijiGoodsStockWork);// ADD 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���i�}�X�^�A�݌Ƀ}�X�^�A���i�}�X�^�̃��O���P�ɏW�񂵂ďo�͂���Ή�
                    }
                }
            }
            else
            {
                foreach (StockWork stockWork in stockDataList)
                {
                    SetLog(sinFuWork, stockWork, errorMsg, out meijiGoodsStockWork);
                    //stockErrorResultWorkList.Add(meijiGoodsStockWork);// DEL 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���i�}�X�^�A�݌Ƀ}�X�^�A���i�}�X�^�̃��O���P�ɏW�񂵂ďo�͂���Ή�
                    goodsErrorResultWorkList.Add(meijiGoodsStockWork);// ADD 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���i�}�X�^�A�݌Ƀ}�X�^�A���i�}�X�^�̃��O���P�ɏW�񂵂ďo�͂���Ή�
                }
            }
        }
        #endregion

        #region ���O�̍쐬
        /// <summary>
        /// ���O�̍쐬
        /// </summary>
        /// <param name="SinFuWork">�V���i�ԑΉ����[�N</param>
        /// <param name="para">�p���[���^</param>
        /// <param name="message">���b�Z�[�W</param>
        /// <param name="meijiGoodsStockWork">���O���[�N</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Programmer  : �i�N</br>
        /// <br>Date        : 2015/01/26</br>
        /// </remarks>
        private void SetLog(MeijiGoodsStockWork SinFuWork, object para, string message, out MeijiGoodsStockWork meijiGoodsStockWork)
        {
            meijiGoodsStockWork = new MeijiGoodsStockWork();
            meijiGoodsStockWork.NewGoodsNo = SinFuWork.NewGoodsNo;
            meijiGoodsStockWork.GoodsMakerCd = SinFuWork.GoodsMakerCd;
            meijiGoodsStockWork.OldGoodsNo = SinFuWork.OldGoodsNo;
            meijiGoodsStockWork.OutNote = message;
            meijiGoodsStockWork.MstDiv = 0;
            if (para != null)
            {
                Type wktype = para.GetType();
                switch (wktype.Name)
                {
                    case "GoodsPriceUWork":
                        {
                            meijiGoodsStockWork.PriceStartDate = ((GoodsPriceUWork)para).PriceStartDate;
                            meijiGoodsStockWork.MstDiv = 1;
                            break;
                        }
                    case "StockWork":
                        {
                            meijiGoodsStockWork.WareCode = ((StockWork)para).WarehouseCode;
                            meijiGoodsStockWork.MstDiv = 2;
                            break;
                        }
                }
            }

        }
        #endregion

        #region ���i���[�N�̎擾
        /// <summary>
        /// ���i���[�N�ɏ]���A���i���[�N�̎擾
        /// </summary>
        /// <param name="goodsNoKey">�L�[</param>
        /// <param name="goodsDataList">���i���X�g</param>
        /// <param name="goodsChgWork">�߂菤�i���[�N</param>
        /// <returns></returns>
        /// <br>Note        : ���i���[�N�ɏ]���A���i���[�N�̎擾</br>
        /// <br>Programmer  : �i�N</br>
        /// <br>Date        : 2015/01/26</br>
        private void GetGoodsWork(string goodsNoKey, ArrayList goodsDataList, out GoodsUWork goodsChgWork)
        {
            string goodsKey = "";
            goodsChgWork = new GoodsUWork();
            // ���i���[�N�ɏ]���A���i���X�g�̍쐬
            foreach (GoodsUWork goodsUWork in goodsDataList)
            {
                goodsKey = goodsUWork.GoodsMakerCd.ToString() + "-" + goodsUWork.GoodsNo.Trim();
                if (goodsNoKey.Equals(goodsKey))
                {
                    goodsChgWork = goodsUWork;
                }
            }
        }
        #endregion

        #region �݌Ƀ��X�g�̎擾
        /// <summary>
        /// ���i���[�N�ɏ]���A�݌Ƀ��X�g�̎擾
        /// </summary>
        /// <param name="goodsNoKey"></param>
        /// <param name="stockDataList"></param>
        /// <param name="chgStockList"></param>
        /// <returns></returns>
        /// <br>Note        : ���i���[�N�ɏ]���A�݌Ƀ��X�g�̎擾</br>
        /// <br>Programmer  : �i�N</br>
        /// <br>Date        : 2015/01/26</br>
        private void GetStockList(string goodsNoKey, ArrayList stockDataList, out ArrayList chgStockList)
        {
            string stockChgKey = "";
            chgStockList = new ArrayList();
            foreach (StockWork stockChgWork in stockDataList)
            {
                stockChgKey = stockChgWork.GoodsMakerCd.ToString() + "-" + stockChgWork.GoodsNo.Trim();
                if (goodsNoKey.Equals(stockChgKey))
                {
                    chgStockList.Add(stockChgWork);
                }
            }
        }
        #endregion

        #region ���i���X�g�̎擾
        /// <summary>
        /// ���i���[�N�ɏ]���A���i���X�g�̎擾
        /// </summary>
        /// <param name="goodsNoKey"></param>
        /// <param name="priceDataList"></param>
        /// <param name="chgPirceList"></param>
        /// <returns></returns>
        /// <br>Note        : ���i���[�N�ɏ]���A�݌Ƀ��X�g�̎擾</br>
        /// <br>Programmer  : �i�N</br>
        /// <br>Date        : 2015/01/26</br>
        private void GetPriceList(string goodsNoKey, ArrayList priceDataList, out ArrayList chgPirceList)
        {
            string priceKey = "";
            chgPirceList = new ArrayList();
            // ���i���[�N�ɏ]���A���i���X�g�̍쐬
            foreach (GoodsPriceUWork goodsPriceUWork in priceDataList)
            {
                priceKey = goodsPriceUWork.GoodsMakerCd.ToString() + "-" + goodsPriceUWork.GoodsNo.Trim();
                if (goodsNoKey.Equals(priceKey))
                {
                    chgPirceList.Add(goodsPriceUWork);
                }
            }
        }
        #endregion

        #region �i�ԕϊ��G���[�f�[�^�̍쐬
        /// <summary>
        /// �i�ԕϊ��G���[�f�[�^�̍쐬����
        /// </summary>
        /// <param name="goodsNoKey">���[�J�[�{�i�ԃL�[</param>
        /// <param name="goodsNoAllDic">�V���i�Ԃ�Dictionary</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Programmer  : �i�N</br>
        /// <br>Date        : 2015/01/26</br>
        /// </remarks>
        private GoodsNoChangeErrorDataWork GoodsNoChgErrData(string goodsNoKey, Dictionary<string, MeijiGoodsStockWork> goodsNoAllDic)
        {
            GoodsNoChangeErrorDataWork goodsNoChangeErrorDataWork = new GoodsNoChangeErrorDataWork();
            goodsNoChangeErrorDataWork.MasterDivCd = GoodsNoChgCommonDB.GOODSMST;
            goodsNoChangeErrorDataWork.GoodsMakerCd = goodsNoAllDic[goodsNoKey].GoodsMakerCd;
            goodsNoChangeErrorDataWork.ChgSrcGoodsNo = goodsNoAllDic[goodsNoKey].OldGoodsNo;
            goodsNoChangeErrorDataWork.ChgDestGoodsNo = goodsNoAllDic[goodsNoKey].NewGoodsNo;

            return goodsNoChangeErrorDataWork;
        }
        #endregion

        #region ����Dictionary�̎擾
        /// <summary>
        /// ��ƃR�[�h�ɂ���āA���[�J�[�A�q�ɁA�a�k�R�[�h�A���_����Dictionary�쐬
        /// </summary>
        /// <param name="makerNameDic">���[�J�[��Dictionary</param>
        /// <param name="wareHouseNameDic">�q�ɂ�Dictionary</param>
        /// <param name="blGoodsNameDic">�a�k�R�[�h��Dictionary</param>
        /// <param name="sectionNameDic">���_��Dictionary</param>
        /// <param name="enterPriseCode">��ƃR�[�h</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Programmer  : �i�N</br>
        /// <br>Date        : 2015/01/26</br>
        /// <br>Note      �@: ���r���[���ʑΉ�(status�ɂ�蔻�f�����̒ǉ�) </br>
        /// <br>Programmer�@: ���V��</br>
        /// <br>Date        : 2015/04/27</br>
        /// </remarks>
        private int SearchWorkDate(out Dictionary<int, string> makerNameDic, out Dictionary<int, string> wareHouseNameDic,
            out Dictionary<int, string> blGoodsNameDic, out Dictionary<string, string> sectionNameDic, string enterPriseCode)
        {
            // �e�}�X�^��Dictionary
            makerNameDic = new Dictionary<int, string>();
            wareHouseNameDic = new Dictionary<int, string>();
            blGoodsNameDic = new Dictionary<int, string>();
            sectionNameDic = new Dictionary<string, string>();
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            // �R�l�N�V��������
            SqlConnection sqlConnection = null;

            try
            {
                sqlConnection = this._iGoodsNoChgCommonDB.CreateSqlConnection(true);

                // BL�R�[�h�}�X�^
                BLGoodsCdUDB bLGoodsCdUDB = new BLGoodsCdUDB();
                ArrayList retal = null;
                BLGoodsCdUWork bLGoodsCdUWork = new BLGoodsCdUWork();
                bLGoodsCdUWork.EnterpriseCode = enterPriseCode;
                status = bLGoodsCdUDB.SearchBLGoodsCdProc(out retal, bLGoodsCdUWork, 0, ConstantManagement.LogicalMode.GetData01, ref sqlConnection);
                //----- ADD 2015/04/27 ���V�� ���r���[���ʑΉ�(status�ɂ�蔻�f�����̒ǉ�) ------>>>>>
                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                    return status;
                }
                //----- ADD 2015/04/27 ���V�� ���r���[���ʑΉ�(status�ɂ�蔻�f�����̒ǉ�) ------<<<<<
                foreach (BLGoodsCdUWork bLGoodsWork in retal)
                {
                    if (!blGoodsNameDic.ContainsKey(bLGoodsWork.BLGoodsCode))
                    {
                        blGoodsNameDic.Add(bLGoodsWork.BLGoodsCode, bLGoodsWork.BLGoodsHalfName);
                    }
                }

                // ���[�J�[�}�X�^�i���[�U�[�o�^
                MakerUDB makerUDB = new MakerUDB();
                retal = null;
                MakerUWork makerUWork = new MakerUWork();
                makerUWork.EnterpriseCode = enterPriseCode;
                status = makerUDB.SearchMakerProc(out retal, makerUWork, 0, ConstantManagement.LogicalMode.GetData01, ref sqlConnection);
                //----- ADD 2015/04/27 ���V�� ���r���[���ʑΉ�(status�ɂ�蔻�f�����̒ǉ�) ------>>>>>
                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                    return status;
                }
                //----- ADD 2015/04/27 ���V�� ���r���[���ʑΉ�(status�ɂ�蔻�f�����̒ǉ�) ------<<<<<
                foreach (MakerUWork makerWork in retal)
                {
                    if (!makerNameDic.ContainsKey(makerWork.GoodsMakerCd))
                    {
                        makerNameDic.Add(makerWork.GoodsMakerCd, makerWork.MakerName);
                    }
                }

                // �q�Ƀ}�X�^
                WarehouseDB warehouseDB = new WarehouseDB();
                retal = null;
                WarehouseWork warehouseWork = new WarehouseWork();
                warehouseWork.EnterpriseCode = enterPriseCode;
                status = warehouseDB.SearchWarehouseProc(out retal, warehouseWork, 0, ConstantManagement.LogicalMode.GetData01, ref sqlConnection);
                //----- ADD 2015/04/27 ���V�� ���r���[���ʑΉ�(status�ɂ�蔻�f�����̒ǉ�) ------>>>>>
                //----- UPD 2015/06/20 T.Nishi �q�Ƀ}�X�^��1�����Ȃ��ꍇ�ɃG���[�ŏI�����Ă��܂��s��̏C�� ------>>>>>
                //if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL
                 && status != (int)ConstantManagement.DB_Status.ctDB_EOF)
                //----- UPD 2015/06/20 T.Nishi �q�Ƀ}�X�^��1�����Ȃ��ꍇ�ɃG���[�ŏI�����Ă��܂��s��̏C�� ------<<<<<
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                    return status;
                }
                //----- ADD 2015/04/27 ���V�� ���r���[���ʑΉ�(status�ɂ�蔻�f�����̒ǉ�) ------<<<<<
                int WareHouseCode = 0;
                foreach (WarehouseWork wareWork in retal)
                {
                    WareHouseCode = Convert.ToInt32(wareWork.WarehouseCode.Trim());
                    if (!wareHouseNameDic.ContainsKey(WareHouseCode))
                    {
                        wareHouseNameDic.Add(WareHouseCode, wareWork.WarehouseName);
                    }
                }

                // ���_���ݒ�}�X�^
                SecInfoSetDB secInfoSetDB = new SecInfoSetDB();
                retal = null;
                SecInfoSetWork secInfoSetWork = new SecInfoSetWork();
                secInfoSetWork.EnterpriseCode = enterPriseCode;
                status = secInfoSetDB.Search(out retal, secInfoSetWork, 0, ConstantManagement.LogicalMode.GetData01, ref sqlConnection);
                //----- ADD 2015/04/27 ���V�� ���r���[���ʑΉ�(status�ɂ�蔻�f�����̒ǉ�) ------>>>>>
                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                    return status;
                }
                //----- ADD 2015/04/27 ���V�� ���r���[���ʑΉ�(status�ɂ�蔻�f�����̒ǉ�) ------<<<<<
                foreach (SecInfoSetWork sectionWork in retal)
                {
                    if (!sectionNameDic.ContainsKey(sectionWork.SectionCode.Trim()))
                    {
                        sectionNameDic.Add(sectionWork.SectionCode.Trim(), sectionWork.SectionGuideNm);
                    }
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "MeijiGoodsStockDB.SearchWorkDate Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            return status;
        }
        #endregion
        #endregion

        #region ���i�}�X�^
        #region ���i����
        /// <summary>
        /// �w�肳�ꂽ�����̏��i�}�X�^�i���[�U�[�o�^���j���LIST��߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="goodsuWorkList">��������</param>
        /// <param name="goodsNoAllDic">�V���i�Ԃ�Dictionary</param>
        /// <param name="updateMode">�X�V���[�h</param>
        /// <param name="enterPriseCode">��ƃR�[�h</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note        : �w�肳�ꂽ�����̏��i�}�X�^�i���[�U�[�o�^���j���LIST��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer  : �i�N</br>
        /// <br>Date        : 2015/01/26</br>
        private int SearchGoodsUProcProc(out ArrayList goodsuWorkList, ref Dictionary<string, MeijiGoodsStockWork> goodsNoAllDic, int updateMode, string enterPriseCode, 
            ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            string goodsNoKey = "";
            goodsuWorkList = new ArrayList();
            goodsNoAllDic = new Dictionary<string, MeijiGoodsStockWork>();
            try
            {
                string sqlTxt = "";
                sqlTxt += "SELECT" + Environment.NewLine;
                sqlTxt += "   GOODS.CREATEDATETIMERF" + Environment.NewLine;
                sqlTxt += "  ,GOODS.UPDATEDATETIMERF" + Environment.NewLine;
                sqlTxt += "  ,GOODS.ENTERPRISECODERF" + Environment.NewLine;
                sqlTxt += "  ,GOODS.FILEHEADERGUIDRF" + Environment.NewLine;
                sqlTxt += "  ,GOODS.UPDEMPLOYEECODERF" + Environment.NewLine;
                sqlTxt += "  ,GOODS.UPDASSEMBLYID1RF" + Environment.NewLine;
                sqlTxt += "  ,GOODS.UPDASSEMBLYID2RF" + Environment.NewLine;
                sqlTxt += "  ,GOODS.LOGICALDELETECODERF" + Environment.NewLine;
                sqlTxt += "  ,GOODS.GOODSMAKERCDRF" + Environment.NewLine;
                sqlTxt += "  ,GOODS.GOODSNORF" + Environment.NewLine;
                sqlTxt += "  ,GOODS.GOODSNAMERF" + Environment.NewLine;
                sqlTxt += "  ,GOODS.GOODSNAMEKANARF" + Environment.NewLine;
                sqlTxt += "  ,GOODS.JANRF" + Environment.NewLine;
                sqlTxt += "  ,GOODS.BLGOODSCODERF" + Environment.NewLine;
                sqlTxt += "  ,GOODS.DISPLAYORDERRF" + Environment.NewLine;
                sqlTxt += "  ,GOODS.GOODSRATERANKRF" + Environment.NewLine;
                sqlTxt += "  ,GOODS.TAXATIONDIVCDRF" + Environment.NewLine;
                sqlTxt += "  ,GOODS.GOODSNONONEHYPHENRF" + Environment.NewLine;
                sqlTxt += "  ,GOODS.OFFERDATERF" + Environment.NewLine;
                sqlTxt += "  ,GOODS.GOODSKINDCODERF" + Environment.NewLine;
                sqlTxt += "  ,GOODS.GOODSNOTE1RF" + Environment.NewLine;
                sqlTxt += "  ,GOODS.GOODSNOTE2RF" + Environment.NewLine;
                sqlTxt += "  ,GOODS.GOODSSPECIALNOTERF" + Environment.NewLine;
                sqlTxt += "  ,GOODS.ENTERPRISEGANRECODERF" + Environment.NewLine;
                sqlTxt += "  ,GOODS.UPDATEDATERF" + Environment.NewLine;
                sqlTxt += "  ,GOODS.OFFERDATADIVRF" + Environment.NewLine;
                sqlTxt += "  ,B.CHGDESTGOODSNORF" + Environment.NewLine;
                sqlTxt += "FROM" + Environment.NewLine;
                sqlTxt += "  GOODSURF AS GOODS WITH (READUNCOMMITTED) " + Environment.NewLine;
                if (updateMode == 0)
                {
                    sqlTxt += " INNER JOIN GOODSNOCHANGERF B WITH (READUNCOMMITTED) " + Environment.NewLine;
                    sqlTxt += " ON GOODS.ENTERPRISECODERF = B.ENTERPRISECODERF " + Environment.NewLine;
                    sqlTxt += " AND GOODS.GOODSNORF = B.CHGSRCGOODSNORF " + Environment.NewLine;
                    sqlTxt += " AND GOODS.GOODSMAKERCDRF = B.GOODSMAKERCDRF " + Environment.NewLine;
                }
                else
                {
                    sqlTxt += " INNER JOIN GOODSNOCHANGEERRDTRF B WITH (READUNCOMMITTED) " + Environment.NewLine;
                    sqlTxt += " ON GOODS.ENTERPRISECODERF = B.ENTERPRISECODERF " + Environment.NewLine;
                    sqlTxt += " AND GOODS.GOODSNORF = B.CHGSRCGOODSNORF " + Environment.NewLine;
                    sqlTxt += " AND GOODS.GOODSMAKERCDRF = B.GOODSMAKERCDRF " + Environment.NewLine;
                    sqlTxt += " AND B.MASTERDIVCDRF = 1 " + Environment.NewLine;
                }

                sqlCommand = new SqlCommand(sqlTxt, sqlConnection);

                sqlTxt = "";
                sqlTxt += "WHERE" + Environment.NewLine;

                //��ƃR�[�h
                sqlTxt += " GOODS.ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterPriseCode);

                //�_���폜�敪
                sqlTxt += " AND B.LOGICALDELETECODERF=@FINDLOGICALDELETECODE" + Environment.NewLine;
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);
                sqlTxt += " ORDER BY GOODS.ENTERPRISECODERF, GOODS.GOODSMAKERCDRF, GOODS.GOODSNORF ";

                sqlCommand.CommandText += sqlTxt;
                myReader = sqlCommand.ExecuteReader();
                while (myReader.Read())
                {
                    // ���i���[�N�ƐV���i�ԃ��[�N�̍쐬
                    GoodsUWork goodsUWork = new GoodsUWork();
                    MeijiGoodsStockWork meijiGoodsStockWork = new MeijiGoodsStockWork();
                    CopyToGoodsUWorkFromReader(ref myReader, out goodsUWork, out meijiGoodsStockWork);
                    // �V���i��Dictionary�̍쐬
                    goodsNoKey = meijiGoodsStockWork.GoodsMakerCd.ToString() + "-" + meijiGoodsStockWork.OldGoodsNo.Trim();
                    if (!goodsNoAllDic.ContainsKey(goodsNoKey))
                    {
                        goodsNoAllDic.Add(goodsNoKey, meijiGoodsStockWork);
                    }
                    // ���ʃ��X�g�̍쐬
                    goodsuWorkList.Add(goodsUWork);

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (Exception)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlCommand != null) sqlCommand.Dispose();
                if (myReader != null)
                    if (!myReader.IsClosed) myReader.Close();
            }

            return status;
        }
        #endregion

        #region ���i�}�X�^�ɐV���i�Ԃ̕ϊ�
        /// <summary>
        /// ���i�}�X�^�ɐV���i�Ԃ̕ϊ�����
        /// </summary>
        /// <param name="goodsNoKey">���[�J�[�{�i�ԃL�[</param>
        /// <param name="goodsChgWork">���i���[�N</param>
        /// <param name="goodsNoAllDic">�V���i�Ԃ�Dictionary</param>
        /// <param name="message">�G���[���b�Z�[�W</param>
        /// <param name="sqlConnection">�R�l�N�V����</param>
        /// <param name="sqlTransaction">�g�����U�N�V����</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Programmer  : �i�N</br>
        /// <br>Date        : 2015/01/26</br>
        /// <br>Note        : Redmine#45436 ���i���g�p���ă}�X�^�̍폜/�o�^�����s���Ă���ӏ����O�L���b�`����Ή�</br>
        /// <br>Programmer  : ���V��</br>
        /// <br>Date        : 2015/04/17</br>
        /// </remarks>
        private int GoodsMstChg(string goodsNoKey, GoodsUWork goodsChgWork, Dictionary<string, MeijiGoodsStockWork> goodsNoAllDic, 
            out string message, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            int logicalDeleteDiv = 0;
            // ���X�g�̍쐬
            ArrayList deleteWorkList = new ArrayList();
            ArrayList insertWorkList = new ArrayList();
            message = "";

            try
            {
                // ���i�Ԃ̍폜
                deleteWorkList.Add(goodsChgWork);
                //----- ADD 2015/04/17 ���V�� Redmine#45436 ���i���g�p���ă}�X�^�̍폜/�o�^�����s���Ă���ӏ����O�L���b�`����Ή�------>>>>>
                try
                {
                    //----- ADD 2015/04/17 ���V�� Redmine#45436 ���i���g�p���ă}�X�^�̍폜/�o�^�����s���Ă���ӏ����O�L���b�`����Ή�------<<<<<
                    status = this._iGoodsUDB.DeleteGoodsUProc(deleteWorkList, ref sqlConnection, ref sqlTransaction);
                    //----- ADD 2015/04/17 ���V�� Redmine#45436 ���i���g�p���ă}�X�^�̍폜/�o�^�����s���Ă���ӏ����O�L���b�`����Ή�------>>>>>
                }
                catch (Exception ex)
                {
                    base.WriteErrorLog(ex, "DeleteGoodsUProc");
                    status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                }
                //----- ADD 2015/04/17 ���V�� Redmine#45436 ���i���g�p���ă}�X�^�̍폜/�o�^�����s���Ă���ӏ����O�L���b�`����Ή�------<<<<<
                deleteWorkList.Clear();

                // �폜�̏ꍇ�ُ킪��������
                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // �r���ُ킪��������ꍇ
                    if (status == (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE
                        || status == (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE)
                    {
                        //message = DELETEERRMSG; // DEL 2015/02/26 ���V�� Redmine#44209 ���b�Z�[�W�̕����Ή�
                        message = string.Format(GoodsNoChgCommonDB.UPDATEFAIL, "���i�}�X�^"); // ADD 2015/02/26 ���V�� Redmine#44209 ���b�Z�[�W�̕����Ή�
                    }
                    // ����ȊO�ُ�̏ꍇ
                    else
                    {
                        //message = OLDEXCEPTIONMSG; // DEL 2015/02/26 ���V�� Redmine#44209 ���b�Z�[�W�̕����Ή�
                        message = GoodsNoChgCommonDB.OLDEXCEPTIONMSG; // ADD 2015/02/26 ���V�� Redmine#44209 ���b�Z�[�W�̕����Ή�
                    }
                }
                // �폜������̏ꍇ
                else
                {
                    // ���i�o�^�p�̃p�����[�^�ɃZ�b�g
                    // �����V�i�Ԃŕϊ�
                    goodsChgWork.GoodsNo = goodsNoAllDic[goodsNoKey].NewGoodsNo;
                    goodsChgWork.GoodsNoNoneHyphen = goodsNoAllDic[goodsNoKey].NewGoodsNo.Replace("-", "");
                    goodsChgWork.UpdateDateTime = DateTime.MinValue;
                    logicalDeleteDiv = goodsChgWork.LogicalDeleteCode;
                    insertWorkList.Add(goodsChgWork);

                    // �V�i�Ԃŏ��i�}�X�^�o�^
                    //----- ADD 2015/04/17 ���V�� Redmine#45436 ���i���g�p���ă}�X�^�̍폜/�o�^�����s���Ă���ӏ����O�L���b�`����Ή�------>>>>>
                    try
                    {
                    //----- ADD 2015/04/17 ���V�� Redmine#45436 ���i���g�p���ă}�X�^�̍폜/�o�^�����s���Ă���ӏ����O�L���b�`����Ή�------<<<<<
                        status = this._iGoodsUDB.WriteGoodsUProc(ref insertWorkList, ref sqlConnection, ref sqlTransaction);
                    //----- ADD 2015/04/17 ���V�� Redmine#45436 ���i���g�p���ă}�X�^�̍폜/�o�^�����s���Ă���ӏ����O�L���b�`����Ή�------>>>>>
                    }
                    catch (Exception ex)
                    {
                        base.WriteErrorLog(ex, "WriteGoodsUProc");
                        status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                    }
                    //----- ADD 2015/04/17 ���V�� Redmine#45436 ���i���g�p���ă}�X�^�̍폜/�o�^�����s���Ă���ӏ����O�L���b�`����Ή�------<<<<<

                    // �o�^���ُ킪��������ꍇ
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        // �r���ُ킪��������ꍇ
                        if (status == (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE
                            || status == (int)ConstantManagement.DB_Status.ctDB_DUPLICATE)
                        {
                            //message = EXISTMSG; // DEL 2015/02/26 ���V�� Redmine#44209 ���b�Z�[�W�̕����Ή�
                            message = string.Format(GoodsNoChgCommonDB.EXISTMSG, "���i�}�X�^"); // ADD 2015/02/26 ���V�� Redmine#44209 ���b�Z�[�W�̕����Ή�
                        }
                        // ����ȊO�ُ�̏ꍇ
                        else
                        {
                            //message = NEWEXCEPTIONMSG; // DEL 2015/02/26 ���V�� Redmine#44209 ���b�Z�[�W�̕����Ή�
                            message = GoodsNoChgCommonDB.NEWEXCEPTIONMSG;// ADD 2015/02/26 ���V�� Redmine#44209 ���b�Z�[�W�̕����Ή�
                        }
                    }
                    // �V�i�ԓo�^����̏ꍇ
                    else
                    {
                        // ���f�[�^���_���폜�̏ꍇ�A�V�i�Ԃ��_���폜���Ƃ��ĕύX����
                        if (logicalDeleteDiv == 1)
                        {
                            // �V�i�Ԙ_���폜
                            //----- ADD 2015/04/17 ���V�� Redmine#45436 ���i���g�p���ă}�X�^�̍폜/�o�^�����s���Ă���ӏ����O�L���b�`����Ή�------>>>>>
                            try
                            {
                            //----- ADD 2015/04/17 ���V�� Redmine#45436 ���i���g�p���ă}�X�^�̍폜/�o�^�����s���Ă���ӏ����O�L���b�`����Ή�------<<<<<
                                status = this._iGoodsUDB.LogicalDeleteGoodsUProc(ref insertWorkList, 0, ref sqlConnection, ref sqlTransaction);
                            //----- ADD 2015/04/17 ���V�� Redmine#45436 ���i���g�p���ă}�X�^�̍폜/�o�^�����s���Ă���ӏ����O�L���b�`����Ή�------>>>>>
                            }
                            catch (Exception ex)
                            {
                                base.WriteErrorLog(ex, "LogicalDeleteGoodsUProc");
                                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                            }
                            //----- ADD 2015/04/17 ���V�� Redmine#45436 ���i���g�p���ă}�X�^�̍폜/�o�^�����s���Ă���ӏ����O�L���b�`����Ή�------<<<<<

                            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                //message = DELETEMSG;// DEL 2015/02/26 ���V�� Redmine#44209 ���b�Z�[�W�̕����Ή�
                                message = GoodsNoChgCommonDB.DELETEMSG;// ADD 2015/02/26 ���V�� Redmine#44209 ���b�Z�[�W�̕����Ή�
                            }
                            else
                            {
                                //message = NEWEXCEPTIONMSG;// DEL 2015/02/26 ���V�� Redmine#44209 ���b�Z�[�W�̕����Ή�
                                message = GoodsNoChgCommonDB.NEWEXCEPTIONMSG;// ADD 2015/02/26 ���V�� Redmine#44209 ���b�Z�[�W�̕����Ή�
                            }
                        }
                    }
                }
                return status;
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "MeijiGoodsStockDB.GoodsMstChg");
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            return status;
        }
        #endregion

        #region ���i���[�N��Clone
        /// <summary>
        /// ���[�N��Clone
        /// </summary>
        /// <param name="work">���i���[�N</param>
        /// <returns></returns>
        private GoodsUWork CloneGoodsUWorkWork(GoodsUWork work)
        {
            GoodsUWork copyGoodsUWork = new GoodsUWork();

            copyGoodsUWork.CreateDateTime = work.CreateDateTime;
            copyGoodsUWork.UpdateDateTime = work.UpdateDateTime;
            copyGoodsUWork.EnterpriseCode = work.EnterpriseCode;
            copyGoodsUWork.FileHeaderGuid = work.FileHeaderGuid;
            copyGoodsUWork.UpdEmployeeCode = work.UpdEmployeeCode;
            copyGoodsUWork.UpdAssemblyId1 = work.UpdAssemblyId1;
            copyGoodsUWork.UpdAssemblyId2 = work.UpdAssemblyId2;
            copyGoodsUWork.LogicalDeleteCode = work.LogicalDeleteCode;
            copyGoodsUWork.GoodsMakerCd = work.GoodsMakerCd;
            copyGoodsUWork.GoodsNo = work.GoodsNo;
            copyGoodsUWork.GoodsName = work.GoodsName;
            copyGoodsUWork.GoodsNameKana = work.GoodsNameKana;
            copyGoodsUWork.Jan = work.Jan;
            copyGoodsUWork.BLGoodsCode = work.BLGoodsCode;
            copyGoodsUWork.DisplayOrder = work.DisplayOrder;
            copyGoodsUWork.GoodsRateRank = work.GoodsRateRank;
            copyGoodsUWork.TaxationDivCd = work.TaxationDivCd;
            copyGoodsUWork.GoodsNoNoneHyphen = work.GoodsNoNoneHyphen;
            copyGoodsUWork.OfferDate = work.OfferDate;
            copyGoodsUWork.GoodsKindCode = work.GoodsKindCode;
            copyGoodsUWork.GoodsNote1 = work.GoodsNote1;
            copyGoodsUWork.GoodsNote2 = work.GoodsNote2;
            copyGoodsUWork.GoodsSpecialNote = work.GoodsSpecialNote;
            copyGoodsUWork.EnterpriseGanreCode = work.EnterpriseGanreCode;
            copyGoodsUWork.UpdateDate = work.UpdateDate;
            copyGoodsUWork.OfferDataDiv = work.OfferDataDiv;

            return copyGoodsUWork;
        }
        #endregion

        #region [�N���X�i�[����]
        /// <summary>
        /// �N���X�i�[���� Reader �� GoodsUWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <param name="wkGoodsUWork">GoodsUWork</param>
        /// <param name="meijiGoodsStockWork">MeijiGoodsStockWork</param>
        /// <returns>GoodsUWork</returns>
        /// <remarks>
        /// <br>Programmer  : �i�N</br>
        /// <br>Date        : 2015/01/26</br>
        /// <br></br>
        /// </remarks>
        private void CopyToGoodsUWorkFromReader(ref SqlDataReader myReader, out GoodsUWork wkGoodsUWork, out MeijiGoodsStockWork meijiGoodsStockWork)
        {
            wkGoodsUWork = new GoodsUWork();
            meijiGoodsStockWork = new MeijiGoodsStockWork();

            wkGoodsUWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
            wkGoodsUWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
            wkGoodsUWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
            wkGoodsUWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
            wkGoodsUWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
            wkGoodsUWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
            wkGoodsUWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
            wkGoodsUWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
            wkGoodsUWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
            wkGoodsUWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
            wkGoodsUWork.GoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMERF"));
            wkGoodsUWork.GoodsNameKana = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMEKANARF"));
            wkGoodsUWork.Jan = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("JANRF"));
            wkGoodsUWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF"));
            wkGoodsUWork.DisplayOrder = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DISPLAYORDERRF"));
            wkGoodsUWork.GoodsRateRank = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSRATERANKRF"));
            wkGoodsUWork.TaxationDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TAXATIONDIVCDRF"));
            wkGoodsUWork.GoodsNoNoneHyphen = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNONONEHYPHENRF"));
            wkGoodsUWork.OfferDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("OFFERDATERF"));
            wkGoodsUWork.GoodsKindCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSKINDCODERF"));
            wkGoodsUWork.GoodsNote1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNOTE1RF"));
            wkGoodsUWork.GoodsNote2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNOTE2RF"));
            wkGoodsUWork.GoodsSpecialNote = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSSPECIALNOTERF"));
            wkGoodsUWork.EnterpriseGanreCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ENTERPRISEGANRECODERF"));
            wkGoodsUWork.UpdateDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("UPDATEDATERF"));
            wkGoodsUWork.OfferDataDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OFFERDATADIVRF"));

            meijiGoodsStockWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
            meijiGoodsStockWork.OldGoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
            meijiGoodsStockWork.NewGoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CHGDESTGOODSNORF"));
        }
        #endregion
        #endregion

        #region �݌Ƀ}�X�^
        #region �݌Ɍ����i�S���L�[�j
        /// <summary>
        /// �݌Ƀ}�X�^����
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="goodsNo">�i��</param>
        /// <param name="goodsMakerCd">���[�J�[�R�[�h</param>
        /// <param name="wareHouseCode">�q�ɃR�[�h</param>
        /// <returns></returns>
        /// <br>Note        : �݌Ƀ}�X�^��������</br>
        /// <br>Programmer  : �i�N</br>
        /// <br>Date        : 2015/01/26</br>
        private int SearchStockInfoProc(string enterpriseCode, string goodsNo, Int32 goodsMakerCd, string wareHouseCode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlCommand sqlCommand = null;
            SqlDataReader myReader = null;

            try
            {
                sqlConnection = this._iGoodsNoChgCommonDB.CreateSqlConnection(true);
                //Select�R�}���h�̐���
                sqlCommand = new SqlCommand("SELECT CREATEDATETIMERF, UPDATEDATETIMERF FROM STOCKRF WITH (READUNCOMMITTED) WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND GOODSMAKERCDRF=@FINDGOODSMAKERCD AND GOODSNORF=@FINDGOODSNO AND WAREHOUSECODERF=@FINDWAREHOUSECODE", sqlConnection);

                //Prameter�I�u�W�F�N�g�̍쐬
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
                SqlParameter findParaGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNO", SqlDbType.NVarChar);
                SqlParameter findParaWareHouseCode = sqlCommand.Parameters.Add("@FINDWAREHOUSECODE", SqlDbType.NVarChar);

                //Parameter�I�u�W�F�N�g�֒l�ݒ�
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCode);
                findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(goodsMakerCd);
                findParaGoodsNo.Value = SqlDataMediator.SqlSetString(goodsNo);
                findParaWareHouseCode.Value = SqlDataMediator.SqlSetString(wareHouseCode);

                sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitInquiry);
                // �ǂݍ���
                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (Exception)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (myReader != null)
                    if (!myReader.IsClosed) myReader.Close();
                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            return status;
        }
        #endregion

        #region �݌Ɍ���
        /// <summary>
        /// �݌Ƀ}�X�^��������
        /// </summary>
        /// <param name="stockList">�݌Ƀ��X�g</param>
        /// <param name="goodsNoAllDic">�V���i�Ԃ�Dictionary</param>
        /// <param name="updateMode">�X�V���[�h</param>
        /// <param name="enterPriseCode">��ƃR�[�h</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <br>Note        : �݌Ƀ}�X�^��������</br>
        /// <br>Programmer  : �i�N</br>
        /// <br>Date        : 2015/01/26</br>
        /// <returns>STATUS</returns>
        private int SearchStockInfoListProc(out ArrayList stockList, ref Dictionary<string, MeijiGoodsStockWork> goodsNoAllDic, int updateMode, string enterPriseCode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            SqlCommand sqlCommand = null;
            SqlDataReader myReader = null;
            stockList = new ArrayList();
            string goodsNoKey = "";
            try
            {
                //Select�R�}���h�̐���
                string sql = string.Empty;
                sql = "SELECT A.CREATEDATETIMERF, A.UPDATEDATETIMERF, A.ENTERPRISECODERF, A.FILEHEADERGUIDRF, A.UPDEMPLOYEECODERF, A.UPDASSEMBLYID1RF, " + Environment.NewLine;
                sql += "A.UPDASSEMBLYID2RF, A.LOGICALDELETECODERF, A.SECTIONCODERF, A.WAREHOUSECODERF, A.GOODSMAKERCDRF, A.GOODSNORF, A.STOCKUNITPRICEFLRF, A.SUPPLIERSTOCKRF, " + Environment.NewLine;
                sql += "A.ACPODRCOUNTRF, A.MONTHORDERCOUNTRF, A.SALESORDERCOUNTRF, A.STOCKDIVRF, A.MOVINGSUPLISTOCKRF, A.SHIPMENTPOSCNTRF, A.STOCKTOTALPRICERF, A.LASTSTOCKDATERF, " + Environment.NewLine;
                sql += "A.LASTSALESDATERF, A.LASTINVENTORYUPDATERF, A.MINIMUMSTOCKCNTRF, A.MAXIMUMSTOCKCNTRF, A.NMLSALODRCOUNTRF, A.SALESORDERUNITRF, A.STOCKSUPPLIERCODERF, " + Environment.NewLine;
                sql += "A.GOODSNONONEHYPHENRF, A.WAREHOUSESHELFNORF, A.DUPLICATIONSHELFNO1RF, A.DUPLICATIONSHELFNO2RF, A.PARTSMANAGEMENTDIVIDE1RF, A.PARTSMANAGEMENTDIVIDE2RF, " + Environment.NewLine;
                sql += "A.STOCKNOTE1RF, A.STOCKNOTE2RF, A.SHIPMENTCNTRF, A.ARRIVALCNTRF, A.STOCKCREATEDATERF, A.UPDATEDATERF, B.CHGDESTGOODSNORF FROM STOCKRF AS A WITH (READUNCOMMITTED) " + Environment.NewLine;
                if (updateMode == 0)
                {
                    sql += " INNER JOIN GOODSNOCHANGERF B WITH (READUNCOMMITTED) " + Environment.NewLine;
                    sql += " ON A.ENTERPRISECODERF = B.ENTERPRISECODERF " + Environment.NewLine;
                    sql += " AND A.GOODSNORF = B.CHGSRCGOODSNORF " + Environment.NewLine;
                    sql += " AND A.GOODSMAKERCDRF = B.GOODSMAKERCDRF " + Environment.NewLine;
                }
                else
                {
                    sql += " INNER JOIN GOODSNOCHANGEERRDTRF B WITH (READUNCOMMITTED) " + Environment.NewLine;
                    sql += " ON A.ENTERPRISECODERF = B.ENTERPRISECODERF " + Environment.NewLine;
                    sql += " AND A.GOODSNORF = B.CHGSRCGOODSNORF " + Environment.NewLine;
                    sql += " AND A.GOODSMAKERCDRF = B.GOODSMAKERCDRF " + Environment.NewLine;
                    sql += " AND B.MASTERDIVCDRF = 1 " + Environment.NewLine;
                }
                sql += " WHERE A.ENTERPRISECODERF=@FINDENTERPRISECODE AND B.LOGICALDELETECODERF=@FINDLOGICALDELETECODERF ";
                sql += " ORDER BY A.ENTERPRISECODERF, A.GOODSMAKERCDRF, A.GOODSNORF, A.WAREHOUSECODERF ";
                sqlCommand = new SqlCommand(sql, sqlConnection);

                //Prameter�I�u�W�F�N�g�̍쐬
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODERF", SqlDbType.Int);


                //Parameter�I�u�W�F�N�g�֒l�ݒ�
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterPriseCode);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);

                sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitInquiry);
                // �ǂݍ���
                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    StockWork _stockWork = new StockWork();
                    MeijiGoodsStockWork meijiGoodsStockWork = new MeijiGoodsStockWork();

                    _stockWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                    _stockWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                    _stockWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                    _stockWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                    _stockWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                    _stockWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                    _stockWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                    _stockWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                    _stockWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
                    _stockWork.WarehouseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSECODERF"));
                    _stockWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
                    _stockWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
                    _stockWork.StockUnitPriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCKUNITPRICEFLRF"));
                    _stockWork.SupplierStock = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SUPPLIERSTOCKRF"));
                    _stockWork.AcpOdrCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("ACPODRCOUNTRF"));
                    _stockWork.MonthOrderCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("MONTHORDERCOUNTRF"));
                    _stockWork.SalesOrderCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESORDERCOUNTRF"));
                    _stockWork.StockDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKDIVRF"));
                    _stockWork.MovingSupliStock = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("MOVINGSUPLISTOCKRF"));
                    _stockWork.ShipmentPosCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SHIPMENTPOSCNTRF"));
                    _stockWork.StockTotalPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKTOTALPRICERF"));
                    _stockWork.LastStockDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("LASTSTOCKDATERF"));
                    _stockWork.LastSalesDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("LASTSALESDATERF"));
                    _stockWork.LastInventoryUpdate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("LASTINVENTORYUPDATERF"));
                    _stockWork.MinimumStockCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("MINIMUMSTOCKCNTRF"));
                    _stockWork.MaximumStockCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("MAXIMUMSTOCKCNTRF"));
                    _stockWork.NmlSalOdrCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("NMLSALODRCOUNTRF"));
                    _stockWork.SalesOrderUnit = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESORDERUNITRF"));
                    _stockWork.StockSupplierCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKSUPPLIERCODERF"));
                    _stockWork.GoodsNoNoneHyphen = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNONONEHYPHENRF"));
                    _stockWork.WarehouseShelfNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSESHELFNORF"));
                    _stockWork.DuplicationShelfNo1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DUPLICATIONSHELFNO1RF"));
                    _stockWork.DuplicationShelfNo2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DUPLICATIONSHELFNO2RF"));
                    _stockWork.PartsManagementDivide1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PARTSMANAGEMENTDIVIDE1RF"));
                    _stockWork.PartsManagementDivide2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PARTSMANAGEMENTDIVIDE2RF"));
                    _stockWork.StockNote1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKNOTE1RF"));
                    _stockWork.StockNote2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKNOTE2RF"));
                    _stockWork.ShipmentCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SHIPMENTCNTRF"));
                    _stockWork.ArrivalCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("ARRIVALCNTRF"));
                    _stockWork.StockCreateDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("STOCKCREATEDATERF"));
                    _stockWork.UpdateDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("UPDATEDATERF"));

                    meijiGoodsStockWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
                    meijiGoodsStockWork.OldGoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
                    meijiGoodsStockWork.NewGoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CHGDESTGOODSNORF"));
                    stockList.Add(_stockWork);
                    goodsNoKey = meijiGoodsStockWork.GoodsMakerCd.ToString() + "-" + meijiGoodsStockWork.OldGoodsNo.Trim();
                    if (!goodsNoAllDic.ContainsKey(goodsNoKey))
                    {
                        goodsNoAllDic.Add(goodsNoKey, meijiGoodsStockWork);
                    }
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (myReader != null)
                    if (!myReader.IsClosed) myReader.Close();
                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }
            return status;
        }
        #endregion

        #region �݌Ƀ��[�N��Clone
        /// <summary>
        /// ���[�N��Clone
        /// </summary>
        /// <param name="work">�݌Ƀ��[�N</param>
        /// <remarks>
        /// <br>Programmer  : �i�N</br>
        /// <br>Date        : 2015/01/26</br>
        /// </remarks>
        private StockWork CloneStockWork(StockWork work)
        {
            StockWork copyStockWork = new StockWork();

            copyStockWork.CreateDateTime = work.CreateDateTime;
            copyStockWork.UpdateDateTime = work.UpdateDateTime;
            copyStockWork.EnterpriseCode = work.EnterpriseCode;
            copyStockWork.FileHeaderGuid = work.FileHeaderGuid;
            copyStockWork.UpdEmployeeCode = work.UpdEmployeeCode;
            copyStockWork.UpdAssemblyId1 = work.UpdAssemblyId1;
            copyStockWork.UpdAssemblyId2 = work.UpdAssemblyId2;
            copyStockWork.LogicalDeleteCode = work.LogicalDeleteCode;
            copyStockWork.SectionCode = work.SectionCode;
            copyStockWork.WarehouseCode = work.WarehouseCode;
            copyStockWork.GoodsMakerCd = work.GoodsMakerCd;
            copyStockWork.GoodsNo = work.GoodsNo;
            copyStockWork.StockUnitPriceFl = work.StockUnitPriceFl;
            copyStockWork.SupplierStock = work.SupplierStock;
            copyStockWork.AcpOdrCount = work.AcpOdrCount;
            copyStockWork.MonthOrderCount = work.MonthOrderCount;
            copyStockWork.SalesOrderCount = work.SalesOrderCount;
            copyStockWork.StockDiv = work.StockDiv;
            copyStockWork.MovingSupliStock = work.MovingSupliStock;
            copyStockWork.ShipmentPosCnt = work.ShipmentPosCnt;
            copyStockWork.StockTotalPrice = work.StockTotalPrice;
            copyStockWork.LastStockDate = work.LastStockDate;
            copyStockWork.LastSalesDate = work.LastSalesDate;
            copyStockWork.LastInventoryUpdate = work.LastInventoryUpdate;
            copyStockWork.MinimumStockCnt = work.MinimumStockCnt;
            copyStockWork.MaximumStockCnt = work.MaximumStockCnt;
            copyStockWork.NmlSalOdrCount = work.NmlSalOdrCount;
            copyStockWork.SalesOrderUnit = work.SalesOrderUnit;
            copyStockWork.StockSupplierCode = work.StockSupplierCode;
            copyStockWork.GoodsNoNoneHyphen = work.GoodsNoNoneHyphen;
            copyStockWork.WarehouseShelfNo = work.WarehouseShelfNo;
            copyStockWork.DuplicationShelfNo1 = work.DuplicationShelfNo1;
            copyStockWork.DuplicationShelfNo2 = work.DuplicationShelfNo2;
            copyStockWork.PartsManagementDivide1 = work.PartsManagementDivide1;
            copyStockWork.PartsManagementDivide2 = work.PartsManagementDivide2;
            copyStockWork.StockNote1 = work.StockNote1;
            copyStockWork.StockNote2 = work.StockNote2;
            copyStockWork.ShipmentCnt = work.ShipmentCnt;
            copyStockWork.ArrivalCnt = work.ArrivalCnt;
            copyStockWork.StockCreateDate = work.StockCreateDate;
            copyStockWork.UpdateDate = work.UpdateDate;

            return copyStockWork;
        }
        #endregion

        #region �݌Ƀ}�X�^�ɐV���i�Ԃ̕ϊ�
        /// <summary>
        /// �݌Ƀ}�X�^�ɐV���i�Ԃ̕ϊ�����
        /// </summary>
        /// <param name="goodsNoKey">���[�J�[�{�i�ԃL�[</param>
        /// <param name="goodsChgWork">���i���[�N</param>
        /// <param name="goodsPriceUWork">���i���[�N</param>
        /// <param name="stockWork">�݌Ƀ��[�N</param>
        /// <param name="goodsNoAllDic">�V���i�Ԃ�Dictionary</param>
        /// <param name="message">�G���[���b�Z�[�W</param>
        /// <param name="makerDic">���[�J�[�R�[�hDictionary</param>
        /// <param name="wareHouseDic">�q��Dictionary</param>
        /// <param name="blGoodsDic">BL���i�R�[�hDictionary</param>
        /// <param name="goodsChangeAllCndWorkWork">�������[�N</param>
        /// <param name="sectionDic">���_Dictionary</param>
        /// <param name="stockRowNo">�s�ԍ�</param>
        /// <param name="sqlConnection">�R�l�N�V����</param>
        /// <param name="sqlTransaction">�g�����U�N�V����</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Programmer  : �i�N</br>
        /// <br>Date        : 2015/01/26</br>
        /// </remarks>
        private int StockMstChg(string goodsNoKey, GoodsUWork goodsChgWork, GoodsPriceUWork goodsPriceUWork, StockWork stockWork, Dictionary<string, MeijiGoodsStockWork> goodsNoAllDic,
            out string message, Dictionary<int, string> makerDic, Dictionary<int, string> wareHouseDic, Dictionary<int, string> blGoodsDic, Dictionary<string, string> sectionDic,
            GoodsChangeAllCndWorkWork goodsChangeAllCndWorkWork, int stockRowNo, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            // �G���[���b�Z�[�W
            message = string.Empty;
            string message2 = string.Empty;
            // ���X�g
            ArrayList changeWorkList = new ArrayList();
            ArrayList deletePartList = new ArrayList();
            CustomSerializeArrayList insertWorkList = new CustomSerializeArrayList();
            CustomSerializeArrayList stockAdjustCsList = new CustomSerializeArrayList();

            int logicalDeleteCode = 0;
            object stockWorkObj = null;
            try
            {
                logicalDeleteCode = stockWork.LogicalDeleteCode;
                // �V�i�ԍ݌Ƀ}�X�^�̔r���`�F�b�N
                status = this.SearchStockInfoProc(stockWork.EnterpriseCode, goodsNoAllDic[goodsNoKey].NewGoodsNo, stockWork.GoodsMakerCd, stockWork.WarehouseCode);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    //message = EXISTMSG; // DEL 2015/02/26 ���V�� Redmine#44209 ���b�Z�[�W�̕����Ή�
                    message = message = string.Format(GoodsNoChgCommonDB.EXISTMSG, "�݌Ƀ}�X�^"); ; // ADD 2015/02/26 ���V�� Redmine#44209 ���b�Z�[�W�̕����Ή�
                    status = (int)ConstantManagement.DB_Status.ctDB_DUPLICATE;
                }
                else if (status != (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                {
                    //message = NEWEXCEPTIONMSG; // DEL 2015/02/26 ���V�� Redmine#44209 ���b�Z�[�W�̕����Ή�
                    message = GoodsNoChgCommonDB.NEWEXCEPTIONMSG;// ADD 2015/02/26 ���V�� Redmine#44209 ���b�Z�[�W�̕����Ή�
                }
                else
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }

                // �݌Ƀ}�X�^�E�݌ɒ����E�݌ɒ������ׁA�݌Ɏ�t����o�^
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // ���i�ԍ폜
                    // �폜�f�[�^����
                    SetOldStockData(goodsNoKey, goodsChangeAllCndWorkWork, stockWork, goodsChgWork, goodsPriceUWork, 
                        goodsNoAllDic, makerDic, wareHouseDic, blGoodsDic, sectionDic, stockRowNo, out stockWorkObj);

                    if (stockWorkObj != null)
                    {
                        //----- ADD 2015/04/17 ���V�� Redmine#45436 ���i���g�p���ă}�X�^�̍폜/�o�^�����s���Ă���ӏ����O�L���b�`����Ή�------>>>>>
                        try
                        {
                        //----- ADD 2015/04/17 ���V�� Redmine#45436 ���i���g�p���ă}�X�^�̍폜/�o�^�����s���Ă���ӏ����O�L���b�`����Ή�------<<<<<
                            status = this._iStockAdjustDB.WriteBatch(ref stockWorkObj, out message2, ref sqlConnection, ref sqlTransaction);
                        //----- ADD 2015/04/17 ���V�� Redmine#45436 ���i���g�p���ă}�X�^�̍폜/�o�^�����s���Ă���ӏ����O�L���b�`����Ή�------>>>>>
                        }
                        catch (Exception ex)
                        {
                            base.WriteErrorLog(ex, "WriteBatch");
                            status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                        }
                        //----- ADD 2015/04/17 ���V�� Redmine#45436 ���i���g�p���ă}�X�^�̍폜/�o�^�����s���Ă���ӏ����O�L���b�`����Ή�------<<<<<
                    }

                    // �폜�̏ꍇ�ُ킪��������
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        // �r���ُ킪��������ꍇ
                        if (status == (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE
                            || status == (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE)
                        {
                            //message = DELETEERRMSG; // DEL 2015/02/26 ���V�� Redmine#44209 ���b�Z�[�W�̕����Ή�
                            message = string.Format(GoodsNoChgCommonDB.UPDATEFAIL, "�݌Ƀ}�X�^"); // ADD 2015/02/26 ���V�� Redmine#44209 ���b�Z�[�W�̕����Ή�
                        }
                        // ����ȊO�ُ�̏ꍇ
                        else
                        {
                            //message = OLDEXCEPTIONMSG; // DEL 2015/02/26 ���V�� Redmine#44209 ���b�Z�[�W�̕����Ή�
                            message = GoodsNoChgCommonDB.OLDEXCEPTIONMSG; // ADD 2015/02/26 ���V�� Redmine#44209 ���b�Z�[�W�̕����Ή�
                        }
                    }
                    // �V�i�ԓo�^
                    else
                    {
                        // �V�i�ԓo�^�p�f�[�^���� 
                        //SetNewStockData(ref stockWorkObj, goodsNoAllDic[goodsNoKey], logicalDeleteCode); // DEL ���R 2015/04/15 Redmine45436�̇�78
                        // ADD ���R 2015/04/15 Redmine45436�̇�78 ----->>>>>
                        SetNewStockData(ref stockWorkObj, goodsChangeAllCndWorkWork, goodsNoAllDic[goodsNoKey], logicalDeleteCode,
                            goodsChgWork, goodsPriceUWork, makerDic, wareHouseDic, blGoodsDic, sectionDic, stockRowNo);
                        // ADD ���R 2015/04/15 Redmine45436�̇�78 -----<<<<<

                        if (stockWorkObj != null)
                        {
                            //----- ADD 2015/04/17 ���V�� Redmine#45436 ���i���g�p���ă}�X�^�̍폜/�o�^�����s���Ă���ӏ����O�L���b�`����Ή�------>>>>>
                            try
                            {
                            //----- ADD 2015/04/17 ���V�� Redmine#45436 ���i���g�p���ă}�X�^�̍폜/�o�^�����s���Ă���ӏ����O�L���b�`����Ή�------<<<<<
                                status = this._iStockAdjustDB.WriteBatch(ref stockWorkObj, out message2, ref sqlConnection, ref sqlTransaction);
                            //----- ADD 2015/04/17 ���V�� Redmine#45436 ���i���g�p���ă}�X�^�̍폜/�o�^�����s���Ă���ӏ����O�L���b�`����Ή�------>>>>>
                            }
                            catch (Exception ex)
                            {
                                base.WriteErrorLog(ex, "WriteBatch");
                                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                            }
                            //----- ADD 2015/04/17 ���V�� Redmine#45436 ���i���g�p���ă}�X�^�̍폜/�o�^�����s���Ă���ӏ����O�L���b�`����Ή�------<<<<<
                        }

                        // ����WriteBatch���\�b�h�̓o�^�����͔r���`�F�b�N�G���[���Ȃ�
                        if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            //message = NEWEXCEPTIONMSG; // DEL 2015/02/26 ���V�� Redmine#44209 ���b�Z�[�W�̕����Ή�
                            message = GoodsNoChgCommonDB.NEWEXCEPTIONMSG;// ADD 2015/02/26 ���V�� Redmine#44209 ���b�Z�[�W�̕����Ή�
                        }
                        else
                        {
                            // ����WriteBatch���\�b�h�̓o�^�����͘_���폜�敪��L���ɂȂ�ł��Ȃ��̂ŁA���̂܂܍X�VOK
                            if (logicalDeleteCode == 1)
                            {
                                //message = DELETEMSG; // DEL 2015/02/26 ���V�� Redmine#44209 ���b�Z�[�W�̕����Ή�
                                message = GoodsNoChgCommonDB.DELETEMSG; // ADD 2015/02/26 ���V�� Redmine#44209 ���b�Z�[�W�̕����Ή�
                            }
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "MeijiGoodsStockDB.StockMstChg");
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
       
            return status;
        }
        #endregion

        #region �V�i�ԍ݌ɏ��̍쐬
        /// <summary>
        /// �V�i�ԍ݌ɏ��̍쐬
        /// </summary>
        /// <param name="stockObj">�߂�Object</param>
        /// <param name="goodsChangeAllCndWorkWork">�ϊ��������[�N</param>
        /// <param name="meijiGoodsStockWork">�V���i�ԑΉ����[�N</param>
        /// <param name="logicalDeleteCode">�_���폜�敪</param>
        /// <param name="goodsChgWork">���i��񃏁[�N</param>
        /// <param name="goodsPriceUWork">���i��񃏁[�N</param>
        /// <param name="makerDic">���[�J�[���Dictionary</param>
        /// <param name="wareHouseDic">�q�ɏ��Dictionary</param>
        /// <param name="blGoodsDic">BL�R�[�h���Dictionary</param>
        /// <param name="sectionDic">���_���Dictionary</param>
        /// <param name="rowNo">�s�ԍ�</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Programmer  : �i�N</br>
        /// <br>Date        : 2015/01/26</br>
        /// <br>Update Note : 2015/04/15 ���R</br>
        /// <br>            : Redmine#45436 ��78�݌Ɏ󕥗����f�[�^�o�^�s��̏C��</br>
        /// </remarks>
        //private void SetNewStockData(ref object stockObj, MeijiGoodsStockWork meijiGoodsStockWork, int logicalDeleteCode)�@// DEL ���R 2015/04/15 Redmine45436�̇�78
        // ADD ���R 2015/04/15 Redmine45436�̇�78 ----->>>>>
        private void SetNewStockData(ref object stockObj,GoodsChangeAllCndWorkWork goodsChangeAllCndWorkWork, MeijiGoodsStockWork meijiGoodsStockWork, int logicalDeleteCode,
                     GoodsUWork goodsChgWork, GoodsPriceUWork goodsPriceUWork, Dictionary<int, string> makerDic, Dictionary<int, string> wareHouseDic,
                     Dictionary<int, string> blGoodsDic, Dictionary<string, string> sectionDic, int rowNo)
        // ADD ���R 2015/04/15 Redmine45436�̇�78 -----<<<<<
        {
            CustomSerializeArrayList stockAdjustCsList = (CustomSerializeArrayList)stockObj;
            CustomSerializeArrayList insertWorkList = null;

            ArrayList stockAdjustWorkList = new ArrayList();// �݌ɒ����f�[�^���X�g
            ArrayList stockAdjustDtlWorkList = new ArrayList();// �݌ɒ������׃f�[�^���X�g
            ArrayList stockOldWorkList = new ArrayList();// �݌Ƀf�[�^���X�g

            StockAdjustWork stockAdjustWork = new StockAdjustWork();
            StockAdjustDtlWork stockAdjustDtlWork = new StockAdjustDtlWork();
            StockWork stockWork = new StockWork();

            // �݌ɒ����f�[�^�A�݌ɒ������׃f�[�^�A�݌Ƀf�[�^���X�g�擾
            if (stockAdjustCsList != null && stockAdjustCsList.Count > 0)
            {
                insertWorkList = (CustomSerializeArrayList)stockAdjustCsList[0];
            }
            if (insertWorkList != null && insertWorkList.Count > 0)
            {
                stockAdjustWorkList = (ArrayList)insertWorkList[0];
                stockAdjustDtlWorkList = (ArrayList)insertWorkList[1];
                stockOldWorkList = (ArrayList)insertWorkList[2];
            }

            // �݌ɒ����A�݌ɒ������ׁA�݌Ƀ��[�N�̎擾
            // DEL ���R 2015/04/15 Redmine45436�̇�78 ----->>>>>
            //if (stockAdjustWorkList != null && stockAdjustWorkList.Count > 0)
            //{
            //    stockAdjustWork = (StockAdjustWork)stockAdjustWorkList[0];
            //}
            //if (stockAdjustDtlWorkList != null && stockAdjustDtlWorkList.Count > 0)
            //{
            //    stockAdjustDtlWork = (StockAdjustDtlWork)stockAdjustDtlWorkList[0];
            //}
            // DEL ���R 2015/04/15 Redmine45436�̇�78 -----<<<<<
            if (stockOldWorkList != null && stockOldWorkList.Count > 0)
            {
                stockWork = (StockWork)stockOldWorkList[0];
            }

            #region DEL
            //----- DEL ���R 2015/04/15 Redmine45436�̇�78 ----->>>>>
            //double allCount = stockWork.SupplierStock + stockWork.SalesOrderCount + stockWork.ShipmentCnt; 

            //if (allCount > 0) 
            //{ 
                //// �݌ɒ����f�[�^
                //stockAdjustWork.UpdateDateTime = DateTime.MinValue;
                //stockAdjustWork.StockAdjustSlipNo = 0;
                //// �݌ɒ������׃f�[�^
                //stockAdjustDtlWork.StockAdjustSlipNo = 0;
                //stockAdjustDtlWork.UpdateDateTime = DateTime.MinValue;
                //stockAdjustDtlWork.AdjustCount = stockWork.SupplierStock;
                //stockAdjustDtlWork.GoodsNo = meijiGoodsStockWork.NewGoodsNo;
            //}

            //// �݌Ƀf�[�^
            //stockWork.GoodsNo = meijiGoodsStockWork.NewGoodsNo;
            //stockWork.GoodsNoNoneHyphen = meijiGoodsStockWork.NewGoodsNo.Replace("-", "");
            //stockWork.UpdateDateTime = DateTime.MinValue;
            //stockWork.LogicalDeleteCode = logicalDeleteCode;
            //stockWork.MovingSupliStock = 0;
            //stockWork.AcpOdrCount = 0;
            //stockWork.ArrivalCnt = 0;
            //stockWork.SupplierStock = stockWork.ShipmentPosCnt + stockWork.ShipmentCnt;
            //----- DEL ���R 2015/04/15 Redmine45436�̇�78 -----<<<<<
            #endregion

            // ADD ���R 2015/04/15 Redmine45436�̇�78 ----->>>>>
            #region  �݌Ƀf�[�^�␳
            // �i�ԁ��V�i��
            stockWork.GoodsNo = meijiGoodsStockWork.NewGoodsNo;
            stockWork.GoodsNoNoneHyphen = meijiGoodsStockWork.NewGoodsNo.Replace("-", "");
            stockWork.UpdateDateTime = DateTime.MinValue;
            stockWork.LogicalDeleteCode = logicalDeleteCode;
            // �ړ����d���݌ɐ��F�[���Œ�
            stockWork.MovingSupliStock = 0;
            // �󒍐��F�[���Œ�
            stockWork.AcpOdrCount = 0;
            // ���א�(���v��)�F�[���Œ�
            stockWork.ArrivalCnt = 0;
            // �d���݌ɐ��F���i�ԍ݌ɂ̏o�׉\��+�o�א�(���v��)
            stockWork.SupplierStock = stockWork.ShipmentPosCnt + stockWork.ShipmentCnt;
            #endregion

            // DEL ���R 2015/04/17 Redmine45436�̇�78 ----->>>>>
            //// �o�׉\���Əo�א�(���v��)�ɂ����ꂪ�[���ł͂Ȃ��ꍇ�A�݌ɒ����f�[�^�쐬����
            //if (stockWork.ShipmentPosCnt != 0 || stockWork.ShipmentCnt != 0)
            // DEL ���R 2015/04/17 Redmine45436�̇�78 -----<<<<<
            // ADD ���R 2015/04/17 Redmine45436�̇�78 ----->>>>>
            // �V�i�ԍ݌ɂ̎d���݌ɐ����[���ł͂Ȃ��ꍇ�̂݁A�݌ɒ����f�[�^�쐬����
            if (stockWork.SupplierStock != 0)
            // ADD ���R 2015/04/17 Redmine45436�̇�78 -----<<<<<
            {
                #region �݌ɒ����f�[�^�̍쐬
                if (stockAdjustWorkList != null && stockAdjustWorkList.Count > 0)
                {
                    stockAdjustWork = (StockAdjustWork)stockAdjustWorkList[0];
                    stockAdjustWork.UpdateDateTime = DateTime.MinValue;
                    stockAdjustWork.StockAdjustSlipNo = 0;
                }
                else
                {
                    if (stockAdjustWorkList == null)
                    {
                        stockAdjustWorkList = new ArrayList();
                    }
                    stockAdjustWork.EnterpriseCode = stockWork.EnterpriseCode;
                    stockAdjustWork.UpdateDateTime = DateTime.MinValue;
                    stockAdjustWork.SectionCode = goodsChangeAllCndWorkWork.LoginSectionCode.Trim();
                    stockAdjustWork.StockAdjustSlipNo = 0;
                    stockAdjustWork.AcPaySlipCd = 42;
                    stockAdjustWork.AcPayTransCd = 30;
                    stockAdjustWork.AdjustDate = DateTime.Now;
                    stockAdjustWork.InputDay = DateTime.Now;
                    stockAdjustWork.StockSectionCd = stockWork.SectionCode;
                    if (sectionDic.ContainsKey(stockWork.SectionCode.Trim()))
                    {
                        stockAdjustWork.StockSectionGuideNm = sectionDic[stockWork.SectionCode.Trim()].Trim();
                    }
                    stockAdjustWork.StockInputCode = goodsChangeAllCndWorkWork.LoginEmpleeCode;
                    stockAdjustWork.StockInputName = goodsChangeAllCndWorkWork.LoginEmpleeName;
                    stockAdjustWork.StockAgentCode = goodsChangeAllCndWorkWork.LoginEmpleeCode;
                    stockAdjustWork.StockAgentName = goodsChangeAllCndWorkWork.LoginEmpleeName;
                    stockAdjustWork.StockSubttlPrice = 0;
                    //stockAdjustWork.SlipNote = ""; // DEL ���R 2015/04/27 ���r���[���ʑΉ�

                    stockAdjustWorkList.Add(stockAdjustWork);
                } 
                #endregion

                #region �݌ɒ������׃f�[�^�̍쐬
                if (stockAdjustDtlWorkList != null && stockAdjustDtlWorkList.Count > 0)
                {
                    stockAdjustDtlWork = (StockAdjustDtlWork)stockAdjustDtlWorkList[0];
                    stockAdjustDtlWork.StockAdjustSlipNo = 0;
                    stockAdjustDtlWork.UpdateDateTime = DateTime.MinValue;
                    stockAdjustDtlWork.AdjustCount = stockWork.SupplierStock;
                    stockAdjustDtlWork.GoodsNo = meijiGoodsStockWork.NewGoodsNo;
                }
                else
                {
                    if (stockAdjustDtlWorkList == null)
                    {
                        stockAdjustDtlWorkList = new ArrayList();
                    }
                    stockAdjustDtlWork.UpdateDateTime = DateTime.MinValue;
                    //stockAdjustDtlWork.UpdateDateTime = DateTime.MinValue; // DEL ���R 2015/04/27 ���r���[���ʑΉ�
                    stockAdjustDtlWork.EnterpriseCode = stockWork.EnterpriseCode;
                    // ���_�̃Z�b�g
                    stockAdjustDtlWork.SectionCode = goodsChangeAllCndWorkWork.LoginSectionCode;
                    if (sectionDic.ContainsKey(goodsChangeAllCndWorkWork.LoginSectionCode.Trim()))
                    {
                        stockAdjustDtlWork.SectionGuideNm = sectionDic[goodsChangeAllCndWorkWork.LoginSectionCode.Trim()].Trim();
                    }
                    stockAdjustDtlWork.StockAdjustSlipNo = 0;
                    stockAdjustDtlWork.StockAdjustRowNo = rowNo;
                    stockAdjustDtlWork.SupplierFormalSrc = 0;
                    stockAdjustDtlWork.StockSlipDtlNumSrc = 0;
                    stockAdjustDtlWork.AcPaySlipCd = 42;
                    stockAdjustDtlWork.AcPayTransCd = 30;
                    stockAdjustDtlWork.AdjustDate = DateTime.Now;
                    stockAdjustDtlWork.InputDay = DateTime.Now;
                    stockAdjustDtlWork.StockUnitPriceFl = 0;
                    stockAdjustDtlWork.BfStockUnitPriceFl = 0;
                    stockAdjustDtlWork.GoodsMakerCd = stockWork.GoodsMakerCd;
                    if (makerDic.ContainsKey(stockWork.GoodsMakerCd))
                    {
                        stockAdjustDtlWork.MakerName = makerDic[stockWork.GoodsMakerCd];
                    }
                    stockAdjustDtlWork.AdjustCount = stockWork.SupplierStock;
                    stockAdjustDtlWork.DtlNote = "";
                    stockAdjustDtlWork.WarehouseCode = stockWork.WarehouseCode;
                    // �q�ɏ��̃Z�b�g
                    if (!string.IsNullOrEmpty(stockWork.WarehouseCode.Trim()))
                    {
                        int wareHouseCodeKey = Convert.ToInt32(stockWork.WarehouseCode.Trim());
                        if (wareHouseDic.ContainsKey(wareHouseCodeKey))
                        {
                            stockAdjustDtlWork.WarehouseName = wareHouseDic[wareHouseCodeKey];
                        }
                    }
                    stockAdjustDtlWork.WarehouseShelfNo = stockWork.WarehouseShelfNo;
                    stockAdjustDtlWork.StockPriceTaxExc = 0;
                    stockAdjustDtlWork.GoodsNo = stockWork.GoodsNo;

                    // ���i���̃Z�b�g
                    stockAdjustDtlWork.GoodsName = goodsChgWork.GoodsName;
                    stockAdjustDtlWork.BLGoodsCode = goodsChgWork.BLGoodsCode;
                    if (blGoodsDic.ContainsKey(stockAdjustDtlWork.BLGoodsCode))
                    {
                        stockAdjustDtlWork.BLGoodsFullName = blGoodsDic[stockAdjustDtlWork.BLGoodsCode];
                    }

                    // ���i���̃Z�b�g
                    stockAdjustDtlWork.ListPriceFl = goodsPriceUWork.ListPrice;
                    stockAdjustDtlWork.OpenPriceDiv = goodsPriceUWork.OpenPriceDiv;
                    stockAdjustDtlWorkList.Add(stockAdjustDtlWork);
                }
                #endregion
            }
            // ADD ���R 2015/04/17 Redmine45436�̇�78 ----->>>>>
            else
            {
                //�݌ɒ����̃f�[�^���X�g�Ɩ��׃��X�g�N���A����
                ArrayList emptyList = new ArrayList();
                object emptyObj = emptyList;
                CustomSerializeArrayList level01List = new CustomSerializeArrayList();
                level01List.Add(emptyObj); // [0]
                level01List.Add(emptyObj); // [1]
                object thirdObj = stockOldWorkList;
                level01List.Add(thirdObj); // [2]

                object level01Obj = level01List;
                CustomSerializeArrayList topList = new CustomSerializeArrayList();
                topList.Add(level01Obj);
                stockObj = topList;

                // �������̉��
                emptyList = null;
                emptyObj = null;
                thirdObj = null;
                level01List = null;
                level01Obj = null;
                topList = null;
            }
            // ADD ���R 2015/04/17 Redmine45436�̇�78 -----<<<<<
            // ADD ���R 2015/04/15 Redmine45436�̇�78 -----<<<<<
        }
        #endregion

        #region ���i�ԍ݌ɏ��̍쐬
        /// <summary>
        /// ���i�ԍ݌ɏ��̍쐬
        /// </summary>
        /// <param name="goodsNoKey">���[�J�[�{�i�Ԃ̃L�[</param>
        /// <param name="goodsChangeAllCndWorkWork">�������[�N</param>
        /// <param name="stockWork">�݌Ƀ��[�N</param>
        /// <param name="goodsChgWork">���i���[�N</param>
        /// <param name="goodsPriceUWork">���i���[�N</param>
        /// <param name="goodsNoAllDic">�V���i�ԑΉ�Dictionary</param>
        /// <param name="makerDic">���[�J�[Dictionary</param>
        /// <param name="wareHouseDic">�q��Dictionary</param>
        /// <param name="blGoodsDic">�a�k�R�[�hDictionary</param>
        /// <param name="sectionDic">���_Dictionary</param>
        /// <param name="rowNo">�݌ɒ������׍s�ԍ�</param>
        /// <param name="stockObj">�߂�Object</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Programmer  : �i�N</br>
        /// <br>Date        : 2015/01/26</br>
        /// <br>Update Note : 2015/04/15 ���R</br>
        /// <br>            : Redmine#45436 ��78�݌Ɏ󕥗����f�[�^�o�^�s��̏C��</br>
        /// </remarks>
        private void SetOldStockData(string goodsNoKey, GoodsChangeAllCndWorkWork goodsChangeAllCndWorkWork, StockWork stockWork, GoodsUWork goodsChgWork, 
            GoodsPriceUWork goodsPriceUWork, Dictionary<string, MeijiGoodsStockWork> goodsNoAllDic, Dictionary<int, string> makerDic, Dictionary<int, string> wareHouseDic, 
            Dictionary<int, string> blGoodsDic, Dictionary<string, string> sectionDic, int rowNo, out object stockObj)
        {
            ArrayList stockAdjustWorkList = new ArrayList();// �݌ɒ����f�[�^���X�g
            ArrayList stockAdjustDtlWorkList = new ArrayList();// �݌ɒ������׃f�[�^���X�g
            ArrayList stockOldWorkList = new ArrayList();// �݌Ƀf�[�^���X�g

            CustomSerializeArrayList insertWorkList = new CustomSerializeArrayList();
            CustomSerializeArrayList stockAdjustCsList = new CustomSerializeArrayList();

            StockAdjustWork stockAdjustWork = new StockAdjustWork();
            StockAdjustDtlWork stockAdjustDtlWork = new StockAdjustDtlWork();
            stockObj = null;

            // DEL ���R 2015/04/15 Redmine45436�̇�78 ----->>>>>
            //// �݌ɒ����f�[�^�E�݌ɒ������׃f�[�^�̍쐬
            //double allCount = stockWork.SupplierStock + stockWork.AcpOdrCount + stockWork.SalesOrderCount
            //        + stockWork.MovingSupliStock + stockWork.ShipmentCnt + stockWork.ArrivalCnt;
            // DEL ���R 2015/04/15 Redmine45436�̇�78 -----<<<<<

            #region �݌Ƀf�[�^�̍쐬
            stockWork.LogicalDeleteCode = 3;
            stockOldWorkList.Add(stockWork);
            #endregion

            // DEL ���R 2015/04/15 Redmine45436�̇�78 ----->>>>>
            //// �݌Ƀf�[�^�쐬
            //if (allCount > 0)
            // DEL ���R 2015/04/15 Redmine45436�̇�78 -----<<<<<
            // ADD ���R 2015/04/15 Redmine45436�̇�78 ----->>>>>
            // ���i�Ԍ��݌ɐ�������ꍇ�̂ݍ݌ɒ����f�[�^���쐬����
            if (stockWork.ShipmentPosCnt != 0)
            // ADD ���R 2015/04/15 Redmine45436�̇�78 -----<<<<<
            {
                #region �݌ɒ����f�[�^�̍쐬
                stockAdjustWork.UpdateDateTime = DateTime.MinValue;
                stockAdjustWork.EnterpriseCode = stockWork.EnterpriseCode;
                stockAdjustWork.SectionCode = goodsChangeAllCndWorkWork.LoginSectionCode.Trim();
                stockAdjustWork.AcPaySlipCd = 42;
                stockAdjustWork.AcPayTransCd = 30;
                stockAdjustWork.AdjustDate = DateTime.Now;
                stockAdjustWork.InputDay = DateTime.Now;
                stockAdjustWork.StockSectionCd = stockWork.SectionCode;
                if (sectionDic.ContainsKey(stockWork.SectionCode.Trim()))
                {
                    stockAdjustWork.StockSectionGuideNm = sectionDic[stockWork.SectionCode.Trim()].Trim();
                }
                stockAdjustWork.StockInputCode = goodsChangeAllCndWorkWork.LoginEmpleeCode;
                stockAdjustWork.StockInputName = goodsChangeAllCndWorkWork.LoginEmpleeName;
                stockAdjustWork.StockAgentCode = goodsChangeAllCndWorkWork.LoginEmpleeCode;
                stockAdjustWork.StockAgentName = goodsChangeAllCndWorkWork.LoginEmpleeName;
                stockAdjustWork.StockSubttlPrice = 0;
                //stockAdjustWork.SlipNote = ""; // DEL ���R 2015/04/27 ���r���[���ʑΉ�
                stockAdjustWorkList.Add(stockAdjustWork);
                #endregion

                #region �݌ɒ������׃f�[�^�̍쐬
                stockAdjustDtlWork.UpdateDateTime = DateTime.MinValue;
                stockAdjustDtlWork.EnterpriseCode = stockWork.EnterpriseCode;
                // ���_�̃Z�b�g
                stockAdjustDtlWork.SectionCode = goodsChangeAllCndWorkWork.LoginSectionCode;
                if (sectionDic.ContainsKey(goodsChangeAllCndWorkWork.LoginSectionCode.Trim()))
                {
                    stockAdjustDtlWork.SectionGuideNm = sectionDic[goodsChangeAllCndWorkWork.LoginSectionCode.Trim()].Trim();
                }
                stockAdjustDtlWork.StockAdjustRowNo = rowNo;
                stockAdjustDtlWork.SupplierFormalSrc = 0;
                stockAdjustDtlWork.StockSlipDtlNumSrc = 0;
                stockAdjustDtlWork.AcPaySlipCd = 42;
                stockAdjustDtlWork.AcPayTransCd = 30;
                stockAdjustDtlWork.AdjustDate = DateTime.Now;
                stockAdjustDtlWork.InputDay = DateTime.Now;
                stockAdjustDtlWork.StockUnitPriceFl = 0;
                stockAdjustDtlWork.BfStockUnitPriceFl = 0;
                stockAdjustDtlWork.GoodsMakerCd = stockWork.GoodsMakerCd;
                if (makerDic.ContainsKey(stockWork.GoodsMakerCd))
                {
                    stockAdjustDtlWork.MakerName = makerDic[stockWork.GoodsMakerCd];
                }
                //stockAdjustDtlWork.AdjustCount = (-1) * stockWork.SupplierStock; // DEL ���R 2015/04/15 Redmine45436�̇�78
                // ADD ���R 2015/04/15 Redmine45436�̇�78 ----->>>>>
                // �������F�d���݌ɐ��ˌ��݌ɐ��ɕύX
                stockAdjustDtlWork.AdjustCount = (-1) * stockWork.ShipmentPosCnt;
                // ADD ���R 2015/04/15 Redmine45436�̇�78 -----<<<<<

                stockAdjustDtlWork.DtlNote = "";
                stockAdjustDtlWork.WarehouseCode = stockWork.WarehouseCode;
                // �q�ɏ��̃Z�b�g
                if (!string.IsNullOrEmpty(stockWork.WarehouseCode.Trim()))
                {
                    int wareHouseCodeKey = Convert.ToInt32(stockWork.WarehouseCode.Trim());
                    if (wareHouseDic.ContainsKey(wareHouseCodeKey))
                    {
                        stockAdjustDtlWork.WarehouseName = wareHouseDic[wareHouseCodeKey];
                    }
                }
                stockAdjustDtlWork.WarehouseShelfNo = stockWork.WarehouseShelfNo;
                stockAdjustDtlWork.StockPriceTaxExc = 0;
                stockAdjustDtlWork.GoodsNo = stockWork.GoodsNo;

                // ���i���̃Z�b�g
                stockAdjustDtlWork.GoodsName = goodsChgWork.GoodsName;
                stockAdjustDtlWork.BLGoodsCode = goodsChgWork.BLGoodsCode;
                if (blGoodsDic.ContainsKey(stockAdjustDtlWork.BLGoodsCode))
                {
                    stockAdjustDtlWork.BLGoodsFullName = blGoodsDic[stockAdjustDtlWork.BLGoodsCode];
                }

                // ���i���̃Z�b�g
                stockAdjustDtlWork.ListPriceFl = goodsPriceUWork.ListPrice;
                stockAdjustDtlWork.OpenPriceDiv = goodsPriceUWork.OpenPriceDiv;
                stockAdjustDtlWorkList.Add(stockAdjustDtlWork);
                #endregion
            }

            #region ���i�ԍX�V�p�f�[�^�̃��X�g
            insertWorkList.Add(stockAdjustWorkList);
            insertWorkList.Add(stockAdjustDtlWorkList);
            insertWorkList.Add(stockOldWorkList);
            stockAdjustCsList.Add(insertWorkList);
            #endregion

            // �߂�l�Z�b�g
            stockObj = stockAdjustCsList;
        }
        #endregion
        #endregion

        #region ���i�}�X�^
        #region ���iWrite���[�N��Clone
        /// <summary>
        /// ���[�N��Clone
        /// </summary>
        /// <param name="work">���i���[�N</param>
        /// <returns></returns>
        private GoodsPriceUWork ClonePriceWork(GoodsPriceUWork work)
        {
            GoodsPriceUWork copyPriceWork = new GoodsPriceUWork();

            copyPriceWork.CreateDateTime = work.CreateDateTime;
            copyPriceWork.UpdateDateTime = work.UpdateDateTime;
            copyPriceWork.EnterpriseCode = work.EnterpriseCode;
            copyPriceWork.FileHeaderGuid = work.FileHeaderGuid;
            copyPriceWork.UpdEmployeeCode = work.UpdEmployeeCode;
            copyPriceWork.UpdAssemblyId1 = work.UpdAssemblyId1;
            copyPriceWork.UpdAssemblyId2 = work.UpdAssemblyId2;
            copyPriceWork.LogicalDeleteCode = work.LogicalDeleteCode;
            copyPriceWork.GoodsMakerCd = work.GoodsMakerCd;
            copyPriceWork.GoodsNo = work.GoodsNo;
            copyPriceWork.PriceStartDate = work.PriceStartDate;
            copyPriceWork.ListPrice = work.ListPrice;
            copyPriceWork.SalesUnitCost = work.SalesUnitCost;
            copyPriceWork.StockRate = work.StockRate;
            copyPriceWork.OpenPriceDiv = work.OpenPriceDiv;
            copyPriceWork.OfferDate = work.OfferDate;
            copyPriceWork.UpdateDate = work.UpdateDate;

            return copyPriceWork;
        }
        #endregion

        #region ���i����
        /// <summary>
        /// �w�肳�ꂽ�����̏��i���i�}�X�^���LIST��߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="GoodsPriceUWorkList">��������</param>
        /// <param name="goodsNoAllDic">�V���i�Ԃ�Dictionary</param>
        /// <param name="updateMode">�X�V���[�h</param>
        /// <param name="enterPriseCode">��ƃR�[�h</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note        : �w�肳�ꂽ�����̏��i���i�}�X�^���LIST��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer  : �i�N</br>
        /// <br>Date        : 2015/01/26</br>
        /// <br>Update Note: PMKOBETSU-4005 �d�a�d�΍�</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2020/06/18</br>
        public int SearchGoodsPriceProc(out ArrayList GoodsPriceUWorkList, ref Dictionary<string, MeijiGoodsStockWork> goodsNoAllDic, int updateMode, string enterPriseCode, 
            ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            GoodsPriceUWorkList = new ArrayList();
            string goodsNoKey = "";
            //----- ADD 2020/06/18 杍^ PMKOBETSU-4005 ---------->>>>>
            // �ϊ����Ăяo��
            ConvertDoubleRelease convertDoubleRelease = new ConvertDoubleRelease();

            // �ϊ���񏉊���
            convertDoubleRelease.ReleaseInitLib();
            //----- ADD 2020/06/18 杍^ PMKOBETSU-4005 ----------<<<<<
            try
            {
                sqlCommand = new SqlCommand(String.Empty, sqlConnection);
                sqlCommand.CommandText += CreateQueryString(ref sqlCommand, updateMode, enterPriseCode);
                // �N�G�����s���̃^�C���A�E�g���Ԃ�10���ɐݒ肷��
                sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitInquiry);
                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    // ���i���[�N�ƐV���i�ԃ��[�N�̍쐬
                    GoodsPriceUWork goodsPriceUWork = new GoodsPriceUWork();
                    MeijiGoodsStockWork meijiGoodsStockWork;
                    // �N���X�i�[���� Reader �� GoodsPriceUWork
                    //----- UPD 2020/06/18 杍^ PMKOBETSU-4005 ---------->>>>>
                    //CopyToGoodsPriceUWorkFromReader(ref myReader, out goodsPriceUWork, out meijiGoodsStockWork);
                    CopyToGoodsPriceUWorkFromReader(ref myReader, out goodsPriceUWork, out meijiGoodsStockWork, convertDoubleRelease);
                    //----- UPD 2020/06/18 杍^ PMKOBETSU-4005 ----------<<<<<
                    GoodsPriceUWorkList.Add(goodsPriceUWork);
                    goodsNoKey = meijiGoodsStockWork.GoodsMakerCd.ToString() + "-" + meijiGoodsStockWork.OldGoodsNo.Trim();
                    if (!goodsNoAllDic.ContainsKey(goodsNoKey))
                    {
                        goodsNoAllDic.Add(goodsNoKey, meijiGoodsStockWork);
                    }
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (Exception)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlCommand != null) sqlCommand.Dispose();
                if (myReader != null)
                {
                    if (!myReader.IsClosed) myReader.Close();
                    myReader.Dispose();
                }
                //----- ADD 2020/06/18 杍^ PMKOBETSU-4005 ---------->>>>>
                // ���
                convertDoubleRelease.Dispose();
                //----- ADD 2020/06/18 杍^ PMKOBETSU-4005 ----------<<<<<
            }
            return status;
        }
        #endregion

        #region [�N�G�������񐶐�]
        /// <summary>
        /// Search���������񐶐��{�����l�ݒ�
        /// </summary>
        /// <param name="sqlCommand">SqlCommand�I�u�W�F�N�g</param>
        /// <param name="updateMode">�X�V���[�h</param>
        /// <param name="enterPriseCode">��ƃR�[�h</param>
        /// <returns>�N�G��������</returns>
        /// <br>Note        : ���i���i�}�X�^�̌����p�N�G��������𐶐����Ė߂��܂�</br>
        /// <br>Programmer  : �i�N</br>
        /// <br>Date        : 2015/01/26</br>
        private string CreateQueryString(ref SqlCommand sqlCommand, int updateMode, string enterPriseCode)
        {
            string sqlText = String.Empty;

            sqlText += "SELECT" + Environment.NewLine;
            sqlText += " GOODSPRICEURF.CREATEDATETIMERF, " + Environment.NewLine;
            sqlText += " GOODSPRICEURF.UPDATEDATETIMERF, " + Environment.NewLine;
            sqlText += " GOODSPRICEURF.ENTERPRISECODERF, " + Environment.NewLine;
            sqlText += " GOODSPRICEURF.FILEHEADERGUIDRF, " + Environment.NewLine;
            sqlText += " GOODSPRICEURF.UPDEMPLOYEECODERF, " + Environment.NewLine;
            sqlText += " GOODSPRICEURF.UPDASSEMBLYID1RF, " + Environment.NewLine;
            sqlText += " GOODSPRICEURF.UPDASSEMBLYID2RF, " + Environment.NewLine;
            sqlText += " GOODSPRICEURF.LOGICALDELETECODERF, " + Environment.NewLine;
            sqlText += " GOODSPRICEURF.GOODSMAKERCDRF, " + Environment.NewLine;
            sqlText += " GOODSPRICEURF.GOODSNORF, " + Environment.NewLine;
            sqlText += " GOODSPRICEURF.PRICESTARTDATERF, " + Environment.NewLine;
            sqlText += " GOODSPRICEURF.LISTPRICERF, " + Environment.NewLine;
            sqlText += " GOODSPRICEURF.SALESUNITCOSTRF, " + Environment.NewLine;
            sqlText += " GOODSPRICEURF.STOCKRATERF, " + Environment.NewLine;
            sqlText += " GOODSPRICEURF.OPENPRICEDIVRF, " + Environment.NewLine;
            sqlText += " GOODSPRICEURF.OFFERDATERF, " + Environment.NewLine;
            sqlText += " GOODSPRICEURF.UPDATEDATERF, " + Environment.NewLine;
            sqlText += " B.CHGDESTGOODSNORF " + Environment.NewLine;
            sqlText += "FROM" + Environment.NewLine;
            sqlText += "  GOODSPRICEURF WITH (READUNCOMMITTED) " + Environment.NewLine;
            if (updateMode == 0)
            {
                sqlText += " INNER JOIN GOODSNOCHANGERF B WITH (READUNCOMMITTED) " + Environment.NewLine;
                sqlText += " ON GOODSPRICEURF.ENTERPRISECODERF = B.ENTERPRISECODERF " + Environment.NewLine;
                sqlText += " AND GOODSPRICEURF.GOODSNORF = B.CHGSRCGOODSNORF " + Environment.NewLine;
                sqlText += " AND GOODSPRICEURF.GOODSMAKERCDRF = B.GOODSMAKERCDRF " + Environment.NewLine;
            }
            else
            {
                sqlText += " INNER JOIN GOODSNOCHANGEERRDTRF B WITH (READUNCOMMITTED) " + Environment.NewLine;
                sqlText += " ON GOODSPRICEURF.ENTERPRISECODERF = B.ENTERPRISECODERF " + Environment.NewLine;
                sqlText += " AND GOODSPRICEURF.GOODSNORF = B.CHGSRCGOODSNORF " + Environment.NewLine;
                sqlText += " AND GOODSPRICEURF.GOODSMAKERCDRF = B.GOODSMAKERCDRF " + Environment.NewLine;
                sqlText += " AND B.MASTERDIVCDRF = 1 " + Environment.NewLine;
            }
            sqlText += "WHERE" + Environment.NewLine;
            sqlText += "  GOODSPRICEURF.ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;

            // ��ƃR�[�h
            SqlParameter findparaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
            findparaEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterPriseCode);

            //�_���폜�敪
            sqlText += " AND B.LOGICALDELETECODERF = @FINDLOGICALDELETECODE " + Environment.NewLine;
            SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
            paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);
            sqlText += " ORDER BY GOODSPRICEURF.ENTERPRISECODERF, GOODSPRICEURF.GOODSMAKERCDRF, GOODSPRICEURF.GOODSNORF, GOODSPRICEURF.PRICESTARTDATERF ";

            return sqlText;
        }
        #endregion

        #region [�N���X�i�[����]
        /// <summary>
        /// �N���X�i�[���� Reader �� GoodsPriceUWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <param name="wkGoodsPriceUWork">���i���[�N</param>
        /// <param name="meijiGoodsStockWork">�V���i�ԑΉ����[�N</param>
        /// <param name="convertDoubleRelease">���l�ϊ����i</param>
        /// <returns>GoodsPriceUWork</returns>
        /// <remarks>
        /// <br>Programmer  : �i�N</br>
        /// <br>Date        : 2015/01/26</br>
        /// <br>Update Note: PMKOBETSU-4005 �d�a�d�΍�</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2020/06/18</br>
        /// </remarks>
        //----- UPD 2020/06/18 杍^ PMKOBETSU-4005 ---------->>>>>
        //private void CopyToGoodsPriceUWorkFromReader(ref SqlDataReader myReader, out GoodsPriceUWork wkGoodsPriceUWork, out MeijiGoodsStockWork meijiGoodsStockWork)
        private void CopyToGoodsPriceUWorkFromReader(ref SqlDataReader myReader, out GoodsPriceUWork wkGoodsPriceUWork, out MeijiGoodsStockWork meijiGoodsStockWork, ConvertDoubleRelease convertDoubleRelease)
        //----- UPD 2020/06/18 杍^ PMKOBETSU-4005 ----------<<<<<
        {
            wkGoodsPriceUWork = new GoodsPriceUWork();
            meijiGoodsStockWork = new MeijiGoodsStockWork();

            wkGoodsPriceUWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
            wkGoodsPriceUWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
            wkGoodsPriceUWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
            wkGoodsPriceUWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
            wkGoodsPriceUWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
            wkGoodsPriceUWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
            wkGoodsPriceUWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
            wkGoodsPriceUWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
            wkGoodsPriceUWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
            wkGoodsPriceUWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
            wkGoodsPriceUWork.PriceStartDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("PRICESTARTDATERF"));
            //----- UPD 2020/06/18 杍^ PMKOBETSU-4005 ---------->>>>>
            //wkGoodsPriceUWork.ListPrice = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("LISTPRICERF"));
            convertDoubleRelease.EnterpriseCode = wkGoodsPriceUWork.EnterpriseCode;
            convertDoubleRelease.GoodsMakerCd = wkGoodsPriceUWork.GoodsMakerCd;
            convertDoubleRelease.GoodsNo = wkGoodsPriceUWork.GoodsNo;
            convertDoubleRelease.ConvertSetParam = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("LISTPRICERF"));

            // �ϊ��������s
            convertDoubleRelease.ReleaseProc();

            wkGoodsPriceUWork.ListPrice = convertDoubleRelease.ConvertInfParam.ConvertGetParam;
            //----- UPD 2020/06/18 杍^ PMKOBETSU-4005 ----------<<<<<
            wkGoodsPriceUWork.SalesUnitCost = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESUNITCOSTRF"));
            wkGoodsPriceUWork.StockRate = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCKRATERF"));
            wkGoodsPriceUWork.OpenPriceDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OPENPRICEDIVRF"));
            wkGoodsPriceUWork.OfferDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("OFFERDATERF"));
            wkGoodsPriceUWork.UpdateDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("UPDATEDATERF"));

            meijiGoodsStockWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
            meijiGoodsStockWork.OldGoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
            meijiGoodsStockWork.NewGoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CHGDESTGOODSNORF"));
        }
        #endregion

        #region ���i�}�X�^�ɐV���i�Ԃ̕ϊ�
        /// <summary>
        /// ���i�}�X�^�ɐV���i�Ԃ̕ϊ�����
        /// </summary>
        /// <param name="goodsNoKey">���[�J�[�{�i�ԃL�[</param>
        /// <param name="goodsChgWork">���i���[�N</param>
        /// <param name="goodsPriceUWork">���i���[�N</param>
        /// <param name="goodsNoAllDic">���i��Dictionary</param>
        /// <param name="message">���b�Z�[�W</param>
        /// <param name="sqlConnection">�R�l�N�V����</param>
        /// <param name="sqlTransaction">�g�����U�N�V����</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Programmer  : �i�N</br>
        /// <br>Date        : 2015/01/26</br>
        /// <br>Note        : Redmine#45436 ���i���g�p���ă}�X�^�̍폜/�o�^�����s���Ă���ӏ����O�L���b�`����Ή�</br>
        /// <br>Programmer  : ���V��</br>
        /// <br>Date        : 2015/04/17</br>
        /// </remarks>
        private int PriceMstChg(string goodsNoKey, GoodsUWork goodsChgWork, GoodsPriceUWork goodsPriceUWork, Dictionary<string, MeijiGoodsStockWork> goodsNoAllDic, 
            out string message, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            ArrayList addWorkList = new ArrayList();
            Dictionary<string, GoodsPriceUWork> goodsPriceGetDic = new Dictionary<string, GoodsPriceUWork>();
            int logicalDeleteDiv = 0;
            // �X�V���X�g
            ArrayList changeWorkList = new ArrayList();
            ArrayList deleteWorkList = new ArrayList();
            // �ǉ����X�g
            ArrayList insertWorkList = new ArrayList();
            ArrayList insertErrorWorkList = new ArrayList();
            message = "";

            try
            {
                // ���i�Ԃ̍폜
                deleteWorkList.Add(goodsPriceUWork);
                //----- ADD 2015/04/17 ���V�� Redmine#45436 ���i���g�p���ă}�X�^�̍폜/�o�^�����s���Ă���ӏ����O�L���b�`����Ή�------>>>>>
                try
                {
                    //----- ADD 2015/04/17 ���V�� Redmine#45436 ���i���g�p���ă}�X�^�̍폜/�o�^�����s���Ă���ӏ����O�L���b�`����Ή�------<<<<<
                    status = this._iGoodsPriceUDB.DeleteGoodsPriceProc(deleteWorkList, ref sqlConnection, ref sqlTransaction);
                    //----- ADD 2015/04/17 ���V�� Redmine#45436 ���i���g�p���ă}�X�^�̍폜/�o�^�����s���Ă���ӏ����O�L���b�`����Ή�------>>>>>
                }
                catch (Exception ex)
                {
                    base.WriteErrorLog(ex, "DeleteGoodsPriceProc");
                    status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                }
                //----- ADD 2015/04/17 ���V�� Redmine#45436 ���i���g�p���ă}�X�^�̍폜/�o�^�����s���Ă���ӏ����O�L���b�`����Ή�------<<<<<
                deleteWorkList.Clear();

                // �폜�̏ꍇ�ُ킪��������
                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // �r���ُ킪��������ꍇ
                    if (status == (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE
                        || status == (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE)
                    {
                        //message = DELETEERRMSG; // DEL 2015/02/26 ���V�� Redmine#44209 ���b�Z�[�W�̕����Ή�
                        message = string.Format(GoodsNoChgCommonDB.UPDATEFAIL, "���i�}�X�^"); // ADD 2015/02/26 ���V�� Redmine#44209 ���b�Z�[�W�̕����Ή�
                    }
                    // ����ȊO�ُ�̏ꍇ
                    else
                    {
                        //message = OLDEXCEPTIONMSG; // DEL 2015/02/26 ���V�� Redmine#44209 ���b�Z�[�W�̕����Ή�
                        message = GoodsNoChgCommonDB.OLDEXCEPTIONMSG; // ADD 2015/02/26 ���V�� Redmine#44209 ���b�Z�[�W�̕����Ή�
                    }
                }
                // �폜������̏ꍇ
                else
                {
                    // ���i�o�^�p�̃p�����[�^�ɃZ�b�g
                    // �����V�i�Ԃŕϊ�
                    goodsPriceUWork.GoodsNo = goodsNoAllDic[goodsNoKey].NewGoodsNo;
                    goodsPriceUWork.UpdateDateTime = DateTime.MinValue;
                    logicalDeleteDiv = goodsPriceUWork.LogicalDeleteCode;
                    insertWorkList.Add(goodsPriceUWork);

                    // �V�i�Ԃŉ��i�}�X�^�o�^
                    //----- ADD 2015/04/17 ���V�� Redmine#45436 ���i���g�p���ă}�X�^�̍폜/�o�^�����s���Ă���ӏ����O�L���b�`����Ή�------>>>>>
                    try
                    {
                    //----- ADD 2015/04/17 ���V�� Redmine#45436 ���i���g�p���ă}�X�^�̍폜/�o�^�����s���Ă���ӏ����O�L���b�`����Ή�------<<<<<
                        status = this._iGoodsPriceUDB.WriteGoodsPriceProc(ref insertWorkList, out insertErrorWorkList, ref sqlConnection, ref sqlTransaction);
                    //----- ADD 2015/04/17 ���V�� Redmine#45436 ���i���g�p���ă}�X�^�̍폜/�o�^�����s���Ă���ӏ����O�L���b�`����Ή�------>>>>>
                    }
                    catch (Exception ex)
                    {
                        base.WriteErrorLog(ex, "WriteGoodsPriceProc");
                        status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                    }
                    //----- ADD 2015/04/17 ���V�� Redmine#45436 ���i���g�p���ă}�X�^�̍폜/�o�^�����s���Ă���ӏ����O�L���b�`����Ή�------<<<<<

                    // �o�^���ُ킪��������ꍇ
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        // �r���ُ킪��������ꍇ
                        if (status == (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE
                            || status == (int)ConstantManagement.DB_Status.ctDB_DUPLICATE)
                        {
                            //message = EXISTMSG; // DEL 2015/02/26 ���V�� Redmine#44209 ���b�Z�[�W�̕����Ή�
                            message = string.Format(GoodsNoChgCommonDB.EXISTMSG, "���i�}�X�^"); // ADD 2015/02/26 ���V�� Redmine#44209 ���b�Z�[�W�̕����Ή�
                        }
                        // ����ȊO�ُ�̏ꍇ
                        else
                        {
                            //message = NEWEXCEPTIONMSG; // DEL 2015/02/26 ���V�� Redmine#44209 ���b�Z�[�W�̕����Ή�
                            message = GoodsNoChgCommonDB.NEWEXCEPTIONMSG;// ADD 2015/02/26 ���V�� Redmine#44209 ���b�Z�[�W�̕����Ή�
                        }
                    }
                    // �V�i�ԓo�^����̏ꍇ
                    else
                    {
                        // ���f�[�^���_���폜�̏ꍇ�A�V�i�Ԃ��_���폜���Ƃ��ĕύX����
                        if (logicalDeleteDiv == 1)
                        {
                            //message = DELETEMSG; // DEL 2015/02/26 ���V�� Redmine#44209 ���b�Z�[�W�̕����Ή�
                            message = GoodsNoChgCommonDB.DELETEMSG;// ADD 2015/02/26 ���V�� Redmine#44209 ���b�Z�[�W�̕����Ή�
                        }
                    }
                }
                return status;
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "MeijiGoodsStockDB.PriceMstChg");
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            return status;
        }
        #endregion
        #endregion
    }
}
