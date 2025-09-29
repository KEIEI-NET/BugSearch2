using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Text;
using System.Windows.Forms;

using Broadleaf.Application.Common;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Controller.Util;    // ADD 2008/10/01 �s��Ή�[5683]
using Broadleaf.Application.UIData;
using Broadleaf.Drawing.Printing;
using Broadleaf.Library.Globarization;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Text;
using Broadleaf.Library.Windows.Forms;

namespace Broadleaf.Drawing.Printing
{
	/// <summary>
	/// �݌ɓ��o�׈ꗗ�\����N���X
	/// </summary>
	/// <remarks>
    /// <br>Note       : �݌ɓ��o�׈ꗗ�\�̈�����s���B</br>
	/// <br>Programmer : 22018 ��� ���b</br>
	/// <br>Date       : 2007.09.19</br>
    /// <br>Update Note: 2009/03/17 30452 ��� �r��</br>
    /// <br>            �E��Q�Ή�12705</br>
	/// </remarks>
	class DCZAI02123PA: IPrintProc
	{

		#region �� Constructor
		/// <summary>
		/// �݌ɓ��o�׈ꗗ�\����N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
		/// <br>Note       : �݌ɓ��o�׈ꗗ�\����N���X�̃C���X�^���X�̍쐬���s���B</br>
		/// <br>Programmer : 22018 ��� ���b</br>
		/// <br>Date       : 2007.09.19</br>
		/// </remarks>
		public DCZAI02123PA()
		{
		}

		/// <summary>
		/// �݌ɓ��o�׈ꗗ�\����N���X�R���X�g���N�^
		/// </summary>
		/// <param name="printInfo">������I�u�W�F�N�g</param>
		/// <remarks>
		/// <br>Note       : �݌ɓ��o�׈ꗗ�\����N���X�̃C���X�^���X�̍쐬���s���B</br>
		/// <br>Programmer : 22018 ��� ���b</br>
		/// <br>Date       : 2007.09.19</br>
		/// </remarks>
		public DCZAI02123PA( object printInfo )
		{
			this._printInfo = printInfo as SFCMN06002C;
			this._stockShipArrivalListCndtn = this._printInfo.jyoken as StockShipArrivalListCndtn;
		}
		#endregion �� Constructor

		#region �� Private Const
		private const string ct_ReportForm_NameSpace = "Broadleaf.Drawing.Printing";
		private const string ct_Space			= "�@";
        //--- DEL 2008/07/16 ---------->>>>>
        //private const string ct_Extr_Top		= "�s�n�o";
        //private const string ct_Extr_End		= "�d�m�c";
        //--- DEL 2008/07/16 ----------<<<<<
        //--- ADD 2008/07/16 ---------->>>>>
        private const string ct_Extr_Top = RangeUtil.FROM_BEGIN;    // MOD 2008/10/01 �s��Ή�[5683] "�ŏ�����"��RangeUtil.FROM_BEGIN;
        private const string ct_Extr_End = RangeUtil.TO_END;        // MOD 2008/10/01 �s��Ή�[5683] "�Ō�܂�"��RangeUtil.TO_END;
        //--- ADD 2008/07/16 ----------<<<<<
        private const string ct_RangeConst = "�F{0} �` {1}";
        
        private const string YYYY_MM_FORMAT = "yyyy/MM";    // ADD 2008/10/01 �s��Ή�[6008]
        private const string DATE_FORMAT = "yyyy/MM/dd";    // ADD 2008/10/01 �s��Ή�[6008]

		#endregion �� Pricate Const

		#region �� Private Member
		private SFCMN06002C _printInfo;					                    // ������N���X
		private StockShipArrivalListCndtn _stockShipArrivalListCndtn;		// ���o�����N���X
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
                prtRpt.DataMember = DCZAI02125EA.ct_Tbl_StockShipArrival;
				
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
		/// <param name="commonInfo"></param>
        /// <param name="rptObj"></param>
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
            commonInfo.PrintMax = (this._printInfo.rdData as DataView).Count;
			
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
            StockShipArrivalListCndtn extraInfo = (StockShipArrivalListCndtn)this._printInfo.jyoken;

			// �\�[�g���v���p�e�B�ݒ�
			instance.PageHeaderSortOderTitle = "";
			
