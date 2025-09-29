//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ���o�����ڍ׉��
// �v���O�����T�v   : ���o�����ڍ׉��
//----------------------------------------------------------------------------//
//                (c)Copyright  2012 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ������
// �� �� ��  2012/07/25  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �C �� ��              �C�����e : 
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10801804-00 �쐬�S�� : ������
// �� �� ��  2012/10/16  �C�����e : ���_�Ǘ����O�Q�ƃc�[���s��̑Ή�
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Remoting.ParamData;
using System.Collections;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Common;

namespace Broadleaf.Windows.Forms
{
    ///<summary>
    /// ���o�����ڍ׉��
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���o�����ڍ׉��</br>
    /// <br>Programmer : ������</br>
    /// <br>Date       : 2012/07/25</br>
    /// <br>Update     : </br>
    /// <br>Update Note: 2012/10/16 ������</br>
    ///	<br>			 Redmine#31026 ���_�Ǘ����O�Q�ƃc�[���s��̑Ή�</br>
    /// </remarks>
    public partial class PMKYO09501UB : Form
    {
        #region �� Constructor ��
        /// <summary>
        /// ���o�����ڍ׉�� �R���X�g���N�^
        /// </summary>
        /// <param name="sndRcvHisTableWork">����M�������O�f�[�^���[�N</param>
        /// <param name="searchEtrResultList">����M���o�����������O�f�[�^���[�N���X�g</param>
        /// <remarks>
        /// <br>Note       : �R���X�g���N�^</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2012/07/25</br>
        /// </remarks>
        public PMKYO09501UB(SndRcvHisTableWork sndRcvHisTableWork, object searchEtrResultList)
        {
            InitializeComponent();

            // �ϐ�������
            _detailsTable = new DataTable();
            _searchEtrResultList = searchEtrResultList;
            _sndRcvHisTableWork = sndRcvHisTableWork;
            this.Text = getTitleName();

            // �{�^���ϐ�������
            this._imageList16 = IconResourceManagement.ImageList16;
            this._closeButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolsManager_MainMenu.Tools["ButtonTool_Close"];
            this._��oginTitleLabel = (Infragistics.Win.UltraWinToolbars.LabelTool)this.tToolsManager_MainMenu.Tools["LabelTool_LoginTitle"];
        }
        #endregion �� Constructor ��

        #region �� Const Memebers ��
        private const String GET_DATA_TYPE = "���o�f�[�^";
        private const String START_CONDITION1 = "�J�n�����P";
        private const String END_CONDITION1 = "�I�������P";

        private const String START_CONDITION2 = "�J�n�����Q";
        private const String END_CONDITION2 = "�I�������Q";

        private const String START_CONDITION3 = "�J�n�����R";
        private const String END_CONDITION3 = "�I�������R";

        private const String START_CONDITION4 = "�J�n�����S";
        private const String END_CONDITION4 = "�I�������S";

        private const String START_CONDITION5 = "�J�n�����T";
        private const String END_CONDITION5 = "�I�������T";

        private const String START_CONDITION6 = "�J�n�����U";
        private const String END_CONDITION6 = "�I�������U";

        private const String START_CONDITION7 = "�J�n�����V";
        private const String END_CONDITION7 = "�I�������V";

        private const String START_CONDITION8 = "�J�n�����W";
        private const String END_CONDITION8 = "�I�������W";

        private const String START_CONDITION9 = "�J�n�����X";
        private const String END_CONDITION9 = "�I�������X";

        private const String START_CONDITION10 = "�J�n�����P�O";
        private const String END_CONDITION10 = "�I�������P�O";

        private const String CustomerRF = "���Ӑ�}�X�^";
        private const String GoodsURF = "���i�}�X�^";
        private const String StockRF = "�݌Ƀ}�X�^";
        private const String SupplierRF = "�d����}�X�^";
        private const String RateRF = "�|���}�X�^";

        private const String SalesSlipRF = "����f�[�^";
        private const String SalesSlipRF1 = "���㖾�׃f�[�^";
        private const String SalesSlipRF2 = "�󒍃}�X�^";
        private const String SalesSlipRF3 = "�󒍃}�X�^�i�ԗ��j";
        private const String SalesHistoryRF = "���㗚���f�[�^";
        private const String SalesHistoryRF1 = "���㗚�𖾍׃f�[�^";
        private const String DepsitMainRF = "�����f�[�^";
        private const String DepsitMainRF1 = "�������׃f�[�^";
        private const String StockSlipRF = "�d���f�[�^";
        private const String StockSlipRF1 = "�d�����׃f�[�^";
        private const String StockSlipRF2 = "�󒍃}�X�^";
        private const String StockSlipHistRF = "�d�������f�[�^";
        private const String StockSlipHistRF1 = "�d�����𖾍׃f�[�^";
        private const String PaymentSlpRF = "�x���`�[�}�X�^";
        private const String PaymentSlpRF1 = "�x�����׃f�[�^";
        private const String StockAdjustRF = "�݌ɒ����f�[�^";
        private const String StockAdjustDtlRF = "�݌ɒ������׃f�[�^";
        private const String StockMoveRF = "�݌Ɉړ��f�[�^";
        private const String DepositAlwRF = "���������}�X�^";
        private const String RcvDraftDataRF = "����`�f�[�^";
        private const String PayDraftDataRF = "�x����`�f�[�^";

        // --- DEL ������ 2012/10/16 for Redmine#31026---------->>>>>
        //private const String MasterSend = "���o�����ڍ�(�}�X�^���M)";
        //private const String MasterReceive = "���o�����ڍ�(�}�X�^��M)";
        //private const String DataSend = "���o�����ڍ�(�f�[�^���M)";
        //private const String DataReceive = "���o�����ڍ�(�f�[�^��M)";
        // --- DEL ������ 2012/10/16 for Redmine#31026----------<<<<<
        // --- ADD ������ 2012/10/16 for Redmine#31026---------->>>>>
        private const String MasterSendStart = "���o�����ڍ�(�}�X�^���M�i�J�n�j)";
        private const String MasterSendEnd = "���o�����ڍ�(�}�X�^���M�i�I���j)";
        private const String MasterSendUpd = "���o�����ڍ�(�}�X�^���M�i����M�����X�V�j)";
        private const String MasterReceiveStart = "���o�����ڍ�(�}�X�^��M�i�J�n�j)";
        private const String MasterReceiveEnd = "���o�����ڍ�(�}�X�^��M�i�I���j)";
        private const String MasterReceiveUpd = "���o�����ڍ�(�}�X�^��M�i����M�����X�V�j)";
        private const String DataSendStart = "���o�����ڍ�(�f�[�^���M�i�J�n�j)";
        private const String DataSendEnd = "���o�����ڍ�(�f�[�^���M�i�I���j)";
        private const String DataSendUpd = "���o�����ڍ�(�f�[�^���M�i����M�����X�V�j)";
        private const String DataReceiveStart = "���o�����ڍ�(�f�[�^��M�i�J�n�j)";
        private const String DataReceiveEnd = "���o�����ڍ�(�f�[�^��M�i�I���j)";
        private const String DataReceiveUpd = "���o�����ڍ�(�f�[�^��M�i����M�����X�V�j)";

