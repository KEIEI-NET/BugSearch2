//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ���Y�񓚃f�[�^�捞����
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
// �C �� ��  2010/03/23  �C�����e : redmine#4160�̑Ή� 
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10607734-00 �쐬�S�� : ���N�n��
// �C �� ��  2010/12/31  �C�����e : �����捞�敪�̒ǉ��ɔ����������ύX�ɂȂ邽�߁A�����̎蓮�����͎c����	�A�����捞�̏����ǉ����s���܂��B 
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10607734-01 �쐬�S�� : liyp
// �C �� ��  2011/03/01  �C�����e : ���Y�������ǉ��d�l���̑g�ݍ���
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10607734-01 �쐬�S�� : ������
// �C �� ��  2011/03/15  �C�����e : Redmine #19948�̑Ή� 
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ������
// �� �� ��  2011/12/02  �C�����e : Redmine#8304�̑Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ������
// �� �� ��  2011/12/18  �C�����e : Redmine#26901�̑Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : chenw
// �� �� ��  2013/03/07  �C�����e : 2013/04/03�z�M��
//                                  Redmine#34989�̑Ή� ���YUOEWEB�̉���(�n�o�d�m���i�Ή�)
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using Broadleaf.Library.Resources;
using System.IO;
using Broadleaf.Application.Remoting.ParamData;
using System.Data;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;
using System.Collections;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// ���YWeb-UOE�����񓚃f�[�^�̍\�z�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���YWeb-UOE�����񓚃f�[�^�̍\�z�N���X���s���܂��B</br>
    /// <br>Programmer : �����</br>
    /// <br>Date       : 2010/03/08</br>
    /// <br>UpdateNote : ����� 2010/03/18 redmine#4044,4046�ƃ\�[�X�w�E�̏C��</br>
    /// <br>Update Note: 2010/03/23 ����� redmine#4160�̑Ή�</br>
    /// <br>UpdateNote : 2010/12/31 ���N�n��</br>
    /// <br>           �@�����捞�敪�̒ǉ��ɔ����������ύX�ɂȂ邽�߁A�����̎蓮�����͎c����	�A�����捞�̏����ǉ����s���܂��B</br>
    /// <br>UpdateNpet :2011/03/01 liyp ���Y�������ǉ��d�l���̑g�ݍ���</br>
    /// <br>UpdateNpet :2011/03/15 ������ Redmine #19948�̑Ή� </br>
    /// </remarks>
    public sealed class NissanWebUOEOrderDtlInfoBuilder : UOEOrderDtlInfoBuilder
    {
        # region -- �v���C�x�[�g�ϐ� --
        /*----------------------------------------------------------------------------------*/
        private DataTable _dataTable;
        private NISSAN_H nissan_h = new NISSAN_H();
        # endregion

        # region -- �v���C�x�[�g�萔 --
        // datatable���̗p
        /// <summary>
        /// datatable����
        /// </summary>
        public static string TABLE_ID = "DETAIL_TABLE";
        /// <summary>
        /// No.
        /// </summary>
        public static string NO = "No";
        /// <summary>
        /// �i��
        /// </summary>
        public static string GOODSNO = "GoodsNo";
        /// <summary>
        /// Ұ��(�^�C�g��)	
        /// </summary>
        public static string GOODSMAKERCD = "GoodsMakerCd";
        /// <summary>
        /// �i��(�^�C�g��)	
        /// </summary>
        public static string GOODSNAME = "GoodsName";
        /// <summary>
        /// ����(�^�C�g��)	
        /// </summary>
        public static string COUNT = "Count";
        /// <summary>
        /// �񓚕i��(�^�C�g��)	
        /// </summary>
        public static string ANSWERPARTSNO = "AnswerPartsNo";
        /// <summary>
        /// �艿(�^�C�g��)	
        /// </summary>
        public static string LISTPRICE = "ListPrice";
        /// <summary>
        /// �P��(�^�C�g��)	
        /// </summary>
        public static string SALESUNITCOST = "SalesUnitCost";
        /// <summary>
        /// �R�����g(�^�C�g��)	
        /// </summary>
        public static string COMMENT = "Comment";
        /// <summary>
        /// ���_�`�[�ԍ�(�^�C�g��)	
        /// </summary>
        public static string UOESECTIONSLIPNO = "UOESectionSlipNo";
        /// <summary>
        /// �o�א�(�^�C�g��)	
        /// </summary>
        public static string UOESECTOUTGOODSCNT = "UOESectOutGoodsCnt";
        /// <summary>
        /// BO�`�[�ԍ�1(�^�C�g��)
        /// </summary>
        public static string BOSLIPNO1 = "BOSlipNo1";
        /// <summary>
        /// �o�א�(�^�C�g��)		
        /// </summary>
        public static string BOSHIPMENTCNT1 = "BOShipmentCnt1";
        /// <summary>
        /// BO�`�[�ԍ�2(�^�C�g��)	
        /// </summary>
        public static string BOSLIPNO2 = "BOSlipNo2";
        /// <summary>
        /// �o�א�(�^�C�g��)		
        /// </summary>
        public static string BOSHIPMENTCNT2 = "BOShipmentCnt2";
        /// <summary>
        /// BO�`�[�ԍ�3(�^�C�g��)	
        /// </summary>
        public static string BOSLIPNO3 = "BOSlipNo3";
        /// <summary>
        /// �o�א�(�^�C�g��)		
        /// </summary>
        public static string BOSHIPMENTCNT3 = "BOShipmentCnt3";
        /// <summary>
        /// Ұ��̫۰��(�^�C�g��)	
        /// </summary>
        public static string MAKERFOLLOWCNT = "MakerFollowCnt";
        /// <summary>
        /// BO�Ǘ��ԍ�	
        /// </summary>
        public static string BOMANAGEMENTNO = "BOManagementNo";
        /// <summary>
        /// EO������	
        /// </summary>
        public static string EOALWCCOUNT = "EOAlwcCount";

        //�w�b�h�G���[���b�Z�[�W
        private const string MSG_SZE = "���޽ �޶����װ";	// 0x13 
        private const string MSG_STT = "���޽ ò����";	// 0x17
        private const string MSG_STE = "����װ";	// 0x99
        private const string MSG_ECD = "�װ����";	// ��

        private const string COMMASSEMBLY_ID = "0203";
        private const string AUTOCOMMASSEMBLY_ID = "0204";  // ADD 2010/12/31
        private const string OPENFLAG1 = "OPEN"; // ADD chenw 2013/03/07 Redmine#34989
        private const string OPENFLAG2 = "OPEN���i"; // ADD chenw 2013/03/07 Redmine#34989
        //---ADD 2010/12/31----------------------------------------------->>>>>
        private string _enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
        private string _loginSectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;
        //�t�n�d������A�N�Z�X�N���X
        private UOESupplierAcs _uoeSupplierAcs;
        //�t�n�d������
        private List<UOESupplier> _uoeSupplier01623;
        private  int UOESupplierFlag = 0;
        //---ADD 2010/12/31-----------------------------------------------<<<<<
        # endregion

        # region -- �R���X�g���N�^ --
        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : �I�t���C���Ή�</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2010/03/08</br>
        /// <br>UpdateNote : </br>
        /// <br>UpdateNote : 2010/12/31 ���N�n��</br>
        /// <br>           �@�����捞�敪�̒ǉ��ɔ����������ύX�ɂȂ邽�߁A�����̎蓮�����͎c����	�A�����捞�̏����ǉ����s���܂��B</br>
        /// </remarks>
        //public NissanWebUOEOrderDtlInfoBuilder() // DEL 2010/03/18
        public NissanWebUOEOrderDtlInfoBuilder()
            : base() // ADD 2010/03/18
        {
            //---ADD 2010/12/31----------------------------------------------->>>>>
            this._uoeSupplierAcs = new UOESupplierAcs();
            this.CacheUOESupplier_01623();
            //---ADD 2010/12/31-----------------------------------------------<<<<<
        }
        # endregion

        # region  -- �\�z�N���X�̎��� --
        
        //---ADD 2010/12/31----------------------------------------------->>>>>
        /// <summary>
        /// �蓮�Ǝ�����Falg���
        /// </summary>
        /// <remarks>
        /// <br>Note       : �蓮�Ǝ�����Falg���</br>
        /// <br>Programmer : ���N�n��</br>
        /// <br>Date       : 2010/12/31</br>
        /// <br>UpdateNote : 2010/12/31 ���N�n��</br>
        /// <br>           �@�����捞�敪�̒ǉ��ɔ����������ύX�ɂȂ邽�߁A�����̎蓮�����͎c����	�A�����捞�̏����ǉ����s���܂��B</br>
        /// </remarks>
        public void GetSupplierFlag()
        {
            foreach (UOESupplier uoeSupplier in _uoeSupplier01623)
            {
                if (("0204").Equals(uoeSupplier.CommAssemblyId))
                {
                    UOESupplierFlag = 1;
                    break;
                }
                // --------ADD 2011/03/01 ---------------->>>>>
                if (("0203").Equals(uoeSupplier.CommAssemblyId))
                {
                    UOESupplierFlag = 2;
                    break;
                }
                if (("0205").Equals(uoeSupplier.CommAssemblyId) && uoeSupplier.InqOrdDivCd==0)
                {
                    UOESupplierFlag = 3;
                    break;
                }
                if (("0205").Equals(uoeSupplier.CommAssemblyId) && uoeSupplier.InqOrdDivCd == 1)
                {
                    UOESupplierFlag = 4;
                    break;
                }
                if (("0206").Equals(uoeSupplier.CommAssemblyId))
                {
                    UOESupplierFlag = 5;
                    break;
                }
                // --------ADD 2011/03/01 ----------------<<<<<
            }

        }
        //---ADD 2010/12/31-----------------------------------------------<<<<<

        //---ADD 2010/12/31----------------------------------------------->>>>>
        /// <summary>
        /// �t�n�d��������L���b�V�����䏈��
        /// </summary>
        /// <remarks>
        /// <br>Note       : �t�n�d��������L���b�V�����䏈�����s���܂��B</br>
        /// <br>Programmer : ���N�n��</br>
        /// <br>Date       : 2010/12/31</br>
        /// <br>UpdateNote : 2010/12/31 ���N�n��</br>
        /// <br>           �@�����捞�敪�̒ǉ��ɔ����������ύX�ɂȂ邽�߁A�����̎蓮�����͎c����	�A�����捞�̏����ǉ����s���܂��B</br>
        /// </remarks>
        public void CacheUOESupplier_01623()
        {
            _uoeSupplier01623 = new List<UOESupplier>();
            List<UOESupplier> resultList = new List<UOESupplier>();
            try
            {
                ArrayList retList;
                int status = this._uoeSupplierAcs.SearchAll(out retList, this._enterpriseCode, this._loginSectionCode.Trim());
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    foreach (UOESupplier uoeSupplier in retList)
                    {
                        if (uoeSupplier.LogicalDeleteCode == 0)
                        {
                            resultList.Add(uoeSupplier);
                        }
                    }
                }

                resultList = resultList.FindAll(delegate(UOESupplier target)
                {
                    if (UOESupplierCd == target.UOESupplierCd)
                    {
                        return (true);
                    }
                    else
                    {
                        return (false);
                    }
                });

                if (resultList != null && resultList.Count > 0)
                {
                    _uoeSupplier01623 = resultList;
                }
            }
            catch (Exception)
            {
                _uoeSupplier01623 = new List<UOESupplier>();
            }

        }
        //---ADD 2010/12/31-----------------------------------------------<<<<<
       
        /// <summary>
        /// �t�@�C�����擾����
        /// </summary>
        /// <param name="filesDataDtlList">�t�@�C�������</param>
        /// <param name="answerSaveFolder">�񓚕ۑ��t�H���_</param>
        /// <param name="errMessage">���b�Z�[�W</param>
        /// <returns>��������</returns>
        /// <remarks>
        /// <br>Note       : �t�@�C�������擾��������B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2010/03/08</br>
        /// <br>UpdateNote : ����� 2010/03/18 �\�[�X�w�E�̏C��</br>
        /// <br>UpdateNote : 2010/12/31 ���N�n��</br>
        /// <br>           �@�����捞�敪�̒ǉ��ɔ����������ύX�ɂȂ邽�߁A�����̎蓮�����͎c����	�A�����捞�̏����ǉ����s���܂��B</br>
        /// <br>UpdateNpet :2011/03/01 liyp ���Y�������ǉ��d�l���̑g�ݍ���</br>
        /// <br>UpdateNpet :2011/03/15 ������ Redmine #19948�̑Ή� </br>
        /// </remarks>
        //public override int GetFilesDate(out List<UOEOrderDtlInfo> filesDataDtlList, string answerSaveFolder, ref string errMessage) // DEL 2010/03/18
        protected override int GetFilesData(out List<UOEOrderDtlInfo> filesDataDtlList, string answerSaveFolder, ref string errMessage) // ADD 2010/03/18
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

            this._dataTable.Clear();

            CacheUOESupplier_01623(); // ADD 2010/12/31

            GetSupplierFlag();// ADD 2010/12/31
            this.SetUOESupplierFlag(UOESupplierFlag); // ADD 2011/03/15
            // �t�@�C�����
            filesDataDtlList = new List<UOEOrderDtlInfo>();

            Dictionary<string, object> uoeRemarkDic = new Dictionary<string, object>();
            FileStream fileStream = null;
            try
            {
                string filePathName = "";
                //--------ADD BY ������ on 2011/12/02 for Redmine#8304  ---------->>>>>>>>
                string timeFormat = "yyyyMMddHHmmss";
                DateTime dt = DateTime.Now;
                string bakFilePathName = string.Empty;
                //--------ADD BY ������ on 2011/12/02 for Redmine#8304  ----------<<<<<<<<
                #region HKAITO.DAT���捞
                List<UOEOrderDtlInfo> datDataDtlList = new List<UOEOrderDtlInfo>();
                //---UPD 2010/12/31----------------------------------------------->>>>>
                //if (UOESupplierFlag != 1) // DEL 2011/03/01
                //if (UOESupplierFlag == 2 && UOESupplierFlag == 3) // ADD 2011/03/01 //DEL BY ������ on 2011/12/02 for Redmine#8304
                if (UOESupplierFlag == 2 || UOESupplierFlag == 3)//ADD BY ������ on 2011/12/02 for Redmine#8304
                {
                    filePathName = answerSaveFolder + "\\HKAITO.DAT";
                    //--------ADD BY ������ on 2011/12/02 for Redmine#8304  ---------->>>>>>>>
                    if (File.Exists(filePathName))
                    {
                        bakFilePathName = answerSaveFolder + "\\HKAITO_" + dt.ToString(timeFormat) + ".DAT";
                        File.Copy(filePathName, bakFilePathName);//ADD BY ������ on 2011/12/18 for Redmine#26901
                    }
                    //File.Copy(filePathName, bakFilePathName);//DEL BY ������ on 2011/12/18 for Redmine#26901
                    //--------ADD BY ������ on 2011/12/02 for Redmine#8304  ----------<<<<<<<<
                    if (File.Exists(filePathName))
                    {
                        try
                        {
                            // HKAITO.DAT�t�@�C���g�p�����f
                            fileStream = new FileStream(filePathName, FileMode.Open, FileAccess.Read, FileShare.None);
                        }
                        catch (IOException)
                        {
                            errMessage = "�����񓚃t�@�C�����g�p���ł��B";
                            // �ُ�ꍇ
                            return (int)ConstantManagement.MethodResult.ctFNC_WARNING;
                        }

                        int recordLength = 256;
                        int num = (int)fileStream.Length / recordLength;

                        for (int i = 0; i < num; i++)
                        {
                            this.nissan_h.Clear(0x00);

                            byte[] line = new byte[recordLength];
                            fileStream.Read(line, 0, line.Length);
                            this.FromByteArray(line);
                            this.ConverDatToUOEOrderDtlInfo(ref datDataDtlList);

                            if (!uoeRemarkDic.ContainsKey(UoeCommonFnc.ToStringFromByteStrAry(nissan_h.cmto).Trim()))
                            {
                                uoeRemarkDic.Add(UoeCommonFnc.ToStringFromByteStrAry(nissan_h.cmto).Trim(), null);
                            }
                        }

                        if (fileStream != null)
                        {
                            fileStream.Close();
                        }
                    }    
                    //---UPD 2010/12/31-----------------------------------------------<<<<<
                }
                #endregion

                #region Order.csv���捞
                List<UOEOrderDtlInfo> orderDataDtlList = new List<UOEOrderDtlInfo>();
                filePathName = answerSaveFolder + "\\Order.csv";
                //--------ADD BY ������ on 2011/12/02 for Redmine#8304  ---------->>>>>>>>
                if (File.Exists(filePathName))
                {
                    bakFilePathName = answerSaveFolder + "\\Order_" + dt.ToString(timeFormat) + ".csv";
                    File.Copy(filePathName, bakFilePathName);
                }
                //--------ADD BY ������ on 2011/12/02 for Redmine#8304  ----------<<<<<<<<
                if (File.Exists(filePathName))
                {
                    try
                    {
                        // Order.csv�t�@�C���g�p�����f
                        fileStream = new FileStream(filePathName, FileMode.Open, FileAccess.Read, FileShare.None);
                    }
                    catch (IOException)
                    {
                        errMessage = "�����񓚃t�@�C�����g�p���ł��B";
                        // �ُ�ꍇ
                        return (int)ConstantManagement.MethodResult.ctFNC_WARNING;
                    }
                    finally
                    {
                        if (fileStream != null)
                        {
                            fileStream.Close();
                        }
                    }

                    List<string[]> csvDataList;
                    status = this.GetCSVData(out csvDataList, filePathName);
                    List<string[]> tempCsvDataList = new List<string[]>();//ADD 2011/03/01
                    string uoeRemark2 = "";
                    for (int row = 0; row < csvDataList.Count; row++)
                    {
                        string[] detailInfo = csvDataList[row];

                        //---UPD 2010/12/31----------------------------------------------->>>>>
                        if (UOESupplierFlag == 1 || UOESupplierFlag == 4)
                        {
                            // �w�b�_�[�F���[�U�[���
                            if (detailInfo.Length == 10)
                            {
                                uoeRemark2 = detailInfo[7].Trim(); // �R�����g1
                                continue;
                            }

                            UOEOrderDtlInfo uOEOrderDtlNissanInfo = new UOEOrderDtlInfo();

                            // �t�n�d���}�[�N�Q
                            uOEOrderDtlNissanInfo.UoeRemark2 = uoeRemark2; // �R�����g1
                            if (!this.CheckUoeRemark2(uoeRemark2))
                            {
                                continue;
                            }
                            int ret = this.ConverStringToUOEOrderDtlInfo(ref uOEOrderDtlNissanInfo, detailInfo);

                            if (ret == -1)
                            {
                                continue;
                            }

                            orderDataDtlList.Add(uOEOrderDtlNissanInfo);
                        }
                       // -------ADD 2011/03/01 -------------------->>>>>
                        else if (UOESupplierFlag == 5)//0206
                        {
                            string renKeNo = "";
                            // �w�b�_�[�F���[�U�[���
                            if (detailInfo.Length == 10)
                            {
                                if (row != 0)
                                {
                                    string[] tempDetailInfo = tempCsvDataList[tempCsvDataList.Count - 1];
                                    if (!string.IsNullOrEmpty(tempDetailInfo[0].Trim()))
                                    {
                                        //renKeNo = tempDetailInfo[0].Trim(); // DEL 2011/03/15
                                        renKeNo = tempDetailInfo[0].Trim().Replace("-",""); // ADD 2011/03/15
                                    }
                                    for (int i = 0; i < tempCsvDataList.Count - 1; i++)
                                    {
                                        UOEOrderDtlInfo uOEOrderDtlNissanInfo = new UOEOrderDtlInfo();
                                        tempDetailInfo = tempCsvDataList[i];
                                        uOEOrderDtlNissanInfo.UoeRemark2 = uoeRemark2;
                                        uOEOrderDtlNissanInfo.RenkeNo = renKeNo; // �A�g�ԍ�
                                        //if (!this.CheckUoeRemark2(renKeNo)) // DEL 2011/03/15
                                        if (!this.CheckRenKeNo(renKeNo)) // ADD 2011/03/15
                                        {
                                            continue;
                                        }
                                        int ret = this.ConverStringToUOEOrderDtlInfo(ref uOEOrderDtlNissanInfo, tempDetailInfo);
                                        if (ret == -1)
                                        {
                                            continue;
                                        }
                                        orderDataDtlList.Add(uOEOrderDtlNissanInfo);
                                    }
                                    tempCsvDataList.Clear();
                                }
                                uoeRemark2 = detailInfo[7].Trim(); // �R�����g2
                                continue;
                            }
                            tempCsvDataList.Add(detailInfo);
                            
                            if (csvDataList.Count - 1 == row)
                              {
                                  string[] tempDetailInfo = tempCsvDataList[tempCsvDataList.Count - 1];
                                  if (!string.IsNullOrEmpty(tempDetailInfo[0].Trim()))
                                  {
                                      //renKeNo = tempDetailInfo[0].Trim(); // DEL 2011/03/15
                                      renKeNo = tempDetailInfo[0].Trim().Replace("-", ""); // ADD 2011/03/15
                                  }
                                  for (int i = 0; i < tempCsvDataList.Count - 1; i++)
                                  {
                                      UOEOrderDtlInfo uOEOrderDtlNissanInfo = new UOEOrderDtlInfo();
                                      tempDetailInfo = tempCsvDataList[i];
                                      uOEOrderDtlNissanInfo.UoeRemark2 = uoeRemark2;
                                      uOEOrderDtlNissanInfo.RenkeNo = renKeNo; // // �A�g�ԍ�
                                      //if (!this.CheckUoeRemark2(renKeNo)) // DEL 2011/03/15
                                      if (!this.CheckRenKeNo(renKeNo)) // ADD 2011/03/15
                                      {
                                          continue;
                                      }
                                      int ret = this.ConverStringToUOEOrderDtlInfo(ref uOEOrderDtlNissanInfo, tempDetailInfo);
                                      if (ret == -1)
                                      {
                                          continue;
                                      }
                                      orderDataDtlList.Add(uOEOrderDtlNissanInfo);
                                  }
                                  tempCsvDataList.Clear();
                              }

                            continue;
                        }
                       // -------ADD 2011/03/01 --------------------<<<<<
                        else
                        {
                            // �w�b�_�[�F���[�U�[���
                            if (detailInfo.Length == 10)
                            {
                                // ---UPD 2011/03/01--------------->>>>>
                                //uoeRemark2 = detailInfo[6].Trim(); // �R�����g1
                                if (UOESupplierFlag == 2)
                                {
                                    uoeRemark2 = detailInfo[6].Trim(); // �R�����g1
                                }
                                else if (UOESupplierFlag == 3)
                                {
                                    uoeRemark2 = detailInfo[7].Trim(); // �R�����g2
                                }
                                else
                                {
                                    //�Ȃ��B
                                }
                                // ---UPD 2011/03/01---------------<<<<<
                                continue;
                            }

                            UOEOrderDtlInfo uOEOrderDtlNissanInfo = new UOEOrderDtlInfo();

                            // �t�n�d���}�[�N�Q
                            uOEOrderDtlNissanInfo.UoeRemark2 = uoeRemark2; // �R�����g1
                            if (!this.CheckUoeRemark2(uoeRemark2))
                            {
                                continue;
                            }
                            int ret = this.ConverStringToUOEOrderDtlInfo(ref uOEOrderDtlNissanInfo, detailInfo);

                            if (ret == -1)
                            {
                                continue;
                            }

                            orderDataDtlList.Add(uOEOrderDtlNissanInfo);
                        }
                        //---UPD 2010/12/31-----------------------------------------------<<<<<
                    }
                }
                #endregion

                #region OrderAns.csv���捞
                List<UOEOrderDtlInfo> orderAnsDataDtlList = new List<UOEOrderDtlInfo>();
                filePathName = answerSaveFolder + "\\OrderAns.csv";
                //--------ADD BY ������ on 2011/12/02 for Redmine#8304  ---------->>>>>>>>
                if (File.Exists(filePathName))
                {
                    bakFilePathName = answerSaveFolder + "\\OrderAns_" + dt.ToString(timeFormat) + ".csv";
                    File.Copy(filePathName, bakFilePathName);
                }
                //--------ADD BY ������ on 2011/12/02 for Redmine#8304  ----------<<<<<<<<
                if (File.Exists(filePathName))
                {
                    try
                    {
                        // OrderAns.csv�t�@�C���g�p�����f
                        fileStream = new FileStream(filePathName, FileMode.Open, FileAccess.Read, FileShare.None);
                    }
                    catch (IOException)
                    {
                        errMessage = "�����񓚃t�@�C�����g�p���ł��B";
                        // �ُ�ꍇ
                        return (int)ConstantManagement.MethodResult.ctFNC_WARNING;
                    }
                    finally
                    {
                        if (fileStream != null)
                        {
                            fileStream.Close();
                        }
                    }

                    List<string[]> csvDataList;
                    status = this.GetCSVData(out csvDataList, filePathName);
                    List<string[]> tempCsvDataList = new List<string[]>(); //ADD 2011/03/01
                    string uoeRemark2 = "";
                    for (int row = 0; row < csvDataList.Count; row++)
                    {
                        string[] detailInfo = csvDataList[row];

                        //---UPD 2010/12/31----------------------------------------------->>>>>
                        // ---UPD 2011/03/01------------->>>>>
                        //if (UOESupplierFlag == 1)
                        if (UOESupplierFlag == 1 || UOESupplierFlag == 4)
                        // ---UPD 2011/03/01-------------<<<<<
                        {
                            // �w�b�_�[�F���[�U�[���
                            if (detailInfo.Length == 10)
                            {
                                uoeRemark2 = detailInfo[7]; // �R�����g1
                                continue;
                            }

                            UOEOrderDtlInfo uOEOrderDtlNissanInfo = new UOEOrderDtlInfo();

                            // �t�n�d���}�[�N�Q
                            uOEOrderDtlNissanInfo.UoeRemark2 = uoeRemark2; // �R�����g1
                            if (!this.CheckUoeRemark2(uoeRemark2))
                            {
                                continue;
                            }
                            int ret = this.ConverStringToUOEOrderDtlInfo(ref uOEOrderDtlNissanInfo, detailInfo);

                            if (ret == -1)
                            {
                                continue;
                            }

                            orderAnsDataDtlList.Add(uOEOrderDtlNissanInfo);
                        }
                        // -------ADD 2011/03/01 -------------------->>>>>
                        else if (UOESupplierFlag == 5)
                        {
                            string renKeNo = "";
                            // �w�b�_�[�F���[�U�[���
                            if (detailInfo.Length == 10)
                            {
                                if (row != 0)
                                {
                                    string[] tempDetailInfo = tempCsvDataList[tempCsvDataList.Count - 1];
                                    if (!string.IsNullOrEmpty(tempDetailInfo[0].Trim()))
                                    {
                                        //renKeNo = tempDetailInfo[0].Trim(); // DEL 2011/03/15
                                        renKeNo = tempDetailInfo[0].Trim().Replace("-",""); // ADD 2011/03/15
                                    }
                                    for (int i = 0; i < tempCsvDataList.Count - 1; i++)
                                    {
                                        UOEOrderDtlInfo uOEOrderDtlNissanInfo = new UOEOrderDtlInfo();
                                        tempDetailInfo = tempCsvDataList[i];
                                        uOEOrderDtlNissanInfo.UoeRemark2 = uoeRemark2;
                                        uOEOrderDtlNissanInfo.RenkeNo = renKeNo;// �A�g�ԍ�
                                        //if (!this.CheckUoeRemark2(renKeNo)) // DEL 2011/03/15
                                        if (!this.CheckRenKeNo(renKeNo)) // ADD 2011/03/15
                                        {
                                            continue;
                                        }
                                        int ret = this.ConverStringToUOEOrderDtlInfo(ref uOEOrderDtlNissanInfo, tempDetailInfo);
                                        if (ret == -1)
                                        {
                                            continue;
                                        }
                                        orderAnsDataDtlList.Add(uOEOrderDtlNissanInfo);
                                    }
                                    tempCsvDataList.Clear();
                                }
                                uoeRemark2 = detailInfo[7].Trim(); // �R�����g2
                                continue;
                            }
                            tempCsvDataList.Add(detailInfo);

                            if (csvDataList.Count - 1 == row)
                            {
                                string[] tempDetailInfo = tempCsvDataList[tempCsvDataList.Count - 1];
                                if (!string.IsNullOrEmpty(tempDetailInfo[0].Trim()))
                                {
                                    //renKeNo = tempDetailInfo[0].Trim(); // DEL 2011/03/15
                                    renKeNo = tempDetailInfo[0].Trim().Replace("-", ""); // ADD 2011/03/15
                                }
                                for (int i = 0; i < tempCsvDataList.Count - 1; i++)
                                {
                                    UOEOrderDtlInfo uOEOrderDtlNissanInfo = new UOEOrderDtlInfo();
                                    tempDetailInfo = tempCsvDataList[i];
                                    uOEOrderDtlNissanInfo.UoeRemark2 = uoeRemark2;
                                    uOEOrderDtlNissanInfo.RenkeNo = renKeNo; // �A�g�ԍ�
                                    //if (!this.CheckUoeRemark2(renKeNo)) // DEL 2011/03/15
                                    if (!this.CheckRenKeNo(renKeNo)) // ADD 2011/03/15
                                    {
                                        continue;
                                    }
                                    int ret = this.ConverStringToUOEOrderDtlInfo(ref uOEOrderDtlNissanInfo, tempDetailInfo);
                                    if (ret == -1)
                                    {
                                        continue;
                                    }
                                    orderAnsDataDtlList.Add(uOEOrderDtlNissanInfo);
                                }
                                tempCsvDataList.Clear();
                            }
                            continue;
                        }
                        // -------ADD 2011/03/01 --------------------<<<<<
                        else
                        {
                            // �w�b�_�[�F���[�U�[���
                            if (detailInfo.Length == 10)
                            {
                                // -------UPD 2011/03/01 -------------------->>>>>
                                //uoeRemark2 = detailInfo[6]; // �R�����g1
                                if (UOESupplierFlag == 2)
                                {
                                    uoeRemark2 = detailInfo[6]; // �R�����g1
                                }
                                else if (UOESupplierFlag == 3)
                                {
                                    uoeRemark2 = detailInfo[7]; // �R�����g2
                                }
                                else
                                {
                                    //�Ȃ��B
                                }
                                // -------UPD 2011/03/01 --------------------<<<<<
                                continue;
                            }

                            UOEOrderDtlInfo uOEOrderDtlNissanInfo = new UOEOrderDtlInfo();

                            // �t�n�d���}�[�N�Q
                            uOEOrderDtlNissanInfo.UoeRemark2 = uoeRemark2; // �R�����g1
                            if (!this.CheckUoeRemark2(uoeRemark2))
                            {
                                continue;
                            }
                            int ret = this.ConverStringToUOEOrderDtlInfo(ref uOEOrderDtlNissanInfo, detailInfo);

                            if (ret == -1)
                            {
                                continue;
                            }

                            orderAnsDataDtlList.Add(uOEOrderDtlNissanInfo);
                            //---UPD 2010/12/31-----------------------------------------------<<<<<
                        }
                    }
                }
                #endregion

                filesDataDtlList = datDataDtlList;
                // ---------UPD 2011/03/01 ------------------------->>>>>
                if (UOESupplierFlag == 5)
                {
                    // Order.csv
                    foreach (UOEOrderDtlInfo orderInfo in orderDataDtlList)
                    {
                        string renkeNo = orderInfo.RenkeNo;
                        if (!uoeRemarkDic.ContainsKey(renkeNo))
                        {
                            List<UOEOrderDtlInfo> tempList = orderDataDtlList.FindAll(
                                                delegate(UOEOrderDtlInfo info)
                                                {
                                                    if (info.RenkeNo  == renkeNo)
                                                    {
                                                        return true;
                                                    }
                                                    else
                                                    {
                                                        return false;
                                                    }
                                                }
                            );

                            filesDataDtlList.AddRange(tempList);

                            uoeRemarkDic.Add(renkeNo.Trim(), null);
                        }
                    }

                    // OrderAns.csv
                    foreach (UOEOrderDtlInfo orderAnsInfo in orderAnsDataDtlList)
                    {
                        string renkeNo = orderAnsInfo.RenkeNo;
                        if (!uoeRemarkDic.ContainsKey(renkeNo))
                        {
                            List<UOEOrderDtlInfo> tempList = orderAnsDataDtlList.FindAll(
                                                delegate(UOEOrderDtlInfo info)
                                                {
                                                    if (info.RenkeNo  == renkeNo)
                                                    {
                                                        return true;
                                                    }
                                                    else
                                                    {
                                                        return false;
                                                    }
                                                }
                            );

                            filesDataDtlList.AddRange(tempList);

                            uoeRemarkDic.Add(renkeNo.Trim(), null);
                        }
                    }
                }
                else
                {
                    // Order.csv
                    foreach (UOEOrderDtlInfo orderInfo in orderDataDtlList)
                    {
                        string uoeRemark2 = orderInfo.UoeRemark2;
                        if (!uoeRemarkDic.ContainsKey(uoeRemark2))
                        {
                            List<UOEOrderDtlInfo> tempList = orderDataDtlList.FindAll(
                                                delegate(UOEOrderDtlInfo info)
                                                {
                                                    if (info.UoeRemark2 == uoeRemark2)
                                                    {
                                                        return true;
                                                    }
                                                    else
                                                    {
                                                        return false;
                                                    }
                                                }
                            );

                            filesDataDtlList.AddRange(tempList);

                            uoeRemarkDic.Add(uoeRemark2.Trim(), null);
                        }
                    }

                    // OrderAns.csv
                    foreach (UOEOrderDtlInfo orderAnsInfo in orderAnsDataDtlList)
                    {
                        string uoeRemark2 = orderAnsInfo.UoeRemark2;
                        if (!uoeRemarkDic.ContainsKey(uoeRemark2))
                        {
                            List<UOEOrderDtlInfo> tempList = orderAnsDataDtlList.FindAll(
                                                delegate(UOEOrderDtlInfo info)
                                                {
                                                    if (info.UoeRemark2 == uoeRemark2)
                                                    {
                                                        return true;
                                                    }
                                                    else
                                                    {
                                                        return false;
                                                    }
                                                }
                            );

                            filesDataDtlList.AddRange(tempList);

                            uoeRemarkDic.Add(uoeRemark2.Trim(), null);
                        }
                    }
                }
                
                // ---------UPD 2011/03/01 -------------------------<<<<<
            }
            catch
            {
                // �ُ�ꍇ
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            finally
            {
                if (fileStream != null)
                {
                    fileStream.Close();
                }
            }
            return status;
        }

        /// <summary>
        /// ���Y���������ō쐬���ꂽ�f�[�^�̍i����
        /// </summary>
        /// <param name="list">RCV���</param>
        /// <param name="remark2">���}�[�N2</param>
        /// <returns>����</returns>
        /// <remarks>
        /// <br>Note       : ���Y���������ō쐬���ꂽ�f�[�^�̍i���݁B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2010/03/08</br>
        /// <br>UpdateNote : ����� 2010/03/18 �\�[�X�w�E�̏C��</br>
        /// </remarks>
        //public override List<UOEOrderDtlWork> FilterUOEOrderDtlList(List<UOEOrderDtlWork> list, string remark2)
        protected override List<UOEOrderDtlWork> FilterUOEOrderDtlList(List<UOEOrderDtlWork> list, string remark2)
        {
            List<UOEOrderDtlWork> retList = new List<UOEOrderDtlWork>();

            // UPD 2010/12/31 ------------- >>>>>>>>>>>>>>>
            if (UOESupplierFlag == 1)
            {
                foreach (UOEOrderDtlWork work in list)
                {
                    if (work.CommAssemblyId == AUTOCOMMASSEMBLY_ID
                        && work.UoeRemark2 == remark2
                        && work.DataRecoverDiv == 0)
                    {
                        retList.Add(work);
                    }
                }
            }
            // ---UPD 2011/03/01-------------->>>>>
            //else
            //{
            //    foreach (UOEOrderDtlWork work in list)
            //    {
            //        if (work.CommAssemblyId == COMMASSEMBLY_ID
            //            && work.UoeRemark2 == remark2
            //            && work.DataRecoverDiv == 0)
            //        {
            //            retList.Add(work);
            //        }
            //    }
            //}
            else if (UOESupplierFlag == 2)
            {
                foreach (UOEOrderDtlWork work in list)
                {
                    if (work.CommAssemblyId == COMMASSEMBLY_ID
                        && work.UoeRemark2 == remark2
                        && work.DataRecoverDiv == 0)
                    {
                        retList.Add(work);
                    }
                }
            }
            else if (UOESupplierFlag == 3 || UOESupplierFlag == 4)
            {
                foreach (UOEOrderDtlWork work in list)
                {
                    if (work.CommAssemblyId == "0205"
                        && work.UoeRemark2 == remark2
                        && work.DataRecoverDiv == 0)
                    {
                        retList.Add(work);
                    }
                }
            }
            else if (UOESupplierFlag == 5)
            {
                foreach (UOEOrderDtlWork work in list)
                {
                    if (work.CommAssemblyId == "0206"
                        && work.UoeRemark2 == remark2
                        && work.DataRecoverDiv == 0)
                    {
                        retList.Add(work);
                    }
                }
            }
            // ---UPD 2011/03/01--------------<<<<<
            // UPD 2010/12/31 ------------- <<<<<<<<<<<<<

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
        /// <br>UpdateNote : liyp 2011/03/01 ���YUOE������B�Ή�</br>
        /// </remarks>
        //public override int MergeList(ref List<UOEOrderDtlWork> workList, List<UOEOrderDtlInfo> dateList) // DEL 2010/03/18
        protected override int MergeList(ref List<UOEOrderDtlWork> workList, List<UOEOrderDtlInfo> dateList) // ADD 2010/03/18
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            try
            {
                for (int i = 0; i < workList.Count; i++)
                {
                    if (i < dateList.Count)
                    {
                        // ��M���t	
                        workList[i].ReceiveDate = dateList[i].ReceiveDate;
                        //��M����
                        workList[i].ReceiveTime = dateList[i].ReceiveTime;
                        //�񓚕i��
                        workList[i].AnswerPartsNo = dateList[i].AnswerPartsNo;
                        //�񓚕i��
                        workList[i].AnswerPartsName = dateList[i].AnswerPartsName;
                        //��֕i��
                        workList[i].SubstPartsNo = dateList[i].SubstPartsNo;
                        //���_�o�ɐ�							
                        workList[i].UOESectOutGoodsCnt = dateList[i].UOESectOutGoodsCnt;
                        //BO�o�ɐ�1	
                        workList[i].BOShipmentCnt1 = dateList[i].BOShipmentCnt1;
                        //BO�o�ɐ�2							
                        workList[i].BOShipmentCnt2 = dateList[i].BOShipmentCnt2;
                        //BO�o�ɐ�3							
                        workList[i].BOShipmentCnt3 = dateList[i].BOShipmentCnt3;
                        //���[�J�[�t�H���[��							
                        workList[i].MakerFollowCnt = dateList[i].MakerFollowCnt;
                        //UOE���_�`�[�ԍ�							
                        workList[i].UOESectionSlipNo = dateList[i].UOESectionSlipNo;
                        //BO�`�[��1		
                        workList[i].BOSlipNo1 = dateList[i].BOSlipNo1;
                        //BO�`�[��2							
                        workList[i].BOSlipNo2 = dateList[i].BOSlipNo2;
                        //BO�`�[��3							
                        workList[i].BOSlipNo3 = dateList[i].BOSlipNo3;
                        // EO������
                        workList[i].EOAlwcCount = dateList[i].EOAlwcCount;
                        // BO�Ǘ��ԍ�
                        workList[i].BOManagementNo = dateList[i].BOManagementNo;
                        //�񓚒艿				
                        workList[i].AnswerListPrice = dateList[i].AnswerListPrice;
                        //�񓚌����P��							
                        workList[i].AnswerSalesUnitCost = dateList[i].AnswerSalesUnitCost;
                        // �w�ʃR�[�h
                        workList[i].PartsLayerCd = dateList[i].PartsLayerCd;
                        // �a�n��
                        workList[i].BOCount = dateList[i].BOCount;
                        //���C���G���[���b�Z�[�W	
                        workList[i].LineErrorMassage = dateList[i].LineErrorMassage;
                        // �f�[�^���M�敪
                        workList[i].DataSendCode = dateList[i].DataSendCode;
                        // -------ADD 2011/03/01 ------------------------->>>>>
                        if (UOESupplierFlag == 5)
                        {
                            // ���}�[�N2
                            workList[i].UoeRemark2 = dateList[i].UoeRemark2;
                        }
                        // -------ADD 2011/03/01 -------------------------<<<<<
                    }
                }
            }
            catch
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }

            return status;
        }

        /// <summary>
        /// �f�[�^�Z�b�g����\�z����
        /// </summary>
        /// <remarks>
        /// <br>Note       : DataSet�̗�����\�z���܂��B�f�[�^�Z�b�g�̗��񂪃t���[���̃r���[�p�O���b�h�̗�ɂȂ�܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2010/03/08</br>
        /// <br>UpdateNote : ����� 2010/03/18 �\�[�X�w�E�̏C��</br>
        /// </remarks>
        //public override void DataTableColumnConstruction() // DEL 2010/03/18
        protected override void DataTableColumnConstruction() // ADD 2010/03/18
        {
            DataTable table = new DataTable(TABLE_ID);

            // Add���s�����Ԃ��A��̕\�����ʂƂȂ�܂��B
            table.Columns.Add(NO, typeof(string));   // No.
            table.Columns.Add(GOODSNO, typeof(string)); // �i��
            table.Columns.Add(GOODSMAKERCD, typeof(Int32)); // Ұ��(�^�C�g��)				
            table.Columns.Add(GOODSNAME, typeof(string)); // �i��(�^�C�g��)	
            table.Columns.Add(COUNT, typeof(Double)); // ����(�^�C�g��)		
            table.Columns.Add(ANSWERPARTSNO, typeof(string)); // �񓚕i��(�^�C�g��)		
            table.Columns.Add(LISTPRICE, typeof(Double)); // �艿(�^�C�g��)				
            table.Columns.Add(SALESUNITCOST, typeof(Double)); // �P��(�^�C�g��)				
            table.Columns.Add(COMMENT, typeof(string)); // �R�����g(�^�C�g��)				
            table.Columns.Add(UOESECTIONSLIPNO, typeof(string)); // ���_�`�[�ԍ�(�^�C�g��)				
            table.Columns.Add(UOESECTOUTGOODSCNT, typeof(Int32)); // �o�א�(�^�C�g��)				
            table.Columns.Add(BOSLIPNO1, typeof(string)); // BO�`�[�ԍ�1(�^�C�g��)				
            table.Columns.Add(BOSHIPMENTCNT1, typeof(Int32)); // �o�א�(�^�C�g��)				
            table.Columns.Add(BOSLIPNO2, typeof(string)); // BO�`�[�ԍ�2(�^�C�g��)				
            table.Columns.Add(BOSHIPMENTCNT2, typeof(Int32)); // �o�א�(�^�C�g��)				
            table.Columns.Add(BOSLIPNO3, typeof(string)); // BO�`�[�ԍ�3(�^�C�g��)				
            table.Columns.Add(BOSHIPMENTCNT3, typeof(Int32)); // BO�Ǘ��ԍ�	
            table.Columns.Add(BOMANAGEMENTNO, typeof(string)); // �d�n	
            table.Columns.Add(EOALWCCOUNT, typeof(Int32)); // EO������
            table.Columns.Add(MAKERFOLLOWCNT, typeof(Int32)); // Ұ��̫۰��(�^�C�g��)				


            table.Columns[NO].Caption = "No.";
            table.Columns[GOODSNO].Caption = "�i��"; // �i��
            table.Columns[GOODSMAKERCD].Caption = "Ұ��"; // �i��(�^�C�g��)				
            table.Columns[GOODSNAME].Caption = "�i��"; // �i��(�^�C�g��)				
            table.Columns[COUNT].Caption = "����"; // ����(�^�C�g��)				
            table.Columns[ANSWERPARTSNO].Caption = "�񓚕i��"; // �񓚕i��(�^�C�g��)				
            table.Columns[LISTPRICE].Caption = "�艿"; // �艿(�^�C�g��)				
            table.Columns[SALESUNITCOST].Caption = "�P��"; // �P��(�^�C�g��)				
            table.Columns[COMMENT].Caption = "�R�����g"; // �R�����g(�^�C�g��)				
            table.Columns[UOESECTIONSLIPNO].Caption = "�����_"; // ���_�`�[�ԍ�(�^�C�g��)				
            table.Columns[UOESECTOUTGOODSCNT].Caption = "�o�א�"; // �o�א�(�^�C�g��)				
            table.Columns[BOSLIPNO1].Caption = "�T�u"; // BO�`�[�ԍ�1(�^�C�g��)				
            table.Columns[BOSHIPMENTCNT1].Caption = "�o�א�"; // �o�א�(�^�C�g��)				
            table.Columns[BOSLIPNO2].Caption = "���C��"; // BO�`�[�ԍ�2(�^�C�g��)				
            table.Columns[BOSHIPMENTCNT2].Caption = "�o�א�"; // �o�א�(�^�C�g��)				
            table.Columns[BOSLIPNO3].Caption = "�����_"; // BO�`�[�ԍ�3(�^�C�g��)				
            table.Columns[BOSHIPMENTCNT3].Caption = "�o�א�"; // �o�א�(�^�C�g��)
            table.Columns[BOMANAGEMENTNO].Caption = "�d�n"; // BO�Ǘ��ԍ�	
            table.Columns[EOALWCCOUNT].Caption = "�o�א�"; // EO������
            table.Columns[MAKERFOLLOWCNT].Caption = "�a�n"; // Ұ��̫۰��(�^�C�g��)	

            this._dataTable = table;
        }

        /// <summary>
        /// �f�[�^�Z�b�g�s��������
        /// </summary>
        /// <remarks>
        /// <br>Note       : �f�[�^�Z�b�g�s�����������s���܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2010/03/08</br>
        /// <br>UpdateNote : ����� 2010/03/18 �\�[�X�w�E�̏C��</br>
        /// </remarks>
        //public override void DataTableAddRow(List<UOEOrderDtlWork> workList) // DEL 2010/03/18
        protected override void DataTableAddRow(List<UOEOrderDtlWork> workList) // ADD 2010/03/18
        {
            int rowIndex = 1;
            foreach (UOEOrderDtlWork work in workList)
            {
                DataRow row = this._dataTable.NewRow();

                row[NO] = rowIndex.ToString();
                //�i��		
                row[GOODSNO] = work.GoodsNo;
                //Ұ��	
                row[GOODSMAKERCD] = work.GoodsMakerCd;
                //�i��	
                row[GOODSNAME] = work.GoodsName;
                //����
                row[COUNT] = work.AcceptAnOrderCnt;
                //�񓚕i��	
                row[ANSWERPARTSNO] = work.AnswerPartsNo;
                //�艿	
                row[LISTPRICE] = work.AnswerListPrice;
                //�P��	
                row[SALESUNITCOST] = work.AnswerSalesUnitCost;
                //�R�����g
                if (string.IsNullOrEmpty(work.HeadErrorMassage))
                {
                    row[COMMENT] = work.LineErrorMassage;
                }
                else
                {
                    row[COMMENT] = work.HeadErrorMassage;
                }
                //�����_								
                row[UOESECTIONSLIPNO] = work.UOESectionSlipNo;
                //�o�א�
                row[UOESECTOUTGOODSCNT] = work.UOESectOutGoodsCnt;
                //�T�u								
                row[BOSLIPNO1] = work.BOSlipNo1;
                //�o�א�								
                row[BOSHIPMENTCNT1] = work.BOShipmentCnt1;
                //���C��								
                row[BOSLIPNO2] = work.BOSlipNo2;
                //�o�א�								
                row[BOSHIPMENTCNT2] = work.BOShipmentCnt2;
                //�����_								
                row[BOSLIPNO3] = work.BOSlipNo3;
                //�o�א�								
                row[BOSHIPMENTCNT3] = work.BOShipmentCnt3;
                //�a�n								
                row[MAKERFOLLOWCNT] = work.MakerFollowCnt;
                //�d�n
                row[BOMANAGEMENTNO] = work.BOManagementNo;
                //�o�א�								
                row[EOALWCCOUNT] = work.EOAlwcCount;

                this._dataTable.Rows.Add(row);
                rowIndex++;
            }
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
        /// <br>Date       : 2010/03/08</br>
        /// </remarks>
        public override void DataTableClear()
        {
            this._dataTable.Clear();
        }
        #endregion

        # region -- �f�[�^�ϊ� --
        /// <summary>
        /// �o�C�g�^�z��ɕϊ�
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : �o�C�g�^�z��ɕϊ����s���B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2010/03/08</br>
        /// </remarks>
        private void FromByteArray(byte[] line)
        {
            MemoryStream ms = new MemoryStream();
            ms.Write(line, 0, line.Length);
            ms.Seek(0, SeekOrigin.Begin);

            ms.Read(nissan_h.usercd, 0, nissan_h.usercd.Length);
            ms.Read(nissan_h.otscd, 0, nissan_h.otscd.Length);
            ms.Read(nissan_h.nhkbn, 0, nissan_h.nhkbn.Length);
            ms.Read(nissan_h.isycd, 0, nissan_h.isycd.Length);
            ms.Read(nissan_h.stsec, 0, nissan_h.stsec.Length);
            ms.Read(nissan_h.bin, 0, nissan_h.bin.Length);
            ms.Read(nissan_h.cmto, 0, nissan_h.cmto.Length);
            ms.Read(nissan_h.bhnum, 0, nissan_h.bhnum.Length);
            ms.Read(nissan_h.bokbn, 0, nissan_h.bokbn.Length);
            ms.Read(nissan_h.bnnm, 0, nissan_h.bnnm.Length);
            ms.Read(nissan_h.hqsu, 0, nissan_h.hqsu.Length);
            ms.Read(nissan_h.bosbr, 0, nissan_h.bosbr.Length);
            ms.Read(nissan_h.zsec_sksu, 0, nissan_h.zsec_sksu.Length);
            ms.Read(nissan_h.zsec_nohno, 0, nissan_h.zsec_nohno.Length);
            ms.Read(nissan_h.zsec_szhs, 0, nissan_h.zsec_szhs.Length);
            ms.Read(nissan_h.zsec_szzhsu, 0, nissan_h.zsec_szzhsu.Length);
            ms.Read(nissan_h.sbst_seccd, 0, nissan_h.sbst_seccd.Length);
            ms.Read(nissan_h.sbst_sksu, 0, nissan_h.sbst_sksu.Length);
            ms.Read(nissan_h.sbst_nohno, 0, nissan_h.sbst_nohno.Length);
            ms.Read(nissan_h.sbst_szhs, 0, nissan_h.sbst_szhs.Length);
            ms.Read(nissan_h.minst_seccd, 0, nissan_h.minst_seccd.Length);
            ms.Read(nissan_h.minst_sksu, 0, nissan_h.minst_sksu.Length);
            ms.Read(nissan_h.minst_nohno, 0, nissan_h.minst_nohno.Length);
            ms.Read(nissan_h.minst_szhs, 0, nissan_h.minst_szhs.Length);
            ms.Read(nissan_h.hsec_seccd, 0, nissan_h.hsec_seccd.Length);
            ms.Read(nissan_h.hsec_sksu, 0, nissan_h.hsec_sksu.Length);
            ms.Read(nissan_h.hsec_nohno, 0, nissan_h.hsec_nohno.Length);
            ms.Read(nissan_h.htzhsu, 0, nissan_h.htzhsu.Length);
            ms.Read(nissan_h.fskusu, 0, nissan_h.fskusu.Length);
            ms.Read(nissan_h.mkeobhsu, 0, nissan_h.mkeobhsu.Length);
            ms.Read(nissan_h.eohtsu, 0, nissan_h.eohtsu.Length);
            ms.Read(nissan_h.mkbosu, 0, nissan_h.mkbosu.Length);
            ms.Read(nissan_h.ytnokbn, 0, nissan_h.ytnokbn.Length);
            ms.Read(nissan_h.ytnodate, 0, nissan_h.ytnodate.Length);
            ms.Read(nissan_h.bomno, 0, nissan_h.bomno.Length);
            ms.Read(nissan_h.zszkosu, 0, nissan_h.zszkosu.Length);
            ms.Read(nissan_h.tekiyo, 0, nissan_h.tekiyo.Length);
            ms.Read(nissan_h.skkku, 0, nissan_h.skkku.Length);
            ms.Read(nissan_h.bhsb, 0, nissan_h.bhsb.Length);
            ms.Read(nissan_h.srtb, 0, nissan_h.srtb.Length);
            ms.Read(nissan_h.srdate, 0, nissan_h.srdate.Length);
            ms.Read(nissan_h.srtime, 0, nissan_h.srtime.Length);
            ms.Read(nissan_h.cmto2, 0, nissan_h.cmto2.Length);
            ms.Read(nissan_h.smsbru, 0, nissan_h.smsbru.Length);
            ms.Read(nissan_h.htosrdate, 0, nissan_h.htosrdate.Length);
            ms.Read(nissan_h.htosrtime, 0, nissan_h.htosrtime.Length);
            ms.Read(nissan_h.szhhz, 0, nissan_h.szhhz.Length);
            ms.Read(nissan_h.zszkhz, 0, nissan_h.zszkhz.Length);
            ms.Read(nissan_h.errmkbn, 0, nissan_h.errmkbn.Length);
            ms.Read(nissan_h.errm, 0, nissan_h.errm.Length);
            ms.Read(nissan_h.bo_errmkbn, 0, nissan_h.bo_errmkbn.Length);
            ms.Read(nissan_h.bokg_num, 0, nissan_h.bokg_num.Length);
            ms.Read(nissan_h.yobi, 0, nissan_h.yobi.Length);
            ms.Read(nissan_h.mtart, 0, nissan_h.mtart.Length);

            ms.Close();
        }

        /// <summary>
        /// ���Y�����񓚃t�@�C����ں��ނ̏���
        /// </summary>
        /// <param name="datDataDtlList">ں��ރ��X�g</param>
        /// <remarks>
        /// <br>Note       : ���Y�����񓚃t�@�C����ں��ނ�����</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2010/03/08</br>
        /// </remarks>
        private void ConverDatToUOEOrderDtlInfo(ref List<UOEOrderDtlInfo> datDataDtlList)
        {
            UOEOrderDtlInfo uOEOrderDtlNissanInfo = new UOEOrderDtlInfo();

            // �t�n�d���}�[�N�Q
            uOEOrderDtlNissanInfo.UoeRemark2 = UoeCommonFnc.ToStringFromByteStrAry(nissan_h.cmto).Trim();

            // �A�gNo�`�F�b�N
            if (!this.CheckUoeRemark2(uOEOrderDtlNissanInfo.UoeRemark2))
            {
                return;
            }
            // ��M���t
            uOEOrderDtlNissanInfo.ReceiveDate = DateTime.Today;
            // ��M����
            uOEOrderDtlNissanInfo.ReceiveTime = Int32.Parse(DateTime.Now.ToString("HHmmss"));
            // �񓚕i��
            uOEOrderDtlNissanInfo.AnswerPartsNo = UoeCommonFnc.ToStringFromByteStrAry(nissan_h.bhnum);
            // �i�ԃ`�F�b�N
            if (uOEOrderDtlNissanInfo.AnswerPartsNo.Trim() == string.Empty)
            {
                return;
            }
            // �񓚕i��
            uOEOrderDtlNissanInfo.AnswerPartsName = UoeCommonFnc.ToStringFromByteStrAry(nissan_h.bnnm);
            // ��֕i��
            uOEOrderDtlNissanInfo.SubstPartsNo = this.GetSubstPartsNo(UoeCommonFnc.ToStringFromByteStrAry(nissan_h.bnnm));
            // ���_�o�ɐ�
            uOEOrderDtlNissanInfo.UOESectOutGoodsCnt = UoeCommonFnc.ToInt32FromByteStrAry(nissan_h.zsec_sksu);
            // BO�o�ɐ�1
            uOEOrderDtlNissanInfo.BOShipmentCnt1 = UoeCommonFnc.ToInt32FromByteStrAry(nissan_h.sbst_sksu);
            // BO�o�ɐ�2
            uOEOrderDtlNissanInfo.BOShipmentCnt2 = UoeCommonFnc.ToInt32FromByteStrAry(nissan_h.minst_sksu);
            // BO�o�ɐ�3
            uOEOrderDtlNissanInfo.BOShipmentCnt3 = UoeCommonFnc.ToInt32FromByteStrAry(nissan_h.hsec_sksu);
            // ���[�J�[�t�H���[��
            uOEOrderDtlNissanInfo.MakerFollowCnt = UoeCommonFnc.ToInt32FromByteStrAry(nissan_h.mkbosu);
            // UOE���_�`�[�ԍ�
            uOEOrderDtlNissanInfo.UOESectionSlipNo = UoeCommonFnc.ToStringFromByteStrAry(nissan_h.zsec_nohno);
            // BO�`�[��1
            uOEOrderDtlNissanInfo.BOSlipNo1 = UoeCommonFnc.ToStringFromByteStrAry(nissan_h.sbst_nohno);
            // BO�`�[��2
            uOEOrderDtlNissanInfo.BOSlipNo2 = UoeCommonFnc.ToStringFromByteStrAry(nissan_h.minst_nohno);
            // BO�`�[��3
            uOEOrderDtlNissanInfo.BOSlipNo3 = UoeCommonFnc.ToStringFromByteStrAry(nissan_h.hsec_nohno);
            // EO������
            uOEOrderDtlNissanInfo.EOAlwcCount = UoeCommonFnc.ToInt32FromByteStrAry(nissan_h.eohtsu);
            // BO�Ǘ��ԍ�
            uOEOrderDtlNissanInfo.BOManagementNo = UoeCommonFnc.ToStringFromByteStrAry(nissan_h.bomno);
            // �񓚒艿
            uOEOrderDtlNissanInfo.AnswerListPrice = UoeCommonFnc.ToDoubleFromByteStrAry(nissan_h.tekiyo);
            // �񓚌����P��
            uOEOrderDtlNissanInfo.AnswerSalesUnitCost = UoeCommonFnc.ToDoubleFromByteStrAry(nissan_h.skkku);
            // �w�ʃR�[�h
            uOEOrderDtlNissanInfo.PartsLayerCd = UoeCommonFnc.ToStringFromByteStrAry(nissan_h.bhsb);
            // �a�n��
            uOEOrderDtlNissanInfo.BOCount = UoeCommonFnc.ToInt32FromByteStrAry(nissan_h.bokg_num);
            // ���C���G���[���b�Z�[�W
            uOEOrderDtlNissanInfo.LineErrorMassage = UoeCommonFnc.ToStringFromByteStrAry(nissan_h.errm);
            // �f�[�^���M�敪
            uOEOrderDtlNissanInfo.DataSendCode = 5;

            datDataDtlList.Add(uOEOrderDtlNissanInfo);
        }

        /// <summary>
        /// ���Y�����񓚃t�@�C����ں��ނ̏���
        /// </summary>
        /// <param name="uOEOrderDtlNissanInfo">�����񓚃f�[�^</param>
        /// <param name="detailInfo">CSV��line�f�[�^</param>
        /// <remarks>
        /// <br>Note       : ���Y�����񓚃t�@�C����ں��ނ�����</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2010/03/08</br>
        /// </remarks>
        private int ConverStringToUOEOrderDtlInfo(ref UOEOrderDtlInfo uOEOrderDtlNissanInfo, string[] detailInfo)
        {
            // ��M���t
            uOEOrderDtlNissanInfo.ReceiveDate = DateTime.Today; // �V�X�e�����t
            // ��M����
            uOEOrderDtlNissanInfo.ReceiveTime = Int32.Parse(DateTime.Now.ToString("HHmmss")); // �V�X�e������
            // �񓚕i��
            uOEOrderDtlNissanInfo.AnswerPartsNo = this.GetPartsNo(detailInfo[0]);  // ���i�ԍ�
            if (uOEOrderDtlNissanInfo.AnswerPartsNo.Trim() == string.Empty)
            {
                return -1;
            }
            // �񓚕i��
            uOEOrderDtlNissanInfo.AnswerPartsName = detailInfo[8]; // ���i����
            // ��֕i��
            uOEOrderDtlNissanInfo.SubstPartsNo = this.GetSubstPartsNo(detailInfo[8]);   // ���i���̂�4�޲Ėڂ���@��1
            // ���_�o�ɐ�
            uOEOrderDtlNissanInfo.UOESectOutGoodsCnt = this.GetUOESectOutGoodsCnt(detailInfo[5]); // �o�ɐ��i�����_�j
            // BO�o�ɐ�1
            uOEOrderDtlNissanInfo.BOShipmentCnt1 = this.GetBOShipmentCnt(detailInfo[12]);  // �o�ɐ��i�T�u�Z���^�[�j
            // BO�o�ɐ�2
            uOEOrderDtlNissanInfo.BOShipmentCnt2 = this.GetBOShipmentCnt(detailInfo[20]);  // �o�ɐ��i���C���Z���^�[�j
            // BO�o�ɐ�2
            uOEOrderDtlNissanInfo.BOShipmentCnt3 = this.GetBOShipmentCnt(detailInfo[24]);  // �o�ɐ��i�����_�j
            // ���[�J�[�t�H���[��
            uOEOrderDtlNissanInfo.MakerFollowCnt = this.GetMakerFollowCnt(detailInfo[9]);  // ���[�J�[BO
            // UOE���_�`�[�ԍ�
            uOEOrderDtlNissanInfo.UOESectionSlipNo = detailInfo[6]; // �[�i��No�i�����_�j
            // BO�`�[��1
            uOEOrderDtlNissanInfo.BOSlipNo1 = detailInfo[13]; // �[�i��No�i�T�u�Z���^�[�j
            // BO�`�[��1
            uOEOrderDtlNissanInfo.BOSlipNo2 = detailInfo[21]; // �[�i��No�i���C���Z���^�[�j
            // BO�`�[��1
            uOEOrderDtlNissanInfo.BOSlipNo3 = detailInfo[25]; //  �[�i��No�i�����_�j
            // EO������
            uOEOrderDtlNissanInfo.EOAlwcCount = this.StringToInt(detailInfo[4]); // EO��������
            // BO�Ǘ��ԍ�
            uOEOrderDtlNissanInfo.BOManagementNo = detailInfo[16];// BO�Ǘ�No
            // �񓚒艿
            uOEOrderDtlNissanInfo.AnswerListPrice = this.StringToDouble(this.RemoveComma(detailInfo[10]));// �E�v
            // �񓚌����P��
            uOEOrderDtlNissanInfo.AnswerSalesUnitCost = this.StringToDouble(this.RemoveComma(detailInfo[3]));// �d��
            // �a�n��
            uOEOrderDtlNissanInfo.BOCount = this.GetBONum(detailInfo[2]);// B/O��
            // �f�[�^���M�敪
            uOEOrderDtlNissanInfo.DataSendCode = 5;// 5:�񓚖���
            // ---- ADD chenw 2013/03/07 Redmine#34989 ------------->>>>>
            // ���C���G���[���b�Z�[�W
            if (OPENFLAG1.Equals(detailInfo[10].Trim()))
            {
                uOEOrderDtlNissanInfo.LineErrorMassage = OPENFLAG2;
            }
            // ---- ADD chenw 2013/03/07 Redmine#34989 -------------<<<<<

            return 0;
        }
        #endregion

        # region -- �f�[�^�̏��� --
        /// <summary>
        /// �i�Ԃ̏���
        /// </summary>
        /// <param name="filePartsNo">���i�ԍ��P�Q���{�n�C�t���~�Q</param>
        /// <returns>�i��</returns>
        /// <remarks>
        /// <br>Note       : �i�Ԃ̏������s��</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2010/03/08</br>
        /// </remarks>
        private string GetPartsNo(string filePartsNo)
        {
            if (string.IsNullOrEmpty(filePartsNo))
            {
                return "";
            }

            if (filePartsNo.Length > 12)
            {
                return filePartsNo.Substring(0, 12);
            }
            else
            {
                return filePartsNo;
            }
        }

        /// <summary>
        /// ��֕i�Ԃ̐ݒ菈��
        /// </summary>
        /// <param name="partsNo">����</param>
        /// <returns>��֕i��</returns>
        /// <remarks>
        /// <br>Note       : ��֕i�Ԃ̐ݒ菈�����s��</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2010/03/08</br>
        /// <br>Update Note: 2010/03/23 ����� redmine#4160�̑Ή�</br>
        /// </remarks>
        private string GetSubstPartsNo(string partsNo)
        {
            // �������ް��́u���i���́v�̏�3����"F2��"����"F5��"�̏ꍇ
            // ��������"B2��"����"B5��"�̏ꍇ�͕i����4�޲Ėڈȍ~���
            // --- UPD 2010/03/23 ---------->>>>>
            //if (("F2 ".CompareTo(partsNo) < 0 && "F5 ".CompareTo(partsNo) > 0)
            //    || ("B2 ".CompareTo(partsNo) < 0 && "B5 ".CompareTo(partsNo) > 0))
            
            //{
            //    return partsNo.Substring(3);
            //}

            if (!string.IsNullOrEmpty(partsNo) && partsNo.Length >= 3)
            {
                string substPartsNo = partsNo.Substring(0, 3);

                if (("F2 ".Equals(substPartsNo)) || ("F3 ".Equals(substPartsNo)) || ("F4 ".Equals(substPartsNo))
                    || ("F5 ".Equals(substPartsNo)) || ("B2 ".Equals(substPartsNo)) || ("B3 ".Equals(substPartsNo))
                    || ("B4 ".Equals(substPartsNo)) || ("B5 ".Equals(substPartsNo)))
                {
                    return partsNo.Substring(3);
                }
            }
            // --- UPD 2010/03/23 ----------<<<<<

            return string.Empty;
        }

        /// <summary>
        /// B/O���̏���
        /// </summary>
        /// <param name="fileBONum">*-ZZZ (BO�敪�{"-"�{BO��)</param>
        /// <returns>B/O��</returns>
        /// <remarks>
        /// <br>Note       : �i�Ԃ̏������s��</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2010/03/08</br>
        /// </remarks>
        private int GetBONum(string fileBONum)
        {
            if (string.IsNullOrEmpty(fileBONum))
            {
                return 0;
            }

            int indexStr = fileBONum.IndexOf("-");

            return this.StringToInt(fileBONum.Substring(indexStr + 1));
        }

        /// <summary>
        /// �J���}�폜����
        /// </summary>
        /// <param name="targetText">�J���}�폜�O�e�L�X�g</param>
        /// <remarks>
        /// <br>Note	   : �Ώۂ̃e�L�X�g����J���}���폜���܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2010/03/08</br>
        /// </remarks>
        private string RemoveComma(string targetText)
        {
            if (string.IsNullOrEmpty(targetText))
            {
                return "";
            }
            // �Z���l�ҏW�p�ɃJ���}�E�s���I�h�폜
            for (int i = targetText.Length - 1; i >= 0; i--)
            {
                // �J���}�̂ݍ폜
                if (targetText[i].ToString() == ",")
                {
                    targetText = targetText.Remove(i, 1);
                }
            }

            return targetText;
        }

        /// <summary>
        /// �o�ɐ�(�����_)�̏���
        /// </summary>
        /// <param name="fileUOESectOutGoodsCnt">��:ZZZ ("��:"�{�o�ɐ�)</param>
        /// <returns>�o�ɐ�(�����_)</returns>
        /// <remarks>
        /// <br>Note       : �o�ɐ�(�����_)�̏������s��</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2010/03/08</br>
        /// <br>UpdateNote : ����� 2010/03/18 redmine#4044�̏C��</br>
        /// </remarks>
        private int GetUOESectOutGoodsCnt(string fileUOESectOutGoodsCnt)
        {
            if (string.IsNullOrEmpty(fileUOESectOutGoodsCnt))
            {
                return 0;
            }

            // --- UPD 2010/03/18 ---------->>>>>
            //return this.StringToInt(fileUOESectOutGoodsCnt.Substring(2));
            int indexStr = fileUOESectOutGoodsCnt.IndexOf(":");

            return this.StringToInt(fileUOESectOutGoodsCnt.Substring(indexStr + 1));
            // --- UPD 2010/03/18 ----------<<<<<
        }

        /// <summary>
        /// ���[�JBO�̏���
        /// </summary>
        /// <param name="fileMakerFollowCnt">*-ZZZ (BO�敪�{"-"�{BO��)</param>
        /// <returns>���[�JBO</returns>
        /// <remarks>
        /// <br>Note       : ���[�JBO�̏������s��</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2010/03/08</br>
        /// </remarks>
        private int GetMakerFollowCnt(string fileMakerFollowCnt)
        {
            if (string.IsNullOrEmpty(fileMakerFollowCnt))
            {
                return 0;
            }

            int indexStr = fileMakerFollowCnt.IndexOf("-");

            return this.StringToInt(fileMakerFollowCnt.Substring(indexStr + 1));
        }

        /// <summary>
        /// �o�ɐ��̏���
        /// </summary>
        /// <param name="fileBOShipmentCnt">ZZZ:ZZZ (���_���ށ{":"�{�o�ɐ�)</param>
        /// <returns>�o�ɐ�</returns>
        /// <remarks>
        /// <br>Note       : �o�ɐ��̏������s��</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2010/03/08</br>
        /// </remarks>
        private int GetBOShipmentCnt(string fileBOShipmentCnt)
        {
            if (string.IsNullOrEmpty(fileBOShipmentCnt))
            {
                return 0;
            }

            int indexStr = fileBOShipmentCnt.IndexOf(":");

            return this.StringToInt(fileBOShipmentCnt.Substring(indexStr + 1));
        }
        #endregion

        # region  -- ���YWeb-UOE�����񓚃f�[�^�N���X --
        /// <summary>
        /// ���Y�����񓚃t�@�C�����{�́�
        /// </summary>
        private class NISSAN_H
        {
            public byte[] usercd = new byte[6];		//           ���[�U�[�R�[�h
            public byte[] otscd = new byte[6];		//           ���͂���R�[�h     
            public byte[] nhkbn = new byte[1];		//           �[�i�敪  
            public byte[] isycd = new byte[2];		//           �˗��҃R�[�h     
            public byte[] stsec = new byte[3];		//           �w�苒�_ 
            public byte[] bin = new byte[1];		//           ��    
            public byte[] cmto = new byte[10];		//           �R�����g     
            public byte[] bhnum = new byte[12];		//           ���i�ԍ�     
            public byte[] bokbn = new byte[1];		//           BO�敪     
            public byte[] bnnm = new byte[16];		//           ���i����     
            public byte[] hqsu = new byte[5];		//           ������    
            public byte[] bosbr = new byte[1];		//           BO�V���{��   
            public byte[] zsec_sksu = new byte[5];	//           �����_�E�o�ɐ��@    
            public byte[] zsec_nohno = new byte[6];	//           �����_�E�[�i��No�@�@    
            public byte[] zsec_szhs = new byte[1];	//           �����_�E�d�|�݌Ɉ����V���{��    
            public byte[] zsec_szzhsu = new byte[5];//           �����_�E�d�|    
            public byte[] sbst_seccd = new byte[3];	//           �T�u�Z���^�[�E���_�R�[�h�@    
            public byte[] sbst_sksu = new byte[5];	//           �T�u�Z���^�[�E�o�ɐ��@�@�@    
            public byte[] sbst_nohno = new byte[6];	//           �T�u�Z���^�[�E�[�i��No�@�@    
            public byte[] sbst_szhs = new byte[1];	//           �T�u�Z���^�[�E�d�|�݌Ɉ����V���{���@    
            public byte[] minst_seccd = new byte[3];//           ���C���Z���^�[�E���_�R�[�h�@    
            public byte[] minst_sksu = new byte[5];	//           ���C���Z���^�[�E�o�ɐ��@�@    
            public byte[] minst_nohno = new byte[6];//           ���C���Z���^�[�E�[�i��No�@
            public byte[] minst_szhs = new byte[1];	//           ���C���Z���^�[�E�d�|�݌Ɉ����V���{���@�@
            public byte[] hsec_seccd = new byte[3];	//           �����_�E���_�R�[�h�@
            public byte[] hsec_sksu = new byte[5];	//           �����_�E�o�ɐ��@�@
            public byte[] hsec_nohno = new byte[6];	//           �����_�E�[�i��No�@
            public byte[] htzhsu = new byte[5];		//           �����c�������@�@
            public byte[] fskusu = new byte[5];		//           �s����
            public byte[] mkeobhsu = new byte[12];	//           ���[�J�[EO�������i�ԍ�	
            public byte[] eohtsu = new byte[3];		//           EO����������	
            public byte[] mkbosu = new byte[3];		//           ���[�J�[BO��	
            public byte[] ytnokbn = new byte[1];	//           �\��[���敪	
            public byte[] ytnodate = new byte[4];	//           �\��[����	
            public byte[] bomno = new byte[6];		//           BO�Ǘ�No	
            public byte[] zszkosu = new byte[5];	//           �S�Ѝ݌ɐ�	
            public byte[] tekiyo = new byte[7];		//           �E�v	
            public byte[] skkku = new byte[7];		//           �d�؂艿�i	
            public byte[] bhsb = new byte[2];		//           ���i�w��	
            public byte[] srtb = new byte[6];		//           �o�͒ʔ�	
            public byte[] srdate = new byte[6];		//           �����N����	
            public byte[] srtime = new byte[4];		//           ��������	
            public byte[] cmto2 = new byte[10];		//           �R�����g�Q	
            public byte[] smsbru = new byte[1];		//           �Q����O�V���{��	
            public byte[] htosrdate = new byte[8];	//           �z�X�g�����N����	
            public byte[] htosrtime = new byte[4];	//           �z�X�g��������	
            public byte[] szhhz = new byte[1];		//           �d�|�݌Ɉ����\��	
            public byte[] zszkhz = new byte[1];		//           �S�Ѝ݌ɕ\��	
            public byte[] errmkbn = new byte[1];	//           �G���[���b�Z�[�W�敪	
            public byte[] errm = new byte[12];		//           �G���[���b�Z�[�W	
            public byte[] bo_errmkbn = new byte[1];	//           BO���ʁE���b�Z�[�W�敪	
            public byte[] bokg_num = new byte[5];	//           BO���ʁE����	
            public byte[] yobi = new byte[9];	    //           �\��	
            public byte[] mtart = new byte[2];	    //           (����)	



            /// <summary>	
            /// �R���X�g���N�^�[
            /// </summary>
            public NISSAN_H()
            {
                Clear(0x00);
            }

            public void Clear(byte cd)
            {
                UoeCommonFnc.MemSet(ref usercd, cd, usercd.Length);
                UoeCommonFnc.MemSet(ref otscd, cd, otscd.Length);
                UoeCommonFnc.MemSet(ref nhkbn, cd, nhkbn.Length);
                UoeCommonFnc.MemSet(ref isycd, cd, isycd.Length);
                UoeCommonFnc.MemSet(ref stsec, cd, stsec.Length);
                UoeCommonFnc.MemSet(ref bin, cd, bin.Length);
                UoeCommonFnc.MemSet(ref cmto, cd, cmto.Length);
                UoeCommonFnc.MemSet(ref bhnum, cd, bhnum.Length);
                UoeCommonFnc.MemSet(ref bokbn, cd, bokbn.Length);
                UoeCommonFnc.MemSet(ref bnnm, cd, bnnm.Length);
                UoeCommonFnc.MemSet(ref hqsu, cd, hqsu.Length);
                UoeCommonFnc.MemSet(ref bosbr, cd, bosbr.Length);
                UoeCommonFnc.MemSet(ref zsec_sksu, cd, zsec_sksu.Length);
                UoeCommonFnc.MemSet(ref zsec_nohno, cd, zsec_nohno.Length);
                UoeCommonFnc.MemSet(ref zsec_szhs, cd, zsec_szhs.Length);
                UoeCommonFnc.MemSet(ref zsec_szzhsu, cd, zsec_szzhsu.Length);
                UoeCommonFnc.MemSet(ref sbst_seccd, cd, sbst_seccd.Length);
                UoeCommonFnc.MemSet(ref sbst_sksu, cd, sbst_sksu.Length);
                UoeCommonFnc.MemSet(ref sbst_nohno, cd, sbst_nohno.Length);
                UoeCommonFnc.MemSet(ref sbst_szhs, cd, sbst_szhs.Length);
                UoeCommonFnc.MemSet(ref minst_seccd, cd, minst_seccd.Length);
                UoeCommonFnc.MemSet(ref minst_sksu, cd, minst_sksu.Length);
                UoeCommonFnc.MemSet(ref minst_nohno, cd, minst_nohno.Length);
                UoeCommonFnc.MemSet(ref minst_szhs, cd, minst_szhs.Length);
                UoeCommonFnc.MemSet(ref hsec_seccd, cd, hsec_seccd.Length);
                UoeCommonFnc.MemSet(ref hsec_sksu, cd, hsec_sksu.Length);
                UoeCommonFnc.MemSet(ref hsec_nohno, cd, hsec_nohno.Length);
                UoeCommonFnc.MemSet(ref htzhsu, cd, htzhsu.Length);
                UoeCommonFnc.MemSet(ref fskusu, cd, fskusu.Length);
                UoeCommonFnc.MemSet(ref mkeobhsu, cd, mkeobhsu.Length);
                UoeCommonFnc.MemSet(ref eohtsu, cd, eohtsu.Length);
                UoeCommonFnc.MemSet(ref mkbosu, cd, mkbosu.Length);
                UoeCommonFnc.MemSet(ref ytnokbn, cd, ytnokbn.Length);
                UoeCommonFnc.MemSet(ref ytnodate, cd, ytnodate.Length);
                UoeCommonFnc.MemSet(ref bomno, cd, bomno.Length);
                UoeCommonFnc.MemSet(ref zszkosu, cd, zszkosu.Length);
                UoeCommonFnc.MemSet(ref tekiyo, cd, tekiyo.Length);
                UoeCommonFnc.MemSet(ref skkku, cd, skkku.Length);
                UoeCommonFnc.MemSet(ref bhsb, cd, bhsb.Length);
                UoeCommonFnc.MemSet(ref srtb, cd, srtb.Length);
                UoeCommonFnc.MemSet(ref srdate, cd, srdate.Length);
                UoeCommonFnc.MemSet(ref srtime, cd, srtime.Length);
                UoeCommonFnc.MemSet(ref cmto2, cd, cmto2.Length);
                UoeCommonFnc.MemSet(ref smsbru, cd, smsbru.Length);
                UoeCommonFnc.MemSet(ref htosrdate, cd, htosrdate.Length);
                UoeCommonFnc.MemSet(ref htosrtime, cd, htosrtime.Length);
                UoeCommonFnc.MemSet(ref szhhz, cd, szhhz.Length);
                UoeCommonFnc.MemSet(ref zszkhz, cd, zszkhz.Length);
                UoeCommonFnc.MemSet(ref errmkbn, cd, errmkbn.Length);
                UoeCommonFnc.MemSet(ref errm, cd, errm.Length);
                UoeCommonFnc.MemSet(ref bo_errmkbn, cd, bo_errmkbn.Length);
                UoeCommonFnc.MemSet(ref bokg_num, cd, bokg_num.Length);
                UoeCommonFnc.MemSet(ref yobi, cd, yobi.Length);
                UoeCommonFnc.MemSet(ref mtart, cd, mtart.Length);
            }
        }
        # endregion
    }
}
