using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Windows.Forms;

using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Globarization;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Xml.Serialization;


namespace Broadleaf.Application.Controller
{
	/// <summary>
    /// ���R���[�i�������j�A�N�Z�X�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note         : ���R���[�i�������j�Ŏg�p����f�[�^���擾����B</br>
    /// <br>               �y���o(E)����call���܂��z</br>
    /// <br>Programmer   : 22018 ��� ���b</br>
    /// <br>Date         : 2008.06.16</br>
    /// <br></br>
    /// <br>Update Note  : 2010.02.15  22018 ��� ���b</br>
    /// <br>             : ������(����)�Ή�</br>
    /// <br></br>
    /// <br>Update Note  : 2010/07/22  22018 ��� ���b</br>
    /// <br>             : �A�E�g�I�u�������G���[�Ή�</br>
    /// <br>Update Note  : 2012/02/06  ���|��</br>
    /// <br>�Ǘ��ԍ��@�@ : 10707327-00 2012/03/28�z�M��</br>
    /// <br>             : Redmine#28258 �������^���O�o�͂̒ǉ�</br>
    /// <br>Update Note  : 2022/10/18 �c������</br>
    /// <br>�Ǘ��ԍ�     : 11870141-00 �C���{�C�X�c�Ή��i�y���ŗ��Ή��j</br>
    /// </remarks>
	public class FrePBillAcs
	{
        #region [private static �t�B�[���h]
        //private static Employee stc_Employee;
        //private static PrtOutSet stc_PrtOutSet;			// ���[�o�͐ݒ�f�[�^�N���X
        //private static PrtOutSetAcs stc_PrtOutSetAcs;	// ���[�o�͐ݒ�A�N�Z�X�N���X

        //private static SecInfoAcs stc_SecInfoAcs;               // ���_�A�N�Z�X�N���X
        //private static Dictionary<string,SecInfoSet> stc_SectionDic;   // ���_Dictionary
        #endregion

        #region [private �t�B�[���h]
        private IFrePBillDB _iFrePBillDB;   // �����[�g�C���^�t�F�[�X

        //private DataTable _printListDt;			// ���DataTable
        //private DataView _printListDataView;	// ���DataView
        private DataSet _printDataSet;  // ���DataSet
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/03 ADD
        private bool _extractCancel;
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/03 ADD
        #endregion

        #region [public �v���p�e�B]
        /// <summary>
        /// ����f�[�^�Z�b�g(�ǂݎ���p)
        /// </summary>
        public DataSet PrintDataSet
        {
            get { return this._printDataSet; }
        }
        #endregion

		#region [�R���X�g���N�^]
		/// <summary>
		/// ���R���[�i�������j�A�N�Z�X�N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
		/// <br>Note       : ���R���[�i�������j�A�N�Z�X�N���X�̏��������s���B</br>
	    /// <br>Programmer : 22018 ��� ���b</br>
	    /// <br>Date       : 2007.09.19</br>
		/// </remarks>
		public FrePBillAcs()
		{
            // �����[�g�I�u�W�F�N�g�擾
            this._iFrePBillDB = (IFrePBillDB)MediationFrePBillDB.GetFrePBillDB();
		}
		#endregion

		#region [public ���\�b�h]
		/// <summary>
		/// �f�[�^�擾
		/// </summary>
        /// <param name="cndtn"></param>
        /// <param name="cndtnView">���o����</param>
		/// <param name="errMsg">�G���[���b�Z�[�W</param>
		/// <returns>Status</returns>
		/// <remarks>
		/// <br>Note       : �������f�[�^���擾����B</br>
	    /// <br>Programmer : 22018 ��� ���b</br>
	    /// <br>Date       : 2007.09.19</br>
		/// </remarks>
        public int SearchMain ( object cndtn, DataView cndtnView, out string errMsg )
		{
            return this.SearchProc( cndtn, cndtnView, out errMsg );
		}
		#endregion

