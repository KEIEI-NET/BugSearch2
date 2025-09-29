//****************************************************************************//
// �V�X�e��         : PM.NS�V���[�Y
// �v���O��������   : �I���֘A�ꗗ�\(�I�������\�A�I�����ٕ\�A�I���\)
// �v���O�����T�v   : �I���֘A�ꗗ�\(�I�������\�A�I�����ٕ\�A�I���\)��������܂��B
//----------------------------------------------------------------------------//
//                (c)Copyright  2007 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �����@�m
// �� �� ��  2007/04/09  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���� ��`
// �C �� ��  2007/09/14  �C�����e : DC.NS�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���� ��`
// �C �� ��  2008/02/13  �C�����e : �s��Ή��iDC.NS�Ή��j
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ����
// �C �� ��  2008/10/08  �C�����e : PM.NS�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �Ɠc �M�u
// �C �� ��  2009/05/13  �C�����e : �s��Ή�[13259]
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���� ���n
// �C �� ��  2009/09/18  �C�����e : ���[�����͕��̒��o�����͈󎚑ΏۊO�Ƃ���
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : liyp
// �C �� ��  2011/01/11  �C�����e : ���o�����ǉ��ɔ������[�̃w�b�_�֒��o������ǉ��ň󎚂���悤�ɕύX����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �c����
// �C �� ��  2011/01/11  �C�����e : �I����Q�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : liyp
// �C �� ��  2011/02/10  �C�����e : ��Q�� #18873 �� ��Q�� #18874
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �c����
// �C �� ��  2012/12/27  �C�����e : 2013/01/16�z�M���@Redmine#33233
//                                  �h�b�g�v�����^�Ɉ󎚂����ꍇ�X�g�b�N�t�H�[��(15�~11)�̉�3����2���炢���g���Ĉ������悤�ɑΉ�
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Text;
using System.Windows.Forms;

using Broadleaf.Application.Common;
using Broadleaf.Application.Controller;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Globarization;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Text;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Windows.Forms;

namespace Broadleaf.Drawing.Printing
{
	/// <summary>
	/// �I���֘A�ꗗ�\����N���X
	/// </summary>
	/// <remarks>
	/// <br>Note       : �I���֘A�ꗗ�\��������܂��B</br>
	/// <br>Programmer : 23010 �����@�m</br>
	/// <br>Date       : 2007.04.09</br>
    /// <br>Update Note: 2007.09.14 980035 ���� ��`</br>
    /// <br>			 �EDC.NS�Ή�</br>
    /// <br>Update Note: 2008.02.13 980035 ���� ��`</br>
    /// <br>			 �E�s��Ή��iDC.NS�Ή��j</br>
    /// -----------------------------------------------------------------------------------
    /// <br>UpdateNote : PM.NS�Ή�</br>
    /// <br>Programmer : 30413 ����</br>
    /// <br>Date	   : 2008.10.08</br>
    /// <br>           : 2009/05/13 �Ɠc �M�u�@�s��Ή�[13259]</br>
    /// <br>Update Note: 2011/01/11 �c����</br>
    /// <br>			 �I����Q�Ή�</br>
    /// <br>Update Note: 2012/12/27 �c����</br>
    /// <br>�Ǘ��ԍ�   : 2013/01/16�z�M��</br>
    /// <br>             Redmine#33233 �h�b�g�v�����^�Ɉ󎚂����ꍇ�X�g�b�N�t�H�[��(15�~11)�̉�3����2���炢���g���Ĉ������悤�ɑΉ�</br>
    /// </remarks>
	class MAZAI02112PA
	{
		// --------------------------------------------------
		#region Constructor

		/// <summary>
		/// �I���֘A�ꗗ�\����N���X�R���X�g���N�^
		/// </summary>
		/// <param name="printInfo">������I�u�W�F�N�g</param>
		/// <remarks>
		/// <br>Note       : �I���֘A�ꗗ�\����N���X�̐V�����C���X�^���X�����������܂��B</br>
		/// <br>Programmer : 23010 �����@�m</br>
        /// <br>Date       : 2007.04.09</br>
        /// <br>Update Note: 2012/12/27 �c����</br>
        /// <br>�Ǘ��ԍ�   : 2013/01/16�z�M��</br>
        /// <br>             Redmine#33233 �h�b�g�v�����^�Ɉ󎚂����ꍇ�X�g�b�N�t�H�[��(15�~11)�̉�3����2���炢���g���Ĉ������悤�ɑΉ�</br>
		/// </remarks>
		public MAZAI02112PA( object printInfo )
		{
			// ������I�u�W�F�N�g�擾
			this._printInfo             = printInfo as SFCMN06002C;
			// �A�N�Z�X�N���X�C���X�^���X����
			this._inventoryListCmnAcs = new InventoryListCmnAcs();
            //----- ADD 2012/12/27 �c���� Redmine#33233 ------->>>>>
            // �`�[����A�N�Z�X�N���X
            this._slipPrintAcs = new SlipPrintAcs(LoginInfoAcquisition.EnterpriseCode, LoginInfoAcquisition.Employee.BelongSectionCode);
            //----- ADD 2012/12/27 �c���� Redmine#33233 -------<<<<<
		}

		#endregion

		// --------------------------------------------------
		#region ReportPrintException

		/// <summary>
		/// ���[�����O�N���X
		/// </summary>
		/// <remarks>
		/// <br>Note       : ���[����̗�O�N���X�ł��B</br>
		/// <br>Programmer : 23010 �����@�m</br>
		/// <br>Date       : 2007.04.09</br>
		/// </remarks>
		private class ReportPrintException : ApplicationException
		{
			#region Private Members

			/// <summary>�X�e�[�^�X</summary>
			private int		_status		= -1;
			/// <summary>�������\�b�hID</summary>
			private string	_procNm		= "";

			#endregion

			#region Constructor

			/// <summary>
			/// ���[�����O�N���X�R���X�g���N�^
			/// </summary>
			/// <param name="message">���b�Z�[�W</param>
			/// <param name="status">�X�e�[�^�X</param>
			/// <remarks>
			/// <br>Note       : ���[�����O�N���X�̐V�����C���X�^���X�����������܂��B</br>
			/// <br>Programmer : 23010 �����@�m</br>
			/// <br>Date       : 2007.04.09</br>
			/// </remarks>
			public ReportPrintException( string message, int status ) : base( message )
			{
				this._status = status;
			}

			/// <summary>
			/// ���[�����O�N���X�R���X�g���N�^
			/// </summary>
			/// <param name="message">���b�Z�[�W</param>
			/// <param name="status">�X�e�[�^�X</param>
			/// <param name="procNm">�������\�b�hID</param>
			/// <remarks>
			/// <br>Note       : ���[�����O�N���X�̐V�����C���X�^���X�����������܂��B</br>
			/// <br>Programmer : 23010 �����@�m</br>
			/// <br>Date       : 2007.04.09</br>
			/// </remarks>
			public ReportPrintException( string message, int status, string procNm ) : base( message )
			{
				this._status = status;
				this._procNm = procNm;
			}

			#endregion

			#region Properties

			/// <summary>
			/// �X�e�[�^�X�v���p�e�B
			/// </summary>
			public int Status {
				get {
					return this._status;
				}
			}

			/// <summary>
			/// �������\�b�hID�v���p�e�B
			/// </summary>
			public string ProcNm {
				get {
					return this._procNm;
				}
			}

			#endregion
		}

		#endregion

		// --------------------------------------------------
		#region Private Members

		// ������I�u�W�F�N�g
		private SFCMN06002C _printInfo  = null;

		// ���o�����N���X
		private InventSearchCndtnUI _extrInfo   = null;

		// �I���֘A�ꗗ�\���ʃA�N�Z�X�N���X
		private InventoryListCmnAcs _inventoryListCmnAcs    = null;

        //----- ADD 2012/12/27 �c���� Redmine#33233 ------->>>>>
        // �`�[����A�N�Z�X�N���X
        private SlipPrintAcs _slipPrintAcs;
        //----- ADD 2012/12/27 �c���� Redmine#33233 -------<<<<<

		#endregion

		// --------------------------------------------------
		#region Constant

		// �N���XID
		private const string	CT_CLASSID              = "MAZAI02112PA";
		// �v���O����ID
		private const string	CT_PGID                 = "MAZAI02112P";
		// �v���O��������
		private const string	CT_PGNM                 = "�I���֘A�ꗗ�\";

		// ���o���������Ԋu�p�萔
		//private const string	CT_SPACE                = "    "; //DEL 2011/02/10
        private const string    CT_SPACE = "  "; // ADD 2011/02/10
		// ReportFormNamspace
		private const string	CT_REPORTFORM_NAMESPACE = "Broadleaf.Drawing.Printing";
        //a

        #endregion

        // 2008.02.13 �ǉ� >>>>>>>>>>>>>>>>>>>>
        /// <summary>�\������</summary>
        private string CT_SectionCode_Odr       = "SectionCode";            // ���_�R�[�h
        private string CT_WarehouseCode_Odr     = "WarehouseCode";          // �q�ɃR�[�h
        private string CT_WarehouseShelfNo_Odr  = "WarehouseShelfNo";       // �q�ɒI��
        private string CT_CustomerCode_Odr      = "CustomerCode";           // ���Ӑ�R�[�h(�d����)
        private string CT_BLGoodsCode_Odr       = "BLGoodsCode";            // �a�k�R�[�h
        private string CT_MakerCode_Odr         = "MakerCode";              // ���[�J�[�R�[�h
        private string CT_GoodsCode_Odr         = "GoodsCode";              // ���i�R�[�h
        private string CT_GoodsDivL_Odr         = "LargeGoodsGanreCode";    // ���i�敪�O���[�v
        private string CT_GoodsDivM_Odr         = "MediumGoodsGanreCode";   // ���i�敪
        private string CT_GoodsDivD_Odr         = "DetailGoodsGanreCode";   // ���i�敪�ڍ�
        // 2008.02.13 �ǉ� <<<<<<<<<<<<<<<<<<<<

