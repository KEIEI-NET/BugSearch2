//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �}�c�_�񓚃f�[�^�捞����
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
// �Ǘ��ԍ�  10702591-00 �쐬�S�� : ������
// �C �� ��  2011/05/27  �C�����e : Redmine#21759�̑Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10702591-00 �쐬�S�� : ������
// �C �� ��  2011/05/27  �C�����e : Redmine#21795�̑Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30517 �Ė� �x��
// �� �� ��  2011/10/18  �C�����e : WEB���������l������Ă��Ȃ��s��̏C��
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ������
// �� �� ��  2011/12/02  �C�����e : Redmine#8304�̑Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10707327-00 �쐬�S�� : ����
// �� �� ��  2012/03/07  �C�����e : Redmine#28795�}�c�_�񓚃f�[�^��荞�ݏ����̑Ή�
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
using System.Text;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// �}�c�_Web-UOE�����񓚃f�[�^�̍\�z�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �}�c�_Web-UOE�����񓚃f�[�^�̍\�z�N���X���s���܂��B</br>
    /// <br>Programmer : ������</br>
    /// <br>Date       : 2011/05/18</br>
    /// <br>Update Note: 2011/05/27 ������</br>
    /// <br>              Redmine#21759�̑Ή�</br>
    /// <br>Update Note: 2011/05/27 ������</br>
    /// <br>              Redmine#21795�̑Ή�</br>
    /// <br>Update Note: 2012/03/07 ����</br>
    /// <br>�Ǘ��ԍ�   : 10707327-00 2012/03/28�z�M��</br>
    /// <br>             Redmine#28795�}�c�_�񓚃f�[�^��荞�ݏ����̑Ή�</br>    
    /// </remarks>
    public sealed class MazdaWebUOEOrderDtlInfoBuilder : UOEOrderDtlInfoBuilder
    {
        # region -- �v���C�x�[�g�ϐ� --
        /*----------------------------------------------------------------------------------*/
        private DataTable _dataTable;
        private MAZDA_H mazda_h = new MAZDA_H();
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
        /// Ұ��̫۰��(�^�C�g��)	
        /// </summary>
        public static string MAKERFOLLOWCNT = "MakerFollowCnt";

        private const string COMMASSEMBLY_ID = "0403";
        private const string HEADERMARK = "HD";
        private const string FOOTERMARK = "TL";

        private string _enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
        private string _loginSectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;
        //�t�n�d������A�N�Z�X�N���X
        private UOESupplierAcs _uoeSupplierAcs;
        //�t�n�d������
        private List<UOESupplier> _uoeSupplier01623;
        private  int UOESupplierFlag = 0;

        private UOESupplier _uoeSupplier = null;
        # endregion

        # region -- �R���X�g���N�^ --
        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : �I�t���C���Ή�</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011/05/18</br>
        /// <br>UpdateNote : </br>
        /// </remarks>
        public MazdaWebUOEOrderDtlInfoBuilder()
            : base()
        {
            this._uoeSupplierAcs = new UOESupplierAcs();
            this.CacheUOESupplier_01623();
        }
        # endregion

        # region  -- �\�z�N���X�̎��� --
        
        /// <summary>
        /// �蓮�Ǝ�����Falg���
        /// </summary>
        /// <remarks>
        /// <br>Note       : �蓮�Ǝ�����Falg���</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011/05/18</br>
        /// </remarks>
        public void GetSupplierFlag()
        {
            foreach (UOESupplier uoeSupplier in _uoeSupplier01623)
            {
                if (COMMASSEMBLY_ID.Equals(uoeSupplier.CommAssemblyId))
                {
                    UOESupplierFlag = 1;
                    this._uoeSupplier = uoeSupplier;
                    break;
                }
            }

        }

        /// <summary>
        /// �t�n�d��������L���b�V�����䏈��
        /// </summary>
        /// <remarks>
        /// <br>Note       : �t�n�d��������L���b�V�����䏈�����s���܂��B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011/05/18</br>
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
       
        /// <summary>
        /// �t�@�C�����擾����
        /// </summary>
        /// <param name="filesDataDtlList">�t�@�C�������</param>
        /// <param name="answerSaveFolder">�񓚕ۑ��t�H���_</param>
        /// <param name="errMessage">���b�Z�[�W</param>
        /// <returns>��������</returns>
        /// <remarks>
        /// <br>Note       : �t�@�C�������擾��������B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011/05/18</br>
        /// <br>           �@�����捞�敪�̒ǉ��ɔ����������ύX�ɂȂ邽�߁A�����̎蓮�����͎c����	�A�����捞�̏����ǉ����s���܂��B</br>
        /// <br>Update Note: 2012/03/07 ����</br>
        /// <br>�Ǘ��ԍ�   : 10707327-00 2012/03/28�z�M��</br>
        /// <br>             Redmine#28795�}�c�_�񓚃f�[�^��荞�ݏ����̑Ή�</br>    
        /// </remarks>
        protected override int GetFilesData(out List<UOEOrderDtlInfo> filesDataDtlList, string answerSaveFolder, ref string errMessage) 
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

            this._dataTable.Clear();

            CacheUOESupplier_01623(); 

            GetSupplierFlag();
            // �t�@�C�����
            filesDataDtlList = new List<UOEOrderDtlInfo>();

            Dictionary<string, object> uoeRemarkDic = new Dictionary<string, object>();
            StreamReader streamReader = null;
            try
            {
                string filePathName = "";

                #region HATTU.MLG���捞
                List<UOEOrderDtlInfo> datDataDtlList = new List<UOEOrderDtlInfo>();

                if (UOESupplierFlag == 1) 
                {
                    filePathName = answerSaveFolder + "\\HATTU.MLG";
                    //--------ADD BY ������ on 2011/12/02 for Redmine#8304  ---------->>>>>>>>
                    string timeFormat = "yyyyMMddHHmmss";
                    DateTime dt = DateTime.Now;
                    string bakFilePathName = answerSaveFolder + "\\HATTU_" + dt.ToString(timeFormat) + ".MLG";                    
                    File.Copy(filePathName, bakFilePathName);
                    //--------ADD BY ������ on 2011/12/02 for Redmine#8304  ----------<<<<<<<<
                    if (File.Exists(filePathName))
                    {
                        try
                        {
                            // HATTU.MLG�t�@�C���g�p�����f
                            streamReader = new StreamReader(filePathName, Encoding.GetEncoding("Shift-JIS"));
                        }
                        catch (IOException)
                        {
                            errMessage = "�����񓚃t�@�C�����g�p���ł��B";
                            // �ُ�ꍇ
                            return (int)ConstantManagement.MethodResult.ctFNC_WARNING;
                        }

                        List<string> mlgDateList = new List<string>();
                        string strLine = string.Empty;
                        while ((strLine = streamReader.ReadLine()) != null)
                        {
                            if (strLine.Trim() != string.Empty)
                            {
                                mlgDateList.Add(strLine);
                            }
                        }

                        Dictionary<string, List<string>> mlgDateDic = new Dictionary<string, List<string>>();

                        List<string> mlgDateSubList = new List<string>();

                        List<string> list = null;
                        string uoeRemark2 = string.Empty;
                        for (int rowIndex = 0; rowIndex < mlgDateList.Count; rowIndex++)
                        {
                            string str = mlgDateList[rowIndex];
                            if (HEADERMARK.Equals(str.Substring(0, 2)))
                            {
                                continue;
                            }
                            if (FOOTERMARK.Equals(str.Substring(0, 2)))
                            {
                                if (rowIndex > 0)
                                {
                                    uoeRemark2 = mlgDateList[rowIndex - 1].Substring(2, 12);

                                    //---ADD ���� 2012/03/07 Redmine#28795------>>>>>
                                    if (uoeRemark2.Substring(0, 3) != _uoeSupplier.HondaSectionCode.Trim())
                                    {
                                        mlgDateSubList.Clear();
                                        continue;
                                    }
                                    //---ADD ���� 2012/03/07 Redmine#28795------<<<<<

                                    list = new List<string>();
                                    foreach (string s in mlgDateSubList)
                                    {
                                        list.Add(s);
                                    }

                                    mlgDateDic.Add(uoeRemark2, list);
                                    mlgDateSubList.Clear();
                                }
                                continue;
                            }
                            mlgDateSubList.Add(str);
                        }

                        foreach (string reMark in mlgDateDic.Keys)
                        {
                            mlgDateSubList = mlgDateDic[reMark];

                            //---DEL ���� 2012/03/07 Redmine#28795------>>>>>
                            // 2011/10/18
                            //if (reMark.Substring(0, 3) != _uoeSupplier.HondaSectionCode.Trim())
                            //{
                            //    continue;
                            //}
                            // 2011/10/18
                            //---DEL ���� 2012/03/07 Redmine#28795------<<<<<

                            for (int i = 0; i < mlgDateSubList.Count; i++)
                            {
                                if (i == mlgDateSubList.Count - 1)
                                {
                                    break;
                                }

                                // 2011/10/18
                                //if (i % 5 != 0 || i == 0)
                                if (mlgDateSubList[i].Substring(2, 12) != reMark || i == 0)
                                // 2011/10/18
                                {
                                    byte[] line = Encoding.GetEncoding("Shift-JIS").GetBytes(mlgDateSubList[i]);
                                    this.FromByteArray(line);
                                    UOEOrderDtlInfo uOEOrderDtlMazdaInfo = new UOEOrderDtlInfo();
                                    uOEOrderDtlMazdaInfo.UoeRemark2 = reMark;
                                    this.ConverDatToUOEOrderDtlInfo(ref uOEOrderDtlMazdaInfo);
                                    if (uOEOrderDtlMazdaInfo != null)
                                    {
                                        datDataDtlList.Add(uOEOrderDtlMazdaInfo);
                                    }
                                }
                            }
                        }

                        filesDataDtlList = datDataDtlList;

                    }
                }
                #endregion
            }
            catch
            {
                // �ُ�ꍇ
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            finally
            {
                if (streamReader != null)
                {
                    streamReader.Dispose();
                    streamReader.Close();
                }
            }
            return status;
        }

        /// <summary>
        /// �}�c�_���������ō쐬���ꂽ�f�[�^�̍i����
        /// </summary>
        /// <param name="list">MLG���</param>
        /// <param name="remark2">���}�[�N2</param>
        /// <returns>����</returns>
        /// <remarks>
        /// <br>Note       : �}�c�_���������ō쐬���ꂽ�f�[�^�̍i���݁B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011/05/18</br>
        /// </remarks>
        protected override List<UOEOrderDtlWork> FilterUOEOrderDtlList(List<UOEOrderDtlWork> list, string remark2)
        {
            List<UOEOrderDtlWork> retList = new List<UOEOrderDtlWork>();

            if (UOESupplierFlag == 1)
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
        /// <br>Update Note: 2011/05/27 ������</br>
        /// <br>              Redmine#21759�̑Ή�</br>
        /// <br>Update Note: 2011/05/27 ������</br>
        /// <br>              Redmine#21795�̑Ή�</br>
        /// </remarks>
        protected override int MergeList(ref List<UOEOrderDtlWork> workList, List<UOEOrderDtlInfo> dateList) 
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            try
            {
                for (int i = 0; i < workList.Count; i++)
                {
                    if (i < dateList.Count)
                    {
                        // ---ADD 2011/05/27--------->>>>>
                        // ���}�[�N2�̃N���A
                        workList[i].UoeRemark2 = string.Empty;
                        // ---ADD 2011/05/27---------<<<<<

                        // ��M���t	
                        workList[i].ReceiveDate = dateList[i].ReceiveDate;
                        //��M����
                        workList[i].ReceiveTime = dateList[i].ReceiveTime;
                        if (dateList[i].SubstPartsNo.Trim() == string.Empty && dateList[i].UOESubstMark.Trim() == string.Empty)
                        {
                            //�񓚕i��
                            workList[i].AnswerPartsNo = dateList[i].AnswerPartsNo;
                            //�񓚕i��
                            workList[i].AnswerPartsName = dateList[i].AnswerPartsName;
                        }
                        else
                        {
                            //�񓚕i��
                            workList[i].AnswerPartsNo = dateList[i].AnswerPartsNo;
                            //�񓚕i��
                            workList[i].AnswerPartsName = dateList[i].AnswerPartsName;
                            //��֕i��
                            workList[i].SubstPartsNo = dateList[i].SubstPartsNo;
                            //UOE��փ}�[�N
                            workList[i].UOESubstMark = dateList[i].UOESubstMark;
                        }

                        //���_�o�ɐ�							
                        workList[i].UOESectOutGoodsCnt = dateList[i].UOESectOutGoodsCnt;
                        //BO�o�ɐ�1	
                        workList[i].BOShipmentCnt1 = dateList[i].BOShipmentCnt1;
                        //BO�o�ɐ�2							
                        workList[i].BOShipmentCnt2 = dateList[i].BOShipmentCnt2;
                        //���[�J�[�t�H���[��							
                        workList[i].MakerFollowCnt = dateList[i].MakerFollowCnt;
                        //UOE���_�`�[�ԍ�							
                        workList[i].UOESectionSlipNo = dateList[i].UOESectionSlipNo;
                        //BO�`�[��1		
                        workList[i].BOSlipNo1 = dateList[i].BOSlipNo1;
                        //BO�`�[��2							
                        workList[i].BOSlipNo2 = dateList[i].BOSlipNo2;

                        //�񓚒艿
                        // ---UPD 2011/05/27-------------->>>>>
                        //workList[i].AnswerListPrice = dateList[i].AnswerListPrice;
                        if (dateList[i].AnswerListPrice != 999999)
                        {			
                            workList[i].AnswerListPrice = dateList[i].AnswerListPrice;
                        }
                        else
                        {			
                            workList[i].AnswerListPrice = 0;
                        }
                        // ---UPD 2011/05/27--------------<<<<<

                        //�񓚌����P��							
                        workList[i].AnswerSalesUnitCost = dateList[i].AnswerSalesUnitCost;
                        // UOE�o�׋��_�R�[�h1�i�}�c�_�j
                        workList[i].MazdaUOEShipSectCd1 = dateList[i].MazdaUOEShipSectCd1;
                        // UOE�o�׋��_�R�[�h2�i�}�c�_�j
                        workList[i].MazdaUOEShipSectCd2 = dateList[i].MazdaUOEShipSectCd2;
                        // UOE�o�׋��_�R�[�h3�i�}�c�_�j
                        workList[i].MazdaUOEShipSectCd3 = dateList[i].MazdaUOEShipSectCd3;
                        //���C���G���[���b�Z�[�W	
                        workList[i].LineErrorMassage = dateList[i].LineErrorMassage;
                        // �f�[�^���M�敪
                        workList[i].DataSendCode = dateList[i].DataSendCode;
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
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011/05/18</br>
        /// </remarks>
        protected override void DataTableColumnConstruction()
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
            table.Columns[UOESECTIONSLIPNO].Caption = "���_"; // ���_�`�[�ԍ�(�^�C�g��)				
            table.Columns[UOESECTOUTGOODSCNT].Caption = "�o�א�"; // �o�א�(�^�C�g��)				
            table.Columns[BOSLIPNO1].Caption = "�T�u"; // BO�`�[�ԍ�1(�^�C�g��)				
            table.Columns[BOSHIPMENTCNT1].Caption = "�o�א�"; // �o�א�(�^�C�g��)				
            table.Columns[BOSLIPNO2].Caption = "�{��"; // BO�`�[�ԍ�2(�^�C�g��)				
            table.Columns[BOSHIPMENTCNT2].Caption = "�o�א�"; // �o�א�(�^�C�g��)				
            table.Columns[MAKERFOLLOWCNT].Caption = "�l�e"; // Ұ��̫۰��(�^�C�g��)	

            this._dataTable = table;
        }

        /// <summary>
        /// �f�[�^�Z�b�g�s��������
        /// </summary>
        /// <remarks>
        /// <br>Note       : �f�[�^�Z�b�g�s�����������s���܂��B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011/05/18</br>
        /// </remarks>
        protected override void DataTableAddRow(List<UOEOrderDtlWork> workList)
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
                //���_								
                row[UOESECTIONSLIPNO] = work.UOESectionSlipNo;
                //�o�א�
                row[UOESECTOUTGOODSCNT] = work.UOESectOutGoodsCnt;
                //�T�u								
                row[BOSLIPNO1] = work.BOSlipNo1;
                //�o�א�								
                row[BOSHIPMENTCNT1] = work.BOShipmentCnt1;
                //�{��								
                row[BOSLIPNO2] = work.BOSlipNo2;
                //�o�א�								
                row[BOSHIPMENTCNT2] = work.BOShipmentCnt2;
                //�l�e							
                row[MAKERFOLLOWCNT] = work.MakerFollowCnt;

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
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011/05/18</br>
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
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011/05/18</br>
        /// </remarks>
        private void FromByteArray(byte[] line)
        {
            MemoryStream ms = new MemoryStream();
            ms.Write(line, 0, line.Length);
            ms.Seek(0, SeekOrigin.Begin);

            ms.Read(mazda_h.seqno, 0, mazda_h.seqno.Length);
            ms.Read(mazda_h.bhnum, 0, mazda_h.bhnum.Length);
            ms.Read(mazda_h.trle, 0, mazda_h.trle.Length);
            ms.Read(mazda_h.trsu, 0, mazda_h.trsu.Length);
            ms.Read(mazda_h.num, 0, mazda_h.num.Length);
            ms.Read(mazda_h.ordnum, 0, mazda_h.ordnum.Length);
            ms.Read(mazda_h.shiptt, 0, mazda_h.shiptt.Length);
            ms.Read(mazda_h.bonum, 0, mazda_h.bonum.Length);
            ms.Read(mazda_h.bocd, 0, mazda_h.bocd.Length);
            ms.Read(mazda_h.bhnam, 0, mazda_h.bhnam.Length);
            ms.Read(mazda_h.concc, 0, mazda_h.concc.Length);
            ms.Read(mazda_h.bhnums, 0, mazda_h.bhnums.Length);
            ms.Read(mazda_h.comcd, 0, mazda_h.comcd.Length);
            ms.Read(mazda_h.unitpr, 0, mazda_h.unitpr.Length);
            ms.Read(mazda_h.retpr, 0, mazda_h.retpr.Length);
            ms.Read(mazda_h.seccd1, 0, mazda_h.seccd1.Length);
            ms.Read(mazda_h.slipcd1, 0, mazda_h.slipcd1.Length);
            ms.Read(mazda_h.shipnum1, 0, mazda_h.shipnum1.Length);
            ms.Read(mazda_h.seccd2, 0, mazda_h.seccd2.Length);
            ms.Read(mazda_h.slipcd2, 0, mazda_h.slipcd2.Length);
            ms.Read(mazda_h.shipnum2, 0, mazda_h.shipnum2.Length);
            ms.Read(mazda_h.seccd3, 0, mazda_h.seccd3.Length);
            ms.Read(mazda_h.slipcd3, 0, mazda_h.slipcd3.Length);
            ms.Read(mazda_h.shipnum3, 0, mazda_h.shipnum3.Length);
            ms.Read(mazda_h.seccd4, 0, mazda_h.seccd4.Length);
            ms.Read(mazda_h.slipcd4, 0, mazda_h.slipcd4.Length);
            ms.Read(mazda_h.shipnum4, 0, mazda_h.shipnum4.Length);
            ms.Read(mazda_h.seccd5, 0, mazda_h.seccd5.Length);
            ms.Read(mazda_h.slipcd5, 0, mazda_h.slipcd5.Length);
            ms.Read(mazda_h.shipnum5, 0, mazda_h.shipnum5.Length);
            ms.Read(mazda_h.seccd6, 0, mazda_h.seccd6.Length);
            ms.Read(mazda_h.slipcd6, 0, mazda_h.slipcd6.Length);
            ms.Read(mazda_h.shipnum6, 0, mazda_h.shipnum6.Length);
            ms.Read(mazda_h.seccd7, 0, mazda_h.seccd7.Length);
            ms.Read(mazda_h.slipcd7, 0, mazda_h.slipcd7.Length);
            ms.Read(mazda_h.shipnum7, 0, mazda_h.shipnum7.Length);
            ms.Read(mazda_h.seccd8, 0, mazda_h.seccd8.Length);
            ms.Read(mazda_h.slipcd8, 0, mazda_h.slipcd8.Length);
            ms.Read(mazda_h.shipnum8, 0, mazda_h.shipnum8.Length);
            ms.Read(mazda_h.seccd9, 0, mazda_h.seccd9.Length);
            ms.Read(mazda_h.slipcd9, 0, mazda_h.slipcd9.Length);
            ms.Read(mazda_h.shipnum9, 0, mazda_h.shipnum9.Length);
            ms.Read(mazda_h.seccd10, 0, mazda_h.seccd10.Length);
            ms.Read(mazda_h.slipcd10, 0, mazda_h.slipcd10.Length);
            ms.Read(mazda_h.shipnum10, 0, mazda_h.shipnum10.Length);
            ms.Read(mazda_h.status1, 0, mazda_h.status1.Length);
            ms.Read(mazda_h.mcnum1, 0, mazda_h.mcnum1.Length);
            ms.Read(mazda_h.didate1, 0, mazda_h.didate1.Length);
            ms.Read(mazda_h.status2, 0, mazda_h.status2.Length);
            ms.Read(mazda_h.mcnum2, 0, mazda_h.mcnum2.Length);
            ms.Read(mazda_h.didate2, 0, mazda_h.didate2.Length);
            ms.Read(mazda_h.status3, 0, mazda_h.status3.Length);
            ms.Read(mazda_h.mcnum3, 0, mazda_h.mcnum3.Length);
            ms.Read(mazda_h.didate3, 0, mazda_h.didate3.Length);
            ms.Read(mazda_h.status4, 0, mazda_h.status4.Length);
            ms.Read(mazda_h.mcnum4, 0, mazda_h.mcnum4.Length);
            ms.Read(mazda_h.didate4, 0, mazda_h.didate4.Length);
            ms.Read(mazda_h.status5, 0, mazda_h.status5.Length);
            ms.Read(mazda_h.mcnum5, 0, mazda_h.mcnum5.Length);
            ms.Read(mazda_h.didate5, 0, mazda_h.didate5.Length);
            ms.Read(mazda_h.cmto, 0, mazda_h.cmto.Length);

            ms.Close();
        }

        /// <summary>
        /// �}�c�_�����񓚃t�@�C����ں��ނ̏���
        /// </summary>
        /// <param name="uOEOrderDtlMazdaInfo">ں��ރ��X�g</param>
        /// <remarks>
        /// <br>Note       : �}�c�_�����񓚃t�@�C����ں��ނ�����</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011/05/18</br>
        /// <br>Update Note: 2011/05/27 ������</br>
        /// <br>              Redmine#21759�̑Ή�</br>
        /// </remarks>
        private void ConverDatToUOEOrderDtlInfo(ref UOEOrderDtlInfo uOEOrderDtlMazdaInfo)
        {
            if (uOEOrderDtlMazdaInfo == null)
            {
                uOEOrderDtlMazdaInfo = new UOEOrderDtlInfo();
            }

            // ���ځu���x���E�T�t�B�b�N�X�v���u01�E01�v�ȊO�̏ꍇ�́A���̖��ׂ�ǂݍ��ݑΏۊO�Ƃ���
            if (UoeCommonFnc.ToStringFromByteStrAry(mazda_h.trle) != "01"
                || UoeCommonFnc.ToStringFromByteStrAry(mazda_h.trsu) != "01")
            {
                uOEOrderDtlMazdaInfo = null;
                return;
            }

            // ��M���t
            uOEOrderDtlMazdaInfo.ReceiveDate = DateTime.Today;
            // ��M����
            uOEOrderDtlMazdaInfo.ReceiveTime = Int32.Parse(DateTime.Now.ToString("HHmmss"));

            // �����񓚃t�@�C���̢�݊����R�[�h��̐擪�PByte���u���p�X�y�[�X or 0�v�ȊO�̏ꍇ�ɃZ�b�g���܂��B
            if (UoeCommonFnc.ToStringFromByteStrAry(mazda_h.comcd).Substring(0, 1) == " "
                || UoeCommonFnc.ToStringFromByteStrAry(mazda_h.comcd).Substring(0, 1) == "0")
            {
                // �񓚕i��
                uOEOrderDtlMazdaInfo.AnswerPartsNo = UoeCommonFnc.ToStringFromByteStrAry(mazda_h.bhnum);
                // �񓚕i��
                uOEOrderDtlMazdaInfo.AnswerPartsName = UoeCommonFnc.ToStringFromByteStrAry(mazda_h.bhnam);
            }
            else
            {
                // ---UPD 2011/05/27----------------->>>>>
                // �񓚕i��
                //uOEOrderDtlMazdaInfo.AnswerPartsNo = UoeCommonFnc.ToStringFromByteStrAry(mazda_h.bhnums);
                uOEOrderDtlMazdaInfo.AnswerPartsNo = UoeCommonFnc.ToStringFromByteStrAry(mazda_h.bhnum);
                // ---UPD 2011/05/27-----------------<<<<<
                // �񓚕i��
                uOEOrderDtlMazdaInfo.AnswerPartsName = UoeCommonFnc.ToStringFromByteStrAry(mazda_h.bhnam);
                // ---UPD 2011/05/27----------------->>>>>
                // ��֕i��
                //uOEOrderDtlMazdaInfo.SubstPartsNo = UoeCommonFnc.ToStringFromByteStrAry(mazda_h.bhnum);
                uOEOrderDtlMazdaInfo.SubstPartsNo = UoeCommonFnc.ToStringFromByteStrAry(mazda_h.bhnums);
                // ---UPD 2011/05/27-----------------<<<<<
                // UOE��փ}�[�N
                uOEOrderDtlMazdaInfo.UOESubstMark = UoeCommonFnc.ToStringFromByteStrAry(mazda_h.comcd);
            }

            // �񓚒艿
            uOEOrderDtlMazdaInfo.AnswerListPrice = UoeCommonFnc.ToDoubleFromByteStrAry(mazda_h.retpr);
            // �񓚌����P��
            uOEOrderDtlMazdaInfo.AnswerSalesUnitCost = UoeCommonFnc.ToDoubleFromByteStrAry(mazda_h.unitpr);
            // ���C���G���[���b�Z�[�W
            uOEOrderDtlMazdaInfo.LineErrorMassage = UoeCommonFnc.ToStringFromByteStrAry(mazda_h.cmto);
            // �f�[�^���M�敪
            uOEOrderDtlMazdaInfo.DataSendCode = 5;
            // ���[�J�[�t�H���[��
            uOEOrderDtlMazdaInfo.MakerFollowCnt = UoeCommonFnc.ToInt32FromByteStrAry(mazda_h.mcnum1)
                                                    + UoeCommonFnc.ToInt32FromByteStrAry(mazda_h.mcnum2)
                                                    + UoeCommonFnc.ToInt32FromByteStrAry(mazda_h.mcnum3)
                                                    + UoeCommonFnc.ToInt32FromByteStrAry(mazda_h.mcnum4)
                                                    + UoeCommonFnc.ToInt32FromByteStrAry(mazda_h.mcnum5);

            if (this._uoeSupplier == null || this._uoeSupplier.CommAssemblyId.Trim().PadLeft(4, '0') != "0403")
            {
                foreach (UOESupplier uoeSupplier in _uoeSupplier01623)
                {
                    if (("0403").Equals(uoeSupplier.CommAssemblyId))
                    {
                        this._uoeSupplier = uoeSupplier;
                        break;
                    }
                }
            }

            Dictionary<int, UOEMergeDateInfo> uoeMergeDateDic = new Dictionary<int, UOEMergeDateInfo>();
            this.GetMergeDateDic(out uoeMergeDateDic);
            int count = uoeMergeDateDic.Count;

            if (count == 0)
            {
                // UOE�o�׋��_�R�[�h�P�i�}�c�_�j
                uOEOrderDtlMazdaInfo.MazdaUOEShipSectCd1 = string.Empty;
                // UOE���_�`�[�ԍ�
                uOEOrderDtlMazdaInfo.UOESectionSlipNo = string.Empty;
                // ���_�o�ɐ�
                uOEOrderDtlMazdaInfo.UOESectOutGoodsCnt = 0;
                // UOE�o�׋��_�R�[�h2�i�}�c�_�j
                uOEOrderDtlMazdaInfo.MazdaUOEShipSectCd2 = string.Empty;
                // BO�`�[��1
                uOEOrderDtlMazdaInfo.BOSlipNo1 = string.Empty;
                // BO�o�ɐ�1
                uOEOrderDtlMazdaInfo.BOShipmentCnt1 = 0;
                // UOE�o�׋��_�R�[�h3�i�}�c�_�j
                uOEOrderDtlMazdaInfo.MazdaUOEShipSectCd3 = string.Empty;
                // BO�`�[��2
                uOEOrderDtlMazdaInfo.BOSlipNo2 = string.Empty;
                // BO�o�ɐ�2
                uOEOrderDtlMazdaInfo.BOShipmentCnt2 = 0;
            }
            else
            {

                for (int i = 1; i <= count; i++)
                {
                    if (uoeMergeDateDic.ContainsKey(i))
                    {
                        if (uoeMergeDateDic[i].SectionCode == this._uoeSupplier.MazdaSectionCode.Trim().PadLeft(3, ' ').Substring(1, 2))
                        {
                            // UOE�o�׋��_�R�[�h�P�i�}�c�_�j
                            uOEOrderDtlMazdaInfo.MazdaUOEShipSectCd1 = uoeMergeDateDic[i].SectionCode;
                            // UOE���_�`�[�ԍ�
                            uOEOrderDtlMazdaInfo.UOESectionSlipNo = uoeMergeDateDic[i].SlipNo;
                            // ���_�o�ɐ�
                            uOEOrderDtlMazdaInfo.UOESectOutGoodsCnt = uoeMergeDateDic[i].ShipCnt;
                            uoeMergeDateDic.Remove(i);
                            break;
                        }
                    }
                }

                if (count != uoeMergeDateDic.Count)
                {
                    if (uoeMergeDateDic.Count == 0)
                    {
                        // UOE�o�׋��_�R�[�h2�i�}�c�_�j
                        uOEOrderDtlMazdaInfo.MazdaUOEShipSectCd2 = string.Empty;
                        // BO�`�[��1
                        uOEOrderDtlMazdaInfo.BOSlipNo1 = string.Empty;
                        // BO�o�ɐ�1
                        uOEOrderDtlMazdaInfo.BOShipmentCnt1 = 0;
                        // UOE�o�׋��_�R�[�h3�i�}�c�_�j
                        uOEOrderDtlMazdaInfo.MazdaUOEShipSectCd3 = string.Empty;
                        // BO�`�[��2
                        uOEOrderDtlMazdaInfo.BOSlipNo2 = string.Empty;
                        // BO�o�ɐ�2
                        uOEOrderDtlMazdaInfo.BOShipmentCnt2 = 0;
                    }
                    else
                    {
                        for (int j = 1; j <= count; j++)
                        {
                            if (uoeMergeDateDic.ContainsKey(j))
                            {
                                // UOE�o�׋��_�R�[�h2�i�}�c�_�j
                                uOEOrderDtlMazdaInfo.MazdaUOEShipSectCd2 = uoeMergeDateDic[j].SectionCode;
                                // BO�`�[��1
                                uOEOrderDtlMazdaInfo.BOSlipNo1 = uoeMergeDateDic[j].SlipNo;
                                // BO�o�ɐ�1
                                uOEOrderDtlMazdaInfo.BOShipmentCnt1 = uoeMergeDateDic[j].ShipCnt;
                                uoeMergeDateDic.Remove(j);
                                break;
                            }
                        }

                        if (uoeMergeDateDic.Count == 0)
                        {
                            // UOE�o�׋��_�R�[�h3�i�}�c�_�j
                            uOEOrderDtlMazdaInfo.MazdaUOEShipSectCd3 = string.Empty;
                            // BO�`�[��2
                            uOEOrderDtlMazdaInfo.BOSlipNo2 = string.Empty;
                            // BO�o�ɐ�2
                            uOEOrderDtlMazdaInfo.BOShipmentCnt2 = 0;
                        }
                        else if (uoeMergeDateDic.Count == 1)
                        {
                            foreach (UOEMergeDateInfo info in uoeMergeDateDic.Values)
                            {
                                // UOE�o�׋��_�R�[�h3�i�}�c�_�j
                                uOEOrderDtlMazdaInfo.MazdaUOEShipSectCd3 = info.SectionCode;
                                // BO�`�[��2
                                uOEOrderDtlMazdaInfo.BOSlipNo2 = info.SlipNo;
                                // BO�o�ɐ�2
                                uOEOrderDtlMazdaInfo.BOShipmentCnt2 = info.ShipCnt;
                            }
                        }
                        else
                        {
                            int shipCntSum = 0;
                            foreach (UOEMergeDateInfo info in uoeMergeDateDic.Values)
                            {
                                shipCntSum += info.ShipCnt;
                            }
                            // UOE�o�׋��_�R�[�h3�i�}�c�_�j
                            uOEOrderDtlMazdaInfo.MazdaUOEShipSectCd3 = string.Empty;
                            // BO�`�[��2
                            uOEOrderDtlMazdaInfo.BOSlipNo2 = string.Empty;
                            // BO�o�ɐ�2
                            uOEOrderDtlMazdaInfo.BOShipmentCnt2 = shipCntSum;
                        }
                    }
                }
                else
                {
                    // UOE�o�׋��_�R�[�h�P�i�}�c�_�j
                    uOEOrderDtlMazdaInfo.MazdaUOEShipSectCd1 = string.Empty;
                    // UOE���_�`�[�ԍ�
                    uOEOrderDtlMazdaInfo.UOESectionSlipNo = string.Empty;
                    // ���_�o�ɐ�
                    uOEOrderDtlMazdaInfo.UOESectOutGoodsCnt = 0;

                    for (int k = 1; k <= count; k++)
                    {
                        if (uoeMergeDateDic.ContainsKey(k))
                        {
                            // UOE�o�׋��_�R�[�h2�i�}�c�_�j
                            uOEOrderDtlMazdaInfo.MazdaUOEShipSectCd2 = uoeMergeDateDic[k].SectionCode;
                            // BO�`�[��1
                            uOEOrderDtlMazdaInfo.BOSlipNo1 = uoeMergeDateDic[k].SlipNo;
                            // BO�o�ɐ�1
                            uOEOrderDtlMazdaInfo.BOShipmentCnt1 = uoeMergeDateDic[k].ShipCnt;
                            uoeMergeDateDic.Remove(k);
                            break;
                        }
                    }

                    if (uoeMergeDateDic.Count == 0)
                    {
                        // UOE�o�׋��_�R�[�h3�i�}�c�_�j
                        uOEOrderDtlMazdaInfo.MazdaUOEShipSectCd3 = string.Empty;
                        // BO�`�[��2
                        uOEOrderDtlMazdaInfo.BOSlipNo2 = string.Empty;
                        // BO�o�ɐ�2
                        uOEOrderDtlMazdaInfo.BOShipmentCnt2 = 0;
                    }
                    else if (uoeMergeDateDic.Count == 1)
                    {
                        foreach (UOEMergeDateInfo info in uoeMergeDateDic.Values)
                        {
                            // UOE�o�׋��_�R�[�h3�i�}�c�_�j
                            uOEOrderDtlMazdaInfo.MazdaUOEShipSectCd3 = info.SectionCode;
                            // BO�`�[��2
                            uOEOrderDtlMazdaInfo.BOSlipNo2 = info.SlipNo;
                            // BO�o�ɐ�2
                            uOEOrderDtlMazdaInfo.BOShipmentCnt2 = info.ShipCnt;
                        }
                    }
                    else
                    {
                        int shipCntSum = 0;
                        foreach (UOEMergeDateInfo info in uoeMergeDateDic.Values)
                        {
                            shipCntSum += info.ShipCnt;
                        }
                        // UOE�o�׋��_�R�[�h3�i�}�c�_�j
                        uOEOrderDtlMazdaInfo.MazdaUOEShipSectCd3 = string.Empty;
                        // BO�`�[��2
                        uOEOrderDtlMazdaInfo.BOSlipNo2 = string.Empty;
                        // BO�o�ɐ�2
                        uOEOrderDtlMazdaInfo.BOShipmentCnt2 = shipCntSum;
                    }
                }
            }
        }

        /// <summary>
        /// �o�א��A�`�[���A���_�R�[�h�ɂ��ăZ�b�g����
        /// </summary>
        /// <param name="uoeMergeDateDic">�o�א��A�`�[���A���_�R�[�hDictionary</param>
        /// <remarks>
        /// <br>Note       : �o�א��A�`�[���A���_�R�[�h�ɂ��ăZ�b�g����</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011/05/18</br>
        /// <br>Update Note: 2011/05/27 ������</br>
        /// <br>              Redmine#21759�̑Ή�</br>
        /// </remarks>
        private void GetMergeDateDic(out Dictionary<int, UOEMergeDateInfo> uoeMergeDateDic)
        {
            Dictionary<int, UOEMergeDateInfo> dictionary = new Dictionary<int, UOEMergeDateInfo>();

            //UoeCommonFnc.ToStringFromByteStrAry(mazda_h.seccd1).Trim(); // DEL 2011/05/27
            int count = 0;
            //if (UoeCommonFnc.ToStringFromByteStrAry(mazda_h.seccd1).Trim() != string.Empty) // DEL 2011/05/27
            if (UoeCommonFnc.ToInt32FromByteStrAry(mazda_h.shipnum1) != 0)  // ADD 2011/05/27
            {
                count++;
                UOEMergeDateInfo uoeMergeDateInfo = new UOEMergeDateInfo();
                uoeMergeDateInfo.SectionCode = UoeCommonFnc.ToStringFromByteStrAry(mazda_h.seccd1);
                uoeMergeDateInfo.SlipNo = UoeCommonFnc.ToStringFromByteStrAry(mazda_h.slipcd1);
                uoeMergeDateInfo.ShipCnt = UoeCommonFnc.ToInt32FromByteStrAry(mazda_h.shipnum1);
                dictionary.Add(count, uoeMergeDateInfo);
            }
            //if (UoeCommonFnc.ToStringFromByteStrAry(mazda_h.seccd2).Trim() != string.Empty) // DEL 2011/05/27
            if (UoeCommonFnc.ToInt32FromByteStrAry(mazda_h.shipnum2) != 0)  // ADD 2011/05/27
            {
                count++;
                UOEMergeDateInfo uoeMergeDateInfo = new UOEMergeDateInfo();
                uoeMergeDateInfo.SectionCode = UoeCommonFnc.ToStringFromByteStrAry(mazda_h.seccd2);
                uoeMergeDateInfo.SlipNo = UoeCommonFnc.ToStringFromByteStrAry(mazda_h.slipcd2);
                uoeMergeDateInfo.ShipCnt = UoeCommonFnc.ToInt32FromByteStrAry(mazda_h.shipnum2);
                dictionary.Add(count, uoeMergeDateInfo);
            }
            //if (UoeCommonFnc.ToStringFromByteStrAry(mazda_h.seccd3).Trim() != string.Empty) // DEL 2011/05/27
            if (UoeCommonFnc.ToInt32FromByteStrAry(mazda_h.shipnum3) != 0)  // ADD 2011/05/27
            {
                count++;
                UOEMergeDateInfo uoeMergeDateInfo = new UOEMergeDateInfo();
                uoeMergeDateInfo.SectionCode = UoeCommonFnc.ToStringFromByteStrAry(mazda_h.seccd3);
                uoeMergeDateInfo.SlipNo = UoeCommonFnc.ToStringFromByteStrAry(mazda_h.slipcd3);
                uoeMergeDateInfo.ShipCnt = UoeCommonFnc.ToInt32FromByteStrAry(mazda_h.shipnum3);
                dictionary.Add(count, uoeMergeDateInfo);
            }
            //if (UoeCommonFnc.ToStringFromByteStrAry(mazda_h.seccd4).Trim() != string.Empty) // DEL 2011/05/27
            if (UoeCommonFnc.ToInt32FromByteStrAry(mazda_h.shipnum4) != 0)  // ADD 2011/05/27
            {
                count++;
                UOEMergeDateInfo uoeMergeDateInfo = new UOEMergeDateInfo();
                uoeMergeDateInfo.SectionCode = UoeCommonFnc.ToStringFromByteStrAry(mazda_h.seccd4);
                uoeMergeDateInfo.SlipNo = UoeCommonFnc.ToStringFromByteStrAry(mazda_h.slipcd4);
                uoeMergeDateInfo.ShipCnt = UoeCommonFnc.ToInt32FromByteStrAry(mazda_h.shipnum4);
                dictionary.Add(count, uoeMergeDateInfo);
            }
            //if (UoeCommonFnc.ToStringFromByteStrAry(mazda_h.seccd5).Trim() != string.Empty) // DEL 2011/05/27
            if (UoeCommonFnc.ToInt32FromByteStrAry(mazda_h.shipnum5) != 0)  // ADD 2011/05/27
            {
                count++;
                UOEMergeDateInfo uoeMergeDateInfo = new UOEMergeDateInfo();
                uoeMergeDateInfo.SectionCode = UoeCommonFnc.ToStringFromByteStrAry(mazda_h.seccd5);
                uoeMergeDateInfo.SlipNo = UoeCommonFnc.ToStringFromByteStrAry(mazda_h.slipcd5);
                uoeMergeDateInfo.ShipCnt = UoeCommonFnc.ToInt32FromByteStrAry(mazda_h.shipnum5);
                dictionary.Add(count, uoeMergeDateInfo);
            }
            //if (UoeCommonFnc.ToStringFromByteStrAry(mazda_h.seccd6).Trim() != string.Empty) // DEL 2011/05/27
            if (UoeCommonFnc.ToInt32FromByteStrAry(mazda_h.shipnum6) != 0)  // ADD 2011/05/27
            {
                count++;
                UOEMergeDateInfo uoeMergeDateInfo = new UOEMergeDateInfo();
                uoeMergeDateInfo.SectionCode = UoeCommonFnc.ToStringFromByteStrAry(mazda_h.seccd6);
                uoeMergeDateInfo.SlipNo = UoeCommonFnc.ToStringFromByteStrAry(mazda_h.slipcd6);
                uoeMergeDateInfo.ShipCnt = UoeCommonFnc.ToInt32FromByteStrAry(mazda_h.shipnum6);
                dictionary.Add(count, uoeMergeDateInfo);
            }
            //if (UoeCommonFnc.ToStringFromByteStrAry(mazda_h.seccd7).Trim() != string.Empty) // DEL 2011/05/27
            if (UoeCommonFnc.ToInt32FromByteStrAry(mazda_h.shipnum7) != 0)  // ADD 2011/05/27
            {
                count++;
                UOEMergeDateInfo uoeMergeDateInfo = new UOEMergeDateInfo();
                uoeMergeDateInfo.SectionCode = UoeCommonFnc.ToStringFromByteStrAry(mazda_h.seccd7);
                uoeMergeDateInfo.SlipNo = UoeCommonFnc.ToStringFromByteStrAry(mazda_h.slipcd7);
                uoeMergeDateInfo.ShipCnt = UoeCommonFnc.ToInt32FromByteStrAry(mazda_h.shipnum7);
                dictionary.Add(count, uoeMergeDateInfo);
            }
            //if (UoeCommonFnc.ToStringFromByteStrAry(mazda_h.seccd8).Trim() != string.Empty) // DEL 2011/05/27
            if (UoeCommonFnc.ToInt32FromByteStrAry(mazda_h.shipnum8) != 0)  // ADD 2011/05/27
            {
                count++;
                UOEMergeDateInfo uoeMergeDateInfo = new UOEMergeDateInfo();
                uoeMergeDateInfo.SectionCode = UoeCommonFnc.ToStringFromByteStrAry(mazda_h.seccd8);
                uoeMergeDateInfo.SlipNo = UoeCommonFnc.ToStringFromByteStrAry(mazda_h.slipcd8);
                uoeMergeDateInfo.ShipCnt = UoeCommonFnc.ToInt32FromByteStrAry(mazda_h.shipnum8);
                dictionary.Add(count, uoeMergeDateInfo);
            }
            //if (UoeCommonFnc.ToStringFromByteStrAry(mazda_h.seccd9).Trim() != string.Empty) // DEL 2011/05/27
            if (UoeCommonFnc.ToInt32FromByteStrAry(mazda_h.shipnum9) != 0)  // ADD 2011/05/27
            {
                count++;
                UOEMergeDateInfo uoeMergeDateInfo = new UOEMergeDateInfo();
                uoeMergeDateInfo.SectionCode = UoeCommonFnc.ToStringFromByteStrAry(mazda_h.seccd9);
                uoeMergeDateInfo.SlipNo = UoeCommonFnc.ToStringFromByteStrAry(mazda_h.slipcd9);
                uoeMergeDateInfo.ShipCnt = UoeCommonFnc.ToInt32FromByteStrAry(mazda_h.shipnum9);
                dictionary.Add(count, uoeMergeDateInfo);
            }
            //if (UoeCommonFnc.ToStringFromByteStrAry(mazda_h.seccd10).Trim() != string.Empty) // DEL 2011/05/27
            if (UoeCommonFnc.ToInt32FromByteStrAry(mazda_h.shipnum10) != 0)  // ADD 2011/05/27
            {
                count++;
                UOEMergeDateInfo uoeMergeDateInfo = new UOEMergeDateInfo();
                uoeMergeDateInfo.SectionCode = UoeCommonFnc.ToStringFromByteStrAry(mazda_h.seccd10);
                uoeMergeDateInfo.SlipNo = UoeCommonFnc.ToStringFromByteStrAry(mazda_h.slipcd10);
                uoeMergeDateInfo.ShipCnt = UoeCommonFnc.ToInt32FromByteStrAry(mazda_h.shipnum10);
                dictionary.Add(count, uoeMergeDateInfo);
            }

            uoeMergeDateDic = dictionary;
        }
        #endregion

        # region  -- ���YWeb-UOE�����񓚃f�[�^�N���X --
        /// <summary>
        /// �}�V�_�����񓚃t�@�C�����{�́�
        /// </summary>
        private class MAZDA_H
        {
            #region -- ���ו� --
            public byte[] seqno = new byte[2];	    //           �����r�d�p��
            public byte[] bhnum = new byte[12];		//           ���i�ԍ�
            public byte[] trle = new byte[2];		//           �U�փ��x��
            public byte[] trsu = new byte[2];		//           �U�փT�t�B�b�N�X
            public byte[] num = new byte[2];	    //           ����
            public byte[] ordnum = new byte[5];	    //           ������
            public byte[] shiptt = new byte[5];		//           �o�א����v
            public byte[] bonum = new byte[5];		//           �a�n��
            public byte[] bocd = new byte[1];		//           �a�n�R�[�h
            public byte[] bhnam = new byte[20];		//           ���i��
            public byte[] concc = new byte[1];	    //           ���i���敪
            public byte[] bhnums = new byte[12];	//           ���i�ԍ��i�����j
            public byte[] comcd = new byte[2];		//           �݊����R�[�h
            public byte[] unitpr = new byte[7];		//           �P���i�d�؁j
            public byte[] retpr = new byte[7];	    //           ��]�������i
            public byte[] seccd1 = new byte[2];	    //           ���_�R�[�h1
            public byte[] slipcd1 = new byte[7];	//           �`�[��1
            public byte[] shipnum1 = new byte[5];	//           �o�א�1
            public byte[] seccd2 = new byte[2];    	//           ���_�R�[�h2
            public byte[] slipcd2 = new byte[7];	//           �`�[��2
            public byte[] shipnum2 = new byte[5];	//           �o�א�2
            public byte[] seccd3 = new byte[2];	    //           ���_�R�[�h3
            public byte[] slipcd3 = new byte[7];	//           �`�[��3
            public byte[] shipnum3 = new byte[5];	//           �o�א�3
            public byte[] seccd4 = new byte[2];	    //           ���_�R�[�h4
            public byte[] slipcd4 = new byte[7];	//           �`�[��4
            public byte[] shipnum4 = new byte[5];	//           �o�א�4
            public byte[] seccd5 = new byte[2];	    //           ���_�R�[�h5
            public byte[] slipcd5 = new byte[7];	//           �`�[��5
            public byte[] shipnum5 = new byte[5];	//           �o�א�5
            public byte[] seccd6 = new byte[2];	    //           ���_�R�[�h6
            public byte[] slipcd6 = new byte[7];	//           �`�[��6
            public byte[] shipnum6 = new byte[5];	//           �o�א�6
            public byte[] seccd7 = new byte[2];	    //           ���_�R�[�h7
            public byte[] slipcd7 = new byte[7];	//           �`�[��7
            public byte[] shipnum7 = new byte[5];	//           �o�א�7
            public byte[] seccd8 = new byte[2];	    //           ���_�R�[�h8
            public byte[] slipcd8 = new byte[7];	//           �`�[��8
            public byte[] shipnum8 = new byte[5];	//           �o�א�8
            public byte[] seccd9 = new byte[2];	    //           ���_�R�[�h9
            public byte[] slipcd9 = new byte[7];	//           �`�[��9
            public byte[] shipnum9 = new byte[5];	//           �o�א�9
            public byte[] seccd10 = new byte[2];	//           ���_�R�[�h10
            public byte[] slipcd10 = new byte[7];	//           �`�[��10
            public byte[] shipnum10 = new byte[5];	//           �o�א�10
            public byte[] status1 = new byte[2];	//           �X�e�[�^�X1
            public byte[] mcnum1 = new byte[4];		//           �l�b������1
            public byte[] didate1 = new byte[8];	//           ���͂���1
            public byte[] status2 = new byte[2];	//           �X�e�[�^�X2
            public byte[] mcnum2 = new byte[4];		//           �l�b������2
            public byte[] didate2 = new byte[8];	//           ���͂���2
            public byte[] status3 = new byte[2];	//           �X�e�[�^�X3
            public byte[] mcnum3 = new byte[4];		//           �l�b������3
            public byte[] didate3 = new byte[8];	//           ���͂���3
            public byte[] status4 = new byte[2];	//           �X�e�[�^�X4
            public byte[] mcnum4 = new byte[4];		//           �l�b������4
            public byte[] didate4 = new byte[8];	//           ���͂���4
            public byte[] status5 = new byte[2];	//           �X�e�[�^�X5
            public byte[] mcnum5 = new byte[4];		//           �l�b������5
            public byte[] didate5 = new byte[8];	//           ���͂���5
            public byte[] cmto = new byte[30];		//           �R�����g
            #endregion -- ���ו� --

            /// <summary>	
            /// �R���X�g���N�^�[
            /// </summary>
            public MAZDA_H()
            {
                Clear(0x00);
            }

            public void Clear(byte cd)
            {
                UoeCommonFnc.MemSet(ref seqno, cd, seqno.Length);
                UoeCommonFnc.MemSet(ref bhnum, cd, bhnum.Length);
                UoeCommonFnc.MemSet(ref trle, cd, trle.Length);
                UoeCommonFnc.MemSet(ref trsu, cd, trsu.Length);
                UoeCommonFnc.MemSet(ref num, cd, num.Length);
                UoeCommonFnc.MemSet(ref ordnum, cd, ordnum.Length);
                UoeCommonFnc.MemSet(ref shiptt, cd, shiptt.Length);
                UoeCommonFnc.MemSet(ref bonum, cd, bonum.Length);
                UoeCommonFnc.MemSet(ref bocd, cd, bocd.Length);
                UoeCommonFnc.MemSet(ref bhnam, cd, bhnam.Length);
                UoeCommonFnc.MemSet(ref concc, cd, concc.Length);
                UoeCommonFnc.MemSet(ref bhnums, cd, bhnums.Length);
                UoeCommonFnc.MemSet(ref comcd, cd, comcd.Length);
                UoeCommonFnc.MemSet(ref unitpr, cd, unitpr.Length);
                UoeCommonFnc.MemSet(ref retpr, cd, retpr.Length);
                UoeCommonFnc.MemSet(ref seccd1, cd, seccd1.Length);
                UoeCommonFnc.MemSet(ref slipcd1, cd, slipcd1.Length);
                UoeCommonFnc.MemSet(ref shipnum1, cd, shipnum1.Length);
                UoeCommonFnc.MemSet(ref seccd2, cd, seccd2.Length);
                UoeCommonFnc.MemSet(ref slipcd2, cd, slipcd2.Length);
                UoeCommonFnc.MemSet(ref shipnum2, cd, shipnum2.Length);
                UoeCommonFnc.MemSet(ref seccd3, cd, seccd3.Length);
                UoeCommonFnc.MemSet(ref slipcd3, cd, slipcd3.Length);
                UoeCommonFnc.MemSet(ref shipnum3, cd, shipnum3.Length);
                UoeCommonFnc.MemSet(ref seccd4, cd, seccd4.Length);
                UoeCommonFnc.MemSet(ref slipcd4, cd, slipcd4.Length);
                UoeCommonFnc.MemSet(ref shipnum4, cd, shipnum4.Length);
                UoeCommonFnc.MemSet(ref seccd5, cd, seccd5.Length);
                UoeCommonFnc.MemSet(ref slipcd5, cd, slipcd5.Length);
                UoeCommonFnc.MemSet(ref shipnum5, cd, shipnum5.Length);
                UoeCommonFnc.MemSet(ref seccd6, cd, seccd6.Length);
                UoeCommonFnc.MemSet(ref slipcd6, cd, slipcd6.Length);
                UoeCommonFnc.MemSet(ref shipnum6, cd, shipnum6.Length);
                UoeCommonFnc.MemSet(ref seccd7, cd, seccd7.Length);
                UoeCommonFnc.MemSet(ref slipcd7, cd, slipcd7.Length);
                UoeCommonFnc.MemSet(ref shipnum7, cd, shipnum7.Length);
                UoeCommonFnc.MemSet(ref seccd8, cd, seccd8.Length);
                UoeCommonFnc.MemSet(ref slipcd8, cd, slipcd8.Length);
                UoeCommonFnc.MemSet(ref shipnum8, cd, shipnum8.Length);
                UoeCommonFnc.MemSet(ref seccd9, cd, seccd9.Length);
                UoeCommonFnc.MemSet(ref slipcd9, cd, slipcd9.Length);
                UoeCommonFnc.MemSet(ref shipnum9, cd, shipnum9.Length);
                UoeCommonFnc.MemSet(ref seccd10, cd, seccd10.Length);
                UoeCommonFnc.MemSet(ref slipcd10, cd, slipcd10.Length);
                UoeCommonFnc.MemSet(ref shipnum10, cd, shipnum10.Length);
                UoeCommonFnc.MemSet(ref status1, cd, status1.Length);
                UoeCommonFnc.MemSet(ref mcnum1, cd, mcnum1.Length);
                UoeCommonFnc.MemSet(ref didate1, cd, didate1.Length);
                UoeCommonFnc.MemSet(ref status2, cd, status2.Length);
                UoeCommonFnc.MemSet(ref mcnum2, cd, mcnum2.Length);
                UoeCommonFnc.MemSet(ref didate2, cd, didate3.Length);
                UoeCommonFnc.MemSet(ref status3, cd, status3.Length);
                UoeCommonFnc.MemSet(ref mcnum3, cd, mcnum3.Length);
                UoeCommonFnc.MemSet(ref didate3, cd, didate3.Length);
                UoeCommonFnc.MemSet(ref status4, cd, status4.Length);
                UoeCommonFnc.MemSet(ref mcnum4, cd, mcnum4.Length);
                UoeCommonFnc.MemSet(ref didate4, cd, didate4.Length);
                UoeCommonFnc.MemSet(ref status5, cd, status5.Length);
                UoeCommonFnc.MemSet(ref mcnum5, cd, mcnum5.Length);
                UoeCommonFnc.MemSet(ref didate5, cd, didate5.Length);
                UoeCommonFnc.MemSet(ref cmto, cd, cmto.Length);
            }
        }
        # endregion

        # region  -- ���_�A�`�[���A�o�א��N���X --
        /// <summary>
        /// ���_�A�`�[���A�o�א��N���X�i�����񓚃f�[�^��UOE�����f�[�^�ɔ��f�p�j
        /// </summary>
        private class UOEMergeDateInfo
        {
            /// <summary>���_�R�[�h</summary>
            private string _sectionCode = string.Empty;

            /// <summary>�`�[��</summary>
            private string _slipNo = string.Empty;

            /// <summary>�o�א�</summary>
            private int _shipCnt;

            /// public propaty name  :  SectionCode
            /// <summary>���_�R�[�h</summary>
            /// ----------------------------------------------------------------------
            /// <remarks>
            /// <br>note             :   ���_�R�[�h</br>
            /// <br>Programer        :   ������</br>
            /// </remarks>
            public string SectionCode
            {
                get { return _sectionCode; }
                set { _sectionCode = value; }
            }

            /// public propaty name  :  SlipNo
            /// <summary>�`�[��</summary>
            /// ----------------------------------------------------------------------
            /// <remarks>
            /// <br>note             :   �`�[��</br>
            /// <br>Programer        :   ������</br>
            /// </remarks>
            public string SlipNo
            {
                get { return _slipNo; }
                set { _slipNo = value; }
            }

            /// public propaty name  :  ShipCnt
            /// <summary>�o�א�</summary>
            /// ----------------------------------------------------------------------
            /// <remarks>
            /// <br>note             :   �o�א�</br>
            /// <br>Programer        :   ������</br>
            /// </remarks>
            public int ShipCnt
            {
                get { return _shipCnt; }
                set { _shipCnt = value; }
            }
        }
        #endregion
    }
}
