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
	/// �o�׏��i���͕\����N���X
	/// </summary>
	/// <remarks>
    /// <br>Note       : �o�׏��i���͕\�̈�����s���B</br>
	/// <br>Programmer : 20081 �D�c �E�l</br>
	/// <br>Date       : 2007.12.03</br>
    /// <br></br>
    /// <br>UpdateNote : ���o�����̌��x��0���ߑΉ��B</br>
    /// <br>Programmer : 980081 �R�c ���F</br>
    /// <br>Date       : 2008.04.03</br>
    /// <br>Update Note: 2008.10.20 30452 ��� �r��</br>
    /// <br>            �EPM.NS�Ή�</br>
    /// <br>Update Note: 2009.02.10 30452 ��� �r��</br>
    /// <br>            �E��Q�Ή�11327</br>
    /// <br>Update Note: 2009/03/17 30452 ��� �r��</br>
    /// <br>            �E��Q�Ή�12700</br>
    /// <br>Update Note: 2014/12/22 ������</br>
    /// <br>�Ǘ��ԍ�   : 11070263-00</br>
    /// <br>           :�E�����Y�ƗlSeiken�i�ԕύX</br>
    /// </remarks>
	class DCTOK02052PA: IPrintProc
	{

		#region �� Constructor
		/// <summary>
		/// �o�׏��i���͕\����N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
		/// <br>Note       : �o�׏��i���͕\����N���X�̃C���X�^���X�̍쐬���s���B</br>
		/// <br>Programmer : 20081 �D�c �E�l</br>
		/// <br>Date       : 2007.12.03</br>
		/// </remarks>
		public DCTOK02052PA()
		{
		}

		/// <summary>
		/// �o�׏��i���͕\����N���X�R���X�g���N�^
		/// </summary>
		/// <param name="printInfo">������I�u�W�F�N�g</param>
		/// <remarks>
		/// <br>Note       : �o�׏��i���͕\����N���X�̃C���X�^���X�̍쐬���s���B</br>
		/// <br>Programmer : 20081 �D�c �E�l</br>
		/// <br>Date       : 2007.12.03</br>
		/// </remarks>
		public DCTOK02052PA( object printInfo )
		{
			this._printInfo = printInfo as SFCMN06002C;
            this._extrInfo_ShipGoodsAnalyze = this._printInfo.jyoken as ExtrInfo_ShipGoodsAnalyze;
		}
		#endregion �� Constructor

		#region �� Pricate Const
		private const string ct_ReportForm_NameSpace = "Broadleaf.Drawing.Printing";
		private const string ct_Space			= "�@";
		private const string ct_Extr_Top		= "�ŏ�����";
		private const string ct_Extr_End		= "�Ō�܂�";
		private	const string ct_RangeConst		= "�F{0} �` {1}";
		#endregion �� Pricate Const

		#region �� Private Member
		private SFCMN06002C _printInfo;					                    // ������N���X
        private ExtrInfo_ShipGoodsAnalyze _extrInfo_ShipGoodsAnalyze;		// ���o�����N���X
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
		/// <br>Programmer : 20081 �D�c �E�l</br>
		/// <br>Date       : 2007.12.03</br>
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
		/// <br>Date       : 2007.12.03</br>
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
                prtRpt.DataMember = DCTOK02054EA.ct_Tbl_ShipGoodsAnalyze;
				
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
		/// <br>Programmer : 20081 �D�c �E�l</br>
		/// <br>Date       : 2007.12.03</br>
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
		/// <br>Date       : 2007.12.03</br>
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
        /// <param name="rptObj"></param>
		/// <returns>�X�e�[�^�X</returns>
		/// <remarks>
		/// <br>Note       : �����ʋ��ʏ����̐ݒ���s���܂��B</br>
		/// <br>Programmer : 20081 �D�c �E�l</br>
		/// <br>Date       : 2007.12.03</br>
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
            //commonInfo.PrintMax = 0; // DEL 2009/02/10
            commonInfo.PrintMax = (this._printInfo.rdData as DataView).Count; // ADD 2009/02/10
			
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
		/// <br>Programmer : 20081 �D�c �E�l</br>
		/// <br>Date       : 2007.12.03</br>
		/// </remarks>
		private int SettingProperty(ref DataDynamics.ActiveReports.ActiveReport3 rpt)
		{
			int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;

			// ActiveReport�C���^�[�t�F�[�X�ɃL���X�g
			IPrintActiveReportTypeList instance = rpt as IPrintActiveReportTypeList;

			// ��������擾
            ExtrInfo_ShipGoodsAnalyze extraInfo = (ExtrInfo_ShipGoodsAnalyze)this._printInfo.jyoken;

			// �\�[�g���v���p�e�B�ݒ�
            instance.PageHeaderSortOderTitle = GetSortOrderName(extraInfo);
			
			// ���[�o�͐ݒ���擾 
			PrtOutSet prtOutSet;
			string message;
            int st = ShipGoodsAnalyzeListAcs.ReadPrtOutSet(out prtOutSet, out message);
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
            object[] titleObj = new object[]{"�o�׏��i���͕\"};
            instance.PageHeaderSubtitle = string.Format("{0}", titleObj);

			// ���̑��f�[�^
			// Todo:�ړ����Ƃ��n���H���o�����n�邩�炢�����H
			instance.OtherDataList = null;

			status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

			return status;
		}

		#endregion

        #region �� �\�[�g�����̎擾
        /// <summary>
        /// �\�[�g�����̎擾
        /// </summary>
        /// <param name="extrInfo_ShipGoodsAnalyze">���o����</param>
        /// <returns>�\�[�g������</returns>
        /// <remarks>
        /// <br>Note       : �\�[�g�����̂��擾����B</br>
        /// <br>Programmer : 20081 �D�c �E�l</br>
        /// <br>Date       : 2007.12.03</br>
        /// </remarks>
        private string GetSortOrderName(ExtrInfo_ShipGoodsAnalyze extrInfo_ShipGoodsAnalyze)
        {
            string sortOrderName = string.Empty;
            sortOrderName = extrInfo_ShipGoodsAnalyze.OrderPrintDivStateTitle;
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
		/// <br>Date       : 2007.12.03</br>
        /// <br>Update Note: 2014/12/22 ������</br>
        /// <br>�Ǘ��ԍ�   : 11070263-00</br>
        /// <br>           :�E�����Y�ƗlSeiken�i�ԕύX</br>
		/// </remarks>
        private void MakeExtarCondition(out StringCollection extraConditions)
        {
            const string ct_RangeConst = "�F{0} �` {1}";
            extraConditions = new StringCollection();
            StringCollection addConditions = new StringCollection(); // ADD 2008/10/20

            // �Ώ۔N�� -----------------------------------------------------------------------------------------------------------
            // --- DEL 2008/10/20 -------------------------------->>>>>
            //string st_Year = string.Empty;
            //string ed_Year = string.Empty;
            //string st_Month = string.Empty;
            //string ed_Month = string.Empty;
            //string st_YearMonth = string.Empty;
            //string ed_YearMonth = string.Empty;

            //if (this._extrInfo_ShipGoodsAnalyze.St_AddUpYearMonth != 0)
            //{
            //    st_Year = Convert.ToString(this._extrInfo_ShipGoodsAnalyze.St_AddUpYearMonth / 100);
            //    st_Month = Convert.ToString(this._extrInfo_ShipGoodsAnalyze.St_AddUpYearMonth % 100);
            //    // �� 2008.04.03 980081 c
            //    //st_YearMonth = st_Year + "/" + st_Month;
            //    if (this._extrInfo_ShipGoodsAnalyze.St_AddUpYearMonth % 100 >= 10)
            //        st_YearMonth = st_Year + "/" + st_Month;
            //    else
            //        st_YearMonth = st_Year + "/0" + st_Month;
            //    // �� 2008.04.03 980081 c
            //}
            //else
            //{
            //    st_YearMonth = ct_Extr_Top;
            //}

            //if (this._extrInfo_ShipGoodsAnalyze.Ed_AddUpYearMonth != 0)
            //{
            //    ed_Year = Convert.ToString(this._extrInfo_ShipGoodsAnalyze.Ed_AddUpYearMonth / 100);
            //    ed_Month = Convert.ToString(this._extrInfo_ShipGoodsAnalyze.Ed_AddUpYearMonth % 100);
            //    // �� 2008.04.03 980081 c
            //    //ed_YearMonth = ed_Year + "/" + ed_Month;
            //    if (this._extrInfo_ShipGoodsAnalyze.Ed_AddUpYearMonth % 100 >= 10)
            //        ed_YearMonth = ed_Year + "/" + ed_Month;
            //    else
            //        ed_YearMonth = ed_Year + "/0" + ed_Month;
            //    // �� 2008.04.03 980081 c
            //}
            //else
            //{
            //    ed_YearMonth = ct_Extr_End;
            //}

            //StringCollection addConditions = new StringCollection();

            //this.EditCondition(ref extraConditions, string.Format("�Ώۊ���  " + ct_RangeConst, st_YearMonth, ed_YearMonth));
            // --- DEL 2008/10/20 --------------------------------<<<<<

            // �Ώ۔N��
            this.EditCondition(ref addConditions, string.Format("�Ώ۔N��" + ct_RangeConst,
                                                                    this._extrInfo_ShipGoodsAnalyze.St_AddUpYearMonth.ToString("yyyy/MM"),
                                                                    this._extrInfo_ShipGoodsAnalyze.Ed_AddUpYearMonth.ToString("yyyy/MM"))); // ADD 2008/10/20s

            // �W�v���@ ----------------------------------------------------------------------------------------------------
            // --- DEL 2008/10/20 -------------------------------->>>>>
            //string sTotalWayName = string.Empty;
            //if (this._extrInfo_ShipGoodsAnalyze.TotalWay)
            //{
            //    sTotalWayName = "�S��";
            //}
            //else
            //{
            //    sTotalWayName = "���_��";
            //}
            // --- DEL 2008/10/20 --------------------------------<<<<<
            // �W�v���@
            this.EditCondition(ref addConditions, string.Format("�W�v���@�F{0}", this._extrInfo_ShipGoodsAnalyze.TtlTypeName)); // ADD 2008/10/20

            // --- ADD 2008/10/20 -------------------------------->>>>>
            if (this._extrInfo_ShipGoodsAnalyze.Ex_StockCreateDate != null && this._extrInfo_ShipGoodsAnalyze.Ex_StockCreateDate != DateTime.MinValue)
            {
                // �݌ɓo�^��
                this.EditCondition(ref addConditions, string.Format("�݌ɓo�^���F{0} {1}",
                    this._extrInfo_ShipGoodsAnalyze.Ex_StockCreateDate.ToString("yyyy/MM/dd"), this._extrInfo_ShipGoodsAnalyze.StockCreateDateDivTitle));
            }
            // --- ADD 2008/10/20 --------------------------------<<<<<

            // �ݎ�w�� ----------------------------------------------------------------------------------------------------
            // --- DEL 2008/10/20 -------------------------------->>>>>
            //string sSalesOrderDivName = string.Empty;

            //switch (this._extrInfo_ShipGoodsAnalyze.RsltTtlDiv)
            //{
            //    case ExtrInfo_ShipGoodsAnalyze.RsltTtlDivState.Acquire:
            //        sSalesOrderDivName = ExtrInfo_ShipGoodsAnalyze.ct_RsltTtlDivState_Acquire;
            //        break;
            //    case ExtrInfo_ShipGoodsAnalyze.RsltTtlDivState.Stock:
            //        sSalesOrderDivName = ExtrInfo_ShipGoodsAnalyze.ct_RsltTtlDivState_Stock;
            //        break;
            //    case ExtrInfo_ShipGoodsAnalyze.RsltTtlDivState.Total:
            //        sSalesOrderDivName = ExtrInfo_ShipGoodsAnalyze.ct_RsltTtlDivState_Total;
            //        break;
            //    default:
            //        sSalesOrderDivName = string.Empty;
            //        break;
            //}
            //this.EditCondition(ref addConditions, string.Format("�ݎ�w��F{0}", sSalesOrderDivName));
            // --- DEL 2008/10/20 --------------------------------<<<<<
            // �ݎ�w��
            this.EditCondition(ref addConditions, string.Format("�ݎ�w��F{0}", this._extrInfo_ShipGoodsAnalyze.RsltTtlDivTitle)); // ADD 2008/10/20

            // ���z�P�� ----------------------------------------------------------------------------------------------------
            // --- DEL 2008/10/20 --------------------------------<<<<<
            //string sMoneyUnitName = string.Empty;

            //switch (this._extrInfo_ShipGoodsAnalyze.MoneyUnit)
            //{
            //    case ExtrInfo_ShipGoodsAnalyze.MoneyUnitState.One:
            //        sMoneyUnitName = ExtrInfo_ShipGoodsAnalyze.ct_MoneyUnitState_One;
            //        break;
            //    case ExtrInfo_ShipGoodsAnalyze.MoneyUnitState.Thousand:
            //        sMoneyUnitName = ExtrInfo_ShipGoodsAnalyze.ct_MoneyUnitState_Thousand;
            //        break;
            //    default:
            //        sMoneyUnitName = string.Empty;
            //        break;
            //}
            //this.EditCondition(ref addConditions, string.Format("���z�P�ʁF{0}", sMoneyUnitName));
            // --- DEL 2008/10/20 --------------------------------<<<<<
            // ���z�P��
            this.EditCondition(ref addConditions, string.Format("���z�P�ʁF{0}", this._extrInfo_ShipGoodsAnalyze.MoneyUnitStateTitle)); // ADD 2008/10/20

            // ���ʕt�ݒ� ----------------------------------------------------------------------------------------------------
            // --- DEL 2008/10/20 -------------------------------->>>>>
            //string sRankSectionName = string.Empty;

            //switch (this._extrInfo_ShipGoodsAnalyze.RankSection)
            //{
            //    case ExtrInfo_ShipGoodsAnalyze.RankSectionState.All:
            //        sRankSectionName = ExtrInfo_ShipGoodsAnalyze.ct_RankSectionState_All;
            //        break;
            //    case ExtrInfo_ShipGoodsAnalyze.RankSectionState.Section:
            //        sRankSectionName = ExtrInfo_ShipGoodsAnalyze.ct_RankSectionState_Section;
            //        break;
            //    default:
            //        sRankSectionName = string.Empty;
            //        break;
            //}

            //string sRankHighLowName = string.Empty;

            //switch (this._extrInfo_ShipGoodsAnalyze.RankHighLow)
            //{
            //    case ExtrInfo_ShipGoodsAnalyze.RankHighLowState.High:
            //        sRankHighLowName = ExtrInfo_ShipGoodsAnalyze.ct_RankHighLowState_High;
            //        break;
            //    case ExtrInfo_ShipGoodsAnalyze.RankHighLowState.Low:
            //        sRankHighLowName = ExtrInfo_ShipGoodsAnalyze.ct_RankHighLowState_Low;
            //        break;
            //    default:
            //        sRankHighLowName = string.Empty;
            //        break;
            //}

            //string sRankOrderMaxName = string.Empty;

            //sRankOrderMaxName = _extrInfo_ShipGoodsAnalyze.RankOrderMax.ToString();

            //this.EditCondition(ref addConditions, string.Format("���ʕt���ݒ�F{0} {1} {2}�ʂ܂�", sRankSectionName, sRankHighLowName, sRankOrderMaxName));
            // --- DEL 2008/10/20 --------------------------------<<<<<
            // ���ʕt�ݒ�
            this.EditCondition(ref addConditions, string.Format("���ʐݒ�F{0} {1} {2}�ʂ܂�", 
                                                                this._extrInfo_ShipGoodsAnalyze.RankSectionStateTitle, 
                                                                this._extrInfo_ShipGoodsAnalyze.RankHighLowStateTitle,
                                                                this._extrInfo_ShipGoodsAnalyze.RankOrderMax)); // ADD 2008/10/20

            // --- ADD 2008/10/20 -------------------------------->>>>>
            // ����
            if (this._extrInfo_ShipGoodsAnalyze.NewPageDiv != ExtrInfo_ShipGoodsAnalyze.NewPageDivState.None)
            {
                this.EditCondition(ref addConditions, string.Format("���ŁF{0}", this._extrInfo_ShipGoodsAnalyze.NewPageDivStateTitle));
            }
            // --- ADD 2008/10/20 --------------------------------<<<<<

            //------ ADD START 2014/12/22 ������ FOR Redmine#44209���� ------>>>>>
            if (this._extrInfo_ShipGoodsAnalyze.GoodsNoTtlDivTitle.Equals("���Z"))
            {
                //�i�ԏW�v�敪
                this.EditCondition(ref addConditions, string.Format("�i�ԏW�v�敪�F{0}", this._extrInfo_ShipGoodsAnalyze.GoodsNoTtlDivTitle));
                //�i�ԕ\���敪
                this.EditCondition(ref addConditions, string.Format("�i�ԕ\���敪�F{0}", this._extrInfo_ShipGoodsAnalyze.GoodsNoShowDivTitle));
            }
            else 
            {
                //�i�ԏW�v�敪
                this.EditCondition(ref addConditions, string.Format("�i�ԏW�v�敪�F{0}", this._extrInfo_ShipGoodsAnalyze.GoodsNoTtlDivTitle));
            }
            //------ ADD END 2014/12/22 ������ FOR Redmine#44209���� ------<<<<<

            // --- ADD 2008/10/20 -------------------------------->>>>>
            string stCode;
            string edCode;

            // �d����
            if ((this._extrInfo_ShipGoodsAnalyze.St_SupplierCd != 0) ||
                (this._extrInfo_ShipGoodsAnalyze.Ed_SupplierCd != 0))
            {
                stCode = this._extrInfo_ShipGoodsAnalyze.St_SupplierCd.ToString("000000");
                edCode = this._extrInfo_ShipGoodsAnalyze.Ed_SupplierCd.ToString("000000");
                if (this._extrInfo_ShipGoodsAnalyze.St_SupplierCd == 0) stCode = ct_Extr_Top;
                if (this._extrInfo_ShipGoodsAnalyze.Ed_SupplierCd == 0) edCode = ct_Extr_End;

                this.EditCondition(ref addConditions, string.Format("�d����" + ct_RangeConst, stCode, edCode));
            }

            // ���[�J�[
            if ((this._extrInfo_ShipGoodsAnalyze.St_GoodsMakerCd != 0) ||
                (this._extrInfo_ShipGoodsAnalyze.Ed_GoodsMakerCd != 0))
            {
                stCode = this._extrInfo_ShipGoodsAnalyze.St_GoodsMakerCd.ToString("0000");
                edCode = this._extrInfo_ShipGoodsAnalyze.Ed_GoodsMakerCd.ToString("0000");
                if (this._extrInfo_ShipGoodsAnalyze.St_GoodsMakerCd == 0) stCode = ct_Extr_Top;
                if (this._extrInfo_ShipGoodsAnalyze.Ed_GoodsMakerCd == 0) edCode = ct_Extr_End;

                this.EditCondition(ref addConditions, string.Format("���[�J�[" + ct_RangeConst, stCode, edCode));
            }

            // ���i�啪��
            if ((this._extrInfo_ShipGoodsAnalyze.St_GoodsLGroup != 0) ||
                (this._extrInfo_ShipGoodsAnalyze.Ed_GoodsLGroup != 0))
            {
                stCode = this._extrInfo_ShipGoodsAnalyze.St_GoodsLGroup.ToString("0000");
                edCode = this._extrInfo_ShipGoodsAnalyze.Ed_GoodsLGroup.ToString("0000");
                if (this._extrInfo_ShipGoodsAnalyze.St_GoodsLGroup == 0) stCode = ct_Extr_Top;
                if (this._extrInfo_ShipGoodsAnalyze.Ed_GoodsLGroup == 0) edCode = ct_Extr_End;

                this.EditCondition(ref addConditions, string.Format("���i�啪��" + ct_RangeConst, stCode, edCode));
            }

            // ���i������
            if ((this._extrInfo_ShipGoodsAnalyze.St_GoodsMGroup != 0) ||
                (this._extrInfo_ShipGoodsAnalyze.Ed_GoodsMGroup != 0))
            {
                stCode = this._extrInfo_ShipGoodsAnalyze.St_GoodsMGroup.ToString("0000");
                edCode = this._extrInfo_ShipGoodsAnalyze.Ed_GoodsMGroup.ToString("0000");
                if (this._extrInfo_ShipGoodsAnalyze.St_GoodsMGroup == 0) stCode = ct_Extr_Top;
                if (this._extrInfo_ShipGoodsAnalyze.Ed_GoodsMGroup == 0) edCode = ct_Extr_End;

                this.EditCondition(ref addConditions, string.Format("���i������" + ct_RangeConst, stCode, edCode));
            }

            // �O���[�v�R�[�h
            if ((this._extrInfo_ShipGoodsAnalyze.St_BLGroupCode != 0) ||
                (this._extrInfo_ShipGoodsAnalyze.Ed_BLGroupCode != 0))
            {
                stCode = this._extrInfo_ShipGoodsAnalyze.St_BLGroupCode.ToString("00000");
                edCode = this._extrInfo_ShipGoodsAnalyze.Ed_BLGroupCode.ToString("00000");
                if (this._extrInfo_ShipGoodsAnalyze.St_BLGroupCode == 0) stCode = ct_Extr_Top;
                if (this._extrInfo_ShipGoodsAnalyze.Ed_BLGroupCode == 0) edCode = ct_Extr_End;

                this.EditCondition(ref addConditions, string.Format("�O���[�v�R�[�h" + ct_RangeConst, stCode, edCode));
            }

            // �a�k�R�[�h
            if ((this._extrInfo_ShipGoodsAnalyze.St_BLGoodsCode != 0) ||
                (this._extrInfo_ShipGoodsAnalyze.Ed_BLGoodsCode != 0))
            {
                stCode = this._extrInfo_ShipGoodsAnalyze.St_BLGoodsCode.ToString("00000");
                edCode = this._extrInfo_ShipGoodsAnalyze.Ed_BLGoodsCode.ToString("00000");
                if (this._extrInfo_ShipGoodsAnalyze.St_BLGoodsCode == 0) stCode = ct_Extr_Top;
                if (this._extrInfo_ShipGoodsAnalyze.Ed_BLGoodsCode == 0) edCode = ct_Extr_End;

                this.EditCondition(ref addConditions, string.Format("�a�k�R�[�h" + ct_RangeConst, stCode, edCode));
            }

            // �i��
            if ((this._extrInfo_ShipGoodsAnalyze.St_GoodsNo.TrimEnd() != string.Empty) ||
                (this._extrInfo_ShipGoodsAnalyze.Ed_GoodsNo.TrimEnd() != string.Empty))
            {
                stCode = this._extrInfo_ShipGoodsAnalyze.St_GoodsNo.TrimEnd();
                edCode = this._extrInfo_ShipGoodsAnalyze.Ed_GoodsNo.TrimEnd();
                if (this._extrInfo_ShipGoodsAnalyze.St_GoodsNo.TrimEnd() == string.Empty) stCode = ct_Extr_Top;
                if (this._extrInfo_ShipGoodsAnalyze.Ed_GoodsNo.TrimEnd() == string.Empty) edCode = ct_Extr_End;

                this.EditCondition(ref addConditions, string.Format("�i��" + ct_RangeConst, stCode, edCode));
            }
            // --- ADD 2008/10/20 --------------------------------<<<<<

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
		/// <br>Date       : 2007.12.03</br>
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
		/// <br>Programmer : 20081 �D�c �E�l</br>
		/// <br>Date       : 2007.12.03</br>
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
		/// <br>Date       : 2007.12.03</br>
		/// </remarks>
		private DialogResult MsgDispProc(emErrorLevel iLevel, string iMsg, int iSt, MessageBoxButtons iButton, MessageBoxDefaultButton iDefButton)
		{
			return TMsgDisp.Show(iLevel, "DCTOK02052P", iMsg, iSt, iButton, iDefButton);
		}

		#endregion
		#endregion
	}
}