		#region [private ���\�b�h]
		#region [���[�f�[�^�擾]
		/// <summary>
		/// �݌Ɉړ��f�[�^�擾
		/// </summary>
        /// <param name="cndtn"></param>
        /// <param name="cndtnView"></param>
		/// <param name="errMsg"></param>
		/// <returns>Status</returns>
		/// <remarks>
		/// <br>Note       : ������鐿�����f�[�^���擾����B</br>
	    /// <br>Programmer : 22018 ��� ���b</br>
	    /// <br>Date       : 2008.06.16</br>
        /// <br>Note       : 11870141-00 �C���{�C�X�c�Ή��i�y���ŗ��Ή��j</br>
        /// <br>Programmer : �c������ </br>
        /// <br>Date       : 2022/10/18</br>
		/// </remarks>
        private int SearchProc ( object cndtn, DataView cndtnView, out string errMsg )
		{
			int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;

			errMsg = "";

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/03 ADD
            _extractCancel = false;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/03 ADD
            // --- ADD START �c������ 2022/10/18 ----->>>>>
            PMKAU08002AB.TaxRatePrintInfo taxRatePrintInfo = null;
            status = PMKAU08002AB.Deserialize(out taxRatePrintInfo, out errMsg);
            if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL) 
            {
                return status;
            }
            // --- ADD END   �c������ 2022/10/18 -----<<<<<

            // �f�[�^�Z�b�g�E�f�[�^�e�[�u������
            _printDataSet = new DataSet();
            _printDataSet.Tables.Add( PMKAU08002AB.CreateBillListTable() );

