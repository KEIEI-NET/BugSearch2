using System;
using System.IO;
using System.Text;
using System.Data;
using System.Collections;
//using System.Windows.Forms;
//using System.Drawing.Printing;
using System.Collections.Generic;

//using ar=DataDynamics.ActiveReports;
//using DataDynamics.ActiveReports.Document;

using Broadleaf.Library.Resources;
//using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;
//using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Globarization;
// --- ADD START �c������ 2022/10/18 ----->>>>>
using Broadleaf.Application.Resources;
using System.Text.RegularExpressions;
// --- ADD END   �c������ 2022/10/18 -----<<<<<

namespace Broadleaf.Application.Controller
{
	/// <summary>
	/// ���R���[(������)�X�L�[�}����N���X
	/// </summary>
	/// <remarks>
    /// <br>Note         : ��������ɓn���e�[�u���̐������s���܂��B�i���������X�g�j</br>
    /// <br>               static�t�B�[���h�^���\�b�h�����̃N���X�Ɏ������܂��B</br>
    /// <br>               �y���o(E)����call���܂��z</br>
    /// <br>               </br>
	/// <br>Programmer   : 22018 ��؁@���b</br>
	/// <br>Date         : 2008.06.17</br>
	/// <br></br>
	/// <br>Update Note  : 2010.01.06  22018 ��� ���b</br>
    /// <br>             : MANTIS 0014863 �Ή�</br>
    /// <br>             : �������ς݃f�B�N�V���i���ɃZ�b�g����KEY��OutputFormFileName�ɏC���B</br>
    /// <br></br>
    /// <br>Update Note  : 2010.02.15  22018 ��� ���b</br>
    /// <br>             : ������(����)�Ή�</br>
    /// <br>Update Note  : 2022/10/18 �c������</br>
    /// <br>�Ǘ��ԍ�     : 11870141-00 �C���{�C�X�c�Ή��i�y���ŗ��Ή��j</br>
    /// </remarks>
	public class PMKAU08002AB
    {
        # region [public static readonly �����o]

        # region [DataSet�Ɋi�[����e�[�u���̖���]
        /// <summary>�������ꗗ�e�[�u��</summary>
        public const string CT_Tbl_BillList = "BillList";
        ///// <summary>�e��ݒ�e�[�u��</summary>
        //public const string CT_Tbl_Settings = "Settings";
        # endregion

        # region [�������{�̂���n�����e�[�u����column]
        /// <summary>����t���O</summary>
        public const string CT_CsDmd_PrintFlag = "PrintFlag";
        /// <summary>�v�㋒�_�R�[�h</summary>
        public const string CT_CsDmd_AddUpSecCode = "AddUpSecCode";
        /// <summary>������R�[�h</summary>
        public const string CT_CsDmd_ClaimCode = "ClaimCode";
        /// <summary>���ы��_�R�[�h</summary>
        public const string CT_CsDmd_ResultsSectCd = "ResultsSectCd";
        /// <summary>���Ӑ�R�[�h</summary>
        public const string CT_CsDmd_CustomerCode = "CustomerCode";
        /// <summary>�v��N�����iint�j</summary>
        public const string CT_CsDmd_AddUpDateInt = "AddUpDateInt";
        // --- ADD m.suzuki 2010/02/18 ---------->>>>>
        /// <summary>������(����)���o�f�[�^�^�C�v</summary>
        public const string CT_CsDmd_DataType = "DataType";
        /// <summary>�������Ӑ�R�[�h</summary>
        public const string CT_CsDmd_SumClaimCustCode = "SumClaimCustCode";
        // --- ADD m.suzuki 2010/02/18 ----------<<<<<
        # endregion

        # region [BillList�e�[�u����column]
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/25 ADD
        /// <summary>���o�L�����Z���t���O</summary>
        public const string CT_BillList_ExtractCancel = "ExtractCancel";
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/25 ADD

        /// <summary>�f�[�^�^�C�v(������Ȃ�true)</summary>
        public const string CT_BillList_DataType = "DataType";
        /// <summary>�v�㋒�_�R�[�h</summary>
        public const string CT_BillList_AddUpSecCode = "AddUpSecCode";
        /// <summary>������R�[�h</summary>
        public const string CT_BillList_ClaimCode = "ClaimCode";
        /// <summary>���ы��_�R�[�h</summary>
        public const string CT_BillList_ResultsSectCd = "ResultsSectCd";
        /// <summary>���Ӑ�R�[�h</summary>
        public const string CT_BillList_CustomerCode = "CustomerCode";
        /// <summary>����(int)</summary>
        public const string CT_BillList_AddUpDateInt = "AddUpDateInt";
        /// <summary>���Ӑ�S���҃R�[�h</summary>
        public const string CT_BillList_CustomerAgentCd = "CustomerAgentCd";
        /// <summary>�W���S���҃R�[�h</summary>
        public const string CT_BillList_BillCollecterCd = "BillCollecterCd";
        /// <summary>�n��R�[�h</summary>
        public const string CT_BillList_SalesAreaCode = "SalesAreaCode";

