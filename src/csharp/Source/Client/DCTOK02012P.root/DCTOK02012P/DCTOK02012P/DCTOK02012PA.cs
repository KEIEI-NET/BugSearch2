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
using Broadleaf.Drawing.Printing;
using Broadleaf.Library.Globarization;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Text;
using Broadleaf.Library.Windows.Forms;

namespace Broadleaf.Drawing.Printing
{
	/// <summary>
	/// ������񌎕����N���X
	/// </summary>
	/// <remarks>
    /// <br>Note       : ������񌎕�̈�����s���B</br>
	/// <br>Programmer : 22013 �v�� ����</br>
	/// <br>Date       : 2007.03.08</br>
	/// </remarks>
	class DCTOK02012PA: IPrintProc
	{

		#region �� Constructor
		/// <summary>
		/// ������񌎕����N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
		/// <br>Note       : ������񌎕����N���X�̃C���X�^���X�̍쐬���s���B</br>
		/// <br>Programmer : 22013 �v�� ����</br>
		/// <br>Date       : 2007.03.08</br>
		/// </remarks>
		public DCTOK02012PA()
		{
		}

		/// <summary>
		/// ������񌎕����N���X�R���X�g���N�^
		/// </summary>
		/// <param name="printInfo">������I�u�W�F�N�g</param>
		/// <remarks>
		/// <br>Note       : ������񌎕����N���X�̃C���X�^���X�̍쐬���s���B</br>
		/// <br>Programmer : 22013 �v�� ����</br>
		/// <br>Date       : 2007.03.08</br>
		/// </remarks>
		public DCTOK02012PA( object printInfo )
		{
			this._printInfo = printInfo as SFCMN06002C;
			this._salesDayMonthReport = this._printInfo.jyoken as SalesDayMonthReport;
		}
		#endregion �� Constructor

		#region �� Pricate Const
		private const string ct_ReportForm_NameSpace = "Broadleaf.Drawing.Printing";
		private const string ct_Space			= "�@";
        // 2008.08.26 30413 ���� ������ύX >>>>>>START
        //private const string ct_Extr_Top = "�s�n�o";
        //private const string ct_Extr_End		= "�d�m�c";
        private const string ct_Extr_Top = "�ŏ�����";
        private const string ct_Extr_End = "�Ō�܂�";
        // 2008.08.26 30413 ���� ������ύX <<<<<<END
        private const string ct_RangeConst = "�F{0} �` {1}";
		#endregion �� Pricate Const

		#region �� Private Member
		private SFCMN06002C _printInfo;					// ������N���X
		private SalesDayMonthReport _salesDayMonthReport;		// ���o�����N���X
		#endregion �� Private Member

		#region �� Exception Class
		/// <summary> ��O�N���X </summary>
        private class StockMoveException: ApplicationException
		{
			private int _status;
			#region �� Constructor
			/// <summary>
			/// ��O�N���X�R���X�g���N�^
			/// </summary>
			/// <param name="message">���b�Z�[�W</param>
			/// <param name="status">�X�e�[�^�X</param>
			public StockMoveException(string message, int status): base(message)
			{
				this._status = status; 
			}
			#endregion
    
			#region �� Public Property
			/// <summary> �X�e�[�^�X�v���p�e�B </summary>
			public int Status
			{
				get{ return this._status; }
			}
			#endregion
		}
		#endregion �� Exception Class

		#region �� IPrintProc �����o
		#region �� Public Property
		/// <summary>
		/// ������擾�v���p�e�B
		/// </summary>
		public SFCMN06002C Printinfo
		{
			get { return this._printInfo; }
			set { this._printInfo = value;}
		}
		#endregion �� Public Property

		#region �� Public Method
		#region �� ��������J�n
		/// <summary>
		/// ��������J�n
		/// </summary>
		/// <returns></returns>
		/// <remarks>
		/// <br>Note       : ������J�n����B</br>
		/// <br>Programmer : 22013 �v�� ����</br>
		/// <br>Date       : 2007.03.08</br>
		/// </remarks>
		public int StartPrint ()
		{
			return PrintMain();
		}
		#endregion
		#endregion �� Public Method
		#endregion �� IPrintProc �����o