			try
			{
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/03 ADD
                if ( _extractCancel ) return SetReturnCancel();
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/03 ADD

                // ���o�����W�J  --------------------------------------------------------------
                FrePBillParaWork billCndtn;
                status = this.DevFrePBillCndtn( cndtn, cndtnView, out billCndtn, out errMsg );
				if ( status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL )
				{
					return status;
				}

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/03 ADD
                if ( _extractCancel ) return SetReturnCancel();
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/03 ADD

				// �f�[�^�擾  ----------------------------------------------------------------
				object retList = null;
                object retMList = null;
                bool msgDiv;
                status = this._iFrePBillDB.Search( XmlByteSerializer.Serialize( billCndtn ), out retList, out retMList, out msgDiv, out errMsg );

				switch ( status )
				{
					case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/03 ADD
                        if ( _extractCancel ) return SetReturnCancel();
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/03 ADD
                        // ----- ADD 2012/02/06 xupz for redmine#28258---------->>>>>
                        if (errMsg != null && errMsg != "" ) { MessageBox.Show(errMsg); }
                        // ----- ADD 2012/02/06 xupz for redmine#28258----------<<<<<
						// �f�[�^�W�J����
                        DevPrintData( cndtn, billCndtn, (ArrayList)retList, (ArrayList)retMList );
                        status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
						break;
					case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
					case (int)ConstantManagement.DB_Status.ctDB_EOF:
						status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
						break;
					default:
						errMsg = "�������f�[�^�̎擾�Ɏ��s���܂����B";
						break;
				}
			}
			catch ( Exception ex )
			{
				errMsg = ex.Message;
				status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
			}
			return status;
		}

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/03 ADD
        /// <summary>
        /// ���o�L�����Z���{�^���C�x���g�n���h��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void CancelButtonClick( object sender, EventArgs e )
        {
            // �L�����Z���t���O�𗧂Ă�
            // ���o�����̗���Ńt���O���m�F���ď����𔲂���
            _extractCancel = true;
        }
        /// <summary>
        /// �L�����Z����
        /// </summary>
        /// <returns></returns>
        private int SetReturnCancel()
        {
            // ���o���ʃe�[�u����ҏW
            # region [���o���ʃe�[�u����ҏW]
            _printDataSet = new DataSet();
            _printDataSet.Tables.Add( PMKAU08002AB.CreateBillListTable() );

            DataRow row = _printDataSet.Tables[0].NewRow();
            // �t���O�𗧂Ă遨P�Ń`�F�b�N
            row[PMKAU08002AB.CT_BillList_ExtractCancel] = true;
            _printDataSet.Tables[0].Rows.Add( row );
            # endregion

            // �߂�l��NORMAL�ŕԂ�
            return (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/03 ADD
		#endregion

		#region [�f�[�^�W�J����]

		#region [���o�����W�J����]
		/// <summary>
		/// ���o�����W�J����
		/// </summary>
        /// <param name="cndtn"></param>
        /// <param name="cndtnView">UI���o�����N���X</param>
        /// <param name="frePBillParaWork">�����[�g���o�����N���X</param>
		/// <param name="errMsg">errMsg</param>
		/// <returns>Status</returns>
        private int DevFrePBillCndtn( object cndtn, DataView cndtnView, out FrePBillParaWork frePBillParaWork, out string errMsg )
		{
			int status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
			errMsg = string.Empty;

            frePBillParaWork = null;
            List<FrePBillParaWork.FrePBillParaKey> billKeyList = new List<FrePBillParaWork.FrePBillParaKey>();

            // --- ADD m.suzuki 2010/07/22 ---------->>>>>
            Dictionary<string, string> sectionDic = new Dictionary<string, string>();
            // --- ADD m.suzuki 2010/07/22 ----------<<<<<

            try
			{
                //-----------------------------------------------------
                // �ʏ�̐������������Z�b�g����DataView�̓��e����A
                // �������L�[���X�g�𐶐����܂��B
                //-----------------------------------------------------

                // --- UPD m.suzuki 2010/02/18 ---------->>>>>
                # region // DEL
                //foreach ( DataRowView rowView in cndtnView )
                //{
                //    if ( (bool)rowView[PMKAU08002AB.CT_CsDmd_PrintFlag] == true )
                //    {
                //        FrePBillParaWork.FrePBillParaKey key = new FrePBillParaWork.FrePBillParaKey();

                //        key.SetAddUpDateLongDate( (int)rowView[PMKAU08002AB.CT_CsDmd_AddUpDateInt] );
                //        key.AddUpSecCode = (string)rowView[PMKAU08002AB.CT_CsDmd_AddUpSecCode];
                //        key.ClaimCode = (int)rowView[PMKAU08002AB.CT_CsDmd_ClaimCode];

                //        if ( (bool)rowView[PMKAU08002AB.CT_BillList_DataType] == true )
                //        {
                //            // ���_�R�[�h
                //            key.ResultsSectCd = "00";
                //            // �����惌�R�[�h
                //            key.CustomerCode = 0;
                //        }
                //        else
                //        {
                //            // ���_�R�[�h
                //            key.ResultsSectCd = (string)rowView[PMKAU08002AB.CT_CsDmd_ResultsSectCd];
                //            // ���Ӑ惌�R�[�h
                //            key.CustomerCode = (int)rowView[PMKAU08002AB.CT_CsDmd_CustomerCode];
                //        }

                //        billKeyList.Add( key );
                //    }
                //}

                //if ( billKeyList.Count > 0 )
                //{
                //    // �����[�g���o��������
                //    frePBillParaWork = new FrePBillParaWork();
                //    frePBillParaWork.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;
                //    frePBillParaWork.FrePBillParaKeyList = billKeyList;
                    
                //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/09/26 ADD
                //    if ( cndtn is ExtrInfo_DemandTotal )
                //    {
                //        // �������^�C�v��ݒ�
                //        frePBillParaWork.SlipPrtKind = (cndtn as ExtrInfo_DemandTotal).SlipPrtKind;
                //    }
                //    else
                //    {
                //        errMsg = "���R���[(������)�̒��o�������������ݒ肳��Ă��܂���B";
                //        status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
                //        return status;
                //    }
                //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/09/26 ADD
                //    status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                //}
                # endregion

                if ( cndtn is ExtrInfo_DemandTotal )
                {
                    // --- ADD m.suzuki 2010/07/22 ---------->>>>>
                    foreach ( string sec in (cndtn as ExtrInfo_DemandTotal).ResultsAddUpSecList )
                    {
                        string sectionCode = sec.Trim();

                        if ( !sectionDic.ContainsKey( sectionCode ) )
                        {
                            sectionDic.Add( sectionCode, string.Empty );
                        }
                    }
                    // --- ADD m.suzuki 2010/07/22 ----------<<<<<

                    //--------------------------------------------------------------
                    // ������
                    //--------------------------------------------------------------
                    # region [������]
                    foreach ( DataRowView rowView in cndtnView )
                    {
                        // --- UPD m.suzuki 2010/07/22 ---------->>>>>
                        //if ( (bool)rowView[PMKAU08002AB.CT_CsDmd_PrintFlag] == true )
                        if ( (bool)rowView[PMKAU08002AB.CT_CsDmd_PrintFlag] == true &&
                             sectionDic.ContainsKey( ((string)rowView[PMKAU08002AB.CT_CsDmd_AddUpSecCode]).Trim() ) )
                        // --- UPD m.suzuki 2010/07/22 ----------<<<<<
                        {
                            FrePBillParaWork.FrePBillParaKey key = new FrePBillParaWork.FrePBillParaKey();

                            key.SetAddUpDateLongDate( (int)rowView[PMKAU08002AB.CT_CsDmd_AddUpDateInt] );
                            key.AddUpSecCode = (string)rowView[PMKAU08002AB.CT_CsDmd_AddUpSecCode];
                            key.ClaimCode = (int)rowView[PMKAU08002AB.CT_CsDmd_ClaimCode];

                            if ( (bool)rowView[PMKAU08002AB.CT_BillList_DataType] == true )
                            {
                                // ���_�R�[�h
                                key.ResultsSectCd = "00";
                                // �����惌�R�[�h
                                key.CustomerCode = 0;
                            }
                            else
                            {
                                // ���_�R�[�h
                                key.ResultsSectCd = (string)rowView[PMKAU08002AB.CT_CsDmd_ResultsSectCd];
                                // ���Ӑ惌�R�[�h
                                key.CustomerCode = (int)rowView[PMKAU08002AB.CT_CsDmd_CustomerCode];
                            }

                            billKeyList.Add( key );
                        }
                    }

                    if ( billKeyList.Count > 0 )
                    {
                        // �����[�g���o��������
                        frePBillParaWork = new FrePBillParaWork();
                        frePBillParaWork.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;
                        frePBillParaWork.FrePBillParaKeyList = billKeyList;

                        // �������^�C�v��ݒ�
                        frePBillParaWork.SlipPrtKind = (cndtn as ExtrInfo_DemandTotal).SlipPrtKind;
                        frePBillParaWork.UseSumCust = false;

                        status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                    }
                    # endregion
                }
                else if ( cndtn is SumExtrInfo_DemandTotal )
                {
                    // --- ADD m.suzuki 2010/07/22 ---------->>>>>
                    foreach ( string sec in (cndtn as SumExtrInfo_DemandTotal).ResultsAddUpSecList )
                    {
                        string sectionCode = sec.Trim();

                        if ( !sectionDic.ContainsKey( sectionCode ) )
                        {
                            sectionDic.Add( sectionCode, string.Empty );
                        }
                    }
                    // --- ADD m.suzuki 2010/07/22 ----------<<<<<

                    //--------------------------------------------------------------
                    // �������i�����j
                    //--------------------------------------------------------------
                    # region [������(����)]
                    foreach ( DataRowView rowView in cndtnView )
                    {
                        // --- UPD m.suzuki 2010/07/22 ---------->>>>>
                        //if ( (bool)rowView[PMKAU08002AB.CT_CsDmd_PrintFlag] == true && (bool)rowView[PMKAU08002AB.CT_CsDmd_DataType] == true )
                        if ( (bool)rowView[PMKAU08002AB.CT_CsDmd_PrintFlag] == true &&
                             (bool)rowView[PMKAU08002AB.CT_CsDmd_DataType] == true &&
                             sectionDic.ContainsKey( ((string)rowView[PMKAU08002AB.CT_CsDmd_AddUpSecCode]).Trim() ) )
                        // --- UPD m.suzuki 2010/07/22 ----------<<<<<
                        {
                            FrePBillParaWork.FrePBillParaKey key = new FrePBillParaWork.FrePBillParaKey();

                            key.SetAddUpDateLongDate( (int)rowView[PMKAU08002AB.CT_CsDmd_AddUpDateInt] );
                            key.AddUpSecCode = (string)rowView[PMKAU08002AB.CT_CsDmd_AddUpSecCode];

                            // ������R�[�h �� �������Ӑ���Z�b�g����
                            key.ClaimCode = (int)rowView[PMKAU08002AB.CT_CsDmd_SumClaimCustCode];

                            // ���_�R�[�h
                            key.ResultsSectCd = "00";
                            // ���Ӑ�R�[�h
                            key.CustomerCode = 0;

                            billKeyList.Add( key );
                        }
                    }

                    if ( billKeyList.Count > 0 )
                    {
                        // �����[�g���o��������
                        frePBillParaWork = new FrePBillParaWork();
                        frePBillParaWork.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;
                        frePBillParaWork.FrePBillParaKeyList = billKeyList;
                        
                        // �������^�C�v��ݒ�
                        frePBillParaWork.SlipPrtKind = (cndtn as SumExtrInfo_DemandTotal).SlipPrtKind;
                        frePBillParaWork.UseSumCust = true;

                        status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                    }
                    # endregion
                }
                else 
                {
                    errMsg = "���R���[(������)�̒��o�������������ݒ肳��Ă��܂���B";
                    status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
                    return status;
                }
                // --- UPD m.suzuki 2010/02/18 ----------<<<<<
			}
			catch ( Exception ex )
			{
				errMsg = ex.Message;
				status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
			}
			return status;
		}
		#endregion

		#region [�擾�f�[�^�W�J����]
		/// <summary>
		/// �擾�f�[�^�W�J����
		/// </summary>
        /// <param name="cndtn"></param>
        /// <param name="billCndtn">UI���o�����N���X</param>
        /// <param name="printList">�擾�f�[�^</param>
        /// <param name="masterList">�}�X�^�z�񃊃X�g</param>
		/// <returns>Status</returns>
		/// <remarks>
		/// <br>Note       : �擾�f�[�^��W�J����B</br>
	    /// <br>Programmer : 22018 ��� ���b</br>
	    /// <br>Date       : 2007.09.19</br>
        /// <br>Note       : 11870141-00 �C���{�C�X�c�Ή��i�y���ŗ��Ή��j</br>
        /// <br>Programmer : �c������ </br>
        /// <br>Date       : 2022/10/18</br>
		/// </remarks>
        private void DevPrintData( object cndtn, FrePBillParaWork billCndtn, ArrayList printList, ArrayList masterList )
		{
            DataTable table = _printDataSet.Tables[PMKAU08002AB.CT_Tbl_BillList];

            int regNo = 0;
            string sectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;

            # region [�}�X�^�W�J]
            List<CustDmdSetWork> custDmdSetList = null;
            List<SlipOutputSetWork> slipOutputSetList = null;
            List<DmdPrtPtnWork> dmdPrtPtnList = null;
            List<FrePrtPSetWork> frePrtPSetList = null;
            List<PrtManage> prtManageList = null;
            List<BillAllStWork> billAllStList = null;
            List<BillPrtStWork> billPrtStList = null;
            List<AllDefSetWork> allDefSetList = null;
            // --- ADD START �c������ 2022/10/18 ----->>>>>
            // ������z�����敪�ݒ�
            List<SalesProcMoneyWork> salesProcMoneyWorkList = null;
            // --- ADD END   �c������ 2022/10/18 -----<<<<<

            // �����[�g�擾�����}�X�^���X�g
            foreach ( object obj in masterList )
            {
                if ( obj is CustDmdSetWork[] )
                {
                    custDmdSetList = new List<CustDmdSetWork>( (CustDmdSetWork[])obj );
                }
                else if ( obj is SlipOutputSetWork[] )
                {
                    slipOutputSetList = new List<SlipOutputSetWork>( (SlipOutputSetWork[])obj );
                }
                else if ( obj is DmdPrtPtnWork[] )
                {
                    dmdPrtPtnList = new List<DmdPrtPtnWork>( (DmdPrtPtnWork[])obj );
                }
                else if ( obj is FrePrtPSetWork[] )
                {
                    frePrtPSetList = new List<FrePrtPSetWork>( (FrePrtPSetWork[])obj );
                }
                else if ( obj is BillAllStWork[] )
                {
                    billAllStList = new List<BillAllStWork>( (BillAllStWork[])obj );
                }
                else if ( obj is BillPrtStWork[] )
                {
                    billPrtStList = new List<BillPrtStWork>( (BillPrtStWork[])obj );
                }
                else if ( obj is AllDefSetWork[] )
                {
                    allDefSetList = new List<AllDefSetWork>( (AllDefSetWork[])obj );
                }
                // --- ADD START �c������ 2022/10/18 ----->>>>>
                else if (obj is SalesProcMoneyWork[])
                {
                    salesProcMoneyWorkList = new List<SalesProcMoneyWork>((SalesProcMoneyWork[])obj);
                }
                // --- ADD END   �c������ 2022/10/18 -----<<<<<
            }

            // �v�����^�ݒ胊�X�g
            prtManageList = SearchAllPrtManage( billCndtn.EnterpriseCode );

            // �[���ԍ��i���W�ԍ��j
            PosTerminalMg posTerminalMg;
            if ( GetPosTerminalMg( out posTerminalMg, billCndtn.EnterpriseCode ) == 0)
            {
                regNo = posTerminalMg.CashRegisterNo;
            }
            # endregion

            // --- DEL START �c������ 2022/10/18 ----->>>>>
            //// �R�s�[����
            //PMKAU08002AB.CopyToBillListTable( ref table, cndtn, billCndtn, printList,
            //                                    custDmdSetList, slipOutputSetList, dmdPrtPtnList, frePrtPSetList, prtManageList, billAllStList, billPrtStList, allDefSetList,
            //                                    regNo, sectionCode );
            // --- DEL END   �c������ 2022/10/18 -----<<<<<
            // --- ADD START �c������ 2022/10/18 ----->>>>>
            // �R�s�[����
            PMKAU08002AB.CopyToBillListTable(ref table, cndtn, billCndtn, printList,
                                                custDmdSetList, slipOutputSetList, dmdPrtPtnList, frePrtPSetList, prtManageList, billAllStList, billPrtStList, allDefSetList,
                                                regNo, sectionCode, salesProcMoneyWorkList);
            // --- ADD END   �c������ 2022/10/18 -----<<<<<
		}
		#endregion

        # region [�v�����^�ݒ�擾]
        /// <summary>
        /// �v�����^�ݒ�@�S�擾
        /// </summary>
        /// <param name="enterpriseCode"></param>
        /// <returns></returns>
        /// <remarks>���v�����^�Ǘ��ݒ�̓��[�J���w�l�k��ǂݍ��݂܂��B</remarks>
        public List<PrtManage> SearchAllPrtManage( string enterpriseCode )
        {
            PrtManageAcs _prtManageAcs = new PrtManageAcs();

            List<PrtManage> prtManageList = new List<PrtManage>();

            ArrayList retList;
            _prtManageAcs.SearchAll( out retList, enterpriseCode );

            foreach ( PrtManage prtManage in retList )
            {
                if ( prtManage.LogicalDeleteCode == 0 )
                {
                    prtManageList.Add( prtManage );
                }
            }

            return prtManageList;
        }
        # endregion

        # region [�[���ݒ�擾]
        /// <summary>
        /// �[���ݒ�擾����
        /// </summary>
        /// <param name="posTerminalMg">POS�[���Ǘ��ݒ�</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <returns></returns>
        private int GetPosTerminalMg( out PosTerminalMg posTerminalMg, string enterpriseCode )
        {
            PosTerminalMgAcs acs = new PosTerminalMgAcs();
            return acs.Search( out posTerminalMg, enterpriseCode );

            //..debug
            //posTerminalMg = new PosTerminalMg();
            //posTerminalMg.CashRegisterNo = 1;
            //posTerminalMg.EnterpriseCode = enterpriseCode;
            //posTerminalMg.PosPCTermCd = 0;
            //return 0;
            //..debug
        }
        # endregion

		#endregion

		#endregion
	}
}