        /// <summary></summary>
        public const string CT_BillList_FrePBillHead = "FrePBillHead";
        /// <summary></summary>
        public const string CT_BillList_FrePBillSalesList = "FrePBillSalesList";
        /// <summary></summary>
        public const string CT_BillList_FrePBillDepositList = "FrePBillDepositList";

        /// <summary></summary>
        public const string CT_BillList_DmdPrtPtn = "DmdPrtPtn";
        /// <summary></summary>
        public const string CT_BillList_FrePrtPSet = "FrePrtPSet";
        /// <summary></summary>
        public const string CT_BillList_PrtManage = "PrtManage";
        /// <summary></summary>
        public const string CT_BillList_BillAllSt = "BillAllSt";
        /// <summary></summary>
        public const string CT_BillList_BillPrtSt = "BillPrtSt";
        /// <summary></summary>
        public const string CT_BillList_AllDefSet = "AllDefSet";
        # endregion

        //# region [Settings�e�[�u����column]
        ///// <summary>�����S�̐ݒ�</summary>
        //public const string CT_Settings_BillAllSt = "BillAllSt";
        //# endregion

        # endregion

        # region [private const]
        private const string ct_SectionZero = "00";
        private const string ct_WarehouseZero = "0000";
        private const int ct_CustomerZero = 0;
        private const int ct_CashRegisterZero = 0;
        // --- ADD START �c������ 2022/10/18 ----->>>>>
        /// <summary>
        /// ������z�����敪�ݒ�
        /// </summary>
        public const string CT_BillList_SalesProcMoneyWork = "SalesProcMoneyWork";
        // XML����
        private const string ctPrintXmlFileName = "PMKAU08002A_TaxRateUserSetting.XML";
        // --- ADD END   �c������ 2022/10/18 -----<<<<<
        # endregion

        # region [�f�[�^�e�[�u������]
        /// <summary>
        /// �f�[�^�e�[�u�����������i���������X�g�e�[�u���X�L�[�}��`�j
        /// </summary>
        /// <returns></returns>
        /// <br>Note       : 11870141-00 �C���{�C�X�c�Ή��i�y���ŗ��Ή��j</br>
        /// <br>Programmer : �c������ </br>
        /// <br>Date       : 2022/10/18</br>
        public static DataTable CreateBillListTable()
        {
            DataTable table = new DataTable( CT_Tbl_BillList );

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/25 ADD
            // �L�����Z���t���O
            table.Columns.Add( new DataColumn( CT_BillList_ExtractCancel, typeof( bool ) ) );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/25 ADD

            // �L�[/�\�[�g����
            table.Columns.Add( new DataColumn( CT_BillList_AddUpDateInt, typeof( int ) ) ); // �v��N����
            table.Columns.Add( new DataColumn( CT_BillList_AddUpSecCode, typeof( string ) ) ); // �v�㋒�_�R�[�h
            table.Columns.Add( new DataColumn( CT_BillList_ClaimCode, typeof( int ) ) ); // ������R�[�h
            table.Columns.Add( new DataColumn( CT_BillList_ResultsSectCd, typeof( string ) ) ); // ���ы��_�R�[�h
            table.Columns.Add( new DataColumn( CT_BillList_CustomerCode, typeof( int ) ) ); // ���Ӑ�R�[�h
            table.Columns.Add( new DataColumn( CT_BillList_CustomerAgentCd, typeof( string ) ) ); // ���Ӑ�S���҃R�[�h
            table.Columns.Add( new DataColumn( CT_BillList_BillCollecterCd, typeof( string ) ) ); // �W���S���҃R�[�h
            table.Columns.Add( new DataColumn( CT_BillList_SalesAreaCode, typeof( int ) ) ); // �n��R�[�h
            // ������
            table.Columns.Add( new DataColumn( CT_BillList_FrePBillHead, typeof( FrePBillHeadWork ) ) ); // ���R���[�������w�b�_�i�w�b�_�j
            table.Columns.Add( new DataColumn( CT_BillList_FrePBillSalesList, typeof( List<FrePBillDetailWork> ) ) ); // ���R���[���������ׁi����j
            table.Columns.Add( new DataColumn( CT_BillList_FrePBillDepositList, typeof( List<FrePBillDetailWork> ) ) ); // ���R���[���������ׁi�����j
            // �ݒ���
            table.Columns.Add( new DataColumn( CT_BillList_DmdPrtPtn, typeof( DmdPrtPtnWork ) ) ); // ����������p�^�[���ݒ�
            table.Columns.Add( new DataColumn( CT_BillList_FrePrtPSet, typeof( FrePrtPSetWork ) ) ); // ���R���[�󎚈ʒu�ݒ�
            table.Columns.Add( new DataColumn( CT_BillList_PrtManage, typeof( PrtManage ) ) ); // �v�����^�Ǘ��ݒ�
            table.Columns.Add( new DataColumn( CT_BillList_BillAllSt, typeof( BillAllStWork ) ) ); // �����S�̐ݒ�
            table.Columns.Add( new DataColumn( CT_BillList_BillPrtSt, typeof( BillPrtStWork ) ) ); // ��������ݒ�
            table.Columns.Add( new DataColumn( CT_BillList_AllDefSet, typeof( AllDefSetWork ) ) ); // �S�̏����\���ݒ�
            // --- ADD START �c������ 2022/10/18 ----->>>>>
            table.Columns.Add(new DataColumn(CT_BillList_SalesProcMoneyWork, typeof(List<SalesProcMoneyWork>))); // ������z�����敪�ݒ�
            // --- ADD END   �c������ 2022/10/18 -----<<<<<
            return table;
        }
        ///// <summary>
        ///// �f�[�^�e�[�u�����������i�e��ݒ�e�[�u���X�L�[�}��`�j
        ///// </summary>
        ///// <returns></returns>
        //public static DataTable CreateSettingsTable()
        //{
        //    DataTable table = new DataTable( CT_Tbl_Settings );