        // --------------------------------------------------
		#region Properties

		/// <summary>������p�����[�^�v���p�e�B</summary>
		/// <value>������p�����[�^���擾�܂��͐ݒ肵�܂��B</value>
		public SFCMN06002C Printinfo
		{
			get {
				return this._printInfo;
			}
			set {
				this._printInfo = value;
			}
		}

		#endregion

		// --------------------------------------------------
		#region Public Methods

		/// <summary>
		/// ��������J�n
		/// </summary>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : ����������J�n���܂��B</br>
		/// <br>Programmer : 23010 �����@�m</br>
		/// <br>Date       : 2007.04.09</br>
		/// </remarks>
		public int StartPrint()
		{
			return this.PrintMain();
		}

		#endregion

		// --------------------------------------------------
		#region Private Methods

		/// <summary>
		/// ������C������
		/// </summary>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : ����̃��C���������s���܂��B</br>
		/// <br>Programmer : 23010 �����@�m</br>
        /// <br>Date       : 2007.04.09</br>
        /// <br>Update Note: 2012/12/27 �c����</br>
        /// <br>�Ǘ��ԍ�   : 2013/01/16�z�M��</br>
        /// <br>             Redmine#33233 �h�b�g�v�����^�Ɉ󎚂����ꍇ�X�g�b�N�t�H�[��(15�~11)�̉�3����2���炢���g���Ĉ������悤�ɑΉ�</br>
		/// </remarks>
		private int PrintMain()
		{
			const string ctPROCNM = "PrintMain";
			int status = ( int )ConstantManagement.MethodResult.ctFNC_ERROR;

			this._extrInfo = this._printInfo.jyoken as InventSearchCndtnUI;

			// ����p�t�H�[���N���X
			DataDynamics.ActiveReports.ActiveReport3 prtRpt = null;

			try 
            {
				// ����p�f�[�^�r���[�C���X�^���X����
                DataView dv = this._printInfo.rdData as DataView;

                // 2008.10.31 30413 ���� E�N���X�Ń\�[�g�ςȂ̂Ŏ��{���Ȃ� >>>>>>START
                // 2008.02.13 �C�� >>>>>>>>>>>>>>>>>>>>
                // �\�[�g���ݒ�
                //dv.Sort = this.GetPrintOderQuerry();
                // 2008.02.13 �C�� <<<<<<<<<<<<<<<<<<<<
                // 2008.10.31 30413 ���� E�N���X�Ń\�[�g�ςȂ̂Ŏ��{���Ȃ� <<<<<<END

                //----- ADD 2012/12/27 �c���� Redmine#33233 ------->>>>>
                //�I�������\�̂�
                if (this._printInfo.PrintPaperSetCd == 0)
                {
                    List<PrtManage> prtManageList = _slipPrintAcs.SearchAllPrtManage(LoginInfoAcquisition.EnterpriseCode);
                    if (prtManageList != null && prtManageList.Count > 0)
                    {
                        if (!string.IsNullOrEmpty(this._printInfo.prinm))
                        {
                            foreach (PrtManage itm in prtManageList)
                            {
                                if (itm.LogicalDeleteCode == 0 && itm.PrinterName == this._printInfo.prinm)
                                {
                                    if (itm.PrinterKind == 0)
                                    {
                                        // ���[�U�[�v�����^�Ɉ󎚂����ꍇ
                                        // ���|�[�g�C���X�^���X����
                                        this.CreateReport(out prtRpt, this._printInfo.prpid);
                                    }
                                    else if (itm.PrinterKind == 1)
                                    {
                                        // �h�b�g�v�����^�Ɉ󎚂����ꍇ
                                        // ���|�[�g�C���X�^���X����
                                        this.CreateReport(out prtRpt, "MAZAI02112P_07A4C");
                                    }
                                    else
                                    {
                                        // �Ȃ�
                                    }
                                }
                            }
                        }
                        else
                        {
                            // ���|�[�g�C���X�^���X����
                            this.CreateReport(out prtRpt, this._printInfo.prpid);
                        }
                    }
                    else
                    {
                        // ���|�[�g�C���X�^���X����
                        this.CreateReport(out prtRpt, this._printInfo.prpid);
                    }
                }
                else
                {
                    // ���|�[�g�C���X�^���X����
                    this.CreateReport(out prtRpt, this._printInfo.prpid);
                }
                //----- ADD 2012/12/27 �c���� Redmine#33233 -------<<<<<

				// ���|�[�g�C���X�^���X����
                //this.CreateReport( out prtRpt, this._printInfo.prpid ); // DEL 2012/12/27 �c���� Redmine#33233
				if( prtRpt == null ) {
					return status;
				}

				// �e��v���p�e�B�ݒ�
				status = this.SetFormProperties( ref prtRpt );
				if( status != 0 ) {
					return status;
				}

				// �o�C���h����f�[�^�\�[�X�̃Z�b�g
				prtRpt.DataSource	= dv;
				prtRpt.DataMember	= "";

				// ������ʏ��v���p�e�B�ݒ�
				Broadleaf.Windows.Forms.SFCMN00293UC commonInfo;
				status = this.SetPrintCommonInfo( out commonInfo );
				if( status != 0 ) {
					return status;
				}

				// �v���r���[�L���敪
				int mode = this._printInfo.prevkbn;

				// �o�̓��[�h��PDF�̏ꍇ�A�������Ńv���r���[����
				if( this._printInfo.printmode == 2 ) {
					// PDF�o�͎�
					mode = 0;
				}

				switch( mode ) {
					case 0:			// �v���r���[����
					{
						Broadleaf.Windows.Forms.SFCMN00293UB processForm = new Broadleaf.Windows.Forms.SFCMN00293UB();

						// ���ʏ����ݒ�
						processForm.CommonInfo = commonInfo;

						// �v���O���X�o�[�A�b�v�C�x���g�ǉ�
						if( prtRpt is IPrintActiveReportTypeCommon ) {
							( ( IPrintActiveReportTypeCommon )prtRpt ).ProgressBarUpEvent += 
								new ProgressBarUpEventHandler( processForm.ProgressBarUpEvent );
						}

						// ������s
						status = processForm.Run( prtRpt, true );

						// �߂�l�ݒ�
						this._printInfo.status = status;
						break;
					}
					case 1:			// �v���r���[�L��
					{
						Broadleaf.Windows.Forms.SFCMN00293UA viewForm = new Broadleaf.Windows.Forms.SFCMN00293UA();

						// ���ʏ����ݒ�
						viewForm.CommonInfo = commonInfo;

						// �v���r���[���s
						status = viewForm.Run( prtRpt );

						// �߂�l�ݒ�
						this._printInfo.status = status;
						break;
					}
				}

				if( status == ( int )ConstantManagement.MethodResult.ctFNC_NORMAL ) {
					switch( this._printInfo.printmode ) {
						case 1:  // �v�����^
						{
							break;
						}
						case 2:  // �o�c�e
						case 3:  // ����(�v�����^ + �o�c�e)
						{
							// �o�c�e�\���t���OON
							this._printInfo.pdfopen = true;

							// ����������̂ݗ���ۑ�
							if( this._printInfo.printmode == 3 ) {
								// �o�͗����Ǘ��ɒǉ�
								SFANL06101UA selectOldPdf = new SFANL06101UA();
								selectOldPdf.AddPrintInfo( this._printInfo.key, this._printInfo.prpnm, this._printInfo.prpnm, this._printInfo.pdftemppath );
							}
							break;
						}
					}
				}
			}
			catch( ReportPrintException rpEx ) {
				this.MsgDispProc( emErrorLevel.ERR_LEVEL_STOPDISP, rpEx.Message, rpEx.Status, rpEx.ProcNm );
			}
			catch( Exception ex ) {
				this.MsgDispProc( emErrorLevel.ERR_LEVEL_STOPDISP, ex.Message, -1, ctPROCNM );
				status = -1;
			}
			finally {
				// ���|�[�g�I�u�W�F�N�g��j��
				if( prtRpt != null ) {
					prtRpt.Dispose();
				}
			}

			return status;
		}

		/// <summary>
		/// �e��ActiveReport���[�C���X�^���X����
		/// </summary>
		/// <param name="prtObj">�C���X�^���X�����ꂽ���[�t�H�[���N���X</param>
		/// <param name="prpid">���[�t�H�[��ID</param>
		/// <remarks>
		/// <br>Note       : �w�肳�ꂽ�A�Z���u���y�уN���X�����A�N���X���C���X�^���X�����܂��B</br>
		/// <br>Programmer : 23010 �����@�m</br>
		/// <br>Date       : 2007.04.09</br>
		/// </remarks>
		private void CreateReport( out DataDynamics.ActiveReports.ActiveReport3 prtObj, string prpid )
		{
			prtObj = ( DataDynamics.ActiveReports.ActiveReport3 )this.LoadAssemblyReport( 
				prpid.Trim(), CT_REPORTFORM_NAMESPACE + "." + prpid.Trim(), 
				typeof( DataDynamics.ActiveReports.ActiveReport3 ) );
		}

		/// <summary>
		/// �w�肳�ꂽ�A�Z���u���y�уN���X���ɂ��N���X�C���X�^���X������
		/// </summary>
		/// <param name="asmname">�A�Z���u������</param>
		/// <param name="classname">�N���X����</param>
		/// <param name="type">��������N���X�^</param>
		/// <returns>�C���X�^���X�����ꂽ�N���X</returns>
		/// <remarks>
		/// <br>Note       : �w�肳�ꂽ�A�Z���u���y�уN���X���̂��A�N���X���C���X�^���X�����܂��B</br>
		/// <br>Programmer : 23010 �����@�m</br>
		/// <br>Date       : 2007.04.09</br>
		/// </remarks>
		private object LoadAssemblyReport( string asmname, string classname, Type type )
		{
			const string ctPROCNM = "LoadAccemblyReport";
			object obj = null;

