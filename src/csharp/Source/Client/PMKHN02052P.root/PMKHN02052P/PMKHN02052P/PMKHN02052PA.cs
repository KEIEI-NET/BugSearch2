//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �L�����y�[�����ѕ\
// �v���O�����T�v   : �L�����y�[�����ѕ\�@����N���X
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �c����
// �� �� ��  2011/05/19  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ����
// �� �� ��  2011/07/11  �C�����e : Redmine �d�l�ύX #22915 �̑Ή�
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
using Broadleaf.Drawing.Printing;
using Broadleaf.Library.Globarization;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Text;
using Broadleaf.Library.Windows.Forms;

namespace Broadleaf.Drawing.Printing
{
	/// <summary>
    /// �L�����y�[�����ѕ\����N���X
	/// </summary>
	/// <remarks>
    /// <br>Note       : �L�����y�[�����ѕ\�̈�����s���B</br>
	/// <br>Programmer : �c����</br>
	/// <br>Date       : 2011/05/19</br>
    /// </remarks>
	class PMKHN02052PA: IPrintProc
	{
		#region �� Constructor
		/// <summary>
		/// �L�����y�[�����ѕ\����N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
        /// <br>Note       : �L�����y�[�����ѕ\����N���X�̃C���X�^���X�̍쐬���s���B</br>
        /// <br>Programmer : �c����</br>
		/// <br>Date       : 2011/05/19</br>
		/// </remarks>
		public PMKHN02052PA()
		{
		}

		/// <summary>
		/// �L�����y�[�����ѕ\����N���X�R���X�g���N�^
		/// </summary>
		/// <param name="printInfo">������I�u�W�F�N�g</param>
		/// <remarks>
		/// <br>Note       : �L�����y�[�����ѕ\����N���X�̃C���X�^���X�̍쐬���s���B</br>
        /// <br>Programmer : �c����</br>
		/// <br>Date       : 2011/05/19</br>
		/// </remarks>
		public PMKHN02052PA( object printInfo )
		{
			this._printInfo = printInfo as SFCMN06002C;
            this._campaignRsltList = this._printInfo.jyoken as CampaignRsltList;
		}
		#endregion �� Constructor

		#region �� Pricate Const
		private const string ct_ReportForm_NameSpace = "Broadleaf.Drawing.Printing";
		private const string ct_Space			= "�@";
        private const string ct_Extr_Top        = "�ŏ�����";
        private const string ct_Extr_End        = "�Ō�܂�";
        private	const string ct_RangeConst		= "�F{0} �` {1}";
		#endregion �� Pricate Const