        //    table.Columns.Add( new DataColumn( CT_Settings_BillAllSt, typeof( BillAllStWork ) ) );  // �����S�̐ݒ�

        //    return table;
        //}
        # endregion

        # region [�f�[�^�ڍs�iDataClass��DataTable�j]
        /// <summary>
        /// �f�[�^�ڍs�����i���������X�g�@�S���R�s�[�j
        /// </summary>
        /// <param name="table"></param>
        /// <param name="cndtn"></param>
        /// <param name="paraWork"></param>
        /// <param name="printBillList"></param>
        /// <param name="custDmdSetWorkList"></param>
        /// <param name="slipOutputSetWorkList"></param>
        /// <param name="dmdPrtPtnWorkList"></param>
        /// <param name="frePrtPSetList"></param>
        /// <param name="prtManageList"></param>
        /// <param name="billAllStList"></param>
        /// <param name="billPrtStList"></param>
        /// <param name="regNo"></param>
        /// <param name="allDefSetList"></param>
        /// <param name="sectionCode"></param>
        /// <param name="salesProcMoneyWorkList"></param>
        /// <br>Note       : 11870141-00 �C���{�C�X�c�Ή��i�y���ŗ��Ή��j</br>
        /// <br>Programmer : �c������ </br>
        /// <br>Date       : 2022/10/18</br>
        //public static void CopyToBillListTable( ref DataTable table, object cndtn, FrePBillParaWork paraWork, ArrayList printBillList, List<CustDmdSetWork> custDmdSetWorkList, List<SlipOutputSetWork> slipOutputSetWorkList, List<DmdPrtPtnWork> dmdPrtPtnWorkList, List<FrePrtPSetWork> frePrtPSetList, List<PrtManage> prtManageList, List<BillAllStWork> billAllStList, List<BillPrtStWork> billPrtStList, List<AllDefSetWork> allDefSetList, int regNo, string sectionCode )// --- DEL �c������ 2022/10/18
        public static void CopyToBillListTable(ref DataTable table, object cndtn, FrePBillParaWork paraWork, ArrayList printBillList, List<CustDmdSetWork> custDmdSetWorkList, List<SlipOutputSetWork> slipOutputSetWorkList, List<DmdPrtPtnWork> dmdPrtPtnWorkList, List<FrePrtPSetWork> frePrtPSetList, List<PrtManage> prtManageList, List<BillAllStWork> billAllStList, List<BillPrtStWork> billPrtStList, List<AllDefSetWork> allDefSetList, int regNo, string sectionCode, List<SalesProcMoneyWork> salesProcMoneyWorkList)     // --- ADD �c������ 2022/10/18
        {
            // �������ςݎ��R���[�󎚈ʒu�ݒ�L�[���X�g
            Dictionary<string, bool> decryptedFrePrtPSetDic = new Dictionary<string, bool>();

            string enterpriseCode = paraWork.EnterpriseCode;
            int slipPrtKind = paraWork.SlipPrtKind;

            // ���������X�g�W�J
            for (int index = 0; index < printBillList.Count; index++)
			{
                DataRow row = table.NewRow();

                //--------------------------------------------------------
                // ������̊i�[
                //--------------------------------------------------------
                
                // �����̃^�C�~���O�ł͊��S�ɂ͓W�J�����A�f�[�^�N���X�̂܂܈��(P)�ɓn���܂��B
                //   ���ёւ���A�󔒍s����A�T�v���X����ȂǁA
                //   ����ɕK�v�Ȏc��̏����͂��ׂĈ��(P)�ɔC���܂��B

                FrePBillHeadWork headWork = null;
                List<FrePBillDetailWork> salesList = null;
                List<FrePBillDetailWork> depositList = null;
                // --- ADD START �c������ 2022/10/18 ----->>>>>
                // ������z�����敪�ݒ�
                row[CT_BillList_SalesProcMoneyWork] = salesProcMoneyWorkList;
                // --- ADD END   �c������ 2022/10/18 -----<<<<<
                try
                {
                    headWork = (FrePBillHeadWork)(printBillList[index] as ArrayList)[0];
                    salesList = (List<FrePBillDetailWork>)(printBillList[index] as ArrayList)[1];
                    depositList = (List<FrePBillDetailWork>)(printBillList[index] as ArrayList)[2];
                }
                catch
                {
                }

                row[CT_BillList_FrePBillHead] = headWork;
                row[CT_BillList_FrePBillSalesList] = salesList;
                row[CT_BillList_FrePBillDepositList] = depositList;

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/25 ADD
                // �L�����Z���t���O
                row[CT_BillList_ExtractCancel] = false;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/25 ADD

                //--------------------------------------------------------
                // �L�[���̊i�[
                //--------------------------------------------------------

                row[CT_BillList_AddUpDateInt] = headWork.CUSTDMDPRCRF_ADDUPDATERF;
                row[CT_BillList_AddUpSecCode] = headWork.CUSTDMDPRCRF_ADDUPSECCODERF;
                row[CT_BillList_ClaimCode] = headWork.CUSTDMDPRCRF_CLAIMCODERF;
                row[CT_BillList_ResultsSectCd] = headWork.CUSTDMDPRCRF_RESULTSSECTCDRF;
                row[CT_BillList_CustomerCode] = headWork.CUSTDMDPRCRF_CUSTOMERCODERF;
                row[CT_BillList_CustomerAgentCd] = headWork.CSTCLM_CUSTOMERAGENTCDRF;
                row[CT_BillList_BillCollecterCd] = headWork.CSTCLM_BILLCOLLECTERCDRF;
                row[CT_BillList_SalesAreaCode] = headWork.CSTCLM_SALESAREACODERF;

                if ( cndtn is ExtrInfo_DemandTotal )
                {
                    int issueDay = GetLongDate( (cndtn as ExtrInfo_DemandTotal).IssueDay );

                    if ( issueDay < headWork.CSTCLM_CUSTAGENTCHGDATERF )
                    {
                        // ���s�����S���ҕύX���Ȃ�΋��S���ŏ���������
                        row[CT_BillList_CustomerAgentCd] = headWork.CSTCLM_OLDCUSTOMERAGENTCDRF;
                    }
                }
                // --- ADD m.suzuki 2010/02/18 ---------->>>>>
                else if ( cndtn is SumExtrInfo_DemandTotal )
                {
                    int issueDay = GetLongDate( (cndtn as SumExtrInfo_DemandTotal).IssueDay );

                    if ( issueDay < headWork.CSTCLM_CUSTAGENTCHGDATERF )
                    {
                        // ���s�����S���ҕύX���Ȃ�΋��S���ŏ���������
                        row[CT_BillList_CustomerAgentCd] = headWork.CSTCLM_OLDCUSTOMERAGENTCDRF;
                    }
                }
                // --- ADD m.suzuki 2010/02/18 ----------<<<<<

                //--------------------------------------------------------
                // �֘A�}�X�^���̊i�[
                //--------------------------------------------------------

                // �S�̏����\���ݒ�
                row[CT_BillList_AllDefSet] = SearchAllDefSet( allDefSetList, enterpriseCode, sectionCode );

                // �����S�̐ݒ�
                row[CT_BillList_BillAllSt] = SearchBillAllSt( billAllStList, enterpriseCode, sectionCode );

                // ��������ݒ�
                row[CT_BillList_BillPrtSt] = SearchBillPrtSt( billPrtStList, enterpriseCode );

                // ���Ӑ�}�X�^(�������Ǘ�)
                CustDmdSetWork custDmdSet = SearchCustDmdSet( custDmdSetWorkList, enterpriseCode, slipPrtKind, sectionCode, headWork.CUSTDMDPRCRF_CLAIMCODERF );

                if ( custDmdSet != null )
                {
                    // ����������p�^�[���ݒ�
                    DmdPrtPtnWork dmdPrtPtn = SearchDmdPrtPtn( dmdPrtPtnWorkList, enterpriseCode, custDmdSet.SlipPrtKind, custDmdSet.SlipPrtSetPaperId );
                    row[CT_BillList_DmdPrtPtn] = dmdPrtPtn; // ���Y���Ȃ����null������܂�

                    // �`�[�o�͐�ݒ�
                    if ( dmdPrtPtn != null )
                    {
                        SlipOutputSetWork slipOutputSet = SearchSlipOutputSet( slipOutputSetWorkList, enterpriseCode, sectionCode, regNo, custDmdSet.SlipPrtSetPaperId );
                        if ( slipOutputSet != null )
                        {
                            // �v�����^�Ǘ��ݒ�
                            row[CT_BillList_PrtManage] = SearchPrtManage( prtManageList, enterpriseCode, slipOutputSet.PrinterMngNo ); // ���Y���Ȃ����null������܂�
                        }
                        else if ( prtManageList != null && prtManageList.Count > 0 )
                        {
                            // �v�����^�Ǘ��ݒ�
                            row[CT_BillList_PrtManage] = prtManageList[0];
                        }
                    }

                    // ���R���[�󎚈ʒu�ݒ�
                    FrePrtPSetWork frePrtPSet = SearchFrePrtPSet( frePrtPSetList, dmdPrtPtn );    // ���Y���Ȃ����null������܂�
                    row[CT_BillList_FrePrtPSet] = frePrtPSet;
                    if ( frePrtPSet != null )
                    {
                        // --- UPD m.suzuki 2010/01/06 ---------->>>>>
                        //if ( !decryptedFrePrtPSetDic.ContainsKey( dmdPrtPtn.SlipPrtSetPaperId ) )
                        if ( !decryptedFrePrtPSetDic.ContainsKey( dmdPrtPtn.OutputFormFileName) )
                        // --- UPD m.suzuki 2010/01/06 ----------<<<<<
                        {
                            // �󎚈ʒu�f�[�^�𕜍�������
                            //�i�����ӁFfrePrtPSet�X�V��frePrtPSetList�̊Y�����R�[�h�X�V���Ӗ����܂��j
                            FrePrtSettingController.DecryptPrintPosClassData( frePrtPSet );
                            // �������ς݃f�B�N�V���i���ɒǉ�����
                            // --- UPD m.suzuki 2010/01/06 ---------->>>>>
                            //decryptedFrePrtPSetDic.Add( dmdPrtPtn.SlipPrtSetPaperId, true );
                            decryptedFrePrtPSetDic.Add( dmdPrtPtn.OutputFormFileName, true );
                            // --- UPD m.suzuki 2010/01/06 ----------<<<<<
                        }
                    }
                }
                else
                {
                    row[CT_BillList_DmdPrtPtn] = null;
                    row[CT_BillList_PrtManage] = null;
                    row[CT_BillList_FrePrtPSet] = null;
                }


                // �s�ǉ�
                table.Rows.Add( row );
            }
        }