			try {
				System.Reflection.Assembly asm = System.Reflection.Assembly.Load( asmname );
				Type objType = asm.GetType( classname );
				if( objType != null ) {
					if( ( objType == type ) || ( objType.IsSubclassOf( type ) == true ) || ( objType.GetInterface( type.Name ).Name == type.Name ) ) {
						obj = Activator.CreateInstance( objType );
					}
				}
			}
			catch( System.IO.FileNotFoundException ) {
				throw new ReportPrintException( asmname + "�����݂��܂���B", -1, ctPROCNM );
			}
			catch( Exception ex ) {
				throw new ReportPrintException( ex.Message, -1, ctPROCNM );
			}

			return obj;
		}

		/// <summary>
		/// �v���p�e�B�ݒ�֐�
		/// </summary>
		/// <param name="prtRpt">����p�A�N�e�B�u���|�[�g�N���X�ϐ�</param>
		/// <remarks>
		/// <br>Note       : �v���p�e�B�ݒ�֐��B</br>
		/// <br>Programmer : 23010 �����@�m</br>
		/// <br>Date       : 2007.04.09</br>
		/// </remarks>
		private int SetFormProperties( ref DataDynamics.ActiveReports.ActiveReport3 prtRpt )
		{
			int status = ( int )ConstantManagement.MethodResult.ctFNC_ERROR;
			const string ctPROCNM = "SetFormProperties";
			try 
            {
				// ActiveReport�C���^�[�t�F�[�X�ɃL���X�g
				IPrintActiveReportTypeList instance     = prtRpt as IPrintActiveReportTypeList;

				// �\�[�g���v���p�e�B�ݒ�
				instance.PageHeaderSortOderTitle        = this.MakeSortCondition();
				
				// ���o�����ҏW����
				StringCollection extraInfomations;
				this.MakeExtractConditionMain( out extraInfomations );
				instance.ExtraConditions                = extraInfomations; 
				
				// ���[�o�͐ݒ���擾
				PrtOutSet prtOutSet = null;
				string message;

                //TODO:�A�N�Z�X�N���X�u����
				status = this._inventoryListCmnAcs.ReadPrtOutSet( out prtOutSet, out message );
				if( status != 0 ) {
					throw new ReportPrintException( message, status, ctPROCNM );
				}

				// ���o�����w�b�_�o�͋敪
				instance.ExtraCondHeadOutDiv            = prtOutSet.ExtraCondHeadOutDiv;
				// �t�b�^�o�͋敪
				instance.PageFooterOutCode              = prtOutSet.FooterPrintOutCode;

				// �t�b�^�o�̓��b�Z�[�W
				StringCollection footers = new StringCollection();
				footers.Add( prtOutSet.PrintFooter1 );
				footers.Add( prtOutSet.PrintFooter2 );
				instance.PageFooters                    = footers;

				// ������I�u�W�F�N�g
				instance.PrintInfo                      = this._printInfo;
		
				// ���̑��f�[�^
				ArrayList otherDataList = new ArrayList();
				instance.OtherDataList                  = otherDataList;

				status = ( int )ConstantManagement.MethodResult.ctFNC_NORMAL;
			}
			catch( ReportPrintException rpEx ) {
				this.MsgDispProc( emErrorLevel.ERR_LEVEL_STOPDISP, rpEx.Message, rpEx.Status, rpEx.ProcNm );
				status = rpEx.Status;
			}
			catch ( Exception ex ) {
				status = -1;
				this.MsgDispProc( emErrorLevel.ERR_LEVEL_STOPDISP, ex.Message, status, ctPROCNM );
			}

			return status;
		}

		/// <summary>
		/// �����ʋ��ʏ��ݒ�
		/// </summary>
		/// <param name="commonInfo"></param>
		/// <returns>�X�e�[�^�X</returns>
		/// <remarks>
		/// <br>Note       : �����ʋ��ʏ����̐ݒ���s���܂��B</br>
		/// <br>Programmer : 23010 �����@�m</br>
		/// <br>Date       : 2007.04.09</br>
		/// </remarks>
		private int SetPrintCommonInfo( out Broadleaf.Windows.Forms.SFCMN00293UC commonInfo )
		{
			int status = ( int )ConstantManagement.DB_Status.ctDB_NORMAL;

			commonInfo = new Broadleaf.Windows.Forms.SFCMN00293UC();
		
			// �v�����^��
			commonInfo.PrinterName = this._printInfo.prinm;
			// ���[��
			commonInfo.PrintName   = this._printInfo.prpnm;				
				
			// �������
            commonInfo.PrintMax    = ( ( DataView )this.Printinfo.rdData ).Count;
			// ������[�h
			commonInfo.PrintMode   = this.Printinfo.printmode;
			
			// PDF�o�̓t���p�X
			// ���[�`���[�g���ʕ��i�N���X
			SFCMN00331C cmnCommon = new SFCMN00331C(); 
			// PDF�p�X�擾
			string pdfPath = "";
			string pdfName = "";
			status = cmnCommon.GetPdfSavePathName( this._printInfo.prpnm, ref pdfPath, ref pdfName );
			if( status != (int)ConstantManagement.DB_Status.ctDB_NORMAL ) {
				status = -1;
				return status;
			}
			this._printInfo.pdftemppath = System.IO.Path.Combine( pdfPath, pdfName );
			commonInfo.PdfFullPath = this._printInfo.pdftemppath;

			// �󎚈ʒu
			commonInfo.MarginsLeft  = this._printInfo.px;
			commonInfo.MarginsTop   = this._printInfo.py;

			return status;
		}

