//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �d����ϊ��c�[��
// �v���O�����T�v   : ���i�Ǘ����}�X�^�̍œK���ׁ̈A�s�v�ȃ��R�[�h���폜����B
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 杍^
// �� �� ��  2009/07/13  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �C �� ��  2009/07/24  �C�����e : PVCS#366 �R�l�N�V�����̉���Ɋւ���
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �C �� ��  2009/07/27  �C�����e : PVCS#369 �_���폜�敪(LogicalDeleteCode)�̔����ǉ�����B
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Data;
using Broadleaf.Library.Data.SqlTypes;
using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Application.Resources;
using System.Collections.Generic;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// �d����ϊ��c�[��READDB�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : �d����ϊ��c�[��READ�̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : 杍^</br>
    /// <br>Date       : 2009.07.13</br>
    /// </remarks>
    [Serializable]
    public class SupplierChangeProcDB : RemoteDB, ISupplierChangeProcDB
    {
        #region �� Const Memebers ��
        private const string ALL_SECTIONCODE = "00";
        private const string MARK_KEY = "<-->";
        private const string MARK_0 = "0";
        #endregion

        #region �� �d����ϊ��c�[���̍폜���� ��
        /// <summary>
        /// �d����ϊ��c�[���̍폜����
        /// </summary>
        /// <param name="enterpriseCodes">��ƃR�[�h</param>
        /// <param name="readCount">��������</param>
        /// <param name="delCount">�폜����</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �d����ϊ��c�[���̍폜�������s���N���X�ł��B</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2009.07.13</br>
        /// </remarks>
        public int DeleteGoodsMng(string enterpriseCodes, out int readCount, out int delCount)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            readCount = 0;
            delCount = 0;
            //--------------------------
            // �f�[�^�x�[�X�I�[�v��
            //--------------------------
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            // MOD 2009/07/24 --->>>
            try
            {
            // MOD 2009/07/24 ---<<<
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string _connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                if (_connectionText == null || _connectionText == "")
                {
                    return status;
                }

                sqlConnection = new SqlConnection(_connectionText);
                sqlConnection.Open();

                Dictionary<string, SupplierChangeWork> group1Dic = new Dictionary<string, SupplierChangeWork>();
                Dictionary<string, SupplierChangeWork> group2Dic = new Dictionary<string, SupplierChangeWork>();
                Dictionary<string, SupplierChangeWork> group3Dic = new Dictionary<string, SupplierChangeWork>();
                Dictionary<string, SupplierChangeWork> group4Dic = new Dictionary<string, SupplierChangeWork>();

                // �d����ϊ��c�[���̉�ʌ�������
                status = Search(enterpriseCodes, 
                                ref group1Dic,
                                ref group2Dic,
                                ref group3Dic,
                                ref group4Dic,
                                ref sqlConnection);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    readCount = group1Dic.Count + group2Dic.Count + group3Dic.Count + group4Dic.Count;

                    ArrayList delList = new ArrayList();

                    SupplierChangeWork tempWork = null;
                    SupplierChangeWork temp2Work = null;
                    SupplierChangeWork temp3Work = null;
                    SupplierChangeWork temp4Work = null;

                    bool isFlag = false;

                    SupplierChangeWork work = null;
                    string tempKey = string.Empty;

                    foreach (KeyValuePair<string, SupplierChangeWork> temp1Dic in group1Dic)
                    {
                        tempWork = temp1Dic.Value;

                        // ���_ != "00"�̏ꍇ�A
                        if (!ALL_SECTIONCODE.Equals(tempWork.SectionCode))
                        {
                            // �@���_�{���[�J�[�{�i�ԗpDictionary
                            tempKey = ALL_SECTIONCODE + MARK_KEY + MARK_0 + MARK_KEY + Convert.ToString(tempWork.GoodsMakerCd)
                                + MARK_KEY + MARK_0 + MARK_KEY + tempWork.GoodsNo;
                            // ���X�g���ɓ���̃��[�J�[�{�i�ԂőS�Аݒ�("00")�̃��R�[�h�����݂��Ȃ�������������B
                            if (group1Dic.ContainsKey(tempKey))
                            {
                                work = group1Dic[tempKey];
                                // ���݂����ꍇ�A�d����R�[�h�Ɣ������b�g����v�����ꍇ�͍폜�ΏۂƂ���B
                                // MOD 2009/07/27 --->>>
                                if (work.SupplierCd == tempWork.SupplierCd
                                    && work.SupplierLot == tempWork.SupplierLot
                                    && work.LogicalDeleteCode == 0)
                                // MOD 2009/07/27 ---<<<
                                {
                                    delList.Add(tempWork);
                                    continue;
                                }
                                // ��v���Ȃ������ꍇ�́A���̃��[�v������
                                else
                                {
                                    continue;
                                }
                            }

                            // �A���_�{���[�J�[�{�����ށ{�a�k�R�[�h�pDictionary
                            tempKey = tempWork.SectionCode + MARK_KEY + Convert.ToString(tempWork.JoinGoodsMGroup) + MARK_KEY + Convert.ToString(tempWork.GoodsMakerCd)
                                + MARK_KEY + Convert.ToString(tempWork.JoinBLGoodsCode) + MARK_KEY + string.Empty;
                            // ���X�g���ɓ���̋��_�{���[�J�[�{�����ށ{�a�k�R�[�h�̃��R�[�h�����݂��Ȃ�������������B
                            if (group2Dic.ContainsKey(tempKey))
                            {
                                work = group2Dic[tempKey];
                                // ���݂����ꍇ�A�d����R�[�h�Ɣ������b�g����v�����ꍇ�͍폜�ΏۂƂ���B
                                // MOD 2009/07/27 --->>>
                                if (work.SupplierCd == tempWork.SupplierCd
                                    && work.SupplierLot == tempWork.SupplierLot
                                    && work.LogicalDeleteCode == 0)
                                // MOD 2009/07/27 ---<<<
                                {
                                    delList.Add(tempWork);
                                    continue;
                                }
                                // ��v���Ȃ������ꍇ�́A���̃��[�v������
                                else
                                {
                                    continue;
                                }
                            }

                            // �B���_�{���[�J�[�{�����ށ{�a�k�R�[�h�pDictionary
                            tempKey = ALL_SECTIONCODE + MARK_KEY + Convert.ToString(tempWork.JoinGoodsMGroup) + MARK_KEY + Convert.ToString(tempWork.GoodsMakerCd)
                                + MARK_KEY + Convert.ToString(tempWork.JoinBLGoodsCode) + MARK_KEY + string.Empty;
                            // ���X�g���ɓ���̃��[�J�[�{�i�ԂőS�Аݒ�("00")�̃��R�[�h�����݂��Ȃ�������������B
                            if (group2Dic.ContainsKey(tempKey))
                            {
                                work = group2Dic[tempKey];
                                // ���݂����ꍇ�A�d����R�[�h�Ɣ������b�g����v�����ꍇ�͍폜�ΏۂƂ���B
                                // MOD 2009/07/27 --->>>
                                if (work.SupplierCd == tempWork.SupplierCd
                                    && work.SupplierLot == tempWork.SupplierLot
                                    && work.LogicalDeleteCode == 0)
                                // MOD 2009/07/27 ---<<<
                                {
                                    delList.Add(tempWork);
                                    continue;
                                }
                                // ��v���Ȃ������ꍇ�́A���̃��[�v������
                                else
                                {
                                    continue;
                                }
                            }

                            // �C���_�{���[�J�[�{�����ޗpDictionary
                            tempKey = tempWork.SectionCode + MARK_KEY + Convert.ToString(tempWork.JoinGoodsMGroup) + MARK_KEY + Convert.ToString(tempWork.GoodsMakerCd)
                                + MARK_KEY + MARK_0 + MARK_KEY + string.Empty;
                            // ���X�g���ɓ���̋��_�{���[�J�[�{�����ށ{�a�k�R�[�h�̃��R�[�h�����݂��Ȃ�������������B
                            if (group3Dic.ContainsKey(tempKey))
                            {
                                work = group3Dic[tempKey];
                                // ���݂����ꍇ�A�d����R�[�h�Ɣ������b�g����v�����ꍇ�͍폜�ΏۂƂ���B
                                // MOD 2009/07/27 --->>>
                                if (work.SupplierCd == tempWork.SupplierCd
                                    && work.SupplierLot == tempWork.SupplierLot
                                    && work.LogicalDeleteCode == 0)
                                // MOD 2009/07/27 ---<<<
                                {
                                    delList.Add(tempWork);
                                    continue;
                                }
                                // ��v���Ȃ������ꍇ�́A���̃��[�v������
                                else
                                {
                                    continue;
                                }
                            }

                            // �D���_�{���[�J�[�{�����ޗpDictionary
                            tempKey = ALL_SECTIONCODE + MARK_KEY + Convert.ToString(tempWork.JoinGoodsMGroup) + MARK_KEY + Convert.ToString(tempWork.GoodsMakerCd)
                                + MARK_KEY + MARK_0 + MARK_KEY + string.Empty;
                            // ���X�g���ɓ���̃��[�J�[�{�i�ԂőS�Аݒ�("00")�̃��R�[�h�����݂��Ȃ�������������B
                            if (group3Dic.ContainsKey(tempKey))
                            {
                                work = group3Dic[tempKey];
                                // ���݂����ꍇ�A�d����R�[�h�Ɣ������b�g����v�����ꍇ�͍폜�ΏۂƂ���B
                                // MOD 2009/07/27 --->>>
                                if (work.SupplierCd == tempWork.SupplierCd
                                    && work.SupplierLot == tempWork.SupplierLot
                                    && work.LogicalDeleteCode == 0)
                                // MOD 2009/07/27 ---<<<
                                {
                                    delList.Add(tempWork);
                                    continue;
                                }
                                // ��v���Ȃ������ꍇ�́A���̃��[�v������
                                else
                                {
                                    continue;
                                }
                            }

                            // �E���_�{���[�J�[�pDictionary
                            tempKey = tempWork.SectionCode + MARK_KEY + MARK_0 + MARK_KEY + Convert.ToString(tempWork.GoodsMakerCd)
                                + MARK_KEY + MARK_0 + MARK_KEY + string.Empty;
                            // ���X�g���ɓ���̋��_�{���[�J�[�{�����ށ{�a�k�R�[�h�̃��R�[�h�����݂��Ȃ�������������B
                            if (group4Dic.ContainsKey(tempKey))
                            {
                                work = group4Dic[tempKey];
                                // ���݂����ꍇ�A�d����R�[�h�Ɣ������b�g����v�����ꍇ�͍폜�ΏۂƂ���B
                                // MOD 2009/07/27 --->>>
                                if (work.SupplierCd == tempWork.SupplierCd
                                    && work.SupplierLot == tempWork.SupplierLot
                                    && work.LogicalDeleteCode == 0)
                                // MOD 2009/07/27 ---<<<
                                {
                                    delList.Add(tempWork);
                                    continue;
                                }
                                // ��v���Ȃ������ꍇ�́A���̃��[�v������
                                else
                                {
                                    continue;
                                }
                            }

                            // �F���_�{���[�J�[�pDictionary
                            tempKey = ALL_SECTIONCODE + MARK_KEY + MARK_0 + MARK_KEY + Convert.ToString(tempWork.GoodsMakerCd)
                                + MARK_KEY + MARK_0 + MARK_KEY + string.Empty;
                            // ���X�g���ɓ���̃��[�J�[�{�i�ԂőS�Аݒ�("00")�̃��R�[�h�����݂��Ȃ�������������B
                            if (group4Dic.ContainsKey(tempKey))
                            {
                                work = group4Dic[tempKey];
                                // ���݂����ꍇ�A�d����R�[�h�Ɣ������b�g����v�����ꍇ�͍폜�ΏۂƂ���B
                                // MOD 2009/07/27 --->>>
                                if (work.SupplierCd == tempWork.SupplierCd
                                    && work.SupplierLot == tempWork.SupplierLot
                                    && work.LogicalDeleteCode == 0)
                                // MOD 2009/07/27 ---<<<
                                {
                                    delList.Add(tempWork);
                                    continue;
                                }
                                // ��v���Ȃ������ꍇ�́A���̃��[�v������
                                else
                                {
                                    continue;
                                }
                            }
                        }
                        // ���_ == "00"�̏ꍇ�A
                        else
                        {
                            isFlag = false;

                            // �A���_�{���[�J�[�{�����ށ{�a�k�R�[�h�pDictionary
                            foreach (KeyValuePair<string, SupplierChangeWork> temp2Dic in group2Dic)
                            {
                                temp2Work = temp2Dic.Value;

                                if (!ALL_SECTIONCODE.Equals(temp2Work.SectionCode)
                                    && tempWork.JoinGoodsMGroup == temp2Work.GoodsMGroup
                                    && tempWork.GoodsMakerCd == temp2Work.GoodsMakerCd
                                    && tempWork.JoinBLGoodsCode == temp2Work.BLGoodsCode
                                    && string.IsNullOrEmpty(temp2Work.GoodsNo))
                                {
                                    isFlag = true;
                                    break;
                                }
                            }

                            // �P���ł����݂����ꍇ�A���̃��[�v������
                            if (isFlag)
                            {
                                continue;
                            }

                            // �B���_�{���[�J�[�{�����ށ{�a�k�R�[�h�pDictionary
                            tempKey = ALL_SECTIONCODE + MARK_KEY + Convert.ToString(tempWork.JoinGoodsMGroup) + MARK_KEY + Convert.ToString(tempWork.GoodsMakerCd)
                                + MARK_KEY + Convert.ToString(tempWork.JoinBLGoodsCode) + MARK_KEY + string.Empty;
                            // ���X�g���ɓ���̃��[�J�[�{�i�ԂőS�Аݒ�("00")�̃��R�[�h�����݂��Ȃ�������������B
                            if (group2Dic.ContainsKey(tempKey))
                            {
                                work = group2Dic[tempKey];
                                // ���݂����ꍇ�A�d����R�[�h�Ɣ������b�g����v�����ꍇ�͍폜�ΏۂƂ���B
                                // MOD 2009/07/27 --->>>
                                if (work.SupplierCd == tempWork.SupplierCd
                                    && work.SupplierLot == tempWork.SupplierLot
                                    && work.LogicalDeleteCode == 0)
                                // MOD 2009/07/27 ---<<<
                                {
                                    delList.Add(tempWork);
                                    continue;
                                }
                                // ��v���Ȃ������ꍇ�́A���̃��[�v������
                                else
                                {
                                    continue;
                                }
                            }

                            // �C���_�{���[�J�[�{�����ޗpDictionary
                            foreach (KeyValuePair<string, SupplierChangeWork> temp3Dic in group3Dic)
                            {
                                temp3Work = temp3Dic.Value;

                                if (!ALL_SECTIONCODE.Equals(temp3Work.SectionCode)
                                    && tempWork.JoinGoodsMGroup == temp3Work.GoodsMGroup
                                    && tempWork.GoodsMakerCd == temp3Work.GoodsMakerCd
                                    && 0 == temp3Work.BLGoodsCode
                                    && string.IsNullOrEmpty(temp3Work.GoodsNo))
                                {
                                    isFlag = true;
                                    break;
                                }
                            }

                            // �P���ł����݂����ꍇ�A���̃��[�v������
                            if (isFlag)
                            {
                                continue;
                            }

                            // �D���_�{���[�J�[�{�����ޗpDictionary
                            tempKey = ALL_SECTIONCODE + MARK_KEY + Convert.ToString(tempWork.JoinGoodsMGroup) + MARK_KEY + Convert.ToString(tempWork.GoodsMakerCd)
                                + MARK_KEY + MARK_0 + MARK_KEY + string.Empty;
                            // ���X�g���ɓ���̃��[�J�[�{�i�ԂőS�Аݒ�("00")�̃��R�[�h�����݂��Ȃ�������������B
                            if (group3Dic.ContainsKey(tempKey))
                            {
                                work = group3Dic[tempKey];
                                // ���݂����ꍇ�A�d����R�[�h�Ɣ������b�g����v�����ꍇ�͍폜�ΏۂƂ���B
                                // MOD 2009/07/27 --->>>
                                if (work.SupplierCd == tempWork.SupplierCd
                                    && work.SupplierLot == tempWork.SupplierLot
                                    && work.LogicalDeleteCode == 0)
                                // MOD 2009/07/27 ---<<<
                                {
                                    delList.Add(tempWork);
                                    continue;
                                }
                                // ��v���Ȃ������ꍇ�́A���̃��[�v������
                                else
                                {
                                    continue;
                                }
                            }

                            // �E���_�{���[�J�[�pDictionary
                            foreach (KeyValuePair<string, SupplierChangeWork> temp4Dic in group4Dic)
                            {
                                temp4Work = temp4Dic.Value;

                                if (!ALL_SECTIONCODE.Equals(temp4Work.SectionCode)
                                    && 0 == temp4Work.GoodsMGroup
                                    && tempWork.GoodsMakerCd == temp4Work.GoodsMakerCd
                                    && 0 == temp4Work.BLGoodsCode
                                    && string.IsNullOrEmpty(temp4Work.GoodsNo))
                                {
                                    isFlag = true;
                                    break;
                                }
                            }

                            // �P���ł����݂����ꍇ�A���̃��[�v������
                            if (isFlag)
                            {
                                continue;
                            }

                            // �F���_�{���[�J�[�pDictionary
                            tempKey = ALL_SECTIONCODE + MARK_KEY + MARK_0 + MARK_KEY + Convert.ToString(tempWork.GoodsMakerCd)
                                + MARK_KEY + MARK_0 + MARK_KEY + string.Empty;
                            // ���X�g���ɓ���̃��[�J�[�{�i�ԂőS�Аݒ�("00")�̃��R�[�h�����݂��Ȃ�������������B
                            if (group4Dic.ContainsKey(tempKey))
                            {
                                work = group4Dic[tempKey];
                                // ���݂����ꍇ�A�d����R�[�h�Ɣ������b�g����v�����ꍇ�͍폜�ΏۂƂ���B
                                // MOD 2009/07/27 --->>>
                                if (work.SupplierCd == tempWork.SupplierCd
                                    && work.SupplierLot == tempWork.SupplierLot
                                    && work.LogicalDeleteCode == 0)
                                // MOD 2009/07/27 ---<<<
                                {
                                    delList.Add(tempWork);
                                    continue;
                                }
                                // ��v���Ȃ������ꍇ�́A���̃��[�v������
                                else
                                {
                                    continue;
                                }
                            }
                        }
                    }
                    // SupplierChangeWork�C���X�^���X�̒l��GoodsMngWork�C���X�^���X�̓���ID�̃v���p�e�B�ɃZ�b�g����B
                    ArrayList goodsMngDelArr = new ArrayList();
                    GoodsMngWork goodsMngWork = null;

                    foreach (SupplierChangeWork supplierChangeWork in delList)
                    {
                        goodsMngWork = new GoodsMngWork();
                        goodsMngWork.EnterpriseCode = supplierChangeWork.EnterpriseCode;
                        goodsMngWork.UpdateDateTime = supplierChangeWork.UpdateDateTime;
                        goodsMngWork.SectionCode = supplierChangeWork.SectionCode;
                        goodsMngWork.GoodsMGroup = supplierChangeWork.GoodsMGroup;
                        goodsMngWork.GoodsMakerCd = supplierChangeWork.GoodsMakerCd;
                        goodsMngWork.BLGoodsCode = supplierChangeWork.BLGoodsCode;
                        goodsMngWork.GoodsNo = supplierChangeWork.GoodsNo;
                        goodsMngDelArr.Add(goodsMngWork);
                    }


                    // ���i�Ǘ����}�X�^�����[�g�̍폜���\�b�h�̌Ăяo�����s��
                    GoodsMngDB _goodsMngDB = new GoodsMngDB();

    #if DEBUG
                    // �g�����U�N�V����
                    sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_ReadUnCommitted);
    #else
                                    // �g�����U�N�V����
                    sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);
    #endif

                    status = _goodsMngDB.DeleteGoodsMngProc(goodsMngDelArr, ref sqlConnection, ref sqlTransaction);

                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        // �폜����
                        delCount = goodsMngDelArr.Count;
                    }
                }
            
            }
            // MOD 2009/07/24 --->>>
            catch (Exception ex)
            {
                // ���N���X�ɗ�O��n���ď������Ă��炤
                base.WriteErrorLog(ex, "SupplierChangeProcDB.DeleteGoodsMng Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlConnection != null)
                {
                    if (sqlTransaction.Connection != null)
                    {
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            sqlTransaction.Commit();
                        }
                        else
                        {
                            sqlTransaction.Rollback();
                        }
                    }
                }

                if (sqlTransaction != null) sqlTransaction.Dispose();
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            // MOD 2009/07/24 ---<<<
            return status;
        }
        #endregion

        #region �� �d����ϊ��c�[���̉�ʌ������� ��
        /// <summary>
        /// �d����ϊ��c�[���̉�ʌ�������
        /// </summary>
        /// <param name="enterpriseCodes">��ƃR�[�h</param>
        /// <param name="group1Dic">���_�{���[�J�[�{�i��Dictionary</param>
        /// <param name="group2Dic">���_�{���[�J�[�{�����ށ{�a�k�R�[�hDictionary</param>
        /// <param name="group3Dic">���_�{���[�J�[�{������Dictionary</param>
        /// <param name="group4Dic">���_�{���[�J�[Dictionary</param>
        /// <param name="sqlConnection">SQL�R�l�N�V����</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �d����ϊ��c�[����ʌ������s���N���X�ł��B</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2009.07.13</br>
        /// </remarks>
        private int Search(string enterpriseCodes,
                            ref Dictionary<string, SupplierChangeWork> group1Dic,
                            ref Dictionary<string, SupplierChangeWork> group2Dic,
                            ref Dictionary<string, SupplierChangeWork> group3Dic,
                            ref Dictionary<string, SupplierChangeWork> group4Dic,
                            ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            SqlCommand sqlCommand = null;
            SqlDataReader myReader = null;
            StringBuilder sb = new StringBuilder();
            SupplierChangeWork supplierChangeWork = null;
            string goodsNo = string.Empty;
            int blGoodsCode = 0;
            int goodsMGroup = 0;
            int goodsMakerCd = 0;
            string sectionCode = string.Empty;

            string groupDicKey = string.Empty;


            sqlCommand = new SqlCommand("", sqlConnection);

            try
            {
                // Select�R�}���h�̐���
                sb.Append(" SELECT A.CREATEDATETIMERF, A.UPDATEDATETIMERF, A.ENTERPRISECODERF, A.FILEHEADERGUIDRF, A.UPDEMPLOYEECODERF, A.UPDASSEMBLYID1RF, A.UPDASSEMBLYID2RF, A.LOGICALDELETECODERF, A.SECTIONCODERF, A.GOODSMGROUPRF, A.GOODSMAKERCDRF, A.BLGOODSCODERF, A.GOODSNORF, A.SUPPLIERCDRF, A.SUPPLIERLOTRF, B.BLGOODSCODERF AS JOINBLGOODSCODERF, D.GOODSMGROUPRF AS JOINGOODSMGROUPRF ");
                sb.Append(" FROM GOODSMNGRF A ");
                sb.Append(" LEFT JOIN GOODSURF B ON ");
                sb.Append(" A.ENTERPRISECODERF = B.ENTERPRISECODERF ");
                sb.Append(" AND A.GOODSNORF = B.GOODSNORF ");
                sb.Append(" AND A.GOODSMAKERCDRF = B.GOODSMAKERCDRF ");
                sb.Append(" LEFT JOIN BLGOODSCDURF C ON ");
                sb.Append(" B.ENTERPRISECODERF = C.ENTERPRISECODERF ");
                sb.Append(" AND B.BLGOODSCODERF = C.BLGOODSCODERF  ");
                sb.Append(" LEFT JOIN BLGROUPURF D ON ");
                sb.Append(" C.ENTERPRISECODERF = D.ENTERPRISECODERF ");
                sb.Append(" AND C.BLGROUPCODERF = D.BLGROUPCODERF ");
                sb.Append(" WHERE A.ENTERPRISECODERF = @FINDENTERPRISECODE ");

                //Prameter�I�u�W�F�N�g�̍쐬
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);

                //Parameter�I�u�W�F�N�g�֒l�ݒ�
                findParaEnterpriseCode.Value = enterpriseCodes;

                sqlCommand.CommandText = sb.ToString();
                // �ǂݍ���
                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    supplierChangeWork = new SupplierChangeWork();
                    supplierChangeWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                    supplierChangeWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                    // MOD 2009/07/27 --->>>
                    supplierChangeWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                    // MOD 2009/07/27 ---<<<
                    sectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
                    sectionCode = sectionCode.Trim();
                    supplierChangeWork.SectionCode = sectionCode;
                    // ���i�����ރR�[�h
                    goodsMGroup = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMGROUPRF"));
                    supplierChangeWork.GoodsMGroup = goodsMGroup;
                    // ���i���[�J�[�R�[�h
                    goodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
                    supplierChangeWork.GoodsMakerCd = goodsMakerCd;
                    // BL���i�R�[�h
                    blGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF"));
                    supplierChangeWork.BLGoodsCode = blGoodsCode;
                    // ���i�ԍ�
                    goodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
                    supplierChangeWork.GoodsNo = goodsNo;
                    supplierChangeWork.SupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERCDRF"));
                    supplierChangeWork.SupplierLot = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERLOTRF"));
                    supplierChangeWork.JoinBLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("JOINBLGOODSCODERF"));
                    supplierChangeWork.JoinGoodsMGroup = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("JOINGOODSMGROUPRF"));

                    groupDicKey = sectionCode + MARK_KEY + Convert.ToString(goodsMGroup) + MARK_KEY + Convert.ToString(goodsMakerCd) + MARK_KEY + Convert.ToString(blGoodsCode) + MARK_KEY + goodsNo;

                    // ���i�Ǘ����}�X�^.�i�� != string.Empty
                    if (!string.IsNullOrEmpty(goodsNo))
                    {
                        group1Dic.Add(groupDicKey, supplierChangeWork);
                    }
                    // ���i�Ǘ����}�X�^.BL�R�[�h != 0
                    else if (blGoodsCode != 0)
                    {
                        group2Dic.Add(groupDicKey, supplierChangeWork);
                    }
                    // ���i�Ǘ����}�X�^.�����ރR�[�h != 0 AND ���i�Ǘ����}�X�^.BL�R�[�h == 0
                    else if (blGoodsCode == 0 && goodsMGroup != 0)
                    {
                        group3Dic.Add(groupDicKey, supplierChangeWork);
                    }
                    // ���i�Ǘ����}�X�^.���[�J�[�R�[�h != 0 AND ���i�Ǘ����}�X�^.�����ރR�[�h == 0 AND ���i�Ǘ����}�X�^.BL�R�[�h == 0 AND ���i�Ǘ����}�X�^.�i�� == string.Empty
                    else if (string.IsNullOrEmpty(goodsNo) && blGoodsCode == 0 && goodsMGroup == 0 && goodsMakerCd != 0)
                    {
                        group4Dic.Add(groupDicKey, supplierChangeWork);
                    }
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                base.WriteErrorLog(ex, "SupplierChangeProcDB.Search Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
                if (myReader != null)
                    if (!myReader.IsClosed) myReader.Close();
            }
            return status;
        }
        #endregion
    }
}
