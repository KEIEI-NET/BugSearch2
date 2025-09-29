using System;
using System.Text;
using System.Collections;
using System.Collections.Specialized;
using DataDynamics.ActiveReports;

using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;
using Broadleaf.Library.Globarization;
using Broadleaf.Drawing.Printing;

namespace Broadleaf.Drawing.Printing
{
	/// <summary>
	/// �I���L���\���(�Ȉ�)�t�H�[���N���X
	/// </summary>
	/// <remarks>
	/// <br>Note		: �I���L���\�̃t�H�[���N���X�ł��B</br>
	/// <br>Programmer	: 23010�@�����@�m</br>
	/// <br>Date		: 2007.04.10</br>
    /// <br>Update Note : 2007.09.05 980035 ���� ��`</br>
    /// <br>			  �EDC.NS�Ή�</br>
    /// <br>Update Note : 2008.02.13 980035 ���� ��`</br>
    /// <br>			  �E�s��Ή��iDC.NS�Ή��j</br>
    /// -----------------------------------------------------------------------------------
    /// <br>UpdateNote  : PM.NS�Ή�</br>
    /// <br>Programmer  : 30413 ����</br>
    /// <br>Date	    : 2008.10.14</br>
    /// -----------------------------------------------------------------------------------
    /// <br>UpdateNote  : MANTIS�Ή�(13918)</br>
    /// <br>Programmer  : 22008 ����</br>
    /// <br>Date	    : 2009/09/16</br>
    /// <br>UpdateNote  : �s��Ή�(PM.NS�ێ�˗��B�Ή�)</br>
    /// <br>Programmer  : ������</br>
    /// <br>Date	    : 2009/12/07</br>
    /// <br>UpdateNote  : Redmine#1969�Ή�</br>
    /// <br>Programmer  : ������</br>
    /// <br>Date	    : 2009/12/17</br>
    /// <br>UpdateNote  : �s��Ή�(PM1005)</br>
    /// <br>Programmer  : ������</br>
    /// <br>Date	    : 2010/02/20</br>
    /// <br>UpdateNote  : 2013/01/16�z�M���ARedmine#33271  �󎚐���̋敪�̒ǉ�</br>
    /// <br>Programmer  : ������</br>
    /// <br>Date	    : 2012/11/14</br>
    /// </remarks>
	public class MAZAI02112P_01A4C : DataDynamics.ActiveReports.ActiveReport3,IPrintActiveReportTypeList, IPrintActiveReportTypeCommon
    {
        #region Constructor
        /// <summary>
		/// �I���L���\(�Ȉ�)�t�H�[���N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
		/// <br>Note		: �I���L���\(�Ȉ�)�t�H�[���N���X�̐V�����C���X�^���X�����������܂��B</br>
		/// <br>Programmer	: 23010�@�����@�m</br>
		/// <br>Date		: 2007.04.10</br>
		/// </remarks>
		public MAZAI02112P_01A4C()
		{
			InitializeComponent();
        }
        #endregion

        #region Private Member
        private string				 _pageHeaderSortOderTitle;		// �\�[�g��
		private int					 _extraCondHeadOutDiv;			// ���o�����w�b�_�o�͋敪
		private StringCollection	 _extraConditions;				// ���o����
		private int					 _pageFooterOutCode;			// �t�b�^�[�o�͋敪
		private StringCollection	 _pageFooters;					// �t�b�^�[���b�Z�[�W
		private	SFCMN06002C			 _printInfo;					// ������N���X
		private string				 _pageHeaderSubtitle;			// �t�H�[���T�u�^�C�g��
		private ArrayList			 _otherDataList;				// ���̑��f�[�^
	
		private	InventSearchCndtnUI _extrInfo;					// ���o�����N���X

        // ���̑��f�[�^�i�[����		
		private int					 _printCount;					// �y�[�W���J�E���g�p
       
		// �w�b�_�[�T�u���|�[�g�쐬
		ListCommon_ExtraHeader _rptExtraHeader  = null;
		// �t�b�^�[���|�[�g�쐬
		ListCommon_PageFooter _rptPageFooter	= null;

        //�T�v���X�p�o�b�t�@(�q��)
        //private string _warehouseBuff = "";
        // 2007.09.05 �C�� >>>>>>>>>>>>>>>>>>>>
        ////�T�v���X�p�o�b�t�@(���Ǝ�)
        //private string _CarrierEpBuff = "";
        ////�T�v���X�p�o�b�t�@(���i�啪��)
        //private string _largeGoodsBuff = "";
        ////�T�v���X�p�o�b�t�@(���i������)
        //private string _mediumGoodsBuff = "";
        //�T�v���X�p�o�b�t�@(�I��)
        //private string _warehouseShelfNoBuff = "";
        // 2007.09.05 �C�� <<<<<<<<<<<<<<<<<<<<
        //�T�v���X�p�o�b�t�@(���[�J�[)
        //private string _makerBuff = "";
        // 2009.02.16 30413 ���� �O���[�v�T�v���X�����ǉ� >>>>>>START
        private string _groupSuppres = "";
        // 2009.02.16 30413 ���� �O���[�v�T�v���X�����ǉ� <<<<<<END
        private string _groupSuppresWarehouseShelfNo = ""; //ADD 2009/12/17
        private TextBox StockSectionCode;
        private Label Maker_Title;
        private Label SupplierCd_Title;
        private Label BLGoodsCode_Title;
        private Label BLGroupCode_Title;
        private TextBox InventStockCount_TextBox;
        private TextBox MakerCode_TextBox;
        private TextBox SupplierCd_TextBox;
        private TextBox BLGoodsCode_TextBox;
        private TextBox BLGroupCode_TextBox;
        private TextBox InventorySeqNo_TextBox;
        private Line line3;
        private Line Line_PageFooter;
        private TextBox PageFooters0;
        private TextBox PageFooters1;
        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox BlankShowFlag;
        private TextBox InvStockCntFlag;
        private TextBox WareInventStockCount_TextBox;
        private TextBox textBox5;
        private TextBox textBox6;
        private TextBox textBox4;
        private TextBox GrandInventStockCount_TextBox;
        private TextBox textBox8;
        private Line line6;

		// Dispose�`�F�b�N�p�t���O
		bool disposed = false;

		#endregion PrivateMembers

		#region Dispose(override)
		/// <summary>
		/// �g�p����Ă��郊�\�[�X�Ɍ㏈�������s���܂��B
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if(!this.disposed)
			{
				try
				{
					if(disposing)
					{
						// �w�b�_�p�T�u���|�[�g�㏈�����s
						if (this._rptExtraHeader != null)
						{
							this._rptExtraHeader.Dispose();
						}

						// �t�b�^�p�T�u���|�[�g�㏈�����s
						if (this._rptPageFooter != null)
						{
							this._rptPageFooter.Dispose();
						}
					}

					this.disposed = true;
				}
				finally
				{
					base.Dispose(disposing);
				}
			}
		} 
		#endregion

		#region Public Property
		#region IPrintActiveReportTypeList �����o
		/// <summary>
		/// �y�[�W�w�b�_�\�[�g���^�C�g������
		/// </summary>
		public string PageHeaderSortOderTitle
		{
			set{ _pageHeaderSortOderTitle = value; }
		}

		/// <summary>
		/// ���o�����w�b�_�o�͋敪[0:���y�[�W,1:�擪�y�[�W�̂�]
		/// </summary>
		public int ExtraCondHeadOutDiv
		{
			set{ _extraCondHeadOutDiv = value; }
		}
		
		/// <summary>
		/// ���o�����w�b�_�[����
		/// </summary>
		public StringCollection ExtraConditions
		{
			set{ this._extraConditions = value; }
		}

		/// <summary>
		/// �t�b�^�[�o�͋敪
		/// </summary>
		public int PageFooterOutCode
		{
			set{ this._pageFooterOutCode = value; }
		}
		
		/// <summary>
		/// �t�b�^�o�͕�
		/// </summary>
		public StringCollection PageFooters
		{
			set{ this._pageFooters = value; }
		}

		/// <summary>
		/// �������
		/// </summary>
		public SFCMN06002C PrintInfo
		{
			set
			{
				this._printInfo = value;
				this._extrInfo = (InventSearchCndtnUI)this._printInfo.jyoken;
			}
		}

		/// <summary>
		/// ���̑��f�[�^
		/// </summary>
		public ArrayList OtherDataList
		{
			set
			{
				this._otherDataList = value;			
			}
		}

		/// <summary>
		/// ���[�T�u�^�C�g��
		/// </summary>
		public string PageHeaderSubtitle
		{
			set{ this._pageHeaderSubtitle = value;}
		}

		/// <summary>
		///	��������J�E���g�A�b�v�C�x���g
		/// </summary>
		public event ProgressBarUpEventHandler ProgressBarUpEvent;        
		#endregion
		#region IPrintActiveReportTypeCommon �����o

		/// <summary>
		/// �w�i���ߐݒ�l�v���p�e�B
		/// </summary>
		public int WatermarkMode
		{
			get{return 0;}
			set{}
		}

		#endregion
		#endregion

		#region Private Method

        #region ���|�[�g�v�f�o�͐ݒ�
        /// <summary>
		/// ���|�[�g�v�f�o�͐ݒ�
		/// </summary>
 		/// <remarks>
		/// <br>Note       : ���|�[�g�̗v�f�iHeader�AFooter�AText�j�̏o�͐ݒ�</br>
		/// <br>Programmer : 23010�@�����@�m</br>
		/// <br>Date       : 2007.04.10</br>
        /// <br>Update Note: 2010/02/20 ������</br>
        /// <br>			 �s��Ή�(PM1005)</br>
        /// <br>Update Note: 2012/11/14 ������</br>
        ///	<br>			 Redmine#33271 �󎚐���̋敪�̒ǉ�</br>
        /// </remarks>
		private void SetOfReportMembersOutput()
		{
            // 2008.10.31 30413 ���� ���o�^�v���p�e�B�̂��ߍ폜 >>>>>>START
            ////���됔�󎚋敪
            //if(this._extrInfo.StockCntPrintDiv == 1)
            //{
            //    //���됔���󎚂��Ȃ�
            //    ScreenPermitionControl(false);
            //    this.StockCount_Title.Text = "�I����";
            //    this.InventStockCount_Title.Text = "�����L����";
            //}
            //else
            //{
            //    //���됔���󎚂���
            //    ScreenPermitionControl(true);
            //    this.StockCount_Title.Text = "���됔";
            //    this.InventStockCount_Title.Text = "�I����";
            //}
            // 2008.10.31 30413 ���� ���o�^�v���p�e�B�̂��ߍ폜 <<<<<<END
		    
            // ���ڂ̖��̂��Z�b�g
			SortTitle.Text	= this._pageHeaderSortOderTitle;	// �\�[�g����    

            // 2007.09.05 �ǉ� >>>>>>>>>>>>>>>>>>>>
            // ���y�[�W�w��敪
            if (this._extrInfo.TurnOoverThePagesDiv == 2)
            {
                // ���y�[�W�Ȃ�
                //this.WarehouseHeader.DataField = "";
                this.WarehouseHeader.NewPage = NewPage.None;
                this.MakerHeader.NewPage = NewPage.None;
                this.GoodsHeader.NewPage = NewPage.None;
                // -----------ADD 2010/02/20------------>>>>>
                // �v�󎚁u����v�̏ꍇ
                if (this._extrInfo.SubtotalPrintDivTemp == 1)
                {
                    this.WarehouseFooter.Visible = true;
                    this.GrandTotalFooter.Visible = true;
                }
                else
                {
                    this.WarehouseFooter.Visible = false;
                    this.GrandTotalFooter.Visible = false;
                }
                // -----------ADD 2010/02/20------------<<<<<
            }
            else if (this._extrInfo.TurnOoverThePagesDiv == 1)
            {
                // �o�͏�
                if (this._extrInfo.SortDiv == 0)
                {
                    // �q�Ɂ��I��
                    this.MakerHeader.DataField = "WarehouseShelfNo_Print";
                }
                else if (this._extrInfo.SortDiv == 1)
                {
                    // �q�Ɂ��d����
                    this.MakerHeader.DataField = "SupplierCd";
                }
                else if (this._extrInfo.SortDiv == 2)
                {
                    // �q�Ɂ��a�k�R�[�h
                    this.MakerHeader.DataField = "BLGoodsCode";
                }
                else if (this._extrInfo.SortDiv == 3)
                {
                    // �q�Ɂ��O���[�v
                    this.MakerHeader.DataField = "BLGroupCode";
                }
                else if (this._extrInfo.SortDiv == 4)
                {
                    // �q�Ɂ����[�J�[
                    this.MakerHeader.DataField = "GoodsMakerCd";
                }
                else if (this._extrInfo.SortDiv == 5)
                {
                    // �q�Ɂ��d���恨�I��
                    this.MakerHeader.DataField = "SupplierCd";
                    this.GoodsHeader.DataField = "WarehouseShelfNo_Print";
                }
                else if (this._extrInfo.SortDiv == 6)
                {
                    // �q�Ɂ��d���恨���[�J�[
                    this.MakerHeader.DataField = "SupplierCd";
                    this.GoodsHeader.DataField = "GoodsMakerCd";
                }
                // -----------ADD 2010/02/20------------>>>>>
                // �v�󎚁u����v�̏ꍇ
                if (this._extrInfo.SubtotalPrintDivTemp == 1)
                {
                    this.WarehouseFooter.Visible = true;
                    this.GrandTotalFooter.Visible = true;
                }
                else
                {
                    this.WarehouseFooter.Visible = false;
                    this.GrandTotalFooter.Visible = false;
                }
                // -----------ADD 2010/02/20------------<<<<<
            }
            // 2007.09.05 �ǉ� <<<<<<<<<<<<<<<<<<<<
            // -----------ADD 2010/02/20------------>>>>>
            // [���y�[�W�w��敪:�q��]�̏ꍇ
            else
            {
                // �v�󎚁u����v�̏ꍇ
                if (this._extrInfo.SubtotalPrintDivTemp == 1)
                {
                    this.WarehouseFooter.Visible = true;
                    this.GrandTotalFooter.Visible = true;
                }
                else
                {
                    this.WarehouseFooter.Visible = false;
                    this.GrandTotalFooter.Visible = false;
                }
            }
            // -----------ADD 2010/02/20------------<<<<<
            // --- ADD ������ 2012/11/14 for Redmine#33271---------->>>>>
            //�r���󎚋敪
            if (this._extrInfo.LineMaSqOfChDiv == 0)
            {
                //�r���󎚂���
                this.Line.Visible = true;
                this.Line2.Visible = true;
                this.line3.Visible = true;
                this.Line37.Visible = true;
                this.Line5.Visible = true;
                this.Line44.Visible = true;
                this.line6.Visible = false;
            }
            else
            {
                //�r���󎚂��Ȃ�
                this.Line.Visible = false;
                this.Line2.Visible = false;
                this.line3.Visible = false;
                this.Line37.Visible = false;
                this.Line5.Visible = false;
                this.Line44.Visible = false;
                this.line6.Visible = true;
            }
            // --- ADD ������ 2012/11/14 for Redmine#33271----------<<<<<

        }

        #endregion

