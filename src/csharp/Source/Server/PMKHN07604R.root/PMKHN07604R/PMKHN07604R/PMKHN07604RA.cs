//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �݌Ƀ}�X�^�i�C���|�[�g�j
// �v���O�����T�v   : �݌Ƀ}�X�^�i�C���|�[�g�jDB�����[�g�I�u�W�F�N�g
//----------------------------------------------------------------------------//
//                (c)Copyright  2012 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : zhangy3
// �� �� ��  2012/06/12  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ� 10801804-00  �쐬�S�� : zhangy3 
// �C �� �� 2012/07/03   �C�����e : Redmine#30387 ���i�}�X�^�C���{�[�g�`�F�b�N�̒ǉ�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ� 10801804-00  �쐬�S�� : zhangy3 
// �C �� �� 2012/07/05   �C�����e : Redmine#30387��Q�ꗗ�̎w�ENO.30�̑Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10801804-00 �쐬�S�� �F������
// �C �� ��  2012/07/11  �C�����e �FRedmine#30387��Q�ꗗ�̎w�ENO.30�̑Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10801804-00 �쐬�S�� �F������
// �C �� ��  2012/07/12  �C�����e �FRedmine#30387��Q�ꗗ�̎w�ENO.93�̑Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10801804-00 �쐬�S�� �F������
// �C �� ��  2012/07/13  �C�����e �FRedmine#30387��Q�ꗗ�̎w�ENO.94�̑Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10801804-00 �쐬�S�� : zhangy3
// �C �� ��  2012/07/20  �C�����e : ��z�Č��ARedmine#30387 �݌Ƀ}�X�^�C���{�[�g�d�l�ύX�̑Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10801804-00 �쐬�S�� : zhangy3
// �C �� ��  2012/07/25  �C�����e : ��z�Č��ARedmine#30387 �d���`�F�b�N�̃��b�Z�[�W��ύX����
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Common;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// �݌Ƀ}�X�^�i�C���|�[�g�jDB�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : �݌Ƀ}�X�^�i�C���|�[�g�j�̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : zhangy3</br>
    /// <br>Date       : 2012/06/12</br>
    /// <br></br>
    /// <br>Update Note: 2012/07/11 ������</br>
    /// <br>�Ǘ��ԍ�   : 10801804-00 ��z�Č�</br>
    /// <br>             ��Q�ꗗ�̎w�ENO.30�̑Ή�</br>
    /// <br>Update Note: 2012/07/12 ������</br>
    /// <br>�Ǘ��ԍ�   : 10801804-00 ��z�Č�</br>
    /// <br>             ��Q�ꗗ�̎w�ENO.93�̑Ή�</br>
    /// <br>Update Note: 2012/07/13 ������</br>
    /// <br>�Ǘ��ԍ�   : 10801804-00 ��z�Č�</br>
    /// <br>             ��Q�ꗗ�̎w�ENO.94�̑Ή�</br>
    /// <br>Update Note: 2012/07/20 zhangy3</br>
    /// <br>�Ǘ��ԍ�   : 10801804-00 ��z�Č�</br>
    /// <br>             Redmine#30387 �݌Ƀ}�X�^�C���{�[�g�d�l�ύX�̑Ή�</br>
    /// <br>Update Note: 2012/07/25 zhangy3</br>
    /// <br>�Ǘ��ԍ�   : 10801804-00 ��z�Č�</br>
    /// <br>             Redmine#30387 �d���`�F�b�N�̃��b�Z�[�W��ύX����</br>
    /// </remarks>
    [Serializable]
    public class StockImportDB : RemoteWithAppLockDB, IStockImportDB
    {

        # region Private Member
        //��ƃR�[�h
        private string _enterpriseCode;
        //���O�C�����_�R�[�h
        private string _loginSectionCode;
        //���O�C�����_����
        private string _loginSectionGuideNm;
        //���O�C���]�ƈ��R�[�h
        private string _employeeCode;
        //���O�C���]�ƈ�����
        private string _employeeName;
        #endregion

        #region IStockImportDB �����o

        /// <summary>
        /// �݌Ƀ}�X�^�i�C���|�[�g�j�̃C���|�[�g�����B
        /// </summary>
        /// <param name="processKbn">�����敪</param>
        /// <param name="dataCheckKbn">�`�F�b�N�敪</param>
        /// <param name="importStockWorkList">�݌Ƀ}�X�^���X�g</param>
        /// <param name="objStockCheckList">�݌Ƀ}�X�^�`�F�b�N���X�g</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="loginSectionCode">���O�C�����_�R�[�h</param>
        /// <param name="loginSectionGuideNm">���O�C�����_����</param>
        /// <param name="employeeCode">���O�C���]�ƈ��R�[�h</param>
        /// <param name="employeeName">���O�C���]�ƈ�����</param>
        /// <param name="readCnt">�Ǎ�����</param>
        /// <param name="addCnt">�ǉ�����</param>
        /// <param name="updCnt">��������</param>
        /// <param name="errCnt">�G���[����</param>
        /// <param name="errStockCheckWorks">�G���[�݌Ƀ}�X�^�`�F�b�N���X�g</param>
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : �݌Ƀ}�X�^�i�C���|�[�g�j�̃C���|�[�g����</br>
        /// <br>Programmer : zhangy3</br>
        /// <br>Date       : 2012/06/12</br>
        /// <br>Update Note: 2012/07/03 zhangy3 </br>
        /// <br>           : 10801804-00�A��z�Č��ARedmine#30387 ���i�}�X�^�C���{�[�g�`�F�b�N�̒ǉ��̑Ή�</br>
        /// <br>Update Note: 2012/07/20 zhangy3 </br>
        /// <br>           : 10801804-00�A��z�Č��ARedmine#30387 �݌Ƀ}�X�^�C���{�[�g�d�l�ύX�̑Ή�</br>
        /// </remarks>
        //public int Import(int processKbn, ref object importStockWorkList, ref object objStockCheckList,string enterpriseCode, string loginSectionCode, string loginSectionGuideNm, string employeeCode, string employeeName, out int readCnt, out int addCnt, out int updCnt, out int errCnt,out DataTable errTable,out string errMsg)//DEL ZHANGY3 2012/07/03 FOR REDMINE#30387
        //public int Import(int processKbn, ref object importStockWorkList, ref object objStockCheckList, string enterpriseCode, string loginSectionCode, string loginSectionGuideNm, string employeeCode, string employeeName, out int readCnt, out int addCnt, out int updCnt, out int errCnt, out object errStockCheckWorks, out string errMsg)//ADD ZHANGY3 2012/07/03 FOR REDMINE#30387//DEL ZHANGY3 2012/07/20 FOR REDMINE#30387
        public int Import(int processKbn, int dataCheckKbn, ref object importStockWorkList, ref object objStockCheckList, string enterpriseCode, string loginSectionCode, string loginSectionGuideNm, string employeeCode, string employeeName, out int readCnt, out int addCnt, out int updCnt, out int errCnt, out object errStockCheckWorks, out string errMsg)//ADD ZHANGY3 2012/07/20 FOR REDMINE#30387
        {
            //���O�C���]�ƈ��R�[�h
            this._employeeCode = employeeCode;
            //���O�C���]�ƈ�����
            this._employeeName = employeeName;
            //��ƃR�[�h
            this._enterpriseCode = enterpriseCode;
            //���O�C�����_�R�[�h
            this._loginSectionCode = loginSectionCode;
            //���O�C�����_����
            this._loginSectionGuideNm = loginSectionGuideNm;
            //return this.ImportProc(processKbn, ref importStockWorkList, ref objStockCheckList, out readCnt, out addCnt, out updCnt, out errCnt, out errTable, out errMsg);//DEL ZHANGY3 2012/07/03 FOR REDMINE#30387
            //return this.ImportProc(processKbn, ref importStockWorkList, ref objStockCheckList, out readCnt, out addCnt, out updCnt, out errCnt, out errStockCheckWorks, out errMsg);//ADD ZHANGY3 2012/07/03 FOR REDMINE#30387//DEL ZHANGY3 2012/07/20 FOR REDMINE#30387
            return this.ImportProc(processKbn, dataCheckKbn, ref importStockWorkList, ref objStockCheckList, out readCnt, out addCnt, out updCnt, out errCnt, out errStockCheckWorks, out errMsg);//ADD ZHANGY3 2012/07/20 FOR REDMINE#30387
        }

        /// <summary>
        /// �݌Ƀ}�X�^�i�C���|�[�g�j�̃C���|�[�g�����B
        /// </summary>
        /// <param name="processKbn">�����敪</param>
        /// <param name="dataCheckKbn">�`�F�b�N�敪</param>
        /// <param name="importStockWorkList">�݌Ƀ}�X�^���X�g</param>
        /// <param name="importStockWorkCheckList">�݌Ƀ}�X�^�`�F�b�N���X�g</param>
        /// <param name="readCnt">�Ǎ�����</param>
        /// <param name="addCnt">�ǉ�����</param>
        /// <param name="updCnt">��������</param>
        /// <param name="errCnt">�G���[����</param>
        /// <param name="errStockCheckWorks">�G���[�݌Ƀ}�X�^�`�F�b�N���X�g</param>
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : �݌Ƀ}�X�^�i�C���|�[�g�j�̃C���|�[�g����</br>
        /// <br>Programmer : zhangy3</br>
        /// <br>Date       : 2012/06/12</br>
        /// <br>Update Note: 2012/07/03 zhangy3 </br>
        /// <br>           : 10801804-00�A��z�Č��ARedmine#30387 ���i�}�X�^�C���{�[�g�`�F�b�N�̒ǉ��̑Ή�</br>
        /// <br>Update Note: 2012/07/20 zhangy3 </br>
        /// <br>           : 10801804-00�A��z�Č��ARedmine#30387 �݌Ƀ}�X�^�C���{�[�g�d�l�ύX�̑Ή�</br>
        /// </remarks>
        //private int ImportProc(int processKbn, ref object importStockWorkList, ref object importStockWorkCheckList, out int readCnt, out int addCnt, out int updCnt, out int errCnt, out DataTable errTable, out string errMsg)//DEL ZHANGY3 2012/07/03 FOR REDMINE#30387
        //private int ImportProc(int processKbn, ref object importStockWorkList, ref object importStockWorkCheckList, out int readCnt, out int addCnt, out int updCnt, out int errCnt, out object errStockCheckWorks, out string errMsg)//ADD ZHANGY3 2012/07/03 FOR REDMINE#30387//DEL ZHANGY3 2012/07/20 FOR REDMINE#30387
        private int ImportProc(int processKbn, int dataCheckKbn, ref object importStockWorkList, ref object importStockWorkCheckList, out int readCnt, out int addCnt, out int updCnt, out int errCnt, out object errStockCheckWorks, out string errMsg)//ADD ZHANGY3 2012/07/20 FOR REDMINE#30387
        {
            
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            readCnt = 0;
            addCnt = 0;
            updCnt = 0;
            errCnt = 0;
            //errTable = new DataTable();//DEL ZHANGY3 2012/07/03 FOR REDMINE#30387
            int index = 0;
            errMsg = string.Empty;
            StockDB stockDB = new StockDB();
            StockAdjustDB stockAdjustDB = new StockAdjustDB();
            errStockCheckWorks = null;//ADD ZHANGY3 2012/07/03 FOR REDMINE#30387
            try
            {
                //�e�[�u���̍쐬
                //CreateDataTable(ref errTable);//DEL ZHANGY3 2012/07/03 FOR REDMINE#30387
                // �݌Ƀ}�X�^�ǉ����X�g
                ArrayList addList = new ArrayList();
                // �݌Ƀ}�X�^�X�V���X�g
                ArrayList updList = new ArrayList();

                ArrayList errList = new ArrayList();

                // �݌Ƀ}�X�^
                ArrayList importWorkList = importStockWorkList as ArrayList;
                // �݌Ƀ}�X�^�`�F�b�N
                ArrayList importCheckWorkList = importStockWorkCheckList as ArrayList;
               
                //ADD ZHANGY3 2012/07/03 FOR REDMINE#30387 --------------->>>>>>
                // �G���[�݌Ƀ}�X�^�`�F�b�N���X�g
                ArrayList errStockCheckWork = new ArrayList();
                //ADD ZHANGY3 2012/07/03 FOR REDMINE#30387 ---------------<<<<<<
                // �݌ɏ��S�ăf�[�^�̌�������
                ArrayList stockWorkList = new ArrayList();

                object objectstockWork = stockWorkList as object;
                //�p�����[�^�̐ݒ�
                StockWork stockWork = new StockWork();
                if (importWorkList == null)
                {
                    //�C���|�[�g���[�N��NULL����ERROR��߂�
                    return status;
                }
                else
                {
                    //�R�[�h��ݒ�
                    stockWork.EnterpriseCode = ((StockWork)importWorkList[0]).EnterpriseCode;
                }
                //�p�����[�^
                object objectparastockWork = stockWork as object;
                
                // �݌ɏ��S�ăf�[�^�̑{��
                status = stockDB.Search(out objectstockWork, objectparastockWork, 0, ConstantManagement.LogicalMode.GetData01);

                stockWorkList = objectstockWork as ArrayList;

                // Dictionary�̍쐬
                Dictionary<StockSearchUImportWorkWrap, StockWork> dict = new Dictionary<StockSearchUImportWorkWrap, StockWork>();
                foreach (StockWork work in stockWorkList)
                {
                    work.WarehouseCode = work.WarehouseCode.Trim();
                    StockSearchUImportWorkWrap warp = new StockSearchUImportWorkWrap(work);
                    dict.Add(warp, work);
                }

                //�ǉ��̃t���O
                bool flgAdd = IsNeedAddCnt(1,processKbn);

                //�X�V�̃t���O
                bool flgUp = IsNeedAddCnt(2, processKbn);

                //ADD ZHANGY3 2012/07/20 FOR REDMINE#30387 --------------->>>>>>
                List<StockCheckWork> lst = new List<StockCheckWork>();
                StockCheckWork[] stockArray = (StockCheckWork[])importCheckWorkList.ToArray(typeof(StockCheckWork));
                lst.AddRange(stockArray);
                //ADD ZHANGY3 2012/07/20 FOR REDMINE#30387 ---------------<<<<<<
                foreach (StockWork importWork in importWorkList)
                {
                    bool flg = false;//ADD ZHANGY3 2012/07/03 FOR REDMINE#30387
                    //CheckClass checkCls;//DEL ZHANGY3 2012/07/03 FOR REDMINE#30387
                    StockSearchUImportWorkWrap importWarp = new StockSearchUImportWorkWrap(importWork);
                    StockCheckWork stockCheckWork = (StockCheckWork)importCheckWorkList[index];
                    index++;
                    if (!dict.ContainsKey(importWarp))
                    {
                        if (flgAdd)
                        {
                            //�C���|�[�g�̃`�F�b�N
                            //ImportCheck(stockCheckWork, out checkCls);//DEL ZHANGY3 2012/07/03 FOR REDMINE#30387
                            //flg = ImportCheck(ref stockCheckWork);//ADD ZHANGY3 2012/07/03 FOR REDMINE#30387//DEL ZHANGY3 2012/07/20 FOR REDMINE#30387
                            flg = ImportCheck(stockCheckWork, dataCheckKbn, lst);//ADD ZHANGY3 2012/07/20 FOR REDMINE#30387
                            //�G���[���X�g�ɑ��݂��Ȃ���΁A�ǉ����X�g�ւł��܂���B
                            //if (checkCls != null)//DEL ZHANGY3 2012/07/03 FOR REDMINE#30387
                            if (flg)//ADD ZHANGY3 2012/07/03 FOR REDMINE#30387
                            {
                                //InsertDataIntoTable(checkCls, ref errTable);//DEL ZHANGY3 2012/07/03 FOR REDMINE#30387
                                errStockCheckWork.Add(stockCheckWork);//ADD ZHANGY3 2012/07/03 FOR REDMINE#30387
                                errCnt++;
                                continue;
                            }
                        }
                        // ���R�[�h�����݂��Ȃ���΁A�ǉ����X�g�֒ǉ�����B
                        addList.Add(ConvertToImportWork(importWork, null, false));
                    }
                    else
                    {
                        if (flgUp)
                        {
                            //�C���|�[�g�̃`�F�b�N
                            //ImportCheck(stockCheckWork, out checkCls);//DEL ZHANGY3 2012/07/03 FOR REDMINE#30387
                            //flg = ImportCheck(ref stockCheckWork);//ADD ZHANGY3 2012/07/03 FOR REDMINE#30387//DEL ZHANGY3 2012/07/20 FOR REDMINE#30387
                            flg = ImportCheck(stockCheckWork, dataCheckKbn, lst);//ADD ZHANGY3 2012/07/20 FOR REDMINE#30387
                            //if (checkCls != null)//DEL ZHANGY3 2012/07/03 FOR REDMINE#30387
                            if (flg)//ADD ZHANGY3 2012/07/03 FOR REDMINE#30387
                            {
                                //InsertDataIntoTable(checkCls, ref errTable);//DEL ZHANGY3 2012/07/03 FOR REDMINE#30387
                                errStockCheckWork.Add(stockCheckWork);//ADD ZHANGY3 2012/07/03 FOR REDMINE#30387
                                errCnt++;
                                continue;
                            }
                        }
                        // ���R�[�h�����݂���΁A�X�V���X�g�֒ǉ�����B
                        updList.Add(ConvertToImportWork(importWork, dict[importWarp], true));
                    }
                    
                }

                // �Ǎ�����
                readCnt = importWorkList.Count;

                CustomSerializeArrayList saveDataList = new CustomSerializeArrayList();

                // �����敪���u�ǉ��v�̏ꍇ
                if (processKbn == 1)
                {
                    if (addList.Count > 0)
                    {
                        saveDataList = this.CreateSaveData(addList, new ArrayList(), dict);

                        object objSaveData = (object)saveDataList;
                        
                        status = stockAdjustDB.WriteBatch(ref objSaveData, out errMsg);

                    }
                    else
                    {
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }

                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        addCnt = addList.Count;
                    }
                }
                else if (processKbn == 2)
                {
                    // �����敪���u�X�V�v�̏ꍇ
                    if (updList.Count > 0)
                    {
                        saveDataList = this.CreateSaveData(new ArrayList(), updList, dict);

                        object objSaveData = (object)saveDataList;

                        status = stockAdjustDB.WriteBatch(ref objSaveData, out errMsg);

                    }
                    else
                    {
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }

                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        updCnt = updList.Count;
                    }
                }
                else
                {
                    if (addList.Count > 0 || updList.Count > 0)
                    {
                        // �����敪���u�ǉ��X�V�v�̏ꍇ
                        saveDataList = this.CreateSaveData(addList, updList, dict);

                        object objSaveData = (object)saveDataList;

                        status = stockAdjustDB.WriteBatch(ref objSaveData, out errMsg);

                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            addCnt = addList.Count;
                            updCnt = updList.Count;
                        }
                    }
                    else
                    {
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }
                }
                errStockCheckWorks = (object)errStockCheckWork;//ADD ZHANGY3 2012/07/03 FOR REDMINE#30387
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return status;
        }
   
        #endregion

        #region �݌Ɍ������I�u�W�F�N�g
        /// <summary>
        /// �݌Ɍ������I�u�W�F�N�g
        /// </summary>
        /// <remarks>
        /// <br>Note       : �݌Ɍ������I�u�W�F�N�g�ł��B</br>
        /// <br>Programmer : zhangy3</br>
        /// <br>Date       : 2012/06/12</br>
        /// </remarks>
        class StockSearchUImportWorkWrap
        {
            #region Public Field
            public StockWork stockWork;
            #endregion

            #region �N���X�R���X�g���N�^

            /// <summary>
            /// �݌Ɍ������I�u�W�F�N�g
            /// </summary>
            /// <param name="stockWork">�݌Ƀ��[�N</param>
            /// <remarks>
            /// <br>Note       : �݌Ɍ������I�u�W�F�N�g</br>
            /// <br>Programmer : zhangy3</br>
            /// <br>Date       : 2012/06/12</br>
            /// </remarks>
            public StockSearchUImportWorkWrap(StockWork stockWork)
            {
                this.stockWork = stockWork;
            }

            #endregion

            #region �����������I�u�W�F�N�g�̃C�R�[���̔�r
            /// <summary>
            /// �݌Ɍ������I�u�W�F�N�g�̃C�R�[���̔�r
            /// </summary>
            /// <param name="obj">�݌Ɍ������I�u�W�F�N�g</param>
            /// <returns>��r����</returns>
            /// <remarks>
            /// <br>Note       : �݌Ɍ������I�u�W�F�N�g�̃C�R�[���̔�r</br>
            /// <br>Programmer : zhangy3</br>
            /// <br>Date       : 2012/06/12</br>
            /// </remarks>
            public override bool Equals(object obj)
            {
                StockSearchUImportWorkWrap target = obj as StockSearchUImportWorkWrap;
                if (target == null) return false;
                // �q�ɃR�[�h�A���i�ԍ��A���i���[�J�[�R�[�h
                // �������ꍇ�A�݌ɏ��I�u�W�F�N�g�̓C�R�[���ɂ���B
                return target.stockWork.EnterpriseCode == stockWork.EnterpriseCode
                         && target.stockWork.WarehouseCode == stockWork.WarehouseCode
                         && target.stockWork.GoodsNo == stockWork.GoodsNo
                         && target.stockWork.GoodsMakerCd == stockWork.GoodsMakerCd;
            }
             #endregion

            #region �݌Ɍ������I�u�W�F�N�g�̃n�V�R�[�h
            /// <summary>
            /// �݌Ɍ������I�u�W�F�N�g�̃n�V�R�[�h
            /// </summary>
            /// <returns>�n�V�R�[�h</returns>
            /// <remarks>
            /// <br>Note       : �݌Ɍ������I�u�W�F�N�g�̃n�V�R�[�h</br>
            /// <br>Programmer : zhangy3</br>
            /// <br>Date       : 2012/06/12</br>
            /// </remarks>
            public override int GetHashCode()
            {
                int val= stockWork.EnterpriseCode.GetHashCode()
                         + stockWork.WarehouseCode.GetHashCode()
                         + stockWork.GoodsNo.GetHashCode()
                         + stockWork.GoodsMakerCd.GetHashCode();
                return val;
            }
            #endregion
        }
        #endregion

        #region �� �ۑ��p�f�[�^�̍쐬

        /// <summary>
        /// �ۑ��p�f�[�^��������
        /// </summary>
        /// <param name="addList">�ǉ����X�g</param>
        /// <param name="updList">�X�V���X�g</param>
        /// <param name="dict">Dictionary</param>
        /// <returns>�ۑ��p�f�[�^(CustomSerializeArrayList)</returns>
        /// <remarks>
        /// <br>Note       : �ۑ��p�f�[�^���������B</br>
        /// <br>Programmer : zhangy3</br>
        /// <br>Date       : 2012/06/12</br>
        /// </remarks>
        private CustomSerializeArrayList CreateSaveData(ArrayList addList, ArrayList updList, Dictionary<StockSearchUImportWorkWrap, StockWork> dict)
        {
            CustomSerializeArrayList saveDataList = new CustomSerializeArrayList();
            ArrayList stockAdjustWorkList = new ArrayList();
            ArrayList stockAdjustDtlWorkList = new ArrayList();
            ArrayList dataList = new ArrayList();
            CustomSerializeArrayList tempList = new CustomSerializeArrayList();

            //�X�V�̏���
            foreach (StockWork updWork in updList)
            {
                StockSearchUImportWorkWrap updWarp = new StockSearchUImportWorkWrap(updWork);

                if (Math.Abs(dict[updWarp].SupplierStock - updWork.SupplierStock) != 0)
                {
                    //�݌ɒ���
                    CreateStockAdjust(ref stockAdjustWorkList);
                    //�݌ɒ�������
                    CreateStockAdjustDtl(ref stockAdjustDtlWorkList, updWork);
                }

                updWork.SupplierStock = updWork.SupplierStock - dict[updWarp].SupplierStock;
                updWork.AcpOdrCount = updWork.AcpOdrCount - dict[updWarp].AcpOdrCount;
                updWork.SalesOrderCount = updWork.SalesOrderCount - dict[updWarp].SalesOrderCount;
                updWork.MovingSupliStock = updWork.MovingSupliStock - dict[updWarp].MovingSupliStock;
                updWork.ShipmentCnt = updWork.ShipmentCnt - dict[updWarp].ShipmentCnt;
                updWork.ArrivalCnt = updWork.ArrivalCnt - dict[updWarp].ArrivalCnt;

            }

            //�V�K�̏���
            foreach (StockWork addwork in addList)
            {
                if (!string.IsNullOrEmpty(addwork.SupplierStock.ToString()) && addwork.SupplierStock > 0)
                {
                    //�݌ɒ���
                    CreateStockAdjust(ref stockAdjustWorkList);
                    //�݌ɒ�������
                    CreateStockAdjustDtl(ref stockAdjustDtlWorkList, addwork);
                }
            }

            if (stockAdjustWorkList.Count > 0)
            {
                // �݌ɒ����f�[�^�ǉ�
                tempList.Add(stockAdjustWorkList);
            }

            if (stockAdjustDtlWorkList.Count > 0)
            {
                // �݌ɒ������׃f�[�^�ǉ�
                tempList.Add(stockAdjustDtlWorkList);
            }

            if (addList.Count > 0)
            {
                dataList.AddRange(addList.GetRange(0, addList.Count));
            }
            if (updList.Count > 0)
            {
                dataList.AddRange(updList.GetRange(0, updList.Count));
            }

            if (dataList.Count > 0)
            {
                // �݌Ƀ}�X�^�ǉ�
                tempList.Add(dataList);
            }

            saveDataList.Add(tempList);

            return saveDataList;
        }

        /// <summary>
        /// �݌ɒ����f�[�^���[�N�N���X��������
        /// </summary>
        /// <param name="stockAdjustWorkList">�݌ɒ����f�[�^���[�N�N���X</param>
        /// <remarks>
        /// <br>Note       : �݌ɒ����f�[�^���[�N�N���X�𐶐����܂��B</br>
        /// <br>Programmer : zhangy3</br>
        /// <br>Date       : 2012/06/12</br>
        /// </remarks>
        private void CreateStockAdjust(ref ArrayList stockAdjustWorkList)
        {
            StockAdjustWork workData = new StockAdjustWork();

            // ��ƃR�[�h
            workData.EnterpriseCode = this._enterpriseCode;
            // ���_�R�[�h
            workData.SectionCode = this._loginSectionCode.Trim();
            // ���_����
            workData.SectionGuideNm = this._loginSectionGuideNm;
            // �󕥌��`�[�敪(42�F�}�X�^�����e)
            workData.AcPaySlipCd = 42;
            // �󕥌�����敪(30�F�݌ɐ�����)
            workData.AcPayTransCd = 30;
            // �������t
            workData.AdjustDate = DateTime.Today;
            // ���͓��t
            workData.InputDay = DateTime.Today;
            // �d�����_�R�[�h
            workData.StockSectionCd = this._loginSectionCode;
            // �d�����_����
            workData.StockSectionGuideNm = this._loginSectionGuideNm;
            // �d�����͎҃R�[�h
            workData.StockInputCode = this._employeeCode;
            // �d���S���҃R�[�h
            workData.StockAgentCode = this._employeeCode;
            if (this._employeeName.Length > 16)
            {
                // �d�����͎Җ���
                workData.StockInputName = this._employeeName.Substring(0, 16);
                // �d���S���Җ���
                workData.StockAgentName = this._employeeName.Substring(0, 16);
            }
            else
            {
                // �d�����͎Җ���
                workData.StockInputName = this._employeeName;
                // �d���S���Җ���
                workData.StockAgentName = this._employeeName;
            }

            stockAdjustWorkList.Add(workData);
        }

        /// <summary>
        /// �݌ɒ������׃f�[�^���[�N�N���X��������
        /// </summary>
        /// <param name="stockAdjustDtlWorkList">�݌ɒ������׃f�[�^���X�g</param>
        /// <param name="work">�݌Ƀ��[�N</param>
        /// <remarks>
        /// <br>Note       : �݌ɒ������׃f�[�^���[�N�N���X�𐶐����܂��B</br>
        /// <br>Programmer : zhangy3</br>
        /// <br>Date       : 2012/06/12</br>
        /// </remarks>
        private void CreateStockAdjustDtl(ref ArrayList stockAdjustDtlWorkList, StockWork work)
        {
            StockAdjustDtlWork workData = new StockAdjustDtlWork();
            // ��ƃR�[�h
            workData.EnterpriseCode = this._enterpriseCode;
            // ���_�R�[�h
            workData.SectionCode = this._loginSectionCode.Trim();
            // ���_����
            workData.SectionGuideNm = this._loginSectionGuideNm;
            // �݌ɒ����`�[�ԍ�
            workData.StockAdjustSlipNo = 0;
            // �󕥌��`�[�敪(42�F�}�X�^�����e)
            workData.AcPaySlipCd = 42;
            // �󕥌�����敪(30�F�݌ɐ�����)
            workData.AcPayTransCd = 30;
            // �������t
            workData.AdjustDate = DateTime.Today;
            // ���͓��t
            workData.InputDay = DateTime.Today;
            // ���i�ԍ�
            workData.GoodsNo = work.GoodsNo;
            // �q�ɃR�[�h
            workData.WarehouseCode = work.WarehouseCode;

            stockAdjustDtlWorkList.Add(workData);
        }

        #endregion

        #region �� DB�o�^�p�̃I�u�W�F�N�g�̍쐬
        /// <summary>
        /// DB�o�^�p�̃I�u�W�F�N�g�̍쐬
        /// </summary>
        /// <param name="csvWork">�C���|�[�g�p�̃I�u�W�F�N�g</param>
        /// <param name="searchWork">���������I�u�W�F�N�g</param>
        /// <param name="isUpdFlg">�X�V�t���O�itrue:�X�V�Afalse:�ǉ��j</param>
        /// <returns>�݌Ƀ��[�N</returns>
        /// <remarks>
        /// <br>Note       : DB�o�^�p�̃I�u�W�F�N�g�̍쐬</br>
        /// <br>Programmer : zhangy3</br>
        /// <br>Date       : 2012/06/12</br>
        /// </remarks>
        private StockWork ConvertToImportWork(StockWork csvWork, StockWork searchWork, bool isUpdFlg)
        {
            StockWork importWork = new StockWork();
            if (isUpdFlg)
            {
                importWork.CreateDateTime = searchWork.CreateDateTime;              // �쐬����
                importWork.UpdateDateTime = System.DateTime.Now;              // �X�V����
                importWork.FileHeaderGuid = searchWork.FileHeaderGuid;              // GUID
                importWork.LogicalDeleteCode = 0;                                   // �L��
                importWork.UpdEmployeeCode = this._employeeCode;
                importWork.UpdAssemblyId1 = searchWork.UpdAssemblyId1;
                importWork.UpdAssemblyId2 = searchWork.UpdAssemblyId2;

                //M/O������
                importWork.MonthOrderCount = searchWork.MonthOrderCount;
                //�݌ɕۗL���z
                importWork.StockTotalPrice = searchWork.StockTotalPrice;
                //�ŏI�d���N����
                importWork.LastStockDate = searchWork.LastStockDate;
                //�ŏI�����
                importWork.LastSalesDate = searchWork.LastSalesDate;
                //�ŏI�I���X�V��
                importWork.LastInventoryUpdate = searchWork.LastInventoryUpdate;
                //�������
                importWork.NmlSalOdrCount = searchWork.NmlSalOdrCount;
                //�n�C�t�������i�ԍ�
                importWork.GoodsNoNoneHyphen = searchWork.GoodsNoNoneHyphen;
                //�݌ɓo�^��
                importWork.StockCreateDate = searchWork.StockCreateDate;

                //�X�V�w�b�_����ݒ�
                object obj = (object)this;
                IFileHeader flhd = (IFileHeader)searchWork;
                FileHeader fileHeader = new FileHeader(obj);
                fileHeader.SetUpdateHeader(ref flhd, obj);
            }
            else
            {
                //M/O������
                importWork.MonthOrderCount = 0;
                //�݌ɕۗL���z
                importWork.StockTotalPrice = 0;
                //�������
                importWork.NmlSalOdrCount = 0;
                //�n�C�t�������i�ԍ�
                importWork.GoodsNoNoneHyphen = string.Empty;
                //�݌ɓo�^��
                importWork.StockCreateDate = System.DateTime.Now;
            }

            importWork.EnterpriseCode = csvWork.EnterpriseCode;                  // ��ƃR�[�h

            //���_�R�[�h
            importWork.SectionCode = csvWork.SectionCode;
            //�q�ɃR�[�h
            importWork.WarehouseCode = csvWork.WarehouseCode;
            //���i���[�J�[�R�[�h
            importWork.GoodsMakerCd = csvWork.GoodsMakerCd;
            //���i�ԍ�
            importWork.GoodsNo = csvWork.GoodsNo;
            //�d���P���i�Ŕ�,�����j
            importWork.StockUnitPriceFl = csvWork.StockUnitPriceFl;
            //�d���݌ɐ�
            importWork.SupplierStock = csvWork.SupplierStock;
            //�󒍐�
            importWork.AcpOdrCount = csvWork.AcpOdrCount;
            //������
            importWork.SalesOrderCount = csvWork.SalesOrderCount;
            //�݌ɋ敪
            importWork.StockDiv = csvWork.StockDiv;
            //�ړ����d���݌ɐ�
            importWork.MovingSupliStock = csvWork.MovingSupliStock;
            //�o�׉\��
            importWork.ShipmentPosCnt = csvWork.ShipmentPosCnt;
            //�Œ�݌ɐ�
            importWork.MinimumStockCnt = csvWork.MinimumStockCnt;
            //�ō��݌ɐ�
            importWork.MaximumStockCnt = csvWork.MaximumStockCnt;
            //�����P��
            importWork.SalesOrderUnit = csvWork.SalesOrderUnit;
            //�݌ɔ�����R�[�h
            importWork.StockSupplierCode = csvWork.StockSupplierCode;
            //�q�ɒI��
            importWork.WarehouseShelfNo = csvWork.WarehouseShelfNo;
            //�d���I�ԂP
            importWork.DuplicationShelfNo1 = csvWork.DuplicationShelfNo1;
            //�d���I�ԂQ
            importWork.DuplicationShelfNo2 = csvWork.DuplicationShelfNo2;
            //���i�Ǘ��敪�P
            importWork.PartsManagementDivide1 = csvWork.PartsManagementDivide1;
            //���i�Ǘ��敪�Q
            importWork.PartsManagementDivide2 = csvWork.PartsManagementDivide2;
            //�݌ɔ��l�P
            importWork.StockNote1 = csvWork.StockNote1;
            //�݌ɔ��l�Q
            importWork.StockNote2 = csvWork.StockNote2;
            //�o�א��i���v��j
            importWork.ShipmentCnt = csvWork.ShipmentCnt;
            //���א��i���v��j
            importWork.ArrivalCnt = csvWork.ArrivalCnt;
            //�X�V�N����
            importWork.UpdateDate = System.DateTime.Now;

            return importWork;
        }

        #endregion

        # region ���ڃ`�F�b�N
        /* DEL ZHANGY3 2012/07/03 FOR REDMINE#30387 --------------->>>>>>
        /// <summary>
        /// �e�[�u���ɒl��ǉ�
        /// </summary>
        /// <param name="ckCls">�G���[���X�g</param>
        /// <param name="errTable">�G���[�e�[�u��</param>
        /// <remarks>
        /// <br>Note       : �e�[�u���ɒl��ǉ�</br>
        /// <br>Programmer : zhangy3</br>
        /// <br>Date       : 2012/06/12</br>
        /// </remarks>
        private void InsertDataIntoTable(CheckClass ckCls, ref DataTable errTable)
        {
            DataRow dr = errTable.NewRow();
            //----- �݌Ƀ}�X�^�̓��e���e�[�u���ɒǉ����� -----
            //���_�R�[�h
            dr["SectionCode"] = ckCls.StockCheckWork.SectionCode;

            //�q�ɃR�[�h
            dr["WarehouseCode"] = ckCls.StockCheckWork.WarehouseCode;

            //���i���[�J�[�R�[�h
            dr["GoodsMakerCd"] = ckCls.StockCheckWork.GoodsMakerCd;

            //���i�ԍ�
            dr["GoodsNo"] = ckCls.StockCheckWork.GoodsNo;

            //�d���P���i�Ŕ�,�����j
            dr["StockUnitPriceFl"] = ckCls.StockCheckWork.StockUnitPriceFl;

            //�d���݌ɐ�
            dr["SupplierStock"] = ckCls.StockCheckWork.SupplierStock;

            //���א��i���v��j
            dr["ArrivalCnt"] = ckCls.StockCheckWork.ArrivalCnt;

            //�o�א��i���v��j
            dr["ShipmentCnt"] = ckCls.StockCheckWork.ShipmentCnt;

            //�󒍐�
            dr["AcpOdrCount"] = ckCls.StockCheckWork.AcpOdrCount;

            //�ړ����d���݌ɐ�
            dr["MovingSupliStock"] = ckCls.StockCheckWork.MovingSupliStock;

            //�o�׉\��
            dr["ShipmentPosCnt"] = ckCls.StockCheckWork.ShipmentPosCnt;

            //������
            dr["SalesOrderCount"] = ckCls.StockCheckWork.SalesOrderCount;

            //�݌ɋ敪
            dr["StockDiv"] = ckCls.StockCheckWork.StockDiv;

            //�Œ�݌ɐ�
            dr["MinimumStockCnt"] = ckCls.StockCheckWork.MinimumStockCnt;

            //�ō��݌ɐ�
            dr["MaximumStockCnt"] = ckCls.StockCheckWork.MaximumStockCnt;

            //�����P��
            dr["SalesOrderUnit"] = ckCls.StockCheckWork.SalesOrderUnit;

            //�݌ɔ�����R�[�h
            dr["StockSupplierCode"] = ckCls.StockCheckWork.StockSupplierCode;

            //�q�ɒI��
            dr["WarehouseShelfNo"] = ckCls.StockCheckWork.WarehouseShelfNo;

            //�d���I�ԂP
            dr["DuplicationShelfNo1"] = ckCls.StockCheckWork.DuplicationShelfNo1;

            //�d���I�ԂQ
            dr["DuplicationShelfNo2"] = ckCls.StockCheckWork.DuplicationShelfNo2;

            //���i�Ǘ��敪�P
            dr["PartsManagementDivide1"] = ckCls.StockCheckWork.PartsManagementDivide1;

            //���i�Ǘ��敪�Q
            dr["PartsManagementDivide2"] = ckCls.StockCheckWork.PartsManagementDivide2;

            //�݌ɔ��l�P
            dr["StockNote1"] = ckCls.StockCheckWork.StockNote1;

            //�݌ɔ��l�Q
            dr["StockNote2"] = ckCls.StockCheckWork.StockNote2;

            //----- �G���[���b�Z�[�W��ǉ����� -----
            //���b�Z�[�W
            dr["ErrMsg"] = ckCls.Msg;

            errTable.Rows.Add(dr);
        }

        /// <summary>
        /// DataTable��Columns��ǉ�����
        /// </summary>
        /// <param name="dataTable">����DataTable</param>
        /// <remarks>
        /// <br>Note       : DataTable��Columns��ǉ�����B</br>
        /// <br>Programmer : zhangy3</br>
        /// <br>Date       : 2012/06/12</br>
        /// </remarks>
        private void CreateDataTable(ref DataTable dataTable)
        {
            //���_�R�[�h
            dataTable.Columns.Add("SectionCode", typeof(string)); 
  
            //�q�ɃR�[�h
            dataTable.Columns.Add("WarehouseCode", typeof(string)); 
            
            //���i���[�J�[�R�[�h
            dataTable.Columns.Add("GoodsMakerCd", typeof(string)); 

            //���i�ԍ�
            dataTable.Columns.Add("GoodsNo", typeof(string)); 

            //�d���P���i�Ŕ�,�����j
            dataTable.Columns.Add("StockUnitPriceFl", typeof(string)); 
            
            //�d���݌ɐ�
            dataTable.Columns.Add("SupplierStock", typeof(string)); 
            
            //���א��i���v��j
            dataTable.Columns.Add("ArrivalCnt", typeof(string)); 
            
            //�o�א��i���v��j
            dataTable.Columns.Add("ShipmentCnt", typeof(string)); 
            
            //�󒍐�
            dataTable.Columns.Add("AcpOdrCount", typeof(string)); 
            
            //�ړ����d���݌ɐ�
            dataTable.Columns.Add("MovingSupliStock", typeof(string)); 
            
            //�o�׉\��
            dataTable.Columns.Add("ShipmentPosCnt", typeof(string));
            
            //������
            dataTable.Columns.Add("SalesOrderCount", typeof(string));
            
            //�݌ɋ敪
            dataTable.Columns.Add("StockDiv", typeof(string));
            
            //�Œ�݌ɐ�
            dataTable.Columns.Add("MinimumStockCnt", typeof(string));
            
            //�ō��݌ɐ�
            dataTable.Columns.Add("MaximumStockCnt", typeof(string));
            
            //�����P��
            dataTable.Columns.Add("SalesOrderUnit", typeof(string));
            
            //�݌ɔ�����R�[�h
            dataTable.Columns.Add("StockSupplierCode", typeof(string));
            
            //�q�ɒI��
            dataTable.Columns.Add("WarehouseShelfNo", typeof(string));
            
            //�d���I�ԂP
            dataTable.Columns.Add("DuplicationShelfNo1", typeof(string));
            
            //�d���I�ԂQ
            dataTable.Columns.Add("DuplicationShelfNo2", typeof(string));
            
            //���i�Ǘ��敪�P
            dataTable.Columns.Add("PartsManagementDivide1", typeof(string));
            
            //���i�Ǘ��敪�Q
            dataTable.Columns.Add("PartsManagementDivide2", typeof(string));
            
            //�݌ɔ��l�P
            dataTable.Columns.Add("StockNote1", typeof(string));
            
            //�݌ɔ��l�Q
            dataTable.Columns.Add("StockNote2", typeof(string));

            //���b�Z�[�W
            dataTable.Columns.Add("ErrMsg", typeof(string));
            
        }
        * DEL ZHANGY3 2012/07/03 FOR REDMINE#30387 ---------------<<<<<< */

        /// <summary>
        /// �G���[���X�g�ɒǉ��̕K�v�𔻒f����
        /// </summary>
        /// <param name="val">�l(1:�ǉ�2:�X�V)</param>
        /// <param name="processKbn">�����敪</param>
        /// <returns>���f����</returns>
        /// <remarks>
        /// <br>Note       : Add�̕K�v�𔻒f����B</br>
        /// <br>Programmer : zhangy3</br>
        /// <br>Date       : 2012/06/12</br>
        /// </remarks>
        private bool IsNeedAddCnt(int val, int processKbn)
        {
            //�����敪�͒ǉ��̏ꍇ
            if (processKbn == 1)
            {
                //�ǉ����ł��܂�
                if (val == 1)
                    return true;
                //�X�V���ł��܂���
                else
                    return false;
            }
            //�����敪�͍X�V�̏ꍇ
            else if (processKbn == 2)
            {
                //�ǉ����ł��܂���
                if (val == 1)
                    return false;
                //�X�V���ł��܂�
                else
                    return true;
            }
            //�����敪�͍X�V�ǉ��̏ꍇ
            else
            {
                //�X�V��ǉ����ł��܂�
                return true;
            }
        }

        /* DEL ZHANGY3 2012/07/03 FOR REDMINE#30387 --------------->>>>>>
        /// <summary>
        /// �`�F�b�N�N���X�I�u�W�F�N�g
        /// </summary>
        /// <remarks>
        /// <br>Note       : �`�F�b�N�N���X�I�u�W�F�N�g�ł��B</br>
        /// <br>Programmer : zhangy3</br>
        /// <br>Date       : 2012/06/12</br>
        /// </remarks>
        private class CheckClass
        {
            StockCheckWork _stockCheckWork;
            string _msg;

            #region �N���X�R���X�g���N�^

            /// <summary>
            /// �݌Ƀ}�X�^
            /// </summary>
            public StockCheckWork StockCheckWork
            {
                get
                {
                    return _stockCheckWork;
                }
                set
                {
                    _stockCheckWork = value;
                }
            }
            
           /// <summary>
           /// ���b�Z�[�W
           /// </summary>
            public string Msg
            {
                get
                {
                    return _msg;
                }
                set
                {
                    _msg = value;
                }
            }

            # endregion
        }
        * DEL ZHANGY3 2012/07/03 FOR REDMINE#30387 ---------------<<<<<< */

        /// <summary>
        /// �C���|�[�g�̃`�F�b�N
        /// </summary>
        /// <param name="stockCheckCls">�C���|�[�g�p�̃I�u�W�F�N�g</param>
        /// <param name="dataCheck">�`�F�b�N�敪</param>
        /// <param name="lst">�݌Ƀ}�X�^�`�F�b�N���X�g</param>
        /// <returns>bool</returns>
        /// <remarks>
        /// <br>Note       : �`�F�b�N�I�u�W�F�N�g�ł��B</br>
        /// <br>Programmer : zhangy3</br>
        /// <br>Date       : 2012/06/12</br>
        /// <br>Update Note: 2012/07/03 zhangy3 </br>
        /// <br>           : 10801804-00�A��z�Č��ARedmine#30387 ���i�}�X�^�C���{�[�g�`�F�b�N�̒ǉ��̑Ή�</br>
        /// <br>Update Note: 2012/07/20 zhangy3 </br>
        /// <br>           : 10801804-00�A��z�Č��ARedmine#30387 �݌Ƀ}�X�^�C���{�[�g�d�l�ύX�̑Ή�</br>
        /// </remarks>
        //private void ImportCheck(StockCheckWork stockCheckCls, out CheckClass checkCls)//DEL ZHANGY3 2012/07/03 FOR REDMINE#30387
        //private bool ImportCheck(ref StockCheckWork stockCheckCls)//ADD ZHANGY3 2012/07/03 FOR REDMINE#30387//DEL ZHANGY3 2012/07/20 FOR REDMINE#30387
        private bool ImportCheck(StockCheckWork stockCheckCls, int dataCheck, List<StockCheckWork> lst)//ADD ZHANGY3 2012/07/20 FOR REDMINE#30387
        {
            //�`�F�b�N�N���X�̍쐬
            //checkCls = null;//DEL ZHANGY3 2012/07/03 FOR REDMINE#30387
            string msg;
            //ADD ZHANGY3 2012/07/20 FOR REDMINE#30387 --------------->>>>>>
            // �`�F�b�N�敪
            if (1 == dataCheck)
            {
                if (!ImportCheckProc(stockCheckCls, out msg))
                {
                    stockCheckCls.ERRMESSAGE = msg;
                    return true;
                }
            }
            bool repeatDataFlg = false;
            repeatDataFlg = lst.FindAll(delegate(StockCheckWork tmp)
             {
                 if (stockCheckCls.GoodsMakerCd.Equals(tmp.GoodsMakerCd) && stockCheckCls.GoodsNo.Equals(tmp.GoodsNo)
                     && stockCheckCls.WarehouseCode.Equals(tmp.WarehouseCode))
                     return true;
                 else
                     return false;
             }).Count > 1;
            if (repeatDataFlg)
            {
                stockCheckCls.ERRMESSAGE = ERRMSG_DUPLICATE;
                return true;
            }
            //ADD ZHANGY3 2012/07/20 FOR REDMINE#30387 ---------------<<<<<<
            /* DEL ZHANGY3 2012/07/20 FOR REDMINE#30387 --------------->>>>>>
            //�C���|�[�g�̃`�F�b�N����
            if (!ImportCheckProc(stockCheckCls, out msg))
            {
             * DEL ZHANGY3 2012/07/20 FOR REDMINE#30387 ---------------<<<<<<*/
            /* DEL ZHANGY3 2012/07/03 FOR REDMINE#30387 --------------->>>>>>
                checkCls = new CheckClass();
                //�݌Ƀ}�X�^
                checkCls.StockCheckWork = stockCheckCls;
                //���b�Z�[�W
                checkCls.Msg = msg;
                 * DEL ZHANGY3 2012/07/03 FOR REDMINE#30387 ---------------<<<<<<*/
            /* DEL ZHANGY3 2012/07/20 FOR REDMINE#30387 --------------->>>>>>
                //ADD ZHANGY3 2012/07/03 FOR REDMINE#30387--------------->>>>>>
                stockCheckCls.ERRMESSAGE = msg;
                return true;
                //ADD ZHANGY3 2012/07/03 FOR REDMINE#30387---------------<<<<<<
             * DEL ZHANGY3 2012/07/20 FOR REDMINE#30387 ---------------<<<<<<*/
            //}//DEL ZHANGY3 2012/07/20 FOR REDMINE#30387
            return false;//ADD ZHANGY3 2012/07/03 FOR REDMINE#30387
        }

        /// <summary>
        /// �C���|�[�g�̃`�F�b�N����
        /// </summary>
        /// <param name="checkCls">�݌Ƀ}�X�g�`�F�b�N</param>
        /// <param name="msg">���b�Z�[�W</param>
        /// <returns>bool</returns>
        /// <remarks>
        /// <br>Note       : �C���|�[�g�̃`�F�b�N�����ł��B</br>
        /// <br>Programmer : zhangy3</br>
        /// <br>Date       : 2012/06/12</br>
        /// </remarks>
        private bool ImportCheckProc(StockCheckWork checkCls,out string msg)
        {
            msg = string.Empty;
            //�Ǘ����_
            if (!Check_IsNull("�Ǘ����_", checkCls.SectionCode, out msg) || !Check_Zero("�Ǘ����_", checkCls.SectionCode, out msg))
                return false;
            else
                if (!Check_IntDataAndLen("�Ǘ����_", checkCls.SectionCode, 2, out msg))
                    return false;

            //�q��
            if (!Check_IsNull("�q��", checkCls.WarehouseCode, out msg) || !Check_Zero("�q��", checkCls.WarehouseCode, out msg))
                return false;
            else
                if (!Check_IntDataAndLen("�q��", checkCls.WarehouseCode, 4, out msg))
                    return false;

            //���[�J�[
            if (!Check_IsNull("���[�J�[", checkCls.GoodsMakerCd, out msg) || !Check_Zero("���[�J�[", checkCls.GoodsMakerCd, out msg))
                return false;
            else
                if (!Check_IntDataAndLen("���[�J�[", checkCls.GoodsMakerCd, 4, out msg))
                    return false;

            //�i��
            if (!Check_IsNull("�i��", checkCls.GoodsNo, out msg) || !Check_Zero("�i��", checkCls.GoodsNo, out msg))
                return false;
            else
                if (!Check_StrUnFixedLen("�i��", checkCls.GoodsNo, 24, out msg))
                    return false;
                else
                    if (!Check_HalfEngNumFixedLength("�i��", checkCls.GoodsNo, 24, out msg))
                        return false;

            //�I���]���P��
            if (!string.IsNullOrEmpty(checkCls.StockUnitPriceFl) && !Check_FloatAndLen("�I���]���P��", checkCls.StockUnitPriceFl, 9, 2, out msg))
                return false;
                    
            //�d���݌ɐ�
            if (!string.IsNullOrEmpty(checkCls.SupplierStock) && !Check_FloatAndLen("�d���݌ɐ�", checkCls.SupplierStock, 8, 2, out msg))
                return false;

            //���א��i���v��j
            if (!string.IsNullOrEmpty(checkCls.ArrivalCnt) && !Check_FloatAndLen("���א��i���v��j", checkCls.ArrivalCnt, 8, 2, out msg))
                    return false;

            //�ݏo���i���v��j
            if (!string.IsNullOrEmpty(checkCls.ShipmentCnt) && !Check_FloatAndLen("�ݏo���i���v��j", checkCls.ShipmentCnt, 8, 2, out msg))
                return false;

            //�󒍐�
            if (!string.IsNullOrEmpty(checkCls.AcpOdrCount) && !Check_FloatAndLen("�󒍐�", checkCls.AcpOdrCount, 8, 2, out msg))
                return false;

            //�ړ����݌Ɏd����
            if (!string.IsNullOrEmpty(checkCls.MovingSupliStock) && !Check_FloatAndLen("�ړ����݌Ɏd����", checkCls.MovingSupliStock, 8, 2, out msg))
                return false;

            //���݌ɐ�
            if (!string.IsNullOrEmpty(checkCls.ShipmentPosCnt) && !Check_FloatAndLen("���݌ɐ�", checkCls.ShipmentPosCnt, 8, 2, out msg))
                return false;

            //�����c
            if (!string.IsNullOrEmpty(checkCls.SalesOrderCount) && !Check_FloatAndLen("�����c", checkCls.SalesOrderCount, 8, 2, out msg))
                return false;

            //�݌ɋ敪
            if (!string.IsNullOrEmpty(checkCls.StockDiv) && !Check_IntAndLen("�݌ɋ敪", checkCls.StockDiv, 1, out msg))
                return false;

            // ------ ADD START 2012/07/12 Redmine#30393 ������ for ��Q�ꗗ�̎w�ENO.93�̑Ή�-------->>>>
            //�݌ɋ敪
            if (!string.IsNullOrEmpty(checkCls.StockDiv) && Convert.ToInt32(checkCls.StockDiv.Trim()) != 0 && Convert.ToInt32(checkCls.StockDiv.Trim()) != 1)
            {
                msg = string.Format(FORMAT_ERRMSG_ERRORVAL, "�݌ɋ敪");
                return false;
            }
            // ------ ADD END 2012/07/12 Redmine#30393 ������ for ��Q�ꗗ�̎w�ENO.93�̑Ή�--------<<<<

            //�Œ�݌ɐ�
            if (!string.IsNullOrEmpty(checkCls.MinimumStockCnt) && !Check_FloatAndLen("�Œ�݌ɐ�", checkCls.MinimumStockCnt, 8, 2, out msg))
                    return false;

            //�ō��݌ɐ�
            if (!string.IsNullOrEmpty(checkCls.MaximumStockCnt) && !Check_FloatAndLen("�ō��݌ɐ�", checkCls.MaximumStockCnt, 8, 2, out msg))
                return false;

            //�������b�g
            if (!string.IsNullOrEmpty(checkCls.SalesOrderUnit) && !Check_IntAndLen("�������b�g", checkCls.SalesOrderUnit, 6, out msg))
                return false;

            //������
            if (!string.IsNullOrEmpty(checkCls.StockSupplierCode) && !Check_IntAndLen("������", checkCls.StockSupplierCode, 6, out msg))
                return false;

            //�I��
            if (!Check_StrUnFixedLen("�I��", checkCls.WarehouseShelfNo, 8, out msg))
                return false;

            //�d���I�ԂP
            if (!Check_StrUnFixedLen("�d���I�ԂP", checkCls.DuplicationShelfNo1, 8, out msg))
                return false;

            //�d���I�ԂQ
            if (!Check_StrUnFixedLen("�d���I�ԂQ", checkCls.DuplicationShelfNo2, 8, out msg))
                return false;

            //�Ǘ��敪�P
            if (!string.IsNullOrEmpty(checkCls.PartsManagementDivide1) && !Check_IntAndLen("�Ǘ��敪�P", checkCls.PartsManagementDivide1, 1, out msg))
                return false;

            //�Ǘ��敪�Q
            if (!string.IsNullOrEmpty(checkCls.PartsManagementDivide2) && !Check_IntAndLen("�Ǘ��敪�Q", checkCls.PartsManagementDivide2, 1, out msg))
                return false;

            //�݌ɔ��l�P
            if (!Check_StrUnFixedLen("�݌ɔ��l�P", checkCls.StockNote1, 40, out msg))
                return false;
            //�݌ɔ��l�Q
            if (!Check_StrUnFixedLen("�݌ɔ��l�Q", checkCls.StockNote2, 20, out msg))
                return false;

            return true;
        }

        # region ���b�Z�[�W
        //�����`�F�b�N
        //private const string FORMAT_ERRMSG_LEN = "{0}��{1}���ȓ��œ��͂��Ă��������B";// DEL  2012/07/11  ������ Redmine#30393 for ��Q�ꗗ�̎w�ENO.30�̑Ή�
        private const string FORMAT_ERRMSG_LEN = "{0}��{1}���ȓ��œ��͂��Ă��������B";// ADD  2012/07/11  ������ Redmine#30393 for ��Q�ꗗ�̎w�ENO.30�̑Ή�
        //�^�C�v�`�F�b�N
        //private const string FORMAT_ERRMSG_TYPE = "{0}��{1}�̂݉\�ł��B";//DEL ZHANGY3 2012/07/05 FOR REDMINE#30387
        private const string FORMAT_ERRMSG_TYPE = "{0}��{1}�̂݉\�ł��B";//ADD ZHANGY3 2012/07/05 FOR REDMINE#30387
        //�K�{���̓`�F�b�N
        private const string FORMAT_ERRMSG_MUSTINPUT = "{0}����͂��Ă��������B";
        //�ҏW���@�`�F�b�N
        private const string FORMAT_ERRMSG_ERRORVAL = "{0}���s���ł��B";

        //------------ADD ZHANGY3 2012/07/20 FOR REDMINE#30387--------->>>>
        //�d���f�[�^�`�F�b�N
        //private const string ERRMSG_DUPLICATE = "�d���f�[�^���Ă��邽�ߓo�^�ł��܂���B";//DEL ZHANGY3 2012/07/25 FOR REDMINE#30387
        private const string ERRMSG_DUPLICATE = "�d���f�[�^�����邽�ߓo�^�ł��܂���B";//ADD ZHANGY3 2012/07/25 FOR REDMINE#30387
        //------------ADD ZHANGY3 2012/07/20 FOR REDMINE#30387---------<<<<
        # endregion

        # region ����

        /// <summary>
        /// �����l�A�������`�F�b�N����
        /// </summary>
        /// <param name="fieldNm">���ږ�</param>
        /// <param name="val">�l</param>
        /// <param name="valLen">���ڒ���</param>
        /// <param name="dotLen">�_�ӏ�</param>
        /// <param name="msg">���b�Z�[�W</param>
        /// <returns>bool</returns>
        /// <remarks>
        /// <br>Note       : �����l�A�������`�F�b�N����B</br>
        /// <br>Programmer : zhangy3</br>
        /// <br>Date       : 2012/06/12</br>
        /// </remarks>
        private bool Check_FloatAndLen(string fieldNm, string val, int valLen, int dotLen,out string msg)
        {
            msg = string.Empty;
            //�^�C�v�̃`�F�b�N
            if (Regex.IsMatch(val, @"^[-+]?\d+(\.\d+)?$"))
            {
                //�����̃`�F�b�N
                if(Check_StrUnFixedLen(fieldNm,val,valLen+1,out msg))
                {
                    string regexStrLen = @"^((-([0-9]){1," + (valLen - dotLen - 1).ToString() + "}([.][0-9]{0," + dotLen.ToString() + "})?)|(([0-9]){1," + (valLen - dotLen ).ToString() + "}([.][0-9]{0," + dotLen.ToString() + "})?))$";
                    //�l�̃`�F�b�N
                    if (!Regex.IsMatch(val, regexStrLen))
                    {
                        msg = string.Format(FORMAT_ERRMSG_ERRORVAL, fieldNm);
                        return false;
                    }
                }
                else
                {
                    return false;
                }
                return true;
            }
            else
            {
                msg = string.Format(FORMAT_ERRMSG_TYPE, fieldNm, "����");
                return false;
            }
        }

        /// <summary>
        /// �����A�������`�F�b�N����
        /// </summary>
        /// <param name="fieldNm">���ږ�</param>
        /// <param name="val">�l</param>
        /// <param name="numLen">���ڒ���</param>
        /// <param name="msg">���b�Z�[�W</param>
        /// <returns>bool</returns>
        /// <remarks>
        /// <br>Note       : �����A�������`�F�b�N����B</br>
        /// <br>Programmer : zhangy3</br>
        /// <br>Date       : 2012/06/12</br>
        /// <br>Update Note: 2012/07/20 zhangy3 </br>
        /// <br>           : 10801804-00�A��z�Č��ARedmine#30387 �݌Ƀ}�X�^�C���{�[�g�d�l�ύX�̑Ή�</br>
        /// </remarks>
        private bool Check_IntDataAndLen(string fieldNm, string val, int numLen, out string msg)
        {
            msg = string.Empty;
            //�^�C�v�̃`�F�b�N
            if (Regex.IsMatch(val, @"^\d+(\.\d+)?$"))
            {
                //�����̃`�F�b�N
                if (Check_StrUnFixedLen(fieldNm, val, numLen, out msg))
                {
                    string regexStrLen = @"^([0-9]{1," + numLen.ToString() + "})$";
                    //�l�̃`�F�b�N
                    if (!Regex.IsMatch(val, regexStrLen))
                    {
                        msg = string.Format(FORMAT_ERRMSG_ERRORVAL, fieldNm);
                        return false;
                    }
                }
                else
                {
                    return false;
                }
                return true;
            }
            else
            {
                //msg = string.Format(FORMAT_ERRMSG_TYPE, fieldNm, "������");// DEL  2012/07/13  ������ Redmine#30393 for ��Q�ꗗ�̎w�ENO.94�̑Ή�
                //msg = string.Format(FORMAT_ERRMSG_TYPE, fieldNm, "����");// ADD  2012/07/13  ������ Redmine#30393 for ��Q�ꗗ�̎w�ENO.94�̑Ή�
                msg = string.Format(FORMAT_ERRMSG_TYPE, fieldNm, "����");//ADD ZHANGY3 2012/07/20 FOR REDMINE#30387
                return false;
            }
        }

        /// <summary>
        /// �����A�������`�F�b�N����
        /// </summary>
        /// <param name="fieldNm">���ږ�</param>
        /// <param name="val">�l</param>
        /// <param name="numLen">���ڒ���</param>
        /// <param name="msg">���b�Z�[�W</param>
        /// <returns>bool</returns>
        /// <remarks>
        /// <br>Note       : �����A�������`�F�b�N����B</br>
        /// <br>Programmer : zhangy3</br>
        /// <br>Date       : 2012/06/12</br>
        /// <br>Update Note: 2012/07/20 zhangy3 </br>
        /// <br>           : 10801804-00�A��z�Č��ARedmine#30387 �݌Ƀ}�X�^�C���{�[�g�d�l�ύX�̑Ή�</br>
        /// </remarks>
        private bool Check_IntAndLen(string fieldNm, string val, int numLen,out string msg)
        {
            msg = string.Empty;
            //�^�C�v�̃`�F�b�N
            if (Regex.IsMatch(val, @"^\d+(\.\d+)?$"))
            {
                //�����̃`�F�b�N
                if (Check_StrUnFixedLen(fieldNm, val, numLen, out msg))
                {
                    string regexStrLen = @"^([0-9]{1," + (numLen).ToString() + "})$";
                    //�l�̃`�F�b�N
                    if (!Regex.IsMatch(val, regexStrLen))
                    {
                        msg = string.Format(FORMAT_ERRMSG_ERRORVAL, fieldNm);
                        return false;
                    }
                }
                else
                {
                    return false;
                }
                return true;
            }
            else
            {
                //msg = string.Format(FORMAT_ERRMSG_TYPE, fieldNm, "������");// DEL  2012/07/13  ������ Redmine#30393 for ��Q�ꗗ�̎w�ENO.94�̑Ή�
                //msg = string.Format(FORMAT_ERRMSG_TYPE, fieldNm, "����");// ADD  2012/07/13  ������ Redmine#30393 for ��Q�ꗗ�̎w�ENO.94�̑Ή�//DEL ZHANGY3 2012/07/20 FOR REDMINE#30387
                msg = string.Format(FORMAT_ERRMSG_TYPE, fieldNm, "����");//ADD ZHANGY3 2012/07/20 FOR REDMINE#30387
                return false;
            }
        }

        /// <summary>
        /// NULL�̔��f
        /// </summary>
        /// <param name="fieldNm">���ږ�</param>
        /// <param name="val">�l</param>
        /// <param name="msg">���b�Z�[�W</param>
        /// <returns>bool</returns>
        /// <remarks>
        /// <br>Note       : NULL�̔��f�B</br>
        /// <br>Programmer : zhangy3</br>
        /// <br>Date       : 2012/06/12</br>
        /// </remarks>
        private bool Check_IsNull(string fieldNm, string val, out string msg)
        {
            msg = string.Empty;
            //NULL�̃`�F�b�N
            if (string.IsNullOrEmpty(val.ToString().Trim()))
            {
                msg = string.Format(FORMAT_ERRMSG_MUSTINPUT, fieldNm);
                return false;
            }
            return true;
        }

        private bool Check_Zero(string fieldNm, string val, out string msg)
        {
            msg = string.Empty;
            string compCharacter = "0";
            //NULL�̃`�F�b�N
            char[] charArr = val.ToCharArray();
            bool flg = false;
            foreach(char _char in charArr)
            {
                if(!compCharacter.Equals(_char.ToString()))
                {
                    flg = true;
                }
            }
            if (!flg)
            {
                msg = string.Format(FORMAT_ERRMSG_MUSTINPUT, fieldNm);
                return false;
            }
            return true;
        }

        /// <summary>
        /// �������w�肷��̕�����`�F�b�N
        /// </summary>
        /// <param name="fieldNm">���ږ�</param>
        /// <param name="val">�l</param>
        /// <param name="len">����</param>
        /// <param name="msg">���b�Z�[�W</param>
        /// <returns>bool</returns>
        /// <remarks>
        /// <br>Note       : �������w�肷��̕�����`�F�b�N�B</br>
        /// <br>Programmer : zhangy3</br>
        /// <br>Date       : 2012/06/12</br>
        /// </remarks>
        private bool Check_StrFixedLen(string fieldNm, string val, int len, out string msg)
        {
            msg = string.Empty;
            //�����̃`�F�b�N
            if (val.Trim().Length != len)
            {
                msg = string.Format(FORMAT_ERRMSG_LEN, fieldNm,len);
                return false;
            }
            return true;
        }

        /// <summary>
        /// �������w�肵�Ȃ��̕�����`�F�b�N
        /// </summary>
        /// <param name="fieldNm">���ږ�</param>
        /// <param name="val">�l</param>
        /// <param name="len">����</param>
        /// <param name="msg">���b�Z�[�W</param>
        /// <returns>bool</returns>
        /// <remarks>
        /// <br>Note       : �������w�肵�Ȃ��̕�����`�F�b�N�B</br>
        /// <br>Programmer : zhangy3</br>
        /// <br>Date       : 2012/06/12</br>
        /// </remarks>
        private bool Check_StrUnFixedLen(string fieldNm, string val, int len, out string msg)
        {
            msg = string.Empty;
            //�����`�F�b�N
            if (val.Length > len)
            {
                msg = string.Format(FORMAT_ERRMSG_LEN, fieldNm,len);
                return false;
            }
            return true;
        }

        /// <summary>
        /// ���p�p�����A�����̃`�F�b�N
        /// </summary>
        /// <param name="fieldNm">���ږ�</param>
        /// <param name="val">�l</param>
        /// <param name="len">����</param>
        /// <param name="msg">���b�Z�[�W</param>
        /// <returns>bool</returns>
        /// <remarks>
        /// <br>Note       : ���p�p�����A�����̃`�F�b�N�B</br>
        /// <br>Programmer : zhangy3</br>
        /// <br>Date       : 2012/06/12</br>
        /// </remarks>
        private bool Check_HalfEngNumFixedLength(string fieldNm, string val, int len,out string msg)
        {
            msg = string.Empty;
            string regexStr = @"^[a-zA-Z0-9 \-_.+=#$*&@%\\[~!_():;'?,/""<>\[\]^`{|}]{1," + len.ToString() + "}$";
            // ���p�p�����A�����̃`�F�b�N
            if (!Regex.IsMatch(val, regexStr))
            {
                msg = string.Format(FORMAT_ERRMSG_TYPE, fieldNm, "���p�p�����A����");
                return false;
            }
            return true;
        }

        # endregion

        # endregion



    }


    
  
}