//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �����Y�Ɗ|���}�X�^�ϊ�����
// �v���O�����T�v   : �b�r�u�t�@�C�����A��ʒ��o�����𖞂������f�[�^���e�L�X�g�t�@�C���֏o�͂���
//----------------------------------------------------------------------------//
//                (c)Copyright  2015 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11003519-00  �쐬�S�� : �i�N
// �� �� ��  2015/01/26   �C�����e : �V�K�쐬
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
using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using System.Text.RegularExpressions;
using Broadleaf.Library.Data.SqlTypes;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// �����Y�Ɗ|���}�X�^�ϊ�����DB�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note        : �|���}�X�^�ϊ������̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer  : �i�N</br>
    /// <br>Date        : 2015/01/26</br>
    /// </remarks>
    [Serializable]
    public class MeijiRateDB : RemoteDB
    {
        // �|���}�X�^�̃����[�g
        private RateDB _iRateDB;
        private GoodsNoChgCommonDB _iGoodsNoChgCommonDB;
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

        #region MeijiRateDB
        /// <summary>
        /// �|���}�X�^�ϊ������R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note        : ���ɂȂ�</br>
        /// <br>Programmer  : �i�N</br>
        /// <br>Date        : 2015/01/26</br>
        /// </remarks>
        public MeijiRateDB()
        {
            // �|���}�X�^
            if (this._iRateDB == null)
            {
                this._iRateDB = new RateDB();
            }
            // �i�ԕϊ���������
            if (this._iGoodsNoChgCommonDB == null)
            {
                this._iGoodsNoChgCommonDB = new GoodsNoChgCommonDB();
            }
        }
        #endregion

        #region �|���}�X�^�̎捞����
        /// <summary>
        /// �w�肳�ꂽ��ƃR�[�h�̊|���̑S�Ė߂鏈��
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note        : �w�肳�ꂽ��ƃR�[�h�̊|��LIST��S�Ė߂��܂�</br>
        /// <br>Programmer  : �i�N</br>
        /// <br>Date        : 2015/01/26</br>
        /// </remarks>
        public int WriteIn(out object rateSuccessResultWork, out object rateErrorResultWork, out int updateCount, int updateMode, string enterPriseCode)
        {
            // �R�l�N�V����
            SqlConnection sqlConnection = null;
            // �g�����U�N�V����
            SqlTransaction sqlTransaction = null;
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            // �|���}�X�^�ɐ����ȓo�^����f�[�^
            rateSuccessResultWork = null;
            ArrayList rateSuccessResultWorkList = new ArrayList();

            // �|���}�X�^�Ɏ��s�ȓo�^����f�[�^
            rateErrorResultWork = null;
            ArrayList rateErrorResultWorkList = new ArrayList();

            // �o�^����
            updateCount = 0;

            try
            {
                // �R�l�N�V��������
                sqlConnection = this._iGoodsNoChgCommonDB.CreateSqlConnection(true);

                // �g�����U�N�V�����J�n
                sqlTransaction = this._iGoodsNoChgCommonDB.CreateTransaction(ref sqlConnection);

                // �|���}�X�^�ϊ�����
                status = RateWriteInProc(out rateSuccessResultWorkList, out rateErrorResultWorkList, out updateCount, updateMode, enterPriseCode, ref sqlConnection, ref sqlTransaction);

                // �߂��郊�X�g
                rateSuccessResultWork = rateSuccessResultWorkList;
                rateErrorResultWork = rateErrorResultWorkList;

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
                base.WriteErrorLog(ex, "MeijiRateDB.WriteIn");
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
        /// �w�肳�ꂽ��ƃR�[�h�̊|���}�X�^�̎捞����
        /// </summary>
        /// <param name="rateSuccessResultWork">�捞�������X�g</param>
        /// <param name="rateErrorResultWork">�捞���s���X�g</param>
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
        private int RateWriteInProc(out ArrayList rateSuccessResultWork, out ArrayList rateErrorResultWork, out int updateCount, int updateMode, string enterPriseCode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            // �߂���錋�ʃ��X�g
            rateSuccessResultWork = new ArrayList();
            rateErrorResultWork = new ArrayList();
            // ���X�g
            ArrayList changeWorkList = new ArrayList();
            ArrayList insertWorkList = new ArrayList();
            ArrayList deleteWorkList = new ArrayList();
            // �i�ԕϊ��G���[�f�[�^�A�X�V�ǉ�Dictionary
            Dictionary<string, GoodsNoChangeErrorDataWork> goodsNoChgErrDic = new Dictionary<string, GoodsNoChangeErrorDataWork>();
            // �����R�l�N�V����
            SqlConnection rateConnection = this._iGoodsNoChgCommonDB.CreateSqlConnection(true);
            // �o�^����
            updateCount = 0;
            // �V���i��Dictionary
            Dictionary<string, MeijiRateWork> goodsNoAllDic = new Dictionary<string, MeijiRateWork>();
            string goodsNoKey = "";

            try
            {
                // �|���}�X�^�Ō�������
                status = this.SearchSubSectionProcProc(out changeWorkList, out goodsNoAllDic, updateMode, enterPriseCode, ref rateConnection);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && changeWorkList.Count > 0)
                {
                    // �ϊ������f�[�^�̃J�E���g
                    updateCount = changeWorkList.Count;
                    // �i�ԕϊ��G���[�f�[�^���폜����
                    status = this._iGoodsNoChgCommonDB.DeleteGoodsNoChangeErrorDataProc(enterPriseCode, GoodsNoChgCommonDB.RATEMST, ref sqlConnection, ref sqlTransaction);
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        #region �|���}�X�^�ɐV���i�Ԃ�ϊ�����
                        int logicalDeleteCode = 0;
                        foreach (RateWork rateChgWork in changeWorkList)
                        {
                            // �g�����U�N�V�����̕ۑ�
                            sqlTransaction.Save("RateSavePoint");
                            // ���[�J�[�{���i�Ԃ̃L�[�̍쐬
                            goodsNoKey = rateChgWork.GoodsMakerCd.ToString() + "-" + rateChgWork.GoodsNo.Trim();
                            // �|���}�X�^�ɋ��i�Ԃ̍폜
                            deleteWorkList.Add(rateChgWork);
                            //----- ADD 2015/04/17 ���V�� Redmine#45436 ���i���g�p���ă}�X�^�̍폜/�o�^�����s���Ă���ӏ����O�L���b�`����Ή�------>>>>>
                            try
                            {
                            //----- ADD 2015/04/17 ���V�� Redmine#45436 ���i���g�p���ă}�X�^�̍폜/�o�^�����s���Ă���ӏ����O�L���b�`����Ή�------<<<<<
                                status = this._iRateDB.DeleteSubSectionProc(deleteWorkList, ref sqlConnection, ref sqlTransaction);
                            //----- ADD 2015/04/17 ���V�� Redmine#45436 ���i���g�p���ă}�X�^�̍폜/�o�^�����s���Ă���ӏ����O�L���b�`����Ή�------>>>>>
                            }
                            catch (Exception ex)
                            {
                                base.WriteErrorLog(ex, "DeleteSubSectionProc");
                                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                            }
                            //----- ADD 2015/04/17 ���V�� Redmine#45436 ���i���g�p���ă}�X�^�̍폜/�o�^�����s���Ă���ӏ����O�L���b�`����Ή�------<<<<<
                            deleteWorkList.Clear(); // ���X�g�̃N���A
                            // ���O�f�[�^�̍쐬
                            MeijiRateWork meijiRateWork = new MeijiRateWork();
                            meijiRateWork.CustomerCode = rateChgWork.CustomerCode;
                            meijiRateWork.CustRateGrpCode = rateChgWork.CustRateGrpCode;
                            meijiRateWork.GoodsMakerCd = rateChgWork.GoodsMakerCd;
                            meijiRateWork.GoodsNo = goodsNoAllDic[goodsNoKey].GoodsNo;
                            meijiRateWork.LotCount = rateChgWork.LotCount;
                            meijiRateWork.NewGoodsNo = goodsNoAllDic[goodsNoKey].NewGoodsNo;
                            meijiRateWork.SectionCode = rateChgWork.SectionCode;
                            meijiRateWork.SupplierCd = rateChgWork.SupplierCd;
                            meijiRateWork.UnitPriceKind = rateChgWork.UnitPriceKind;
                            meijiRateWork.UnitRateSetDivCd = rateChgWork.UnitRateSetDivCd;
                            // �|���}�X�^�̋��i�Ԃ̍폜�Ɏ��s�����ꍇ
                            if (status == (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE || status == (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE)
                            {
                                //meijiRateWork.OutNote = UPDATEFAIL;// DEL 2015/02/26 ���V�� Redmine#44209 ���b�Z�[�W�̕����Ή�
                                meijiRateWork.OutNote = string.Format(GoodsNoChgCommonDB.UPDATEFAIL, "�|���}�X�^"); // ADD 2015/02/26 ���V�� Redmine#44209 ���b�Z�[�W�̕����Ή�
                                if (!goodsNoChgErrDic.ContainsKey(goodsNoKey))
                                {
                                    GoodsNoChangeErrorDataWork goodsNoChangeErrorDataWork = new GoodsNoChangeErrorDataWork();
                                    goodsNoChangeErrorDataWork.MasterDivCd = GoodsNoChgCommonDB.RATEMST;
                                    goodsNoChangeErrorDataWork.GoodsMakerCd = rateChgWork.GoodsMakerCd;
                                    goodsNoChangeErrorDataWork.ChgSrcGoodsNo = goodsNoAllDic[goodsNoKey].GoodsNo;
                                    goodsNoChangeErrorDataWork.ChgDestGoodsNo = goodsNoAllDic[goodsNoKey].NewGoodsNo;
                                    goodsNoChgErrDic.Add(goodsNoKey, goodsNoChangeErrorDataWork);
                                }
                                rateErrorResultWork.Add(meijiRateWork);
                            }
                            // �|���}�X�^�̋��i�Ԃ̍폜�ɐ��������ꍇ
                            else if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                #region �V�i�Ԃ̒ǉ�
                                rateChgWork.GoodsNo = goodsNoAllDic[goodsNoKey].NewGoodsNo;
                                rateChgWork.UpdateDateTime = DateTime.MinValue;
                                logicalDeleteCode = rateChgWork.LogicalDeleteCode;
                                insertWorkList.Add(rateChgWork);
                                // �|���}�X�^�Œǉ�����
                                //----- ADD 2015/04/17 ���V�� Redmine#45436 ���i���g�p���ă}�X�^�̍폜/�o�^�����s���Ă���ӏ����O�L���b�`����Ή�------>>>>>
                                try
                                {
                                //----- ADD 2015/04/17 ���V�� Redmine#45436 ���i���g�p���ă}�X�^�̍폜/�o�^�����s���Ă���ӏ����O�L���b�`����Ή�------<<<<<
                                    status = this._iRateDB.WriteSubSectionProc(ref insertWorkList, ref sqlConnection, ref sqlTransaction);
                                //----- ADD 2015/04/17 ���V�� Redmine#45436 ���i���g�p���ă}�X�^�̍폜/�o�^�����s���Ă���ӏ����O�L���b�`����Ή�------>>>>>
                                }
                                catch (Exception ex)
                                {
                                    base.WriteErrorLog(ex, "WriteSubSectionProc");
                                    status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                                }
                                //----- ADD 2015/04/17 ���V�� Redmine#45436 ���i���g�p���ă}�X�^�̍폜/�o�^�����s���Ă���ӏ����O�L���b�`����Ή�------<<<<<
                                // �|���}�X�^�ɋ��i�ԑΉ��̐V�i�Ԃ����ɑ��݂���ꍇ�A�r�����b�Z�[�W�̃Z�b�g
                                if (status == (int)ConstantManagement.DB_Status.ctDB_DUPLICATE || status == (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE)
                                {
                                    insertWorkList.Clear(); // ���X�g�̃N���A
                                    //meijiRateWork.OutNote = EXISTMSG; // DEL 2015/02/26 ���V�� Redmine#44209 ���b�Z�[�W�̕����Ή�
                                    meijiRateWork.OutNote = string.Format(GoodsNoChgCommonDB.EXISTMSG, "�|���}�X�^"); // ADD 2015/02/26 ���V�� Redmine#44209 ���b�Z�[�W�̕����Ή�
                                    if (!goodsNoChgErrDic.ContainsKey(goodsNoKey))
                                    {
                                        GoodsNoChangeErrorDataWork goodsNoChangeErrorDataWork = new GoodsNoChangeErrorDataWork();
                                        goodsNoChangeErrorDataWork.MasterDivCd = GoodsNoChgCommonDB.RATEMST;
                                        goodsNoChangeErrorDataWork.GoodsMakerCd = rateChgWork.GoodsMakerCd;
                                        goodsNoChangeErrorDataWork.ChgSrcGoodsNo = goodsNoAllDic[goodsNoKey].GoodsNo;
                                        goodsNoChangeErrorDataWork.ChgDestGoodsNo = goodsNoAllDic[goodsNoKey].NewGoodsNo;
                                        goodsNoChgErrDic.Add(goodsNoKey, goodsNoChangeErrorDataWork);
                                    }
                                    rateErrorResultWork.Add(meijiRateWork);
                                }
                                else if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                {
                                    // �_���폜�̏ꍇ
                                    if (logicalDeleteCode == 1)
                                    {
                                        //----- ADD 2015/04/17 ���V�� Redmine#45436 ���i���g�p���ă}�X�^�̍폜/�o�^�����s���Ă���ӏ����O�L���b�`����Ή�------>>>>>
                                        try
                                        {
                                        //----- ADD 2015/04/17 ���V�� Redmine#45436 ���i���g�p���ă}�X�^�̍폜/�o�^�����s���Ă���ӏ����O�L���b�`����Ή�------<<<<<
                                            status = this._iRateDB.LogicalDeleteSubSectionProc(ref insertWorkList, 0, ref sqlConnection, ref sqlTransaction);
                                        //----- ADD 2015/04/17 ���V�� Redmine#45436 ���i���g�p���ă}�X�^�̍폜/�o�^�����s���Ă���ӏ����O�L���b�`����Ή�------>>>>>
                                        }
                                        catch (Exception ex)
                                        {
                                            base.WriteErrorLog(ex, "LogicalDeleteSubSectionProc");
                                            status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                                        }
                                        //----- ADD 2015/04/17 ���V�� Redmine#45436 ���i���g�p���ă}�X�^�̍폜/�o�^�����s���Ă���ӏ����O�L���b�`����Ή�------<<<<<
                                        insertWorkList.Clear(); // ���X�g�̃N���A
                                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                        {
                                            //meijiRateWork.OutNote = DELETEMSG;// DEL 2015/02/26 ���V�� Redmine#44209 ���b�Z�[�W�̕����Ή�
                                            meijiRateWork.OutNote = GoodsNoChgCommonDB.DELETEMSG;// ADD 2015/02/26 ���V�� Redmine#44209 ���b�Z�[�W�̕����Ή�
                                            rateSuccessResultWork.Add(meijiRateWork);
                                        }
                                        else
                                        {
                                            //meijiRateWork.OutNote = NEWEXCEPTIONMSG;// DEL 2015/02/26 ���V�� Redmine#44209 ���b�Z�[�W�̕����Ή�
                                            meijiRateWork.OutNote = GoodsNoChgCommonDB.NEWEXCEPTIONMSG;// ADD 2015/02/26 ���V�� Redmine#44209 ���b�Z�[�W�̕����Ή�
                                            if (!goodsNoChgErrDic.ContainsKey(goodsNoKey))
                                            {
                                                GoodsNoChangeErrorDataWork goodsNoChangeErrorDataWork = new GoodsNoChangeErrorDataWork();
                                                goodsNoChangeErrorDataWork.MasterDivCd = GoodsNoChgCommonDB.RATEMST;
                                                goodsNoChangeErrorDataWork.GoodsMakerCd = rateChgWork.GoodsMakerCd;
                                                goodsNoChangeErrorDataWork.ChgSrcGoodsNo = goodsNoAllDic[goodsNoKey].GoodsNo;
                                                goodsNoChangeErrorDataWork.ChgDestGoodsNo = goodsNoAllDic[goodsNoKey].NewGoodsNo;
                                                goodsNoChgErrDic.Add(goodsNoKey, goodsNoChangeErrorDataWork);
                                            }
                                            rateErrorResultWork.Add(meijiRateWork);
                                        }
                                    }
                                    else
                                    {
                                        insertWorkList.Clear(); // ���X�g�̃N���A
                                        rateSuccessResultWork.Add(meijiRateWork);
                                    }
                                }
                                else
                                {
                                    insertWorkList.Clear(); // ���X�g�̃N���A
                                    //meijiRateWork.OutNote = NEWEXCEPTIONMSG;// DEL 2015/02/26 ���V�� Redmine#44209 ���b�Z�[�W�̕����Ή�
                                    meijiRateWork.OutNote = GoodsNoChgCommonDB.NEWEXCEPTIONMSG;// ADD 2015/02/26 ���V�� Redmine#44209 ���b�Z�[�W�̕����Ή�
                                    if (!goodsNoChgErrDic.ContainsKey(goodsNoKey))
                                    {
                                        GoodsNoChangeErrorDataWork goodsNoChangeErrorDataWork = new GoodsNoChangeErrorDataWork();
                                        goodsNoChangeErrorDataWork.MasterDivCd = GoodsNoChgCommonDB.RATEMST;
                                        goodsNoChangeErrorDataWork.GoodsMakerCd = rateChgWork.GoodsMakerCd;
                                        goodsNoChangeErrorDataWork.ChgSrcGoodsNo = goodsNoAllDic[goodsNoKey].GoodsNo;
                                        goodsNoChangeErrorDataWork.ChgDestGoodsNo = goodsNoAllDic[goodsNoKey].NewGoodsNo;
                                        goodsNoChgErrDic.Add(goodsNoKey, goodsNoChangeErrorDataWork);
                                    }
                                    rateErrorResultWork.Add(meijiRateWork);
                                }
                                #endregion
                            }
                            else
                            {
                                //meijiRateWork.OutNote = OLDEXCEPTIONMSG; // DEL 2015/02/26 ���V�� Redmine#44209 ���b�Z�[�W�̕����Ή�
                                meijiRateWork.OutNote = GoodsNoChgCommonDB.OLDEXCEPTIONMSG; // ADD 2015/02/26 ���V�� Redmine#44209 ���b�Z�[�W�̕����Ή�
                                if (!goodsNoChgErrDic.ContainsKey(goodsNoKey))
                                {
                                    GoodsNoChangeErrorDataWork goodsNoChangeErrorDataWork = new GoodsNoChangeErrorDataWork();
                                    goodsNoChangeErrorDataWork.MasterDivCd = GoodsNoChgCommonDB.RATEMST;
                                    goodsNoChangeErrorDataWork.GoodsMakerCd = rateChgWork.GoodsMakerCd;
                                    goodsNoChangeErrorDataWork.ChgSrcGoodsNo = goodsNoAllDic[goodsNoKey].GoodsNo;
                                    goodsNoChangeErrorDataWork.ChgDestGoodsNo = goodsNoAllDic[goodsNoKey].NewGoodsNo;
                                    goodsNoChgErrDic.Add(goodsNoKey, goodsNoChangeErrorDataWork);
                                }
                                rateErrorResultWork.Add(meijiRateWork);
                            }

                            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                sqlTransaction.Rollback("RateSavePoint");
                            }
                        }
                        // ���X�g�̃N���A
                        changeWorkList.Clear();
                        #endregion

                        #region �i�ԕϊ��G���[�f�[�^�̍X�V
                        status = this._iGoodsNoChgCommonDB.WriteGoodsNoChangeErrorDataProc(goodsNoChgErrDic, ref sqlConnection, ref sqlTransaction);
                        if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            rateSuccessResultWork.Clear();
                            rateErrorResultWork.Clear();
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
                base.WriteErrorLog(ex, "MeijiRateDB.RateWriteInProc");
                return (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (rateConnection != null)
                {
                    rateConnection.Close();
                    rateConnection.Dispose();
                }
            }
        }

        /// <summary>
        /// �w�肳�ꂽ�����̊|���ݒ�}�X�^�߂�f�[�^���LIST��߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="rateWorkList">��������</param>
        /// <param name="goodsNoAllDic">�V���i��Dictionary</param>
        /// <param name="updateMode">�X�V���[�h</param>
        /// <param name="enterPriseCode">��ƃR�[�h</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note        : �w�肳�ꂽ������e-JIBAI�߂�f�[�^���LIST��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer  : �i�N</br>
        /// <br>Date        : 2015/01/26</br>
        private int SearchSubSectionProcProc(out ArrayList rateWorkList, out Dictionary<string, MeijiRateWork> goodsNoAllDic, int updateMode, string enterPriseCode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            string goodsNoKey = "";
            rateWorkList = new ArrayList();
            goodsNoAllDic = new Dictionary<string, MeijiRateWork>();
            try
            {
                string command = string.Empty;
                command = " SELECT A.CREATEDATETIMERF, A.UPDATEDATETIMERF, A.ENTERPRISECODERF, A.FILEHEADERGUIDRF, A.UPDEMPLOYEECODERF, " + Environment.NewLine;
                command += " A.UPDASSEMBLYID1RF, A.UPDASSEMBLYID2RF, A.LOGICALDELETECODERF, A.SECTIONCODERF, A.UNITRATESETDIVCDRF, " + Environment.NewLine;
                command += " A.UNITPRICEKINDRF, A.RATESETTINGDIVIDERF, A.RATEMNGGOODSCDRF, A.RATEMNGGOODSNMRF, A.RATEMNGCUSTCDRF, " + Environment.NewLine;
                command += " A.RATEMNGCUSTNMRF, A.GOODSMAKERCDRF, A.GOODSNORF, A.GOODSRATERANKRF, A.GOODSRATEGRPCODERF, A.BLGROUPCODERF, " + Environment.NewLine;
                command += " A.BLGOODSCODERF, A.CUSTOMERCODERF, A.CUSTRATEGRPCODERF, A.SUPPLIERCDRF, A.LOTCOUNTRF, A.PRICEFLRF, " + Environment.NewLine;
                command += " A.RATEVALRF, A.UPRATERF, A.GRSPROFITSECURERATERF, A.UNPRCFRACPROCUNITRF, A.UNPRCFRACPROCDIVRF, B.CHGDESTGOODSNORF " + Environment.NewLine;
                command += " FROM RATERF A WITH (READUNCOMMITTED) " + Environment.NewLine;
                if (updateMode == 0)
                {
                    command += " INNER JOIN GOODSNOCHANGERF B WITH (READUNCOMMITTED) " + Environment.NewLine;
                    command += " ON A.ENTERPRISECODERF = B.ENTERPRISECODERF " + Environment.NewLine;
                    command += " AND A.GOODSNORF = B.CHGSRCGOODSNORF " + Environment.NewLine;
                    command += " AND A.GOODSMAKERCDRF = B.GOODSMAKERCDRF " + Environment.NewLine;
                }
                else
                {
                    command += " INNER JOIN GOODSNOCHANGEERRDTRF B WITH (READUNCOMMITTED) " + Environment.NewLine;
                    command += " ON A.ENTERPRISECODERF = B.ENTERPRISECODERF " + Environment.NewLine;
                    command += " AND A.GOODSNORF = B.CHGSRCGOODSNORF " + Environment.NewLine;
                    command += " AND A.GOODSMAKERCDRF = B.GOODSMAKERCDRF " + Environment.NewLine;
                    command += " AND B.MASTERDIVCDRF = 3 " + Environment.NewLine;
                }

                sqlCommand = new SqlCommand(command, sqlConnection);

                sqlCommand.CommandText += MakeWhereString(ref sqlCommand, enterPriseCode);
                // �N�G�����s���̃^�C���A�E�g���Ԃ�10���ɐݒ肷��
                sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitInquiry);

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    // �|�����[�N�ƐV���i�ԃ��[�N�̍쐬
                    RateWork wkRateWork = new RateWork();
                    MeijiRateWork meijiRateCndtnWork = new MeijiRateWork();
                    // �N���X�i�[����
                    CopyToRateWorkFromReader(ref myReader, out wkRateWork, out meijiRateCndtnWork);
                    rateWorkList.Add(wkRateWork);
                    goodsNoKey = meijiRateCndtnWork.GoodsMakerCd.ToString() + "-" + meijiRateCndtnWork.GoodsNo.Trim();
                    if (!goodsNoAllDic.ContainsKey(goodsNoKey))
                    {
                        goodsNoAllDic.Add(goodsNoKey, meijiRateCndtnWork);
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
                if (sqlCommand != null) sqlCommand.Dispose();
                if (myReader != null)
                    if (!myReader.IsClosed) myReader.Close();
            }

            return status;
        }

        /// <summary>
        /// �������������񐶐��{�����l�ݒ�
        /// </summary>
        /// <param name="sqlCommand">SqlCommand�I�u�W�F�N�g</param>
        /// <param name="enterPriseCode">��ƃR�[�h</param>
        /// <returns>Where����������</returns>
        /// <br>Note        : Where����쐬���Ė߂��܂�</br>
        /// <br>Programmer  : �i�N</br>
        /// <br>Date        : 2015/01/26</br>
        private string MakeWhereString(ref SqlCommand sqlCommand, string enterPriseCode)
        {
            string retstring = "WHERE ";

            //��ƃR�[�h
            retstring += "A.ENTERPRISECODERF=@ENTERPRISECODE ";
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterPriseCode);

            //�_���폜�敪
            retstring += "AND B.LOGICALDELETECODERF=@FINDLOGICALDELETECODE ";
            SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
            paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);

            retstring += " ORDER BY A.ENTERPRISECODERF, A.GOODSMAKERCDRF, A.GOODSNORF, A.SECTIONCODERF, A.UNITRATESETDIVCDRF, A.CUSTOMERCODERF, A.CUSTRATEGRPCODERF, A.SUPPLIERCDRF, A.LOTCOUNTRF ";
            return retstring;
        }

        /// <summary>
        /// �N���X�i�[���� Reader �� RateWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <param name="wkRateWork">RateWork</param>
        /// <param name="meijiRateCndtnWork">MeijiRateWork</param>
        /// <returns>RateWork</returns>
        /// <remarks>
        /// <br>Programmer  : �i�N</br>
        /// <br>Date        : 2015/01/26</br>
        /// </remarks>
        private void CopyToRateWorkFromReader(ref SqlDataReader myReader, out RateWork wkRateWork, out MeijiRateWork meijiRateCndtnWork)
        {
            // �|�����[�N�ƐV���i�ԃ��[�N�̍쐬
            wkRateWork = new RateWork();
            meijiRateCndtnWork = new MeijiRateWork();
            #region �N���X�֊i�[
            wkRateWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
            wkRateWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
            wkRateWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
            wkRateWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
            wkRateWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
            wkRateWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
            wkRateWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
            wkRateWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
            wkRateWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
            wkRateWork.UnitRateSetDivCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UNITRATESETDIVCDRF"));
            wkRateWork.UnitPriceKind = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UNITPRICEKINDRF"));
            wkRateWork.RateSettingDivide = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATESETTINGDIVIDERF"));
            wkRateWork.RateMngGoodsCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATEMNGGOODSCDRF"));
            wkRateWork.RateMngGoodsNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATEMNGGOODSNMRF"));
            wkRateWork.RateMngCustCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATEMNGCUSTCDRF"));
            wkRateWork.RateMngCustNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATEMNGCUSTNMRF"));
            wkRateWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
            wkRateWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
            wkRateWork.GoodsRateRank = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSRATERANKRF"));
            wkRateWork.GoodsRateGrpCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSRATEGRPCODERF"));
            wkRateWork.BLGroupCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGROUPCODERF"));
            wkRateWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF"));
            wkRateWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));
            wkRateWork.CustRateGrpCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTRATEGRPCODERF"));
            wkRateWork.SupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERCDRF"));
            wkRateWork.LotCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("LOTCOUNTRF"));
            wkRateWork.PriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("PRICEFLRF"));
            wkRateWork.RateVal = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("RATEVALRF"));
            wkRateWork.UpRate = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("UPRATERF"));
            wkRateWork.GrsProfitSecureRate = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("GRSPROFITSECURERATERF"));
            wkRateWork.UnPrcFracProcUnit = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("UNPRCFRACPROCUNITRF"));
            wkRateWork.UnPrcFracProcDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("UNPRCFRACPROCDIVRF"));

            meijiRateCndtnWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
            meijiRateCndtnWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
            meijiRateCndtnWork.NewGoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CHGDESTGOODSNORF"));
            #endregion
        }
        #endregion
    }
}
