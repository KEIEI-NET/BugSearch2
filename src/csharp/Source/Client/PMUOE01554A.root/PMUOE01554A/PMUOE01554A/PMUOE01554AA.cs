//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �����ꗗ�X�V����
// �v���O�����T�v   : �z���_e-Parts�V�X�e�����u�������ꗗCSV�v����荞�݁A
//                    �񓚏����X�V���܂��B
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �����
// �� �� ��  2009/05/31  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �C �� ��              �C�����e : 
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ������
// �C �� ��  2011/12/02  �C�����e : Readmine 8304�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ������
// �C �� ��  2011/12/20  �C�����e : Readmine 26901�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �{�{ ����
// �C �� ��  2014/03/25  �C�����e : CSV���ڃ^�C�g���ύX
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Library.Resources;
using System.Collections;
using Broadleaf.Application.UIData;
using System.IO;
using System.Data;
using Microsoft.VisualBasic.FileIO;
using System.Globalization;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// �����ꗗ�X�V�����A�N�Z�X�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �����ꗗ�X�V�����̃A�N�Z�X������s���܂��B</br>
    /// <br>Programmer : �����</br>
    /// <br>Date       : 2009.05.31</br>
    /// <br></br>
    /// <br>Update Note: 2009/06/25 �����</br>
    /// <br>             PVCS#273�ɂ��āA�A�C�e���`�F�b�N���C�����܂��B</br>
    /// <br>Update Note: 2009/06/25 �����</br>
    /// <br>             �d�l�ύX11�ɂ��āA�����Ώۂ̖��ׂ����݃`�F�b�N��ǉ����܂��B</br>
    /// </remarks>
    public class UoeOrderAllInfoAcs
    {
        # region �v���C�x�[�g�ϐ�
        /*----------------------------------------------------------------------------------*/
        private DataTable _dataTable;
        private UOESupplierAcs _uOESupplierAcs;
        private UoeSndRcvCtlAcs _uoeSndRcvCtlAcs;
        # endregion

        # region �v���C�x�[�g�萔
        /*----------------------------------------------------------------------------------*/
        // �N��Mode
        private const int INPUT_MODE = 1;  // �����
        private const int PM_MODE = 0;  // PM�A��

        // datatable���̗p
        private const string TABLE_ID = "RESULT_TABLE";
        private const string FILENAME = "fileName"; // �t�@�C����
        private const string PROCESSNUM = "processNum"; // ����
        private const string RESULT = "result"; // ����

        // �X�V����
        private const string RESULT0 = "����I��";
        private const string RESULT1 = "�O�񐿋����Z�o�G���[";
        private const string RESULT2 = "�O�񏀔������ȑO";
        private const string RESULT3 = "�捞��";
        private const string RESULT4 = "�ُ�I��";

        // CSV����(e-Parts����͎�)
        private const string INPUTCSVTITLE_USERNAME = "���q�l��";
        private const string INPUTCSVTITLE_USERCODE = "���q�lCD";
        private const string INPUTCSVTITLE_ITEMCODE = "�A�C�e��";
        private const string INPUTCSVTITLE_ORDERDATE = "������";
        private const string INPUTCSVTITLE_ORDERTIME = "��������";
        private const string INPUTCSVTITLE_SLIPNOHEAD = "�`�[�ԍ�";
        private const string INPUTCSVTITLE_MEMO = "������";


        // CSV����(PM�A��)
        private const string PMCSVTITLE_USERNAME = "�̔��X�l��";
        private const string PMCSVTITLE_USERCODE = "�̔��X�l�R�[�h";
        private const string PMCSVTITLE_SLIPNOHEAD = "�`�[�ԍ�";
        private const string PMCSVTITLE_ORDERDATE = "������";
        private const string PMCSVTITLE_ORDERTIME = "��������";
        private const string PMCSVTITLE_ITEMCODE = "�A�C�e��";
        private const string PMCSVTITLE_MSG = "���b�Z�[�W";
        private const string PMCSVTITLE_LINKNO = "��ײݔԍ�(�A�g�ԍ�)";

        // CSV����(����)
        private const string CSVTITLE_ORDERGOODSNO = "�������i�ԍ�";
        private const string CSVTITLE_SHIPMGOODSNO = "�o�ו��i�ԍ�";
        private const string CSVTITLE_GOODSNAME = "�o�ו��i��";
        private const string CSVTITLE_SHIPMENTCNT = "��������";
        private const string CSVTITLE_ORDERREMCNT = "�����c����";
        private const string CSVTITLE_SOURCESHIPMENT = "�o�׌���";
        private const string CSVTITLE_PLANDATE = "���͗\���";
        private const string CSVTITLE_SLIPNODTL = "�`�[�ԍ�";
        // --- UPD 2014/03/25 T.Miyamoto ------------------------------>>>>>
        //private const string CSVTITLE_ANSWERLISTPRICE = "��]�������i";
        //private const string CSVTITLE_ANSWERSALESUNITCOST = "�d���ꉿ�i";
        private const string CSVTITLE_ANSWERLISTPRICE = "��]�����P��";
        private const string CSVTITLE_ANSWERSALESUNITCOST = "�d����P��";
        // --- UPD 2014/03/25 T.Miyamoto ------------------------------<<<<<
        private const string CSVTITLE_MEMO = "������";

        private const string SUCCESS_INFO = "�_�E�����[�h����";

        # endregion

        # region -- �R���X�g���N�^ --
        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : �I�t���C���Ή�</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2009.05.31</br>
        /// </remarks>
        public UoeOrderAllInfoAcs()
        {
            this._uOESupplierAcs = new UOESupplierAcs();

            // �f�[�^�Z�b�g����\�z����
            this.DataTableColumnConstruction();
        }
        # endregion

        # region -- �m�菈�� --
        /// <summary>
        /// �m�菈��
        /// </summary>
        /// <param name="uOESupplierInfo">��ʏ��</param>
        /// <param name="errMessage">���b�Z�[�W</param>
        /// <returns>�`�F�b�N���ʁB�@0�F����G�@-1�F�ُ�</returns>
        /// <remarks>
        /// <br>Note       : CSV�����擾��������B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2009.06.02</br>
        /// </remarks>
        public int DoConfirm(UOESupplierInfo uOESupplierInfo, out string errMessage)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            errMessage = string.Empty;

            this._dataTable.Clear();

            // �����ꗗ�b�r�u�t�@�C���̎擾
            ArrayList csvFiles = new ArrayList();

            status = this.GetCSVFiles(out csvFiles, uOESupplierInfo.AnswerSaveFolder);

            // ����ꍇ
            if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {
                // �����Ώۂ̂b�r�u�t�@�C�������݂��Ȃ��ꍇ
                if (csvFiles.Count == 0)
                {
                    errMessage = "�����ꗗ�b�r�u�t�@�C�������݂��܂���B";
                    return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
                }

                // �����Ώۂ̖��ׂ����݂��邩�ǂ���
                bool isHaveDetail = false;
                foreach (FileInfo fileInfo in csvFiles)
                {
                    List<string[]> csvDataList;
                    // CSV���擾����
                    status = this.GetCSVData(out csvDataList, fileInfo.FullName);

                    // �擾����ꍇ
                    if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                    {
                        // CSV���̃t�H�[�}�b�g�`�F�b�N
                        int csvKind = PM_MODE;
                        bool ret = this.CheckCSVFormat(csvDataList, ref csvKind);

                        // �t�H�[�}�b�g�������ꍇ
                        if (ret)
                        {
                            List<OrderLsthead> list = new List<OrderLsthead>();
                            OrderLsthead orderLsthead = new OrderLsthead();

                            ArrayList lstDtl = new ArrayList();
                            // �����ꗗ���ׂ̏���
                            if (csvKind == INPUT_MODE)
                            {
                                // �����ꗗ���ׁi����́j�̏���
                                status = this.GetOrderInputDetail(ref lstDtl, csvDataList, uOESupplierInfo, ref errMessage);
                                // �ُ�ꍇ
                                if (status == (int)ConstantManagement.MethodResult.ctFNC_ERROR)
                                {
                                    return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
                                }
                                // �A�C�e���͖�肪����ꍇ
                                else if (status == (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN)
                                {
                                    status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                                    continue;
                                }
                            }
                            else
                            {
                                // �����ꗗ���ׁiPM�A���j�̏���
                                status = this.GetOrderPMDetail(ref lstDtl, csvDataList, uOESupplierInfo, ref errMessage);
                                // �ُ�ꍇ
                                if (status == (int)ConstantManagement.MethodResult.ctFNC_ERROR)
                                {
                                    return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
                                }
                                // �A�C�e���͖�肪����ꍇ
                                else if (status == (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN)
                                {
                                    status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                                    continue;
                                }
                            }

                            // �����Ώۂ̖��ׂ����݂��܂��B
                            isHaveDetail = true;

                            // �b�r�u���
                            orderLsthead.CsvKnd = csvKind;
                            // �b�r�u�t�@�C����
                            orderLsthead.CsvName = fileInfo.Name;
                            // �b�r�u�t���p�X��
                            orderLsthead.CsvFullPath = fileInfo.FullName;
                            // �����ꗗ���׃N���X
                            orderLsthead.LstDtl = lstDtl;
                            // ��ƃR�[�h
                            orderLsthead.EnterpriseCode = uOESupplierInfo.EnterpriseCode;
                            // ���_�R�[�h
                            orderLsthead.SectionCode = uOESupplierInfo.SectionCode;
                            // UOE������R�[�h
                            orderLsthead.UOESupplierCd = uOESupplierInfo.UOESupplierCd;
                            // �X�V����							
                            orderLsthead.UpdRsl = 9;

                            list.Add(orderLsthead);

                            // �񓚃f�[�^�̍X�V����
                            status = this.DoUpdate(ref list, ref errMessage);
                            // ����
                            if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                            {
                                // �X�V���ʂ��u0:����I���v�ꍇ
                                if (list[0].UpdRsl == 0)
                                {
                                    // �����ꗗ�b�r�u�t�@�C���̍폜����
                                    status = this.DeleteCSVFile(fileInfo);
                                }
                            }
                            // �ُ�
                            else
                            {
                                errMessage = "�z���_UOE-WEB�񓚃f�[�^�̍X�V�����Ɏ��s���܂����B";
                                return (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
                            }
                        }
                    }
                }

                // --- ADD 2009/06/25 ------------------------------->>>>>
                // �����Ώۂ̖��ׂ����݂��Ȃ��ꍇ�A�G���[�Ƃ��܂��B
                if (!isHaveDetail)
                {
                    errMessage = "�����ꗗ�b�r�u�����݂��܂���B";
                    return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
                }
                // --- ADD 2009/06/25 ------------------------------<<<<<
            }
            else
            {
                errMessage = "�b�r�u�t�@�C���̎擾�Ɏ��s���܂����B";
                return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }

            return (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
        }

        /// <summary>
        /// CSV�t�@�C�����X�g�擾����
        /// </summary>
        /// <param name="csvFileList">CSV�t�@�C�����X�g</param>
        /// <param name="filePath">�t�@�C�����O</param>
        /// <returns>��������</returns>
        /// <remarks>
        /// <br>Note       : CSV�t�@�C�����X�g���擾��������B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2009.06.02</br>
        /// </remarks>
        private int GetCSVFiles(out ArrayList csvFileList, string filePath)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

            csvFileList = new ArrayList();
            try
            {                
                // �t�H���_���̃t�@�C������荞
                string[] fileList = System.IO.Directory.GetFiles(filePath, "*.csv");                
                //--------ADD BY ������ on 2011/12/02 for Redmine#8304 ---------->>>>>>>>>>>>> 
                string dateFormat = "yyyyMMddHHmmss";
                DateTime dt = DateTime.Now;
                string bakFileName  = string.Empty;
                //------ADD BY ������ on 2011/12/20 for Redmine#26901------>>>>>
                if (!Directory.Exists(filePath + "\\" + "BAK") && fileList.Length > 0)
                {
                    Directory.CreateDirectory(filePath + "\\" + "BAK");
                }
                //------ADD BY ������ on 2011/12/20 for Redmine#26901------<<<<<
                //------DEL BY ������ on 2011/12/20 for Redmine#26901------>>>>>
                //foreach (string file in fileList)
                //{
                //    bakFileName = file.Substring(0, file.Length - 4) + "_" + dt.ToString(dateFormat) + ".csv";
                //    File.Copy(file, bakFileName);
                //}
                //string[] bakFileList = System.IO.Directory.GetFiles(filePath, "*_"+dt.ToString(dateFormat)+".csv");
                //------DEL BY ������ on 2011/12/20 for Redmine#26901------>>>>>
                //--------ADD BY ������ on 2011/12/02 for Redmine#8304 ----------<<<<<<<<<<<<<
                foreach (string file in fileList) 
                {
                    //------ADD BY ������ on 2011/12/20 for Redmine#26901------>>>>>
                    string subFile = file.Substring(0, file.Length - 4);
                    bakFileName = subFile.Substring(filePath.Length + 1) + "_" + dt.ToString(dateFormat) + ".csv";
                    File.Copy(file, filePath + "\\" + "BAK" + "\\" + bakFileName);
                    //------ADD BY ������ on 2011/12/20 for Redmine#26901------<<<<<
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
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2009.06.02</br>
        /// </remarks>
        private int GetCSVData(out List<string[]> csvDataList, string filePathName)
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
        /// CSV���̃t�H�[�}�b�g�`�F�b�N
        /// </summary>
        /// <param name="csvDataList">CSV���</param>
        /// <param name="csvKind">�b�r�u���</param>
        /// <returns>�`�F�b�N����</returns>
        /// <remarks>
        /// <br>Note       : CSV�����擾��������B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2009.06.02</br>
        /// </remarks>
        private bool CheckCSVFormat(List<string[]> csvDataList, ref int csvKind)
        {
            if (csvDataList.Count < 5)
            {
                return false;
            }

            // 1�s��
            string[] csvInfo1 = csvDataList[0];

            // 1�s�ڂ�"�_�E�����[�h����"������
            if (!csvInfo1[0].Contains(SUCCESS_INFO))
            {
                return false;
            }

            // 2�s��
            string[] csvInfo2 = csvDataList[1];
            // 4�s��
            string[] csvInfo4 = csvDataList[3];

            // �uPM�A�����v
            if (csvInfo2[0].Equals(PMCSVTITLE_USERNAME)
                && csvInfo2[1].Equals(PMCSVTITLE_USERCODE)
                && csvInfo4[0].Equals(PMCSVTITLE_SLIPNOHEAD)
                && csvInfo4[1].Equals(PMCSVTITLE_ORDERDATE)
                && csvInfo4[2].Equals(PMCSVTITLE_ORDERTIME)
                && csvInfo4[3].Equals(PMCSVTITLE_ITEMCODE)
                && csvInfo4[4].Equals(PMCSVTITLE_MSG)
                && csvInfo4[5].Equals(PMCSVTITLE_LINKNO))
            {
                csvKind = PM_MODE;
                return true;
            }
            // �ue-Parts����͎��v
            else if (csvInfo2[0].Equals(INPUTCSVTITLE_USERNAME)
                     && csvInfo2[1].Equals(INPUTCSVTITLE_USERCODE)
                     && csvInfo2[2].Equals(INPUTCSVTITLE_ITEMCODE)
                     && csvInfo2[3].Equals(INPUTCSVTITLE_ORDERDATE)
                     && csvInfo2[4].Equals(INPUTCSVTITLE_ORDERTIME)
                     && csvInfo2[5].Equals(INPUTCSVTITLE_SLIPNOHEAD)
                     && csvInfo2[6].Equals(INPUTCSVTITLE_MEMO))
            {
                csvKind = INPUT_MODE;
                return true;
            }
            else
            {
                return false;
            }
        }


        // --- DEL 2009/06/25 ------------------------------->>>>>
        ///// <summary>
        ///// UOE�A�C�e���̃`�F�b�N����
        ///// </summary>
        ///// <param name="uOESupplierInfo">��ʏ��</param>
        ///// <param name="uOEItemCd">�����ꗗ���׃N���X���A�C�e�������ڒl</param>
        ///// <returns>�`�F�b�N���� 0:����  1:�Ȃ�  2:����  3:�قȂ�</returns>
        ///// <remarks>
        ///// <br>Note       : UOE������R�[�h�̎Z�o��������B</br>
        ///// <br>Programmer : �����</br>
        ///// <br>Date       : 2009.06.02</br>
        ///// </remarks>
        //private int CheckuUOEItemCd(UOESupplierInfo uOESupplierInfo, string uOEItemCd)
        //{
        //    int status = 0;

        //    ArrayList list;

        //    // ������̎Z�o
        //    status = this.GetUOESupplier(out list, uOESupplierInfo.EnterpriseCode, uOESupplierInfo.SectionCode);

        //    // ���ʂ̏���
        //    int num = 0;
        //    UOESupplier checkUOESupplier = new UOESupplier();
        //    foreach (UOESupplier uOESupplier in list)
        //    {
        //        if (uOESupplier.UOEItemCd.Equals(uOEItemCd))
        //        {
        //            num++;
        //            checkUOESupplier = uOESupplier;
        //        }
        //    }

        //    // UOE������}�X�^���Y�����Ȃ��ꍇ
        //    if (num == 0)
        //    {
        //        status = 1;
        //    }
        //    // ������UOE������}�X�^���Y������ꍇ
        //    else if (num > 1)
        //    {
        //        status = 2;
        //    }
        //    else
        //    {
        //        // �قȂ�ꍇ
        //        if (checkUOESupplier.UOESupplierCd != uOESupplierInfo.UOESupplierCd)
        //        {
        //            status = 3;
        //        }
        //    }

        //    return status;
        //}
        // --- DEL 2009/06/25 ------------------------------<<<<<

        /// <summary>
        /// �����ꗗ���ׁi����́j�̏���
        /// </summary>
        /// <param name="lstDtl">��������</param>
        /// <param name="csvDataList">CSV���</param>
        /// <param name="uOESupplierInfo">��ʂ̏��</param>
        /// <param name="msg">�G���[���b�Z�[�W</param>
        /// <remarks>
        /// <br>Note       : �����ꗗ���ׁi����́j�̏�������B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2009.06.02</br>
        /// </remarks>
        private int GetOrderInputDetail(ref ArrayList lstDtl, List<string[]> csvDataList, UOESupplierInfo uOESupplierInfo, ref string msg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            try
            {
                // �w�b�_Info
                string[] headInfo = csvDataList[2];

                for (int row = 1; row < csvDataList.Count; row++)
                {
                    string[] detailInfo = csvDataList[row];

                    // �u���b�N����
                    if (detailInfo[0] == INPUTCSVTITLE_USERNAME)
                    {
                        // ���׃`�F�b�N
                        string[] detailTitle = csvDataList[row + 2];
                        if (!(detailTitle[0] == CSVTITLE_ORDERGOODSNO
                            && detailTitle[1] == CSVTITLE_SHIPMGOODSNO
                            && detailTitle[2] == CSVTITLE_GOODSNAME
                            && detailTitle[3] == CSVTITLE_SHIPMENTCNT
                            && detailTitle[4] == CSVTITLE_ORDERREMCNT
                            && detailTitle[5] == CSVTITLE_ANSWERLISTPRICE
                            && detailTitle[6] == CSVTITLE_SOURCESHIPMENT
                            && detailTitle[7] == CSVTITLE_PLANDATE
                            && detailTitle[8] == CSVTITLE_SLIPNODTL
                            && detailTitle[9] == CSVTITLE_ANSWERSALESUNITCOST))
                        {
                            return (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                        }

                        headInfo = csvDataList[row + 1];

                        // --- DEL 2009/06/25 ------------------------------->>>>>
                        //// UOE�A�C�e���̃`�F�b�N����
                        //status = this.CheckuUOEItemCd(uOESupplierInfo, headInfo[2]);

                        //switch (status)
                        //{
                        //    // ����ꍇ
                        //    case 0:
                        //        break;
                        //    // �Y�����Ȃ��ꍇ
                        //    case 1:
                        //        msg = "UOE������}�X�^�ɊY���̃A�C�e�������݂��܂���B\n<" + headInfo[2] + ">";
                        //        return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
                        //    // ����
                        //    case 2:
                        //        msg = "UOE������}�X�^�ɓ����A�C�e�����������݂��܂��B\n<" + headInfo[2] + ">";
                        //        return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
                        //    // �قȂ�ꍇ
                        //    case 3:
                        //        return (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                        //}
                        // --- DEL 2009/06/25 ------------------------------<<<<<

                        // --- ADD 2009/06/25 ------------------------------->>>>>
                        // �A�C�e���̃`�F�b�N�Ɋւ���
                        // ��ʓ��͍��ڂ�UOE��������Z�o�����A�C�e���ƁA�b�r�u�t�@�C���̃A�C�e�����قȂ�ꍇ
                        if (!uOESupplierInfo.UOEItemCd.Equals(headInfo[2]))
                        {
                            // �ʂb�r�u�t�@�C�����������܂�
                            return (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                        }
                        // --- ADD 2009/06/25 ------------------------------<<<<<

                        row = row + 2;

                        continue;
                    }

                    OrderLstInputDtl orderLstInputDtl = new OrderLstInputDtl();

                    orderLstInputDtl.UserName = headInfo[0];  // ���q�l��
                    orderLstInputDtl.UserCode = headInfo[1];  // ���q�lCD
                    orderLstInputDtl.ItemCode = headInfo[2];  // �A�C�e��
                    orderLstInputDtl.OrderDate = this.StringToDateTime(headInfo[3]);  // ������
                    orderLstInputDtl.OrderTime = StringToInt(StringToDateTime(headInfo[4]).ToString("HHmmss"));  // ��������
                    orderLstInputDtl.SlipNoHead = headInfo[5];  // �`�[�ԍ�
                    orderLstInputDtl.Memo = headInfo[6];  // ������
                    orderLstInputDtl.OrderGoodsNo = detailInfo[0];  // �������i�ԍ�
                    orderLstInputDtl.ShipmGoodsNo = detailInfo[1];  // �o�ו��i�ԍ�
                    orderLstInputDtl.GoodsName = detailInfo[2];  // �o�ו��i��
                    orderLstInputDtl.ShipmentCnt = this.StringToDouble(detailInfo[3]);  // ��������
                    orderLstInputDtl.OrderRemCnt = this.StringToDouble(detailInfo[4]);  // �����c����
                    orderLstInputDtl.AnswerListPrice = this.StringToDouble(detailInfo[5]);  // ��]�������i
                    orderLstInputDtl.SourceShipment = detailInfo[6];  // �o�׌���
                    orderLstInputDtl.PlanDate = this.StringToDateTime(detailInfo[7]);  // ���͗\���
                    orderLstInputDtl.SlipNoDtl = detailInfo[8];  // �`�[�ԍ�
                    orderLstInputDtl.AnswerSalesUnitCost = this.StringToDouble(detailInfo[9]);  // �d���ꉿ�i

                    lstDtl.Add(orderLstInputDtl);
                }
            }
            catch
            {
                return (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
            }

            // �����Ώۂ̖��ׂ����݂��Ȃ��ꍇ
            if (lstDtl.Count == 0) status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;

            return status;
        }

        /// <summary>
        /// �����ꗗ���ׁiPM�A���j�̏���
        /// </summary>
        /// <param name="lstDtl">��������</param>
        /// <param name="csvDataList">CSV���</param>
        /// <param name="uOESupplierInfo">��ʂ̏��</param>
        /// <param name="msg">�G���[���b�Z�[�W</param>
        /// <remarks>
        /// <br>Note       : �����ꗗ���ׁiPM�A���j�̏�������B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2009.06.02</br>
        /// </remarks>
        private int GetOrderPMDetail(ref ArrayList lstDtl, List<string[]> csvDataList, UOESupplierInfo uOESupplierInfo, ref string msg)
        {
            int status = 0;

            try
            {
                // �w�b�_Info1
                string[] headInfo1 = csvDataList[2];
                // �w�b�_Info2
                string[] headInfo2 = csvDataList[4];

                for (int row = 3; row < csvDataList.Count; row++)
                {
                    string[] detailInfo = csvDataList[row];

                    // �u���b�N����
                    if (detailInfo[0] == PMCSVTITLE_SLIPNOHEAD)
                    {
                        // ���׃`�F�b�N
                        string[] detailTitle = csvDataList[row + 2];
                        if (!(detailTitle[0] == CSVTITLE_ORDERGOODSNO
                            && detailTitle[1] == CSVTITLE_SHIPMGOODSNO
                            && detailTitle[2] == CSVTITLE_GOODSNAME
                            && detailTitle[3] == CSVTITLE_SHIPMENTCNT
                            && detailTitle[4] == CSVTITLE_ORDERREMCNT
                            && detailTitle[5] == CSVTITLE_ANSWERLISTPRICE
                            && detailTitle[6] == CSVTITLE_SOURCESHIPMENT
                            && detailTitle[7] == CSVTITLE_PLANDATE
                            && detailTitle[8] == CSVTITLE_SLIPNODTL
                            && detailTitle[9] == CSVTITLE_MEMO
                            && detailTitle[10] == CSVTITLE_ANSWERSALESUNITCOST))
                        {
                            return (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                        }

                        headInfo2 = csvDataList[row + 1];

                        // --- DEL 2009/06/25 ------------------------------->>>>>
                        //// UOE�A�C�e���̃`�F�b�N����
                        //status = this.CheckuUOEItemCd(uOESupplierInfo, headInfo2[3]);

                        //switch (status)
                        //{
                        //    // ����ꍇ
                        //    case 0:
                        //        break;
                        //    // �Y�����Ȃ��ꍇ
                        //    case 1:
                        //        msg = "UOE������}�X�^�ɊY���̃A�C�e�������݂��܂���B\n<" + headInfo2[3] + ">";
                        //        return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
                        //    // ����
                        //    case 2:
                        //        msg = "UOE������}�X�^�ɓ����A�C�e�����������݂��܂��B\n<" + headInfo2[3] + ">";
                        //        return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
                        //    // �قȂ�ꍇ
                        //    case 3:
                        //        return (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                        //}
                        // --- DEL 2009/06/25 ------------------------------<<<<<

                        // --- ADD 2009/06/25 ------------------------------->>>>>
                        // �A�C�e���̃`�F�b�N�Ɋւ���
                        // ��ʓ��͍��ڂ�UOE��������Z�o�����A�C�e���ƁA�b�r�u�t�@�C���̃A�C�e�����قȂ�ꍇ
                        if (!uOESupplierInfo.UOEItemCd.Equals(headInfo2[3]))
                        {
                            // �ʂb�r�u�t�@�C�����������܂�
                            return (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                        }
                        // --- ADD 2009/06/25 ------------------------------<<<<<

                        row = row + 2;

                        continue;
                    }

                    OrderLstPmDtl orderLstPmDtl = new OrderLstPmDtl();

                    orderLstPmDtl.UserName = headInfo1[0];  // �̔��X�l��
                    orderLstPmDtl.UserCode = headInfo1[1];  // �̔��X�l�R�[�h
                    orderLstPmDtl.SlipNoHead = headInfo2[0];  // �`�[�ԍ�
                    orderLstPmDtl.OrderDate = this.StringToDateTime(headInfo2[1]);  // ������
                    orderLstPmDtl.OrderTime = StringToInt(StringToDateTime(headInfo2[2]).ToString("HHmmss"));  // ��������
                    orderLstPmDtl.ItemCode = headInfo2[3];  // �A�C�e��
                    orderLstPmDtl.Msg = headInfo2[4];  // ���b�Z�[�W
                    orderLstPmDtl.LinkNo = this.StringToInt(headInfo2[5]);// ��ײݔԍ�(�A�g�ԍ�)
                    orderLstPmDtl.OrderGoodsNo = detailInfo[0];  // �������i�ԍ�
                    orderLstPmDtl.ShipmGoodsNo = detailInfo[1];  // �o�ו��i�ԍ�
                    orderLstPmDtl.GoodsName = detailInfo[2];  // �o�ו��i��
                    orderLstPmDtl.ShipmentCnt = this.StringToDouble(detailInfo[3]);  // ��������
                    orderLstPmDtl.OrderRemCnt = this.StringToDouble(detailInfo[4]);  // �����c����

                    string retText1;
                    this.RemoveCommaPeriod(detailInfo[5], out retText1, false);
                    orderLstPmDtl.AnswerListPrice = this.StringToDouble(retText1);  // ��]�������i

                    orderLstPmDtl.SourceShipment = detailInfo[6];  // �o�׌���
                    orderLstPmDtl.PlanDate = this.StringToDateTime(detailInfo[7]);  // ���͗\���
                    orderLstPmDtl.SlipNoDtl = detailInfo[8];  // �`�[�ԍ�
                    orderLstPmDtl.Memo = detailInfo[9]; // ������

                    string retText2;
                    this.RemoveCommaPeriod(detailInfo[10], out retText2, false);
                    orderLstPmDtl.AnswerSalesUnitCost = this.StringToDouble(retText2);  // �d���ꉿ�i

                    lstDtl.Add(orderLstPmDtl);
                }
            }
            catch
            {
                return (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
            }

            // �����Ώۂ̖��ׂ����݂��Ȃ��ꍇ
            if (lstDtl.Count == 0) status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;

            return status;
        }

        /// <summary>
        /// �񓚃f�[�^�̍X�V����
        /// </summary>
        /// <param name="list">CSV���</param>
        /// <param name="msg">�G���[���b�Z�[�W</param>
        /// <returns>�`�F�b�N����</returns>
        /// <remarks>
        /// <br>Note       : �񓚃f�[�^�̍X�V��������B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2009.06.02</br>
        /// </remarks>
        private int DoUpdate(ref List<OrderLsthead> list, ref string msg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

            // ����M����A�N�Z�X�N���X
            if (this._uoeSndRcvCtlAcs == null)
            {
                this._uoeSndRcvCtlAcs = new UoeSndRcvCtlAcs();
            }

            // ����UOE Web�񓚃f�[�^�X�V���C������
            string message;
            status = this._uoeSndRcvCtlAcs.EpartsUoeWebOrderCtl(ref list, out message);

            // ����ꍇ
            if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {
                if (list[0].UpdRsl != 9)
                {
                    this.DataTableAddRow(list[0]);
                }
                if (list[0].UpdRsl == -1)
                {
                    status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
                }
            }
            // �ُ�ꍇ
            else
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
                msg = message;
            }

            return status;
        }

        /// <summary>
        /// �����ꗗ�b�r�u�t�@�C���̍폜����
        /// </summary>
        /// <param name="fileInfo">CSV���</param>
        /// <returns>�`�F�b�N����</returns>
        /// <remarks>
        /// <br>Note       : �����ꗗ�b�r�u�t�@�C�����폜���܂��B</br>
        /// <br>Programmer : �����</br>
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
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            return status;
        }
        # endregion �m�菈��

        # region -- �L���b�V������ --
        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// ������̎Z�o
        /// </summary>
        /// <param name="outUOESupplierlilst">UOE������}�X�^Info</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="sectionCode">���O�C�����_</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ������̎Z�o�������s���܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2009.05.31</br>
        /// </remarks>
        public int GetUOESupplier(out ArrayList outUOESupplierlilst, string enterpriseCode, string sectionCode)
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
                    if (uOESupplier.LogicalDeleteCode == 0 && uOESupplier.CommAssemblyId == "0502")
                    {
                        outUOESupplierlilst.Add(uOESupplier);
                    }
                }
            }

            return status;
        }
        # endregion

        # region -- ������ҏW���� --
        /// <summary>
        /// �J���}�E�s���I�h�폜����
        /// </summary>
        /// <param name="targetText">�J���}�E�s���I�h�폜�O�e�L�X�g</param>
        /// <param name="retText">�J���}�E�s���I�h�폜�ς݃e�L�X�g</param>
        /// <param name="periodDelFlg">�s���I�h�폜�t���O(True:�J���}�E�s���I�h�폜  False:�J���}�폜)</param>
        /// <remarks>
        /// <br>Note	   : �Ώۂ̃e�L�X�g����J���}�E�s���I�h���폜���܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2009.06.03</br>
        /// </remarks>
        private void RemoveCommaPeriod(string targetText, out string retText, bool periodDelFlg)
        {
            retText = "";

            if (targetText == string.Empty)
            {
                return;
            }
            // �Z���l�ҏW�p�ɃJ���}�E�s���I�h�폜
            for (int i = targetText.Length - 1; i >= 0; i--)
            {
                // �J���}�E�s���I�h�폜
                if (periodDelFlg == true)
                {
                    if ((targetText[i].ToString() == ",") || (targetText[i].ToString() == "."))
                    {
                        targetText = targetText.Remove(i, 1);
                    }
                }
                // �J���}�̂ݍ폜
                else
                {
                    if (targetText[i].ToString() == ",")
                    {
                        targetText = targetText.Remove(i, 1);
                    }
                }
            }

            retText = targetText;
        }

        /// <summary>
        /// string -> int ����
        /// </summary>
        /// <param name="targetText">�����Ώۃe�L�X�g</param>
        /// <remarks>
        /// <br>Note	   : int��Ԃ��܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2009.06.03</br>
        /// </remarks>
        private double StringToDouble(string targetText)
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

        /// <summary>
        /// string -> double ����
        /// </summary>
        /// <param name="targetText">�����Ώۃe�L�X�g</param>
        /// <remarks>
        /// <br>Note	   : int��Ԃ��܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2009.06.03</br>
        /// </remarks>
        private int StringToInt(string targetText)
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
        /// string -> DateTime ����
        /// </summary>
        /// <param name="targetText">�����Ώۃe�L�X�g</param>
        /// <remarks>
        /// <br>Note	   : DateTime��Ԃ��܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2009.06.03</br>
        /// </remarks>
        private DateTime StringToDateTime(string targetText)
        {
            DateTime dt = new DateTime();

            if (string.IsNullOrEmpty(targetText)) return dt;

            try
            {
                dt = Convert.ToDateTime(targetText);
            }
            catch
            {
                dt = DateTime.MinValue;
            }

            return dt;
        }
        # endregion

        # region -- DataTable�̏��� --
        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// ��������
        /// </summary>
        /// <value>DetailDataTable</value>
        /// <remarks>�������ʂ����擾</remarks>
        public DataTable DetailDataTable
        {
            get { return this._dataTable; }
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// �f�[�^�Z�b�g�N���A����
        /// </summary>
        /// <remarks>
        /// <br>Note       : �f�[�^�Z�b�g�N���A�������s���܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2009.06.08</br>
        /// </remarks>
        public void DataTableClear()
        {
            this._dataTable.Clear();
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// �f�[�^�Z�b�g����\�z����
        /// </summary>
        /// <remarks>
        /// <br>Note       : DataSet�̗�����\�z���܂��B�f�[�^�Z�b�g�̗��񂪃t���[���̃r���[�p�O���b�h�̗�ɂȂ�܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2009.05.31</br>
        /// </remarks>
        private void DataTableColumnConstruction()
        {
            DataTable table = new DataTable(TABLE_ID);

            // Add���s�����Ԃ��A��̕\�����ʂƂȂ�܂��B
            table.Columns.Add(FILENAME, typeof(string));   // �t�@�C����
            table.Columns.Add(PROCESSNUM, typeof(string)); // ����
            table.Columns.Add(RESULT, typeof(string));     // ����

            table.Columns[FILENAME].Caption = "�t�@�C����";
            table.Columns[PROCESSNUM].Caption = "����";
            table.Columns[RESULT].Caption = "����";

            this._dataTable = table;
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// �f�[�^�Z�b�g�s��������
        /// </summary>
        /// <remarks>
        /// <br>Note       : �f�[�^�Z�b�g�s�����������s���܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2009.05.31</br>
        /// </remarks>
        private void DataTableAddRow(OrderLsthead orderLsthead)
        {
            DataRow row = this._dataTable.NewRow();

            // �t�@�C����
            row[FILENAME] = orderLsthead.CsvName;
            // ����
            if (orderLsthead.UpdRsl != -1)
            {
                row[PROCESSNUM] = orderLsthead.LstDtl.Count.ToString("###,##0") + "��";
            }
            else
            {
                row[PROCESSNUM] = "0��";
            }

            // ����
            string result = string.Empty;
            // ���ʃR�[�h���A�\�����ʂ̔���
            switch (orderLsthead.UpdRsl)
            {
                // 0:����I��
                case 0:
                    {
                        result = RESULT0;
                        break;
                    }
                //  1:�O�񐿋����Z�o�G���[ 
                case 1:
                    {
                        result = RESULT1;
                        break;
                    }
                // 2:�O�񏀔������ȑO
                case 2:
                    {
                        result = RESULT2;
                        break;
                    }
                // 3:�捞��
                case 3:
                    {
                        result = RESULT3;
                        break;
                    }
                // -1:�ُ�I��
                case -1:
                    {
                        result = RESULT4;
                        break;
                    }
                // ���̑�
                default:
                    {
                        break;
                    }

            }
            row[RESULT] = result;

            // �e�[�u��Row��ǉ�
            this._dataTable.Rows.Add(row);
        }
        # endregion
    }
}
