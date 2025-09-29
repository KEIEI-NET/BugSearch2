//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �ȒP�⍇���ڑ����A�N�Z�X�N���X
// �v���O�����T�v   : �ȒP�⍇���ڑ�����ǉ��E�폜����
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ� 10601193-00  �쐬�S�� : 21024�@���X�� ��
// �� �� ��  2010/03/25  �C�����e : 
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �C �� ��              �C�����e : 
//----------------------------------------------------------------------------//
using System;
using System.IO;
using System.Data;
using System.Text;
using System.Collections;
using System.Collections.Generic;

using Broadleaf.Library.Resources;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting.ParamData;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// �ȒP�⍇���ڑ����A�N�Z�X�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �V�K�쐬</br>
    /// <br>Programmer : 21024�@���X�� ��</br>
    /// <br>Date       : 2010/03/25</br>
    /// <br>----------------------------------------------------------------------------</br>
    /// <br>UpdateNote : </br>
    /// </remarks>
    public class SimplInqCnectInfoAcs
    {
        // ===================================================================================== //
        // �R���X�g���N�^
        // ===================================================================================== //
        # region ��Constructor
        /// <summary>
        /// �f�t�H���g�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : �V�K�쐬</br>
        /// <br>Programmer : 21024 ���X�� ��</br>
        /// <br>Date       : 2010/03/25</br>
        /// </remarks>
        public SimplInqCnectInfoAcs()
        {
        }
        #endregion


        // ===================================================================================== //
        // �v���C�x�[�g�ϐ�
        // ===================================================================================== //
        # region �� Private Member

        private ISimplInqCnectInfoDB _SimplInqCnectInfoDB = null;
        private SimplInqCnectInfoDataSet _SimplInqCnectInfoDataSet = null;

        private List<SimplInqCnectInfo> _cacheList = null;
        private List<CustomerSearchRet> _customerSearchRetList = null;
        private PosTerminalMg _ownPosTerminalMg = null;
        private List<PosTerminalMg> _posTerminalMgList = null;

        #endregion


        // ===================================================================================== //
        // �v���p�e�B
        // ===================================================================================== //
        # region �� Property

        /// <summary>
        /// CMT�ڑ����e�[�u���v���p�e�B
        /// </summary>
        public SimplInqCnectInfoDataSet.SimplInqCnectInfoDataTable SimplInqCnectInfoTable
        {
            get
            {
                if (this._SimplInqCnectInfoDataSet == null) this._SimplInqCnectInfoDataSet = new SimplInqCnectInfoDataSet();

                return this._SimplInqCnectInfoDataSet.SimplInqCnectInfo;
            }
        }

        #endregion


        // ===================================================================================== //
        // �p�u���b�N���\�b�h
        // ===================================================================================== //
        # region �� Public Method

        #region �t�h�p�̃��\�b�h

        /// <summary>
        /// ���_�}�X�^���A�w�苒�_�̋��_���̂��擾���܂��B
        /// </summary>
        /// <returns>�����_����</returns>
        /// <remarks>
        /// <br>Note       : �V�K�쐬</br>
        /// <br>Programmer : 21024�@���X�� ��</br>
        /// <br>Date       : 2010/03/25</br>
        /// </remarks>
        public string GetOwnSectionName(string loginSectionCode)
        {
            string ownSectionName = string.Empty;

            // �����_�̎擾
            SecInfoAcs _secInfoAcs = new SecInfoAcs();
            SecInfoSet secInfoSet;
            _secInfoAcs.GetSecInfo(loginSectionCode, out secInfoSet);
            if (secInfoSet != null)
            {
                // �����_�R�[�h�̕ۑ�
                ownSectionName = secInfoSet.SectionGuideNm;
            }

            return ownSectionName;
        }

        /// <summary>
        /// �[���Ǘ��}�X�^�i���[�J���j���A���[���̔ԍ����擾���܂��B
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : �V�K�쐬</br>
        /// <br>Programmer : 21024�@���X�� ��</br>
        /// <br>Date       : 2010/03/25</br>
        /// </remarks>
        public int GetOwnCashRegisterNo(string enterpriseCode)
        {
            if (_ownPosTerminalMg == null)
            {
                PosTerminalMgAcs acs = new PosTerminalMgAcs();
                acs.Search(out this._ownPosTerminalMg, enterpriseCode);
            }

            if (_ownPosTerminalMg == null) this._ownPosTerminalMg = new PosTerminalMg();

            return _ownPosTerminalMg.CashRegisterNo;
        }

        /// <summary>
        /// �w�肳�ꂽ��Ƃ̊ȒP�⍇���ڑ������擾���܂��B(��ʗp)
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : �V�K�쐬</br>
        /// <br>Programmer : 21024�@���X�� ��</br>
        /// <br>Date       : 2010/03/25</br>
        /// </remarks>
        public int Search(string enterpriseCode)
        {
            List<SimplInqCnectInfo> SimplInqCnectInfoList;

            return this.SearchProc(enterpriseCode, out SimplInqCnectInfoList, true, true);
        }

        /// <summary>
        /// �ۑ����܂��i�f�[�^�e�[�u���őI�𒆂̐ڑ������폜���܂��j
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : �V�K�쐬</br>
        /// <br>Programmer : 21024�@���X�� ��</br>
        /// <br>Date       : 2010/03/25</br>
        /// </remarks>
        public int Save(string enterpriseCode)
        {
            SimplInqCnectInfoDataSet.SimplInqCnectInfoRow[] rows = (SimplInqCnectInfoDataSet.SimplInqCnectInfoRow[])this._SimplInqCnectInfoDataSet.SimplInqCnectInfo.Select(string.Format("{0} = True", this._SimplInqCnectInfoDataSet.SimplInqCnectInfo.SelectedColumn.ColumnName));

            List<SimplInqCnectInfo> paraList = new List<SimplInqCnectInfo>();
            if (rows != null && rows.Length > 0)
            {
                foreach (SimplInqCnectInfoDataSet.SimplInqCnectInfoRow row in rows)
                {
                    paraList.Add(this.CopyToSimplInqCnectInfoFromRow(row));
                }

                return this.DeleteProc(enterpriseCode, paraList);
            }
            return (int)ConstantManagement.DB_Status.ctDB_NORMAL;
        }

        #endregion

        #region ���i�Ƃ��Ď����������\�b�h

        /// <summary>
        /// ���[���̊ȒP�⍇���ڑ������擾���܂��B
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="simplInqCnectInfoList">�ȒP�⍇���ڑ���񃊃X�g</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : �V�K�쐬</br>
        /// <br>Programmer : 21024�@���X�� ��</br>
        /// <br>Date       : 2010/03/25</br>
        /// </remarks>
        public int SearchOwnCnectInfoList(string enterpriseCode, out List<SimplInqCnectInfo> simplInqCnectInfoList)
        {
            return this.SearchOwnCnectInfoListProc(enterpriseCode, out simplInqCnectInfoList);
        }

        /// <summary>
        /// �w�肳�ꂽ��Ƃ̊ȒP�⍇���ڑ������擾���܂��B
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="simplInqCnectInfoList">�ȒP�⍇���ڑ���񃊃X�g</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : �V�K�쐬</br>
        /// <br>Programmer : 21024�@���X�� ��</br>
        /// <br>Date       : 2010/03/25</br>
        /// </remarks>
        public int Search(string enterpriseCode, out List<SimplInqCnectInfo> simplInqCnectInfoList)
        {
            return this.SearchProc(enterpriseCode, out simplInqCnectInfoList, false, false);
        }

        /// <summary>
        /// �ȒP�⍇���ڑ�����ǉ����܂��B
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="cashRegisterNo">�[���ԍ�</param>
        /// <param name="customerCode">���Ӑ�R�[�h</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : �V�K�쐬</br>
        /// <br>Programmer : 21024�@���X�� ��</br>
        /// <br>Date       : 2010/03/25</br>
        /// </remarks>
        public int AddConnect(string enterpriseCode, int cashRegisterNo, int customerCode)
        {
            SimplInqCnectInfo inf = new SimplInqCnectInfo();
            inf.CashRegisterNo = cashRegisterNo;
            inf.CustomerCode = customerCode;
            return this.WriteProc(enterpriseCode, inf);
        }


        /// <summary>
        /// �ȒP�⍇���ڑ������폜���܂��B
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="cashRegisterNo">�[���ԍ�</param>
        /// <param name="customerCode">���Ӑ�R�[�h</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : �V�K�쐬</br>
        /// <br>Programmer : 21024�@���X�� ��</br>
        /// <br>Date       : 2010/03/25</br>
        /// </remarks>
        public int DeleteConnect(string enterpriseCode, int cashRegisterNo, int customerCode)
        {
            List<SimplInqCnectInfo> list = new List<SimplInqCnectInfo>();
            SimplInqCnectInfo inf = new SimplInqCnectInfo();
            inf.CashRegisterNo = cashRegisterNo;
            inf.CustomerCode = customerCode;
            list.Add(inf);

            return this.DeleteProc(enterpriseCode, list);
        }

        #endregion

        #endregion


        // ===================================================================================== //
        // �v���C�x�[�g���\�b�h
        // ===================================================================================== //
        #region �� Private Method

        #region [ �ȒP�⍇���ڑ����֌W ]

        /// <summary>
        /// �ȒP�⍇���ڑ������������܂��B
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="simplInqCnectInfoList"></param>
        /// <returns></returns>
        private int SearchOwnCnectInfoListProc(string enterpriseCode, out List<SimplInqCnectInfo> simplInqCnectInfoList)
        {
            simplInqCnectInfoList = null;

            List<SimplInqCnectInfo> tempList;
            int status = this.SearchProc(enterpriseCode, out tempList, false, false);
            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                return status;
            }

            int cashRegisterNo = this.GetOwnCashRegisterNo(enterpriseCode);
            if (cashRegisterNo != 0 && tempList != null)
            {
                simplInqCnectInfoList = tempList.FindAll(delegate(SimplInqCnectInfo target)
                {
                    if (target.CashRegisterNo == cashRegisterNo) return true;
                    return false;
                });
            }

            return status;
        }

        /// <summary>
        /// �ȒP�⍇���ڑ������������܂��B
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="simplInqCnectInfoList">�ȒP�⍇���ڑ���񃊃X�g</param>
        /// <param name="cache">True:�L���b�V������</param>
        /// <param name="createTable">True:�e�[�u���쐬����(���Ӑ�y�ђ[���Ǘ��̌���������܂�)</param>
        /// <returns></returns>
        private int SearchProc(string enterpriseCode, out List<SimplInqCnectInfo> simplInqCnectInfoList, bool cache, bool createTable)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            simplInqCnectInfoList = null;

            if (_SimplInqCnectInfoDB == null)
            {
                _SimplInqCnectInfoDB = MediationSimplInqCnectInfoDB.GetSimplInqCnectInfoDB();
            }

            // �t�@�C��
            object retObj;

            status = _SimplInqCnectInfoDB.Search(enterpriseCode, out retObj);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                ArrayList al = (ArrayList)retObj;

                simplInqCnectInfoList = new List<SimplInqCnectInfo>();

                foreach (SimplInqCnectInfoWork work in al)
                {
                    simplInqCnectInfoList.Add(CopyToSimplInqCnectInfoFromSimplInqCnectInfoWork(work));
                }

                // TODO:����܂�ǂ��Ȃ�����
                if (cache) this._cacheList = simplInqCnectInfoList;
            }

            // �e�[�u���쐬�L��
            if (createTable)
            {
                if (this._SimplInqCnectInfoDataSet == null)
                    this._SimplInqCnectInfoDataSet = new SimplInqCnectInfoDataSet();
                else
                    this._SimplInqCnectInfoDataSet.SimplInqCnectInfo.Rows.Clear();

                if (simplInqCnectInfoList != null)
                {
                    foreach (SimplInqCnectInfo SimplInqCnectInfo in simplInqCnectInfoList)
                    {
                        SimplInqCnectInfoDataSet.SimplInqCnectInfoRow row = this._SimplInqCnectInfoDataSet.SimplInqCnectInfo.NewSimplInqCnectInfoRow();
                        row.CashRegisterNo = SimplInqCnectInfo.CashRegisterNo;
                        row.CustomerCode = SimplInqCnectInfo.CustomerCode;

                        // ���Ӑ於�̂̃Z�b�g
                        if (row.CustomerCode != 0)
                        {
                            CustomerSearchRet customer = this.FindCustomer(enterpriseCode, row.CustomerCode);
                            if (customer != null)
                            {
                                row.CustomerSnm = customer.Snm;
                            }
                        }

                        PosTerminalMg pos = this.FindPosTerminalMg(enterpriseCode, row.CashRegisterNo);
                        if (pos != null)
                        {
                            row.MachineName = pos.MachineName;
                        }
                        this._SimplInqCnectInfoDataSet.SimplInqCnectInfo.AddSimplInqCnectInfoRow(row);
                    }
                }
            }

            return status;
        }


        /// <summary>
        /// �w�肳�ꂽ�ȒP�⍇���ڑ������������݂܂��B
        /// </summary>
        /// <param name="enterpriseCode"></param>
        /// <param name="simplInqCnectInfo"></param>
        /// <returns></returns>
        private int WriteProc(string enterpriseCode, SimplInqCnectInfo simplInqCnectInfo)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            if (_SimplInqCnectInfoDB == null)
            {
                _SimplInqCnectInfoDB = MediationSimplInqCnectInfoDB.GetSimplInqCnectInfoDB();
            }
            SimplInqCnectInfoWork para = this.CopyToSimplInqCnectInfoWorkFromSimplInqCnectInfo(simplInqCnectInfo);
            status = _SimplInqCnectInfoDB.Write(enterpriseCode, (object)para);

            return status;
        }


        /// <summary>
        /// �w�肳�ꂽ�ȒP�⍇���ڑ������폜���܂��B
        /// </summary>
        /// <param name="enterpriseCode"></param>
        /// <param name="simplInqCnectInfoList"></param>
        /// <returns></returns>
        private int DeleteProc(string enterpriseCode, List<SimplInqCnectInfo> simplInqCnectInfoList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            if (_SimplInqCnectInfoDB == null)
            {
                _SimplInqCnectInfoDB = MediationSimplInqCnectInfoDB.GetSimplInqCnectInfoDB();
            }
            ArrayList paraList = new ArrayList();

            foreach (SimplInqCnectInfo info in simplInqCnectInfoList)
            {
                paraList.Add(this.CopyToSimplInqCnectInfoWorkFromSimplInqCnectInfo(info));
            }

            status = _SimplInqCnectInfoDB.Delete(enterpriseCode, (object)paraList);

            return status;
        }

        #endregion

        #region [ ���Ӑ�֌W ]

        /// <summary>
        /// ���Ӑ挟��
        /// </summary>
        /// <param name="enterpriseCode"></param>
        /// <param name="customerCode"></param>
        /// <returns></returns>
        private CustomerSearchRet FindCustomer(string enterpriseCode, int customerCode)
        {
            if (this._customerSearchRetList == null) this.SearchCutomer(enterpriseCode);

            if (this._customerSearchRetList == null || this._customerSearchRetList.Count == 0) return null;

            return _customerSearchRetList.Find(
                delegate(CustomerSearchRet ret)
                {
                    if (ret.LogicalDeleteCode != 0) return false;
                    if (ret.CustomerCode != customerCode) return false;

                    return true;
                });
        }


        /// <summary>
        /// ���Ӑ挟��
        /// </summary>
        /// <param name="enterpriseCode"></param>
        private void SearchCutomer(string enterpriseCode)
        {
            this._customerSearchRetList = new List<CustomerSearchRet>();

            CustomerSearchAcs acs = new CustomerSearchAcs();

            CustomerSearchPara para = new CustomerSearchPara();
            para.EnterpriseCode = enterpriseCode;

            CustomerSearchRet[] retList;
            int status = acs.Serch(out retList, para);


            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                this._customerSearchRetList.AddRange(retList);
            }
        }

        #endregion

        #region [ �[���Ǘ��֌W ]

        /// <summary>
        /// �[���Ǘ�����
        /// </summary>
        /// <param name="enterpriseCode"></param>
        /// <param name="customerCode"></param>
        /// <returns></returns>
        private PosTerminalMg FindPosTerminalMg(string enterpriseCode, int cashRegisterNo)
        {
            if (this._posTerminalMgList == null) this.SearchPosTerminalMg(enterpriseCode);

            if (this._posTerminalMgList == null || this._posTerminalMgList.Count == 0) return null;

            return _posTerminalMgList.Find(
                delegate(PosTerminalMg ret)
                {
                    if (ret.LogicalDeleteCode != 0) return false;
                    if (ret.CashRegisterNo != cashRegisterNo) return false;

                    return true;
                });
        }

        /// <summary>
        /// �[���Ǘ�����
        /// </summary>
        /// <param name="enterpriseCode"></param>
        private void SearchPosTerminalMg(string enterpriseCode)
        {
            this._posTerminalMgList = new List<PosTerminalMg>();
            
            PosTerminalMgAcs acs = new PosTerminalMgAcs();
            ArrayList al;

            int status = acs.SearchServer(out al, enterpriseCode);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                this._posTerminalMgList = new List<PosTerminalMg>();
                foreach (PosTerminalMg element in al)
                {
                    this._posTerminalMgList.Add(element);
                }
            }
        }

        #endregion

        # region [ �N���X�i�[���� ]

        /// <summary>
        /// �N���X�i�[�����iSimplInqCnectInfo��SimplInqCnectInfoWork)
        /// </summary>
        /// <param name="SimplInqCnectInfo">SimplInqCnectInfo�I�u�W�F�N�g</param>
        /// <returns>SimplInqCnectInfoWork�I�u�W�F�N�g</returns>
        private SimplInqCnectInfoWork CopyToSimplInqCnectInfoWorkFromSimplInqCnectInfo(SimplInqCnectInfo SimplInqCnectInfo)
        {
            SimplInqCnectInfoWork work = new SimplInqCnectInfoWork();

            work.CashRegisterNo = SimplInqCnectInfo.CashRegisterNo;
            work.CustomerCode = SimplInqCnectInfo.CustomerCode;

            return work;
        }

        /// <summary>
        /// �N���X�i�[�����iSimplInqCnectInfo��SimplInqCnectInfoWork)
        /// </summary>
        /// <param name="SimplInqCnectInfoWork">SimplInqCnectInfoWork�I�u�W�F�N�g</param>
        /// <returns>SimplInqCnectInfo�I�u�W�F�N�g</returns>
        private SimplInqCnectInfo CopyToSimplInqCnectInfoFromSimplInqCnectInfoWork(SimplInqCnectInfoWork SimplInqCnectInfoWork)
        {
            SimplInqCnectInfo info = new SimplInqCnectInfo();

            info.CashRegisterNo = SimplInqCnectInfoWork.CashRegisterNo;
            info.CustomerCode = SimplInqCnectInfoWork.CustomerCode;

            return info;
        }

        /// <summary>
        ///  �N���X�i�[�����iDataRow��SimplInqCnectInfo)
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        private SimplInqCnectInfo CopyToSimplInqCnectInfoFromRow(SimplInqCnectInfoDataSet.SimplInqCnectInfoRow row)
        {
            SimplInqCnectInfo info = new SimplInqCnectInfo();

            info.CashRegisterNo = row.CashRegisterNo;
            info.CustomerCode = row.CustomerCode;

            return info;
        }

        # endregion

        #endregion

    }
}