		#region �� Private Member
		private SFCMN06002C _printInfo;					// ������N���X
        private CampaignRsltList _campaignRsltList;		            // ���o�����N���X
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
        /// <br>Programmer : �c����</br>
		/// <br>Date       : 2011/05/19</br>
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
		/// <br>Programmer : �c����</br>
		/// <br>Date       : 2011/05/19</br>
		/// </remarks>
		private int PrintMain ()
		{
			int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
			// ����t�H�[���N���X�C���X�^���X�쐬
			DataDynamics.ActiveReports.ActiveReport3 prtRpt = null;
			
			try
			{
				// ���|�[�g�C���X�^���X�쐬
                string prpid = string.Empty;
                this.CreateReport(out prtRpt, this._printInfo.prpid); 
				if (prtRpt == null) return status;

				// �e��v���p�e�B�ݒ�
				status = this.SettingProperty(ref prtRpt);
                if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL) return status;

                // �J���}�ҏW���s��
                if (_campaignRsltList.PrintType == 1)
                {
                    PMCMN02000CA reportCtrl = PMCMN02000CA.GetInstance();
                    reportCtrl.SetReportProps(ref prtRpt, PMCMN02000CA.SetReportPropsKind.NormalList);
                }

				// �f�[�^�\�[�X�ݒ�
				prtRpt.DataSource = this._printInfo.rdData;
				prtRpt.DataMember = PMKHN02054EA.ct_Tbl_CampaignData;
				
				// ������ʏ��v���p�e�B�ݒ�
				Broadleaf.Windows.Forms.SFCMN00293UC commonInfo;
                this.SetPrintCommonInfo(ref prtRpt, out commonInfo);
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
		/// <br>Programmer : �c����</br>
		/// <br>Date       : 2011/05/19</br>
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
		/// <br>Programmer : �c����</br>
		/// <br>Date       : 2011/05/19</br>
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
        /// <param name="rptObj"></param>
        /// <param name="commonInfo"></param>
		/// <returns>�X�e�[�^�X</returns>
		/// <remarks>
		/// <br>Note       : �����ʋ��ʏ����̐ݒ���s���܂��B</br>
		/// <br>Programmer : �c����</br>
		/// <br>Date       : 2011/05/19</br>
		/// </remarks>
        private void SetPrintCommonInfo(ref DataDynamics.ActiveReports.ActiveReport3 rptObj, out Broadleaf.Windows.Forms.SFCMN00293UC commonInfo)
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
            
            rptObj.Document.CacheToDisk = true;
            rptObj.Document.CacheToDiskLocation = pdfPath;
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
		/// <br>Programmer : �c����</br>
		/// <br>Date       : 2011/05/19</br>
		/// </remarks>
		private int SettingProperty(ref DataDynamics.ActiveReports.ActiveReport3 rpt)
		{
			int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;

			// ActiveReport�C���^�[�t�F�[�X�ɃL���X�g
			IPrintActiveReportTypeList instance = rpt as IPrintActiveReportTypeList;

			// ��������擾
            _campaignRsltList = (CampaignRsltList)this._printInfo.jyoken;            
			
			// ���[�o�͐ݒ���擾 
			PrtOutSet prtOutSet;
			string message;
			int st = CampaignRsltListAcs.ReadPrtOutSet(out prtOutSet, out message);
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
			//0:���i�� 1:���Ӑ�� 2:�S���ҕ�
			string ttlTypeString = "";
            ttlTypeString = "�i" + this._campaignRsltList.TotalTypeName + "�j";

			instance.PageHeaderSubtitle = "�L�����y�[�����ѕ\" + ttlTypeString;

			// ���̑��f�[�^
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
		/// <br>Programmer : �c����</br>
		/// <br>Date       : 2011/05/19</br>
		/// </remarks>
		private void MakeExtarCondition( out StringCollection extraConditions )
		{
			string swName = string.Empty;
			extraConditions = new StringCollection();
			StringCollection addConditions = new StringCollection();

            //����^�C�v�F
            switch (this._campaignRsltList.PrintType)
            {
                case 0:
                    this.EditCondition(ref addConditions, string.Format("����^�C�v�F����"));
                    break;
                case 1:
                    this.EditCondition(ref addConditions, string.Format("����^�C�v�F����"));
                    break;
                case 2:
                    this.EditCondition(ref addConditions, string.Format("����^�C�v�F���t"));
                    break;
            }

			//�Ώۓ��t:
			string st_ShipArrivalDate = string.Empty;
			string ed_ShipArrivalDate = string.Empty;
            string format = string.Empty;
            // �����E����
			// �J�n��I���̂����ꂩ�����͂���Ă���Έ�
            if (this._campaignRsltList.PrintType != 2)
            {
                format = "YYYY/MM";
                if ((this._campaignRsltList.AddUpYearMonthSt != DateTime.MinValue) || (this._campaignRsltList.AddUpYearMonthEd != DateTime.MinValue))
                {
                    // �J�n
                    if (this._campaignRsltList.AddUpYearMonthSt != DateTime.MinValue)
                    {
                        st_ShipArrivalDate = TDateTime.DateTimeToString(format, this._campaignRsltList.AddUpYearMonthSt);
                    }
                    else
                    {
                        st_ShipArrivalDate = ct_Extr_Top;
                    }
                    // �I��
                    if (this._campaignRsltList.AddUpYearMonthEd != DateTime.MinValue)
                    {
                        ed_ShipArrivalDate = TDateTime.DateTimeToString(format, this._campaignRsltList.AddUpYearMonthEd);
                    }
                    else
                    {
                        ed_ShipArrivalDate = ct_Extr_End;
                    }

                    this.EditCondition(ref addConditions, string.Format("�Ώۓ��t" + ct_RangeConst, st_ShipArrivalDate, ed_ShipArrivalDate));
                }
            }
            // ���t
            else
            {
                format = "YYYY/MM/DD";
                // �J�n��I���̂����ꂩ�����͂���Ă���Έ�
                if ((this._campaignRsltList.AddUpYearMonthDaySt != DateTime.MinValue) || (this._campaignRsltList.AddUpYearMonthDayEd != DateTime.MinValue))
                {
                    // �J�n
                    if (this._campaignRsltList.AddUpYearMonthDaySt != DateTime.MinValue)
                    {
                        st_ShipArrivalDate = TDateTime.DateTimeToString(format, this._campaignRsltList.AddUpYearMonthDaySt);
                    }
                    else
                    {
                        st_ShipArrivalDate = ct_Extr_Top;
                    }
                    // �I��
                    if (this._campaignRsltList.AddUpYearMonthDayEd != DateTime.MinValue)
                    {
                        ed_ShipArrivalDate = TDateTime.DateTimeToString(format, this._campaignRsltList.AddUpYearMonthDayEd);
                    }
                    else
                    {
                        ed_ShipArrivalDate = ct_Extr_End;
                    }

                    this.EditCondition(ref addConditions, string.Format("�Ώۓ��t" + ct_RangeConst, st_ShipArrivalDate, ed_ShipArrivalDate));
                }
            }
            
            //���גP�ʁF
            switch (this._campaignRsltList.Detail)
            {
                case 0:
                    this.EditCondition(ref addConditions, string.Format("���גP�ʁF�i��"));
                    break;
                case 1:
                    this.EditCondition(ref addConditions, string.Format("���גP�ʁFBL����"));
                    break;
                case 2:
                    this.EditCondition(ref addConditions, string.Format("���גP�ʁF��ٰ�ߺ���"));
                    break;
            }

            //���v�P�ʁF
            if (this._campaignRsltList.Detail == 0)
            {
                switch (this._campaignRsltList.Total)
                {
                    case 0:
                        this.EditCondition(ref addConditions, string.Format("���v�P�ʁF��ٰ�ߺ���"));
                        break;
                    case 1:
                        this.EditCondition(ref addConditions, string.Format("���v�P�ʁFBL����"));
                        break;
                }
            }

            //�o�͏��F
            switch (this._campaignRsltList.TotalType)
            {
                case CampaignRsltList.TotalTypeState.EachGoods: // ���i��
                    break;

                case CampaignRsltList.TotalTypeState.EachCustomer: // ���Ӑ��

                    switch (this._campaignRsltList.OutputSort)
                    {
                        case 0:
                            this.EditCondition(ref addConditions, string.Format("�o�͏��F���Ӑ�"));
                            break;
                        case 1:
                            this.EditCondition(ref addConditions, string.Format("�o�͏��F���_"));
                            break;
                        case 2:
                            this.EditCondition(ref addConditions, string.Format("�o�͏��F���Ӑ�-���_"));
                            break;
                        case 3:
                            this.EditCondition(ref addConditions, string.Format("�o�͏��F�Ǘ����_"));
                            break;
                    }
                    break;

                case CampaignRsltList.TotalTypeState.EachEmployee: // �S���ҕ�
                    
                    switch (this._campaignRsltList.OutputSort)
                    {
                        case 0:
                            this.EditCondition(ref addConditions, string.Format("�o�͏��F�S����"));
                            break;
                        case 1:
                            this.EditCondition(ref addConditions, string.Format("�o�͏��F���Ӑ�"));
                            break;
                        case 2:
                            this.EditCondition(ref addConditions, string.Format("�o�͏��F�S���ҁ|���_"));
                            break;
                        case 3:
                            this.EditCondition(ref addConditions, string.Format("�o�͏��F�Ǘ����_"));
                            break;
                    }
                    break;

                case CampaignRsltList.TotalTypeState.EachAcceptOdr: // �󒍎ҕ�

                    switch (this._campaignRsltList.OutputSort)
                    {
                        case 0:
                            this.EditCondition(ref addConditions, string.Format("�o�͏��F�󒍎�"));
                            break;
                        case 1:
                            this.EditCondition(ref addConditions, string.Format("�o�͏��F���Ӑ�"));
                            break;
                        case 2:
                            this.EditCondition(ref addConditions, string.Format("�o�͏��F�󒍎ҁ|���_"));
                            break;
                        case 3:
                            this.EditCondition(ref addConditions, string.Format("�o�͏��F�Ǘ����_"));
                            break;
                    }
                    break;

                case CampaignRsltList.TotalTypeState.EachPrinter: // ���s�ҕ�

                    switch (this._campaignRsltList.OutputSort)
                    {
                        case 0:
                            this.EditCondition(ref addConditions, string.Format("�o�͏��F���s��"));
                            break;
                        case 1:
                            this.EditCondition(ref addConditions, string.Format("�o�͏��F���Ӑ�"));
                            break;
                        case 2:
                            this.EditCondition(ref addConditions, string.Format("�o�͏��F���s�ҁ|���_"));
                            break;
                        case 3:
                            this.EditCondition(ref addConditions, string.Format("�o�͏��F�Ǘ����_"));
                            break;
                    }
                    break;

                case CampaignRsltList.TotalTypeState.EachArea: // �n���

                    switch (this._campaignRsltList.OutputSort)
                    {
                        case 0:
                            this.EditCondition(ref addConditions, string.Format("�o�͏��F�n��"));
                            break;
                        case 1:
                            this.EditCondition(ref addConditions, string.Format("�o�͏��F���Ӑ�"));
                            break;
                        case 2:
                            this.EditCondition(ref addConditions, string.Format("�o�͏��F�n��|���_"));
                            break;
                        case 3:
                            this.EditCondition(ref addConditions, string.Format("�o�͏��F�Ǘ����_"));
                            break;
                    }
                    break;

                default:
                    break;
            }

            //������F
            if (this._campaignRsltList.Detail == 0 && this._campaignRsltList.PrintType != 1) // ����^�C�v�F����/���t
            {
                switch (this._campaignRsltList.PrintSort)
                {
                    case 0:
                        this.EditCondition(ref addConditions, string.Format("������F�i�ԁ{���[�J�["));
                        break;
                    case 1:
                        this.EditCondition(ref addConditions, string.Format("������F���[�J�[�{�i��"));
                        break;
                }
            }

            // ���o����
            switch (this._campaignRsltList.TotalType)
            {
                case CampaignRsltList.TotalTypeState.EachGoods: // ���i��
                    {
                        // ��ٰ�ߺ���
                        if (this._campaignRsltList.BLGroupCodeSt != 0 ||
                            this._campaignRsltList.BLGroupCodeEd != 0)
                        {
                            string stName = ct_Extr_Top;
                            string edName = ct_Extr_End;

                            if (this._campaignRsltList.BLGroupCodeSt != 0)
                            {
                                stName = this._campaignRsltList.BLGroupCodeSt.ToString("d5");
                            }
                            if (this._campaignRsltList.BLGroupCodeEd != 0)
                            {
                                edName = this._campaignRsltList.BLGroupCodeEd.ToString("d5");
                            }

                            this.EditCondition(ref addConditions,
                                string.Format("��ٰ��" + ct_RangeConst, stName, edName)
                            );
                        }

                        // BL����
                        if (this._campaignRsltList.BLGoodsCodeSt != 0 ||
                            this._campaignRsltList.BLGoodsCodeEd != 0)
                        {
                            string stName = ct_Extr_Top;
                            string edName = ct_Extr_End;

                            if (this._campaignRsltList.BLGoodsCodeSt != 0)
                            {
                                stName = this._campaignRsltList.BLGoodsCodeSt.ToString("d5");
                            }
                            if (this._campaignRsltList.BLGoodsCodeEd != 0)
                            {
                                edName = this._campaignRsltList.BLGoodsCodeEd.ToString("d5");
                            }

                            this.EditCondition(ref addConditions,
                                string.Format("BL����" + ct_RangeConst, stName, edName)
                            );
                        }

                        // ----- ADD 2011/07/11 ----- >>>>>
                        //���Ӑ�R�[�h
                        if ((this._campaignRsltList.CustomerCodeSt != 0) ||
                            (this._campaignRsltList.CustomerCodeEd != 0))
                        {
                            string stName = ct_Extr_Top;
                            string edName = ct_Extr_End;

                            if (this._campaignRsltList.CustomerCodeSt != 0)
                            {
                                stName = this._campaignRsltList.CustomerCodeSt.ToString("d8");
                            }
                            if (this._campaignRsltList.CustomerCodeEd != 0)
                            {
                                edName = this._campaignRsltList.CustomerCodeEd.ToString("d8");
                            }

                            this.EditCondition(ref addConditions,
                                string.Format("���Ӑ�" + ct_RangeConst, stName, edName)
                            );
                        }
                        // ----- ADD 2011/07/11 ----- <<<<<
                    }
                    break;

                case CampaignRsltList.TotalTypeState.EachCustomer: // ���Ӑ��
                    {
                        //���Ӑ�R�[�h
                        if ((this._campaignRsltList.CustomerCodeSt != 0) ||
                            (this._campaignRsltList.CustomerCodeEd != 0))
                        {
                            string stName = ct_Extr_Top;
                            string edName = ct_Extr_End;

                            if (this._campaignRsltList.CustomerCodeSt != 0)
                            {
                                stName = this._campaignRsltList.CustomerCodeSt.ToString("d8");
                            }
                            if (this._campaignRsltList.CustomerCodeEd != 0)
                            {
                                edName = this._campaignRsltList.CustomerCodeEd.ToString("d8");
                            }

                            this.EditCondition(ref addConditions,
                                string.Format("���Ӑ�" + ct_RangeConst, stName, edName)
                            );
                        }
                    }
                    break;

                case CampaignRsltList.TotalTypeState.EachEmployee: // �S���ҕ�
                    {
                        //�S���҃R�[�h
                        if (!string.IsNullOrEmpty(this._campaignRsltList.EmployeeCodeSt.ToString()) ||
                            !string.IsNullOrEmpty(this._campaignRsltList.EmployeeCodeEd.ToString()))
                        {

                            string stName = ct_Extr_Top;
                            string edName = ct_Extr_End;

                            //�S���҃R�[�h
                            if (!string.IsNullOrEmpty(this._campaignRsltList.EmployeeCodeSt.ToString()))
                            {
                                stName = this._campaignRsltList.EmployeeCodeSt;
                            }
                            if (!string.IsNullOrEmpty(this._campaignRsltList.EmployeeCodeEd.ToString()))
                            {
                                edName = this._campaignRsltList.EmployeeCodeEd;
                            }
                            this.EditCondition(ref addConditions,
                                string.Format("�S����" + ct_RangeConst, stName, edName)
                            );
                        }

                        //���Ӑ�R�[�h
                        if ((this._campaignRsltList.CustomerCodeSt != 0) ||
                            (this._campaignRsltList.CustomerCodeEd != 0))
                        {
                            string stName = ct_Extr_Top;
                            string edName = ct_Extr_End;

                            if (this._campaignRsltList.CustomerCodeSt != 0)
                            {
                                stName = this._campaignRsltList.CustomerCodeSt.ToString("d8");
                            }
                            if (this._campaignRsltList.CustomerCodeEd != 0)
                            {
                                edName = this._campaignRsltList.CustomerCodeEd.ToString("d8");
                            }

                            this.EditCondition(ref addConditions,
                                string.Format("���Ӑ�" + ct_RangeConst, stName, edName)
                            );
                        }
                    }
                    break;

                case CampaignRsltList.TotalTypeState.EachAcceptOdr: // �󒍎ҕ�
                    {
                        // �󒍎҃R�[�h
                        if (!string.IsNullOrEmpty(this._campaignRsltList.AcceptOdrCodeSt) 
                            || !string.IsNullOrEmpty(this._campaignRsltList.AcceptOdrCodeEd))
                        {

                            string stName = ct_Extr_Top;
                            string edName = ct_Extr_End;

                            // �󒍎҃R�[�h
                            if ((string.IsNullOrEmpty(this._campaignRsltList.AcceptOdrCodeSt) == false) ||
                                (string.IsNullOrEmpty(this._campaignRsltList.AcceptOdrCodeEd) == false))
                            {
                                if (string.IsNullOrEmpty(this._campaignRsltList.AcceptOdrCodeSt) == false)
                                {
                                    stName = this._campaignRsltList.AcceptOdrCodeSt;
                                }
                                if (string.IsNullOrEmpty(this._campaignRsltList.AcceptOdrCodeEd) == false)
                                {
                                    edName = this._campaignRsltList.AcceptOdrCodeEd;
                                }
                                this.EditCondition(ref addConditions,
                                    string.Format("�󒍎�" + ct_RangeConst, stName, edName)
                                );
                            }
                        }

                        // ���Ӑ�R�[�h
                        if ((this._campaignRsltList.CustomerCodeSt != 0) ||
                            (this._campaignRsltList.CustomerCodeEd != 0))
                        {
                            string stName = ct_Extr_Top;
                            string edName = ct_Extr_End;

                            if (this._campaignRsltList.CustomerCodeSt != 0)
                            {
                                stName = this._campaignRsltList.CustomerCodeSt.ToString("d8");
                            }
                            if ((this._campaignRsltList.CustomerCodeEd != 0))
                            {
                                edName = this._campaignRsltList.CustomerCodeEd.ToString("d8");
                            }

                            this.EditCondition(ref addConditions,
                                string.Format("���Ӑ�" + ct_RangeConst, stName, edName)
                            );
                        }
                    }
                    break;

                case CampaignRsltList.TotalTypeState.EachPrinter: //���s�ҕ�
                    {
                        // ���s�҃R�[�h
                        if (!string.IsNullOrEmpty(this._campaignRsltList.PrinterCodeSt)
                            || !string.IsNullOrEmpty(this._campaignRsltList.PrinterCodeEd))
                        {

                            string stName = ct_Extr_Top;
                            string edName = ct_Extr_End;

                            // ���s�҃R�[�h
                            if ((string.IsNullOrEmpty(this._campaignRsltList.PrinterCodeSt) == false) ||
                                (string.IsNullOrEmpty(this._campaignRsltList.PrinterCodeEd) == false))
                            {
                                if (string.IsNullOrEmpty(this._campaignRsltList.PrinterCodeSt) == false)
                                {
                                    stName = this._campaignRsltList.PrinterCodeSt;
                                }
                                if (string.IsNullOrEmpty(this._campaignRsltList.PrinterCodeEd) == false)
                                {
                                    edName = this._campaignRsltList.PrinterCodeEd;
                                }
                                this.EditCondition(ref addConditions,
                                    string.Format("���s��" + ct_RangeConst, stName, edName)
                                );
                            }
                        }

                        // ���Ӑ�R�[�h
                        if ((this._campaignRsltList.CustomerCodeSt != 0) ||
                            (this._campaignRsltList.CustomerCodeEd != 0))
                        {
                            string stName = ct_Extr_Top;
                            string edName = ct_Extr_End;

                            if (this._campaignRsltList.CustomerCodeSt != 0)
                            {
                                stName = this._campaignRsltList.CustomerCodeSt.ToString("d8");
                            }
                            if ((this._campaignRsltList.CustomerCodeEd != 0))
                            {
                                edName = this._campaignRsltList.CustomerCodeEd.ToString("d8");
                            }

                            this.EditCondition(ref addConditions,
                                string.Format("���Ӑ�" + ct_RangeConst, stName, edName)
                            );
                        }
                    }
                    break;
                case CampaignRsltList.TotalTypeState.EachArea: // �n���
                    {
                        //�n��R�[�h
                        if ((this._campaignRsltList.AreaCodeSt != 0) ||
                            (this._campaignRsltList.AreaCodeEd != 0))
                        {

                            string stName = ct_Extr_Top;
                            string edName = ct_Extr_End;

                            //�n��R�[�h
                            if ((this._campaignRsltList.AreaCodeSt != 0) || this._campaignRsltList.AreaCodeEd != 0)
                            {
                                if (this._campaignRsltList.AreaCodeSt != 0)
                                {
                                    stName = this._campaignRsltList.AreaCodeSt.ToString("d4");
                                }
                                if (this._campaignRsltList.AreaCodeEd != 0)
                                {
                                    edName = this._campaignRsltList.AreaCodeEd.ToString("d4");
                                }
                                this.EditCondition(ref addConditions,
                                    string.Format("�n��" + ct_RangeConst, stName, edName)
                                );
                            }
                        }

                        //���Ӑ�R�[�h
                        if ((this._campaignRsltList.CustomerCodeSt != 0) ||
                            (this._campaignRsltList.CustomerCodeEd != 0))
                        {
                            string stName = ct_Extr_Top;
                            string edName = ct_Extr_End;

                            if (this._campaignRsltList.CustomerCodeSt != 0)
                            {
                                stName = this._campaignRsltList.CustomerCodeSt.ToString("d8");
                            }
                            if (this._campaignRsltList.CustomerCodeEd != 0)
                            {
                                edName = this._campaignRsltList.CustomerCodeEd.ToString("d8");
                            }

                            this.EditCondition(ref addConditions,
                                string.Format("���Ӑ�" + ct_RangeConst, stName, edName)
                            );
                        }
                    }
                    break;

                case CampaignRsltList.TotalTypeState.EachSales:
                    {
                        //�̔��敪�R�[�h
                        if ((this._campaignRsltList.SalesCodeSt != 0) ||
                            ((this._campaignRsltList.SalesCodeEd != 0)))
                        {
                            string stName = ct_Extr_Top;
                            string edName = ct_Extr_End;

                            //�̔��敪�R�[�h
                            if ((this._campaignRsltList.SalesCodeSt != 0) ||
                                (this._campaignRsltList.SalesCodeEd != 0))
                            {
                                if (this._campaignRsltList.SalesCodeSt != 0)
                                {
                                    stName = this._campaignRsltList.SalesCodeSt.ToString("d4");
                                }
                                if (this._campaignRsltList.SalesCodeEd != 0)
                                {
                                    edName = this._campaignRsltList.SalesCodeEd.ToString("d4");
                                }
                                this.EditCondition(ref addConditions,
                                    string.Format("�̔��敪" + ct_RangeConst, stName, edName)
                                );
                            }
                        }
                        //���Ӑ�R�[�h
                        if ((this._campaignRsltList.CustomerCodeSt != 0) ||
                            (this._campaignRsltList.CustomerCodeEd != 0))
                        {
                            string stName = ct_Extr_Top;
                            string edName = ct_Extr_End;

                            if (this._campaignRsltList.CustomerCodeSt != 0)
                            {
                                stName = this._campaignRsltList.CustomerCodeSt.ToString("d8");
                            }
                            if ((this._campaignRsltList.CustomerCodeEd != 0))
                            {
                                edName = this._campaignRsltList.CustomerCodeEd.ToString("d8");
                            }

                            this.EditCondition(ref addConditions,
                                string.Format("���Ӑ�" + ct_RangeConst, stName, edName)
                            );
                        }
                    }
                    break;
                default:
                    break;
            }
			
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
		/// <br>Programmer : �c����</br>
		/// <br>Date       : 2011/05/19</br>
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
		/// <br>Programmer : �c����</br>
		/// <br>Date       : 2011/05/19</br>
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
		/// <br>Programmer : �c����</br>
		/// <br>Date       : 2011/05/19</br>
		/// </remarks>
		private DialogResult MsgDispProc(emErrorLevel iLevel, string iMsg, int iSt, MessageBoxButtons iButton, MessageBoxDefaultButton iDefButton)
		{
			return TMsgDisp.Show(iLevel, "DCTOK02152P", iMsg, iSt, iButton, iDefButton);
		}

		#endregion
		#endregion
	}
}