			// ���[�o�͐ݒ���擾 
			PrtOutSet prtOutSet;
			string message;
			int st = StockShipArrivalListAcs.ReadPrtOutSet(out prtOutSet, out message);
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
            object[] titleObj = new object[]{"�݌ɓ��o�׈ꗗ�\"};
            instance.PageHeaderSubtitle = string.Format("{0}", titleObj);
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

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
		/// <br>Programmer : 22018 ��� ���b</br>
		/// <br>Date       : 2007.09.19</br>
		/// </remarks>
		private void MakeExtarCondition( out StringCollection extraConditions )
		{
            extraConditions = new StringCollection();
            StringCollection addConditions = new StringCollection();

            // DEL 2008/09/25 �s��Ή�[5616]---------->>>>>
            //// �o�͏��� ----------------------------------------------------------------------------------------------------
            //string st_ShipArrivalCnt = string.Empty;
            //string ed_ShipArrivalCnt = string.Empty;
            
            //st_ShipArrivalCnt = string.Format("{0}�ȏ�",this._stockShipArrivalListCndtn.St_ShipArrivalCnt);
            //ed_ShipArrivalCnt = string.Format("{0}�ȉ�",this._stockShipArrivalListCndtn.Ed_ShipArrivalCnt);

            //this.EditCondition(ref addConditions, String.Format("�o�͏����F{0}�@{1}{2}", 
            //                                                        this._stockShipArrivalListCndtn.ShipArrivalCntDivTitle,
            //                                                        st_ShipArrivalCnt,
            //                                                        ed_ShipArrivalCnt));

            //// ����^�C�v --------------------------------------------------------------------------------------------------
            //string shipArrivalPrintDivTitleExp = string.Empty;
            //if (this._stockShipArrivalListCndtn.ShipArrivalPrintDiv == StockShipArrivalListCndtn.ShipArrivalPrintDivState.ShipArrival) {
            //    shipArrivalPrintDivTitleExp = "��i�F�o�ׁ@���i�F����";
            //}
            //this.EditCondition( ref addConditions, String.Format("����^�C�v�F{0}�@{1}",
            //                                                        this._stockShipArrivalListCndtn.ShipArrivalPrintDivTitle,
            //                                                        shipArrivalPrintDivTitleExp) );

            //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            
            //// �݌ɓo�^�� ----------------------------------------------------------------------------------------------------
            //this.EditCondition( ref addConditions,
            //    string.Format( "�݌ɓo�^���F{0} {1}",
            //    this._stockShipArrivalListCndtn.StockCreateDate.ToString( "yyyy�NMM��dd�� " ), 
            //    this._stockShipArrivalListCndtn.StockCreateDateDivTitle) );
            // DEL 2008/09/25 �s��Ή�[5616]----------<<<<<

            // �o�͏��� ----------------------------------------------------------------------------------------------------
            this.EditCondition(ref addConditions, "�o�͏����F");    // ADD 2008/09/25 �s��Ή�[5616]

            // �Ώ۔N�� ----------------------------------------------------------------------------------------------------
            string st_ShipArrivalDate = string.Empty;
            string ed_ShipArrivalDate = string.Empty;
            //string ShipArrivalDateFormat = "yyyy�NMM��";

            // �J�n��I���̂����ꂩ�����͂���Ă���Έ�
            if ( (this._stockShipArrivalListCndtn.St_AddUpYearMonth != DateTime.MinValue) || (this._stockShipArrivalListCndtn.Ed_AddUpYearMonth != DateTime.MinValue) )
            {
                // �J�n
                if (this._stockShipArrivalListCndtn.St_AddUpYearMonth != DateTime.MinValue)
                {
                    // MOD 2008/10/01 �s��Ή�[6008]�� "yyyy�NMM��"��YYYY_MM_FORMAT
                    st_ShipArrivalDate = this._stockShipArrivalListCndtn.St_AddUpYearMonth.ToString(YYYY_MM_FORMAT);//TDateTime.DateTimeToString(ShipArrivalDateFormat, this._stockShipArrivalListCndtn.St_AddUpYearMonth);
                }
                else
                {
                    st_ShipArrivalDate = ct_Extr_Top;
                }
                // �I��
                // MOD 2008/09/24 �s��Ή�[5614]�� DateTime.MinValue��DateTime.MaxValue
                if (this._stockShipArrivalListCndtn.Ed_AddUpYearMonth != DateTime.MaxValue)
                {
                    // MOD 2008/10/01 �s��Ή�[6008]�� "yyyy�NMM��"��YYYY_MM_FORMAT
                    ed_ShipArrivalDate = this._stockShipArrivalListCndtn.Ed_AddUpYearMonth.ToString(YYYY_MM_FORMAT);//TDateTime.DateTimeToString(ShipArrivalDateFormat, this._stockShipArrivalListCndtn.Ed_AddUpYearMonth);
                }
                else
                {
                    ed_ShipArrivalDate = ct_Extr_End;
                }

                this.EditCondition(
                    ref addConditions,
                    string.Format(
                        "�Ώ۔N��" + ct_RangeConst, // MOD 2008/10/01 �s��Ή�[5683] "������"��"�Ώ۔N����"
                        st_ShipArrivalDate,
                        ed_ShipArrivalDate ) );
            }

            // ADD 2008/09/25 �s��Ή�[5616]---------->>>>>
            // �݌ɓo�^�� ----------------------------------------------------------------------------------------------------
            this.EditCondition(ref addConditions,
                string.Format("�݌ɓo�^���F{0} {1}",
                this._stockShipArrivalListCndtn.StockCreateDate.ToString(DATE_FORMAT + " "),    // MOD 2008/10/01 �s��Ή�[6008]�� "yyyy�NMM��dd�� "��DATE_FORMAT + " "
                this._stockShipArrivalListCndtn.StockCreateDateDivTitle));

            // ���w�� ----------------------------------------------------------------------------------------------------
            string st_ShipArrivalCnt = string.Empty;
            string ed_ShipArrivalCnt = string.Empty;

            st_ShipArrivalCnt = string.Format("{0}�ȏ�", this._stockShipArrivalListCndtn.St_ShipArrivalCnt);
            ed_ShipArrivalCnt = string.Format("{0}�ȉ�", this._stockShipArrivalListCndtn.Ed_ShipArrivalCnt);

            this.EditCondition(ref addConditions, String.Format("���w��F{0}�@{1}{2}",
                                                                    this._stockShipArrivalListCndtn.ShipArrivalCntDivTitle,
                                                                    st_ShipArrivalCnt,
                                                                    ed_ShipArrivalCnt));

            // ����^�C�v --------------------------------------------------------------------------------------------------
            string shipArrivalPrintDivTitleExp = string.Empty;
            if (this._stockShipArrivalListCndtn.ShipArrivalPrintDiv == StockShipArrivalListCndtn.ShipArrivalPrintDivState.ShipArrival)
            {
                shipArrivalPrintDivTitleExp = "��i�F�o�ׁ@���i�F����";
            }
            this.EditCondition(ref addConditions, String.Format("����^�C�v�F{0}�@{1}",
                                                                    this._stockShipArrivalListCndtn.ShipArrivalPrintDivTitle,
                                                                    shipArrivalPrintDivTitleExp));
            // ADD 2008/09/25 �s��Ή�[5616]----------<<<<<



            // �q�� ----------------------------------------------------------------------------------------------------
            // DEL 2008/10/01 �s��Ή�[5683]---------->>>>>
            //this.EditCondition( ref addConditions,
            //    this.GetConditionRange( "�q��", this._stockShipArrivalListCndtn.St_WarehouseCode, this._stockShipArrivalListCndtn.Ed_WarehouseCode )
            //    );
            // DEL 2008/10/01 �s��Ή�[5683]----------<<<<<
            // ADD 2008/10/01 �s��Ή�[5683]---------->>>>>
            if (!RangeUtil.WarehouseCode.IsAllRange(
                this._stockShipArrivalListCndtn.St_WarehouseCode,
                this._stockShipArrivalListCndtn.Ed_WarehouseCode
            ))
            {
                string start= RangeUtil.WarehouseCode.GetStartString(this._stockShipArrivalListCndtn.St_WarehouseCode);
                string end  = RangeUtil.WarehouseCode.GetEndString(this._stockShipArrivalListCndtn.Ed_WarehouseCode);

                EditCondition(
                    ref addConditions,
                    GetConditionRange("�q��", start, end)
                );
            }
            // ADD 2008/10/01 �s��Ή�[5683]----------<<<<<

            // �d���� ----------------------------------------------------------------------------------------------------
            // DEL 2008/10/01 �s��Ή�[5683]---------->>>>>
            //this.EditCondition( ref addConditions,
            //    this.GetConditionRange("�d����", this._stockShipArrivalListCndtn.St_CustomerCode, this._stockShipArrivalListCndtn.Ed_CustomerCode, 999999)  // MOD 2008/09/24 �s��Ή�[5614] 999999999��999999   
            //    );
            // DEL 2008/10/01 �s��Ή�[5683]----------<<<<<
            // ADD 2008/10/01 �s��Ή�[5683]---------->>>>>
            if (!RangeUtil.SupplierCode.IsAllRange(
                this._stockShipArrivalListCndtn.St_CustomerCode,
                this._stockShipArrivalListCndtn.Ed_CustomerCode
            ))
            {
                string start= RangeUtil.SupplierCode.GetStartString(this._stockShipArrivalListCndtn.St_CustomerCode);
                string end  = RangeUtil.SupplierCode.GetEndString(this._stockShipArrivalListCndtn.Ed_CustomerCode);

                EditCondition(
                    ref addConditions,
                    GetConditionRange("�d����", start, end)   
                );
            }
            // ADD 2008/10/01 �s��Ή�[5683]----------<<<<<

            // ���[�J�[ ----------------------------------------------------------------------------------------------------
            // DEL 2008/10/01 �s��Ή�[5683]---------->>>>>
            //this.EditCondition( ref addConditions,
            //    this.GetConditionRange("���[�J�[", this._stockShipArrivalListCndtn.St_GoodsMakerCd, this._stockShipArrivalListCndtn.Ed_GoodsMakerCd, 9999)  // MOD 2008/09/24 �s��Ή�[5614] 999999��9999
            //    );
            // DEL 2008/10/01 �s��Ή�[5683]----------<<<<<
            // ADD 2008/10/01 �s��Ή�[5683]---------->>>>>
            if (!RangeUtil.GoodsMakerCode.IsAllRange(
                this._stockShipArrivalListCndtn.St_GoodsMakerCd,
                this._stockShipArrivalListCndtn.Ed_GoodsMakerCd
            ))
            {
                string start= RangeUtil.GoodsMakerCode.GetStartString(this._stockShipArrivalListCndtn.St_GoodsMakerCd);
                string end  = RangeUtil.GoodsMakerCode.GetEndString(this._stockShipArrivalListCndtn.Ed_GoodsMakerCd);

                EditCondition(
                    ref addConditions,
                    GetConditionRange("���[�J�[", start, end)
                );
            }
            // ADD 2008/10/01 �s��Ή�[5683]----------<<<<<

            // ���i�敪�O���[�v ----------------------------------------------------------------------------------------------------
            // DEL 2008/10/01 �s��Ή�[5683]---------->>>>>
            //this.EditCondition( ref addConditions,
            //    //this.GetConditionRange("���i�敪�O���[�v", this._stockShipArrivalListCndtn.St_LargeGoodsGanreCode, this._stockShipArrivalListCndtn.Ed_LargeGoodsGanreCode)    // DEL 2008.07.16
            //    this.GetConditionRange( "���i�啪��", this._stockShipArrivalListCndtn.St_LargeGoodsGanreCode, this._stockShipArrivalListCndtn.Ed_LargeGoodsGanreCode )          // ADD 2008.07.16
            //    );
            // DEL 2008/10/01 �s��Ή�[5683]----------<<<<<
            // ADD 2008/10/01 �s��Ή�[5683]---------->>>>>
            if (!RangeUtil.GoodsLGroupCode.IsAllRange(
                this._stockShipArrivalListCndtn.St_LargeGoodsGanreCode,
                this._stockShipArrivalListCndtn.Ed_LargeGoodsGanreCode
            ))
            {
                string start= RangeUtil.GoodsLGroupCode.GetStartString(this._stockShipArrivalListCndtn.St_LargeGoodsGanreCode);
                string end  = RangeUtil.GoodsLGroupCode.GetEndString(this._stockShipArrivalListCndtn.Ed_LargeGoodsGanreCode);

                EditCondition(
                    ref addConditions,
                    GetConditionRange("���i�啪��", start, end)
                );
            }
            // ADD 2008/10/01 �s��Ή�[5683]----------<<<<<

            // ���i�敪 ----------------------------------------------------------------------------------------------------
            // DEL 2008/10/01 �s��Ή�[5683]---------->>>>>
            //this.EditCondition( ref addConditions,
            //    //this.GetConditionRange("���i�敪", this._stockShipArrivalListCndtn.St_MediumGoodsGanreCode, this._stockShipArrivalListCndtn.Ed_MediumGoodsGanreCode)          // DEL 2008.07.16
            //    this.GetConditionRange( "���i������", this._stockShipArrivalListCndtn.St_MediumGoodsGanreCode, this._stockShipArrivalListCndtn.Ed_MediumGoodsGanreCode )        // ADD 2008.07.16
            //    );
            // DEL 2008/10/01 �s��Ή�[5683]----------<<<<<
            // ADD 2008/10/01 �s��Ή�[5683]---------->>>>>
            if (!RangeUtil.GoodsMGroupCode.IsAllRange(
                this._stockShipArrivalListCndtn.St_MediumGoodsGanreCode,
                this._stockShipArrivalListCndtn.Ed_MediumGoodsGanreCode
            ))
            {
                string start= RangeUtil.GoodsMGroupCode.GetStartString(this._stockShipArrivalListCndtn.St_MediumGoodsGanreCode);
                string end  = RangeUtil.GoodsMGroupCode.GetEndString(this._stockShipArrivalListCndtn.Ed_MediumGoodsGanreCode);

                EditCondition(
                    ref addConditions,
                    GetConditionRange("���i������", start, end)
                );
            }
            // ADD 2008/10/01 �s��Ή�[5683]----------<<<<<

            // ���i�ڍ� ----------------------------------------------------------------------------------------------------
            // DEL 2008/10/01 �s��Ή�[5683]---------->>>>>
            //this.EditCondition( ref addConditions,
            //    //this.GetConditionRange( "���i�敪�ڍ�", this._stockShipArrivalListCndtn.St_DetailGoodsGanreCode, this._stockShipArrivalListCndtn.Ed_DetailGoodsGanreCode )    // DEL 2008.07.16
            //    this.GetConditionRange( "�O���[�v�R�[�h", this._stockShipArrivalListCndtn.St_DetailGoodsGanreCode, this._stockShipArrivalListCndtn.Ed_DetailGoodsGanreCode )    // ADD 2008.07.16
            //    );
            // DEL 2008/10/01 �s��Ή�[5683]----------<<<<<
            // ADD 2008/10/01 �s��Ή�[5683]---------->>>>>
            if (!RangeUtil.BLGroupCode.IsAllRange(
                this._stockShipArrivalListCndtn.St_DetailGoodsGanreCode,
                this._stockShipArrivalListCndtn.Ed_DetailGoodsGanreCode
            ))
            {
                string start= RangeUtil.BLGroupCode.GetStartString(this._stockShipArrivalListCndtn.St_DetailGoodsGanreCode);
                string end  = RangeUtil.BLGroupCode.GetEndString(this._stockShipArrivalListCndtn.Ed_DetailGoodsGanreCode);

                EditCondition(
                    ref addConditions,
                    GetConditionRange("�O���[�v�R�[�h", start, end)
                );
            }
            // ADD 2008/10/01 �s��Ή�[5683]----------<<<<<

            // ���Е��� ----------------------------------------------------------------------------------------------------
            // DEL 2008/10/01 �s��Ή�[5683]---------->>>>>
            //this.EditCondition( ref addConditions,
            //    //this.GetConditionRange("���Е���", this._stockShipArrivalListCndtn.St_EnterpriseGanreCode, this._stockShipArrivalListCndtn.Ed_EnterpriseGanreCode, 9999)      // DEL 2008.07.16
            //    this.GetConditionRange( "���i�敪", this._stockShipArrivalListCndtn.St_EnterpriseGanreCode, this._stockShipArrivalListCndtn.Ed_EnterpriseGanreCode, 9999 )      // ADD 2008.07.16
            //    );
            // DEL 2008/10/01 �s��Ή�[5683]----------<<<<<
            // ADD 2008/10/01 �s��Ή�[5683]---------->>>>>
            if (!RangeUtil.EnterpriseGanreCode.IsAllRange(
                this._stockShipArrivalListCndtn.St_EnterpriseGanreCode,
                this._stockShipArrivalListCndtn.Ed_EnterpriseGanreCode
            ))
            {
                string start= RangeUtil.EnterpriseGanreCode.GetStartString(this._stockShipArrivalListCndtn.St_EnterpriseGanreCode);
                string end  = RangeUtil.EnterpriseGanreCode.GetEndString(this._stockShipArrivalListCndtn.Ed_EnterpriseGanreCode);

                EditCondition(
                    ref addConditions,
                    GetConditionRange("���i�敪", start, end)
                );
            }
            // ADD 2008/10/01 �s��Ή�[5683]----------<<<<<

            // �a�k���i�R�[�h ----------------------------------------------------------------------------------------------------
            // DEL 2008/10/01 �s��Ή�[5683]---------->>>>>
            //this.EditCondition( ref addConditions,
            //    //this.GetConditionRange("�a�k���i�R�[�h", this._stockShipArrivalListCndtn.St_BLGoodsCode, this._stockShipArrivalListCndtn.Ed_BLGoodsCode, 99999999)// DEL 2008.07.16
            //    this.GetConditionRange( "�a�k�R�[�h", this._stockShipArrivalListCndtn.St_BLGoodsCode, this._stockShipArrivalListCndtn.Ed_BLGoodsCode, 99999 )       // ADD 2008.07.16
            //                                                                                                                                                        // MOD 2008/09/24 �s��Ή�[5614] 99999999��99999
            //    );
            // DEL 2008/10/01 �s��Ή�[5683]----------<<<<<
            // ADD 2008/10/01 �s��Ή�[5683]---------->>>>>
            if (!RangeUtil.BLGoodsCode.IsAllRange(
                this._stockShipArrivalListCndtn.St_BLGoodsCode,
                this._stockShipArrivalListCndtn.Ed_BLGoodsCode
            ))
            {
                string start= RangeUtil.BLGoodsCode.GetStartString(this._stockShipArrivalListCndtn.St_BLGoodsCode);
                string end  = RangeUtil.BLGoodsCode.GetEndString(this._stockShipArrivalListCndtn.Ed_BLGoodsCode);

                EditCondition(
                    ref addConditions,
                    GetConditionRange("�a�k�R�[�h", start, end)
                );
            }
            // ADD 2008/10/01 �s��Ή�[5683]----------<<<<<

            // ���i�ԍ� ----------------------------------------------------------------------------------------------------
            this.EditCondition( ref addConditions,
                //this.GetConditionRange( "���i�ԍ�", this._stockShipArrivalListCndtn.St_GoodsNo, this._stockShipArrivalListCndtn.Ed_GoodsNo )                                  // DEL 2008.07.16
                this.GetConditionRange( "�i��", this._stockShipArrivalListCndtn.St_GoodsNo, this._stockShipArrivalListCndtn.Ed_GoodsNo )                                        // ADD 2008.07.16
                );

            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

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
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
        /// <summary>
        /// ���o�͈͕�����쐬�i���l�p�j
        /// </summary>
        /// <param name="title"></param>
        /// <param name="startCode"></param>
        /// <param name="endCode"></param>
        /// <param name="endMax"></param>
        /// <returns>�쐬������</returns>
        private string GetConditionRange( string title, int startCode, int endCode, int endMax )
        {
            string result = "";
            if ((startCode >= 0) || (endCode != endMax)) // MOD 2008/09/24 �s��Ή�[5614] != 0 �� >= 0
            {
                string start = ct_Extr_Top;
                string end = ct_Extr_End;
                if ( startCode != 0 )
                    start = startCode.ToString().TrimEnd();
                if ( endCode != endMax )
                    end = endCode.ToString().TrimEnd();
                result = String.Format( title + ct_RangeConst, start, end );

                if (start.Equals(ct_Extr_Top) && end.Equals(ct_Extr_End)) result = string.Empty;    // ADD 2008/09/24 �s��Ή�[5614]
            }
            return result;
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
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
			return TMsgDisp.Show(iLevel, "DCZAI02123P", iMsg, iSt, iButton, iDefButton);
		}

		#endregion
		#endregion
    }
}