		#region �� Private Member
		#region �� �������
		/// <summary>
		/// �������
		/// </summary>
		/// <returns>Status</returns>
		/// <remarks>
		/// <br>Note       : ����������s���B</br>
		/// <br>Programmer : 22013 �v�� ����</br>
		/// <br>Date       : 2007.03.08</br>
		/// </remarks>
		private int PrintMain ()
		{
			int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
			// ����t�H�[���N���X�C���X�^���X�쐬
			DataDynamics.ActiveReports.ActiveReport3 prtRpt = null;
			
			try
			{
				// ���|�[�g�C���X�^���X�쐬
				this.CreateReport(out prtRpt, this._printInfo.prpid); 
				if (prtRpt == null) return status;

				// �e��v���p�e�B�ݒ�
				status = this.SettingProperty(ref prtRpt);
				if (status != 0) return status;
							
				// �f�[�^�\�[�X�ݒ�
				prtRpt.DataSource = this._printInfo.rdData;
				prtRpt.DataMember = DCTOK02014EA.ct_Tbl_SalesDayMonthReportData;
				
				// ������ʏ��v���p�e�B�ݒ�
				Broadleaf.Windows.Forms.SFCMN00293UC commonInfo;
			    this.SetPrintCommonInfo(out commonInfo);

			    // �v���r���[�L��				
			    int mode = this._printInfo.prevkbn;
				
			    // �o�̓��[�h���o�c�e�̏ꍇ�A�������Ńv���r���[��
			    if (this._printInfo.printmode == 2)
			    {
			        mode = 0;
			    }
				
			    switch(mode)
			    {
			        case 0:		// �v���r����
			        {
			            Broadleaf.Windows.Forms.SFCMN00293UB processForm = new Broadleaf.Windows.Forms.SFCMN00293UB();
						
			            // ���ʏ����ݒ�
			            processForm.CommonInfo = commonInfo;

			            // �v���O���X�o�[UP�C�x���g�ǉ�
			            if (prtRpt is IPrintActiveReportTypeCommon)
			            {
			                ((IPrintActiveReportTypeCommon)prtRpt).ProgressBarUpEvent +=
			                    new ProgressBarUpEventHandler(processForm.ProgressBarUpEvent);
			            }

			            // ������s
			            status = processForm.Run(prtRpt);

			            // �߂�l�ݒ�
			            this._printInfo.status = status;

			            break;
			        }
			        case 1:		// �v���r���L
			        {
			            Broadleaf.Windows.Forms.SFCMN00293UA viewForm = new Broadleaf.Windows.Forms.SFCMN00293UA();

			            // ���ʏ����ݒ�
			            viewForm.CommonInfo   = commonInfo;

			            // �v���r���[���s
			            status = viewForm.Run(prtRpt); 

			            // �߂�l�ݒ�
			            this._printInfo.status = status;
						
			            break;
			        }
			    }

			    // �o�c�e�o�͂̏ꍇ
			    if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
			    {
			        switch (this._printInfo.printmode)
			        {
			            case 1:  // �v�����^
			                break;
			            case 2:  // �o�c�e
			            case 3:  // ����(�v�����^ + �o�c�e)
			            {
			                // �o�c�e�\���t���OON
			                this._printInfo.pdfopen = true;
   
			                // ����������̂ݗ���ۑ�
			                if (this._printInfo.printmode == 3)
			                {
			                    // �o�͗����Ǘ��ɒǉ�
			                    Broadleaf.Windows.Forms.SFANL06101UA pdfHistoryControl = new Broadleaf.Windows.Forms.SFANL06101UA();
			                    pdfHistoryControl.AddPrintInfo(this._printInfo.key, this._printInfo.prpnm, this._printInfo.prpnm,
			                        this._printInfo.pdftemppath);
			                }
			                break;
			            }
			        }
			    }
			}
			catch(Exception ex)
			{
			    this.MsgDispProc(emErrorLevel.ERR_LEVEL_STOPDISP,
			        ex.Message, -1, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
			}
			finally
			{
			    if ( prtRpt != null )
			    {
			        prtRpt.Dispose();
			    }
			}
			return status;
		}
		#endregion �� �������

		#region �� ���|�[�g�t�H�[���ݒ�֘A
		#region �� �e��ActiveReport���[�C���X�^���X�쐬
		/// <summary>
		/// �e��ActiveReport���[�C���X�^���X�쐬
		/// </summary>
		/// <param name="rptObj">�C���X�^���X�����ꂽ���[�t�H�[���N���X</param>
		/// <param name="prpid">���[�t�H�[��ID</param>
		/// <returns></returns>
		/// <remarks>
		/// <br>Note       : �w�肳�ꂽ�A�Z���u���y�уN���X�����A�N���X���C���X�^���X�����܂��B</br>
		/// <br>Programmer : 22013 �v�� ����</br>
		/// <br>Date       : 2007.03.08</br>
		/// </remarks>
		private void CreateReport(out DataDynamics.ActiveReports.ActiveReport3 rptObj,string prpid)
		{
			// ����t�H�[���N���X�C���X�^���X�쐬
			rptObj = (DataDynamics.ActiveReports.ActiveReport3)this.LoadAssemblyReport(
				prpid.Trim(), ct_ReportForm_NameSpace + "." + prpid.Trim(), 
				typeof(DataDynamics.ActiveReports.ActiveReport3));
		}
		#endregion

		#region �� ���|�[�g�A�Z���u���C���X�^���X��
		/// <summary>
		/// ���|�[�g�A�Z���u���C���X�^���X��
		/// </summary>
		/// <param name="asmname">�A�Z���u������</param>
		/// <param name="classname">�N���X����</param>
		/// <param name="type">��������N���X�^</param>
		/// <returns>�C���X�^���X�����ꂽ�N���X</returns>
		/// <remarks>
		/// <br>Note       : �w�肳�ꂽ�A�Z���u���y�уN���X�����A�N���X���C���X�^���X�����܂��B</br>
		/// <br>Programmer : 22013 �v�� ����</br>
		/// <br>Date       : 2007.03.08</br>
		/// </remarks>
		private	object LoadAssemblyReport(string asmname, string classname, Type type)
		{
			object	obj	= null;
			try
			{
				System.Reflection.Assembly	asm	= System.Reflection.Assembly.Load(asmname);
				Type	objType	= asm.GetType(classname);
				if (objType != null)
				{
					if ((objType == type) || (objType.IsSubclassOf(type) == true) || (objType.GetInterface(type.Name).Name == type.Name))
					{
						obj = Activator.CreateInstance(objType);
					}
				}
			}
			catch(System.IO.FileNotFoundException)
			{
				throw new StockMoveException(asmname + "�����݂��܂���B",-1);
			}
			catch(System.Exception er)
			{
				throw new StockMoveException(er.Message, -1);
			}
			return obj;
		}
		#endregion

		#region �� �����ʋ��ʏ��ݒ�

		/// <summary>
		/// �����ʋ��ʏ��ݒ�
		/// </summary>
		/// <param name="commonInfo"></param>
		/// <returns>�X�e�[�^�X</returns>
		/// <remarks>
		/// <br>Note       : �����ʋ��ʏ����̐ݒ���s���܂��B</br>
		/// <br>Programmer : 22013 �v�� ����</br>
		/// <br>Date       : 2007.03.08</br>
		/// </remarks>
		private void SetPrintCommonInfo(out Broadleaf.Windows.Forms.SFCMN00293UC commonInfo)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
			commonInfo = new Broadleaf.Windows.Forms.SFCMN00293UC();
			
			// ���[�`���[�g���ʕ��i�N���X
			SFCMN00331C cmnCommon = new SFCMN00331C(); 

			// PDF�p�X�擾
			string pdfPath = "";
			string pdfName = "";
		
			// �v�����^��
			commonInfo.PrinterName = this._printInfo.prinm;
			// ���[��
			commonInfo.PrintName   = this._printInfo.prpnm;				
			// ������[�h
			commonInfo.PrintMode   = this.Printinfo.printmode;
			// �������
			commonInfo.PrintMax    = 0;
			DataView dv = (DataView)this._printInfo.rdData;
			commonInfo.PrintMax = dv.Count;
			
			status = cmnCommon.GetPdfSavePathName(this._printInfo.prpnm, ref pdfPath, ref pdfName);
			this._printInfo.pdftemppath = pdfPath + pdfName;
			commonInfo.PdfFullPath = this._printInfo.pdftemppath;

			// ��]��
			commonInfo.MarginsTop  = this._printInfo.py;
			// ���]��
			commonInfo.MarginsLeft = this._printInfo.px;
		}

