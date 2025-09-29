//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �����Y�Ə��i�Ǘ����}�X�^�ϊ�����
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
// �� �� ��  2015/04/17  �C�����e : Redmine#45436 ���i���g�p���ă}�X�^�̍폜/�o�^�����s���Ă���ӏ����O�L���b�`����Ή�
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

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// �����Y�Ə��i�Ǘ����}�X�^�ϊ�����DB�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note        : ���i�Ǘ����}�X�^�ϊ������̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer  : �i�N</br>
    /// <br>Date        : 2015/01/26</br>
    /// </remarks>
    [Serializable]
    public class MeijiGoodsMngDB : RemoteDB
    {
        # region ���b�Z�[�W
        //----- DEL 2015/02/26 ���V�� Redmine#44209 ���b�Z�[�W�̕����Ή�----->>>>>
        //// �r���`�F�b�N���b�Z�[�W
        //private const string EXISTMSG = "�ϊ���i�Ԃ����ɓo�^����܂���";
        //// �_���폜�`�F�b�N���b�Z�[�W
        //private const string DELETEMSG = "�_���폜�f�[�^";
        //// �X�V���s�̏ꍇ
        //private const string UPDATEFAIL = "�r���G���[�A�ϊ����i�Ԃ̍폜�Ɏ��s���܂���";
        //// �ϊ����ُ�G���[�̏ꍇ
        //private const string OLDEXCEPTIONMSG = "�폜�G���[�A�ϊ����i�Ԃ̍폜�Ɏ��s���܂���";
        //// �ϊ���ُ�G���[�̏ꍇ
        //private const string NEWEXCEPTIONMSG = "�o�^�G���[�A�ϊ���i�Ԃ̓o�^�Ɏ��s���܂���";
        //----- DEL 2015/02/26 ���V�� Redmine#44209 ���b�Z�[�W�̕����Ή�-----<<<<<
        # endregion

        #region �����̃����[�g
        private GoodsMngDB _iGoodsMngDB;
        private GoodsNoChgCommonDB _iGoodsNoChgCommonDB;
        #endregion

        #region MeijiGoodsStockDB
        /// <summary>
        /// ���i�Ǘ����}�X�^�ϊ������R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note        : ���ɂȂ�</br>
        /// <br>Programmer  : �i�N</br>
        /// <br>Date        : 2015/01/26</br>
        /// </remarks>
        public MeijiGoodsMngDB()
        {
            // ���i�Ǘ����
            if (this._iGoodsMngDB == null)
            {
                this._iGoodsMngDB = new GoodsMngDB();
            }
            // �i�ԕϊ���������
            if (this._iGoodsNoChgCommonDB == null)
            {
                this._iGoodsNoChgCommonDB = new GoodsNoChgCommonDB();
            }
        }
        #endregion

        #region ���i�Ǘ����}�X�^�̎捞����
        /// <summary>
        /// �w�肳�ꂽ��ƃR�[�h�̏��i�Ǘ����̑S�Ė߂鏈��
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note        : �w�肳�ꂽ��ƃR�[�h�̏��i�Ǘ����LIST��S�Ė߂��܂�</br>
        /// <br>Programmer  : �i�N</br>
        /// <br>Date        : 2015/01/26</br>
        /// </remarks>
        public int WriteIn(out object MngSuccessResultWork, out object MngErrorResultWork, out int updateCount, int updateMode, string enterPriseCode)
        {
            // �R�l�N�V����
            SqlConnection sqlConnection = null;
            // �g�����U�N�V����
            SqlTransaction sqlTransaction = null;
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            // ���i�Ǘ����}�X�^�ɐ����ȓo�^����f�[�^
            MngSuccessResultWork = null;
            ArrayList mngSuccessResultWorkList = new ArrayList();

            // ���i�Ǘ����}�X�^�Ɏ��s�ȓo�^����f�[�^
            MngErrorResultWork = null;
            ArrayList mngErrorResultWorkList = new ArrayList();

            // �o�^����
            updateCount = 0;

            try
            {
                // �R�l�N�V��������
                sqlConnection = this._iGoodsNoChgCommonDB.CreateSqlConnection(true);

                // �g�����U�N�V�����J�n
                sqlTransaction = this._iGoodsNoChgCommonDB.CreateTransaction(ref sqlConnection);

                // ���i�Ǘ����}�X�^�ϊ�����
                status = WriteInMngProc(out mngSuccessResultWorkList, out mngErrorResultWorkList, out updateCount, updateMode, enterPriseCode, ref sqlConnection, ref sqlTransaction);

                // �߂��郊�X�g
                MngSuccessResultWork = mngSuccessResultWorkList;
                MngErrorResultWork = mngErrorResultWorkList;

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
                base.WriteErrorLog(ex, "MeijiGoodsMngDB.WriteIn");
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

        #region ���i���Ǘ��}�X�^
        #region ���i���Ǘ�Write
        /// <summary>
        /// �w�肳�ꂽ��ƃR�[�h�̏��i�Ǘ����}�X�^�̎捞����
        /// </summary>
        /// <param name="mngSuccessResultWork">�捞�������X�g</param>
        /// <param name="mngErrorResultWork">�捞���s���X�g</param>
        /// <param name="updateCount">�X�V����</param>
        /// <param name="updateMode">�X�V���[�h</param>
        /// <param name="enterPriseCode">��ƃR�[�h</param>
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
        private int WriteInMngProc(out ArrayList mngSuccessResultWork, out ArrayList mngErrorResultWork, out int updateCount, int updateMode, string enterPriseCode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            // �߂���錋�ʃ��X�g
            mngSuccessResultWork = new ArrayList();
            mngErrorResultWork = new ArrayList();
            updateCount = 0;
            // �G���[���b�Z�[�W
            string message = string.Empty;
            // ���X�g
            ArrayList changeWorkList = new ArrayList();
            ArrayList deleteWorkList = new ArrayList();
            ArrayList insertWorkList = new ArrayList();
            SqlConnection mngConnection = this._iGoodsNoChgCommonDB.CreateSqlConnection(true);
            // �V���i��Dictionary
            Dictionary<string, MeijiGoodsStockWork> goodsNoAllDic = new Dictionary<string, MeijiGoodsStockWork>();
            string goodsNoKey = "";
            // �i�ԕϊ��G���[�f�[�^�A�X�V�ǉ����X�g
            ArrayList changeErrorList = new ArrayList();
            Dictionary<string, GoodsNoChangeErrorDataWork> goodsNoChgErrDic = new Dictionary<string, GoodsNoChangeErrorDataWork>();
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            int logicalDeleteDiv = 0;

            try
            {
                // ���i�Ǘ����}�X�^�Ō�������
                status = this.SearchGoodsMngProcProc(out changeWorkList, out goodsNoAllDic, updateMode, enterPriseCode, ref mngConnection);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && changeWorkList.Count > 0)
                {
                    // �ϊ������f�[�^�̃J�E���g
                    updateCount = changeWorkList.Count;
                    // �i�ԕϊ��G���[�f�[�^���폜����
                    status = this._iGoodsNoChgCommonDB.DeleteGoodsNoChangeErrorDataProc(enterPriseCode, GoodsNoChgCommonDB.GOODSMNGMST, ref sqlConnection, ref sqlTransaction);
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        #region ���i�Ǘ����}�X�^�ɐV���i�Ԃ�ϊ�����
                        foreach (GoodsMngWork goodsMngWork in changeWorkList)
                        {
                            // �g�����U�N�V�����̕ۑ�
                            sqlTransaction.Save("GoodsMngSavePoint");
                            // ���[�J�[�{���i�Ԃ̃L�[�̍쐬
                            goodsNoKey = goodsMngWork.GoodsMakerCd.ToString() + "-" + goodsMngWork.GoodsNo.Trim();
                            // ���i�Ǘ����}�X�^�ɋ��i�Ԃ̍폜
                            deleteWorkList.Add(goodsMngWork);
                            //----- ADD 2015/04/17 ���V�� Redmine#45436 ���i���g�p���ă}�X�^�̍폜/�o�^�����s���Ă���ӏ����O�L���b�`����Ή�------>>>>>
                            try
                            {
                            //----- ADD 2015/04/17 ���V�� Redmine#45436 ���i���g�p���ă}�X�^�̍폜/�o�^�����s���Ă���ӏ����O�L���b�`����Ή�------<<<<<
                                status = this._iGoodsMngDB.DeleteGoodsMngProc(deleteWorkList, ref sqlConnection, ref sqlTransaction);
                            //----- ADD 2015/04/17 ���V�� Redmine#45436 ���i���g�p���ă}�X�^�̍폜/�o�^�����s���Ă���ӏ����O�L���b�`����Ή�------>>>>>
                            }
                            catch (Exception ex)
                            {
                                base.WriteErrorLog(ex, "DeleteGoodsMngProc");
                                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                            }
                            //----- ADD 2015/04/17 ���V�� Redmine#45436 ���i���g�p���ă}�X�^�̍폜/�o�^�����s���Ă���ӏ����O�L���b�`����Ή�------<<<<<
                            deleteWorkList.Clear();
                            // ���O�f�[�^�̍쐬
                            MeiJiGoodsMngWork meiJiGoodsMngWork = new MeiJiGoodsMngWork();
                            meiJiGoodsMngWork.SectionCode = goodsMngWork.SectionCode;
                            meiJiGoodsMngWork.GoodsMGroup = goodsMngWork.GoodsMGroup;
                            meiJiGoodsMngWork.GoodsMakerCd = goodsMngWork.GoodsMakerCd;
                            meiJiGoodsMngWork.BLGoodsCode = goodsMngWork.BLGoodsCode;
                            meiJiGoodsMngWork.GoodsNo = goodsNoAllDic[goodsNoKey].OldGoodsNo;
                            meiJiGoodsMngWork.NewGoodsNo = goodsNoAllDic[goodsNoKey].NewGoodsNo;
                            // ���i�Ǘ����}�X�^�ŋ��i�ԂɍX�V�����ꍇ
                            if (status == (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE || status == (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE)
                            {
                                //meiJiGoodsMngWork.OutNote = UPDATEFAIL; // DEL 2015/02/26 ���V�� Redmine#44209 ���b�Z�[�W�̕����Ή�
                                meiJiGoodsMngWork.OutNote = string.Format(GoodsNoChgCommonDB.UPDATEFAIL, "���i�Ǘ����}�X�^"); // ADD 2015/02/26 ���V�� Redmine#44209 ���b�Z�[�W�̕����Ή�
                                if (!goodsNoChgErrDic.ContainsKey(goodsNoKey))
                                {
                                    GoodsNoChangeErrorDataWork goodsNoChangeErrorDataWork = new GoodsNoChangeErrorDataWork();
                                    goodsNoChangeErrorDataWork.MasterDivCd = GoodsNoChgCommonDB.GOODSMNGMST;
                                    goodsNoChangeErrorDataWork.GoodsMakerCd = goodsMngWork.GoodsMakerCd;
                                    goodsNoChangeErrorDataWork.ChgSrcGoodsNo = goodsNoAllDic[goodsNoKey].OldGoodsNo;
                                    goodsNoChangeErrorDataWork.ChgDestGoodsNo = goodsNoAllDic[goodsNoKey].NewGoodsNo;
                                    goodsNoChgErrDic.Add(goodsNoKey, goodsNoChangeErrorDataWork);
                                }
                                mngErrorResultWork.Add(meiJiGoodsMngWork);
                            }
                            else if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                #region �V�i�Ԃ̒ǉ�
                                goodsMngWork.GoodsNo = goodsNoAllDic[goodsNoKey].NewGoodsNo;
                                goodsMngWork.UpdateDateTime = DateTime.MinValue;
                                logicalDeleteDiv = goodsMngWork.LogicalDeleteCode;
                                insertWorkList.Add(goodsMngWork);
                                // ���i�Ǘ����}�X�^�Œǉ�����
                                //----- ADD 2015/04/17 ���V�� Redmine#45436 ���i���g�p���ă}�X�^�̍폜/�o�^�����s���Ă���ӏ����O�L���b�`����Ή�------>>>>>
                                try
                                {
                                //----- ADD 2015/04/17 ���V�� Redmine#45436 ���i���g�p���ă}�X�^�̍폜/�o�^�����s���Ă���ӏ����O�L���b�`����Ή�------<<<<<
                                    status = this._iGoodsMngDB.WriteGoodsMngProc(ref insertWorkList, ref sqlConnection, ref sqlTransaction);
                                //----- ADD 2015/04/17 ���V�� Redmine#45436 ���i���g�p���ă}�X�^�̍폜/�o�^�����s���Ă���ӏ����O�L���b�`����Ή�------>>>>>
                                }
                                catch (Exception ex)
                                {
                                    base.WriteErrorLog(ex, "WriteGoodsMngProc");
                                    status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                                }
                                //----- ADD 2015/04/17 ���V�� Redmine#45436 ���i���g�p���ă}�X�^�̍폜/�o�^�����s���Ă���ӏ����O�L���b�`����Ή�------<<<<<
                                // ���i�Ǘ����}�X�^�ɋ��i�ԑΉ��̐V�i�Ԃ����ɑ��݂���ꍇ�A�r�����b�Z�[�W�̃Z�b�g
                                if (status == (int)ConstantManagement.DB_Status.ctDB_DUPLICATE || status == (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE)
                                {
                                    insertWorkList.Clear();�@// ���X�g�̃N���A
                                    //meiJiGoodsMngWork.OutNote = EXISTMSG; // DEL 2015/02/26 ���V�� Redmine#44209 ���b�Z�[�W�̕����Ή�
                                    meiJiGoodsMngWork.OutNote = string.Format(GoodsNoChgCommonDB.EXISTMSG, "���i�Ǘ����}�X�^"); // ADD 2015/02/26 ���V�� Redmine#44209 ���b�Z�[�W�̕����Ή�
                                    if (!goodsNoChgErrDic.ContainsKey(goodsNoKey))
                                    {
                                        GoodsNoChangeErrorDataWork goodsNoChangeErrorDataWork = new GoodsNoChangeErrorDataWork();
                                        goodsNoChangeErrorDataWork.MasterDivCd = GoodsNoChgCommonDB.GOODSMNGMST;
                                        goodsNoChangeErrorDataWork.GoodsMakerCd = goodsMngWork.GoodsMakerCd;
                                        goodsNoChangeErrorDataWork.ChgSrcGoodsNo = goodsNoAllDic[goodsNoKey].OldGoodsNo;
                                        goodsNoChangeErrorDataWork.ChgDestGoodsNo = goodsNoAllDic[goodsNoKey].NewGoodsNo;
                                        goodsNoChgErrDic.Add(goodsNoKey, goodsNoChangeErrorDataWork);
                                    }
                                    mngErrorResultWork.Add(meiJiGoodsMngWork);
                                }
                                else if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                {
                                    if (logicalDeleteDiv == 1)
                                    {
                                        //----- ADD 2015/04/17 ���V�� Redmine#45436 ���i���g�p���ă}�X�^�̍폜/�o�^�����s���Ă���ӏ����O�L���b�`����Ή�------>>>>>
                                        try
                                        {
                                        //----- ADD 2015/04/17 ���V�� Redmine#45436 ���i���g�p���ă}�X�^�̍폜/�o�^�����s���Ă���ӏ����O�L���b�`����Ή�------<<<<<
                                            status = this._iGoodsMngDB.LogicalDeleteGoodsMngProc(ref insertWorkList, 0, ref sqlConnection, ref sqlTransaction);
                                        //----- ADD 2015/04/17 ���V�� Redmine#45436 ���i���g�p���ă}�X�^�̍폜/�o�^�����s���Ă���ӏ����O�L���b�`����Ή�------>>>>>
                                        }
                                        catch (Exception ex)
                                        {
                                            base.WriteErrorLog(ex, "LogicalDeleteGoodsMngProc");
                                            status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                                        }
                                        //----- ADD 2015/04/17 ���V�� Redmine#45436 ���i���g�p���ă}�X�^�̍폜/�o�^�����s���Ă���ӏ����O�L���b�`����Ή�------<<<<<
                                        insertWorkList.Clear();�@// ���X�g�̃N���A
                                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                        {
                                            //meiJiGoodsMngWork.OutNote = DELETEMSG;// DEL 2015/02/26 ���V�� Redmine#44209 ���b�Z�[�W�̕����Ή�
                                            meiJiGoodsMngWork.OutNote = GoodsNoChgCommonDB.DELETEMSG;// ADD 2015/02/26 ���V�� Redmine#44209 ���b�Z�[�W�̕����Ή�
                                            mngSuccessResultWork.Add(meiJiGoodsMngWork);
                                        }
                                        else
                                        {
                                            //meiJiGoodsMngWork.OutNote = NEWEXCEPTIONMSG;// DEL 2015/02/26 ���V�� Redmine#44209 ���b�Z�[�W�̕����Ή�
                                            meiJiGoodsMngWork.OutNote = GoodsNoChgCommonDB.NEWEXCEPTIONMSG;// ADD 2015/02/26 ���V�� Redmine#44209 ���b�Z�[�W�̕����Ή�
                                            if (!goodsNoChgErrDic.ContainsKey(goodsNoKey))
                                            {
                                                GoodsNoChangeErrorDataWork goodsNoChangeErrorDataWork = new GoodsNoChangeErrorDataWork();
                                                goodsNoChangeErrorDataWork.MasterDivCd = GoodsNoChgCommonDB.GOODSMNGMST;
                                                goodsNoChangeErrorDataWork.GoodsMakerCd = goodsMngWork.GoodsMakerCd;
                                                goodsNoChangeErrorDataWork.ChgSrcGoodsNo = goodsNoAllDic[goodsNoKey].OldGoodsNo;
                                                goodsNoChangeErrorDataWork.ChgDestGoodsNo = goodsNoAllDic[goodsNoKey].NewGoodsNo;
                                                goodsNoChgErrDic.Add(goodsNoKey, goodsNoChangeErrorDataWork);
                                            }
                                            mngErrorResultWork.Add(meiJiGoodsMngWork);
                                        }
                                    }
                                    else
                                    {
                                        insertWorkList.Clear();�@// ���X�g�̃N���A
                                        mngSuccessResultWork.Add(meiJiGoodsMngWork);
                                    }
                                }
                                else
                                {
                                    insertWorkList.Clear();�@// ���X�g�̃N���A
                                    //meiJiGoodsMngWork.OutNote = NEWEXCEPTIONMSG;// DEL 2015/02/26 ���V�� Redmine#44209 ���b�Z�[�W�̕����Ή�
                                    meiJiGoodsMngWork.OutNote = GoodsNoChgCommonDB.NEWEXCEPTIONMSG;// ADD 2015/02/26 ���V�� Redmine#44209 ���b�Z�[�W�̕����Ή�
                                    if (!goodsNoChgErrDic.ContainsKey(goodsNoKey))
                                    {
                                        GoodsNoChangeErrorDataWork goodsNoChangeErrorDataWork = new GoodsNoChangeErrorDataWork();
                                        goodsNoChangeErrorDataWork.MasterDivCd = GoodsNoChgCommonDB.GOODSMNGMST;
                                        goodsNoChangeErrorDataWork.GoodsMakerCd = goodsMngWork.GoodsMakerCd;
                                        goodsNoChangeErrorDataWork.ChgSrcGoodsNo = goodsNoAllDic[goodsNoKey].OldGoodsNo;
                                        goodsNoChangeErrorDataWork.ChgDestGoodsNo = goodsNoAllDic[goodsNoKey].NewGoodsNo;
                                        goodsNoChgErrDic.Add(goodsNoKey, goodsNoChangeErrorDataWork);
                                    }
                                    mngErrorResultWork.Add(meiJiGoodsMngWork);
                                }
                                #endregion
                            }
                            else
                            {
                                //meiJiGoodsMngWork.OutNote = OLDEXCEPTIONMSG; // DEL 2015/02/26 ���V�� Redmine#44209 ���b�Z�[�W�̕����Ή�
                                meiJiGoodsMngWork.OutNote = GoodsNoChgCommonDB.OLDEXCEPTIONMSG; // ADD 2015/02/26 ���V�� Redmine#44209 ���b�Z�[�W�̕����Ή�
                                if (!goodsNoChgErrDic.ContainsKey(goodsNoKey))
                                {
                                    GoodsNoChangeErrorDataWork goodsNoChangeErrorDataWork = new GoodsNoChangeErrorDataWork();
                                    goodsNoChangeErrorDataWork.MasterDivCd = GoodsNoChgCommonDB.GOODSMNGMST;
                                    goodsNoChangeErrorDataWork.GoodsMakerCd = goodsMngWork.GoodsMakerCd;
                                    goodsNoChangeErrorDataWork.ChgSrcGoodsNo = goodsNoAllDic[goodsNoKey].OldGoodsNo;
                                    goodsNoChangeErrorDataWork.ChgDestGoodsNo = goodsNoAllDic[goodsNoKey].NewGoodsNo;
                                    goodsNoChgErrDic.Add(goodsNoKey, goodsNoChangeErrorDataWork);
                                }
                                mngErrorResultWork.Add(meiJiGoodsMngWork);
                            }

                            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                sqlTransaction.Rollback("GoodsMngSavePoint");
                            }
                        }
                        // ���X�g�̃N���A
                        changeWorkList.Clear();
                        #endregion

                        #region �i�ԕϊ��G���[�f�[�^�̍X�V
                        status = this._iGoodsNoChgCommonDB.WriteGoodsNoChangeErrorDataProc(goodsNoChgErrDic, ref sqlConnection, ref sqlTransaction);
                        if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            mngSuccessResultWork.Clear();
                            mngErrorResultWork.Clear();
                            return status;
                        }
                        #endregion
                    }
                    else
                    {
                        return status;
                    }
                }
                else
                {
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                    {
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }
                    return status;
                }
                return status;
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "MeijiGoodsStockDB.WriteInMngProc");
                return (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (mngConnection != null)
                {
                    mngConnection.Close();
                    mngConnection.Dispose();
                }
            }
        }
        #endregion

        #region ���i���Ǘ�����
        /// <summary>
        /// �w�肳�ꂽ�����̏��i�Ǘ����}�X�^���LIST��߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="goodsmngWorkList">��������</param>
        /// <param name="goodsNoAllDic">�V���i��Dictionary</param>
        /// <param name="updateMode">�X�V���[�h</param>
        /// <param name="enterPriseCode">��ƃR�[�h</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note        : �w�肳�ꂽ�����̏��i�Ǘ����}�X�^���LIST��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer  : �i�N</br>
        /// <br>Date        : 2015/01/26</br>
        /// <br></br>
        private int SearchGoodsMngProcProc(out ArrayList goodsmngWorkList, out Dictionary<string, MeijiGoodsStockWork> goodsNoAllDic, int updateMode, string enterPriseCode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            string goodsNoKey = "";
            goodsmngWorkList = new ArrayList();
            goodsNoAllDic = new Dictionary<string, MeijiGoodsStockWork>();
            try
            {
                string sqlTxt = "";

                sqlTxt += "SELECT" + Environment.NewLine;
                sqlTxt += "	 GDM.CREATEDATETIMERF" + Environment.NewLine;
                sqlTxt += "	,GDM.UPDATEDATETIMERF" + Environment.NewLine;
                sqlTxt += "	,GDM.ENTERPRISECODERF" + Environment.NewLine;
                sqlTxt += "	,GDM.FILEHEADERGUIDRF" + Environment.NewLine;
                sqlTxt += "	,GDM.UPDEMPLOYEECODERF" + Environment.NewLine;
                sqlTxt += "	,GDM.UPDASSEMBLYID1RF" + Environment.NewLine;
                sqlTxt += "	,GDM.UPDASSEMBLYID2RF" + Environment.NewLine;
                sqlTxt += "	,GDM.LOGICALDELETECODERF" + Environment.NewLine;
                sqlTxt += "	,GDM.SECTIONCODERF" + Environment.NewLine;
                sqlTxt += "	,SEC.SECTIONGUIDENMRF" + Environment.NewLine;
                sqlTxt += "	,GDM.GOODSMAKERCDRF" + Environment.NewLine;
                sqlTxt += "	,MAK.MAKERNAMERF" + Environment.NewLine;
                sqlTxt += "	,GDM.BLGOODSCODERF" + Environment.NewLine;
                sqlTxt += "	,BLC.BLGOODSFULLNAMERF" + Environment.NewLine;
                sqlTxt += "	,GDM.GOODSNORF" + Environment.NewLine;
                sqlTxt += "	,GOO.GOODSNAMERF" + Environment.NewLine;
                sqlTxt += "	,GDM.SUPPLIERCDRF" + Environment.NewLine;
                sqlTxt += "	,SUP.SUPPLIERSNMRF" + Environment.NewLine;
                sqlTxt += "	,GDM.SUPPLIERLOTRF" + Environment.NewLine;
                sqlTxt += "	,GDM.GOODSMGROUPRF" + Environment.NewLine;
                sqlTxt += "	,GGR.GOODSMGROUPNAMERF" + Environment.NewLine;
                sqlTxt += "	,B.CHGDESTGOODSNORF" + Environment.NewLine;
                sqlTxt += "FROM GOODSMNGRF AS GDM WITH (READUNCOMMITTED) " + Environment.NewLine;
                if (updateMode == 0)
                {
                    sqlTxt += " INNER JOIN GOODSNOCHANGERF B WITH (READUNCOMMITTED) " + Environment.NewLine;
                    sqlTxt += " ON GDM.ENTERPRISECODERF = B.ENTERPRISECODERF " + Environment.NewLine;
                    sqlTxt += " AND GDM.GOODSNORF = B.CHGSRCGOODSNORF " + Environment.NewLine;
                    sqlTxt += " AND GDM.GOODSMAKERCDRF = B.GOODSMAKERCDRF " + Environment.NewLine;
                }
                else
                {
                    sqlTxt += " INNER JOIN GOODSNOCHANGEERRDTRF B WITH (READUNCOMMITTED) " + Environment.NewLine;
                    sqlTxt += " ON GDM.ENTERPRISECODERF = B.ENTERPRISECODERF " + Environment.NewLine;
                    sqlTxt += " AND GDM.GOODSNORF = B.CHGSRCGOODSNORF " + Environment.NewLine;
                    sqlTxt += " AND GDM.GOODSMAKERCDRF = B.GOODSMAKERCDRF " + Environment.NewLine;
                    sqlTxt += " AND B.MASTERDIVCDRF = 2 " + Environment.NewLine;
                }
                sqlTxt += "LEFT JOIN SECINFOSETRF AS SEC" + Environment.NewLine;
                sqlTxt += "ON" + Environment.NewLine;
                sqlTxt += "	GDM.ENTERPRISECODERF=SEC.ENTERPRISECODERF" + Environment.NewLine;
                sqlTxt += "AND GDM.SECTIONCODERF=SEC.SECTIONCODERF" + Environment.NewLine;
                sqlTxt += "LEFT JOIN SUPPLIERRF AS SUP" + Environment.NewLine;
                sqlTxt += "ON" + Environment.NewLine;
                sqlTxt += "	GDM.ENTERPRISECODERF=SUP.ENTERPRISECODERF" + Environment.NewLine;
                sqlTxt += "AND GDM.SUPPLIERCDRF=SUP.SUPPLIERCDRF" + Environment.NewLine;
                sqlTxt += "LEFT JOIN MAKERURF AS MAK" + Environment.NewLine;
                sqlTxt += "ON" + Environment.NewLine;
                sqlTxt += "	MAK.ENTERPRISECODERF = GDM.ENTERPRISECODERF" + Environment.NewLine;
                sqlTxt += "AND MAK.GOODSMAKERCDRF = GDM.GOODSMAKERCDRF" + Environment.NewLine;
                sqlTxt += "LEFT JOIN BLGOODSCDURF AS BLC" + Environment.NewLine;
                sqlTxt += "ON" + Environment.NewLine;
                sqlTxt += "	BLC.ENTERPRISECODERF = GDM.ENTERPRISECODERF" + Environment.NewLine;
                sqlTxt += "AND BLC.BLGOODSCODERF = GDM.BLGOODSCODERF" + Environment.NewLine;
                sqlTxt += "LEFT JOIN GOODSGROUPURF AS GGR" + Environment.NewLine;
                sqlTxt += "ON" + Environment.NewLine;
                sqlTxt += "	GGR.ENTERPRISECODERF = GDM.ENTERPRISECODERF" + Environment.NewLine;
                sqlTxt += "AND GGR.GOODSMGROUPRF = GDM.GOODSMGROUPRF" + Environment.NewLine;
                sqlTxt += "LEFT JOIN GOODSURF AS GOO" + Environment.NewLine;
                sqlTxt += "ON" + Environment.NewLine;
                sqlTxt += "	GOO.ENTERPRISECODERF = GDM.ENTERPRISECODERF" + Environment.NewLine;
                sqlTxt += "AND GOO.GOODSMAKERCDRF = GDM.GOODSMAKERCDRF" + Environment.NewLine;
                sqlTxt += "AND GOO.GOODSNORF = GDM.GOODSNORF	" + Environment.NewLine;

                sqlCommand = new SqlCommand(sqlTxt, sqlConnection);

                sqlTxt = "";
                sqlTxt += "WHERE" + Environment.NewLine;

                //��ƃR�[�h
                sqlTxt += " GDM.ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterPriseCode);

                //�_���폜�敪
                sqlTxt += " AND B.LOGICALDELETECODERF=@FINDLOGICALDELETECODE" + Environment.NewLine;
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);

                sqlTxt += " ORDER BY GDM.ENTERPRISECODERF, GDM.GOODSMAKERCDRF, GDM.GOODSNORF, GDM.SECTIONCODERF ";

                sqlCommand.CommandText += sqlTxt;

                // �N�G�����s���̃^�C���A�E�g���Ԃ�10���ɐݒ肷��
                sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitInquiry);

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    // ���i�Ǘ���񃏁[�N�ƐV���i�ԃ��[�N�̍쐬
                    GoodsMngWork goodsMngWork = new GoodsMngWork();
                    MeijiGoodsStockWork meijiGoodsStockWork = new MeijiGoodsStockWork();
                    // �N���X�i�[����
                    CopyToGoodsMngWorkFromReader(ref myReader, out goodsMngWork, out meijiGoodsStockWork);
                    goodsmngWorkList.Add(goodsMngWork);
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
                    if (!myReader.IsClosed) myReader.Close();
            }

            return status;
        }
        #endregion

        #region [�N���X�i�[����]
        /// <summary>
        /// �N���X�i�[���� Reader �� GoodsMngWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <param name="wkGoodsMngWork">GoodsMngWork</param>
        /// <param name="meijiGoodsStockWork">MeijiGoodsStockWork</param>
        /// <remarks>
        /// <br>Programmer  : �i�N</br>
        /// <br>Date        : 2015/01/26</br>
        /// <br></br>
        /// </remarks>
        private void CopyToGoodsMngWorkFromReader(ref SqlDataReader myReader, out GoodsMngWork wkGoodsMngWork, out MeijiGoodsStockWork meijiGoodsStockWork)
        {
            wkGoodsMngWork = new GoodsMngWork();
            meijiGoodsStockWork = new MeijiGoodsStockWork();

            wkGoodsMngWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
            wkGoodsMngWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
            wkGoodsMngWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
            wkGoodsMngWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
            wkGoodsMngWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
            wkGoodsMngWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
            wkGoodsMngWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
            wkGoodsMngWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
            wkGoodsMngWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
            wkGoodsMngWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
            wkGoodsMngWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF"));
            wkGoodsMngWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
            wkGoodsMngWork.SupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERCDRF"));
            wkGoodsMngWork.SupplierLot = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERLOTRF"));
            wkGoodsMngWork.GoodsMGroup = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMGROUPRF"));
            wkGoodsMngWork.SectionGuideNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONGUIDENMRF"));
            wkGoodsMngWork.SupplierSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERSNMRF"));
            wkGoodsMngWork.MakerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKERNAMERF"));
            wkGoodsMngWork.BLGoodsFullName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BLGOODSFULLNAMERF"));
            wkGoodsMngWork.GoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMERF"));
            wkGoodsMngWork.GoodsMGroupName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSMGROUPNAMERF"));

            meijiGoodsStockWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
            meijiGoodsStockWork.OldGoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
            meijiGoodsStockWork.NewGoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CHGDESTGOODSNORF"));
        }
        #endregion
        #endregion
        #endregion
    }
}
