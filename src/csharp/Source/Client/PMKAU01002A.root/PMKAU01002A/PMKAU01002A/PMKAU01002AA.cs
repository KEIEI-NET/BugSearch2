//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ���R���[�i�������j�A�N�Z�X�N���X
// �v���O�����T�v   : ���R���[�i�������j�A�N�Z�X�N���X
//----------------------------------------------------------------------------//
//                (c)Copyright  2022 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11570183-00   �쐬�S�� : ���O
// �� �� ��  2022/03/07    �C�����e : ���������s(�d�q����A�g)�V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11870141-00   �쐬�S�� : �c������
// �� �� ��  2022/10/18    �C�����e : �C���{�C�X�c�Ή��i�y���ŗ��Ή��j
//----------------------------------------------------------------------------//
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
    /// <br>Programmer   : ���O</br>
    /// <br>Date         : 2022/03/07</br>
    /// <br>Update Note  : 2022/10/18 �c������</br>
    /// <br>�Ǘ��ԍ�     : 11870141-00 �C���{�C�X�c�Ή��i�y���ŗ��Ή��j</br>
    /// </remarks>
	public class EBooksFrePBillAcs
	{

        #region [private �t�B�[���h]
        private IEBooksFrePBillDB _iEBooksFrePBillDB;   // �����[�g�C���^�t�F�[�X
        private DataSet _printDataSet;  // ���DataSet
        private bool _extractCancel;
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
        /// <br>Programmer   : ���O</br>
        /// <br>Date         : 2022/03/07</br>
		/// </remarks>
		public EBooksFrePBillAcs()
		{
            // �����[�g�I�u�W�F�N�g�擾
            this._iEBooksFrePBillDB = (IEBooksFrePBillDB)MediationEBooksFrePBillDB.GetEBooksFrePBillDB();
		}
		#endregion

		#region [public ���\�b�h]
		/// <summary>
		/// �f�[�^�擾
		/// </summary>
        /// <param name="cndtn">���o����</param>
        /// <param name="cndtnView">���o����View</param>
		/// <param name="errMsg">�G���[���b�Z�[�W</param>
        /// <returns>�X�e�[�^�X</returns>
		/// <remarks>
		/// <br>Note       : �������f�[�^���擾����B</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2022/03/07</br>
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
        /// <param name="cndtn">���o����</param>
        /// <param name="cndtnView">���o����View</param>
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
        /// <returns>�X�e�[�^�X</returns>
		/// <remarks>
		/// <br>Note       : ������鐿�����f�[�^���擾����B</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2022/03/07</br>
        /// <br>Note       : 11870141-00 �C���{�C�X�c�Ή��i�y���ŗ��Ή��j</br>
        /// <br>Programmer : �c������ </br>
        /// <br>Date       : 2022/10/18</br>
		/// </remarks>
        private int SearchProc ( object cndtn, DataView cndtnView, out string errMsg )
		{
			int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;

			errMsg = "";

            _extractCancel = false;
            // --- ADD START �c������ 2022/10/18 ----->>>>>
            PMKAU01002AB.TaxRatePrintInfo taxRatePrintInfo = null;
            status = PMKAU01002AB.Deserialize(out taxRatePrintInfo, out errMsg);
            if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL) 
            {
                return status;
            }
            // --- ADD END   �c������ 2022/10/18 -----<<<<<

            // �f�[�^�Z�b�g�E�f�[�^�e�[�u������
            _printDataSet = new DataSet();
            _printDataSet.Tables.Add( PMKAU01002AB.CreateBillListTable() );

			try
			{
                if ( _extractCancel ) return SetReturnCancel();
                // ���o�����W�J  --------------------------------------------------------------
                EBooksFrePBillParaWork billCndtn;
                status = this.DevFrePBillCndtn( cndtn, cndtnView, out billCndtn, out errMsg );
				if ( status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL )
				{
					return status;
				}

                if ( _extractCancel ) return SetReturnCancel();
				// �f�[�^�擾  ----------------------------------------------------------------
				object retList = null;
                object retMList = null;
                bool msgDiv;
                status = this._iEBooksFrePBillDB.Search( XmlByteSerializer.Serialize( billCndtn ), out retList, out retMList, out msgDiv, out errMsg );

				switch ( status )
				{
					case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        if ( _extractCancel ) return SetReturnCancel();
                        if (errMsg != null && errMsg != "" ) { MessageBox.Show(errMsg); }
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
            _printDataSet.Tables.Add( PMKAU01002AB.CreateBillListTable() );

            DataRow row = _printDataSet.Tables[0].NewRow();
            // �t���O�𗧂Ă遨P�Ń`�F�b�N
            row[PMKAU01002AB.CT_BillList_ExtractCancel] = true;
            _printDataSet.Tables[0].Rows.Add( row );
            # endregion

            // �߂�l��NORMAL�ŕԂ�
            return (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
        }
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
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note        : ���o�����W�J����</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        private int DevFrePBillCndtn(object cndtn, DataView cndtnView, out EBooksFrePBillParaWork frePBillParaWork, out string errMsg)
		{
			int status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
			errMsg = string.Empty;

            frePBillParaWork = null;
            List<EBooksFrePBillParaWork.FrePBillParaKey> billKeyList = new List<EBooksFrePBillParaWork.FrePBillParaKey>();

            Dictionary<string, string> sectionDic = new Dictionary<string, string>();

            try
			{
                //-----------------------------------------------------
                // �ʏ�̐������������Z�b�g����DataView�̓��e����A
                // �������L�[���X�g�𐶐����܂��B
                //-----------------------------------------------------

                if ( cndtn is ExtrInfo_EBooksDemandTotal )
                {
                    foreach ( string sec in (cndtn as ExtrInfo_EBooksDemandTotal).ResultsAddUpSecList )
                    {
                        string sectionCode = sec.Trim();

                        if ( !sectionDic.ContainsKey( sectionCode ) )
                        {
                            sectionDic.Add( sectionCode, string.Empty );
                        }
                    }

                    //--------------------------------------------------------------
                    // ������
                    //--------------------------------------------------------------
                    # region [������]
                    foreach ( DataRowView rowView in cndtnView )
                    {
                        if ( (bool)rowView[PMKAU01002AB.CT_CsDmd_PrintFlag] == true &&
                             sectionDic.ContainsKey( ((string)rowView[PMKAU01002AB.CT_CsDmd_AddUpSecCode]).Trim() ) )
                        {
                            EBooksFrePBillParaWork.FrePBillParaKey key = new EBooksFrePBillParaWork.FrePBillParaKey();

                            key.SetAddUpDateLongDate( (int)rowView[PMKAU01002AB.CT_CsDmd_AddUpDateInt] );
                            key.AddUpSecCode = (string)rowView[PMKAU01002AB.CT_CsDmd_AddUpSecCode];
                            key.ClaimCode = (int)rowView[PMKAU01002AB.CT_CsDmd_ClaimCode];

                            if ( (bool)rowView[PMKAU01002AB.CT_BillList_DataType] == true )
                            {
                                // ���_�R�[�h
                                key.ResultsSectCd = "00";
                                // �����惌�R�[�h
                                key.CustomerCode = 0;
                            }
                            else
                            {
                                // ���_�R�[�h
                                key.ResultsSectCd = (string)rowView[PMKAU01002AB.CT_CsDmd_ResultsSectCd];
                                // ���Ӑ惌�R�[�h
                                key.CustomerCode = (int)rowView[PMKAU01002AB.CT_CsDmd_CustomerCode];
                            }

                            billKeyList.Add( key );
                        }
                    }

                    if ( billKeyList.Count > 0 )
                    {
                        // �����[�g���o��������
                        frePBillParaWork = new EBooksFrePBillParaWork();
                        frePBillParaWork.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;
                        frePBillParaWork.FrePBillParaKeyList = billKeyList;

                        // �������^�C�v��ݒ�
                        frePBillParaWork.SlipPrtKind = 60;
                        frePBillParaWork.UseSumCust = false;

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
        /// <param name="cndtn">��������</param>
        /// <param name="billCndtn">UI���o�����N���X</param>
        /// <param name="printList">�擾�f�[�^</param>
        /// <param name="masterList">�}�X�^�z�񃊃X�g</param>
		/// <remarks>
        /// <br>Note  �@    : �擾�f�[�^��W�J����B</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2022/03/07</br>
        /// <br>Note       : 11870141-00 �C���{�C�X�c�Ή��i�y���ŗ��Ή��j</br>
        /// <br>Programmer : �c������ </br>
        /// <br>Date       : 2022/10/18</br>
		/// </remarks>
        private void DevPrintData( object cndtn, EBooksFrePBillParaWork billCndtn, ArrayList printList, ArrayList masterList )
		{
            DataTable table = _printDataSet.Tables[PMKAU01002AB.CT_Tbl_BillList];

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

            //// �R�s�[����
            // --- DEL START �c������ 2022/10/18 ----->>>>>
            //PMKAU01002AB.CopyToBillListTable( ref table, cndtn, billCndtn, printList,
            //                                    custDmdSetList, slipOutputSetList, dmdPrtPtnList, frePrtPSetList, prtManageList, billAllStList, billPrtStList, allDefSetList,
            //                                    regNo, sectionCode );
            // --- DEL END   �c������ 2022/10/18 -----<<<<<
            // --- ADD START �c������ 2022/10/18 ----->>>>>
            PMKAU01002AB.CopyToBillListTable(ref table, cndtn, billCndtn, printList,
                                                custDmdSetList, slipOutputSetList, dmdPrtPtnList, frePrtPSetList, prtManageList, billAllStList, billPrtStList, allDefSetList,
                                                regNo, sectionCode, salesProcMoneyWorkList);
            // --- ADD END   �c������ 2022/10/18 -----<<<<<
		}
		#endregion

        # region [�v�����^�ݒ�擾]
        /// <summary>
        /// �v�����^�ݒ�@�S�擾
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <returns>�v�����^�Ǘ��ݒ茋��</returns>
        /// <remarks>
        /// <br>Note         : �v�����^�Ǘ��ݒ�̓��[�J���w�l�k��ǂݍ��݂܂��B</br>
        /// <br>Programmer   : ���O</br>
        /// <br>Date         : 2022/03/07</br>
        /// </remarks>
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
        /// <returns>�[���ݒ�</returns>
        /// <remarks>
        /// <br>Note         : �[���ݒ�擾����</br>
        /// <br>Programmer   : ���O</br>
        /// <br>Date         : 2022/03/07</br>
        /// </remarks>
        private int GetPosTerminalMg( out PosTerminalMg posTerminalMg, string enterpriseCode )
        {
            PosTerminalMgAcs acs = new PosTerminalMgAcs();
            return acs.Search( out posTerminalMg, enterpriseCode );
        }
        # endregion

		#endregion

		#endregion
	}
}
