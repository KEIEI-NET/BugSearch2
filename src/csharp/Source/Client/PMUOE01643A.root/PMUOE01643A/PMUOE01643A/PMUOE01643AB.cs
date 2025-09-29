//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �񓚃f�[�^�捞����
// �v���O�����T�v   : UOE�����f�[�^�Ɣ����񓚃f�[�^�̂����킹���s���A
//                    ����E�d���f�[�^�̍쐬���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10702591-00 �쐬�S�� : ������
// �� �� ��  2011/05/18  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//

using System;
using System.Data;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Windows.Forms;
using System.Collections;
using System.IO;
using System.Collections.Generic;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// �����񓚃f�[�^�̍\�z�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �����񓚃f�[�^�̍\�z�N���X���s���܂��B</br>
    /// <br>Programmer : ������</br>
    /// <br>Date       : 2011/05/18</br>
    /// </remarks>
    public abstract class UOEOrderDtlInfoBuilder
    {
        # region -- �v���C�x�[�g�ϐ� --
        /*----------------------------------------------------------------------------------*/
        private UOEOrderDtlAcs _uOEOrderDtlAcs;
        private UoeSndRcvCtlAcs _uoeSndRcvCtlAcs;
        private UOESupplierAcs _uOESupplierAcs;

        private List<UOEOrderDtlWork> _uOEOrderDtlWorkList = new List<UOEOrderDtlWork>();
        private List<StockDetailWork> _stockDetailWorkList = new List<StockDetailWork>();

        /// <summary>
        /// ������R�[�h
        /// </summary>
        public  int UOESupplierCd = 0;
        private const string MAZDACOMMASSEMBLY_ID_0403 = "0403";
        #endregion

        # region -- �R���X�g���N�^ --
        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : �I�t���C���Ή�</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011/05/18</br>
        /// </remarks>
        protected UOEOrderDtlInfoBuilder()
        {
            this._uOEOrderDtlAcs = new UOEOrderDtlAcs();
            this._uoeSndRcvCtlAcs = new UoeSndRcvCtlAcs();
            this._uOESupplierAcs = new UOESupplierAcs();

            // DB�X�V������������i���\���p�t�H�[������܂��B
            this._uoeSndRcvCtlAcs.UpdateProgress += new UoeSndRcvCtlAcs.OnUpdateProgress(this.CloseProgressForm);

            // �f�[�^�Z�b�g����\�z����
            this.DataTableColumnConstruction();
        }
        #endregion

        # region -- �������� --
        /// <summary>
        /// ��������
        /// </summary>
        /// <param name="answerDateMazdaPara">��ʏ��</param>
        /// <param name="errMessage">���b�Z�[�W</param>
        /// <returns>�`�F�b�N���ʁB�@0�F����G�@-1�F�ُ�</returns>
        /// <remarks>
        /// <br>Note       : MLG�����擾��������B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011/05/18</br>
        /// </remarks>
        public int DoSearch(AnswerDateMazdaPara answerDateMazdaPara, out string errMessage)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            errMessage = string.Empty;

            List<UOEOrderDtlInfo> filesDataDtlList;
            this._stockDetailWorkList.Clear();
            this._uOEOrderDtlWorkList.Clear();
            UOESupplierCd = answerDateMazdaPara.UOESupplierCd;

            // �t�@�C�����擾����
            status = this.GetFilesData(out filesDataDtlList, answerDateMazdaPara.AnswerSaveFolder, ref errMessage);

            if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {
                return status;
            }

            // Files�̃f�[�^���Ȃ��ꍇ
            if (filesDataDtlList == null || filesDataDtlList.Count == 0)
            {
                return (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
            }

            Dictionary<string, object> uoeRemarkDic = new Dictionary<string, object>();
            Dictionary<int, ArrayList> systemDivDic = new Dictionary<int, ArrayList>();

            foreach (UOEOrderDtlInfo info in filesDataDtlList)
            {
                // �����񓚃f�[�^�̃��}�[�N2
                string uoeRemark = info.UoeRemark2.Trim();

                if (!uoeRemarkDic.ContainsKey(uoeRemark))
                { 
                    List<UOEOrderDtlInfo> tempList;
                    uoeRemarkDic.Add(uoeRemark, null);
                    tempList = filesDataDtlList.FindAll(
                                delegate(UOEOrderDtlInfo info2)
                                {
                                    if (info2.UoeRemark2.Trim() == uoeRemark)
                                    {
                                        return true;
                                    }
                                    else
                                    {
                                        return false;
                                    }
                                }
                    );

                    // �V�X�e���敪
                    int systemDivCd = Int32.Parse(uoeRemark.Substring(3, 1));

                    List<UOEOrderDtlWork> uOEOrderDtlWorkList = new List<UOEOrderDtlWork>(); // UOE�����f�[�^
                    List<StockDetailWork> stockDetailWorkList = new List<StockDetailWork>(); // �d�����׃f�[�^

                    if (systemDivDic.ContainsKey(systemDivCd))
                    {
                        uOEOrderDtlWorkList = systemDivDic[systemDivCd][0] as List<UOEOrderDtlWork>;
                        stockDetailWorkList = systemDivDic[systemDivCd][1] as List<StockDetailWork>;
                    }
                    else
                    {
                        // UOE�����f�[�^������,���������̐ݒ�
                        UOESendProcCndtnPara para = new UOESendProcCndtnPara();
                        para.EnterpriseCode = answerDateMazdaPara.EnterpriseCode; //��ƃR�[�h					
                        para.CashRegisterNo = 0; //���W�ԍ�					
                        para.SystemDivCd = systemDivCd; //�V�X�e���敪	
                        para.St_InputDay = DateTime.MinValue; //�J�n���͓�					
                        para.Ed_InputDay = DateTime.MaxValue; //�I�����͓�					
                        para.CustomerCode = 0; //���Ӑ�R�[�h					
                        para.UOESupplierCd = answerDateMazdaPara.UOESupplierCd; //UOE������R�[�h					
                        para.St_OnlineNo = int.MinValue; //�J�n�ďo�ԍ�					
                        para.Ed_OnlineNo = int.MaxValue; //�I���ďo�ԍ�					
                        para.DataSendCodes = new int[] { 1 }; //�f�[�^���M�t���O

                        // UOE�����f�[�^������
                        status = this._uOEOrderDtlAcs.Search(para, out uOEOrderDtlWorkList, out stockDetailWorkList, out errMessage);

                        if (status != 0)
                        {
                            if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                            {
                                status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                                continue;
                            }

                            return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
                        }

                        ArrayList list = new ArrayList();
                        list.Add(uOEOrderDtlWorkList);
                        list.Add(stockDetailWorkList);
                        systemDivDic.Add(systemDivCd, list);
                    }

                    if (uOEOrderDtlWorkList == null || uOEOrderDtlWorkList.Count == 0)
                    {
                        status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                        continue;
                    }
                    
                    // ���������ō쐬���ꂽ�f�[�^�̍i����
                    List<UOEOrderDtlWork> retuOEOrderDtlWorkList = this.FilterUOEOrderDtlList(uOEOrderDtlWorkList, uoeRemark);

                    if (retuOEOrderDtlWorkList == null || retuOEOrderDtlWorkList.Count == 0)
                    {
                        continue;
                    }

                    // �i�荞�܂ꂽ�����f�[�^�Ƒ΂ɂȂ�d�����׃f�[�^�𒊏o
                    List<StockDetailWork> retStockDetailWorkList = this.FilterStockDetailList(retuOEOrderDtlWorkList, stockDetailWorkList);

                    // �Ώ�UOE�����f�[�^���񓚔����f�[�^�̃\�[�g���Ń\�[�g
                    retuOEOrderDtlWorkList.Sort(new UOEOrderDtlWorkComparer());

                    this.MergeList(ref retuOEOrderDtlWorkList, tempList);

                    // �m�菈���g�p
                    this._uOEOrderDtlWorkList.AddRange(retuOEOrderDtlWorkList);
                    this._stockDetailWorkList.AddRange(retStockDetailWorkList);
                }
            }

            if (this._uOEOrderDtlWorkList.Count == 0 || this._stockDetailWorkList.Count == 0)
            {
                return (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
            }
            else
            {
                // �f�[�^�Z�b�g�s��������
                this.DataTableAddRow(this._uOEOrderDtlWorkList);
            }

            return status;
        }

        /// <summary>
        /// �t�@�C�����擾����
        /// </summary>
        /// <param name="filesDataDtlList">�t�@�C�����</param>
        /// <param name="answerSaveFolder">�񓚕ۑ��t�H���_</param>
        /// <param name="errMessage">���b�Z�[�W</param>
        /// <returns>��������</returns>
        /// <remarks>
        /// <br>Note       : �t�@�C�������擾��������B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011/05/18</br>
        /// </remarks>
        protected abstract int GetFilesData(out List<UOEOrderDtlInfo> filesDataDtlList, string answerSaveFolder, ref string errMessage);

        /// <summary>
        /// ���������ō쐬���ꂽ�f�[�^�̍i����
        /// </summary>
        /// <param name="list">���</param>
        /// <param name="remark2">���}�[�N2</param>
        /// <returns>����</returns>
        /// <remarks>
        /// <br>Note       : ���������ō쐬���ꂽ�f�[�^�̍i���݁B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011/05/18</br>
        /// </remarks>
        protected abstract List<UOEOrderDtlWork> FilterUOEOrderDtlList(List<UOEOrderDtlWork> list, string remark2);
        #endregion

        # region -- �m�菈�� --
        /// <summary>
        /// �m�菈��
        /// </summary>
        /// <param name="answerDateMazdaPara">��ʏ��</param>
        /// <param name="errMessage">���b�Z�[�W</param>
        /// <returns>�`�F�b�N���ʁB�@0�F����G�@-1�F�ُ�</returns>
        /// <remarks>
        /// <br>Note       : �m�菈������B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011/05/18</br>
        /// <br>UpdateNote : </br>
        /// </remarks>
        public int DoConfirm(AnswerDateMazdaPara answerDateMazdaPara, out string errMessage)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            errMessage = string.Empty;

            if (this._uOEOrderDtlWorkList.Count == 0 || this._stockDetailWorkList.Count == 0)
            {
                errMessage = "�捞�����Ɏ��s���܂����B";
                return (-1);
            }

            Dictionary<int, object> sysDivDic = new Dictionary<int, object>();
            foreach (UOEOrderDtlWork uOEOrderDtlWork in this._uOEOrderDtlWorkList)
            {
                int sysDiv = uOEOrderDtlWork.SystemDivCd;

                if (sysDivDic.ContainsKey(sysDiv))
                {
                    continue;
                }

                sysDivDic.Add(sysDiv, null);

                List<UOEOrderDtlWork> uOEOrderDtlWorkList = this._uOEOrderDtlWorkList.FindAll(
                            delegate(UOEOrderDtlWork work)
                            {
                                if (work.SystemDivCd == sysDiv)
                                {
                                    return true;
                                }
                                else
                                {
                                    return false;
                                }
                            }
                 );

                // �i�荞�܂ꂽ�����f�[�^�Ƒ΂ɂȂ�d�����׃f�[�^�̒��o����
                List<StockDetailWork> stockDetailWorkList = this.FilterStockDetailList(uOEOrderDtlWorkList, this._stockDetailWorkList);

                // �����N���X
                UoeSndRcvCtlPara uoeSndRcvCtlPara = new UoeSndRcvCtlPara();
                uoeSndRcvCtlPara.BusinessCode = 1; // 1:���� 2:���� 3:�݌Ɋm�F 4:�������
                uoeSndRcvCtlPara.EnterpriseCode = answerDateMazdaPara.EnterpriseCode;
                uoeSndRcvCtlPara.SystemDivCd = sysDiv;
                uoeSndRcvCtlPara.ProcessDiv = 1;            //0�F�ʏ�A1�F����

                // �t�n�d����M����
                status = this._uoeSndRcvCtlAcs.UoeSndRcvCtl(uoeSndRcvCtlPara, uOEOrderDtlWorkList, stockDetailWorkList, out errMessage);

                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    break;
                }
            }

            return status;
        }
        #endregion

        # region -- DataTable�̏��� --
        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// �f�[�^�Z�b�g�N���A����
        /// </summary>
        /// <remarks>
        /// <br>Note       : �f�[�^�Z�b�g�N���A�������s���܂��B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011/05/18</br>
        /// </remarks>
        public abstract void DataTableClear();

        /// <summary>
        /// �f�[�^�Z�b�g����\�z����
        /// </summary>
        /// <remarks>
        /// <br>Note       : DataSet�̗�����\�z���܂��B�f�[�^�Z�b�g�̗��񂪃t���[���̃r���[�p�O���b�h�̗�ɂȂ�܂��B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011/05/18</br>
        /// </remarks>
        protected abstract void DataTableColumnConstruction();

        /// <summary>
        /// �f�[�^�Z�b�g�s��������
        /// </summary>
        /// <remarks>
        /// <br>Note       : �f�[�^�Z�b�g�s�����������s���܂��B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011/05/18</br>
        /// </remarks>
        protected abstract void DataTableAddRow(List<UOEOrderDtlWork> workList);
        # endregion

        # region -- ������ҏW���� --
        /// <summary>
        /// string -> int ����
        /// </summary>
        /// <param name="targetText">�����Ώۃe�L�X�g</param>
        /// <remarks>
        /// <br>Note	   : int��Ԃ��܂��B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011/05/18</br>
        /// </remarks>
        protected int StringToInt(string targetText)
        {
            int result = 0;

            if (string.IsNullOrEmpty(targetText)) return result;

            try
            {
                result = Convert.ToInt32(targetText);
            }
            catch
            {
                result = 0;
            }

            return result;
        }

        /// <summary>
        /// string -> Double ����
        /// </summary>
        /// <param name="targetText">�����Ώۃe�L�X�g</param>
        /// <remarks>
        /// <br>Note	   : int��Ԃ��܂��B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011/05/18</br>
        /// </remarks>
        protected double StringToDouble(string targetText)
        {
            double result = 0;

            if (string.IsNullOrEmpty(targetText)) return result;

            try
            {
                result = Convert.ToDouble(targetText);
            }
            catch
            {
                result = 0;
            }

            return result;
        }
        #endregion

        # region -- ���X�g���̍쐬���� --
        /// <summary>
        /// �Ώ�UOE�����f�[�^��r�N���X(�I�����C���ԍ�(����)�A�C�����C���s�ԍ�(����)�AUOE�����ԍ�(����)�AUOE�����s�ԍ�(����))
        /// </summary>
        /// <remarks>
        /// <br>Note       : �Ώ�UOE�����f�[�^��r�N���X�B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011/05/18</br>
        /// </remarks>
        private class UOEOrderDtlWorkComparer : Comparer<UOEOrderDtlWork>
        {
            /// <summary>
            /// ��r����
            /// </summary>
            /// <param name="x"></param>
            /// <param name="y"></param>
            /// <returns></returns>
            public override int Compare(UOEOrderDtlWork x, UOEOrderDtlWork y)
            {
                // �I�����C���ԍ� 
                int result = x.OnlineNo.CompareTo(y.OnlineNo);
                if (result != 0) return result;

                // �I�����C���s�ԍ�
                result = x.OnlineRowNo.CompareTo(y.OnlineRowNo);
                if (result != 0) return result;

                // UOE�����ԍ�
                result = x.UOESalesOrderNo.CompareTo(y.UOESalesOrderNo);
                if (result != 0) return result;

                // UOE�����s�ԍ�
                result = x.UOESalesOrderRowNo.CompareTo(y.UOESalesOrderRowNo);
                return result;
            }
        }
        # endregion

        # region  -- ���̑����� --
        /// <summary>
        /// ���}�[�N2�̃`�F�b�N����
        /// </summary>
        /// <param name="uoeRemark2">���}�[�N2</param>
        /// <returns>True:�L��  False:����</returns>
        /// <remarks>
        /// <br>Note       : ���}�[�N2�̃`�F�b�N�������s��</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011/05/18</br>
        /// </remarks>
        protected bool CheckUoeRemark2(string uoeRemark2)
        {
            // ���}�[�N2�͋�ꍇ
            if (uoeRemark2 == null
                || uoeRemark2.Trim() == ""
                || uoeRemark2.Length < 2)
            {
                return false;
            }

            // �u"@" + �V�X�e���敪�i1���j + �A�gNo.�v�̃`�F�b�N
            if (uoeRemark2.Substring(0, 2) != "@0"
                && uoeRemark2.Substring(0, 2) != "@1"
                && uoeRemark2.Substring(0, 2) != "@2"
                && uoeRemark2.Substring(0, 2) != "@3"
                && uoeRemark2.Substring(0, 2) != "@4")
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// �i�荞�܂ꂽ�����f�[�^�Ƒ΂ɂȂ�d�����׃f�[�^�̒��o����
        /// </summary>
        /// <param name="uOEOrderDtlWorkList">�i�荞�܂ꂽ�����f�[�^���X�g</param>
        /// <param name="stockDetailWorkList">�d�����׃f�[�^���X�g</param>
        /// <returns>���ʎd�����׃f�[�^���X�g</returns>
        /// <remarks>
        /// <br>Note       : �i�荞�܂ꂽ�����f�[�^�Ƒ΂ɂȂ�d�����׃f�[�^�𒊏o</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011/05/18</br>
        /// </remarks>
        private List<StockDetailWork> FilterStockDetailList(List<UOEOrderDtlWork> uOEOrderDtlWorkList, List<StockDetailWork> stockDetailWorkList)
        {
            List<StockDetailWork> retList = new List<StockDetailWork>();

            foreach (UOEOrderDtlWork uOEOrderDtlWork in uOEOrderDtlWorkList)
            {
                // �d���`��
                int supplierFormal = uOEOrderDtlWork.SupplierFormal;
                // �d�����גʔ�
                long stockSlipDtlNum = uOEOrderDtlWork.StockSlipDtlNum;

                foreach (StockDetailWork stockDetailWork in stockDetailWorkList)
                {
                    if (stockDetailWork.EnterpriseCode == uOEOrderDtlWork.EnterpriseCode
                        && stockDetailWork.SupplierFormal == supplierFormal
                        && stockDetailWork.StockSlipDtlNum == stockSlipDtlNum)
                    {
                        retList.Add(stockDetailWork);
                    }
                }
            }

            return retList;
        }

        /// <summary>
        /// �����񓚃f�[�^��UOE�����f�[�^�ɔ��f�̏���
        /// </summary>
        /// <param name="workList">UOE�����f�[�^</param>
        /// <param name="dateList">�����񓚃f�[�^</param>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note       : �����񓚃f�[�^��UOE�����f�[�^�ɔ��fނ�����</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011/05/18</br>
        /// </remarks>
        protected abstract int MergeList(ref List<UOEOrderDtlWork> workList, List<UOEOrderDtlInfo> dateList);
        #endregion

        #region -- �i���\�� --

        /// <summary>�i���\���p�t�H�[��</summary>
        SFCMN00299CA _progressForm;
        /// <summary>�i���\���p�t�H�[�����擾�܂��͐ݒ肵�܂��B</summary>
        public SFCMN00299CA ProgressForm
        {
            get { return _progressForm; }
            set { _progressForm = value; }
        }

        /// <summary>
        /// �i���\���p�t�H�[�������C�x���g�n���h��
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        private void CloseProgressForm(object sender, UoeSndRcvCtlAcs.UpdateProgressEventArgs e)
        {
            if (ProgressForm == null) return;

            // DB�X�V������������i���\���p�t�H�[������܂��B
            if (e.ProgressState.Equals(UoeSndRcvCtlAcs.SendAndReceiveProgress.DoneUpdateDB))
            {
                ProgressForm.Close();
            }
        }
        #endregion // �i���\��

        # region -- �L���b�V������ --
        /// <summary>
        /// ������̎Z�o
        /// </summary>
        /// <param name="outUOESupplierlilst">UOE������}�X�^Info</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="sectionCode">���O�C�����_</param>
        /// <param name="commAssemblyId">commAssemblyId</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ������̎Z�o�������s���܂��B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011/05/18</br>
        /// </remarks>
        public int GetUOESupplier(out ArrayList outUOESupplierlilst, string enterpriseCode, string sectionCode, string commAssemblyId)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            outUOESupplierlilst = new ArrayList();

            // ��������
            ArrayList uOESupplierList = new ArrayList();

            // �t�n�d������}�X�^��ǂݍ���
            status = this._uOESupplierAcs.SearchAll(out uOESupplierList, enterpriseCode, sectionCode);

            // ����̏ꍇ
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL
                || status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
            {
                status = 0;

                foreach (UOESupplier uOESupplier in uOESupplierList)
                {
                    if (uOESupplier.LogicalDeleteCode == 0 && (uOESupplier.CommAssemblyId == commAssemblyId || uOESupplier.CommAssemblyId == MAZDACOMMASSEMBLY_ID_0403) && uOESupplier.InqOrdDivCd == 0)
                    {
                        outUOESupplierlilst.Add(uOESupplier);
                    }
                }
            }

            return status;
        }
        # endregion
    }
}
