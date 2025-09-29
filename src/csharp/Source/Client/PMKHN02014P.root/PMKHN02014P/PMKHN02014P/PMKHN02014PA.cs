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
	/// �|���}�X�^����N���X
	/// </summary>
	/// <remarks>
    /// <br>Note       : �|���}�X�^�̈�����s���B</br>
	/// <br>Programmer : 30462 �s�V �m��</br>
	/// <br>Date       : 2008.10.16</br>
    /// -----------------------------------------------------------------
    /// <br>UpdateNote   : 2008/10/29 30462 �s�V �m���@�o�O�C��</br>
    /// -----------------------------------------------------------------
    /// <br>UpdateNote   : 2011/07/22 �����@�A��898 ���[�U�[���i�̒ǉ�</br>
    /// </remarks>
	class PMKHN02014PA: IPrintProc
	{

		#region �� Constructor
		/// <summary>
        /// �|���}�X�^����N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
        /// <br>Note       : �|���}�X�^����N���X�̃C���X�^���X�̍쐬���s���B</br>
		/// <br>Programmer : 30462 �s�V �m��</br>
		/// <br>Date       : 2008.10.16</br>
		/// </remarks>
		public PMKHN02014PA()
		{
		}

		/// <summary>
        /// �|���}�X�^����N���X�R���X�g���N�^
		/// </summary>
		/// <param name="printInfo">������I�u�W�F�N�g</param>
		/// <remarks>
        /// <br>Note       : �|���}�X�^����N���X�̃C���X�^���X�̍쐬���s���B</br>
		/// <br>Programmer : 30462 �s�V �m��</br>
		/// <br>Date       : 2008.10.16</br>
		/// </remarks>
        public PMKHN02014PA(object printInfo)
		{
			this._printInfo = printInfo as SFCMN06002C;
            this._ratePrtReqCndtn = this._printInfo.jyoken as RatePrtReqCndtn;
		}
		#endregion �� Constructor

		#region �� Pricate Const
		private const string ct_ReportForm_NameSpace = "Broadleaf.Drawing.Printing";
		private const string ct_Space			= "�@";
        private const string ct_Extr_Top = "�ŏ�����";
        private const string ct_Extr_End = "�Ō�܂�";
        private const string ct_RangeConst = "�F{0} �` {1}";
		#endregion �� Pricate Const

		#region �� Private Member
		private SFCMN06002C _printInfo;					                // ������N���X
        private RatePrtReqCndtn _ratePrtReqCndtn;	                    // ���o�����N���X
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
		/// <br>Programmer : 30462 �s�V �m��</br>
		/// <br>Date       : 2008.10.16</br>
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
		/// <br>Programmer : 30462 �s�V �m��</br>
		/// <br>Date       : 2008.10.16</br>
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
                prtRpt.DataMember = PMKHN02019EA.ct_Tbl_Rate;
				
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
		/// <br>Programmer : 30462 �s�V �m��</br>
		/// <br>Date       : 2008.10.16</br>
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
		/// <br>Programmer : 30462 �s�V �m��</br>
		/// <br>Date       : 2008.10.16</br>
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
		/// <br>Programmer : 30462 �s�V �m��</br>
		/// <br>Date       : 2008.10.16</br>
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
			commonInfo.PrintMax    = (this._printInfo.rdData as DataView).Count;
			
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
		/// <br>Programmer : 30462 �s�V �m��</br>
		/// <br>Date       : 2008.10.16</br>
		/// </remarks>
		private int SettingProperty(ref DataDynamics.ActiveReports.ActiveReport3 rpt)
		{
			int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;

			// ActiveReport�C���^�[�t�F�[�X�ɃL���X�g
			IPrintActiveReportTypeList instance = rpt as IPrintActiveReportTypeList;

			// ��������擾
            RatePrtReqCndtn extraInfo = (RatePrtReqCndtn)this._printInfo.jyoken;

			// �\�[�g���v���p�e�B�ݒ�
            //instance.PageHeaderSortOderTitle = this._stockGetuNenCndtn.PrintSortDivStateTitle;
			
			// ���[�o�͐ݒ���擾 
			PrtOutSet prtOutSet;
			string message;
            int st = RateReportAcs.ReadPrtOutSet(out prtOutSet, out message);
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
            //object[] titleObj = new object[] { this._ratePrtReqCndtn.ReportSubTitle, "�|���}�X�^" };
            //instance.PageHeaderSubtitle = string.Format("{0}{1}", titleObj);
            //instance.PageHeaderSubtitle = string.Format("�|���}�X�^");  // DEL 2008/10/29 �s��Ή�[7169]
            instance.PageHeaderSubtitle = string.Format("�|���}�X�^���");  // ADD 2008/10/29 �s��Ή�[7169]

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
        /// <br>Programmer : 30462 �s�V �m��</br>
        /// <br>Date       : 2008.10.16</br>
        /// <br>Update Note: 2011/07/22 ����� NS���[�U�[���Ǘv�]�ꗗ�̘A��898�̑Ή�</br>
        /// <br>             ���[�U�[���i�w���ǉ�����</br>
        /// </remarks>
		private void MakeExtarCondition( out StringCollection extraConditions )
		{
            extraConditions = new StringCollection();
            StringCollection addConditions = new StringCollection();

            // �P�����
            if (this._ratePrtReqCndtn.UnitPriceKind == 1)
            {
                this.EditCondition(ref addConditions, "�P����ށF�����ݒ�");
            }
            else if (this._ratePrtReqCndtn.UnitPriceKind == 2)
            {
                this.EditCondition(ref addConditions, "�P����ށF�����ݒ�");
            }
            else if (this._ratePrtReqCndtn.UnitPriceKind == 3)
            {
                this.EditCondition(ref addConditions, "�P����ށF���i�ݒ�");
            }
            // �o�͋敪
            if (this._ratePrtReqCndtn.LogicalDeleteCode == 1)
            {
                this.EditCondition(ref addConditions, "�o�͋敪�F�W��");
            }
            else if (this._ratePrtReqCndtn.LogicalDeleteCode == 2)
            {
                this.EditCondition(ref addConditions, "�o�͋敪�F�폜��");
            }
            else if (this._ratePrtReqCndtn.LogicalDeleteCode == 3)
            {
                this.EditCondition(ref addConditions, "�o�͋敪�F�S��");
            }

            // �ݒ���@
            if (this._ratePrtReqCndtn.RateMngGoodsCdKind == 1)
            {
                this.EditCondition(ref addConditions, "�ݒ���@�F��ٰ�ߐݒ�");
            }
            else if (this._ratePrtReqCndtn.RateMngGoodsCdKind == 0)
            {
                this.EditCondition(ref addConditions, "�ݒ���@�F�P�i�ݒ�");
            }

            // �|���ݒ�敪
            if (this._ratePrtReqCndtn.RateSettingDivideSt != string.Empty || this._ratePrtReqCndtn.RateSettingDivideEd != string.Empty)
            {
                string st_WarehouseCode = this._ratePrtReqCndtn.RateSettingDivideSt;
                string ed_WarehouseCode = this._ratePrtReqCndtn.RateSettingDivideEd;

                if (st_WarehouseCode == string.Empty)
                    st_WarehouseCode = ct_Extr_Top;
                if (ed_WarehouseCode == string.Empty)
                    ed_WarehouseCode = ct_Extr_End;

                this.EditCondition(
                    ref addConditions,
                    string.Format("�|���ݒ�敪" + ct_RangeConst, st_WarehouseCode, ed_WarehouseCode));
            }

            // ���Ӑ�
            if (this._ratePrtReqCndtn.CustomerCodeSt != 0 || this._ratePrtReqCndtn.CustomerCodeEd != 99999999)         
            {
                string st_SupplierCd = this._ratePrtReqCndtn.CustomerCodeSt.ToString("00000000");
                string ed_SupplierCd = this._ratePrtReqCndtn.CustomerCodeEd.ToString("00000000");
                if (st_SupplierCd == "00000000")
                    st_SupplierCd = ct_Extr_Top;
                if (ed_SupplierCd == "99999999")
                    ed_SupplierCd = ct_Extr_End;

                this.EditCondition(
                    ref addConditions,
                    string.Format("���Ӑ�" + ct_RangeConst,
                                    st_SupplierCd, ed_SupplierCd));                    
            }

            // ���Ӑ�|����ٰ��
            if (this._ratePrtReqCndtn.CustRateGrpCodeSt != 0 || this._ratePrtReqCndtn.CustRateGrpCodeEd != 9999)
            {
                string st_SupplierCd = this._ratePrtReqCndtn.CustRateGrpCodeSt.ToString("0000");
                string ed_SupplierCd = this._ratePrtReqCndtn.CustRateGrpCodeEd.ToString("0000");
                if (st_SupplierCd == "0000")
                    st_SupplierCd = ct_Extr_Top;
                if (ed_SupplierCd == "9999")
                    ed_SupplierCd = ct_Extr_End;

                this.EditCondition(
                    ref addConditions,
                    string.Format("���Ӑ�|����ٰ��" + ct_RangeConst,
                                    st_SupplierCd, ed_SupplierCd));
            }

            // �d����
            if (this._ratePrtReqCndtn.SupplierCdSt != 0 || this._ratePrtReqCndtn.SupplierCdEd != 999999)
            {
                string st_SupplierCd = this._ratePrtReqCndtn.SupplierCdSt.ToString("000000");
                string ed_SupplierCd = this._ratePrtReqCndtn.SupplierCdEd.ToString("000000");
                if (st_SupplierCd == "000000")
                    st_SupplierCd = ct_Extr_Top;
                if (ed_SupplierCd == "999999")
                    ed_SupplierCd = ct_Extr_End;

                this.EditCondition(
                    ref addConditions,
                    string.Format("�d����" + ct_RangeConst,
                                    st_SupplierCd, ed_SupplierCd));
            }

            // Ұ��
            if (this._ratePrtReqCndtn.GoodsMakerCdSt != 0 || this._ratePrtReqCndtn.GoodsMakerCdEd != 9999)
            {
                string st_SupplierCd = this._ratePrtReqCndtn.GoodsMakerCdSt.ToString("0000");
                string ed_SupplierCd = this._ratePrtReqCndtn.GoodsMakerCdEd.ToString("0000");
                if (st_SupplierCd == "0000")
                    st_SupplierCd = ct_Extr_Top;
                if (ed_SupplierCd == "9999")
                    ed_SupplierCd = ct_Extr_End;

                this.EditCondition(
                    ref addConditions,
                    string.Format("Ұ��" + ct_RangeConst,
                                    st_SupplierCd, ed_SupplierCd));
            }

            // �w��
            if (this._ratePrtReqCndtn.GoodsRateRankSt != string.Empty || this._ratePrtReqCndtn.GoodsRateRankEd != string.Empty)
            {
                string st_WarehouseCode = this._ratePrtReqCndtn.GoodsRateRankSt;
                string ed_WarehouseCode = this._ratePrtReqCndtn.GoodsRateRankEd;

                if (st_WarehouseCode == string.Empty)
                    st_WarehouseCode = ct_Extr_Top;
                if (ed_WarehouseCode == string.Empty)
                    ed_WarehouseCode = ct_Extr_End;

                this.EditCondition(
                    ref addConditions,
                    string.Format("�w��" + ct_RangeConst, st_WarehouseCode, ed_WarehouseCode));
            }

            // ���i�|����ٰ��
            if (this._ratePrtReqCndtn.GoodsRateGrpCodeSt != 0 || this._ratePrtReqCndtn.GoodsRateGrpCodeEd != 9999)
            {
                string st_SupplierCd = this._ratePrtReqCndtn.GoodsRateGrpCodeSt.ToString("0000");
                string ed_SupplierCd = this._ratePrtReqCndtn.GoodsRateGrpCodeEd.ToString("0000");
                if (st_SupplierCd == "0000")
                    st_SupplierCd = ct_Extr_Top;
                if (ed_SupplierCd == "9999")
                    ed_SupplierCd = ct_Extr_End;

                this.EditCondition(
                    ref addConditions,
                    string.Format("���i�|����ٰ��" + ct_RangeConst,
                                    st_SupplierCd, ed_SupplierCd));
            }

            // ��ٰ�ߺ���
            if (this._ratePrtReqCndtn.BLGroupCodeSt != 0 || this._ratePrtReqCndtn.BLGroupCodeEd != 99999)
            {
                string st_SupplierCd = this._ratePrtReqCndtn.BLGroupCodeSt.ToString("00000");
                string ed_SupplierCd = this._ratePrtReqCndtn.BLGroupCodeEd.ToString("00000");
                if (st_SupplierCd == "00000")
                    st_SupplierCd = ct_Extr_Top;
                if (ed_SupplierCd == "99999")
                    ed_SupplierCd = ct_Extr_End;

                this.EditCondition(
                    ref addConditions,
                    string.Format("��ٰ�ߺ���" + ct_RangeConst,
                                    st_SupplierCd, ed_SupplierCd));
            }

            // BL����
            if (this._ratePrtReqCndtn.BLGoodsCodeSt != 0 || this._ratePrtReqCndtn.BLGoodsCodeEd != 99999)
            {
                string st_SupplierCd = this._ratePrtReqCndtn.BLGoodsCodeSt.ToString("00000");
                string ed_SupplierCd = this._ratePrtReqCndtn.BLGoodsCodeEd.ToString("00000");
                if (st_SupplierCd == "00000")
                    st_SupplierCd = ct_Extr_Top;
                if (ed_SupplierCd == "99999")
                    ed_SupplierCd = ct_Extr_End;

                this.EditCondition(
                    ref addConditions,
                    string.Format("BL����" + ct_RangeConst,
                                    st_SupplierCd, ed_SupplierCd));
            }

            // �i��
            if (this._ratePrtReqCndtn.GoodsNoSt != string.Empty || this._ratePrtReqCndtn.GoodsNoEd != string.Empty)
            {
                string st_WarehouseCode = this._ratePrtReqCndtn.GoodsNoSt;
                string ed_WarehouseCode = this._ratePrtReqCndtn.GoodsNoEd;

                if (st_WarehouseCode == string.Empty)
                    st_WarehouseCode = ct_Extr_Top;
                if (ed_WarehouseCode == string.Empty)
                    ed_WarehouseCode = ct_Extr_End;

                this.EditCondition(
                    ref addConditions,
                    string.Format("�i��" + ct_RangeConst, st_WarehouseCode, ed_WarehouseCode));
            }
            
            // --- ADD 2011/07/22 ---------->>>>>
            // ���[�U�[���i�w��
            if (this._ratePrtReqCndtn.UserPriceAppoint == 1)
            {
                this.EditCondition(ref addConditions, "���[�U�[���i�w��F�S��");
            }
            else if (this._ratePrtReqCndtn.UserPriceAppoint == 2)
            {
                this.EditCondition(ref addConditions, "���[�U�[���i�w��F���i�}�X�^���i�����[�U�[���i");
            }
            else if (this._ratePrtReqCndtn.UserPriceAppoint == 3)
            {
                this.EditCondition(ref addConditions, "���[�U�[���i�w��F���i�}�X�^���i�����[�U�[���i");
            }
            // --- ADD 2011/07/22  ----------<<<<<
            
            // �ǉ�
            foreach ( string exCondStr in addConditions ) {
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
        /// <br>Programmer : 30462 �s�V �m��</br>
        /// <br>Date       : 2008.10.16</br>
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
        /// <br>Programmer : 30462 �s�V �m��</br>
        /// <br>Date       : 2008.10.16</br>
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
		/// <br>Programmer : 30462 �s�V �m��</br>
		/// <br>Date       : 2008.10.16</br>
		/// </remarks>
		private DialogResult MsgDispProc(emErrorLevel iLevel, string iMsg, int iSt, MessageBoxButtons iButton, MessageBoxDefaultButton iDefButton)
		{
			return TMsgDisp.Show(iLevel, "PMKHN02014P", iMsg, iSt, iButton, iDefButton);
		}

		#endregion
		#endregion
	}
}