		#endregion
		
		#region �� �e��v���p�e�B�ݒ�
		/// <summary>
		/// �e��v���p�e�B�ݒ�
		/// </summary>
		/// <param name="rpt">�C���X�^���X�����ꂽ���[�t�H�[���N���X</param>
		/// <returns>�X�e�[�^�X</returns>
		/// <remarks>
		/// <br>Note       : �e��v���p�e�B��ݒ肵�܂��B</br>
		/// <br>Programmer : 22013 �v�� ����</br>
		/// <br>Date       : 2007.03.08</br>
		/// </remarks>
		private int SettingProperty(ref DataDynamics.ActiveReports.ActiveReport3 rpt)
		{
			int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;

			// ActiveReport�C���^�[�t�F�[�X�ɃL���X�g
			IPrintActiveReportTypeList instance = rpt as IPrintActiveReportTypeList;

			// ��������擾
			_salesDayMonthReport = (SalesDayMonthReport)this._printInfo.jyoken;

			//�W�v�^�C�v 0:�S�� 1:���_��
			string ttlTypeString = "";
            // 2008.08.26 30413 ���� �W�v���@�ɂ��\�[�g���v���p�e�B�ݒ�̕ύX�͖��� >>>>>>START
            //if (_salesDayMonthReport.TtlType == 0)
            //{
            //    ttlTypeString = "[���_ ";
            //}
            //else
            //{
            //    ttlTypeString = "[";
            //}
            // 2008.08.26 30413 ���� �W�v���@�ɂ��\�[�g���v���p�e�B�ݒ�̕ύX�͖��� <<<<<<END
            
			// �\�[�g���v���p�e�B�ݒ�
            // 2008.08.26 30413 ���� �W�v�P�ʕʂ̃\�[�g���v���p�e�B��ύX >>>>>>START
            //0:���_�� 1:������ 2:�ە� 3:�n��� 4:�Ǝ�� 5:�S���ҕ� 6:�󒍎ҕ� 7:���s�ҕ� 8:���Ӑ�� 9:�n��ʓ��Ӑ�� 10:�Ǝ�ʓ��Ӑ�ʈ� 11:�S���ҕʓ��Ӑ��
            //switch (_salesDayMonthReport.TotalType)
            //{
            //    case 0: instance.PageHeaderSortOderTitle = "[���_��]"; break;
            //    case 1: instance.PageHeaderSortOderTitle = ttlTypeString + "������]"; break;
            //    case 2: instance.PageHeaderSortOderTitle = ttlTypeString + "���� �ۏ�]"; break;
            //    case 3: instance.PageHeaderSortOderTitle = ttlTypeString + "�n�揇]"; break;
            //    case 4: instance.PageHeaderSortOderTitle = ttlTypeString + "�Ǝ폇]"; break;
            //    case 5: instance.PageHeaderSortOderTitle = ttlTypeString + "�S���ҏ�]"; break;
            //    case 6: instance.PageHeaderSortOderTitle = ttlTypeString + "�󒍎ҏ�]"; break;
            //    case 7: instance.PageHeaderSortOderTitle = ttlTypeString + "���s�ҏ�]"; break;
            //    case 8: instance.PageHeaderSortOderTitle = ttlTypeString + "���Ӑ揇]"; break;
            //    case 9: instance.PageHeaderSortOderTitle = ttlTypeString + "�n�� ���Ӑ揇]"; break;
            //    case 10: instance.PageHeaderSortOderTitle = ttlTypeString + "�Ǝ� ���Ӑ揇]"; break;
            //    case 11: instance.PageHeaderSortOderTitle = ttlTypeString + "�S���� ���Ӑ揇]"; break;
            //}
            //0:���Ӑ�� 1:�S���ҕ� 2:�󒍎ҕ� 3:���s�ҕ� 4:�n��� 5:�Ǝҕ� 6:�̔��敪��
            switch (_salesDayMonthReport.TotalType)
            {
                case (int)SalesDayMonthReport.TotalTypeState.Customer:          // ���Ӑ��
                    {
                        switch (_salesDayMonthReport.OutType)
                        {
                            case 0: ttlTypeString = "[���Ӑ揇]"; break;
                            case 1: ttlTypeString = "[���_��]"; break;
                            case 2: ttlTypeString = "[���Ӑ�|���_��]"; break;
                            case 3: ttlTypeString = "[�Ǘ����_��]"; break;
                        }
                        break;
                    }
                case (int)SalesDayMonthReport.TotalTypeState.SalesEmployee:     // �S���ҕ�
                    {
                        switch (_salesDayMonthReport.OutType)
                        {
                            case 0: ttlTypeString = "[�S���ҏ�]"; break;
                            case 1: ttlTypeString = "[���Ӑ揇]"; break;
                            case 2: ttlTypeString = "[�S���ҁ|���_��]"; break;
                            case 3: ttlTypeString = "[�Ǘ����_��]"; break;
                        }
                        break;
                    }
                case (int)SalesDayMonthReport.TotalTypeState.FrontEmployee:     // �󒍎ҕ�
                    {
                        switch (_salesDayMonthReport.OutType)
                        {
                            case 0: ttlTypeString = "[�󒍎ҏ�]"; break;
                            case 1: ttlTypeString = "[���Ӑ揇]"; break;
                            case 2: ttlTypeString = "[�󒍎ҁ|���_��]"; break;
                            case 3: ttlTypeString = "[�Ǘ����_��]"; break;
                        }
                        break;
                    }
                case (int)SalesDayMonthReport.TotalTypeState.SalesInput:        // ���s�ҕ�
                    {
                        switch (_salesDayMonthReport.OutType)
                        {
                            case 0: ttlTypeString = "[���s�ҏ�]"; break;
                            case 1: ttlTypeString = "[���Ӑ揇]"; break;
                            case 2: ttlTypeString = "[���s�ҁ|���_��]"; break;
                            case 3: ttlTypeString = "[�Ǘ����_��]"; break;
                        }
                        break;
                    }
                case (int)SalesDayMonthReport.TotalTypeState.Area:              // �n���
                    {
                        switch (_salesDayMonthReport.OutType)
                        {
                            case 0: ttlTypeString = "[�n�揇]"; break;
                            case 1: ttlTypeString = "[���Ӑ揇]"; break;
                            case 2: ttlTypeString = "[�n��|���_��]"; break;
                        }
                        break;
                    }
                case (int)SalesDayMonthReport.TotalTypeState.BusinessType:      // �Ǝ��
                    {
                        switch (_salesDayMonthReport.OutType)
                        {
                            case 0: ttlTypeString = "[�Ǝ폇]"; break;
                            case 1: ttlTypeString = "[���Ӑ揇]"; break;
                            case 2: ttlTypeString = "[�Ǝ�|���_��]"; break;
                        }
                        break;
                    }
                case (int)SalesDayMonthReport.TotalTypeState.SalesDiv:          // �̔��敪
                    {
                        ttlTypeString = "";
                        break;
                    }
            }
            instance.PageHeaderSortOderTitle = ttlTypeString;
            // 2008.08.26 30413 ���� �W�v�P�ʕʂ̃\�[�g���v���p�e�B��ύX <<<<<<END
            
			// ���[�o�͐ݒ���擾 
			PrtOutSet prtOutSet;
			string message;
			int st = SalesDayMonthReportAcs.ReadPrtOutSet(out prtOutSet, out message);
			if (st != 0) 
			{
                throw new StockMoveException(message, status);
            }
			
			// ���o�����w�b�_�o�͋敪
			instance.ExtraCondHeadOutDiv = prtOutSet.ExtraCondHeadOutDiv;

			// ���o�����ҏW����
			StringCollection extraInfomations;
			this.MakeExtarCondition( out extraInfomations );
			instance.ExtraConditions = extraInfomations; 
			
			// �t�b�^�o�͋敪
			instance.PageFooterOutCode   = prtOutSet.FooterPrintOutCode;

			// �t�b�^�o�̓��b�Z�[�W
			StringCollection footers = new StringCollection();
			footers.Add(prtOutSet.PrintFooter1);
			footers.Add(prtOutSet.PrintFooter2);
			
			instance.PageFooters = footers;

			// ������I�u�W�F�N�g
			instance.PrintInfo = this._printInfo;

            // 2008.08.26 30413 ���� �W�v�P�ʕʂ̃T�u�^�C�g�����̂�ύX >>>>>>START
            // �w�b�_�[�T�u�^�C�g��
            ////0:���_�� 1:������ 2:�ە� 3:�n��� 4:�Ǝ�� 5:�S���ҕ� 6:�󒍎ҕ� 7:���s�ҕ� 8:���Ӑ�� 9:�n��ʓ��Ӑ�� 10:�Ǝ�ʓ��Ӑ�ʈ� 11:�S���ҕʓ��Ӑ��
            //switch (_salesDayMonthReport.TotalType)
            //{
            //    case 0: ttlTypeString = "�i���_�ʁj"; break;
            //    case 1: ttlTypeString = "�i�����ʁj"; break;
            //    case 2: ttlTypeString = "�i�ەʁj"; break;
            //    case 3: ttlTypeString = "�i�n��ʁj"; break;
            //    case 4: ttlTypeString = "�i�Ǝ�ʁj"; break;
            //    case 5: ttlTypeString = "�i�S���ҕʁj"; break;
            //    case 6: ttlTypeString = "�i�󒍎ҕʁj"; break;
            //    case 7: ttlTypeString = "�i���s�ҕʁj"; break;
            //    case 8: ttlTypeString = "�i���Ӑ�ʁj"; break;
            //    case 9: ttlTypeString = "�i�n��ʓ��Ӑ�ʁj"; break;
            //    case 10: ttlTypeString = "�i�Ǝ�ʓ��Ӑ�ʁj"; break;
            //    case 11: ttlTypeString = "�i�S���ҕʓ��Ӑ�ʁj"; break;
            //}
            //0:���Ӑ�� 1:�S���ҕ� 2:�󒍎ҕ� 3:���s�ҕ� 4:�n��� 5:�Ǝҕ� 6:�̔��敪��
            switch (_salesDayMonthReport.TotalType)
            {
                case (int)SalesDayMonthReport.TotalTypeState.Customer:          // ���Ӑ��
                    {
                        ttlTypeString = "�i���Ӑ�ʁj";
                        break;
                    }
                case (int)SalesDayMonthReport.TotalTypeState.SalesEmployee:     // �S���ҕ�
                    {
                        ttlTypeString = "�i�S���ҕʁj";
                        break;
                    }
                case (int)SalesDayMonthReport.TotalTypeState.FrontEmployee:     // �󒍎ҕ�
                    {
                        ttlTypeString = "�i�󒍎ҕʁj";
                        break;
                    }
                case (int)SalesDayMonthReport.TotalTypeState.SalesInput:        // ���s�ҕ�
                    {
                        ttlTypeString = "�i���s�ҕʁj";
                        break;
                    }
                case (int)SalesDayMonthReport.TotalTypeState.Area:              // �n���
                    {
                        ttlTypeString = "�i�n��ʁj";
                        break;
                    }
                case (int)SalesDayMonthReport.TotalTypeState.BusinessType:      // �Ǝ��
                    {
                        ttlTypeString = "�i�Ǝ�ʁj";
                        break;
                    }
                case (int)SalesDayMonthReport.TotalTypeState.SalesDiv:          // �̔��敪
                    {
                        ttlTypeString = "�i�̔��敪�ʁj";
                        break;
                    }
            }
            // 2008.08.26 30413 ���� �W�v�P�ʕʂ̃T�u�^�C�g�����̂�ύX <<<<<<END
            instance.PageHeaderSubtitle = " ������񌎕�" + ttlTypeString;

			// ���̑��f�[�^
			// Todo:�ړ����Ƃ��n���H���o�����n�邩�炢�����H
			instance.OtherDataList = null;

			status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

			return status;
		}

