using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Text;
using System.Windows.Forms;

using Broadleaf.Application.Common;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Controller.Util;    // ADD 2008/09/30 �s��Ή�[5713],[5714]
using Broadleaf.Application.UIData;
using Broadleaf.Drawing.Printing;
using Broadleaf.Library.Globarization;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Text;
using Broadleaf.Library.Windows.Forms;

namespace Broadleaf.Drawing.Printing
{
	/// <summary>
	/// �݌ɖ��o�׈ꗗ�\����N���X
	/// </summary>
	/// <remarks>
    /// <br>Note       : �݌ɖ��o�׈ꗗ�\�̈�����s���B</br>
	/// <br>Programmer : 22018 ��� ���b</br>
	/// <br>Date       : 2007.09.19</br>
    /// <br></br>
    /// <br>UpdateNote : 2008.07.17 30416 ���� ����</br>
    /// <br>           : 2008/10/06       �Ɠc �M�u�@�o�O�C���A�d�l�ύX�Ή�</br>
    /// <br>Update Note: 2009/03/17 30452 ��� �r��</br>
    /// <br>            �E��Q�Ή�12706</br>
    /// </remarks>
	class DCZAI02163PA: IPrintProc
	{

		#region �� Constructor
		/// <summary>
		/// �݌ɖ��o�׈ꗗ�\����N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
		/// <br>Note       : �݌ɖ��o�׈ꗗ�\����N���X�̃C���X�^���X�̍쐬���s���B</br>
		/// <br>Programmer : 22018 ��� ���b</br>
		/// <br>Date       : 2007.09.19</br>
		/// </remarks>
		public DCZAI02163PA()
		{
		}

		/// <summary>
		/// �݌ɖ��o�׈ꗗ�\����N���X�R���X�g���N�^
		/// </summary>
		/// <param name="printInfo">������I�u�W�F�N�g</param>
		/// <remarks>
		/// <br>Note       : �݌ɖ��o�׈ꗗ�\����N���X�̃C���X�^���X�̍쐬���s���B</br>
		/// <br>Programmer : 22018 ��� ���b</br>
		/// <br>Date       : 2007.09.19</br>
		/// </remarks>
		public DCZAI02163PA( object printInfo )
		{
			this._printInfo = printInfo as SFCMN06002C;
			this._stockNoShipmentListCndtn = this._printInfo.jyoken as StockNoShipmentListCndtn;
		}
		#endregion �� Constructor

		#region �� Pricate Const
		private const string ct_ReportForm_NameSpace = "Broadleaf.Drawing.Printing";
		private const string ct_Space			= "�@";
        //--- DEL 2008/07/17 ---------->>>>>
        //private const string ct_Extr_Top		= "�s�n�o";
        //private const string ct_Extr_End		= "�d�m�c";
        //--- DEL 2008/07/17 ----------<<<<<
        //--- ADD 2008/07/17 ---------->>>>>
        private const string ct_Extr_Top = RangeUtil.FROM_BEGIN;    // MOD 2008/09/30 �s��Ή�[5713],[5714] "�ŏ�����"��RangeUtil.FROM_BEGIN
        private const string ct_Extr_End = RangeUtil.TO_END;        // MOD 2008/09/30 �s��Ή�[5713],[5714] "�Ō�܂�"��RangeUtil.TO_END
        //--- ADD 2008/07/17 ----------<<<<<
        private const string ct_RangeConst = "�F{0} �` {1}";
		#endregion �� Pricate Const

