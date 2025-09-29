//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �g���^�񓚃f�[�^�捞����
// �v���O�����T�v   : UOE�����f�[�^�Ɣ����񓚃f�[�^�̂����킹���s���A
//                    ����E�d���f�[�^�̍쐬���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10507391-00 �쐬�S�� : �����
// �� �� ��  2010/01/04  �C�����e : �V�K�쐬
//                                 �y�v��No.6�zUOE�����f�[�^�Ɣ����񓚃f�[�^�̂����킹���s���A����E�d���f�[�^�̍쐬���s��
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10507391-00 �쐬�S�� : �����
// �C �� ��  2010/01/19  �C�����e : �d�����׃f�[�^�����o���鏈����ǉ�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10507391-00 �쐬�S�� : �����
// �C �� ��  2010/01/22  �C�����e : redmine#2554 �i���X�V�p���b�Z�[�W��ʂ̒ǉ�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10607734-00 �쐬�S�� : �� ��
// �C �� ��  2011/01/30  �C�����e : UOE����������
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ������
// �C �� ��  2011/11/12  �C�����e : Redmine:26485
//                                  Redmine�d�l�A�� �̑Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ������
// �C �� ��  2011/11/29  �C�����e : Redmine:7733
//                                  Redmine�d�l�A�� �̑Ή�(�ďC��)
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : yangmj
// �� �� ��  2011/12/15  �C�����e : Redmine#27386�g���^UOEWeb�^�N�e�B�[�i�Ԃ̔����Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : FSI ����
// �� �� ��  2012/09/20  �C�����e : �i�ԃ`�F�b�N�����̏C��
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11370054-00 �쐬�S�� : 30757 ���X�؋M�p
// �� �� ��  2017/07/12  �C�����e : �g���^�VWEBUOE���{�b�g�Ή�
//                                  �A�����o�b�N�A�b�v�f�[�^�̖����ɃS�~���܂܂��
//                                    ������Q�Ή�
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Library.Resources;
using System.Collections;
using Broadleaf.Application.UIData;
using System.IO;
using System.Data;
using System.Globalization;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Windows.Forms;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// �g���^�񓚃f�[�^�捞�����A�N�Z�X�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �g���^�񓚃f�[�^�捞�����̃A�N�Z�X������s���܂��B</br>
    /// <br>Programmer : �����</br>
    /// <br>Date       : 2010/01/04</br>
    /// <br>UpdateNote : 2010/01/19 �����</br>
    /// <br>             redmine#2510 �d�����׃f�[�^�����o���鏈����ǉ�</br>
    /// <br>UpdateNote : 2010/01/22 �����</br>
    /// <br>             redmine#2554 �i���X�V�p���b�Z�[�W��ʂ̒ǉ�</br>
    /// <br>Update Note : 2011/01/30 �� ��</br>
    /// <br>              UOE����������</br>
    /// <br>Update Note : 2017/07/12 30757 ���X�؋M�p</br>
    /// <br>�Ǘ��ԍ�    : 11370054-00 �g���^�VWEBUOE���{�b�g�Ή�</br>
    /// <br>              �A�����o�b�N�A�b�v�f�[�^�̖����ɃS�~���܂܂�������Q�Ή�</br>
    /// </remarks>
    public class UOEOrderDtlToyotaAcs
    {
        # region �v���C�x�[�g�ϐ�
        /*----------------------------------------------------------------------------------*/
        private DataTable _dataTable;
        private UOESupplierAcs _uOESupplierAcs;
        private UOEOrderDtlAcs _uOEOrderDtlAcs;
        private UoeSndRcvCtlAcs _uoeSndRcvCtlAcs;

        private DN_H dn_h = new DN_H();
        private int _systemDivCd = 0;
        private List<UOEOrderDtlWork> _uOEOrderDtlWorkList = new List<UOEOrderDtlWork>();
        private List<StockDetailWork> _stockDetailWorkList = new List<StockDetailWork>();
        # endregion

        # region �v���C�x�[�g�萔
        /*----------------------------------------------------------------------------------*/
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
        //------ADD BY ������ on 2011/11/12 for Redmine#26485------>>>>>>>
        /// <summary>
        /// �I�����C���ԍ�(�^�C�g��)	
        /// </summary>
        public static string ONLINENO = "OnlineNo";
        //------ADD BY ������ on 2011/11/12 for Redmine#26485------<<<<<<<

        //�w�b�h�G���[���b�Z�[�W
        private const string MSG_TRA = "��ݻ޸��ݴװ";	// 0x11  0xf1  0xf1  0xf1
        private const string MSG_UCD = "�����Ϻ��޴װ";	// 0x12  0xf7  0xf7
        private const string MSG_PAS = "�߽ܰ�޴װ";	// 0x14
        private const string MSG_RUS = "ٽ��ݴװ";	// 0x88
        private const string MSG_ELS = "����װ";	// 0x99
        private const string MSG_HEN = "�ݼ��ް�ż";	//       0xf2
        private const string MSG_NOU = "ɳ�ݺ���ż";	//       0xf3
        private const string MSG_DAT = "�ް�ż";	//       0xf4  0xf4  0xf4
        private const string MSG_STK = "�ò���ݴװ";	//       0xf5
        private const string MSG_KUF = "�����ر��̶";	//       0xc3
        private const string MSG_HTA = "ʯ�����ĳ���װ";	//       0xc4
        private const string MSG_FNC = "̫۰ɰ�ݺ���ż";	//       0xc5
        private const string MSG_KOC = "���������Ϻ��޴װ";	//       0xc6

        private const string COMMASSEMBLY_ID = "0103";
        private const string AUTOCOMMASSEMBLY_ID = "0104"; // ADD 2010/01/30

        private const Int32 ctBufLen = 3;		//���׃o�b�t�@�T�C�Y
        # endregion

        # region -- �R���X�g���N�^ --
        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : �I�t���C���Ή�</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2010/01/04</br>
        /// <br>UpdateNote : 2010/01/22 �����</br>
        /// <br>             redmine#2554 �i���X�V�p���b�Z�[�W��ʂ̒ǉ�</br>
        /// </remarks>
        public UOEOrderDtlToyotaAcs()
        {
            this._uOESupplierAcs = new UOESupplierAcs();
            this._uOEOrderDtlAcs = new UOEOrderDtlAcs();
            this._uoeSndRcvCtlAcs = new UoeSndRcvCtlAcs();

            // --- ADD 2010/01/22 ---------->>>>>
            // DB�X�V������������i���\���p�t�H�[������܂��B
            this._uoeSndRcvCtlAcs.UpdateProgress += new UoeSndRcvCtlAcs.OnUpdateProgress(this.CloseProgressForm);
            // --- ADD 2010/01/22 ----------<<<<<

            // �f�[�^�Z�b�g����\�z����
            this.DataTableColumnConstruction();
        }
        # endregion

        # region -- �������� --
        /// <summary>
        /// ��������
        /// </summary>
        /// <param name="toyotaAnswerDatePara">��ʏ��</param>
        /// <param name="errMessage">���b�Z�[�W</param>
        /// <param name="results">�I�����C���ԍ�results</param> //ADD BY ������ on 2011/11/12 for Redmine#26485 
        /// <returns>�`�F�b�N���ʁB�@0�F����G�@-1�F�ُ�</returns>
        /// <remarks>
        /// <br>Note       : RCV�����擾��������B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2010/01/04</br>
        /// <br>UpdateNote : 2010/01/19 �����</br>
        /// <br>             redmine#2510 �d�����׃f�[�^�����o���鏈����ǉ�</br>
        /// </remarks>
        //public int DoSearch(ToyotaAnswerDatePara toyotaAnswerDatePara, out string errMessage)//DEL BY ������ on 2011/11/12 for Redmine#26485 
        public int DoSearch(ToyotaAnswerDatePara toyotaAnswerDatePara, out string errMessage, ref List<string> results)//ADD BY ������ on 2011/11/12 for Redmine#26485 
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            errMessage = string.Empty;

            this._dataTable.Clear();

            List<UOEOrderDtlInfo> rcvDataDtlList;
            // RCV���擾����
            string fileName = toyotaAnswerDatePara.AnswerSaveFolder + "\\HATTU.RCV";
            //status = this.GetRCVData(out rcvDataDtlList, fileName, ref errMessage);//DEL BY ������ on 2011/11/12 for Redmine#26485
            //--------ADD BY ������ on 2011/11/12 for Redmine#26485 ---------->>>>>>>>>>>>>
            //�g���^bak�t�@�C��
            string toyotaFlod = toyotaAnswerDatePara.AnswerSaveFolder;
            string month = DateTime.Now.Month < 10 ? ("0" + DateTime.Now.Month.ToString()) : (DateTime.Now.Month.ToString());
            string hour = DateTime.Now.Hour < 10 ? ("0" + DateTime.Now.Hour.ToString()) : (DateTime.Now.Hour.ToString());
            string day = DateTime.Now.Day < 10 ? ("0" + DateTime.Now.Day.ToString()) : (DateTime.Now.Day.ToString());
            string minuet = DateTime.Now.Minute < 10 ? ("0" + DateTime.Now.Minute.ToString()) : (DateTime.Now.Minute.ToString());
            string second = DateTime.Now.Second < 10 ? ("0" + DateTime.Now.Second.ToString()) : (DateTime.Now.Second.ToString());
            string bakFileName = "HATTU_" + DateTime.Now.Year
                                           + month
                                           + day
                                           + hour
                                           + minuet
                                           + second
                                           + ".RCV";
            if (!File.Exists(toyotaFlod + "\\" + bakFileName))
            {
                CopyFile(fileName, toyotaFlod + "\\" + bakFileName);
            }
            status = this.GetRCVData(out rcvDataDtlList, toyotaFlod + "\\" + bakFileName, ref errMessage);
            //--------ADD BY ������ on 2011/11/12 for Redmine#26485 ----------<<<<<<<<<<<<<<<<

            if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {
                return status;
            }

            // RCV�̃f�[�^���Ȃ��ꍇ
            if (rcvDataDtlList.Count == 0)
            {
                return (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
            }

            // �����񓚃f�[�^�̃��}�[�N2
            //--------ADD BY ������ on 2011/11/12 for Redmine#26485 ---------->>>>>>>>>>>>>>>>
            List<String> uoeRemarks = new List<String>();
            for (int i = 0; i < rcvDataDtlList.Count; i++)
            {
                uoeRemarks.Add(rcvDataDtlList[i].UoeRemark2);
            }
            //--------ADD BY ������ on 2011/11/12 for Redmine#26485 ----------<<<<<<<<<<<<<<<<
            string uoeRemark2 = rcvDataDtlList[0].UoeRemark2;
            // �V�X�e���敪
            this._systemDivCd = Int32.Parse(uoeRemark2.Substring(1, 1));

            // UOE�����f�[�^������,���������̐ݒ�
            UOESendProcCndtnPara para = new UOESendProcCndtnPara();
            para.EnterpriseCode = toyotaAnswerDatePara.EnterpriseCode; //��ƃR�[�h					
            para.CashRegisterNo = 0; //���W�ԍ�					
            para.SystemDivCd = this._systemDivCd; //�V�X�e���敪	
            para.St_InputDay = DateTime.MinValue; //�J�n���͓�					
            para.Ed_InputDay = DateTime.MaxValue; //�I�����͓�					
            para.CustomerCode = 0; //���Ӑ�R�[�h					
            para.UOESupplierCd = toyotaAnswerDatePara.UOESupplierCd; //UOE������R�[�h					
            para.St_OnlineNo = int.MinValue; //�J�n�ďo�ԍ�					
            para.Ed_OnlineNo = int.MaxValue; //�I���ďo�ԍ�					
            para.DataSendCodes = new int[] { 1 }; //�f�[�^���M�t���O					

            // UOE�����f�[�^������
            List<UOEOrderDtlWork> uOEOrderDtlWorkList = new List<UOEOrderDtlWork>(); // UOE�����f�[�^
            List<StockDetailWork> stockDetailWorkList = new List<StockDetailWork>(); // �d�����׃f�[�^

            status = this._uOEOrderDtlAcs.Search(para, out uOEOrderDtlWorkList, out stockDetailWorkList, out errMessage);

            if (status != 0)
            {
                if (uOEOrderDtlWorkList == null || uOEOrderDtlWorkList.Count == 0)
                {
                    return (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                }
                return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }

            // �g���^���������ō쐬���ꂽ�f�[�^�̍i����
            //List<UOEOrderDtlWork> retuOEOrderDtlWorkList = this.FilterUOEOrderDtlList(uOEOrderDtlWorkList, uoeRemark2);//DEL BY ������ on 2011/11/12 for Redmine#26485
            List<UOEOrderDtlWork> retuOEOrderDtlWorkList = this.FilterUOEOrderDtlList(uOEOrderDtlWorkList, uoeRemarks);//ADD BY ������ on 2011/11/12 for Redmine#26485

            // �i�荞�܂ꂽ�����f�[�^�Ƒ΂ɂȂ�d�����׃f�[�^�𒊏o
            List<StockDetailWork> retStockDetailWorkList = this.FilterStockDetailList(retuOEOrderDtlWorkList, stockDetailWorkList); // ADD 2010/01/19

            if (retuOEOrderDtlWorkList.Count == 0)
            {
                return (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
            }

            // �Ώ�UOE�����f�[�^���񓚔����f�[�^�̃\�[�g���Ń\�[�g
            retuOEOrderDtlWorkList.Sort(new UOEOrderDtlWorkComparer());
            //--------ADD BY ������ on 2011/11/12 for Redmine#26485 ---------->>>>>>>>>>>>>
            string message = "";
            results = OnlineMergerList(retuOEOrderDtlWorkList, rcvDataDtlList, ref message);
            if (results.Count > 0)
            {
                errMessage = message;
                status = (int)ConstantManagement.MethodResult.ctFNC_DO_END;
            }
            else
            {
                this.MergeList(ref retuOEOrderDtlWorkList, rcvDataDtlList);
            }
            //--------ADD BY ������ on 2011/11/12 for Redmine#26485 ----------<<<<<<<<<<<<<
            //this.MergeList(ref retuOEOrderDtlWorkList, rcvDataDtlList);//DEL BY ������ on 2011/11/12 for Redmine#26485

            // �f�[�^�Z�b�g�s��������
            this.DataTableAddRow(retuOEOrderDtlWorkList);

            // �m�菈���g�p
            this._uOEOrderDtlWorkList = retuOEOrderDtlWorkList;

            // --- ADD 2010/01/19 ---------->>>>>
            //this._stockDetailWorkList = stockDetailWorkList;
            this._stockDetailWorkList = retStockDetailWorkList;
            // --- ADD 2010/01/19 ----------<<<<<

            return status;
        }

        /// <summary>
        /// ��������
        /// </summary>
        /// <param name="toyotaAnswerDatePara">��ʏ��</param>
        /// <param name="errMessage">���b�Z�[�W</param>
        /// <param name="rem2">���}�[�N�Q</param>
        /// <param name="results">�I�����C���ԍ�results</param> //ADD BY ������ on 2011/11/29 for Redmine#7733 
        /// <returns>�`�F�b�N���ʁB�@0�F����G�@-1�F�ُ�</returns>
        /// <remarks>
        /// <br>Note       : RCV�����擾��������B</br>
        /// <br>Programmer : �� ��</br>
        /// <br>Date       : 2011/01/30</br>
        /// </remarks>
        //public int DoSearch(ToyotaAnswerDatePara toyotaAnswerDatePara, out string errMessage, string rem2) //DEL BY ������ on 2011/11/29 for Redmine#7733
        public int DoSearch(ToyotaAnswerDatePara toyotaAnswerDatePara, out string errMessage, List<string> rem2, ref List<string> results)//ADD BY ������ on 2011/11/29 for Redmine#7733
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            errMessage = string.Empty;

            this._dataTable.Clear();

            List<UOEOrderDtlInfo> rcvDataDtlList;
            // RCV���擾����
            string fileName = toyotaAnswerDatePara.AnswerSaveFolder + "\\HATTU.RCV";
            //status = this.GetRCVData(out rcvDataDtlList, fileName, ref errMessage);//ADD BY ������ on 2011/11/29 for Redmine#7733
            //--------ADD BY ������ on 2011/11/29 for Redmine#7733 ---------->>>>>>>>>>>>>
            //�g���^bak�t�@�C��
            string toyotaFlod = toyotaAnswerDatePara.AnswerSaveFolder;
            string month = DateTime.Now.Month < 10 ? ("0" + DateTime.Now.Month.ToString()) : (DateTime.Now.Month.ToString());
            string hour = DateTime.Now.Hour < 10 ? ("0" + DateTime.Now.Hour.ToString()) : (DateTime.Now.Hour.ToString());
            string day = DateTime.Now.Day < 10 ? ("0" + DateTime.Now.Day.ToString()) : (DateTime.Now.Day.ToString());
            string minuet = DateTime.Now.Minute < 10 ? ("0" + DateTime.Now.Minute.ToString()) : (DateTime.Now.Minute.ToString());
            string second = DateTime.Now.Second < 10 ? ("0" + DateTime.Now.Second.ToString()) : (DateTime.Now.Second.ToString());
            string bakFileName = "HATTU_" + DateTime.Now.Year
                                           + month
                                           + day
                                           + hour
                                           + minuet
                                           + second
                                           + ".RCV";
            if (!File.Exists(toyotaFlod + "\\" + bakFileName))
            {
                CopyFile(fileName, toyotaFlod + "\\" + bakFileName);
            }
            status = this.GetRCVData(out rcvDataDtlList, toyotaFlod + "\\" + bakFileName, ref errMessage);
            //--------ADD BY ������ on 2011/11/29 for Redmine#7733 ----------<<<<<<<<<<<<<<<<

            if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {
                return status;
            }

            // RCV�̃f�[�^���Ȃ��ꍇ
            if (rcvDataDtlList.Count == 0)
            {
                return (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
            }

            // �����񓚃f�[�^�̃��}�[�N2
            //string uoeRemark2 = rem2;//DEL BY ������ on 2011/11/29 for Redmine#7733
            string uoeRemark2 = rem2[0];//DEL BY ������ on 2011/11/29 for Redmine#7733
            // �V�X�e���敪
            this._systemDivCd = Int32.Parse(uoeRemark2.Substring(1, 1));

            // UOE�����f�[�^������,���������̐ݒ�
            UOESendProcCndtnPara para = new UOESendProcCndtnPara();
            para.EnterpriseCode = toyotaAnswerDatePara.EnterpriseCode; //��ƃR�[�h					
            para.CashRegisterNo = 0; //���W�ԍ�					
            para.SystemDivCd = this._systemDivCd; //�V�X�e���敪	
            para.St_InputDay = DateTime.MinValue; //�J�n���͓�					
            para.Ed_InputDay = DateTime.MaxValue; //�I�����͓�					
            para.CustomerCode = 0; //���Ӑ�R�[�h					
            para.UOESupplierCd = toyotaAnswerDatePara.UOESupplierCd; //UOE������R�[�h					
            para.St_OnlineNo = int.MinValue; //�J�n�ďo�ԍ�					
            para.Ed_OnlineNo = int.MaxValue; //�I���ďo�ԍ�					
            para.DataSendCodes = new int[] { 1 }; //�f�[�^���M�t���O					

            // UOE�����f�[�^������
            List<UOEOrderDtlWork> uOEOrderDtlWorkList = new List<UOEOrderDtlWork>(); // UOE�����f�[�^
            List<StockDetailWork> stockDetailWorkList = new List<StockDetailWork>(); // �d�����׃f�[�^

            status = this._uOEOrderDtlAcs.Search(para, out uOEOrderDtlWorkList, out stockDetailWorkList, out errMessage);

            if (status != 0)
            {
                if (uOEOrderDtlWorkList == null || uOEOrderDtlWorkList.Count == 0)
                {
                    return (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                }
                return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }

            // �g���^���������ō쐬���ꂽ�f�[�^�̍i����
            //List<UOEOrderDtlWork> retuOEOrderDtlWorkList = this.FilterUOEOrderDtlList(uOEOrderDtlWorkList, uoeRemark2);//DEL BY ������ on 2011/11/29 for Redmine#7733
            List<UOEOrderDtlWork> retuOEOrderDtlWorkList = this.FilterUOEOrderDtlList(uOEOrderDtlWorkList, rem2);// ADD BY ������ on 2011/11/29 for Redmine#7733

            // �i�荞�܂ꂽ�����f�[�^�Ƒ΂ɂȂ�d�����׃f�[�^�𒊏o
            List<StockDetailWork> retStockDetailWorkList = this.FilterStockDetailList(retuOEOrderDtlWorkList, stockDetailWorkList); // ADD 2010/01/19

            if (retuOEOrderDtlWorkList.Count == 0)
            {
                return (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
            }

            // �Ώ�UOE�����f�[�^���񓚔����f�[�^�̃\�[�g���Ń\�[�g
            retuOEOrderDtlWorkList.Sort(new UOEOrderDtlWorkComparer());
            //--------ADD BY ������ on 2011/11/29 for Redmine#7733 ---------->>>>>>>>>>>>>
            string message = "";
            results = OnlineMergerList(retuOEOrderDtlWorkList, rcvDataDtlList, ref message);
            if (results.Count > 0)
            {
                errMessage = message;
                status = (int)ConstantManagement.MethodResult.ctFNC_DO_END;
            }
            else
            {
            this.MergeList(ref retuOEOrderDtlWorkList, rcvDataDtlList);
            }
            //--------ADD BY ������ on 2011/11/29 for Redmine#7733 ----------<<<<<<<<<<<<<
            //this.MergeList(ref retuOEOrderDtlWorkList, rcvDataDtlList);//DEL BY ������ on 2011/11/29 for Redmine#7733

            // �f�[�^�Z�b�g�s��������
            this.DataTableAddRow(retuOEOrderDtlWorkList);

            // �m�菈���g�p
            this._uOEOrderDtlWorkList = retuOEOrderDtlWorkList;

            this._stockDetailWorkList = retStockDetailWorkList;

            return status;
        }

        //--------ADD BY ������ on 2011/11/12 for Redmine#26485 ---------->>>>>>>>>>>>>
        //---UPD 2017/07/12 30757 ���X�؋M�p �g���^�VWEBUOE���{�b�g�Ή� ----->>>>>
        ///// <summary>
        ///// bak�t�@�C��
        ///// </summary>
        ///// <param name="srcPath"></param>
        ///// <param name="dirPath"></param> 
        ///// <br>Note       : bak�t�@�C���B</br>
        ///// <br>Programmer : ������</br>
        ///// <br>Date       : 2011/11/12</br>
        ///// </remarks>
        //private void CopyFile(string srcPath, string dirPath)
        //{
        //    FileStream srcFile = new FileStream(srcPath, FileMode.Open);
        //    FileStream dirFile = new FileStream(dirPath, FileMode.Create);
        //    BufferedStream bs = null;
        //    BufferedStream bs2 = null;
        //    try
        //    {
        //        byte[] data = new byte[1024];
        //        bs = new BufferedStream(srcFile);
        //        bs2 = new BufferedStream(dirFile);
        //        while (bs.Read(data, 0, data.Length) > 0)
        //        {
        //            bs2.Write(data, 0, data.Length);
        //            bs2.Flush();
        //        }
        //    }
        //    catch (IOException)
        //    {
        //        return;
        //    }
        //    finally
        //    {
        //        bs.Close();
        //        bs2.Close();
        //        srcFile.Close();
        //        dirFile.Close();
        //    }
        //}
        /// <summary>
        /// �R�s�[���t�@�C�����R�s�[��t�@�C���ɃR�s�[����
        /// </summary>
        /// <param name="srcPath">�R�s�[���t�@�C�����i�t���p�X�j</param>
        /// <param name="dirPath">�R�s�[��t�@�C�����i�t���p�X�j</param> 
        /// <remarks>
        /// <br>Note       : bak�t�@�C���B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011/11/12</br>
        /// <br>Update Note: 2017/07/12 30757 ���X�؋M�p</br>
        /// <br>�Ǘ��ԍ�   : 11370054-00 �g���^�VWEBUOE���{�b�g�Ή�</br>
        /// <br>             �A�����o�b�N�A�b�v�f�[�^�̖����ɃS�~���܂܂�������Q�Ή�</br>
        /// </remarks>
        private void CopyFile( string srcPath, string dirPath )
        {
            File.Copy( srcPath, dirPath );
        }
        //---UPD 2017/07/12 30757 ���X�؋M�p �g���^�VWEBUOE���{�b�g�Ή� -----<<<<<

        /// <summary>
        /// �񓚃f�[�^�Ɣ����f�[�^�̐������`�F�b�N
        /// </summary>
        /// <param name="workList"></param>
        /// <param name="dateList"></param>
        /// <param name="message"></param> 
        /// <returns>List</returns>
        /// <br>Note       : �񓚃f�[�^�Ɣ����f�[�^�̐������`�F�b�N�B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011/11/12</br>
        private List<string> OnlineMergerList(List<UOEOrderDtlWork> workList, List<UOEOrderDtlInfo> dateList, ref string message)
        {
            List<string> results = new List<string>();
            for (int i = 0; i < workList.Count; i++)
            {
                if (i < dateList.Count)
                {
                    //UOE��փ}�[�N�Ȃ�					
                    // --- DEL K2012/09/20 ---------------------------->>>>>
                    //if ("".Equals(dateList[i].UOESubstMark.Trim()) || null == dateList[i].UOESubstMark)
                    // --- DEL K2012/09/20 ----------------------------<<<<<
                    // --- ADD K2012/09/20 ---------------------------->>>>>
                    if ("".Equals(dateList[i].UOESubstMark.Trim()) || null == dateList[i].UOESubstMark || "0".Equals(dateList[i].UOESubstMark.Trim()))
                    // --- ADD K2012/09/20 ----------------------------<<<<<
                    {
                        //if (dateList[i].AnswerPartsNo.Trim() != workList[i].GoodsNo) //DEL BY ������ on 2011/11/29 for Redmine#7733
                        //if (dateList[i].AnswerPartsNo.Trim() != workList[i].GoodsNoNoneHyphen)//ADD BY ������ on 2011/11/29 for Redmine#7733 // DEL 2011/12/15 yangmj for Redmine#
                        if (dateList[i].AnswerPartsNo.Trim().Replace("-", "") != workList[i].GoodsNoNoneHyphen) // ADD 2011/12/15 yangmj for Redmine#
                        {
                            message = "���L�̃I�����C���ԍ��̖��ד��e���قȂ�܂��̂�" + "\r\n" + "�捞�����𒆒f�������܂��B \r\n ";
                            if (results.Contains(workList[i].OnlineNo.ToString()))
                            {
                                continue;
                            }
                            else
                            {
                                results.Add(workList[i].OnlineNo.ToString());
                            }
                        }
                    }
                }
            }
            return results;
        }

        /// <summary>
        /// �g���^���������ō쐬���ꂽ�f�[�^�̍i����
        /// </summary>
        /// <param name="list">RCV���</param>
        /// <param name="remark2">���}�[�N2</param>
        /// <returns>����</returns>
        /// <remarks>
        /// <br>Note       : �g���^���������ō쐬���ꂽ�f�[�^�̍i���݁B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011/11/12</br>
        /// </remarks>
        private List<UOEOrderDtlWork> FilterUOEOrderDtlList(List<UOEOrderDtlWork> list, List<String> remark2)
        {
            List<UOEOrderDtlWork> retList = new List<UOEOrderDtlWork>();

            foreach (UOEOrderDtlWork work in list)
            {
                for (int i = 0; i < remark2.Count; i++)
                {
                    if (work.CommAssemblyId == COMMASSEMBLY_ID
                        && work.UoeRemark2 == remark2[i]
                        && work.DataRecoverDiv == 0)
                    {
                        retList.Add(work);
                        break;
                    }
                    //--------ADD BY ������ on 2011/11/29-------------->>>>>>>>>>
                    else if (work.CommAssemblyId == AUTOCOMMASSEMBLY_ID
                         && work.UoeRemark2 == remark2[i]
                         && work.DataRecoverDiv == 0)
                    {
                        retList.Add(work);
                        break;
                    }
                   //--------ADD BY ������ on 2011/11/29--------------<<<<<<<<<<<<
                }
            }

            return retList;
        }
        //--------ADD BY ������ on 2011/11/12 for Redmine#26485 ----------<<<<<<<<<<<<<<<<


        /// <summary>
        /// RCV���擾����
        /// </summary>
        /// <param name="rcvDataDtlList">RCV���</param>
        /// <param name="filePathName">�t�@�C�����O</param>
        /// <param name="errMessage">���b�Z�[�W</param>
        /// <returns>��������</returns>
        /// <remarks>
        /// <br>Note       : RCV�����擾��������B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2010/01/04</br>
        /// </remarks>
        private int GetRCVData(out List<UOEOrderDtlInfo> rcvDataDtlList, string filePathName, ref string errMessage)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

            // RCV���
            rcvDataDtlList = new List<UOEOrderDtlInfo>();

            FileStream fileStream = null;
            try
            {
                // �g�p�����f
                try
                {
                    fileStream = new FileStream(filePathName, FileMode.Open, FileAccess.Read, FileShare.None);
                }
                catch(IOException)
                {
                    errMessage = "�����񓚃t�@�C�����g�p���ł��B";
                    // �ُ�ꍇ
                    return (int)ConstantManagement.MethodResult.ctFNC_WARNING;
                }

                int recordLength = 511;
                int num = (int)fileStream.Length / recordLength;

                for (int i = 0; i < num; i++)
                {
                    this.dn_h.Clear(0x00);

                    byte[] line = new byte[recordLength];
                    fileStream.Read(line, 0, line.Length);
                    this.FromByteArray(line);
                    this.ConverDNHToUOEOrderDtlInfo(ref rcvDataDtlList);
                }
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
        # endregion

        # region -- �m�菈�� --
        // --- ADD 2010/01/22 ---------->>>>>
        #region �i���\��

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
        // --- ADD 2010/01/22 ----------<<<<<

        /// <summary>
        /// �m�菈��
        /// </summary>
        /// <param name="toyotaAnswerDatePara">��ʏ��</param>
        /// <param name="errMessage">���b�Z�[�W</param>
        /// <returns>�`�F�b�N���ʁB�@0�F����G�@-1�F�ُ�</returns>
        /// <remarks>
        /// <br>Note       : �m�菈������B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2010/01/04</br>
        /// <br>UpdateNote : 2010/01/19 �����</br>
        /// <br>             redmine#2510 �d�����׃f�[�^�����o���鏈����ǉ�</br>
        /// </remarks>
        public int DoConfirm(ToyotaAnswerDatePara toyotaAnswerDatePara, out string errMessage)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            errMessage = string.Empty;

            // --- ADD 2010/01/19 ---------->>>>>
            if (_uOEOrderDtlWorkList.Count == 0 || _stockDetailWorkList.Count == 0)
            {
                errMessage = "�捞�����Ɏ��s���܂����B";
                return (-1);
            }
            // --- ADD 2010/01/19 ----------<<<<<

            // �����N���X
            UoeSndRcvCtlPara uoeSndRcvCtlPara = new UoeSndRcvCtlPara();
            uoeSndRcvCtlPara.BusinessCode = 1; // 1:���� 2:���� 3:�݌Ɋm�F 4:�������
            uoeSndRcvCtlPara.EnterpriseCode = toyotaAnswerDatePara.EnterpriseCode;
            uoeSndRcvCtlPara.SystemDivCd = this._systemDivCd;
            uoeSndRcvCtlPara.ProcessDiv = 1;            //0�F�ʏ�A1�F����

            status = this._uoeSndRcvCtlAcs.UoeSndRcvCtl(uoeSndRcvCtlPara, this._uOEOrderDtlWorkList, this._stockDetailWorkList, out errMessage);

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
        /// <br>Date       : 2010/01/04</br>
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
                    if (uOESupplier.LogicalDeleteCode == 0 && uOESupplier.CommAssemblyId == COMMASSEMBLY_ID)
                    {
                        outUOESupplierlilst.Add(uOESupplier);
                    }
                }
            }

            return status;
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
        /// <br>Date       : 2010/01/04</br>
        /// </remarks>
        private void DataTableColumnConstruction()
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
            table.Columns.Add(BOSHIPMENTCNT3, typeof(Int32)); // �o�א�(�^�C�g��)				
            table.Columns.Add(MAKERFOLLOWCNT, typeof(Int32)); // Ұ��̫۰��(�^�C�g��)	
            table.Columns.Add(ONLINENO, typeof(Int32)); // �I�����C���ԍ�(�^�C�g��)	  //ADD BY ������ on 2011/11/12 for Redmine#26485


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
            table.Columns[BOSLIPNO1].Caption = "�r�e"; // BO�`�[�ԍ�1(�^�C�g��)				
            table.Columns[BOSHIPMENTCNT1].Caption = "�o�א�"; // �o�א�(�^�C�g��)				
            table.Columns[BOSLIPNO2].Caption = "�g�e"; // BO�`�[�ԍ�2(�^�C�g��)				
            table.Columns[BOSHIPMENTCNT2].Caption = "�o�א�"; // �o�א�(�^�C�g��)				
            table.Columns[BOSLIPNO3].Caption = "�q�e"; // BO�`�[�ԍ�3(�^�C�g��)				
            table.Columns[BOSHIPMENTCNT3].Caption = "�o�א�"; // �o�א�(�^�C�g��)				
            table.Columns[MAKERFOLLOWCNT].Caption = "�l�e"; // Ұ��̫۰��(�^�C�g��)	
            table.Columns[ONLINENO].ColumnMapping = MappingType.Hidden; //ADD BY ������ on 2011/11/12 for Redmine#26485
            this._dataTable = table;
        }

        /// <summary>
        /// �f�[�^�Z�b�g�s��������
        /// </summary>
        /// <remarks>
        /// <br>Note       : �f�[�^�Z�b�g�s�����������s���܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2010/01/04</br>
        /// </remarks>
        private void DataTableAddRow(List<UOEOrderDtlWork> workList)
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
                if (work.HeadErrorMassage == string.Empty)
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
                //�r�e								
                row[BOSLIPNO1] = work.BOSlipNo1;
                //�o�א�								
                row[BOSHIPMENTCNT1] = work.BOShipmentCnt1;
                //�g�e								
                row[BOSLIPNO2] = work.BOSlipNo2;
                //�o�א�								
                row[BOSHIPMENTCNT2] = work.BOShipmentCnt2;
                //�q�e								
                row[BOSLIPNO3] = work.BOSlipNo3;
                //�o�א�								
                row[BOSHIPMENTCNT3] = work.BOShipmentCnt3;
                //�l�e								
                row[MAKERFOLLOWCNT] = work.MakerFollowCnt;
                //�I�����C���ԍ�
                row[ONLINENO] = work.OnlineNo; //ADD BY ������ on 2011/11/12 for Redmine#26485

                this._dataTable.Rows.Add(row);
                rowIndex++;
            }
        }
        # endregion

        # region -- ���̑����� --
        /// <summary>
        /// �g���^�����񓚃t�@�C����ں��ނ̏���
        /// </summary>
        /// <param name="rcvDataDtlList">ں��ރ��X�g</param>
        /// <remarks>
        /// <br>Note       : �g���^�����񓚃t�@�C����ں��ނ�����</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2010/01/04</br>
        /// </remarks>
        private void ConverDNHToUOEOrderDtlInfo(ref List<UOEOrderDtlInfo> rcvDataDtlList)
        {
            for (int i = 0; i < ctBufLen; i++)
            {
                UOEOrderDtlInfo uOEOrderDtlInfo = new UOEOrderDtlInfo();

                // ���}�[�N2
                uOEOrderDtlInfo.UoeRemark2 = UoeCommonFnc.ToStringFromByteStrAry(dn_h.rem2);
                // �񓚕i��
                uOEOrderDtlInfo.AnswerPartsNo = UoeCommonFnc.ToStringFromByteStrAry(dn_h.ln_h[i].hb);

                if (uOEOrderDtlInfo.AnswerPartsNo.Trim() == string.Empty)
                {
                    continue;
                }
                // �񓚕i��
                uOEOrderDtlInfo.AnswerPartsName = UoeCommonFnc.ToStringFromByteStrAry(dn_h.ln_h[i].hn);

                //��ւȂ�
                if (!((dn_h.ln_h[i].daita[0] == 0x00)
                || (dn_h.ln_h[i].daita[0] == 0x20)
                || (dn_h.ln_h[i].daita[0] == 0x30)))
                {
                    // ��֕i��
                    uOEOrderDtlInfo.SubstPartsNo = UoeCommonFnc.ToStringFromByteStrAry(dn_h.ln_h[i].hb);
                }

                // ���_�o�ɐ�						
                uOEOrderDtlInfo.UOESectOutGoodsCnt = UoeCommonFnc.ToInt32FromByteStrAry(dn_h.ln_h[i].su);
                // BO�o�ɐ�1							
                uOEOrderDtlInfo.BOShipmentCnt1 = UoeCommonFnc.ToInt32FromByteStrAry(dn_h.ln_h[i].sbfsu);
                // BO�o�ɐ�2	
                uOEOrderDtlInfo.BOShipmentCnt2 = UoeCommonFnc.ToInt32FromByteStrAry(dn_h.ln_h[i].hofsu);
                // BO�o�ɐ�3							
                uOEOrderDtlInfo.BOShipmentCnt3 = UoeCommonFnc.ToInt32FromByteStrAry(dn_h.ln_h[i].rgfsu);
                // ���[�J�[�t�H���[��	
                uOEOrderDtlInfo.MakerFollowCnt = UoeCommonFnc.ToInt32FromByteStrAry(dn_h.ln_h[i].mkfsu);
                // ���o�ɐ�	
                uOEOrderDtlInfo.NonShipmentCnt = UoeCommonFnc.ToInt32FromByteStrAry(dn_h.ln_h[i].nonsu);
                // BO�݌ɐ�1							
                uOEOrderDtlInfo.BOStockCount1 = UoeCommonFnc.ToInt32FromByteStrAry(dn_h.ln_h[i].sbzsu);
                // BO�݌ɐ�2	
                uOEOrderDtlInfo.BOStockCount2 = UoeCommonFnc.ToInt32FromByteStrAry(dn_h.ln_h[i].hozsu);
                // BO�݌ɐ�3							
                uOEOrderDtlInfo.BOStockCount3 = UoeCommonFnc.ToInt32FromByteStrAry(dn_h.ln_h[i].rgzai);
                // UOE���_�`�[�ԍ�	
                uOEOrderDtlInfo.UOESectionSlipNo = UoeCommonFnc.ToStringFromByteStrAry(dn_h.ln_h[i].kyden);
                // BO�`�[��1							
                uOEOrderDtlInfo.BOSlipNo1 = UoeCommonFnc.ToStringFromByteStrAry(dn_h.ln_h[i].sbden);
                // BO�`�[��2	
                uOEOrderDtlInfo.BOSlipNo2 = UoeCommonFnc.ToStringFromByteStrAry(dn_h.ln_h[i].hofde);
                // BO�`�[��3							
                uOEOrderDtlInfo.BOSlipNo3 = UoeCommonFnc.ToStringFromByteStrAry(dn_h.ln_h[i].rgfde);
                // �񓚒艿			
                uOEOrderDtlInfo.AnswerListPrice = UoeCommonFnc.ToDoubleFromByteStrAry(dn_h.ln_h[i].l_p);
                // �񓚌����P��							
                uOEOrderDtlInfo.AnswerSalesUnitCost = UoeCommonFnc.ToDoubleFromByteStrAry(dn_h.ln_h[i].d_n);
                // UOE��փ}�[�N							
                uOEOrderDtlInfo.UOESubstMark = UoeCommonFnc.ToStringFromByteStrAry(dn_h.ln_h[i].daita);

                //�w�b�h�G���[�Ȃ�
                if (!(dn_h.ln_h[i].lerrC[0] == 0x00
                    || dn_h.ln_h[i].lerrC[0] == 0x20))
                {
                    string errMessage = GetHeadErrorMassage(dn_h.ln_h[i].lerrC[0]);
                    //�w�b�h�G���[���b�Z�[�W
                    uOEOrderDtlInfo.HeadErrorMassage = errMessage;
                }

                // ���C���G���[���b�Z�[�W							
                uOEOrderDtlInfo.LineErrorMassage = UoeCommonFnc.ToStringFromByteStrAry(dn_h.ln_h[i].lerrM);

                rcvDataDtlList.Add(uOEOrderDtlInfo);
            }
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
        /// <br>Date       : 2010/01/04</br>
        /// <br>UpdateNote : 2011/01/30 �� ��</br>
        /// <br>             UOE����������</br>
        /// </remarks>
        private int MergeList(ref List<UOEOrderDtlWork> workList, List<UOEOrderDtlInfo> dateList)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            try
            {
                for (int i = 0; i < workList.Count; i++)
                {
                    if (i < dateList.Count)
                    {
                        // ��M���t	
                        workList[i].ReceiveDate = DateTime.ParseExact(DateTime.Now.ToString("yyyyMMdd"), "yyyyMMdd", CultureInfo.InvariantCulture);
                        //��M����
                        workList[i].ReceiveTime = Int32.Parse(DateTime.Now.ToString("HHmmss"));
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
                        //���o�ɐ�	
                        workList[i].NonShipmentCnt = dateList[i].NonShipmentCnt;
                        //BO�݌ɐ�1							
                        workList[i].BOStockCount1 = dateList[i].BOStockCount1;
                        //BO�݌ɐ�2							
                        workList[i].BOStockCount2 = dateList[i].BOStockCount2;
                        //BO�݌ɐ�3							
                        workList[i].BOStockCount3 = dateList[i].BOStockCount3;
                        //UOE���_�`�[�ԍ�							
                        workList[i].UOESectionSlipNo = dateList[i].UOESectionSlipNo;
                        //BO�`�[��1		
                        workList[i].BOSlipNo1 = dateList[i].BOSlipNo1;
                        //BO�`�[��2							
                        workList[i].BOSlipNo2 = dateList[i].BOSlipNo2;
                        //BO�`�[��3							
                        workList[i].BOSlipNo3 = dateList[i].BOSlipNo3;
                        //�񓚒艿				
                        workList[i].AnswerListPrice = dateList[i].AnswerListPrice;
                        //�񓚌����P��							
                        workList[i].AnswerSalesUnitCost = dateList[i].AnswerSalesUnitCost;
                        //UOE��փ}�[�N							
                        workList[i].UOESubstMark = dateList[i].UOESubstMark;
                        //�w�b�h�G���[���b�Z�[�W	
                        workList[i].HeadErrorMassage = dateList[i].HeadErrorMassage;
                        //���C���G���[���b�Z�[�W					
                        workList[i].LineErrorMassage = dateList[i].LineErrorMassage;
                        // �f�[�^���M�敪
                        workList[i].DataSendCode = 5;
                        workList[i].UoeRemark2 = dateList[i].UoeRemark2; // ADD 2011/01/30 �� �� // UOE���}�[�N�Q
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
        /// �g���^���������ō쐬���ꂽ�f�[�^�̍i����
        /// </summary>
        /// <param name="list">RCV���</param>
        /// <param name="remark2">���}�[�N2</param>
        /// <returns>����</returns>
        /// <remarks>
        /// <br>Note       : �g���^���������ō쐬���ꂽ�f�[�^�̍i���݁B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2010/01/04</br>
        /// <br>UpdateNote : 2011/01/30 �� ��</br>
        /// <br>             UOE����������</br>
        /// </remarks>
        private List<UOEOrderDtlWork> FilterUOEOrderDtlList(List<UOEOrderDtlWork> list, string remark2)       
        {
            List<UOEOrderDtlWork> retList = new List<UOEOrderDtlWork>();

            foreach (UOEOrderDtlWork work in list)
            {
                if (work.CommAssemblyId == COMMASSEMBLY_ID
                    && work.UoeRemark2 == remark2
                    && work.DataRecoverDiv == 0)
                {
                    retList.Add(work);
                }
                // ---ADD 2011/01/30 �� �� ---------------------------------------->>>>>
                else if (work.CommAssemblyId == AUTOCOMMASSEMBLY_ID
                && work.UoeRemark2 == remark2
                && work.DataRecoverDiv == 0)
                {
                    retList.Add(work);
                }
                // ---ADD 2011/01/30 �� �� ----------------------------------------<<<<<                
            }

            return retList;
        }

        // --- ADD 2010/01/19 ---------->>>>>
        /// <summary>
        /// �i�荞�܂ꂽ�����f�[�^�Ƒ΂ɂȂ�d�����׃f�[�^�̒��o����
        /// </summary>
        /// <param name="uOEOrderDtlWorkList">�i�荞�܂ꂽ�����f�[�^���X�g</param>
        /// <param name="stockDetailWorkList">�d�����׃f�[�^���X�g</param>
        /// <returns>���ʎd�����׃f�[�^���X�g</returns>
        /// <remarks>
        /// <br>Note       : �i�荞�܂ꂽ�����f�[�^�Ƒ΂ɂȂ�d�����׃f�[�^�𒊏o</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2010/01/19</br>
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
        // --- ADD 2010/01/19 ----------<<<<<
        # endregion

        # region ���X�g���̍쐬����
        /// <summary>
        /// �Ώ�UOE�����f�[�^��r�N���X(�I�����C���ԍ�(����)�A�C�����C���s�ԍ�(����)�AUOE�����ԍ�(����)�AUOE�����s�ԍ�(����))
        /// </summary>
        /// <remarks>
        /// <br>Note       : �Ώ�UOE�����f�[�^��r�N���X�B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2010/01/04</br>
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

        # region �w�b�h�G���[���b�Z�[�W�̎擾
        /// <summary>
        /// �װү���ނ̐ݒ菈��
        /// </summary>
        /// <param name="cd">����</param>
        /// <returns>�װү����</returns>
        /// <remarks>
        /// <br>Note       : �װү���ނ̐ݒ菈�����s��</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2010/01/04</br>
        /// </remarks>
        private string GetHeadErrorMassage(byte cd)
        {
            string str = "";

            switch (cd)
            {
                case 0x11:						//-- "��ݻ޸��ݴװ" --
                case 0xF1:						//-- "��ݻ޸��ݴװ" --
                    str = MSG_TRA;
                    break;
                case 0x12:						//-- "�����Ϻ��޴װ" --
                case 0xF7:						//-- "�����Ϻ��޴װ" --
                    str = MSG_UCD;
                    break;
                case 0x14:						//-- "�߽ܰ�޴װ" --
                    str = MSG_PAS;
                    break;
                case 0x88:						//-- "ٽ��ݴװ" --
                    str = MSG_RUS;
                    break;
                case 0xF2:						//-- "�ݼ��ް�ż" --
                    str = MSG_HEN;
                    break;
                case 0xF3:						//-- "ɳ�ݺ���ż" --
                    str = MSG_NOU;
                    break;
                case 0xF4:						//-- "�ް�ż" --
                    str = MSG_DAT;
                    break;
                case 0xF5:						//-- "�ò���ݴװ" --
                    str = MSG_STK;
                    break;
                case 0xC3:						//-- "�����ر��̶" --
                    str = MSG_KUF;
                    break;
                case 0xC4:						//-- "ʯ�����ĳ���װ" --
                    str = MSG_HTA;
                    break;
                case 0xC5:						//-- "̫۰ɰ�ݺ���ż" --
                    str = MSG_FNC;
                    break;
                case 0xC6:						//-- "���������Ϻ��޴װ" --
                    str = MSG_KOC;
                    break;
                case 0x99:						//-- "����װ" --
                default:
                    str = MSG_ELS;
                    break;
            }
            return (str);
        }
        # endregion

        # region �g���^�����񓚃t�@�C���N���X
        /// <summary>
        /// �g���^�����񓚃t�@�C�������C����
        /// </summary>
        private class LN_H
        {
            public byte[] mkkbn = new byte[1];	// ײ�      Ұ���敪
            public byte[] hb = new byte[14];	//          �i��              
            public byte[] hn = new byte[30];	//	        �i��              
            public byte[] l_p = new byte[7];	//          L_P               
            public byte[] d_n = new byte[7];	//          D_N               
            public byte[] jsu = new byte[5];	//          �󒍐�            
            public byte[] su = new byte[5];		//          �o�ɐ�            
            public byte[] sbfsu = new byte[5];	//          ��ޖ{��̫۰��     
            public byte[] hofsu = new byte[5];	//          �{��̫۰��        
            public byte[] rgfsu = new byte[5];	//          ٰĊO̫۰��       
            public byte[] mkfsu = new byte[5];	//          Ұ��̫۰��        
            public byte[] nonsu = new byte[5];	//          ���o�ɐ�          
            public byte[] sbzsu = new byte[5];	//          ��ޖ{���݌�       
            public byte[] hozsu = new byte[5];	//          �{���݌�          
            public byte[] rgzai = new byte[5];	//          ٰĊO�݌ɐ�       
            public byte[] kyden = new byte[6];	//          ��ǋ��_�`��      
            public byte[] sbden = new byte[6];	//          ��ޖ{���`��       
            public byte[] hofde = new byte[6];	//          �{��̫۰�`��      
            public byte[] rgfde = new byte[6];	//          ٰĊO̫۰�`��     
            public byte[] daita = new byte[1];	//          ��֗L��          
            public byte[] hbkbn = new byte[1];	//          �i�ԋ敪          
            public byte[] syocd = new byte[1];	//          ���iCD            
            public byte[] hincd = new byte[4];	//          �i��CD            
            public byte[] nkicd = new byte[1];	//          �[��CD            
            public byte[] hozcd = new byte[1];	//          �{���݌�CD        
            public byte[] lerrC = new byte[1];	//          ײݴװC           
            public byte[] lerrM = new byte[6];	//          ײݴװM           

            public LN_H()
            {
                Clear(0x00);
            }
            public void Clear(byte cd)
            {
                UoeCommonFnc.MemSet(ref mkkbn, cd, mkkbn.Length);	// ײ�      Ұ���敪 
                UoeCommonFnc.MemSet(ref hb, cd, hb.Length);		    //          �i��              
                UoeCommonFnc.MemSet(ref hn, cd, hn.Length);		    //          �i��              
                UoeCommonFnc.MemSet(ref l_p, cd, l_p.Length);		//          L_P               
                UoeCommonFnc.MemSet(ref d_n, cd, d_n.Length);		//          D_N               
                UoeCommonFnc.MemSet(ref jsu, cd, jsu.Length);		//          �󒍐�            
                UoeCommonFnc.MemSet(ref su, cd, su.Length);		    //          �o�ɐ�            
                UoeCommonFnc.MemSet(ref sbfsu, cd, sbfsu.Length);	//          ��ޖ{��̫۰��     
                UoeCommonFnc.MemSet(ref hofsu, cd, hofsu.Length);	//          �{��̫۰��        
                UoeCommonFnc.MemSet(ref rgfsu, cd, rgfsu.Length);	//          ٰĊO̫۰��       
                UoeCommonFnc.MemSet(ref mkfsu, cd, mkfsu.Length);	//          Ұ��̫۰��        
                UoeCommonFnc.MemSet(ref nonsu, cd, nonsu.Length);	//          ���o�ɐ�          
                UoeCommonFnc.MemSet(ref sbzsu, cd, sbzsu.Length);	//          ��ޖ{���݌�       
                UoeCommonFnc.MemSet(ref hozsu, cd, hozsu.Length);	//          �{���݌�          
                UoeCommonFnc.MemSet(ref rgzai, cd, rgzai.Length);	//          ٰĊO�݌ɐ�       
                UoeCommonFnc.MemSet(ref kyden, cd, kyden.Length);	//          ��ǋ��_�`��      
                UoeCommonFnc.MemSet(ref sbden, cd, sbden.Length);	//          ��ޖ{���`��       
                UoeCommonFnc.MemSet(ref hofde, cd, hofde.Length);	//          �{��̫۰�`��      
                UoeCommonFnc.MemSet(ref rgfde, cd, rgfde.Length);	//          ٰĊO̫۰�`��     
                UoeCommonFnc.MemSet(ref daita, cd, daita.Length);	//          ��֗L��          
                UoeCommonFnc.MemSet(ref hbkbn, cd, hbkbn.Length);	//          �i�ԋ敪          
                UoeCommonFnc.MemSet(ref syocd, cd, syocd.Length);	//          ���iCD            
                UoeCommonFnc.MemSet(ref hincd, cd, hincd.Length);	//          �i��CD            
                UoeCommonFnc.MemSet(ref nkicd, cd, nkicd.Length);	//          �[��CD            
                UoeCommonFnc.MemSet(ref hozcd, cd, hozcd.Length);	//          �{���݌�CD        
                UoeCommonFnc.MemSet(ref lerrC, cd, lerrC.Length);	//          ײݴװC           
                UoeCommonFnc.MemSet(ref lerrM, cd, lerrM.Length);	//          ײݴװM           
            }
        }

        /// <summary>
        /// �g���^�����񓚃t�@�C�����{�́�
        /// </summary>
        private class DN_H
        {
            public byte[] acd = new byte[7];		//           ����溰��       
            public byte[] tcd = new byte[7];		//           ��������         
            public byte[] dttm = new byte[6];		//           ���t�����        
            public byte[] pass = new byte[6];		//           �߽ܰ��          
            public byte[] kflg = new byte[1];		//           �p���׸� 
            public byte[] nrkdttm = new byte[4];	//           ���͓��t����
            public byte[] sysdt = new byte[6];	    //           ���ѓ��t
            public byte[] sbs = new byte[2];	    //           ��߰�
            public byte[] nhkb = new byte[1];		//           �[�i�敪         
            public byte[] fnkb = new byte[1];		//           ̫۰�[�i�敪     
            public byte[] rem1 = new byte[8];		//           �ϰ�1            
            public byte[] rem2 = new byte[10];	    //           �ϰ�2            
            public byte[] kyo = new byte[2];		//           �w�苒�_         
            public byte[] tan = new byte[2];		//           �S���Һ���  
            public byte[] skbn = new byte[1];		//           �����敪  
            public LN_H[] ln_h = new LN_H[ctBufLen];// ײ�       149�޲�       

            /// <summary>	
            /// �R���X�g���N�^�[
            /// </summary>
            public DN_H()
            {
                Clear(0x00);
            }

            public void Clear(byte cd)
            {
                UoeCommonFnc.MemSet(ref acd, cd, acd.Length);		    //           ����溰��       
                UoeCommonFnc.MemSet(ref tcd, cd, tcd.Length);		    //           ��������         
                UoeCommonFnc.MemSet(ref dttm, cd, dttm.Length);		    //           ���t�����        
                UoeCommonFnc.MemSet(ref pass, cd, pass.Length);		    //           �߽ܰ��          
                UoeCommonFnc.MemSet(ref kflg, cd, kflg.Length);		    //           �p���׸�  
                UoeCommonFnc.MemSet(ref nrkdttm, cd, nrkdttm.Length);	//           ���͓��t����
                UoeCommonFnc.MemSet(ref sysdt, cd, sysdt.Length);	    //           ���ѓ��t
                UoeCommonFnc.MemSet(ref sbs, cd, sbs.Length);	        //           ��߰�
                UoeCommonFnc.MemSet(ref nhkb, cd, nhkb.Length);		    //           �[�i�敪         
                UoeCommonFnc.MemSet(ref fnkb, cd, fnkb.Length);		    //           ̫۰�[�i�敪     
                UoeCommonFnc.MemSet(ref rem1, cd, rem1.Length);		    //           �ϰ�1            
                UoeCommonFnc.MemSet(ref rem2, cd, rem2.Length);		    //           �ϰ�2            
                UoeCommonFnc.MemSet(ref kyo, cd, kyo.Length);		    //           �w�苒�_         
                UoeCommonFnc.MemSet(ref tan, cd, tan.Length);		    //           �S���Һ���       
                UoeCommonFnc.MemSet(ref skbn, cd, skbn.Length);		    //           �����敪  

                //���ו�
                for (int i = 0; i < ctBufLen; i++)
                {
                    if (ln_h[i] == null)
                    {
                        ln_h[i] = new LN_H();
                    }
                    else
                    {
                        ln_h[i].Clear(0x00);
                    }
                }         
            }
        }
        # endregion

        # region �o�C�g�^�z��ɕϊ�
        /// <summary>
        /// �o�C�g�^�z��ɕϊ�
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : �o�C�g�^�z��ɕϊ����s���B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2010/01/04</br>
        /// </remarks>
        private void FromByteArray(byte[] line)
        {
            //_detailMax = 0;
            MemoryStream ms = new MemoryStream();
            ms.Write(line, 0, line.Length);
            ms.Seek(0, SeekOrigin.Begin);

            ms.Read(dn_h.acd, 0, dn_h.acd.Length);      //           ����溰��       
            ms.Read(dn_h.tcd, 0, dn_h.tcd.Length);      //           ��������         
            ms.Read(dn_h.dttm, 0, dn_h.dttm.Length);    //           ���t�����        
            ms.Read(dn_h.pass, 0, dn_h.pass.Length);    //           �߽ܰ��          
            ms.Read(dn_h.kflg, 0, dn_h.kflg.Length);    //           �p���׸�  
            ms.Read(dn_h.nrkdttm, 0, dn_h.nrkdttm.Length);//         ���͓��t����  
            ms.Read(dn_h.sysdt, 0, dn_h.sysdt.Length);  //           ���ѓ��t  
            ms.Read(dn_h.sbs, 0, dn_h.sbs.Length);      //           ��߰�  
            ms.Read(dn_h.nhkb, 0, dn_h.nhkb.Length);    //           �[�i�敪         
            ms.Read(dn_h.fnkb, 0, dn_h.fnkb.Length);    //           ̫۰�[�i�敪     
            ms.Read(dn_h.rem1, 0, dn_h.rem1.Length);    //           �ϰ�1            
            ms.Read(dn_h.rem2, 0, dn_h.rem2.Length);    //           �ϰ�2            
            ms.Read(dn_h.kyo, 0, dn_h.kyo.Length);      //           �w�苒�_         
            ms.Read(dn_h.tan, 0, dn_h.tan.Length);      //           �S���Һ���       
            ms.Read(dn_h.skbn, 0, dn_h.skbn.Length);    //           �����敪      

            //���ו�
            for (int i = 0; i < ctBufLen; i++)
            {
                ms.Read(dn_h.ln_h[i].mkkbn, 0, dn_h.ln_h[i].mkkbn.Length);	// ײ�      Ұ���敪 
                ms.Read(dn_h.ln_h[i].hb, 0, dn_h.ln_h[i].hb.Length);        // ײ�      �i��              
                ms.Read(dn_h.ln_h[i].hn, 0, dn_h.ln_h[i].hn.Length);        //          �i��              
                ms.Read(dn_h.ln_h[i].l_p, 0, dn_h.ln_h[i].l_p.Length);      //          L_P               
                ms.Read(dn_h.ln_h[i].d_n, 0, dn_h.ln_h[i].d_n.Length);      //          D_N               
                ms.Read(dn_h.ln_h[i].jsu, 0, dn_h.ln_h[i].jsu.Length);      //          �󒍐�            
                ms.Read(dn_h.ln_h[i].su, 0, dn_h.ln_h[i].su.Length);        //          �o�ɐ�            
                ms.Read(dn_h.ln_h[i].sbfsu, 0, dn_h.ln_h[i].sbfsu.Length);  //          ��ޖ{��̫۰��     
                ms.Read(dn_h.ln_h[i].hofsu, 0, dn_h.ln_h[i].hofsu.Length);  //          �{��̫۰��        
                ms.Read(dn_h.ln_h[i].rgfsu, 0, dn_h.ln_h[i].rgfsu.Length);  //          ٰĊO̫۰��       
                ms.Read(dn_h.ln_h[i].mkfsu, 0, dn_h.ln_h[i].mkfsu.Length);  //          Ұ��̫۰��        
                ms.Read(dn_h.ln_h[i].nonsu, 0, dn_h.ln_h[i].nonsu.Length);  //          ���o�ɐ�          
                ms.Read(dn_h.ln_h[i].sbzsu, 0, dn_h.ln_h[i].sbzsu.Length);  //          ��ޖ{���݌�       
                ms.Read(dn_h.ln_h[i].hozsu, 0, dn_h.ln_h[i].hozsu.Length);  //          �{���݌�          
                ms.Read(dn_h.ln_h[i].rgzai, 0, dn_h.ln_h[i].rgzai.Length);  //          ٰĊO�݌ɐ�       
                ms.Read(dn_h.ln_h[i].kyden, 0, dn_h.ln_h[i].kyden.Length);  //          ��ǋ��_�`��      
                ms.Read(dn_h.ln_h[i].sbden, 0, dn_h.ln_h[i].sbden.Length);  //          ��ޖ{���`��       
                ms.Read(dn_h.ln_h[i].hofde, 0, dn_h.ln_h[i].hofde.Length);  //          �{��̫۰�`��      
                ms.Read(dn_h.ln_h[i].rgfde, 0, dn_h.ln_h[i].rgfde.Length);  //          ٰĊO̫۰�`��     
                ms.Read(dn_h.ln_h[i].daita, 0, dn_h.ln_h[i].daita.Length);  //          ��֗L��          
                ms.Read(dn_h.ln_h[i].hbkbn, 0, dn_h.ln_h[i].hbkbn.Length);  //          �i�ԋ敪          
                ms.Read(dn_h.ln_h[i].syocd, 0, dn_h.ln_h[i].syocd.Length);  //          ���iCD            
                ms.Read(dn_h.ln_h[i].hincd, 0, dn_h.ln_h[i].hincd.Length);  //          �i��CD            
                ms.Read(dn_h.ln_h[i].nkicd, 0, dn_h.ln_h[i].nkicd.Length);  //          �[��CD            
                ms.Read(dn_h.ln_h[i].hozcd, 0, dn_h.ln_h[i].hozcd.Length);  //          �{���݌�CD        
                ms.Read(dn_h.ln_h[i].lerrC, 0, dn_h.ln_h[i].lerrC.Length);  //          ײݴװC           
                ms.Read(dn_h.ln_h[i].lerrM, 0, dn_h.ln_h[i].lerrM.Length);  //          ײݴװM   
            }    

            ms.Close();
        }
        # endregion
    }
}
