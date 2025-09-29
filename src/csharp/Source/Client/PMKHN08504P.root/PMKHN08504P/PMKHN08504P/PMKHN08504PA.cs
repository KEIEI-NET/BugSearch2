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
	/// �}�X�^�G�N�X�|�[�g�C���|�[�g�i��{�p�j�N���X
	/// </summary>
	/// <remarks>
    /// <br>Note       : �}�X�^�G�N�X�|�[�g�C���|�[�g�i��{�p�j�̈�����s���B</br>
	/// <br>Programmer : 30462 �s�V �m��</br>
	/// <br>Date       : 2008.10.30</br>
    /// </remarks>
	class PMKHN08504PA: IPrintProc
	{

		#region �� Constructor
		/// <summary>
        /// �}�X�^�G�N�X�|�[�g�C���|�[�g�i��{�p�j�N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
        /// <br>Note       : �}�X�^�G�N�X�|�[�g�C���|�[�g�i��{�p�j�N���X�̃C���X�^���X�̍쐬���s���B</br>
		/// <br>Programmer : 30462 �s�V �m��</br>
		/// <br>Date       : 2008.10.30</br>
		/// </remarks>
		public PMKHN08504PA()
		{
		}

		/// <summary>
        /// �}�X�^�G�N�X�|�[�g�C���|�[�g�i��{�p�j�N���X�R���X�g���N�^
		/// </summary>
		/// <param name="printInfo">������I�u�W�F�N�g</param>
		/// <remarks>
        /// <br>Note       : �}�X�^�G�N�X�|�[�g�C���|�[�g�i��{�p�j�N���X�̃C���X�^���X�̍쐬���s���B</br>
		/// <br>Programmer : 30462 �s�V �m��</br>
		/// <br>Date       : 2008.10.30</br>
		/// </remarks>
        public PMKHN08504PA(object printInfo)
		{
			this._printInfo = printInfo as SFCMN06002C;
            switch (this._printInfo.kidopgid)
            {
                case WAREHOUSE_PGID:
                    this._warehousePrintWork = (WarehousePrintWork)this._printInfo.jyoken;
                    break;
                case USERGD_PGID:
                    this._userGdPrintWork = (UserGdPrintWork)this._printInfo.jyoken;
                    break;
                case NOTEGUID_PGID:
                    this._noteGuidPrintWork = (NoteGuidPrintWork)this._printInfo.jyoken;
                    break;
                case BLGOODSCD_PGID:
                    this._bLGoodsCdPrintWork = (BLGoodsCdPrintWork)this._printInfo.jyoken;
                    break;
                case MAKER_PGID:
                    this._makerPrintWork = (MakerPrintWork)this._printInfo.jyoken;
                    break;
                case GOODSGROUP_PGID:
                    this._goodsGroupPrintWork = (GoodsGroupPrintWork)this._printInfo.jyoken;
                    break;
                case BLGROUP_PGID:
                    this._bLGroupPrintWork = (BLGroupPrintWork)this._printInfo.jyoken;
                    break;
                case ISOLISLANDPRC_PGID:
                    this._isolIslandPrcPrintWork = (IsolIslandPrcPrintWork)this._printInfo.jyoken;
                    break;
                case JOINPARTS_PGID:
                    this._joinPartsPrintWork = (JoinPartsPrintWork)this._printInfo.jyoken;
                    break;
                case PARTSSUBST_PGID:
                    this._partsSubstPrintWork = (PartsSubstPrintWork)this._printInfo.jyoken;
                    break;
                case GOODSSET_PGID:
                    this._goodsSetPrintWork = (GoodsSetPrintWork)this._printInfo.jyoken;
                    break;
                case MODELNAME_PGID:
                    this._modelNamePrintWork = (ModelNamePrintWork)this._printInfo.jyoken;
                    break;
                case PARTSPOSCODE_PGID:
                    this._partsPosCodePrintWork = (PartsPosCodePrintWork)this._printInfo.jyoken;
                    break;
            }

		}
		#endregion �� Constructor

		#region �� Pricate Const
		private const string ct_ReportForm_NameSpace = "Broadleaf.Drawing.Printing";
		private const string ct_Space			= "�@";
        private const string ct_Extr_Top = "�ŏ�����";
        private const string ct_Extr_End = "�Ō�܂�";
        private const string ct_RangeConst = "�F{0} �` {1}";

        private const string WAREHOUSE_PGID = "PMKHN08510U";            // �q�Ƀ}�X�^
        private const string USERGD_PGID = "PMKHN08530U";               // ���[�U�K�C�h
        private const string NOTEGUID_PGID = "PMKHN08540U";             // ���l�K�C�h
        private const string BLGOODSCD_PGID = "PMKHN08570U";            // �a�k�R�[�h
        private const string MAKER_PGID = "PMKHN08580U";                // ���[�J�[
        private const string GOODSGROUP_PGID = "PMKHN08590U";           // ���i������
        private const string BLGROUP_PGID = "PMKHN08600U";              // ��ٰ�ߺ���
        private const string ISOLISLANDPRC_PGID = "PMKHN08620U";        // �������i
        private const string JOINPARTS_PGID = "PMKHN08640U";            // ����
        private const string PARTSSUBST_PGID = "PMKHN08650U";           // ���
        private const string GOODSSET_PGID = "PMKHN08660U";             // �Z�b�g
        private const string MODELNAME_PGID = "PMKHN08670U";            // �Ԏ�
        private const string PARTSPOSCODE_PGID = "PMKHN08680U";         // ����
		#endregion �� Pricate Const

		#region �� Private Member
		private SFCMN06002C _printInfo;					                // ������N���X

        #region ���o�����N���X�̒�`
        private WarehousePrintWork _warehousePrintWork;                 // �q�Ƀ}�X�^
        private UserGdPrintWork _userGdPrintWork;                       // ���[�U�K�C�h
        private NoteGuidPrintWork _noteGuidPrintWork;                   // ���l�K�C�h
        private BLGoodsCdPrintWork _bLGoodsCdPrintWork;                 // �a�k�R�[�h
        private MakerPrintWork _makerPrintWork;                         // ���[�J�[
        private GoodsGroupPrintWork _goodsGroupPrintWork;               // ���i������
        private BLGroupPrintWork _bLGroupPrintWork;                     // ��ٰ�ߺ���
        private IsolIslandPrcPrintWork _isolIslandPrcPrintWork;         // �������i
        private JoinPartsPrintWork _joinPartsPrintWork;                 // ����
        private PartsSubstPrintWork _partsSubstPrintWork;               // ���
        private GoodsSetPrintWork _goodsSetPrintWork;                   // �Z�b�g
        private ModelNamePrintWork _modelNamePrintWork;                 // �Ԏ�
        private PartsPosCodePrintWork _partsPosCodePrintWork;           // ����        
        #endregion

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
		/// <br>Date       : 2008.10.30</br>
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
		/// <br>Date       : 2008.10.30</br>
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
                //prtRpt.DataMember = PMKHN02019EA.ct_Tbl_Rate;
				
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
		/// <br>Date       : 2008.10.30</br>
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
		/// <br>Date       : 2008.10.30</br>
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
		/// <br>Date       : 2008.10.30</br>
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
		/// <br>Date       : 2008.10.30</br>
		/// </remarks>
		private int SettingProperty(ref DataDynamics.ActiveReports.ActiveReport3 rpt)
		{
			int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;

			// ActiveReport�C���^�[�t�F�[�X�ɃL���X�g
			IPrintActiveReportTypeList instance = rpt as IPrintActiveReportTypeList;
			
			// ���[�o�͐ݒ���擾 
			PrtOutSet prtOutSet = null;
            string message = "";
            int st = 0;
            switch (this._printInfo.kidopgid)
            {
                case WAREHOUSE_PGID:
                    st = WarehousePrintReportAcs.ReadPrtOutSet(out prtOutSet, out message);
                    break;
                case USERGD_PGID:
                    st = UserGdPrintReportAcs.ReadPrtOutSet(out prtOutSet, out message);
                    break;
                case NOTEGUID_PGID:
                    st = NoteGuidPrintReportAcs.ReadPrtOutSet(out prtOutSet, out message);
                    break;
                case BLGOODSCD_PGID:
                    st = BLGoodsCdPrintReportAcs.ReadPrtOutSet(out prtOutSet, out message);
                    break;
                case MAKER_PGID:
                    st = MakerPrintReportAcs.ReadPrtOutSet(out prtOutSet, out message);
                    break;
                case GOODSGROUP_PGID:
                    st = GoodsGroupPrintReportAcs.ReadPrtOutSet(out prtOutSet, out message);
                    break;
                case BLGROUP_PGID:
                    st = BLGroupPrintReportAcs.ReadPrtOutSet(out prtOutSet, out message);
                    break;
                case ISOLISLANDPRC_PGID:
                    st = IsolIslandPrcPrintReportAcs.ReadPrtOutSet(out prtOutSet, out message);
                    break;
                case JOINPARTS_PGID:
                    st = JoinPartsPrintReportAcs.ReadPrtOutSet(out prtOutSet, out message);
                    break;
                case PARTSSUBST_PGID:
                    st = PartsSubstPrintReportAcs.ReadPrtOutSet(out prtOutSet, out message);
                    break;
                case GOODSSET_PGID:
                    st = GoodsSetPrintReportAcs.ReadPrtOutSet(out prtOutSet, out message);
                    break;
                case MODELNAME_PGID:
                    st = ModelNamePrintReportAcs.ReadPrtOutSet(out prtOutSet, out message);
                    break;
                case PARTSPOSCODE_PGID:
                    st = PartsPosCodePrintReportAcs.ReadPrtOutSet(out prtOutSet, out message);
                    break;
            }
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
            if (this._printInfo.kidopgid.Equals(USERGD_PGID))
            {
                instance.PageHeaderSubtitle = this._printInfo.prpnm+"(" + this._userGdPrintWork.UserGuideDivName +")";
            }
            else
            {
                instance.PageHeaderSubtitle = this._printInfo.prpnm;
            }

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
        /// <br>Date       : 2008.10.30</br>
        /// </remarks>
		private void MakeExtarCondition( out StringCollection extraConditions )
		{
            extraConditions = new StringCollection();
            StringCollection addConditions = new StringCollection();

            const string dateFormat = "YYYY/MM/DD";
            string stTarget = "";
            string edTarget = "";

            switch (this._printInfo.kidopgid)
            {
                case WAREHOUSE_PGID:
                    // �폜���
                    if (this._warehousePrintWork.LogicalDeleteCode == 1)
                    {
                        if ((this._warehousePrintWork.DeleteDateTimeSt != 0) || (this._warehousePrintWork.DeleteDateTimeEd != 0))
                        {
                            // �J�n
                            if (this._warehousePrintWork.DeleteDateTimeSt != 0)
                            {
                                stTarget = TDateTime.LongDateToString(dateFormat, this._warehousePrintWork.DeleteDateTimeSt);
                            }
                            else
                            {
                                stTarget = ct_Extr_Top;
                            }
                            // �I��
                            if (this._warehousePrintWork.DeleteDateTimeEd != 0)
                            {
                                edTarget = TDateTime.LongDateToString(dateFormat, this._warehousePrintWork.DeleteDateTimeEd);
                            }
                            else
                            {
                                edTarget = ct_Extr_End;
                            }
                            this.EditCondition(ref extraConditions, string.Format("�폜���t" + ct_RangeConst, stTarget, edTarget));
                        }
                    }

                    // �q�ɃR�[�h
                    if (this._warehousePrintWork.WarehouseCodeSt != string.Empty || this._warehousePrintWork.WarehouseCodeEd != string.Empty)
                    {
                        stTarget = this._warehousePrintWork.WarehouseCodeSt;
                        edTarget = this._warehousePrintWork.WarehouseCodeEd;
                        if (stTarget == string.Empty) stTarget = ct_Extr_Top;
                        if (edTarget == string.Empty) edTarget = ct_Extr_End;

                        this.EditCondition(ref extraConditions, string.Format("�q��" + ct_RangeConst, stTarget, edTarget));

                    }
                    break;
                case USERGD_PGID:
                    // �폜���
                    if (this._userGdPrintWork.LogicalDeleteCode == 1)
                    {
                        if ((this._userGdPrintWork.DeleteDateTimeSt != 0) || (this._userGdPrintWork.DeleteDateTimeEd != 0))
                        {
                            // �J�n
                            if (this._userGdPrintWork.DeleteDateTimeSt != 0)
                            {
                                stTarget = TDateTime.LongDateToString(dateFormat, this._userGdPrintWork.DeleteDateTimeSt);
                            }
                            else
                            {
                                stTarget = ct_Extr_Top;
                            }
                            // �I��
                            if (this._userGdPrintWork.DeleteDateTimeEd != 0)
                            {
                                edTarget = TDateTime.LongDateToString(dateFormat, this._userGdPrintWork.DeleteDateTimeEd);
                            }
                            else
                            {
                                edTarget = ct_Extr_End;
                            }
                            this.EditCondition(ref extraConditions, string.Format("�폜���t" + ct_RangeConst, stTarget, edTarget));
                        }
                    }
                    // ���[�U�R�[�h
                    if (this._userGdPrintWork.GuideCodeSt != 0 || this._userGdPrintWork.GuideCodeEd != 0)
                    {
                        if (this._userGdPrintWork.UserGuideDivCd == 72 ||
                            this._userGdPrintWork.UserGuideDivCd == 73)
                        {
                            stTarget = this._userGdPrintWork.GuideCodeSt.ToString();
                            edTarget = this._userGdPrintWork.GuideCodeEd.ToString();
                        }
                        else
                        {
                            stTarget = this._userGdPrintWork.GuideCodeSt.ToString("0000");
                            edTarget = this._userGdPrintWork.GuideCodeEd.ToString("0000");
                        }
                        if (this._userGdPrintWork.GuideCodeSt == 0) stTarget = ct_Extr_Top;
                        if (this._userGdPrintWork.GuideCodeEd == 0) edTarget = ct_Extr_End;

                        this.EditCondition(ref extraConditions, string.Format(this._userGdPrintWork.UserGuideDivName + ct_RangeConst, stTarget, edTarget));

                    }
                    break;
                case NOTEGUID_PGID:
                    // �폜���
                    if (this._noteGuidPrintWork.LogicalDeleteCode == 1)
                    {
                        if ((this._noteGuidPrintWork.DeleteDateTimeSt != 0) || (this._noteGuidPrintWork.DeleteDateTimeEd != 0))
                        {
                            // �J�n
                            if (this._noteGuidPrintWork.DeleteDateTimeSt != 0)
                            {
                                stTarget = TDateTime.LongDateToString(dateFormat, this._noteGuidPrintWork.DeleteDateTimeSt);
                            }
                            else
                            {
                                stTarget = ct_Extr_Top;
                            }
                            // �I��
                            if (this._noteGuidPrintWork.DeleteDateTimeEd != 0)
                            {
                                edTarget = TDateTime.LongDateToString(dateFormat, this._noteGuidPrintWork.DeleteDateTimeEd);
                            }
                            else
                            {
                                edTarget = ct_Extr_End;
                            }
                            this.EditCondition(ref extraConditions, string.Format("�폜���t" + ct_RangeConst, stTarget, edTarget));
                        }
                    }
                    // ���l�K�C�h�敪
                    if (this._noteGuidPrintWork.NoteGuideDivCodeSt != 0 || this._noteGuidPrintWork.NoteGuideDivCodeEd != 0)
                    {

                        stTarget = this._noteGuidPrintWork.NoteGuideDivCodeSt.ToString("0000");
                        edTarget = this._noteGuidPrintWork.NoteGuideDivCodeEd.ToString("0000");
                        if (this._noteGuidPrintWork.NoteGuideDivCodeSt == 0) stTarget = ct_Extr_Top;
                        if (this._noteGuidPrintWork.NoteGuideDivCodeEd == 0) edTarget = ct_Extr_End;

                        this.EditCondition(ref extraConditions, string.Format("���l�K�C�h�敪" + ct_RangeConst, stTarget, edTarget));
                    }
                    break;
                case BLGOODSCD_PGID:
                    // �폜���
                    if (this._bLGoodsCdPrintWork.LogicalDeleteCode == 1)
                    {
                        if ((this._bLGoodsCdPrintWork.DeleteDateTimeSt != 0) || (this._bLGoodsCdPrintWork.DeleteDateTimeEd != 0))
                        {
                            // �J�n
                            if (this._bLGoodsCdPrintWork.DeleteDateTimeSt != 0)
                            {
                                stTarget = TDateTime.LongDateToString(dateFormat, this._bLGoodsCdPrintWork.DeleteDateTimeSt);
                            }
                            else
                            {
                                stTarget = ct_Extr_Top;
                            }
                            // �I��
                            if (this._bLGoodsCdPrintWork.DeleteDateTimeEd != 0)
                            {
                                edTarget = TDateTime.LongDateToString(dateFormat, this._bLGoodsCdPrintWork.DeleteDateTimeEd);
                            }
                            else
                            {
                                edTarget = ct_Extr_End;
                            }
                            this.EditCondition(ref extraConditions, string.Format("�폜���t" + ct_RangeConst, stTarget, edTarget));
                        }
                    }
                    // BL����
                    if (this._bLGoodsCdPrintWork.BLGoodsCodeSt != 0 || this._bLGoodsCdPrintWork.BLGoodsCodeEd != 0)
                    {

                        stTarget = this._bLGoodsCdPrintWork.BLGoodsCodeSt.ToString("00000");
                        edTarget = this._bLGoodsCdPrintWork.BLGoodsCodeEd.ToString("00000");
                        if (this._bLGoodsCdPrintWork.BLGoodsCodeSt == 0) stTarget = ct_Extr_Top;
                        if (this._bLGoodsCdPrintWork.BLGoodsCodeEd == 0) edTarget = ct_Extr_End;

                        this.EditCondition(ref extraConditions, string.Format("�a�k�R�[�h" + ct_RangeConst, stTarget, edTarget));
                    }
                    break;
                case MAKER_PGID:
                    // �폜���
                    if (this._makerPrintWork.LogicalDeleteCode == 1)
                    {
                        if ((this._makerPrintWork.DeleteDateTimeSt != 0) || (this._makerPrintWork.DeleteDateTimeEd != 0))
                        {
                            // �J�n
                            if (this._makerPrintWork.DeleteDateTimeSt != 0)
                            {
                                stTarget = TDateTime.LongDateToString(dateFormat, this._makerPrintWork.DeleteDateTimeSt);
                            }
                            else
                            {
                                stTarget = ct_Extr_Top;
                            }
                            // �I��
                            if (this._makerPrintWork.DeleteDateTimeEd != 0)
                            {
                                edTarget = TDateTime.LongDateToString(dateFormat, this._makerPrintWork.DeleteDateTimeEd);
                            }
                            else
                            {
                                edTarget = ct_Extr_End;
                            }
                            this.EditCondition(ref extraConditions, string.Format("�폜���t" + ct_RangeConst, stTarget, edTarget));
                        }
                    }
                    // ���[�J�[�R�[�h
                    if (this._makerPrintWork.GoodsMakerCdSt != 0 || this._makerPrintWork.GoodsMakerCdEd != 0)
                    {

                        stTarget = this._makerPrintWork.GoodsMakerCdSt.ToString("0000");
                        edTarget = this._makerPrintWork.GoodsMakerCdEd.ToString("0000");
                        if (this._makerPrintWork.GoodsMakerCdSt == 0) stTarget = ct_Extr_Top;
                        if (this._makerPrintWork.GoodsMakerCdEd == 0) edTarget = ct_Extr_End;

                        this.EditCondition(ref extraConditions, string.Format("���[�J�[" + ct_RangeConst, stTarget, edTarget));
                    }
                    break;
                case GOODSGROUP_PGID:
                    // �폜���
                    if (this._goodsGroupPrintWork.LogicalDeleteCode == 1)
                    {
                        if ((this._goodsGroupPrintWork.DeleteDateTimeSt != 0) || (this._goodsGroupPrintWork.DeleteDateTimeEd != 0))
                        {
                            // �J�n
                            if (this._goodsGroupPrintWork.DeleteDateTimeSt != 0)
                            {
                                stTarget = TDateTime.LongDateToString(dateFormat, this._goodsGroupPrintWork.DeleteDateTimeSt);
                            }
                            else
                            {
                                stTarget = ct_Extr_Top;
                            }
                            // �I��
                            if (this._goodsGroupPrintWork.DeleteDateTimeEd != 0)
                            {
                                edTarget = TDateTime.LongDateToString(dateFormat, this._goodsGroupPrintWork.DeleteDateTimeEd);
                            }
                            else
                            {
                                edTarget = ct_Extr_End;
                            }
                            this.EditCondition(ref extraConditions, string.Format("�폜���t" + ct_RangeConst, stTarget, edTarget));
                        }
                    }

                    // ���i������
                    if (this._goodsGroupPrintWork.GoodsMGroupSt != 0 || this._goodsGroupPrintWork.GoodsMGroupEd != 0)
                    {

                        stTarget = this._goodsGroupPrintWork.GoodsMGroupSt.ToString("0000");
                        edTarget = this._goodsGroupPrintWork.GoodsMGroupEd.ToString("0000");
                        if (this._goodsGroupPrintWork.GoodsMGroupSt == 0) stTarget = ct_Extr_Top;
                        if (this._goodsGroupPrintWork.GoodsMGroupEd == 0) edTarget = ct_Extr_End;

                        this.EditCondition(ref extraConditions, string.Format("���i������" + ct_RangeConst, stTarget, edTarget));
                    }
                    break;
                case BLGROUP_PGID:
                    // �폜���
                    if (this._bLGroupPrintWork.LogicalDeleteCode == 1)
                    {
                        if ((this._bLGroupPrintWork.DeleteDateTimeSt != 0) || (this._bLGroupPrintWork.DeleteDateTimeEd != 0))
                        {
                            // �J�n
                            if (this._bLGroupPrintWork.DeleteDateTimeSt != 0)
                            {
                                stTarget = TDateTime.LongDateToString(dateFormat, this._bLGroupPrintWork.DeleteDateTimeSt);
                            }
                            else
                            {
                                stTarget = ct_Extr_Top;
                            }
                            // �I��
                            if (this._bLGroupPrintWork.DeleteDateTimeEd != 0)
                            {
                                edTarget = TDateTime.LongDateToString(dateFormat, this._bLGroupPrintWork.DeleteDateTimeEd);
                            }
                            else
                            {
                                edTarget = ct_Extr_End;
                            }
                            this.EditCondition(ref extraConditions, string.Format("�폜���t" + ct_RangeConst, stTarget, edTarget));
                        }
                    }
                    // ��ٰ�߃R�[�h
                    if (this._bLGroupPrintWork.BLGroupCodeSt != 0 || this._bLGroupPrintWork.BLGroupCodeEd != 0)
                    {

                        stTarget = this._bLGroupPrintWork.BLGroupCodeSt.ToString("00000");
                        edTarget = this._bLGroupPrintWork.BLGroupCodeEd.ToString("00000");
                        if (this._bLGroupPrintWork.BLGroupCodeSt == 0) stTarget = ct_Extr_Top;
                        if (this._bLGroupPrintWork.BLGroupCodeEd == 0) edTarget = ct_Extr_End;

                        this.EditCondition(ref extraConditions, string.Format("�O���[�v�R�[�h" + ct_RangeConst, stTarget, edTarget));
                    }
                    break;
                case ISOLISLANDPRC_PGID:
                    // �폜���
                    if (this._isolIslandPrcPrintWork.LogicalDeleteCode == 1)
                    {
                        if ((this._isolIslandPrcPrintWork.DeleteDateTimeSt != 0) || (this._isolIslandPrcPrintWork.DeleteDateTimeEd != 0))
                        {
                            // �J�n
                            if (this._isolIslandPrcPrintWork.DeleteDateTimeSt != 0)
                            {
                                stTarget = TDateTime.LongDateToString(dateFormat, this._isolIslandPrcPrintWork.DeleteDateTimeSt);
                            }
                            else
                            {
                                stTarget = ct_Extr_Top;
                            }
                            // �I��
                            if (this._isolIslandPrcPrintWork.DeleteDateTimeEd != 0)
                            {
                                edTarget = TDateTime.LongDateToString(dateFormat, this._isolIslandPrcPrintWork.DeleteDateTimeEd);
                            }
                            else
                            {
                                edTarget = ct_Extr_End;
                            }
                            this.EditCondition(ref extraConditions, string.Format("�폜���t" + ct_RangeConst, stTarget, edTarget));
                        }
                    }
                    // ���_�R�[�h
                    if (this._isolIslandPrcPrintWork.SectionCodeSt != string.Empty || this._isolIslandPrcPrintWork.SectionCodeEd != string.Empty)
                    {
                        stTarget = this._isolIslandPrcPrintWork.SectionCodeSt;
                        edTarget = this._isolIslandPrcPrintWork.SectionCodeEd;
                        if (stTarget == string.Empty) stTarget = ct_Extr_Top;
                        if (edTarget == string.Empty) edTarget = ct_Extr_End;

                        this.EditCondition(ref extraConditions, string.Format("���_" + ct_RangeConst, stTarget, edTarget));

                    }
                    break;
                case JOINPARTS_PGID:
                    // �폜���
                    if (this._joinPartsPrintWork.LogicalDeleteCode == 1)
                    {
                        if ((this._joinPartsPrintWork.DeleteDateTimeSt != 0) || (this._joinPartsPrintWork.DeleteDateTimeEd != 0))
                        {
                            // �J�n
                            if (this._joinPartsPrintWork.DeleteDateTimeSt != 0)
                            {
                                stTarget = TDateTime.LongDateToString(dateFormat, this._joinPartsPrintWork.DeleteDateTimeSt);
                            }
                            else
                            {
                                stTarget = ct_Extr_Top;
                            }
                            // �I��
                            if (this._joinPartsPrintWork.DeleteDateTimeEd != 0)
                            {
                                edTarget = TDateTime.LongDateToString(dateFormat, this._joinPartsPrintWork.DeleteDateTimeEd);
                            }
                            else
                            {
                                edTarget = ct_Extr_End;
                            }
                            this.EditCondition(ref extraConditions, string.Format("�폜���t" + ct_RangeConst, stTarget, edTarget));
                        }
                    }
                    // ���[�J�[
                    if (this._joinPartsPrintWork.JoinSourceMakerCodeSt != 0 || this._joinPartsPrintWork.JoinSourceMakerCodeEd != 0)
                    {

                        stTarget = this._joinPartsPrintWork.JoinSourceMakerCodeSt.ToString("0000");
                        edTarget = this._joinPartsPrintWork.JoinSourceMakerCodeEd.ToString("0000");
                        if (this._joinPartsPrintWork.JoinSourceMakerCodeSt == 0) stTarget = ct_Extr_Top;
                        if (this._joinPartsPrintWork.JoinSourceMakerCodeEd == 0) edTarget = ct_Extr_End;

                        this.EditCondition(ref extraConditions, string.Format("���[�J�[�R�[�h" + ct_RangeConst, stTarget, edTarget));
                    }
                    // �i��
                    if (this._joinPartsPrintWork.JoinSourPartsNoWithHSt != string.Empty || this._joinPartsPrintWork.JoinSourPartsNoWithHEd != string.Empty)
                    {
                        stTarget = this._joinPartsPrintWork.JoinSourPartsNoWithHSt;
                        edTarget = this._joinPartsPrintWork.JoinSourPartsNoWithHEd;
                        if (stTarget == string.Empty) stTarget = ct_Extr_Top;
                        if (edTarget == string.Empty) edTarget = ct_Extr_End;

                        this.EditCondition(ref extraConditions, string.Format("�i��" + ct_RangeConst, stTarget, edTarget));

                    }
                    // ����
                    if (this._joinPartsPrintWork.JoinDispOrderSt != 0 || this._joinPartsPrintWork.JoinDispOrderEd != 0)
                    {

                        stTarget = this._joinPartsPrintWork.JoinDispOrderSt.ToString();
                        edTarget = this._joinPartsPrintWork.JoinDispOrderEd.ToString();
                        if (this._joinPartsPrintWork.JoinDispOrderSt == 0) stTarget = ct_Extr_Top;
                        if (this._joinPartsPrintWork.JoinDispOrderEd == 0) edTarget = ct_Extr_End;

                        this.EditCondition(ref extraConditions, string.Format("����" + ct_RangeConst, stTarget, edTarget));
                    }
                    break;
                case PARTSSUBST_PGID:
                    // �폜���
                    if (this._partsSubstPrintWork.LogicalDeleteCode == 1)
                    {
                        if ((this._partsSubstPrintWork.DeleteDateTimeSt != 0) || (this._partsSubstPrintWork.DeleteDateTimeEd != 0))
                        {
                            // �J�n
                            if (this._partsSubstPrintWork.DeleteDateTimeSt != 0)
                            {
                                stTarget = TDateTime.LongDateToString(dateFormat, this._partsSubstPrintWork.DeleteDateTimeSt);
                            }
                            else
                            {
                                stTarget = ct_Extr_Top;
                            }
                            // �I��
                            if (this._partsSubstPrintWork.DeleteDateTimeEd != 0)
                            {
                                edTarget = TDateTime.LongDateToString(dateFormat, this._partsSubstPrintWork.DeleteDateTimeEd);
                            }
                            else
                            {
                                edTarget = ct_Extr_End;
                            }
                            this.EditCondition(ref extraConditions, string.Format("�폜���t" + ct_RangeConst, stTarget, edTarget));
                        }
                    }
                    // ���[�J�[
                    if (this._partsSubstPrintWork.ChgSrcMakerCdSt != 0 || this._partsSubstPrintWork.ChgSrcMakerCdEd != 0)
                    {

                        stTarget = this._partsSubstPrintWork.ChgSrcMakerCdSt.ToString("0000");
                        edTarget = this._partsSubstPrintWork.ChgSrcMakerCdEd.ToString("0000");
                        if (this._partsSubstPrintWork.ChgSrcMakerCdSt == 0) stTarget = ct_Extr_Top;
                        if (this._partsSubstPrintWork.ChgSrcMakerCdEd == 0) edTarget = ct_Extr_End;

                        this.EditCondition(ref extraConditions, string.Format("���[�J�[�R�[�h" + ct_RangeConst, stTarget, edTarget));
                    }
                    // �i��
                    if (this._partsSubstPrintWork.ChgSrcGoodsNoSt != string.Empty || this._partsSubstPrintWork.ChgSrcGoodsNoEd != string.Empty)
                    {
                        stTarget = this._partsSubstPrintWork.ChgSrcGoodsNoSt;
                        edTarget = this._partsSubstPrintWork.ChgSrcGoodsNoEd;
                        if (stTarget == string.Empty) stTarget = ct_Extr_Top;
                        if (edTarget == string.Empty) edTarget = ct_Extr_End;

                        this.EditCondition(ref extraConditions, string.Format("�i��" + ct_RangeConst, stTarget, edTarget));

                    }
                    break;
                case GOODSSET_PGID:
                    // �폜���
                    if (this._goodsSetPrintWork.LogicalDeleteCode == 1)
                    {
                        if ((this._goodsSetPrintWork.DeleteDateTimeSt != 0) || (this._goodsSetPrintWork.DeleteDateTimeEd != 0))
                        {
                            // �J�n
                            if (this._goodsSetPrintWork.DeleteDateTimeSt != 0)
                            {
                                stTarget = TDateTime.LongDateToString(dateFormat, this._goodsSetPrintWork.DeleteDateTimeSt);
                            }
                            else
                            {
                                stTarget = ct_Extr_Top;
                            }
                            // �I��
                            if (this._goodsSetPrintWork.DeleteDateTimeEd != 0)
                            {
                                edTarget = TDateTime.LongDateToString(dateFormat, this._goodsSetPrintWork.DeleteDateTimeEd);
                            }
                            else
                            {
                                edTarget = ct_Extr_End;
                            }
                            this.EditCondition(ref extraConditions, string.Format("�폜���t" + ct_RangeConst, stTarget, edTarget));
                        }
                    }
                    // ���[�J�[
                    if (this._goodsSetPrintWork.ParentGoodsMakerCdSt != 0 || this._goodsSetPrintWork.ParentGoodsMakerCdEd != 0)
                    {

                        stTarget = this._goodsSetPrintWork.ParentGoodsMakerCdSt.ToString("0000");
                        edTarget = this._goodsSetPrintWork.ParentGoodsMakerCdEd.ToString("0000");
                        if (this._goodsSetPrintWork.ParentGoodsMakerCdSt == 0) stTarget = ct_Extr_Top;
                        if (this._goodsSetPrintWork.ParentGoodsMakerCdEd == 0) edTarget = ct_Extr_End;

                        this.EditCondition(ref extraConditions, string.Format("���[�J�[�R�[�h" + ct_RangeConst, stTarget, edTarget));
                    }
                    // �i��
                    if (this._goodsSetPrintWork.ParentGoodsNoSt != string.Empty || this._goodsSetPrintWork.ParentGoodsNoEd != string.Empty)
                    {
                        stTarget = this._goodsSetPrintWork.ParentGoodsNoSt;
                        edTarget = this._goodsSetPrintWork.ParentGoodsNoEd;
                        if (stTarget == string.Empty) stTarget = ct_Extr_Top;
                        if (edTarget == string.Empty) edTarget = ct_Extr_End;

                        this.EditCondition(ref extraConditions, string.Format("�i��" + ct_RangeConst, stTarget, edTarget));

                    }
                    this._goodsSetPrintWork = (GoodsSetPrintWork)this._printInfo.jyoken;
                    break;
                case MODELNAME_PGID:
                    // �폜���
                    if (this._modelNamePrintWork.LogicalDeleteCode == 1)
                    {
                        if ((this._modelNamePrintWork.DeleteDateTimeSt != 0) || (this._modelNamePrintWork.DeleteDateTimeEd != 0))
                        {
                            // �J�n
                            if (this._modelNamePrintWork.DeleteDateTimeSt != 0)
                            {
                                stTarget = TDateTime.LongDateToString(dateFormat, this._modelNamePrintWork.DeleteDateTimeSt);
                            }
                            else
                            {
                                stTarget = ct_Extr_Top;
                            }
                            // �I��
                            if (this._modelNamePrintWork.DeleteDateTimeEd != 0)
                            {
                                edTarget = TDateTime.LongDateToString(dateFormat, this._modelNamePrintWork.DeleteDateTimeEd);
                            }
                            else
                            {
                                edTarget = ct_Extr_End;
                            }
                            this.EditCondition(ref extraConditions, string.Format("�폜���t" + ct_RangeConst, stTarget, edTarget));
                        }
                    }
                    // ���[�J�[
                    if (this._modelNamePrintWork.MakerCodeSt != 0 || this._modelNamePrintWork.MakerCodeEd != 0)
                    {

                        stTarget = this._modelNamePrintWork.MakerCodeSt.ToString("000") + "-" + this._modelNamePrintWork.ModelCodeSt.ToString("000") + "-" + this._modelNamePrintWork.ModelSubCodeSt.ToString("000");
                        edTarget = this._modelNamePrintWork.MakerCodeEd.ToString("999") + "-" + this._modelNamePrintWork.ModelCodeEd.ToString("999") + "-" + this._modelNamePrintWork.ModelSubCodeEd.ToString("999");
                        if ((this._modelNamePrintWork.MakerCodeSt + this._modelNamePrintWork.ModelCodeSt + this._modelNamePrintWork.ModelSubCodeSt) == 0) stTarget = ct_Extr_Top;
                        if ((this._modelNamePrintWork.MakerCodeEd + this._modelNamePrintWork.ModelCodeEd + this._modelNamePrintWork.ModelSubCodeEd) == 0) edTarget = ct_Extr_End;

                        this.EditCondition(ref extraConditions, string.Format("�Ԏ�" + ct_RangeConst, stTarget, edTarget));
                    }
                    this._modelNamePrintWork = (ModelNamePrintWork)this._printInfo.jyoken;
                    break;
                case PARTSPOSCODE_PGID:
                    // �폜���
                    if (this._partsPosCodePrintWork.LogicalDeleteCode == 1)
                    {
                        if ((this._partsPosCodePrintWork.DeleteDateTimeSt != 0) || (this._partsPosCodePrintWork.DeleteDateTimeEd != 0))
                        {
                            // �J�n
                            if (this._partsPosCodePrintWork.DeleteDateTimeSt != 0)
                            {
                                stTarget = TDateTime.LongDateToString(dateFormat, this._partsPosCodePrintWork.DeleteDateTimeSt);
                            }
                            else
                            {
                                stTarget = ct_Extr_Top;
                            }
                            // �I��
                            if (this._partsPosCodePrintWork.DeleteDateTimeEd != 0)
                            {
                                edTarget = TDateTime.LongDateToString(dateFormat, this._partsPosCodePrintWork.DeleteDateTimeEd);
                            }
                            else
                            {
                                edTarget = ct_Extr_End;
                            }
                            this.EditCondition(ref extraConditions, string.Format("�폜���t" + ct_RangeConst, stTarget, edTarget));
                        }
                    }
                    // ���Ӑ�
                    if (this._partsPosCodePrintWork.CustomerCodeSt != 0 || this._partsPosCodePrintWork.CustomerCodeEd != 0)
                    {

                        stTarget = this._partsPosCodePrintWork.CustomerCodeSt.ToString("00000000");
                        edTarget = this._partsPosCodePrintWork.CustomerCodeEd.ToString("00000000");
                        if (this._partsPosCodePrintWork.CustomerCodeSt == 0) stTarget = ct_Extr_Top;
                        if (this._partsPosCodePrintWork.CustomerCodeEd == 0) edTarget = ct_Extr_End;

                        this.EditCondition(ref extraConditions, string.Format("���Ӑ�" + ct_RangeConst, stTarget, edTarget));
                    }
                    // ����
                    if (this._partsPosCodePrintWork.SearchPartsPosCodeSt != 0 || this._partsPosCodePrintWork.SearchPartsPosCodeEd != 0)
                    {

                        stTarget = this._partsPosCodePrintWork.SearchPartsPosCodeSt.ToString("00");
                        edTarget = this._partsPosCodePrintWork.SearchPartsPosCodeEd.ToString("00");
                        if (this._partsPosCodePrintWork.SearchPartsPosCodeSt == 0) stTarget = ct_Extr_Top;
                        if (this._partsPosCodePrintWork.SearchPartsPosCodeEd == 0) edTarget = ct_Extr_End;

                        this.EditCondition(ref extraConditions, string.Format("����" + ct_RangeConst, stTarget, edTarget));
                    }
                    break;
            }

            // �ǉ�
            foreach ( string exCondStr in addConditions ) {
                extraConditions.Add(exCondStr);
            }
        }
		#endregion

        #region �� ���o�͈͓��t�쐬
        /// <summary>
        /// ���t�͈̔͏��������񐶐�
        /// </summary>
        /// <param name="dateTitle">���t�^�C�g��</param>
        /// <param name="stDate">�J�n���t</param>
        /// <param name="edDate">�I�����t</param>
        /// <returns></returns>
        private string GetExtarConditionOfDates(string dateTitle, DateTime stDate, DateTime edDate)
        {
            string wkStDate = string.Empty;
            string wkEdDate = string.Empty;

            string resultString = string.Empty;

            // �J�n��I���̂����ꂩ�����͂���Ă���Έ�
            if ((stDate != DateTime.MinValue) || (edDate != DateTime.MinValue))
            {
                // �J�n
                if (stDate != DateTime.MinValue)
                {
                    wkStDate = stDate.ToString("yyyy/MM/dd");
                }
                else
                {
                    wkStDate = ct_Extr_Top;
                }

                // �I��
                if (edDate != DateTime.MinValue)
                {
                    wkEdDate = edDate.ToString("yyyy/MM/dd");
                }
                else
                {
                    wkEdDate = ct_Extr_End;
                }

                resultString = string.Format(dateTitle + ct_RangeConst, wkStDate, wkEdDate);
            }

            return resultString;
        }
        #endregion �� ���o�͈͓��t�쐬

        #region �� ���o�͈͕�����쐬
        /// <summary>
		/// ���o�͈͕�����쐬
		/// </summary>
		/// <returns>�쐬������</returns>
		/// <remarks>
		/// <br>Note       : ���o�͈͕�������쐬���܂�</br>
        /// <br>Programmer : 30462 �s�V �m��</br>
        /// <br>Date       : 2008.10.30</br>
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
        /// <br>Date       : 2008.10.30</br>
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
		/// <br>Date       : 2008.10.30</br>
		/// </remarks>
		private DialogResult MsgDispProc(emErrorLevel iLevel, string iMsg, int iSt, MessageBoxButtons iButton, MessageBoxDefaultButton iDefButton)
		{
			return TMsgDisp.Show(iLevel, "PMKHN08504P", iMsg, iSt, iButton, iDefButton);
		}

		#endregion
		#endregion
	}
}
