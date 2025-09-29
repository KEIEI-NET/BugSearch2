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
	/// �I���\���(�Ȉ�)�t�H�[���N���X
	/// </summary>
	/// <remarks>
	/// <br>Note		: �I���\�̃t�H�[���N���X�ł��B</br>
	/// <br>Programmer	: 23010�@�����@�m</br>
	/// <br>Date		: 2007.04.11</br>
    /// <br>Update Note : 2007.09.05 980035 ���� ��`</br>
    /// <br>			  �EDC.NS�Ή�</br>
    /// <br>Update Note : 2008.02.13 980035 ���� ��`</br>
    /// <br>			  �E�s��Ή��iDC.NS�Ή��j</br>
    /// -----------------------------------------------------------------------------------
    /// <br>UpdateNote  : PM.NS�Ή�</br>
    /// <br>Programmer  : 30413 ����</br>
    /// <br>Date	    : 2008.10.07</br>
    /// -----------------------------------------------------------------------------------
    /// <br>UpdateNote  : MANTIS�Ή�(13918)</br>
    /// <br>Programmer  : 22008 ����</br>
    /// <br>Date	    : 2009/09/16</br>
    /// -----------------------------------------------------------------------------------
    /// <br>UpdateNote  : 2013/01/16�z�M���ARedmine#33271 �󎚐���̋敪�̒ǉ�</br>
    /// <br>Programmer  : ������</br>
    /// <br>Date	    : 2012/11/14</br>
    /// </remarks>
	public class MAZAI02112P_05A4C : DataDynamics.ActiveReports.ActiveReport3,IPrintActiveReportTypeList, IPrintActiveReportTypeCommon
    {
        #region Constructor
        /// <summary>
		/// �I���\(�Ȉ�)�t�H�[���N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
		/// <br>Note		: �I���\(�Ȉ�)�t�H�[���N���X�̐V�����C���X�^���X�����������܂��B</br>
		/// <br>Programmer	: 23010�@�����@�m</br>
		/// <br>Date		: 2007.04.11</br>
		/// </remarks>
		public MAZAI02112P_05A4C()
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
        // 2009.02.17 30413 ���� �O���[�v�T�v���X�����ǉ� >>>>>>START
        private string _groupSuppres = "";
        // 2009.02.17 30413 ���� �O���[�v�T�v���X�����ǉ� <<<<<<END
        private TextBox StockSectionCode;
        private Label SupplierCd_Title;
        private Label BLGoodsCode_Title;
        private Label BLGroupCode_Title;
        private Label label6;
        private TextBox BLGroupCode_TextBox;
        private Line line3;
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
		/// <br>Date       : 2007.04.11</br>
        /// <br>Update Note: 2012/11/14 ������</br>
        ///	<br>			 Redmine#33271 �󎚐���̋敪�̒ǉ�</br>
		/// </remarks>
		private void SetOfReportMembersOutput()
		{
            // ���ڂ̖��̂��Z�b�g
            SortTitle.Text = this._pageHeaderSortOderTitle;	// �\�[�g����

            // 2008.02.13 �C�� >>>>>>>>>>>>>>>>>>>>
            ////���o�Ώۓ��敪�ɂ���ă^�C�g����ύX����
            ////���̂Ƃ����1���Œ�ő�����Ă��邽�߁A�I���\��\�����łȂ�
            ////0:�I������������,1:�I�����{��,2:�I���X�V��
            //switch(this._extrInfo.TargetDateExtraDiv)
            //{
            //    //�I������������
            //    case 0:
            //    {
            //        //�����͎g�p����Ȃ�
            //        //���[�^�C�g����I���\��\�ɂ���
            //        this.Title_Label.Text = "�I���\��\(�Ȉ�)";
            //        //���t�^�C�g����I��������������
            //        this.InventoryDate_Title.Text = "����������";
            //        //�I�����̍��ڂɒI�����{�����Z�b�g
            //        this.InventoryDay_TextBox.DataField = "InventoryPreprDay_Print";
            //        break;
            //    }
            //    //�I����
            //    case 1:
            //    {
            //        //2007/07/23 H.NAKAMURA �I���\��\���I���\�ɕύX
            //        //���[�^�C�g����I���\��\�ɂ���
            //        //this.Title_Label.Text = "�I���\��\(�Ȉ�)";
            //        this.Title_Label.Text = "�I���\(�Ȉ�)";
            //        //���t�^�C�g����I��������������
            //        this.InventoryDate_Title.Text = "�I����";
            //        //�I�����̍��ڂɒI�����{�����Z�b�g
            //        this.InventoryDay_TextBox.DataField = "InventoryDay_Print";
            //        break;
            //    }
            //    //�I���X�V��
            //    case 2:
            //    {
            //        //���[�^�C�g����I���\��\�ɂ���
            //        this.Title_Label.Text = "�I���\(�Ȉ�)";
            //        //���t�^�C�g����I��������������
            //        this.InventoryDate_Title.Text = "�I���X�V��";
            //        //�I�����̍��ڂɒI�����{�����Z�b�g
            //        this.InventoryDay_TextBox.DataField = "InventoryUpDate_Print";
            //        break;
            //    }

            //}
            //this.Title_Label.Text = "�I���\(�Ȉ�)";
            // 2008.02.13 �C�� <<<<<<<<<<<<<<<<<<<<

            // 2008.11.27 30413 ���� �o�͏�������C�� >>>>>>START
            // 2008.11.04 30413 ���� ���Ő�����C�� >>>>>>START
            // 2007.09.05 �ǉ� >>>>>>>>>>>>>>>>>>>>
            // ���y�[�W�w��敪
            if (this._extrInfo.TurnOoverThePagesDiv == 2)
            {
                // ���y�[�W�Ȃ�
                //this.WarehouseHeader.DataField = "";
                this.WarehouseHeader.NewPage = NewPage.None;
                this.SubTotalHeader.NewPage = NewPage.None;
            }
            //else if (this._extrInfo.TurnOoverThePagesDiv == 1)
            else
            {
                if (this._extrInfo.TurnOoverThePagesDiv == 1)
                {
                    // ���v
                    this.SubTotalHeader.NewPage = NewPage.Before;
                }
                else
                {
                    // �q��
                    this.SubTotalHeader.NewPage = NewPage.None;
                }

                //// �o�͏�
                //if (this._extrInfo.SortDiv == 0)
                //{
                //    // �q�Ɂ��I��
                //    this.SubTotalHeader.DataField = "WarehouseShelfNo_Print";
                //    this.SubTotal_Title.Text = "�I�Ԍv";
                //}
                //else if (this._extrInfo.SortDiv == 1)
                //{
                //    // �q�Ɂ��d����
                //    //this.MakerHeader.DataField = "CustomerCode";
                //    this.SubTotalHeader.DataField = "SupplierCd";
                //    this.SubTotal_Title.Text = "�d����v";
                //}
                //else if (this._extrInfo.SortDiv == 2)
                //{
                //    // �q�Ɂ��a�k�R�[�h
                //    this.SubTotalHeader.DataField = "BLGoodsCode";
                //    this.SubTotal_Title.Text = "BL���ތv";
                //}
                //else if (this._extrInfo.SortDiv == 3)
                //{
                //    //// �q�Ɂ����[�J�[
                //    //this.MakerHeader.DataField = "MakerCode";
                //    //this.MakerTotal_Title.Text = "Ұ���v";
                //    // �q�Ɂ��O���[�v
                //    this.SubTotalHeader.DataField = "BLGroupCode";
                //    this.SubTotal_Title.Text = "��ٰ�ߌv";
                //}
                //else if (this._extrInfo.SortDiv == 4)
                //{
                //    //// �q�Ɂ��d���恨�I��
                //    //this.MakerHeader.DataField = "CustomerCode";
                //    //this.GoodsHeader.DataField = "WarehouseShelfNo_Print";
                //    // �q�Ɂ����[�J�[
                //    this.SubTotalHeader.DataField = "GoodsMakerCd";
                //    this.SubTotal_Title.Text = "Ұ���v";
                //}
                //else if (this._extrInfo.SortDiv == 5)
                //{
                //    //// �q�Ɂ��d���恨���[�J�[
                //    //this.MakerHeader.DataField = "CustomerCode";
                //    //this.GoodsHeader.DataField = "MakerCode";
                //    // �q�Ɂ��d����
                //    this.SubTotalHeader.DataField = "SupplierCd";
                //    this.SubTotal_Title.Text = "�d����v";
                //}
                //else if (this._extrInfo.SortDiv == 6)
                //{
                //    //// �q�Ɂ��d���恨���[�J�[
                //    //this.MakerHeader.DataField = "CustomerCode";
                //    //this.GoodsHeader.DataField = "MakerCode";
                //    // �q�Ɂ��d����
                //    this.SubTotalHeader.DataField = "SupplierCd";
                //    this.SubTotal_Title.Text = "�d����v";
                //}
            }
            // 2007.09.05 �ǉ� <<<<<<<<<<<<<<<<<<<<
            // 2008.11.04 30413 ���� ���Ő�����C�� <<<<<<END

            // �o�͏�
            if (this._extrInfo.SortDiv == 0)
            {
                // �q�Ɂ��I��
                this.SubTotalHeader.DataField = "WarehouseShelfNo_Print";
                this.SubTotal_Title.Text = "�I�Ԍv";
            }
            else if (this._extrInfo.SortDiv == 1)
            {
                // �q�Ɂ��d����
                this.SubTotalHeader.DataField = "SupplierCd";
                this.SubTotal_Title.Text = "�d����v";
            }
            else if (this._extrInfo.SortDiv == 2)
            {
                // �q�Ɂ��a�k�R�[�h
                this.SubTotalHeader.DataField = "BLGoodsCode";
                this.SubTotal_Title.Text = "BL���ތv";
            }
            else if (this._extrInfo.SortDiv == 3)
            {
                // �q�Ɂ��O���[�v
                this.SubTotalHeader.DataField = "BLGroupCode";
                this.SubTotal_Title.Text = "��ٰ�ߌv";
            }
            else if (this._extrInfo.SortDiv == 4)
            {
                // �q�Ɂ����[�J�[
                this.SubTotalHeader.DataField = "GoodsMakerCd";
                this.SubTotal_Title.Text = "Ұ���v";
            }
            else if (this._extrInfo.SortDiv == 5)
            {
                // �q�Ɂ��d����
                this.SubTotalHeader.DataField = "SupplierCd";
                this.SubTotal_Title.Text = "�d����v";
            }
            else if (this._extrInfo.SortDiv == 6)
            {
                // �q�Ɂ��d����
                this.SubTotalHeader.DataField = "SupplierCd";
                this.SubTotal_Title.Text = "�d����v";
            }
            // 2008.11.27 30413 ���� �o�͏�������C�� <<<<<<END
            
            // 2008.11.04 30413 ���� ���v�󎚐��� >>>>>>START
            // ���v��
            if (this._extrInfo.SubtotalPrintDiv == 0)
            {
                // ���v�󎚂���
                this.SubTotalFooter.Visible = true;
            }
            else
            {
                // ���v�󎚂��Ȃ�
                this.SubTotalFooter.Visible = false;
            }
            // 2008.11.04 30413 ���� ���v�󎚐��� <<<<<<END
            // --- ADD ������ 2012/11/14 for Redmine#33271---------->>>>>
            //�r���󎚋敪
            if (this._extrInfo.LineMaSqOfChDiv == 0)
            {
                //�r���󎚂���
                this.Line.Visible = true;
                this.Line2.Visible = true;
                this.line3.Visible = true;
                this.Line37.Visible = true;
                this.Line44.Visible = true;
                this.Line5.Visible = true;
                this.line6.Visible = false;
            }
            else
            {
                //�r���󎚂��Ȃ�
                this.Line.Visible = false;
                this.Line2.Visible = false;
                this.line3.Visible = false;
                this.Line37.Visible = false;
                this.Line44.Visible = false;
                this.Line5.Visible = false;
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
        /// <br>Note      : �o�͏��ɍ��킹�āA�󎚃p�^�[����ύX���܂�</br>
        /// <br>Programer : 30413 ����</br>
        /// <br>Date      : 2008.10.14</br>
        /// </remarks>
        private void SetOutputPrintPattern()
        {
            switch (this._extrInfo.SortDiv)
            {
                case 1:     // �d���揇
                case 5:     // �d����E�I�ԏ�
                    {
                        // ���׃^�C�g��
                        SupplierCd_Title.Left = 0.0F;               // �d����
                        WarehouseShelfNo_Title.Left = 0.5F;         // �I��
                        GoodsNo_Title.Left = 1.063F;              // �i��
                        GoodsName_Title.Left = 2.5F;                // �i��
                        BLGoodsCode_Title.Left = 3.75F;             // BL�R�[�h
                        BLGroupCode_Title.Left = 4.25F;             // �O���[�v�R�[�h
                        Maker_Title.Left = 4.75F;                   // ���[�J�[

                        // ���׍s
                        SupplierCd_TextBox.Left = 0.0F;             // �d����
                        WarehouseShelfNo_TextBox.Left = 0.5F;       // �I��
                        GoodsNo_TextBox.Left = 1.063F;            // �i��
                        GoodsName_TextBox.Left = 2.5F;              // �i��
                        BLGoodsCode_TextBox.Left = 3.75F;           // BL�R�[�h
                        BLGroupCode_TextBox.Left = 4.25F;           // �O���[�v�R�[�h
                        MakerCode_TextBox.Left = 4.75F;             // ���[�J�[
                        break;
                    }
                case 2:     // BL�R�[�h��
                    {
                        // ���׃^�C�g��
                        BLGoodsCode_Title.Left = 0.0F;              // BL�R�[�h
                        WarehouseShelfNo_Title.Left = 0.5F;         // �I��
                        GoodsNo_Title.Left = 1.063F;              // �i��
                        GoodsName_Title.Left = 2.5F;                // �i��
                        SupplierCd_Title.Left = 3.75F;              // �d����
                        BLGroupCode_Title.Left = 4.25F;             // �O���[�v�R�[�h
                        Maker_Title.Left = 4.75F;                   // ���[�J�[

                        // ���׍s
                        BLGoodsCode_TextBox.Left = 0.0F;            // BL�R�[�h
                        WarehouseShelfNo_TextBox.Left = 0.5F;       // �I��
                        GoodsNo_TextBox.Left = 1.063F;            // �i��
                        GoodsName_TextBox.Left = 2.5F;              // �i��
                        SupplierCd_TextBox.Left = 3.75F;            // �d����
                        BLGroupCode_TextBox.Left = 4.25F;           // �O���[�v�R�[�h
                        MakerCode_TextBox.Left = 4.75F;             // ���[�J�[
                        break;
                    }
                case 3:     // �O���[�v�R�[�h��
                    {
                        // ���׃^�C�g��
                        BLGroupCode_Title.Left = 0.0F;              // �O���[�v�R�[�h
                        WarehouseShelfNo_Title.Left = 0.5F;         // �I��
                        GoodsNo_Title.Left = 1.063F;              // �i��
                        GoodsName_Title.Left = 2.5F;                // �i��
                        SupplierCd_Title.Left = 3.75F;              // �d����
                        BLGoodsCode_Title.Left = 4.25F;             // BL�R�[�h
                        Maker_Title.Left = 4.75F;                   // ���[�J�[

                        // ���׍s
                        BLGroupCode_TextBox.Left = 0.0F;            // �O���[�v�R�[�h
                        WarehouseShelfNo_TextBox.Left = 0.5F;       // �I��
                        GoodsNo_TextBox.Left = 1.063F;            // �i��
                        GoodsName_TextBox.Left = 2.5F;              // �i��
                        SupplierCd_TextBox.Left = 3.75F;            // �d����
                        BLGoodsCode_TextBox.Left = 4.25F;           // BL�R�[�h
                        MakerCode_TextBox.Left = 4.75F;             // ���[�J�[
                        break;
                    }
                case 4:     // ���[�J�[��
                    {
                        // ���׃^�C�g��
                        Maker_Title.Left = 0.0F;                    // ���[�J�[
                        WarehouseShelfNo_Title.Left = 0.375F;       // �I��
                        GoodsNo_Title.Left = 0.938F;              // �i��
                        GoodsName_Title.Left = 2.375F;              // �i��
                        SupplierCd_Title.Left = 3.625F;             // �d����
                        BLGoodsCode_Title.Left = 4.125F;            // BL�R�[�h
                        BLGroupCode_Title.Left = 4.625F;            // �O���[�v�R�[�h
                        
                        // ���׍s
                        MakerCode_TextBox.Left = 0.0F;              // ���[�J�[
                        WarehouseShelfNo_TextBox.Left = 0.375F;     // �I��
                        GoodsNo_TextBox.Left = 0.938F;            // �i��
                        GoodsName_TextBox.Left = 2.375F;            // �i��
                        SupplierCd_TextBox.Left = 3.625F;           // �d����
                        BLGoodsCode_TextBox.Left = 4.125F;          // BL�R�[�h
                        BLGroupCode_TextBox.Left = 4.625F;          // �O���[�v�R�[�h
                        break;
                    }
                case 6:     // �d����E���[�J�[��
                    {
                        // ���׃^�C�g��
                        SupplierCd_Title.Left = 0.0F;               // �d����
                        Maker_Title.Left = 0.5F;                    // ���[�J�[
                        WarehouseShelfNo_Title.Left = 0.875F;       // �I��
                        GoodsNo_Title.Left = 1.438F;              // �i��
                        GoodsName_Title.Left = 2.875F;              // �i��
                        BLGoodsCode_Title.Left = 4.125F;            // BL�R�[�h
                        BLGroupCode_Title.Left = 4.625F;            // �O���[�v�R�[�h

                        // ���׍s
                        SupplierCd_TextBox.Left = 0.0F;             // �d����
                        MakerCode_TextBox.Left = 0.5F;              // ���[�J�[
                        WarehouseShelfNo_TextBox.Left = 0.875F;     // �I��
                        GoodsNo_TextBox.Left = 1.438F;            // �i��
                        GoodsName_TextBox.Left = 2.875F;            // �i��
                        BLGoodsCode_TextBox.Left = 4.125F;          // BL�R�[�h
                        BLGroupCode_TextBox.Left = 4.625F;          // �O���[�v�R�[�h
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
        }
        #endregion


        #region �o�b�t�@�N���A����
        /// <summary>
        /// �o�b�t�@�N���A����
        /// </summary>
        /// <remarks>
        /// <br>Note      : �O���[�v�T�v���X�p�̃o�b�t�@�����������܂�</br>
        /// <br>Programer : 23010 �����@�m</br>
        /// <br>Date      : 2007.04.11</br>
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

            // 2009.02.17 30413 ���� �O���[�v�T�v���X�����ǉ� >>>>>>START
            this._groupSuppres = "";
            // 2009.02.17 30413 ���� �O���[�v�T�v���X�����ǉ� <<<<<<END
        }

        #endregion

        #region �O���[�v�T�v���X����
        /// <summary>
        /// �O���[�v�T�v���X����
        /// </summary>
        /// <remarks>
        /// <br>Note      : �O���[�v�T�v���X�������s���܂�</br>
        /// <br>Programer : 23010 �����@�m</br>
        /// <br>Date      : 2007.04.11</br>
        /// </remarks>    
        private void SetOfGroupSuppres()
        {
            // 2009.02.17 30413 ���� ���g�p�Ȃ̂ō폜 >>>>>>START
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
            //
            ////�O���[�v�T�v���X����(���i�啪��)
            //if(this.LgGoosCode_TextBox.Text != null)
            //{
            //    if(this.LgGoosCode_TextBox.Text.CompareTo(this._largeGoodsBuff) == 0)
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
            //    if(this._largeGoodsBuff == string.Empty)
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
            //if(this.MdGoodsCode_TextBox.Text != null)
            //{
            //    if(this.MdGoodsCode_TextBox.Text.CompareTo(this._mediumGoodsBuff) == 0)
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
            //     //��O�I�ȏꍇ
            //    //null�̏ꍇ�͋󕶎��ƌ��Ȃ�
            //    if(this._mediumGoodsBuff == string.Empty)
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
            //�O���[�v�T�v���X����(�I��)
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
            // 2009.02.17 30413 ���� ���g�p�Ȃ̂ō폜 <<<<<<END
            
            // 2009.02.17 30413 ���� �O���[�v�T�v���X�����ǉ� >>>>>>START
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
            // 2009.02.17 30413 ���� �O���[�v�T�v���X�����ǉ� <<<<<<END

            // 2008.10.14 30413 ���� ���[�J�[���̍폜 >>>>>>START
            //if(this.MakerCode_TextBox.Text != null)
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
            // 2008.10.14 30413 ���� ���[�J�[���̍폜 <<<<<<END
            
        }

        /// <summary>
        /// �O���[�v�T�v���X�ݒ菈��
        /// </summary>
        /// <remarks>
        /// <br>Note      : �O���[�v�T�v���X�̃`�F�b�N�Ɛݒ���s���܂��B</br>
        /// <br>Programer : 30413 ����</br>
        /// <br>Date      : 2009.02.17</br>
        /// </remarks>    
        private void SetSuppres(TextBox textBox)
        {
            if (textBox.Text != null)
            {
                // �o�b�t�@�Ɣ�r
                if (textBox.Text.CompareTo(this._groupSuppres) == 0)
                {
                    textBox.Visible = false;
                }
                else
                {
                    textBox.Visible = true;
                    //�o�b�t�@�X�V
                    this._groupSuppres = textBox.Text;
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
		/// <br>Date       : 2007.04.11</br>
		/// </remarks>
		private void Detail_BeforePrint(object sender, System.EventArgs eArgs)
		{
            // 2009.02.17 30413 ���� �O���[�v�T�v���X������ǉ� >>>>>>START
            // 2008.02.13 �폜 >>>>>>>>>>>>>>>>>>>>
            ////�O���[�v�T�v���X����
            SetOfGroupSuppres();
            // 2008.02.13 �폜 <<<<<<<<<<<<<<<<<<<<
            // 2009.02.17 30413 ���� �O���[�v�T�v���X������ǉ� <<<<<<END
            // Wordrap�v���p�e�B�ŕ��������r���[�ȂƂ���ŋ�؂��Ȃ��悤�ɂ��邽�߂̑Ή�
			PrintCommonLibrary.ConvertReportString(this.Detail);

            // 2008.10.14 30413 ���� �I�������͋敪�̍폜 >>>>>>START
            //// 2007.09.05 �ǉ� >>>>>>>>>>>>>>>>>>>>
            ////�I�������͋敪
            //if (this._extrInfo.InventoryInputDiv != 0)
            //{
            //    if ((this.InventoryStockCount_TextBox.Value.ToString().Trim() == "0") ||
            //        (this.InventoryStockCount_TextBox.Value.ToString().Trim() == ""))
            //    {
            //        //���됔����
            //        this.InventoryStockCount_TextBox = this.StockTotal_TextBox;
            //    }
            //}
            //// 2007.09.05 �ǉ� <<<<<<<<<<<<<<<<<<<<
            // 2008.10.14 30413 ���� �I�������͋敪�̍폜 <<<<<<END
        }

        #endregion

        #region MAZAI02112P_05A4C_PageEnd�C�x���g
        /// <summary>
		/// MAZAI02112P_05A4C_PageEnd�C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="eArgs">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note       : �P�y�[�W�̏o�͂��I�������Ƃ��ɔ�������C�x���g�ł��B</br>
		/// <br>Programmer : 23010�@�����@�m</br>
		/// <br>Date       : 2007.04.11</br>
		/// </remarks>
		private void MAZAI02112P_05A4C_PageEnd(object sender, System.EventArgs eArgs)
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
		/// <br>Date       : 2007.04.11</br>
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

            // 2008.11.27 30413 ���� ���_�͈󎚂��Ȃ� >>>>>>START
            //// 2007.09.05 �C�� >>>>>>>>>>>>>>>>>>>>
            ////// ���_�I�v�V�����L������
            ////if (this._extrInfo.IsOptSection)
            ////{
            ////    
            ////    this._rptExtraHeader.SectionCondition.Text = "�I�����_�F " + this.StockSectionName.Text;
            ////    
            ////} 
            ////else 
            ////{
            ////    this._rptExtraHeader.SectionCondition.Text = "";
            ////}
            //// 2008.02.13 �C�� >>>>>>>>>>>>>>>>>>>>
            ////this._rptExtraHeader.SectionCondition.Text = "�I�����_�F " + this.StockSectionName.Text;
            //this._rptExtraHeader.SectionCondition.Text = "�I�����_�F " + this.StockSectionCode.Text + " " + this.StockSectionName.Text;
            //// 2008.02.13 �C�� <<<<<<<<<<<<<<<<<<<<
            //// 2007.09.05 �C�� <<<<<<<<<<<<<<<<<<<<
            // 2008.11.27 30413 ���� ���_�͈󎚂��Ȃ� <<<<<<END
            
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
		/// <br>Date       : 2007.04.11</br>
		/// </remarks>
		private void PageFooter_Format(object sender, System.EventArgs eArgs)
		{
            // �t�b�^�[�o�͂���H
            if (this._pageFooterOutCode == 0)
            {
                // �C���X�^���X���쐬����Ă��Ȃ���΍쐬
                if (this._rptPageFooter == null)
                {
                    this._rptPageFooter = new ListCommon_PageFooter();
                }
                else
                {
                    // �C���X�^���X���쐬����Ă���΁A�f�[�^�\�[�X������������
                    // (�o�C���h����f�[�^�\�[�X�������f�[�^�ł����Ă��A��x���������Ă����Ȃ��Ƃ��܂��������Ȃ��B
                    this._rptPageFooter.DataSource = null;
                }

                // �t�b�^�[�󎚍��ڐݒ�
                if (this._pageFooters[0] != null)
                {
                    this._rptPageFooter.PrintFooter1 = this._pageFooters[0];
                }
                if (this._pageFooters[1] != null)
                {
                    this._rptPageFooter.PrintFooter2 = this._pageFooters[1];
                }

                this.Footer_SubReport.Report = this._rptPageFooter;
            }
        }

        #endregion

        #region MAZAI02112P_05A4C_ReportStart�C�x���g
        /// <summary>
		/// MAZAI02112P_05A4C_ReportStart�C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="eArgs">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note       : MAZAI02112P_05A4C_ReportStart�̏������C�x���g�ł��B</br>
		/// <br>Programmer : 23010�@�����@�m</br>
		/// <br>Date       : 2007.04.11</br>
		/// </remarks>
		private void MAZAI02112P_05A4C_ReportStart(object sender, System.EventArgs eArgs)
		{
			// ���|�[�g�v�f�o�͐ݒ�
			SetOfReportMembersOutput();

            // 2008.10.14 30413 ���� �󎚃p�^�[���̕ύX��ǉ� >>>>>>START
            // �o�͏��ɂ��󎚃p�^�[���ύX
            SetOutputPrintPattern();
            // 2008.10.14 30413 ���� �󎚃p�^�[���̕ύX��ǉ� <<<<<<END
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
		/// <br>Date       : 2007.04.11</br>
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
		/// <br>Date        : 2007.04.11</br>
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
		/// <br>Date       : 2007.04.11</br>
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
        ///// <br>Date       : 2007.04.11</br>
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
		/// <br>Date       : 2007.04.11</br>
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
		/// <br>Date       : 2007.04.15</br>
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
		private DataDynamics.ActiveReports.Label Title_Label;
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
		private DataDynamics.ActiveReports.Label Maker_Title;
		private DataDynamics.ActiveReports.Label GoodsNo_Title;
		private DataDynamics.ActiveReports.Line Line4;
		private DataDynamics.ActiveReports.Label StockUnitPrice_Title;
        private DataDynamics.ActiveReports.Label GoodsName_Title;
		private DataDynamics.ActiveReports.Label WarehouseShelfNo_Title;
        private DataDynamics.ActiveReports.Label StockTotalExec_Title;
        private DataDynamics.ActiveReports.Label StockPrice_Title;
		private DataDynamics.ActiveReports.GroupHeader GrandTotalHeader;
		private DataDynamics.ActiveReports.GroupHeader SectionHeader;
		private DataDynamics.ActiveReports.TextBox StockSectionName;
		private DataDynamics.ActiveReports.GroupHeader WarehouseHeader;
		private DataDynamics.ActiveReports.GroupHeader SubTotalHeader;
		private DataDynamics.ActiveReports.GroupHeader GoodsHeader;
		private DataDynamics.ActiveReports.Detail Detail;
        private DataDynamics.ActiveReports.Line Line37;
		private DataDynamics.ActiveReports.TextBox GoodsName_TextBox;
		private DataDynamics.ActiveReports.TextBox ListPrice_TextBox;
		private DataDynamics.ActiveReports.TextBox GoodsNo_TextBox;
		private DataDynamics.ActiveReports.TextBox Warehouse_TextBox;
        private DataDynamics.ActiveReports.TextBox WarehouseShelfNo_TextBox;
		private DataDynamics.ActiveReports.TextBox StockUnitPriceFl_TextBox;
        private DataDynamics.ActiveReports.TextBox StockAmountPrice_TextBox;
		private DataDynamics.ActiveReports.TextBox WarehouseCode_TextBox;
		private DataDynamics.ActiveReports.TextBox MakerCode_TextBox;
		private DataDynamics.ActiveReports.TextBox StockTotalExec_TextBox;
		private DataDynamics.ActiveReports.TextBox SupplierCd_TextBox;
		private DataDynamics.ActiveReports.TextBox BLGoodsCode_TextBox;
		private DataDynamics.ActiveReports.GroupFooter GoodsFooter;
		private DataDynamics.ActiveReports.Line Line44;
		private DataDynamics.ActiveReports.TextBox GoodsTotal_Title;
		private DataDynamics.ActiveReports.TextBox Goods_StockTotal;
		private DataDynamics.ActiveReports.TextBox GoodsTotalStockPrice_TextBox;
		private DataDynamics.ActiveReports.GroupFooter SubTotalFooter;
		private DataDynamics.ActiveReports.Line Line5;
		private DataDynamics.ActiveReports.TextBox SubTotal_Title;
		private DataDynamics.ActiveReports.TextBox Maker_StockTotal;
		private DataDynamics.ActiveReports.TextBox MakerTotalStockPrice_TextBox;
		private DataDynamics.ActiveReports.GroupFooter WarehouseFooter;
		private DataDynamics.ActiveReports.Line Line2;
		private DataDynamics.ActiveReports.TextBox WarehouseTotal_Title;
		private DataDynamics.ActiveReports.TextBox Warehouse_StockTotal;
		private DataDynamics.ActiveReports.TextBox WarehouseStockPrice_TextBox;
		private DataDynamics.ActiveReports.GroupFooter SectionFooter;
		private DataDynamics.ActiveReports.GroupFooter GrandTotalFooter;
		private DataDynamics.ActiveReports.Label GrandTotal_Title;
		private DataDynamics.ActiveReports.Line Line;
		private DataDynamics.ActiveReports.TextBox GrandTotal_StockTotal;
		private DataDynamics.ActiveReports.TextBox GrandTotalStockPrice_TextBox;
		private DataDynamics.ActiveReports.GroupFooter TitleFooter;
		private DataDynamics.ActiveReports.Line Line41;
		private DataDynamics.ActiveReports.GroupFooter ExtraFooter;
		private DataDynamics.ActiveReports.PageFooter PageFooter;
		private DataDynamics.ActiveReports.SubReport Footer_SubReport;
		public void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MAZAI02112P_05A4C));
            this.Detail = new DataDynamics.ActiveReports.Detail();
            this.Line37 = new DataDynamics.ActiveReports.Line();
            this.GoodsName_TextBox = new DataDynamics.ActiveReports.TextBox();
            this.ListPrice_TextBox = new DataDynamics.ActiveReports.TextBox();
            this.GoodsNo_TextBox = new DataDynamics.ActiveReports.TextBox();
            this.WarehouseShelfNo_TextBox = new DataDynamics.ActiveReports.TextBox();
            this.StockUnitPriceFl_TextBox = new DataDynamics.ActiveReports.TextBox();
            this.StockAmountPrice_TextBox = new DataDynamics.ActiveReports.TextBox();
            this.MakerCode_TextBox = new DataDynamics.ActiveReports.TextBox();
            this.StockTotalExec_TextBox = new DataDynamics.ActiveReports.TextBox();
            this.SupplierCd_TextBox = new DataDynamics.ActiveReports.TextBox();
            this.BLGoodsCode_TextBox = new DataDynamics.ActiveReports.TextBox();
            this.BLGroupCode_TextBox = new DataDynamics.ActiveReports.TextBox();
            this.Warehouse_TextBox = new DataDynamics.ActiveReports.TextBox();
            this.WarehouseCode_TextBox = new DataDynamics.ActiveReports.TextBox();
            this.PageHeader = new DataDynamics.ActiveReports.PageHeader();
            this.Title_Label = new DataDynamics.ActiveReports.Label();
            this.Label3 = new DataDynamics.ActiveReports.Label();
            this.PrintDate = new DataDynamics.ActiveReports.TextBox();
            this.Label2 = new DataDynamics.ActiveReports.Label();
            this.PRINTPAGE = new DataDynamics.ActiveReports.TextBox();
            this.Line1 = new DataDynamics.ActiveReports.Line();
            this.SortTitle = new DataDynamics.ActiveReports.TextBox();
            this.PrintTime = new DataDynamics.ActiveReports.TextBox();
            this.PageFooter = new DataDynamics.ActiveReports.PageFooter();
            this.Footer_SubReport = new DataDynamics.ActiveReports.SubReport();
            this.ExtraHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.Header_SubReport = new DataDynamics.ActiveReports.SubReport();
            this.ExtraFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.TitleHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.Maker_Title = new DataDynamics.ActiveReports.Label();
            this.GoodsNo_Title = new DataDynamics.ActiveReports.Label();
            this.Line4 = new DataDynamics.ActiveReports.Line();
            this.StockUnitPrice_Title = new DataDynamics.ActiveReports.Label();
            this.GoodsName_Title = new DataDynamics.ActiveReports.Label();
            this.WarehouseShelfNo_Title = new DataDynamics.ActiveReports.Label();
            this.StockTotalExec_Title = new DataDynamics.ActiveReports.Label();
            this.StockPrice_Title = new DataDynamics.ActiveReports.Label();
            this.SupplierCd_Title = new DataDynamics.ActiveReports.Label();
            this.BLGoodsCode_Title = new DataDynamics.ActiveReports.Label();
            this.BLGroupCode_Title = new DataDynamics.ActiveReports.Label();
            this.label6 = new DataDynamics.ActiveReports.Label();
            this.line6 = new DataDynamics.ActiveReports.Line();
            this.TitleFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.Line41 = new DataDynamics.ActiveReports.Line();
            this.GrandTotalHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.GrandTotalFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.GrandTotal_Title = new DataDynamics.ActiveReports.Label();
            this.Line = new DataDynamics.ActiveReports.Line();
            this.GrandTotal_StockTotal = new DataDynamics.ActiveReports.TextBox();
            this.GrandTotalStockPrice_TextBox = new DataDynamics.ActiveReports.TextBox();
            this.SectionHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.StockSectionName = new DataDynamics.ActiveReports.TextBox();
            this.StockSectionCode = new DataDynamics.ActiveReports.TextBox();
            this.SectionFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.WarehouseHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.line3 = new DataDynamics.ActiveReports.Line();
            this.WarehouseFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.Line2 = new DataDynamics.ActiveReports.Line();
            this.WarehouseTotal_Title = new DataDynamics.ActiveReports.TextBox();
            this.Warehouse_StockTotal = new DataDynamics.ActiveReports.TextBox();
            this.WarehouseStockPrice_TextBox = new DataDynamics.ActiveReports.TextBox();
            this.SubTotalHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.SubTotalFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.Line5 = new DataDynamics.ActiveReports.Line();
            this.SubTotal_Title = new DataDynamics.ActiveReports.TextBox();
            this.Maker_StockTotal = new DataDynamics.ActiveReports.TextBox();
            this.MakerTotalStockPrice_TextBox = new DataDynamics.ActiveReports.TextBox();
            this.GoodsHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.GoodsFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.Line44 = new DataDynamics.ActiveReports.Line();
            this.GoodsTotal_Title = new DataDynamics.ActiveReports.TextBox();
            this.Goods_StockTotal = new DataDynamics.ActiveReports.TextBox();
            this.GoodsTotalStockPrice_TextBox = new DataDynamics.ActiveReports.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsName_TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ListPrice_TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsNo_TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WarehouseShelfNo_TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StockUnitPriceFl_TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StockAmountPrice_TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MakerCode_TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StockTotalExec_TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupplierCd_TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BLGoodsCode_TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BLGroupCode_TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Warehouse_TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WarehouseCode_TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Title_Label)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PrintDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PRINTPAGE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SortTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PrintTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Maker_Title)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsNo_Title)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StockUnitPrice_Title)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsName_Title)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WarehouseShelfNo_Title)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StockTotalExec_Title)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StockPrice_Title)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupplierCd_Title)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BLGoodsCode_Title)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BLGroupCode_Title)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrandTotal_Title)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrandTotal_StockTotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrandTotalStockPrice_TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StockSectionName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StockSectionCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WarehouseTotal_Title)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Warehouse_StockTotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WarehouseStockPrice_TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SubTotal_Title)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Maker_StockTotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MakerTotalStockPrice_TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsTotal_Title)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Goods_StockTotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsTotalStockPrice_TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.CanShrink = true;
            this.Detail.ColumnSpacing = 0F;
            this.Detail.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.Line37,
            this.GoodsName_TextBox,
            this.ListPrice_TextBox,
            this.GoodsNo_TextBox,
            this.WarehouseShelfNo_TextBox,
            this.StockUnitPriceFl_TextBox,
            this.StockAmountPrice_TextBox,
            this.MakerCode_TextBox,
            this.StockTotalExec_TextBox,
            this.SupplierCd_TextBox,
            this.BLGoodsCode_TextBox,
            this.BLGroupCode_TextBox});
            this.Detail.Height = 0.34375F;
            this.Detail.KeepTogether = true;
            this.Detail.Name = "Detail";
            this.Detail.AfterPrint += new System.EventHandler(this.Detail_AfterPrint);
            this.Detail.BeforePrint += new System.EventHandler(this.Detail_BeforePrint);
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
            this.Line37.Width = 10.8F;
            this.Line37.X1 = 0F;
            this.Line37.X2 = 10.8F;
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
            this.GoodsName_TextBox.Left = 2F;
            this.GoodsName_TextBox.MultiLine = false;
            this.GoodsName_TextBox.Name = "GoodsName_TextBox";
            this.GoodsName_TextBox.OutputFormat = resources.GetString("GoodsName_TextBox.OutputFormat");
            this.GoodsName_TextBox.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: �l�r ����; vertical" +
                "-align: top; ";
            this.GoodsName_TextBox.Text = "��������������������";
            this.GoodsName_TextBox.Top = 0F;
            this.GoodsName_TextBox.Width = 1.1875F;
            // 
            // ListPrice_TextBox
            // 
            this.ListPrice_TextBox.Border.BottomColor = System.Drawing.Color.Black;
            this.ListPrice_TextBox.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ListPrice_TextBox.Border.LeftColor = System.Drawing.Color.Black;
            this.ListPrice_TextBox.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ListPrice_TextBox.Border.RightColor = System.Drawing.Color.Black;
            this.ListPrice_TextBox.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ListPrice_TextBox.Border.TopColor = System.Drawing.Color.Black;
            this.ListPrice_TextBox.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ListPrice_TextBox.DataField = "ListPrice_Print";
            this.ListPrice_TextBox.Height = 0.125F;
            this.ListPrice_TextBox.Left = 6.0625F;
            this.ListPrice_TextBox.MultiLine = false;
            this.ListPrice_TextBox.Name = "ListPrice_TextBox";
            this.ListPrice_TextBox.OutputFormat = resources.GetString("ListPrice_TextBox.OutputFormat");
            this.ListPrice_TextBox.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: �l�r �S�V�b�N; verti" +
                "cal-align: top; ";
            this.ListPrice_TextBox.Text = "1,234,567";
            this.ListPrice_TextBox.Top = 0F;
            this.ListPrice_TextBox.Width = 0.625F;
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
            this.GoodsNo_TextBox.Height = 0.125F;
            this.GoodsNo_TextBox.Left = 0.5625F;
            this.GoodsNo_TextBox.MultiLine = false;
            this.GoodsNo_TextBox.Name = "GoodsNo_TextBox";
            this.GoodsNo_TextBox.OutputFormat = resources.GetString("GoodsNo_TextBox.OutputFormat");
            this.GoodsNo_TextBox.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: �l�r ����; vertical" +
                "-align: top; ";
            this.GoodsNo_TextBox.Text = "123456789012345678901234";
            this.GoodsNo_TextBox.Top = 0F;
            this.GoodsNo_TextBox.Width = 1.375F;
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
            this.WarehouseShelfNo_TextBox.Height = 0.125F;
            this.WarehouseShelfNo_TextBox.Left = 0F;
            this.WarehouseShelfNo_TextBox.MultiLine = false;
            this.WarehouseShelfNo_TextBox.Name = "WarehouseShelfNo_TextBox";
            this.WarehouseShelfNo_TextBox.OutputFormat = resources.GetString("WarehouseShelfNo_TextBox.OutputFormat");
            this.WarehouseShelfNo_TextBox.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: �l�r ����; vertical" +
                "-align: top; ";
            this.WarehouseShelfNo_TextBox.Text = "XXXXXXXX";
            this.WarehouseShelfNo_TextBox.Top = 0F;
            this.WarehouseShelfNo_TextBox.Width = 0.5F;
            // 
            // StockUnitPriceFl_TextBox
            // 
            this.StockUnitPriceFl_TextBox.Border.BottomColor = System.Drawing.Color.Black;
            this.StockUnitPriceFl_TextBox.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockUnitPriceFl_TextBox.Border.LeftColor = System.Drawing.Color.Black;
            this.StockUnitPriceFl_TextBox.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockUnitPriceFl_TextBox.Border.RightColor = System.Drawing.Color.Black;
            this.StockUnitPriceFl_TextBox.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockUnitPriceFl_TextBox.Border.TopColor = System.Drawing.Color.Black;
            this.StockUnitPriceFl_TextBox.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockUnitPriceFl_TextBox.DataField = "StockUnitPriceFl_Print";
            this.StockUnitPriceFl_TextBox.Height = 0.125F;
            this.StockUnitPriceFl_TextBox.Left = 6.75F;
            this.StockUnitPriceFl_TextBox.MultiLine = false;
            this.StockUnitPriceFl_TextBox.Name = "StockUnitPriceFl_TextBox";
            this.StockUnitPriceFl_TextBox.OutputFormat = resources.GetString("StockUnitPriceFl_TextBox.OutputFormat");
            this.StockUnitPriceFl_TextBox.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: �l�r �S�V�b�N; verti" +
                "cal-align: top; ";
            this.StockUnitPriceFl_TextBox.Text = "1,234,567.99";
            this.StockUnitPriceFl_TextBox.Top = 0F;
            this.StockUnitPriceFl_TextBox.Width = 0.8125F;
            // 
            // StockAmountPrice_TextBox
            // 
            this.StockAmountPrice_TextBox.Border.BottomColor = System.Drawing.Color.Black;
            this.StockAmountPrice_TextBox.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockAmountPrice_TextBox.Border.LeftColor = System.Drawing.Color.Black;
            this.StockAmountPrice_TextBox.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockAmountPrice_TextBox.Border.RightColor = System.Drawing.Color.Black;
            this.StockAmountPrice_TextBox.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockAmountPrice_TextBox.Border.TopColor = System.Drawing.Color.Black;
            this.StockAmountPrice_TextBox.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockAmountPrice_TextBox.DataField = "StockAmountPrice_Print";
            this.StockAmountPrice_TextBox.Height = 0.125F;
            this.StockAmountPrice_TextBox.Left = 7.625F;
            this.StockAmountPrice_TextBox.MultiLine = false;
            this.StockAmountPrice_TextBox.Name = "StockAmountPrice_TextBox";
            this.StockAmountPrice_TextBox.OutputFormat = resources.GetString("StockAmountPrice_TextBox.OutputFormat");
            this.StockAmountPrice_TextBox.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: �l�r �S�V�b�N; verti" +
                "cal-align: top; ";
            this.StockAmountPrice_TextBox.Text = "1,000,000,000";
            this.StockAmountPrice_TextBox.Top = 0F;
            this.StockAmountPrice_TextBox.Width = 1.125F;
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
            this.MakerCode_TextBox.Left = 4.8125F;
            this.MakerCode_TextBox.MultiLine = false;
            this.MakerCode_TextBox.Name = "MakerCode_TextBox";
            this.MakerCode_TextBox.OutputFormat = resources.GetString("MakerCode_TextBox.OutputFormat");
            this.MakerCode_TextBox.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: �l�r �S�V�b�N; vertic" +
                "al-align: top; ";
            this.MakerCode_TextBox.Text = "1234";
            this.MakerCode_TextBox.Top = 0F;
            this.MakerCode_TextBox.Width = 0.3125F;
            // 
            // StockTotalExec_TextBox
            // 
            this.StockTotalExec_TextBox.Border.BottomColor = System.Drawing.Color.Black;
            this.StockTotalExec_TextBox.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockTotalExec_TextBox.Border.LeftColor = System.Drawing.Color.Black;
            this.StockTotalExec_TextBox.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockTotalExec_TextBox.Border.RightColor = System.Drawing.Color.Black;
            this.StockTotalExec_TextBox.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockTotalExec_TextBox.Border.TopColor = System.Drawing.Color.Black;
            this.StockTotalExec_TextBox.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockTotalExec_TextBox.DataField = "StockCount_Print";
            this.StockTotalExec_TextBox.Height = 0.125F;
            this.StockTotalExec_TextBox.Left = 5.1875F;
            this.StockTotalExec_TextBox.MultiLine = false;
            this.StockTotalExec_TextBox.Name = "StockTotalExec_TextBox";
            this.StockTotalExec_TextBox.OutputFormat = resources.GetString("StockTotalExec_TextBox.OutputFormat");
            this.StockTotalExec_TextBox.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: �l�r �S�V�b�N; verti" +
                "cal-align: top; ";
            this.StockTotalExec_TextBox.Text = "123,456.99";
            this.StockTotalExec_TextBox.Top = 0F;
            this.StockTotalExec_TextBox.Width = 0.8125F;
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
            this.SupplierCd_TextBox.Left = 3.3125F;
            this.SupplierCd_TextBox.MultiLine = false;
            this.SupplierCd_TextBox.Name = "SupplierCd_TextBox";
            this.SupplierCd_TextBox.OutputFormat = resources.GetString("SupplierCd_TextBox.OutputFormat");
            this.SupplierCd_TextBox.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: �l�r �S�V�b�N; vertic" +
                "al-align: top; ";
            this.SupplierCd_TextBox.Text = "123456";
            this.SupplierCd_TextBox.Top = 0F;
            this.SupplierCd_TextBox.Width = 0.4375F;
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
            this.BLGoodsCode_TextBox.Left = 3.8125F;
            this.BLGoodsCode_TextBox.MultiLine = false;
            this.BLGoodsCode_TextBox.Name = "BLGoodsCode_TextBox";
            this.BLGoodsCode_TextBox.OutputFormat = resources.GetString("BLGoodsCode_TextBox.OutputFormat");
            this.BLGoodsCode_TextBox.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: �l�r �S�V�b�N; vertic" +
                "al-align: top; ";
            this.BLGoodsCode_TextBox.Text = "12345";
            this.BLGoodsCode_TextBox.Top = 0F;
            this.BLGoodsCode_TextBox.Width = 0.4375F;
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
            this.BLGroupCode_TextBox.Left = 4.3125F;
            this.BLGroupCode_TextBox.MultiLine = false;
            this.BLGroupCode_TextBox.Name = "BLGroupCode_TextBox";
            this.BLGroupCode_TextBox.OutputFormat = resources.GetString("BLGroupCode_TextBox.OutputFormat");
            this.BLGroupCode_TextBox.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: �l�r �S�V�b�N; vertic" +
                "al-align: top; ";
            this.BLGroupCode_TextBox.Text = "12345";
            this.BLGroupCode_TextBox.Top = 0F;
            this.BLGroupCode_TextBox.Width = 0.4375F;
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
            this.Warehouse_TextBox.Left = 0.5F;
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
            this.WarehouseCode_TextBox.DataField = "WarehouseCode";
            this.WarehouseCode_TextBox.Height = 0.125F;
            this.WarehouseCode_TextBox.Left = 0F;
            this.WarehouseCode_TextBox.MultiLine = false;
            this.WarehouseCode_TextBox.Name = "WarehouseCode_TextBox";
            this.WarehouseCode_TextBox.OutputFormat = resources.GetString("WarehouseCode_TextBox.OutputFormat");
            this.WarehouseCode_TextBox.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: �l�r �S�V�b�N; vertic" +
                "al-align: top; ";
            this.WarehouseCode_TextBox.Text = "1234";
            this.WarehouseCode_TextBox.Top = 0F;
            this.WarehouseCode_TextBox.Width = 0.375F;
            // 
            // PageHeader
            // 
            this.PageHeader.CanShrink = true;
            this.PageHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.Title_Label,
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
            // Title_Label
            // 
            this.Title_Label.Border.BottomColor = System.Drawing.Color.Black;
            this.Title_Label.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Title_Label.Border.LeftColor = System.Drawing.Color.Black;
            this.Title_Label.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Title_Label.Border.RightColor = System.Drawing.Color.Black;
            this.Title_Label.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Title_Label.Border.TopColor = System.Drawing.Color.Black;
            this.Title_Label.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Title_Label.Height = 0.21875F;
            this.Title_Label.HyperLink = "";
            this.Title_Label.Left = 0.21875F;
            this.Title_Label.MultiLine = false;
            this.Title_Label.Name = "Title_Label";
            this.Title_Label.Style = "ddo-char-set: 1; font-weight: bold; font-style: italic; font-size: 14.25pt; font-" +
                "family: �l�r ����; vertical-align: middle; ";
            this.Title_Label.Text = "�I���\";
            this.Title_Label.Top = 0F;
            this.Title_Label.Width = 2.09375F;
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
            this.Label3.Height = 0.15625F;
            this.Label3.HyperLink = "";
            this.Label3.Left = 7.9375F;
            this.Label3.MultiLine = false;
            this.Label3.Name = "Label3";
            this.Label3.Style = "ddo-char-set: 1; font-size: 8pt; font-family: �l�r ����; vertical-align: top; ";
            this.Label3.Text = "�쐬���t�F";
            this.Label3.Top = 0.0625F;
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
            this.PrintDate.Height = 0.15625F;
            this.PrintDate.Left = 8.5F;
            this.PrintDate.MultiLine = false;
            this.PrintDate.Name = "PrintDate";
            this.PrintDate.OutputFormat = resources.GetString("PrintDate.OutputFormat");
            this.PrintDate.Style = "ddo-char-set: 1; font-size: 8pt; font-family: �l�r ����; vertical-align: top; ";
            this.PrintDate.Text = "����17�N11�� 5��";
            this.PrintDate.Top = 0.0625F;
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
            this.Label2.Height = 0.15625F;
            this.Label2.HyperLink = "";
            this.Label2.Left = 9.9375F;
            this.Label2.MultiLine = false;
            this.Label2.Name = "Label2";
            this.Label2.Style = "ddo-char-set: 1; font-size: 8pt; font-family: �l�r ����; vertical-align: top; ";
            this.Label2.Text = "�y�[�W�F";
            this.Label2.Top = 0.0625F;
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
            this.PRINTPAGE.Height = 0.15625F;
            this.PRINTPAGE.Left = 10.4375F;
            this.PRINTPAGE.MultiLine = false;
            this.PRINTPAGE.Name = "PRINTPAGE";
            this.PRINTPAGE.OutputFormat = resources.GetString("PRINTPAGE.OutputFormat");
            this.PRINTPAGE.Style = "ddo-char-set: 1; text-align: right; font-size: 8pt; font-family: �l�r ����; vertical-" +
                "align: top; ";
            this.PRINTPAGE.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.PRINTPAGE.SummaryType = DataDynamics.ActiveReports.SummaryType.PageCount;
            this.PRINTPAGE.Text = "123";
            this.PRINTPAGE.Top = 0.0625F;
            this.PRINTPAGE.Width = 0.28125F;
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
            this.Line1.Width = 10.8F;
            this.Line1.X1 = 0F;
            this.Line1.X2 = 10.8F;
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
            this.SortTitle.Height = 0.156F;
            this.SortTitle.Left = 2.325F;
            this.SortTitle.MultiLine = false;
            this.SortTitle.Name = "SortTitle";
            this.SortTitle.Style = "ddo-char-set: 1; font-size: 8pt; font-family: �l�r ����; vertical-align: top; ";
            this.SortTitle.Text = "[�\�[�g����]";
            this.SortTitle.Top = 0.0625F;
            this.SortTitle.Width = 3F;
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
            this.PrintTime.Left = 9.4375F;
            this.PrintTime.Name = "PrintTime";
            this.PrintTime.Style = "ddo-char-set: 1; font-size: 8pt; ";
            this.PrintTime.Text = "11��20��";
            this.PrintTime.Top = 0.0625F;
            this.PrintTime.Width = 0.5F;
            // 
            // PageFooter
            // 
            this.PageFooter.CanShrink = true;
            this.PageFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.Footer_SubReport});
            this.PageFooter.Height = 0F;
            this.PageFooter.Name = "PageFooter";
            this.PageFooter.Format += new System.EventHandler(this.PageFooter_Format);
            // 
            // Footer_SubReport
            // 
            this.Footer_SubReport.Border.BottomColor = System.Drawing.Color.Black;
            this.Footer_SubReport.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Footer_SubReport.Border.LeftColor = System.Drawing.Color.Black;
            this.Footer_SubReport.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Footer_SubReport.Border.RightColor = System.Drawing.Color.Black;
            this.Footer_SubReport.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Footer_SubReport.Border.TopColor = System.Drawing.Color.Black;
            this.Footer_SubReport.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Footer_SubReport.CloseBorder = false;
            this.Footer_SubReport.Height = 0.239F;
            this.Footer_SubReport.Left = 0F;
            this.Footer_SubReport.Name = "Footer_SubReport";
            this.Footer_SubReport.Report = null;
            this.Footer_SubReport.Top = 0F;
            this.Footer_SubReport.Width = 10.8F;
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
            this.Header_SubReport.Width = 10.8F;
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
            this.Maker_Title,
            this.GoodsNo_Title,
            this.Line4,
            this.StockUnitPrice_Title,
            this.GoodsName_Title,
            this.WarehouseShelfNo_Title,
            this.StockTotalExec_Title,
            this.StockPrice_Title,
            this.SupplierCd_Title,
            this.BLGoodsCode_Title,
            this.BLGroupCode_Title,
            this.label6,
            this.line6});
            this.TitleHeader.Height = 0.2604167F;
            this.TitleHeader.Name = "TitleHeader";
            this.TitleHeader.RepeatStyle = DataDynamics.ActiveReports.RepeatStyle.OnPageIncludeNoDetail;
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
            this.Maker_Title.Left = 4.8125F;
            this.Maker_Title.MultiLine = false;
            this.Maker_Title.Name = "Maker_Title";
            this.Maker_Title.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: �l�r ����; vertical-align: middle; ";
            this.Maker_Title.Text = "Ұ��";
            this.Maker_Title.Top = 0F;
            this.Maker_Title.Width = 0.3125F;
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
            this.GoodsNo_Title.Left = 0.5625F;
            this.GoodsNo_Title.MultiLine = false;
            this.GoodsNo_Title.Name = "GoodsNo_Title";
            this.GoodsNo_Title.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: �l�r ����; vertical-align: middle; ";
            this.GoodsNo_Title.Text = "�i��";
            this.GoodsNo_Title.Top = 0F;
            this.GoodsNo_Title.Width = 1.375F;
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
            this.Line4.Width = 10.8F;
            this.Line4.X1 = 0F;
            this.Line4.X2 = 10.8F;
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
            this.StockUnitPrice_Title.Left = 6.75F;
            this.StockUnitPrice_Title.MultiLine = false;
            this.StockUnitPrice_Title.Name = "StockUnitPrice_Title";
            this.StockUnitPrice_Title.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: �l�r ����; vertical-align: middle; ";
            this.StockUnitPrice_Title.Text = "���P��";
            this.StockUnitPrice_Title.Top = 0F;
            this.StockUnitPrice_Title.Width = 0.8125F;
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
            this.GoodsName_Title.Left = 2F;
            this.GoodsName_Title.MultiLine = false;
            this.GoodsName_Title.Name = "GoodsName_Title";
            this.GoodsName_Title.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: �l�r ����; vertical-align: middle; ";
            this.GoodsName_Title.Text = "�i��";
            this.GoodsName_Title.Top = 0F;
            this.GoodsName_Title.Width = 1.1875F;
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
            this.WarehouseShelfNo_Title.Width = 0.5F;
            // 
            // StockTotalExec_Title
            // 
            this.StockTotalExec_Title.Border.BottomColor = System.Drawing.Color.Black;
            this.StockTotalExec_Title.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockTotalExec_Title.Border.LeftColor = System.Drawing.Color.Black;
            this.StockTotalExec_Title.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockTotalExec_Title.Border.RightColor = System.Drawing.Color.Black;
            this.StockTotalExec_Title.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockTotalExec_Title.Border.TopColor = System.Drawing.Color.Black;
            this.StockTotalExec_Title.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockTotalExec_Title.Height = 0.1875F;
            this.StockTotalExec_Title.HyperLink = "";
            this.StockTotalExec_Title.Left = 5.25F;
            this.StockTotalExec_Title.MultiLine = false;
            this.StockTotalExec_Title.Name = "StockTotalExec_Title";
            this.StockTotalExec_Title.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: �l�r ����; vertical-align: middle; ";
            this.StockTotalExec_Title.Text = "�I����";
            this.StockTotalExec_Title.Top = 0F;
            this.StockTotalExec_Title.Width = 0.75F;
            // 
            // StockPrice_Title
            // 
            this.StockPrice_Title.Border.BottomColor = System.Drawing.Color.Black;
            this.StockPrice_Title.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockPrice_Title.Border.LeftColor = System.Drawing.Color.Black;
            this.StockPrice_Title.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockPrice_Title.Border.RightColor = System.Drawing.Color.Black;
            this.StockPrice_Title.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockPrice_Title.Border.TopColor = System.Drawing.Color.Black;
            this.StockPrice_Title.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockPrice_Title.Height = 0.1875F;
            this.StockPrice_Title.HyperLink = "";
            this.StockPrice_Title.Left = 7.625F;
            this.StockPrice_Title.MultiLine = false;
            this.StockPrice_Title.Name = "StockPrice_Title";
            this.StockPrice_Title.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: �l�r ����; vertical-align: middle; ";
            this.StockPrice_Title.Text = "�I�����z";
            this.StockPrice_Title.Top = 0F;
            this.StockPrice_Title.Width = 1.125F;
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
            this.SupplierCd_Title.Left = 3.3125F;
            this.SupplierCd_Title.MultiLine = false;
            this.SupplierCd_Title.Name = "SupplierCd_Title";
            this.SupplierCd_Title.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: �l�r ����; vertical-align: middle; ";
            this.SupplierCd_Title.Text = "�d����";
            this.SupplierCd_Title.Top = 0F;
            this.SupplierCd_Title.Width = 0.4375F;
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
            this.BLGoodsCode_Title.Left = 3.8125F;
            this.BLGoodsCode_Title.MultiLine = false;
            this.BLGoodsCode_Title.Name = "BLGoodsCode_Title";
            this.BLGoodsCode_Title.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: �l�r ����; vertical-align: middle; ";
            this.BLGoodsCode_Title.Text = "BL����";
            this.BLGoodsCode_Title.Top = 0F;
            this.BLGoodsCode_Title.Width = 0.4375F;
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
            this.BLGroupCode_Title.Left = 4.3125F;
            this.BLGroupCode_Title.MultiLine = false;
            this.BLGroupCode_Title.Name = "BLGroupCode_Title";
            this.BLGroupCode_Title.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: �l�r ����; vertical-align: middle; ";
            this.BLGroupCode_Title.Text = "��ٰ��";
            this.BLGroupCode_Title.Top = 0F;
            this.BLGroupCode_Title.Width = 0.4375F;
            // 
            // label6
            // 
            this.label6.Border.BottomColor = System.Drawing.Color.Black;
            this.label6.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label6.Border.LeftColor = System.Drawing.Color.Black;
            this.label6.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label6.Border.RightColor = System.Drawing.Color.Black;
            this.label6.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label6.Border.TopColor = System.Drawing.Color.Black;
            this.label6.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label6.Height = 0.1875F;
            this.label6.HyperLink = "";
            this.label6.Left = 6.0625F;
            this.label6.MultiLine = false;
            this.label6.Name = "label6";
            this.label6.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: �l�r ����; vertical-align: middle; ";
            this.label6.Text = "�W�����i";
            this.label6.Top = 0F;
            this.label6.Width = 0.625F;
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
            this.line6.LineWeight = 1F;
            this.line6.Name = "line6";
            this.line6.Top = 0.1875F;
            this.line6.Width = 10.8F;
            this.line6.X1 = 0F;
            this.line6.X2 = 10.8F;
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
            this.Line41.Width = 10.8F;
            this.Line41.X1 = 0F;
            this.Line41.X2 = 10.8F;
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
            this.GrandTotal_StockTotal,
            this.GrandTotalStockPrice_TextBox});
            this.GrandTotalFooter.Height = 0.2708333F;
            this.GrandTotalFooter.KeepTogether = true;
            this.GrandTotalFooter.Name = "GrandTotalFooter";
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
            this.GrandTotal_Title.Left = 3.6875F;
            this.GrandTotal_Title.MultiLine = false;
            this.GrandTotal_Title.Name = "GrandTotal_Title";
            this.GrandTotal_Title.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 10.8pt; font-fam" +
                "ily: �l�r ����; vertical-align: middle; ";
            this.GrandTotal_Title.Text = "�����v";
            this.GrandTotal_Title.Top = 0F;
            this.GrandTotal_Title.Width = 0.6875F;
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
            this.Line.Width = 10.8F;
            this.Line.X1 = 0F;
            this.Line.X2 = 10.8F;
            this.Line.Y1 = 0F;
            this.Line.Y2 = 0F;
            // 
            // GrandTotal_StockTotal
            // 
            this.GrandTotal_StockTotal.Border.BottomColor = System.Drawing.Color.Black;
            this.GrandTotal_StockTotal.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrandTotal_StockTotal.Border.LeftColor = System.Drawing.Color.Black;
            this.GrandTotal_StockTotal.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrandTotal_StockTotal.Border.RightColor = System.Drawing.Color.Black;
            this.GrandTotal_StockTotal.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrandTotal_StockTotal.Border.TopColor = System.Drawing.Color.Black;
            this.GrandTotal_StockTotal.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrandTotal_StockTotal.DataField = "StockCount_Print";
            this.GrandTotal_StockTotal.Height = 0.1875F;
            this.GrandTotal_StockTotal.Left = 5.1875F;
            this.GrandTotal_StockTotal.MultiLine = false;
            this.GrandTotal_StockTotal.Name = "GrandTotal_StockTotal";
            this.GrandTotal_StockTotal.OutputFormat = resources.GetString("GrandTotal_StockTotal.OutputFormat");
            this.GrandTotal_StockTotal.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: �l�r �S�V�b�N; vertical-align: middle; ";
            this.GrandTotal_StockTotal.SummaryGroup = "GrandTotalHeader";
            this.GrandTotal_StockTotal.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.GrandTotal_StockTotal.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.GrandTotal_StockTotal.Text = "1,234,567.99";
            this.GrandTotal_StockTotal.Top = 0F;
            this.GrandTotal_StockTotal.Width = 0.8125F;
            // 
            // GrandTotalStockPrice_TextBox
            // 
            this.GrandTotalStockPrice_TextBox.Border.BottomColor = System.Drawing.Color.Black;
            this.GrandTotalStockPrice_TextBox.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrandTotalStockPrice_TextBox.Border.LeftColor = System.Drawing.Color.Black;
            this.GrandTotalStockPrice_TextBox.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrandTotalStockPrice_TextBox.Border.RightColor = System.Drawing.Color.Black;
            this.GrandTotalStockPrice_TextBox.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrandTotalStockPrice_TextBox.Border.TopColor = System.Drawing.Color.Black;
            this.GrandTotalStockPrice_TextBox.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrandTotalStockPrice_TextBox.DataField = "StockAmountPrice_Print";
            this.GrandTotalStockPrice_TextBox.Height = 0.1875F;
            this.GrandTotalStockPrice_TextBox.Left = 7.625F;
            this.GrandTotalStockPrice_TextBox.MultiLine = false;
            this.GrandTotalStockPrice_TextBox.Name = "GrandTotalStockPrice_TextBox";
            this.GrandTotalStockPrice_TextBox.OutputFormat = resources.GetString("GrandTotalStockPrice_TextBox.OutputFormat");
            this.GrandTotalStockPrice_TextBox.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: �l�r �S�V�b�N; vertical-align: middle; ";
            this.GrandTotalStockPrice_TextBox.SummaryGroup = "GrandTotalHeader";
            this.GrandTotalStockPrice_TextBox.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.GrandTotalStockPrice_TextBox.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.GrandTotalStockPrice_TextBox.Text = "10,000,000,000";
            this.GrandTotalStockPrice_TextBox.Top = 0F;
            this.GrandTotalStockPrice_TextBox.Width = 1.125F;
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
            this.StockSectionName.Left = 0F;
            this.StockSectionName.MultiLine = false;
            this.StockSectionName.Name = "StockSectionName";
            this.StockSectionName.Style = "ddo-char-set: 128; font-size: 8pt; font-family: �l�r ����; vertical-align: top; ";
            this.StockSectionName.Text = null;
            this.StockSectionName.Top = 0F;
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
            this.StockSectionCode.Left = 0.8125F;
            this.StockSectionCode.MultiLine = false;
            this.StockSectionCode.Name = "StockSectionCode";
            this.StockSectionCode.Style = "ddo-char-set: 128; font-size: 8pt; font-family: �l�r ����; vertical-align: top; ";
            this.StockSectionCode.Text = null;
            this.StockSectionCode.Top = 0F;
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
            this.line3.LineWeight = 1F;
            this.line3.Name = "line3";
            this.line3.Top = 0F;
            this.line3.Width = 10.8F;
            this.line3.X1 = 0F;
            this.line3.X2 = 10.8F;
            this.line3.Y1 = 0F;
            this.line3.Y2 = 0F;
            // 
            // WarehouseFooter
            // 
            this.WarehouseFooter.CanShrink = true;
            this.WarehouseFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.Line2,
            this.WarehouseTotal_Title,
            this.Warehouse_StockTotal,
            this.WarehouseStockPrice_TextBox});
            this.WarehouseFooter.Height = 0.3020833F;
            this.WarehouseFooter.KeepTogether = true;
            this.WarehouseFooter.Name = "WarehouseFooter";
            this.WarehouseFooter.AfterPrint += new System.EventHandler(this.WarehouseFooter_AfterPrint);
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
            this.Line2.Width = 10.8F;
            this.Line2.X1 = 0F;
            this.Line2.X2 = 10.8F;
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
            this.WarehouseTotal_Title.Left = 3.6875F;
            this.WarehouseTotal_Title.MultiLine = false;
            this.WarehouseTotal_Title.Name = "WarehouseTotal_Title";
            this.WarehouseTotal_Title.OutputFormat = resources.GetString("WarehouseTotal_Title.OutputFormat");
            this.WarehouseTotal_Title.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 10.8pt; font-fam" +
                "ily: �l�r ����; vertical-align: middle; ";
            this.WarehouseTotal_Title.Text = "�q�Ɍv";
            this.WarehouseTotal_Title.Top = 0F;
            this.WarehouseTotal_Title.Width = 0.6875F;
            // 
            // Warehouse_StockTotal
            // 
            this.Warehouse_StockTotal.Border.BottomColor = System.Drawing.Color.Black;
            this.Warehouse_StockTotal.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Warehouse_StockTotal.Border.LeftColor = System.Drawing.Color.Black;
            this.Warehouse_StockTotal.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Warehouse_StockTotal.Border.RightColor = System.Drawing.Color.Black;
            this.Warehouse_StockTotal.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Warehouse_StockTotal.Border.TopColor = System.Drawing.Color.Black;
            this.Warehouse_StockTotal.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Warehouse_StockTotal.DataField = "StockCount_Print";
            this.Warehouse_StockTotal.Height = 0.1875F;
            this.Warehouse_StockTotal.Left = 5.1875F;
            this.Warehouse_StockTotal.MultiLine = false;
            this.Warehouse_StockTotal.Name = "Warehouse_StockTotal";
            this.Warehouse_StockTotal.OutputFormat = resources.GetString("Warehouse_StockTotal.OutputFormat");
            this.Warehouse_StockTotal.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: �l�r �S�V�b�N; vertical-align: middle; ";
            this.Warehouse_StockTotal.SummaryGroup = "WarehouseHeader";
            this.Warehouse_StockTotal.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Warehouse_StockTotal.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Warehouse_StockTotal.Text = "1,234,567.99";
            this.Warehouse_StockTotal.Top = 0F;
            this.Warehouse_StockTotal.Width = 0.8125F;
            // 
            // WarehouseStockPrice_TextBox
            // 
            this.WarehouseStockPrice_TextBox.Border.BottomColor = System.Drawing.Color.Black;
            this.WarehouseStockPrice_TextBox.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WarehouseStockPrice_TextBox.Border.LeftColor = System.Drawing.Color.Black;
            this.WarehouseStockPrice_TextBox.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WarehouseStockPrice_TextBox.Border.RightColor = System.Drawing.Color.Black;
            this.WarehouseStockPrice_TextBox.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WarehouseStockPrice_TextBox.Border.TopColor = System.Drawing.Color.Black;
            this.WarehouseStockPrice_TextBox.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WarehouseStockPrice_TextBox.DataField = "StockAmountPrice_Print";
            this.WarehouseStockPrice_TextBox.Height = 0.1875F;
            this.WarehouseStockPrice_TextBox.Left = 7.625F;
            this.WarehouseStockPrice_TextBox.MultiLine = false;
            this.WarehouseStockPrice_TextBox.Name = "WarehouseStockPrice_TextBox";
            this.WarehouseStockPrice_TextBox.OutputFormat = resources.GetString("WarehouseStockPrice_TextBox.OutputFormat");
            this.WarehouseStockPrice_TextBox.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: �l�r �S�V�b�N; vertical-align: middle; ";
            this.WarehouseStockPrice_TextBox.SummaryGroup = "WarehouseHeader";
            this.WarehouseStockPrice_TextBox.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.WarehouseStockPrice_TextBox.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.WarehouseStockPrice_TextBox.Text = "10,000,000,000";
            this.WarehouseStockPrice_TextBox.Top = 0F;
            this.WarehouseStockPrice_TextBox.Width = 1.125F;
            // 
            // SubTotalHeader
            // 
            this.SubTotalHeader.CanShrink = true;
            this.SubTotalHeader.Height = 0F;
            this.SubTotalHeader.Name = "SubTotalHeader";
            this.SubTotalHeader.NewPage = DataDynamics.ActiveReports.NewPage.Before;
            // 
            // SubTotalFooter
            // 
            this.SubTotalFooter.CanShrink = true;
            this.SubTotalFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.Line5,
            this.SubTotal_Title,
            this.Maker_StockTotal,
            this.MakerTotalStockPrice_TextBox});
            this.SubTotalFooter.Height = 0.28125F;
            this.SubTotalFooter.KeepTogether = true;
            this.SubTotalFooter.Name = "SubTotalFooter";
            this.SubTotalFooter.AfterPrint += new System.EventHandler(this.MakerFooter_AfterPrint);
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
            this.Line5.Width = 10.8F;
            this.Line5.X1 = 0F;
            this.Line5.X2 = 10.8F;
            this.Line5.Y1 = 0F;
            this.Line5.Y2 = 0F;
            // 
            // SubTotal_Title
            // 
            this.SubTotal_Title.Border.BottomColor = System.Drawing.Color.Black;
            this.SubTotal_Title.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SubTotal_Title.Border.LeftColor = System.Drawing.Color.Black;
            this.SubTotal_Title.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SubTotal_Title.Border.RightColor = System.Drawing.Color.Black;
            this.SubTotal_Title.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SubTotal_Title.Border.TopColor = System.Drawing.Color.Black;
            this.SubTotal_Title.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SubTotal_Title.Height = 0.1875F;
            this.SubTotal_Title.Left = 3.6875F;
            this.SubTotal_Title.MultiLine = false;
            this.SubTotal_Title.Name = "SubTotal_Title";
            this.SubTotal_Title.OutputFormat = resources.GetString("SubTotal_Title.OutputFormat");
            this.SubTotal_Title.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 10.8pt; font-fam" +
                "ily: �l�r ����; vertical-align: middle; ";
            this.SubTotal_Title.Text = "�o�͏��v";
            this.SubTotal_Title.Top = 0F;
            this.SubTotal_Title.Width = 0.6875F;
            // 
            // Maker_StockTotal
            // 
            this.Maker_StockTotal.Border.BottomColor = System.Drawing.Color.Black;
            this.Maker_StockTotal.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Maker_StockTotal.Border.LeftColor = System.Drawing.Color.Black;
            this.Maker_StockTotal.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Maker_StockTotal.Border.RightColor = System.Drawing.Color.Black;
            this.Maker_StockTotal.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Maker_StockTotal.Border.TopColor = System.Drawing.Color.Black;
            this.Maker_StockTotal.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Maker_StockTotal.DataField = "StockCount_Print";
            this.Maker_StockTotal.Height = 0.1875F;
            this.Maker_StockTotal.Left = 5.1875F;
            this.Maker_StockTotal.MultiLine = false;
            this.Maker_StockTotal.Name = "Maker_StockTotal";
            this.Maker_StockTotal.OutputFormat = resources.GetString("Maker_StockTotal.OutputFormat");
            this.Maker_StockTotal.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: �l�r �S�V�b�N; vertical-align: middle; ";
            this.Maker_StockTotal.SummaryGroup = "SubTotalHeader";
            this.Maker_StockTotal.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Maker_StockTotal.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Maker_StockTotal.Text = "1,234,567.99";
            this.Maker_StockTotal.Top = 0F;
            this.Maker_StockTotal.Width = 0.8125F;
            // 
            // MakerTotalStockPrice_TextBox
            // 
            this.MakerTotalStockPrice_TextBox.Border.BottomColor = System.Drawing.Color.Black;
            this.MakerTotalStockPrice_TextBox.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakerTotalStockPrice_TextBox.Border.LeftColor = System.Drawing.Color.Black;
            this.MakerTotalStockPrice_TextBox.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakerTotalStockPrice_TextBox.Border.RightColor = System.Drawing.Color.Black;
            this.MakerTotalStockPrice_TextBox.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakerTotalStockPrice_TextBox.Border.TopColor = System.Drawing.Color.Black;
            this.MakerTotalStockPrice_TextBox.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakerTotalStockPrice_TextBox.DataField = "StockAmountPrice_Print";
            this.MakerTotalStockPrice_TextBox.Height = 0.1875F;
            this.MakerTotalStockPrice_TextBox.Left = 7.625F;
            this.MakerTotalStockPrice_TextBox.MultiLine = false;
            this.MakerTotalStockPrice_TextBox.Name = "MakerTotalStockPrice_TextBox";
            this.MakerTotalStockPrice_TextBox.OutputFormat = resources.GetString("MakerTotalStockPrice_TextBox.OutputFormat");
            this.MakerTotalStockPrice_TextBox.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: �l�r �S�V�b�N; vertical-align: middle; ";
            this.MakerTotalStockPrice_TextBox.SummaryGroup = "SubTotalHeader";
            this.MakerTotalStockPrice_TextBox.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.MakerTotalStockPrice_TextBox.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.MakerTotalStockPrice_TextBox.Text = "10,000,000,000";
            this.MakerTotalStockPrice_TextBox.Top = 0F;
            this.MakerTotalStockPrice_TextBox.Width = 1.125F;
            // 
            // GoodsHeader
            // 
            this.GoodsHeader.CanShrink = true;
            this.GoodsHeader.Height = 0F;
            this.GoodsHeader.Name = "GoodsHeader";
            this.GoodsHeader.Visible = false;
            // 
            // GoodsFooter
            // 
            this.GoodsFooter.CanShrink = true;
            this.GoodsFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.Line44,
            this.GoodsTotal_Title,
            this.Goods_StockTotal,
            this.GoodsTotalStockPrice_TextBox});
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
            this.Line44.Width = 10.8F;
            this.Line44.X1 = 0F;
            this.Line44.X2 = 10.8F;
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
            this.GoodsTotal_Title.Height = 0.125F;
            this.GoodsTotal_Title.Left = 3.6875F;
            this.GoodsTotal_Title.MultiLine = false;
            this.GoodsTotal_Title.Name = "GoodsTotal_Title";
            this.GoodsTotal_Title.OutputFormat = resources.GetString("GoodsTotal_Title.OutputFormat");
            this.GoodsTotal_Title.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": �l�r ����; vertical-align: top; ";
            this.GoodsTotal_Title.Text = "���i�v";
            this.GoodsTotal_Title.Top = 0F;
            this.GoodsTotal_Title.Width = 0.6875F;
            // 
            // Goods_StockTotal
            // 
            this.Goods_StockTotal.Border.BottomColor = System.Drawing.Color.Black;
            this.Goods_StockTotal.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Goods_StockTotal.Border.LeftColor = System.Drawing.Color.Black;
            this.Goods_StockTotal.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Goods_StockTotal.Border.RightColor = System.Drawing.Color.Black;
            this.Goods_StockTotal.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Goods_StockTotal.Border.TopColor = System.Drawing.Color.Black;
            this.Goods_StockTotal.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Goods_StockTotal.DataField = "StockTotal";
            this.Goods_StockTotal.Height = 0.125F;
            this.Goods_StockTotal.Left = 5.1875F;
            this.Goods_StockTotal.MultiLine = false;
            this.Goods_StockTotal.Name = "Goods_StockTotal";
            this.Goods_StockTotal.OutputFormat = resources.GetString("Goods_StockTotal.OutputFormat");
            this.Goods_StockTotal.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: �l�r �S�V�b�N; vertical-align: top; ";
            this.Goods_StockTotal.SummaryGroup = "GoodsHeader";
            this.Goods_StockTotal.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Goods_StockTotal.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Goods_StockTotal.Text = "1,234,567";
            this.Goods_StockTotal.Top = 0F;
            this.Goods_StockTotal.Width = 0.625F;
            // 
            // GoodsTotalStockPrice_TextBox
            // 
            this.GoodsTotalStockPrice_TextBox.Border.BottomColor = System.Drawing.Color.Black;
            this.GoodsTotalStockPrice_TextBox.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsTotalStockPrice_TextBox.Border.LeftColor = System.Drawing.Color.Black;
            this.GoodsTotalStockPrice_TextBox.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsTotalStockPrice_TextBox.Border.RightColor = System.Drawing.Color.Black;
            this.GoodsTotalStockPrice_TextBox.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsTotalStockPrice_TextBox.Border.TopColor = System.Drawing.Color.Black;
            this.GoodsTotalStockPrice_TextBox.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsTotalStockPrice_TextBox.DataField = "StockPrice";
            this.GoodsTotalStockPrice_TextBox.Height = 0.125F;
            this.GoodsTotalStockPrice_TextBox.Left = 7.4375F;
            this.GoodsTotalStockPrice_TextBox.MultiLine = false;
            this.GoodsTotalStockPrice_TextBox.Name = "GoodsTotalStockPrice_TextBox";
            this.GoodsTotalStockPrice_TextBox.OutputFormat = resources.GetString("GoodsTotalStockPrice_TextBox.OutputFormat");
            this.GoodsTotalStockPrice_TextBox.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: �l�r �S�V�b�N; vertical-align: top; ";
            this.GoodsTotalStockPrice_TextBox.SummaryGroup = "GoodsHeader";
            this.GoodsTotalStockPrice_TextBox.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.GoodsTotalStockPrice_TextBox.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.GoodsTotalStockPrice_TextBox.Text = "10,000,000,000";
            this.GoodsTotalStockPrice_TextBox.Top = 0F;
            this.GoodsTotalStockPrice_TextBox.Width = 0.875F;
            // 
            // MAZAI02112P_05A4C
            // 
            this.MasterReport = false;
            this.PageSettings.DefaultPaperSize = false;
            this.PageSettings.Margins.Bottom = 0.2F;
            this.PageSettings.Margins.Left = 0.2F;
            this.PageSettings.Margins.Right = 0.2F;
            this.PageSettings.Margins.Top = 0.2F;
            this.PageSettings.Orientation = DataDynamics.ActiveReports.Document.PageOrientation.Landscape;
            this.PageSettings.PaperHeight = 11.69291F;
            this.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.A4;
            this.PageSettings.PaperWidth = 8.268056F;
            this.PrintWidth = 10.8125F;
            this.Sections.Add(this.PageHeader);
            this.Sections.Add(this.ExtraHeader);
            this.Sections.Add(this.TitleHeader);
            this.Sections.Add(this.GrandTotalHeader);
            this.Sections.Add(this.SectionHeader);
            this.Sections.Add(this.WarehouseHeader);
            this.Sections.Add(this.SubTotalHeader);
            this.Sections.Add(this.GoodsHeader);
            this.Sections.Add(this.Detail);
            this.Sections.Add(this.GoodsFooter);
            this.Sections.Add(this.SubTotalFooter);
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
            this.PageEnd += new System.EventHandler(this.MAZAI02112P_05A4C_PageEnd);
            this.ReportStart += new System.EventHandler(this.MAZAI02112P_05A4C_ReportStart);
            ((System.ComponentModel.ISupportInitialize)(this.GoodsName_TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ListPrice_TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsNo_TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WarehouseShelfNo_TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StockUnitPriceFl_TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StockAmountPrice_TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MakerCode_TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StockTotalExec_TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupplierCd_TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BLGoodsCode_TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BLGroupCode_TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Warehouse_TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WarehouseCode_TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Title_Label)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PrintDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PRINTPAGE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SortTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PrintTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Maker_Title)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsNo_Title)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StockUnitPrice_Title)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsName_Title)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WarehouseShelfNo_Title)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StockTotalExec_Title)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StockPrice_Title)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupplierCd_Title)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BLGoodsCode_Title)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BLGroupCode_Title)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrandTotal_Title)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrandTotal_StockTotal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrandTotalStockPrice_TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StockSectionName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StockSectionCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WarehouseTotal_Title)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Warehouse_StockTotal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WarehouseStockPrice_TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SubTotal_Title)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Maker_StockTotal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MakerTotalStockPrice_TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsTotal_Title)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Goods_StockTotal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsTotalStockPrice_TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

		 }

		#endregion
  
    }
}
