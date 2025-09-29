//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �񋟃}�X�^�폜����
// �v���O�����T�v   : �񋟃f�[�^�d�����郆�[�U�[�����A�Z�b�g�}�X�^�̃��R�[�h���폜����B
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 杍^
// �� �� ��  2009/06/18  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 杍^
// �C �� ��  2009/07/08  �C�����e : �폜���\�b�h�Ăяo�������Ɋւ��� 
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 杍^
// �C �� ��  2009/07/10  �C�����e : �폜�����̕s�� 
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30517 �Ė� �x��
// �C �� ��  2010/01/28  �C�����e : Mantis:14923�@�����}�X�^�������ɃG���[�������錏�̏C��
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Text;
using System.Net.NetworkInformation;
using Microsoft.Win32;

using Broadleaf.Application.Common;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting;
using Broadleaf.Library.Collections;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Xml.Serialization;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    ///�񋟃}�X�^�폜�����X�N���X
    /// </summary>
    /// <remarks>
    /// Note       : �񋟃}�X�^�폜�����ł��B<br />
    /// Programmer : 杍^<br />
    /// Date       : 2009.06.18<br />
    /// UpdateNote : Mantis:14923�@�����}�X�^�������ɃG���[�������錏�̏C��<br />
    /// Programmer : 30517 �Ė� �x��<br />
    /// Date       : 2010/01/28<br />
    /// </remarks>
    public class OfferMstDelInputAcs
    {
        #region �� Const Memebers ��
        private const string PROGRAM_ID = "PMKHN01200U";
        private const string PROGRAM_NAME = "�񋟃}�X�^�폜����";
        private const string MARK_1 = "<-->";
        #endregion

        # region �� Private Members ��
        private static OfferMstDelInputAcs _offerMstDelInputAcs;
        private IJoinPartsUDB _iJoinPartsUDB;
        private IGoodsSetDB _iGoodsSetDB;

        #endregion

        # region �� Constructor ��
        /// <summary>
        /// �f�t�H���g�R���X�g���N�^�iSingleton�f�U�C���p�^�[�����̗p���Ă���ׁAprivate�Ƃ���j
        /// </summary>
        /// <remarks>
        /// Note       : �Ȃ��B<br />
        /// Programmer : 杍^<br />
        /// Date       : 2009.06.18<br />
        /// </remarks>
        private OfferMstDelInputAcs()
        {
            // �ϐ�������

        }
        # endregion �� Constructor ��

        # region �� �񋟃}�X�^�폜�����A�N�Z�X�N���X �C���X�^���X�擾���� ��
        /// <summary>
        /// �񋟃}�X�^�폜�����A�N�Z�X�N���X �C���X�^���X�擾����
        /// </summary>
        /// <remarks>
        /// Note       : �Ȃ��B<br />
        /// Programmer : 杍^<br />
        /// Date       : 2009.06.18<br />
        /// </remarks>
        /// <returns>�񋟃}�X�^�폜�����A�N�Z�X�N���X �C���X�^���X</returns>
        public static OfferMstDelInputAcs GetInstance()
        {
            if (_offerMstDelInputAcs == null)
            {
                _offerMstDelInputAcs = new OfferMstDelInputAcs();
            }

            return _offerMstDelInputAcs;
        }
        #endregion

        #region �� �����}�X�^�i���[�U�[�j�폜���� ��
        /// <summary>
        /// �����}�X�^�i���[�U�[�j�폜����
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="joinCount">�폜����</param>
        /// </summary>
        /// <remarks>
        /// <br>Note       : �����}�X�^�i���[�U�[�j�폜�������s���B</br>      
        /// <br>Programmer : 杍^</br>                                  
        /// <br>Date       : 2009.06.18</br> 
        /// </remarks>
        /// <returns>�폜���ʃX�e�[�^�X</returns>
        public int DeleteJoinProc(string enterpriseCode, out int joinCount)
        {
            string joinLogStr = string.Empty;
            // �X�V�����pHASHTABLE
            Hashtable updateTimeTable = new Hashtable();
            joinCount = 0;
            // ���[�U�[DB�̌������ʃ��X�g
            ArrayList joinPartsUserList = new ArrayList();
            object joinPartsUserObj = (object)joinPartsUserList;
            // ���[�U�[DB�̌����������[�N
            JoinPartsUWork paraJoinPartsUserWork = new JoinPartsUWork();
            paraJoinPartsUserWork.EnterpriseCode = enterpriseCode;
            object paraJoinPartsUserObj = (object)paraJoinPartsUserWork;
            // OFFER_DB�̌������ʃ��X�g
            ArrayList joinPartsOfferList = new ArrayList();
            object joinPartsOfferObj = (object)joinPartsOfferList;
            // 2010/01/28 Add >>>
            JoinPartsUWork oldParaJoinPartsUserWork = new JoinPartsUWork();
            ArrayList loopAllList = new ArrayList();
            int joinInt = 100000;
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            IJoinPartsDB _iJoinPartsDB = MediationJoinPartsDB.GetJoinPartsDB();
            // 2010/01/28 Add <<<

            // ���O�p�A�N�Z�X
            OperationHistoryLog operationHistoryLog = new OperationHistoryLog();
            // ���[�U�[DB����������B
            // 2010/01/28 Add >>>
            while (joinInt == 100000)
            {
                joinPartsUserList = new ArrayList();
                joinPartsUserObj = (object)joinPartsUserList;
                if (oldParaJoinPartsUserWork != null)
                {
                    paraJoinPartsUserWork.JoinSourceMakerCode = oldParaJoinPartsUserWork.JoinSourceMakerCode;
                    paraJoinPartsUserWork.JoinSourPartsNoWithH = oldParaJoinPartsUserWork.JoinSourPartsNoWithH;
                    paraJoinPartsUserWork.JoinDestMakerCd = oldParaJoinPartsUserWork.JoinDestMakerCd;
                    paraJoinPartsUserWork.JoinDestPartsNo = oldParaJoinPartsUserWork.JoinDestPartsNo;
                }
                // 2010/01/28 Add <<<
                this._iJoinPartsUDB = MediationJoinPartsUDB.GetJoinPartsUDB();
                // 2010/01/28 >>>
                //int status = _iJoinPartsUDB.Search(ref joinPartsUserObj, paraJoinPartsUserObj, 0, ConstantManagement.LogicalMode.GetDataAll);
                status = _iJoinPartsUDB.SearchMstDel(ref joinPartsUserObj, paraJoinPartsUserObj, 0, ConstantManagement.LogicalMode.GetDataAll, 100000);
                // 2010/01/28 <<<
                // �����}�X�^(��)�̒��o
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    ArrayList joinPartsUserTempList = joinPartsUserObj as ArrayList;
                    //IJoinPartsDB _iJoinPartsDB = MediationJoinPartsDB.GetJoinPartsDB(); // 2010/01/28 Del
                    ArrayList loopList = new ArrayList();
                    //ArrayList loopAllList = new ArrayList();    // 2010/01/28 Del
                    JoinPartsUWork loopWork = null;
                    // 2010/01/28 >>>
                    //int joinInt = joinPartsUserTempList.Count;
                    joinInt = joinPartsUserTempList.Count;
                    // 2010/01/28 <<<

                    for (int i = 1; i <= joinInt; i++)
                    {
                        loopWork = (JoinPartsUWork)joinPartsUserTempList[i - 1];
                        loopList.Add(loopWork);
                        // MOD 杍^ 2009/07/08 --->>>
                        if (i != 1 && i % 100000 == 0)
                        // MOD 杍^ 2009/07/08 ---<<<
                        {

                            loopAllList.Add(loopList);
                            loopList = new ArrayList();
                        }
                    }

                    if (loopList.Count != 0)
                    {
                        loopAllList.Add(loopList);
                    }

                    // 2010/01/28 Add >>>
                    oldParaJoinPartsUserWork.JoinSourceMakerCode = loopWork.JoinSourceMakerCode;
                    oldParaJoinPartsUserWork.JoinSourPartsNoWithH = loopWork.JoinSourPartsNoWithH;
                    oldParaJoinPartsUserWork.JoinDestMakerCd = loopWork.JoinDestMakerCd;
                    oldParaJoinPartsUserWork.JoinDestPartsNo = loopWork.JoinDestPartsNo;
                }
                else
                    joinInt = 0;
            }
            if (loopAllList.Count != 0)
            {
                // 2010/01/28 Add <<<

                ArrayList loopTempList = new ArrayList();
                // OFFER_DB�����p���X�g
                ArrayList joinPartsOfferTempList;
                JoinPartsWork JoinPartsTempWork = null;
                int joinTempCount = 0;

                for (int m = 0; m < loopAllList.Count; m++)
                {
                    joinPartsOfferTempList = new ArrayList();
                    loopTempList = (ArrayList)loopAllList[m];
                    for (int n = 0; n < loopTempList.Count; n++)
                    {
                        JoinPartsUWork tempWork = (JoinPartsUWork)loopTempList[n];
                        JoinPartsTempWork = new JoinPartsWork();
                        JoinPartsTempWork.JoinSourceMakerCode = tempWork.JoinSourceMakerCode;
                        JoinPartsTempWork.JoinSourPartsNoWithH = tempWork.JoinSourPartsNoWithH;
                        JoinPartsTempWork.JoinDestMakerCd = tempWork.JoinDestMakerCd;
                        JoinPartsTempWork.JoinDestPartsNo = tempWork.JoinDestPartsNo;
                        // MOD 杍^ 2009/07/08 --->>>
                        // �X�V�����pHASHTABLE
                        updateTimeTable.Add(Convert.ToString(tempWork.JoinSourceMakerCode) + MARK_1 + tempWork.JoinSourPartsNoWithH
                            + MARK_1 + Convert.ToString(tempWork.JoinDestMakerCd) + MARK_1 + tempWork.JoinDestPartsNo, tempWork.UpdateDateTime);
                        // MOD 杍^ 2009/07/08 ---<<<
                        joinPartsOfferTempList.Add(JoinPartsTempWork);
                    }

                    // OFFER_DB�̌�������
                    object paraJoinPartsOfferObj = (object)joinPartsOfferTempList;

                    try
                    {
                        status = _iJoinPartsDB.Search(out joinPartsOfferObj, paraJoinPartsOfferObj);
                    }
                    catch
                    {
                        status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                    }

                    // �����}�X�^(���[�U�[)�̍폜
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        ArrayList joinPartsOfferChgList = joinPartsOfferObj as ArrayList;
                        // OFFER_DB�폜�p���X�g
                        ArrayList joinPartsOfferDelList = new ArrayList();
                        JoinPartsUWork JoinPartsUdelWork = null;

                        bool isFirst = true;
                        Hashtable JoinPartstable = new Hashtable();
                        foreach (JoinPartsWork delWork in joinPartsOfferChgList)
                        {

                            // MOD 杍^ 2009/07/08 --->>>
                            if (isFirst)
                            {
                                JoinPartstable.Add(Convert.ToString(delWork.JoinSourceMakerCode)
                                    + MARK_1 + delWork.JoinSourPartsNoWithH
                                    + MARK_1 + Convert.ToString(delWork.JoinDestMakerCd)
                                    + MARK_1 + delWork.JoinDestPartsNo, MARK_1);

                                JoinPartsUdelWork = new JoinPartsUWork();
                                JoinPartsUdelWork.EnterpriseCode = enterpriseCode;
                                JoinPartsUdelWork.JoinSourceMakerCode = delWork.JoinSourceMakerCode;
                                JoinPartsUdelWork.JoinSourPartsNoWithH = delWork.JoinSourPartsNoWithH;
                                JoinPartsUdelWork.JoinDestMakerCd = delWork.JoinDestMakerCd;
                                JoinPartsUdelWork.JoinDestPartsNo = delWork.JoinDestPartsNo;
                                // �X�V�����pHASHTABLE
                                JoinPartsUdelWork.UpdateDateTime = (DateTime)updateTimeTable[Convert.ToString(delWork.JoinSourceMakerCode) + MARK_1 + delWork.JoinSourPartsNoWithH
                                    + MARK_1 + Convert.ToString(delWork.JoinDestMakerCd) + MARK_1 + delWork.JoinDestPartsNo];

                                joinPartsOfferDelList.Add(JoinPartsUdelWork);

                                isFirst = false;
                            }
                            else
                            {
                                if (JoinPartstable.ContainsKey(Convert.ToString(delWork.JoinSourceMakerCode)
                                    + MARK_1 + delWork.JoinSourPartsNoWithH
                                    + MARK_1 + Convert.ToString(delWork.JoinDestMakerCd)
                                    + MARK_1 + delWork.JoinDestPartsNo))
                                {
                                    continue;
                                }
                                else
                                {
                                    JoinPartstable.Add(Convert.ToString(delWork.JoinSourceMakerCode)
                                        + MARK_1 + delWork.JoinSourPartsNoWithH
                                        + MARK_1 + Convert.ToString(delWork.JoinDestMakerCd)
                                        + MARK_1 + delWork.JoinDestPartsNo, MARK_1);

                                    JoinPartsUdelWork = new JoinPartsUWork();
                                    JoinPartsUdelWork.EnterpriseCode = enterpriseCode;
                                    JoinPartsUdelWork.JoinSourceMakerCode = delWork.JoinSourceMakerCode;
                                    JoinPartsUdelWork.JoinSourPartsNoWithH = delWork.JoinSourPartsNoWithH;
                                    JoinPartsUdelWork.JoinDestMakerCd = delWork.JoinDestMakerCd;
                                    JoinPartsUdelWork.JoinDestPartsNo = delWork.JoinDestPartsNo;
                                    // �X�V�����pHASHTABLE
                                    JoinPartsUdelWork.UpdateDateTime = (DateTime)updateTimeTable[Convert.ToString(delWork.JoinSourceMakerCode) + MARK_1 + delWork.JoinSourPartsNoWithH
                                        + MARK_1 + Convert.ToString(delWork.JoinDestMakerCd) + MARK_1 + delWork.JoinDestPartsNo];

                                    joinPartsOfferDelList.Add(JoinPartsUdelWork);
                                }
                            }
                        }
                        // ADD 杍^ 2009/07/10 --->>>
                        // �폜����
                        joinTempCount = joinPartsOfferDelList.Count;
                        // ADD 杍^ 2009/07/10 ---<<<

                        object joinPartsOfferDelObj = (object)joinPartsOfferDelList;
                        status = _iJoinPartsUDB.Delete(joinPartsOfferDelObj);
                        // MOD 杍^ 2009/07/08 ---<<<
                    }
                    // �����}�X�^(��)�̃f�[�^�����݂̏ꍇ�A
                    else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                    {
                        continue;
                    }

                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        joinCount = joinCount + joinTempCount;
                    }
                    else
                    {
                        break;
                    }
                }

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL
                    || status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                {
                    joinLogStr = "�����}�X�^ �폜�����F" + IntConvert(joinCount) + " �������ʁF����I��";
                    operationHistoryLog.WriteOperationLog(this, System.DateTime.Now, LogDataKind.SystemLog, PROGRAM_ID, PROGRAM_NAME, string.Empty, 0, 0, joinLogStr, string.Empty);
                }
                else
                {
                    joinLogStr = "�����}�X�^ �폜�����F" + IntConvert(joinCount) + " �������ʁF�X�V�����Ɏ��s���܂����B";
                    operationHistoryLog.WriteOperationLog(this, System.DateTime.Now, LogDataKind.SystemLog, PROGRAM_ID, PROGRAM_NAME, string.Empty, 0, 0, joinLogStr, string.Empty);
                }
            }
            // ���[�U�[DB�̃f�[�^���Ȃ��̏ꍇ�A
            else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
            {
                joinLogStr = "�����}�X�^ �폜�����F0 �������ʁF����I��";
                operationHistoryLog.WriteOperationLog(this, System.DateTime.Now, LogDataKind.SystemLog, PROGRAM_ID, PROGRAM_NAME, string.Empty, 0, 0, joinLogStr, string.Empty);
                return status;
            }
            else
            {
                joinLogStr = "�����}�X�^ �폜�����F0 �������ʁF�X�V�����Ɏ��s���܂����B";
                operationHistoryLog.WriteOperationLog(this, System.DateTime.Now, LogDataKind.SystemLog, PROGRAM_ID, PROGRAM_NAME, string.Empty, 0, 0, joinLogStr, string.Empty);
                return status;
            }
            return status;
        }

        /// <summary>
        /// ���������t�H�[�}�b�g�ݒ�
        /// </summary>
        /// <remarks>		
        /// <br>Note		: ���������t�H�[�}�b�g�ݒ菈�����s���B</br>
        /// <br>Programmer	: 杍^</br>	
        /// <br>Date		: 2009.06.18</br>
        /// </remarks>
        private String IntConvert(Int32 searchCount)
        {
            String searchCountStr = Convert.ToString(searchCount);
            Int32 searchCountLen = searchCountStr.Length;
            if (3 < searchCountLen && searchCountLen <= 6)
            {
                searchCountStr = searchCountStr.Substring(0, searchCountLen - 3) + "," + searchCountStr.Substring(searchCountLen - 3);
            }
            else if (6 < searchCountLen && searchCountLen <= 9)
            {
                searchCountStr = searchCountStr.Substring(0, searchCountLen - 6) + ","
                    + searchCountStr.Substring(searchCountLen - 6, 3) + ","
                    + searchCountStr.Substring(searchCountLen - 3);
            }
            return searchCountStr;
        }
        #endregion

        #region �� �Z�b�g�}�X�^�i���[�U�[�j�폜���� ��
        /// <summary>
        /// �Z�b�g�}�X�^�i���[�U�[�j�폜����
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="setCount">�폜����</param>
        /// </summary>
        /// <remarks>
        /// <br>Note       : �Z�b�g�}�X�^�i���[�U�[�j�폜�������s���B</br>      
        /// <br>Programmer : 杍^</br>                                  
        /// <br>Date       : 2009.06.18</br> 
        /// </remarks>
        /// <returns>�Ǎ����ʃX�e�[�^�X</returns>
        public int DeleteSetProc(string enterpriseCode, out int setCount)
        {
            string setLogStr = string.Empty;
            // �X�V�����pHASHTABLE
            Hashtable updateTimeTable = new Hashtable(); 
            setCount = 0;
            // ���[�U�[DB�̌������ʃ��X�g
            ArrayList setPartsUserList = new ArrayList();
            object setPartsUserObj = (object)setPartsUserList;
            // ���[�U�[DB�̌����������[�N
            GoodsSetWork paraSetPartsUserWork = new GoodsSetWork();
            paraSetPartsUserWork.EnterpriseCode = enterpriseCode;
            object paraSetPartsUserObj = (object)paraSetPartsUserWork;
            // OFFER_DB�̌������ʃ��X�g
            ArrayList setPartsOfferList = new ArrayList();
            object setPartsOfferObj = (object)setPartsOfferList;

            // ���O�p�A�N�Z�X
            OperationHistoryLog operationHistoryLog = new OperationHistoryLog();
            // ���[�U�[DB����������B
            this._iGoodsSetDB = MediationGoodsSetDB.GetGoodsSetDB();
            int status = _iGoodsSetDB.Search(out setPartsUserObj, paraSetPartsUserObj, 0, ConstantManagement.LogicalMode.GetDataAll);
            // �Z�b�g�}�X�^(��)�̒��o
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                ArrayList setPartsUserTempList = setPartsUserObj as ArrayList;
                ISetPartsDB _iSetPartsDB = MediationSetPartsDB.GetSetPartsDB();
                ArrayList loopList = new ArrayList();
                ArrayList loopAllList = new ArrayList();
                GoodsSetWork loopWork = null;
                int setInt = setPartsUserTempList.Count;

                for (int i = 1; i <= setInt; i++)
                {
                    loopWork = (GoodsSetWork)setPartsUserTempList[i - 1];
                    loopList.Add(loopWork);
                    // MOD 杍^ 2009/07/08 --->>>
                    if (i != 1 && i%100000 == 0)
                    // MOD 杍^ 2009/07/08 ---<<<
                    {

                        loopAllList.Add(loopList);
                        loopList = new ArrayList();
                    }
                }

                if (loopList.Count != 0)
                {
                    loopAllList.Add(loopList);
                }

                ArrayList loopTempList = new ArrayList();
                // OFFER_DB�����p���X�g
                ArrayList setPartsOfferTempList;
                SetPartsWork setPartsTempWork = null;
                int setTempCount = 0;

                for (int m = 0; m < loopAllList.Count; m++)
                {
                    setPartsOfferTempList = new ArrayList();
                    loopTempList = (ArrayList)loopAllList[m];
                    for (int n = 0; n < loopTempList.Count; n++)
                    {
                        GoodsSetWork tempWork = (GoodsSetWork)loopTempList[n];
                        setPartsTempWork = new SetPartsWork();
                        setPartsTempWork.SetMainMakerCd = tempWork.ParentGoodsMakerCd;
                        setPartsTempWork.SetMainPartsNo = tempWork.ParentGoodsNo;
                        setPartsTempWork.SetSubMakerCd = tempWork.SubGoodsMakerCd;
                        setPartsTempWork.SetSubPartsNo = tempWork.SubGoodsNo;
                        // MOD 杍^ 2009/07/08 --->>>
                        // �X�V�����pHASHTABLE
                        updateTimeTable.Add(Convert.ToString(tempWork.ParentGoodsMakerCd) + MARK_1 + tempWork.ParentGoodsNo
                            + MARK_1 + Convert.ToString(tempWork.SubGoodsMakerCd) + MARK_1 + tempWork.SubGoodsNo, tempWork.UpdateDateTime);
                        // MOD 杍^ 2009/07/08 ---<<<
                        setPartsOfferTempList.Add(setPartsTempWork);
                    }

                    // OFFER_DB�̌�������
                    object paraSetPartsOfferObj = (object)setPartsOfferTempList;


                    try
                    {
                        status = _iSetPartsDB.Search(out setPartsOfferObj, paraSetPartsOfferObj);
                    }
                    catch
                    {
                        status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                    }

                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        ArrayList setPartsOfferChgList = setPartsOfferObj as ArrayList;
                        setTempCount = setPartsOfferChgList.Count;
                        // OFFER_DB�폜�p���X�g
                        ArrayList setPartsOfferDelList = new ArrayList();
                        GoodsSetWork goodsSetDelWork = null;
                        foreach (SetPartsWork delWork in setPartsOfferChgList)
                        {
                            goodsSetDelWork = new GoodsSetWork();
                            goodsSetDelWork.EnterpriseCode = enterpriseCode;
                            goodsSetDelWork.ParentGoodsMakerCd = delWork.SetMainMakerCd;
                            goodsSetDelWork.ParentGoodsNo = delWork.SetMainPartsNo;
                            goodsSetDelWork.SubGoodsMakerCd = delWork.SetSubMakerCd;
                            goodsSetDelWork.SubGoodsNo = delWork.SetSubPartsNo;
                            // MOD 杍^ 2009/07/08 --->>>
                            // �X�V�����pHASHTABLE
                            goodsSetDelWork.UpdateDateTime = (DateTime)updateTimeTable[Convert.ToString(delWork.SetMainMakerCd) + MARK_1 + delWork.SetMainPartsNo
                                + MARK_1 + Convert.ToString(delWork.SetSubMakerCd) + MARK_1 + delWork.SetSubPartsNo];
                            // MOD 杍^ 2009/07/08 ---<<<
                            setPartsOfferDelList.Add(goodsSetDelWork);
                        }
                        GoodsSetWork[] goodsSetDelWorks = (GoodsSetWork[])setPartsOfferDelList.ToArray(typeof(GoodsSetWork));
                        byte[] setPartsOfferDelObj = XmlByteSerializer.Serialize(goodsSetDelWorks);

                        status = _iGoodsSetDB.Delete(setPartsOfferDelObj);
                    }
                    else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                    {
                        continue;
                    }

                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        setCount = setCount + setTempCount;
                    }
                    else
                    {
                        break;
                    }
                }

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL
                    || status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                {
                    setLogStr = "�Z�b�g�}�X�^ �폜�����F" + IntConvert(setCount) + " �������ʁF����I��";
                    operationHistoryLog.WriteOperationLog(this, System.DateTime.Now, LogDataKind.SystemLog, PROGRAM_ID, PROGRAM_NAME, string.Empty, 0, 0, setLogStr, string.Empty);
                }
                else
                {
                    setLogStr = "�Z�b�g�}�X�^ �폜�����F" + IntConvert(setCount) + " �������ʁF�X�V�����Ɏ��s���܂����B";
                    operationHistoryLog.WriteOperationLog(this, System.DateTime.Now, LogDataKind.SystemLog, PROGRAM_ID, PROGRAM_NAME, string.Empty, 0, 0, setLogStr, string.Empty);
                }
            }
            else if (status == (int)ConstantManagement.DB_Status.ctDB_EOF)
            {
                setLogStr = "�Z�b�g�}�X�^ �폜�����F0 �������ʁF����I��";
                operationHistoryLog.WriteOperationLog(this, System.DateTime.Now, LogDataKind.SystemLog, PROGRAM_ID, PROGRAM_NAME, string.Empty, 0, 0, setLogStr, string.Empty);
                return status;
            }
            else
            {
                setLogStr = "�Z�b�g�}�X�^ �폜�����F0 �������ʁF�X�V�����Ɏ��s���܂����B";
                operationHistoryLog.WriteOperationLog(this, System.DateTime.Now, LogDataKind.SystemLog, PROGRAM_ID, PROGRAM_NAME, string.Empty, 0, 0, setLogStr, string.Empty);
                return status;
            }
            return status;
        }
        #endregion
    }
}