        /// <summary>
        /// ���tLongDate�擾
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        private static int GetLongDate( DateTime dateTime )
        {
            if ( dateTime != DateTime.MinValue )
            {
                return (dateTime.Year * 10000) + (dateTime.Month * 100) + (dateTime.Day);
            }
            else
            {
                return 0;
            }
        }
        # endregion

        # region [�}�X�^Search]
        /// <summary>
        /// �S�̏����\���ݒ�@�擾����
        /// </summary>
        /// <param name="list"></param>
        /// <param name="enterpriseCode"></param>
        /// <param name="sectionCode"></param>
        /// <returns></returns>
        private static AllDefSetWork SearchAllDefSet( List<AllDefSetWork> list, string enterpriseCode, string sectionCode )
        {
            AllDefSetWork allDefSetWork = null;

            // ���_�ʐݒ�
            allDefSetWork = FindAllDefSetWork( list, enterpriseCode, sectionCode );
            if ( allDefSetWork != null ) return allDefSetWork;

            // �S�Аݒ�[���_=0]
            allDefSetWork = FindAllDefSetWork( list, enterpriseCode, ct_SectionZero );
            if ( allDefSetWork != null ) return allDefSetWork;

            return null;
        }
        /// <summary>
        /// ����������p�^�[���@�擾����
        /// </summary>
        /// <param name="list"></param>
        /// <param name="enterpriseCode"></param>
        /// <param name="slipPrtKind"></param>
        /// <param name="slipPrtSetPaperId"></param>
        /// <returns></returns>
        public static DmdPrtPtnWork SearchDmdPrtPtn( List<DmdPrtPtnWork> list, string enterpriseCode, int slipPrtKind, string slipPrtSetPaperId )
        {
            if ( list == null || list.Count == 0 ) return null;

            return list.Find(
                delegate( DmdPrtPtnWork target )
                {
                    return (target.EnterpriseCode == enterpriseCode)
                            && (target.SlipPrtKind == slipPrtKind)
                            && (target.SlipPrtSetPaperId == slipPrtSetPaperId);
                }
                );
        }
        /// <summary>
        /// ���R���[�󎚈ʒu�@�擾����
        /// </summary>
        /// <param name="list"></param>
        /// <param name="dmdPrtPtn"></param>
        /// <returns></returns>
        public static FrePrtPSetWork SearchFrePrtPSet( List<FrePrtPSetWork> list, DmdPrtPtnWork dmdPrtPtn )
        {
            if ( list == null || list.Count == 0 || dmdPrtPtn == null ) return null;

            string outputFileName;
            int userPrtPprIdDerivNo;
            // --- UPD m.suzuki 2010/01/06 ---------->>>>>
            //GetFrePrtPSetReadKey( dmdPrtPtn, out outputFileName, out userPrtPprIdDerivNo );
            outputFileName = dmdPrtPtn.OutputFormFileName;
            userPrtPprIdDerivNo = 0;
            // --- UPD m.suzuki 2010/01/06 ----------<<<<<

            return list.Find(
                delegate( FrePrtPSetWork target )
                {
                    return (target.EnterpriseCode == dmdPrtPtn.EnterpriseCode)
                            && (target.OutputFormFileName == outputFileName)
                            && (target.UserPrtPprIdDerivNo == userPrtPprIdDerivNo);
                }
                );
        }
        // --- DEL m.suzuki 2010/01/06 ---------->>>>>
        ///// <summary>
        ///// ���R���[�󎚈ʒu�ݒ� �ǂݍ��݃L�[���擾
        ///// </summary>
        ///// <param name="dmdPrtPtn"></param>
        ///// <param name="outputFormFileName"></param>
        ///// <param name="userPrtPprIdDerivNo"></param>
        //private static void GetFrePrtPSetReadKey( DmdPrtPtnWork dmdPrtPtn, out string outputFormFileName, out int userPrtPprIdDerivNo )
        //{
        //    outputFormFileName = dmdPrtPtn.OutputFormFileName;
        //    userPrtPprIdDerivNo = 0;