        #region �o�͏��ł̈󎚃p�^�[���ύX����
        /// <summary>
        /// �o�͏��ł̈󎚃p�^�[���ύX����
        /// </summary>
        /// <remarks>
        /// <br>Note       : �o�͏��ɍ��킹�āA�󎚃p�^�[����ύX���܂�</br>
        /// <br>Programer  : 30413 ����</br>
        /// <br>Date       : 2008.10.16</br>
        /// <br>Update Note: 2009/12/07 ������</br>
        /// <br>			 �s��Ή�(PM.NS�ێ�˗��B�Ή�)</br>
        /// <br>Update Note: 2009/12/17 ������</br>
        /// <br>			 Redmine#1969�Ή�</br>
        /// <br>Update Note: 2010/02/20 ������</br>
        /// <br>			 �s��Ή�(PM1005)</br>
        /// </remarks>
        private void SetOutputPrintPattern()
        {
            switch (this._extrInfo.SortDiv)
            {
                // ---------------- UPD 2009/12/07 ---------------->>>>>
                case 1:     // �d���揇
                case 5:     // �d����E�I�ԏ�
                    {
                        // -- UPD 2009/09/16 ---------------------------->>>
                        //// ���׃^�C�g��
                        //SupplierCd_Title.Left = 0.0F;               // �d����
                        //WarehouseShelfNo_Title.Left = 0.5F;         // �I��
                        //GoodsNo_Title.Left = 1.063F;              // �i��
                        //GoodsName_Title.Left = 2.5F;                // �i��
                        //StockCount_Title.Left = 3.688F;             // ���됔
                        //InventStockCount_Title.Left = 4.125F;       // �I����
                        //StockUnitPrice_Title.Left = 4.875F;         // ���P��
                        //// --- DEL 2009/03/12 -------------------------------->>>>>
                        ////BLGoodsCode_Title.Left = 5.688F;            // BL�R�[�h
                        ////BLGroupCode_Title.Left = 6.125F;            // �O���[�v�R�[�h
                        ////Maker_Title.Left = 6.563F;                  // ���[�J�[
                        //// --- DEL 2009/03/12 --------------------------------<<<<<
                        //// --- ADD 2009/03/12 -------------------------------->>>>>
                        //BLGoodsCode_Title.Left = 5.788F;            // BL�R�[�h
                        //BLGroupCode_Title.Left = 6.225F;            // �O���[�v�R�[�h
                        //Maker_Title.Left = 6.663F;                  // ���[�J�[
                        //// --- ADD 2009/03/12 --------------------------------<<<<<

                        //// ���׍s
                        //SupplierCd_TextBox.Left = 0.0F;             // �d����
                        //WarehouseShelfNo_TextBox.Left = 0.5F;       // �I��
                        //GoodsNo_TextBox.Left = 1.063F;            // �i��
                        //GoodsName_TextBox.Left = 2.5F;              // �i��
                        //StockCount_TextBox.Left = 3.688F;           // ���됔
                        //InventStockCount_TextBox.Left = 4.125F;     // �I����
                        //StockUnitPrice_TextBox.Left = 4.875F;       // ���P��
                        //// --- DEL 2009/03/12 -------------------------------->>>>>
                        ////BLGoodsCode_TextBox.Left = 5.688F;          // BL�R�[�h
                        ////BLGroupCode_TextBox.Left = 6.125F;          // �O���[�v�R�[�h
                        ////MakerCode_TextBox.Left = 6.563F;            // ���[�J�[
                        //// --- DEL 2009/03/12 --------------------------------<<<<<
                        //// --- ADD 2009/03/12 -------------------------------->>>>>
                        //BLGoodsCode_TextBox.Left = 5.788F;          // BL�R�[�h
                        //BLGroupCode_TextBox.Left = 6.225F;          // �O���[�v�R�[�h
                        //MakerCode_TextBox.Left = 6.663F;            // ���[�J�[
                        //// --- ADD 2009/03/12 --------------------------------<<<<<
                        // -- UPD 2009/09/16 ----------------------------<<<

                        //// ���׃^�C�g��
                        //SupplierCd_Title.Left = 0.0F;               // �d����
                        //WarehouseShelfNo_Title.Left = 0.5F;         // �I��
                        //GoodsNo_Title.Left = 1.063F;              // �i��
                        //GoodsName_Title.Left = 2.5F;                // �i��
                        //StockCount_Title.Left = 3.688F;             // ���됔
                        //InventStockCount_Title.Left = 4.275F;       // �I����
                        //StockUnitPrice_Title.Left = 5.025F;         // ���P��
                        //BLGoodsCode_Title.Left = 5.878F;            // BL�R�[�h
                        //BLGroupCode_Title.Left = 6.265F;            // �O���[�v�R�[�h
                        //Maker_Title.Left = 6.653F;                  // ���[�J�[

                        //// ���׍s
                        //SupplierCd_TextBox.Left = 0.0F;             // �d����
                        //WarehouseShelfNo_TextBox.Left = 0.5F;       // �I��
                        //GoodsNo_TextBox.Left = 1.063F;            // �i��
                        //GoodsName_TextBox.Left = 2.5F;              // �i��
                        //StockCount_TextBox.Left = 3.688F;           // ���됔
                        //InventStockCount_TextBox.Left = 4.275F;     // �I����
                        //StockUnitPrice_TextBox.Left = 5.025F;       // ���P��
                        //BLGoodsCode_TextBox.Left = 5.878F;          // BL�R�[�h
                        //BLGroupCode_TextBox.Left = 6.265F;          // �O���[�v�R�[�h
                        //MakerCode_TextBox.Left = 6.653F;            // ���[�J�[

                        // ------------- UPD 2009/12/17 ----------->>>>>
                        //SupplierCd_Title.Left = 0.0F;                  // �d����
                        //WarehouseShelfNo_Title.Left = 0.433F;         // �I��
                        //GoodsNo_Title.Left = 1.126F;                  // �i��
                        //GoodsName_Title.Left = 3.659F;                // �i��
                        //StockCount_Title.Left = 4.872F;              // ���됔
                        //InventStockCount_Title.Left = 5.542F;        // �I����
                        //StockUnitPrice_Title.Left = 6.425F;         // ���P��
                        //BLGoodsCode_Title.Left = 7.188F;            // BL�R�[�h
                        //BLGroupCode_Title.Left = 7.621F;            // �O���[�v�R�[�h
                        //Maker_Title.Left = 8.054F;                  // ���[�J�[

                        //// ���׍s
                        //SupplierCd_TextBox.Left = 0.0F;             // �d����
                        //WarehouseShelfNo_TextBox.Left = 0.433F;    // �I��
                        //GoodsNo_TextBox.Left = 1.126F;            // �i��
                        //GoodsName_TextBox.Left = 3.659F;              // �i��
                        //StockCount_TextBox.Left = 4.872F;           // ���됔
                        //textBox1.Left = 5.472F;                      // (
                        //InventStockCount_TextBox.Left = 5.542F;     // �I����
                        //textBox2.Left = 6.355F;                      // )
                        //StockUnitPrice_TextBox.Left = 6.425F;       // ���P��
                        //BLGoodsCode_TextBox.Left = 7.188F;          // BL�R�[�h
                        //BLGroupCode_TextBox.Left = 7.621F;          // �O���[�v�R�[�h
                        //MakerCode_TextBox.Left = 8.054F;            // ���[�J�[
                        //// --- ADD 2009/03/12 --------------------------------<<<<<
                        SupplierCd_Title.Left = 0.0F;                  // �d����
                        WarehouseShelfNo_Title.Left = 0.388F;         // �I��
                        GoodsNo_Title.Left = 1.01F;                  // �i��
                        GoodsName_Title.Left = 3.273F;                // �i��
                        StockCount_Title.Left = 4.357F;              // ���됔
                        InventStockCount_Title.Left = 4.951F;        // �I����
                        StockUnitPrice_Title.Left = 5.565F;         // ���P��
                        BLGoodsCode_Title.Left = 6.289F;            // BL�R�[�h
                        BLGroupCode_Title.Left = 6.611F;            // �O���[�v�R�[�h
                        Maker_Title.Left = 6.939F;                  // ���[�J�[

                        // ���׍s
                        SupplierCd_TextBox.Left = 0.0F;             // �d����
                        WarehouseShelfNo_TextBox.Left = 0.388F;    // �I��
                        GoodsNo_TextBox.Left = 1.01F;            // �i��
                        GoodsName_TextBox.Left = 3.273F;              // �i��
                        StockCount_TextBox.Left = 4.357F;           // ���됔
                        textBox1.Left = 4.919F;                      // (
                        InventStockCount_TextBox.Left = 4.951F;     // �I����
                        textBox2.Left = 5.534F;                      // )
                        StockUnitPrice_TextBox.Left = 5.565F;       // ���P��
                        BLGoodsCode_TextBox.Left = 6.289F;          // BL�R�[�h
                        BLGroupCode_TextBox.Left = 6.611F;          // �O���[�v�R�[�h
                        MakerCode_TextBox.Left = 6.939F;            // ���[�J�[
                        // ------------- UPD 2009/12/17 -----------<<<<<
                        // -----------ADD 2010/02/20----------->>>>>
                        this.WarehouseTotal_Title.Left = 3.273F;
                        this.textBox5.Left = 4.919F;
                        this.WareStockCount_TextBox.Left = 4.357F;
                        this.WareInventStockCount_TextBox.Left = 4.951F;
                        this.textBox6.Left = 5.534F;
                        this.GrandTotal_Title.Left = 3.273F;
                        this.textBox4.Left = 4.919F;
                        this.GrandStockCount_TextBox.Left = 4.357F;
                        this.GrandInventStockCount_TextBox.Left = 4.951F;
                        this.textBox8.Left = 5.534F;
                        // -----------ADD 2010/02/20-----------<<<<<
                        break;
                    }
                case 2:     // BL�R�[�h��
                    {
                        // -- UPD 2009/09/16 ---------------------------->>>
                        //// ���׃^�C�g��
                        //BLGoodsCode_Title.Left = 0.0F;              // BL�R�[�h
                        //WarehouseShelfNo_Title.Left = 0.5F;         // �I��
                        //GoodsNo_Title.Left = 1.063F;              // �i��
                        //GoodsName_Title.Left = 2.5F;                // �i��
                        //StockCount_Title.Left = 3.688F;             // ���됔
                        //InventStockCount_Title.Left = 4.125F;       // �I����
                        //StockUnitPrice_Title.Left = 4.875F;         // ���P��
                        //// --- DEL 2009/03/12 -------------------------------->>>>>
                        ////SupplierCd_Title.Left = 5.688F;             // �d����
                        ////BLGroupCode_Title.Left = 6.125F;            // �O���[�v�R�[�h
                        ////Maker_Title.Left = 6.563F;                  // ���[�J�[
                        //// --- DEL 2009/03/12 --------------------------------<<<<<
                        //// --- ADD 2009/03/12 -------------------------------->>>>>
                        //SupplierCd_Title.Left = 5.788F;             // �d����
                        //BLGroupCode_Title.Left = 6.225F;            // �O���[�v�R�[�h
                        //Maker_Title.Left = 6.663F;                  // ���[�J�[
                        //// --- ADD 2009/03/12 --------------------------------<<<<<

                        //// ���׍s
                        //BLGoodsCode_TextBox.Left = 0.0F;            // BL�R�[�h
                        //WarehouseShelfNo_TextBox.Left = 0.5F;       // �I��
                        //GoodsNo_TextBox.Left = 1.063F;            // �i��
                        //GoodsName_TextBox.Left = 2.5F;              // �i��
                        //StockCount_TextBox.Left = 3.688F;           // ���됔
                        //InventStockCount_TextBox.Left = 4.125F;     // �I����
                        //StockUnitPrice_TextBox.Left = 4.875F;       // ���P��
                        //// --- DEL 2009/03/12 -------------------------------->>>>>
                        ////SupplierCd_TextBox.Left = 5.688F;           // �d����
                        ////BLGroupCode_TextBox.Left = 6.125F;          // �O���[�v�R�[�h
                        ////MakerCode_TextBox.Left = 6.563F;            // ���[�J�[
                        //// --- DEL 2009/03/12 --------------------------------<<<<<
                        //// --- ADD 2009/03/12 -------------------------------->>>>>
                        //SupplierCd_TextBox.Left = 5.788F;           // �d����
                        //BLGroupCode_TextBox.Left = 6.225F;          // �O���[�v�R�[�h
                        //MakerCode_TextBox.Left = 6.663F;            // ���[�J�[
                        //// --- ADD 2009/03/12 --------------------------------<<<<<

                        // ���׃^�C�g��
                        //BLGoodsCode_Title.Left = 0.0F;              // BL�R�[�h
                        //WarehouseShelfNo_Title.Left = 0.5F;         // �I��
                        //GoodsNo_Title.Left = 1.063F;              // �i��
                        //GoodsName_Title.Left = 2.5F;                // �i��
                        //StockCount_Title.Left = 3.688F;             // ���됔
                        //InventStockCount_Title.Left = 4.275F;       // �I����
                        //StockUnitPrice_Title.Left = 5.025F;         // ���P��
                        //SupplierCd_Title.Left = 5.878F;             // �d����
                        //BLGroupCode_Title.Left = 6.305F;            // �O���[�v�R�[�h
                        //Maker_Title.Left = 6.653F;                  // ���[�J�[

                        //// ���׍s
                        //BLGoodsCode_TextBox.Left = 0.0F;            // BL�R�[�h
                        //WarehouseShelfNo_TextBox.Left = 0.5F;       // �I��
                        //GoodsNo_TextBox.Left = 1.063F;            // �i��
                        //GoodsName_TextBox.Left = 2.5F;              // �i��
                        //StockCount_TextBox.Left = 3.688F;           // ���됔
                        //InventStockCount_TextBox.Left = 4.275F;     // �I����
                        //StockUnitPrice_TextBox.Left = 5.025F;       // ���P��
                        //SupplierCd_TextBox.Left = 5.878F;           // �d����
                        //BLGroupCode_TextBox.Left = 6.305F;          // �O���[�v�R�[�h
                        //MakerCode_TextBox.Left = 6.653F;            // ���[�J�[

                        // ------------- UPD 2009/12/17 ----------->>>>>
                        //BLGoodsCode_Title.Left = 0.0F;              // BL�R�[�h
                        //WarehouseShelfNo_Title.Left = 0.433F;         // �I��
                        //GoodsNo_Title.Left = 1.126F;                  // �i��
                        //GoodsName_Title.Left = 3.659F;                // �i��
                        //StockCount_Title.Left = 4.872F;              // ���됔
                        //InventStockCount_Title.Left = 5.542F;        // �I����
                        //StockUnitPrice_Title.Left = 6.425F;         // ���P��
                        //SupplierCd_Title.Left = 7.188F;             // �d����
                        //BLGroupCode_Title.Left = 7.621F;            // �O���[�v�R�[�h
                        //Maker_Title.Left = 8.054F;                  // ���[�J�[

                        //// ���׍s
                        //BLGoodsCode_TextBox.Left = 0.0F;            // BL�R�[�h
                        //WarehouseShelfNo_TextBox.Left = 0.433F;       // �I��
                        //GoodsNo_TextBox.Left = 1.126F;            // �i��
                        //GoodsName_TextBox.Left = 3.659F;              // �i��
                        //StockCount_TextBox.Left = 4.872F;           // ���됔
                        //textBox1.Left = 5.472F;                      // (
                        //InventStockCount_TextBox.Left = 5.542F;     // �I����
                        //textBox2.Left = 6.355F;                      // )
                        //StockUnitPrice_TextBox.Left = 6.425F;       // ���P��
                        //SupplierCd_TextBox.Left = 7.188F;           // �d����
                        //BLGroupCode_TextBox.Left = 7.621F;          // �O���[�v�R�[�h
                        //MakerCode_TextBox.Left = 8.054F;            // ���[�J�[
                        //// -- UPD 2009/09/16 ----------------------------<<<
                        BLGoodsCode_Title.Left = 0.0F;              // BL�R�[�h
                        WarehouseShelfNo_Title.Left = 0.322F;         // �I��
                        GoodsNo_Title.Left = 0.947F;                  // �i��
                        GoodsName_Title.Left = 3.207F;                // �i��
                        StockCount_Title.Left = 4.291F;              // ���됔
                        InventStockCount_Title.Left = 4.887F;        // �I����
                        StockUnitPrice_Title.Left = 5.501F;         // ���P��
                        SupplierCd_Title.Left = 6.225F;             // �d����
                        BLGroupCode_Title.Left = 6.613F;            // �O���[�v�R�[�h
                        Maker_Title.Left = 6.941F;                  // ���[�J�[

                        // ���׍s
                        BLGoodsCode_TextBox.Left = 0.0F;            // BL�R�[�h
                        WarehouseShelfNo_TextBox.Left = 0.322F;       // �I��
                        GoodsNo_TextBox.Left = 0.947F;            // �i��
                        GoodsName_TextBox.Left = 3.207F;              // �i��
                        StockCount_TextBox.Left = 4.291F;           // ���됔
                        textBox1.Left = 4.855F;                      // (
                        InventStockCount_TextBox.Left = 4.887F;     // �I����
                        textBox2.Left = 5.47F;                      // )
                        StockUnitPrice_TextBox.Left = 5.501F;       // ���P��
                        SupplierCd_TextBox.Left = 6.225F;           // �d����
                        BLGroupCode_TextBox.Left = 6.613F;          // �O���[�v�R�[�h
                        MakerCode_TextBox.Left = 6.941F;            // ���[�J�[
                        // ------------- UPD 2009/12/17 -----------<<<<<
                        // -----------ADD 2010/02/20----------->>>>>
                        this.WarehouseTotal_Title.Left = 3.207F;
                        this.textBox5.Left = 4.855F;
                        this.WareStockCount_TextBox.Left = 4.291F;
                        this.WareInventStockCount_TextBox.Left = 4.887F;
                        this.textBox6.Left = 5.47F;
                        this.GrandTotal_Title.Left = 3.207F;
                        this.textBox4.Left = 4.855F;
                        this.GrandStockCount_TextBox.Left = 4.291F;
                        this.GrandInventStockCount_TextBox.Left = 4.887F;
                        this.textBox8.Left = 5.47F;
                        // -----------ADD 2010/02/20-----------<<<<<
                        break;
                    }
                case 3:     // �O���[�v�R�[�h��
                    {

                        // -- UPD 2009/09/16 ---------------------------->>>
                        //// ���׃^�C�g��
                        //BLGroupCode_Title.Left = 0.0F;              // �O���[�v�R�[�h
                        //WarehouseShelfNo_Title.Left = 0.5F;         // �I��
                        //GoodsNo_Title.Left = 1.063F;              // �i��
                        //GoodsName_Title.Left = 2.5F;                // �i��
                        //StockCount_Title.Left = 3.688F;             // ���됔
                        //InventStockCount_Title.Left = 4.125F;       // �I����
                        //StockUnitPrice_Title.Left = 4.875F;         // ���P��
                        //// --- DEL 2009/03/12 -------------------------------->>>>>
                        ////SupplierCd_Title.Left = 5.688F;             // �d����
                        ////BLGoodsCode_Title.Left = 6.125F;            // BL�R�[�h
                        ////Maker_Title.Left = 6.563F;                  // ���[�J�[
                        //// --- DEL 2009/03/12 --------------------------------<<<<<
                        //// --- ADD 2009/03/12 -------------------------------->>>>>
                        //SupplierCd_Title.Left = 5.788F;             // �d����
                        //BLGoodsCode_Title.Left = 6.225F;            // BL�R�[�h
                        //Maker_Title.Left = 6.663F;                  // ���[�J�[
                        //// --- ADD 2009/03/12 --------------------------------<<<<<

                        //// ���׍s
                        //BLGroupCode_TextBox.Left = 0.0F;            // �O���[�v�R�[�h
                        //WarehouseShelfNo_TextBox.Left = 0.5F;       // �I��
                        //GoodsNo_TextBox.Left = 1.063F;            // �i��
                        //GoodsName_TextBox.Left = 2.5F;              // �i��
                        //StockCount_TextBox.Left = 3.688F;           // ���됔
                        //InventStockCount_TextBox.Left = 4.125F;     // �I����
                        //StockUnitPrice_TextBox.Left = 4.875F;       // ���P��
                        //// --- DEL 2009/03/12 -------------------------------->>>>>
                        ////SupplierCd_TextBox.Left = 5.688F;           // �d����
                        ////BLGoodsCode_TextBox.Left = 6.125F;          // BL�R�[�h
                        ////MakerCode_TextBox.Left = 6.563F;            // ���[�J�[
                        //// --- DEL 2009/03/12 --------------------------------<<<<<
                        //// --- ADD 2009/03/12 -------------------------------->>>>>
                        //SupplierCd_TextBox.Left = 5.788F;           // �d����
                        //BLGoodsCode_TextBox.Left = 6.225F;          // BL�R�[�h
                        //MakerCode_TextBox.Left = 6.663F;            // ���[�J�[
                        //// --- ADD 2009/03/12 --------------------------------<<<<<
                        // ���׃^�C�g��
                        //BLGroupCode_Title.Left = 0.0F;              // �O���[�v�R�[�h
                        //WarehouseShelfNo_Title.Left = 0.5F;         // �I��
                        //GoodsNo_Title.Left = 1.063F;              // �i��
                        //GoodsName_Title.Left = 2.5F;                // �i��
                        //StockCount_Title.Left = 3.688F;             // ���됔
                        //InventStockCount_Title.Left = 4.275F;       // �I����
                        //StockUnitPrice_Title.Left = 5.025F;         // ���P��
                        //SupplierCd_Title.Left = 5.878F;             // �d����
                        //BLGoodsCode_Title.Left = 6.305F;            // BL�R�[�h
                        //Maker_Title.Left = 6.653F;                  // ���[�J�[

                        //// ���׍s
                        //BLGroupCode_TextBox.Left = 0.0F;            // �O���[�v�R�[�h
                        //WarehouseShelfNo_TextBox.Left = 0.5F;       // �I��
                        //GoodsNo_TextBox.Left = 1.063F;            // �i��
                        //GoodsName_TextBox.Left = 2.5F;              // �i��
                        //StockCount_TextBox.Left = 3.688F;           // ���됔
                        //InventStockCount_TextBox.Left = 4.275F;     // �I����
                        //StockUnitPrice_TextBox.Left = 5.025F;       // ���P��
                        //SupplierCd_TextBox.Left = 5.878F;           // �d����
                        //BLGoodsCode_TextBox.Left = 6.305F;          // BL�R�[�h
                        //MakerCode_TextBox.Left = 6.653F;            // ���[�J�[

                        // ------------- UPD 2009/12/17 ----------->>>>>
                        //BLGroupCode_Title.Left = 0.0F;              // �O���[�v�R�[�h
                        //WarehouseShelfNo_Title.Left = 0.433F;         // �I��
                        //GoodsNo_Title.Left = 1.126F;                  // �i��
                        //GoodsName_Title.Left = 3.659F;                // �i��
                        //StockCount_Title.Left = 4.872F;              // ���됔
                        //InventStockCount_Title.Left = 5.542F;        // �I����
                        //StockUnitPrice_Title.Left = 6.425F;         // ���P��
                        //SupplierCd_Title.Left = 7.188F;             // �d����
                        //BLGoodsCode_Title.Left = 7.621F;            // BL�R�[�h
                        //Maker_Title.Left = 8.054F;                  // ���[�J�[

                        //// ���׍s
                        //BLGroupCode_TextBox.Left = 0.0F;            // �O���[�v�R�[�h
                        //WarehouseShelfNo_TextBox.Left = 0.433F;       // �I��
                        //GoodsNo_TextBox.Left = 1.126F;            // �i��
                        //GoodsName_TextBox.Left = 3.659F;              // �i��
                        //StockCount_TextBox.Left = 4.872F;           // ���됔
                        //textBox1.Left = 5.472F;                      // (
                        //InventStockCount_TextBox.Left = 5.542F;     // �I����
                        //textBox2.Left = 6.355F;                      // )
                        //StockUnitPrice_TextBox.Left = 6.425F;       // ���P��
                        //SupplierCd_TextBox.Left = 7.188F;           // �d����
                        //BLGoodsCode_TextBox.Left = 7.621F;          // BL�R�[�h
                        //MakerCode_TextBox.Left = 8.054F;            // ���[�J�[
                        //// -- UPD 2009/09/16 ----------------------------<<<
                        BLGroupCode_Title.Left = 0.0F;              // �O���[�v�R�[�h
                        WarehouseShelfNo_Title.Left = 0.328F;         // �I��
                        GoodsNo_Title.Left = 0.953F;                  // �i��
                        GoodsName_Title.Left = 3.213F;                // �i��
                        StockCount_Title.Left = 4.297F;              // ���됔
                        InventStockCount_Title.Left = 4.891F;        // �I����
                        StockUnitPrice_Title.Left = 5.505F;         // ���P��
                        SupplierCd_Title.Left = 6.229F;             // �d����
                        BLGoodsCode_Title.Left = 6.617F;            // BL�R�[�h
                        Maker_Title.Left = 6.945F;                  // ���[�J�[

                        // ���׍s
                        BLGroupCode_TextBox.Left = 0.0F;            // �O���[�v�R�[�h
                        WarehouseShelfNo_TextBox.Left = 0.328F;       // �I��
                        GoodsNo_TextBox.Left = 0.953F;            // �i��
                        GoodsName_TextBox.Left = 3.213F;              // �i��
                        StockCount_TextBox.Left = 4.297F;           // ���됔
                        textBox1.Left = 4.859F;                      // (
                        InventStockCount_TextBox.Left = 4.891F;     // �I����
                        textBox2.Left = 5.474F;                      // )
                        StockUnitPrice_TextBox.Left = 5.505F;       // ���P��
                        SupplierCd_TextBox.Left = 6.229F;           // �d����
                        BLGoodsCode_TextBox.Left = 6.617F;          // BL�R�[�h
                        MakerCode_TextBox.Left = 6.945F;            // ���[�J�[
                        // ------------- UPD 2009/12/17 -----------<<<<<
                        // -----------ADD 2010/02/20----------->>>>>
                        this.WarehouseTotal_Title.Left = 3.213F;
                        this.textBox5.Left = 4.859F;
                        this.WareStockCount_TextBox.Left = 4.297F;
                        this.WareInventStockCount_TextBox.Left = 4.891F;
                        this.textBox6.Left = 5.474F;
                        this.GrandTotal_Title.Left = 3.213F;
                        this.textBox4.Left = 4.859F;
                        this.GrandStockCount_TextBox.Left = 4.297F;
                        this.GrandInventStockCount_TextBox.Left = 4.891F;
                        this.textBox8.Left = 5.474F;
                        // -----------ADD 2010/02/20-----------<<<<<
                        break;
                    }
                case 4:     // ���[�J�[��
                    {
                        // -- UPD 2009/09/16 ---------------------------->>>
                        //// ���׃^�C�g��
                        //Maker_Title.Left = 0.0F;                    // ���[�J�[
                        //WarehouseShelfNo_Title.Left = 0.375F;       // �I��
                        //GoodsNo_Title.Left = 0.938F;              // �i��
                        //GoodsName_Title.Left = 2.375F;              // �i��
                        //StockCount_Title.Left = 3.563F;             // ���됔
                        //InventStockCount_Title.Left = 4.0F;         // �I����
                        //StockUnitPrice_Title.Left = 4.75F;          // ���P��
                        //// --- DEL 2009/03/12 -------------------------------->>>>>
                        ////SupplierCd_Title.Left = 5.563F;             // �d����
                        ////BLGoodsCode_Title.Left = 6.0F;              // BL�R�[�h
                        ////BLGroupCode_Title.Left = 6.438F;            // �O���[�v�R�[�h
                        //// --- DEL 2009/03/12 --------------------------------<<<<<
                        //// --- ADD 2009/03/12 -------------------------------->>>>>
                        //SupplierCd_Title.Left = 5.663F;             // �d����
                        //BLGoodsCode_Title.Left = 6.1F;              // BL�R�[�h
                        //BLGroupCode_Title.Left = 6.538F;            // �O���[�v�R�[�h
                        //// --- ADD 2009/03/12 --------------------------------<<<<<

                        //// ���׍s
                        //MakerCode_TextBox.Left = 0.0F;              // ���[�J�[
                        //WarehouseShelfNo_TextBox.Left = 0.375F;     // �I��
                        //GoodsNo_TextBox.Left = 0.938F;            // �i��
                        //GoodsName_TextBox.Left = 2.375F;            // �i��
                        //StockCount_TextBox.Left = 3.563F;           // ���됔
                        //InventStockCount_TextBox.Left = 4.0F;       // �I����
                        //StockUnitPrice_TextBox.Left = 4.75F;        // ���P��
                        //// --- DEL 2009/03/12 -------------------------------->>>>>
                        ////SupplierCd_TextBox.Left = 5.563F;           // �d����
                        ////BLGoodsCode_TextBox.Left = 6.0F;            // BL�R�[�h
                        ////BLGroupCode_TextBox.Left = 6.438F;          // �O���[�v�R�[�h
                        //// --- DEL 2009/03/12 --------------------------------<<<<<
                        //// --- ADD 2009/03/12 -------------------------------->>>>>
                        //SupplierCd_TextBox.Left = 5.663F;           // �d����
                        //BLGoodsCode_TextBox.Left = 6.1F;            // BL�R�[�h
                        //BLGroupCode_TextBox.Left = 6.538F;          // �O���[�v�R�[�h
                        //// --- ADD 2009/03/12 --------------------------------<<<<<

                        // ���׃^�C�g��
                        //Maker_Title.Left = 0.0F;                    // ���[�J�[
                        //WarehouseShelfNo_Title.Left = 0.375F;       // �I��
                        //GoodsNo_Title.Left = 1.063F;              // �i��
                        //GoodsName_Title.Left = 2.5F;              // �i��
                        //StockCount_Title.Left = 3.688F;             // ���됔
                        //InventStockCount_Title.Left = 4.275F;         // �I����
                        //StockUnitPrice_Title.Left = 5.025F;          // ���P��
                        //SupplierCd_Title.Left = 5.828F;             // �d����
                        //BLGoodsCode_Title.Left = 6.255F;              // BL�R�[�h
                        //BLGroupCode_Title.Left = 6.603F;            // �O���[�v�R�[�h

                        //// ���׍s
                        //MakerCode_TextBox.Left = 0.0F;              // ���[�J�[
                        //WarehouseShelfNo_TextBox.Left = 0.375F;     // �I��
                        //GoodsNo_TextBox.Left = 1.063F;            // �i��
                        //GoodsName_TextBox.Left = 2.5F;            // �i��
                        //StockCount_TextBox.Left = 3.688F;           // ���됔
                        //InventStockCount_TextBox.Left = 4.275F;       // �I����
                        //StockUnitPrice_TextBox.Left = 5.025F;        // ���P��
                        //SupplierCd_TextBox.Left = 5.828F;           // �d����
                        //BLGoodsCode_TextBox.Left = 6.255F;            // BL�R�[�h
                        //BLGroupCode_TextBox.Left = 6.603F;          // �O���[�v�R�[�h

                        // ------------- UPD 2009/12/17 ----------->>>>>
                        //Maker_Title.Left = 0.0F;                    // ���[�J�[
                        //WarehouseShelfNo_Title.Left = 0.323F;         // �I��
                        //GoodsNo_Title.Left = 1.016F;                  // �i��
                        //GoodsName_Title.Left = 3.549F;                // �i��
                        //StockCount_Title.Left = 4.762F;              // ���됔
                        //InventStockCount_Title.Left = 5.432F;        // �I����
                        //StockUnitPrice_Title.Left = 6.315F;         // ���P��
                        //SupplierCd_Title.Left = 7.078F;             // �d����
                        //BLGoodsCode_Title.Left = 7.511F;              // BL�R�[�h
                        //BLGroupCode_Title.Left = 7.944F;            // �O���[�v�R�[�h

                        //// ���׍s
                        //MakerCode_TextBox.Left = 0.0F;              // ���[�J�[
                        //WarehouseShelfNo_TextBox.Left = 0.323F;       // �I��
                        //GoodsNo_TextBox.Left = 1.016F;            // �i��
                        //GoodsName_TextBox.Left = 3.549F;              // �i��
                        //StockCount_TextBox.Left = 4.762F;           // ���됔
                        //textBox1.Left = 5.362F;                      // (
                        //InventStockCount_TextBox.Left = 5.432F;     // �I����
                        //textBox2.Left = 6.245F;                           // )
                        //StockUnitPrice_TextBox.Left = 6.315F;       // ���P��
                        //SupplierCd_TextBox.Left = 7.078F;           // �d����
                        //BLGoodsCode_TextBox.Left = 7.511F;            // BL�R�[�h
                        //BLGroupCode_TextBox.Left = 7.944F;          // �O���[�v�R�[�h
                        //// -- UPD 2009/09/16 ----------------------------<<<
                        Maker_Title.Left = 0.0F;                    // ���[�J�[
                        WarehouseShelfNo_Title.Left = 0.269F;         // �I��
                        GoodsNo_Title.Left = 0.894F;                  // �i��
                        GoodsName_Title.Left = 3.154F;                // �i��
                        StockCount_Title.Left = 4.238F;              // ���됔
                        InventStockCount_Title.Left = 4.832F;        // �I����
                        StockUnitPrice_Title.Left = 5.446F;         // ���P��
                        SupplierCd_Title.Left = 6.17F;             // �d����
                        BLGoodsCode_Title.Left = 6.558F;              // BL�R�[�h
                        BLGroupCode_Title.Left = 6.88F;            // �O���[�v�R�[�h

                        // ���׍s
                        MakerCode_TextBox.Left = 0.0F;              // ���[�J�[
                        WarehouseShelfNo_TextBox.Left = 0.269F;       // �I��
                        GoodsNo_TextBox.Left = 0.894F;            // �i��
                        GoodsName_TextBox.Left = 3.154F;              // �i��
                        StockCount_TextBox.Left = 4.238F;           // ���됔
                        textBox1.Left = 4.8F;                      // (
                        InventStockCount_TextBox.Left = 4.832F;     // �I����
                        textBox2.Left = 5.415F;                     // )
                        StockUnitPrice_TextBox.Left = 5.446F;       // ���P��
                        SupplierCd_TextBox.Left = 6.17F;           // �d����
                        BLGoodsCode_TextBox.Left = 6.558F;            // BL�R�[�h
                        BLGroupCode_TextBox.Left = 6.88F;          // �O���[�v�R�[�h
                        // ------------- UPD 2009/12/17 -----------<<<<<
                        // -----------ADD 2010/02/20----------->>>>>
                        this.WarehouseTotal_Title.Left = 3.154F;
                        this.textBox5.Left = 4.8F;
                        this.WareStockCount_TextBox.Left = 4.238F;
                        this.WareInventStockCount_TextBox.Left = 4.832F;
                        this.textBox6.Left = 5.415F;
                        this.GrandTotal_Title.Left = 3.154F;
                        this.textBox4.Left = 4.8F;
                        this.GrandStockCount_TextBox.Left = 4.238F;
                        this.GrandInventStockCount_TextBox.Left = 4.832F;
                        this.textBox8.Left = 5.415F;
                        // -----------ADD 2010/02/20-----------<<<<<
                        break;
                    }
                case 6:     // �d����E���[�J�[��
                    {
                        // -- UPD 2009/09/16 ---------------------------->>>
                        //// ���׃^�C�g��
                        //SupplierCd_Title.Left = 0.0F;               // �d����
                        //Maker_Title.Left = 0.5F;                    // ���[�J�[
                        //WarehouseShelfNo_Title.Left = 0.813F;       // �I��
                        //GoodsNo_Title.Left = 1.375F;              // �i��
                        //GoodsName_Title.Left = 2.813F;              // �i��
                        //StockCount_Title.Left = 4.0F;               // ���됔
                        //InventStockCount_Title.Left = 4.438F;       // �I����
                        //StockUnitPrice_Title.Left = 5.188F;         // ���P��
                        //// --- DEL 2009/03/12 -------------------------------->>>>>
                        ////BLGoodsCode_Title.Left = 6.0F;              // BL�R�[�h
                        ////BLGroupCode_Title.Left = 6.438F;            // �O���[�v�R�[�h
                        //// --- DEL 2009/03/12 --------------------------------<<<<<
                        //// --- ADD 2009/03/12 -------------------------------->>>>>
                        //BLGoodsCode_Title.Left = 6.1F;              // BL�R�[�h
                        //BLGroupCode_Title.Left = 6.538F;            // �O���[�v�R�[�h
                        //// --- ADD 2009/03/12 --------------------------------<<<<<

                        //// ���׍s
                        //SupplierCd_TextBox.Left = 0.0F;             // �d����
                        //MakerCode_TextBox.Left = 0.5F;              // ���[�J�[
                        //WarehouseShelfNo_TextBox.Left = 0.813F;     // �I��
                        //GoodsNo_TextBox.Left = 1.375F;            // �i��
                        //GoodsName_TextBox.Left = 2.813F;            // �i��
                        //StockCount_TextBox.Left = 4.0F;             // ���됔
                        //InventStockCount_TextBox.Left = 4.438F;     // �I����
                        //StockUnitPrice_TextBox.Left = 5.188F;       // ���P��
                        //// --- DEL 2009/03/12 -------------------------------->>>>>
                        ////BLGoodsCode_TextBox.Left = 6.0F;            // BL�R�[�h
                        ////BLGroupCode_TextBox.Left = 6.438F;          // �O���[�v�R�[�h
                        //// --- DEL 2009/03/12 --------------------------------<<<<<
                        //// --- ADD 2009/03/12 -------------------------------->>>>>
                        //BLGoodsCode_TextBox.Left = 6.1F;            // BL�R�[�h
                        //BLGroupCode_TextBox.Left = 6.538F;          // �O���[�v�R�[�h
                        //// --- ADD 2009/03/12 --------------------------------<<<<<

                        // ���׃^�C�g��
                        //SupplierCd_Title.Left = 0.0F;               // �d����
                        //Maker_Title.Left = 0.5F;                    // ���[�J�[
                        //WarehouseShelfNo_Title.Left = 0.813F;       // �I��
                        //GoodsNo_Title.Left = 1.375F;              // �i��
                        //GoodsName_Title.Left = 2.813F;              // �i��
                        //StockCount_Title.Left = 4.0F;               // ���됔
                        //InventStockCount_Title.Left = 4.587F;       // �I����
                        //StockUnitPrice_Title.Left = 5.337F;         // ���P��
                        //BLGoodsCode_Title.Left = 6.255F;              // BL�R�[�h
                        //BLGroupCode_Title.Left = 6.603F;            // �O���[�v�R�[�h

                        //// ���׍s
                        //SupplierCd_TextBox.Left = 0.0F;             // �d����
                        //MakerCode_TextBox.Left = 0.5F;              // ���[�J�[
                        //WarehouseShelfNo_TextBox.Left = 0.813F;     // �I��
                        //GoodsNo_TextBox.Left = 1.375F;            // �i��
                        //GoodsName_TextBox.Left = 2.813F;            // �i��
                        //StockCount_TextBox.Left = 4.0F;             // ���됔
                        //InventStockCount_TextBox.Left = 4.587F;     // �I����
                        //StockUnitPrice_TextBox.Left = 5.337F;       // ���P��
                        //BLGoodsCode_TextBox.Left = 6.255F;            // BL�R�[�h
                        //BLGroupCode_TextBox.Left = 6.603F;          // �O���[�v�R�[�h

                        // ------------- UPD 2009/12/17 ----------->>>>>
                        //SupplierCd_Title.Left = 0.0F;               // �d����
                        //Maker_Title.Left = 0.433F;                    // ���[�J�[
                        //WarehouseShelfNo_Title.Left = 0.756F;       // �I��
                        //GoodsNo_Title.Left = 1.449F;              // �i��
                        //GoodsName_Title.Left = 3.982F;              // �i��
                        //StockCount_Title.Left = 5.195F;               // ���됔
                        //InventStockCount_Title.Left = 5.865F;       // �I����
                        //StockUnitPrice_Title.Left = 6.748F;         // ���P��
                        //BLGoodsCode_Title.Left = 7.511F;              // BL�R�[�h
                        //BLGroupCode_Title.Left = 7.944F;            // �O���[�v�R�[�h

                        //// ���׍s
                        //SupplierCd_TextBox.Left = 0.0F;             // �d����
                        //MakerCode_TextBox.Left = 0.433F;              // ���[�J�[
                        //WarehouseShelfNo_TextBox.Left = 0.756F;     // �I��
                        //GoodsNo_TextBox.Left = 1.449F;            // �i��
                        //GoodsName_TextBox.Left = 3.982F;            // �i��
                        //StockCount_TextBox.Left = 5.195F;           // ���됔
                        //textBox1.Left = 5.795F;                      // (
                        //InventStockCount_TextBox.Left = 5.865F;     // �I����
                        //textBox2.Left = 6.678F;                           // )
                        //StockUnitPrice_TextBox.Left = 6.748F;       // ���P��
                        //BLGoodsCode_TextBox.Left = 7.511F;            // BL�R�[�h
                        //BLGroupCode_TextBox.Left = 7.944F;          // �O���[�v�R�[�h
                        //// -- UPD 2009/09/16 ----------------------------<<<
                        SupplierCd_Title.Left = 0.0F;               // �d����
                        Maker_Title.Left = 0.388F;                    // ���[�J�[
                        WarehouseShelfNo_Title.Left = 0.657F;       // �I��
                        GoodsNo_Title.Left = 1.282F;              // �i��
                        GoodsName_Title.Left = 3.542F;              // �i��
                        StockCount_Title.Left = 4.626F;               // ���됔
                        InventStockCount_Title.Left = 5.22F;       // �I����
                        StockUnitPrice_Title.Left = 5.834F;         // ���P��
                        BLGoodsCode_Title.Left = 6.558F;              // BL�R�[�h
                        BLGroupCode_Title.Left = 6.886F;            // �O���[�v�R�[�h

                        // ���׍s
                        SupplierCd_TextBox.Left = 0.0F;             // �d����
                        MakerCode_TextBox.Left = 0.388F;              // ���[�J�[
                        WarehouseShelfNo_TextBox.Left = 0.657F;     // �I��
                        GoodsNo_TextBox.Left = 1.282F;            // �i��
                        GoodsName_TextBox.Left = 3.542F;            // �i��
                        StockCount_TextBox.Left = 4.626F;           // ���됔
                        textBox1.Left = 5.188F;                      // (
                        InventStockCount_TextBox.Left = 5.22F;     // �I����
                        textBox2.Left = 5.803F;                           // )
                        StockUnitPrice_TextBox.Left = 5.834F;       // ���P��
                        BLGoodsCode_TextBox.Left = 6.558F;            // BL�R�[�h
                        BLGroupCode_TextBox.Left = 6.886F;          // �O���[�v�R�[�h
                        // ------------- UPD 2009/12/17 -----------<<<<<
                        // -----------ADD 2010/02/20----------->>>>>
                        this.WarehouseTotal_Title.Left = 3.542F;
                        this.textBox5.Left = 5.188F;
                        this.WareStockCount_TextBox.Left = 4.626F;
                        this.WareInventStockCount_TextBox.Left = 5.22F;
                        this.textBox6.Left = 5.803F;
                        this.GrandTotal_Title.Left = 3.542F;
                        this.textBox4.Left = 5.188F;
                        this.GrandStockCount_TextBox.Left = 4.626F;
                        this.GrandInventStockCount_TextBox.Left = 5.22F;
                        this.textBox8.Left = 5.803F;
                        // -----------ADD 2010/02/20-----------<<<<<
                        break;
                    }
                default:
                    {
                        break;
                    }
                // ---------------- UPD 2009/12/07 ----------------<<<<<
            }
        }
        #endregion

