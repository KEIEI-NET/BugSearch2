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
	/// ���㏇�ʕ\����N���X
	/// </summary>
	/// <remarks>
    /// <br>Note       : ���㏇�ʕ\�̈�����s���B</br>
	/// <br>Programmer : 96186 ���ԗT��</br>
	/// <br>Date       : 2007.03.08</br>
    /// <br>Update Note: 2008.09.24 30452 ��� �r��</br>
    /// <br>            �EPM.NS�Ή�</br>
    /// <br>           : 2008/10/27       �Ɠc �M�u</br>
    /// <br>            �E�o�O�C���A�d�l�ύX�Ή�</br>
    /// <br>Update Note: 2008.12.11 30452 ��� �r��</br>
    /// <br>            �E�d�l�ύX�Ή�</br>
    /// <br>            �@�O���[�v�R�[�h�̒P�̎w����w�b�_�󎚂���悤�C��</br>
    /// <br>Update Note: 2009/03/17 30452 ��� �r��</br>
    /// <br>            �E��Q�Ή�12699</br>
    /// <br>Update Note: 2011/11/28 ������</br>
    /// <br>            �E��Q�Ή�Redmine#7739</br>
    /// <br>Update Note: 2014/12/16 ����</br>
    /// <br>�Ǘ��ԍ�   : 11070263-00</br>
    /// <br>           :�E�����Y�ƗlSeiken�i�ԕύX</br>
    /// <br>Update Note: 2015/03/27 ���V��</br>
    /// <br>�Ǘ��ԍ�   : 11070263-00</br>
    /// <br>           : Redmine#44209��#423�i�ԏW�v�敪�̖��̕ύX</br>
    /// </remarks>
	class DCHNB02052PA: IPrintProc
	{
		#region �� Constructor
		/// <summary>
		/// ���㏇�ʕ\����N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
		/// <br>Note       : ���㏇�ʕ\����N���X�̃C���X�^���X�̍쐬���s���B</br>
		/// <br>Programmer : 96186 ���ԗT��</br>
		/// <br>Date       : 2007.03.08</br>
		/// </remarks>
		public DCHNB02052PA()
		{
		}

		/// <summary>
		/// ���㏇�ʕ\����N���X�R���X�g���N�^
		/// </summary>
		/// <param name="printInfo">������I�u�W�F�N�g</param>
		/// <remarks>
		/// <br>Note       : ���㏇�ʕ\����N���X�̃C���X�^���X�̍쐬���s���B</br>
		/// <br>Programmer : 96186 ���ԗT��</br>
		/// <br>Date       : 2007.03.08</br>
		/// </remarks>
		public DCHNB02052PA( object printInfo )
		{
			this._printInfo = printInfo as SFCMN06002C;
			this._shipmGoodsOdrReport = this._printInfo.jyoken as ShipmGoodsOdrReport;
		}
		#endregion �� Constructor

		#region �� Pricate Const
		private const string ct_ReportForm_NameSpace = "Broadleaf.Drawing.Printing";
		private const string ct_Space			= "�@";
        ///private const string ct_Extr_Top       = "�s�n�o"; // DEL 2008/09/24
        //private const string ct_Extr_End        = "�d�m�c"; // DEL 2008/09/24
        private const string ct_Extr_Top        = "�ŏ�����"; // ADD 2008/09/24
        private const string ct_Extr_End        = "�Ō�܂�"; // ADD 2008/09/24
        private	const string ct_RangeConst		= "�F{0} �` {1}";
		#endregion �� Pricate Const

		#region �� Private Member
		private SFCMN06002C _printInfo;					// ������N���X
		private ShipmGoodsOdrReport _shipmGoodsOdrReport;		// ���o�����N���X
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
    
			#region �� Public Propertyf
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
		/// <br>Programmer : 96186 ���ԗT��</br>
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
		/// <br>Programmer : 96186 ���ԗT��</br>
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
				prtRpt.DataMember = DCHNB02054EA.ct_Tbl_ShipmGoodsOdrReportData;
				
				// ������ʏ��v���p�e�B�ݒ�
				Broadleaf.Windows.Forms.SFCMN00293UC commonInfo;
                //this.SetPrintCommonInfo(out commonInfo); // DEL 2009/03/17
                this.SetPrintCommonInfo(ref prtRpt, out commonInfo); // ADD 2009/03/17

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
		/// <br>Programmer : 96186 ���ԗT��</br>
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
		/// <br>Programmer : 96186 ���ԗT��</br>
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
		/// <br>Programmer : 96186 ���ԗT��</br>
		/// <br>Date       : 2007.03.08</br>
		/// </remarks>
        //private void SetPrintCommonInfo(out Broadleaf.Windows.Forms.SFCMN00293UC commonInfo) // DEL 2009/03/17
        private void SetPrintCommonInfo(ref DataDynamics.ActiveReports.ActiveReport3 rptObj, out Broadleaf.Windows.Forms.SFCMN00293UC commonInfo) // ADD 2009/03/17
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

            // --- ADD 2009/03/17 -------------------------------->>>>>
            rptObj.Document.CacheToDisk = true;
            rptObj.Document.CacheToDiskLocation = pdfPath;
            // --- ADD 2009/03/17 --------------------------------<<<<<
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
		/// <br>Programmer : 96186 ���ԗT��</br>
		/// <br>Date       : 2007.03.08</br>
		/// </remarks>
		private int SettingProperty(ref DataDynamics.ActiveReports.ActiveReport3 rpt)
		{
			int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;

			// ActiveReport�C���^�[�t�F�[�X�ɃL���X�g
			IPrintActiveReportTypeList instance = rpt as IPrintActiveReportTypeList;

			// ��������擾
			_shipmGoodsOdrReport = (ShipmGoodsOdrReport)this._printInfo.jyoken;

            if (_shipmGoodsOdrReport.TotalType == 0)
            {
                // �\�[�g���v���p�e�B�ݒ�
                //0:�d����{���[�J�[�{���i�����ށ{�a�k�R�[�h�{�i��
                //1:���[�J�[�{���i�����ށ{�a�k�R�[�h�{�i��
                //2:�d����{���[�J�[�{�i��
                //3:���[�J�[�{�i��
                //4:���[�J�[�{���i�����ށ{�i��
                //5:�i�� //ADD BY ������ on 2011/11/28 for Redmine#7739 
                switch (_shipmGoodsOdrReport.Detail)
                {
                    case 0: instance.PageHeaderSortOderTitle = "[�d����{���[�J�[�{���i�����ށ{�a�k�R�[�h�{�i�ԏ�]"; break;
                    case 1: instance.PageHeaderSortOderTitle = "[���[�J�[�{���i�����ށ{�a�k�R�[�h�{�i�ԏ�]"; break;
                    case 2: instance.PageHeaderSortOderTitle = "[�d����{���[�J�[�{�i�ԏ�]"; break;
                    case 3: instance.PageHeaderSortOderTitle = "[���[�J�[�{�i�ԏ�]"; break;
                    case 4: instance.PageHeaderSortOderTitle = "[���[�J�[�{���i�����ށ{�i�ԏ�]"; break;
                    case 5: instance.PageHeaderSortOderTitle = "[�i�ԏ�]"; break;//ADD BY ������ on 2011/11/28 for Redmine#7739 
                }
            }
            else if (_shipmGoodsOdrReport.TotalType == 2)
            {
                switch (_shipmGoodsOdrReport.Detail)
                {
                    case 0: instance.PageHeaderSortOderTitle = "[�i�ԏ�]"; break;
                    case 1: instance.PageHeaderSortOderTitle = "[�O���[�v�R�[�h��]"; break;
                }
            }
			
			// ���[�o�͐ݒ���擾 
			PrtOutSet prtOutSet;
			string message;
			int st = ShipmGoodsOdrReportAcs.ReadPrtOutSet(out prtOutSet, out message);
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

			// �w�b�_�[�T�u�^�C�g��
			//0:���i�� 2:���Ӑ�� 3:�S���ҕ�
			string ttlTypeString = "";
			switch (_shipmGoodsOdrReport.TotalType)
			{
				case 0: ttlTypeString = "�i���i�ʁj"; break;
                case 1: ttlTypeString = "�i�a�k�R�[�h�ʁj"; break; // ADD 2008/09/24
				case 2: ttlTypeString = "�i���Ӑ�ʁj"; break;
				case 3: ttlTypeString = "�i�S���ҕʁj"; break;
			}
			instance.PageHeaderSubtitle = "���㏇�ʕ\" + ttlTypeString;

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
		/// <br>Programmer : 96186 ���ԗT��</br>
		/// <br>Date       : 2007.03.08</br>
        /// <br>Update Note: 2014/12/16 ����</br>
        /// <br>�Ǘ��ԍ�   : 11070263-00</br>
        /// <br>           : �����Y�ƗlSeiken�i�ԕύX</br>
		/// </remarks>
		private void MakeExtarCondition( out StringCollection extraConditions )
		{
			string swName = string.Empty;		// ���_��q�Ƀ^�C�g��
			extraConditions = new StringCollection();
			StringCollection addConditions = new StringCollection();

			//�Ώ۔N��
			string st_ShipArrivalDate = string.Empty;
			string ed_ShipArrivalDate = string.Empty;
			// �J�n��I���̂����ꂩ�����͂���Ă���Έ�
			if ((this._shipmGoodsOdrReport.SalesDateSt != DateTime.MinValue) || (this._shipmGoodsOdrReport.SalesDateEd != DateTime.MinValue))
			{
				// �J�n
				if (this._shipmGoodsOdrReport.SalesDateSt != DateTime.MinValue)
					st_ShipArrivalDate = TDateTime.DateTimeToString("YYYY/MM", this._shipmGoodsOdrReport.PrnSalesDateSt);
				else
					st_ShipArrivalDate = ct_Extr_Top;
				// �I��
				if (this._shipmGoodsOdrReport.SalesDateSt != DateTime.MinValue)
					ed_ShipArrivalDate = TDateTime.DateTimeToString("YYYY/MM", this._shipmGoodsOdrReport.PrnSalesDateEd);
				else
					ed_ShipArrivalDate = ct_Extr_End;

				this.EditCondition(
					ref addConditions,
					string.Format(
						//this._shipmGoodsOdrReport.ExtractDateTitle.PadRight(7, '�@') + 
						"�Ώ۔N��" +
						ct_RangeConst,
						st_ShipArrivalDate,
						ed_ShipArrivalDate));
			}

            // --- ADD 2008/09/24 -------------------------------->>>>>
            // �W�v���@
            if (this._shipmGoodsOdrReport.TtlType == 0)
            {
                this.EditCondition(ref addConditions, string.Format("�W�v���@�F�S��"));
            }
            else
            {
                this.EditCondition(ref addConditions, string.Format("�W�v���@�F���_"));
            }
            // --- ADD 2008/09/24 --------------------------------<<<<<

            //����݌Ɏ�񂹋敪
            //0:���v 1:�݌�, 2:���
            switch (this._shipmGoodsOdrReport.SalesOrderDivCd)
            {
                case 0:
                    this.EditCondition(ref addConditions, string.Format("�ݎ�w��F���v"));
                    break;
                case 1:
                    this.EditCondition(ref addConditions, string.Format("�ݎ�w��F�݌�"));
                    break;
                case 2:
                    this.EditCondition(ref addConditions, string.Format("�ݎ�w��F���"));
                    break;
            }

            //���z�P��
            //0:�~ 1:��~
            if (_shipmGoodsOdrReport.MoneyUnit == 0)
            {
                this.EditCondition(ref addConditions, string.Format("���z�P�ʁF�~"));
            }
            else
            {
                this.EditCondition(ref addConditions, string.Format("���z�P�ʁF��~"));
            }

            // --- ADD 2008/09/24 -------------------------------->>>>>
            //����
            //0:�Ȃ� 1:���_ 2:���Ӑ� 3:�S���� 4:�d����
            switch (_shipmGoodsOdrReport.CrMode)
            {
                case 0:
                    break;
                case 1:
                    this.EditCondition(ref addConditions, string.Format("���ŁF���_�P��"));
                    break;
                case 2:
                    this.EditCondition(ref addConditions, string.Format("���ŁF���Ӑ�P��"));
                    break;
                case 3:
                    this.EditCondition(ref addConditions, string.Format("���ŁF�S���ҒP��"));
                    break;
                case 4:
                    this.EditCondition(ref addConditions, string.Format("���ŁF�d����P��"));
                    break;
            }
            // --- ADD 2008/09/24 --------------------------------<<<<<

            //���ʐݒ�F
            string order0 = "";
            string order1 = "";
            string order2 = "";

            //0:���㐔�� 1:����� 2:������z 3:�e�����z 4:���ʂȂ�
            switch (this._shipmGoodsOdrReport.SortItem)
            {
                case 0:
                    order0 = "���ʏ�";
                    break;
                case 1:
                    order0 = "�񐔏�";
                    break;
                case 2:
                    order0 = "������z��";
                    break;
                case 3:
                    order0 = "�e�����z��";
                    break;
                case 4:
                    order0 = "";
                    break;
            }

            //0:�S�� 1:���_�P��
            switch (this._shipmGoodsOdrReport.Order1)
            {
                case 0:
                    order1 = "�S��";
                    break;
                case 1:
                    order1 = "���_";
                    break;
            }

            //0:��� 1:����
            switch (this._shipmGoodsOdrReport.Order2)
            {
                case 0:
                    order2 = "���";
                    break;
                case 1:
                    order2 = "����";
                    break;
            }

            this.EditCondition(ref addConditions,
                string.Format("���ʐݒ�F{0} {1} {2} {3}�ʂ܂�", order0, order1, order2, this._shipmGoodsOdrReport.Order3)
            );

            // --- DEL 2009/02/10 -------------------------------->>>>>
            ////����͈͎w��i���ʁj
            ////if ((this._shipmGoodsOdrReport.PrintRangeSt != 0) || (this._shipmGoodsOdrReport.PrintRangeEd != 999999999))       //DEL 2008/10/27 ��ʂ̓��͒l�����̂܂܈󎚂̈�
            //// --- ADD 2008/10/27 --------------------------------------------------------------------------->>>>>
            //if ((this._shipmGoodsOdrReport.PrintRangeSt != 0) ||
            //    ((this._shipmGoodsOdrReport.PrintRangeEd != 0) &&
            //     (string.IsNullOrEmpty(this._shipmGoodsOdrReport.PrintRangeEd.ToString()) == false)))
            //// --- ADD 2008/10/27 ---------------------------------------------------------------------------<<<<<
            //{
            //    string stName = ct_Extr_Top;
            //    string edName = ct_Extr_End;

            //    if (this._shipmGoodsOdrReport.PrintRangeSt != 0)
            //    {
            //        //stName = this._shipmGoodsOdrReport.PrintRangeSt.ToString("000000000");    //DEL 2008/10/27 0�l�߂͂��Ȃ�
            //        stName = this._shipmGoodsOdrReport.PrintRangeSt.ToString("");               //ADD 2008/10/27
            //    }

            //    //if (this._shipmGoodsOdrReport.PrintRangeEd != 999999999)      //DEL 2008/10/27 ��ʂ̓��͒l�����̂܂܈󎚂̈�
            //    // --- ADD 2008/10/27 --------------------------------------------------------------------------->>>>>
            //    if ((this._shipmGoodsOdrReport.PrintRangeEd != 0) &&
            //        (string.IsNullOrEmpty(this._shipmGoodsOdrReport.PrintRangeEd.ToString()) == false))
            //    // --- ADD 2008/10/27 ---------------------------------------------------------------------------<<<<<
            //    {
            //        //edName = this._shipmGoodsOdrReport.PrintRangeEd.ToString("000000000");    //DEL 2008/10/27 0�l�߂͂��Ȃ�
            //        edName = this._shipmGoodsOdrReport.PrintRangeEd.ToString("");               //ADD 2008/10/27
            //    }

            //    this.EditCondition(ref addConditions,
            //        string.Format("����͈͎w��i���ʁj�F{0} �` {1}", stName, edName)
            //    );
            //}
            // --- DEL 2009/02/10 -------------------------------->>>>>
            // --- ADD 2009/02/10 -------------------------------->>>>>
            //����͈͎w��i���ʁj
            if (!this._shipmGoodsOdrReport.PrintRangeStNoInput || !this._shipmGoodsOdrReport.PrintRangeEdNoInput)
            {
                string stName = ct_Extr_Top;
                string edName = ct_Extr_End;

                if (!this._shipmGoodsOdrReport.PrintRangeStNoInput)
                {
                    stName = this._shipmGoodsOdrReport.PrintRangeSt.ToString();
                }

                if (!this._shipmGoodsOdrReport.PrintRangeEdNoInput)
                {
                    edName = this._shipmGoodsOdrReport.PrintRangeEd.ToString();
                }

                    this.EditCondition(ref addConditions,
                        string.Format("����͈͎w��i���ʁj�F{0} �` {1}", stName, edName));
            }

            // --- ADD 2009/02/10 --------------------------------<<<<<

            // --- ADD 2008/09/24 -------------------------------->>>>>
            // �\����P��
            if (this._shipmGoodsOdrReport.TotalType == 1)
            {
                if (this._shipmGoodsOdrReport.ConstUnit == 0) // 0:�����v
                {
                    this.EditCondition(ref addConditions, string.Format("�\����P�ʁF�����v"));
                }
                else // 1:���_�v
                {
                    this.EditCondition(ref addConditions, string.Format("�\����P�ʁF���_�v"));
                }
            }
            // --- ADD 2008/09/24 --------------------------------<<<<<
            
            //------ ADD START 2014/12/16 ���� FOR Redmine#44209�����Y�ƗlSeiken�i�ԕύX ------>>>>>
            if (this._shipmGoodsOdrReport.TotalType == 0)
            {
                // �i�ԏW�v�敪
                // 0:�ʁX 1:���Z
                switch (this._shipmGoodsOdrReport.GoodsNoTtlDiv)
                {
                    case 0:
                        //this.EditCondition(ref addConditions, string.Format("�i�ԏW�v�敪�F�ʁX"));// DEL 2015/03/27 Redmine#44209��#423�i�ԏW�v�敪�̖��̕ύX
                        this.EditCondition(ref addConditions, string.Format("�i�ԏW�v�敪�F�ʏ�"));// ADD 2015/03/27 Redmine#44209��#423�i�ԏW�v�敪�̖��̕ύX
                        break;
                    case 1:
                        this.EditCondition(ref addConditions, string.Format("�i�ԏW�v�敪�F���Z"));
                        break;
                }

                if (this._shipmGoodsOdrReport.GoodsNoTtlDiv == 1)
                {
                    // �i�ԕ\���敪
                    // 0:�V�i�� 1:���i��
                    switch (this._shipmGoodsOdrReport.GoodsNoShowDiv)
                    {
                        case 0:
                            this.EditCondition(ref addConditions, string.Format("�i�ԕ\���敪�F�V�i��"));
                            break;
                        case 1:
                            this.EditCondition(ref addConditions, string.Format("�i�ԕ\���敪�F���i��"));
                            break;
                    }
                }
            }
            //------ ADD END 2014/12/16 ���� FOR Redmine#44209�����Y�ƗlSeiken�i�ԕύX ------<<<<<

            //����^�C�v�F
            //0:����,1:��,2:���z,3:���z������,4:���z����,5:���ʁ���
            switch (_shipmGoodsOdrReport.PrintType)
            {
                case 0:
                    this.EditCondition(ref addConditions, string.Format("����^�C�v�F����"));
                    break;
                case 1:
                    this.EditCondition(ref addConditions, string.Format("����^�C�v�F��"));
                    break;
                case 2:
                    this.EditCondition(ref addConditions, string.Format("����^�C�v�F���z"));
                    break;
                case 3:
                    this.EditCondition(ref addConditions, string.Format("����^�C�v�F��i�E���z�^���i�E����"));
                    break;
                case 4:
                    this.EditCondition(ref addConditions, string.Format("����^�C�v�F��i�E���z�^���i�E��"));
                    break;
                case 5:
                    this.EditCondition(ref addConditions, string.Format("����^�C�v�F��i�E���ʁ^���i�E��"));
                    break;
            }

            // --- ADD 2008/09/24 -------------------------------->>>>>
            if (_shipmGoodsOdrReport.TotalType == 0
                || _shipmGoodsOdrReport.TotalType == 1)
            {
                // �d����
                //if ((this._shipmGoodsOdrReport.SupplierCdSt != 0) || (this._shipmGoodsOdrReport.SupplierCdEd != 999999))      //DEL 2008/10/27 ��ʂ̓��͒l�����̂܂܈󎚂̈�
                // --- ADD 2008/10/27 --------------------------------------------------------------------------->>>>>
                if ((this._shipmGoodsOdrReport.SupplierCdSt != 0) ||
                    ((this._shipmGoodsOdrReport.SupplierCdEd != 0) &&
                     (string.IsNullOrEmpty(this._shipmGoodsOdrReport.SupplierCdEd.ToString()) == false)))
                // --- ADD 2008/10/27 ---------------------------------------------------------------------------<<<<<
                {
                    string stName = ct_Extr_Top;
                    string edName = ct_Extr_End;

                    if (this._shipmGoodsOdrReport.SupplierCdSt != 0)
                    {
                        stName = this._shipmGoodsOdrReport.SupplierCdSt.ToString("d6");
                    }
                    //if (this._shipmGoodsOdrReport.SupplierCdEd != 999999)     //DEL 2008/10/27 ��ʂ̒l�����̂܂܈󎚂̈�
                    // --- ADD 2008/10/27 --------------------------------------------------------------------------->>>>>
                    if ((this._shipmGoodsOdrReport.SupplierCdEd != 0) &&
                        (string.IsNullOrEmpty(this._shipmGoodsOdrReport.SupplierCdEd.ToString()) == false))
                    // --- ADD 2008/10/27 ---------------------------------------------------------------------------<<<<<
                    {
                        edName = this._shipmGoodsOdrReport.SupplierCdEd.ToString("d6");
                    }

                    this.EditCondition(ref addConditions,
                        string.Format("�d����F{0} �` {1}", stName, edName)
                    );
                }
            }
            else if (_shipmGoodsOdrReport.TotalType == 2)
            {
                //���Ӑ�R�[�h
                //if ((this._shipmGoodsOdrReport.CustomerCodeSt != 0) || (this._shipmGoodsOdrReport.CustomerCodeEd != 99999999))    //DEL 2008/10/27 ��ʂ̓��͒l�����̂܂܈󎚂̈�
                // --- ADD 2008/10/27 --------------------------------------------------------------------------->>>>>
                if ((this._shipmGoodsOdrReport.CustomerCodeSt != 0) ||
                    ((this._shipmGoodsOdrReport.CustomerCodeEd != 0) &&
                     (string.IsNullOrEmpty(this._shipmGoodsOdrReport.CustomerCodeEd.ToString()) == false)))
                // --- ADD 2008/10/27 ---------------------------------------------------------------------------<<<<<
                {
                    string stName = ct_Extr_Top;
                    string edName = ct_Extr_End;

                    if (this._shipmGoodsOdrReport.CustomerCodeSt != 0)
                    {
                        stName = this._shipmGoodsOdrReport.CustomerCodeSt.ToString("d8");
                    }
                    //if (this._shipmGoodsOdrReport.CustomerCodeEd != 99999999)     //DEL 2008/10/27 ��ʂ̒l�����̂܂܈󎚂̈�
                    // --- ADD 2008/10/27 --------------------------------------------------------------------------->>>>>
                    if ((this._shipmGoodsOdrReport.CustomerCodeEd != 0) &&
                        (string.IsNullOrEmpty(this._shipmGoodsOdrReport.CustomerCodeEd.ToString()) == false))
                    // --- ADD 2008/10/27 ---------------------------------------------------------------------------<<<<<
                    {
                        edName = this._shipmGoodsOdrReport.CustomerCodeEd.ToString("d8");
                    }

                    this.EditCondition(ref addConditions,
                        string.Format("���Ӑ�F{0} �` {1}", stName, edName)
                    );
                }
            }
            else if (_shipmGoodsOdrReport.TotalType == 3)
            {
                string stName = ct_Extr_Top;
                string edName = ct_Extr_End;

                //�S���҃R�[�h
                //if ((this._shipmGoodsOdrReport.EmployeeCodeSt != "0000") || (this._shipmGoodsOdrReport.EmployeeCodeEd != "9999"))     //DEL 2008/10/27 ��ʂ̒l�����̂܂܈󎚂̈�
                // --- ADD 2008/10/27 --------------------------------------------------------------------------->>>>>
                if ((this._shipmGoodsOdrReport.EmployeeCodeSt != "0000") ||
                    (string.IsNullOrEmpty(this._shipmGoodsOdrReport.EmployeeCodeEd) == false))
                // --- ADD 2008/10/27 ---------------------------------------------------------------------------<<<<<
                {
                    if (this._shipmGoodsOdrReport.EmployeeCodeSt != "0000")
                    {
                        stName = this._shipmGoodsOdrReport.EmployeeCodeSt;
                    }
                    //if (this._shipmGoodsOdrReport.EmployeeCodeEd != "9999")                           //DEL 2008/10/27 ��ʂ̒l�����̂܂܈󎚂̈�
                    if (string.IsNullOrEmpty(this._shipmGoodsOdrReport.EmployeeCodeEd) == false)        //ADD 2008/10/27
                    {
                        edName = this._shipmGoodsOdrReport.EmployeeCodeEd;
                    }
                    this.EditCondition(ref addConditions,
                        string.Format("�S���ҁF{0} �` {1}", stName, edName)
                    );
                }
            }
            // --- ADD 2008/09/24 --------------------------------<<<<<

			//���[�J�[�R�[�h
            //if ((this._shipmGoodsOdrReport.GoodsMakerCdSt != 0) || (this._shipmGoodsOdrReport.GoodsMakerCdEd != 9999))        //DEL 2008/10/27 ��ʂ̒l�����̂܂܈󎚂̈�
            // --- ADD 2008/10/27 --------------------------------------------------------------------------->>>>>
            if ((this._shipmGoodsOdrReport.GoodsMakerCdSt != 0) ||
                ((this._shipmGoodsOdrReport.GoodsMakerCdEd != 0) &&
                 (string.IsNullOrEmpty(this._shipmGoodsOdrReport.GoodsMakerCdEd.ToString()) == false)))
            // --- ADD 2008/10/27 ---------------------------------------------------------------------------<<<<<
            {
				string stName = ct_Extr_Top;
				string edName = ct_Extr_End;

				if (this._shipmGoodsOdrReport.GoodsMakerCdSt != 0)
				{
					stName = this._shipmGoodsOdrReport.GoodsMakerCdSt.ToString("d4");
				}
                //if (this._shipmGoodsOdrReport.GoodsMakerCdEd != 9999)     //DEL 2008/10/27 ��ʂ̒l�����̂܂܈󎚂̈�
                // --- ADD 2008/10/27 --------------------------------------------------------------------------->>>>>
                if ((this._shipmGoodsOdrReport.GoodsMakerCdEd != 0) &&
                    (string.IsNullOrEmpty(this._shipmGoodsOdrReport.GoodsMakerCdEd.ToString()) == false))
                // --- ADD 2008/10/27 ---------------------------------------------------------------------------<<<<<
                {
					edName = this._shipmGoodsOdrReport.GoodsMakerCdEd.ToString("d4");
				}

				this.EditCondition(ref addConditions,
					string.Format("���[�J�[�F{0} �` {1}", stName, edName)
				);
			}

            // --- ADD 2008/09/24 -------------------------------->>>>>
            // ���i�啪��
            //if ((this._shipmGoodsOdrReport.GoodsLGroupSt != 0) || (this._shipmGoodsOdrReport.GoodsLGroupEd != 9999))      //DEL 2008/10/27 ��ʂ̒l�����̂܂܈󎚂̈�
            // --- ADD 2008/10/27 --------------------------------------------------------------------------->>>>>
            if ((this._shipmGoodsOdrReport.GoodsLGroupSt != 0) ||
                ((this._shipmGoodsOdrReport.GoodsLGroupEd != 0) &&
                 (string.IsNullOrEmpty(this._shipmGoodsOdrReport.GoodsLGroupEd.ToString()) == false)))
            // --- ADD 2008/10/27 ---------------------------------------------------------------------------<<<<<
            {
                string stName = ct_Extr_Top;
                string edName = ct_Extr_End;

                if (this._shipmGoodsOdrReport.GoodsLGroupSt != 0)
                {
                    stName = this._shipmGoodsOdrReport.GoodsLGroupSt.ToString("d4");
                }
                //if (this._shipmGoodsOdrReport.GoodsLGroupEd != 9999)      //DEL 2008/10/27 ��ʂ̒l�����̂܂܈󎚂̈�
                // --- ADD 2008/10/27 --------------------------------------------------------------------------->>>>>
                if ((this._shipmGoodsOdrReport.GoodsLGroupEd != 0) &&
                    (string.IsNullOrEmpty(this._shipmGoodsOdrReport.GoodsLGroupEd.ToString()) == false))
                // --- ADD 2008/10/27 ---------------------------------------------------------------------------<<<<<
                {
                    edName = this._shipmGoodsOdrReport.GoodsLGroupEd.ToString("d4");
                }

                this.EditCondition(ref addConditions,
                    string.Format("���i�啪�ށF{0} �` {1}", stName, edName)
                );
            }

            // ���i������
            //if ((this._shipmGoodsOdrReport.GoodsMGroupSt != 0) || (this._shipmGoodsOdrReport.GoodsMGroupEd != 9999))      //DEL 2008/10/27 ��ʂ̒l�����̂܂܈󎚂̈�
            // --- ADD 2008/10/27 --------------------------------------------------------------------------->>>>>
            if ((this._shipmGoodsOdrReport.GoodsMGroupSt != 0) ||
                ((this._shipmGoodsOdrReport.GoodsMGroupEd != 0) &&
                 (string.IsNullOrEmpty(this._shipmGoodsOdrReport.GoodsMGroupEd.ToString()) == false)))
            // --- ADD 2008/10/27 ---------------------------------------------------------------------------<<<<<
            {
                string stName = ct_Extr_Top;
                string edName = ct_Extr_End;

                if (this._shipmGoodsOdrReport.GoodsMGroupSt != 0)
                {
                    stName = this._shipmGoodsOdrReport.GoodsMGroupSt.ToString("d4");
                }
                //if (this._shipmGoodsOdrReport.GoodsMGroupEd != 9999)      //DEL 2008/10/27 ��ʂ̒l�����̂܂܈󎚂̈�
                // --- ADD 2008/10/27 --------------------------------------------------------------------------->>>>>
                if ((this._shipmGoodsOdrReport.GoodsMGroupEd != 0) &&
                    (string.IsNullOrEmpty(this._shipmGoodsOdrReport.GoodsMGroupEd.ToString()) == false))
                // --- ADD 2008/10/27 ---------------------------------------------------------------------------<<<<<
                {
                    edName = this._shipmGoodsOdrReport.GoodsMGroupEd.ToString("d4");
                }

                this.EditCondition(ref addConditions,
                    string.Format("���i�����ށF{0} �` {1}", stName, edName)
                );
            }

            // --- DEL 2008/12/11 -------------------------------->>>>>
            // �O���[�v�R�[�h
            //if ((this._shipmGoodsOdrReport.BLGroupCodeSt != 0) || (this._shipmGoodsOdrReport.BLGroupCodeEd != 99999))     //DEL 2008/10/27 ��ʂ̒l�����̂܂܈󎚂̈�
            //// --- ADD 2008/10/27 --------------------------------------------------------------------------->>>>>
            //if ((this._shipmGoodsOdrReport.BLGroupCodeSt != 0) ||
            //    ((this._shipmGoodsOdrReport.BLGroupCodeEd != 0) &&
            //     (string.IsNullOrEmpty(this._shipmGoodsOdrReport.BLGroupCodeEd.ToString()) == false)))
            //// --- ADD 2008/10/27 ---------------------------------------------------------------------------<<<<<
            //{
            //    string stName = ct_Extr_Top;
            //    string edName = ct_Extr_End;

            //    if (this._shipmGoodsOdrReport.BLGroupCodeSt != 0)
            //    {
            //        stName = this._shipmGoodsOdrReport.BLGroupCodeSt.ToString("d5");
            //    }
            //    //if (this._shipmGoodsOdrReport.BLGroupCodeEd != 99999)     //DEL 2008/10/27 ��ʂ̒l�����̂܂܈󎚂̈�
            //    // --- ADD 2008/10/27 --------------------------------------------------------------------------->>>>>
            //    if ((this._shipmGoodsOdrReport.BLGroupCodeEd != 0) &&
            //        (string.IsNullOrEmpty(this._shipmGoodsOdrReport.BLGroupCodeEd.ToString()) == false))
            //    // --- ADD 2008/10/27 ---------------------------------------------------------------------------<<<<<
            //    {
            //        edName = this._shipmGoodsOdrReport.BLGroupCodeEd.ToString("d5");
            //    }

            //    this.EditCondition(ref addConditions,
            //        string.Format("�O���[�v�R�[�h�F{0} �` {1}", stName, edName)
            //    );

            //    setGroupCodeFlg = true; // ADD 2008/12/09
            //}
            // --- DEL 2008/12/11 --------------------------------<<<<<

            // --- ADD 2008/09/24 --------------------------------<<<<<

            // --- ADD 2008/12/11 -------------------------------->>>>>
            // �O���[�v�R�[�h
            StringBuilder groupCodeStr = new StringBuilder();
            bool setGroupCodeFlg = false; // ADD 2008/12/09

            // �͈͎w��
            if ((this._shipmGoodsOdrReport.BLGroupCodeSt != 0) ||
                ((this._shipmGoodsOdrReport.BLGroupCodeEd != 0) &&
                 (string.IsNullOrEmpty(this._shipmGoodsOdrReport.BLGroupCodeEd.ToString()) == false)))
            {
                string stName = ct_Extr_Top;
                string edName = ct_Extr_End;

                if (this._shipmGoodsOdrReport.BLGroupCodeSt != 0)
                {
                    stName = this._shipmGoodsOdrReport.BLGroupCodeSt.ToString("d5");
                }

                if ((this._shipmGoodsOdrReport.BLGroupCodeEd != 0) &&
                    (string.IsNullOrEmpty(this._shipmGoodsOdrReport.BLGroupCodeEd.ToString()) == false))
                {
                    edName = this._shipmGoodsOdrReport.BLGroupCodeEd.ToString("d5");
                }

                groupCodeStr.Append(
                    string.Format("�O���[�v�R�[�h�F{0} �` {1}", stName, edName));

                setGroupCodeFlg = true; // ADD 2008/12/09
            }

            if (this._shipmGoodsOdrReport.BLGroupCodeAry.Length != 0)
            {


                if (!setGroupCodeFlg)
                {
                    groupCodeStr.Append("�O���[�v�R�[�h�F");
                }
                else
                {
                    groupCodeStr.Append(" ");
                }

                foreach (int groupCode in this._shipmGoodsOdrReport.BLGroupCodeAry)
                {
                    groupCodeStr.Append(groupCode.ToString("d5"));
                    groupCodeStr.Append(" ");
                }

                // �]���ȋ󔒂�����
                groupCodeStr.Remove(groupCodeStr.Length - 1, 1);

                this.EditCondition(ref addConditions, groupCodeStr.ToString());

            }
            else
            {
                if (setGroupCodeFlg)
                {
                    this.EditCondition(ref addConditions, groupCodeStr.ToString());
                }
            }
            // --- ADD 2008/12/11 --------------------------------<<<<<

            // --- DEL 2008/09/24 -------------------------------->>>>>
            ////���i�敪�O���[�v�R�[�h
            //if ((this._shipmGoodsOdrReport.LargeGoodsGanreCodeSt != "") || (this._shipmGoodsOdrReport.LargeGoodsGanreCodeEd != ""))
            //{
            //    this.EditCondition(ref addConditions,
            //        string.Format("���i�敪�O���[�v�R�[�h�F{0} �` {1}", this._shipmGoodsOdrReport.LargeGoodsGanreCodeSt, this._shipmGoodsOdrReport.LargeGoodsGanreCodeEd)
            //    );
            //}
            ////���i�敪�R�[�h
            //if ((this._shipmGoodsOdrReport.MediumGoodsGanreCodeSt != "") || (this._shipmGoodsOdrReport.MediumGoodsGanreCodeEd != ""))
            //{
            //    this.EditCondition(ref addConditions,
            //        string.Format("���i�敪�R�[�h�F{0} �` {1}", this._shipmGoodsOdrReport.MediumGoodsGanreCodeSt, this._shipmGoodsOdrReport.MediumGoodsGanreCodeEd)
            //    );
            //}
            ////���i�敪�ڍ׃R�[�h
            //if ((this._shipmGoodsOdrReport.DetailGoodsGanreCodeSt != "") || (this._shipmGoodsOdrReport.DetailGoodsGanreCodeEd != ""))
            //{
            //    this.EditCondition(ref addConditions,
            //        string.Format("���i�敪�ڍ׃R�[�h�F{0} �` {1}", this._shipmGoodsOdrReport.DetailGoodsGanreCodeSt, this._shipmGoodsOdrReport.DetailGoodsGanreCodeEd)
            //    );
            //}
            // --- DEL 2008/09/24 --------------------------------<<<<<

			//BL�R�[�h
            //if ((this._shipmGoodsOdrReport.BLGoodsCodeSt != 0) || (this._shipmGoodsOdrReport.BLGoodsCodeEd != 99999))     //DEL 2008/10/27 ��ʂ̒l�����̂܂܈󎚂̈�
            // --- ADD 2008/10/27 --------------------------------------------------------------------------->>>>>
            if ((this._shipmGoodsOdrReport.BLGoodsCodeSt != 0) ||
                ((this._shipmGoodsOdrReport.BLGoodsCodeEd != 0) &&
                 (string.IsNullOrEmpty(this._shipmGoodsOdrReport.BLGoodsCodeEd.ToString()) == false)))
            // --- ADD 2008/10/27 ---------------------------------------------------------------------------<<<<<
            {
				string stName = ct_Extr_Top;
				string edName = ct_Extr_End;

				if (this._shipmGoodsOdrReport.BLGoodsCodeSt != 0)
				{
					stName = this._shipmGoodsOdrReport.BLGoodsCodeSt.ToString("d5");
				}
                //if (this._shipmGoodsOdrReport.BLGoodsCodeEd != 99999)     //DEL 2008/10/27 ��ʂ̒l�����̂܂܈󎚂̈�
                // --- ADD 2008/10/27 --------------------------------------------------------------------------->>>>>
                if ((this._shipmGoodsOdrReport.BLGoodsCodeEd != 0) &&
                    (string.IsNullOrEmpty(this._shipmGoodsOdrReport.BLGoodsCodeEd.ToString()) == false))
                // --- ADD 2008/10/27 ---------------------------------------------------------------------------<<<<<
                {
					edName = this._shipmGoodsOdrReport.BLGoodsCodeEd.ToString("d5");
				}

				this.EditCondition(ref addConditions,
					string.Format("BL�R�[�h�F{0} �` {1}", stName, edName)
				);
			}
			//�i��
			if ((this._shipmGoodsOdrReport.GoodsNoSt != "") || (this._shipmGoodsOdrReport.GoodsNoEd != ""))
			{
                string stName = ct_Extr_Top;
				string edName = ct_Extr_End;

                if (this._shipmGoodsOdrReport.GoodsNoSt != "")
                {
                    stName = this._shipmGoodsOdrReport.GoodsNoSt;
                }
                if (this._shipmGoodsOdrReport.GoodsNoEd != "")
                {
                    edName = this._shipmGoodsOdrReport.GoodsNoEd;
                }

				this.EditCondition(ref addConditions,
                    string.Format("�i�ԁF{0} �` {1}", stName, edName)
				);
			}

			//�̔��]�ƈ��R�[�h
            // --- DEL 2008/09/24 -------------------------------->>>>>
            //if ((this._shipmGoodsOdrReport.SalesEmployeeCdSt != "") || (this._shipmGoodsOdrReport.SalesEmployeeCdEd != ""))
            //{
            //    this.EditCondition(ref addConditions,
            //        string.Format("�̔��]�ƈ��R�[�h�F{0} �` {1}", this._shipmGoodsOdrReport.SalesEmployeeCdSt, this._shipmGoodsOdrReport.SalesEmployeeCdEd)
            //    );
            //}
            // --- DEL 2008/09/24 --------------------------------<<<<<
			
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
		/// <br>Programmer : 96186 ���ԗT��</br>
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
		#endregion

		#region �� ���o����������ҏW
		/// <summary>
		/// ���o����������ҏW
		/// </summary>
		/// <param name="editArea">�i�[�G���A</param>
		/// <param name="target">�Ώە�����</param>
		/// <remarks>
		/// <br>Note       : �o�͂��钊�o�����������ҏW���܂��B</br>
		/// <br>Programmer : 96186 ���ԗT��</br>
		/// <br>Date       : 2007.03.08</br>
        /// <br>Update Note: 2014/12/16 ����</br>
        /// <br>�Ǘ��ԍ�   : 11070263-00</br>
        /// <br>           :�E�����Y�ƗlSeiken�i�ԕύX</br>
		/// </remarks>
		private void EditCondition(ref StringCollection editArea, string target)
		{
			bool isEdit = false;
			
			// �ҏW�Ώە����o�C�g���Z�o
			int targetByte = TStrConv.SizeCountSJIS(target);
            //------ ADD START 2014/12/16 ���� FOR Redmine#44209�����Y�ƗlSeiken�i�ԕύX ------>>>>>
            int newindex = 0;
            if (editArea.Count == 0)
            {
                newindex = 0;
            }
            else
            {
                newindex = editArea.Count - 1;
            }
            //------ ADD END 2014/12/16 ���� FOR Redmine#44209�����Y�ƗlSeiken�i�ԕύX ------<<<<<

            //for (int i = 0; i < editArea.Count; i++) // DEL 2014/12/16 ���� FOR Redmine#44209�����Y�ƗlSeiken�i�ԕύX
            for (int i = newindex; i < editArea.Count; i++) // ADD 2014/12/16 ���� FOR Redmine#44209�����Y�ƗlSeiken�i�ԕύX
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
		/// <br>Programmer : 96186 ���ԗT��</br>
		/// <br>Date       : 2007.03.08</br>
		/// </remarks>
		private DialogResult MsgDispProc(emErrorLevel iLevel, string iMsg, int iSt, MessageBoxButtons iButton, MessageBoxDefaultButton iDefButton)
		{
			return TMsgDisp.Show(iLevel, "DCTOK02152P", iMsg, iSt, iButton, iDefButton);
		}

		#endregion
		#endregion
	}
}