        //    if ( dmdPrtPtn.SlipPrtSetPaperId.StartsWith( dmdPrtPtn.OutputFormFileName ) )
        //    {
        //        string derivNoText = dmdPrtPtn.SlipPrtSetPaperId.Substring( dmdPrtPtn.OutputFormFileName.Length, dmdPrtPtn.SlipPrtSetPaperId.Length - dmdPrtPtn.OutputFormFileName.Length );
        //        try
        //        {
        //            userPrtPprIdDerivNo = Int32.Parse( derivNoText );
        //        }
        //        catch
        //        {
        //            userPrtPprIdDerivNo = 0;
        //        }
        //    }
        //}
        // --- DEL m.suzuki 2010/01/06 ----------<<<<<
        /// <summary>
        /// �v�����^�Ǘ��ݒ�@�擾����
        /// </summary>
        /// <param name="list"></param>
        /// <param name="enterpriseCode"></param>
        /// <param name="printerMngNo"></param>
        /// <returns></returns>
        public static PrtManage SearchPrtManage( List<PrtManage> list, string enterpriseCode, int printerMngNo )
        {
            if ( list == null || list.Count == 0 ) return null;

            return list.Find(
                delegate( PrtManage prtManage )
                {
                    return (prtManage.EnterpriseCode == enterpriseCode)
                           && (prtManage.PrinterMngNo == printerMngNo);
                }
                );
        }