        #region ��ʏ�ԕύX����
        /// <summary>
		/// ��ʏ�ԕύX����
		/// </summary>
		/// <param name="conditon"></param>
		/// <remarks>
		/// <br>Note       : ���됔�󎚋敪�ɍ��킹����ʏ�ԕύX�������s���܂�</br>
		/// <br>Programmer : 23010�@�����@�m</br>
		/// <br>Date       : 2007.04.10</br>
		/// </remarks>
        private void ScreenPermitionControl(bool conditon)
        {
            //�t�b�^
            this.GrandTotalFooter.Visible = conditon;
            this.WarehouseFooter.Visible = conditon;
            this.MakerFooter.Visible = conditon;
            // 2007.09.05 �폜 >>>>>>>>>>>>>>>>>>>>
            //this.CellphoneModelFooter.Visible = conditon;
            // 2007.09.05 �폜 <<<<<<<<<<<<<<<<<<<<
            this.GoodsFooter.Visible = conditon;
            //����݌ɐ�
            this.InventorySeqNo_Title.Visible = conditon;
            this.StockCount_TextBox.Visible = conditon;
            //this.StockCount_Title.Visible = conditon;

        }
        #endregion

        #region �o�b�t�@�N���A����
        /// <summary>
        /// �o�b�t�@�N���A����
        /// </summary>
        /// <remarks>
        /// <br>Note      : �O���[�v�T�v���X�p�̃o�b�t�@�����������܂�</br>
        /// <br>Programer : 23010 �����@�m</br>
        /// <br>Date      : 2007.04.10</br>
        /// </remarks>
        private void BufferClear()
        {
            //this._warehouseBuff = "";
            // 2007.09.05 �C�� >>>>>>>>>>>>>>>>>>>>
            //this._CarrierEpBuff = "";
            //this._largeGoodsBuff = "";
            //this._mediumGoodsBuff = "";
            //this._warehouseShelfNoBuff = "";
            // 2007.09.05 �C�� <<<<<<<<<<<<<<<<<<<<
            //this._makerBuff = "";

            // 2009.02.16 30413 ���� �O���[�v�T�v���X�����ǉ� >>>>>>START
            this._groupSuppres = "";
            // 2009.02.16 30413 ���� �O���[�v�T�v���X�����ǉ� <<<<<<END
        }

        #endregion

        #region �O���[�v�T�v���X����
        /// <summary>
        /// �O���[�v�T�v���X����
        /// </summary>
        /// <remarks>
        /// <br>Note      : �O���[�v�T�v���X�������s���܂�</br>
        /// <br>Programer : 23010 �����@�m</br>
        /// <br>Date      : 2007.04.10</br>
        /// </remarks>    
        private void SetOfGroupSuppres()
        {      
            // 2009.02.16 30413 ���� ���g�p�Ȃ̂ō폜 >>>>>>START
            //TextBox��Null�����邱�Ƃ�����̂ňꉞNull��������Ă���
            //�O���[�v�T�v���X����(�q��)    
            //if(this.WarehouseCode_TextBox.Text != null)
            //{               
            //    if(this.WarehouseCode_TextBox.Text.CompareTo(this._warehouseBuff) == 0)
            //    {
            //        this.Warehouse_TextBox.Visible = false;
            //    }
            //    else
            //    {
            //        this.Warehouse_TextBox.Visible = true;
            //        //�o�b�t�@�X�V
            //        this._warehouseBuff = this.WarehouseCode_TextBox.Text;
            //    }            
            //}
            //else
            //{
            //    //��O�I�ȏꍇ
            //    //null�̏ꍇ�͋󕶎��ƌ��Ȃ�
            //    if(this._warehouseBuff == string.Empty)
            //    {
            //        this.Warehouse_TextBox.Visible = false;
            //    }
            //    else
            //    {
            //        this.Warehouse_TextBox.Visible = true;
            //        //�o�b�t�@���󕶎��ōX�V
            //        this._warehouseBuff = string.Empty;
            //    }               
            //}
            // 2009.02.16 30413 ���� ���g�p�Ȃ̂ō폜 <<<<<<END
            
            // 2007.09.05 �C�� >>>>>>>>>>>>>>>>>>>>
            ////�O���[�v�T�v���X����(���Ǝ�)
            //if(this.CarrierEpCode_TextBox.Text != null)
            //{               
            //    //��ׂ�̂̓L�����A�R�[�h(int)
            //    if(this.CarrierEpCode_TextBox.Text.CompareTo(this._CarrierEpBuff) == 0)
            //    {
            //        this.CarrierEp_TextBox.Visible = false;                 
            //    }
            //    else
            //    {
            //        this.CarrierEp_TextBox.Visible = true;                  
            //        //�o�b�t�@�X�V
            //        this._CarrierEpBuff = this.CarrierEpCode_TextBox.Text;
            //    }
            //}
            //else
            //{
            //    //��O�I�ȏꍇ
            //    //null�̏ꍇ�͋󕶎��ƌ��Ȃ�
            //    if(this._CarrierEpBuff == string.Empty)
            //    {
            //         this.CarrierEp_TextBox.Visible = false;
            //    }
            //    else
            //    {
            //        this.CarrierEp_TextBox.Visible = true;
            //        //�o�b�t�@���󕶎��ōX�V
			//        this._CarrierEpBuff = string.Empty;
            //    }            
            //}
            ////�O���[�v�T�v���X����(���i�啪��)
            //if (this.LgGoosCode_TextBox.Text != null)
            //{
            //    if (this.LgGoosCode_TextBox.Text.CompareTo(this._largeGoodsBuff) == 0)
            //    {
            //        this.LargeGoosGanre_TextBox.Visible = false;
            //    }
            //    else
            //    {
            //        this.LargeGoosGanre_TextBox.Visible = true;
            //        //�o�b�t�@�X�V
            //        this._largeGoodsBuff = this.LgGoosCode_TextBox.Text;
            //    }
            //}
            //else
            //{
            //    //��O�I�ȏꍇ
            //    //null�̏ꍇ�͋󕶎��ƌ��Ȃ�
            //    if (this._largeGoodsBuff == string.Empty)
            //    {
            //        this.LargeGoosGanre_TextBox.Visible = false;
            //    }
            //    else
            //    {
            //        this.LargeGoosGanre_TextBox.Visible = true;
            //        //�o�b�t�@���󕶎��ōX�V
            //        this._largeGoodsBuff = string.Empty;
            //    }
            //}
            //
            ////�O���[�v�T�v���X����(���i������)
            //if (this.MdGoodsCode_TextBox.Text != null)
            //{
            //    if (this.MdGoodsCode_TextBox.Text.CompareTo(this._mediumGoodsBuff) == 0)
            //    {
            //        this.MediumGoodsGanre_TextBox.Visible = false;
            //    }
            //    else
            //    {
            //        this.MediumGoodsGanre_TextBox.Visible = true;
            //        //�o�b�t�@�X�V
            //        this._mediumGoodsBuff = MdGoodsCode_TextBox.Text;
            //    }
            //}
            //else
            //{
            //    //��O�I�ȏꍇ
            //    //null�̏ꍇ�͋󕶎��ƌ��Ȃ�
            //    if (this._mediumGoodsBuff == string.Empty)
            //    {
            //        this.MediumGoodsGanre_TextBox.Visible = false;
            //    }
            //    else
            //    {
            //        this.MediumGoodsGanre_TextBox.Visible = true;
            //        //�o�b�t�@���󕶎��ōX�V
            //        this._mediumGoodsBuff = string.Empty;
            //    }
            //}
            //
            // 2009.02.16 30413 ���� ���g�p�Ȃ̂ō폜 >>>>>>START
            ////�O���[�v�T�v���X����(�I��)
            //if (this.WarehouseShelfNo_TextBox.Text != null)
            //{
            //    //��ׂ�͎̂��Ǝ҃R�[�h(int)
            //    if (this.WarehouseShelfNo_TextBox.Text.CompareTo(this._warehouseShelfNoBuff) == 0)
            //    {
            //        this.WarehouseShelfNo_TextBox.Visible = false;
            //    }
            //    else
            //    {
            //        this.WarehouseShelfNo_TextBox.Visible = true;
            //        //�o�b�t�@�X�V
            //        this._warehouseShelfNoBuff = this.WarehouseShelfNo_TextBox.Text;
            //    }
            //}
            //else
            //{
            //    //��O�I�ȏꍇ
            //    //null�̏ꍇ�͋󕶎��ƌ��Ȃ�
            //    if (this._warehouseShelfNoBuff == string.Empty)
            //    {
            //        this.WarehouseShelfNo_TextBox.Visible = false;
            //    }
            //    else
            //    {
            //        this.WarehouseShelfNo_TextBox.Visible = true;
            //        //�o�b�t�@���󕶎��ōX�V
            //        this._warehouseShelfNoBuff = string.Empty;
            //    }
            //}
            // 2007.09.05 �C�� <<<<<<<<<<<<<<<<<<<<
            // 2009.02.16 30413 ���� ���g�p�Ȃ̂ō폜 <<<<<<END

            // 2009.02.16 30413 ���� �O���[�v�T�v���X�����ǉ� >>>>>>START
            // �o�͏��ŃO���[�v�T�v���X����
            if (this._extrInfo.SortDiv == 0)
            {
                // �q�Ɂ��I��
                this.SetSuppres(this.WarehouseShelfNo_TextBox);
            }
            else if (this._extrInfo.SortDiv == 1)
            {
                // �q�Ɂ��d����
                this.SetSuppres(this.SupplierCd_TextBox);
            }
            else if (this._extrInfo.SortDiv == 2)
            {
                // �q�Ɂ��a�k�R�[�h
                this.SetSuppres(this.BLGoodsCode_TextBox);
            }
            else if (this._extrInfo.SortDiv == 3)
            {
                // �q�Ɂ��O���[�v
                this.SetSuppres(this.BLGroupCode_TextBox);
            }
            else if (this._extrInfo.SortDiv == 4)
            {
                // �q�Ɂ����[�J�[
                this.SetSuppres(this.MakerCode_TextBox);
            }
            else if (this._extrInfo.SortDiv == 5)
            {
                // �q�Ɂ��d���恨�I��
                this.SetSuppres(this.SupplierCd_TextBox);
            }
            else if (this._extrInfo.SortDiv == 6)
            {
                // �q�Ɂ��d���恨���[�J�[
                this.SetSuppres(this.SupplierCd_TextBox);
            }
            // 2009.02.16 30413 ���� �O���[�v�T�v���X�����ǉ� <<<<<<END
        
            // 2008.10.31 30413 ���� ���o�^�v���p�e�B�̂��ߍ폜 >>>>>>START
            //if (this.MakerCode_TextBox.Text != null)
            //{
            //     //�O���[�v�T�v���X����(���[�J�[)
            //    if(this.MakerCode_TextBox.Text.CompareTo(this._makerBuff) == 0)
            //    {
            //        this.Maker_TextBox.Visible = false;
            //    }
            //    else
            //    {
            //        this.Maker_TextBox.Visible = true;
            //        //�o�b�t�@�X�V
            //        this._makerBuff = this.MakerCode_TextBox.Text;
            //    }
            //}
            //else
            //{
            //    //��O�I�ȏꍇ
            //    //null�̏ꍇ�͋󕶎��ƌ��Ȃ�
            //    if(this._makerBuff == string.Empty)
            //    {
            //        this.Maker_TextBox.Visible = false;
            //    }
            //    else
            //    {
            //        this.Maker_TextBox.Visible = true;
            //        //�o�b�t�@���󕶎��ōX�V
            //        this._makerBuff = string.Empty;       
            //    }                                  
            //}
            // 2008.10.31 30413 ���� ���o�^�v���p�e�B�̂��ߍ폜 <<<<<<END
        }