		/// <summary>
		///	���o�����쐬�֐�
		/// </summary>
		/// <remarks>
		/// <br>Note       : �Ώۊ��ԁA���o�����P�C�Q��string�^�̔z��Ɋi�[����B</br>
		/// <br>Programmer : 23010 �����@�m</br>
        /// <br>Date       : 2007.04.09</br>
        /// <br>Update Note: 2011/01/11 �c����</br>
        /// <br>			 �I����Q�Ή�</br> 
        /// <br>Update Note: 2011/01/11 liyp </br>
        /// <br>           ���o�����ǉ��ɔ������[�̃w�b�_�֒��o������ǉ��ň󎚂���悤�ɕύX����</br>
        /// <br>Update Note: 2011/02/10 liyp </br>
        /// <br>           ��Q�� #18873</br>
		/// </remarks>
		private void MakeExtractConditionMain( out StringCollection allExtractCondition )
        {
            #region ���o�����P�쐬����
          
            allExtractCondition = new StringCollection();

            //���[��ނɂ���ď����𕪂���
            // 2007.09.14 �C�� >>>>>>>>>>>>>>>>>>>>
            //switch (this._extrInfo.SelctedPaperKindDiv)
            switch (this._extrInfo.SelectedPaperKind)
            // 2007.09.14 �C�� <<<<<<<<<<<<<<<<<<<<
            {
                case 0:
                {
                    //�I���L���\
                    //�I������������
                    // 2008.02.13 �C�� >>>>>>>>>>>>>>>>>>>>
                    ////�J�n�̓��t�������Ă��Ȃ��ꍇ
                    //if(this._extrInfo.St_InventoryPreprDayDateTime == DateTime.MinValue)
                    //{
                    //    //�I���̓��t�������Ă��Ȃ�
                    //    if(this._extrInfo.Ed_InventoryPreprDayDateTime == DateTime.MinValue)
                    //    {
                    //        //�������w�肵�Ă��Ȃ��ƌ��Ȃ��������Ȃ�
                    //    }
                    //    //�I���̓��t�͓����Ă���
                    //    else
                    //    {
                    //        this.EditCondition( ref allExtractCondition,
                    //        String.Format("�I������������" + "�F {0} �` {1}", "�s�n�o", TDateTime.DateTimeToString("YYYY/MM/DD",this._extrInfo.Ed_InventoryPreprDayDateTime)));
                    //    }                 
                    //}
                    //else
                    //{
                    //    //�I�����̓��t�������Ă��Ȃ�
                    //    if(this._extrInfo.Ed_InventoryPreprDayDateTime == DateTime.MinValue)
                    //    {
                    //        this.EditCondition( ref allExtractCondition,
                    //        String.Format("�I������������" + "�F {0} �` {1}", TDateTime.DateTimeToString("YYYY/MM/DD",this._extrInfo.St_InventoryPreprDayDateTime),"�d�m�c"));
                    //    }
                    //    //�ǂ���������Ă���
                    //    else
                    //    {
                    //        this.EditCondition( ref allExtractCondition,
                    //        String.Format("�I������������" + "�F {0} �` {1}", TDateTime.DateTimeToString("YYYY/MM/DD",this._extrInfo.St_InventoryPreprDayDateTime),TDateTime.DateTimeToString("YYYY/MM/DD",this._extrInfo.Ed_InventoryPreprDayDateTime)));
                    //    }                        
                    //}
                    // 2008.10.31 30413 ���� �I�����ɏC�� >>>>>>START
                    //this.EditCondition(ref allExtractCondition,
                    //String.Format("�I������������" + "�F {0}", TDateTime.DateTimeToString("YYYY/MM/DD", this._extrInfo.St_InventoryPreprDayDateTime)));
                    this.EditCondition(ref allExtractCondition,
                    String.Format("�I����" + "�F {0}", TDateTime.DateTimeToString("YYYY/MM/DD", this._extrInfo.St_InventoryPreprDayDateTime)));
                    // 2008.10.31 30413 ���� �I�����ɏC�� <<<<<<END
                    // 2008.02.13 �C�� <<<<<<<<<<<<<<<<<<<<
                    break;
                }
                case 1:
                {
                    //�I�����ٕ\
                    //�I����
                    // 2008.02.13 �C�� >>>>>>>>>>>>>>>>>>>>
                    ////�J�n�̓��t�������Ă��Ȃ��ꍇ
                    //if(this._extrInfo.St_InventoryDayDateTime == DateTime.MinValue)
                    //{
                    //    //�I���̓��t�������Ă��Ȃ�
                    //    if(this._extrInfo.Ed_InventoryDayDateTime == DateTime.MinValue)
                    //    {
                    //        //�������w�肵�Ă��Ȃ��ƌ��Ȃ��������Ȃ�
                    //    }
                    //    //�I���̓��t�͓����Ă���
                    //    else
                    //    {
                    //        this.EditCondition( ref allExtractCondition,
                    //        String.Format("�I����" + "�F {0} �` {1}", "�s�n�o", TDateTime.DateTimeToString("YYYY/MM/DD",this._extrInfo.Ed_InventoryDayDateTime)));
                    //    }                 
                    //}
                    //else
                    //{
                    //    //�I�����̓��t�������Ă��Ȃ�
                    //    if(this._extrInfo.Ed_InventoryDayDateTime == DateTime.MinValue)
                    //    {
                    //        this.EditCondition( ref allExtractCondition,
                    //        String.Format("�I����" + "�F {0} �` {1}", TDateTime.DateTimeToString("YYYY/MM/DD",this._extrInfo.St_InventoryDayDateTime),"�d�m�c"));
                    //    }
                    //    //�ǂ���������Ă���
                    //    else
                    //    {
                    //        this.EditCondition( ref allExtractCondition,
                    //        String.Format("�I����" + "�F {0} �` {1}", TDateTime.DateTimeToString("YYYY/MM/DD",this._extrInfo.St_InventoryDayDateTime),TDateTime.DateTimeToString("YYYY/MM/DD",this._extrInfo.Ed_InventoryDayDateTime)));
                    //    }                        
                    //}
                    this.EditCondition(ref allExtractCondition,
                    String.Format("�I����" + "�F {0}", TDateTime.DateTimeToString("YYYY/MM/DD", this._extrInfo.St_InventoryDayDateTime)));
                    // 2008.02.13 �C�� <<<<<<<<<<<<<<<<<<<<
                    break;
                }
                case 2:
                {
                    //�I���\
                    //�I����
                    // 2008.02.13 �C�� >>>>>>>>>>>>>>>>>>>>
                    ////�J�n�̓��t�������Ă��Ȃ��ꍇ
                    //if (this._extrInfo.St_InventoryDayDateTime == DateTime.MinValue)
                    //{
                    //    //�I���̓��t�������Ă��Ȃ�
                    //    if(this._extrInfo.Ed_InventoryDayDateTime == DateTime.MinValue)
                    //    {
                    //        //�������w�肵�Ă��Ȃ��ƌ��Ȃ��������Ȃ�
                    //    }
                    //    //�I���̓��t�͓����Ă���
                    //    else
                    //    {
                    //        this.EditCondition( ref allExtractCondition,
                    //        String.Format("�I����" + "�F {0} �` {1}", "�s�n�o", TDateTime.DateTimeToString("YYYY/MM/DD",this._extrInfo.Ed_InventoryDayDateTime)));
                    //    }                 
                    //}
                    //else
                    //{
                    //    //�I�����̓��t�������Ă��Ȃ�
                    //    if(this._extrInfo.Ed_InventoryDayDateTime == DateTime.MinValue)
                    //    {
                    //        this.EditCondition( ref allExtractCondition,
                    //        String.Format("�I����" + "�F {0} �` {1}", TDateTime.DateTimeToString("YYYY/MM/DD",this._extrInfo.St_InventoryDayDateTime),"�d�m�c"));
                    //    }
                    //    //�ǂ���������Ă���
                    //    else
                    //    {
                    //        this.EditCondition( ref allExtractCondition,
                    //        String.Format("�I����" + "�F {0} �` {1}", TDateTime.DateTimeToString("YYYY/MM/DD",this._extrInfo.St_InventoryDayDateTime),TDateTime.DateTimeToString("YYYY/MM/DD",this._extrInfo.Ed_InventoryDayDateTime)));
                    //    }                        
                    //}
                    this.EditCondition(ref allExtractCondition,
                    String.Format("�I����" + "�F {0}", TDateTime.DateTimeToString("YYYY/MM/DD", this._extrInfo.St_InventoryDayDateTime)));
                    // 2008.02.13 �C�� <<<<<<<<<<<<<<<<<<<<
                    break;
                }
            }

            string wkStr = "";

            // 2008.10.31 30413 ���� ��󎚍��ڂ��폜 >>>>>>START
            ////�󎚑Ώ�(���ٕ\�̏ꍇ�̂�)
            //// 2007.09.14 �C�� >>>>>>>>>>>>>>>>>>>>
            ////if(this._extrInfo.SelctedPaperKindDiv == 1)
            //if (this._extrInfo.SelectedPaperKind == 1)
            //// 2007.09.14 �C�� <<<<<<<<<<<<<<<<<<<<
            //{
            //    if(this._extrInfo.DifCntExtraDiv == 0)
            //    {
            //        //�S��
            //        wkStr = "�󎚑Ώ�: �S��";
            //        this.EditCondition( ref allExtractCondition, wkStr );
            //    }
            //    // 2007.09.14 �ǉ� >>>>>>>>>>>>>>>>>>>>
            //    else if (this._extrInfo.DifCntExtraDiv == 1)
            //    {
            //        //�������͕��̂�
            //        wkStr = "�󎚑Ώ�: �������͕��̂�";
            //        this.EditCondition(ref allExtractCondition, wkStr);
            //    }
            //    else if (this._extrInfo.DifCntExtraDiv == 2)
            //    {
            //        //�����͕��̂�
            //        wkStr = "�󎚑Ώ�: �����͕��̂�";
            //        this.EditCondition(ref allExtractCondition, wkStr);
            //    }
            //    // 2007.09.14 �ǉ� <<<<<<<<<<<<<<<<<<<<
            //    else
            //    {
            //        //���ٕ��݈̂�
            //        // 2007.09.14 �C�� >>>>>>>>>>>>>>>>>>>>
            //        //wkStr = "�󎚑Ώ�: ���ٕ��݈̂�";
            //        wkStr = "�󎚑Ώ�: ���ٕ��̂�";
            //        // 2007.09.14 �C�� <<<<<<<<<<<<<<<<<<<<
            //        this.EditCondition(ref allExtractCondition, wkStr);
            //    }
            //}

            //// 2007.09.14 �C�� >>>>>>>>>>>>>>>>>>>>
            //////�W�v�P��          
            ////if (this._extrInfo.GrossPrintDiv == 0) 
            ////{
            ////    //�W�v(�O���X)���Ȃ�
            ////	wkStr = "�W�v�P��: �����ԍ�";
            ////	this.EditCondition( ref allExtractCondition, wkStr );
            ////}
            ////else
            ////{
            ////    //�W�v(�O���X)����
            ////    wkStr = "�W�v�P��: ���i";
            ////	this.EditCondition( ref allExtractCondition, wkStr );
            ////}
            //// 2007.09.14 �C�� <<<<<<<<<<<<<<<<<<<<

            ////�O�o��
            ////�I���\
            //// 2007.09.14 �C�� >>>>>>>>>>>>>>>>>>>>
            ////if (this._extrInfo.SelctedPaperKindDiv == 2)
            //if (this._extrInfo.SelectedPaperKind == 2)
            //// 2007.09.14 �C�� <<<<<<<<<<<<<<<<<<<<
            //{
            //    //�I�����O�o��
            //    if(this._extrInfo.IvtStkCntZeroExtraDiv == 0)
            //    {
            //        //�󎚂���
            //        wkStr = "�I�����O�o��: �o�͂���";
            //        this.EditCondition( ref allExtractCondition, wkStr );
            //    }
            //    else
            //    {
            //        //�󎚂��Ȃ�
            //        wkStr = "�I�����O�o��: �o�͂��Ȃ�";
            //        this.EditCondition( ref allExtractCondition, wkStr );
            //    }
            //}
            ////�I�����ٕ\
            //// 2007.09.14 �C�� >>>>>>>>>>>>>>>>>>>>
            ////else if(this._extrInfo.SelctedPaperKindDiv == 1)
            //else if(this._extrInfo.SelectedPaperKind == 1)
            //// 2007.09.14 �C�� <<<<<<<<<<<<<<<<<<<<
            //{
            //    //2007/04/24
            //    //���됔�O�o�͂�����
            //    ////���됔�O�o��
            //    //if(this._extrInfo.IvtStkCntZeroExtraDiv == 0)
            //    //{
            //    //    //�󎚂���
            //    //    wkStr = "���됔�O�o��: �o�͂���";
            //    //    this.EditCondition( ref allExtractCondition, wkStr );
            //    //}
            //    //else
            //    //{
            //    //    //�󎚂��Ȃ�
            //    //    wkStr = "���됔�O�o��: �o�͂��Ȃ�";
            //    //    this.EditCondition( ref allExtractCondition, wkStr );
            //    //}
            //}

            ////���Ӑ�󎚋敪
            //if(this._extrInfo.CustomerPrintDiv == 0)
            //{              
            //    wkStr = "���Ӑ�󎚋敪: �d�������";
            //    this.EditCondition( ref allExtractCondition, wkStr );
            //}
            //else
            //{
            //    wkStr = "���Ӑ�󎚋敪: �ϑ������";
            //    this.EditCondition( ref allExtractCondition, wkStr );
            //}

            ////���됔��
            //// 2007.09.14 �C�� >>>>>>>>>>>>>>>>>>>>
            ////if(this._extrInfo.SelctedPaperKindDiv == 0)
            //if(this._extrInfo.SelectedPaperKind == 0)
            //// 2007.09.14 �C�� <<<<<<<<<<<<<<<<<<<<
            //{
            //    //�L���\�̏ꍇ
            //    //���됔��
            //    if(this._extrInfo.StockCntPrintDiv == 0)
            //    {
            //        //�󎚂���
            //        wkStr = "���됔��: �󎚂���";
            //        this.EditCondition( ref allExtractCondition, wkStr );
            //    }
            //    else
            //    {
            //        //�󎚂��Ȃ�
            //        wkStr = "���됔��: �󎚂��Ȃ�";
            //        this.EditCondition( ref allExtractCondition, wkStr );
            //    }
            //}
            // 2008.10.31 30413 ���� ��󎚍��ڂ��폜 <<<<<<END
            
            // 2007.09.14 �ǉ� >>>>>>>>>>>>>>>>>>>>
            //�o�͎w��敪
            if (this._extrInfo.SelectedPaperKind == 0)
            {
                if (this._extrInfo.OutputAppointDiv == 0)
                {
                    //�S��
                    wkStr = "�o�͎w��: �S��";
                    this.EditCondition(ref allExtractCondition, wkStr);
                }
                else if (this._extrInfo.OutputAppointDiv == 1)
                {
                    //�I�������͂̂�
                    wkStr = "�o�͎w��: �I�������͂̂�";
                    this.EditCondition(ref allExtractCondition, wkStr);
                }
                else if (this._extrInfo.OutputAppointDiv == 2)
                {
                    //���ٕ��̂�
                    wkStr = "�o�͎w��: ���ٕ��̂�";
                    this.EditCondition(ref allExtractCondition, wkStr);
                }
                else
                {
                    //�d���I�Ԃ���̂�
                    wkStr = "�o�͎w��: �d���I�Ԃ���̂�";
                    this.EditCondition(ref allExtractCondition, wkStr);
                }
            }

            // 2008.11.04 30413 ���� �ǉ� >>>>>>START
            // �݌ɋ敪
            if (this._extrInfo.StockDiv == 0)
            {
                // �S��
                wkStr = "�݌ɋ敪: �S��";
                this.EditCondition(ref allExtractCondition, wkStr);
            }
            else if (this._extrInfo.StockDiv == 1)
            {
                // ����
                wkStr = "�݌ɋ敪: ����";
                this.EditCondition(ref allExtractCondition, wkStr);
            }
            else
            {
                // ���
                wkStr = "�݌ɋ敪: ���";
                this.EditCondition(ref allExtractCondition, wkStr);
            }

            // -- UPD 2009/09/18 ------------------------>>>
            //// �I�������͋敪
            //if (this._extrInfo.SelectedPaperKind == 2)
            //{
            //    if (this._extrInfo.InventoryNonInputDiv == 0)
            //    {
            //        // ���됔�̗p
            //        wkStr = "�I�������͋敪: ���됔�̗p";
            //        this.EditCondition(ref allExtractCondition, wkStr);
            //    }
            //    else
            //    {
            //        // �����͈���
            //        wkStr = "�I�������͋敪: �����͈���";
            //        this.EditCondition(ref allExtractCondition, wkStr);
            //    }
            //}
            // -- UPD 2009/09/18 ------------------------<<<

            // ���v��
            if ((this._extrInfo.SelectedPaperKind == 1) || (this._extrInfo.SelectedPaperKind == 2))
            {
                if (this._extrInfo.SubtotalPrintDiv == 0)
                {
                    // ����
                    wkStr = "���v��: ����";
                    this.EditCondition(ref allExtractCondition, wkStr);
                }
                else
                {
                    // ���Ȃ�
                    wkStr = "���v��: ���Ȃ�";
                    this.EditCondition(ref allExtractCondition, wkStr);
                }
            }
            // 2008.11.04 30413 ���� �ǉ� <<<<<<END
            
            // 2008.10.31 30413 ���� ��󎚍��ڂ��폜 >>>>>>START
            ////�I�������͋敪
            //if (this._extrInfo.SelectedPaperKind == 2)
            //{
            //    if (this._extrInfo.InventoryInputDiv == 0)
            //    {
            //        //�����͈���
            //        wkStr = "�I�������͎�: �����͈���";
            //        this.EditCondition(ref allExtractCondition, wkStr);
            //    }
            //    else
            //    {
            //        //���됔�Ɠ���
            //        wkStr = "�I�������͎�: ���됔�Ɠ���";
            //        this.EditCondition(ref allExtractCondition, wkStr);
            //    }
            //}
            // 2008.10.31 30413 ���� ��󎚍��ڂ��폜 <<<<<<END
            
            // 2008.11.26 30413 ���� ���y�[�W�����łɕ����ύX >>>>>>START
            //���y�[�W�w��敪
            if (this._extrInfo.TurnOoverThePagesDiv == 0)
            {
                //�q��
                //wkStr = "���y�[�W: �q��";
                wkStr = "����: �q��";
                this.EditCondition(ref allExtractCondition, wkStr);
            }
            else if (this._extrInfo.TurnOoverThePagesDiv == 1)
            {
                //�����
                // 2008.10.31 30413 ���� �o�͏��ɏC�� >>>>>>START
                //wkStr = "���y�[�W: �����";
                wkStr = "����: �o�͏�";
                // 2008.10.31 30413 ���� �o�͏��ɏC�� <<<<<<END
                this.EditCondition(ref allExtractCondition, wkStr);

                if ((this._extrInfo.SortDiv == 0) || (this._extrInfo.SortDiv == 4))
                {
                    //�I�ԃu���C�N�敪�i�����j
                    int shelfNoBreak = this._extrInfo.ShelfNoBreakDiv + 1;
                    wkStr = "�I�ԃu���C�N: " + shelfNoBreak.ToString() + "��";
                    this.EditCondition(ref allExtractCondition, wkStr);
                }
            }
            else
            {
                //���Ȃ�
                //wkStr = "���y�[�W: ���Ȃ�";
                wkStr = "����: ���Ȃ�";
                this.EditCondition(ref allExtractCondition, wkStr);
            }
            // 2008.11.26 30413 ���� ���y�[�W�����łɕ����ύX <<<<<<END
            // 2007.09.14 �ǉ� <<<<<<<<<<<<<<<<<<<<
            
            // ---ADD 2009/05/13 �s��Ή�[13259] ---------------------------->>>>>
            // ----- UPD 2011/01/11 ----------------->>>>>
            ////�I�����ٕ\���̂�
            //if (this._extrInfo.SelectedPaperKind == 0)
            // �I�������\�ƒI�����ٕ\�ƒI���\
            if (this._extrInfo.SelectedPaperKind == 0 || this._extrInfo.SelectedPaperKind == 1 || this._extrInfo.SelectedPaperKind == 2)
            // ----- UPD 2011/01/11 -----------------<<<<<
            {
                //�ݏo��
                if (this._extrInfo.LendExtraDiv == 0)
                {
                    wkStr = "�ݏo��: ������Ȃ�";
                    this.EditCondition(ref allExtractCondition, wkStr);
                }
                else
                {
                    wkStr = "�ݏo��: �������";
                    this.EditCondition(ref allExtractCondition, wkStr);
                }

                //�����v�㕪
                if (this._extrInfo.DelayPaymentDiv == 0)
                {
                    wkStr = "�����v�㕪: ������Ȃ�";
                    this.EditCondition(ref allExtractCondition, wkStr);
                }
                else
                {
                    wkStr = "�����v�㕪: �������";
                    this.EditCondition(ref allExtractCondition, wkStr);
                }

            }
            // ---ADD 2009/05/13 �s��Ή�[13259] ----------------------------<<<<<

            //�I���\���̂�
            // ---------ADD 2011/01/11 --------------------------->>>>>
            if (this._extrInfo.SelectedPaperKind == 2)
            {
                //���ʈ���敪
                if (this._extrInfo.InventoryNonInputDiv == 0) //�I�������͋敪:���됔�̗p
                {
                    if (this._extrInfo.NumOutputDiv == 1) // �I�����P�ȏ�o��
                    {
                        // wkStr = "���ʈ���敪: �I�����P�ȏ�"; DEL 2011/02/10
                        wkStr = "���ʏo�͋敪: �I�����P�ȏ�"; //ADD 2011/02/10
                        this.EditCondition(ref allExtractCondition, wkStr);
                    }
                    else if (this._extrInfo.NumOutputDiv == 2) //�I�����O�ȉ��o��
                    {
                        // wkStr = "���ʈ���敪: �I�����O�ȉ�";DEL 2011/02/10
                        wkStr = "���ʏo�͋敪: �I�����O�ȉ�"; //ADD 2011/02/10
                        this.EditCondition(ref allExtractCondition, wkStr);
                    }
                    else if (this._extrInfo.NumOutputDiv == 3)                                // �I�����O�̂ݏo��
                    {
                        // wkStr = "���ʈ���敪: �I�����O�̂�";DEL 2011/02/10
                        wkStr = "���ʏo�͋敪: �I�����O�̂�"; //ADD 2011/02/10
                        this.EditCondition(ref allExtractCondition, wkStr);
                    }
                    else
                    {
                        // wkStr = "���ʈ���敪: �S��"; // DEL 2011/02/10
                        wkStr = "���ʏo�͋敪: �S��";// ADD 2011/02/10
                        this.EditCondition(ref allExtractCondition, wkStr);
                    }
                }
                else                                           //�I�������͋敪:�����͈���
                {
                    if (this._extrInfo.NumOutputDiv == 4) // �����͂̂ݏo��
                    {
                        // wkStr = "���ʈ���敪: �����͂̂�"; // DEL 2011/02/10
                        wkStr = "���ʏo�͋敪: �����͂̂�"; // ADD 2011/02/10
                        this.EditCondition(ref allExtractCondition, wkStr);
                    }
                    else if (this._extrInfo.NumOutputDiv == 5)// �����͈ȊO�o��
                    {
                        // wkStr = "���ʈ���敪: �����͈ȊO"; // DEL 2011/02/10
                        wkStr = "���ʏo�͋敪: �����͈ȊO"; // ADD 2011/02/10
                        this.EditCondition(ref allExtractCondition, wkStr);
                    }
                    else
                    {
                        // wkStr = "���ʈ���敪: �S��"; // DEL 2011/02/10
                        wkStr = "���ʏo�͋敪: �S��"; // ADD 2011/02/10
                        this.EditCondition(ref allExtractCondition, wkStr);
                    }
                }

                // �I�Ԉ���敪
                if (this._extrInfo.WarehouseShelfOutputDiv == 1)      // �I�ԂȂ��̂ݏo��
                {
                    // wkStr = "�I�Ԉ���敪: �I�ԂȂ��̂�"; // DEL 2011/02/10
                    wkStr = "�I�ԏo�͋敪: �I�ԂȂ��̂�"; // ADD 2011/02/10
                    this.EditCondition(ref allExtractCondition, wkStr);
                }
                else if (this._extrInfo.WarehouseShelfOutputDiv == 2) // �I�ԂȂ��ȊO�o��
                {
                    // wkStr = "�I�Ԉ���敪: �I�ԂȂ��ȊO"; // DEL 2011/02/10
                    wkStr = "�I�ԏo�͋敪: �I�ԂȂ��ȊO"; // ADD 2011/02/10
                    this.EditCondition(ref allExtractCondition, wkStr);
                }
                else                                                  // �S�ďo��
                {
                    // wkStr = "�I�Ԉ���敪: �S��"; // DEL 2011/02/10
                    wkStr = "�I�ԏo�͋敪: �S��"; // ADD 2011/02/10
                    this.EditCondition(ref allExtractCondition, wkStr);
                }
            }
            // ---------ADD 2011/01/11 ---------------------------<<<<<
           
            #endregion
    		
			StringCollection wkStrCollection = new StringCollection();
			// ���o����2
			this.MakeCondition2( ref wkStrCollection );
			// �������ڒǉ�
			foreach( string workStr in wkStrCollection ) 
            {
				allExtractCondition.Add( workStr );
			}

           
		}

