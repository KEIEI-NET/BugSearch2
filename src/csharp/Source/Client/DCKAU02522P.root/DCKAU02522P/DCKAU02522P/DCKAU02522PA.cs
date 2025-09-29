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
	/// ����\��\����N���X
	/// </summary>
	/// <remarks>
    /// <br>Note       : ����\��\�̈�����s���B</br>
	/// <br>Programmer : 20081 �D�c �E�l</br>
	/// <br>Date       : 2007.10.23</br>
    /// -----------------------------------------------------------------------------------
    /// <br>UpdateNote : PM.NS�Ή�</br>
    /// <br>Programmer : 30413 ����</br>
    /// <br>Date	   : 2008.11.11</br>
    /// -----------------------------------------------------------------------------------
    /// <br>UpdateNote : PM.NS�Ή�</br>
    /// <br>Programmer : 30414 �E</br>
    /// <br>Date	   : 2009.02.24</br>
    /// -----------------------------------------------------------------------------------
    /// <br>UpdateNote : #13691�̑Ή�</br>
    /// <br>Programmer : �k���r</br>
    /// <br>Date	   : 2010/08/26</br>
    /// <br></br>
    /// <br>UpdateNote : 2011/04/11  22018 ��� ���b</br>
    /// <br>           : �t�H���g�T�C�Y��傫������ׂɁA�󎚌������ǉ��B</br>
    /// </remarks>
	class DCKAU02522PA: IPrintProc
	{

		#region �� Constructor
		/// <summary>
		/// ����\��\����N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
		/// <br>Note       : ����\��\����N���X�̃C���X�^���X�̍쐬���s���B</br>
		/// <br>Programmer : 20081 �D�c �E�l</br>
		/// <br>Date       : 2007.10.23</br>
		/// </remarks>
		public DCKAU02522PA()
		{
		}

		/// <summary>
		/// ����\��\����N���X�R���X�g���N�^
		/// </summary>
		/// <param name="printInfo">������I�u�W�F�N�g</param>
		/// <remarks>
		/// <br>Note       : ����\��\����N���X�̃C���X�^���X�̍쐬���s���B</br>
		/// <br>Programmer : 20081 �D�c �E�l</br>
		/// <br>Date       : 2007.10.23</br>
		/// </remarks>
		public DCKAU02522PA( object printInfo )
		{
			this._printInfo = printInfo as SFCMN06002C;
            this._rsltInfo_CollectPlan = this._printInfo.jyoken as RsltInfo_CollectPlan;
		}
		#endregion �� Constructor

		#region �� Pricate Const
		private const string ct_ReportForm_NameSpace = "Broadleaf.Drawing.Printing";
		private const string ct_Space			= "�@";
		private const string ct_Extr_Top		= "�ŏ�����";
		private const string ct_Extr_End		= "�Ō�܂�";
		#endregion �� Pricate Const

		#region �� Private Member
		private SFCMN06002C _printInfo;					    // ������N���X
        private RsltInfo_CollectPlan _rsltInfo_CollectPlan;	// ���o�����N���X
		#endregion �� Private Member

        // 2008.11.21 30413 ���� �o�͏��̃v���p�e�B�ύX >>>>>>START
        private string CT_Sort1_Odr = "AddUpSecCode, ClaimCode";                                        // ���_+���Ӑ�
        private string CT_Sort2_1_Odr = "AddUpSecCode, CustomerAgentCd, ClaimCode"; �@                  // ���_+���Ӑ�S����+���Ӑ�
        private string CT_Sort2_2_Odr = "AddUpSecCode, BillCollecterCd, ClaimCode"; �@                  // ���_+�W���S����+���Ӑ�
        private string CT_Sort3_Odr = "AddUpSecCode, SalesAreaCode, ClaimCode";                         // ���_+�n��+���Ӑ�
        private string CT_Sort4_1_Odr = "AddUpSecCode, CustomerAgentCd, CalcCollectDay, ClaimCode"; �@  // ���_+���Ӑ�S����+��������+���Ӑ�
        private string CT_Sort4_2_Odr = "AddUpSecCode, BillCollecterCd, CalcCollectDay, ClaimCode";     // ���_+�W���S����+��������+���Ӑ�
        private string CT_Sort5_Odr = "AddUpSecCode, SalesAreaCode, CalcCollectDay, ClaimCode"; �@      // ���_+�n��+��������+���Ӑ�
        private string CT_Sort6_Odr = "AddUpSecCode, CalcCollectDay, ClaimCode";                        // ���_+��������+���Ӑ�
        private string CT_Sort7_Odr = "AddUpSecCode, CalcCollectDay, CollectCond, ClaimCode";           // ���_+��������+�������+���Ӑ�
        // 2008.11.21 30413 ���� �o�͏��̃v���p�e�B�ύX <<<<<<END

		#region �� Exception Class
		/// <summary> ��O�N���X </summary>
        private class CollectPlanMainException: ApplicationException
		{
			private int _status;
			#region �� Constructor
			/// <summary>
			/// ��O�N���X�R���X�g���N�^
			/// </summary>
			/// <param name="message">���b�Z�[�W</param>
			/// <param name="status">�X�e�[�^�X</param>
			public CollectPlanMainException(string message, int status): base(message)
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
		/// <br>Programmer : 20081 �D�c �E�l</br>
		/// <br>Date       : 2007.10.23</br>
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
		/// <br>Programmer : 20081 �D�c �E�l</br>
		/// <br>Date       : 2007.10.23</br>
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

                // --- ADD m.suzuki 2011/04/11 ---------->>>>>
                PMCMN02000CA reportCtrl = PMCMN02000CA.GetInstance();
                reportCtrl.SetReportProps( ref prtRpt, PMCMN02000CA.SetReportPropsKind.NormalList );
                // --- ADD m.suzuki 2011/04/11 ----------<<<<<

                // 2008.11.21 30413 ���� �f�[�^�\�[�X�ݒ莞�ɏo�͏��Ƀ\�[�g�N�G����ݒ� >>>>>>START
                // �f�[�^�\�[�X�ݒ�
                //prtRpt.DataSource = (DataSet)this._printInfo.rdData;
                prtRpt.DataMember = DCKAU02524EA.Col_Tbl_RsltInfo_CollectPlan;

                // 2008.12.16 30413 ���� �t�B���^�[�ǉ��̂��߁A�f�[�^�r���[�ɕύX >>>>>>START
                // ����f�[�^�擾
                //DataSet ds = (DataSet)this._printInfo.rdData;
                //dv.Table = ds.Tables[DCKAU02524EA.Col_Tbl_RsltInfo_CollectPlan];
                DataView dv = (DataView)this._printInfo.rdData;
                // 2008.12.16 30413 ���� �t�B���^�[�ǉ��̂��߁A�f�[�^�r���[�ɕύX <<<<<<END
        
                // �\�[�g���ݒ�
                dv.Sort = this.GetPrintOderQuerry();

                // �f�[�^�\�[�X�ݒ�
                prtRpt.DataSource = dv;
                // 2008.11.21 30413 ���� �f�[�^�\�[�X�ݒ莞�ɏo�͏��Ƀ\�[�g�N�G����ݒ� <<<<<<END

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
		/// <br>Programmer : 20081 �D�c �E�l</br>
		/// <br>Date       : 2007.10.23</br>
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
		/// <br>Programmer : 20081 �D�c �E�l</br>
		/// <br>Date       : 2007.10.23</br>
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
				throw new CollectPlanMainException(asmname + "�����݂��܂���B",-1);
			}
			catch(System.Exception er)
			{
				throw new CollectPlanMainException(er.Message, -1);
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
		/// <br>Programmer : 20081 �D�c �E�l</br>
		/// <br>Date       : 2007.10.23</br>
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
            //commonInfo.PrintMax    = 0;
            int maxCount = 0;
            if (this._printInfo.rdData is DataView)
            {
                maxCount = (this._printInfo.rdData as DataView).Count;
            }
            commonInfo.PrintMax = maxCount;
			
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
		/// <br>Programmer : 20081 �D�c �E�l</br>
		/// <br>Date       : 2007.10.23</br>
		/// </remarks>
		private int SettingProperty(ref DataDynamics.ActiveReports.ActiveReport3 rpt)
		{
			int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;

			// ActiveReport�C���^�[�t�F�[�X�ɃL���X�g
			IPrintActiveReportTypeList instance = rpt as IPrintActiveReportTypeList;

			// ��������擾
            RsltInfo_CollectPlan extraInfo = (RsltInfo_CollectPlan)this._printInfo.jyoken;

			// �\�[�g���v���p�e�B�ݒ�
			instance.PageHeaderSortOderTitle = GetSortOrderName( extraInfo );
			
			// ���[�o�͐ݒ���擾 
			PrtOutSet prtOutSet;
			string message;
            int st = CollectPlanAcs.ReadPrtOutSet(out prtOutSet, out message);
			if (st != 0) 
			{
                throw new CollectPlanMainException(message, status);
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
            instance.PageHeaderSubtitle = this._rsltInfo_CollectPlan.PrintDivName;

			// ���̑��f�[�^
			ArrayList otherDataList = new ArrayList();
			otherDataList.Add(this._rsltInfo_CollectPlan.EmployeeKindDivName);		// �S���҃^�C�g������

			// �S�Ђ��I������Ă����疾�ׂɋ��_���̂��o���B
			if ( this._rsltInfo_CollectPlan.IsSelectAllSection )
			{
				otherDataList.Add("�x���v�㋒�_");		// ���׋��_���̃^�C�g��
			}
			else
			{
				otherDataList.Add( string.Empty );		// ���׋��_���̃^�C�g��
			}
			instance.OtherDataList = otherDataList;

			status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

			return status;
		}

		#endregion

		#region �� �\�[�g�����̎擾
		/// <summary>
		/// �\�[�g�����̎擾
		/// </summary>
		/// <param name="rsltInfo_CollectPlan">���o����</param>
		/// <returns>�\�[�g������</returns>
		/// <remarks>
		/// <br>Note       : �\�[�g�����̂��擾����B</br>
		/// <br>Programmer : 20081 �D�c �E�l</br>
		/// <br>Date       : 2007.10.23</br>
		/// </remarks>
        private string GetSortOrderName(RsltInfo_CollectPlan rsltInfo_CollectPlan)
		{
			string sortOrderName = string.Empty;
            sortOrderName = "[" + rsltInfo_CollectPlan.SortOrderDivName + "]";
			return sortOrderName;
		}
		#endregion

		#region �� ���o�����o�͏��쐬
		/// <summary>
		/// ���o�����o�͏��쐬
		/// </summary>
		/// <param name="extraConditions">�쐬�㒊�o�����R���N�V����</param>
		/// <remarks>
		/// <br>Note       : �o�͂��钊�o������������쐬����B</br>
		/// <br>Programmer : 20081 �D�c �E�l</br>
		/// <br>Date       : 2007.10.23</br>
        /// <br>Update Note : 2010/08/26 �k���r #13691�̑Ή�</br>
        /// </remarks>
		private void MakeExtarCondition( out StringCollection extraConditions )
		{
			extraConditions = new StringCollection();

            // 2008.11.20 30413 ���� ���o�����o�͂̕ύX >>>>>>START
            string target = "";
            StringCollection addConditions = new StringCollection();

			// ������ ----------------------------------------------------------------------------------------------------
			string addUpADate = string.Empty;
			
			if ( this._rsltInfo_CollectPlan.AddUpDate != DateTime.MinValue )
                addUpADate = TDateTime.DateTimeToString(RsltInfo_CollectPlan.ct_DateFomat, this._rsltInfo_CollectPlan.AddUpDate);
			else
				addUpADate = "";

            //this.EditCondition(ref extraConditions, string.Format( "�������@" + addUpADate ) );
            this.EditCondition(ref addConditions, string.Format("�������F" + addUpADate));

            //StringCollection addConditions = new StringCollection();

            //// ���Ӑ��R�[�h ----------------------------------------------------------------------------------------------------
            //if ((this._rsltInfo_CollectPlan.St_ClaimCode != 0) || (this._rsltInfo_CollectPlan.Ed_ClaimCode != 0))
            //{
            //    string st_ClaimCode_Top = string.Empty;
            //    string ed_ClaimCode_End = string.Empty;

            //    if (this._rsltInfo_CollectPlan.St_ClaimCode == 0)
            //    {
            //        st_ClaimCode_Top = ct_Extr_Top;
            //    }
            //    else
            //    {
            //        st_ClaimCode_Top = string.Format("{0:000000000}", this._rsltInfo_CollectPlan.St_ClaimCode);
            //    }

            //    if (this._rsltInfo_CollectPlan.Ed_ClaimCode == 0)
            //    {
            //        ed_ClaimCode_End = ct_Extr_End;
            //    }
            //    else
            //    {
            //        ed_ClaimCode_End = string.Format("{0:000000000}", this._rsltInfo_CollectPlan.Ed_ClaimCode);
            //    }

            //    this.EditCondition(ref addConditions,
            //        string.Format("���Ӑ�R�[�h�F{0} �` {1}", st_ClaimCode_Top, ed_ClaimCode_End));
            //}
            //// �S���҃R�[�h ----------------------------------------------------------------------------------------------------
            //if ( ( this._rsltInfo_CollectPlan.St_EmployeeCode != string.Empty ) || ( this._rsltInfo_CollectPlan.Ed_EmployeeCode != string.Empty ) )
            //{
            //    this.EditCondition( ref addConditions, 
            //        GetConditionRange( this._rsltInfo_CollectPlan.EmployeeKindDivName + "�҃R�[�h", this._rsltInfo_CollectPlan.St_EmployeeCode, this._rsltInfo_CollectPlan.Ed_EmployeeCode ) );
            //}

            // ����
            if (this._rsltInfo_CollectPlan.TotalDay == 0)
            {
                // ����������
                this.EditCondition(ref addConditions, "�����F�S����");
            }
            else
            {
                //-----UPD 2010/08/26 ---------->>>>>
                if (this._rsltInfo_CollectPlan.TotalDay == 31)
                {
                    target = "�����F����";
                }
                else
                {
                    target = "�����F" + this._rsltInfo_CollectPlan.TotalDay.ToString("d02") + "��";
                }
                //target = "�����F" + this._rsltInfo_CollectPlan.TotalDay.ToString("d02") + "��";
                //-----UPD 2010/08/26 ----------<<<<<
                this.EditCondition(ref addConditions, target);
            }

            // �����
            if (this._rsltInfo_CollectPlan.ExpectedDepositDate == 0)
            {
                // �����������
                this.EditCondition(ref addConditions, "������F�S�����");
            }
            else
            {
                //-----UPD 2010/08/26 ---------->>>>>
                if (this._rsltInfo_CollectPlan.ExpectedDepositDate == 31)
                {
                    target = "������F����";
                }
                else
                {
                    target = "������F" + this._rsltInfo_CollectPlan.ExpectedDepositDate.ToString("d02") + "��";
                }
                //target = "������F" + this._rsltInfo_CollectPlan.ExpectedDepositDate.ToString("d02") + "��";
                //-----UPD 2010/08/26 ----------<<<<<
                this.EditCondition(ref addConditions, target);
            }

			// ������� ----------------------------------------------------------------------------------------------------
            if (!this._rsltInfo_CollectPlan.CollectCond.ContainsKey(RsltInfo_CollectPlan.ct_All_Code))
			{
                this.EditCondition(ref addConditions, "��������F" + GetCollectCondDivName());
			}

            // �S���҃R�[�h
            if (this._rsltInfo_CollectPlan.St_EmployeeCode.Trim() != "" || this._rsltInfo_CollectPlan.Ed_EmployeeCode.Trim() != "")
            {
                string startEmpCode = "";
                if (this._rsltInfo_CollectPlan.St_EmployeeCode.Trim() == "")
                {
                    startEmpCode = ct_Extr_Top;
                }
                else
                {
                    startEmpCode = this._rsltInfo_CollectPlan.St_EmployeeCode;
                }

                string endEmpCode = "";
                if (this._rsltInfo_CollectPlan.Ed_EmployeeCode.Trim() == "")
                {
                    endEmpCode = ct_Extr_End;
                }
                else
                {
                    endEmpCode = this._rsltInfo_CollectPlan.Ed_EmployeeCode;
                }

                string title = "";
                title = this._rsltInfo_CollectPlan.EmployeeKindDivName + "�ҁF";
                target = title + startEmpCode + " �` " + endEmpCode;
                this.EditCondition(ref addConditions, target);
            }

            // �n��
            if ((this._rsltInfo_CollectPlan.St_SalesAreaCode == 0) && (this._rsltInfo_CollectPlan.Ed_SalesAreaCode != 0))
            {
                target = "�n��: " + ct_Extr_Top + " �` " + this._rsltInfo_CollectPlan.Ed_SalesAreaCode.ToString("d04");
                this.EditCondition(ref addConditions, target);
            }

            if ((this._rsltInfo_CollectPlan.St_SalesAreaCode > 0) && (this._rsltInfo_CollectPlan.Ed_SalesAreaCode == 0))
            {
                target = "�n��: " + this._rsltInfo_CollectPlan.St_SalesAreaCode.ToString("d04") + " �` " + ct_Extr_End;
                this.EditCondition(ref addConditions, target);
            }

            if ((this._rsltInfo_CollectPlan.St_SalesAreaCode > 0) && (this._rsltInfo_CollectPlan.Ed_SalesAreaCode != 0))
            {
                target = "�n��: " + this._rsltInfo_CollectPlan.St_SalesAreaCode.ToString("d04") + " �` " + this._rsltInfo_CollectPlan.Ed_SalesAreaCode.ToString("d04");
                this.EditCondition(ref addConditions, target);
            }

            // ���Ӑ�R�[�h
            if (this._rsltInfo_CollectPlan.St_ClaimCode != 0 || this._rsltInfo_CollectPlan.Ed_ClaimCode != 0)
            {
                string startCode = "";
                if (this._rsltInfo_CollectPlan.St_ClaimCode == 0)
                {
                    startCode = ct_Extr_Top;
                }
                else
                {
                    startCode = this._rsltInfo_CollectPlan.St_ClaimCode.ToString("d08");
                }

                string endCode = "";
                if (this._rsltInfo_CollectPlan.Ed_ClaimCode == 0)
                {
                    endCode = ct_Extr_End;
                }
                else
                {
                    endCode = this._rsltInfo_CollectPlan.Ed_ClaimCode.ToString("d08");
                }
                target = "���Ӑ�F" + startCode + " �` " + endCode;
                this.EditCondition(ref addConditions, target);
            }
            // 2008.11.20 30413 ���� ���o�����o�͂̕ύX <<<<<<END

            //// --- ADD 2009/02/24 ��QID:10843�Ή�------------------------------------------------------>>>>>
            //// ����敪
            //if (this._rsltInfo_CollectPlan.PrintExpctDiv == 0)
            //{
            //    this.EditCondition(ref addConditions, "����敪�F�\��z��0�ł��󎚂���");
            //}
            //else
            //{
            //    this.EditCondition(ref addConditions, "����敪�F�\��z��0�͈󎚂��Ȃ�");
            //}
            //// --- ADD 2009/02/24 ��QID:10843�Ή�------------------------------------------------------<<<<<
			
			foreach ( string exCondStr in addConditions )
			{
				extraConditions.Add( exCondStr );
			}

		}
		#endregion

		#region �� ��������̕�����쐬
		/// <summary>
		/// ����������̕�����쐬
		/// </summary>
		/// <returns>�쐬������</returns>
		/// <remarks>
		/// <br>Note       : ���o�͈͕�������쐬���܂�</br>
		/// <br>Programmer : 20081 �D�c �E�l</br>
		/// <br>Date       : 2007.10.23</br>
		/// </remarks>
        private string GetCollectCondDivName()
		{
			StringBuilder result = new StringBuilder();

            foreach (string corpName in this._rsltInfo_CollectPlan.CollectCond.Values)
			{
				if ( result.ToString().CompareTo( string.Empty ) != 0 )
				{
					result.Append("�A");
				}
				result.Append( corpName );
			}

			return result.ToString();
		}
		#endregion

		#region �� ���o�͈͕�����쐬
		/// <summary>
		/// ���o�͈͕�����쐬
		/// </summary>
		/// <returns>�쐬������</returns>
		/// <remarks>
		/// <br>Note       : ���o�͈͕�������쐬���܂�</br>
		/// <br>Programmer : 20081 �D�c �E�l</br>
		/// <br>Date       : 2007.10.23</br>
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
				result = String.Format(title + "�F {0} �` {1}", start, end);
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
		/// <br>Programmer : 20081 �D�c �E�l</br>
		/// <br>Date       : 2007.10.23</br>
		/// </remarks>
		private void EditCondition(ref StringCollection editArea, string target)
		{
			bool isEdit = false;
			
			// �ҏW�Ώە����o�C�g���Z�o
			int targetByte = TStrConv.SizeCountSJIS(target);

            // 2008.11.20 30413 ���� ���o������K�X���s����悤�ɏC�� >>>>>>START
            //for (int i = 0; i < editArea.Count; i++)
            //{
            //    int areaByte = 0;
				
            //    // �i�[�G���A�̃o�C�g���Z�o
            //    if (editArea[i] != null)
            //    {
            //        areaByte = TStrConv.SizeCountSJIS(editArea[i]);
            //    }

            //    if ((areaByte + targetByte + 2) <= 190)
            //    {
            //        isEdit = true;

            //        // �S�p�X�y�[�X��}��
            //        if (editArea[i] != null) editArea[i] += ct_Space;
					
            //        editArea[i]  += target;
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

                if ((areaByte + targetByte + 2) >= 140)
                {
                    // ���s
                    editArea[index] += "\n";
                }
                else
                {
                    isEdit = true;

                    // �S�p�X�y�[�X��}��
                    if (editArea[index] != null) editArea[index] += ct_Space;

                    editArea[index] += target;
                }
            }
            // 2008.11.20 30413 ���� ���o������K�X���s����悤�ɏC�� <<<<<<END

			// �V�K�ҏW�G���A�쐬
			if (!isEdit)
			{
				editArea.Add(target);
			}
		}
		#endregion
		#endregion �� ���|�[�g�t�H�[���ݒ�֘A

        #region ���@������N�G���쐬�֐�
        /// <summary>
        /// �󎚏��N�G���쐬����
        /// </summary>
        /// <returns>�쐬�����N�G��</returns>
        /// <remarks>
        /// <br>Note       : DataView�ɐݒ肷��󎚏��ʂ̃N�G�����쐬���܂��B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2008.11.21</br>
        /// </remarks>
        private string GetPrintOderQuerry()
        {
            string oderQuerry = "";

            switch (this._rsltInfo_CollectPlan.SortOrderDiv)
            {
                case RsltInfo_CollectPlan.SortOrderDivState.CustomerCode:
                    {
                        oderQuerry = CT_Sort1_Odr;
                        break;
                    }
                case RsltInfo_CollectPlan.SortOrderDivState.EmployeeCode:
                    {
                        if (this._rsltInfo_CollectPlan.EmployeeKindDiv == 0)
                        {
                            // ���Ӑ�S��
                            oderQuerry = CT_Sort2_1_Odr;
                        }
                        else
                        {
                            // �W���S��
                            oderQuerry = CT_Sort2_2_Odr;
                        }
                        break;
                    }
                case RsltInfo_CollectPlan.SortOrderDivState.SalesAreaCode:
                    {
                        oderQuerry = CT_Sort3_Odr;
                        break;
                    }
                case RsltInfo_CollectPlan.SortOrderDivState.EmployeeCollect:
                    {
                        if (this._rsltInfo_CollectPlan.EmployeeKindDiv == 0)
                        {
                            // ���Ӑ�S��
                            oderQuerry = CT_Sort4_1_Odr;
                        }
                        else
                        {
                            // �W���S��
                            oderQuerry = CT_Sort4_2_Odr;
                        }
                        break;
                    }
                case RsltInfo_CollectPlan.SortOrderDivState.SalesAreaCollect:
                    {
                        oderQuerry = CT_Sort5_Odr;
                        break;
                    }
                case RsltInfo_CollectPlan.SortOrderDivState.CollectMoneyDay:
                    {
                        oderQuerry = CT_Sort6_Odr;
                        break;
                    }
                case RsltInfo_CollectPlan.SortOrderDivState.CollectMoneyDayCond:
                    {
                        oderQuerry = CT_Sort7_Odr;
                        break;
                    }
            }

            return oderQuerry;
        }
        #endregion

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
		/// <br>Programmer : 20081 �D�c �E�l</br>
		/// <br>Date       : 2007.10.23</br>
		/// </remarks>
		private DialogResult MsgDispProc(emErrorLevel iLevel, string iMsg, int iSt, MessageBoxButtons iButton, MessageBoxDefaultButton iDefButton)
		{
			return TMsgDisp.Show(iLevel, "DCKAU02522P", iMsg, iSt, iButton, iDefButton);
		}

		#endregion
		#endregion
	}
}