        /// <summary>
        /// ���Ӑ�}�X�^�i�������Ǘ��j�擾����
        /// </summary>
        /// <param name="list"></param>
        /// <param name="enterpriseCode"></param>
        /// <param name="slipPrtKind"></param>
        /// <param name="sectionCode"></param>
        /// <param name="customerCode"></param>
        /// <returns></returns>
        public static CustDmdSetWork SearchCustDmdSet( List<CustDmdSetWork> list, string enterpriseCode, int slipPrtKind, string sectionCode, int customerCode )
        {
            CustDmdSetWork custDmdSetWork = null;

            // ���Ӑ�ʐݒ�[���_=0]
            custDmdSetWork = FindCustDmdSetWork( list, enterpriseCode, slipPrtKind, ct_SectionZero, customerCode );
            if ( custDmdSetWork != null ) return custDmdSetWork;

            // ���_�ʐݒ�[���Ӑ�=0]
            custDmdSetWork = FindCustDmdSetWork( list, enterpriseCode, slipPrtKind, sectionCode, ct_CustomerZero );
            if ( custDmdSetWork != null ) return custDmdSetWork;

            // �S�Аݒ�[���_=0,���Ӑ�=0]
            custDmdSetWork = FindCustDmdSetWork( list, enterpriseCode, slipPrtKind, ct_SectionZero, ct_CustomerZero );
            if ( custDmdSetWork != null ) return custDmdSetWork;

            return null;
        }
        /// <summary>
        /// �`�[�o�͐�ݒ�@�擾����
        /// </summary>
        /// <param name="list"></param>
        /// <param name="enterpriseCode"></param>
        /// <param name="sectionCode"></param>
        /// <param name="cashRegisterNo"></param>
        /// <param name="slipPrtSetPaperId"></param>
        /// <returns></returns>
        private static SlipOutputSetWork SearchSlipOutputSet( List<SlipOutputSetWork> list, string enterpriseCode, string sectionCode, int cashRegisterNo, string slipPrtSetPaperId )
        {
            SlipOutputSetWork slipOutputSetWork = null;

            // ���W�ԍ��ʐݒ�[���_=0,�q��=0]
            slipOutputSetWork = FindSlipOutputSetWork( list, enterpriseCode, ct_SectionZero, ct_WarehouseZero, cashRegisterNo, slipPrtSetPaperId );
            if ( slipOutputSetWork != null ) return slipOutputSetWork;

            // ���_�ʐݒ�[�q��=0,���W�ԍ�=0]
            slipOutputSetWork = FindSlipOutputSetWork( list, enterpriseCode, sectionCode, ct_WarehouseZero, ct_CashRegisterZero, slipPrtSetPaperId );
            if ( slipOutputSetWork != null ) return slipOutputSetWork;

            // �S�Аݒ�[���_=0,�q��=0,���W�ԍ�=0]
            slipOutputSetWork = FindSlipOutputSetWork( list, enterpriseCode, ct_SectionZero, ct_WarehouseZero, ct_CashRegisterZero, slipPrtSetPaperId );
            if ( slipOutputSetWork != null ) return slipOutputSetWork;

            return null;
        }
        /// <summary>
        /// �����S�̐ݒ�@�擾����
        /// </summary>
        /// <param name="list"></param>
        /// <param name="enterpriseCode"></param>
        /// <param name="sectionCode"></param>
        /// <returns></returns>
        private static BillAllStWork SearchBillAllSt( List<BillAllStWork> list, string enterpriseCode, string sectionCode )
        {
            BillAllStWork billAllStWork = null;

            // ���_��
            billAllStWork = FindBillAllStWork( list, enterpriseCode, sectionCode );
            if ( billAllStWork != null ) return billAllStWork;

            // �S��
            billAllStWork = FindBillAllStWork( list, enterpriseCode, ct_SectionZero );
            if ( billAllStWork != null ) return billAllStWork;

            return null;
        }