		#region �� Private Member
		private SFCMN06002C _printInfo;					// ������N���X
		private StockNoShipmentListCndtn _stockNoShipmentListCndtn;		// ���o�����N���X
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
		/// <br>Programmer : 22018 ��� ���b</br>
		/// <br>Date       : 2007.09.19</br>
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
		/// <br>Programmer : 22018 ��� ���b</br>
		/// <br>Date       : 2007.09.19</br>
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
                prtRpt.DataMember = DCZAI02165EA.ct_Tbl_StockNoShipment;
				
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
		/// <br>Programmer : 22018 ��� ���b</br>
		/// <br>Date       : 2007.09.19</br>
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
		/// <br>Programmer : 22018 ��� ���b</br>
		/// <br>Date       : 2007.09.19</br>
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
		/// <br>Programmer : 22018 ��� ���b</br>
		/// <br>Date       : 2007.09.19</br>
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
			commonInfo.PrintMax    = (this._printInfo.rdData as DataView).Count;
			
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
		/// <br>Programmer : 22018 ��� ���b</br>
		/// <br>Date       : 2007.09.19</br>
		/// </remarks>
		private int SettingProperty(ref DataDynamics.ActiveReports.ActiveReport3 rpt)
		{
			int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;

			// ActiveReport�C���^�[�t�F�[�X�ɃL���X�g
			IPrintActiveReportTypeList instance = rpt as IPrintActiveReportTypeList;

			// ��������擾
            StockNoShipmentListCndtn extraInfo = (StockNoShipmentListCndtn)this._printInfo.jyoken;

			// �\�[�g���v���p�e�B�ݒ�
			instance.PageHeaderSortOderTitle = this._stockNoShipmentListCndtn.PrintSortDivStateTitle;
			
			// ���[�o�͐ݒ���擾 
			PrtOutSet prtOutSet;
			string message;
			int st = StockNoShipmentListAcs.ReadPrtOutSet(out prtOutSet, out message);
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
            object[] titleObj = new object[] { this._stockNoShipmentListCndtn.ReportSubTitle, "�݌ɖ��o�׈ꗗ�\" };
            instance.PageHeaderSubtitle = string.Format("{0}{1}", titleObj);

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
		/// <br>Programmer : 22018 ��� ���b</br>
		/// <br>Date       : 2007.09.19</br>
		/// </remarks>
		private void MakeExtarCondition( out StringCollection extraConditions )
		{
            extraConditions = new StringCollection();
            StringCollection addConditions = new StringCollection();

            // �Ώ۔N�� ----------------------------------------------------------------------------------------------------
            string st_ShipArrivalDate = string.Empty;
            string ed_ShipArrivalDate = string.Empty;

            // �J�n��I���̂����ꂩ�����͂���Ă���Έ�
            if ((this._stockNoShipmentListCndtn.St_AddUpYearMonth != DateTime.MinValue) || (this._stockNoShipmentListCndtn.Ed_AddUpYearMonth != DateTime.MinValue))
            {
                // �J�n
                if (this._stockNoShipmentListCndtn.St_AddUpYearMonth != DateTime.MinValue)
                    //st_ShipArrivalDate = this._stockNoShipmentListCndtn.St_AddUpYearMonth.ToString("yyyy�NMM��");     //DEL 2008/10/06 �����ύX
                    st_ShipArrivalDate = this._stockNoShipmentListCndtn.St_AddUpYearMonth.ToString("yyyy/MM");          //ADD 2008/10/06
                else
                    st_ShipArrivalDate = ct_Extr_Top;
                // �I��
                if (this._stockNoShipmentListCndtn.Ed_AddUpYearMonth != DateTime.MinValue)
                    //ed_ShipArrivalDate = this._stockNoShipmentListCndtn.Ed_AddUpYearMonth.ToString("yyyy�NMM��");     //DEL 2008/10/06 �����ύX
                    ed_ShipArrivalDate = this._stockNoShipmentListCndtn.Ed_AddUpYearMonth.ToString("yyyy/MM");          //ADD 2008/10/06
                else
                    ed_ShipArrivalDate = ct_Extr_End;

                this.EditCondition(
                    ref addConditions,
                    string.Format(
                        "�Ώ۔N��" + ct_RangeConst,   // MOD 2008/10/02 �s��Ή�[5711] "�������F"��"�Ώ۔N��"
                        st_ShipArrivalDate,
                        ed_ShipArrivalDate));
            }

            // �݌ɓo�^�� ----------------------------------------------------------------------------------------------------
            this.EditCondition( ref addConditions, String.Format( "�݌ɓo�^���F{0}{1}",
                                                                    //this._stockNoShipmentListCndtn.StockCreateDate.ToString( "yyyy�NMM��dd��" ),      //DEL 2008/10/06 �����ύX
                                                                    this._stockNoShipmentListCndtn.StockCreateDate.ToString("yyyy/MM/dd"),
                                                                    this._stockNoShipmentListCndtn.StockCreateDateDivStateTitle));

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //// �\�[�g�� ----------------------------------------------------------------------------------------------------
            //this.EditCondition(ref addConditions, String.Format("�\�[�g���F{0}",
            //                                                        this._stockNoShipmentListCndtn.PrintSortDivStateTitle));
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            // �q��
            // DEL 2008/09/30 �s��Ή�[5513],[5714]��
            //if ( this._stockNoShipmentListCndtn.St_WarehouseCode != string.Empty || this._stockNoShipmentListCndtn.Ed_WarehouseCode != string.Empty )
            if (!RangeUtil.WarehouseCode.IsAllRange(this._stockNoShipmentListCndtn.St_WarehouseCode, this._stockNoShipmentListCndtn.Ed_WarehouseCode))  // ADD 2008/09/29 �s��Ή�[5713],[5714]
            {
                // DEL 2008/09/30 �s��Ή�[5713],[5714]---------->>>>>
                //string st_WarehouseCode = this._stockNoShipmentListCndtn.St_WarehouseCode;
                //string ed_WarehouseCode = this._stockNoShipmentListCndtn.Ed_WarehouseCode;

                //if ( st_WarehouseCode == string.Empty )
                //    st_WarehouseCode = ct_Extr_Top;
                //if ( ed_WarehouseCode == string.Empty )
                //    ed_WarehouseCode = ct_Extr_End;

                //this.EditCondition(ref addConditions,
                //                    string.Format("�q��" + ct_RangeConst, st_WarehouseCode, ed_WarehouseCode));
                // DEL 2008/09/30 �s��Ή�[5713],[5714]----------<<<<<

                // ADD 2008/09/30 �s��Ή�[5713],[5714]---------->>>>>
                string start= RangeUtil.WarehouseCode.GetStartString(this._stockNoShipmentListCndtn.St_WarehouseCode);
                string end  = RangeUtil.WarehouseCode.GetEndString(this._stockNoShipmentListCndtn.Ed_WarehouseCode);

                this.EditCondition(
                    ref addConditions,
                    string.Format("�q��" + ct_RangeConst, start, end)
                );
                // ADD 2008/09/30 �s��Ή�[5713],[5714]----------<<<<<
            }

            // �d����
            // DEL 2008/09/30 �s��Ή�[5713],[5714]��
            //if (this._stockNoShipmentListCndtn.St_CustomerCode != 0 || this._stockNoShipmentListCndtn.Ed_CustomerCode != 999999) 
            if (!RangeUtil.SupplierCode.IsAllRange(this._stockNoShipmentListCndtn.St_CustomerCode, this._stockNoShipmentListCndtn.Ed_CustomerCode)) // ADD 2008/09/29 �s��Ή�[5713],[5714]
            {
                // DEL 2008/09/30 �s��Ή�[5713],[5714]---------->>>>>
                //this.EditCondition(
                //    ref addConditions,
                //    string.Format( "�d����" + ct_RangeConst,
                //                    this._stockNoShipmentListCndtn.St_CustomerCode,
                //                    this._stockNoShipmentListCndtn.Ed_CustomerCode ) );
                // DEL 2008/09/30 �s��Ή�[5713],[5714]----------<<<<<

                // ADD 2008/09/30 �s��Ή�[5713],[5714]---------->>>>>
                string start= RangeUtil.SupplierCode.GetStartString(this._stockNoShipmentListCndtn.St_CustomerCode);
                string end  = RangeUtil.SupplierCode.GetEndString(this._stockNoShipmentListCndtn.Ed_CustomerCode);

                EditCondition(
                    ref addConditions,
                    string.Format("�d����" + ct_RangeConst, start, end)
                );
                // ADD 2008/09/30 �s��Ή�[5713],[5714]----------<<<<<
            }

            // ���[�J�[
            // DEL 2008/09/30 �s��Ή�[5713],[5714]��
            //if ( this._stockNoShipmentListCndtn.St_GoodsMakerCd != 0 || this._stockNoShipmentListCndtn.Ed_GoodsMakerCd != 999999 )
            if (!RangeUtil.GoodsMakerCode.IsAllRange(this._stockNoShipmentListCndtn.St_GoodsMakerCd, this._stockNoShipmentListCndtn.Ed_GoodsMakerCd))   // ADD 2008/09/29 �s��Ή�[5713],[5714]
            {
                // DEL 2008/09/30 �s��Ή�[5713],[5714]---------->>>>>
                
                //this.EditCondition(
                //    ref addConditions,
                //    string.Format( "���[�J�[" + ct_RangeConst,
                //                    this._stockNoShipmentListCndtn.St_GoodsMakerCd,
                //                    this._stockNoShipmentListCndtn.Ed_GoodsMakerCd ) );
                // DEL 2008/09/30 �s��Ή�[5713],[5714]----------<<<<<

                // ADD 2008/09/30 �s��Ή�[5713],[5714]---------->>>>>
                string start= RangeUtil.GoodsMakerCode.GetStartString(this._stockNoShipmentListCndtn.St_GoodsMakerCd);
                string end  = RangeUtil.GoodsMakerCode.GetEndString(this._stockNoShipmentListCndtn.Ed_GoodsMakerCd);

                this.EditCondition(
                    ref addConditions,
                    string.Format("���[�J�[" + ct_RangeConst, start, end)
                );
                // ADD 2008/09/30 �s��Ή�[5713],[5714]----------<<<<<

            }

            // �I��
            if ( this._stockNoShipmentListCndtn.St_WarehouseShelfNo != string.Empty || this._stockNoShipmentListCndtn.Ed_WarehouseShelfNo != string.Empty )
            {
                string st_WarehouseShelfNo = this._stockNoShipmentListCndtn.St_WarehouseShelfNo;
                string ed_WarehouseShelfNo = this._stockNoShipmentListCndtn.Ed_WarehouseShelfNo;

                if ( st_WarehouseShelfNo == string.Empty )
                    st_WarehouseShelfNo = ct_Extr_Top;
                if ( ed_WarehouseShelfNo == string.Empty )
                    ed_WarehouseShelfNo = ct_Extr_End;

                this.EditCondition(
                    ref addConditions,
                    //string.Format("�q�ɒI��" + ct_RangeConst, st_WarehouseShelfNo, ed_WarehouseShelfNo));     // DEL 2008.07.17
                    string.Format( "�I��" + ct_RangeConst, st_WarehouseShelfNo, ed_WarehouseShelfNo ) );        // ADD 2008.07.17
            }

            // ADD 2008/09/30 �s��Ή�[5712]---------->>>>>
            // ���i�啪��
            if (!RangeUtil.GoodsLGroupCode.IsAllRange(this._stockNoShipmentListCndtn.St_LargeGoodsGanreCode, this._stockNoShipmentListCndtn.Ed_LargeGoodsGanreCode))
            {
                string start= RangeUtil.GoodsLGroupCode.GetStartString(this._stockNoShipmentListCndtn.St_LargeGoodsGanreCode);
                string end  = RangeUtil.GoodsLGroupCode.GetEndString(this._stockNoShipmentListCndtn.Ed_LargeGoodsGanreCode);

                this.EditCondition(
                    ref addConditions,
                    string.Format("���i�啪��" + ct_RangeConst, start, end)
                );
            }

            // ���i������
            if (!RangeUtil.GoodsMGroupCode.IsAllRange(this._stockNoShipmentListCndtn.St_MediumGoodsGanreCode, this._stockNoShipmentListCndtn.Ed_MediumGoodsGanreCode))
            {
                string start= RangeUtil.GoodsMGroupCode.GetStartString(this._stockNoShipmentListCndtn.St_MediumGoodsGanreCode);
                string end  = RangeUtil.GoodsMGroupCode.GetEndString(this._stockNoShipmentListCndtn.Ed_MediumGoodsGanreCode);

                this.EditCondition(
                    ref addConditions,
                    string.Format("���i������" + ct_RangeConst, start, end)
                );
            }

            // �O���[�v�R�[�h
            if (!RangeUtil.BLGroupCode.IsAllRange(this._stockNoShipmentListCndtn.St_DetailGoodsGanreCode, this._stockNoShipmentListCndtn.Ed_DetailGoodsGanreCode))
            {
                string start= RangeUtil.BLGroupCode.GetStartString(this._stockNoShipmentListCndtn.St_DetailGoodsGanreCode);
                string end  = RangeUtil.BLGroupCode.GetEndString(this._stockNoShipmentListCndtn.Ed_DetailGoodsGanreCode);

                this.EditCondition(
                    ref addConditions,
                    string.Format("�O���[�v�R�[�h" + ct_RangeConst, start, end)
                );
            }

            // ���i�敪
            if (!RangeUtil.EnterpriseGanreCode.IsAllRange(this._stockNoShipmentListCndtn.St_EnterpriseGanreCode, this._stockNoShipmentListCndtn.Ed_EnterpriseGanreCode))
            {
                string start= RangeUtil.EnterpriseGanreCode.GetStartString(this._stockNoShipmentListCndtn.St_EnterpriseGanreCode);
                string end  = RangeUtil.EnterpriseGanreCode.GetEndString(this._stockNoShipmentListCndtn.Ed_EnterpriseGanreCode);

                this.EditCondition(
                    ref addConditions,
                    string.Format("���i�敪" + ct_RangeConst, start, end)
                );
            }

            // ADD 2008/09/30 �s��Ή�[5712]----------<<<<<

            // �a�k�R�[�h
            // DEL 2008/09/30 �s��Ή�[5713],[5714]��
            //if ( this._stockNoShipmentListCndtn.St_BLGoodsCode != 0 || this._stockNoShipmentListCndtn.Ed_BLGoodsCode != 99999999 )
            if (!RangeUtil.BLGoodsCode.IsAllRange(this._stockNoShipmentListCndtn.St_BLGoodsCode, this._stockNoShipmentListCndtn.Ed_BLGoodsCode))    // ADD 2008/09/29 �s��Ή�[5713],[5714]
            {
                // DEL 2008/09/30 �s��Ή�[5713],[5714]---------->>>>>
                //this.EditCondition(
                //    ref addConditions,
                //    //string.Format("�a�k���i�R�[�h" + ct_RangeConst,       // DEL 2008.07.17
                //    string.Format( "�a�k�R�[�h" + ct_RangeConst,            // ADD 2008.07.17
                //                    this._stockNoShipmentListCndtn.St_BLGoodsCode,
                //                    this._stockNoShipmentListCndtn.Ed_BLGoodsCode ) );
                // DEL 2008/09/30 �s��Ή�[5713],[5714]----------<<<<<

                // ADD 2008/09/30 �s��Ή�[5713],[5714]---------->>>>>
                string start= RangeUtil.BLGoodsCode.GetStartString(this._stockNoShipmentListCndtn.St_BLGoodsCode);
                string end  = RangeUtil.BLGoodsCode.GetEndString(this._stockNoShipmentListCndtn.Ed_BLGoodsCode);

                EditCondition(
                    ref addConditions,
                    string.Format("�a�k�R�[�h" + ct_RangeConst, start, end)
                );
                // ADD 2008/09/30 �s��Ή�[5713],[5714]----------<<<<<
            }

            // �i��
            if ( this._stockNoShipmentListCndtn.St_GoodsNo != string.Empty || this._stockNoShipmentListCndtn.Ed_GoodsNo != string.Empty )
            {
                string st_GoodsNo = this._stockNoShipmentListCndtn.St_GoodsNo;
                string ed_GoodsNo = this._stockNoShipmentListCndtn.Ed_GoodsNo;

                if ( st_GoodsNo == string.Empty )
                    st_GoodsNo = ct_Extr_Top;
                if ( ed_GoodsNo == string.Empty )
                    ed_GoodsNo = ct_Extr_End;

                this.EditCondition(
                    ref addConditions,
                    //string.Format("���i�ԍ�" + ct_RangeConst, st_GoodsNo, ed_GoodsNo));       // DEL 2008.07.17
                    string.Format( "�i��" + ct_RangeConst, st_GoodsNo, ed_GoodsNo ) );          // ADD 2008.07.17
            }

            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

            // ADD 2008/10/08 �s��Ή�[6289]---------->>>>>
            // �Ǘ��敪1
            if ((this._stockNoShipmentListCndtn.PartsManagementDivide1 != null)
                    &&
                (this._stockNoShipmentListCndtn.PartsManagementDivide1.Length > 0)
            )
            {
                StringBuilder partsMngDiv1 = new StringBuilder("�Ǘ��敪1�F");  // LITERAL:
                Array.Sort<string>(this._stockNoShipmentListCndtn.PartsManagementDivide1);
                foreach (string partsMngDiv1Item in this._stockNoShipmentListCndtn.PartsManagementDivide1)
                {
                    partsMngDiv1.Append(partsMngDiv1Item);
                }

                EditCondition(ref addConditions, partsMngDiv1.ToString());
            }

            // �Ǘ��敪2
            if ((this._stockNoShipmentListCndtn.PartsManagementDivide2 != null)
                    &&
                (this._stockNoShipmentListCndtn.PartsManagementDivide2.Length > 0)
            )
            {
                StringBuilder partsMngDiv2 = new StringBuilder("�Ǘ��敪2�F");  // LITERAL:
                Array.Sort<string>(this._stockNoShipmentListCndtn.PartsManagementDivide2);
                foreach (string partsMngDiv2Item in this._stockNoShipmentListCndtn.PartsManagementDivide2)
                {
                    partsMngDiv2.Append(partsMngDiv2Item);
                }

                EditCondition(ref addConditions, partsMngDiv2.ToString());
            }
            // ADD 2008/10/08 �s��Ή�[6289]----------<<<<<

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
		/// <br>Programmer : 22018 ��� ���b</br>
		/// <br>Date       : 2007.09.19</br>
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
		/// <br>Programmer : 22018 ��� ���b</br>
		/// <br>Date       : 2007.09.19</br>
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
		/// <br>Programmer : 22018 ��� ���b</br>
		/// <br>Date       : 2007.09.19</br>
		/// </remarks>
		private DialogResult MsgDispProc(emErrorLevel iLevel, string iMsg, int iSt, MessageBoxButtons iButton, MessageBoxDefaultButton iDefButton)
		{
			return TMsgDisp.Show(iLevel, "MAZAI02032P", iMsg, iSt, iButton, iDefButton);
		}

		#endregion
		#endregion
	}
}