		/// <summary>
		/// ���o����������ҏW
		/// </summary>
		/// <param name="editArea">�i�[�G���A</param>
		/// <param name="target">�Ώە�����</param>
		/// <remarks>
		/// <br>Note       : �o�͂��钊�o�����������ҏW���܂��B</br>
		/// <br>Programmer : 23010 �����@�m</br>
		/// <br>Date       : 2007.04.09</br>
        /// <br>UpdateNote : 2011/02/10 liyp</br>
        /// <br>           : ��Q�� #18874</br>
		/// </remarks>
		private void EditCondition( ref StringCollection editArea, string target )
		{
			bool isEdit = false;

            // 2008.11.26 30413 ���� ���o������K�X���s����悤�ɏC�� >>>>>>START
            // �ҏW�Ώە����o�C�g���Z�o
            int targetByte = TStrConv.SizeCountSJIS( target );
			
            //for( int ix = 0; ix < editArea.Count; ix++ ) {
            //    int areaByte = 0;
				
            //    // �i�[�G���A�̃o�C�g���Z�o
            //    if( editArea[ ix ] != null ) {
            //        areaByte = TStrConv.SizeCountSJIS( editArea[ ix ] );
            //    }

            //    if( ( areaByte + targetByte + 2 ) <= 190 ) {
            //        isEdit = true;

            //        // �S�p�X�y�[�X��}��
            //        if( editArea[ ix ] != null ) {
            //            editArea[ ix ] += CT_SPACE;
            //        }
					
            //        editArea[ ix ] += target;
            //        break;
            //    }
            //}

            int index = 0;
            int areaByte = 0;

            // �ǉ�����G���A�̃C���f�b�N�X���擾
            if (editArea.Count != 0)
            {
                index = editArea.Count - 1;

                // �i�[�G���A�̃o�C�g���Z�o
                if (editArea[index] != null)
                {
                    areaByte = TStrConv.SizeCountSJIS(editArea[index]);
                }

                
                if ((this._extrInfo.SelectedPaperKind == 0) && ((areaByte + targetByte + 2) >= 120))
                {
                    // �I�������\
                    // ���s
                    editArea[index] += "\n";
                }
                // else if ((this._extrInfo.SelectedPaperKind != 0) && ((areaByte + targetByte + 2) >= 140)) //DEL 2011/02/10
                else if ((this._extrInfo.SelectedPaperKind != 0) && ((areaByte + targetByte +2) >= 200)) //ADD 2011/02/10
                {
                    // ���s
                    editArea[index] += "\n";
                }
                else
                {
                    isEdit = true;

                    // �S�p�X�y�[�X��}��
                    if (editArea[index] != null) editArea[index] += CT_SPACE;

                    editArea[index] += target;
                }
            }
            // 2008.11.26 30413 ���� ���o������K�X���s����悤�ɏC�� <<<<<<END

			// �V�K�ҏW�G���A�쐬
			if( !isEdit ) {
				editArea.Add( target );
			}
		}