        /// <summary>
        /// ��������ݒ�@�擾����
        /// </summary>
        /// <param name="list"></param>
        /// <param name="enterpriseCode"></param>
        /// <returns></returns>
        private static BillPrtStWork SearchBillPrtSt( List<BillPrtStWork> list, string enterpriseCode )
        {
            BillPrtStWork billPrtStWork = null;

            // �S�Аݒ�
            billPrtStWork = FindBillPrtStWork( list, enterpriseCode );
            if ( billPrtStWork != null ) return billPrtStWork;

            return null;
        }

        /// <summary>
        /// find ���Ӑ�}�X�^�i�������Ǘ��j
        /// </summary>
        /// <param name="list"></param>
        /// <param name="enterpriseCode"></param>
        /// <param name="slipPrtKind"></param>
        /// <param name="sectionCode"></param>
        /// <param name="customerCode"></param>
        /// <returns></returns>
        private static CustDmdSetWork FindCustDmdSetWork( List<CustDmdSetWork> list, string enterpriseCode, int slipPrtKind, string sectionCode, int customerCode )
        {
            if ( list == null || list.Count == 0 ) return null;

            return list.Find(
                delegate( CustDmdSetWork target )
                {
                    return (target.EnterpriseCode.TrimEnd() == enterpriseCode.TrimEnd())
                            && (target.SlipPrtKind == slipPrtKind)
                            && ((target.SectionCode.TrimEnd() == sectionCode.TrimEnd()) ||
                                (target.SectionCode.TrimEnd() == string.Empty) && (sectionCode == ct_SectionZero))
                            && (target.CustomerCode == customerCode);
                }
                );
        }
        /// <summary>
        /// find �`�[�o�͐�ݒ�
        /// </summary>
        /// <param name="list"></param>
        /// <param name="enterpriseCode"></param>
        /// <param name="sectionCode"></param>
        /// <param name="warehouseCode"></param>
        /// <param name="cashRegisterNo"></param>
        /// <param name="slipPrtSetPaperId"></param>
        /// <returns></returns>
        private static SlipOutputSetWork FindSlipOutputSetWork( List<SlipOutputSetWork> list, string enterpriseCode, string sectionCode, string warehouseCode, int cashRegisterNo, string slipPrtSetPaperId )
        {
            if ( list == null || list.Count == 0 ) return null;

            return list.Find(
                delegate( SlipOutputSetWork target )
                {
                    return (target.EnterpriseCode.TrimEnd() == enterpriseCode.TrimEnd())
                        //&& (target.SectionCode == sectionCode)
                            && ((target.WarehouseCode.TrimEnd() == warehouseCode.TrimEnd()) ||
                                ( target.WarehouseCode.TrimEnd() == string.Empty ) && (warehouseCode == ct_WarehouseZero))
                            && (target.CashRegisterNo == cashRegisterNo)
                            && (target.SlipPrtSetPaperId.TrimEnd() == slipPrtSetPaperId.TrimEnd());
                }
                );
        }
        /// <summary>
        /// find �����S�̐ݒ�
        /// </summary>
        /// <param name="list"></param>
        /// <param name="enterpriseCode"></param>
        /// <param name="sectionCode"></param>
        /// <returns></returns>
        private static BillAllStWork FindBillAllStWork( List<BillAllStWork> list, string enterpriseCode, string sectionCode )
        {
            if ( list == null || list.Count == 0 ) return null;

            return list.Find(
                delegate( BillAllStWork target )
                {
                    return (target.EnterpriseCode.TrimEnd() == enterpriseCode.TrimEnd() &&
                            ((target.SectionCode.TrimEnd() == sectionCode.TrimEnd()) ||
                              ((target.SectionCode.TrimEnd() == string.Empty) && (sectionCode == ct_SectionZero))));
                }
                );
        }
        /// <summary>
        /// find ��������ݒ�
        /// </summary>
        /// <param name="list"></param>
        /// <param name="enterpriseCode"></param>
        /// <returns></returns>
        private static BillPrtStWork FindBillPrtStWork( List<BillPrtStWork> list, string enterpriseCode )
        {
            if ( list == null || list.Count == 0 ) return null;

            return list.Find(
                delegate( BillPrtStWork target )
                {
                    return (target.EnterpriseCode.TrimEnd() == enterpriseCode.TrimEnd());
                }
                );

        }
        /// <summary>
        /// find �S�̏����\���ݒ�
        /// </summary>
        /// <param name="list"></param>
        /// <param name="enterpriseCode"></param>
        /// <param name="sectionCode"></param>
        /// <returns></returns>
        private static AllDefSetWork FindAllDefSetWork( List<AllDefSetWork> list, string enterpriseCode, string sectionCode )
        {
            if ( list == null || list.Count == 0 ) return null;

            return list.Find(
                delegate( AllDefSetWork target )
                {
                    return (target.EnterpriseCode.TrimEnd() == enterpriseCode.TrimEnd() &&
                            ((target.SectionCode.TrimEnd() == sectionCode.TrimEnd()) ||
                              ((target.SectionCode.TrimEnd() == string.Empty) && (sectionCode == ct_SectionZero))));
                }
                );
        }
        # endregion