        private const string MST_SECINFOSET = "���_�ݒ�}�X�^";
        private const string MST_SUBSECTION = "����ݒ�}�X�^";
        private const string MST_WAREHOUSE = "�q�ɐݒ�}�X�^";
        private const string MST_EMPLOYEE = "�]�ƈ��ݒ�}�X�^";
        private const string MST_USERGDAREADIVU = "���[�U�[�K�C�h�}�X�^(�̔��G���A�敪�j";
        private const string MST_USERGDBUSDIVU = "���[�U�[�K�C�h�}�X�^�i�Ɩ��敪�j";
        private const string MST_USERGDCATEU = "���[�U�[�K�C�h�}�X�^�i�Ǝ�j";
        private const string MST_USERGDBUSU = "���[�U�[�K�C�h�}�X�^�i�E��j";
        private const string MST_USERGDGOODSDIVU = "���[�U�[�K�C�h�}�X�^�i���i�敪�j";
        private const string MST_USERGDCUSGROUPU = "���[�U�[�K�C�h�}�X�^�i���Ӑ�|���O���[�v�j";
        private const string MST_USERGDBANKU = "���[�U�[�K�C�h�}�X�^�i��s�j";
        private const string MST_USERGDPRIDIVU = "���[�U�[�K�C�h�}�X�^�i���i�敪�j";
        private const string MST_USERGDDELIDIVU = "���[�U�[�K�C�h�}�X�^�i�[�i�敪�j";
        private const string MST_USERGDGOODSBIGU = "���[�U�[�K�C�h�}�X�^�i���i�啪�ށj";
        private const string MST_USERGDBUYDIVU = "���[�U�[�K�C�h�}�X�^�i�̔��敪�j";
        private const string MST_USERGDSTOCKDIVOU = "���[�U�[�K�C�h�}�X�^�i�݌ɊǗ��敪�P�j";
        private const string MST_USERGDSTOCKDIVTU = "���[�U�[�K�C�h�}�X�^�i�݌ɊǗ��敪�Q�j";
        private const string MST_USERGDRETURNREAU = "���[�U�[�K�C�h�}�X�^�i�ԕi���R�j";
        private const string MST_RATEPROTYMNG = "�|���D��Ǘ��}�X�^";
        private const string MST_RATE = "�|���}�X�^";
        private const string MST_SALESTARGET = "����ڕW�ݒ�}�X�^";
        private const string MST_CUSTOME = "���Ӑ�}�X�^";
        private const string MST_SUPPLIER = "�d����}�X�^";
        private const string MST_JOINPARTSU = "�����}�X�^";
        private const string MST_GOODSSET = "�Z�b�g�}�X�^";
        private const string MST_TBOSEARCHU = "�s�a�n�}�X�^";
        private const string MST_MODELNAMEU = "�Ԏ�}�X�^";
        private const string MST_BLGOODSCDU = "�a�k�R�[�h�}�X�^";
        private const string MST_MAKERU = "���[�J�[�}�X�^";
        private const string MST_GOODSMGROUPU = "���i�����ރ}�X�^";
        private const string MST_BLGROUPU = "�O���[�v�R�[�h�}�X�^";
        private const string MST_BLCODEGUIDE = "BL�R�[�h�K�C�h�}�X�^";
        private const string MST_GOODSU = "���i�}�X�^";
        private const string MST_STOCK = "�݌Ƀ}�X�^";
        private const string MST_PARTSSUBSTU = "��փ}�X�^";
        private const string MST_PARTSPOSCODEU = "���ʃ}�X�^";

        private const string MST_ID_SECINFOSET = "SecInfoSetRF";
        private const string MST_ID_SUBSECTION = "SubSectionRF";
        private const string MST_ID_WAREHOUSE = "WarehouseRF";
        private const string MST_ID_EMPLOYEE = "EmployeeRF";
        private const string MST_ID_EMPLOYEEDTL = "EmployeeDtlRF";
        private const string MST_ID_USERGDU = "UserGdBdURF";
        private const string MST_ID_RATEPROTYMNG = "RateProtyMngRF";
        private const string MST_ID_RATE = "RateRF";
        private const string MST_ID_CUSTSALESTARGET = "CustSalesTargetRF";
        private const string MST_ID_EMPSALESTARGET = "EmpSalesTargetRF";
        private const string MST_ID_GCDSALESTARGET = "GcdSalesTargetRF";
        private const string MST_ID_CUSTOMECHA = "CustomerChangeRF";
        private const string MST_ID_CUSTOME = "CustomerRF";
        private const string MST_ID_CUSTOMEGROUP = "CustRateGroupRF";
        private const string MST_ID_CUSTOMESLIPMNG = "CustSlipMngRF";
        private const string MST_ID_CUSTOMESLIPNO = "CustSlipNoSetRF";
        private const string MST_ID_SUPPLIER = "SupplierRF";
        private const string MST_ID_JOINPARTSU = "JoinPartsURF";
        private const string MST_ID_GOODSSET = "GoodsSetRF";
        private const string MST_ID_TBOSEARCHU = "TBOSearchURF";
        private const string MST_ID_MODELNAMEU = "ModelNameURF";
        private const string MST_ID_BLGOODSCDU = "BLGoodsCdURF";
        private const string MST_ID_MAKERU = "MakerURF";
        private const string MST_ID_GOODSMGROUPU = "GoodsMGroupURF";
        private const string MST_ID_BLGROUPU = "BLGroupURF";
        private const string MST_ID_BLCODEGUIDE = "BLCodeGuideRF";
        private const string MST_ID_GOODSUMNG = "GoodsMngRF";
        private const string MST_ID_GOODSUPRI = "GoodsPriceURF";
        private const string MST_ID_GOODSU = "GoodsURF";
        private const string MST_ID_GOODSUISO = "IsolIslandPrcRF";
        private const string MST_ID_STOCK = "StockRF";
        private const string MST_ID_PARTSSUBSTU = "PartsSubstURF";
        private const string MST_ID_PARTSPOSCODEU = "PartsPosCodeURF";
        // --- ADD ������ 2012/10/16 for Redmine#31026----------<<<<<
        
        #endregion �� Const Memebers ��

        #region �� Private Field ��
        /// <summary>
        /// ���o�����ڍ׃O�b���h
        /// </summary>
        private DataTable _detailsTable;
        private object _searchEtrResultList;
        private SndRcvHisTableWork _sndRcvHisTableWork;
        private string _loginName;
        private ImageList _imageList16 = null;
        private Infragistics.Win.UltraWinToolbars.ButtonTool _closeButton;
        private Infragistics.Win.UltraWinToolbars.LabelTool _��oginTitleLabel;
        #endregion �� Private Field ��


        #region �� Event ��
        /// <summary>
        /// �c�[���o�[�N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">ToolClickEventArgs</param>
        /// <remarks>
        /// <br>Note       : �c�[���o�[�N���b�N�C�x���g</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2012/07/25</br>
        /// </remarks>
        private void tToolsManager_MainMenu_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            switch (e.Tool.Key)
            {
                // ��ʂ̏I��
                case "ButtonTool_Close":
                    {
                        //��ʕ���B
                        this.Close();
                    }
                    break;
            }
        }