		/// <summary>
		/// ���o����1�쐬
		/// </summary>
		/// <param name="extraCondition">���o����1</param>
		/// <remarks>
		/// <br>Note       : ���o����1�쐬(�o�͏����j�B</br>
		/// <br>Programmer : 23010 �����@�m</br>
		/// <br>Date       : 2007.04.09</br>
		/// </remarks>
		private void MakeCondition2( ref StringCollection extraCondition )
        {
            #region ���o�����Q�쐬����
            // 2008.10.31 30413 ���� �萔�ǉ� >>>>>>START
            const string ct_Extr_Top = "�ŏ�����";
            const string ct_Extr_End = "�Ō�܂�";
            // 2008.10.31 30413 ���� �萔�ǉ� <<<<<<END
            
            string wkStr = "";
            // 2007.09.14 �폜 >>>>>>>>>>>>>>>>>>>>
            //string target = "";
            // 2007.09.14 �폜 <<<<<<<<<<<<<<<<<<<<
            string start = "";
            string end   = "";

            // 2008.10.31 30413 ���� ���o�����̏C�� >>>>>>START
            // �q�ɃR�[�h
			if( ( this._extrInfo.St_WarehouseCode != "" ) || ( this._extrInfo.Ed_WarehouseCode != "" ) ) 
            {
                // �J�n
                if(this._extrInfo.St_WarehouseCode == "")
                {
                    //start = "�s�n�o";
                    start = ct_Extr_Top;
                }
                else
                {
                    start = this._extrInfo.St_WarehouseCode;
                }
                // �I��
                if(this._extrInfo.Ed_WarehouseCode == "")
                {
                    //end   = "�d�m�c";
                    end = ct_Extr_End;
                }
                else
                {
                    end = this._extrInfo.Ed_WarehouseCode;
                }
                //wkStr = String.Format( "�q�ɃR�[�h�F {0} �` {1}", 
                //start, end );
                //this.EditCondition( ref extraCondition, wkStr );
                wkStr = String.Format("�q�ɁF {0} �` {1}",
                start, end);
                this.EditCondition(ref extraCondition, wkStr);
			}

            // 2007.09.14 �ǉ� >>>>>>>>>>>>>>>>>>>>
            // �I��
            if ((this._extrInfo.St_WarehouseShelfNo != "") || (this._extrInfo.Ed_WarehouseShelfNo != ""))
            {
                // �J�n
                if (this._extrInfo.St_WarehouseShelfNo == "")
                {
                    //start = "�s�n�o";
                    start = ct_Extr_Top;
                }
                else
                {
                    start = this._extrInfo.St_WarehouseShelfNo;
                }
                //�I��
                if (this._extrInfo.Ed_WarehouseShelfNo == "")
                {
                    //end = "�d�m�c";
                    end = ct_Extr_End;
                }
                else
                {
                    end = this._extrInfo.Ed_WarehouseShelfNo;
                }
                wkStr = String.Format("�I�ԁF {0} �` {1}",
                start, end);
                this.EditCondition(ref extraCondition, wkStr);
            }
            // 2007.09.14 �ǉ� <<<<<<<<<<<<<<<<<<<<
            // 2008.10.31 30413 ���� ���o�����̏C�� <<<<<<END
            
            // 2007.09.14 �폜 >>>>>>>>>>>>>>>>>>>>
            //// �L�����A
            //if( ( this._extrInfo.St_CarrierCode != 0 ) || ( this._extrInfo.Ed_CarrierCode != 999 ) ) 
            //{
			//    wkStr = String.Format( "�L�����A�R�[�h�F {0} �` {1}", 
			//	this._extrInfo.St_CarrierCode.ToString(), this._extrInfo.Ed_CarrierCode.ToString() );
			//    this.EditCondition( ref extraCondition, wkStr );
		    //}           
            ////���Ǝ҃R�[�h
            //if( ( this._extrInfo.St_CarrierEpCode != 0 ) || ( this._extrInfo.Ed_CarrierEpCode != 9999 ) ) 
            //{
            //	wkStr = String.Format( "���Ǝ҃R�[�h�F {0} �` {1}", 
            //	this._extrInfo.St_CarrierEpCode.ToString(), this._extrInfo.Ed_CarrierEpCode.ToString() );
            //	this.EditCondition( ref extraCondition, wkStr );
            //}
            // 2007.09.14 �폜 <<<<<<<<<<<<<<<<<<<<

            // 2008.10.31 30413 ���� ���o�����̒ǉ� >>>>>>START
            // �d����
            if ((this._extrInfo.St_SupplierCd == 0) && (this._extrInfo.Ed_SupplierCd != 0))
            {
                wkStr = "�d����: " + ct_Extr_Top + " �` " + this._extrInfo.Ed_SupplierCd.ToString("d06");
                this.EditCondition(ref extraCondition, wkStr);
            }

            if ((this._extrInfo.St_SupplierCd > 0) && (this._extrInfo.Ed_SupplierCd == 0))
            {
                wkStr = "�d����: " + this._extrInfo.St_SupplierCd.ToString("d06") + " �` " + ct_Extr_End;
                this.EditCondition(ref extraCondition, wkStr);
            }

            if ((this._extrInfo.St_SupplierCd > 0) && (this._extrInfo.Ed_SupplierCd != 0))
            {
                wkStr = "�d����: " + this._extrInfo.St_SupplierCd.ToString("d06") + " �` " + this._extrInfo.Ed_SupplierCd.ToString("d06");
                this.EditCondition(ref extraCondition, wkStr);
            }

            // BL�R�[�h
            if ((this._extrInfo.St_BLGoodsCode == 0) && (this._extrInfo.Ed_BLGoodsCode != 0))
            {
                wkStr = "BL����: " + ct_Extr_Top + " �` " + this._extrInfo.Ed_BLGoodsCode.ToString("d05");
                this.EditCondition(ref extraCondition, wkStr);
            }

            if ((this._extrInfo.St_BLGoodsCode > 0) && (this._extrInfo.Ed_BLGoodsCode == 0))
            {
                wkStr = "BL����: " + this._extrInfo.St_BLGoodsCode.ToString("d05") + " �` " + ct_Extr_End;
                this.EditCondition(ref extraCondition, wkStr);
            }

            if ((this._extrInfo.St_BLGoodsCode > 0) && (this._extrInfo.Ed_BLGoodsCode != 0))
            {
                wkStr = "BL����: " + this._extrInfo.St_BLGoodsCode.ToString("d05") + " �` " + this._extrInfo.Ed_BLGoodsCode.ToString("d05");
                this.EditCondition(ref extraCondition, wkStr);
            }

            // �O���[�v�R�[�h
            if ((this._extrInfo.St_BLGroupCode == 0) && (this._extrInfo.Ed_BLGroupCode != 0))
            {
                wkStr = "��ٰ��: " + ct_Extr_Top + " �` " + this._extrInfo.Ed_BLGroupCode.ToString("d05");
                this.EditCondition(ref extraCondition, wkStr);
            }

            if ((this._extrInfo.St_BLGroupCode > 0) && (this._extrInfo.Ed_BLGroupCode == 0))
            {
                wkStr = "��ٰ��: " + this._extrInfo.St_BLGroupCode.ToString("d05") + " �` " + ct_Extr_End;
                this.EditCondition(ref extraCondition, wkStr);
            }

            if ((this._extrInfo.St_BLGroupCode > 0) && (this._extrInfo.Ed_BLGroupCode != 0))
            {
                wkStr = "��ٰ��: " + this._extrInfo.St_BLGroupCode.ToString("d05") + " �` " + this._extrInfo.Ed_BLGroupCode.ToString("d05");
                this.EditCondition(ref extraCondition, wkStr);
            }

            // ���[�J�[�R�[�h
            if ((this._extrInfo.St_MakerCode == 0) && (this._extrInfo.Ed_MakerCode != 0))
            {
                wkStr = "Ұ��: " + ct_Extr_Top + " �` " + this._extrInfo.Ed_MakerCode.ToString("d04");
                this.EditCondition(ref extraCondition, wkStr);
            }

            if ((this._extrInfo.St_MakerCode > 0) && (this._extrInfo.Ed_MakerCode == 0))
            {
                wkStr = "Ұ��: " + this._extrInfo.St_MakerCode.ToString("d04") + " �` " + ct_Extr_End;
                this.EditCondition(ref extraCondition, wkStr);
            }

            if ((this._extrInfo.St_MakerCode > 0) && (this._extrInfo.Ed_MakerCode != 0))
            {
                wkStr = "Ұ��: " + this._extrInfo.St_MakerCode.ToString("d04") + " �` " + this._extrInfo.Ed_MakerCode.ToString("d04");
                this.EditCondition(ref extraCondition, wkStr);
            }
            // 2008.10.31 30413 ���� ���o�����̒ǉ� <<<<<<END
            
            // 2008.10.31 30413 ���� ���o�����̍폜 >>>>>>START
            ////���[�J�[�R�[�h
            //// 2008.02.13 �C�� >>>>>>>>>>>>>>>>>>>>
            ////if ((this._extrInfo.St_MakerCode != 0) || (this._extrInfo.Ed_MakerCode != 999))
            //if ((this._extrInfo.St_MakerCode != 0) || (this._extrInfo.Ed_MakerCode != 999999))
            //// 2008.02.13 �C�� <<<<<<<<<<<<<<<<<<<<
            //{
            //    wkStr = String.Format( "���[�J�[�R�[�h�F {0} �` {1}", 
            //    this._extrInfo.St_MakerCode.ToString(), this._extrInfo.Ed_MakerCode.ToString() );
            //    this.EditCondition( ref extraCondition, wkStr );
            //}

            ////�d����R�[�h
            //if( ( this._extrInfo.St_CustomerCode != 0 ) || ( this._extrInfo.Ed_CustomerCode != 999999999 ) ) 
            //{
            //    wkStr = String.Format( "�d����R�[�h�F {0} �` {1}", 
            //    this._extrInfo.St_CustomerCode.ToString(), this._extrInfo.Ed_CustomerCode.ToString() );
            //    this.EditCondition( ref extraCondition, wkStr );
            //}

            ////�ϑ���R�[�h
            //if( ( this._extrInfo.St_ShipCustomerCode != 0 ) || ( this._extrInfo.Ed_ShipCustomerCode != 999999999 ) ) 
            //{
            //    wkStr = String.Format( "�ϑ���R�[�h�F {0} �` {1}", 
            //    this._extrInfo.St_ShipCustomerCode.ToString(), this._extrInfo.Ed_ShipCustomerCode.ToString() );
            //    this.EditCondition( ref extraCondition, wkStr );
            //}
            ////���i�敪�O���[�v�R�[�h
            //if( ( this._extrInfo.St_LargeGoodsGanreCode != "" ) || ( this._extrInfo.Ed_LargeGoodsGanreCode != "" ) ) 
            //{
            //    start = "";
            //    end   = "";
            //    if(this._extrInfo.St_LargeGoodsGanreCode == "")
            //    {
            //        start = "�s�n�o";
            //    }
            //    else
            //    {
            //        start = this._extrInfo.St_LargeGoodsGanreCode;
            //    }
            //    if(this._extrInfo.Ed_LargeGoodsGanreCode == "")
            //    {
            //        end   = "�d�m�c";
            //    }
            //    else
            //    {
            //        end = this._extrInfo.Ed_LargeGoodsGanreCode;
            //    }

            //    wkStr = String.Format( "���i�敪�O���[�v�F {0} �` {1}", 
            //    start, end );
            //    this.EditCondition( ref extraCondition, wkStr );
            //}

            ////���i�敪�R�[�h
            //if( ( this._extrInfo.St_MediumGoodsGanreCode != "" ) || ( this._extrInfo.Ed_MediumGoodsGanreCode != "" ) ) 
            //{
            //    start = "";
            //    end   = "";
            //    if(this._extrInfo.St_MediumGoodsGanreCode == "")
            //    {
            //        start = "�s�n�o";
            //    }
            //    else
            //    {
            //        start = this._extrInfo.St_MediumGoodsGanreCode;
            //    }
            //    if(this._extrInfo.Ed_MediumGoodsGanreCode == "")
            //    {
            //        end   = "�d�m�c";
            //    }
            //    else
            //    {
            //        end = this._extrInfo.Ed_MediumGoodsGanreCode;
            //    }

            //    wkStr = String.Format( "���i�敪�F {0} �` {1}", 
            //    start, end );
            //    this.EditCondition( ref extraCondition, wkStr );
            //}
            // 2008.10.31 30413 ���� ���o�����̍폜 <<<<<<END
            
            // 2007.09.14 �C�� >>>>>>>>>>>>>>>>>>>>
            ////�@��R�[�h
            //if( ( this._extrInfo.St_CellphoneModelCode != "" ) || ( this._extrInfo.Ed_CellphoneModelCode != "" ) ) 
            //{
            //    start = "";
            //    end   = "";
            //    if(this._extrInfo.St_CellphoneModelCode == "")
            //    {
            //        start = "�s�n�o";
            //    }
            //    else
            //    {
            //        start = this._extrInfo.St_CellphoneModelCode;
            //    }
            //    if(this._extrInfo.Ed_CellphoneModelCode == "")
            //    {
            //        end   = "�d�m�c";
            //    }
            //    else
            //    {
            //        end = this._extrInfo.Ed_CellphoneModelCode;
            //    }
            //
            //    wkStr = String.Format( "�@��R�[�h�F {0} �` {1}", 
            //	start, end );
            //    this.EditCondition( ref extraCondition, wkStr );
            //}

            // 2008.10.31 30413 ���� ���o�����̍폜 >>>>>>START
            ////���i�敪�ڍ׃R�[�h
            //if ((this._extrInfo.St_DetailGoodsGanreCode != "") || (this._extrInfo.Ed_DetailGoodsGanreCode != ""))
            //{
            //    start = "";
            //    end = "";
            //    if (this._extrInfo.St_DetailGoodsGanreCode == "")
            //    {
            //        start = "�s�n�o";
            //    }
            //    else
            //    {
            //        start = this._extrInfo.St_DetailGoodsGanreCode;
            //    }
            //    if (this._extrInfo.Ed_DetailGoodsGanreCode == "")
            //    {
            //        end = "�d�m�c";
            //    }
            //    else
            //    {
            //        end = this._extrInfo.Ed_DetailGoodsGanreCode;
            //    }

            //    wkStr = String.Format("���i�敪�ڍׁF {0} �` {1}",
            //    start, end);
            //    this.EditCondition(ref extraCondition, wkStr);
            //}

            ////���Е��ރR�[�h
            //// 2008.02.13 �C�� >>>>>>>>>>>>>>>>>>>>
            ////if ((this._extrInfo.St_EnterpriseGanreCode != 0) || (this._extrInfo.Ed_EnterpriseGanreCode != 99))
            //if ((this._extrInfo.St_EnterpriseGanreCode != 0) || (this._extrInfo.Ed_EnterpriseGanreCode != 9999))
            //// 2008.02.13 �C�� <<<<<<<<<<<<<<<<<<<<
            //{
            //    wkStr = String.Format("���Е��ރR�[�h�F {0} �` {1}",
            //    this._extrInfo.St_EnterpriseGanreCode.ToString(), this._extrInfo.Ed_EnterpriseGanreCode.ToString());
            //    this.EditCondition(ref extraCondition, wkStr);
            //}

            ////�a�k�R�[�h
            //// 2008.02.13 �C�� >>>>>>>>>>>>>>>>>>>>
            ////if ((this._extrInfo.St_BLGoodsCode != 0) || (this._extrInfo.Ed_BLGoodsCode != 99))
            //if ((this._extrInfo.St_BLGoodsCode != 0) || (this._extrInfo.Ed_BLGoodsCode != 99999999))
            //// 2008.02.13 �C�� <<<<<<<<<<<<<<<<<<<<
            //{
            //    wkStr = String.Format("�a�k�R�[�h�F {0} �` {1}",
            //    this._extrInfo.St_BLGoodsCode.ToString(), this._extrInfo.Ed_BLGoodsCode.ToString());
            //    this.EditCondition(ref extraCondition, wkStr);
            //}
            //// 2007.09.14 �C�� <<<<<<<<<<<<<<<<<<<<
            
            ////���i�R�[�h
            //if( ( this._extrInfo.St_GoodsNo != "" ) || ( this._extrInfo.Ed_GoodsNo != "" ) ) 
            //{
            //    start = "";
            //    end   = "";
            //    if (this._extrInfo.St_GoodsNo == "")
            //    {
            //        start = "�s�n�o";
            //    }
            //    else
            //    {
            //        start = this._extrInfo.St_GoodsNo;
            //    }
            //    if (this._extrInfo.Ed_GoodsNo == "")
            //    {
            //        end   = "�d�m�c";
            //    }
            //    else
            //    {
            //        end = this._extrInfo.Ed_GoodsNo;
            //    }

            //    wkStr = String.Format( "���i�R�[�h�F {0} �` {1}", 
            //    start, end );
            //    this.EditCondition( ref extraCondition, wkStr );
            //}
            // 2008.10.31 30413 ���� ���o�����̍폜 <<<<<<END
            
            // 2007.09.14 �폜 >>>>>>>>>>>>>>>>>>>>
            //target = "�݌ɋ敪: ";
            //wkStr = "";
            //
            //// �݌ɋ敪(����)      
			//if( this._extrInfo.CompanyStockExtraDiv == 0 ) 
            //{
            //    //���o����
			//	wkStr += "����";
			//}
            //// �݌ɋ敪(���)      
			//if( this._extrInfo.TrustStockExtraDiv == 0 ) 
            //{
            //    //���o����
            //    if(wkStr != "")
            //    {
            //        wkStr += ",���";
            //    }				
            //    else
            //    {
            //        wkStr += "���";
            //    }
			//}
            //// �݌ɋ敪(�ϑ�(����))      
			//if( this._extrInfo.EntrustCmpStockExtraDiv == 0 ) 
            //{
            //    //���o����
            //    if(wkStr != "")
            //    {
            //        wkStr += ",�ϑ�(����)";
            //    }
            //    else
            //    {
            //        wkStr += "�ϑ�(����)";
            //    }				
            //}
            //// �݌ɋ敪(�ϑ�(���))      
            //if( this._extrInfo.EntrustTrtStockExtraDiv == 0 ) 
            //{
            //    //���o����
            //    if(wkStr != "")
            //    {
            //        wkStr += ",�ϑ�(���)";
            //    }
            //    else
            //    {
            //        wkStr += "�ϑ�(���)";
            //    }				
            //}
            //
            //target += wkStr;
            //
            //this.EditCondition( ref extraCondition, target );
            // 2007.09.14 �폜 <<<<<<<<<<<<<<<<<<<<

            #endregion
        }
	    