        // --- ADD START �c������ 2022/10/18 ----->>>>>
        # region [����p�ŗ����XML]
        /// <summary>
        /// ����p�ŗ����
        /// </summary>
        /// <remarks> 
        /// </remarks>
        public class TaxRatePrintInfo
        {
            /// <summary>����p�ŗ��ݒ���ŗ��P</summary>
            private string _taxRate1;
            /// <summary>����p�ŗ��ݒ���ŗ��Q</summary>
            private string _taxRate2;

            /// <summary>����p�ŗ��ݒ���ŗ��P</summary>
            public string TaxRate1
            {
                get { return _taxRate1; }
                set { _taxRate1 = value; }
            }

            /// <summary>����p�ŗ��ݒ���ŗ��Q</summary>
            public string TaxRate2
            {
                get { return _taxRate2; }
                set { _taxRate2 = value; }
            }
        }
        # endregion

        # region[�f�V���A���C�Y����]
        /// <summary>
        /// �f�V���A���C�Y����
        /// </summary>
        /// <returns>�f�V���A���C�Y����</returns>
        /// <remarks> 
        /// </remarks>
        public static Int32 Deserialize(out TaxRatePrintInfo taxRatePrintInfo, out String errmsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_WARNING;

            errmsg = string.Empty;
            taxRatePrintInfo = null;

            // ����p�ŗ����XML�t�@�C�����݂̔��f
            if (UserSettingController.ExistUserSetting(Path.Combine(ConstantManagement_ClientDirectory.UISettings, ctPrintXmlFileName)))
            {
                try
                {
                    taxRatePrintInfo = UserSettingController.DeserializeUserSetting<TaxRatePrintInfo>(Path.Combine(ConstantManagement_ClientDirectory.UISettings, ctPrintXmlFileName));
                    // �ŗ��ݒ���ŗ��P
                    double dTaxRate1 = -1;
                    Boolean bTaxRate1 = double.TryParse(taxRatePrintInfo.TaxRate1, out dTaxRate1);
                    // �ŗ��ݒ���ŗ��Q
                    double dTaxRate2 = -1;
                    Boolean bTaxRate2 = double.TryParse(taxRatePrintInfo.TaxRate2, out dTaxRate2);

                    // �ŗ����ݒ�̏ꍇ�A
                    if ((taxRatePrintInfo.TaxRate1 == string.Empty) || (taxRatePrintInfo.TaxRate2 == string.Empty) ||
                        // �����ŗ��l�̏ꍇ
                        (taxRatePrintInfo.TaxRate1 == taxRatePrintInfo.TaxRate2) ||
                        // �����ȊO�̏ꍇ�A
                        (!bTaxRate1) || (!bTaxRate2) ||
                        // �ŗ��l�̓}�C�i�X�̏ꍇ
                        (dTaxRate1 < 0) || (dTaxRate2 < 0) ||
                        // �ŗ��l��10�ȏ�̏ꍇ
                        (dTaxRate1 >= 10) || (dTaxRate2 >= 10))
                    {
                        errmsg = "�ŗ��ݒ��񂪐������ݒ肳��Ă��܂���B";
                        return status;
                    }

                }
                catch (System.InvalidOperationException)
                {
                    errmsg = "�ŗ��ݒ��񂪐������ݒ肳��Ă��܂���B";
                    return status;
                }
            }
            else
            {
                errmsg = "�ŗ��ݒ���t�@�C��(" + ctPrintXmlFileName + ")�����݂��܂���B";
                return status;
            }

            return (int)ConstantManagement.MethodResult.ctFNC_NORMAL; ;
        }
        # endregion        
        // --- ADD END   �c������ 2022/10/18 -----<<<<<
    }
}
