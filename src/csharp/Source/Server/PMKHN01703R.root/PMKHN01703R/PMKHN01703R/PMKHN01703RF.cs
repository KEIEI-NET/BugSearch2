//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �����Y�ƌ����}�X�^�ϊ�����
// �v���O�����T�v   : �b�r�u�t�@�C�����A��ʒ��o�����𖞂������f�[�^���e�L�X�g�t�@�C���֏o�͂���
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
// �� �� ��  2015/04/07  �C�����e : Redmine#44209 �ϊ���̌��i�ԂƐ�i�Ԃ�����̏ꍇ�̓G���[�Ƃ���Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11003519-00 �쐬�S�� : �i�N
// �� �� ��  2015/04/13  �C�����e : Redmine#45436 �\�����ʏd���̑Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11003519-00 �쐬�S�� : ���V��
// �� �� ��  2015/04/17  �C�����e : Redmine#45436 ���i���g�p���ă}�X�^�̍폜/�o�^�����s���Ă���ӏ����O�L���b�`����Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11003519-00 �쐬�S�� : ���V��
// �� �� ��  2015/04/29  �C�����e : Redmine#45436 �\�����ʍ̔Ԍ�A�ԍ���50������ꍇ�A�G���[�Ƃ��āA���O�ɏo�͂���Ή�
//----------------------------------------------------------------------------//

