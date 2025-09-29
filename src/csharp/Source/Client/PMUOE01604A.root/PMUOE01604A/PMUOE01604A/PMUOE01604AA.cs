//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �`�[�ԍ���������
// �v���O�����T�v   : �`�[�ԍ���������
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���m
// �� �� ��  2009/06/01  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10801804-00 �쐬�S�� : ����
// �C �� ��  2013/01/09  �C�����e : 2013/03/13�z�M�� Redmine #33989 �S���҃R�[�h�o�^�͕s���̑Ή��B
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting.ParamData;
using System.IO;
using Microsoft.VisualBasic.FileIO;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// �`�[�ԍ����������t�H�[���N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �Ȃ��B</br>
    /// <br>Programmer : ���m</br>
    /// <br>Date       : 2009.06.01</br>
    /// </remarks>
    public class SlipNoAlwcInputAcs
    {
        // ===================================================================================== //
        // �R���X�g���N�^
        // ===================================================================================== //
        # region ��Constructor
        /// <summary>
        /// �f�t�H���g�R���X�g���N�^�iSingleton�f�U�C���p�^�[�����̗p���Ă���ׁAprivate�Ƃ���j
        /// </summary>
        /// <remarks>
        /// <br>Note       : �Ȃ��B</br>
        /// <br>Programmer : ���m</br>
        /// <br>Date       : 2009.06.01</br>
        /// </remarks>
        private SlipNoAlwcInputAcs()
        {
            _slipNoAlwcData = new SlipNoAlwcData();
            _uOESupplierAcs = new UOESupplierAcs();
            _slipNoAlwcDataTable = new DataResult.SlipNoAlwcDataTable();
            _employeeDB = MediationEmployeeDB.GetEmployeeDB();
            _uoeSndRcvCtlAcs = new UoeSndRcvCtlAcs();
            stc_PrtOutSet = null;					// ���[�o�͐ݒ�f�[�^�N���X
            stc_PrtOutSetAcs = new PrtOutSetAcs();	// ���[�o�͐ݒ�A�N�Z�X�N���X
            stc_Employee = null;

            // ���O�C�����_�擾
            Employee loginEmployee = LoginInfoAcquisition.Employee.Clone();
            if (loginEmployee != null)
            {
                stc_Employee = loginEmployee.Clone();
            }
        }

        /// <summary>
        /// �A�N�Z�X�N���X �C���X�^���X�擾����
        /// </summary>
        /// <returns>�A�N�Z�X�N���X �C���X�^���X</returns>
        /// <remarks>
        /// <br>Note       : �Ȃ��B</br>
        /// <br>Programmer : ���m</br>
        /// <br>Date       : 2009.06.01</br>
        /// </remarks>
        public static SlipNoAlwcInputAcs GetInstance()
        {
            if (_slipNoAlwcInputAcs == null)
            {
                _slipNoAlwcInputAcs = new SlipNoAlwcInputAcs();
            }

            return _slipNoAlwcInputAcs;
        }
        #endregion

        // ===================================================================================== //
        // �v���C�x�[�g�ϐ�
        // ===================================================================================== //
        # region ��Private Members
        private static SlipNoAlwcInputAcs _slipNoAlwcInputAcs = null;
        private SlipNoAlwcData _slipNoAlwcData = null;
        private ArrayList outUOESupplier = null;
        private UOESupplierAcs _uOESupplierAcs = null;
        private DataResult.SlipNoAlwcDataTable _slipNoAlwcDataTable = null;
        private IEmployeeDB _employeeDB = null;
        private Dictionary<string, string> employeeDic = new Dictionary<string,string>();
        private UoeSndRcvCtlAcs _uoeSndRcvCtlAcs = null;
        private static PrtOutSet stc_PrtOutSet;			// ���[�o�͐ݒ�f�[�^�N���X
        private static PrtOutSetAcs stc_PrtOutSetAcs;	// ���[�o�͐ݒ�A�N�Z�X�N���X
        private static Employee stc_Employee;
        #endregion

        // ===================================================================================== //
        // ����
        // ===================================================================================== //
        # region ��Propertity

        /// <summary>
        /// UI�f�[�^
        /// </summary>
        public SlipNoAlwcData SlipNoAlwcData
        {
            get { return this._slipNoAlwcData; }
        }

        /// <summary>
        /// �f�[�^�e�[�v��
        /// </summary>
        public DataResult.SlipNoAlwcDataTable SlipNoAlwcDataTable
        {
            get { return this._slipNoAlwcDataTable; }
        }

        /// <summary>
        /// UOE������f�[�^
        /// </summary>
        public ArrayList UOESupplierData
        {
            get { return this.outUOESupplier; }
        }
        #endregion

        // ===================================================================================== //
        // �v���C�x�[�g���\�b�h
        // ===================================================================================== //
        # region ��Private Methods

        /// <summary>
        /// �����f�[�^�����C���X�^���X��������
        /// </summary>
        /// <remarks>
        /// <br>Note       : �Ȃ��B</br>
        /// <br>Programmer : ���m</br>
        /// <br>Date       : 2009.06.01</br>
        /// </remarks>
        public void CreateSlipNoAlwcInitialData()
        {
            SlipNoAlwcData slipNoAlwcData = new SlipNoAlwcData();

            // ����������
            slipNoAlwcData.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            slipNoAlwcData.SectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;
            slipNoAlwcData.SupplierCode = 0;
            // UOE������f�[�^
            if (outUOESupplier.Count > 0)
            {
                UOESupplier uoeSupplier = (UOESupplier)outUOESupplier[0];
                slipNoAlwcData.UOESupplierCd = uoeSupplier.UOESupplierCd;
                slipNoAlwcData.UOESupplierName = uoeSupplier.UOESupplierName;
                slipNoAlwcData.AnswerSaveFolder = uoeSupplier.AnswerSaveFolder;
            }
            else
            {
                slipNoAlwcData.UOESupplierCd = 0;
                slipNoAlwcData.UOESupplierName = "";
                slipNoAlwcData.AnswerSaveFolder = "";
            }
            // ���Ȃ�
            slipNoAlwcData.PriceUpdateCode = 0;
            // ���Ȃ�
            slipNoAlwcData.StockDataCode = 0;

            this.CacheSlipNoAlwcData(slipNoAlwcData);
        }

        /// <summary>
        /// �����f�[�^�L���b�V������
        /// </summary>
        /// <param name="source">����f�[�^�C���X�^���X</param>
        /// <remarks>
        /// <br>Note       : �Ȃ��B</br>
        /// <br>Programmer : ���m</br>
        /// <br>Date       : 2009.06.01</br>
        /// </remarks>
        public void CacheSlipNoAlwcData(SlipNoAlwcData source)
        {
            this._slipNoAlwcData = source.Clone();
        }

        /// <summary>
        /// �]�ƈ��}�X�^�ǂ�
        /// </summary>
        public int ReadEmployeeData()
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            EmployeeWork paraEmployeeWork = new EmployeeWork();
            paraEmployeeWork.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            Object employeeList = null;

            status = _employeeDB.Search(out employeeList, paraEmployeeWork, 0, ConstantManagement.LogicalMode.GetData0);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                employeeDic = new Dictionary<string, string>();
                ArrayList res = (ArrayList)employeeList;
                foreach (EmployeeWork employeeWork in res)
                {
                    employeeDic.Add(employeeWork.EmployeeCode, employeeWork.Name);
                }
            }

            return status;
        }

        /// <summary>
        /// �]�ƈ��擾
        /// </summary>
        /// <param name="employee">�]�ƈ��R�[�h</param>
        /// <returns>�]�ƈ�����</returns>
        public string GetEmployeeName(string employee)
        {
            string name = string.Empty;

            foreach (KeyValuePair<string, string> employeeData in employeeDic)
            {

                if (employeeData.Key.Trim().Equals(employee.PadLeft(4, '0')))
                {
                    name = employeeData.Value;
                    break;
                }
            }

            return name;
        }

        /// <summary>
        /// UOE�����挟��
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="sectionCode">���O�C�����_</param>
        /// <param name="msg">���b�Z�[�W</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �Ȃ��B</br>
        /// <br>Programmer : ���m</br>
        /// <br>Date       : 2009.06.01</br>
        /// </remarks>
        public int ReadInitData(string enterpriseCode, string sectionCode, ref string msg)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            outUOESupplier = new ArrayList();

            // ��������
            ArrayList uOESupplierList = new ArrayList();

            // �t�n�d������}�X�^��ǂݍ���
            status = this._uOESupplierAcs.SearchAll(out uOESupplierList, enterpriseCode, sectionCode);

            // ����̏ꍇ
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL
                || status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
            {
                foreach (UOESupplier uOESupplier in uOESupplierList)
                {
                    if ("0502".Equals(uOESupplier.CommAssemblyId) && uOESupplier.LogicalDeleteCode == 0) 
                    {
                        outUOESupplier.Add(uOESupplier);
                    }
                }
            }
            else
            {
                msg = "�z���_�t�n�d �v�d�a�擾�����s���܂��B";
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return status;
        }

        /// <summary>
        /// �X�V����
        /// </summary>
        /// <param name="errorMsg">�G���[���b�Z�[�W</param>
        /// <returns>�X�e�[�^�X</returns>
        public int SaveData(ref string errorMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

            // �����ꗗ�b�r�u�t�@�C���̎擾
            ArrayList csvFiles = new ArrayList();

            status = this.GetCSVFiles(out csvFiles, this._slipNoAlwcData.AnswerSaveFolder);

            // ����ꍇ
            if (status == 0)
            {
                // �����Ώۂ̂b�r�u�t�@�C�������݂��Ȃ��ꍇ
                if (csvFiles.Count == 0)
                {
                    return (int)ConstantManagement.MethodResult.ctFNC_WARNING;
                }

                foreach (FileInfo fileInfo in csvFiles)
                {
                    List<string[]> csvDataList;
                    // CSV���擾����
                    status = this.GetCSVData(out csvDataList, fileInfo.FullName);

                    // �擾����ꍇ
                    if (status == 0)
                    {
                        // CSV���̃t�H�[�}�b�g�`�F�b�N
                        bool ret = this.CheckCSVFormat(csvDataList);

                        // �t�H�[�}�b�g�������ꍇ
                        if (ret)
                        {
                            try
                            {
                                BuyOutLsthead buyOutLsthead = new BuyOutLsthead();

                                // CSV���
                                buyOutLsthead.CsvKnd = 0;
                                // ��ƃR�[�h
                                buyOutLsthead.EnterpriseCode = this._slipNoAlwcData.EnterpriseCode;
                                // ���_�R�[�h
                                buyOutLsthead.SectionCode = this._slipNoAlwcData.SectionCode;
                                // ������R�[�h
                                UOESupplier uoeSuppler = (UOESupplier)UOESupplierData[this._slipNoAlwcData.SupplierCode];
                                buyOutLsthead.UOESupplierCd = uoeSuppler.UOESupplierCd;
                                // �S���҃R�[�h
                                //buyOutLsthead.StockAgentCode = this._slipNoAlwcData.EmployeeCode;//DEL 2013/01/09 Redmine#33989 ����
                                buyOutLsthead.StockAgentCode = this._slipNoAlwcData.EmployeeCode.PadLeft(4, '0');//ADD 2013/01/09 Redmine#33989 ����

                                // �S���Җ���
                                buyOutLsthead.StockAgentName = this._slipNoAlwcData.EmployeeName;
                                // �����X�V
                                buyOutLsthead.CostUpdtDiv = this._slipNoAlwcData.PriceUpdateCode;
                                // �d���쐬�敪
                                buyOutLsthead.StcCreDiv = this._slipNoAlwcData.StockDataCode;
                                // �b�r�u�t�@�C����
                                buyOutLsthead.CsvName = fileInfo.Name;
                                // �b�r�u�t�@�C���o�X
                                buyOutLsthead.CsvFullPath = fileInfo.FullName;
                                // �X�V����
                                buyOutLsthead.UpdRsl = 9;

                                ArrayList buyOutDtlList = new ArrayList();
                                for (int i = 4; i < csvDataList.Count; i++)
                                {
                                    string[] data = csvDataList[i];

                                    BuyOutLstDtl buyOutLstDtl = new BuyOutLstDtl();

                                    // No
                                    if (!string.IsNullOrEmpty(data[0]))
                                    {
                                        buyOutLstDtl.No = Convert.ToInt32(data[0]);
                                    }
                                    // ��������
                                    if (!string.IsNullOrEmpty(data[1]))
                                    {
                                        buyOutLstDtl.OrderDate = Convert.ToDateTime(data[1]);
                                    }
                                    // �������
                                    if (!string.IsNullOrEmpty(data[2]))
                                    {
                                        buyOutLstDtl.BuyOutDate = Convert.ToDateTime(data[2]);
                                    }
                                    // ����
                                    buyOutLstDtl.GoodsNo = data[3];
                                    // �i��
                                    buyOutLstDtl.GoodsName = data[4];
                                    // ����
                                    if (!string.IsNullOrEmpty(data[5]))
                                    {
                                        buyOutLstDtl.ShipmentCnt = Convert.ToDouble(data[5]);
                                    }
                                    // ��]�������i
                                    if (!string.IsNullOrEmpty(data[6]))
                                    {
                                        buyOutLstDtl.AnswerListPrice = Convert.ToDouble(data[6]);
                                    }
                                    // ������P��
                                    if (!string.IsNullOrEmpty(data[7]))
                                    {
                                        buyOutLstDtl.BuyOutCost = Convert.ToDouble(data[7]);
                                    }
                                    // ������z���v
                                    if (!string.IsNullOrEmpty(data[8]))
                                    {
                                        buyOutLstDtl.BuyOutTotalCost = Convert.ToDouble(data[8]);
                                    }
                                    // �`�[�ԍ�
                                    buyOutLstDtl.BuyOutSlipNo = data[9];
                                    // �����`�[�ԍ�
                                    if (data[9].Length >= 6)
                                    {
                                        buyOutLstDtl.OrderSlipNo = data[9].Substring(0, 6);
                                    }
                                    else
                                    {
                                        buyOutLstDtl.OrderSlipNo = data[9];
                                    }
                                    // �R�����g
                                    buyOutLstDtl.Comment = data[10];

                                    buyOutDtlList.Add(buyOutLstDtl);
                                }

                                buyOutLsthead.LstDtl = buyOutDtlList;

                                // �X�V����
                                string msg = null;
                                List<BuyOutLsthead> buyOutLstheadList = new List<BuyOutLsthead>();
                                buyOutLstheadList.Add(buyOutLsthead);
                                status = this._uoeSndRcvCtlAcs.EpartsUoeWebBuyCtl(ref buyOutLstheadList, out msg);


                                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                {
                                    errorMsg = "�z���_UOE-WEB �`�[�ԍ����������Ɏ��s���܂����B";
                                    return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
                                }
                                else
                                {
                                    BuyOutLsthead resBuyOutLstHead = (BuyOutLsthead)buyOutLstheadList[0];
                                    if (resBuyOutLstHead.UpdRsl == -1)
                                    {
                                        errorMsg = "�z���_UOE-WEB �`�[�ԍ����������Ɏ��s���܂����B";
                                        return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
                                    }
                                    else if (resBuyOutLstHead.UpdRsl == 0)
                                    {
                                        // foreach (BuyOutLstDtl buyOutLstDtl in buyOutLsthead.LstDtl)
                                        foreach (BuyOutLstDtl buyOutLstDtl in resBuyOutLstHead.LstDtl)
                                        {
                                            // ��ʕ\��
                                            DataResult.SlipNoAlwcRow row = this._slipNoAlwcDataTable.NewSlipNoAlwcRow();

                                            row.SupplierDate = buyOutLstDtl.BuyOutDate.Date.ToString().Substring(0, 10);
                                            row.OrderDate = buyOutLstDtl.OrderDate.Date.ToString().Substring(0, 10);
                                            row.OldSupplierSlipNo = buyOutLstDtl.OrderSlipNo;
                                            row.SupplierSlipNo = buyOutLstDtl.BuyOutSlipNo;
                                            row.GoodsNo = buyOutLstDtl.GoodsNo;
                                            row.GoodsName = buyOutLstDtl.GoodsName;
                                            row.UpdatePrice = buyOutLstDtl.OrderCost.ToString("N0");
                                            row.Price = buyOutLstDtl.BuyOutCost.ToString("N0");
                                            row.FilesName = buyOutLsthead.CsvName;
                                            if (buyOutLstDtl.UpdRsl == 1)
                                            {
                                                row.UpdateResult = "��������";
                                            }
                                            else if (buyOutLstDtl.UpdRsl == 2)
                                            {
                                                row.UpdateResult = "�Y����";
                                            }
                                            else if (buyOutLstDtl.UpdRsl == 3)
                                            {
                                                row.UpdateResult = "���וs��v";
                                            }
                                            else if (buyOutLstDtl.UpdRsl == 9)
                                            {
                                                row.UpdateResult = "������";
                                            }
                                            else if (buyOutLstDtl.UpdRsl == 4)
                                            {
                                                row.UpdateResult = "�����X�V������";
                                            }
                                            else if (buyOutLstDtl.UpdRsl == 5)
                                            {
                                                row.UpdateResult = "�����X�V������";
                                            }
                                            else if (buyOutLstDtl.UpdRsl == 6)
                                            {
                                                row.UpdateResult = "�d���f�[�^�쐬";
                                            }
                                            else if (buyOutLstDtl.UpdRsl == 7)
                                            {
                                                row.UpdateResult = "�P���ύX";
                                            }

                                            this._slipNoAlwcDataTable.AddSlipNoAlwcRow(row);
                                        }

                                        // �t�@�C���폜
                                        this.DeleteCSVFile(fileInfo);
                                    }
                                }
                            }
                            catch
                            {
                                status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                            }
                        }
                    }
                    else
                    {
                        status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                    }
                }
            }
            else
            {
                errorMsg = "�b�r�u�捞�����Ɏ��s���܂����B";
            }

            return status;
        }

        /// <summary>
        /// CSV�t�@�C�����X�g�擾����
        /// </summary>
        /// <param name="csvFileList">CSV�t�@�C�����X�g</param>
        /// <param name="filePath">�t�@�C�����O</param>
        /// <returns>��������</returns>
        /// <remarks>
        /// <br>Note       : CSV�t�@�C�����X�g���擾��������B</br>
        /// <br>Programmer : ���m</br>
        /// <br>Date       : 2009.06.02</br>
        /// </remarks>
        private int GetCSVFiles(out ArrayList csvFileList, string filePath)
        {
            int status = 0;

            csvFileList = new ArrayList();
            try
            {
                // �t�H���_���̃t�@�C������荞
                string[] fileList = System.IO.Directory.GetFiles(filePath, "*.csv");

                foreach (string file in fileList)
                {
                    //CSVFileInfo cSVFileInfo = new CSVFileInfo();
                    FileInfo info = new FileInfo(file);
                    csvFileList.Add(info);
                }
            }
            catch
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
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
        /// <br>Programmer : ���m</br>
        /// <br>Date       : 2009.06.02</br>
        /// </remarks>
        private int GetCSVData(out List<string[]> csvDataList, string filePathName)
        {
            int status = 0;

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
                status = -1;
            }

            return status;
        }

        /// <summary>
        /// CSV���̃t�H�[�}�b�g�`�F�b�N
        /// </summary>
        /// <param name="csvDataList">CSV���</param>
        /// <returns>�`�F�b�N����</returns>
        /// <remarks>
        /// <br>Note       : CSV�����擾��������B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2009.06.02</br>
        /// </remarks>
        private bool CheckCSVFormat(List<string[]> csvDataList)
        {

            if (csvDataList.Count < 5)
            {
                return false;
            }

            // 1�s��
            string[] autoInfo1 = csvDataList[0];
            if (!autoInfo1[0].Contains("�_�E�����[�h����"))
            {
                return false;
            }

            // 2�s��
            string[] autoInfo2 = csvDataList[1];
            if (!(autoInfo2[0].Equals("�������t") && autoInfo2[1].Equals("���t����")))
            {
                return false;
            }

            // 4�s��
            string[] autoInfo4 = csvDataList[3];
            if (!(autoInfo4[0].Equals("NO") && autoInfo4[1].Equals("��������")
                && autoInfo4[2].Equals("�������") && autoInfo4[3].Equals("����")
                && autoInfo4[4].Equals("�i��")))
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// ������b�r�u�t�@�C���̍폜����
        /// </summary>
        /// <param name="fileInfo">CSV���</param>
        /// <returns>�`�F�b�N����</returns>
        /// <remarks>
        /// <br>Note       : ������b�r�u�t�@�C�����폜���܂��B</br>
        /// <br>Programmer : ���m</br>
        /// <br>Date       : 2009.06.08</br>
        /// </remarks>
        private int DeleteCSVFile(FileInfo fileInfo)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

            try
            {
                // �t�@�C�����폜
                fileInfo.Delete();
            }
            catch
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            }
            return status;
        }
        #endregion

        #region �� ���[�o�͐ݒ�擾����
        /// <summary>
        /// ���[�o�͐ݒ�Ǎ�
        /// </summary>
        /// <param name="retPrtOutSet">���[�o�͐ݒ�f�[�^�N���X</param>
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note       : �����_�̒��[�o�͐ݒ�̓Ǎ����s���܂��B</br>
        /// <br>Programmer : ���m</br>
        /// <br>Date       : 2009.04.07</br>
        /// </remarks>
        static public int ReadPrtOutSet(out PrtOutSet retPrtOutSet, out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            retPrtOutSet = new PrtOutSet();
            errMsg = string.Empty;

            try
            {
                // �f�[�^�͓Ǎ��ς݂��H
                if (stc_PrtOutSet != null)
                {
                    retPrtOutSet = stc_PrtOutSet.Clone();
                    status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                }
                else
                {
                    status = stc_PrtOutSetAcs.Read(out stc_PrtOutSet, LoginInfoAcquisition.EnterpriseCode, stc_Employee.BelongSectionCode);

                    switch (status)
                    {
                        case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                            retPrtOutSet = stc_PrtOutSet.Clone();
                            status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                            break;
                        case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                        case (int)ConstantManagement.DB_Status.ctDB_EOF:
                            status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                            break;
                        default:
                            errMsg = "���[�o�͐ݒ�̓Ǎ��Ɏ��s���܂���";
                            status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                retPrtOutSet = new PrtOutSet();
                status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            }
            return status;
        }
        #endregion
    }
}