        /// <summary>
        /// �O���[�v�T�v���X�ݒ菈��
        /// </summary>
        /// <remarks>
        /// <br>Note      : �O���[�v�T�v���X�̃`�F�b�N�Ɛݒ���s���܂��B</br>
        /// <br>Programer : 30413 ����</br>
        /// <br>Date      : 2009.02.16</br>
        /// </remarks>    
        private void SetSuppres(TextBox textBox)
        {
            if (textBox.Text != null)
            {
                // �o�b�t�@�Ɣ�r
                //if (textBox.Text.CompareTo(this._groupSuppres) == 0)
                if (textBox.Text.CompareTo(this._groupSuppres) == 0
                    && (WarehouseCode_TextBox.Text.CompareTo(_groupSuppresWarehouseShelfNo)) == 0) // ADD 2009/12/17
                {
                    textBox.Visible = false;
                }
                else
                {
                    textBox.Visible = true;
                    //�o�b�t�@�X�V
                    this._groupSuppres = textBox.Text;
                    this._groupSuppresWarehouseShelfNo = WarehouseCode_TextBox.Text;// ADD 2009/12/17
                }
            }
            else
            {
                //��O�I�ȏꍇ
                //null�̏ꍇ�͋󕶎��ƌ��Ȃ�
                if (this._groupSuppres == string.Empty)
                {
                    textBox.Visible = false;
                }
                else
                {
                    textBox.Visible = true;
                    //�o�b�t�@���󕶎��ōX�V
                    this._groupSuppres = string.Empty;
                }
            }
        }
        #endregion

		#endregion

        #region Event

        #region Detail_BeforePrint�C�x���g
        /// <summary>
		/// Detail_BeforePrint�C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="eArgs">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note       : Detail�Z�N�V�����̈���O�ɔ�������C�x���g�ł��B</br>
		/// <br>Programmer : 23010�@�����@�m</br>
		/// <br>Date       : 2007.04.10</br>
		/// </remarks>
		private void Detail_BeforePrint(object sender, System.EventArgs eArgs)
		{
            // 2009.02.16 30413 ���� �O���[�v�T�v���X������ǉ� >>>>>>START
            // 2008.02.13 �폜 >>>>>>>>>>>>>>>>>>>>
            ////�O���[�v�T�v���X����
            SetOfGroupSuppres();
            // 2008.02.13 �폜 <<<<<<<<<<<<<<<<<<<<
            // 2009.02.16 30413 ���� �O���[�v�T�v���X������ǉ� <<<<<<END
            // Wordrap�v���p�e�B�ŕ��������r���[�ȂƂ���ŋ�؂��Ȃ��悤�ɂ��邽�߂̑Ή�
			PrintCommonLibrary.ConvertReportString(this.Detail);

        }

        #endregion

        #region MAZAI02112P_01A4C_PageEnd�C�x���g
        /// <summary>
		/// MAZAI02112P_01A4C_PageEnd�C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="eArgs">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note       : �P�y�[�W�̏o�͂��I�������Ƃ��ɔ�������C�x���g�ł��B</br>
		/// <br>Programmer : 23010�@�����@�m</br>
		/// <br>Date       : 2007.04.10</br>
		/// </remarks>
		private void MAZAI02112P_01A4C_PageEnd(object sender, System.EventArgs eArgs)
		{
		    //�o�b�t�@�N���A
			BufferClear();
        }

        #endregion

        #region ExtraHeader_Format�C�x���g
        /// <summary>
		/// ExtraHeader_Format�C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="eArgs">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note       : ExtraHeader�O���[�v�̏������C�x���g�ł��B</br>
		/// <br>Programmer : 23010�@�����@�m</br>
		/// <br>Date       : 2007.04.10</br>
		/// </remarks>
		private void ExtraHeader_Format(object sender, System.EventArgs eArgs)
		{			
			// �w�b�_�o�͐���
			if (this._extraCondHeadOutDiv == 0)
			{
				// ���y�[�W�o��
				this.ExtraHeader.RepeatStyle = RepeatStyle.OnPageIncludeNoDetail;
			} 
			else 
			{
				// �擪�y�[�W�̂�
				this.ExtraHeader.RepeatStyle = RepeatStyle.None;
			}
			

			if ( this._rptExtraHeader == null )
			{
				this._rptExtraHeader = new ListCommon_ExtraHeader();
			}
			else
			{
				this._rptExtraHeader.DataSource = null;
			}

            // 2007.09.05 �C�� >>>>>>>>>>>>>>>>>>>>
            //// ���_�I�v�V�����L������
            //if (this._extrInfo.IsOptSection)
            //{
            //    
            //    this._rptExtraHeader.SectionCondition.Text = "�I�����_�F " + this.StockSectionName.Text;
            //    
            //} 
            //else 
            //{
            //    this._rptExtraHeader.SectionCondition.Text = "";
            //}
            // 2008.02.13 �C�� >>>>>>>>>>>>>>>>>>>>
            //this._rptExtraHeader.SectionCondition.Text = "�I�����_�F " + this.StockSectionName.Text;
            //this._rptExtraHeader.SectionCondition.Text = "�I�����_�F " + this.StockSectionCode.Text + " " + this.StockSectionName.Text;
            // 2008.02.13 �C�� <<<<<<<<<<<<<<<<<<<<
            // 2007.09.05 �C�� <<<<<<<<<<<<<<<<<<<<

			// ���o�����󎚍��ڐݒ�
			this._rptExtraHeader.ExtraConditions = this._extraConditions;

			this.Header_SubReport.Report = this._rptExtraHeader;
        }

        #endregion

        #region PageFooter_Format�C�x���g
        /// <summary>
		/// PageFooter_Format�C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="eArgs">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note       : PageFooter_Format�O���[�v�̏������C�x���g�ł��B</br>
		/// <br>Programmer : 23010�@�����@�m</br>
		/// <br>Date       : 2007.04.10</br>
		/// </remarks>
		private void PageFooter_Format(object sender, System.EventArgs eArgs)
		{
            // 2009.03.18 30413 ���� �t�b�^�[���̈󎚕ύX >>>>>>START
            //// �t�b�^�[�o�͂���H
            //if (this._pageFooterOutCode == 0)
            //{
            //    // �C���X�^���X���쐬����Ă��Ȃ���΍쐬
            //    if (this._rptPageFooter == null)
            //    {
            //        this._rptPageFooter = new ListCommon_PageFooter();
            //    }
            //    else
            //    {
            //        // �C���X�^���X���쐬����Ă���΁A�f�[�^�\�[�X������������
            //        // (�o�C���h����f�[�^�\�[�X�������f�[�^�ł����Ă��A��x���������Ă����Ȃ��Ƃ��܂��������Ȃ��B
            //        this._rptPageFooter.DataSource = null;
            //    }

            //    // �t�b�^�[�󎚍��ڐݒ�
            //    if (this._pageFooters[0] != null)
            //    {
            //        this._rptPageFooter.PrintFooter1 = this._pageFooters[0];
            //    }
            //    if (this._pageFooters[1] != null)
            //    {
            //        this._rptPageFooter.PrintFooter2 = this._pageFooters[1];
            //    }

            //    this.Footer_SubReport.Report = this._rptPageFooter;
            //}
            // �t�b�^�[�o�͂���H
            if (this._pageFooterOutCode == 0)
            {
                // �t�b�^�[�r���󎚐ݒ�
                Line_PageFooter.Visible = true;

                // �t�b�^�[�󎚍��ڐݒ�
                if (this._pageFooters[0] != null)
                {
                    PageFooters0.Visible = true;
                    PageFooters0.Text = this._pageFooters[0];
                }
                if (this._pageFooters[1] != null)
                {
                    PageFooters1.Visible = true;
                    PageFooters1.Value = this._pageFooters[1];
                }
            }
            else
            {
                // �t�b�^�[�r���󎚐ݒ�
                Line_PageFooter.Visible = false;

                PageFooters0.Visible = false;
                PageFooters1.Visible = false;
            }
            // 2009.03.18 30413 ���� �t�b�^�[���̈󎚕ύX <<<<<<END
        }

        #endregion

        #region MAZAI02112P_01A4C_ReportStart�C�x���g
        /// <summary>
		/// MAZAI02112P_01A4C_ReportStart�C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="eArgs">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note       : MAZAI02112P_01A4C_ReportStart�̏������C�x���g�ł��B</br>
		/// <br>Programmer : 23010�@�����@�m</br>
		/// <br>Date       : 2007.04.10</br>
		/// </remarks>
		private void MAZAI02112P_01A4C_ReportStart(object sender, System.EventArgs eArgs)
		{
			// ���|�[�g�v�f�o�͐ݒ�
			SetOfReportMembersOutput();

            // �󎚃p�^�[���ύX
            SetOutputPrintPattern();
        }

        #endregion

        #region PageHeader_Format�C�x���g
        /// <summary>
		/// PageHeader_Format�C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="eArgs">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note       : �y�[�W�w�b�_�[�O���[�v�̏������C�x���g�ł��B</br>
		/// <br>Programmer : 23010�@�����@�m</br>
		/// <br>Date       : 2007.04.10</br>
		/// </remarks>
		private void PageHeader_Format(object sender, System.EventArgs eArgs)
		{
			// �쐬���t           
            //���݂̎������擾
			DateTime now = DateTime.Now;
            //�쐬��(����ŕ\��)
            this.PrintDate.Text = TDateTime.DateTimeToString("YYYY/MM/DD", now);			
			// �쐬����
			this.PrintTime.Text   = now.ToString("HH:mm");
        }

        #endregion

        #region Detail_AfterPrint�C�x���g
        /// <summary>
		/// ���׃A�t�^�[�v�����g�C�x���g
		/// </summary>
		/// <param name="sender">�C�x���g�\�[�X</param>
		/// <param name="eArgs">�C�x���g�f�[�^</param>
		/// <remarks>
		/// <br>Note        : �Z�N�V�������y�[�W�ɕ`�悳�ꂽ��ɔ������܂��B</br>
		/// <br>Programmer  : 23010�@�����@�m</br>
		/// <br>Date        : 2007.04.10</br>
		/// </remarks>
		private void Detail_AfterPrint(object sender, System.EventArgs eArgs)
		{
			// ��������J�E���g�A�b�v
			this._printCount++;
			
			if (this.ProgressBarUpEvent != null)
			{
				this.ProgressBarUpEvent(this, this._printCount);
			}
        }

        #endregion

        #region GoodsFooter_AfterPrint�C�x���g
        /// <summary>
		/// GoodsFooter_AfterPrint�C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="eArgs">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note       : GoodsFooter�Z�N�V�����̈����ɔ�������C�x���g�ł��B</br>
		/// <br>Programmer : 23010�@�����@�m</br>
		/// <br>Date       : 2007.04.10</br>
		/// </remarks>
		private void GoodsFooter_AfterPrint(object sender, System.EventArgs eArgs)
		{
			//�o�b�t�@���N���A
			BufferClear();
		}
        #endregion

        // 2007.09.05 �폜 >>>>>>>>>>>>>>>>>>>>
        //#region CellphoneModelFooter_AfterPrint�C�x���g
        ///// <summary>
		///// CellphoneModelFooter_AfterPrint�C�x���g
		///// </summary>
		///// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		///// <param name="eArgs">�C�x���g�p�����[�^</param>
		///// <remarks>
		///// <br>Note       : CellphoneModelFooter_AfterPrint�Z�N�V�����̈����ɔ�������C�x���g�ł��B</br>
		///// <br>Programmer : 23010�@�����@�m</br>
		///// <br>Date       : 2007.04.10</br>
		///// </remarks>
		//private void CellphoneModelFooter_AfterPrint(object sender, System.EventArgs eArgs)
		//{
		//	//�o�b�t�@���N���A
		//	BufferClear();
		//}
        //#endregion
        // 2007.09.05 �폜 <<<<<<<<<<<<<<<<<<<<

        #region MakerFooter_AfterPrint�C�x���g
        /// <summary>
		/// MakerFooter_AfterPrint�C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="eArgs">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note       : MakerFooter�Z�N�V�����̈����ɔ�������C�x���g�ł��B</br>
		/// <br>Programmer : 23010�@�����@�m</br>
		/// <br>Date       : 2007.04.10</br>
		/// </remarks>
		private void MakerFooter_AfterPrint(object sender, System.EventArgs eArgs)
		{
			//�o�b�t�@���N���A
			BufferClear();
		}

        #endregion

        #region WarehouseFooter_AfterPrint�C�x���g
        /// <summary>
		/// WarehouseFooter_AfterPrint�C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="eArgs">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note       : WarehouseFooter�Z�N�V�����̈����ɔ�������C�x���g�ł��B</br>
		/// <br>Programmer : 23010�@�����@�m</br>
		/// <br>Date       : 2007.04.16</br>
        /// </remarks>
		private void WarehouseFooter_AfterPrint(object sender, System.EventArgs eArgs)
		{
			//�o�b�t�@���N���A
			BufferClear();
		}

        #endregion

        #endregion
        
