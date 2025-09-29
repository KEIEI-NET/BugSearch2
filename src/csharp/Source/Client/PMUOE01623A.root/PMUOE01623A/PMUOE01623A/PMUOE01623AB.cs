//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �񓚃f�[�^�捞����
// �v���O�����T�v   : UOE�����f�[�^�Ɣ����񓚃f�[�^�̂����킹���s���A
//                    ����E�d���f�[�^�̍쐬���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10601190-00 �쐬�S�� : �����
// �� �� ��  2010/03/08  �C�����e : �V�K�쐬
//                                 �y�v��No.6�zUOE�����f�[�^�Ɣ����񓚃f�[�^�̂����킹���s���A����E�d���f�[�^�̍쐬���s��
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10601190-00 �쐬�S�� : �����
// �C �� ��  2010/03/18  �C�����e : redmine#4044,4046�ƃ\�[�X�w�E�̏C��
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10601190-00 �쐬�S�� : �����
// �C �� ��  2010/03/22  �C�����e : redmine#4067,4068�̏C��
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10607734-00 �쐬�S�� : ���N�n��
// �C �� ��  2010/12/31  �C�����e : �����捞�敪�̒ǉ��ɔ����������ύX�ɂȂ邽�߁A�����̎蓮�����͎c����	�A�����捞�̏����ǉ����s���܂��B 
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10607734-01 �쐬�S�� : liyp
// �C �� ��  2011/03/01  �C�����e : ���Y�������ǉ��d�l���̑g�ݍ���
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10607734-01 �쐬�S�� : ������
// �C �� ��  2011/03/15  �C�����e : Redmine #19908�E#19948�̑Ή�
//----------------------------------------------------------------------------//
using System;
using Microsoft.VisualBasic.FileIO;
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
    /// <br>Programmer : �����</br>
    /// <br>Date       : 2010/03/08</br>
    /// <br>UpdateNote : ����� 2010/03/18 redmine#4044,4046�ƃ\�[�X�w�E�̏C��</br>
    /// <br>UpdateNote : ����� 2010/03/22 redmine#4067,4068�̏C��</br>
    /// <br>UpdateNote : 2010/12/31 ���N�n��</br>
    /// <br>           �@�����捞�敪�̒ǉ��ɔ����������ύX�ɂȂ邽�߁A�����̎蓮�����͎c����	�A�����捞�̏����ǉ����s���܂��B</br> 
    /// <br>UpdateNpet :2011/03/01 liyp ���Y�������ǉ��d�l���̑g�ݍ���</br>
    /// <br>UpdateNote :2011/03/15 ������ Redmine #19908�E#19948�̑Ή�</br>
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

        public  int UOESupplierCd = 0;// ADD 2010/12/31
        private int _uOESupplierFlag = 0; // ADD 2011/03/15
        private const string NISSANCOMMASSEMBLY_ID_0205 = "0205"; // ADD 2011/03/01
        private const string NISSANCOMMASSEMBLY_ID_0204 = "0204"; // ADD 2011/03/15
        private const string NISSANCOMMASSEMBLY_ID_0206 = "0206"; // ADD 2011/03/15
        #endregion

        # region -- �R���X�g���N�^ --
        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : �I�t���C���Ή�</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2010/03/08</br>
        /// <br>UpdateNote : ����� 2010/03/18 redmine#4037�̏C��</br>
        /// </remarks>
        //public UOEOrderDtlInfoBuilder() // DEL 2010/03/18
        protected UOEOrderDtlInfoBuilder() // ADD 2010/03/18
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
        /// <param name="answerDateNissanPara">��ʏ��</param>
        /// <param name="errMessage">���b�Z�[�W</param>
        /// <returns>�`�F�b�N���ʁB�@0�F����G�@-1�F�ُ�</returns>
        /// <remarks>
        /// <br>Note       : RCV�����擾��������B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2010/03/08</br>
        /// <br>UpdateNote : ����� 2010/03/18 redmine#4046�̏C��</br>
        /// <br>UpdateNote : ����� 2010/03/22 redmine#4067,4068�̏C��</br>
        /// <br>UpdateNote : 2010/12/31 ���N�n��</br>
        /// <br>           �@�����捞�敪�̒ǉ��ɔ����������ύX�ɂȂ邽�߁A�����̎蓮�����͎c����	�A�����捞�̏����ǉ����s���܂��B</br> 
        /// <br>UpdateNote :2011/03/01 liyp ���Y�������ǉ��d�l���̑g�ݍ���</br>
        /// <br>UpdateNote :2011/03/15 ������ Redmine #19948�̑Ή�</br>
        /// </remarks>
        public int DoSearch(AnswerDateNissanPara answerDateNissanPara, out string errMessage)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            errMessage = string.Empty;

            List<UOEOrderDtlInfo> filesDataDtlList;
            this._stockDetailWorkList.Clear();
            this._uOEOrderDtlWorkList.Clear();
            UOESupplierCd = answerDateNissanPara.UOESupplierCd;// ADD 2010/12/31

            // �t�@�C�����擾����
            // --- UPD 2010/03/18 ---------->>>>>
            //status = this.GetFilesDate(out filesDataDtlList, answerDateNissanPara.AnswerSaveFolder, ref errMessage);
            status = this.GetFilesData(out filesDataDtlList, answerDateNissanPara.AnswerSaveFolder, ref errMessage);
            // --- UPD 2010/03/18 ----------<<<<<

            if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {
                return status;
            }

            // Files�̃f�[�^���Ȃ��ꍇ
            if (filesDataDtlList == null || filesDataDtlList.Count == 0)
            {
                return (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
            }

            // �\�[�g���Ń\�[�g
            //filesDataDtlList.Sort(new UOEOrderDtlInfoComparer()); // DEL 2010/03/18

            Dictionary<string, object> uoeRemarkDic = new Dictionary<string, object>();
            Dictionary<int, ArrayList> systemDivDic = new Dictionary<int, ArrayList>();

            foreach (UOEOrderDtlInfo info in filesDataDtlList)
            {
                // �����񓚃f�[�^�̃��}�[�N2
                string uoeRemark = info.UoeRemark2.Trim();
                // -----ADD 2011/03/01 ------------>>>>>
                if (!string.IsNullOrEmpty(info.RenkeNo))
                {
                    uoeRemark = info.RenkeNo.Trim();
                }
                // -----ADD 2011/03/01 ------------<<<<<
                if (!uoeRemarkDic.ContainsKey(uoeRemark))
                { 
                    // ---------UPD 2011/03/01 ---------------->>>>>
                    List<UOEOrderDtlInfo> tempList;
                    uoeRemarkDic.Add(uoeRemark, null);
                    if (!string.IsNullOrEmpty(info.RenkeNo))
                    {
                        tempList = filesDataDtlList.FindAll(
                                    delegate(UOEOrderDtlInfo info2)
                                    {
                                        if (info2.RenkeNo == uoeRemark)
                                        {
                                            return true;
                                        }
                                        else
                                        {
                                            return false;
                                        }
                                    }
                        );
                    }
                    else
                    {
                        tempList = filesDataDtlList.FindAll(
                                    delegate(UOEOrderDtlInfo info2)
                                    {
                                        if (info2.UoeRemark2 == uoeRemark)
                                        {
                                            return true;
                                        }
                                        else
                                        {
                                            return false;
                                        }
                                    }
                        );
                    }
                    // ---------UPD 2011/03/01 ----------------<<<<<

                    // ---UPD 2011/03/15---------------->>>>>
                    // �V�X�e���敪
                    //int systemDivCd = Int32.Parse(uoeRemark.Substring(1, 1));
                    int systemDivCd = 0;
                    if (this._uOESupplierFlag == 5)
                    {
                        systemDivCd = Int32.Parse(uoeRemark.Substring(3, 1));
                    }
                    else
                    {
                        systemDivCd = Int32.Parse(uoeRemark.Substring(1, 1));
                    }
                    // ---UPD 2011/03/15----------------<<<<<

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
                        para.EnterpriseCode = answerDateNissanPara.EnterpriseCode; //��ƃR�[�h					
                        para.CashRegisterNo = 0; //���W�ԍ�					
                        para.SystemDivCd = systemDivCd; //�V�X�e���敪	
                        para.St_InputDay = DateTime.MinValue; //�J�n���͓�					
                        para.Ed_InputDay = DateTime.MaxValue; //�I�����͓�					
                        para.CustomerCode = 0; //���Ӑ�R�[�h					
                        para.UOESupplierCd = answerDateNissanPara.UOESupplierCd; //UOE������R�[�h					
                        para.St_OnlineNo = int.MinValue; //�J�n�ďo�ԍ�					
                        para.Ed_OnlineNo = int.MaxValue; //�I���ďo�ԍ�					
                        para.DataSendCodes = new int[] { 1 }; //�f�[�^���M�t���O

                        // UOE�����f�[�^������
                        status = this._uOEOrderDtlAcs.Search(para, out uOEOrderDtlWorkList, out stockDetailWorkList, out errMessage);

                        if (status != 0)
                        {
                            // --- ADD 2010/03/22 ---------->>>>>
                            if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                            {
                                status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                                continue;
                            }
                            // --- ADD 2010/03/22 ----------<<<<<

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
        /// CSV���擾����
        /// </summary>
        /// <param name="csvDataList">CSV���</param>
        /// <param name="filePathName">�t�@�C�����O</param>
        /// <returns>��������</returns>
        /// <remarks>
        /// <br>Note       : CSV�����擾��������B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2010/03/08</br>
        /// <br>UpdateNote : ����� 2010/03/18 �\�[�X�w�E�̏C��</br>
        /// </remarks>
        //public int GetCSVData(out List<string[]> csvDataList, string filePathName) // DEL 2010/03/18
        protected int GetCSVData(out List<string[]> csvDataList, string filePathName) // ADD 2010/03/18
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

            // CSV���
            csvDataList = new List<string[]>();
            try
            {
                FileStream fileStream = new FileStream(filePathName, FileMode.Open, FileAccess.Read, FileShare.None);
                byte[] bytes = new byte[fileStream.Length];
                fileStream.Read(bytes, 0, bytes.Length);
                fileStream.Close();
                Stream stream = new MemoryStream(bytes);

                TextFieldParser parser = new TextFieldParser(stream, System.Text.Encoding.GetEncoding("Shift_JIS"));
                using (parser)
                {
                    parser.TextFieldType = FieldType.Delimited;
                    parser.SetDelimiters(","); // ��؂蕶���̓R���}
                    while (!parser.EndOfData)
                    {
                        string[] row = parser.ReadFields(); // 1�s�ǂݍ���
                        csvDataList.Add(row);
                    }
                }
            }
            catch
            {
                // �ُ�ꍇ
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
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
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2010/03/08</br>
        /// <br>UpdateNote : ����� 2010/03/18 �\�[�X�w�E�̏C��</br>
        /// </remarks>
        //public abstract int GetFilesDate(out List<UOEOrderDtlInfo> filesDataDtlList, string answerSaveFolder, ref string errMessage); // DEL 2010/03/18
        protected abstract int GetFilesData(out List<UOEOrderDtlInfo> filesDataDtlList, string answerSaveFolder, ref string errMessage); // ADD 2010/03/18

        /// <summary>
        /// ���������ō쐬���ꂽ�f�[�^�̍i����
        /// </summary>
        /// <param name="list">���</param>
        /// <param name="remark2">���}�[�N2</param>
        /// <returns>����</returns>
        /// <remarks>
        /// <br>Note       : ���������ō쐬���ꂽ�f�[�^�̍i���݁B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2010/03/08</br>
        /// </remarks>
        //public abstract List<UOEOrderDtlWork> FilterUOEOrderDtlList(List<UOEOrderDtlWork> list, string remark2); // DEL 2010/03/18
        protected abstract List<UOEOrderDtlWork> FilterUOEOrderDtlList(List<UOEOrderDtlWork> list, string remark2); // ADD 2010/03/18
        #endregion

        # region -- �m�菈�� --
        /// <summary>
        /// �m�菈��
        /// </summary>
        /// <param name="answerDateNissanPara">��ʏ��</param>
        /// <param name="errMessage">���b�Z�[�W</param>
        /// <returns>�`�F�b�N���ʁB�@0�F����G�@-1�F�ُ�</returns>
        /// <remarks>
        /// <br>Note       : �m�菈������B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2010/03/08</br>
        /// <br>UpdateNote : </br>
        /// </remarks>
        public int DoConfirm(AnswerDateNissanPara answerDateNissanPara, out string errMessage)
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
                uoeSndRcvCtlPara.EnterpriseCode = answerDateNissanPara.EnterpriseCode;
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
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2009.06.08</br>
        /// </remarks>
        public abstract void DataTableClear();

        /// <summary>
        /// �f�[�^�Z�b�g����\�z����
        /// </summary>
        /// <remarks>
        /// <br>Note       : DataSet�̗�����\�z���܂��B�f�[�^�Z�b�g�̗��񂪃t���[���̃r���[�p�O���b�h�̗�ɂȂ�܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2010/03/08</br>
        /// <br>UpdateNote : ����� 2010/03/18 �\�[�X�w�E�̏C��</br>
        /// </remarks>
        //public abstract void DataTableColumnConstruction(); // DEL 2010/03/18
        protected abstract void DataTableColumnConstruction(); // ADD 2010/03/18

        /// <summary>
        /// �f�[�^�Z�b�g�s��������
        /// </summary>
        /// <remarks>
        /// <br>Note       : �f�[�^�Z�b�g�s�����������s���܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2010/03/08</br>
        /// <br>UpdateNote : ����� 2010/03/18 �\�[�X�w�E�̏C��</br>
        /// </remarks>
        //public abstract void DataTableAddRow(List<UOEOrderDtlWork> workList); // DEL 2010/03/18
        protected abstract void DataTableAddRow(List<UOEOrderDtlWork> workList); // ADD 2010/03/18
        # endregion

        # region -- ������ҏW���� --
        /// <summary>
        /// string -> int ����
        /// </summary>
        /// <param name="targetText">�����Ώۃe�L�X�g</param>
        /// <remarks>
        /// <br>Note	   : int��Ԃ��܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2010/03/08</br>
        /// <br>UpdateNote : ����� 2010/03/18 �\�[�X�w�E�̏C��</br>
        /// </remarks>
        //public int StringToInt(string targetText) // DEL 2010/03/18
        protected int StringToInt(string targetText) // ADD 2010/03/18
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
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2010/03/08</br>
        /// <br>UpdateNote : ����� 2010/03/18 �\�[�X�w�E�̏C��</br>
        /// </remarks>
        //public double StringToDouble(string targetText) // DEL 2010/03/18
        protected double StringToDouble(string targetText) // ADD 2010/03/18
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
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2010/03/08</br>
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

        // --- DEL 2010/03/18 ---------->>>>>
        ///// <summary>
        ///// �Ώ�UOE�����f�[�^��r�N���X(�I�����C���ԍ�(����)�A�C�����C���s�ԍ�(����)�AUOE�����ԍ�(����)�AUOE�����s�ԍ�(����))
        ///// </summary>
        ///// <remarks>
        ///// <br>Note       : �Ώ�UOE�����f�[�^��r�N���X�B</br>
        ///// <br>Programmer : �����</br>
        ///// <br>Date       : 2010/03/08</br>
        ///// </remarks>
        //private class UOEOrderDtlInfoComparer : Comparer<UOEOrderDtlInfo>
        //{
        //    /// <summary>
        //    /// ��r����
        //    /// </summary>
        //    /// <param name="x"></param>
        //    /// <param name="y"></param>
        //    /// <returns></returns>
        //    public override int Compare(UOEOrderDtlInfo x, UOEOrderDtlInfo y)
        //    {
        //        // �t�n�d���}�[�N�Q
        //        int result = x.UoeRemark2.CompareTo(y.UoeRemark2);
        //        if (result != 0) return result;

        //        // �I�����C���ԍ� 
        //        int result = x.OnlineNo.CompareTo(y.OnlineNo);
        //        if (result != 0) return result;

        //        // �I�����C���s�ԍ�
        //        result = x.OnlineRowNo.CompareTo(y.OnlineRowNo);
        //        if (result != 0) return result;

        //        // UOE�����ԍ�
        //        result = x.UOESalesOrderNo.CompareTo(y.UOESalesOrderNo);
        //        if (result != 0) return result;

        //        // UOE�����s�ԍ�
        //        result = x.UOESalesOrderRowNo.CompareTo(y.UOESalesOrderRowNo);
        //        return result;
        //    }
        //}
        // --- DEL 2010/03/18 ----------<<<<<
        # endregion

        # region  -- ���̑����� --
        /// <summary>
        /// ���}�[�N2�̃`�F�b�N����
        /// </summary>
        /// <param name="uoeRemark2">���}�[�N2</param>
        /// <returns>True:�L��  False:����</returns>
        /// <remarks>
        /// <br>Note       : ���}�[�N2�̃`�F�b�N�������s��</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2010/03/08</br>
        /// <br>UpdateNote : ����� 2010/03/18 �\�[�X�w�E�̏C��</br>
        /// </remarks>
        //public bool CheckUoeRemark2(string uoeRemark2) // DEL 2010/03/18
        protected bool CheckUoeRemark2(string uoeRemark2) // ADD 2010/03/18
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

        // ---ADD 2011/03/15-------------->>>>>
        /// <summary>
        /// ���}�[�N2�̃`�F�b�N�����i�v���O�����F0206�̂ݗp�j
        /// </summary>
        /// <param name="uoeRemark2">���}�[�N2</param>
        /// <returns>True:�L��  False:����</returns>
        /// <remarks>
        /// <br>Note       : ���}�[�N2�̃`�F�b�N�������s��</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011/03/15</br>
        /// </remarks>
        protected bool CheckRenKeNo(string uoeRemark2)
        {
            // ���}�[�N2�͋�ꍇ
            if (uoeRemark2 == null
                || uoeRemark2.Trim() == ""
                || uoeRemark2.Length < 4)
            {
                return false;
            }

            // �u"@" + �V�X�e���敪�i1���j + �A�gNo.�v�̃`�F�b�N
            if (uoeRemark2.Substring(3, 1) != "0"
                && uoeRemark2.Substring(3, 1) != "1"
                && uoeRemark2.Substring(3, 1) != "2"
                && uoeRemark2.Substring(3, 1) != "3"
                && uoeRemark2.Substring(3, 1) != "4")
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// �v���O����ID��ݒ�
        /// </summary>
        /// <param name="uOESupplierFlag">�v���O����ID</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : �v���O����ID��ݒ�</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011/03/15</br>
        /// </remarks>
        protected void SetUOESupplierFlag(int uOESupplierFlag)
        {
            this._uOESupplierFlag = uOESupplierFlag;
        }
        // ---ADD 2011/03/15--------------<<<<<

        /// <summary>
        /// �i�荞�܂ꂽ�����f�[�^�Ƒ΂ɂȂ�d�����׃f�[�^�̒��o����
        /// </summary>
        /// <param name="uOEOrderDtlWorkList">�i�荞�܂ꂽ�����f�[�^���X�g</param>
        /// <param name="stockDetailWorkList">�d�����׃f�[�^���X�g</param>
        /// <returns>���ʎd�����׃f�[�^���X�g</returns>
        /// <remarks>
        /// <br>Note       : �i�荞�܂ꂽ�����f�[�^�Ƒ΂ɂȂ�d�����׃f�[�^�𒊏o</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2010/03/08</br>
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
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2010/03/08</br>
        /// <br>UpdateNote : ����� 2010/03/18 �\�[�X�w�E�̏C��</br>
        /// </remarks>
        //public abstract int MergeList(ref List<UOEOrderDtlWork> workList, List<UOEOrderDtlInfo> dateList); // DEL 2010/03/18
        protected abstract int MergeList(ref List<UOEOrderDtlWork> workList, List<UOEOrderDtlInfo> dateList); // ADD 2010/03/18
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
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2010/03/08</br>
        /// <br>UpdateNote :2011/03/01 liyp</br>
        /// <br>          ���YUOE������B�Ή�</br>
        /// <br>UpdateNote :2011/03/15 ������</br>
        /// <br>          Redmine #19908�̑Ή�</br>
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
                    //if (uOESupplier.LogicalDeleteCode == 0 && uOESupplier.CommAssemblyId == commAssemblyId) // DEL 2011/03/01
                    // ---UPD 2011/03/15--------------->>>>>
                    //if (uOESupplier.LogicalDeleteCode == 0 && (uOESupplier.CommAssemblyId == commAssemblyId || uOESupplier.CommAssemblyId == NISSANCOMMASSEMBLY_ID_0205) && uOESupplier.InqOrdDivCd == 0)// ADD 2011/03/01
                    if (uOESupplier.LogicalDeleteCode == 0 && (uOESupplier.CommAssemblyId == commAssemblyId || 
                                                                uOESupplier.CommAssemblyId == NISSANCOMMASSEMBLY_ID_0205 ||
                                                                uOESupplier.CommAssemblyId == NISSANCOMMASSEMBLY_ID_0204 ||
                                                                uOESupplier.CommAssemblyId == NISSANCOMMASSEMBLY_ID_0206))
                    // ---UPD 2011/03/15---------------<<<<<
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