		/// <summary>
		/// �\�[�g��������쐬����
		/// </summary>
		/// <returns>�\�[�g��������</returns>
		/// <remarks>
		/// <br>Note       : �\�[�g����������쐬���܂��B</br>
		/// <br>Programmer : 23010 �����@�m</br>
		/// <br>Date       : 2007.04.09</br>
		/// </remarks>
		private string MakeSortCondition()
		{
			return String.Format( "[{0}]",InventSearchCndtnUI.GetTargetSortTitle(this._extrInfo.SortDiv) + " ��");
		}

        #region ���@������N�G���쐬�֐�
        /// <summary>
        /// �󎚏��N�G���쐬����
        /// </summary>
        /// <returns>�쐬�����N�G��</returns>
        /// <remarks>
        /// <br>Note       : DataView�ɐݒ肷��󎚏��ʂ̃N�G�����쐬���܂��B</br>
        /// <br>Programmer : 980035 ����@��`</br>
        /// <br>Date       : 2008.02.13</br>
        /// </remarks>
        private string GetPrintOderQuerry()
        {
            string orderQuerry = CT_SectionCode_Odr + "," + CT_WarehouseCode_Odr + ",";

            // 2008.10.31 30413 ���� E�N���X�Ń\�[�g�ς̂��ߏȗ� >>>>>>START
            //switch (this._extrInfo.SortDiv)
            //{
            //    // �q�Ɂ��I�ԁ����[�J�[�����i�敪�����i ��
            //    case (int)InventSearchCndtnUI.SortOrder.Warehouce_ShelfNo_GoodsDiv:
            //        {
            //            orderQuerry = orderQuerry + CT_WarehouseShelfNo_Odr + "," + CT_MakerCode_Odr + "," + CT_GoodsDivL_Odr + "," + CT_GoodsDivM_Odr + "," + CT_GoodsDivD_Odr + "," + CT_GoodsCode_Odr;
            //            break;
            //        }
            //    // �q�Ɂ��I�ԁ����[�J�[�����i ��
            //    case (int)InventSearchCndtnUI.SortOrder.Warehouce_ShelfNo:
            //        {
            //            orderQuerry = orderQuerry + CT_WarehouseShelfNo_Odr + "," + CT_MakerCode_Odr + "," + CT_GoodsCode_Odr;
            //            break;
            //        }
            //    // �q�Ɂ��d���� ��
            //    case (int)InventSearchCndtnUI.SortOrder.Warehouce_Customer:
            //        {
            //            orderQuerry = orderQuerry + CT_CustomerCode_Odr;
            //            break;
            //        }
            //    // �q�Ɂ��a�k�R�[�h ��
            //    case (int)InventSearchCndtnUI.SortOrder.Warehouce_BLCode:
            //        {
            //            orderQuerry = orderQuerry + CT_BLGoodsCode_Odr;
            //            break;
            //        }
            //    // �q�Ɂ����[�J�[ ��
            //    case (int)InventSearchCndtnUI.SortOrder.Warehouce_Maker:
            //        {
            //            orderQuerry = orderQuerry + CT_MakerCode_Odr;
            //            break;
            //        }
            //    // �q�Ɂ��d���恨�I�� ��
            //    case (int)InventSearchCndtnUI.SortOrder.Warehouce_Customer_ShelfNo:
            //        {
            //            orderQuerry = orderQuerry + CT_CustomerCode_Odr + "," + CT_WarehouseShelfNo_Odr;
            //            break;
            //        }
            //    // �q�Ɂ��d���恨���[�J�[ ��
            //    case (int)InventSearchCndtnUI.SortOrder.Warehouce_Customer_Maker:
            //        {
            //            orderQuerry = orderQuerry + CT_CustomerCode_Odr + "," + CT_MakerCode_Odr;
            //            break;
            //        }
            //}
            // 2008.10.31 30413 ���� E�N���X�Ń\�[�g�ς̂��ߏȗ� <<<<<<END
            
            return orderQuerry;
        }
        #endregion