using System;
using System.Data;
using System.Text;
using System.Collections;
using System.Data.SqlClient;
using System.Collections.Generic;
using Broadleaf.Library.Data;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using System.Text.RegularExpressions;
using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Library.Data.SqlTypes;
using Broadleaf.Library.Diagnostics;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// �����Y�ƌ����}�X�^�ϊ�����DB�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note        : �����}�X�^�ϊ������̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer  : �i�N</br>
    /// <br>Date        : 2015/01/26</br>
    /// </remarks>
    [Serializable]
    public class MeijiJoinPartsDB : RemoteDB
    {
        #region ���������[�g
        // �����}�X�^�̃����[�g
        private JoinPartsUDB _joinPartsUDB;
        // �i�ԕϊ���������
        private GoodsNoChgCommonDB _iGoodsNoChgCommonDB;
        #endregion

        #region JoinPartsDB
        /// <summary>
        /// �����}�X�^�ϊ������R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note        : ���ɂȂ�</br>
        /// <br>Programmer  : �i�N</br>
        /// <br>Date        : 2015/01/26</br>
        /// </remarks>
        public MeijiJoinPartsDB()
        {
            // �����}�X�^
            if (this._joinPartsUDB == null)
            {
                this._joinPartsUDB = new JoinPartsUDB();
            }
            // �i�ԕϊ���������
            if (this._iGoodsNoChgCommonDB == null)
            {
                this._iGoodsNoChgCommonDB = new GoodsNoChgCommonDB();
            }
        }
        #endregion

        #region �����}�X�^�̎捞����
        /// <summary>
        /// �w�肳�ꂽ��ƃR�[�h�̌����̑S�Ė߂鏈��
        /// </summary>
        /// <param name="updateCount">�����̌���</param>
        /// <param name="joinerrorResultWork">�����������X�g</param>
        /// <param name="mode">�敪</param>
        /// <param name="enterPriseCode">��ƃR�[�h</param>
        /// <param name="joinSuccessResultWork">�捞�������X�g</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note        : �w�肳�ꂽ��ƃR�[�h�̌���LIST��S�Ė߂��܂�</br>
        /// <br>Programmer  : �i�N</br>
        /// <br>Date        : 2015/01/26</br>
        /// </remarks>
        public int ReadIn(out object joinSuccessResultWork, out object joinerrorResultWork, out int updateCount, int mode, string enterPriseCode)
        {
            // �R�l�N�V����
            SqlConnection sqlConnection = null;
            // �g�����U�N�V����
            SqlTransaction sqlTransaction = null;
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            #region �����}�X�^
            // �����}�X�^���O
            joinSuccessResultWork = null;
            joinerrorResultWork = null;
            ArrayList joinSuccessResultWorkList = new ArrayList();
            ArrayList joinerrorResultWorkList = new ArrayList();
            // �o�^����
            updateCount = 0;
            #endregion

            try
            {
                // �R�l�N�V��������
                sqlConnection = this._iGoodsNoChgCommonDB.CreateSqlConnection(true);

                // �g�����U�N�V�����J�n
                sqlTransaction = this._iGoodsNoChgCommonDB.CreateTransaction(ref sqlConnection);

                // �����}�X�^�ϊ�����
                status = JoinReadInProc(out joinSuccessResultWorkList, out joinerrorResultWorkList, out updateCount, mode, enterPriseCode, ref sqlConnection, ref sqlTransaction);

                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    return status;
                }

                // �߂��郊�X�g
                joinSuccessResultWork = joinSuccessResultWorkList;
                joinerrorResultWork = joinerrorResultWorkList;

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
                base.WriteErrorLog(ex, "JoinPartsDB.ReadIn");
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

        ///<summary>
        /// �w�肳�ꂽ��ƃR�[�h�̌����}�X�^�̎捞����
        /// </summary>
        /// <param name="joinSuccessResultWork">�捞�������X�g</param>
        /// <param name="updateCount">�����̌���</param>
        /// <param name="joinerrorResultWorkList">�����������X�g</param>
        /// <param name="mode">�敪</param>
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
        /// <br>Note        : Redmine#45436 �\�����ʍ̔Ԍ�A�ԍ���50������ꍇ�A�G���[�Ƃ��āA���O�ɏo�͂���Ή�</br>
        /// <br>Programmer  : ���V��</br>
        /// <br>Date        : 2015/04/29</br>
        /// </remarks>
        private int JoinReadInProc(out ArrayList joinSuccessResultWork, out ArrayList joinerrorResultWorkList, out int updateCount, int mode, string enterPriseCode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            // �߂���錋�ʃ��X�g
            joinSuccessResultWork = new ArrayList();
            joinerrorResultWorkList = new ArrayList();
            // ���S�폜���X�g
            ArrayList phyDeleteWorkList = new ArrayList();
            ArrayList DeleteWorkList = new ArrayList();
            // �ǉ����X�g
            ArrayList insertWorkList = new ArrayList();
            ArrayList haveWorkList = new ArrayList();
            ArrayList LogicalDeleteList = new ArrayList();
            ArrayList FinallyDeleteList = new ArrayList();
            ArrayList cndtnWorkList = new ArrayList();
            ArrayList coyList = new ArrayList();
            Dictionary<string, string> DeleteErrorDic = new Dictionary<string, string>();
            Dictionary<string, string> errorDic = new Dictionary<string, string>();
            Dictionary<string, string> _insertDic = new Dictionary<string, string>();
            Dictionary<string, int> _displayOrderDic = new Dictionary<string, int>(); // ADD �i�N 2015/04/13 �\�����ʏd���̑Ή�
            ArrayList ErrorDeleteList = new ArrayList();
            // �o�^����
            updateCount = 0;

            Dictionary<string, JoinPartsUWork> JoinDic = new Dictionary<string, JoinPartsUWork>();
            Dictionary<string, GoodsNoChangeErrorDataWork> goodsNoChgErrDic = new Dictionary<string, GoodsNoChangeErrorDataWork>();
            SqlConnection joinConnection = this._iGoodsNoChgCommonDB.CreateSqlConnection(true);
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            string goodsNoKeySrc = "";
            string goodsNoKeyDes = "";
            string specialNote = "";
            string errDBInsertKey = "";

            try
            {
                // --- ADD �i�N 2015/04/13 �\�����ʏd���̑Ή� ------>>>>>
                // �\�����ʂ���������
                status = this.SearchDisplayOrder(out _displayOrderDic, enterPriseCode, mode);
                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    return status;
                }
                // --- ADD �i�N 2015/04/13 �\�����ʏd���̑Ή� ------<<<<<
                // �����}�X�^�̌���
                status = this.JoinSearchProc(out phyDeleteWorkList, ref cndtnWorkList, mode, enterPriseCode, ref sqlConnection, ref sqlTransaction);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && phyDeleteWorkList.Count > 0)
                {
                    // �X�V����
                    updateCount = phyDeleteWorkList.Count;
                    // �V���i��Dictionary�̍쐬
                    foreach (NewJoinPartsWork newJoinPartsWork in cndtnWorkList)
                    {
                        string str = newJoinPartsWork.JoinSourceMakerCode + ":" + newJoinPartsWork.JoinSourPartsNoWithH;
                        DeleteErrorDic.Add(str, newJoinPartsWork.JoinDestPartsNo);
                    }
                    // �G���[�f�[�^�̍폜
                    status = this._iGoodsNoChgCommonDB.DeleteGoodsNoChangeErrorDataProc(enterPriseCode, GoodsNoChgCommonDB.JOINMST, ref sqlConnection, ref sqlTransaction);
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        foreach (JoinPartsUWork ajoinPartsUWork in phyDeleteWorkList)
                        {
                            goodsNoKeySrc = ajoinPartsUWork.JoinSourceMakerCode + ":" + ajoinPartsUWork.JoinSourPartsNoWithH;
                            goodsNoKeyDes = ajoinPartsUWork.JoinDestMakerCd + ":" + ajoinPartsUWork.JoinDestPartsNo;
                            // �g�����U�N�V�����̕ۑ�
                            sqlTransaction.Save("JoinSavePoint");
                            JoinPartsUWork bjoinPartsUWork = CloneJoinWork(ajoinPartsUWork);
                            NewJoinPartsWork sucNewJoinPartsWork = new NewJoinPartsWork();
                            sucNewJoinPartsWork.JoinSourPartsNoWithH = ajoinPartsUWork.JoinSourPartsNoWithH;
                            sucNewJoinPartsWork.JoinSourceMakerCode = ajoinPartsUWork.JoinSourceMakerCode;
                            sucNewJoinPartsWork.JoinDestPartsNo = ajoinPartsUWork.JoinDestPartsNo;
                            sucNewJoinPartsWork.JoinDestMakerCd = ajoinPartsUWork.JoinDestMakerCd;
                            if (DeleteErrorDic.ContainsKey(goodsNoKeySrc))
                            {
                                sucNewJoinPartsWork.NewJoinSourPartsNoWithH = DeleteErrorDic[goodsNoKeySrc];
                            }
                            else
                            {
                                sucNewJoinPartsWork.NewJoinSourPartsNoWithH = ajoinPartsUWork.JoinSourPartsNoWithH;
                            }
                            if (DeleteErrorDic.ContainsKey(goodsNoKeyDes))
                            {
                                sucNewJoinPartsWork.NewJoinDestPartsNo = DeleteErrorDic[goodsNoKeyDes];
                            }
                            else
                            {
                                sucNewJoinPartsWork.NewJoinDestPartsNo = ajoinPartsUWork.JoinDestPartsNo;
                            }
                            coyList.Add(ajoinPartsUWork);
                            // �����}�X�^�ō폜����
                            //----- ADD 2015/04/17 ���V�� Redmine#45436 ���i���g�p���ă}�X�^�̍폜/�o�^�����s���Ă���ӏ����O�L���b�`����Ή�------>>>>>
                            try
                            {
                            //----- ADD 2015/04/17 ���V�� Redmine#45436 ���i���g�p���ă}�X�^�̍폜/�o�^�����s���Ă���ӏ����O�L���b�`����Ή�------<<<<<
                                status = this._joinPartsUDB.Delete(coyList, ref  sqlConnection, ref sqlTransaction);
                            //----- ADD 2015/04/17 ���V�� Redmine#45436 ���i���g�p���ă}�X�^�̍폜/�o�^�����s���Ă���ӏ����O�L���b�`����Ή�------>>>>>
                            }
                            catch (Exception ex)
                            {
                                base.WriteErrorLog(ex, "Delete");
                                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                            }
                            //----- ADD 2015/04/17 ���V�� Redmine#45436 ���i���g�p���ă}�X�^�̍폜/�o�^�����s���Ă���ӏ����O�L���b�`����Ή�------<<<<<
                            coyList.Clear();
                            if (status == (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE || status == (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE)
                            {
                                string stra = ajoinPartsUWork.JoinSourceMakerCode + ":" + ajoinPartsUWork.JoinSourPartsNoWithH;
                                string strb = ajoinPartsUWork.JoinDestMakerCd + ":" + ajoinPartsUWork.JoinDestPartsNo;
                                if (DeleteErrorDic.ContainsKey(stra))
                                {
                                    GoodsNoChangeErrorDataWork goodsNoChangeErrorDataWork = new GoodsNoChangeErrorDataWork();
                                    goodsNoChangeErrorDataWork.MasterDivCd = GoodsNoChgCommonDB.JOINMST;
                                    goodsNoChangeErrorDataWork.ChgSrcGoodsNo = ajoinPartsUWork.JoinSourPartsNoWithH;
                                    goodsNoChangeErrorDataWork.GoodsMakerCd = ajoinPartsUWork.JoinSourceMakerCode;
                                    goodsNoChangeErrorDataWork.ChgDestGoodsNo = DeleteErrorDic[stra];
                                    goodsNoChangeErrorDataWork.UpdateDateTime = DateTime.MinValue;
                                    if (!errorDic.ContainsKey(stra))
                                    {
                                        errorDic.Add(stra, "");
                                        ErrorDeleteList.Add(goodsNoChangeErrorDataWork);
                                    }
                                }
                                if (DeleteErrorDic.ContainsKey(strb))
                                {
                                    GoodsNoChangeErrorDataWork goodsNoChangeErrorDataWork = new GoodsNoChangeErrorDataWork();
                                    goodsNoChangeErrorDataWork.MasterDivCd = GoodsNoChgCommonDB.JOINMST;
                                    goodsNoChangeErrorDataWork.ChgSrcGoodsNo = ajoinPartsUWork.JoinDestPartsNo;
                                    goodsNoChangeErrorDataWork.GoodsMakerCd = ajoinPartsUWork.JoinDestMakerCd;
                                    goodsNoChangeErrorDataWork.ChgDestGoodsNo = DeleteErrorDic[strb];
                                    goodsNoChangeErrorDataWork.UpdateDateTime = DateTime.MinValue;
                                    if (!errorDic.ContainsKey(strb))
                                    {
                                        errorDic.Add(strb, "");
                                        ErrorDeleteList.Add(goodsNoChangeErrorDataWork);
                                    }
                                }
                                //sucNewJoinPartsWork.OutNote = "�r���G���[�A�ϊ����i�Ԃ̍폜�Ɏ��s���܂���"; // DEL 2015/02/26 ���V�� Redmine#44209 ���b�Z�[�W�̕����Ή�
                                sucNewJoinPartsWork.OutNote = string.Format(GoodsNoChgCommonDB.UPDATEFAIL, "�����}�X�^"); // ADD 2015/02/26 ���V�� Redmine#44209 ���b�Z�[�W�̕����Ή�
                                joinerrorResultWorkList.Add(sucNewJoinPartsWork);
                            }
                            else if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                // ���i�Ԃ���V�i�Ԃ�ύX����
                                foreach (NewJoinPartsWork anewJoinPartsWork in cndtnWorkList)
                                {
                                    if (ajoinPartsUWork.JoinDestMakerCd == anewJoinPartsWork.JoinSourceMakerCode && ajoinPartsUWork.JoinDestPartsNo.Equals(anewJoinPartsWork.JoinSourPartsNoWithH))
                                    {
                                        ajoinPartsUWork.JoinDestPartsNo = anewJoinPartsWork.JoinDestPartsNo;
                                        if (string.IsNullOrEmpty(ajoinPartsUWork.JoinSpecialNote))
                                        {
                                            ajoinPartsUWork.JoinSpecialNote = anewJoinPartsWork.JoinSourPartsNoWithH;
                                        }
                                        else
                                        {
                                            specialNote = ajoinPartsUWork.JoinSpecialNote + " " + anewJoinPartsWork.JoinSourPartsNoWithH;
                                            if (!string.IsNullOrEmpty(specialNote) && specialNote.Length > 40)
                                            {
                                                ajoinPartsUWork.JoinSpecialNote = specialNote.Substring(0, 40);
                                            }
                                            else
                                            {
                                                ajoinPartsUWork.JoinSpecialNote = specialNote;
                                            }
                                        }
                                    }

                                    if (ajoinPartsUWork.JoinSourceMakerCode == anewJoinPartsWork.JoinSourceMakerCode && ajoinPartsUWork.JoinSourPartsNoWithH.Equals(anewJoinPartsWork.JoinSourPartsNoWithH))
                                    {
                                        ajoinPartsUWork.JoinSourPartsNoWithH = anewJoinPartsWork.JoinDestPartsNo;
                                        ajoinPartsUWork.JoinSourPartsNoNoneH = anewJoinPartsWork.JoinDestPartsNo.Replace("-", "");
                                    }
                                }

                                //----- ADD 2015/04/07 ���V�� Redmine#44209 �ϊ���̌��i�ԂƐ�i�Ԃ�����̏ꍇ�̓G���[�Ƃ���Ή�------>>>>>
                                if (!string.IsNullOrEmpty(ajoinPartsUWork.JoinSourPartsNoWithH.Trim())
                                    && ajoinPartsUWork.JoinSourPartsNoWithH.Trim().Equals(ajoinPartsUWork.JoinDestPartsNo.Trim())
                                    && ajoinPartsUWork.JoinSourceMakerCode == ajoinPartsUWork.JoinDestMakerCd)
                                {
                                    string repeatStra = bjoinPartsUWork.JoinSourceMakerCode + ":" + bjoinPartsUWork.JoinSourPartsNoWithH;
                                    string repeatStrb = bjoinPartsUWork.JoinDestMakerCd + ":" + bjoinPartsUWork.JoinDestPartsNo;
                                    if (DeleteErrorDic.ContainsKey(repeatStra))
                                    {
                                        GoodsNoChangeErrorDataWork goodsNoChangeErrorDataWork = new GoodsNoChangeErrorDataWork();
                                        goodsNoChangeErrorDataWork.MasterDivCd = GoodsNoChgCommonDB.JOINMST;
                                        goodsNoChangeErrorDataWork.ChgSrcGoodsNo = bjoinPartsUWork.JoinSourPartsNoWithH;
                                        goodsNoChangeErrorDataWork.GoodsMakerCd = bjoinPartsUWork.JoinSourceMakerCode;
                                        goodsNoChangeErrorDataWork.ChgDestGoodsNo = DeleteErrorDic[repeatStra];
                                        goodsNoChangeErrorDataWork.UpdateDateTime = DateTime.MinValue;
                                        if (!errorDic.ContainsKey(repeatStra))
                                        {
                                            errorDic.Add(repeatStra, "");
                                            ErrorDeleteList.Add(goodsNoChangeErrorDataWork);
                                        }
                                    }
                                    if (DeleteErrorDic.ContainsKey(repeatStrb))
                                    {
                                        GoodsNoChangeErrorDataWork goodsNoChangeErrorDataWork = new GoodsNoChangeErrorDataWork();
                                        goodsNoChangeErrorDataWork.MasterDivCd = GoodsNoChgCommonDB.JOINMST;
                                        goodsNoChangeErrorDataWork.ChgSrcGoodsNo = bjoinPartsUWork.JoinDestPartsNo;
                                        goodsNoChangeErrorDataWork.GoodsMakerCd = bjoinPartsUWork.JoinDestMakerCd;
                                        goodsNoChangeErrorDataWork.ChgDestGoodsNo = DeleteErrorDic[repeatStrb];
                                        goodsNoChangeErrorDataWork.UpdateDateTime = DateTime.MinValue;
                                        if (!errorDic.ContainsKey(repeatStrb))
                                        {
                                            errorDic.Add(repeatStrb, "");
                                            ErrorDeleteList.Add(goodsNoChangeErrorDataWork);
                                        }
                                    }
                                    sucNewJoinPartsWork.OutNote = GoodsNoChgCommonDB.REPEATJOINMSG;
                                    joinerrorResultWorkList.Add(sucNewJoinPartsWork);

                                    status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                                }

                                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                {
                                    //----- ADD 2015/04/07 ���V�� Redmine#44209 �ϊ���̌��i�ԂƐ�i�Ԃ�����̏ꍇ�̓G���[�Ƃ���Ή�------<<<<<
                                    ajoinPartsUWork.UpdateDateTime = DateTime.MinValue;

                                    int logicalDeleteCode = ajoinPartsUWork.LogicalDeleteCode;
                                    // --- ADD �i�N 2015/04/13 �\�����ʏd���̑Ή� ------>>>>>
                                    string displayOrderKey = ajoinPartsUWork.JoinSourceMakerCode.ToString().Trim().PadLeft(4, '0') + ":" + ajoinPartsUWork.JoinSourPartsNoWithH.Trim();
                                    if (_displayOrderDic.ContainsKey(displayOrderKey))
                                    {
                                        ajoinPartsUWork.JoinDispOrder = _displayOrderDic[displayOrderKey] + 1;
                                    }
                                    //----- ADD 2015/04/29 ���V�� Redmine#45436 �\�����ʍ̔Ԍ�A�ԍ���50������ꍇ�A�G���[�Ƃ��āA���O�ɏo�͂���Ή�------>>>>>
                                    if (ajoinPartsUWork.JoinDispOrder > 50)
                                    {
                                        string straOver = bjoinPartsUWork.JoinSourceMakerCode + ":" + bjoinPartsUWork.JoinSourPartsNoWithH;
                                        string strbOver = bjoinPartsUWork.JoinDestMakerCd + ":" + bjoinPartsUWork.JoinDestPartsNo;
                                        if (DeleteErrorDic.ContainsKey(straOver))
                                        {
                                            GoodsNoChangeErrorDataWork goodsNoChangeErrorDataWork = new GoodsNoChangeErrorDataWork();
                                            goodsNoChangeErrorDataWork.MasterDivCd = GoodsNoChgCommonDB.JOINMST;
                                            goodsNoChangeErrorDataWork.ChgSrcGoodsNo = bjoinPartsUWork.JoinSourPartsNoWithH;
                                            goodsNoChangeErrorDataWork.GoodsMakerCd = bjoinPartsUWork.JoinSourceMakerCode;
                                            goodsNoChangeErrorDataWork.ChgDestGoodsNo = DeleteErrorDic[straOver];
                                            goodsNoChangeErrorDataWork.UpdateDateTime = DateTime.MinValue;
                                            if (!errorDic.ContainsKey(straOver))
                                            {
                                                errorDic.Add(straOver, "");
                                                ErrorDeleteList.Add(goodsNoChangeErrorDataWork);
                                            }
                                        }
                                        if (DeleteErrorDic.ContainsKey(strbOver))
                                        {
                                            GoodsNoChangeErrorDataWork goodsNoChangeErrorDataWork = new GoodsNoChangeErrorDataWork();
                                            goodsNoChangeErrorDataWork.MasterDivCd = GoodsNoChgCommonDB.JOINMST;
                                            goodsNoChangeErrorDataWork.ChgSrcGoodsNo = bjoinPartsUWork.JoinDestPartsNo;
                                            goodsNoChangeErrorDataWork.GoodsMakerCd = bjoinPartsUWork.JoinDestMakerCd;
                                            goodsNoChangeErrorDataWork.ChgDestGoodsNo = DeleteErrorDic[strbOver];
                                            goodsNoChangeErrorDataWork.UpdateDateTime = DateTime.MinValue;
                                            if (!errorDic.ContainsKey(strbOver))
                                            {
                                                errorDic.Add(strbOver, "");
                                                ErrorDeleteList.Add(goodsNoChangeErrorDataWork);
                                            }
                                        }
                                        sucNewJoinPartsWork.OutNote = GoodsNoChgCommonDB.DISPORDEROVERNUMBER;
                                        joinerrorResultWorkList.Add(sucNewJoinPartsWork);

                                        status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                                    }
                                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                    {
                                    //----- ADD 2015/04/29 ���V�� Redmine#45436 �\�����ʍ̔Ԍ�A�ԍ���50������ꍇ�A�G���[�Ƃ��āA���O�ɏo�͂���Ή�------<<<<<
                                        // --- ADD �i�N 2015/04/13 �\�����ʏd���̑Ή� ------<<<<<
                                        insertWorkList.Add(ajoinPartsUWork);
                                        //----- ADD 2015/04/17 ���V�� Redmine#45436 ���i���g�p���ă}�X�^�̍폜/�o�^�����s���Ă���ӏ����O�L���b�`����Ή�------>>>>>
                                        try
                                        {
                                            //----- ADD 2015/04/17 ���V�� Redmine#45436 ���i���g�p���ă}�X�^�̍폜/�o�^�����s���Ă���ӏ����O�L���b�`����Ή�------<<<<<
                                            status = this._joinPartsUDB.Write(ref insertWorkList, ref  sqlConnection, ref sqlTransaction);
                                            //----- ADD 2015/04/17 ���V�� Redmine#45436 ���i���g�p���ă}�X�^�̍폜/�o�^�����s���Ă���ӏ����O�L���b�`����Ή�------>>>>>
                                        }
                                        catch (Exception ex)
                                        {
                                            base.WriteErrorLog(ex, "Write");
                                            status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                                        }
                                        //----- ADD 2015/04/17 ���V�� Redmine#45436 ���i���g�p���ă}�X�^�̍폜/�o�^�����s���Ă���ӏ����O�L���b�`����Ή�------<<<<<
                                        insertWorkList.Clear();
                                        // �����}�X�^�ɋ��i�ԑΉ��̐V�i�Ԃ����ɑ��݂���ꍇ�A�r�����b�Z�[�W�̃Z�b�g
                                        if (status == (int)ConstantManagement.DB_Status.ctDB_DUPLICATE || status == (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE)
                                        {
                                            string stra = bjoinPartsUWork.JoinSourceMakerCode + ":" + bjoinPartsUWork.JoinSourPartsNoWithH;
                                            string strb = bjoinPartsUWork.JoinDestMakerCd + ":" + bjoinPartsUWork.JoinDestPartsNo;
                                            if (DeleteErrorDic.ContainsKey(stra))
                                            {
                                                GoodsNoChangeErrorDataWork goodsNoChangeErrorDataWork = new GoodsNoChangeErrorDataWork();
                                                goodsNoChangeErrorDataWork.MasterDivCd = GoodsNoChgCommonDB.JOINMST;
                                                goodsNoChangeErrorDataWork.ChgSrcGoodsNo = bjoinPartsUWork.JoinSourPartsNoWithH;
                                                goodsNoChangeErrorDataWork.GoodsMakerCd = bjoinPartsUWork.JoinSourceMakerCode;
                                                goodsNoChangeErrorDataWork.ChgDestGoodsNo = DeleteErrorDic[stra];
                                                goodsNoChangeErrorDataWork.UpdateDateTime = DateTime.MinValue;
                                                if (!errorDic.ContainsKey(stra))
                                                {
                                                    errorDic.Add(stra, "");
                                                    ErrorDeleteList.Add(goodsNoChangeErrorDataWork);
                                                }
                                            }
                                            if (DeleteErrorDic.ContainsKey(strb))
                                            {
                                                GoodsNoChangeErrorDataWork goodsNoChangeErrorDataWork = new GoodsNoChangeErrorDataWork();
                                                goodsNoChangeErrorDataWork.MasterDivCd = GoodsNoChgCommonDB.JOINMST;
                                                goodsNoChangeErrorDataWork.ChgSrcGoodsNo = bjoinPartsUWork.JoinDestPartsNo;
                                                goodsNoChangeErrorDataWork.GoodsMakerCd = bjoinPartsUWork.JoinDestMakerCd;
                                                goodsNoChangeErrorDataWork.ChgDestGoodsNo = DeleteErrorDic[strb];
                                                goodsNoChangeErrorDataWork.UpdateDateTime = DateTime.MinValue;
                                                if (!errorDic.ContainsKey(strb))
                                                {
                                                    errorDic.Add(strb, "");
                                                    ErrorDeleteList.Add(goodsNoChangeErrorDataWork);
                                                }
                                            }
                                            //sucNewJoinPartsWork.OutNote = "�ϊ���i�Ԃ����ɓo�^����܂���"; // DEL 2015/02/26 ���V�� Redmine#44209 ���b�Z�[�W�̕����Ή�
                                            sucNewJoinPartsWork.OutNote = string.Format(GoodsNoChgCommonDB.EXISTMSG, "�����}�X�^"); // ADD 2015/02/26 ���V�� Redmine#44209 ���b�Z�[�W�̕����Ή�
                                            joinerrorResultWorkList.Add(sucNewJoinPartsWork);
                                        }
                                        else if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                        {
                                            // --- ADD �i�N 2015/04/13 �\�����ʏd���̑Ή� ------>>>>>
                                            if (_displayOrderDic.ContainsKey(displayOrderKey))
                                            {
                                                _displayOrderDic[displayOrderKey] = _displayOrderDic[displayOrderKey] + 1;
                                            }
                                            // --- ADD �i�N 2015/04/13 �\�����ʏd���̑Ή� ------<<<<<
                                            if (logicalDeleteCode == 1)
                                            {
                                                LogicalDeleteList.Add(ajoinPartsUWork);
                                                //----- ADD 2015/04/17 ���V�� Redmine#45436 ���i���g�p���ă}�X�^�̍폜/�o�^�����s���Ă���ӏ����O�L���b�`����Ή�------>>>>>
                                                try
                                                {
                                                    //----- ADD 2015/04/17 ���V�� Redmine#45436 ���i���g�p���ă}�X�^�̍폜/�o�^�����s���Ă���ӏ����O�L���b�`����Ή�------<<<<<
                                                    status = this._joinPartsUDB.LogicalDelete(ref LogicalDeleteList, 0, ref  sqlConnection, ref  sqlTransaction);
                                                    //----- ADD 2015/04/17 ���V�� Redmine#45436 ���i���g�p���ă}�X�^�̍폜/�o�^�����s���Ă���ӏ����O�L���b�`����Ή�------>>>>>
                                                }
                                                catch (Exception ex)
                                                {
                                                    base.WriteErrorLog(ex, "LogicalDelete");
                                                    status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                                                }
                                                //----- ADD 2015/04/17 ���V�� Redmine#45436 ���i���g�p���ă}�X�^�̍폜/�o�^�����s���Ă���ӏ����O�L���b�`����Ή�------<<<<<
                                                LogicalDeleteList.Clear();
                                                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                                {
                                                    //sucNewJoinPartsWork.OutNote = "�_���폜�f�[�^"; // DEL 2015/02/26 ���V�� Redmine#44209 ���b�Z�[�W�̕����Ή�
                                                    sucNewJoinPartsWork.OutNote = GoodsNoChgCommonDB.DELETEMSG; // ADD 2015/02/26 ���V�� Redmine#44209 ���b�Z�[�W�̕����Ή�
                                                    joinSuccessResultWork.Add(sucNewJoinPartsWork);
                                                }
                                                else
                                                {
                                                    string stra = bjoinPartsUWork.JoinSourceMakerCode + ":" + bjoinPartsUWork.JoinSourPartsNoWithH;
                                                    string strb = bjoinPartsUWork.JoinDestMakerCd + ":" + bjoinPartsUWork.JoinDestPartsNo;
                                                    if (DeleteErrorDic.ContainsKey(stra))
                                                    {
                                                        GoodsNoChangeErrorDataWork goodsNoChangeErrorDataWork = new GoodsNoChangeErrorDataWork();
                                                        goodsNoChangeErrorDataWork.MasterDivCd = GoodsNoChgCommonDB.JOINMST;
                                                        goodsNoChangeErrorDataWork.ChgSrcGoodsNo = bjoinPartsUWork.JoinSourPartsNoWithH;
                                                        goodsNoChangeErrorDataWork.GoodsMakerCd = bjoinPartsUWork.JoinSourceMakerCode;
                                                        goodsNoChangeErrorDataWork.ChgDestGoodsNo = DeleteErrorDic[stra];
                                                        goodsNoChangeErrorDataWork.UpdateDateTime = DateTime.MinValue;
                                                        if (!errorDic.ContainsKey(stra))
                                                        {
                                                            errorDic.Add(stra, "");
                                                            ErrorDeleteList.Add(goodsNoChangeErrorDataWork);
                                                        }
                                                    }
                                                    if (DeleteErrorDic.ContainsKey(strb))
                                                    {
                                                        GoodsNoChangeErrorDataWork goodsNoChangeErrorDataWork = new GoodsNoChangeErrorDataWork();
                                                        goodsNoChangeErrorDataWork.MasterDivCd = GoodsNoChgCommonDB.JOINMST;
                                                        goodsNoChangeErrorDataWork.ChgSrcGoodsNo = bjoinPartsUWork.JoinDestPartsNo;
                                                        goodsNoChangeErrorDataWork.GoodsMakerCd = bjoinPartsUWork.JoinDestMakerCd;
                                                        goodsNoChangeErrorDataWork.ChgDestGoodsNo = DeleteErrorDic[strb];
                                                        goodsNoChangeErrorDataWork.UpdateDateTime = DateTime.MinValue;
                                                        if (!errorDic.ContainsKey(strb))
                                                        {
                                                            errorDic.Add(strb, "");
                                                            ErrorDeleteList.Add(goodsNoChangeErrorDataWork);
                                                        }
                                                    }
                                                    //sucNewJoinPartsWork.OutNote = "�o�^�G���[�A�ϊ���i�Ԃ̓o�^�Ɏ��s���܂���"; // DEL 2015/02/26 ���V�� Redmine#44209 ���b�Z�[�W�̕����Ή�
                                                    sucNewJoinPartsWork.OutNote = GoodsNoChgCommonDB.NEWEXCEPTIONMSG; // ADD 2015/02/26 ���V�� Redmine#44209 ���b�Z�[�W�̕����Ή�
                                                    joinerrorResultWorkList.Add(sucNewJoinPartsWork);
                                                }
                                            }
                                            else
                                            {
                                                joinSuccessResultWork.Add(sucNewJoinPartsWork);
                                            }
                                        }
                                        else
                                        {
                                            string stra = bjoinPartsUWork.JoinSourceMakerCode + ":" + bjoinPartsUWork.JoinSourPartsNoWithH;
                                            string strb = bjoinPartsUWork.JoinDestMakerCd + ":" + bjoinPartsUWork.JoinDestPartsNo;
                                            if (DeleteErrorDic.ContainsKey(stra))
                                            {
                                                GoodsNoChangeErrorDataWork goodsNoChangeErrorDataWork = new GoodsNoChangeErrorDataWork();
                                                goodsNoChangeErrorDataWork.MasterDivCd = GoodsNoChgCommonDB.JOINMST;
                                                goodsNoChangeErrorDataWork.ChgSrcGoodsNo = bjoinPartsUWork.JoinSourPartsNoWithH;
                                                goodsNoChangeErrorDataWork.GoodsMakerCd = bjoinPartsUWork.JoinSourceMakerCode;
                                                goodsNoChangeErrorDataWork.ChgDestGoodsNo = DeleteErrorDic[stra];
                                                goodsNoChangeErrorDataWork.UpdateDateTime = DateTime.MinValue;
                                                if (!errorDic.ContainsKey(stra))
                                                {
                                                    errorDic.Add(stra, "");
                                                    ErrorDeleteList.Add(goodsNoChangeErrorDataWork);
                                                }
                                            }
                                            if (DeleteErrorDic.ContainsKey(strb))
                                            {
                                                GoodsNoChangeErrorDataWork goodsNoChangeErrorDataWork = new GoodsNoChangeErrorDataWork();
                                                goodsNoChangeErrorDataWork.MasterDivCd = GoodsNoChgCommonDB.JOINMST;
                                                goodsNoChangeErrorDataWork.ChgSrcGoodsNo = bjoinPartsUWork.JoinDestPartsNo;
                                                goodsNoChangeErrorDataWork.GoodsMakerCd = bjoinPartsUWork.JoinDestMakerCd;
                                                goodsNoChangeErrorDataWork.ChgDestGoodsNo = DeleteErrorDic[strb];
                                                goodsNoChangeErrorDataWork.UpdateDateTime = DateTime.MinValue;
                                                if (!errorDic.ContainsKey(strb))
                                                {
                                                    errorDic.Add(strb, "");
                                                    ErrorDeleteList.Add(goodsNoChangeErrorDataWork);
                                                }
                                            }
                                            //sucNewJoinPartsWork.OutNote = "�o�^�G���[�A�ϊ���i�Ԃ̓o�^�Ɏ��s���܂���"; // DEL 2015/02/26 ���V�� Redmine#44209 ���b�Z�[�W�̕����Ή�
                                            sucNewJoinPartsWork.OutNote = GoodsNoChgCommonDB.NEWEXCEPTIONMSG; // ADD 2015/02/26 ���V�� Redmine#44209 ���b�Z�[�W�̕����Ή�
                                            joinerrorResultWorkList.Add(sucNewJoinPartsWork);
                                        }
                                    }  // ADD 2015/04/29 ���V�� Redmine#45436 �\�����ʍ̔Ԍ�A�ԍ���50������ꍇ�A�G���[�Ƃ��āA���O�ɏo�͂���Ή�
                                }// ADD 2015/04/07 ���V�� Redmine#44209 �ϊ���̌��i�ԂƐ�i�Ԃ�����̏ꍇ�̓G���[�Ƃ���Ή�
                            }
                            else
                            {
                                string stra = ajoinPartsUWork.JoinSourceMakerCode + ":" + ajoinPartsUWork.JoinSourPartsNoWithH;
                                string strb = ajoinPartsUWork.JoinDestMakerCd + ":" + ajoinPartsUWork.JoinDestPartsNo;
                                if (DeleteErrorDic.ContainsKey(stra))
                                {
                                    GoodsNoChangeErrorDataWork goodsNoChangeErrorDataWork = new GoodsNoChangeErrorDataWork();
                                    goodsNoChangeErrorDataWork.MasterDivCd = GoodsNoChgCommonDB.JOINMST;
                                    goodsNoChangeErrorDataWork.ChgSrcGoodsNo = ajoinPartsUWork.JoinSourPartsNoWithH;
                                    goodsNoChangeErrorDataWork.GoodsMakerCd = ajoinPartsUWork.JoinSourceMakerCode;
                                    goodsNoChangeErrorDataWork.ChgDestGoodsNo = DeleteErrorDic[stra];
                                    goodsNoChangeErrorDataWork.UpdateDateTime = DateTime.MinValue;
                                    if (!errorDic.ContainsKey(stra))
                                    {
                                        errorDic.Add(stra, "");
                                        ErrorDeleteList.Add(goodsNoChangeErrorDataWork);
                                    }
                                }
                                if (DeleteErrorDic.ContainsKey(strb))
                                {
                                    GoodsNoChangeErrorDataWork goodsNoChangeErrorDataWork = new GoodsNoChangeErrorDataWork();
                                    goodsNoChangeErrorDataWork.MasterDivCd = GoodsNoChgCommonDB.JOINMST;
                                    goodsNoChangeErrorDataWork.ChgSrcGoodsNo = ajoinPartsUWork.JoinDestPartsNo;
                                    goodsNoChangeErrorDataWork.GoodsMakerCd = ajoinPartsUWork.JoinDestMakerCd;
                                    goodsNoChangeErrorDataWork.ChgDestGoodsNo = DeleteErrorDic[strb];
                                    goodsNoChangeErrorDataWork.UpdateDateTime = DateTime.MinValue;
                                    if (!errorDic.ContainsKey(strb))
                                    {
                                        errorDic.Add(strb, "");
                                        ErrorDeleteList.Add(goodsNoChangeErrorDataWork);
                                    }
                                }
                                //sucNewJoinPartsWork.OutNote = "�폜�G���[�A�ϊ����i�Ԃ̍폜�Ɏ��s���܂���"; // DEL 2015/02/26 ���V�� Redmine#44209 ���b�Z�[�W�̕����Ή�
                                sucNewJoinPartsWork.OutNote = GoodsNoChgCommonDB.OLDEXCEPTIONMSG; // ADD 2015/02/26 ���V�� Redmine#44209 ���b�Z�[�W�̕����Ή�
                                joinerrorResultWorkList.Add(sucNewJoinPartsWork);
                            }

                            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                sqlTransaction.Rollback("JoinSavePoint");
                            }
                        }
                        phyDeleteWorkList.Clear();

                        #region �i�ԕϊ��G���[�f�[�^�̍X�V
                        if (ErrorDeleteList != null && ErrorDeleteList.Count > 0)
                        {
                            foreach (GoodsNoChangeErrorDataWork goodsNoChangeErrorDataWork in ErrorDeleteList)
                            {
                                errDBInsertKey = goodsNoChangeErrorDataWork.GoodsMakerCd.ToString() + "-" + goodsNoChangeErrorDataWork.ChgSrcGoodsNo;
                                if (!goodsNoChgErrDic.ContainsKey(errDBInsertKey))
                                {
                                    goodsNoChgErrDic.Add(errDBInsertKey, goodsNoChangeErrorDataWork);
                                }
                            }
                            status = this._iGoodsNoChgCommonDB.WriteGoodsNoChangeErrorDataProc(goodsNoChgErrDic, ref sqlConnection, ref sqlTransaction);
                        }

                        if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            joinSuccessResultWork.Clear();
                            joinerrorResultWorkList.Clear();
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
                base.WriteErrorLog(ex, "JoinPartsDB.JoinReadInProc");
                return (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (joinConnection != null)
                {
                    joinConnection.Close();
                    joinConnection.Dispose();
                }
            }
        }
        #endregion

        #region
        /// <summary>
        /// �����}�X�^�ϊ������̌���
        /// </summary>
        /// <param name="deleteWorkList">��������</param>
        /// <param name="cndtnWorkList">�����p�����[�^</param>
        /// <param name="mode">�敪</param>
        /// <param name="enterPriseCode">��ƃR�[�h</param>
        /// <param name="sqlConnection">�R�l�N�V����</param>
        /// <param name="sqlTransaction">�g�����U�N�V����</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Programmer  : �i�N</br>
        /// <br>Date        : 2015/01/26</br>
        /// </remarks>
        private int JoinSearchProc(out ArrayList deleteWorkList, ref ArrayList cndtnWorkList, int mode, string enterPriseCode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            Dictionary<string, string> loginDic = new Dictionary<string, string>();
            Dictionary<string, string> CntDic = new Dictionary<string, string>();
            deleteWorkList = new ArrayList();
            cndtnWorkList = new ArrayList();
            try
            {
                sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);
                StringBuilder sb = new StringBuilder();
                sb.Append(
                    " SELECT " +
                    "A.LOGICALDELETECODERF ," +
                    "A.UPDASSEMBLYID2RF ," +
                    "A.UPDASSEMBLYID1RF ," +
                    "A.UPDEMPLOYEECODERF ," +
                    "A.FILEHEADERGUIDRF ," +
                    "A.ENTERPRISECODERF ," +
                    "A.CREATEDATETIMERF ," +
                    "A.UPDATEDATETIMERF ," +
                    "A.JOINSOURCEMAKERCODERF ," +
                    "A.JOINSOURPARTSNOWITHHRF ," +
                    "A.JOINSOURPARTSNONONEHRF ," +
                    "A.JOINDESTMAKERCDRF ," +
                    "A.JOINDESTPARTSNORF ," +
                    "A.JOINDISPORDERRF ," +
                    "A.JOINQTYRF ," +
                    "A.JOINSPECIALNOTERF ," +
                    "B.GOODSMAKERCDRF ," +
                    "B.CHGSRCGOODSNORF ," +
                    "B.CHGDESTGOODSNORF " +
                    " FROM " +
                    "JOINPARTSURF A WITH (READUNCOMMITTED) " +
                    "INNER JOIN ");

                if (mode == 0)
                {
                    sb.Append(" GOODSNOCHANGERF B WITH (READUNCOMMITTED) " +
                              "ON " +
                              "( A.JOINSOURCEMAKERCODERF = B.GOODSMAKERCDRF AND A.JOINSOURPARTSNOWITHHRF = B.CHGSRCGOODSNORF AND B.ENTERPRISECODERF = A.ENTERPRISECODERF ) " +
                              "OR ( A.JOINDESTMAKERCDRF = B.GOODSMAKERCDRF AND A.JOINDESTPARTSNORF = B.CHGSRCGOODSNORF AND B.ENTERPRISECODERF = A.ENTERPRISECODERF ) " +
                              "WHERE A.ENTERPRISECODERF = @ENTERPRISECODERF AND B.LOGICALDELETECODERF = 0 " +
                              "ORDER BY A.ENTERPRISECODERF, A.JOINSOURCEMAKERCODERF, A.JOINSOURPARTSNOWITHHRF, A.JOINDESTMAKERCDRF, A.JOINDESTPARTSNORF ");
                }
                else if (mode == 1)
                {
                    sb.Append(" GOODSNOCHANGEERRDTRF B WITH (READUNCOMMITTED) " +
                             "ON " +
                             "( A.JOINSOURCEMAKERCODERF = B.GOODSMAKERCDRF AND A.JOINSOURPARTSNOWITHHRF = B.CHGSRCGOODSNORF AND B.ENTERPRISECODERF = A.ENTERPRISECODERF ) " +
                             "OR ( A.JOINDESTMAKERCDRF = B.GOODSMAKERCDRF AND A.JOINDESTPARTSNORF = B.CHGSRCGOODSNORF AND B.ENTERPRISECODERF = A.ENTERPRISECODERF ) " +
                             "WHERE A.ENTERPRISECODERF = @ENTERPRISECODERF AND B.MASTERDIVCDRF = 4 AND B.LOGICALDELETECODERF = 0 " +
                             "ORDER BY A.ENTERPRISECODERF, A.JOINSOURCEMAKERCODERF, A.JOINSOURPARTSNOWITHHRF, A.JOINDESTMAKERCDRF, A.JOINDESTPARTSNORF ");
                }

                //Prameter�I�u�W�F�N�g�̍쐬
                SqlParameter findParaJoinEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODERF", SqlDbType.NChar);
                //Parameter�I�u�W�F�N�g�֒l�ݒ�
                findParaJoinEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterPriseCode);
                sqlCommand.CommandText = sb.ToString();

                // �N�G�����s���̃^�C���A�E�g���Ԃ�10���ɐݒ肷��
                sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitInquiry);
                myReader = sqlCommand.ExecuteReader();

                if (myReader == null)
                {
                    return (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                }
                while (myReader.Read())
                {
                    JoinPartsUWork joinPartsUWork = new JoinPartsUWork();
                    NewJoinPartsWork newJoinPartsWork = new NewJoinPartsWork();
                    string str = string.Empty;
                    string str1 = string.Empty;
                    joinPartsUWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                    joinPartsUWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                    joinPartsUWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                    joinPartsUWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                    joinPartsUWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                    joinPartsUWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                    joinPartsUWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                    joinPartsUWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                    joinPartsUWork.JoinSourceMakerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("JOINSOURCEMAKERCODERF"));
                    joinPartsUWork.JoinSourPartsNoWithH = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("JOINSOURPARTSNOWITHHRF"));
                    joinPartsUWork.JoinSourPartsNoNoneH = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("JOINSOURPARTSNONONEHRF")).Trim();
                    joinPartsUWork.JoinDestMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("JOINDESTMAKERCDRF"));
                    joinPartsUWork.JoinDestPartsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("JOINDESTPARTSNORF")).Trim();
                    joinPartsUWork.JoinDispOrder = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("JOINDISPORDERRF"));
                    joinPartsUWork.JoinQty = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("JOINQTYRF"));
                    joinPartsUWork.JoinSpecialNote = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("JOINSPECIALNOTERF")).Trim();
                    newJoinPartsWork.JoinSourceMakerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
                    newJoinPartsWork.JoinDestPartsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CHGDESTGOODSNORF")).Trim();
                    newJoinPartsWork.JoinSourPartsNoWithH = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CHGSRCGOODSNORF")).Trim();
                    str = joinPartsUWork.JoinSourceMakerCode + ":" + joinPartsUWork.JoinSourPartsNoWithH + ":" + joinPartsUWork.JoinDestMakerCd + ":" + joinPartsUWork.JoinDestPartsNo;
                    str1 = newJoinPartsWork.JoinSourceMakerCode + ":" + newJoinPartsWork.JoinDestPartsNo + ":" + newJoinPartsWork.JoinSourPartsNoWithH;
                    if (!CntDic.ContainsKey(str1))
                    {
                        cndtnWorkList.Add(newJoinPartsWork);
                        CntDic.Add(str1, "");
                    }
                    if (loginDic.ContainsKey(str))
                    {
                        continue;
                    }
                    loginDic.Add(str, "");
                    deleteWorkList.Add(joinPartsUWork);
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                CntDic.Clear();
                loginDic.Clear();
                if (deleteWorkList.Count > 0)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                else
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                }
            }
            catch (SqlException sqlEx)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                base.WriteSQLErrorLog(sqlEx, "JoinPartsChangeDB.JoinPartsSearchProc", status);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            catch (Exception ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                base.WriteErrorLog(ex, "JoinPartsChangeDB.JoinPartsSearchProc", status);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (null != myReader && !myReader.IsClosed)
                {
                    myReader.Close();
                }

                if (null != sqlCommand)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }

            return status;
        }
        #endregion

        #region �\�����ʂ���������
        /// <summary>
        /// �����}�X�^�̕\�����ʂ��擾���܂��B
        /// </summary>
        /// <param name="displayOrderDic"></param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="mode">���[�h</param>
        /// <returns>STATUS</returns>
        /// <br>Programmer : �i�N</br>
        /// <br>Date       : 2015/04/13</br>
        private int SearchDisplayOrder(out Dictionary<string, int> displayOrderDic, string enterpriseCode, int mode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            // �R�l�N�V����
            SqlConnection sqlConnection = null;

            Dictionary<string, int> displayOrder = new Dictionary<string, int>();
            try
            {
                // �R�l�N�V��������
                sqlConnection = _iGoodsNoChgCommonDB.CreateSqlConnection(true);
                // �����}�X�^��������
                status = SearchDisplayOrderProc(out displayOrder, enterpriseCode, mode, ref sqlConnection);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "MeijiJoinPartsDB.SearchDisplayOrder");
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (null != sqlConnection)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            displayOrderDic = displayOrder;

            return status;
        }

        /// <summary>
        /// ���i�����}�X�^���̃��X�g���擾���܂��B
        /// </summary>
        /// <param name="displayOrderDic"></param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="mode">���[�h</param>
        /// <param name="sqlConnection">�R�l�N�V����</param>
        /// <returns>STATUS</returns>
        /// <br>Programmer : �i�N</br>
        /// <br>Date       : 2015/04/13</br>
        private int SearchDisplayOrderProc(out Dictionary<string, int> displayOrderDic, string enterpriseCode, int mode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            displayOrderDic = new Dictionary<string, int>();
            try
            {
                string sqlText = "SELECT A.JOINSOURCEMAKERCODERF , A.JOINSOURPARTSNOWITHHRF , MAX(A.JOINDISPORDERRF) AS DISPLAYORDERRF " + Environment.NewLine;
                sqlText += "FROM JOINPARTSURF A WITH (READUNCOMMITTED) " + Environment.NewLine;

                if (mode == 0)
                {
                    sqlText += " INNER JOIN GOODSNOCHANGERF B WITH (READUNCOMMITTED)" + Environment.NewLine;
                    sqlText += " ON A.JOINSOURCEMAKERCODERF = B.GOODSMAKERCDRF AND A.JOINSOURPARTSNOWITHHRF=B.CHGDESTGOODSNORF AND A.ENTERPRISECODERF = B.ENTERPRISECODERF " + Environment.NewLine;
                }
                if (mode == 1)
                {
                    sqlText += " INNER JOIN GOODSNOCHANGEERRDTRF B WITH (READUNCOMMITTED)" + Environment.NewLine;
                    sqlText += " ON A.JOINSOURCEMAKERCODERF = B.GOODSMAKERCDRF AND A.JOINSOURPARTSNOWITHHRF=B.CHGDESTGOODSNORF AND A.ENTERPRISECODERF = B.ENTERPRISECODERF " + Environment.NewLine;
                }

                sqlCommand = new SqlCommand(sqlText, sqlConnection);

                sqlCommand.CommandText = sqlText;
                sqlCommand.CommandText += MakeWhereStringDisplayOrder(ref sqlCommand, mode, enterpriseCode);

                //�^�C���A�E�g���Ԃ̐ݒ�i�b�j
                sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitInquiry);
                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    JoinPartsUWork joinPartsUWork = new JoinPartsUWork();
                    if (myReader != null && joinPartsUWork != null)
                    {
                        # region �N���X�֊i�[
                        joinPartsUWork.JoinSourceMakerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("JOINSOURCEMAKERCODERF"));
                        joinPartsUWork.JoinSourPartsNoWithH = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("JOINSOURPARTSNOWITHHRF"));
                        joinPartsUWork.JoinDispOrder = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DISPLAYORDERRF"));
                        # endregion
                    }
                    string key = joinPartsUWork.JoinSourceMakerCode.ToString().Trim().PadLeft(4, '0') + ":" + joinPartsUWork.JoinSourPartsNoWithH.Trim();
                    if (!displayOrderDic.ContainsKey(key))
                    {
                        displayOrderDic.Add(key, joinPartsUWork.JoinDispOrder);
                    }
                    else
                    {
                        continue;
                    }
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                status = base.WriteSQLErrorLog(ex, errmsg, ex.Number);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "MeijiJoinPartsDB.SearchDisplayOrderProc");
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (myReader != null)
                {
                    if (!myReader.IsClosed)
                    {
                        myReader.Close();
                    }

                    myReader.Dispose();
                }

                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }

            return status;
        }

        /// <summary>
        /// �������������񐶐��{�����l�ݒ�
        /// </summary>
        /// <param name="sqlCommand">SqlCommand�I�u�W�F�N�g</param>
        /// <param name="mode">���[�h</param>
        /// <param name="enterpriseCode">���������i�[�N���X</param>
        /// <returns>Where����������</returns>
        /// <br>Note       : Where����쐬���Ė߂��܂�</br>
        /// <br>Programmer : �i�N</br>
        /// <br>Date       : 2015/04/13</br>
        private string MakeWhereStringDisplayOrder(ref SqlCommand sqlCommand, int mode, string enterpriseCode)
        {
            StringBuilder retstring = new StringBuilder();
            retstring.Append("WHERE ");

            //��ƃR�[�h
            retstring.Append(" A.ENTERPRISECODERF=@ENTERPRISECODE ");
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCode);

            //�_���폜�敪
            retstring.Append(" AND B.LOGICALDELETECODERF = @FINDLOGICALDELETECODE ").Append(Environment.NewLine);
            SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
            paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);

            //�}�X�^�敪
            if (mode == 1)
            {
                retstring.Append(" AND B.MASTERDIVCDRF = @FINDMASTERDIVCDRF ").Append(Environment.NewLine);
                SqlParameter paraLogicalMasterDiv = sqlCommand.Parameters.Add("@FINDMASTERDIVCDRF", SqlDbType.Int);
                paraLogicalMasterDiv.Value = SqlDataMediator.SqlSetInt32(4);
            }

            //GROUP BY
            retstring.Append(" GROUP BY A.JOINSOURCEMAKERCODERF, A.JOINSOURPARTSNOWITHHRF ");

            return retstring.ToString();
        }
        #endregion

        /// <summary>
        /// ���[�N��Clone
        /// </summary>
        /// <param name="work"></param>
        /// <returns></returns>
        private JoinPartsUWork CloneJoinWork(JoinPartsUWork work)
        {
            JoinPartsUWork joinPartsUWork = new JoinPartsUWork();
            joinPartsUWork.EnterpriseCode = work.EnterpriseCode;
            joinPartsUWork.UpdateDateTime = work.UpdateDateTime;
            joinPartsUWork.JoinDestPartsNo = work.JoinDestPartsNo;
            joinPartsUWork.JoinDestMakerCd = work.JoinDestMakerCd;
            joinPartsUWork.JoinSourceMakerCode = work.JoinSourceMakerCode;
            joinPartsUWork.JoinSourPartsNoWithH = work.JoinSourPartsNoWithH;
            return joinPartsUWork;
        }
    }
}
