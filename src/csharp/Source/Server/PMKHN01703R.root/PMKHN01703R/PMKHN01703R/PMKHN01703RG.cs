//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �����Y�Ƒ�փ}�X�^�ϊ�����
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
// �� �� ��  2015/04/07  �C�����e : Redmine#44209 �ϊ���̌��i�ԂƐ�i�Ԃ�����̏ꍇ�̓G���[�Ƃ���Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11003519-00 �쐬�S�� : ���V��
// �� �� ��  2015/04/17  �C�����e : Redmine#45436 ���i���g�p���ă}�X�^�̍폜/�o�^�����s���Ă���ӏ����O�L���b�`����Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11003519-00 �쐬�S�� : ���V��
// �� �� ��  2015/04/29  �C�����e : ���X�g��NULL�A��count�͔��f����Ή�
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
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using System.Text.RegularExpressions;
using Broadleaf.Library.Diagnostics;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// �����Y�Ƒ�փ}�X�^�ϊ�����DB�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note        : ��փ}�X�^�ϊ������̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer  : �i�N</br>
    /// <br>Date        : 2015/01/26</br>
    /// </remarks>
    [Serializable]
    public class MeijiPartsSubstDB : RemoteDB
    {
        // ��փ}�X�^�̃����[�g
        private PartsSubstUDB _iPartsSubstDB;
        private GoodsNoChgCommonDB _goodsNoChgCommonDB;

        #region MeijiPartsSubstDB
        /// <summary>
        /// ��փ}�X�^�ϊ������R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note        : ���ɂȂ�</br>
        /// <br>Programmer  : �i�N</br>
        /// <br>Date        : 2015/01/26</br>
        /// </remarks>
        public MeijiPartsSubstDB()
        {
            // ��փ}�X�^
            if (this._iPartsSubstDB == null)
            {
                this._iPartsSubstDB = new PartsSubstUDB();
            }

            if (this._goodsNoChgCommonDB == null)
            {
                this._goodsNoChgCommonDB = new GoodsNoChgCommonDB();
            }
        }
        #endregion

        #region ��փ}�X�^�̎捞����
        /// <summary>
        /// �w�肳�ꂽ��ƃR�[�h�̑�ւ̑S�Ė߂鏈��
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note        : �w�肳�ꂽ��ƃR�[�h�̑��LIST��S�Ė߂��܂�</br>
        /// <br>Programmer  : �i�N</br>
        /// <br>Date        : 2015/01/26</br>
        /// </remarks>
        public int WriteIn(out object partsSubstSuccessResultWork, out object partserrorResultWork, out int updateCount, int mode, string enterPriseCode)
        {
            // �R�l�N�V����
            SqlConnection sqlConnection = null;
            // �g�����U�N�V����
            SqlTransaction sqlTransaction = null;
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            // ��փ}�X�^���O
            partsSubstSuccessResultWork = null;
            partserrorResultWork = null;
            ArrayList partsSubstSuccessResultWorkList = new ArrayList();
            ArrayList partserrorResultWorkList = new ArrayList();

            // �o�^����
            updateCount = 0;

            try
            {
                // �R�l�N�V��������
                sqlConnection = _goodsNoChgCommonDB.CreateSqlConnection(true);

                // �g�����U�N�V�����J�n
                sqlTransaction = _goodsNoChgCommonDB.CreateTransaction(ref sqlConnection);

                // ��փ}�X�^�ϊ�����
                status = PartsSubstWriteInProc(out partsSubstSuccessResultWorkList, out partserrorResultWorkList, out updateCount, mode, enterPriseCode, ref sqlConnection, ref sqlTransaction);

                // �߂��郊�X�g
                partsSubstSuccessResultWork = partsSubstSuccessResultWorkList;
                partserrorResultWork = partserrorResultWorkList;

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
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                base.WriteErrorLog(ex, errmsg, status);
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
        /// �w�肳�ꂽ��ƃR�[�h�̑�փ}�X�^�̎捞����
        /// </summary>
        /// <param name="partsSubstSuccessResultWork">�捞�������X�g</param>
        /// <param name="PartserrorResultWorkList">�����������X�g</param>
        /// <param name="updateCount">�o�^����</param>
        /// <param name="mode"></param>
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
        /// <br>Note        : ���X�g��NULL�A��count�͔��f����Ή�</br>
        /// <br>Programmer  : ���V��</br>
        /// <br>Date        : 2015/04/29</br>
        /// </remarks>
        private int PartsSubstWriteInProc(out ArrayList partsSubstSuccessResultWork, out ArrayList PartserrorResultWorkList, out int updateCount, int mode, string enterPriseCode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            ArrayList cndtnWorkList = new ArrayList();
            // �߂���錋�ʃ��X�g
            partsSubstSuccessResultWork = new ArrayList();
            PartserrorResultWorkList = new ArrayList();
            // ���S�폜���X�g
            ArrayList phyDeleteWorkList = new ArrayList();
            // �ǉ����X�g
            ArrayList insertWorkList = new ArrayList();
            // ���������߂���냊�X�g
            ArrayList searchBackWorkList = new ArrayList();
            
            ArrayList haveWorkList = new ArrayList();
            ArrayList logicalDeleteList = new ArrayList();
            ArrayList errorDeleteList = new ArrayList();

            Dictionary<string, string> deleteErrorDic = new Dictionary<string, string>();
            Dictionary<string, string> errorDic = new Dictionary<string, string>();
            // �����R�l�N�V����
            SqlConnection partsSubstConnection = _goodsNoChgCommonDB.CreateSqlConnection(true);
            // �o�^����
            updateCount = 0;
            string srcGoodsNoKey = "";
            string destGoodsNoKey = "";
            int logicalDeleteCode = 0;

            try
            {
                // ���������L�[
                string cndtnKey = string.Empty;

                status = this.Search(out searchBackWorkList, out cndtnWorkList, mode, enterPriseCode, ref sqlConnection, ref sqlTransaction);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && searchBackWorkList.Count > 0)
                {
                    updateCount = searchBackWorkList.Count;
                    status = _goodsNoChgCommonDB.DeleteGoodsNoChangeErrorDataProc(enterPriseCode, GoodsNoChgCommonDB.PARTSMST, ref  sqlConnection, ref  sqlTransaction);

                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        #region ��փ}�X�^�̐V���i�Ԃ̑Ή�����l
                        foreach (MeijiPartsSubstWork meijiPartsSubstWork in cndtnWorkList)
                        {
                            string str = meijiPartsSubstWork.ChgSrcMakerCd + ":" + meijiPartsSubstWork.ChgSrcGoodsNo;
                            deleteErrorDic.Add(str, meijiPartsSubstWork.ChgDestGoodsNo);
                        }
                        #endregion

                        foreach (PartsSubstUWork partsSubstUWork in searchBackWorkList)
                        {
                            sqlTransaction.Save("PartsSavePoint");
                            logicalDeleteCode = partsSubstUWork.LogicalDeleteCode;
                            srcGoodsNoKey = partsSubstUWork.ChgSrcMakerCd + ":" + partsSubstUWork.ChgSrcGoodsNo;
                            destGoodsNoKey = partsSubstUWork.ChgDestMakerCd + ":" + partsSubstUWork.ChgDestGoodsNo;
                            ArrayList coyList = new ArrayList();
                            PartsSubstUWork apartsSubstUWork = CloneJoinWork(partsSubstUWork);
                            GoodsNoChangeErrorDataWork goodsNoChangeErrorDataWork1 = new GoodsNoChangeErrorDataWork();

                            MeijiPartsSubstWork ameijiPartsSubstWork = new MeijiPartsSubstWork();
                            ameijiPartsSubstWork.ChgSrcMakerCd = partsSubstUWork.ChgSrcMakerCd;
                            ameijiPartsSubstWork.ChgSrcGoodsNo = partsSubstUWork.ChgSrcGoodsNo;
                            ameijiPartsSubstWork.ChgDestMakerCd = partsSubstUWork.ChgDestMakerCd;
                            ameijiPartsSubstWork.ChgDestGoodsNo = partsSubstUWork.ChgDestGoodsNo;
                            if (deleteErrorDic.ContainsKey(srcGoodsNoKey))
                            {
                                ameijiPartsSubstWork.ChgSrcChgGoodsNo = deleteErrorDic[srcGoodsNoKey];
                            }
                            else
                            {
                                ameijiPartsSubstWork.ChgSrcChgGoodsNo = partsSubstUWork.ChgSrcGoodsNo;
                            }
                            if (deleteErrorDic.ContainsKey(destGoodsNoKey))
                            {
                                ameijiPartsSubstWork.ChgDestChgGoodsNo = deleteErrorDic[destGoodsNoKey];
                            }
                            else
                            {
                                ameijiPartsSubstWork.ChgDestChgGoodsNo = partsSubstUWork.ChgDestGoodsNo;
                            }

                            // ���i�Ԃ̍폜
                            coyList.Add(apartsSubstUWork);
                            //----- ADD 2015/04/17 ���V�� Redmine#45436 ���i���g�p���ă}�X�^�̍폜/�o�^�����s���Ă���ӏ����O�L���b�`����Ή�------>>>>>
                            try
                            {
                            //----- ADD 2015/04/17 ���V�� Redmine#45436 ���i���g�p���ă}�X�^�̍폜/�o�^�����s���Ă���ӏ����O�L���b�`����Ή�------<<<<<
                                status = this._iPartsSubstDB.Delete(coyList, ref sqlConnection, ref sqlTransaction);
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
                                string stra = partsSubstUWork.ChgSrcMakerCd + ":" + partsSubstUWork.ChgSrcGoodsNo;
                                string strb = partsSubstUWork.ChgDestMakerCd + ":" + partsSubstUWork.ChgDestGoodsNo;
                                if (deleteErrorDic.ContainsKey(stra))
                                {
                                    GoodsNoChangeErrorDataWork goodsNoChangeErrorDataWork = new GoodsNoChangeErrorDataWork();
                                    goodsNoChangeErrorDataWork.MasterDivCd = GoodsNoChgCommonDB.PARTSMST;
                                    goodsNoChangeErrorDataWork.ChgSrcGoodsNo = partsSubstUWork.ChgSrcGoodsNo;
                                    goodsNoChangeErrorDataWork.GoodsMakerCd = partsSubstUWork.ChgSrcMakerCd;
                                    goodsNoChangeErrorDataWork.ChgDestGoodsNo = deleteErrorDic[stra];
                                    if (!errorDic.ContainsKey(stra))
                                    {
                                        errorDic.Add(stra, "");
                                        errorDeleteList.Add(goodsNoChangeErrorDataWork);
                                    }
                                }
                                if (deleteErrorDic.ContainsKey(strb))
                                {
                                    GoodsNoChangeErrorDataWork goodsNoChangeErrorDataWork = new GoodsNoChangeErrorDataWork();
                                    goodsNoChangeErrorDataWork.MasterDivCd = GoodsNoChgCommonDB.PARTSMST;
                                    goodsNoChangeErrorDataWork.ChgSrcGoodsNo = partsSubstUWork.ChgDestGoodsNo;
                                    goodsNoChangeErrorDataWork.GoodsMakerCd = partsSubstUWork.ChgDestMakerCd;
                                    goodsNoChangeErrorDataWork.ChgDestGoodsNo = deleteErrorDic[strb];
                                    if (!errorDic.ContainsKey(strb))
                                    {
                                        errorDic.Add(strb, "");
                                        errorDeleteList.Add(goodsNoChangeErrorDataWork);
                                    }
                                }
                                //ameijiPartsSubstWork.OutNote = "�r���G���[�A�ϊ����i�Ԃ̍폜�Ɏ��s���܂���"; // DEL 2015/02/26 ���V�� Redmine#44209 ���b�Z�[�W�̕����Ή�
                                ameijiPartsSubstWork.OutNote = string.Format(GoodsNoChgCommonDB.UPDATEFAIL, "��փ}�X�^"); // ADD 2015/02/26 ���V�� Redmine#44209 ���b�Z�[�W�̕����Ή�
                                PartserrorResultWorkList.Add(ameijiPartsSubstWork);
                            }
                            else if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                #region �V�i�Ԃ̒ǉ�
                                foreach (MeijiPartsSubstWork newmeijiPartsSubstWork in cndtnWorkList)
                                {
                                    if (partsSubstUWork.ChgSrcMakerCd == newmeijiPartsSubstWork.ChgSrcMakerCd && partsSubstUWork.ChgSrcGoodsNo.Equals(newmeijiPartsSubstWork.ChgSrcGoodsNo))
                                    {
                                        partsSubstUWork.ChgSrcGoodsNo = newmeijiPartsSubstWork.ChgDestGoodsNo;
                                        partsSubstUWork.ChgSrcGoodsNoNoneHp = newmeijiPartsSubstWork.ChgDestGoodsNo.Replace("-", "");
                                    }
                                    if (partsSubstUWork.ChgDestMakerCd == newmeijiPartsSubstWork.ChgSrcMakerCd && partsSubstUWork.ChgDestGoodsNo.Equals(newmeijiPartsSubstWork.ChgSrcGoodsNo))
                                    {
                                        partsSubstUWork.ChgDestGoodsNo = newmeijiPartsSubstWork.ChgDestGoodsNo;
                                        partsSubstUWork.ChgDestGoodsNoNoneHp = newmeijiPartsSubstWork.ChgDestGoodsNo.Replace("-", "");
                                    }
                                }

                                //----- ADD 2015/04/07 ���V�� Redmine#44209 �ϊ���̌��i�ԂƐ�i�Ԃ�����̏ꍇ�̓G���[�Ƃ���Ή�------>>>>>
                                if (!string.IsNullOrEmpty(partsSubstUWork.ChgSrcGoodsNo.Trim())
                                    && partsSubstUWork.ChgSrcGoodsNo.Trim().Equals(partsSubstUWork.ChgDestGoodsNo.Trim())
                                    && partsSubstUWork.ChgSrcMakerCd == partsSubstUWork.ChgDestMakerCd)
                                {
                                    string stra = apartsSubstUWork.ChgSrcMakerCd + ":" + apartsSubstUWork.ChgSrcGoodsNo;
                                    string strb = apartsSubstUWork.ChgDestMakerCd + ":" + apartsSubstUWork.ChgDestGoodsNo;
                                    if (deleteErrorDic.ContainsKey(stra))
                                    {
                                        GoodsNoChangeErrorDataWork goodsNoChangeErrorDataWork = new GoodsNoChangeErrorDataWork();
                                        goodsNoChangeErrorDataWork.MasterDivCd = GoodsNoChgCommonDB.PARTSMST;
                                        goodsNoChangeErrorDataWork.ChgSrcGoodsNo = apartsSubstUWork.ChgSrcGoodsNo;
                                        goodsNoChangeErrorDataWork.GoodsMakerCd = apartsSubstUWork.ChgSrcMakerCd;
                                        goodsNoChangeErrorDataWork.ChgDestGoodsNo = deleteErrorDic[stra];
                                        if (!errorDic.ContainsKey(stra))
                                        {
                                            errorDic.Add(stra, "");
                                            errorDeleteList.Add(goodsNoChangeErrorDataWork);
                                        }
                                    }
                                    if (deleteErrorDic.ContainsKey(strb))
                                    {
                                        GoodsNoChangeErrorDataWork goodsNoChangeErrorDataWork = new GoodsNoChangeErrorDataWork();
                                        goodsNoChangeErrorDataWork.MasterDivCd = GoodsNoChgCommonDB.PARTSMST;
                                        goodsNoChangeErrorDataWork.ChgSrcGoodsNo = apartsSubstUWork.ChgDestGoodsNo;
                                        goodsNoChangeErrorDataWork.GoodsMakerCd = apartsSubstUWork.ChgDestMakerCd;
                                        goodsNoChangeErrorDataWork.ChgDestGoodsNo = deleteErrorDic[strb];
                                        if (!errorDic.ContainsKey(strb))
                                        {
                                            errorDic.Add(strb, "");
                                            errorDeleteList.Add(goodsNoChangeErrorDataWork);
                                        }
                                    }
                                    ameijiPartsSubstWork.OutNote = GoodsNoChgCommonDB.REPEATPARTSMSG;
                                    PartserrorResultWorkList.Add(ameijiPartsSubstWork);

                                    status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                                }

                                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                {
                                    //----- ADD 2015/04/07 ���V�� Redmine#44209 �ϊ���̌��i�ԂƐ�i�Ԃ�����̏ꍇ�̓G���[�Ƃ���Ή�------<<<<<

                                    // �V�i�Ԃ�insert
                                    partsSubstUWork.UpdateDateTime = DateTime.MinValue;
                                    insertWorkList.Add(partsSubstUWork);
                                    //----- ADD 2015/04/17 ���V�� Redmine#45436 ���i���g�p���ă}�X�^�̍폜/�o�^�����s���Ă���ӏ����O�L���b�`����Ή�------>>>>>
                                    try
                                    {
                                    //----- ADD 2015/04/17 ���V�� Redmine#45436 ���i���g�p���ă}�X�^�̍폜/�o�^�����s���Ă���ӏ����O�L���b�`����Ή�------<<<<<
                                        status = this._iPartsSubstDB.Write(ref insertWorkList, ref sqlConnection, ref sqlTransaction);
                                    //----- ADD 2015/04/17 ���V�� Redmine#45436 ���i���g�p���ă}�X�^�̍폜/�o�^�����s���Ă���ӏ����O�L���b�`����Ή�------>>>>>
                                    }
                                    catch (Exception ex)
                                    {
                                        base.WriteErrorLog(ex, "Write");
                                        status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                                    }
                                    //----- ADD 2015/04/17 ���V�� Redmine#45436 ���i���g�p���ă}�X�^�̍폜/�o�^�����s���Ă���ӏ����O�L���b�`����Ή�------<<<<<
                                    insertWorkList.Clear(); // ���X�g�̃N���A
                                    // ��փ}�X�^�ɋ��i�ԑΉ��̐V�i�Ԃ����ɑ��݂���ꍇ�A�r�����b�Z�[�W�̃Z�b�g
                                    if (status == (int)ConstantManagement.DB_Status.ctDB_DUPLICATE || status == (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE)
                                    {
                                        string stra = apartsSubstUWork.ChgSrcMakerCd + ":" + apartsSubstUWork.ChgSrcGoodsNo;
                                        string strb = apartsSubstUWork.ChgDestMakerCd + ":" + apartsSubstUWork.ChgDestGoodsNo;
                                        if (deleteErrorDic.ContainsKey(stra))
                                        {
                                            GoodsNoChangeErrorDataWork goodsNoChangeErrorDataWork = new GoodsNoChangeErrorDataWork();
                                            goodsNoChangeErrorDataWork.MasterDivCd = GoodsNoChgCommonDB.PARTSMST;
                                            goodsNoChangeErrorDataWork.ChgSrcGoodsNo = apartsSubstUWork.ChgSrcGoodsNo;
                                            goodsNoChangeErrorDataWork.GoodsMakerCd = apartsSubstUWork.ChgSrcMakerCd;
                                            goodsNoChangeErrorDataWork.ChgDestGoodsNo = deleteErrorDic[stra];
                                            if (!errorDic.ContainsKey(stra))
                                            {
                                                errorDic.Add(stra, "");
                                                errorDeleteList.Add(goodsNoChangeErrorDataWork);
                                            }
                                        }
                                        if (deleteErrorDic.ContainsKey(strb))
                                        {
                                            GoodsNoChangeErrorDataWork goodsNoChangeErrorDataWork = new GoodsNoChangeErrorDataWork();
                                            goodsNoChangeErrorDataWork.MasterDivCd = GoodsNoChgCommonDB.PARTSMST;
                                            goodsNoChangeErrorDataWork.ChgSrcGoodsNo = apartsSubstUWork.ChgDestGoodsNo;
                                            goodsNoChangeErrorDataWork.GoodsMakerCd = apartsSubstUWork.ChgDestMakerCd;
                                            goodsNoChangeErrorDataWork.ChgDestGoodsNo = deleteErrorDic[strb];
                                            if (!errorDic.ContainsKey(strb))
                                            {
                                                errorDic.Add(strb, "");
                                                errorDeleteList.Add(goodsNoChangeErrorDataWork);
                                            }
                                        }
                                        //ameijiPartsSubstWork.OutNote = "�ϊ���i�Ԃ����ɓo�^����܂���"; // DEL 2015/02/26 ���V�� Redmine#44209 ���b�Z�[�W�̕����Ή�
                                        ameijiPartsSubstWork.OutNote = string.Format(GoodsNoChgCommonDB.EXISTMSG, "��փ}�X�^"); // ADD 2015/02/26 ���V�� Redmine#44209 ���b�Z�[�W�̕����Ή�
                                        PartserrorResultWorkList.Add(ameijiPartsSubstWork);
                                    }
                                    else if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                    {
                                        if (logicalDeleteCode == 1)
                                        {
                                            logicalDeleteList.Add(partsSubstUWork);
                                            // �V�i�Ԃ̘_���폜
                                            //----- ADD 2015/04/17 ���V�� Redmine#45436 ���i���g�p���ă}�X�^�̍폜/�o�^�����s���Ă���ӏ����O�L���b�`����Ή�------>>>>>
                                            try
                                            {
                                            //----- ADD 2015/04/17 ���V�� Redmine#45436 ���i���g�p���ă}�X�^�̍폜/�o�^�����s���Ă���ӏ����O�L���b�`����Ή�------<<<<<
                                                status = this._iPartsSubstDB.LogicalDelete(ref logicalDeleteList, 0, ref  sqlConnection, ref  sqlTransaction);
                                            //----- ADD 2015/04/17 ���V�� Redmine#45436 ���i���g�p���ă}�X�^�̍폜/�o�^�����s���Ă���ӏ����O�L���b�`����Ή�------>>>>>
                                            }
                                            catch (Exception ex)
                                            {
                                                base.WriteErrorLog(ex, "LogicalDelete");
                                                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                                            }
                                            //----- ADD 2015/04/17 ���V�� Redmine#45436 ���i���g�p���ă}�X�^�̍폜/�o�^�����s���Ă���ӏ����O�L���b�`����Ή�------<<<<<
                                            logicalDeleteList.Clear();

                                            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                            {
                                                //ameijiPartsSubstWork.OutNote = "�_���폜�f�[�^"; // DEL 2015/02/26 ���V�� Redmine#44209 ���b�Z�[�W�̕����Ή�
                                                ameijiPartsSubstWork.OutNote = GoodsNoChgCommonDB.DELETEMSG; // ADD 2015/02/26 ���V�� Redmine#44209 ���b�Z�[�W�̕����Ή�
                                                partsSubstSuccessResultWork.Add(ameijiPartsSubstWork);
                                            }
                                            else
                                            {
                                                string stra = apartsSubstUWork.ChgSrcMakerCd + ":" + apartsSubstUWork.ChgSrcGoodsNo;
                                                string strb = apartsSubstUWork.ChgDestMakerCd + ":" + apartsSubstUWork.ChgDestGoodsNo;
                                                if (deleteErrorDic.ContainsKey(stra))
                                                {
                                                    GoodsNoChangeErrorDataWork goodsNoChangeErrorDataWork = new GoodsNoChangeErrorDataWork();
                                                    goodsNoChangeErrorDataWork.MasterDivCd = GoodsNoChgCommonDB.PARTSMST;
                                                    goodsNoChangeErrorDataWork.ChgSrcGoodsNo = apartsSubstUWork.ChgSrcGoodsNo;
                                                    goodsNoChangeErrorDataWork.GoodsMakerCd = apartsSubstUWork.ChgSrcMakerCd;
                                                    goodsNoChangeErrorDataWork.ChgDestGoodsNo = deleteErrorDic[stra];
                                                    if (!errorDic.ContainsKey(stra))
                                                    {
                                                        errorDic.Add(stra, "");
                                                        errorDeleteList.Add(goodsNoChangeErrorDataWork);
                                                    }
                                                }
                                                if (deleteErrorDic.ContainsKey(strb))
                                                {
                                                    GoodsNoChangeErrorDataWork goodsNoChangeErrorDataWork = new GoodsNoChangeErrorDataWork();
                                                    goodsNoChangeErrorDataWork.MasterDivCd = GoodsNoChgCommonDB.PARTSMST;
                                                    goodsNoChangeErrorDataWork.ChgSrcGoodsNo = apartsSubstUWork.ChgDestGoodsNo;
                                                    goodsNoChangeErrorDataWork.GoodsMakerCd = apartsSubstUWork.ChgDestMakerCd;
                                                    goodsNoChangeErrorDataWork.ChgDestGoodsNo = deleteErrorDic[strb];
                                                    if (!errorDic.ContainsKey(strb))
                                                    {
                                                        errorDic.Add(strb, "");
                                                        errorDeleteList.Add(goodsNoChangeErrorDataWork);
                                                    }
                                                }
                                                //ameijiPartsSubstWork.OutNote = "�o�^�G���[�A�ϊ���i�Ԃ̓o�^�Ɏ��s���܂���"; // DEL 2015/02/26 ���V�� Redmine#44209 ���b�Z�[�W�̕����Ή�
                                                ameijiPartsSubstWork.OutNote = GoodsNoChgCommonDB.NEWEXCEPTIONMSG; // ADD 2015/02/26 ���V�� Redmine#44209 ���b�Z�[�W�̕����Ή�
                                                PartserrorResultWorkList.Add(ameijiPartsSubstWork);
                                            }
                                        }
                                        else
                                        {
                                            partsSubstSuccessResultWork.Add(ameijiPartsSubstWork);
                                        }
                                    }
                                    else
                                    {
                                        string stra = apartsSubstUWork.ChgSrcMakerCd + ":" + apartsSubstUWork.ChgSrcGoodsNo;
                                        string strb = apartsSubstUWork.ChgDestMakerCd + ":" + apartsSubstUWork.ChgDestGoodsNo;
                                        if (deleteErrorDic.ContainsKey(stra))
                                        {
                                            GoodsNoChangeErrorDataWork goodsNoChangeErrorDataWork = new GoodsNoChangeErrorDataWork();
                                            goodsNoChangeErrorDataWork.MasterDivCd = GoodsNoChgCommonDB.PARTSMST;
                                            goodsNoChangeErrorDataWork.ChgSrcGoodsNo = apartsSubstUWork.ChgSrcGoodsNo;
                                            goodsNoChangeErrorDataWork.GoodsMakerCd = apartsSubstUWork.ChgSrcMakerCd;
                                            goodsNoChangeErrorDataWork.ChgDestGoodsNo = deleteErrorDic[stra];
                                            if (!errorDic.ContainsKey(stra))
                                            {
                                                errorDic.Add(stra, "");
                                                errorDeleteList.Add(goodsNoChangeErrorDataWork);
                                            }
                                        }
                                        if (deleteErrorDic.ContainsKey(strb))
                                        {
                                            GoodsNoChangeErrorDataWork goodsNoChangeErrorDataWork = new GoodsNoChangeErrorDataWork();
                                            goodsNoChangeErrorDataWork.MasterDivCd = GoodsNoChgCommonDB.PARTSMST;
                                            goodsNoChangeErrorDataWork.ChgSrcGoodsNo = apartsSubstUWork.ChgDestGoodsNo;
                                            goodsNoChangeErrorDataWork.GoodsMakerCd = apartsSubstUWork.ChgDestMakerCd;
                                            goodsNoChangeErrorDataWork.ChgDestGoodsNo = deleteErrorDic[strb];
                                            if (!errorDic.ContainsKey(strb))
                                            {
                                                errorDic.Add(strb, "");
                                                errorDeleteList.Add(goodsNoChangeErrorDataWork);
                                            }
                                        }
                                        //ameijiPartsSubstWork.OutNote = "�o�^�G���[�A�ϊ���i�Ԃ̓o�^�Ɏ��s���܂���"; // DEL 2015/02/26 ���V�� Redmine#44209 ���b�Z�[�W�̕����Ή�
                                        ameijiPartsSubstWork.OutNote = GoodsNoChgCommonDB.NEWEXCEPTIONMSG; // ADD 2015/02/26 ���V�� Redmine#44209 ���b�Z�[�W�̕����Ή�
                                        PartserrorResultWorkList.Add(ameijiPartsSubstWork);
                                    }

                                } // ADD 2015/04/07 ���V�� Redmine#44209 �ϊ���̌��i�ԂƐ�i�Ԃ�����̏ꍇ�̓G���[�Ƃ���Ή�
                                #endregion
                            }
                            else
                            {
                                string stra = partsSubstUWork.ChgSrcMakerCd + ":" + partsSubstUWork.ChgSrcGoodsNo;
                                string strb = partsSubstUWork.ChgDestMakerCd + ":" + partsSubstUWork.ChgDestGoodsNo;
                                if (deleteErrorDic.ContainsKey(stra))
                                {
                                    GoodsNoChangeErrorDataWork goodsNoChangeErrorDataWork = new GoodsNoChangeErrorDataWork();
                                    goodsNoChangeErrorDataWork.MasterDivCd = GoodsNoChgCommonDB.PARTSMST;
                                    goodsNoChangeErrorDataWork.ChgSrcGoodsNo = partsSubstUWork.ChgSrcGoodsNo;
                                    goodsNoChangeErrorDataWork.GoodsMakerCd = partsSubstUWork.ChgSrcMakerCd;
                                    goodsNoChangeErrorDataWork.ChgDestGoodsNo = deleteErrorDic[stra];
                                    if (!errorDic.ContainsKey(stra))
                                    {
                                        errorDic.Add(stra, "");
                                        errorDeleteList.Add(goodsNoChangeErrorDataWork);
                                    }
                                }
                                if (deleteErrorDic.ContainsKey(strb))
                                {
                                    GoodsNoChangeErrorDataWork goodsNoChangeErrorDataWork = new GoodsNoChangeErrorDataWork();
                                    goodsNoChangeErrorDataWork.MasterDivCd = GoodsNoChgCommonDB.PARTSMST;
                                    goodsNoChangeErrorDataWork.ChgSrcGoodsNo = partsSubstUWork.ChgDestGoodsNo;
                                    goodsNoChangeErrorDataWork.GoodsMakerCd = partsSubstUWork.ChgDestMakerCd;
                                    goodsNoChangeErrorDataWork.ChgDestGoodsNo = deleteErrorDic[strb];
                                    if (!errorDic.ContainsKey(strb))
                                    {
                                        errorDic.Add(strb, "");
                                        errorDeleteList.Add(goodsNoChangeErrorDataWork);
                                    }
                                }
                                //ameijiPartsSubstWork.OutNote = "�폜�G���[�A�ϊ����i�Ԃ̍폜�Ɏ��s���܂���"; // DEL 2015/02/26 ���V�� Redmine#44209 ���b�Z�[�W�̕����Ή�
                                ameijiPartsSubstWork.OutNote = GoodsNoChgCommonDB.OLDEXCEPTIONMSG; // ADD 2015/02/26 ���V�� Redmine#44209 ���b�Z�[�W�̕����Ή�
                                PartserrorResultWorkList.Add(ameijiPartsSubstWork);
                            }

                            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                sqlTransaction.Rollback("PartsSavePoint");
                            }
                        }
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
                // ���X�g�̃N���A
                phyDeleteWorkList.Clear();

                // �G���[�f�[�^�x�[�X�̍X�V
                if (errorDeleteList != null && errorDeleteList.Count > 0)
                {
                    Dictionary<string, GoodsNoChangeErrorDataWork> repeatDate = new Dictionary<string, GoodsNoChangeErrorDataWork>();
                    string repeatDateKey = "";
                    for (int i = 0; i < errorDeleteList.Count; i++)
                    {
                        //GoodsNoChangeErrorDataWork errorDataWork = errorDeleteList[i] as GoodsNoChangeErrorDataWork;// DEL 2015/04/03 ���V�� ���X�g��NULL�A��count�͔��f����Ή�
                        //----- ADD 2015/04/29 ���V�� ���X�g��NULL�A��count�͔��f����Ή�------>>>>>
                        GoodsNoChangeErrorDataWork errorDataWork = null;
                        if (errorDeleteList != null && errorDeleteList.Count > 0)
                        {
                            errorDataWork = errorDeleteList[i] as GoodsNoChangeErrorDataWork;
                        }
                        //----- ADD 2015/04/29 ���V�� ���X�g��NULL�A��count�͔��f����Ή�------<<<<<
                        repeatDateKey = errorDataWork.GoodsMakerCd.ToString() + "-" + errorDataWork.ChgSrcGoodsNo.Trim();

                        if (!repeatDate.ContainsKey(repeatDateKey))
                        {
                            repeatDate.Add(repeatDateKey, errorDataWork);
                        }
                    }
                    status = _goodsNoChgCommonDB.WriteGoodsNoChangeErrorDataProc(repeatDate, ref sqlConnection, ref sqlTransaction);
                }

                // �o�^����
                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    partsSubstSuccessResultWork.Clear();
                    PartserrorResultWorkList.Clear();
                }
                return status;
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                base.WriteErrorLog(ex, errmsg, status);
            }
            finally
            {
                if (partsSubstConnection != null)
                {
                    partsSubstConnection.Close();
                    partsSubstConnection.Dispose();
                }
            }
            return status;
        }
        #endregion

        #region
        /// <summary>
        /// ���i��փ}�X�^���̃��X�g���擾���܂��B
        /// </summary>
        /// <param name="searchBackWorkList">���i��փ}�X�^�����i�[���� ArrayList</param>
        /// <param name="cndtnWorkList">��������</param>
        /// <param name="mode">�敪</param>
        /// <param name="enterPriseCode">��ƃR�[�h</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�f�[�^�x�[�X�ڑ����</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ���i��փ}�X�^�̃L�[�l����v����A�S�Ă̕��i��փ}�X�^��񂪊i�[����Ă��� ArrayList ���擾���܂��B</br>
        /// <br>Programmer : �i�N</br>
        /// <br>Date       : 2015/01/26</br>
        /// </remarks>
        private int Search(out ArrayList searchBackWorkList, out ArrayList cndtnWorkList, int mode, string enterPriseCode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.SearchProc(out searchBackWorkList, out cndtnWorkList, mode, enterPriseCode, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// ���i��փ}�X�^���̃��X�g���擾���܂��B
        /// </summary>
        /// <param name="searchBackWorkList">���i��փ}�X�^�����i�[���� ArrayList</param>
        /// <param name="cndtnWorkList">��������</param>
        /// <param name="mode">�敪</param>
        /// <param name="enterPriseCode">��ƃR�[�h</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�f�[�^�x�[�X�ڑ����</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ���i��փ}�X�^�̃L�[�l����v����A�S�Ă̕��i��փ}�X�^��񂪊i�[����Ă��� ArrayList ���擾���܂��B</br>
        /// <br>Programmer : �i�N</br>
        /// <br>Date       : 2015/01/26</br>
        /// </remarks>
        private int SearchProc(out ArrayList searchBackWorkList, out ArrayList cndtnWorkList, int mode, string enterPriseCode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            Dictionary<string, string> loginDic = new Dictionary<string, string>();
            Dictionary<string, string> CntDic = new Dictionary<string, string>();
            searchBackWorkList = new ArrayList();
            cndtnWorkList = new ArrayList();

            try
            {
                sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);
                StringBuilder sql = new StringBuilder();

                # region [SELECT��]
                sql.Append("SELECT").Append(Environment.NewLine);
                sql.Append("PRT.CREATEDATETIMERF").Append(Environment.NewLine);
                sql.Append("  ,PRT.UPDATEDATETIMERF").Append(Environment.NewLine);
                sql.Append("  ,PRT.ENTERPRISECODERF").Append(Environment.NewLine);
                sql.Append("  ,PRT.FILEHEADERGUIDRF").Append(Environment.NewLine);
                sql.Append("  ,PRT.UPDEMPLOYEECODERF").Append(Environment.NewLine);
                sql.Append("  ,PRT.UPDASSEMBLYID1RF").Append(Environment.NewLine);
                sql.Append("  ,PRT.UPDASSEMBLYID2RF").Append(Environment.NewLine);
                sql.Append("  ,PRT.LOGICALDELETECODERF").Append(Environment.NewLine);
                sql.Append("  ,PRT.CHGSRCMAKERCDRF").Append(Environment.NewLine);
                sql.Append("  ,PRT.CHGSRCGOODSNORF").Append(Environment.NewLine);
                sql.Append("  ,PRT.CHGSRCGOODSNONONEHPRF").Append(Environment.NewLine);
                sql.Append("  ,PRT.CHGDESTMAKERCDRF").Append(Environment.NewLine);
                sql.Append("  ,PRT.CHGDESTGOODSNORF").Append(Environment.NewLine);
                sql.Append("  ,PRT.CHGDESTGOODSNONONEHPRF").Append(Environment.NewLine);
                sql.Append("  ,PRT.APPLYSTADATERF").Append(Environment.NewLine);
                sql.Append("  ,PRT.APPLYENDDATERF").Append(Environment.NewLine);
                sql.Append("  ,B.GOODSMAKERCDRF").Append(Environment.NewLine);
                sql.Append("  ,B.CHGSRCGOODSNORF AS CHGSRCGOODSNORF2").Append(Environment.NewLine);
                sql.Append("  ,B.CHGDESTGOODSNORF AS CHGDESTGOODSNORF2").Append(Environment.NewLine);
                sql.Append(" FROM PARTSSUBSTURF AS PRT WITH (READUNCOMMITTED)").Append(Environment.NewLine);
                if (mode == 0)
                {
                    sql.Append(" INNER JOIN GOODSNOCHANGERF B WITH (READUNCOMMITTED)").Append(Environment.NewLine);
                    sql.Append("ON").Append(Environment.NewLine);
                    sql.Append("( PRT.CHGSRCMAKERCDRF = B.GOODSMAKERCDRF AND PRT.CHGSRCGOODSNORF = B.CHGSRCGOODSNORF AND PRT.ENTERPRISECODERF = B.ENTERPRISECODERF) ").Append(Environment.NewLine);
                    sql.Append("OR ( PRT.CHGDESTMAKERCDRF = B.GOODSMAKERCDRF AND PRT.CHGDESTGOODSNORF = B.CHGSRCGOODSNORF AND PRT.ENTERPRISECODERF = B.ENTERPRISECODERF)").Append(Environment.NewLine);
                }
                else if (mode == 1)
                {
                    sql.Append(" INNER JOIN GOODSNOCHANGEERRDTRF B WITH (READUNCOMMITTED)").Append(Environment.NewLine);
                    sql.Append("ON").Append(Environment.NewLine);
                    sql.Append("( PRT.CHGSRCMAKERCDRF = B.GOODSMAKERCDRF AND PRT.CHGSRCGOODSNORF = B.CHGSRCGOODSNORF AND PRT.ENTERPRISECODERF = B.ENTERPRISECODERF) ").Append(Environment.NewLine);
                    sql.Append("OR ( PRT.CHGDESTMAKERCDRF = B.GOODSMAKERCDRF AND PRT.CHGDESTGOODSNORF = B.CHGSRCGOODSNORF AND PRT.ENTERPRISECODERF = B.ENTERPRISECODERF)").Append(Environment.NewLine);
                }

                sqlCommand.CommandText = sql.ToString();
                sqlCommand.CommandText += MakeWhereString(ref sqlCommand, mode, enterPriseCode);
                # endregion

                // �N�G�����s���̃^�C���A�E�g���Ԃ�10���ɐݒ肷��
                sqlCommand.CommandTimeout = 600;
                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    PartsSubstUWork partsSubstUWork = new PartsSubstUWork();
                    MeijiPartsSubstWork meijiPartsSubstWork = new MeijiPartsSubstWork();
                    string str = string.Empty;
                    string str1 = string.Empty;
                    partsSubstUWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                    partsSubstUWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                    partsSubstUWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                    partsSubstUWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                    partsSubstUWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                    partsSubstUWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                    partsSubstUWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                    partsSubstUWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                    partsSubstUWork.ChgSrcMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CHGSRCMAKERCDRF"));
                    partsSubstUWork.ChgSrcGoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CHGSRCGOODSNORF"));
                    partsSubstUWork.ChgSrcGoodsNoNoneHp = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CHGSRCGOODSNONONEHPRF"));
                    partsSubstUWork.ChgDestMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CHGDESTMAKERCDRF"));
                    partsSubstUWork.ChgDestGoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CHGDESTGOODSNORF"));
                    partsSubstUWork.ChgDestGoodsNoNoneHp = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CHGDESTGOODSNONONEHPRF"));
                    partsSubstUWork.ApplyStaDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("APPLYSTADATERF"));
                    partsSubstUWork.ApplyEndDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("APPLYENDDATERF"));
                    meijiPartsSubstWork.ChgSrcMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
                    meijiPartsSubstWork.ChgDestGoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CHGDESTGOODSNORF2"));
                    meijiPartsSubstWork.ChgSrcGoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CHGSRCGOODSNORF2"));
                    str = partsSubstUWork.ChgSrcMakerCd + ":" + partsSubstUWork.ChgSrcGoodsNo;
                    str1 = meijiPartsSubstWork.ChgSrcMakerCd + ":" + meijiPartsSubstWork.ChgDestGoodsNo + ":" + meijiPartsSubstWork.ChgSrcGoodsNo;
                    if (!CntDic.ContainsKey(str1))
                    {
                        cndtnWorkList.Add(meijiPartsSubstWork);
                        CntDic.Add(str1, "");
                    }
                    if (loginDic.ContainsKey(str))
                    {
                        continue;
                    }
                    loginDic.Add(str, "");
                    searchBackWorkList.Add(partsSubstUWork);
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                CntDic.Clear();
                loginDic.Clear();

                if (searchBackWorkList.Count > 0)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                else
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                }
            }
            catch (SqlException exsql)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                status = base.WriteSQLErrorLog(exsql, errmsg, exsql.Number);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                base.WriteErrorLog(ex, errmsg, status);
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
        # endregion

        # region [Where���쐬����]
        /// <summary>
        /// �������������񐶐��{�����l�ݒ�
        /// </summary>
        /// <param name="sqlCommand">SqlCommand�I�u�W�F�N�g</param>
        /// <param name="mode">�敪</param>
        /// <param name="enterPriseCode">��ƃR�[�h</param>
        /// <returns>Where����������</returns>
        /// <remarks>
        /// <br>Note       : Where����쐬���Ė߂��܂�</br>
        /// <br>Programmer : �i�N</br>
        /// <br>Date       : 2015/01/26</br>
        /// </remarks>
        private StringBuilder MakeWhereString(ref SqlCommand sqlCommand, int mode, string enterPriseCode)
        {
            StringBuilder sql = new StringBuilder();
            // ��ƃR�[�h
            sql.Append(" WHERE PRT.ENTERPRISECODERF = @FINDENTERPRISECODE ").Append(Environment.NewLine);
            SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
            findEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterPriseCode);

            //�_���폜�敪
            sql.Append(" AND B.LOGICALDELETECODERF = @FINDLOGICALDELETECODE ").Append(Environment.NewLine);
            SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
            paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);

            //�}�X�^�敪
            if (mode == 1)
            {
                sql.Append(" AND B.MASTERDIVCDRF = @FINDMASTERDIVCDRF ").Append(Environment.NewLine);
                SqlParameter paraLogicalMasterDiv = sqlCommand.Parameters.Add("@FINDMASTERDIVCDRF", SqlDbType.Int);
                paraLogicalMasterDiv.Value = SqlDataMediator.SqlSetInt32(5);
            }

            sql.Append(" ORDER BY PRT.ENTERPRISECODERF, PRT.CHGSRCMAKERCDRF, PRT.CHGSRCGOODSNORF ");

            return sql;
        }
        # endregion
 
        /// <summary>
        /// ���[�N��Clone
        /// </summary>
        /// <param name="work"></param>
        /// <returns></returns>
        private PartsSubstUWork CloneJoinWork(PartsSubstUWork work)
        {
            PartsSubstUWork partsSubstUWork = new PartsSubstUWork();
            partsSubstUWork.EnterpriseCode = work.EnterpriseCode;
            partsSubstUWork.UpdateDateTime = work.UpdateDateTime;
            partsSubstUWork.ChgDestGoodsNo = work.ChgDestGoodsNo;
            partsSubstUWork.ChgDestMakerCd = work.ChgDestMakerCd;
            partsSubstUWork.ChgSrcGoodsNo = work.ChgSrcGoodsNo;
            partsSubstUWork.ChgSrcMakerCd = work.ChgSrcMakerCd;
            return partsSubstUWork;
        }
    }
}
