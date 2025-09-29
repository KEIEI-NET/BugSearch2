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
	/// �݌Ɉꗗ�\����N���X
	/// </summary>
	/// <remarks>
	/// <br>Note       : �݌Ɉꗗ�\��������܂��B</br>
	/// <br>Programmer : 23010 �����@�m</br>
	/// <br>Date       : 2007.03.22</br>
    /// <br>Update Note: 2007.10.05 980035 ���� ��`</br>
    /// <br>			 �EDC.NS�Ή�</br>
    /// <br>Update Note: 2008.01.24 980035 ���� ��`</br>
    /// <br>			 �EDC.NS�Ή��i�s��Ή��j</br>
    /// <br>Update Note: 2008/10/08        �Ɠc �M�u</br>
    /// <br>			 �E�o�O�C���A�d�l�ύX�Ή�</br>
    /// <br>Update Note: 2009/03/17        ��� �r��</br>
    /// <br>			 �E��Q�Ή�12703</br>
    /// </remarks>
	class MAZAI02072PA
	{
		// --------------------------------------------------
		#region Constructor

		/// <summary>
		/// �݌Ɉꗗ�\����N���X�R���X�g���N�^
		/// </summary>
		/// <param name="printInfo">������I�u�W�F�N�g</param>
		/// <remarks>
		/// <br>Note       : �݌Ɉꗗ�\����N���X�̐V�����C���X�^���X�����������܂��B</br>
		/// <br>Programmer : 23010 �����@�m</br>
		/// <br>Date       : 2007.03.22</br>
		/// </remarks>
		public MAZAI02072PA( object printInfo )
		{
			// ������I�u�W�F�N�g�擾
			this._printInfo    = printInfo as SFCMN06002C;
			// �A�N�Z�X�N���X�C���X�^���X����
			this._stockListAcs = new StockListAcs();
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
		/// <br>Date       : 2007.03.22</br>
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
			/// <br>Date       : 2007.03.16</br>
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
			/// <br>Date       : 2007.03.16</br>
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
		private StockListCndtn _extrInfo   = null;

		// �݌Ɉꗗ�\�A�N�Z�X�N���X
		private StockListAcs _stockListAcs    = null;

		#endregion

		// --------------------------------------------------
		#region Constant

		// �N���XID
		private const string	CT_CLASSID              = "MAZAI02072PA";
		// �v���O����ID
		private const string	CT_PGID                 = "MAZAI02072P";
		// �v���O��������
		private const string	CT_PGNM                 = "�݌Ɉꗗ�\";

		// ���o���������Ԋu�p�萔
		private const string	CT_SPACE                = "    ";
		// ReportFormNamspace
		private const string	CT_REPORTFORM_NAMESPACE = "Broadleaf.Drawing.Printing";
        //a

		#endregion

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
		/// <br>Date       : 2007.03.22</br>
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
		/// <br>Date       : 2007.03.22</br>
		/// </remarks>
		private int PrintMain()
		{
			const string ctPROCNM = "PrintMain";
			int status = ( int )ConstantManagement.MethodResult.ctFNC_ERROR;

			this._extrInfo = this._printInfo.jyoken as StockListCndtn;

			// ����p�t�H�[���N���X
			DataDynamics.ActiveReports.ActiveReport3 prtRpt = null;

			try 
            {
				// ����p�f�[�^�r���[�C���X�^���X����
				DataView dv = this._printInfo.rdData as DataView;

				// ���|�[�g�C���X�^���X����
				this.CreateReport( out prtRpt, this._printInfo.prpid );
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
                //status = this.SetPrintCommonInfo( out commonInfo ); // DEL 2009/03/17
                status = this.SetPrintCommonInfo(ref prtRpt, out commonInfo); // ADD 2009/03/17

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
		/// <br>Date       : 2007.03.16</br>
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
		/// <br>Date       : 2007.03.16</br>
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
		/// <br>Date       : 2007.03.22</br>
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
				
				// �݌ɑS�̐ݒ���擾
				StockMngTtlSt stockMngTtlSt = null;
				string mess;
				status = this._stockListAcs.ReadStockMngTtlSt( out stockMngTtlSt, out mess );
				if( status != 0 ) {
					throw new ReportPrintException( mess, status, ctPROCNM );
				}
                //�����N���X�ɃZ�b�g���Ă���
                this._extrInfo.StockPointWay = stockMngTtlSt.StockPointWay;  
                
                // ���[�o�͐ݒ���擾
				PrtOutSet prtOutSet = null;
				string message;
				status = this._stockListAcs.ReadPrtOutSet( out prtOutSet, out message );
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

				// �w�b�_�[�T�u�^�C�g��
                instance.PageHeaderSubtitle             = "";
                
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
		/// <br>Date       : 2007.03.16</br>
		/// </remarks>
        //private int SetPrintCommonInfo( out Broadleaf.Windows.Forms.SFCMN00293UC commonInfo ) // DEL 2009/03/17
        private int SetPrintCommonInfo(ref DataDynamics.ActiveReports.ActiveReport3 rptObj, out Broadleaf.Windows.Forms.SFCMN00293UC commonInfo) // ADD 2009/03/17
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

            // --- ADD 2009/03/17 -------------------------------->>>>>
            rptObj.Document.CacheToDisk = true;
            rptObj.Document.CacheToDiskLocation = pdfPath;
            // --- ADD 2009/03/17 --------------------------------<<<<< 

			return status;
		}

		/// <summary>
		///	���o�����쐬�֐�
		/// </summary>
		/// <remarks>
		/// <br>Note       : �Ώۊ��ԁA���o�����P�C�Q��string�^�̔z��Ɋi�[����B</br>
		/// <br>Programmer : 23010 �����@�m</br>
		/// <br>Date       : 2007.03.16</br>
		/// </remarks>
		private void MakeExtractConditionMain( out StringCollection allExtractCondition )
		{
			allExtractCondition = new StringCollection();

            string start = "";      //ADD 2008/10/08
            string end = "";        //ADD 2008/10/08
            string wkStr = "";

            //--- ADD 2008/08/01 ---------->>>>>
            // --- ADD 2008/10/08 ----------------------------------------------------------------------------------------->>>>>
            //�ŏI�d����
            //�J�n��or�I���������͂���Ă���
            if ((this._extrInfo.St_LastStockDate != DateTime.MinValue) || (this._extrInfo.Ed_LastStockDate != DateTime.MinValue))
            {
                //�J�n�d�����������Ă��Ȃ��ꍇ
                if (this._extrInfo.St_LastStockDate == DateTime.MinValue)
                {
                    start = "�ŏ�����";
                }
                else
                {
                    start = TDateTime.DateTimeToString("YYYY/MM", this._extrInfo.St_LastStockDate);
                }

                if (this._extrInfo.Ed_LastStockDate == DateTime.MinValue)
                {
                    end = "�Ō�܂�";
                }
                else
                {
                    end = TDateTime.DateTimeToString("YYYY/MM", this._extrInfo.Ed_LastStockDate);
                }
                wkStr = String.Format("�Ώ۔N��" + "�F {0} �` {1}", start, end);
                this.EditCondition(ref allExtractCondition, wkStr);
            }
            // --- ADD 2008/10/08 -----------------------------------------------------------------------------------------<<<<<
            // �݌ɓo�^��
            if (this._extrInfo.StockCreateDate != DateTime.MinValue)
            {
                wkStr = String.Format("�݌ɓo�^���F {0} {1}",
                //this._extrInfo.StockCreateDate.ToString("yyyy�NMM��dd��"),        //DEL 2008/10/08 �����ύX
                this._extrInfo.StockCreateDate.ToString("yyyy/MM/dd"),              //ADD 2008/10/08
                this._extrInfo.StockCreateDateDivStateTitle);
                this.EditCondition(ref allExtractCondition, wkStr);
            }
            // �o�׎w��
            if ((this._extrInfo.St_ShipmentPosCnt != 0) || (this._extrInfo.Ed_ShipmentPosCnt != 99999999))
            {
                //wkStr = String.Format("�o�׎w��F {0} �` {1}",            //DEL 2008/10/08 �����ύX
                wkStr = String.Format("�o�א��w��F {0}�� �` {1}��",        //ADD 2008/10/08
                this._extrInfo.St_ShipmentPosCnt.ToString(), this._extrInfo.Ed_ShipmentPosCnt.ToString());
                this.EditCondition(ref allExtractCondition, wkStr);
            }
            // --- ADD 2008/10/08 ----------------------------------------------------------------------------------------->>>>>
            // �Ǘ��敪1
            if ((this._extrInfo.PartsManagementDivide1 != null) &&
                (this._extrInfo.PartsManagementDivide1.Length > 0))
            {
                StringBuilder partsMngDiv1 = new StringBuilder("�Ǘ��敪1�F");
                Array.Sort<string>(this._extrInfo.PartsManagementDivide1);
                foreach (string partsMngDiv1Item in this._extrInfo.PartsManagementDivide1)
                {
                    partsMngDiv1.Append(partsMngDiv1Item);
                }

                EditCondition(ref allExtractCondition, partsMngDiv1.ToString());
            }
            // �Ǘ��敪2
            if ((this._extrInfo.PartsManagementDivide2 != null) &&
                (this._extrInfo.PartsManagementDivide2.Length > 0))
            {
                StringBuilder partsMngDiv2 = new StringBuilder("�Ǘ��敪2�F");
                Array.Sort<string>(this._extrInfo.PartsManagementDivide2);
                foreach (string partsMngDiv2Item in this._extrInfo.PartsManagementDivide2)
                {
                    partsMngDiv2.Append(partsMngDiv2Item);
                }

                EditCondition(ref allExtractCondition, partsMngDiv2.ToString());
            }
            // --- ADD 2008/10/08 -----------------------------------------------------------------------------------------<<<<<
            // �I�ԃu���C�N�w��
            if (this._extrInfo.ChangePageDiv == 1)
            {
                wkStr = String.Format("�I�ԃu���C�N�w��F {0}",
                this._extrInfo.WarehouseShelfNoBreakDivStateTitle);
                this.EditCondition(ref allExtractCondition, wkStr);
            }
            //--- ADD 2008/08/01 ----------<<<<<

            //���i�R�[�h
            // 2007.10.05 �C�� >>>>>>>>>>>>>>>>>>>>
            //if ((this._extrInfo.St_GoodsCode != "") || (this._extrInfo.Ed_GoodsCode != "")) 
            //{
            //    string start = "";
            //    string end   = "";
            //    if(this._extrInfo.St_GoodsCode == "")
            //    {
            //        start = "�s�n�o";
            //    }
            //    else
            //    {
            //        start = this._extrInfo.St_GoodsCode;
            //    }
            //    if(this._extrInfo.Ed_GoodsCode == "")
            //    {
            //        end   = "�d�m�c";
            //    }
            //    else
            //    {
            //        end = this._extrInfo.Ed_GoodsCode;
            //    }
            //
			//    wkStr = String.Format( "���i�R�[�h�F {0} �` {1}", 
			//	start, end );
			//    this.EditCondition( ref allExtractCondition, wkStr );
		    //}
            // 2007.10.05 �C�� <<<<<<<<<<<<<<<<<<<<

            // 2007.10.05 �C�� >>>>>>>>>>>>>>>>>>>>
            ////�L�����A�R�[�h
            //if( ( this._extrInfo.St_CarrierCode != 0 ) || ( this._extrInfo.Ed_CarrierCode != 999 ) ) 
            //{
			//    wkStr = String.Format( "�L�����A�R�[�h�F {0} �` {1}", 
			//	this._extrInfo.St_CarrierCode.ToString(), this._extrInfo.Ed_CarrierCode.ToString() );
			//    this.EditCondition( ref allExtractCondition, wkStr );
		    //}


            // 2007.10.05 �C�� <<<<<<<<<<<<<<<<<<<<
	
			StringCollection wkStrCollection = new StringCollection();
			// ���o����1
			this.MakeCondition1( ref wkStrCollection );
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
		/// <br>Date       : 2007.03.16</br>
		/// </remarks>
		private void EditCondition( ref StringCollection editArea, string target )
		{
			bool isEdit = false;
			
			// �ҏW�Ώە����o�C�g���Z�o
			int targetByte = TStrConv.SizeCountSJIS( target );
			
			for( int ix = 0; ix < editArea.Count; ix++ ) {
				int areaByte = 0;
				
				// �i�[�G���A�̃o�C�g���Z�o
				if( editArea[ ix ] != null ) {
					areaByte = TStrConv.SizeCountSJIS( editArea[ ix ] );
				}

				if( ( areaByte + targetByte + 2 ) <= 190 ) {
					isEdit = true;

					// �S�p�X�y�[�X��}��
					if( editArea[ ix ] != null ) {
						editArea[ ix ] += CT_SPACE;
					}
					
					editArea[ ix ] += target;
					break;
				}
			}
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
		/// <br>Date       : 2007.03.22</br>
		/// </remarks>
		private void MakeCondition1( ref StringCollection extraCondition )
		{
            string start = "";
            string end   = "";
			string wkStr = "";

            #region ����������쐬����

            /* --- DEL 2008/10/08 �݌ɓo�^���ƑΏ۔N���̈ʒu�ύX�̈� ------------------------------------------------------>>>>>
            //�ŏI�d����
            //�J�n��or�I���������͂���Ă���
            if((this._extrInfo.St_LastStockDate != DateTime.MinValue) || (this._extrInfo.Ed_LastStockDate != DateTime.MinValue))
            {
                 //�J�n�d�����������Ă��Ȃ��ꍇ
                if(this._extrInfo.St_LastStockDate == DateTime.MinValue)
                {
                    //start = "�s�n�o";     // DEL 2008.08.04
                    start = "�ŏ�����";     // ADD 2008.08.04
                }
                else
                {                 
                    start = TDateTime.DateTimeToString("YYYY/MM/DD",this._extrInfo.St_LastStockDate);
                }

                if(this._extrInfo.Ed_LastStockDate == DateTime.MinValue)
                {
                    //end = "�d�m�c";       // DEL 2008.08.04
                    end = "�Ō�܂�";       // ADD 2008.08.04
                }
                else
                {
                    end = TDateTime.DateTimeToString("YYYY/MM/DD",this._extrInfo.Ed_LastStockDate);        
                }
                //wkStr = String.Format("�ŏI�d����" + "�F {0} �` {1}", start, end);    // DEL 2008.08.01
                wkStr = String.Format("�Ώ۔N��" + "�F {0} �` {1}", start, end);      // ADD 2008.08.01
                this.EditCondition(ref extraCondition, wkStr);
            }
               --- DEL 2008/10/08 -----------------------------------------------------------------------------------------<<<<< */
            // �q�ɃR�[�h
            if ((this._extrInfo.St_WarehouseCode != "") || (this._extrInfo.Ed_WarehouseCode != ""))
            {
                if (this._extrInfo.St_WarehouseCode == "")
                {
                    //start = "�s�n�o";     // DEL 2008.08.04
                    start = "�ŏ�����";     // ADD 2008.08.04
                }
                else
                {
                    start = this._extrInfo.St_WarehouseCode;
                }
                if (this._extrInfo.Ed_WarehouseCode == "")
                {
                    //end = "�d�m�c";       // DEL 2008.08.04
                    end = "�Ō�܂�";       // ADD 2008.08.04
                }
                else
                {
                    end = this._extrInfo.Ed_WarehouseCode;
                }

                //wkStr = String.Format("�q�ɃR�[�h�F {0} �` {1}",      // DEL 2008.08.01
                wkStr = String.Format("�q�ɁF {0} �` {1}",              // ADD 2008.08.01
                start, end);
                this.EditCondition(ref extraCondition, wkStr);
            }

            //--- DEL 2008.08.01 ---------->>>>>
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
            //        end = "�d�m�c";
            //    }
            //    else
            //    {
            //        end = this._extrInfo.Ed_LargeGoodsGanreCode;
            //    }

            //    wkStr = String.Format( "���i�敪�O���[�v�F {0} �` {1}", 
            //    start, end );
            //    this.EditCondition( ref extraCondition, wkStr );
            //}
            //--- DEL 2008.08.01 ----------<<<<<

            //--- DEL 2008.08.01 ---------->>>>>
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
            //        end = "�d�m�c";
            //    }
            //    else
            //    {
            //        end = this._extrInfo.Ed_MediumGoodsGanreCode;
            //    }

            //    wkStr = String.Format( "���i�敪�F {0} �` {1}", 
            //    start, end );
            //    this.EditCondition( ref extraCondition, wkStr );
            //}
            //--- DEL 2008.08.01 ----------<<<<<

            //--- DEL 2008.08.01 ---------->>>>>
            //// 2008.01.24 �C�� >>>>>>>>>>>>>>>>>>>>
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
            //--- DEL 2008.08.01 ----------<<<<<

            //--- DEL 2008.08.01 ---------->>>>>
            ////���Е��ރR�[�h
            //if ((this._extrInfo.St_EnterpriseGanreCode != 0) || (this._extrInfo.Ed_EnterpriseGanreCode != 9999))
            //{
            //    wkStr = String.Format("���Е��ރR�[�h�F {0} �` {1}",
            //    this._extrInfo.St_EnterpriseGanreCode.ToString(), this._extrInfo.Ed_EnterpriseGanreCode.ToString());
            //    this.EditCondition(ref extraCondition, wkStr);
            //}
            //--- DEL 2008.08.01 ----------<<<<<

            // 2008.01.24 �C�� <<<<<<<<<<<<<<<<<<<<
            /* --- DEL 2008/10/08 �啝�ύX�̈� ---------------------------------------------------------------------------->>>>>
            //--- ADD 2008/08/01 ---------->>>>>
            // �d����
            if ((this._extrInfo.St_StockSupplierCode != 0) || (this._extrInfo.Ed_StockSupplierCode != 99999999))
            {
                wkStr = String.Format("�d����F {0} �` {1}",
                this._extrInfo.St_StockSupplierCode.ToString(), this._extrInfo.Ed_StockSupplierCode.ToString());
                this.EditCondition(ref extraCondition, wkStr);
            }

            // �q�ɒI��
            if ((this._extrInfo.St_WarehouseShelfNo != string.Empty) || (this._extrInfo.Ed_WarehouseShelfNo != string.Empty))
            {
                wkStr = String.Format("�q�ɒI�ԁF {0} �` {1}",
                this._extrInfo.St_WarehouseShelfNo.ToString(), this._extrInfo.Ed_WarehouseShelfNo.ToString());
                this.EditCondition(ref extraCondition, wkStr);
            }
            //--- ADD 2008/08/01 ----------<<<<<

            //���[�J�[�R�[�h
            // 2007.10.05 �C�� >>>>>>>>>>>>>>>>>>>>
            //if ((this._extrInfo.St_MakerCode != 0) || (this._extrInfo.Ed_MakerCode != 999))
            if ((this._extrInfo.St_GoodsMakerCd != 0) || (this._extrInfo.Ed_GoodsMakerCd != 999999))
            // 2007.10.05 �C�� <<<<<<<<<<<<<<<<<<<<
            {
                //wkStr = String.Format("���[�J�[�R�[�h�F {0} �` {1}",  // DEL 2008.08.01
                wkStr = String.Format("���[�J�[�F {0} �` {1}",          // ADD 2008.08.01
                    // 2007.10.05 �C�� >>>>>>>>>>>>>>>>>>>>
                    //this._extrInfo.St_MakerCode.ToString(), this._extrInfo.Ed_MakerCode.ToString());
                this._extrInfo.St_GoodsMakerCd.ToString(), this._extrInfo.Ed_GoodsMakerCd.ToString());
                // 2007.10.05 �C�� <<<<<<<<<<<<<<<<<<<<
                this.EditCondition(ref extraCondition, wkStr);
            }

            //�a�k�R�[�h
            if ((this._extrInfo.St_BLGoodsCode != 0) || (this._extrInfo.Ed_BLGoodsCode != 99999999))
            {
                wkStr = String.Format("�a�k�R�[�h�F {0} �` {1}",
                this._extrInfo.St_BLGoodsCode.ToString(), this._extrInfo.Ed_BLGoodsCode.ToString());
                this.EditCondition(ref extraCondition, wkStr);
            }
               --- DEL 2008/10/08 -----------------------------------------------------------------------------------------<<<<< */
            // --- ADD 2008/10/08 ----------------------------------------------------------------------------------------->>>>>
            // �d����
            //if ((this._extrInfo.St_StockSupplierCode != 0) || (this._extrInfo.Ed_StockSupplierCode != 999999))        //DEL�@""��ALL9���͂̋�ʂ�����K�v�������
            if ((this._extrInfo.St_StockSupplierCode != 0) ||
                ((this._extrInfo.Ed_StockSupplierCode != 0) &&
                 (string.IsNullOrEmpty(this._extrInfo.Ed_StockSupplierCode.ToString()) == false)))
            {
                if (this._extrInfo.St_StockSupplierCode == 0)
                {
                    start = "�ŏ�����";
                }
                else
                {
                    start = this._extrInfo.St_StockSupplierCode.ToString("000000");
                }
                //if (this._extrInfo.Ed_StockSupplierCode == 999999)        //DEL�@""��ALL9���͂̋�ʂ�����K�v�������
                if ((this._extrInfo.Ed_StockSupplierCode == 0) || (string.IsNullOrEmpty(this._extrInfo.Ed_StockSupplierCode.ToString()) == true))
                {
                    end = "�Ō�܂�";
                }
                else
                {
                    end = this._extrInfo.Ed_StockSupplierCode.ToString("000000");
                }
                wkStr = String.Format("�d����F {0} �` {1}", start, end);
                this.EditCondition(ref extraCondition, wkStr);
            }

            // �q�ɒI��
            if ((this._extrInfo.St_WarehouseShelfNo != string.Empty) || (this._extrInfo.Ed_WarehouseShelfNo != string.Empty))
            {
                if (this._extrInfo.St_WarehouseShelfNo == string.Empty)
                {
                    start = "�ŏ�����";
                }
                else
                {
                    start = this._extrInfo.St_WarehouseShelfNo.ToString();
                }
                if (this._extrInfo.Ed_WarehouseShelfNo == string.Empty)
                {
                    end = "�Ō�܂�";
                }
                else
                {
                    end = this._extrInfo.Ed_WarehouseShelfNo.ToString();
                }
                wkStr = String.Format("�q�ɒI�ԁF {0} �` {1}", start, end);
                this.EditCondition(ref extraCondition, wkStr);
            }

            //���[�J�[�R�[�h
            //if ((this._extrInfo.St_GoodsMakerCd != 0) || (this._extrInfo.Ed_GoodsMakerCd != 9999))    //DEL�@""��ALL9���͂̋�ʂ�����K�v�������
            if ((this._extrInfo.St_GoodsMakerCd != 0) ||
                ((this._extrInfo.Ed_GoodsMakerCd != 0) &&
                 (string.IsNullOrEmpty(this._extrInfo.Ed_GoodsMakerCd.ToString()) == false)))
            {
                if (this._extrInfo.St_GoodsMakerCd == 0)
                {
                    start = "�ŏ�����";
                }
                else
                {
                    start = this._extrInfo.St_GoodsMakerCd.ToString("0000");
                }
                //if (this._extrInfo.Ed_GoodsMakerCd == 9999)           //DEL�@""��ALL9���͂̋�ʂ�����K�v�������
                if ((this._extrInfo.Ed_GoodsMakerCd == 0) || (string.IsNullOrEmpty(this._extrInfo.Ed_GoodsMakerCd.ToString()) == true))
                {
                    end = "�Ō�܂�";
                }
                else
                {
                    end = this._extrInfo.Ed_GoodsMakerCd.ToString("0000");
                }
                wkStr = String.Format("���[�J�[�F {0} �` {1}", start, end);
                this.EditCondition(ref extraCondition, wkStr);
            }

            //�a�k�R�[�h
            //if ((this._extrInfo.St_BLGoodsCode != 0) || (this._extrInfo.Ed_BLGoodsCode != 99999))     //DEL�@""��ALL9���͂̋�ʂ�����K�v�������
            if ((this._extrInfo.St_BLGoodsCode != 0) ||
                ((this._extrInfo.Ed_BLGoodsCode != 0) &&
                 (string.IsNullOrEmpty(this._extrInfo.Ed_BLGoodsCode.ToString()) == false)))
            {
                if (this._extrInfo.St_BLGoodsCode == 0)
                {
                    start = "�ŏ�����";
                }
                else
                {
                    start = this._extrInfo.St_BLGoodsCode.ToString("00000");
                }
                //if (this._extrInfo.Ed_BLGoodsCode == 99999)           //DEL�@""��ALL9���͂̋�ʂ�����K�v�������
                if ((this._extrInfo.Ed_BLGoodsCode == 0) || (string.IsNullOrEmpty(this._extrInfo.Ed_BLGoodsCode.ToString()) == true))
                {
                    end = "�Ō�܂�";
                }
                else
                {
                    end = this._extrInfo.Ed_BLGoodsCode.ToString("00000");
                }
                wkStr = String.Format("�a�k�R�[�h�F {0} �` {1}", start, end);
                this.EditCondition(ref extraCondition, wkStr);
            }
            // --- ADD 2008/10/08 -----------------------------------------------------------------------------------------<<<<<

            if ((this._extrInfo.St_GoodsNo != "") || (this._extrInfo.Ed_GoodsNo != ""))
            {
                if (this._extrInfo.St_GoodsNo == "")
                {
                    //start = "�s�n�o";     // DEL 2008.08.04
                    start = "�ŏ�����";     // ADD 2008.08.04
                }
                else
                {
                    start = this._extrInfo.St_GoodsNo;
                }
                if (this._extrInfo.Ed_GoodsNo == "")
                {
                    //end = "�d�m�c";       // DEL 2008.08.04
                    end = "�Ō�܂�";       // ADD 2008.08.04
                }
                else
                {
                    end = this._extrInfo.Ed_GoodsNo;
                }

                //wkStr = String.Format("���i�R�[�h�F {0} �` {1}",      // DEL 2008.08.01
                wkStr = String.Format("�i�ԁF {0} �` {1}",              // ADD 2008.08.01
                start, end);
                this.EditCondition(ref extraCondition, wkStr);
            }

            //--- DEL 2008/08/01 ---------->>>>>
            //wkStr = "�݌ɋ敪�F ";
            ////�݌ɋ敪
            //switch(this._extrInfo.StockDiv)
            //{
                
            //    //�S��
            //    case (int)StockListCndtn.StockDivStatus.StockDiv_ALLStock:
            //    {
            //        wkStr += StockListCndtn.GetStockDivName((int)StockListCndtn.StockDivStatus.StockDiv_ALLStock);
            //        break;
            //    }
            //    //�d���݌ɕ�
            //    case (int)StockListCndtn.StockDivStatus.StockDiv_MyStock:
            //    {
            //        wkStr += StockListCndtn.GetStockDivName((int)StockListCndtn.StockDivStatus.StockDiv_MyStock);
            //        break;
            //    }
            //    //����݌ɕ�
            //    case (int)StockListCndtn.StockDivStatus.StockDiv_TrustStock:
            //    {
            //        wkStr += StockListCndtn.GetStockDivName((int)StockListCndtn.StockDivStatus.StockDiv_TrustStock);
            //        break;
            //    }
                                  
            //}
            //this.EditCondition( ref extraCondition, wkStr );
            //--- DEL 2008/08/01 ----------<<<<<
                     
            #endregion
        }
	    

		/// <summary>
		/// �\�[�g��������쐬����
		/// </summary>
		/// <returns>�\�[�g��������</returns>
		/// <remarks>
		/// <br>Note       : �\�[�g����������쐬���܂��B</br>
		/// <br>Programmer : 23010 �����@�m</br>
		/// <br>Date       : 2007.03.22</br>
		/// </remarks>
		private string MakeSortCondition()
		{
			return "[" + StockListCndtn.GetSortName(this._extrInfo.ChangePageDiv) + "]";
		}

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
		/// <br>Date       : 2007.03.16</br>
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
		/// <br>Date       : 2007.03.16</br>
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