		#endregion

		#region �� ���o�����o�͏��쐬
		/// <summary>
		/// ���o�����o�͏��쐬
		/// </summary>
		/// <param name="extraConditions">�쐬�㒊�o�����R���N�V����</param>
		/// <remarks>
		/// <br>Note       : �o�͂��钊�o������������쐬����B</br>
		/// <br>Programmer : 22013 �v�� ����</br>
		/// <br>Date       : 2007.03.08</br>
		/// </remarks>
		private void MakeExtarCondition( out StringCollection extraConditions )
		{
			string swName = string.Empty;		// ���_��q�Ƀ^�C�g��
			extraConditions = new StringCollection();
			StringCollection addConditions = new StringCollection();
            string stTarget = "";
            string edTarget = "";
            
			//�Ώۓ��t
			string st_ShipArrivalDate = string.Empty;
			string ed_ShipArrivalDate = string.Empty;
			// �J�n��I���̂����ꂩ�����͂���Ă���Έ�
			if ((this._salesDayMonthReport.SalesDateSt != DateTime.MinValue) || (this._salesDayMonthReport.SalesDateEd != DateTime.MinValue))
			{
				// �J�n
				if (this._salesDayMonthReport.SalesDateSt != DateTime.MinValue)
					st_ShipArrivalDate = TDateTime.DateTimeToString("YYYY/MM/DD", this._salesDayMonthReport.SalesDateSt);
				else
					st_ShipArrivalDate = ct_Extr_Top;
				// �I��
				if (this._salesDayMonthReport.SalesDateEd != DateTime.MinValue)
					ed_ShipArrivalDate = TDateTime.DateTimeToString("YYYY/MM/DD", this._salesDayMonthReport.SalesDateEd);
				else
					ed_ShipArrivalDate = ct_Extr_End;

				this.EditCondition(
					ref addConditions,
					string.Format(
						//this._salesDayMonthReport.ExtractDateTitle.PadRight(7, '�@') + 
						"�Ώۓ�" + 
						ct_RangeConst,
						st_ShipArrivalDate,
						ed_ShipArrivalDate));
			}

            // 2008.08.19 30413 ���� ���Ӑ�̒��o�����󎚏��������Ɉړ� >>>>>>START
            ////���Ӑ�R�[�h
            //if ((this._salesDayMonthReport.CustomerCodeSt != 0) || (this._salesDayMonthReport.CustomerCodeEd != 0))
            //{
            //    this.EditCondition(ref addConditions,
            //        GetConditionRange("���Ӑ�R�[�h�F", this._salesDayMonthReport.CustomerCodeSt, this._salesDayMonthReport.CustomerCodeEd, "d9")
            //    );
            //}
            // 2008.08.19 30413 ���� ���Ӑ�̒��o�����󎚏��������Ɉړ� <<<<<<END
            
            // 2008.08.19 30413 ���� �o�͒P�ʕʂɒ��o�����o�͂�ύX >>>>>>START
            ////�S���҃R�[�h
            //if ((this._salesDayMonthReport.SalesEmployeeCdSt != string.Empty) || (this._salesDayMonthReport.SalesEmployeeCdEd != string.Empty))
            //{
            //    this.EditCondition(ref addConditions,
            //        GetConditionRange("�S���҃R�[�h�F", this._salesDayMonthReport.SalesEmployeeCdSt, this._salesDayMonthReport.SalesEmployeeCdEd));
            //}
            ////�󒍎҃R�[�h
            //if ((this._salesDayMonthReport.FrontEmployeeCdSt != string.Empty) || (this._salesDayMonthReport.FrontEmployeeCdEd != string.Empty))
            //{
            //    this.EditCondition(ref addConditions,
            //        GetConditionRange("�󒍎҃R�[�h�F", this._salesDayMonthReport.FrontEmployeeCdSt, this._salesDayMonthReport.FrontEmployeeCdEd));
            //}
            ////���s�҃R�[�h
            //if ((this._salesDayMonthReport.SalesInputCodeSt != string.Empty) || (this._salesDayMonthReport.SalesInputCodeEd != string.Empty))
            //{
            //    this.EditCondition(ref addConditions,
            //        GetConditionRange("���s�҃R�[�h�F", this._salesDayMonthReport.SalesInputCodeSt, this._salesDayMonthReport.SalesInputCodeEd));
            //}
            ////�n��R�[�h
            //if ((this._salesDayMonthReport.SalesAreaCodeSt != 0) || (this._salesDayMonthReport.SalesAreaCodeEd != 0))
            //{
            //    this.EditCondition(ref addConditions,
            //        GetConditionRange("�n��R�[�h�F", this._salesDayMonthReport.SalesAreaCodeSt, this._salesDayMonthReport.SalesAreaCodeEd, "d2")
            //    );
            //}
            ////�Ǝ�R�[�h
            //if ((this._salesDayMonthReport.BusinessTypeCodeSt != 0) || (this._salesDayMonthReport.BusinessTypeCodeEd != 0))
            //{
            //    this.EditCondition(ref addConditions,
            //        GetConditionRange("�Ǝ�R�[�h�F", this._salesDayMonthReport.BusinessTypeCodeSt, this._salesDayMonthReport.BusinessTypeCodeEd, "d2")
            //    );
            //}

            
            //// �W�v�P��
            //if (this._salesDayMonthReport.SrchCodeSt != string.Empty || this._salesDayMonthReport.SrchCodeEd != string.Empty)
            //{
            //    string stTarget = this._salesDayMonthReport.SrchCodeSt;
            //    string edTarget = this._salesDayMonthReport.SrchCodeEd;
            //    if (stTarget == string.Empty) stTarget = ct_Extr_Top;
            //    if (edTarget == string.Empty) edTarget = ct_Extr_End;

            //    switch (_salesDayMonthReport.TotalType)
            //    {
            //        case (int)SalesDayMonthReport.TotalTypeState.SalesEmployee:     // �S���ҕ�
            //            {
            //                this.EditCondition(ref addConditions, string.Format("�S����" + ct_RangeConst, stTarget, edTarget));
            //                break;
            //            }
            //        case (int)SalesDayMonthReport.TotalTypeState.FrontEmployee:     // �󒍎ҕ�
            //            {
            //                this.EditCondition(ref addConditions, string.Format("�󒍎�" + ct_RangeConst, stTarget, edTarget));
            //                break;
            //            }
            //        case (int)SalesDayMonthReport.TotalTypeState.SalesInput:        // ���s�ҕ�
            //            {
            //                this.EditCondition(ref addConditions, string.Format("���s��" + ct_RangeConst, stTarget, edTarget));
            //                break;
            //            }
            //        case (int)SalesDayMonthReport.TotalTypeState.Area:              // �n���
            //            {
            //                this.EditCondition(ref addConditions, string.Format("�n��" + ct_RangeConst, stTarget, edTarget));
            //                break;
            //            }
            //        case (int)SalesDayMonthReport.TotalTypeState.BusinessType:      // �Ǝ��
            //            {
            //                this.EditCondition(ref addConditions, string.Format("�Ǝ�" + ct_RangeConst, stTarget, edTarget));
            //                break;
            //            }
            //        case (int)SalesDayMonthReport.TotalTypeState.SalesDiv:          // �̔��敪
            //            {
            //                this.EditCondition(ref addConditions, string.Format("�̔��敪" + ct_RangeConst, stTarget, edTarget));
            //                break;
            //            }
            //    }
            //}

            //// ���Ӑ�
            //if (this._salesDayMonthReport.CustomerCodeSt != 0 || (this._salesDayMonthReport.CustomerCodeEd != 0 && this._salesDayMonthReport.CustomerCodeEd == 999999999))
            //{
            //    string stTarget = this._salesDayMonthReport.CustomerCodeSt.ToString("d09");
            //    string edTarget = this._salesDayMonthReport.CustomerCodeEd.ToString("d09");
            //    if (stTarget == string.Empty) stTarget = ct_Extr_Top;
            //    if (edTarget == string.Empty) edTarget = ct_Extr_End;

            //    this.EditCondition(ref addConditions, string.Format("���Ӑ�" + ct_RangeConst, stTarget, edTarget));
            //}
            // 2008.08.19 30413 ���� �o�͒P�ʕʂɒ��o�����o�͂�ύX <<<<<<END

            // 2008.09.24 30413 ���� ���o�����̏o�͐����ύX >>>>>>START
            // �W�v�P��
            string outType = "";
            switch (_salesDayMonthReport.TotalType)
            {
                case (int)SalesDayMonthReport.TotalTypeState.SalesEmployee:     // �S���ҕ�
                    {
                        outType = "�S����";
                        break;
                    }
                case (int)SalesDayMonthReport.TotalTypeState.FrontEmployee:     // �󒍎ҕ�
                    {
                        outType = "�󒍎�";
                        break;
                    }
                case (int)SalesDayMonthReport.TotalTypeState.SalesInput:        // ���s�ҕ�
                    {
                        outType = "���s��";
                        break;
                    }
                case (int)SalesDayMonthReport.TotalTypeState.Area:              // �n���
                    {
                        outType = "�n��";
                        break;
                    }
                case (int)SalesDayMonthReport.TotalTypeState.BusinessType:      // �Ǝ��
                    {
                        outType = "�Ǝ�";
                        break;
                    }
                case (int)SalesDayMonthReport.TotalTypeState.SalesDiv:          // �̔��敪
                    {
                        outType = "�̔��敪";
                        break;
                    }
            }

            if ((this._salesDayMonthReport.SrchCodeSt == "") && (this._salesDayMonthReport.SrchCodeEd != ""))
            {
                stTarget = ct_Extr_Top;
                edTarget = this._salesDayMonthReport.SrchCodeEd;
                this.EditCondition(ref addConditions, string.Format(outType + ct_RangeConst, stTarget, edTarget));
            }
            else if ((this._salesDayMonthReport.SrchCodeSt != "") && (this._salesDayMonthReport.SrchCodeEd == ""))
            {
                stTarget = this._salesDayMonthReport.SrchCodeSt;
                edTarget = ct_Extr_End;
                this.EditCondition(ref addConditions, string.Format(outType + ct_RangeConst, stTarget, edTarget));
            }
            else if ((this._salesDayMonthReport.SrchCodeSt != "") && (this._salesDayMonthReport.SrchCodeEd != ""))
            {
                stTarget = this._salesDayMonthReport.SrchCodeSt;
                edTarget = this._salesDayMonthReport.SrchCodeEd;
                this.EditCondition(ref addConditions, string.Format(outType + ct_RangeConst, stTarget, edTarget));
            }

            // ���Ӑ�
            if ((this._salesDayMonthReport.CustomerCodeSt == 0) && (this._salesDayMonthReport.CustomerCodeEd != 0))
            {
                stTarget = ct_Extr_Top;
                edTarget = this._salesDayMonthReport.CustomerCodeEd.ToString("d08");
                this.EditCondition(ref addConditions, string.Format("���Ӑ�" + ct_RangeConst, stTarget, edTarget));                
            }
            else if ((this._salesDayMonthReport.CustomerCodeSt > 0) && (this._salesDayMonthReport.CustomerCodeEd == 0))
            {
                stTarget = this._salesDayMonthReport.CustomerCodeSt.ToString("d08");
                edTarget = ct_Extr_End;
                this.EditCondition(ref addConditions, string.Format("���Ӑ�" + ct_RangeConst, stTarget, edTarget));                
            }
            else if ((this._salesDayMonthReport.CustomerCodeSt > 0) && (this._salesDayMonthReport.CustomerCodeEd != 0))
            {
                stTarget = this._salesDayMonthReport.CustomerCodeSt.ToString("d08");
                edTarget = this._salesDayMonthReport.CustomerCodeEd.ToString("d08");
                this.EditCondition(ref addConditions, string.Format("���Ӑ�" + ct_RangeConst, stTarget, edTarget));                
            }
            // 2008.09.24 30413 ���� ���o�����̏o�͐����ύX <<<<<<END

			//�W�v���@
			if(_salesDayMonthReport.TtlType == 0)
			{
				this.EditCondition(ref addConditions, string.Format("�W�v���@�F�S��"));
			}
			else
			{
				this.EditCondition(ref addConditions, string.Format("�W�v���@�F���_��"));
			}

			//���z�P��
			if(_salesDayMonthReport.MoneyUnit == 0)
			{
				this.EditCondition(ref addConditions, string.Format("���z�P�ʁF�~"));
			}
			else
			{
				this.EditCondition(ref addConditions, string.Format("���z�P�ʁF��~"));
			}

            // 2008.08.26 30413 ���� ���v��������̒ǉ� >>>>>>START
            // ���v�������
            if (_salesDayMonthReport.TotalType != 6)
            {
                // �W�v�P�ʂ��u�̔��敪�v�ȊO
                if (_salesDayMonthReport.DaySumPrtDiv == 0)
                {
                    this.EditCondition(ref addConditions, string.Format("���v��������F����"));
                }
                else
                {
                    this.EditCondition(ref addConditions, string.Format("���v��������F���Ȃ�"));
                }
            }
            // 2008.08.26 30413 ���� ���v��������̒ǉ� <<<<<<END

            // 2008.08.26 30413 ���� ���ł̍폜 >>>>>>START
			//����
            //if(_salesDayMonthReport.CrMode == 1)
            //{
            //    this.EditCondition(ref addConditions, string.Format("���ŁF���_��"));
            //}
            // 2008.08.26 30413 ���� ���ł̍폜 <<<<<<END
			
			foreach ( string exCondStr in addConditions )
			{
				extraConditions.Add( exCondStr );
			}
		}
		#endregion

