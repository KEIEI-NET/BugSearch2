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
	/// �����ꗗ�\����N���X
	/// </summary>
	/// <remarks>
    /// <br>Note       : �����ꗗ�\�̈�����s���B</br>
	/// <br>Programmer : 22013 �v�� ����</br>
	/// <br>Date       : 2007.03.08</br>
    /// <br>UpdateNote : 2007.11.14 980035 ���� ��`</br>
    ///                :    �EDC.NS�Ή��i�u�����ꗗ�\�v�ˁu�����m�F�\�v�ɕύX�j
    /// <br>UpdateNote : 2008.03.07 980035 ���� ��`</br>
    /// <br>                �EDC.NS�Ή��i���t�\���C���j</br>
    /// <br>UpdateNote : 2008.07.10 30413 ����</br>
    /// <br>                �EPM.NS�Ή�</br>
    /// <br>UpdateNote : 2008/10/10 30462 �s�V �m���@�o�O�C��</br>
    /// <br>UpdateNote : 2009/01/07 30413 ����</br>
    /// <br>                �E��QID:9649�Ή�</br>
    /// </remarks>
	class MAHNB02012PA: IPrintProc
	{

		#region �� Constructor
		/// <summary>
		/// �����ꗗ�\����N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
		/// <br>Note       : �����ꗗ�\����N���X�̃C���X�^���X�̍쐬���s���B</br>
		/// <br>Programmer : 22013 �v�� ����</br>
		/// <br>Date       : 2007.03.08</br>
		/// </remarks>
		public MAHNB02012PA()
		{
		}

		/// <summary>
		/// �����ꗗ�\����N���X�R���X�g���N�^
		/// </summary>
		/// <param name="printInfo">������I�u�W�F�N�g</param>
		/// <remarks>
		/// <br>Note       : �����ꗗ�\����N���X�̃C���X�^���X�̍쐬���s���B</br>
		/// <br>Programmer : 22013 �v�� ����</br>
		/// <br>Date       : 2007.03.08</br>
		/// </remarks>
		public MAHNB02012PA( object printInfo )
		{
			this._printInfo = printInfo as SFCMN06002C;
			this._depositMainCndtn = this._printInfo.jyoken as DepositMainCndtn;
		}
		#endregion �� Constructor

		#region �� Pricate Const
		private const string ct_ReportForm_NameSpace = "Broadleaf.Drawing.Printing";
		private const string ct_Space			= "�@";
        // 2008.07.11 30413 ���� �yTOP/END�z���y�ŏ�����/�Ō�܂Łz�ɕύX >>>>>>START
        //private const string ct_Extr_Top		= "�s�n�o";
        //private const string ct_Extr_End		= "�d�m�c";
        private const string ct_Extr_Top = "�ŏ�����";
        private const string ct_Extr_End = "�Ō�܂�";
        // 2008.07.11 30413 ���� �yTOP/END�z���y�ŏ�����/�Ō�܂Łz�ɕύX <<<<<<END
        #endregion �� Pricate Const

		#region �� Private Member
		private SFCMN06002C _printInfo;					// ������N���X
		private DepositMainCndtn _depositMainCndtn;		// ���o�����N���X
		#endregion �� Private Member

		#region �� Exception Class
		/// <summary> ��O�N���X </summary>
        private class DepositMainException: ApplicationException
		{
			private int _status;
			#region �� Constructor
			/// <summary>
			/// ��O�N���X�R���X�g���N�^
			/// </summary>
			/// <param name="message">���b�Z�[�W</param>
			/// <param name="status">�X�e�[�^�X</param>
			public DepositMainException(string message, int status): base(message)
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
                // 2008.01.31 �C�� >>>>>>>>>>>>>>>>>>>>
                prtRpt.DataSource = (DataSet)this._printInfo.rdData;
                //// ����f�[�^�擾
                //DataSet ds = (DataSet)this._printInfo.rdData;
                //DataView dv = new DataView();
                //dv.Table = ds.Tables[MAHNB02014EA.ct_Tbl_DepositMain];

                //// �\�[�g���ݒ�
                //dv.Sort = this.GetPrintOderQuerry();

                //// �f�[�^�\�[�X�ݒ�
                //prtRpt.DataSource = dv;
                // 2008.01.31 �C�� <<<<<<<<<<<<<<<<<<<<
                prtRpt.DataMember = MAHNB02014EA.ct_Tbl_DepositMain;

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
				throw new DepositMainException(asmname + "�����݂��܂���B",-1);
			}
			catch(System.Exception er)
			{
				throw new DepositMainException(er.Message, -1);
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
            // --- CHG 2009/01/07 ��QID:9649�Ή�------------------------------------------------------>>>>>
            //commonInfo.PrintMax    = 0;
            DataSet ds = (DataSet)this._printInfo.rdData;
            DataView dv = new DataView();
            dv.Table = ds.Tables[MAHNB02014EA.ct_Tbl_DepositMain];
            commonInfo.PrintMax = dv.Count;
            // --- CHG 2009/01/07 ��QID:9649�Ή�------------------------------------------------------<<<<<
			
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
            DepositMainCndtn extraInfo = (DepositMainCndtn)this._printInfo.jyoken;

			// �\�[�g���v���p�e�B�ݒ�
			instance.PageHeaderSortOderTitle = GetSortOrderName( extraInfo );
			
			// ���[�o�͐ݒ���擾 
			PrtOutSet prtOutSet;
			string message;
			int st = DepositMainAcs.ReadPrtOutSet(out prtOutSet, out message);
			if (st != 0) 
			{
                throw new DepositMainException(message, status);
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
			instance.PageHeaderSubtitle = this._depositMainCndtn.PrintDivName;

			// ���̑��f�[�^
			ArrayList otherDataList = new ArrayList();

            // 2008.07.23 30413 ���� ���v�^�C�g���ƒS���҃^�C�g���̍폜 >>>>>>START
            //otherDataList.Add(this._depositMainCndtn.SumDivPrintName);			// ���v�^�C�g��
            //otherDataList.Add(this._depositMainCndtn.EmployeeKindDivName);		// �S���҃^�C�g������
            // 2008.07.23 30413 ���� ���v�^�C�g���ƒS���҃^�C�g���̍폜 <<<<<<END
            
			// �S�Ђ��I������Ă����疾�ׂɋ��_���̂��o���B
			if ( this._depositMainCndtn.IsSelectAllSection )
			{
				otherDataList.Add("�����v�㋒�_");		// ���׋��_���̃^�C�g��
			}
			else
			{
				otherDataList.Add( string.Empty );		// ���׋��_���̃^�C�g��
			}
            // 2007.11.14 �ǉ� >>>>>>>>>>>>>>>>>>>>
            otherDataList.Add(this._depositMainCndtn.DepositKindCode);          // ��������v���p�e�B
            otherDataList.Add(this._depositMainCndtn.DepositKindName);          // ��������v���p�e�B
            // 2007.11.14 �ǉ� <<<<<<<<<<<<<<<<<<<<


            // 2008.07.11 30413 ���� ���햼�̂��擾 >>>>>>START
            Dictionary<int, string> dicKindName = new Dictionary<int,string>();
            DepositMainAcs depositMainAcs = new DepositMainAcs();
            status = depositMainAcs.SearchKindName(out dicKindName);
            if (status == 0)
            {
                otherDataList.Add(dicKindName);
            }
            // 2008.07.11 30413 ���� ���햼�̂��擾 <<<<<<END
            
            instance.OtherDataList = otherDataList;

            status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

			return status;
		}

		#endregion

		#region �� �\�[�g�����̎擾
		/// <summary>
		/// �\�[�g�����̎擾
		/// </summary>
		/// <param name="depositMainCndtn">���o����</param>
		/// <returns>�\�[�g������</returns>
		/// <remarks>
		/// <br>Note       : �\�[�g�����̂��擾����B</br>
		/// <br>Programmer : 22013 �v�� ����</br>
		/// <br>Date       : 2007.03.08</br>
		/// </remarks>
		private string GetSortOrderName ( DepositMainCndtn depositMainCndtn )
		{
			string sortOrderName = string.Empty;
            // 2008.07.22 30413 ���� �\�[�g��������̕ύX >>>>>>START
            //const string ct_SortFomat = "[{0}{1}]";
            const string ct_SortFomat = "[�\�[�g���F{0}]";
            // 2008.07.22 30413 ���� �\�[�g��������̕ύX <<<<<<END
            switch (depositMainCndtn.PrintDiv)
			{
                // 2008.07.10 30413 ���� ���[��ʂ̕ύX >>>>>>START
                //case (int)DepositMainCndtn.PrintDivState.GrandTotal:			// �����v
                //// 2007.11.14 �ǉ� >>>>>>>>>>>>>>>>>>>>
                //case (int)DepositMainCndtn.PrintDivState.DepositKind:           // ����ʏW�v
                //// 2007.11.14 �ǉ� <<<<<<<<<<<<<<<<<<<<
                //    sortOrderName = string.Empty;
                //    break;
                //// 2007.11.14 �폜 >>>>>>>>>>>>>>>>>>>>
                ////case (int)DepositMainCndtn.PrintDivState.Details_HaveDraw:	// �ڍ׈����L
                //// 2007.11.14 �폜 <<<<<<<<<<<<<<<<<<<<
                //case (int)DepositMainCndtn.PrintDivState.Details_NotDraw:		// �ڍ׈�����
                //case (int)DepositMainCndtn.PrintDivState.Simple:			    // �ȈՓ��v
                //    // ���v�敪�������ԍ���
                //    if ( depositMainCndtn.SumDiv == DepositMainCndtn.SumDivState.DepositSlipNo )
                //        sortOrderName = string.Format( ct_SortFomat, string.Empty, depositMainCndtn.SumDivPrintName + "��" );
                //    else
                //        sortOrderName = string.Format( ct_SortFomat, depositMainCndtn.SortOrderDivName, ct_Space + depositMainCndtn.SumDivPrintName + "��" );
                //    break;
                case (int)DepositMainCndtn.PrintDivState.DepsitMainList:             // �����m�F�\
                case (int)DepositMainCndtn.PrintDivState.DepositMainList_Sum:             // �����m�F�\(�W�v�\)
                    sortOrderName = string.Format(ct_SortFomat, depositMainCndtn.SortOrderDivName);
                    break;
                // 2008.07.10 30413 ���� ���[��ʂ̕ύX <<<<<<END
                default:
					sortOrderName = string.Empty;
					break;
			}
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
		/// <br>Programmer : 22013 �v�� ����</br>
		/// <br>Date       : 2007.03.08</br>
		/// </remarks>
		private void MakeExtarCondition( out StringCollection extraConditions )
		{
			const string ct_RangeConst = "�F{0} �` {1}";
			extraConditions = new StringCollection();
            StringCollection addConditions = new StringCollection();

            // 2008.07.14 30413 ���� �ϐ��ǉ� >>>>>>START
            string target = "";
            // 2008.07.14 30413 ���� �ϐ��ǉ� <<<<<<END
            
			// ���o���t ----------------------------------------------------------------------------------------------------
            // 2008.03.07 �C�� >>>>>>>>>>>>>>>>>>>>
            //string st_AddUpADate = string.Empty;
            //string ed_AddUpADate = string.Empty;
            //// �J�n
            //if ( this._depositMainCndtn.St_AddUpADate != DateTime.MinValue )
            //    st_AddUpADate = TDateTime.DateTimeToString( DepositMainCndtn.ct_DateFomat, this._depositMainCndtn.St_AddUpADate );
            //else
            //    st_AddUpADate = ct_Extr_Top;
            //// �I��
            //if ( this._depositMainCndtn.Ed_AddupADate != DateTime.MinValue )
            //    ed_AddUpADate = TDateTime.DateTimeToString( DepositMainCndtn.ct_DateFomat, this._depositMainCndtn.Ed_AddupADate );
            //else
            //    ed_AddUpADate = ct_Extr_End;

            //this.EditCondition(ref extraConditions, string.Format( "�����v����@" + ct_RangeConst, st_AddUpADate, ed_AddUpADate ) );
            // 2008.03.07 �C�� <<<<<<<<<<<<<<<<<<<<

            // 2008.07.23 30413 ���� ���o�����̓������̈󎚏���ύX >>>>>>START
            if ((this._depositMainCndtn.St_AddUpADate != DateTime.MinValue) ||
                ((this._depositMainCndtn.Ed_AddupADate != DateTime.MinValue) && (this._depositMainCndtn.Ed_AddupADate != DateTime.MaxValue)))
            {
                string st_AddUpADate = string.Empty;
                string ed_AddUpADate = string.Empty;
                // �J�n
                if (this._depositMainCndtn.St_AddUpADate != DateTime.MinValue)
                    st_AddUpADate = TDateTime.DateTimeToString(DepositMainCndtn.ct_DateFomat, this._depositMainCndtn.St_AddUpADate);
                else
                    st_AddUpADate = ct_Extr_Top;
                // �I��
                if ((this._depositMainCndtn.Ed_AddupADate != DateTime.MinValue) && (this._depositMainCndtn.Ed_AddupADate != DateTime.MaxValue))
                    ed_AddUpADate = TDateTime.DateTimeToString(DepositMainCndtn.ct_DateFomat, this._depositMainCndtn.Ed_AddupADate);
                else
                    ed_AddUpADate = ct_Extr_End;

                this.EditCondition(ref addConditions, string.Format("�������@" + ct_RangeConst, st_AddUpADate, ed_AddUpADate));
            }// 2008.07.23 30413 ���� ���o�����̓������̈󎚏���ύX <<<<<<END

            // 2007.11.14 �ǉ� >>>>>>>>>>>>>>>>>>>>
            if ((this._depositMainCndtn.St_CreateDate != DateTime.MinValue) || (this._depositMainCndtn.Ed_CreateDate != DateTime.MinValue))
            {
                string st_CreateDate = string.Empty;
                string ed_CreateDate = string.Empty;
                // �J�n
                if (this._depositMainCndtn.St_CreateDate != DateTime.MinValue)
                    st_CreateDate = TDateTime.DateTimeToString(DepositMainCndtn.ct_DateFomat, this._depositMainCndtn.St_CreateDate);
                else
                    st_CreateDate = ct_Extr_Top;
                // �I��
                if (this._depositMainCndtn.Ed_CreateDate != DateTime.MinValue)
                    ed_CreateDate = TDateTime.DateTimeToString(DepositMainCndtn.ct_DateFomat, this._depositMainCndtn.Ed_CreateDate);
                else
                    ed_CreateDate = ct_Extr_End;

                this.EditCondition(ref addConditions, string.Format("���͓��@" + ct_RangeConst, st_CreateDate, ed_CreateDate));
            }
            // 2007.11.14 �ǉ� <<<<<<<<<<<<<<<<<<<<

            // 2008.07.23 30413 ���� ���o�����̓������̈󎚏���ύX >>>>>>START
            //// 2008.03.07 �C�� >>>>>>>>>>>>>>>>>>>>
            //if ( (this._depositMainCndtn.St_AddUpADate != DateTime.MinValue) ||
            //    ((this._depositMainCndtn.Ed_AddupADate != DateTime.MinValue) && (this._depositMainCndtn.Ed_AddupADate != DateTime.MaxValue)))
            //{
            //    string st_AddUpADate = string.Empty;
            //    string ed_AddUpADate = string.Empty;
            //    // �J�n
            //    if (this._depositMainCndtn.St_AddUpADate != DateTime.MinValue)
            //        st_AddUpADate = TDateTime.DateTimeToString(DepositMainCndtn.ct_DateFomat, this._depositMainCndtn.St_AddUpADate);
            //    else
            //        st_AddUpADate = ct_Extr_Top;
            //    // �I��
            //    if ((this._depositMainCndtn.Ed_AddupADate != DateTime.MinValue) && (this._depositMainCndtn.Ed_AddupADate != DateTime.MaxValue))
            //        ed_AddUpADate = TDateTime.DateTimeToString(DepositMainCndtn.ct_DateFomat, this._depositMainCndtn.Ed_AddupADate);
            //    else
            //        ed_AddUpADate = ct_Extr_End;

            //    this.EditCondition(ref extraConditions, string.Format("�����v����@" + ct_RangeConst, st_AddUpADate, ed_AddUpADate));
            //}
            //// 2008.03.07 �C�� <<<<<<<<<<<<<<<<<<<<
            // 2008.07.23 30413 ���� ���o�����̓������̈󎚏���ύX <<<<<<END

            //StringCollection addConditions = new StringCollection();
            
            // 2008.07.14 30413 ���� �ŏ�����`�Ō�܂łɕύX >>>>>>START
            // ���Ӑ�R�[�h ----------------------------------------------------------------------------------------------------
            //if ((this._depositMainCndtn.St_CustomerCode != 0) || (this._depositMainCndtn.Ed_CustomerCode != 999999999))
            //{
            //    this.EditCondition(ref addConditions,
            //        string.Format("���Ӑ�R�[�h�F{0} �` {1}", this._depositMainCndtn.St_CustomerCode, this._depositMainCndtn.Ed_CustomerCode)
            //    );
            //}
            if ((this._depositMainCndtn.St_CustomerCode == 0) && (this._depositMainCndtn.Ed_CustomerCode != 0))
            {
                // DEL 2008/10/10 �s��Ή�[6362] ��
                //target = "���Ӑ�R�[�h: " + ct_Extr_Top + " �` " + this._depositMainCndtn.Ed_CustomerCode.ToString();
                target = "���Ӑ�R�[�h: " + ct_Extr_Top + " �` " + this._depositMainCndtn.Ed_CustomerCode.ToString().PadLeft(8,'0');    // ADD 2008/10/10 �s��Ή�[6362]
                this.EditCondition(ref addConditions, target);
            }

            if ((this._depositMainCndtn.St_CustomerCode > 0) && (this._depositMainCndtn.Ed_CustomerCode == 0))
            {
                // DEL 2008/10/10 �s��Ή�[6362] ��
                //target = "���Ӑ�R�[�h: " + this._depositMainCndtn.St_CustomerCode.ToString() + " �` " + ct_Extr_End;
                target = "���Ӑ�R�[�h: " + this._depositMainCndtn.St_CustomerCode.ToString().PadLeft(8, '0') + " �` " + ct_Extr_End;    // ADD 2008/10/10 �s��Ή�[6362]
                this.EditCondition(ref addConditions, target);
            }

            if ((this._depositMainCndtn.St_CustomerCode > 0) && (this._depositMainCndtn.Ed_CustomerCode != 0))
            {
                // DEL 2008/10/10 �s��Ή�[6362] ��
                //target = "���Ӑ�R�[�h: " + this._depositMainCndtn.St_CustomerCode.ToString() + " �` " + this._depositMainCndtn.Ed_CustomerCode.ToString();
                target = "���Ӑ�R�[�h: " + this._depositMainCndtn.St_CustomerCode.ToString().PadLeft(8,'0') + " �` " + this._depositMainCndtn.Ed_CustomerCode.ToString().PadLeft(8,'0');    // ADD 2008/10/10 �s��Ή�[6362]
                this.EditCondition(ref addConditions, target);
            }
            // 2008.07.14 30413 ���� �ŏ�����`�Ō�܂łɕύX >>>>>>END

            // 2008.07.23 30413 ���� ���Ӑ�J�i�ƒS���҃R�[�h�̍폜 >>>>>>START
            //// ���Ӑ�J�i ----------------------------------------------------------------------------------------------------
            //if ((this._depositMainCndtn.St_CustomerKana != string.Empty) || (this._depositMainCndtn.Ed_CustomerKana != string.Empty))
            //{
            //    this.EditCondition(ref addConditions,
            //        GetConditionRange("���Ӑ�J�i", this._depositMainCndtn.St_CustomerKana, this._depositMainCndtn.Ed_CustomerKana));
            //}

            //// �S���҃R�[�h ----------------------------------------------------------------------------------------------------
            //if ((this._depositMainCndtn.St_EmployeeCode != string.Empty) || (this._depositMainCndtn.Ed_EmployeeCode != string.Empty))
            //{
            //    this.EditCondition(ref addConditions,
            //        // 2007.11.14 �C�� >>>>>>>>>>>>>>>>>>>>
            //        //GetConditionRange(this._depositMainCndtn.EmployeeKindDivName + "�҃R�[�h", this._depositMainCndtn.St_EmployeeCode, this._depositMainCndtn.Ed_EmployeeCode));
            //        GetConditionRange(this._depositMainCndtn.EmployeeKindDivName + "�R�[�h", this._depositMainCndtn.St_EmployeeCode, this._depositMainCndtn.Ed_EmployeeCode));
            //        // 2007.11.14 �C�� <<<<<<<<<<<<<<<<<<<<
            //}
            // 2008.07.23 30413 ���� ���Ӑ�J�i�ƒS���҃R�[�h�̍폜 <<<<<<END
            
            // 2007.11.14 �폜 >>>>>>>>>>>>>>>>>>>>
            //// �l�@�l�敪 ----------------------------------------------------------------------------------------------------
			//if ( ( this._depositMainCndtn.CorporateDivCode.Count > 0 ) && ( this._depositMainCndtn.CorporateDivCode.Count < 5 ) )
			//{
			//	this.EditCondition( ref addConditions, "�@�l�敪�F" + GetCorporateDivCodeName() );
			//}
            // 2007.11.14 �폜 <<<<<<<<<<<<<<<<<<<<

            // 2007.11.14 �ǉ� >>>>>>>>>>>>>>>>>>>>
            // �����敪 ----------------------------------------------------------------------------------------------------
            this.EditCondition(ref addConditions, "�����敪�F" + this._depositMainCndtn.DepositNm);
            // 2007.11.14 �ǉ� <<<<<<<<<<<<<<<<<<<<

            // 2008.07.14 30413 ���� �ŏ�����`�Ō�܂łɕύX >>>>>>START
            // �����ԍ� ----------------------------------------------------------------------------------------------------
            //if ((this._depositMainCndtn.St_DepositSlipNo != 0) || (this._depositMainCndtn.Ed_DepositSlipNo != 999999999))
            //{
            //    this.EditCondition(ref addConditions,
            //        string.Format("�����ԍ��F{0} �` {1}",
            //            String.Format("{0:D9}", this._depositMainCndtn.St_DepositSlipNo),
            //            String.Format("{0:D9}", this._depositMainCndtn.Ed_DepositSlipNo)
            //        )
            //    );
            //}
            if ((this._depositMainCndtn.St_DepositSlipNo == 0) && (this._depositMainCndtn.Ed_DepositSlipNo != 0))
            {
                target = "�����ԍ�: " + ct_Extr_Top + " �` " + this._depositMainCndtn.Ed_DepositSlipNo.ToString();
                this.EditCondition(ref addConditions, target);
            }

            if ((this._depositMainCndtn.St_DepositSlipNo > 0) && (this._depositMainCndtn.Ed_DepositSlipNo == 0))
            {
                target = "�����ԍ�: " + this._depositMainCndtn.St_DepositSlipNo.ToString() + " �` " + ct_Extr_End;
                this.EditCondition(ref addConditions, target);
            }

            if ((this._depositMainCndtn.St_DepositSlipNo > 0) && (this._depositMainCndtn.Ed_DepositSlipNo != 0))
            {
                target = "�����ԍ�: " + this._depositMainCndtn.St_DepositSlipNo.ToString() + " �` " + this._depositMainCndtn.Ed_DepositSlipNo.ToString();
                this.EditCondition(ref addConditions, target);
            }
            // 2008.07.14 30413 ���� �ŏ�����`�Ō�܂łɕύX >>>>>>END
            
            // �������� ----------------------------------------------------------------------------------------------------
            // 2007.11.14 �C�� >>>>>>>>>>>>>>>>>>>>
            if (!this._depositMainCndtn.DepositKind.ContainsKey(DepositMainCndtn.ct_All_Code))
            {
                this.EditCondition(ref addConditions, "��������F" + GetDepositKindName());
            }
            // --- ADD 2009/03/27 -------------------------------->>>>>
            else
            {
                // �u�S�āv�̏ꍇ�͑S�ĕ\��
                Dictionary<int, string> dicKindName = new Dictionary<int, string>();
                DepositMainAcs depositMainAcs = new DepositMainAcs();
                int status = depositMainAcs.SearchKindName(out dicKindName);
                if (status == 0)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append("��������F");

                    for (int i = 0; i < dicKindName.Count && i < 8; i++)
                    {
                        if (i != 0)
                        {
                            sb.Append("�A");
                        }

                        sb.Append(dicKindName[i]);
                    }

                    this.EditCondition(ref addConditions, sb.ToString());
                }
            }
            // --- ADD 2009/03/27 --------------------------------<<<<<
            //this.EditCondition(ref addConditions, "��������F" + GetDepositKindName());
            // 2007.11.14 �C�� <<<<<<<<<<<<<<<<<<<<

            // 2007.11.14 �ǉ� >>>>>>>>>>>>>>>>>>>>
            // �����敪 ----------------------------------------------------------------------------------------------------
            this.EditCondition(ref addConditions, "�����敪�F" + this._depositMainCndtn.AllowanceDivName);
            // 2007.11.14 �ǉ� <<<<<<<<<<<<<<<<<<<<

            // 2007.11.14 �폜 >>>>>>>>>>>>>>>>>>>>
            //// �N���W�b�g���[���敪 ----------------------------------------------------------------------------------------------------
			//if ( this._depositMainCndtn.CreditOrLoanCd != DepositMainCndtn.CreditOrLoanCdState.All )
			//{
			//	this.EditCondition( ref addConditions, "�N���W�b�g/���[���F" + this._depositMainCndtn.CreditOrLoanNm );
			//}
            //
			//// ������� ----------------------------------------------------------------------------------------------------
			//// ������Ԃ͏ڍ׈����L�̂Ƃ��̂ݗL��
			//if ( this._depositMainCndtn.PrintDiv == (int)DepositMainCndtn.PrintDivState.Details_HaveDraw )
			//{
			//	if ( this._depositMainCndtn.AllowanceDiv != DepositMainCndtn.AllowanceDivState.All )
			//	{
			//		this.EditCondition( ref addConditions, "������ԁF" + this._depositMainCndtn.CreditOrLoanNm );
			//	}
			//}
            // 2007.11.14 �폜 <<<<<<<<<<<<<<<<<<<<

			foreach ( string exCondStr in addConditions )
			{
				extraConditions.Add( exCondStr );
			}

		}
		#endregion

		#region �� �������햼�̕�����쐬
		/// <summary>
		/// �������햼�̕�����쐬
		/// </summary>
		/// <returns>�쐬������</returns>
		/// <remarks>
		/// <br>Note       : ���o�͈͕�������쐬���܂�</br>
		/// <br>Programmer : 22013 �v�� ����</br>
		/// <br>Date       : 2007.03.08</br>
		/// </remarks>
		private string GetDepositKindName()
		{
			StringBuilder result = new StringBuilder();

			foreach ( string corpName in this._depositMainCndtn.DepositKind.Values )
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

        // 2008.07.14 30413 ���� ���g�p���\�b�h�̍폜 >>>>>>START
        #region �� �l�@�l�敪���̕�����쐬
        ///// <summary>
        ///// �l�@�l�敪���̕�����쐬
        ///// </summary>
        ///// <returns>�쐬������</returns>
        ///// <remarks>
        ///// <br>Note       : ���o�͈͕�������쐬���܂�</br>
        ///// <br>Programmer : 22013 �v�� ����</br>
        ///// <br>Date       : 2007.03.08</br>
        ///// </remarks>
        //private string GetCorporateDivCodeName()
        //{
        //    StringBuilder result = new StringBuilder();

        //    foreach ( string corpName in this._depositMainCndtn.CorporateDivCode.Values )
        //    {
        //        if ( result.ToString().CompareTo( string.Empty ) != 0 )
        //        {
        //            result.Append("�E");
        //        }
        //        result.Append( corpName );
        //    }

        //    return result.ToString();
        //}
		#endregion
        // 2008.07.14 30413 ���� ���g�p���\�b�h�̍폜 <<<<<<END
        
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

        // 2008.07.23 30413 ���� ���g�p���\�b�h�̍폜 >>>>>>START
        #region ���@������N�G���쐬�֐�
        ///// <summary>
        ///// �󎚏��N�G���쐬����
        ///// </summary>
        ///// <returns>�쐬�����N�G��</returns>
        ///// <remarks>
        ///// <br>Note       : DataView�ɐݒ肷��󎚏��ʂ̃N�G�����쐬���܂��B</br>
        ///// <br>Programmer : 980035 ���� ��`</br>
        ///// <br>Date       : 2008.01.31</br>
        ///// </remarks>
        //private string GetPrintOderQuerry()
        //{
        //    string orderQuerry = "";

        //    orderQuerry = MAHNB02014EA.ct_Col_AddUpSecCode;
        //    // ���v�敪��I��
        //    switch (this._depositMainCndtn.SumDiv)
        //    {
        //        case DepositMainCndtn.SumDivState.Day:				// ���v
        //            {
        //                orderQuerry = orderQuerry + "," + MAHNB02014EA.ct_Col_AddUpADate;
        //                break;
        //            }
        //        case DepositMainCndtn.SumDivState.Customer:			// ���Ӑ�v
        //            {
        //                orderQuerry = orderQuerry + "," + MAHNB02014EA.ct_Col_CustomerCode;
        //                break;
        //            }
        //        case DepositMainCndtn.SumDivState.DepositKind:		// ����v
        //            {
        //                orderQuerry = orderQuerry + "," + MAHNB02014EA.ct_Col_DepositKindCode;
        //                break;
        //            }
        //        case DepositMainCndtn.SumDivState.DepositSlipNo:	// �����ԍ�
        //            {
        //                orderQuerry = orderQuerry + "," + MAHNB02014EA.ct_Col_DepositSlipNo;
        //                break;
        //            }
        //    }
        //    // ���я�������I��
        //    switch (this._depositMainCndtn.SortOrderDiv)
        //    {
        //        case DepositMainCndtn.SortOrderDivState.CustomerCode:	// ���Ӑ�R�[�h��
        //            {
        //                orderQuerry = orderQuerry + "," + MAHNB02014EA.ct_Col_CustomerCode;
        //                break;
        //            }
        //        case DepositMainCndtn.SortOrderDivState.CustomerKane:	// ���Ӑ�J�i��
        //            {
        //                orderQuerry = orderQuerry + "," + MAHNB02014EA.ct_Col_Kana;
        //                break;
        //            }
        //        case DepositMainCndtn.SortOrderDivState.EmployeeCode:	// �S���҃R�[�h��
        //            {
        //                orderQuerry = orderQuerry + "," + MAHNB02014EA.ct_Col_AgentCode;
        //                break;
        //            }
        //    }

        //    return orderQuerry;
        //}
        #endregion
        // 2008.07.23 30413 ���� ���g�p���\�b�h�̍폜 <<<<<<END
        
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
			return TMsgDisp.Show(iLevel, "MAHNB02012P", iMsg, iSt, iButton, iDefButton);
		}

		#endregion
		#endregion
	}
}