        /// <summary>
		/// �G���[���b�Z�[�W�\������
		/// </summary>
		/// <param name="iLevel">�G���[���x��</param>
		/// <param name="message">�\�����b�Z�[�W</param>
		/// <param name="status">�X�e�[�^�X</param>
		/// <param name="procNm">�������\�b�hID</param>
		/// <remarks>
		/// <br>Note       : �G���[���b�Z�[�W�̕\�����s���܂��B</br>
		/// <br>Programmer : 23010 �����@�m</br>
		/// <br>Date       : 2007.04.09</br>
		/// </remarks>
		private void MsgDispProc( emErrorLevel iLevel, string message, int status, string procNm )
		{
			TMsgDisp.Show( 
				iLevel, 							// �G���[���x��
				CT_CLASSID,							// �A�Z���u���h�c�܂��̓N���X�h�c
				CT_PGNM,							// �v���O��������
				procNm, 							// ��������
				"",									// �I�y���[�V����
				message,							// �\�����郁�b�Z�[�W
				status, 							// �X�e�[�^�X�l
				null, 								// �G���[�����������I�u�W�F�N�g
				MessageBoxButtons.OK, 				// �\������{�^��
				MessageBoxDefaultButton.Button1 );	// �����\���{�^��
		}

		/// <summary>
		/// �G���[���b�Z�[�W�\������
		/// </summary>
		/// <param name="message">�\�����b�Z�[�W</param>
		/// <param name="status">�X�e�[�^�X</param>
		/// <param name="procnm">�������\�b�hID</param>
		/// <param name="ex">��O���</param>
		/// <remarks>
		/// <br>Note       : �G���[���b�Z�[�W�̕\�����s���܂��B</br>
		/// <br>Programmer : 23010 �����@�m</br>
		/// <br>Date       : 2007.04.09</br>
		/// </remarks>
		private void MsgDispProc( string message, int status, string procnm, Exception ex )
		{
			string errMessage = message + "\r\n" + ex.Message;

			TMsgDisp.Show( 
				emErrorLevel.ERR_LEVEL_STOP, 		// �G���[���x��
				CT_CLASSID,							// �A�Z���u���h�c�܂��̓N���X�h�c
				CT_PGNM,							// �v���O��������
				procnm, 							// ��������
				"",									// �I�y���[�V����
				errMessage,							// �\�����郁�b�Z�[�W
				status, 							// �X�e�[�^�X�l
				null, 								// �G���[�����������I�u�W�F�N�g
				MessageBoxButtons.OK, 				// �\������{�^��
				MessageBoxDefaultButton.Button1 );	// �����\���{�^��
		}

		#endregion
	}
}
