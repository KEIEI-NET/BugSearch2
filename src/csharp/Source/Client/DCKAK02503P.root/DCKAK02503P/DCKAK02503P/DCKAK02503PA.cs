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
	/// �x���ꗗ�\����N���X
	/// </summary>
	/// <remarks>
    /// <br>Note       : �x���ꗗ�\�̈�����s���B</br>
	/// <br>Programmer : 20081 �D�c �E�l</br>
	/// <br>Date       : 2007.09.10</br>
    /// -----------------------------------------------------------------------------------
    /// <br>UpdateNote : PM.NS�Ή�</br>
    /// <br>Programmer : 30413 ����</br>
    /// <br>Date	   : 2008.11.06</br>
    /// <br></br>
    /// </remarks>
	class DCKAK02503PA: IPrintProc
	{

		#region �� Constructor
		/// <summary>
		/// �x���ꗗ�\����N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
		/// <br>Note       : �x���ꗗ�\����N���X�̃C���X�^���X�̍쐬���s���B</br>
		/// <br>Programmer : 20081 �D�c �E�l</br>
		/// <br>Date       : 2007.09.10</br>
		/// </remarks>
		public DCKAK02503PA()
		{
		}

		/// <summary>
		/// �x���ꗗ�\����N���X�R���X�g���N�^
		/// </summary>
		/// <param name="printInfo">������I�u�W�F�N�g</param>
		/// <remarks>
		/// <br>Note       : �x���ꗗ�\����N���X�̃C���X�^���X�̍쐬���s���B</br>
		/// <br>Programmer : 20081 �D�c �E�l</br>
		/// <br>Date       : 2007.09.10</br>
		/// </remarks>
		public DCKAK02503PA( object printInfo )
		{
			this._printInfo = printInfo as SFCMN06002C;
            this._suplierPayMainCndtn = this._printInfo.jyoken as SuplierPayMainCndtn;
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
        private SuplierPayMainCndtn _suplierPayMainCndtn;	// ���o�����N���X
		#endregion �� Private Member

		#region �� Exception Class
		/// <summary> ��O�N���X </summary>
        private class SuplierPayMainException: ApplicationException
		{
			private int _status;
			#region �� Constructor
			/// <summary>
			/// ��O�N���X�R���X�g���N�^
			/// </summary>
			/// <param name="message">���b�Z�[�W</param>
			/// <param name="status">�X�e�[�^�X</param>
			public SuplierPayMainException(string message, int status): base(message)
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
		/// <br>Date       : 2007.09.10</br>
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
		/// <br>Date       : 2007.09.10</br>
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

                // 2008.11.14 30413 ���� �x�������ɂ��t�B���^�[���� >>>>>>START
                // ����f�[�^�擾
                DataSet ds = (DataSet)this._printInfo.rdData;
                DataView dv = new DataView();
                dv = ds.Tables[DCKAK02505EA.Col_Tbl_SuplierPayMain].DefaultView;

				// �f�[�^�\�[�X�ݒ�
                //prtRpt.DataSource = (DataSet)this._printInfo.rdData;
                //prtRpt.DataMember = DCKAK02505EA.Col_Tbl_SuplierPayMain;
                prtRpt.DataSource = dv;
                // 2008.11.14 30413 ���� �x�������ɂ��t�B���^�[���� <<<<<<END
                
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
		/// <br>Date       : 2007.09.10</br>
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
		/// <br>Date       : 2007.09.10</br>
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
				throw new SuplierPayMainException(asmname + "�����݂��܂���B",-1);
			}
			catch(System.Exception er)
			{
				throw new SuplierPayMainException(er.Message, -1);
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
		/// <br>Date       : 2007.09.10</br>
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
            // 2009.02.16 30413 ���� ���������ݒ� >>>>>>START
            commonInfo.PrintMax = 0;
            int maxCount = 0;
            foreach (object obj in (this._printInfo.rdData as DataSet).Tables)
            {
                if (obj is DataTable && (obj as DataTable).TableName == DCKAK02505EA.Col_Tbl_SuplierPayMain)
                {
                    maxCount = (obj as DataTable).DefaultView.Count;
                    break;
                }
            }
            commonInfo.PrintMax = maxCount;
            // 2009.02.16 30413 ���� ���������ݒ� <<<<<<END

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
		/// <br>Date       : 2007.09.10</br>
		/// </remarks>
		private int SettingProperty(ref DataDynamics.ActiveReports.ActiveReport3 rpt)
		{
			int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;

			// ActiveReport�C���^�[�t�F�[�X�ɃL���X�g
			IPrintActiveReportTypeList instance = rpt as IPrintActiveReportTypeList;

			// ��������擾
            SuplierPayMainCndtn extraInfo = (SuplierPayMainCndtn)this._printInfo.jyoken;

			// ���[�o�͐ݒ���擾 
			PrtOutSet prtOutSet;
			string message;
            int st = SuplierPayMainAcs.ReadPrtOutSet(out prtOutSet, out message);
			if (st != 0) 
			{
                throw new SuplierPayMainException(message, status);
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
			instance.PageHeaderSubtitle = this._suplierPayMainCndtn.PrintDivName;

			// ���̑��f�[�^
			ArrayList otherDataList = new ArrayList();

			// �S�Ђ��I������Ă����疾�ׂɋ��_���̂��o���B
			if ( this._suplierPayMainCndtn.IsSelectAllSection )
			{
				otherDataList.Add("�v�㋒�_");		// ���׋��_���̃^�C�g��
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

		#region �� ���o�����o�͏��쐬
		/// <summary>
		/// ���o�����o�͏��쐬
		/// </summary>
		/// <param name="extraConditions">�쐬�㒊�o�����R���N�V����</param>
		/// <remarks>
		/// <br>Note       : �o�͂��钊�o������������쐬����B</br>
		/// <br>Programmer : 20081 �D�c �E�l</br>
		/// <br>Date       : 2007.09.10</br>
		/// </remarks>
		private void MakeExtarCondition( out StringCollection extraConditions )
		{
			const string ct_RangeConst = "�F{0} �` {1}";
			extraConditions = new StringCollection();

            // 2008.11.07 30413 ���� �����̒��o������ύX >>>>>>START
            StringCollection addConditions = new StringCollection();

			// ���� -----------------------------------------------------------------------------------------------------------
            //string st_CAddUpUpdExecDate = string.Empty;
            //string ed_CAddUpUpdExecDate = string.Empty;
            //// �J�n
            //if ( this._suplierPayMainCndtn.St_CAddUpUpdExecDate != DateTime.MinValue )
            //    st_CAddUpUpdExecDate = TDateTime.DateTimeToString(SuplierPayMainCndtn.ct_DateFomat, this._suplierPayMainCndtn.St_CAddUpUpdExecDate);
            //else
            //    st_CAddUpUpdExecDate = ct_Extr_Top;
            //// �I��
            //if ( this._suplierPayMainCndtn.Ed_CAddUpUpdExecDate != DateTime.MinValue )
            //    ed_CAddUpUpdExecDate = TDateTime.DateTimeToString(SuplierPayMainCndtn.ct_DateFomat, this._suplierPayMainCndtn.Ed_CAddUpUpdExecDate);
            //else
            //    ed_CAddUpUpdExecDate = ct_Extr_End;
                       
            //this.EditCondition(ref extraConditions, string.Format("����  " + ct_RangeConst, st_CAddUpUpdExecDate, ed_CAddUpUpdExecDate));

            //StringCollection addConditions = new StringCollection();

            string CAddUpUpdExecDate = TDateTime.DateTimeToString(SuplierPayMainCndtn.ct_DateFomat, this._suplierPayMainCndtn.CAddUpUpdExecDate);
            this.EditCondition(ref addConditions, string.Format("�����F{0}�@����", CAddUpUpdExecDate));

            // 2008.11.07 30413 ���� �����̒��o������ύX <<<<<<END

            // 2008.11.07 30413 ���� �x����̒��o������ύX >>>>>>START
            // �x����R�[�h ----------------------------------------------------------------------------------------------------
			if ( ( this._suplierPayMainCndtn.St_PayeeCode != 0 ) || ( this._suplierPayMainCndtn.Ed_PayeeCode != 0 ) )
			{
                string st_PayeeCode_Top = string.Empty;
                string ed_PayeeCode_End = string.Empty;

                if (this._suplierPayMainCndtn.St_PayeeCode == 0)
                {
                    st_PayeeCode_Top = ct_Extr_Top;
                }
                else
                {
                    //st_PayeeCode_Top = string.Format("{0:000000000}", this._suplierPayMainCndtn.St_PayeeCode);
                    st_PayeeCode_Top = string.Format("{0:000000}", this._suplierPayMainCndtn.St_PayeeCode);
                }

                if (this._suplierPayMainCndtn.Ed_PayeeCode == 0)
                {
                    ed_PayeeCode_End = ct_Extr_End;
                }
                else
                {
                    //ed_PayeeCode_End = string.Format("{0:000000000}", this._suplierPayMainCndtn.Ed_PayeeCode);
                    ed_PayeeCode_End = string.Format("{0:000000}", this._suplierPayMainCndtn.Ed_PayeeCode);
                }

                //this.EditCondition( ref addConditions,
                //    string.Format("�x����R�[�h�F{0} �` {1}", st_PayeeCode_Top, ed_PayeeCode_End));
                this.EditCondition(ref addConditions,
                    string.Format("�d����F{0} �` {1}", st_PayeeCode_Top, ed_PayeeCode_End));
			}
            // 2008.11.07 30413 ���� �x����̒��o������ύX <<<<<<END
            
            foreach (string exCondStr in addConditions)
            {
                extraConditions.Add(exCondStr);
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
		/// <br>Programmer : 20081 �D�c �E�l</br>
		/// <br>Date       : 2007.09.10</br>
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
		/// <br>Date       : 2007.09.10</br>
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
		/// <br>Programmer : 20081 �D�c �E�l</br>
		/// <br>Date       : 2007.09.10</br>
		/// </remarks>
		private DialogResult MsgDispProc(emErrorLevel iLevel, string iMsg, int iSt, MessageBoxButtons iButton, MessageBoxDefaultButton iDefButton)
		{
			return TMsgDisp.Show(iLevel, "DCKAK02503P", iMsg, iSt, iButton, iDefButton);
		}

		#endregion
		#endregion
	}
}