		#region �� ���o�͈͕�����쐬
		/// <summary>
		/// ���o�͈͕�����쐬
		/// </summary>
		/// <returns>�쐬������</returns>
		/// <remarks>
		/// <br>Note       : ���o�͈͕�������쐬���܂�</br>
		/// <br>Programmer : 22013 �v�� ����</br>
		/// <br>Date       : 2007.03.08</br>
		/// </remarks>
		private string GetConditionRange( string title, string startString, string endString )
		{
			string result = "";
			if ((startString != "") || (endString != ""))
			{
				string start = ct_Extr_Top;
				string end	 = ct_Extr_End;
				if (startString	!= "")	start	= startString;
				if (endString	!= "")	end		= endString;
				result = String.Format(title + ct_RangeConst, start, end);
			}
			return result;
		}

		/// <summary>
		/// ���o�͈͕�����쐬
		/// </summary>
		/// <returns>�쐬������</returns>
		/// <remarks>
		/// <br>Note       : ���o�͈͕�������쐬���܂�</br>
		/// <br>Programmer : 22013 �v�� ����</br>
		/// <br>Date       : 2007.03.08</br>
		/// </remarks>
		private string GetConditionRange(string title, int startString, int endString, string kt)
		{
			string result = "";
			if ((startString != 0) || (endString != 0))
			{
				string start = ct_Extr_Top;
				string end = ct_Extr_End;
				if (startString != 0) start = startString.ToString(kt);
				if (endString != 0) end = endString.ToString(kt);
				result = String.Format(title + ct_RangeConst, start, end);
			}
			return result;
		}
		#endregion