		#region ActiveReports Designer generated code
		private DataDynamics.ActiveReports.PageHeader PageHeader;
		private DataDynamics.ActiveReports.Label Label1;
		private DataDynamics.ActiveReports.Label Label3;
		private DataDynamics.ActiveReports.TextBox PrintDate;
		private DataDynamics.ActiveReports.Label Label2;
		private DataDynamics.ActiveReports.TextBox PRINTPAGE;
		private DataDynamics.ActiveReports.Line Line1;
		private DataDynamics.ActiveReports.TextBox SortTitle;
		private DataDynamics.ActiveReports.TextBox PrintTime;
		private DataDynamics.ActiveReports.GroupHeader ExtraHeader;
		private DataDynamics.ActiveReports.SubReport Header_SubReport;
        private DataDynamics.ActiveReports.GroupHeader TitleHeader;
        private DataDynamics.ActiveReports.Label GoodsNo_Title;
		private DataDynamics.ActiveReports.Line Line4;
        private DataDynamics.ActiveReports.Label StockUnitPrice_Title;
		private DataDynamics.ActiveReports.Label GoodsName_Title;
        private DataDynamics.ActiveReports.Label StockCount_Title;
		private DataDynamics.ActiveReports.Label WarehouseShelfNo_Title;
		private DataDynamics.ActiveReports.Label InventStockCount_Title;
		private DataDynamics.ActiveReports.Label InventorySeqNo_Title;
		private DataDynamics.ActiveReports.GroupHeader GrandTotalHeader;
		private DataDynamics.ActiveReports.GroupHeader SectionHeader;
		private DataDynamics.ActiveReports.TextBox StockSectionName;
		private DataDynamics.ActiveReports.GroupHeader WarehouseHeader;
		private DataDynamics.ActiveReports.GroupHeader MakerHeader;
		private DataDynamics.ActiveReports.GroupHeader GoodsHeader;
		private DataDynamics.ActiveReports.Detail Detail;
		private DataDynamics.ActiveReports.TextBox StockCount_TextBox;
        private DataDynamics.ActiveReports.Line Line37;
        private DataDynamics.ActiveReports.TextBox GoodsName_TextBox;
        private DataDynamics.ActiveReports.TextBox StockUnitPrice_TextBox;
		private DataDynamics.ActiveReports.TextBox GoodsNo_TextBox;
		private DataDynamics.ActiveReports.TextBox Warehouse_TextBox;
        private DataDynamics.ActiveReports.TextBox WarehouseShelfNo_TextBox;
        private DataDynamics.ActiveReports.TextBox WarehouseCode_TextBox;
		private DataDynamics.ActiveReports.GroupFooter GoodsFooter;
		private DataDynamics.ActiveReports.Line Line44;
		private DataDynamics.ActiveReports.TextBox GoodsTotal_Title;
		private DataDynamics.ActiveReports.TextBox GoosTotal_TextBox;
		private DataDynamics.ActiveReports.GroupFooter MakerFooter;
		private DataDynamics.ActiveReports.Line Line5;
		private DataDynamics.ActiveReports.TextBox MakerTotal_Title;
		private DataDynamics.ActiveReports.TextBox MakerTotal_TextBox;
		private DataDynamics.ActiveReports.GroupFooter WarehouseFooter;
		private DataDynamics.ActiveReports.TextBox WareStockCount_TextBox;
		private DataDynamics.ActiveReports.Line Line2;
		private DataDynamics.ActiveReports.TextBox WarehouseTotal_Title;
		private DataDynamics.ActiveReports.GroupFooter SectionFooter;
		private DataDynamics.ActiveReports.GroupFooter GrandTotalFooter;
		private DataDynamics.ActiveReports.Label GrandTotal_Title;
		private DataDynamics.ActiveReports.Line Line;
		private DataDynamics.ActiveReports.TextBox GrandStockCount_TextBox;
		private DataDynamics.ActiveReports.GroupFooter TitleFooter;
		private DataDynamics.ActiveReports.Line Line41;
		private DataDynamics.ActiveReports.GroupFooter ExtraFooter;
        private DataDynamics.ActiveReports.PageFooter PageFooter;
		public void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MAZAI02112P_01A4C));
            this.Detail = new DataDynamics.ActiveReports.Detail();
            this.StockCount_TextBox = new DataDynamics.ActiveReports.TextBox();
            this.Line37 = new DataDynamics.ActiveReports.Line();
            this.GoodsName_TextBox = new DataDynamics.ActiveReports.TextBox();
            this.StockUnitPrice_TextBox = new DataDynamics.ActiveReports.TextBox();
            this.GoodsNo_TextBox = new DataDynamics.ActiveReports.TextBox();
            this.WarehouseShelfNo_TextBox = new DataDynamics.ActiveReports.TextBox();
            this.InventStockCount_TextBox = new DataDynamics.ActiveReports.TextBox();
            this.MakerCode_TextBox = new DataDynamics.ActiveReports.TextBox();
            this.SupplierCd_TextBox = new DataDynamics.ActiveReports.TextBox();
            this.BLGoodsCode_TextBox = new DataDynamics.ActiveReports.TextBox();
            this.BLGroupCode_TextBox = new DataDynamics.ActiveReports.TextBox();
            this.InventorySeqNo_TextBox = new DataDynamics.ActiveReports.TextBox();
            this.textBox1 = new DataDynamics.ActiveReports.TextBox();
            this.textBox2 = new DataDynamics.ActiveReports.TextBox();
            this.BlankShowFlag = new DataDynamics.ActiveReports.TextBox();
            this.InvStockCntFlag = new DataDynamics.ActiveReports.TextBox();
            this.Warehouse_TextBox = new DataDynamics.ActiveReports.TextBox();
            this.WarehouseCode_TextBox = new DataDynamics.ActiveReports.TextBox();
            this.PageHeader = new DataDynamics.ActiveReports.PageHeader();
            this.Label1 = new DataDynamics.ActiveReports.Label();
            this.Label3 = new DataDynamics.ActiveReports.Label();
            this.PrintDate = new DataDynamics.ActiveReports.TextBox();
            this.Label2 = new DataDynamics.ActiveReports.Label();
            this.PRINTPAGE = new DataDynamics.ActiveReports.TextBox();
            this.Line1 = new DataDynamics.ActiveReports.Line();
            this.SortTitle = new DataDynamics.ActiveReports.TextBox();
            this.PrintTime = new DataDynamics.ActiveReports.TextBox();
            this.PageFooter = new DataDynamics.ActiveReports.PageFooter();
            this.Line_PageFooter = new DataDynamics.ActiveReports.Line();
            this.PageFooters0 = new DataDynamics.ActiveReports.TextBox();
            this.PageFooters1 = new DataDynamics.ActiveReports.TextBox();
            this.ExtraHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.Header_SubReport = new DataDynamics.ActiveReports.SubReport();
            this.ExtraFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.TitleHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.GoodsNo_Title = new DataDynamics.ActiveReports.Label();
            this.Line4 = new DataDynamics.ActiveReports.Line();
            this.StockUnitPrice_Title = new DataDynamics.ActiveReports.Label();
            this.GoodsName_Title = new DataDynamics.ActiveReports.Label();
            this.StockCount_Title = new DataDynamics.ActiveReports.Label();
            this.WarehouseShelfNo_Title = new DataDynamics.ActiveReports.Label();
            this.InventStockCount_Title = new DataDynamics.ActiveReports.Label();
            this.InventorySeqNo_Title = new DataDynamics.ActiveReports.Label();
            this.Maker_Title = new DataDynamics.ActiveReports.Label();
            this.SupplierCd_Title = new DataDynamics.ActiveReports.Label();
            this.BLGoodsCode_Title = new DataDynamics.ActiveReports.Label();
            this.BLGroupCode_Title = new DataDynamics.ActiveReports.Label();
            this.line6 = new DataDynamics.ActiveReports.Line();
            this.TitleFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.Line41 = new DataDynamics.ActiveReports.Line();
            this.GrandTotalHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.GrandTotalFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.GrandTotal_Title = new DataDynamics.ActiveReports.Label();
            this.Line = new DataDynamics.ActiveReports.Line();
            this.GrandStockCount_TextBox = new DataDynamics.ActiveReports.TextBox();
            this.textBox4 = new DataDynamics.ActiveReports.TextBox();
            this.GrandInventStockCount_TextBox = new DataDynamics.ActiveReports.TextBox();
            this.textBox8 = new DataDynamics.ActiveReports.TextBox();
            this.SectionHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.StockSectionName = new DataDynamics.ActiveReports.TextBox();
            this.StockSectionCode = new DataDynamics.ActiveReports.TextBox();
            this.SectionFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.WarehouseHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.line3 = new DataDynamics.ActiveReports.Line();
            this.WarehouseFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.WareStockCount_TextBox = new DataDynamics.ActiveReports.TextBox();
            this.Line2 = new DataDynamics.ActiveReports.Line();
            this.WarehouseTotal_Title = new DataDynamics.ActiveReports.TextBox();
            this.WareInventStockCount_TextBox = new DataDynamics.ActiveReports.TextBox();
            this.textBox5 = new DataDynamics.ActiveReports.TextBox();
            this.textBox6 = new DataDynamics.ActiveReports.TextBox();
            this.MakerHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.MakerFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.Line5 = new DataDynamics.ActiveReports.Line();
            this.MakerTotal_Title = new DataDynamics.ActiveReports.TextBox();
            this.MakerTotal_TextBox = new DataDynamics.ActiveReports.TextBox();
            this.GoodsHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.GoodsFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.Line44 = new DataDynamics.ActiveReports.Line();
            this.GoodsTotal_Title = new DataDynamics.ActiveReports.TextBox();
            this.GoosTotal_TextBox = new DataDynamics.ActiveReports.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.StockCount_TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsName_TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StockUnitPrice_TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsNo_TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WarehouseShelfNo_TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.InventStockCount_TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MakerCode_TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupplierCd_TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BLGoodsCode_TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BLGroupCode_TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.InventorySeqNo_TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BlankShowFlag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.InvStockCntFlag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Warehouse_TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WarehouseCode_TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PrintDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PRINTPAGE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SortTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PrintTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PageFooters0)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PageFooters1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsNo_Title)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StockUnitPrice_Title)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsName_Title)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StockCount_Title)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WarehouseShelfNo_Title)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.InventStockCount_Title)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.InventorySeqNo_Title)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Maker_Title)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupplierCd_Title)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BLGoodsCode_Title)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BLGroupCode_Title)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrandTotal_Title)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrandStockCount_TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrandInventStockCount_TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StockSectionName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StockSectionCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WareStockCount_TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WarehouseTotal_Title)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WareInventStockCount_TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MakerTotal_Title)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MakerTotal_TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsTotal_Title)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoosTotal_TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.CanShrink = true;
            this.Detail.ColumnSpacing = 0F;
            this.Detail.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.StockCount_TextBox,
            this.Line37,
            this.GoodsName_TextBox,
            this.StockUnitPrice_TextBox,
            this.GoodsNo_TextBox,
            this.WarehouseShelfNo_TextBox,
            this.InventStockCount_TextBox,
            this.MakerCode_TextBox,
            this.SupplierCd_TextBox,
            this.BLGoodsCode_TextBox,
            this.BLGroupCode_TextBox,
            this.InventorySeqNo_TextBox,
            this.textBox1,
            this.textBox2,
            this.BlankShowFlag,
            this.InvStockCntFlag});
            this.Detail.Height = 0.4375F;
            this.Detail.KeepTogether = true;
            this.Detail.Name = "Detail";
            this.Detail.Format += new System.EventHandler(this.Detail_Format);
            this.Detail.AfterPrint += new System.EventHandler(this.Detail_AfterPrint);
            this.Detail.BeforePrint += new System.EventHandler(this.Detail_BeforePrint);
            // 
            // StockCount_TextBox
            // 
            this.StockCount_TextBox.Border.BottomColor = System.Drawing.Color.Black;
            this.StockCount_TextBox.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockCount_TextBox.Border.LeftColor = System.Drawing.Color.Black;
            this.StockCount_TextBox.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockCount_TextBox.Border.RightColor = System.Drawing.Color.Black;
            this.StockCount_TextBox.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockCount_TextBox.Border.TopColor = System.Drawing.Color.Black;
            this.StockCount_TextBox.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockCount_TextBox.DataField = "StockTotal";
            this.StockCount_TextBox.Height = 0.125F;
            this.StockCount_TextBox.Left = 3.96875F;
            this.StockCount_TextBox.MultiLine = false;
            this.StockCount_TextBox.Name = "StockCount_TextBox";
            this.StockCount_TextBox.OutputFormat = resources.GetString("StockCount_TextBox.OutputFormat");
            this.StockCount_TextBox.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: �l�r �S�V�b�N; verti" +
                "cal-align: top; ";
            this.StockCount_TextBox.Text = "123,456.99";
            this.StockCount_TextBox.Top = 0F;
            this.StockCount_TextBox.Width = 0.6F;
            // 
            // Line37
            // 
            this.Line37.Border.BottomColor = System.Drawing.Color.Black;
            this.Line37.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line37.Border.LeftColor = System.Drawing.Color.Black;
            this.Line37.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line37.Border.RightColor = System.Drawing.Color.Black;
            this.Line37.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line37.Border.TopColor = System.Drawing.Color.Black;
            this.Line37.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line37.Height = 0F;
            this.Line37.Left = 0F;
            this.Line37.LineWeight = 1F;
            this.Line37.Name = "Line37";
            this.Line37.Top = 0F;
            this.Line37.Width = 7.677F;
            this.Line37.X1 = 0F;
            this.Line37.X2 = 7.677F;
            this.Line37.Y1 = 0F;
            this.Line37.Y2 = 0F;
            // 
            // GoodsName_TextBox
            // 
            this.GoodsName_TextBox.Border.BottomColor = System.Drawing.Color.Black;
            this.GoodsName_TextBox.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsName_TextBox.Border.LeftColor = System.Drawing.Color.Black;
            this.GoodsName_TextBox.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsName_TextBox.Border.RightColor = System.Drawing.Color.Black;
            this.GoodsName_TextBox.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsName_TextBox.Border.TopColor = System.Drawing.Color.Black;
            this.GoodsName_TextBox.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsName_TextBox.DataField = "GoodsName";
            this.GoodsName_TextBox.Height = 0.125F;
            this.GoodsName_TextBox.Left = 2.885417F;
            this.GoodsName_TextBox.MultiLine = false;
            this.GoodsName_TextBox.Name = "GoodsName_TextBox";
            this.GoodsName_TextBox.OutputFormat = resources.GetString("GoodsName_TextBox.OutputFormat");
            this.GoodsName_TextBox.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: �l�r ����; vertical" +
                "-align: top; ";
            this.GoodsName_TextBox.Text = "��������������������";
            this.GoodsName_TextBox.Top = 0F;
            this.GoodsName_TextBox.Width = 1.14F;
            // 
            // StockUnitPrice_TextBox
            // 
            this.StockUnitPrice_TextBox.Border.BottomColor = System.Drawing.Color.Black;
            this.StockUnitPrice_TextBox.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockUnitPrice_TextBox.Border.LeftColor = System.Drawing.Color.Black;
            this.StockUnitPrice_TextBox.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockUnitPrice_TextBox.Border.RightColor = System.Drawing.Color.Black;
            this.StockUnitPrice_TextBox.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockUnitPrice_TextBox.Border.TopColor = System.Drawing.Color.Black;
            this.StockUnitPrice_TextBox.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockUnitPrice_TextBox.DataField = "StockUnitPriceFl";
            this.StockUnitPrice_TextBox.Height = 0.125F;
            this.StockUnitPrice_TextBox.Left = 5.177083F;
            this.StockUnitPrice_TextBox.MultiLine = false;
            this.StockUnitPrice_TextBox.Name = "StockUnitPrice_TextBox";
            this.StockUnitPrice_TextBox.OutputFormat = resources.GetString("StockUnitPrice_TextBox.OutputFormat");
            this.StockUnitPrice_TextBox.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: �l�r �S�V�b�N; verti" +
                "cal-align: top; ";
            this.StockUnitPrice_TextBox.Text = "1,234,567.00";
            this.StockUnitPrice_TextBox.Top = 0F;
            this.StockUnitPrice_TextBox.Width = 0.7F;
            // 
            // GoodsNo_TextBox
            // 
            this.GoodsNo_TextBox.Border.BottomColor = System.Drawing.Color.Black;
            this.GoodsNo_TextBox.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsNo_TextBox.Border.LeftColor = System.Drawing.Color.Black;
            this.GoodsNo_TextBox.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsNo_TextBox.Border.RightColor = System.Drawing.Color.Black;
            this.GoodsNo_TextBox.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsNo_TextBox.Border.TopColor = System.Drawing.Color.Black;
            this.GoodsNo_TextBox.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsNo_TextBox.DataField = "GoodsNo";
            this.GoodsNo_TextBox.Height = 0.25F;
            this.GoodsNo_TextBox.Left = 0.625F;
            this.GoodsNo_TextBox.MultiLine = false;
            this.GoodsNo_TextBox.Name = "GoodsNo_TextBox";
            this.GoodsNo_TextBox.OutputFormat = resources.GetString("GoodsNo_TextBox.OutputFormat");
            this.GoodsNo_TextBox.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 13pt; font-fam" +
                "ily: �l�r ����; vertical-align: top; ";
            this.GoodsNo_TextBox.Text = "1234567890123456789012345";
            this.GoodsNo_TextBox.Top = 0F;
            this.GoodsNo_TextBox.Width = 2.29F;
            // 
            // WarehouseShelfNo_TextBox
            // 
            this.WarehouseShelfNo_TextBox.Border.BottomColor = System.Drawing.Color.Black;
            this.WarehouseShelfNo_TextBox.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WarehouseShelfNo_TextBox.Border.LeftColor = System.Drawing.Color.Black;
            this.WarehouseShelfNo_TextBox.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WarehouseShelfNo_TextBox.Border.RightColor = System.Drawing.Color.Black;
            this.WarehouseShelfNo_TextBox.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WarehouseShelfNo_TextBox.Border.TopColor = System.Drawing.Color.Black;
            this.WarehouseShelfNo_TextBox.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WarehouseShelfNo_TextBox.DataField = "WarehouseShelfNo";
            this.WarehouseShelfNo_TextBox.Height = 0.1875F;
            this.WarehouseShelfNo_TextBox.Left = 0F;
            this.WarehouseShelfNo_TextBox.MultiLine = false;
            this.WarehouseShelfNo_TextBox.Name = "WarehouseShelfNo_TextBox";
            this.WarehouseShelfNo_TextBox.OutputFormat = resources.GetString("WarehouseShelfNo_TextBox.OutputFormat");
            this.WarehouseShelfNo_TextBox.Style = "ddo-char-set: 128; text-align: left; font-size: 10.8pt; font-family: �l�r ����; verti" +
                "cal-align: top; ";
            this.WarehouseShelfNo_TextBox.Text = "XXXXXXXX";
            this.WarehouseShelfNo_TextBox.Top = 0F;
            this.WarehouseShelfNo_TextBox.Width = 0.628F;
            // 
            // InventStockCount_TextBox
            // 
            this.InventStockCount_TextBox.Border.BottomColor = System.Drawing.Color.Black;
            this.InventStockCount_TextBox.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.InventStockCount_TextBox.Border.LeftColor = System.Drawing.Color.Black;
            this.InventStockCount_TextBox.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.InventStockCount_TextBox.Border.RightColor = System.Drawing.Color.Black;
            this.InventStockCount_TextBox.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.InventStockCount_TextBox.Border.TopColor = System.Drawing.Color.Black;
            this.InventStockCount_TextBox.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.InventStockCount_TextBox.DataField = "InventoryStockCnt";
            this.InventStockCount_TextBox.Height = 0.125F;
            this.InventStockCount_TextBox.Left = 4.5625F;
            this.InventStockCount_TextBox.MultiLine = false;
            this.InventStockCount_TextBox.Name = "InventStockCount_TextBox";
            this.InventStockCount_TextBox.OutputFormat = resources.GetString("InventStockCount_TextBox.OutputFormat");
            this.InventStockCount_TextBox.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: �l�r �S�V�b�N; verti" +
                "cal-align: top; ";
            this.InventStockCount_TextBox.Text = "123,456.99";
            this.InventStockCount_TextBox.Top = 0F;
            this.InventStockCount_TextBox.Width = 0.6F;
            // 
            // MakerCode_TextBox
            // 
            this.MakerCode_TextBox.Border.BottomColor = System.Drawing.Color.Black;
            this.MakerCode_TextBox.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakerCode_TextBox.Border.LeftColor = System.Drawing.Color.Black;
            this.MakerCode_TextBox.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakerCode_TextBox.Border.RightColor = System.Drawing.Color.Black;
            this.MakerCode_TextBox.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakerCode_TextBox.Border.TopColor = System.Drawing.Color.Black;
            this.MakerCode_TextBox.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakerCode_TextBox.DataField = "MakerCode_Print";
            this.MakerCode_TextBox.Height = 0.125F;
            this.MakerCode_TextBox.Left = 6.93875F;
            this.MakerCode_TextBox.MultiLine = false;
            this.MakerCode_TextBox.Name = "MakerCode_TextBox";
            this.MakerCode_TextBox.OutputFormat = resources.GetString("MakerCode_TextBox.OutputFormat");
            this.MakerCode_TextBox.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: �l�r �S�V�b�N; vertic" +
                "al-align: top; ";
            this.MakerCode_TextBox.Text = "1234";
            this.MakerCode_TextBox.Top = 0F;
            this.MakerCode_TextBox.Width = 0.253F;
            // 
            // SupplierCd_TextBox
            // 
            this.SupplierCd_TextBox.Border.BottomColor = System.Drawing.Color.Black;
            this.SupplierCd_TextBox.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupplierCd_TextBox.Border.LeftColor = System.Drawing.Color.Black;
            this.SupplierCd_TextBox.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupplierCd_TextBox.Border.RightColor = System.Drawing.Color.Black;
            this.SupplierCd_TextBox.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupplierCd_TextBox.Border.TopColor = System.Drawing.Color.Black;
            this.SupplierCd_TextBox.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupplierCd_TextBox.DataField = "SupplierCd_Print";
            this.SupplierCd_TextBox.Height = 0.125F;
            this.SupplierCd_TextBox.Left = 5.900833F;
            this.SupplierCd_TextBox.MultiLine = false;
            this.SupplierCd_TextBox.Name = "SupplierCd_TextBox";
            this.SupplierCd_TextBox.OutputFormat = resources.GetString("SupplierCd_TextBox.OutputFormat");
            this.SupplierCd_TextBox.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: �l�r �S�V�b�N; vertic" +
                "al-align: top; ";
            this.SupplierCd_TextBox.Text = "123456";
            this.SupplierCd_TextBox.Top = 0F;
            this.SupplierCd_TextBox.Width = 0.363F;
            // 
            // BLGoodsCode_TextBox
            // 
            this.BLGoodsCode_TextBox.Border.BottomColor = System.Drawing.Color.Black;
            this.BLGoodsCode_TextBox.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BLGoodsCode_TextBox.Border.LeftColor = System.Drawing.Color.Black;
            this.BLGoodsCode_TextBox.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BLGoodsCode_TextBox.Border.RightColor = System.Drawing.Color.Black;
            this.BLGoodsCode_TextBox.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BLGoodsCode_TextBox.Border.TopColor = System.Drawing.Color.Black;
            this.BLGoodsCode_TextBox.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BLGoodsCode_TextBox.DataField = "BLGoodsCode_Print";
            this.BLGoodsCode_TextBox.Height = 0.125F;
            this.BLGoodsCode_TextBox.Left = 6.28875F;
            this.BLGoodsCode_TextBox.MultiLine = false;
            this.BLGoodsCode_TextBox.Name = "BLGoodsCode_TextBox";
            this.BLGoodsCode_TextBox.OutputFormat = resources.GetString("BLGoodsCode_TextBox.OutputFormat");
            this.BLGoodsCode_TextBox.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: �l�r �S�V�b�N; vertic" +
                "al-align: top; ";
            this.BLGoodsCode_TextBox.Text = "12345";
            this.BLGoodsCode_TextBox.Top = 0F;
            this.BLGoodsCode_TextBox.Width = 0.363F;
            // 
            // BLGroupCode_TextBox
            // 
            this.BLGroupCode_TextBox.Border.BottomColor = System.Drawing.Color.Black;
            this.BLGroupCode_TextBox.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BLGroupCode_TextBox.Border.LeftColor = System.Drawing.Color.Black;
            this.BLGroupCode_TextBox.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BLGroupCode_TextBox.Border.RightColor = System.Drawing.Color.Black;
            this.BLGroupCode_TextBox.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BLGroupCode_TextBox.Border.TopColor = System.Drawing.Color.Black;
            this.BLGroupCode_TextBox.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BLGroupCode_TextBox.DataField = "BLGroupCode_Print";
            this.BLGroupCode_TextBox.Height = 0.125F;
            this.BLGroupCode_TextBox.Left = 6.61075F;
            this.BLGroupCode_TextBox.MultiLine = false;
            this.BLGroupCode_TextBox.Name = "BLGroupCode_TextBox";
            this.BLGroupCode_TextBox.OutputFormat = resources.GetString("BLGroupCode_TextBox.OutputFormat");
            this.BLGroupCode_TextBox.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: �l�r �S�V�b�N; vertic" +
                "al-align: top; ";
            this.BLGroupCode_TextBox.Text = "12345";
            this.BLGroupCode_TextBox.Top = 0F;
            this.BLGroupCode_TextBox.Width = 0.363F;
            // 
            // InventorySeqNo_TextBox
            // 
            this.InventorySeqNo_TextBox.Border.BottomColor = System.Drawing.Color.Black;
            this.InventorySeqNo_TextBox.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.InventorySeqNo_TextBox.Border.LeftColor = System.Drawing.Color.Black;
            this.InventorySeqNo_TextBox.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.InventorySeqNo_TextBox.Border.RightColor = System.Drawing.Color.Black;
            this.InventorySeqNo_TextBox.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.InventorySeqNo_TextBox.Border.TopColor = System.Drawing.Color.Black;
            this.InventorySeqNo_TextBox.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.InventorySeqNo_TextBox.DataField = "InventorySeqNo";
            this.InventorySeqNo_TextBox.Height = 0.125F;
            this.InventorySeqNo_TextBox.Left = 7.208333F;
            this.InventorySeqNo_TextBox.MultiLine = false;
            this.InventorySeqNo_TextBox.Name = "InventorySeqNo_TextBox";
            this.InventorySeqNo_TextBox.OutputFormat = resources.GetString("InventorySeqNo_TextBox.OutputFormat");
            this.InventorySeqNo_TextBox.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: �l�r �S�V�b�N; vertic" +
                "al-align: top; ";
            this.InventorySeqNo_TextBox.Text = "12345678";
            this.InventorySeqNo_TextBox.Top = 0F;
            this.InventorySeqNo_TextBox.Width = 0.48F;
            // 
            // textBox1
            // 
            this.textBox1.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox1.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox1.Border.RightColor = System.Drawing.Color.Black;
            this.textBox1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox1.Border.TopColor = System.Drawing.Color.Black;
            this.textBox1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox1.Height = 0.1875F;
            this.textBox1.Left = 4.53125F;
            this.textBox1.MultiLine = false;
            this.textBox1.Name = "textBox1";
            this.textBox1.OutputFormat = resources.GetString("textBox1.OutputFormat");
            this.textBox1.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: �l�r ����; vertical" +
                "-align: top; ";
            this.textBox1.Text = "(";
            this.textBox1.Top = 0F;
            this.textBox1.Width = 0.125F;
            // 
            // textBox2
            // 
            this.textBox2.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox2.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox2.Border.RightColor = System.Drawing.Color.Black;
            this.textBox2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox2.Border.TopColor = System.Drawing.Color.Black;
            this.textBox2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox2.Height = 0.188F;
            this.textBox2.Left = 5.145833F;
            this.textBox2.MultiLine = false;
            this.textBox2.Name = "textBox2";
            this.textBox2.OutputFormat = resources.GetString("textBox2.OutputFormat");
            this.textBox2.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: �l�r ����; vertical" +
                "-align: top; ";
            this.textBox2.Text = ")";
            this.textBox2.Top = 0F;
            this.textBox2.Width = 0.125F;
            // 
            // BlankShowFlag
            // 
            this.BlankShowFlag.Border.BottomColor = System.Drawing.Color.Black;
            this.BlankShowFlag.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BlankShowFlag.Border.LeftColor = System.Drawing.Color.Black;
            this.BlankShowFlag.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BlankShowFlag.Border.RightColor = System.Drawing.Color.Black;
            this.BlankShowFlag.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BlankShowFlag.Border.TopColor = System.Drawing.Color.Black;
            this.BlankShowFlag.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BlankShowFlag.DataField = "BlankShowFlag_Print";
            this.BlankShowFlag.Height = 0.125F;
            this.BlankShowFlag.Left = 0.6875F;
            this.BlankShowFlag.MultiLine = false;
            this.BlankShowFlag.Name = "BlankShowFlag";
            this.BlankShowFlag.OutputFormat = resources.GetString("BlankShowFlag.OutputFormat");
            this.BlankShowFlag.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: �l�r �S�V�b�N; verti" +
                "cal-align: top; ";
            this.BlankShowFlag.Text = "123,456.99";
            this.BlankShowFlag.Top = 0.3125F;
            this.BlankShowFlag.Visible = false;
            this.BlankShowFlag.Width = 0.6F;
            // 
            // InvStockCntFlag
            // 
            this.InvStockCntFlag.Border.BottomColor = System.Drawing.Color.Black;
            this.InvStockCntFlag.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.InvStockCntFlag.Border.LeftColor = System.Drawing.Color.Black;
            this.InvStockCntFlag.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.InvStockCntFlag.Border.RightColor = System.Drawing.Color.Black;
            this.InvStockCntFlag.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.InvStockCntFlag.Border.TopColor = System.Drawing.Color.Black;
            this.InvStockCntFlag.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.InvStockCntFlag.DataField = "InvStockCntFlag_Print";
            this.InvStockCntFlag.Height = 0.125F;
            this.InvStockCntFlag.Left = 3.25F;
            this.InvStockCntFlag.MultiLine = false;
            this.InvStockCntFlag.Name = "InvStockCntFlag";
            this.InvStockCntFlag.OutputFormat = resources.GetString("InvStockCntFlag.OutputFormat");
            this.InvStockCntFlag.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: �l�r ����; vertical" +
                "-align: top; ";
            this.InvStockCntFlag.Text = null;
            this.InvStockCntFlag.Top = 0.25F;
            this.InvStockCntFlag.Visible = false;
            this.InvStockCntFlag.Width = 0.25F;
            // 
            // Warehouse_TextBox
            // 
            this.Warehouse_TextBox.Border.BottomColor = System.Drawing.Color.Black;
            this.Warehouse_TextBox.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Warehouse_TextBox.Border.LeftColor = System.Drawing.Color.Black;
            this.Warehouse_TextBox.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Warehouse_TextBox.Border.RightColor = System.Drawing.Color.Black;
            this.Warehouse_TextBox.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Warehouse_TextBox.Border.TopColor = System.Drawing.Color.Black;
            this.Warehouse_TextBox.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Warehouse_TextBox.DataField = "WarehouseName";
            this.Warehouse_TextBox.Height = 0.125F;
            this.Warehouse_TextBox.Left = 0.375F;
            this.Warehouse_TextBox.MultiLine = false;
            this.Warehouse_TextBox.Name = "Warehouse_TextBox";
            this.Warehouse_TextBox.OutputFormat = resources.GetString("Warehouse_TextBox.OutputFormat");
            this.Warehouse_TextBox.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: �l�r ����; vertical" +
                "-align: top; ";
            this.Warehouse_TextBox.Text = "�q�ɖ���";
            this.Warehouse_TextBox.Top = 0F;
            this.Warehouse_TextBox.Width = 1.1875F;
            // 
            // WarehouseCode_TextBox
            // 
            this.WarehouseCode_TextBox.Border.BottomColor = System.Drawing.Color.Black;
            this.WarehouseCode_TextBox.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WarehouseCode_TextBox.Border.LeftColor = System.Drawing.Color.Black;
            this.WarehouseCode_TextBox.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WarehouseCode_TextBox.Border.RightColor = System.Drawing.Color.Black;
            this.WarehouseCode_TextBox.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WarehouseCode_TextBox.Border.TopColor = System.Drawing.Color.Black;
            this.WarehouseCode_TextBox.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WarehouseCode_TextBox.DataField = "WarehouseCode_Print";
            this.WarehouseCode_TextBox.Height = 0.125F;
            this.WarehouseCode_TextBox.Left = 0F;
            this.WarehouseCode_TextBox.MultiLine = false;
            this.WarehouseCode_TextBox.Name = "WarehouseCode_TextBox";
            this.WarehouseCode_TextBox.OutputFormat = resources.GetString("WarehouseCode_TextBox.OutputFormat");
            this.WarehouseCode_TextBox.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: �l�r �S�V�b�N; verti" +
                "cal-align: top; ";
            this.WarehouseCode_TextBox.Text = "5000";
            this.WarehouseCode_TextBox.Top = 0F;
            this.WarehouseCode_TextBox.Width = 0.3125F;
            // 
            // PageHeader
            // 
            this.PageHeader.CanShrink = true;
            this.PageHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.Label1,
            this.Label3,
            this.PrintDate,
            this.Label2,
            this.PRINTPAGE,
            this.Line1,
            this.SortTitle,
            this.PrintTime});
            this.PageHeader.Height = 0.2708333F;
            this.PageHeader.Name = "PageHeader";
            this.PageHeader.Format += new System.EventHandler(this.PageHeader_Format);
            // 
            // Label1
            // 
            this.Label1.Border.BottomColor = System.Drawing.Color.Black;
            this.Label1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label1.Border.LeftColor = System.Drawing.Color.Black;
            this.Label1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label1.Border.RightColor = System.Drawing.Color.Black;
            this.Label1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label1.Border.TopColor = System.Drawing.Color.Black;
            this.Label1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label1.Height = 0.21875F;
            this.Label1.HyperLink = "";
            this.Label1.Left = 0.21875F;
            this.Label1.MultiLine = false;
            this.Label1.Name = "Label1";
            this.Label1.Style = "ddo-char-set: 1; font-weight: bold; font-style: italic; font-size: 14.25pt; font-" +
                "family: �l�r ����; vertical-align: middle; ";
            this.Label1.Text = "�I�������\";
            this.Label1.Top = 0.01041667F;
            this.Label1.Width = 2.09375F;
            // 
            // Label3
            // 
            this.Label3.Border.BottomColor = System.Drawing.Color.Black;
            this.Label3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label3.Border.LeftColor = System.Drawing.Color.Black;
            this.Label3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label3.Border.RightColor = System.Drawing.Color.Black;
            this.Label3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label3.Border.TopColor = System.Drawing.Color.Black;
            this.Label3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label3.Height = 0.1875F;
            this.Label3.HyperLink = "";
            this.Label3.Left = 4.854167F;
            this.Label3.MultiLine = false;
            this.Label3.Name = "Label3";
            this.Label3.Style = "ddo-char-set: 1; font-size: 8pt; font-family: �l�r ����; vertical-align: top; ";
            this.Label3.Text = "�쐬���t�F";
            this.Label3.Top = 0.08333334F;
            this.Label3.Width = 0.625F;
            // 
            // PrintDate
            // 
            this.PrintDate.Border.BottomColor = System.Drawing.Color.Black;
            this.PrintDate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PrintDate.Border.LeftColor = System.Drawing.Color.Black;
            this.PrintDate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PrintDate.Border.RightColor = System.Drawing.Color.Black;
            this.PrintDate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PrintDate.Border.TopColor = System.Drawing.Color.Black;
            this.PrintDate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PrintDate.CanShrink = true;
            this.PrintDate.Height = 0.1875F;
            this.PrintDate.Left = 5.479167F;
            this.PrintDate.MultiLine = false;
            this.PrintDate.Name = "PrintDate";
            this.PrintDate.OutputFormat = resources.GetString("PrintDate.OutputFormat");
            this.PrintDate.Style = "ddo-char-set: 1; font-size: 8pt; font-family: �l�r ����; vertical-align: top; ";
            this.PrintDate.Text = "����17�N11�� 5��";
            this.PrintDate.Top = 0.08333334F;
            this.PrintDate.Width = 0.9375F;
            // 
            // Label2
            // 
            this.Label2.Border.BottomColor = System.Drawing.Color.Black;
            this.Label2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label2.Border.LeftColor = System.Drawing.Color.Black;
            this.Label2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label2.Border.RightColor = System.Drawing.Color.Black;
            this.Label2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label2.Border.TopColor = System.Drawing.Color.Black;
            this.Label2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label2.Height = 0.1875F;
            this.Label2.HyperLink = "";
            this.Label2.Left = 6.854167F;
            this.Label2.MultiLine = false;
            this.Label2.Name = "Label2";
            this.Label2.Style = "ddo-char-set: 1; font-size: 8pt; font-family: �l�r ����; vertical-align: top; ";
            this.Label2.Text = "�y�[�W�F";
            this.Label2.Top = 0.08333334F;
            this.Label2.Width = 0.5F;
            // 
            // PRINTPAGE
            // 
            this.PRINTPAGE.Border.BottomColor = System.Drawing.Color.Black;
            this.PRINTPAGE.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PRINTPAGE.Border.LeftColor = System.Drawing.Color.Black;
            this.PRINTPAGE.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PRINTPAGE.Border.RightColor = System.Drawing.Color.Black;
            this.PRINTPAGE.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PRINTPAGE.Border.TopColor = System.Drawing.Color.Black;
            this.PRINTPAGE.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PRINTPAGE.CanShrink = true;
            this.PRINTPAGE.Height = 0.1875F;
            this.PRINTPAGE.Left = 7.354167F;
            this.PRINTPAGE.MultiLine = false;
            this.PRINTPAGE.Name = "PRINTPAGE";
            this.PRINTPAGE.OutputFormat = resources.GetString("PRINTPAGE.OutputFormat");
            this.PRINTPAGE.Style = "ddo-char-set: 1; text-align: right; font-size: 8pt; font-family: �l�r ����; vertical-" +
                "align: top; ";
            this.PRINTPAGE.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.PRINTPAGE.SummaryType = DataDynamics.ActiveReports.SummaryType.PageCount;
            this.PRINTPAGE.Text = "123";
            this.PRINTPAGE.Top = 0.08333334F;
            this.PRINTPAGE.Width = 0.3125F;
            // 
            // Line1
            // 
            this.Line1.Border.BottomColor = System.Drawing.Color.Black;
            this.Line1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line1.Border.LeftColor = System.Drawing.Color.Black;
            this.Line1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line1.Border.RightColor = System.Drawing.Color.Black;
            this.Line1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line1.Border.TopColor = System.Drawing.Color.Black;
            this.Line1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line1.Height = 0F;
            this.Line1.Left = 0F;
            this.Line1.LineWeight = 3F;
            this.Line1.Name = "Line1";
            this.Line1.Top = 0.2085F;
            this.Line1.Width = 7.677F;
            this.Line1.X1 = 0F;
            this.Line1.X2 = 7.677F;
            this.Line1.Y1 = 0.2085F;
            this.Line1.Y2 = 0.2085F;
            // 
            // SortTitle
            // 
            this.SortTitle.Border.BottomColor = System.Drawing.Color.Black;
            this.SortTitle.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SortTitle.Border.LeftColor = System.Drawing.Color.Black;
            this.SortTitle.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SortTitle.Border.RightColor = System.Drawing.Color.Black;
            this.SortTitle.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SortTitle.Border.TopColor = System.Drawing.Color.Black;
            this.SortTitle.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SortTitle.CanShrink = true;
            this.SortTitle.Height = 0.125F;
            this.SortTitle.Left = 2.125F;
            this.SortTitle.MultiLine = false;
            this.SortTitle.Name = "SortTitle";
            this.SortTitle.Style = "ddo-char-set: 1; font-size: 8pt; font-family: �l�r ����; vertical-align: top; ";
            this.SortTitle.Text = "[�\�[�g����]";
            this.SortTitle.Top = 0.08333334F;
            this.SortTitle.Width = 2.25F;
            // 
            // PrintTime
            // 
            this.PrintTime.Border.BottomColor = System.Drawing.Color.Black;
            this.PrintTime.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PrintTime.Border.LeftColor = System.Drawing.Color.Black;
            this.PrintTime.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PrintTime.Border.RightColor = System.Drawing.Color.Black;
            this.PrintTime.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PrintTime.Border.TopColor = System.Drawing.Color.Black;
            this.PrintTime.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PrintTime.Height = 0.125F;
            this.PrintTime.Left = 6.354167F;
            this.PrintTime.Name = "PrintTime";
            this.PrintTime.Style = "ddo-char-set: 1; font-size: 8pt; ";
            this.PrintTime.Text = "11��20��";
            this.PrintTime.Top = 0.08333334F;
            this.PrintTime.Width = 0.5F;
            // 
            // PageFooter
            // 
            this.PageFooter.CanShrink = true;
            this.PageFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.Line_PageFooter,
            this.PageFooters0,
            this.PageFooters1});
            this.PageFooter.Height = 0.3020833F;
            this.PageFooter.Name = "PageFooter";
            this.PageFooter.Format += new System.EventHandler(this.PageFooter_Format);
            // 
            // Line_PageFooter
            // 
            this.Line_PageFooter.Border.BottomColor = System.Drawing.Color.Black;
            this.Line_PageFooter.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line_PageFooter.Border.LeftColor = System.Drawing.Color.Black;
            this.Line_PageFooter.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line_PageFooter.Border.RightColor = System.Drawing.Color.Black;
            this.Line_PageFooter.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line_PageFooter.Border.TopColor = System.Drawing.Color.Black;
            this.Line_PageFooter.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line_PageFooter.Height = 0F;
            this.Line_PageFooter.Left = 0F;
            this.Line_PageFooter.LineWeight = 2F;
            this.Line_PageFooter.Name = "Line_PageFooter";
            this.Line_PageFooter.Top = 0F;
            this.Line_PageFooter.Width = 7.677F;
            this.Line_PageFooter.X1 = 0F;
            this.Line_PageFooter.X2 = 7.677F;
            this.Line_PageFooter.Y1 = 0F;
            this.Line_PageFooter.Y2 = 0F;
            // 
            // PageFooters0
            // 
            this.PageFooters0.Border.BottomColor = System.Drawing.Color.Black;
            this.PageFooters0.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PageFooters0.Border.LeftColor = System.Drawing.Color.Black;
            this.PageFooters0.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PageFooters0.Border.RightColor = System.Drawing.Color.Black;
            this.PageFooters0.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PageFooters0.Border.TopColor = System.Drawing.Color.Black;
            this.PageFooters0.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PageFooters0.Height = 0.125F;
            this.PageFooters0.Left = 0F;
            this.PageFooters0.MultiLine = false;
            this.PageFooters0.Name = "PageFooters0";
            this.PageFooters0.OutputFormat = resources.GetString("PageFooters0.OutputFormat");
            this.PageFooters0.Style = "ddo-char-set: 1; text-align: left; font-size: 8pt; font-family: �l�r ����; vertical-a" +
                "lign: top; ";
            this.PageFooters0.Text = null;
            this.PageFooters0.Top = 0F;
            this.PageFooters0.Width = 3F;
            // 
            // PageFooters1
            // 
            this.PageFooters1.Border.BottomColor = System.Drawing.Color.Black;
            this.PageFooters1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PageFooters1.Border.LeftColor = System.Drawing.Color.Black;
            this.PageFooters1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PageFooters1.Border.RightColor = System.Drawing.Color.Black;
            this.PageFooters1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PageFooters1.Border.TopColor = System.Drawing.Color.Black;
            this.PageFooters1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PageFooters1.Height = 0.125F;
            this.PageFooters1.Left = 4.5F;
            this.PageFooters1.MultiLine = false;
            this.PageFooters1.Name = "PageFooters1";
            this.PageFooters1.OutputFormat = resources.GetString("PageFooters1.OutputFormat");
            this.PageFooters1.Style = "ddo-char-set: 1; text-align: right; font-size: 8pt; font-family: �l�r ����; vertical-" +
                "align: top; ";
            this.PageFooters1.Text = null;
            this.PageFooters1.Top = 0F;
            this.PageFooters1.Width = 3F;
            // 
            // ExtraHeader
            // 
            this.ExtraHeader.CanShrink = true;
            this.ExtraHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.Header_SubReport});
            this.ExtraHeader.Height = 0.5F;
            this.ExtraHeader.Name = "ExtraHeader";
            this.ExtraHeader.RepeatStyle = DataDynamics.ActiveReports.RepeatStyle.OnPageIncludeNoDetail;
            this.ExtraHeader.Format += new System.EventHandler(this.ExtraHeader_Format);
            // 
            // Header_SubReport
            // 
            this.Header_SubReport.Border.BottomColor = System.Drawing.Color.Black;
            this.Header_SubReport.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Header_SubReport.Border.LeftColor = System.Drawing.Color.Black;
            this.Header_SubReport.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Header_SubReport.Border.RightColor = System.Drawing.Color.Black;
            this.Header_SubReport.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Header_SubReport.Border.TopColor = System.Drawing.Color.Black;
            this.Header_SubReport.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Header_SubReport.CloseBorder = false;
            this.Header_SubReport.Height = 0.5F;
            this.Header_SubReport.Left = 0F;
            this.Header_SubReport.Name = "Header_SubReport";
            this.Header_SubReport.Report = null;
            this.Header_SubReport.Top = 0F;
            this.Header_SubReport.Width = 7.625F;
            // 
            // ExtraFooter
            // 
            this.ExtraFooter.CanShrink = true;
            this.ExtraFooter.Height = 0F;
            this.ExtraFooter.KeepTogether = true;
            this.ExtraFooter.Name = "ExtraFooter";
            this.ExtraFooter.Visible = false;
            // 
            // TitleHeader
            // 
            this.TitleHeader.CanShrink = true;
            this.TitleHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.GoodsNo_Title,
            this.Line4,
            this.StockUnitPrice_Title,
            this.GoodsName_Title,
            this.StockCount_Title,
            this.WarehouseShelfNo_Title,
            this.InventStockCount_Title,
            this.InventorySeqNo_Title,
            this.Maker_Title,
            this.SupplierCd_Title,
            this.BLGoodsCode_Title,
            this.BLGroupCode_Title,
            this.line6});
            this.TitleHeader.Height = 0.28125F;
            this.TitleHeader.Name = "TitleHeader";
            this.TitleHeader.RepeatStyle = DataDynamics.ActiveReports.RepeatStyle.OnPageIncludeNoDetail;
            // 
            // GoodsNo_Title
            // 
            this.GoodsNo_Title.Border.BottomColor = System.Drawing.Color.Black;
            this.GoodsNo_Title.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsNo_Title.Border.LeftColor = System.Drawing.Color.Black;
            this.GoodsNo_Title.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsNo_Title.Border.RightColor = System.Drawing.Color.Black;
            this.GoodsNo_Title.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsNo_Title.Border.TopColor = System.Drawing.Color.Black;
            this.GoodsNo_Title.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsNo_Title.Height = 0.1875F;
            this.GoodsNo_Title.HyperLink = "";
            this.GoodsNo_Title.Left = 0.625F;
            this.GoodsNo_Title.MultiLine = false;
            this.GoodsNo_Title.Name = "GoodsNo_Title";
            this.GoodsNo_Title.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: �l�r ����; vertical-align: middle; ";
            this.GoodsNo_Title.Text = "�i��";
            this.GoodsNo_Title.Top = 0F;
            this.GoodsNo_Title.Width = 2.29F;
            // 
            // Line4
            // 
            this.Line4.Border.BottomColor = System.Drawing.Color.Black;
            this.Line4.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line4.Border.LeftColor = System.Drawing.Color.Black;
            this.Line4.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line4.Border.RightColor = System.Drawing.Color.Black;
            this.Line4.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line4.Border.TopColor = System.Drawing.Color.Black;
            this.Line4.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line4.Height = 0F;
            this.Line4.Left = 0F;
            this.Line4.LineWeight = 2F;
            this.Line4.Name = "Line4";
            this.Line4.Top = 0F;
            this.Line4.Width = 7.677F;
            this.Line4.X1 = 0F;
            this.Line4.X2 = 7.677F;
            this.Line4.Y1 = 0F;
            this.Line4.Y2 = 0F;
            // 
            // StockUnitPrice_Title
            // 
            this.StockUnitPrice_Title.Border.BottomColor = System.Drawing.Color.Black;
            this.StockUnitPrice_Title.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockUnitPrice_Title.Border.LeftColor = System.Drawing.Color.Black;
            this.StockUnitPrice_Title.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockUnitPrice_Title.Border.RightColor = System.Drawing.Color.Black;
            this.StockUnitPrice_Title.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockUnitPrice_Title.Border.TopColor = System.Drawing.Color.Black;
            this.StockUnitPrice_Title.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockUnitPrice_Title.Height = 0.1875F;
            this.StockUnitPrice_Title.HyperLink = "";
            this.StockUnitPrice_Title.Left = 5.177F;
            this.StockUnitPrice_Title.MultiLine = false;
            this.StockUnitPrice_Title.Name = "StockUnitPrice_Title";
            this.StockUnitPrice_Title.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: �l�r ����; vertical-align: middle; ";
            this.StockUnitPrice_Title.Text = "���P��";
            this.StockUnitPrice_Title.Top = 0F;
            this.StockUnitPrice_Title.Width = 0.7F;
            // 
            // GoodsName_Title
            // 
            this.GoodsName_Title.Border.BottomColor = System.Drawing.Color.Black;
            this.GoodsName_Title.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsName_Title.Border.LeftColor = System.Drawing.Color.Black;
            this.GoodsName_Title.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsName_Title.Border.RightColor = System.Drawing.Color.Black;
            this.GoodsName_Title.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsName_Title.Border.TopColor = System.Drawing.Color.Black;
            this.GoodsName_Title.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsName_Title.Height = 0.1875F;
            this.GoodsName_Title.HyperLink = "";
            this.GoodsName_Title.Left = 2.885F;
            this.GoodsName_Title.MultiLine = false;
            this.GoodsName_Title.Name = "GoodsName_Title";
            this.GoodsName_Title.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: �l�r ����; vertical-align: middle; ";
            this.GoodsName_Title.Text = "�i��";
            this.GoodsName_Title.Top = 0F;
            this.GoodsName_Title.Width = 1.14F;
            // 
            // StockCount_Title
            // 
            this.StockCount_Title.Border.BottomColor = System.Drawing.Color.Black;
            this.StockCount_Title.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockCount_Title.Border.LeftColor = System.Drawing.Color.Black;
            this.StockCount_Title.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockCount_Title.Border.RightColor = System.Drawing.Color.Black;
            this.StockCount_Title.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockCount_Title.Border.TopColor = System.Drawing.Color.Black;
            this.StockCount_Title.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockCount_Title.Height = 0.1875F;
            this.StockCount_Title.HyperLink = "";
            this.StockCount_Title.Left = 3.969F;
            this.StockCount_Title.MultiLine = false;
            this.StockCount_Title.Name = "StockCount_Title";
            this.StockCount_Title.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: �l�r ����; vertical-align: middle; ";
            this.StockCount_Title.Text = "���됔";
            this.StockCount_Title.Top = 0F;
            this.StockCount_Title.Width = 0.6F;
            // 
            // WarehouseShelfNo_Title
            // 
            this.WarehouseShelfNo_Title.Border.BottomColor = System.Drawing.Color.Black;
            this.WarehouseShelfNo_Title.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WarehouseShelfNo_Title.Border.LeftColor = System.Drawing.Color.Black;
            this.WarehouseShelfNo_Title.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WarehouseShelfNo_Title.Border.RightColor = System.Drawing.Color.Black;
            this.WarehouseShelfNo_Title.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WarehouseShelfNo_Title.Border.TopColor = System.Drawing.Color.Black;
            this.WarehouseShelfNo_Title.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WarehouseShelfNo_Title.Height = 0.1875F;
            this.WarehouseShelfNo_Title.HyperLink = "";
            this.WarehouseShelfNo_Title.Left = 0F;
            this.WarehouseShelfNo_Title.MultiLine = false;
            this.WarehouseShelfNo_Title.Name = "WarehouseShelfNo_Title";
            this.WarehouseShelfNo_Title.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: �l�r ����; vertical-align: middle; ";
            this.WarehouseShelfNo_Title.Text = "�I��";
            this.WarehouseShelfNo_Title.Top = 0F;
            this.WarehouseShelfNo_Title.Width = 0.628F;
            // 
            // InventStockCount_Title
            // 
            this.InventStockCount_Title.Border.BottomColor = System.Drawing.Color.Black;
            this.InventStockCount_Title.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.InventStockCount_Title.Border.LeftColor = System.Drawing.Color.Black;
            this.InventStockCount_Title.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.InventStockCount_Title.Border.RightColor = System.Drawing.Color.Black;
            this.InventStockCount_Title.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.InventStockCount_Title.Border.TopColor = System.Drawing.Color.Black;
            this.InventStockCount_Title.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.InventStockCount_Title.Height = 0.1875F;
            this.InventStockCount_Title.HyperLink = "";
            this.InventStockCount_Title.Left = 4.563F;
            this.InventStockCount_Title.MultiLine = false;
            this.InventStockCount_Title.Name = "InventStockCount_Title";
            this.InventStockCount_Title.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: �l�r ����; vertical-align: middle; ";
            this.InventStockCount_Title.Text = "�I�����@";
            this.InventStockCount_Title.Top = 0F;
            this.InventStockCount_Title.Width = 0.6F;
            // 
            // InventorySeqNo_Title
            // 
            this.InventorySeqNo_Title.Border.BottomColor = System.Drawing.Color.Black;
            this.InventorySeqNo_Title.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.InventorySeqNo_Title.Border.LeftColor = System.Drawing.Color.Black;
            this.InventorySeqNo_Title.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.InventorySeqNo_Title.Border.RightColor = System.Drawing.Color.Black;
            this.InventorySeqNo_Title.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.InventorySeqNo_Title.Border.TopColor = System.Drawing.Color.Black;
            this.InventorySeqNo_Title.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.InventorySeqNo_Title.Height = 0.1875F;
            this.InventorySeqNo_Title.HyperLink = "";
            this.InventorySeqNo_Title.Left = 7.208F;
            this.InventorySeqNo_Title.MultiLine = false;
            this.InventorySeqNo_Title.Name = "InventorySeqNo_Title";
            this.InventorySeqNo_Title.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: �l�r ����; vertical-align: middle; ";
            this.InventorySeqNo_Title.Text = "�I���A��";
            this.InventorySeqNo_Title.Top = 0F;
            this.InventorySeqNo_Title.Width = 0.48F;
            // 
            // Maker_Title
            // 
            this.Maker_Title.Border.BottomColor = System.Drawing.Color.Black;
            this.Maker_Title.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Maker_Title.Border.LeftColor = System.Drawing.Color.Black;
            this.Maker_Title.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Maker_Title.Border.RightColor = System.Drawing.Color.Black;
            this.Maker_Title.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Maker_Title.Border.TopColor = System.Drawing.Color.Black;
            this.Maker_Title.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Maker_Title.Height = 0.1875F;
            this.Maker_Title.HyperLink = "";
            this.Maker_Title.Left = 6.939F;
            this.Maker_Title.MultiLine = false;
            this.Maker_Title.Name = "Maker_Title";
            this.Maker_Title.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: �l�r ����; vertical-align: middle; ";
            this.Maker_Title.Text = "Ұ��";
            this.Maker_Title.Top = 0F;
            this.Maker_Title.Width = 0.253F;
            // 
            // SupplierCd_Title
            // 
            this.SupplierCd_Title.Border.BottomColor = System.Drawing.Color.Black;
            this.SupplierCd_Title.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupplierCd_Title.Border.LeftColor = System.Drawing.Color.Black;
            this.SupplierCd_Title.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupplierCd_Title.Border.RightColor = System.Drawing.Color.Black;
            this.SupplierCd_Title.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupplierCd_Title.Border.TopColor = System.Drawing.Color.Black;
            this.SupplierCd_Title.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupplierCd_Title.Height = 0.1875F;
            this.SupplierCd_Title.HyperLink = "";
            this.SupplierCd_Title.Left = 5.901F;
            this.SupplierCd_Title.MultiLine = false;
            this.SupplierCd_Title.Name = "SupplierCd_Title";
            this.SupplierCd_Title.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: �l�r ����; vertical-align: middle; ";
            this.SupplierCd_Title.Text = "�d����";
            this.SupplierCd_Title.Top = 0F;
            this.SupplierCd_Title.Width = 0.363F;
            // 
            // BLGoodsCode_Title
            // 
            this.BLGoodsCode_Title.Border.BottomColor = System.Drawing.Color.Black;
            this.BLGoodsCode_Title.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BLGoodsCode_Title.Border.LeftColor = System.Drawing.Color.Black;
            this.BLGoodsCode_Title.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BLGoodsCode_Title.Border.RightColor = System.Drawing.Color.Black;
            this.BLGoodsCode_Title.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BLGoodsCode_Title.Border.TopColor = System.Drawing.Color.Black;
            this.BLGoodsCode_Title.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BLGoodsCode_Title.Height = 0.1875F;
            this.BLGoodsCode_Title.HyperLink = "";
            this.BLGoodsCode_Title.Left = 6.289F;
            this.BLGoodsCode_Title.MultiLine = false;
            this.BLGoodsCode_Title.Name = "BLGoodsCode_Title";
            this.BLGoodsCode_Title.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: �l�r ����; vertical-align: middle; ";
            this.BLGoodsCode_Title.Text = "BL����";
            this.BLGoodsCode_Title.Top = 0F;
            this.BLGoodsCode_Title.Width = 0.363F;
            // 
            // BLGroupCode_Title
            // 
            this.BLGroupCode_Title.Border.BottomColor = System.Drawing.Color.Black;
            this.BLGroupCode_Title.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BLGroupCode_Title.Border.LeftColor = System.Drawing.Color.Black;
            this.BLGroupCode_Title.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BLGroupCode_Title.Border.RightColor = System.Drawing.Color.Black;
            this.BLGroupCode_Title.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BLGroupCode_Title.Border.TopColor = System.Drawing.Color.Black;
            this.BLGroupCode_Title.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BLGroupCode_Title.Height = 0.1875F;
            this.BLGroupCode_Title.HyperLink = "";
            this.BLGroupCode_Title.Left = 6.611F;
            this.BLGroupCode_Title.MultiLine = false;
            this.BLGroupCode_Title.Name = "BLGroupCode_Title";
            this.BLGroupCode_Title.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: �l�r ����; vertical-align: middle; ";
            this.BLGroupCode_Title.Text = "��ٰ��";
            this.BLGroupCode_Title.Top = 0F;
            this.BLGroupCode_Title.Width = 0.363F;
            // 
            // line6
            // 
            this.line6.Border.BottomColor = System.Drawing.Color.Black;
            this.line6.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line6.Border.LeftColor = System.Drawing.Color.Black;
            this.line6.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line6.Border.RightColor = System.Drawing.Color.Black;
            this.line6.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line6.Border.TopColor = System.Drawing.Color.Black;
            this.line6.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line6.Height = 0F;
            this.line6.Left = 0F;
            this.line6.LineWeight = 2F;
            this.line6.Name = "line6";
            this.line6.Top = 0.1875F;
            this.line6.Width = 7.677F;
            this.line6.X1 = 0F;
            this.line6.X2 = 7.677F;
            this.line6.Y1 = 0.1875F;
            this.line6.Y2 = 0.1875F;
            // 
            // TitleFooter
            // 
            this.TitleFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.Line41});
            this.TitleFooter.Height = 0F;
            this.TitleFooter.Name = "TitleFooter";
            this.TitleFooter.Visible = false;
            // 
            // Line41
            // 
            this.Line41.Border.BottomColor = System.Drawing.Color.Black;
            this.Line41.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line41.Border.LeftColor = System.Drawing.Color.Black;
            this.Line41.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line41.Border.RightColor = System.Drawing.Color.Black;
            this.Line41.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line41.Border.TopColor = System.Drawing.Color.Black;
            this.Line41.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line41.Height = 0F;
            this.Line41.Left = 0F;
            this.Line41.LineWeight = 2F;
            this.Line41.Name = "Line41";
            this.Line41.Top = 0F;
            this.Line41.Width = 7.677F;
            this.Line41.X1 = 0F;
            this.Line41.X2 = 7.677F;
            this.Line41.Y1 = 0F;
            this.Line41.Y2 = 0F;
            // 
            // GrandTotalHeader
            // 
            this.GrandTotalHeader.CanShrink = true;
            this.GrandTotalHeader.Height = 0F;
            this.GrandTotalHeader.Name = "GrandTotalHeader";
            this.GrandTotalHeader.Visible = false;
            // 
            // GrandTotalFooter
            // 
            this.GrandTotalFooter.CanShrink = true;
            this.GrandTotalFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.GrandTotal_Title,
            this.Line,
            this.GrandStockCount_TextBox,
            this.textBox4,
            this.GrandInventStockCount_TextBox,
            this.textBox8});
            this.GrandTotalFooter.Height = 0.21875F;
            this.GrandTotalFooter.KeepTogether = true;
            this.GrandTotalFooter.Name = "GrandTotalFooter";
            this.GrandTotalFooter.Visible = false;
            this.GrandTotalFooter.BeforePrint += new System.EventHandler(this.GrandTotalFooter_BeforePrint);
            // 
            // GrandTotal_Title
            // 
            this.GrandTotal_Title.Border.BottomColor = System.Drawing.Color.Black;
            this.GrandTotal_Title.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrandTotal_Title.Border.LeftColor = System.Drawing.Color.Black;
            this.GrandTotal_Title.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrandTotal_Title.Border.RightColor = System.Drawing.Color.Black;
            this.GrandTotal_Title.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrandTotal_Title.Border.TopColor = System.Drawing.Color.Black;
            this.GrandTotal_Title.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrandTotal_Title.Height = 0.1875F;
            this.GrandTotal_Title.HyperLink = "";
            this.GrandTotal_Title.Left = 2.885F;
            this.GrandTotal_Title.MultiLine = false;
            this.GrandTotal_Title.Name = "GrandTotal_Title";
            this.GrandTotal_Title.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 11.25pt; font-" +
                "family: �l�r ����; vertical-align: top; ";
            this.GrandTotal_Title.Text = "�����v";
            this.GrandTotal_Title.Top = 0F;
            this.GrandTotal_Title.Width = 0.5625F;
            // 
            // Line
            // 
            this.Line.Border.BottomColor = System.Drawing.Color.Black;
            this.Line.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line.Border.LeftColor = System.Drawing.Color.Black;
            this.Line.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line.Border.RightColor = System.Drawing.Color.Black;
            this.Line.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line.Border.TopColor = System.Drawing.Color.Black;
            this.Line.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line.Height = 0F;
            this.Line.Left = 0F;
            this.Line.LineWeight = 2F;
            this.Line.Name = "Line";
            this.Line.Top = 0F;
            this.Line.Width = 7.677F;
            this.Line.X1 = 0F;
            this.Line.X2 = 7.677F;
            this.Line.Y1 = 0F;
            this.Line.Y2 = 0F;
            // 
            // GrandStockCount_TextBox
            // 
            this.GrandStockCount_TextBox.Border.BottomColor = System.Drawing.Color.Black;
            this.GrandStockCount_TextBox.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrandStockCount_TextBox.Border.LeftColor = System.Drawing.Color.Black;
            this.GrandStockCount_TextBox.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrandStockCount_TextBox.Border.RightColor = System.Drawing.Color.Black;
            this.GrandStockCount_TextBox.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrandStockCount_TextBox.Border.TopColor = System.Drawing.Color.Black;
            this.GrandStockCount_TextBox.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrandStockCount_TextBox.DataField = "StockTotal";
            this.GrandStockCount_TextBox.Height = 0.125F;
            this.GrandStockCount_TextBox.Left = 3.969F;
            this.GrandStockCount_TextBox.MultiLine = false;
            this.GrandStockCount_TextBox.Name = "GrandStockCount_TextBox";
            this.GrandStockCount_TextBox.OutputFormat = resources.GetString("GrandStockCount_TextBox.OutputFormat");
            this.GrandStockCount_TextBox.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: �l�r �S�V�b�N; vertical-align: top; ";
            this.GrandStockCount_TextBox.SummaryGroup = "GrandTotalHeader";
            this.GrandStockCount_TextBox.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.GrandStockCount_TextBox.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.GrandStockCount_TextBox.Text = "123,456.99";
            this.GrandStockCount_TextBox.Top = 0F;
            this.GrandStockCount_TextBox.Width = 0.6F;
            // 
            // textBox4
            // 
            this.textBox4.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox4.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox4.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox4.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox4.Border.RightColor = System.Drawing.Color.Black;
            this.textBox4.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox4.Border.TopColor = System.Drawing.Color.Black;
            this.textBox4.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox4.Height = 0.1875F;
            this.textBox4.Left = 4.53125F;
            this.textBox4.MultiLine = false;
            this.textBox4.Name = "textBox4";
            this.textBox4.OutputFormat = resources.GetString("textBox4.OutputFormat");
            this.textBox4.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8.25pt; font-f" +
                "amily: �l�r ����; vertical-align: top; ";
            this.textBox4.Text = "(";
            this.textBox4.Top = 0F;
            this.textBox4.Width = 0.125F;
            // 
            // GrandInventStockCount_TextBox
            // 
            this.GrandInventStockCount_TextBox.Border.BottomColor = System.Drawing.Color.Black;
            this.GrandInventStockCount_TextBox.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrandInventStockCount_TextBox.Border.LeftColor = System.Drawing.Color.Black;
            this.GrandInventStockCount_TextBox.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrandInventStockCount_TextBox.Border.RightColor = System.Drawing.Color.Black;
            this.GrandInventStockCount_TextBox.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrandInventStockCount_TextBox.Border.TopColor = System.Drawing.Color.Black;
            this.GrandInventStockCount_TextBox.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrandInventStockCount_TextBox.DataField = "InventoryStockCnt";
            this.GrandInventStockCount_TextBox.Height = 0.125F;
            this.GrandInventStockCount_TextBox.Left = 4.563F;
            this.GrandInventStockCount_TextBox.MultiLine = false;
            this.GrandInventStockCount_TextBox.Name = "GrandInventStockCount_TextBox";
            this.GrandInventStockCount_TextBox.OutputFormat = resources.GetString("GrandInventStockCount_TextBox.OutputFormat");
            this.GrandInventStockCount_TextBox.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: �l�r �S�V�b�N; vertical-align: top; ";
            this.GrandInventStockCount_TextBox.SummaryGroup = "GrandTotalHeader";
            this.GrandInventStockCount_TextBox.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.GrandInventStockCount_TextBox.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.GrandInventStockCount_TextBox.Text = "123,456.99";
            this.GrandInventStockCount_TextBox.Top = 0F;
            this.GrandInventStockCount_TextBox.Width = 0.6F;
            // 
            // textBox8
            // 
            this.textBox8.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox8.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox8.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox8.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox8.Border.RightColor = System.Drawing.Color.Black;
            this.textBox8.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox8.Border.TopColor = System.Drawing.Color.Black;
            this.textBox8.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox8.Height = 0.1875F;
            this.textBox8.Left = 5.146F;
            this.textBox8.MultiLine = false;
            this.textBox8.Name = "textBox8";
            this.textBox8.OutputFormat = resources.GetString("textBox8.OutputFormat");
            this.textBox8.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8.25pt; font-f" +
                "amily: �l�r ����; vertical-align: top; ";
            this.textBox8.Text = ")";
            this.textBox8.Top = 0F;
            this.textBox8.Width = 0.125F;
            // 
            // SectionHeader
            // 
            this.SectionHeader.CanShrink = true;
            this.SectionHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.StockSectionName,
            this.StockSectionCode});
            this.SectionHeader.Height = 0F;
            this.SectionHeader.Name = "SectionHeader";
            this.SectionHeader.Visible = false;
            // 
            // StockSectionName
            // 
            this.StockSectionName.Border.BottomColor = System.Drawing.Color.Black;
            this.StockSectionName.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockSectionName.Border.LeftColor = System.Drawing.Color.Black;
            this.StockSectionName.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockSectionName.Border.RightColor = System.Drawing.Color.Black;
            this.StockSectionName.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockSectionName.Border.TopColor = System.Drawing.Color.Black;
            this.StockSectionName.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockSectionName.CanShrink = true;
            this.StockSectionName.DataField = "SectionGuideNm";
            this.StockSectionName.Height = 0.15F;
            this.StockSectionName.Left = 0.1F;
            this.StockSectionName.MultiLine = false;
            this.StockSectionName.Name = "StockSectionName";
            this.StockSectionName.Style = "ddo-char-set: 128; font-size: 8pt; font-family: �l�r ����; vertical-align: top; ";
            this.StockSectionName.Text = null;
            this.StockSectionName.Top = 0.05F;
            this.StockSectionName.Visible = false;
            this.StockSectionName.Width = 0.75F;
            // 
            // StockSectionCode
            // 
            this.StockSectionCode.Border.BottomColor = System.Drawing.Color.Black;
            this.StockSectionCode.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockSectionCode.Border.LeftColor = System.Drawing.Color.Black;
            this.StockSectionCode.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockSectionCode.Border.RightColor = System.Drawing.Color.Black;
            this.StockSectionCode.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockSectionCode.Border.TopColor = System.Drawing.Color.Black;
            this.StockSectionCode.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockSectionCode.CanShrink = true;
            this.StockSectionCode.DataField = "SectionCode";
            this.StockSectionCode.Height = 0.15F;
            this.StockSectionCode.Left = 0.9375F;
            this.StockSectionCode.MultiLine = false;
            this.StockSectionCode.Name = "StockSectionCode";
            this.StockSectionCode.Style = "ddo-char-set: 128; font-size: 8pt; font-family: �l�r ����; vertical-align: top; ";
            this.StockSectionCode.Text = null;
            this.StockSectionCode.Top = 0.0625F;
            this.StockSectionCode.Visible = false;
            this.StockSectionCode.Width = 0.75F;
            // 
            // SectionFooter
            // 
            this.SectionFooter.CanShrink = true;
            this.SectionFooter.Height = 0F;
            this.SectionFooter.KeepTogether = true;
            this.SectionFooter.Name = "SectionFooter";
            this.SectionFooter.Visible = false;
            // 
            // WarehouseHeader
            // 
            this.WarehouseHeader.CanShrink = true;
            this.WarehouseHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.Warehouse_TextBox,
            this.WarehouseCode_TextBox,
            this.line3});
            this.WarehouseHeader.DataField = "WarehouseCode";
            this.WarehouseHeader.Height = 0.1979167F;
            this.WarehouseHeader.Name = "WarehouseHeader";
            this.WarehouseHeader.NewPage = DataDynamics.ActiveReports.NewPage.Before;
            this.WarehouseHeader.RepeatStyle = DataDynamics.ActiveReports.RepeatStyle.OnPage;
            // 
            // line3
            // 
            this.line3.Border.BottomColor = System.Drawing.Color.Black;
            this.line3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line3.Border.LeftColor = System.Drawing.Color.Black;
            this.line3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line3.Border.RightColor = System.Drawing.Color.Black;
            this.line3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line3.Border.TopColor = System.Drawing.Color.Black;
            this.line3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line3.Height = 0F;
            this.line3.Left = 0F;
            this.line3.LineWeight = 2F;
            this.line3.Name = "line3";
            this.line3.Top = 0F;
            this.line3.Width = 7.677F;
            this.line3.X1 = 0F;
            this.line3.X2 = 7.677F;
            this.line3.Y1 = 0F;
            this.line3.Y2 = 0F;
            // 
            // WarehouseFooter
            // 
            this.WarehouseFooter.CanShrink = true;
            this.WarehouseFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.WareStockCount_TextBox,
            this.Line2,
            this.WarehouseTotal_Title,
            this.WareInventStockCount_TextBox,
            this.textBox5,
            this.textBox6});
            this.WarehouseFooter.Height = 0.219F;
            this.WarehouseFooter.KeepTogether = true;
            this.WarehouseFooter.Name = "WarehouseFooter";
            this.WarehouseFooter.Visible = false;
            this.WarehouseFooter.AfterPrint += new System.EventHandler(this.WarehouseFooter_AfterPrint);
            this.WarehouseFooter.BeforePrint += new System.EventHandler(this.WarehouseFooter_BeforePrint);
            // 
            // WareStockCount_TextBox
            // 
            this.WareStockCount_TextBox.Border.BottomColor = System.Drawing.Color.Black;
            this.WareStockCount_TextBox.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WareStockCount_TextBox.Border.LeftColor = System.Drawing.Color.Black;
            this.WareStockCount_TextBox.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WareStockCount_TextBox.Border.RightColor = System.Drawing.Color.Black;
            this.WareStockCount_TextBox.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WareStockCount_TextBox.Border.TopColor = System.Drawing.Color.Black;
            this.WareStockCount_TextBox.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WareStockCount_TextBox.DataField = "StockTotal";
            this.WareStockCount_TextBox.Height = 0.125F;
            this.WareStockCount_TextBox.Left = 3.969F;
            this.WareStockCount_TextBox.MultiLine = false;
            this.WareStockCount_TextBox.Name = "WareStockCount_TextBox";
            this.WareStockCount_TextBox.OutputFormat = resources.GetString("WareStockCount_TextBox.OutputFormat");
            this.WareStockCount_TextBox.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: �l�r �S�V�b�N; vertical-align: top; ";
            this.WareStockCount_TextBox.SummaryGroup = "WarehouseHeader";
            this.WareStockCount_TextBox.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.WareStockCount_TextBox.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.WareStockCount_TextBox.Text = "123,456.99";
            this.WareStockCount_TextBox.Top = 0F;
            this.WareStockCount_TextBox.Width = 0.6F;
            // 
            // Line2
            // 
            this.Line2.Border.BottomColor = System.Drawing.Color.Black;
            this.Line2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line2.Border.LeftColor = System.Drawing.Color.Black;
            this.Line2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line2.Border.RightColor = System.Drawing.Color.Black;
            this.Line2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line2.Border.TopColor = System.Drawing.Color.Black;
            this.Line2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line2.Height = 0F;
            this.Line2.Left = 0F;
            this.Line2.LineWeight = 2F;
            this.Line2.Name = "Line2";
            this.Line2.Top = 0F;
            this.Line2.Width = 7.677F;
            this.Line2.X1 = 0F;
            this.Line2.X2 = 7.677F;
            this.Line2.Y1 = 0F;
            this.Line2.Y2 = 0F;
            // 
            // WarehouseTotal_Title
            // 
            this.WarehouseTotal_Title.Border.BottomColor = System.Drawing.Color.Black;
            this.WarehouseTotal_Title.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WarehouseTotal_Title.Border.LeftColor = System.Drawing.Color.Black;
            this.WarehouseTotal_Title.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WarehouseTotal_Title.Border.RightColor = System.Drawing.Color.Black;
            this.WarehouseTotal_Title.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WarehouseTotal_Title.Border.TopColor = System.Drawing.Color.Black;
            this.WarehouseTotal_Title.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WarehouseTotal_Title.Height = 0.1875F;
            this.WarehouseTotal_Title.Left = 2.875F;
            this.WarehouseTotal_Title.MultiLine = false;
            this.WarehouseTotal_Title.Name = "WarehouseTotal_Title";
            this.WarehouseTotal_Title.OutputFormat = resources.GetString("WarehouseTotal_Title.OutputFormat");
            this.WarehouseTotal_Title.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 11.25pt; font-" +
                "family: �l�r ����; vertical-align: top; ";
            this.WarehouseTotal_Title.Text = "�q�Ɍv";
            this.WarehouseTotal_Title.Top = 0F;
            this.WarehouseTotal_Title.Width = 0.563F;
            // 
            // WareInventStockCount_TextBox
            // 
            this.WareInventStockCount_TextBox.Border.BottomColor = System.Drawing.Color.Black;
            this.WareInventStockCount_TextBox.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WareInventStockCount_TextBox.Border.LeftColor = System.Drawing.Color.Black;
            this.WareInventStockCount_TextBox.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WareInventStockCount_TextBox.Border.RightColor = System.Drawing.Color.Black;
            this.WareInventStockCount_TextBox.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WareInventStockCount_TextBox.Border.TopColor = System.Drawing.Color.Black;
            this.WareInventStockCount_TextBox.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WareInventStockCount_TextBox.DataField = "InventoryStockCnt";
            this.WareInventStockCount_TextBox.Height = 0.125F;
            this.WareInventStockCount_TextBox.Left = 4.563F;
            this.WareInventStockCount_TextBox.MultiLine = false;
            this.WareInventStockCount_TextBox.Name = "WareInventStockCount_TextBox";
            this.WareInventStockCount_TextBox.OutputFormat = resources.GetString("WareInventStockCount_TextBox.OutputFormat");
            this.WareInventStockCount_TextBox.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: �l�r �S�V�b�N; vertical-align: top; ";
            this.WareInventStockCount_TextBox.SummaryGroup = "WarehouseHeader";
            this.WareInventStockCount_TextBox.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.WareInventStockCount_TextBox.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.WareInventStockCount_TextBox.Text = "123,456.99";
            this.WareInventStockCount_TextBox.Top = 0F;
            this.WareInventStockCount_TextBox.Width = 0.6F;
            // 
            // textBox5
            // 
            this.textBox5.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox5.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox5.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox5.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox5.Border.RightColor = System.Drawing.Color.Black;
            this.textBox5.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox5.Border.TopColor = System.Drawing.Color.Black;
            this.textBox5.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox5.Height = 0.1875F;
            this.textBox5.Left = 4.53125F;
            this.textBox5.MultiLine = false;
            this.textBox5.Name = "textBox5";
            this.textBox5.OutputFormat = resources.GetString("textBox5.OutputFormat");
            this.textBox5.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8.25pt; font-f" +
                "amily: �l�r ����; vertical-align: top; ";
            this.textBox5.Text = "(";
            this.textBox5.Top = 0F;
            this.textBox5.Width = 0.125F;
            // 
            // textBox6
            // 
            this.textBox6.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox6.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox6.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox6.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox6.Border.RightColor = System.Drawing.Color.Black;
            this.textBox6.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox6.Border.TopColor = System.Drawing.Color.Black;
            this.textBox6.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox6.Height = 0.1875F;
            this.textBox6.Left = 5.146F;
            this.textBox6.MultiLine = false;
            this.textBox6.Name = "textBox6";
            this.textBox6.OutputFormat = resources.GetString("textBox6.OutputFormat");
            this.textBox6.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8.25pt; font-f" +
                "amily: �l�r ����; vertical-align: top; ";
            this.textBox6.Text = ")";
            this.textBox6.Top = 0F;
            this.textBox6.Width = 0.125F;
            // 
            // MakerHeader
            // 
            this.MakerHeader.CanShrink = true;
            this.MakerHeader.Height = 0F;
            this.MakerHeader.Name = "MakerHeader";
            this.MakerHeader.NewPage = DataDynamics.ActiveReports.NewPage.Before;
            this.MakerHeader.RepeatStyle = DataDynamics.ActiveReports.RepeatStyle.OnPage;
            // 
            // MakerFooter
            // 
            this.MakerFooter.CanShrink = true;
            this.MakerFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.Line5,
            this.MakerTotal_Title,
            this.MakerTotal_TextBox});
            this.MakerFooter.Height = 0F;
            this.MakerFooter.KeepTogether = true;
            this.MakerFooter.Name = "MakerFooter";
            this.MakerFooter.Visible = false;
            this.MakerFooter.AfterPrint += new System.EventHandler(this.MakerFooter_AfterPrint);
            // 
            // Line5
            // 
            this.Line5.Border.BottomColor = System.Drawing.Color.Black;
            this.Line5.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line5.Border.LeftColor = System.Drawing.Color.Black;
            this.Line5.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line5.Border.RightColor = System.Drawing.Color.Black;
            this.Line5.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line5.Border.TopColor = System.Drawing.Color.Black;
            this.Line5.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line5.Height = 0F;
            this.Line5.Left = 0F;
            this.Line5.LineWeight = 2F;
            this.Line5.Name = "Line5";
            this.Line5.Top = 0F;
            this.Line5.Width = 7.677F;
            this.Line5.X1 = 0F;
            this.Line5.X2 = 7.677F;
            this.Line5.Y1 = 0F;
            this.Line5.Y2 = 0F;
            // 
            // MakerTotal_Title
            // 
            this.MakerTotal_Title.Border.BottomColor = System.Drawing.Color.Black;
            this.MakerTotal_Title.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakerTotal_Title.Border.LeftColor = System.Drawing.Color.Black;
            this.MakerTotal_Title.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakerTotal_Title.Border.RightColor = System.Drawing.Color.Black;
            this.MakerTotal_Title.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakerTotal_Title.Border.TopColor = System.Drawing.Color.Black;
            this.MakerTotal_Title.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakerTotal_Title.Height = 0.15625F;
            this.MakerTotal_Title.Left = 5.5F;
            this.MakerTotal_Title.MultiLine = false;
            this.MakerTotal_Title.Name = "MakerTotal_Title";
            this.MakerTotal_Title.OutputFormat = resources.GetString("MakerTotal_Title.OutputFormat");
            this.MakerTotal_Title.Style = "ddo-char-set: 1; text-align: left; font-weight: normal; font-size: 10.8pt; font-f" +
                "amily: �l�r ����; vertical-align: top; ";
            this.MakerTotal_Title.Text = "���[�J�[�v";
            this.MakerTotal_Title.Top = 0F;
            this.MakerTotal_Title.Width = 0.9999993F;
            // 
            // MakerTotal_TextBox
            // 
            this.MakerTotal_TextBox.Border.BottomColor = System.Drawing.Color.Black;
            this.MakerTotal_TextBox.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakerTotal_TextBox.Border.LeftColor = System.Drawing.Color.Black;
            this.MakerTotal_TextBox.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakerTotal_TextBox.Border.RightColor = System.Drawing.Color.Black;
            this.MakerTotal_TextBox.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakerTotal_TextBox.Border.TopColor = System.Drawing.Color.Black;
            this.MakerTotal_TextBox.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakerTotal_TextBox.DataField = "StockCnt";
            this.MakerTotal_TextBox.Height = 0.125F;
            this.MakerTotal_TextBox.Left = 6.375F;
            this.MakerTotal_TextBox.MultiLine = false;
            this.MakerTotal_TextBox.Name = "MakerTotal_TextBox";
            this.MakerTotal_TextBox.OutputFormat = resources.GetString("MakerTotal_TextBox.OutputFormat");
            this.MakerTotal_TextBox.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: �l�r �S�V�b�N; vertical-align: top; ";
            this.MakerTotal_TextBox.SummaryGroup = "MakerHeader";
            this.MakerTotal_TextBox.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.MakerTotal_TextBox.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.MakerTotal_TextBox.Text = "12345678";
            this.MakerTotal_TextBox.Top = 0F;
            this.MakerTotal_TextBox.Width = 0.8125F;
            // 
            // GoodsHeader
            // 
            this.GoodsHeader.CanShrink = true;
            this.GoodsHeader.Height = 0F;
            this.GoodsHeader.Name = "GoodsHeader";
            this.GoodsHeader.NewPage = DataDynamics.ActiveReports.NewPage.Before;
            this.GoodsHeader.RepeatStyle = DataDynamics.ActiveReports.RepeatStyle.OnPage;
            // 
            // GoodsFooter
            // 
            this.GoodsFooter.CanShrink = true;
            this.GoodsFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.Line44,
            this.GoodsTotal_Title,
            this.GoosTotal_TextBox});
            this.GoodsFooter.Height = 0F;
            this.GoodsFooter.KeepTogether = true;
            this.GoodsFooter.Name = "GoodsFooter";
            this.GoodsFooter.Visible = false;
            this.GoodsFooter.AfterPrint += new System.EventHandler(this.GoodsFooter_AfterPrint);
            // 
            // Line44
            // 
            this.Line44.Border.BottomColor = System.Drawing.Color.Black;
            this.Line44.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line44.Border.LeftColor = System.Drawing.Color.Black;
            this.Line44.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line44.Border.RightColor = System.Drawing.Color.Black;
            this.Line44.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line44.Border.TopColor = System.Drawing.Color.Black;
            this.Line44.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line44.Height = 0F;
            this.Line44.Left = 0F;
            this.Line44.LineWeight = 2F;
            this.Line44.Name = "Line44";
            this.Line44.Top = 0F;
            this.Line44.Width = 7.677F;
            this.Line44.X1 = 0F;
            this.Line44.X2 = 7.677F;
            this.Line44.Y1 = 0F;
            this.Line44.Y2 = 0F;
            // 
            // GoodsTotal_Title
            // 
            this.GoodsTotal_Title.Border.BottomColor = System.Drawing.Color.Black;
            this.GoodsTotal_Title.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsTotal_Title.Border.LeftColor = System.Drawing.Color.Black;
            this.GoodsTotal_Title.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsTotal_Title.Border.RightColor = System.Drawing.Color.Black;
            this.GoodsTotal_Title.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsTotal_Title.Border.TopColor = System.Drawing.Color.Black;
            this.GoodsTotal_Title.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsTotal_Title.Height = 0.15625F;
            this.GoodsTotal_Title.Left = 5.75F;
            this.GoodsTotal_Title.MultiLine = false;
            this.GoodsTotal_Title.Name = "GoodsTotal_Title";
            this.GoodsTotal_Title.OutputFormat = resources.GetString("GoodsTotal_Title.OutputFormat");
            this.GoodsTotal_Title.Style = "ddo-char-set: 1; text-align: left; font-weight: normal; font-size: 10.8pt; font-f" +
                "amily: �l�r ����; vertical-align: top; ";
            this.GoodsTotal_Title.Text = "���i�v";
            this.GoodsTotal_Title.Top = 0F;
            this.GoodsTotal_Title.Width = 0.5625F;
            // 
            // GoosTotal_TextBox
            // 
            this.GoosTotal_TextBox.Border.BottomColor = System.Drawing.Color.Black;
            this.GoosTotal_TextBox.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoosTotal_TextBox.Border.LeftColor = System.Drawing.Color.Black;
            this.GoosTotal_TextBox.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoosTotal_TextBox.Border.RightColor = System.Drawing.Color.Black;
            this.GoosTotal_TextBox.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoosTotal_TextBox.Border.TopColor = System.Drawing.Color.Black;
            this.GoosTotal_TextBox.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoosTotal_TextBox.DataField = "StockCnt";
            this.GoosTotal_TextBox.Height = 0.125F;
            this.GoosTotal_TextBox.Left = 6.4375F;
            this.GoosTotal_TextBox.MultiLine = false;
            this.GoosTotal_TextBox.Name = "GoosTotal_TextBox";
            this.GoosTotal_TextBox.OutputFormat = resources.GetString("GoosTotal_TextBox.OutputFormat");
            this.GoosTotal_TextBox.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: �l�r �S�V�b�N; vertical-align: top; ";
            this.GoosTotal_TextBox.SummaryGroup = "GoodsHeader";
            this.GoosTotal_TextBox.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.GoosTotal_TextBox.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.GoosTotal_TextBox.Text = "12,345,678.90";
            this.GoosTotal_TextBox.Top = 0F;
            this.GoosTotal_TextBox.Width = 0.8125F;
            // 
            // MAZAI02112P_01A4C
            // 
            this.MasterReport = false;
            this.PageSettings.DefaultPaperSize = false;
            this.PageSettings.Margins.Bottom = 0.2F;
            this.PageSettings.Margins.Left = 0.2F;
            this.PageSettings.Margins.Right = 0.2F;
            this.PageSettings.Margins.Top = 0.2F;
            this.PageSettings.Orientation = DataDynamics.ActiveReports.Document.PageOrientation.Portrait;
            this.PageSettings.PaperHeight = 11.69291F;
            this.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.A4;
            this.PageSettings.PaperWidth = 8.267716F;
            this.PrintWidth = 7.677083F;
            this.Sections.Add(this.PageHeader);
            this.Sections.Add(this.ExtraHeader);
            this.Sections.Add(this.TitleHeader);
            this.Sections.Add(this.GrandTotalHeader);
            this.Sections.Add(this.SectionHeader);
            this.Sections.Add(this.WarehouseHeader);
            this.Sections.Add(this.MakerHeader);
            this.Sections.Add(this.GoodsHeader);
            this.Sections.Add(this.Detail);
            this.Sections.Add(this.GoodsFooter);
            this.Sections.Add(this.MakerFooter);
            this.Sections.Add(this.WarehouseFooter);
            this.Sections.Add(this.SectionFooter);
            this.Sections.Add(this.GrandTotalFooter);
            this.Sections.Add(this.TitleFooter);
            this.Sections.Add(this.ExtraFooter);
            this.Sections.Add(this.PageFooter);
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule(resources.GetString("$this.StyleSheet"), "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: inherit; font-style: inherit; font-variant: inherit; font-weight: bo" +
                        "ld; font-size: 16pt; font-size-adjust: inherit; font-stretch: inherit; ", "Heading1", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: Times New Roman; font-style: italic; font-variant: inherit; font-wei" +
                        "ght: bold; font-size: 14pt; font-size-adjust: inherit; font-stretch: inherit; ", "Heading2", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: inherit; font-style: inherit; font-variant: inherit; font-weight: bo" +
                        "ld; font-size: 13pt; font-size-adjust: inherit; font-stretch: inherit; ", "Heading3", "Normal"));
            this.PageEnd += new System.EventHandler(this.MAZAI02112P_01A4C_PageEnd);
            this.ReportStart += new System.EventHandler(this.MAZAI02112P_01A4C_ReportStart);
            ((System.ComponentModel.ISupportInitialize)(this.StockCount_TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsName_TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StockUnitPrice_TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsNo_TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WarehouseShelfNo_TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.InventStockCount_TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MakerCode_TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupplierCd_TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BLGoodsCode_TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BLGroupCode_TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.InventorySeqNo_TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BlankShowFlag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.InvStockCntFlag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Warehouse_TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WarehouseCode_TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PrintDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PRINTPAGE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SortTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PrintTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PageFooters0)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PageFooters1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsNo_Title)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StockUnitPrice_Title)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsName_Title)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StockCount_Title)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WarehouseShelfNo_Title)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.InventStockCount_Title)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.InventorySeqNo_Title)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Maker_Title)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupplierCd_Title)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BLGoodsCode_Title)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BLGroupCode_Title)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrandTotal_Title)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrandStockCount_TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrandInventStockCount_TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StockSectionName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StockSectionCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WareStockCount_TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WarehouseTotal_Title)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WareInventStockCount_TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MakerTotal_Title)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MakerTotal_TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsTotal_Title)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoosTotal_TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

		 }

		#endregion   

         /// <summary>
         /// ���׃A�t�^�[�v�����g�C�x���g
         /// </summary>
         /// <param name="sender">�C�x���g�\�[�X</param>
         /// <param name="eArgs">�C�x���g�f�[�^</param>
         /// <remarks>
         /// <br>Note        : �Z�N�V�������y�[�W�ɕ`�悳�ꂽ��ɔ������܂��B</br>
         /// <br>Programmer  : ���M</br>
         /// <br>Date        : 2009.12.07</br>
         /// </remarks>
        private void Detail_Format(object sender, EventArgs e)
        {
            // �d���I��1,�d���I��2�ꍇ�A�I�����A���P���A�������͋󔒂ł�
            if (1 == (int)this.BlankShowFlag.Value)
            {
                this.StockCount_TextBox.Text = string.Empty;
                this.InventStockCount_TextBox.Text = string.Empty;
                this.StockUnitPrice_TextBox.Text = string.Empty;
                this.InventorySeqNo_TextBox.Text = string.Empty;
                this.textBox1.Text = string.Empty;
                this.textBox2.Text = string.Empty;
                this.GoodsNo_TextBox.Text = string.Empty;
            }
            else
            {
                this.textBox1.Text = "(";
                this.textBox2.Text = ")";
            }
            // ----------UPD 2010/02/20---------->>>>>
            //if (0.0 == (double)this.InventStockCount_TextBox.Value)
            //{
            //    this.InventStockCount_TextBox.Text = string.Empty;
            //}
            //�I�����{��(InventoryDayRF)��NULL�̏ꍇ�A�I������������Ȃ��i�󔒁j
            if (1 == (int)this.InvStockCntFlag.Value)
            {
                this.InventStockCount_TextBox.Text = string.Empty;
            }
            // ----------UPD 2010/02/20----------<<<<<
        }

        /// <summary>
        /// WarehouseFooter_BeforePrint�C�x���g
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>
        /// <param name="e">�C�x���g�f�[�^</param>
        /// <remarks>
        /// <br>Note		: �Z�N�V�������y�[�W�ɕ`�悳���O�ɔ������܂��B</br>
        /// <br>Programmer  : ������</br>                                   
        /// <br>Date        : 2010/02/20</br>                                       
        /// </remarks>
        private void WarehouseFooter_BeforePrint(object sender, EventArgs e)
        {
            // Wordrap�v���p�e�B�ŕ��������r���[�ȂƂ���ŋ�؂��Ȃ��悤�ɂ��邽�߂̑Ή�
            PrintCommonLibrary.ConvertReportString(this.WarehouseFooter);

        }

        /// <summary>
        /// GrandTotalFooter_BeforePrint�C�x���g
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>
        /// <param name="e">�C�x���g�f�[�^</param>
        /// <remarks>
        /// <br>Note		: �Z�N�V�������y�[�W�ɕ`�悳���O�ɔ������܂��B</br>
        /// <br>Programmer  : ������</br>                                   
        /// <br>Date        : 2010/02/20</br>                                       
        /// </remarks>
        private void GrandTotalFooter_BeforePrint(object sender, EventArgs e)
        {
            // Wordrap�v���p�e�B�ŕ��������r���[�ȂƂ���ŋ�؂��Ȃ��悤�ɂ��邽�߂̑Ή�
            PrintCommonLibrary.ConvertReportString(this.GrandTotalFooter);

        }
    }
}