        /// <summary>
        /// ��ʃ��[�h�C�x���g
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">EventArgs</param>
        /// <remarks>
        /// <br>Note       : ��ʃ��[�h�C�x���g</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2012/07/25</br>
        /// <br>Update Note: 2012/10/16 ������</br>
        ///	<br>			 Redmine#31026 ���_�Ǘ����O�Q�ƃc�[���s��̑Ή�</br>
        /// </remarks>
        private void PMKYO09501UB_Load(object sender, EventArgs e)
        {
            //this.DataSetColumnConstruction(this._sndRcvHisTableWork.Kind);//DEL 2012/10/16 ������ for redmine#31026
            this.DataSetColumnConstruction(this._sndRcvHisTableWork.Kind,this._sndRcvHisTableWork.SndLogExtraCondDiv);//ADD 2012/10/16 ������ for redmine#31026
            this.ButtonInitialSetting();
            //this.SetColumnStyle(this._sndRcvHisTableWork.Kind);//DEL 2012/10/16 ������ for redmine#31026
            this.SetColumnStyle(this._sndRcvHisTableWork.Kind, this._sndRcvHisTableWork.SndLogExtraCondDiv);//ADD 2012/10/16 ������ for redmine#31026

            // �ڍ׏���\������
            this.DetailShow();
        }
        #endregion �� Event ��

        #region �� Private Method ��

        /// <summary>
        /// ��ʃt�H�[����
        /// </summary>
        /// <returns>��ʃt�H�[����</returns>
        /// <remarks>
        /// <br>Note       : ��ʃt�H�[����</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2012/07/25</br>
        /// <br>Update Note: 2012/10/16 ������</br>
        ///	<br>			 Redmine#31026 ���_�Ǘ����O�Q�ƃc�[���s��̑Ή�</br>
        /// </remarks>
        private string getTitleName()
        {
            string titleName = "";
            // --- DEL ������ 2012/10/16 for Redmine#31026---------->>>>>
            //if (this._sndRcvHisTableWork.Kind == 0 && this._sndRcvHisTableWork.SendOrReceiveDivCd == 0)
            //{
            //    titleName = DataSend;
            //    this.Size = new System.Drawing.Size(320, 580);

            //}
            //else if (this._sndRcvHisTableWork.Kind == 0 && this._sndRcvHisTableWork.SendOrReceiveDivCd == 1)
            //{
            //    titleName = DataReceive;
            //    this.Size = new System.Drawing.Size(320, 580);
            //}
            //else if (this._sndRcvHisTableWork.Kind == 1 && this._sndRcvHisTableWork.SendOrReceiveDivCd == 0)
            //{
            //    titleName = MasterSend;
            //}
            //else if (this._sndRcvHisTableWork.Kind == 1 && this._sndRcvHisTableWork.SendOrReceiveDivCd == 1)
            //{
            //    titleName = MasterReceive;
            //}
            // --- DEL ������ 2012/10/16 for Redmine#31026----------<<<<<
            // --- ADD ������ 2012/10/16 for Redmine#31026---------->>>>>
            if (this._sndRcvHisTableWork.Kind == 0)
            {
                if (this._sndRcvHisTableWork.SendOrReceiveDivCd == 0)
                {
                    titleName = DataSendStart;
                }
                else if (this._sndRcvHisTableWork.SendOrReceiveDivCd == 1)
                {
                    titleName =DataSendEnd;
                }
                else if (this._sndRcvHisTableWork.SendOrReceiveDivCd == 2)
                {
                    titleName = DataSendUpd;
                }
                else if (this._sndRcvHisTableWork.SendOrReceiveDivCd == 3)
                {
                    titleName = DataReceiveStart;
                }
                else if (this._sndRcvHisTableWork.SendOrReceiveDivCd == 4)
                {
                    titleName = DataReceiveEnd;
                }
                else if (this._sndRcvHisTableWork.SendOrReceiveDivCd == 5)
                {
                    titleName = DataReceiveUpd;
                }

                this.Size = new System.Drawing.Size(340, 620);
            }
            else if (this._sndRcvHisTableWork.Kind == 1)
            {
                if (this._sndRcvHisTableWork.SendOrReceiveDivCd == 0)
                {
                    titleName = MasterSendStart;
                }
                else if (this._sndRcvHisTableWork.SendOrReceiveDivCd == 1)
                {
                    titleName = MasterSendEnd;
                }
                else if (this._sndRcvHisTableWork.SendOrReceiveDivCd == 2)
                {
                    titleName = MasterSendUpd;
                }
                else if (this._sndRcvHisTableWork.SendOrReceiveDivCd == 3)
                {
                    titleName = MasterReceiveStart;
                }
                else if (this._sndRcvHisTableWork.SendOrReceiveDivCd == 4)
                {
                    titleName = MasterReceiveEnd;
                }
                else if (this._sndRcvHisTableWork.SendOrReceiveDivCd == 5)
                {
                    titleName = MasterReceiveUpd;
                }
                //����
                if (this._sndRcvHisTableWork.SndLogExtraCondDiv == 0)
                {
                    this.Size = new System.Drawing.Size(340, 620);
                }
            }
            // --- ADD ������ 2012/10/16 for Redmine#31026----------<<<<<
            return titleName;
        }
        /// <summary>
        /// �f�[�^�Z�b�g����\�z����
        /// </summary>
        /// <remarks>
        /// <br>Note       : �f�[�^�Z�b�g����\�z�����ł�</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2012/07/25</br>
        /// <br>Update Note: 2012/10/16 ������</br>
        ///	<br>			 Redmine#31026 ���_�Ǘ����O�Q�ƃc�[���s��̑Ή�</br>
        /// </remarks>
        //private void DataSetColumnConstruction(int kind)//DEL 2012/10/16 ������ for redmine#31026
        private void DataSetColumnConstruction(int kind, int sndLogExtraCondDiv)//ADD 2012/10/16 ������ for redmine#31026
        {
            //if (kind == 0)//DEL 2012/10/16 ������ for redmine#31026
            if (kind == 0 || (kind == 1 && sndLogExtraCondDiv == 0))//ADD 2012/10/16 ������ for redmine#31026
            {
                this._detailsTable.Columns.Add(GET_DATA_TYPE, typeof(string));

            }
            //else if (kind == 1)//DEL 2012/10/16 ������ for redmine#31026
            else if (kind == 1 && sndLogExtraCondDiv == 1)//ADD 2012/10/16 ������ for redmine#31026
            {
                this._detailsTable.Columns.Add(GET_DATA_TYPE, typeof(string));
                this._detailsTable.Columns.Add(START_CONDITION1, typeof(string));
                this._detailsTable.Columns.Add(END_CONDITION1, typeof(string));

                this._detailsTable.Columns.Add(START_CONDITION2, typeof(string));
                this._detailsTable.Columns.Add(END_CONDITION2, typeof(string));

                this._detailsTable.Columns.Add(START_CONDITION3, typeof(string));
                this._detailsTable.Columns.Add(END_CONDITION3, typeof(string));

                this._detailsTable.Columns.Add(START_CONDITION4, typeof(string));
                this._detailsTable.Columns.Add(END_CONDITION4, typeof(string));

                this._detailsTable.Columns.Add(START_CONDITION5, typeof(string));
                this._detailsTable.Columns.Add(END_CONDITION5, typeof(string));

                this._detailsTable.Columns.Add(START_CONDITION6, typeof(string));
                this._detailsTable.Columns.Add(END_CONDITION6, typeof(string));

                this._detailsTable.Columns.Add(START_CONDITION7, typeof(string));
                this._detailsTable.Columns.Add(END_CONDITION7, typeof(string));

                this._detailsTable.Columns.Add(START_CONDITION8, typeof(string));
                this._detailsTable.Columns.Add(END_CONDITION8, typeof(string));

                this._detailsTable.Columns.Add(START_CONDITION9, typeof(string));
                this._detailsTable.Columns.Add(END_CONDITION9, typeof(string));

                this._detailsTable.Columns.Add(START_CONDITION10, typeof(string));
                this._detailsTable.Columns.Add(END_CONDITION10, typeof(string));
            }
            this.uGrid_Details.DataSource = _detailsTable;
        }