		#region �� ���o����������ҏW
		/// <summary>
		/// ���o����������ҏW
		/// </summary>
		/// <param name="editArea">�i�[�G���A</param>
		/// <param name="target">�Ώە�����</param>
		/// <remarks>
		/// <br>Note       : �o�͂��钊�o�����������ҏW���܂��B</br>
		/// <br>Programmer : 22013 �v�� ����</br>
		/// <br>Date       : 2007.03.08</br>
		/// </remarks>
		private void EditCondition(ref StringCollection editArea, string target)
		{
			bool isEdit = false;
			
			// �ҏW�Ώە����o�C�g���Z�o
			int targetByte = TStrConv.SizeCountSJIS(target);
			
			for (int i = 0; i < editArea.Count; i++)
			{
				int areaByte = 0;
				
				// �i�[�G���A�̃o�C�g���Z�o
				if (editArea[i] != null)
				{
					areaByte = TStrConv.SizeCountSJIS(editArea[i]);
				}

				if ((areaByte + targetByte + 2) <= 190)
				{
					isEdit = true;

					// �S�p�X�y�[�X��}��
					if (editArea[i] != null) editArea[i] += ct_Space;
					
					editArea[i]  += target;
					break;
				}
			}
			// �V�K�ҏW�G���A�쐬
			if (!isEdit)
			{
				editArea.Add(target);
			}
		}
		#endregion
		#endregion �� ���|�[�g�t�H�[���ݒ�֘A

		#region �� ���b�Z�[�W�\��

		/// <summary>
		/// ���b�Z�[�W�\��
		/// </summary>
		/// <param name="iLevel">�G���[���x��</param>
		/// <param name="iMsg">�G���[���b�Z�[�W</param>
		/// <param name="iSt">�X�e�[�^�X</param>
		/// <param name="iButton">�\���{�^��</param>
		/// <param name="iDefButton">�f�t�H���g�t�H�[�J�X�{�^��</param>
		/// <returns>DialogResult</returns>
		/// <remarks>
		/// <br>Note       : �o�͌����̐ݒ���s���܂��B</br>
		/// <br>Programmer : 22013 �v�� ����</br>
		/// <br>Date       : 2007.03.08</br>
		/// </remarks>
		private DialogResult MsgDispProc(emErrorLevel iLevel, string iMsg, int iSt, MessageBoxButtons iButton, MessageBoxDefaultButton iDefButton)
		{
			return TMsgDisp.Show(iLevel, "DCTOK02012P", iMsg, iSt, iButton, iDefButton);
		}

		#endregion
		#endregion
	}
}