        /// <summary>
        /// ���R�[�h�̗�̃X�^�C���̐ݒ�
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���R�[�h�̗�̃X�^�C���̐ݒ�</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2012/07/25</br>
        /// <br>Update Note: 2012/10/16 ������</br>
        ///	<br>			 Redmine#31026 ���_�Ǘ����O�Q�ƃc�[���s��̑Ή�</br>
        /// </remarks>
        //private void SetColumnStyle(int kind)//DEL 2012/10/16 ������ for redmine#31026
        private void SetColumnStyle(int kind, int sndLogExtraCondDiv)//ADD 2012/10/16 ������ for redmine#31026
        {

            Infragistics.Win.UltraWinGrid.ColumnsCollection Columns = this.uGrid_Details.DisplayLayout.Bands[0].Columns;

            //if (kind == 0)//DEL 2012/10/16 ������ for redmine#31026
            if (kind == 0 || (kind == 1 && sndLogExtraCondDiv == 0))//ADD 2012/10/16 ������ for redmine#31026
            {
                // �\�����ݒ�
                //Columns[this._detailsTable.Columns[GET_DATA_TYPE].ColumnName].Width = 150;//DEL 2012/10/16 ������ for redmine#31026
                Columns[this._detailsTable.Columns[GET_DATA_TYPE].ColumnName].Width = 240;//ADD 2012/10/16 ������ for redmine#31026

                // ���͋��ݒ�
                Columns[this._detailsTable.Columns[GET_DATA_TYPE].ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            }
            //else if (kind == 1)//DEL 2012/10/16 ������ for redmine#31026
            else if (kind == 1 && sndLogExtraCondDiv == 1)//ADD 2012/10/16 ������ for redmine#31026
            {
                // �\�����ݒ�
                Columns[this._detailsTable.Columns[GET_DATA_TYPE].ColumnName].Width = 110;
                Columns[this._detailsTable.Columns[START_CONDITION1].ColumnName].Width = 100;
                Columns[this._detailsTable.Columns[END_CONDITION1].ColumnName].Width = 100;

                Columns[this._detailsTable.Columns[START_CONDITION2].ColumnName].Width = 100;
                Columns[this._detailsTable.Columns[END_CONDITION2].ColumnName].Width = 100;

                Columns[this._detailsTable.Columns[START_CONDITION3].ColumnName].Width = 100;
                Columns[this._detailsTable.Columns[END_CONDITION3].ColumnName].Width = 100;

                Columns[this._detailsTable.Columns[START_CONDITION4].ColumnName].Width = 100;
                Columns[this._detailsTable.Columns[END_CONDITION4].ColumnName].Width = 100;

                Columns[this._detailsTable.Columns[START_CONDITION5].ColumnName].Width = 100;
                Columns[this._detailsTable.Columns[END_CONDITION5].ColumnName].Width = 100;

                Columns[this._detailsTable.Columns[START_CONDITION6].ColumnName].Width = 100;
                Columns[this._detailsTable.Columns[END_CONDITION6].ColumnName].Width = 100;

                Columns[this._detailsTable.Columns[START_CONDITION7].ColumnName].Width = 100;
                Columns[this._detailsTable.Columns[END_CONDITION7].ColumnName].Width = 100;

                Columns[this._detailsTable.Columns[START_CONDITION8].ColumnName].Width = 100;
                Columns[this._detailsTable.Columns[END_CONDITION8].ColumnName].Width = 100;

                Columns[this._detailsTable.Columns[START_CONDITION9].ColumnName].Width = 100;
                Columns[this._detailsTable.Columns[END_CONDITION9].ColumnName].Width = 100;

                Columns[this._detailsTable.Columns[START_CONDITION10].ColumnName].Width = 100;
                Columns[this._detailsTable.Columns[END_CONDITION10].ColumnName].Width = 100;

                // ���͋��ݒ�
                Columns[this._detailsTable.Columns[GET_DATA_TYPE].ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                Columns[this._detailsTable.Columns[START_CONDITION1].ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                Columns[this._detailsTable.Columns[END_CONDITION1].ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;

                Columns[this._detailsTable.Columns[START_CONDITION2].ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                Columns[this._detailsTable.Columns[END_CONDITION2].ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;

                Columns[this._detailsTable.Columns[START_CONDITION3].ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                Columns[this._detailsTable.Columns[END_CONDITION3].ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;

                Columns[this._detailsTable.Columns[START_CONDITION4].ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                Columns[this._detailsTable.Columns[END_CONDITION4].ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;

                Columns[this._detailsTable.Columns[START_CONDITION5].ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                Columns[this._detailsTable.Columns[END_CONDITION5].ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;

                Columns[this._detailsTable.Columns[START_CONDITION6].ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                Columns[this._detailsTable.Columns[END_CONDITION6].ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;

                Columns[this._detailsTable.Columns[START_CONDITION7].ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                Columns[this._detailsTable.Columns[END_CONDITION7].ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;

                Columns[this._detailsTable.Columns[START_CONDITION8].ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                Columns[this._detailsTable.Columns[END_CONDITION8].ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;

                Columns[this._detailsTable.Columns[START_CONDITION9].ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                Columns[this._detailsTable.Columns[END_CONDITION9].ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;

                Columns[this._detailsTable.Columns[START_CONDITION10].ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                Columns[this._detailsTable.Columns[END_CONDITION10].ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            }

        }

        /// <summary>
        /// �{�^�������ݒ菈��
        /// </summary>
        /// <remarks>
        /// <br>Note       : �{�^�������ݒ菈���ł��B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2012/07/25</br>
        /// </remarks>
        private void ButtonInitialSetting()
        {
            this._loginName = LoginInfoAcquisition.Employee.Name;
            this.tToolsManager_MainMenu.ImageListSmall = this._imageList16;
            this._closeButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CLOSE;
            this._��oginTitleLabel.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.EMPLOYEE;


            // ���O�C���S���҂̐ݒ�
            Infragistics.Win.UltraWinToolbars.LabelTool loginNameLabel = (Infragistics.Win.UltraWinToolbars.LabelTool)tToolsManager_MainMenu.Tools["LabelTool_LoginName"];
            loginNameLabel.SharedProps.Caption = _loginName;
        }

        /// <summary>
        /// �ڍ׏���\������
        /// </summary>
        /// <remarks>
        /// <br>Note       : �ڍ׏���\������</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2012/07/25</br>
        /// <br>Update Note: 2012/10/16 ������</br>
        ///	<br>			 Redmine#31026 ���_�Ǘ����O�Q�ƃc�[���s��̑Ή�</br>
        /// </remarks>
        private void DetailShow()
        {
            //�f�[�^
            if (this._sndRcvHisTableWork.Kind == 0)
            {
                string[] fileId = this._sndRcvHisTableWork.SndRcvFileID.Split(',');
                DataRow row = null;

                foreach (string FileId in fileId)
                {
                    row = this._detailsTable.NewRow();

                    // --- DEL ������ 2012/10/16 for Redmine#31026---------->>>>>
                    //if ("SalesSlipRF".Equals(FileId))
                    //{
                    //    // ����f�[�^�A���㖾�׃f�[�^�A�󒍃}�X�^�A�󒍃}�X�^�i�ԗ��j
                    //    row[this._detailsTable.Columns[GET_DATA_TYPE]] = SalesSlipRF;
                    //    this._detailsTable.Rows.Add(row);

                    //    row = this._detailsTable.NewRow();
                    //    row[this._detailsTable.Columns[GET_DATA_TYPE]] = SalesSlipRF1;
                    //    this._detailsTable.Rows.Add(row);

                    //    row = this._detailsTable.NewRow();
                    //    row[this._detailsTable.Columns[GET_DATA_TYPE]] = SalesSlipRF2;
                    //    this._detailsTable.Rows.Add(row);

                    //    row = this._detailsTable.NewRow();
                    //    row[this._detailsTable.Columns[GET_DATA_TYPE]] = SalesSlipRF3;
                    //    this._detailsTable.Rows.Add(row);
                    //}
                    //else if ("SalesHistoryRF".Equals(FileId))
                    //{
                    //    // ���㗚���f�[�^�A���㗚�𖾍׃f�[�^
                    //    row[this._detailsTable.Columns[GET_DATA_TYPE]] = SalesHistoryRF;
                    //    this._detailsTable.Rows.Add(row);

                    //    row = this._detailsTable.NewRow();
                    //    row[this._detailsTable.Columns[GET_DATA_TYPE]] = SalesHistoryRF1;
                    //    this._detailsTable.Rows.Add(row);

                    //}
                    //else if ("DepsitMainRF".Equals(FileId))
                    //{
                    //    // �����f�[�^�A�������׃f�[�^
                    //    row[this._detailsTable.Columns[GET_DATA_TYPE]] = DepsitMainRF;
                    //    this._detailsTable.Rows.Add(row);

                    //    row = this._detailsTable.NewRow();
                    //    row[this._detailsTable.Columns[GET_DATA_TYPE]] = DepsitMainRF1;
                    //    this._detailsTable.Rows.Add(row);
                    //}
                    //else if ("StockSlipRF".Equals(FileId))
                    //{
                    //    // �d���f�[�^�A�d�����׃f�[�^�A�󒍃}�X�^
                    //    row[this._detailsTable.Columns[GET_DATA_TYPE]] = StockSlipRF;
                    //    this._detailsTable.Rows.Add(row);

                    //    row = this._detailsTable.NewRow();
                    //    row[this._detailsTable.Columns[GET_DATA_TYPE]] = StockSlipRF1;
                    //    this._detailsTable.Rows.Add(row);

                    //    row = this._detailsTable.NewRow();
                    //    row[this._detailsTable.Columns[GET_DATA_TYPE]] = StockSlipRF2;
                    //    this._detailsTable.Rows.Add(row);

                    //}
                    //else if ("StockSlipHistRF".Equals(FileId))
                    //{
                    //    // �d�������f�[�^�A�d�����𖾍׃f�[�^
                    //    row[this._detailsTable.Columns[GET_DATA_TYPE]] = StockSlipHistRF;
                    //    this._detailsTable.Rows.Add(row);

                    //    row = this._detailsTable.NewRow();
                    //    row[this._detailsTable.Columns[GET_DATA_TYPE]] = StockSlipHistRF1;
                    //    this._detailsTable.Rows.Add(row);

                    //}
                    //else if ("PaymentSlpRF".Equals(FileId))
                    //{
                    //    // �x���`�[�}�X�^�A�x�����׃f�[�^
                    //    row[this._detailsTable.Columns[GET_DATA_TYPE]] = PaymentSlpRF;
                    //    this._detailsTable.Rows.Add(row);

                    //    row = this._detailsTable.NewRow();
                    //    row[this._detailsTable.Columns[GET_DATA_TYPE]] = PaymentSlpRF1;
                    //    this._detailsTable.Rows.Add(row);

                    //}
                    // --- DEL ������ 2012/10/16 for Redmine#31026----------<<<<<
                    // --- ADD ������ 2012/10/16 for Redmine#31026---------->>>>>
                    if ("SalesSlipRF".Equals(FileId))
                    {
                        // ����f�[�^
                        row[this._detailsTable.Columns[GET_DATA_TYPE]] = SalesSlipRF;
                        this._detailsTable.Rows.Add(row);
                    }else if("SalesDetailRF".Equals(FileId))
                    {
                        // ���㖾�׃f�[�^
                        row = this._detailsTable.NewRow();
                        row[this._detailsTable.Columns[GET_DATA_TYPE]] = SalesSlipRF1;
                        this._detailsTable.Rows.Add(row);
                    }
                    else if ("AcceptOdrRF".Equals(FileId))
                    {
                        // �󒍃}�X�^
                        row = this._detailsTable.NewRow();
                        row[this._detailsTable.Columns[GET_DATA_TYPE]] = SalesSlipRF2;
                        this._detailsTable.Rows.Add(row);
                    }
                    else if ("AcceptOdrCarRF".Equals(FileId))
                    {
                        // �󒍃}�X�^�i�ԗ��j
                        row = this._detailsTable.NewRow();
                        row[this._detailsTable.Columns[GET_DATA_TYPE]] = SalesSlipRF3;
                        this._detailsTable.Rows.Add(row);
                    }
                    else if ("SalesHistoryRF".Equals(FileId))
                    {
                        // ���㗚���f�[�^
                        row[this._detailsTable.Columns[GET_DATA_TYPE]] = SalesHistoryRF;
                        this._detailsTable.Rows.Add(row);
                    }
                    else if ("SalesHistDtlRF".Equals(FileId))
                    {
                        // ���㗚�𖾍׃f�[�^
                        row = this._detailsTable.NewRow();
                        row[this._detailsTable.Columns[GET_DATA_TYPE]] = SalesHistoryRF1;
                        this._detailsTable.Rows.Add(row);

                    }
                    else if ("DepsitMainRF".Equals(FileId))
                    {
                        // �����f�[�^
                        row[this._detailsTable.Columns[GET_DATA_TYPE]] = DepsitMainRF;
                        this._detailsTable.Rows.Add(row);
                    }
                    else if ("DepsitDtlRF".Equals(FileId))
                    {
                        // �������׃f�[�^
                        row = this._detailsTable.NewRow();
                        row[this._detailsTable.Columns[GET_DATA_TYPE]] = DepsitMainRF1;
                        this._detailsTable.Rows.Add(row);
                    }
                    else if ("StockSlipRF".Equals(FileId))
                    {
                        // �d���f�[�^
                        row[this._detailsTable.Columns[GET_DATA_TYPE]] = StockSlipRF;
                        this._detailsTable.Rows.Add(row);
                    }
                    else if ("StockDetailRF".Equals(FileId))
                    {
                        // �d�����׃f�[�^
                        row = this._detailsTable.NewRow();
                        row[this._detailsTable.Columns[GET_DATA_TYPE]] = StockSlipRF1;
                        this._detailsTable.Rows.Add(row);
                    }
                    else if ("StockSlipHistRF".Equals(FileId))
                    {
                        // �d�������f�[�^
                        row[this._detailsTable.Columns[GET_DATA_TYPE]] = StockSlipHistRF;
                        this._detailsTable.Rows.Add(row);
                    }
                    else if ("StockSlHistDtlRF".Equals(FileId))
                    {
                        // �d�����𖾍׃f�[�^
                        row = this._detailsTable.NewRow();
                        row[this._detailsTable.Columns[GET_DATA_TYPE]] = StockSlipHistRF1;
                        this._detailsTable.Rows.Add(row);
                    }
                    else if ("PaymentSlpRF".Equals(FileId))
                    {
                        // �x���`�[�}�X�^
                        row[this._detailsTable.Columns[GET_DATA_TYPE]] = PaymentSlpRF;
                        this._detailsTable.Rows.Add(row);
                    }
                    else if ("PaymentDtlRF".Equals(FileId))
                    {
                        // �x�����׃f�[�^
                        row = this._detailsTable.NewRow();
                        row[this._detailsTable.Columns[GET_DATA_TYPE]] = PaymentSlpRF1;
                        this._detailsTable.Rows.Add(row);
                    }
                    // --- ADD ������ 2012/10/16 for Redmine#31026----------<<<<<
                    else if ("StockAdjustRF".Equals(FileId))
                    {
                        // �݌ɒ����f�[�^
                        row[this._detailsTable.Columns[GET_DATA_TYPE]] = StockAdjustRF;
                        this._detailsTable.Rows.Add(row);
                    }
                    else if ("StockAdjustDtlRF".Equals(FileId))
                    {
                        // �݌ɒ������׃f�[�^
                        row[this._detailsTable.Columns[GET_DATA_TYPE]] = StockAdjustDtlRF;
                        this._detailsTable.Rows.Add(row);
                    }
                    else if ("StockMoveRF".Equals(FileId))
                    {
                        // �݌Ɉړ��f�[�^
                        row[this._detailsTable.Columns[GET_DATA_TYPE]] = StockMoveRF;
                        this._detailsTable.Rows.Add(row);
                    }
                    else if ("DepositAlwRF".Equals(FileId))
                    {
                        // ���������}�X�^
                        row[this._detailsTable.Columns[GET_DATA_TYPE]] = DepositAlwRF;
                        this._detailsTable.Rows.Add(row);
                    }
                    else if ("RcvDraftDataRF".Equals(FileId))
                    {
                        // ����`�f�[�^
                        row[this._detailsTable.Columns[GET_DATA_TYPE]] = RcvDraftDataRF;
                        this._detailsTable.Rows.Add(row);
                    }
                    else if ("PayDraftDataRF".Equals(FileId))
                    {
                        // �x����`�f�[�^
                        row[this._detailsTable.Columns[GET_DATA_TYPE]] = PayDraftDataRF;
                        this._detailsTable.Rows.Add(row);
                    }
                }
            }
            //�}�X�^
            else if (this._sndRcvHisTableWork.Kind == 1)
            {
                // --- ADD ������ 2012/10/16 for Redmine#31026---------->>>>>
                //����
                if (this._sndRcvHisTableWork.SndLogExtraCondDiv == 1)
                {
                // --- ADD ������ 2012/10/16 for Redmine#31026----------<<<<<
                    ArrayList resultList = this._searchEtrResultList as ArrayList;
                    SndRcvEtrWork work = null;
                    DataRow row = null;

                    if (resultList != null)
                    {
                        int sndRcvHisConsNo = this._sndRcvHisTableWork.SndRcvHisConsNo;  // ����M�������O���M�ԍ�
                        string sectionCode = this._sndRcvHisTableWork.SectionCode;       //���_�R�[�h
                        string enterpriseCode = this._sndRcvHisTableWork.EnterpriseCode; //��ƃR�[�h

                        for (int i = 0; i < resultList.Count; i++)
                        {
                            if (resultList[i].GetType() == typeof(SndRcvEtrWork))
                            {
                                work = resultList[i] as SndRcvEtrWork;
                                if (work.SndRcvHisConsNo == sndRcvHisConsNo && work.EnterpriseCode.Trim().Equals(enterpriseCode.Trim()) && work.SectionCode.Trim().Equals(sectionCode.Trim()))
                                {
                                    row = this._detailsTable.NewRow();
                                    row[this._detailsTable.Columns[START_CONDITION1]] = work.StartCond1;
                                    row[this._detailsTable.Columns[END_CONDITION1]] = work.EndCond1;
                                    row[this._detailsTable.Columns[START_CONDITION2]] = work.StartCond2;
                                    row[this._detailsTable.Columns[END_CONDITION2]] = work.EndCond2;
                                    row[this._detailsTable.Columns[START_CONDITION3]] = work.StartCond3;
                                    row[this._detailsTable.Columns[END_CONDITION3]] = work.EndCond3;
                                    row[this._detailsTable.Columns[START_CONDITION4]] = work.StartCond4;
                                    row[this._detailsTable.Columns[END_CONDITION4]] = work.EndCond4;
                                    row[this._detailsTable.Columns[START_CONDITION5]] = work.StartCond5;
                                    row[this._detailsTable.Columns[END_CONDITION5]] = work.EndCond5;
                                    row[this._detailsTable.Columns[START_CONDITION6]] = work.StartCond6;
                                    row[this._detailsTable.Columns[END_CONDITION6]] = work.EndCond6;
                                    row[this._detailsTable.Columns[START_CONDITION7]] = work.StartCond7;
                                    row[this._detailsTable.Columns[END_CONDITION7]] = work.EndCond7;
                                    row[this._detailsTable.Columns[START_CONDITION8]] = work.StartCond8;
                                    row[this._detailsTable.Columns[END_CONDITION8]] = work.EndCond8;
                                    row[this._detailsTable.Columns[START_CONDITION9]] = work.StartCond9;
                                    row[this._detailsTable.Columns[END_CONDITION9]] = work.EndCond9;
                                    row[this._detailsTable.Columns[START_CONDITION10]] = work.StartCond10;
                                    row[this._detailsTable.Columns[END_CONDITION10]] = work.EndCond10;

                                    if ("CustomerRF".Equals(work.FileId))
                                    {
                                        row[this._detailsTable.Columns[GET_DATA_TYPE]] = CustomerRF;
                                    }
                                    else if ("GoodsURF".Equals(work.FileId))
                                    {
                                        row[this._detailsTable.Columns[GET_DATA_TYPE]] = GoodsURF;
                                    }
                                    else if ("StockRF".Equals(work.FileId))
                                    {
                                        row[this._detailsTable.Columns[GET_DATA_TYPE]] = StockRF;
                                    }
                                    else if ("SupplierRF".Equals(work.FileId))
                                    {
                                        row[this._detailsTable.Columns[GET_DATA_TYPE]] = SupplierRF;
                                    }
                                    else if ("RateRF".Equals(work.FileId))
                                    {
                                        row[this._detailsTable.Columns[GET_DATA_TYPE]] = RateRF;
                                    }
                                    this._detailsTable.Rows.Add(row);
                                }
                            }
                        }
                    }
                    // --- ADD ������ 2012/10/16 for Redmine#31026---------->>>>>
                }
                else if (this._sndRcvHisTableWork.SndLogExtraCondDiv == 0)
                {
                    string[] fileId = this._sndRcvHisTableWork.SndRcvFileID.Split(',');
                    DataRow row = null;
                    string tempUserGuideDivCd = null;
                    foreach (string FileId in fileId)
                    {
                        row = this._detailsTable.NewRow();

                        if (FileId.Length >= 11 && MST_ID_USERGDU.Equals(FileId.Substring(0, 11)))
                        {
                            tempUserGuideDivCd = FileId.Substring(11);

                            // ���[�U�[�K�C�h�}�X�^(�̔��G���A�敪�j
                            if (tempUserGuideDivCd.Equals("21"))
                            {
                                row[this._detailsTable.Columns[GET_DATA_TYPE]] = MST_USERGDAREADIVU;
                                this._detailsTable.Rows.Add(row);
                            }
                            // ���[�U�[�K�C�h�}�X�^�i�Ɩ��敪�j
                            else if (tempUserGuideDivCd.Equals("31"))
                            {
                                row[this._detailsTable.Columns[GET_DATA_TYPE]] = MST_USERGDBUSDIVU;
                                this._detailsTable.Rows.Add(row);
                            }
                            // ���[�U�[�K�C�h�}�X�^�i�Ǝ�j
                            else if (tempUserGuideDivCd.Equals("33"))
                            {
                                row[this._detailsTable.Columns[GET_DATA_TYPE]] = MST_USERGDCATEU;
                                this._detailsTable.Rows.Add(row);
                            }
                            // ���[�U�[�K�C�h�}�X�^�i�E��j
                            else if (tempUserGuideDivCd.Equals("34"))
                            {
                                row[this._detailsTable.Columns[GET_DATA_TYPE]] = MST_USERGDBUSU;
                                this._detailsTable.Rows.Add(row);
                            }
                            // ���[�U�[�K�C�h�}�X�^�i���i�敪�j
                            else if (tempUserGuideDivCd.Equals("41"))
                            {
                                row[this._detailsTable.Columns[GET_DATA_TYPE]] = MST_USERGDGOODSDIVU;
                                this._detailsTable.Rows.Add(row);
                            }
                            // ���[�U�[�K�C�h�}�X�^�i���Ӑ�|���O���[�v�j
                            else if (tempUserGuideDivCd.Equals("43"))
                            {
                                row[this._detailsTable.Columns[GET_DATA_TYPE]] = MST_USERGDCUSGROUPU;
                                this._detailsTable.Rows.Add(row);
                            }
                            // ���[�U�[�K�C�h�}�X�^�i��s�j
                            else if (tempUserGuideDivCd.Equals("46"))
                            {
                                row[this._detailsTable.Columns[GET_DATA_TYPE]] = MST_USERGDBANKU;
                                this._detailsTable.Rows.Add(row);
                            }
                            // ���[�U�[�K�C�h�}�X�^�i���i�敪�j
                            else if (tempUserGuideDivCd.Equals("47"))
                            {
                                row[this._detailsTable.Columns[GET_DATA_TYPE]] = MST_USERGDPRIDIVU;
                                this._detailsTable.Rows.Add(row);
                            }
                            // ���[�U�[�K�C�h�}�X�^�i�[�i�敪�j
                            else if (tempUserGuideDivCd.Equals("48"))
                            {
                                row[this._detailsTable.Columns[GET_DATA_TYPE]] = MST_USERGDDELIDIVU;
                                this._detailsTable.Rows.Add(row);
                            }
                            // ���[�U�[�K�C�h�}�X�^�i���i�啪�ށj
                            else if (tempUserGuideDivCd.Equals("70"))
                            {
                                row[this._detailsTable.Columns[GET_DATA_TYPE]] = MST_USERGDGOODSBIGU;
                                this._detailsTable.Rows.Add(row);
                            }
                            // ���[�U�[�K�C�h�}�X�^�i�̔��敪�j
                            else if (tempUserGuideDivCd.Equals("71"))
                            {
                                row[this._detailsTable.Columns[GET_DATA_TYPE]] = MST_USERGDBUYDIVU;
                                this._detailsTable.Rows.Add(row);
                            }
                            // ���[�U�[�K�C�h�}�X�^�i�݌ɊǗ��敪�P�j
                            else if (tempUserGuideDivCd.Equals("72"))
                            {
                                row[this._detailsTable.Columns[GET_DATA_TYPE]] = MST_USERGDSTOCKDIVOU;
                                this._detailsTable.Rows.Add(row);
                            }
                            // ���[�U�[�K�C�h�}�X�^�i�݌ɊǗ��敪�Q�j
                            else if (tempUserGuideDivCd.Equals("73"))
                            {
                                row[this._detailsTable.Columns[GET_DATA_TYPE]] = MST_USERGDSTOCKDIVTU;
                                this._detailsTable.Rows.Add(row);
                            }
                            // ���[�U�[�K�C�h�}�X�^�i�ԕi���R�j
                            else if (tempUserGuideDivCd.Equals("91"))
                            {
                                row[this._detailsTable.Columns[GET_DATA_TYPE]] = MST_USERGDRETURNREAU;
                                this._detailsTable.Rows.Add(row);
                            }
                        }
                        else if (MST_ID_SECINFOSET.Equals(FileId))
                        {
                            // ���_�ݒ�}�X�^
                            row[this._detailsTable.Columns[GET_DATA_TYPE]] = MST_SECINFOSET;
                            this._detailsTable.Rows.Add(row);
                        }
                        else if (MST_ID_SUBSECTION.Equals(FileId))
                        {
                            //����ݒ�}�X�^
                            row[this._detailsTable.Columns[GET_DATA_TYPE]] = MST_SUBSECTION;
                            this._detailsTable.Rows.Add(row);
                        }
                        else if (MST_ID_WAREHOUSE.Equals(FileId))
                        {
                            //�q�ɐݒ�}�X�^
                            row[this._detailsTable.Columns[GET_DATA_TYPE]] = MST_WAREHOUSE;
                            this._detailsTable.Rows.Add(row);
                        }
                        else if (MST_ID_EMPLOYEE.Equals(FileId)||MST_ID_EMPLOYEEDTL.Equals(FileId))
                        {
                            //�]�ƈ��}�X�^�A�]�ƈ��ڍ׃}�X�^
                            row[this._detailsTable.Columns[GET_DATA_TYPE]] = MST_EMPLOYEE;
                            this._detailsTable.Rows.Add(row);
                        }
                        else if (MST_ID_CUSTOME.Equals(FileId) || MST_ID_CUSTOMECHA.Equals(FileId) || MST_ID_CUSTOMESLIPMNG.Equals(FileId) || MST_ID_CUSTOMEGROUP.Equals(FileId) || MST_ID_CUSTOMESLIPNO.Equals(FileId))
                        {
                            //���Ӑ�}�X�^�A���Ӑ�}�X�^(�ϓ����)�A���Ӑ�}�X�^�i�`�[�Ǘ��j�A���Ӑ�}�X�^�i�|���O���[�v�j�A���Ӑ�}�X�^(�`�[�ԍ�)
                            row[this._detailsTable.Columns[GET_DATA_TYPE]] = MST_CUSTOME;
                            this._detailsTable.Rows.Add(row);
                        }
                        else if (MST_ID_SUPPLIER.Equals(FileId))
                        {
                            //�d����}�X�^
                            row[this._detailsTable.Columns[GET_DATA_TYPE]] = MST_SUPPLIER;
                            this._detailsTable.Rows.Add(row);
                        }
                        else if (MST_ID_MAKERU.Equals(FileId))
                        {
                            //���[�J�[�}�X�^�i���[�U�[�o�^���j
                            row[this._detailsTable.Columns[GET_DATA_TYPE]] = MST_MAKERU;
                            this._detailsTable.Rows.Add(row);
                        }
                        else if (MST_ID_BLGOODSCDU.Equals(FileId))
                        {
                            //BL���i�R�[�h�}�X�^�i���[�U�[�o�^���j
                            row[this._detailsTable.Columns[GET_DATA_TYPE]] = MST_BLGOODSCDU;
                            this._detailsTable.Rows.Add(row);
                        }
                        else if (MST_ID_GOODSU.Equals(FileId) || MST_ID_GOODSUPRI.Equals(FileId) || MST_ID_GOODSUMNG.Equals(FileId) || MST_ID_GOODSUISO.Equals(FileId))
                        {
                            //���i�}�X�^�i���[�U�[�o�^���j�A���i�}�X�^�i���[�U�[�o�^�j�A���i�Ǘ����}�X�^�A�������i�}�X�^
                            row[this._detailsTable.Columns[GET_DATA_TYPE]] = MST_GOODSU;
                            this._detailsTable.Rows.Add(row);
                        }
                        else if (MST_ID_STOCK.Equals(FileId))
                        {
                            //�݌Ƀ}�X�^
                            row[this._detailsTable.Columns[GET_DATA_TYPE]] = MST_STOCK;
                            this._detailsTable.Rows.Add(row);
                        }
                        else if (MST_ID_RATEPROTYMNG.Equals(FileId))
                        {
                            //�|���D��Ǘ��}�X�^
                            row[this._detailsTable.Columns[GET_DATA_TYPE]] = MST_RATEPROTYMNG;
                            this._detailsTable.Rows.Add(row);
                        }
                        else if (MST_ID_RATE.Equals(FileId))
                        {
                            //�|���}�X�^
                            row[this._detailsTable.Columns[GET_DATA_TYPE]] = MST_RATE;
                            this._detailsTable.Rows.Add(row);
                        }
                        else if (MST_ID_GOODSSET.Equals(FileId))
                        {
                            //���i�Z�b�g�}�X�^
                            row[this._detailsTable.Columns[GET_DATA_TYPE]] = MST_GOODSSET;
                            this._detailsTable.Rows.Add(row);
                        }
                        else if (MST_ID_PARTSSUBSTU.Equals(FileId))
                        {
                            //���i��փ}�X�^�i���[�U�[�o�^���j
                            row[this._detailsTable.Columns[GET_DATA_TYPE]] = MST_PARTSSUBSTU;
                            this._detailsTable.Rows.Add(row);
                        }
                        else if (MST_ID_EMPSALESTARGET.Equals(FileId))
                        {
                            //�]�ƈ��ʔ���ڕW�ݒ�}�X�^
                            row[this._detailsTable.Columns[GET_DATA_TYPE]] = MST_SALESTARGET;
                            this._detailsTable.Rows.Add(row);
                        }
                        else if (MST_ID_CUSTSALESTARGET.Equals(FileId) || MST_ID_GCDSALESTARGET.Equals(FileId))
                        {
                            //���Ӑ�ʔ���ڕW�ݒ�}�X�^�A���i�ʔ���ڕW�ݒ�}�X�^
                            row[this._detailsTable.Columns[GET_DATA_TYPE]] = MST_SALESTARGET;
                            this._detailsTable.Rows.Add(row);
                        }
                        else if (MST_ID_GOODSMGROUPU.Equals(FileId))
                        {
                            //���i�����ރ}�X�^�i���[�U�[�o�^���j
                            row[this._detailsTable.Columns[GET_DATA_TYPE]] = MST_GOODSMGROUPU;
                            this._detailsTable.Rows.Add(row);
                        }
                        else if (MST_ID_BLGROUPU.Equals(FileId))
                        {
                            //BL�O���[�v�}�X�^�i���[�U�[�o�^���j
                            row[this._detailsTable.Columns[GET_DATA_TYPE]] = MST_BLGROUPU;
                            this._detailsTable.Rows.Add(row);
                        }
                        else if (MST_ID_JOINPARTSU.Equals(FileId))
                        {
                            //�����}�X�^�i���[�U�[�o�^���j
                            row[this._detailsTable.Columns[GET_DATA_TYPE]] = MST_JOINPARTSU;
                            this._detailsTable.Rows.Add(row);
                        }
                        else if (MST_ID_TBOSEARCHU.Equals(FileId))
                        {
                            //TBO�����}�X�^�i���[�U�[�o�^�j
                            row[this._detailsTable.Columns[GET_DATA_TYPE]] = MST_TBOSEARCHU;
                            this._detailsTable.Rows.Add(row);
                        }
                        else if (MST_ID_PARTSPOSCODEU.Equals(FileId))
                        {
                            //���ʃR�[�h�}�X�^�i���[�U�[�o�^�j
                            row[this._detailsTable.Columns[GET_DATA_TYPE]] = MST_PARTSPOSCODEU;
                            this._detailsTable.Rows.Add(row);
                        }
                        else if (MST_ID_BLCODEGUIDE.Equals(FileId))
                        {
                            //BL�R�[�h�K�C�h�}�X�^
                            row[this._detailsTable.Columns[GET_DATA_TYPE]] = MST_BLCODEGUIDE;
                            this._detailsTable.Rows.Add(row);
                        }
                        else if (MST_ID_MODELNAMEU.Equals(FileId))
                        {
                            //�Ԏ햼�̃}�X�^
                            row[this._detailsTable.Columns[GET_DATA_TYPE]] = MST_MODELNAMEU;
                            this._detailsTable.Rows.Add(row);
                        }
                    }
                }
                   // --- ADD ������ 2012/10/16 for Redmine#31026----------<<<<<
            }
        }
        #endregion �� Private Method ��
    }
}