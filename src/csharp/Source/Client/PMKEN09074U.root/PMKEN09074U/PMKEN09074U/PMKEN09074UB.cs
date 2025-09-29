//****************************************************************************//
// �V�X�e��         : .NS�V���[�Y
// �v���O��������   : �����}�X�^
// �v���O�����T�v   : �����}�X�^�̓o�^�E�X�V�E�폜���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30415 �ēc �ύK
// �� �� ��  2008/07/28  �C�����e : Partsman�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30413 ����
// �� �� ��  2009/02/12  �C�����e : ���x�A�b�v�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30413 ����
// �� �� ��  2009/04/09  �C�����e : �폜���i�̏��i�����\���ɏC��
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30413 ����
// �� �� ��  2009/06/22  �C�����e : MANTIS�y13572�z�y13573�z�y13574�z
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30413 ����
// �� �� ��  2009/06/24  �C�����e : MANTIS�y13575�z
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 22008 ����
// �� �� ��  2009/07/16  �C�����e : Mantis�y13573�z�y13574�z
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 22008 ����
// �� �� ��  2009/10/30  �C�����e : Mantis�y14536�z
//                                : GoodsSetDetailDataTable.SetNote �̌�����ύX 40��80
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30517 �Ė� �x��
// �� �� ��  2010/01/05  �C�����e : Mantis�y14852�z
//                                : �\�����ʁF00�Ń����e�i���X�\�ɕύX����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30517 �Ė� �x��
// �� �� ��  2010/07/14  �C�����e : Mantis�y15808�z
//                                : �A���ōs�폜����ƃG���[�ƂȂ�i�t�B�[�h�o�b�N�j
//                                : �s�폜��폜����ƃG���[�ƂȂ�i�t�B�[�h�o�b�N�j
//                                : �񋟕��V�K�o�^���A�s�ǉ����Ă��s�폜�{�^�����L���ɂȂ�Ȃ��i�t�B�[�h�o�b�N�j
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ����
// �� �� ��  2010/12/03  �C�����e : ������i�ԓ��͎��̗�O�G���[
//                                : �������ׂ̍s�폜���̃G���[
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10704766-00 �쐬�S�� : ���J
// �C �� ��  2011/09/01  �C�����e : �I�������݌ɂ������\�������悤�C���̑Ή�
//                                : �Č��ꗗ �A��984 FOR redmine #24263
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10902175-00 �쐬�S�� : �{�{ ����
// �C �� ��  2013/10/03  �C�����e : �d�|�ꗗ ��2154�Ή�(2011/09/01�C���ɂ���Q)
//                                : �����̌������ďo����2011/09/01�Ή��͕s�v
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10902175-00 �쐬�S�� : �{�{ ����
// �C �� ��  2013/10/08  �C�����e : �d�|�ꗗ ��2094�Ή�
//                                : ���P���̎擾�Ɋ|���}�X�^�̐ݒ���܂߂�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10904597-00 �쐬�S�� : �{�{ ����
// �C �� ��  2013/12/02  �C�����e : �����擾���|���}�X�^�̒P�i�ݒ�̂ݑΏۂƂ���
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ����
// �� �� ��  2013/12/04  �C�����e : ���ׂ̍��ڈʒu��ێ�����悤�ɑΉ�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : gezh
// �� �� ��  2014/01/21  �C�����e : Redmine#41447������Q�̏C��
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11170188-00 �쐬�S�� : ���V��
// �� �� ��  2015/10/28  �C�����e : Redmine#47547 ������i�ԓ��͎��� "." ����͂ł��Ȃ����Ƃ̑Ή�
//----------------------------------------------------------------------------//

using System;
using System.IO; // ADD �����@2013/12/04 FOR Redmine#41447
using System.Collections;
using System.ComponentModel;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Broadleaf.Application.Common;
using Broadleaf.Application.Controller;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.Resources; // ADD �����@2013/12/04 FOR Redmine#41447

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// ���������̓R���g���[���N���X
    /// </summary>
    /// <remarks>
    /// <br>------------------------------------------------------------------------------------</br>
    /// <br>UpdateNote : PM.NS�p�ɕύX����(�ύX�_���������邽�ߕύX�R�����g�͎c���܂���)        </br>
    /// <br>Programmer : 30415 �ēc �ύK                                                        </br>
    /// <br>Date       : 2008/07/28                                                             </br>
    /// <br>------------------------------------------------------------------------------------</br>    
    /// <br>UpdateNote : ���x�A�b�v�Ή�</br>
    /// <br>Programmer : 30413 ����</br>
    /// <br>Date       : 2009/02.12</br>
    /// <br>------------------------------------------------------------------------------------</br>
    /// <br>UpdateNote : �Č��ꗗ �A��984 �̑Ή�                                                </br>
    /// <br>           : �I�������݌ɂ������\�������悤�C�� FOR redmine #24263                </br>
    /// <br>Programmer : ���J                                                                   </br>
    /// <br>Date       : 2011/09/01                                                             </br>
    /// <br>------------------------------------------------------------------------------------</br>
    /// <br>UpdateNote : ���ׂ̍��ڈʒu��ێ�����悤�ɑΉ�</br>
    /// <br>Programmer : ����</br>
    /// <br>Date       : 2013/12/04</br>
    /// <br>------------------------------------------------------------------------------------</br>
    /// <br>UpdateNote : Redmine#41447������Q�̏C��</br>
    /// <br>Programmer : gezh</br>
    /// <br>Date       : 2014/01/21</br>
    /// <br>------------------------------------------------------------------------------------</br>
    /// <br>UpdateNote : Redmine#47547 ������i�ԓ��͎��� "." ����͂ł��Ȃ����Ƃ̑Ή�          </br>
    /// <br>Programmer : ���V��                                                                 </br>
    /// <br>Date       : 2015/10/28                                                             </br>
    /// <br>------------------------------------------------------------------------------------</br>
    /// </remarks>
    public partial class PMKEN09074UB : UserControl
    {
        #region ��Constractor
        /// <summary>
        /// ���������̓R���g���[���N���X�R���X�g���N�^
        /// </summary>
        /// <param name="joinPartsUAcs">�����}�X�^�i���[�U�[�o�^�j�A�N�Z�X</param>
        /// <remarks>
        /// <br>Update Note : 2010/12/03 ���� �������ׂ̍s�폜���̃G���[���C��</br>
        /// </remarks>
        public PMKEN09074UB(JoinPartsUAcs joinPartsUAcs)    // ADD 2008/10/17 �s��Ή�[6559] �����FjoinPartsUAcs ��ǉ�
        {
            InitializeComponent();

            _goodsDetailDataTable = new GoodsSetGoodsDataSet.GoodsSetDetailDataTable();

            // �폜�e�[�u��
            _deleteGoodsDetailDataTable = new GoodsSetGoodsDataSet.GoodsSetDetailDataTable();

            // -- ADD 2010/12/03 ------------------------------>>>
            // �폜�e�[�u���̎�L�[���unull�v�Ƃ���
            _deleteGoodsDetailDataTable.PrimaryKey = null;
            // -- ADD 2010/12/03 ------------------------------<<<

            // ��ƃR�[�h���擾����
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

            // ���i�Z�b�g�}�X�^�A�N�Z�X�N���X�C���X�^���X��
            this._joinPartsUAcs = joinPartsUAcs;  // ADD 2008/10/17 �s��Ή�[6559]

            // �݌ɏ��
            _storeDic = new Dictionary<string, ArrayList>();
            
            // ���i�A���f�[�^���[�J���L���b�V��
            _lcGoodsUnitDataList = new List<GoodsUnitData>();

            // ADD START �����@2013/12/04 FOR Redmine#41447 ------>>>>>>
            this._userSetting = new IntegrateMstUserConst();

            this.Deserialize();

            // ���׃O���b�h
            this.LoadGridColumnsSetting(ref uGrid_Details, this._detailColumnsList);
            // ADD END �����@2013/12/04 FOR Redmine#41447 ------<<<<<<
        }

        #endregion

        #region ��Private Members

        private GoodsSetGoodsDataSet.GoodsSetDetailDataTable _goodsDetailDataTable;
        private Image _guideButtonImage;
        private ImageList _imageList16;

        // �����\���s��
        private int _defaultRowCnt = 100;

        // �폜�e�[�u��
        private GoodsSetGoodsDataSet.GoodsSetDetailDataTable _deleteGoodsDetailDataTable;
        
        // ��ƃR�[�h
        private string _enterpriseCode;

        // �ύX�t���O
        private bool _changeFlg;

        /// <summary>�����}�X�^�i���[�U�[�o�^�j�A�N�Z�X</summary>
        private JoinPartsUAcs _joinPartsUAcs;

        // �݌ɏ��i�[�f�B�N�V���i���[
        private Dictionary<string, ArrayList> _storeDic;
        
        // ���������[�J�[�R�[�h
        private int _joinSourceMakerCode;

        // �������i��
        private string _joinSourPartsNoWithH;

        // �������i�̕i�ԍX�V�敪
        private bool _joinGoodNoUpdFlg = true;

        /// <summary>���i�A�����[�J���L���b�V���p�f�[�^���X�g�N���X</summary>
        private List<GoodsUnitData> _lcGoodsUnitDataList;

        // �ҏW�O�̌�����i��
        private string _childGoodsNo = "";

        private bool _deleteBtnFlag = true;

        // ADD START �����@2013/12/04 FOR Redmine#41447 ------>>>>>>
        /// <summary>�ݒ�t�@�C����̗�ԍ���3���[���l��</summary>
        static public readonly int ct_ColumnCountLength = 3;
        // ���[�U�[�ݒ�
        private IntegrateMstUserConst _userSetting;
        // ���׃O���b�h�J�������X�g
        private List<ColumnInfo> _detailColumnsList;
        /// <summary>�ݒ�XML�t�@�C����</summary>
        private const string XML_FILE_NAME = "PMKEN09074UB_Construction.XML";
        //�������t���O
        private bool _initialLoadFlag = false;
        // ADD END �����@2013/12/04 FOR Redmine#41447 ------<<<<<<

        #endregion

        /// public propaty name  :  JoinSourceMakerCode
        /// <summary>���������[�J�[�R�[�h�v���p�e�B</summary>
        public int JoinSourceMakerCode
        {
            get { return _joinSourceMakerCode; }
            set { _joinSourceMakerCode = value; }
        }

        /// public propaty name  :  JoinSourPartsNoWithH
        /// <summary>�������i�ԃv���p�e�B</summary>
        public string JoinSourPartsNoWithH
        {
            get { return _joinSourPartsNoWithH; }
            set { _joinSourPartsNoWithH = value; }
        }

        /// public propaty name  :  DeleteBtnFlag
        /// <summary>�폜�{�^���̗L���v���p�e�B</summary>
        public bool DeleteBtnFlag
        {
            get { return _deleteBtnFlag; }
            set { _deleteBtnFlag = value; }
        }

        // ADD START �����@2013/12/04 FOR Redmine#41447 ------>>>>>>
        /// <summary>�����}�X�^���[�U�[�ݒ�</summary>
        public IntegrateMstUserConst UserSetting
        {
            get { return this._userSetting; }
        }

        /// <summary>���׃O���b�h�J�������X�g</summary>
        public List<ColumnInfo> DetailColumnsList
        {
            get { return this._detailColumnsList; }
            set { this._detailColumnsList = value; }
        }

        /// <summary>�������t���O</summary>
        public bool InitialLoadFlag
        {
            get { return this._initialLoadFlag; }
            set { this._initialLoadFlag = value; }
        }
        // ADD END �����@2013/12/04 FOR Redmine#41447 ------<<<<<<

        # region ��Event

        /// <summary>�O���b�h�ŏ�ʍs�L�[�_�E���C�x���g</summary>
        internal event EventHandler GridKeyDownTopRow;

        /// <summary>�O���b�h�ŉ��w�s�L�[�_�E���C�x���g</summary>
        internal event EventHandler GridKeyDownButtomRow;
        
        # endregion

        #region ��Public Methods

        /// <summary>
        /// �������s�ǉ�����
        /// </summary>
        /// <remarks>
        /// </remarks>
        public void AddGoodsDetailRow()
        {
            // No�̔Ԃ̂��߂Ƀf�[�^�e�[�u���̍s�����J�E���g����
            int rowCount = this._goodsDetailDataTable.Rows.Count;

            GoodsSetGoodsDataSet.GoodsSetDetailRow row = this._goodsDetailDataTable.NewGoodsSetDetailRow();
            row.No = (short)(rowCount + 1);
            this._goodsDetailDataTable.AddGoodsSetDetailRow(row);
        }

        /// <summary>
        /// �f�[�^�e�[�u���O���b�h�o�C���h����
        /// </summary>
        /// <remarks>
        /// </remarks>
        public void SetJoinPartsUGrid()   // MEMO:�O���b�h�̏����ݒ�
        {
            // �O���b�h�ɕ\������f�[�^�e�[�u����ݒ�
            uGrid_Details.DataSource = _goodsDetailDataTable;

            // �O���b�h�����ݒ�
            this.InitialSettingGridCol();

            // �{�^���̏����ݒ�
            ButtonInitialSetting();

            // �O���b�h�L�[�}�b�s���O�ݒ菈��
            this.MakeKeyMappingForGrid(this.uGrid_Details);
        }

        /// <summary>
        /// �f�[�^�s�f�[�^�e�[�u���i�[����
        /// </summary>
        /// <param name="No">�\��No</param>
        /// <param name="goodsUnitData">�I�����ꂽ�f�[�^�s</param>
        /// <param name="unitPriceCalcRet">�P���Z�o����</param>
        /// <remarks>
        /// <br>UpdateNote : 2011/09/01 ���J �Č��ꗗ �A��984 �̑Ή� �I�������݌ɂ������\�������悤�C�� FOR redmine #24263</br>
        /// </remarks>
        // --- UPD 2013/10/08 T.Miyamoto ------------------------------>>>>>
        //public void SetJoinPartsUDataTable(int No, GoodsUnitData goodsUnitData)
        public void SetJoinPartsUDataTable(int No, GoodsUnitData goodsUnitData, UnitPriceCalcRet unitPriceCalcRet)
        // --- UPD 2013/10/08 T.Miyamoto ------------------------------<<<<<
        {
            this._goodsDetailDataTable.BeginLoadData();

            // �\���s
            GoodsSetGoodsDataSet.GoodsSetDetailRow detailRow;

            // ��̓��͍s�ȏ�f�[�^�����݂���ꍇ�͐V�K�s������ăf�[�^���i�[
            if (No > _defaultRowCnt)
            {
                detailRow = this._goodsDetailDataTable.NewGoodsSetDetailRow();
            }
            // ��̓��͍s�ȉ��̏ꍇ�͑��݂���s���ƕϐ�No����v����s���X�V����
            else
            {
                detailRow = (GoodsSetGoodsDataSet.GoodsSetDetailRow)this._goodsDetailDataTable.Rows.Find((short)No);
            }

            // �K�v�ȍ��ڂ����O���b�h�\���f�[�^�e�[�u���ɃZ�b�g
            detailRow.No = (short)No;                                                   // No
            detailRow.Disply = goodsUnitData.JoinDispOrder;                             // �\������
            detailRow.GoodsCode = goodsUnitData.GoodsNo;                                // �i��
            detailRow.GoodsName = goodsUnitData.GoodsName;                              // �i��
            // DEL 2009/04/09 ------>>>
            //detailRow.MakerCode = goodsUnitData.GoodsMakerCd.ToString("d04");           // ���[�J�[�R�[�h
            //detailRow.MakerName = goodsUnitData.MakerName;                              // ���[�J�[����
            // DEL 2009/04/09 ------<<<
            
            // ADD 2009/04/09 ------>>>
            if (goodsUnitData.GoodsMakerCd == 0)
            {
                detailRow.MakerCode = string.Empty;
                detailRow.MakerName = string.Empty;
            }
            else
            {
                detailRow.MakerCode = goodsUnitData.GoodsMakerCd.ToString("d04");           // ���[�J�[�R�[�h
                detailRow.MakerName = goodsUnitData.MakerName;                              // ���[�J�[����
            }
            // ADD 2009/04/09 ------<<<

            detailRow.Qty = goodsUnitData.JoinQty.ToString("##0.00");                   // �p�s�x(����)
            detailRow.SetNote = goodsUnitData.JoinSpecialNote;                          // �����K�i�E���L����

            //detailRow.OfferDate = goodsUnitData.OfferDate;        // �񋟓��t
            // 2009/07/16 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            //�s�폜����null�l���G���[�h������
            detailRow.OfferDate = "";        // �񋟓��t
            // 2009/07/16 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<
            
            // ���i���X�g���猻�݂̉��i���擾
            GoodsPrice goodsPrice = this._joinPartsUAcs.GetGoodsPriceFromGoodsPriceList(goodsUnitData.GoodsPriceList);
            if (goodsPrice != null)
            {
                detailRow.Price = goodsPrice.ListPrice;                                 // �W�����i
                detailRow.Cost = goodsPrice.SalesUnitCost;                              // ���P��
            }
            // 2009.03.26 30413 ���� �����揤�i�̏��i�}�X�^�폜�`�F�b�N >>>>>>START
            else
            {
                // �����l�ݒ�
                detailRow.Price = 0.0;                                                  // �W�����i
                detailRow.Cost = 0.0;                                                   // ���P��
            }
            // 2009.03.26 30413 ���� �����揤�i�̏��i�}�X�^�폜�`�F�b�N <<<<<<END
            // --- ADD 2013/10/08 T.Miyamoto ------------------------------>>>>>
            if (unitPriceCalcRet != null)
            {
                detailRow.Cost = unitPriceCalcRet.UnitPriceTaxExcFl; // ���P��
            }
            // --- ADD 2013/10/08 T.Miyamoto ------------------------------<<<<<
            
            // �q�Ƀ��X�g�̏����擾
            //if (goodsUnitData.StockList.Count != 0)
            if ((goodsUnitData.StockList != null) && (goodsUnitData.StockList.Count != 0))  // 2009.03.26 �폜�`�F�b�N�Ή�
            {
                // --- UPD 2013/10/03 T.Miyamoto ------------------------------>>>>>
                ///* -------------------- DEL 2011/09/01 --------------------- >>>>>
                //detailRow.StoreCode = goodsUnitData.StockList[0].WarehouseCode;         // �q�ɃR�[�h
                //detailRow.Store = goodsUnitData.StockList[0].WarehouseName;             // �q�ɖ���
                //detailRow.ShelfNo = goodsUnitData.StockList[0].WarehouseShelfNo;        // �I��
                //detailRow.Stock = goodsUnitData.StockList[0].ShipmentPosCnt;            // ���݌�
                //----------------------- DEL 2011/09/01 --------------------- <<<<<*/
                //// ----------------- ADD 2011/09/01 ------------------- >>>>>
                //Stock stock = new Stock();
                //foreach (Stock stockBak in goodsUnitData.StockList)
                //{
                //    if (stockBak.WarehouseCode == goodsUnitData.SelectedWarehouseCode)
                //    {
                //        stock = stockBak;
                //    }
                //}
                //detailRow.Store = stock.WarehouseName;                            // �q�ɖ���
                //detailRow.ShelfNo = stock.WarehouseShelfNo;                       // �I��
                //detailRow.Stock = stock.ShipmentPosCnt;                           // ���݌�
                //detailRow.StoreCode = stock.WarehouseCode;                        // �q�ɃR�[�h
                //// ----------------- ADD 2011/09/01 ------------------- <<<<<
                detailRow.StoreCode = goodsUnitData.StockList[0].WarehouseCode;         // �q�ɃR�[�h
                detailRow.Store = goodsUnitData.StockList[0].WarehouseName;             // �q�ɖ���
                detailRow.ShelfNo = goodsUnitData.StockList[0].WarehouseShelfNo;        // �I��
                detailRow.Stock = goodsUnitData.StockList[0].ShipmentPosCnt;            // ���݌�
                // --- UPD 2013/10/03 T.Miyamoto ------------------------------<<<<<

                // �݌ɏ�񃊃X�g�̍쐬
                string key = goodsUnitData.GoodsNo + "-" + goodsUnitData.GoodsMakerCd.ToString("d4");
                if (!this._storeDic.ContainsKey(key))
                {
                    ArrayList storeList = new ArrayList();
                    foreach (Stock wkStock in goodsUnitData.StockList)
                    {
                        JoinPartsUAcs.F_DATA_STORE dataStore = new JoinPartsUAcs.F_DATA_STORE();
                        dataStore.joinDestMakerCd = goodsUnitData.GoodsMakerCd;
                        dataStore.joinDestPartsNo = goodsUnitData.GoodsNo;
                        dataStore.store = wkStock.WarehouseName;
                        dataStore.shelfNo = wkStock.WarehouseShelfNo;
                        dataStore.stock = wkStock.ShipmentPosCnt;
                        dataStore.storeCode = wkStock.WarehouseCode;

                        if (!storeList.Contains(dataStore))
                        {
                            storeList.Add(dataStore);
                        }
                    }
                    this._storeDic.Add(key, storeList);
                }
            }
            // 2009/07/16 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            else
            {
                detailRow.StoreCode = "";
                detailRow.Store = "";
                detailRow.ShelfNo = "";
                detailRow.Stock = 0;
            }
            // 2009/07/16 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<


            // �V�K�s�̂Ƃ��̂ݐV�����s��ǉ����邽��Add�������K�v
            if (No > _defaultRowCnt)
            {
                this._goodsDetailDataTable.AddGoodsSetDetailRow(detailRow);
            }

            // �񋟃f�[�^�s��ҏW�s�Ƃ���
            // -- UPD 2009/10/30 ------------------------------>>>
            //�\�����ʂP�O�O�Ԉȍ~��񋟃f�[�^�Ƃ���
            //if (!this._joinPartsUAcs.CheckDivision(goodsUnitData))
            if (goodsUnitData.JoinDispOrder >= 100)
            // -- UPD 2009/10/30 ------------------------------<<<
            {
                // �񋟃f�[�^
                detailRow.OfferKubun = "0";
                detailRow.EditFlg = false;                                              // �ҏW�ۃt���O

                int rowIdx = No - 1;
                this.uGrid_Details.Rows[rowIdx].Cells[this._goodsDetailDataTable.DisplyColumn.ColumnName].Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                this.uGrid_Details.Rows[rowIdx].Cells[this._goodsDetailDataTable.GoodsCodeColumn.ColumnName].Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                this.uGrid_Details.Rows[rowIdx].Cells[this._goodsDetailDataTable.QtyColumn.ColumnName].Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                this.uGrid_Details.Rows[rowIdx].Cells[this._goodsDetailDataTable.SetNoteColumn.ColumnName].Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            }
            else
            {
                // ���[�U�f�[�^
                detailRow.OfferKubun = "1";
                detailRow.EditFlg = true;                                               // �ҏW�ۃt���O

                // Tab����
                int rowIdx = No - 1;
                this.uGrid_Details.Rows[rowIdx].Cells[this._goodsDetailDataTable.QtyColumn.ColumnName].TabStop = Infragistics.Win.DefaultableBoolean.True;
                this.uGrid_Details.Rows[rowIdx].Cells[this._goodsDetailDataTable.SetNoteColumn.ColumnName].TabStop = Infragistics.Win.DefaultableBoolean.True;
            }

            detailRow.AddFlag = false;                                                  // �ǉ��t���O
            
            this._goodsDetailDataTable.EndLoadData();
        }

        /// <summary>
        /// �폜�Ώۃf�[�^�e�[�u���i�[����
        /// </summary>
        /// <param name="deleteDataList">�I�����ꂽ�f�[�^�s</param>
        /// <remarks>
        /// </remarks>
        public void GetDeleteData(out List<GoodsSetGoodsDataSet.GoodsSetDetailRow> deleteDataList)
        {
            deleteDataList = new List<GoodsSetGoodsDataSet.GoodsSetDetailRow>();

            // �폜�Ώۃf�[�^�e�[�u���̌������J�E���g
            int totalCnt = this._deleteGoodsDetailDataTable.Rows.Count;

            for (int i = 0; i < totalCnt; i++)
            {
                GoodsSetGoodsDataSet.GoodsSetDetailRow row = (GoodsSetGoodsDataSet.GoodsSetDetailRow)this._deleteGoodsDetailDataTable.Rows[i];

                // �폜�Ώۃf�[�^�e�[�u����ǉ�
                deleteDataList.Add(row);
            }
        }

        /// <summary>
        /// �f�[�^�e�[�u���N���A����
        /// </summary>
        /// <remarks>
        /// </remarks>
        public void ClearGoodsSetDataTable()
        {
            this._goodsDetailDataTable.Clear();

            // �폜�f�[�^�e�[�u��
            this._deleteGoodsDetailDataTable.Clear();

            //this.uGrid_Details.DataSource = null;   // ADD 2008/10/24 �s��Ή�[7009] // DEL �����@2013/12/04 FOR Redmine#41447

            // ���[�J���L���b�V�����N���A
            this._lcGoodsUnitDataList.Clear();
        }

        /// <summary>
        /// �f�[�^�e�[�u�����Z�b�g����
        /// </summary>
        /// <remarks>
        /// </remarks>
        public void ResetGoodsSetDataTable()
        {
            this._goodsDetailDataTable.Reset();

            // �폜�f�[�^�e�[�u��
            this._deleteGoodsDetailDataTable.Reset();
        }

        /// <summary>
        /// �O���b�h���͋����䏈��
        /// </summary>
        /// <remarks>
        /// </remarks>
        public void GridInputPermissionControl(bool enabled)
        {
            this.uGrid_Details.Enabled = enabled;
        }

        /// <summary>
        /// �O���b�h�{�^�������䏈��
        /// </summary>
        /// <remarks>
        /// </remarks>
        public void GridButtonPermissionControl(bool enabled)
        {
            //this.uButton_JoinSource.Enabled = enabled;  // DEL gezh 2014/01/21 Redmine#41447
            this.uButton_JoinDest.Enabled = enabled;
        }

        /// <summary>
        /// �O���b�h�����̓`�F�b�N
        /// </summary>
        /// <return>RESULT</return>
        /// <remarks>
        /// </remarks>
        public bool GridDataCheck(ref Control control, ref string message)
        {
            bool result;
            int errorRowNo;
            string errorColNm;

            int errorDispNo;

            // 2009.03.26 30413 ���� �����揤�i�̏��i�}�X�^�폜�`�F�b�N >>>>>>START
            #region ���폜�`�F�b�N
            this.CheckDeleteData(out errorRowNo);
            if (errorRowNo != 0)
            {
                message = "��������� [ " + errorRowNo + " ] �s�ڂ����i�}�X�^����폜����Ă��܂��B";
                control = this.uGrid_Details;
                result = false;
                return result;
            }
            #endregion
            // 2009.03.26 30413 ���� �����揤�i�̏��i�}�X�^�폜�`�F�b�N <<<<<<END

            List<GoodsSetGoodsDataSet.GoodsSetDetailRow> effectDataList = new List<GoodsSetGoodsDataSet.GoodsSetDetailRow>();
            
            #region ���L���f�[�^�`�F�b�N
            
            #region < �L���f�[�^�����擾 >
            this.GetEffectiveData(out errorRowNo, out errorColNm, out effectDataList);
            #endregion

            #region < �K�{���̓`�F�b�N >
            if (errorColNm != "")
            {
                message = "��������� [ " + errorRowNo + " ] �s�ڂ�" + errorColNm + "����͂��Ă��������B";
                control = this.uGrid_Details;
                result = false;
                return result;
            }

            // 2010/07/14 Add >>>
            List<GoodsSetGoodsDataSet.GoodsSetDetailRow> deleteDataList;
            List<JoinPartsU> delDataList = new List<JoinPartsU>();

            // �폜�Ώۃf�[�^�̎擾
            this.GetDeleteData(out deleteDataList);
            // 2010/07/14 Add <<<

            // 2010/07/14 >>>
            //if (effectDataList.Count == 0)
            if (effectDataList.Count == 0 && deleteDataList.Count == 0)
            // 2010/07/14 <<<
            {
                message = "�����������͂��Ă��������B";
                control = this.uGrid_Details;
                result = false;
                return result;
            }
            #endregion

            #region < �����f�[�^�����`�F�b�N>
            if (errorRowNo != 0)
            {
                message = "��������� [ " + errorRowNo + " ] �s�ڂ𐳂������͂��Ă��������B";
                control = this.uGrid_Details;
                result = false;
                return result;
            }
            #endregion

            #endregion

            #region �����������i�Ɠ��ꏤ�i�`�F�b�N
            this.CheckParentOverlapData(out errorRowNo, effectDataList);

            #region -- ���������i�Ɠ��ꏤ�i�L�� --
            if (errorRowNo != 0)
            {
                message = "��������� [ " + errorRowNo + " ] �s�ڂ����������i�Ɠ���ł�";
                control = this.uGrid_Details;
                result = false;
                return result;
            }
            #endregion
            #endregion

            #region ���d���`�F�b�N
            this.CheckOverlapData(out errorRowNo, out errorDispNo, effectDataList);

            #region -- �d���L�� --
            if (errorRowNo != 0)
            {
                message = "��������� [ " + errorRowNo + " ] �s�ڂ��d�����Ă��܂�";
                control = this.uGrid_Details;
                result = false;
                return result;
            }
            #endregion

            #region -- �\�����ʂ̏d���L�� --
            if (errorDispNo != 0)
            {
                // 2010/01/05 >>>
                //message = "��������� [ " + errorDispNo + " ] �s�ڂ̕\�����ʂ��d��\n�܂��͓��͔͈�(1�`50)����O��Ă��܂�";
                message = "��������� [ " + errorDispNo + " ] �s�ڂ̕\�����ʂ��d��\n�܂��͓��͔͈�(0�`50)����O��Ă��܂�";
                // 2010/01/05 <<<
                control = this.uGrid_Details;
                result = false;
                return result;
            }
            #endregion

            #endregion

            result = true;
            return result;
        }

        /// <summary>
        /// ���i�}�X�^�폜�f�[�^�`�F�b�N
        /// </summary>
        /// <param name="errorRowNo">�G���[�s�ԍ�</param>
        /// <remarks>
        /// </remarks>
        public void CheckDeleteData(out int errorRowNo)
        {
            // �G���[���s�ԍ�(0 ������I��)
            errorRowNo = 0;

            // �f�[�^�e�[�u���̑��������J�E���g���A���̒��Ńf�[�^�����͂���Ă���s�̂݃`�F�b�N���s��
            int totalCnt = this._goodsDetailDataTable.Rows.Count;

            for (int i = 0; i < totalCnt; i++)
            {
                GoodsSetGoodsDataSet.GoodsSetDetailRow row = (GoodsSetGoodsDataSet.GoodsSetDetailRow)this._goodsDetailDataTable.Rows[i];

                if (row.EditFlg)
                {
                    // �i�����󔒂̃f�[�^�͖���
                    if (row.MakerCode != "" && row.GoodsCode != "")
                    {
                        if (row.GoodsName.Trim() == "")
                        {
                            // �����f�[�^�s�̍s�ԍ�
                            errorRowNo = (int)row.No;
                            return;
                        }
                    }
                }
                // ADD 2009/04/09 ------>>>
                else if (row.MakerCode == "" && row.GoodsCode == "")
                {
                    // ��f�[�^�Ȃ̂ŉ������Ȃ�
                }
                // �����f�[�^
                else
                {
                    if (row.GoodsName.Trim() == "")
                    {
                        // �����f�[�^�s�̍s�ԍ�
                        errorRowNo = (int)row.No;
                        return;
                    }
                }
                // ADD 2009/04/09 ------<<<
            }
        }

        /// <summary>
        /// �L���f�[�^�e�[�u���s�擾����
        /// </summary>
        /// <param name="errorRowNo">�G���[�s�ԍ�</param>
        /// <param name="errorColNm">�G���[�񖼏�</param>
        /// <param name="effectDataList">�L���f�[�^�s���X�g</param>
        /// <remarks>
        /// <br>--------------------------------------------------------------------------------------</br>
        /// Note			:	�f�[�^�e�[�u���̒�����L���ȃf�[�^�s�̃��X�g���擾���鏈�����s���܂��B<br />
        /// Programmer		:	30005 �،��@��<br />
        /// Date			:	2007.05.14<br />
        /// <br>--------------------------------------------------------------------------------------</br>
          /// </remarks>
        public void GetEffectiveData(out int errorRowNo, out string errorColNm, out List<GoodsSetGoodsDataSet.GoodsSetDetailRow> effectDataList)
        {
            // �G���[���s�ԍ�(0 ������I��)
            errorRowNo = 0;
            errorColNm = "";
            effectDataList = new List<GoodsSetGoodsDataSet.GoodsSetDetailRow>();

            // �f�[�^�e�[�u���̑��������J�E���g���A���̒��Ńf�[�^�����͂���Ă���s�̂݃`�F�b�N���s��
            int totalCnt = this._goodsDetailDataTable.Rows.Count;

            for (int i = 0; i < totalCnt ; i++)
            {
                GoodsSetGoodsDataSet.GoodsSetDetailRow row = (GoodsSetGoodsDataSet.GoodsSetDetailRow)this._goodsDetailDataTable.Rows[i];

                if (row.EditFlg)
                {
                    // �S�J���������͂���Ă���(���L���f�[�^)
                    //if (row.MakerCode != 0 && row.GoodsCode != "")
                    if ((row.MakerCode != "") && (row.GoodsCode != ""))
                    {
                        // DEL 2009/06/24 ------>>>
                        //double qty = 0.0;
                        //if ((!double.TryParse(row.Qty, out qty)) || (qty == 0.0))
                        //{
                        //    // �����f�[�^�s�̍s�ԍ�
                        //    errorRowNo = (int)row.No;
                        //    errorColNm = this._goodsDetailDataTable.QtyColumn.Caption;
                        //    return;
                        //}
                        // DEL 2009/06/24 ------<<<
                        
                        effectDataList.Add(row);
                    }
                    // �񋟃f�[�^
                    else if (row.OfferKubun != "1")
                    {
                        // �����Ώۃf�[�^�Ƃ��Ȃ�
                    }
                    // �S�J���������͂���Ă��Ȃ��B(���L���f�[�^)
                    else if (row.MakerCode == "" && row.GoodsCode == "")
                    {
                        // ��f�[�^�Ȃ̂ŉ������Ȃ�
                    }
                    // �����f�[�^
                    else
                    {
                        // �����f�[�^�s�̍s�ԍ�
                        errorRowNo = (int)row.No;
                        return;
                    }
                }
            }
        }

        /// <summary>
        /// �e���i�Ƃ̓���i�`�F�b�N����
        /// </summary>
        /// <param name="errorRowNo">�G���[�s�ԍ�</param>
        /// <param name="effectDataList">�L���f�[�^�s���X�g</param>
        /// <remarks>
        /// </remarks>
        public void CheckParentOverlapData(out int errorRowNo, List<GoodsSetGoodsDataSet.GoodsSetDetailRow> effectDataList)
        {
            int effectRowCnt;

            // �L���f�[�^�S�����擾
            effectRowCnt = effectDataList.Count;

            errorRowNo = 0;

            #region < ��r�Ώۍs��ݒ肵�S����r >
            for (int i = 0; i < effectRowCnt; i++)
            {
                GoodsSetGoodsDataSet.GoodsSetDetailRow targetRow = effectDataList[i];
                List<int> equalRowNoList = new List<int>();

                #region - ���������i�̕i�ԁA���[�J�[�Ɠ����r -
                if ((targetRow.GoodsCode == this.JoinSourPartsNoWithH) &&
                    (int.Parse(targetRow.MakerCode) == this.JoinSourceMakerCode))
                {
                    equalRowNoList.Add((int)targetRow.No);
                }
                #endregion

                #region -- ���������i����No�`�F�b�N --
                if (equalRowNoList.Count > 0)
                {
                    // ���������i�̕i�ԁA���[�J�[�Ɠ���̌����揤�i�̍s�ԍ����擾���Ĉ����Ɋi�[
                    errorRowNo = equalRowNoList[equalRowNoList.Count - 1];
                    return;
                }
                #endregion
            }
            #endregion

            // �d�������݂��Ȃ������̂ŃG���[�ԍ��͂O
            errorRowNo = 0;
        }

        /// <summary>
        /// �f�[�^�e�[�u���s�d���`�F�b�N����
        /// </summary>
        /// <param name="errorRowNo">�G���[�s�ԍ�</param>
        /// <param name="errorDispNo">�\�����ʃG���[�s�ԍ�</param>
        /// <param name="effectDataList">�L���f�[�^�s���X�g</param>
        /// <remarks>
        /// </remarks>
        public void CheckOverlapData(out int errorRowNo, out int errorDispNo, List<GoodsSetGoodsDataSet.GoodsSetDetailRow> effectDataList)
        {
            int effectRowCnt;
            
            // �L���f�[�^�S�����擾
            effectRowCnt = effectDataList.Count;

            errorRowNo = 0;
            errorDispNo = 0;
            
            #region < ��r�Ώۍs��ݒ肵�S����r >
            for (int i = 0; i < effectRowCnt; i++)
            {
                GoodsSetGoodsDataSet.GoodsSetDetailRow targetRow = effectDataList[i];
                List<int> equalRowNoList = new List<int>();

                List<int> equalDispNoList = new List<int>();

                // 2010/01/05 >>>
                //if ((targetRow.Disply < 1) || (targetRow.Disply > 50))
                if ((targetRow.Disply < 0) || (targetRow.Disply > 50))
                // 2010/01/05 <<<
                {
                    // �\�����ʂ͈̔͂��s��
                    equalDispNoList.Add((int)targetRow.No);
                }

                #region -- ��r�Ώۂ����ɍs���X�g��S����r --
                for (int j = 0; j < effectRowCnt; j++)
                {
                    GoodsSetGoodsDataSet.GoodsSetDetailRow compareRow = effectDataList[j];

                    #region - ���i�R�[�h��r -
                    if (
                        targetRow.GoodsCode == compareRow.GoodsCode
                            && targetRow.MakerCode.Equals(compareRow.MakerCode) // ADD 2008/10/22 �s��Ή�[6574]
                    )
                    {
                        equalRowNoList.Add((int)compareRow.No);
                    }
                    #endregion

                    #region - �\�����ʔ�r -
                    if (targetRow.Disply == compareRow.Disply)
                    {
                        equalDispNoList.Add((int)compareRow.No);
                    }
                    #endregion
                }
                #endregion

                #region -- �d��No�`�F�b�N --
                if (equalRowNoList.Count > 1)
                {
                    // �d�����������Ō�̍s�ԍ����擾���Ĉ����Ɋi�[
                    errorRowNo = equalRowNoList[equalRowNoList.Count - 1];
                    return ;
                }
                #endregion

                #region -- �d���\�����ʃ`�F�b�N --
                if (equalDispNoList.Count > 1)
                {
                    // �d�����������Ō�̍s�ԍ����擾���Ĉ����Ɋi�[
                    errorDispNo = equalDispNoList[equalDispNoList.Count - 1];
                    return;
                }
                #endregion

            }
            #endregion

            // �d�������݂��Ȃ������̂ŃG���[�ԍ��͂O
            errorRowNo = 0;
        }

        /// <summary>
        /// �O���b�h���ύX�m�F����
        /// </summary>
        /// <return>�ύX�t���O(ON:�ύX�L  OFF:�ύX��)</return>
        /// <remarks>
        /// </remarks>
        public bool CheckGridChange()
        {
            return _changeFlg;
        }

        /// <summary>
        /// �����^�C�v�擾����
        /// </summary>
        /// <param name="inputCode">���͂��ꂽ�R�[�h</param>
        /// <param name="searchCode">�����p�R�[�h�i*�������j</param>
        /// <returns>0:���S��v���� 1:�O����v���� 2:�����v���� 3:�B������</returns>
        /// <remarks>
        /// </remarks>
        public int GetSearchType(string inputCode, out string searchCode)
        {
            searchCode = inputCode;
            if (String.IsNullOrEmpty(inputCode)) return 0;

            if (inputCode.Contains("*"))
            {
                string firstString = inputCode.Substring(0, 1);
                string lastString = inputCode.Substring(inputCode.Length - 1, 1);

                if ((firstString == "*") && (lastString == "*"))
                {
                    return 3;
                }
                else if (firstString == "*")
                {
                    return 2;
                }
                else if (lastString == "*")
                {
                    return 1;
                }
                else
                {
                    return 3;
                }
            }
            else
            {
                // *�����݂��Ȃ����ߊ��S��v����
                return 0;
            }
        }

        /// <summary>
        /// �폜�{�^���̗L������
        /// </summary>
        /// <param name="flag">�L���t���O</param>
        public void uButton_RowDeleteEnabled(bool flag)
        {
            this.uButton_RowDelete.Enabled = flag;
        }

        /// <summary>
        /// Return�L�[�_�E������
        /// </summary>
        /// <param name="previousCellCoodinate">�ړ��O�̃Z�����W</param>
        /// <returns>true:�Z���ړ����� false:�Z���ړ����s</returns>
        internal bool ReturnKeyDown(out CellCoodinate previousCellCoodinate)    // ADD 2008/11/25 �s��Ή�[6564] �������V�K�ǉ����́uQTY�v�֋����t�H�[�J�X�J�ځ@���p�����[�^�Fout CellCoodinate��ǉ�
        {
            previousCellCoodinate = new CellCoodinate(0, 0);    // ADD 2008/11/25 �s��Ή�[6564] �������V�K�ǉ����́uQTY�v�֋����t�H�[�J�X�J��

            if (this.uGrid_Details.ActiveCell == null) return false;
            Infragistics.Win.UltraWinGrid.UltraGridCell cell = this.uGrid_Details.ActiveCell;

            // ADD 2008/11/25 �s��Ή�[6564] �������V�K�ǉ����́uQTY�v�֋����t�H�[�J�X�J�� ---------->>>>>
            previousCellCoodinate.Row = cell.Row.Index;
            previousCellCoodinate.Column = cell.Column.Index;
            Debug.WriteLine("Cell( " + previousCellCoodinate.Row.ToString() + ", " + previousCellCoodinate.Column.ToString() + " )");
            // ADD 2008/11/25 �s��Ή�[6564] �������V�K�ǉ����́uQTY�v�֋����t�H�[�J�X�J�� ----------<<<<<

            int goodsRowNo = this._goodsDetailDataTable[cell.Row.Index].No;

            // DEL START �����@2013/12/04 FOR Redmine#41447 ------>>>>>>
            //// 2009.02.09 30413 ���� �i�ԂȂ��̃t�H�[�J�X�����ǉ� >>>>>>START
            ////bool canMove;
            ////canMove = this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.NextCellByTab);
            //bool canMove = true;
            //canMove = this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.NextCellByTab);

            //if (!this._joinGoodNoUpdFlg)
            //{
            //    this._joinGoodNoUpdFlg = true;
            //    canMove = this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.PrevCellByTab);
            //}
            //// 2009.02.09 30413 ���� �i�ԂȂ��̃t�H�[�J�X�����ǉ� <<<<<<END
            // DEL START �����@2013/12/04 FOR Redmine#41447 ------<<<<<
            // ADD START �����@2013/12/04 FOR Redmine#41447 ------>>>>>>
            if (this.uGrid_Details.ActiveCell == null) return false;

            bool canMove = this.MoveNextAllowEditCell(false);

            return canMove;
            // ADD START �����@2013/12/04 FOR Redmine#41447 ------<<<<<
        }

        #endregion

        #region Return�L�[�_�E������(Shift+TAB�p)
        /// <summary>
        /// Return�L�[�_�E������(Shift+TAB�p)
        /// </summary>
        /// <returns>true:�Z���ړ����� false:�Z���ړ����s</returns>
        internal bool ReturnKeyDown2()
        {
            if (this.uGrid_Details.ActiveCell == null) return false;
            Infragistics.Win.UltraWinGrid.UltraGridCell cell = this.uGrid_Details.ActiveCell;

            bool canMove = true;

            #region ��ActiveCell���\������
            if (cell.Column.Key == this._goodsDetailDataTable.DisplyColumn.ColumnName)
            {
                canMove = this.MovePrevAllowEditCell(false);
            }
            #endregion

            #region ��ActiveCell���i��
            else if (cell.Column.Key == this._goodsDetailDataTable.GoodsCodeColumn.ColumnName)
            {
                // 2009.02.09 30413 ���� �i�ԂȂ��̃t�H�[�J�X�����ǉ� >>>>>>START
                //canMove = this.MovePrevAllowEditCell(false);
                canMove = this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.PrevCellByTab);

                if (!this._joinGoodNoUpdFlg)
                {
                    this._joinGoodNoUpdFlg = true;
                    canMove = this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.NextCellByTab);
                }
                // 2009.02.09 30413 ���� �i�ԂȂ��̃t�H�[�J�X�����ǉ� <<<<<<END
            }
            #endregion

            #region ��ActiveCell���i��
            else if (cell.Column.Key == this._goodsDetailDataTable.GoodsNameColumn.ColumnName)
            {
                canMove = this.MovePrevAllowEditCell(false);
            }
            #endregion

            #region ��ActiveCell�����[�J�[����
            else if (cell.Column.Key == this._goodsDetailDataTable.MakerNameColumn.ColumnName)
            {
                canMove = this.MovePrevAllowEditCell(false);
            }
            #endregion

            #region ��ActiveCell�����[�J�[�R�[�h
            else if (cell.Column.Key == this._goodsDetailDataTable.MakerCodeColumn.ColumnName)
            {
                canMove = this.MovePrevAllowEditCell(false);
            }
            #endregion

            #region ��ActiveCell���p�s�x
            else if (cell.Column.Key == this._goodsDetailDataTable.QtyColumn.ColumnName)
            {
                canMove = this.MovePrevAllowEditCell(false);
            }
            #endregion

            #region ��ActiveCell���Z�b�g�K�i�E���L����
            else if (cell.Column.Key == this._goodsDetailDataTable.SetNoteColumn.ColumnName)
            {
                canMove = this.MovePrevAllowEditCell(false);
            }
            #endregion

            return canMove;
        }

        
        #endregion
        
        #region ��Private Methods

        /// <summary>
        /// �O���b�h�񏉊��ݒ菈��
        /// </summary>
        /// <remarks>
        /// </remarks>
        private void InitialSettingGridCol()
        {
            // �K�C�h�{�^���̃A�C�R��
            this._guideButtonImage = IconResourceManagement.ImageList16.Images[(int)Size16_Index.STAR1];
            
            // ���̓t�H�[����ʕ\���̂��߃f�[�^�e�[�u��������
            this._goodsDetailDataTable.Clear();

            // ADD 2008/11/06 �s��Ή�[6568] �q�ɃR�[�h��\�� ---------->>>>>
            if (InitialLoadFlag)       // ADD �����@2013/12/04 FOR Redmine#41447 
            {    // ADD �����@2013/12/04 FOR Redmine#41447
                #region ���\����

                int visiblePosition = 0;
                this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.NoColumn.ColumnName].Header.VisiblePosition = visiblePosition++;       // No
                this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.DisplyColumn.ColumnName].Header.VisiblePosition = visiblePosition++;   // �\������
                this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.GoodsCodeColumn.ColumnName].Header.VisiblePosition = visiblePosition++;// �i��
                this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.GoodsNameColumn.ColumnName].Header.VisiblePosition = visiblePosition++;// �i��
                this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.MakerCodeColumn.ColumnName].Header.VisiblePosition = visiblePosition++;// ���[�J�[�R�[�h 
                this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.MakerNameColumn.ColumnName].Header.VisiblePosition = visiblePosition++;// ���[�J�[����
                this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.QtyColumn.ColumnName].Header.VisiblePosition = visiblePosition++;      // QTY
                this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.SetNoteColumn.ColumnName].Header.VisiblePosition = visiblePosition++;  // �����K�i�E���L����
                this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.OfferDateColumn.ColumnName].Header.VisiblePosition = visiblePosition++;// �񋟓��t
                this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.PriceColumn.ColumnName].Header.VisiblePosition = visiblePosition++;    // �W�����i
                this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.CostColumn.ColumnName].Header.VisiblePosition = visiblePosition++;     // ���P��
                this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.StoreCodeColumn.ColumnName].Header.VisiblePosition = visiblePosition++;// �q�ɃR�[�h
                this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.StoreColumn.ColumnName].Header.VisiblePosition = visiblePosition++;    // �q��
                this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.ShelfNoColumn.ColumnName].Header.VisiblePosition = visiblePosition++;  // �I��
                this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.StockColumn.ColumnName].Header.VisiblePosition = visiblePosition++;    // ���݌�
                // TODO:�񏇂ƃ^�u�C���f�b�N�X�͍��킹�邱��
                int tabIndex = 0;
                this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.NoColumn.ColumnName].TabIndex = tabIndex++;
                this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.DisplyColumn.ColumnName].TabIndex = tabIndex++;
                this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.GoodsCodeColumn.ColumnName].TabIndex = tabIndex++;
                this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.GoodsNameColumn.ColumnName].TabIndex = tabIndex++;
                this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.MakerCodeColumn.ColumnName].TabIndex = tabIndex++;
                this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.MakerNameColumn.ColumnName].TabIndex = tabIndex++;
                this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.QtyColumn.ColumnName].TabIndex = tabIndex++;
                this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.SetNoteColumn.ColumnName].TabIndex = tabIndex++;
                this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.OfferDateColumn.ColumnName].TabIndex = tabIndex++;
                this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.PriceColumn.ColumnName].TabIndex = tabIndex++;
                this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.CostColumn.ColumnName].TabIndex = tabIndex++;
                this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.StoreCodeColumn.ColumnName].TabIndex = tabIndex++;
                this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.StoreColumn.ColumnName].TabIndex = tabIndex++;
                this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.ShelfNoColumn.ColumnName].TabIndex = tabIndex++;
                this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.StockColumn.ColumnName].TabIndex = tabIndex++;

                #endregion  // ���\����

                #region ���\�����ݒ�
                this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.NoColumn.ColumnName].Width = 50;                   // No

                this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.DisplyColumn.ColumnName].PerformAutoResize();      // �\������
                this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.GoodsCodeColumn.ColumnName].Width = 200;           // ���i�R�[�h
                this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.GoodsNameColumn.ColumnName].Width = 300;           // ���i����
                this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.MakerCodeColumn.ColumnName].Width = 100;           // ���[�J�[�R�[�h 
                this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.MakerNameColumn.ColumnName].Width = 150;           // ���[�J�[����
                this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.QtyColumn.ColumnName].Width = 80;                  // MOD 2008/11/07 �s��Ή�[6568] QTY�͕ҏW�\ .PerformAutoResize()��.Width = 100
                this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.SetNoteColumn.ColumnName].Width = 300;             // �Z�b�g�K�i�E���L����
                this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.PriceColumn.ColumnName].Width = 100;               // �W�����i
                this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.CostColumn.ColumnName].Width = 100;                // ���P��
                this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.StoreColumn.ColumnName].Width = 100;               // �q��
                this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.ShelfNoColumn.ColumnName].Width = 100;             // �I��
                this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.StockColumn.ColumnName].Width = 100;               // ���݌�
                this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.StoreCodeColumn.ColumnName].Width = 100;           // ADD 2008/11/06 �s��Ή�[6568] �q�ɃR�[�h��\��

                #endregion

                InitialLoadFlag = false; // ADD �����@2013/12/04 FOR Redmine#41447
            } // ADD �����@2013/12/04 FOR Redmine#41447

            #region ���Z�����̃f�[�^�\���ʒu�ݒ�
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.NoColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.DisplyColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.MakerCodeColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.MakerNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.GoodsCodeColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.GoodsNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.SetNoteColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.QtyColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;            // QTY
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.PriceColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;          // �W�����i
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.CostColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;           // ���P��
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.StoreColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;           // �q��
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.ShelfNoColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;         // �I��
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.StockColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;          // ���݌�
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.StoreCodeColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right; // ADD 2008/11/06 �s��Ή�[6568] �q�ɃR�[�h��\��
            #endregion

            #region ���Z�����̓��͍��ڑ啶���������ݒ�
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.GoodsCodeColumn.ColumnName].CharacterCasing = CharacterCasing.Normal;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.SetNoteColumn.ColumnName].CharacterCasing = CharacterCasing.Upper;
            #endregion

            #region ���\���J�[�\���ݒ�
            //this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.MakerGuideButtonColumn.ColumnName].CellAppearance.Cursor = Cursors.Hand;
            //this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.GoodsGuideButtonColumn.ColumnName].CellAppearance.Cursor = Cursors.Hand;
            #endregion

            #region ���X�^�C���ݒ�
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.DisplyColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;                 // �\������
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.GoodsCodeColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;              // ���i�R�[�h
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.GoodsNameColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;              // ���i����
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.MakerCodeColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;              // ���[�J�[�R�[�h 
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.MakerNameColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;              // ���[�J�[����
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.QtyColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;                    // QTY
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.SetNoteColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;                // �Z�b�g�K�i�E���L����
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.PriceColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;                  // �W�����i
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.CostColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;                   // ���P��
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.StoreColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;                  // �q��
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.ShelfNoColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;                // �I��
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.StockColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;                  // ���݌�
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.StoreCodeColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;    // ADD 2008/11/06 �s��Ή�[6568] �q�ɃR�[�h��\��          
            #endregion

            #region ���ʐݒ�

            #region < No >
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.NoColumn.ColumnName].CellAppearance.BackColor = this.uGrid_Details.DisplayLayout.Override.HeaderAppearance.BackColor;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.NoColumn.ColumnName].CellAppearance.BackColor2 = this.uGrid_Details.DisplayLayout.Override.HeaderAppearance.BackColor2;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.NoColumn.ColumnName].CellAppearance.BackGradientStyle = this.uGrid_Details.DisplayLayout.Override.HeaderAppearance.BackGradientStyle;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.NoColumn.ColumnName].CellAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.NoColumn.ColumnName].CellAppearance.ForeColor = this.uGrid_Details.DisplayLayout.Override.HeaderAppearance.ForeColor;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.NoColumn.ColumnName].CellAppearance.ForeColorDisabled = this.uGrid_Details.DisplayLayout.Override.HeaderAppearance.ForeColor;
            #endregion

            // �񋟋敪��\��
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.OfferKubunColumn.ColumnName].Hidden = true;
            // �ҏW�t���O��\��
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.EditFlgColumn.ColumnName].Hidden = true;
            // �񋟓��t��\��
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.OfferDateColumn.ColumnName].Hidden = true; // ADD 2008/10/21 �s��Ή�[6567]
            // �ǉ��t���O�̔�\��
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.AddFlagColumn.ColumnName].Hidden = true;

            #endregion

            #region �����͐���
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.NoColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.Disabled;        // No
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.MakerCodeColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;   // ���[�J�[
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.MakerNameColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;   // ���[�J�[����
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.GoodsNameColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;	 // ���i����
            
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.OfferDateColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;   // �񋟓��t
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.PriceColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;       // �W�����i
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.CostColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;        // ���P��
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.StoreColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;       // �q��
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.ShelfNoColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;     // �I��
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.StockColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;       // ���݌�
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.StoreCodeColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;  // ADD 2008/11/06 �s��Ή�[6568] �q�ɃR�[�h��\��   
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.AddFlagColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;       // �ǉ��t���O
            #endregion

            // ADD 2008/10/21 �s��Ή�[6564]---------->>>>>
            #region ���t�H�[�J�X����
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.MakerCodeColumn.ColumnName].TabStop = false;   // ���[�J�[
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.MakerNameColumn.ColumnName].TabStop = false;   // ���[�J�[����
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.GoodsNameColumn.ColumnName].TabStop = false;	// ���i����
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.QtyColumn.ColumnName].TabStop = false;		    // QTY
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.SetNoteColumn.ColumnName].TabStop = false;     // �����K�i�E���L����
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.OfferDateColumn.ColumnName].TabStop = false;   // �񋟓��t
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.PriceColumn.ColumnName].TabStop = false;       // �W�����i
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.CostColumn.ColumnName].TabStop = false;        // ���P��
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.StoreColumn.ColumnName].TabStop = false;       // �q��
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.ShelfNoColumn.ColumnName].TabStop = false;     // �I��
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.StockColumn.ColumnName].TabStop = false;       // ���݌�
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.StoreCodeColumn.ColumnName].TabStop = false;   // ADD 2008/11/06 �s��Ή�[6568] �q�ɃR�[�h��\��     
            #endregion
            // ADD 2008/10/21 �s��Ή�[6559]----------<<<<<

            #region ���t�H�[�}�b�g�ݒ�

            string codeFormat = "0000";            
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.MakerCodeColumn.ColumnName].Format = codeFormat;

            const string NUMBER_FORMAT = "N";
            // �W�����i
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.PriceColumn.ColumnName].Format = NUMBER_FORMAT;
            // ���P��
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.CostColumn.ColumnName].Format = NUMBER_FORMAT;
            // ���݌�
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.StockColumn.ColumnName].Format = NUMBER_FORMAT;
            // �q�ɃR�[�h
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.StoreCodeColumn.ColumnName].Format = "0000";

            #endregion

            #region ���V�K���͍s�쐬

            int count;
            for (count = 1; count <= _defaultRowCnt; count++)
            {
                GoodsSetGoodsDataSet.GoodsSetDetailRow detailRow = this._goodsDetailDataTable.NewGoodsSetDetailRow();
                detailRow.No = (short)count;
                this._goodsDetailDataTable.AddGoodsSetDetailRow(detailRow);
            }

            #endregion

            #region ���ύX�s���t�H���g�J���[�ݒ�
            // 2007.07.10 add by T-Kidate
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.DisplyColumn.ColumnName].CellAppearance.ForeColorDisabled = Color.Black;               // �\������
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.MakerCodeColumn.ColumnName].CellAppearance.ForeColorDisabled = Color.Black;            // ���[�J�[�R�[�h 
            //this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.MakerGuideButtonColumn.ColumnName].CellAppearance.ForeColorDisabled = Color.Black;   // ���[�J�[�K�C�h�{�^��
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.MakerNameColumn.ColumnName].CellAppearance.ForeColorDisabled = Color.Black;            // ���[�J�[����
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.GoodsCodeColumn.ColumnName].CellAppearance.ForeColorDisabled = Color.Black;            // ���i�R�[�h
            //this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.GoodsGuideButtonColumn.ColumnName].CellAppearance.ForeColorDisabled = Color.Black;     // ���i�K�C�h�{�^��
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.GoodsNameColumn.ColumnName].CellAppearance.ForeColorDisabled = Color.Black;            // ���i����
            //this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.CntFlColumn.ColumnName].CellAppearance.ForeColorDisabled = Color.Black;              // ����
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.SetNoteColumn.ColumnName].CellAppearance.ForeColorDisabled = Color.Black;              // �Z�b�g�K�i�E���L����
            //this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.CatalogShapeColumn.ColumnName].CellAppearance.ForeColorDisabled = Color.Black;       // �J�^���O�}��
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.QtyColumn.ColumnName].CellAppearance.ForeColorDisabled = Color.Black;                  // QTY
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.PriceColumn.ColumnName].CellAppearance.ForeColorDisabled = Color.Black;                // �W�����i
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.CostColumn.ColumnName].CellAppearance.ForeColorDisabled = Color.Black;                 // ���P��
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.StoreColumn.ColumnName].CellAppearance.ForeColorDisabled = Color.Black;                // �q��
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.ShelfNoColumn.ColumnName].CellAppearance.ForeColorDisabled = Color.Black;              // �I��
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.StockColumn.ColumnName].CellAppearance.ForeColorDisabled = Color.Black;                // ���݌�
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.StoreCodeColumn.ColumnName].CellAppearance.ForeColorDisabled = Color.Black;    // ADD 2008/11/06 �s��Ή�[6568] �q�ɃR�[�h��\��         
            #endregion

            #region �����l�ߐݒ�
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.GoodsCodeColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;  // ���i�R�[�h
            #endregion

            // ��̓��ւ����\�ɂ���
            this.uGrid_Details.DisplayLayout.Override.AllowColMoving = Infragistics.Win.UltraWinGrid.AllowColMoving.WithinBand;

            // �񕝂̕ύX���\�ɂ���
            this.uGrid_Details.DisplayLayout.Override.AllowColSizing = Infragistics.Win.UltraWinGrid.AllowColSizing.Free;

            // ADD 2008/10/27 �s��Ή�[6558]---------->>>>>
            // 1�s�ڂ̕\�����ʂ��A�N�e�B�u�Z���ɐݒ�
            this.uGrid_Details.Rows[0].Activate();
            this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.ActivateCell);
            // ADD 2008/10/27 �s��Ή�[6558]----------<<<<<
        }

        /// <summary>
		/// �{�^�������ݒ菈��
		/// </summary>
        /// <remarks>
        /// </remarks>
        private void ButtonInitialSetting()
        {
            this._imageList16 = IconResourceManagement.ImageList16;

            this.uButton_StoreChange.ImageList = this._imageList16;
            this.uButton_RowDelete.ImageList = this._imageList16;

            this.uButton_StoreChange.Appearance.Image = (int)Size16_Index.ROWINSERT;
            this.uButton_RowDelete.Appearance.Image = (int)Size16_Index.ROWDELETE;

            this.uButton_StoreChange.Enabled = false;
            if (_deleteBtnFlag)
            {
                // �폜�{�^���g�p��
                this.uButton_RowDelete.Enabled = true;
            }
            else
            {
                // �폜�{�^���g�p�s��
                this.uButton_RowDelete.Enabled = false;
            }
            this.uButton_JoinSource.Enabled = true;
            // -- 2009/08/04 ------------------>>>
            //�V�K�쐬���̏����\�����Ɍ�����{�^�����L���ɂȂ��Ă��邽�ߕύX
            //this.uButton_JoinDest.Enabled = true;
            this.uButton_JoinDest.Enabled = false;
            // -- 2009/08/04 ------------------<<<
			
            // �ύX�t���OOFF
            this._changeFlg = false;
        }

        /// <summary>
        /// �O���b�h�L�[�}�b�s���O�ݒ菈��
        /// </summary>
        /// <param name="grid">�ݒ�Ώۂ̃O���b�h</param>
        /// <remarks>
        /// </remarks>
        private void MakeKeyMappingForGrid(Infragistics.Win.UltraWinGrid.UltraGrid grid)
        {
            Infragistics.Win.UltraWinGrid.GridKeyActionMapping enterMap;

            //----- Enter�L�[
            enterMap = new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(
                Keys.Enter,
                Infragistics.Win.UltraWinGrid.UltraGridAction.NextCellByTab,
                0,
                Infragistics.Win.UltraWinGrid.UltraGridState.Cell,
                Infragistics.Win.SpecialKeys.All,
                0,
                true);
            this.uGrid_Details.KeyActionMappings.Add(enterMap);

            //----- Shift + Enter�L�[
            enterMap = new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(
                Keys.Enter,
                Infragistics.Win.UltraWinGrid.UltraGridAction.PrevCellByTab,
                0,
                Infragistics.Win.UltraWinGrid.UltraGridState.Cell,
                Infragistics.Win.SpecialKeys.AltCtrl,
                Infragistics.Win.SpecialKeys.Shift,
                true);
            this.uGrid_Details.KeyActionMappings.Add(enterMap);

            //----- ���L�[
            enterMap = new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(
                Keys.Up,
                Infragistics.Win.UltraWinGrid.UltraGridAction.AboveCell,
                Infragistics.Win.UltraWinGrid.UltraGridState.IsDroppedDown,
                Infragistics.Win.UltraWinGrid.UltraGridState.InEdit,
                Infragistics.Win.SpecialKeys.All,
                0,
                true);
            this.uGrid_Details.KeyActionMappings.Add(enterMap);

            //----- ���L�[ (�ŏ�i�̃h���b�v�_�E�����X�g�ł͉������Ȃ��B���ꂪ�����ƃ��X�g���ڂ��ς���Ă��܂��̂�...)
            enterMap = new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(
                Keys.Up,
                Infragistics.Win.UltraWinGrid.UltraGridAction.ExitEditMode,
                Infragistics.Win.UltraWinGrid.UltraGridState.IsDroppedDown,
                Infragistics.Win.UltraWinGrid.UltraGridState.RowFirst | Infragistics.Win.UltraWinGrid.UltraGridState.HasDropdown,
                Infragistics.Win.SpecialKeys.All,
                0,
                true);
            this.uGrid_Details.KeyActionMappings.Add(enterMap);

            //----- ���L�[ (�ŉ��i�̃h���b�v�_�E�����X�g�ł͉������Ȃ��B���ꂪ�����ƃ��X�g���ڂ��ς���Ă��܂��̂�...)
            enterMap = new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(
                Keys.Down,
                Infragistics.Win.UltraWinGrid.UltraGridAction.ExitEditMode,
                Infragistics.Win.UltraWinGrid.UltraGridState.IsDroppedDown,
                Infragistics.Win.UltraWinGrid.UltraGridState.RowLast | Infragistics.Win.UltraWinGrid.UltraGridState.HasDropdown,
                Infragistics.Win.SpecialKeys.All,
                0,
                true);
            this.uGrid_Details.KeyActionMappings.Add(enterMap);

            //----- ���L�[
            enterMap = new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(
                Keys.Down,
                Infragistics.Win.UltraWinGrid.UltraGridAction.BelowCell,
                Infragistics.Win.UltraWinGrid.UltraGridState.IsDroppedDown,
                Infragistics.Win.UltraWinGrid.UltraGridState.InEdit,
                Infragistics.Win.SpecialKeys.All,
                0,
                true);
            this.uGrid_Details.KeyActionMappings.Add(enterMap);

            //----- �O�ŃL�[
            enterMap = new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(
                Keys.Prior,
                Infragistics.Win.UltraWinGrid.UltraGridAction.PageUpCell,
                0,
                Infragistics.Win.UltraWinGrid.UltraGridState.InEdit,
                Infragistics.Win.SpecialKeys.All,
                0,
                true);
            this.uGrid_Details.KeyActionMappings.Add(enterMap);

            //----- ���ŃL�[
            enterMap = new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(
                Keys.Next,
                Infragistics.Win.UltraWinGrid.UltraGridAction.PageDownCell,
                0,
                Infragistics.Win.UltraWinGrid.UltraGridState.InEdit,
                Infragistics.Win.SpecialKeys.All,
                0,
                true);

            this.uGrid_Details.KeyActionMappings.Add(enterMap);
        }

        /// <summary>
        /// ActiveRow�C���f�b�N�X�擾����
        /// </summary>
        /// <returns>ActiveRow�C���f�b�N�X</returns>
        /// <remarks>
        /// </remarks>
        private int GetActiveRowIndex()
        {
            if (this.uGrid_Details.ActiveCell != null)
            {
                return this.uGrid_Details.ActiveCell.Row.Index;
            }
            else if (this.uGrid_Details.ActiveRow != null)
            {
                return this.uGrid_Details.ActiveRow.Index;
            }
            else
            {
                return -1;
            }
        }

        /// <summary>
        /// �����͉\�Z���ړ�����
        /// </summary>
        /// <param name="activeCellCheck">true:ActiveCell�����͉\�̏ꍇ��Next�Ɉړ������Ȃ� false:ActiveCell�Ɋ֌W�Ȃ�Next�Ɉړ�������</param>
        /// <returns>true:�Z���ړ����� false:�Z���ړ����s</returns>
        /// <remarks>
        /// </remarks>
        private bool MoveNextAllowEditCell(bool activeCellCheck)
        {
            bool moved = false;
            bool performActionResult = false;

            if ((activeCellCheck) && (this.uGrid_Details.ActiveCell != null))
            {
                if ((this.uGrid_Details.ActiveCell.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit) &&
                    (this.uGrid_Details.ActiveCell.Column.CellActivation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit))
                {
                    moved = true;
                }
            }

            while (!moved)
            {
                performActionResult = this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.NextCell);
    
                if (performActionResult)
                {
                    if ((this.uGrid_Details.ActiveCell.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit) &&
                        (this.uGrid_Details.ActiveCell.Column.CellActivation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit))
                    {
                        moved = true;
                    }
                    else
                    {
                        moved = false;
                    }
                }
                else
                {
                    break;
                }
            }

            if (moved)
            {
                this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
            }

            return performActionResult;
        }

        /// <summary>
        /// �O���͉\�Z���ړ�����
        /// </summary>
        /// <param name="activeCellCheck">true:ActiveCell�����͉\�̏ꍇ��Prev�Ɉړ������Ȃ� false:ActiveCell�Ɋ֌W�Ȃ�Prev�Ɉړ�������</param>
        /// <returns>true:�Z���ړ����� false:�Z���ړ����s</returns>
        /// <remarks>
        /// </remarks>
        private bool MovePrevAllowEditCell(bool activeCellCheck)    // TODO:�O���b�h�ł�Shift+Tab
        {
            bool moved = false;
            bool performActionResult = false;

            if ((activeCellCheck) && (this.uGrid_Details.ActiveCell != null))
            {
                if ((this.uGrid_Details.ActiveCell.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit) &&
                    (this.uGrid_Details.ActiveCell.Column.CellActivation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit))
                {
                    moved = true;
                }
            }
            else
            {
                while (!moved)
                {
                    if (!this._goodsDetailDataTable[this.uGrid_Details.ActiveCell.Row.Index].EditFlg)   // MOD 2008/03/30 �s��Ή�[12871] .EditFlg.Equals("1")��.EditFlg
                    {
                        int rowCnt = this.uGrid_Details.ActiveCell.Row.Index;
                        while (!this._goodsDetailDataTable[rowCnt].EditFlg) // MOD 2008/03/30 �s��Ή�[12871] .EditFlg.Equals("1")��.EditFlg
                        {
                            rowCnt--;
                        }
                        this.uGrid_Details.Rows[rowCnt].Activate();
                        this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.ActivateCell);
                        moved = true;
                    }
                    else
                    {
                        performActionResult = this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.PrevCell);

                        if (performActionResult)
                        {
                            if ((this.uGrid_Details.ActiveCell.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit) &&
                                (this.uGrid_Details.ActiveCell.Column.CellActivation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit))
                            {
                                moved = true;
                            }
                            else
                            {
                                moved = false;
                            }
                        }
                        else
                        {
                            break;
                        }
                    }
                }
            }

            if (moved)
            {
                this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
            }

            return performActionResult;
        }

        /// <summary>
        /// �I���ς݌������s�ԍ����X�g�擾����
        /// </summary>
        /// <returns>�I���ς݌������s�ԍ����X�g</returns>
        /// <remarks>
        /// </remarks>
        private List<int> GetSelectedGoodsRowNoList()
        {
            // �I�����ꂽ�Z�����擾
            Infragistics.Win.UltraWinGrid.UltraGridCell cell = this.uGrid_Details.ActiveCell;
            // �I�����ꂽ�s���擾����
            Infragistics.Win.UltraWinGrid.SelectedRowsCollection rows = this.uGrid_Details.Selected.Rows;
            
            if ((cell == null) && (rows == null)) return null;

            List<int> selectedGoodsRowNoList = new List<int>();
            List<int> selectedIndexList = new List<int>();

            if (cell != null)
            {
                selectedGoodsRowNoList.Add(this._goodsDetailDataTable[cell.Row.Index].No);
                selectedIndexList.Add(cell.Row.Index);
            }
            else if (rows != null)
            {
                foreach (Infragistics.Win.UltraWinGrid.UltraGridRow row in rows)
                {
                    selectedGoodsRowNoList.Add(this._goodsDetailDataTable[row.Index].No);
                    selectedIndexList.Add(row.Index);
                }
            }

            return selectedGoodsRowNoList;
        }

        /// <summary>
        /// �������s�폜�\�`�F�b�N����
        /// </summary>
        /// <param name="goodsRowNoList">�폜�sStockRowNo���X�g</param>
        /// <param name="message">���b�Z�[�W</param>
        /// <returns>true:�s�폜�\ false:�s�폜�s��</returns>
        /// <remarks>
        /// </remarks>
        private bool CanDeleteGoodsDetailRow(List<int> goodsRowNoList, out string message)
        {
            message = "";
            return true;
        }

        /// <summary>
        /// �������s�폜����
        /// </summary>
        /// <param name="goodsRowNoList">�폜�sNo���X�g</param>
        /// <remarks>
        /// </remarks>
        private void DeleteGoodsDetailRow(List<int> goodsRowNoList)
        {
            this.DeleteGoodsDetailRow(goodsRowNoList, false);
        }

        /// <summary>
        /// �������s�폜����(�I�[�o�[���[�h)
        /// </summary>
        /// <param name="goodsRowNoList">�폜�sStockRowNo���X�g</param>
        /// <param name="changeRowCount">true:�s����ύX���� false:�s����ύX����͕ύX���Ȃ�</param>
        /// <remarks>
        /// </remarks>
        private void DeleteGoodsDetailRow(List<int> goodsRowNoList, bool changeRowCount)
        {
            this._goodsDetailDataTable.BeginLoadData();
            foreach (int goodsRowNo in goodsRowNoList)
            {
                // �폜�Ώۍs�����擾����
                GoodsSetGoodsDataSet.GoodsSetDetailRow targetRow = this._goodsDetailDataTable.FindByNo((short)goodsRowNo);
                if (targetRow == null) continue;

                // �폜�Ώۍs��ޔ�
                if ((targetRow.GoodsCode != "") && (targetRow.MakerCode != "") && (!targetRow.AddFlag))
                {
                    GoodsSetGoodsDataSet.GoodsSetDetailRow row = this._deleteGoodsDetailDataTable.NewGoodsSetDetailRow();
                    // 2010/07/14 >>>
                    //row.No = targetRow.No;
                    row.No = (short)(targetRow.No + this._deleteGoodsDetailDataTable.Rows.Count);
                    // 2010/07/14 <<<
                    row.Disply = targetRow.Disply;
                    row.GoodsCode = targetRow.GoodsCode;
                    row.GoodsName = targetRow.GoodsName;
                    row.MakerCode = targetRow.MakerCode;
                    row.MakerName = targetRow.MakerName;
                    row.Qty = targetRow.Qty;
                    row.SetNote = targetRow.SetNote;
                    row.OfferDate = targetRow.OfferDate;
                    row.Price = targetRow.Price;
                    row.Cost = targetRow.Cost;
                    row.Store = targetRow.Store;
                    row.ShelfNo = targetRow.ShelfNo;
                    row.Stock = targetRow.Stock;
                    row.OfferKubun = targetRow.OfferKubun;
                    row.EditFlg = targetRow.EditFlg;
                    row.StoreCode = targetRow.StoreCode;
                    row.AddFlag = targetRow.AddFlag;
                    this._deleteGoodsDetailDataTable.AddGoodsSetDetailRow(row);
                }
                
                // �Ώۍs�폜����
                this._goodsDetailDataTable.RemoveGoodsSetDetailRow(targetRow);
            }

            // �������f�[�^�e�[�u��StockRowNo�񏉊�������
            this.InitializeGoodsSetDetailRowNoColumn();

            if (!changeRowCount)
            {
                // �폜�����������V�K�ɍs��ǉ�����
                for (int i = 0; i < goodsRowNoList.Count; i++)
                {
                    this.AddGoodsDetailRow();
                }
            }
            this._goodsDetailDataTable.EndLoadData();

        }

        /// <summary>
        /// �������f�[�^�e�[�u��No�񏉊�������
        /// </summary>
        /// <remarks>
        /// </remarks>
        private void InitializeGoodsSetDetailRowNoColumn()
        {
            this._goodsDetailDataTable.BeginLoadData();

            for (int i = 0; i < this._goodsDetailDataTable.Rows.Count; i++)
            {
                this._goodsDetailDataTable[i].No = (short)(i + 1);
            }

            this._goodsDetailDataTable.EndLoadData();
        }

        /// <summary>
        /// �Z���A�N�e�B�u���{�^���L�������R���g���[������
        /// </summary>
        /// <param name="index">�s�C���f�b�N�X</param>
        /// <remarks>
       /// </remarks>
        private void ActiveCellButtonEnabledControl(int index)
        {
            // �s����{�^���̗L��������ݒ肷��
            int makerCode = int.Parse(this._goodsDetailDataTable[index].MakerCode); 
            string goodsCode = this._goodsDetailDataTable[index].GoodsCode;

            if (makerCode == 0 && goodsCode == "")
            {
                this.uButton_StoreChange.Enabled = true;
                
            }
        }

        /// <summary>
        /// �������f�[�^�Z�b�e�B���O�����i���i�Z�b�g���ݒ�j
        /// </summary>
        /// <param name="goodsRowNo">�������s�ԍ�</param>
        /// <param name="goodsUnitData">���i�Z�b�g���e�N���X���X�g</param>
        /// <param name="unitPriceCalcRet">�P���Z�o����</param>
        /// <remarks>
        /// <br>UpdateNote : 2010/12/03 ���� ������i�ԓ��͎��̗�O�G���[�̏C��</br>
        /// <br>UpdateNote : 2011/09/01 ���J �Č��ꗗ �A��984 �̑Ή� �I�������݌ɂ������\�������悤�C�� FOR redmine #24263</br>
        /// </remarks>
        // --- UPD 2013/10/08 T.Miyamoto ------------------------------>>>>>
        //private void GoodsDetailRowGoodsSetSetting(int goodsRowNo, GoodsUnitData goodsUnitData)
        private void GoodsDetailRowGoodsSetSetting(int goodsRowNo, GoodsUnitData goodsUnitData, UnitPriceCalcRet unitPriceCalcRet)
        // --- UPD 2013/10/08 T.Miyamoto ------------------------------<<<<<
        {
            GoodsSetGoodsDataSet.GoodsSetDetailRow row = this._goodsDetailDataTable.FindByNo((short)goodsRowNo);

            row.Disply    = goodsUnitData.JoinDispOrder;                    // �\������
            row.MakerCode = goodsUnitData.GoodsMakerCd.ToString("d04");     // �����惁�[�J�[�R�[�h   
            row.MakerName = goodsUnitData.MakerName;                        // �����惁�[�J�[��
            row.GoodsCode = goodsUnitData.GoodsNo;                          // �i��
            row.GoodsName = goodsUnitData.GoodsName;                        // �i��
            row.Qty = goodsUnitData.JoinQty.ToString();                     // QTY
            //row.OfferKubun = goodsUnitData.OfferKubun.ToString();         // �񋟋敪
            row.SetNote = goodsUnitData.JoinSpecialNote;                    // �����K�i�E���L����

            switch (goodsUnitData.OfferKubun)
            {
                case 0:     // ���[�U�[�o�^
                case 1:     // �񋟏����ҏW
                case 2:     // �񋟗D�ǕҏW
                    {
                        // ���[�U�[
                        row.OfferKubun = "0";
                        break;
                    }
                case 3:     // 3:�񋟏���
                case 4:     // 4:�񋟗D��
                case 5:     // 5:TBO
                case 7:     // 7:�I���W�i��
                    {
                        // ��
                        row.OfferKubun = "1";
                        break;
                    }
            }

            //row.OfferDate = goodsUnitData.OfferDate.ToString("yyyy/MM/dd");
            row.EditFlg = true;                                             // �ҏW��
            row.AddFlag = true;                                             // �ǉ��t���O
            
            // ���i�ݒ�
            if (goodsUnitData.GoodsPriceList.Count > 0)
            {
                GoodsPrice goodsPrice;

                // ���i���X�g���猻�݂̉��i���擾
                goodsPrice = this._joinPartsUAcs.GetGoodsPriceFromGoodsPriceList(goodsUnitData.GoodsPriceList);
                // ---UPD 2010/12/03 ---------------------------------------->>>>>
                //row.Price = goodsPrice.ListPrice;                           // �W�����i
                //row.Cost = goodsPrice.SalesUnitCost;                        // ���P��
                if (goodsPrice != null)
                {
                    row.Price = goodsPrice.ListPrice;                           // �W�����i
                    row.Cost = goodsPrice.SalesUnitCost;                       // ���P��
                }
                // ---UPD 2010/12/03 ----------------------------------------<<<<<
            }
            // --- ADD 2013/10/08 T.Miyamoto ------------------------------>>>>>
            if (unitPriceCalcRet != null)
            {
                row.Cost = unitPriceCalcRet.UnitPriceTaxExcFl; // ���P��
            }
            // --- ADD 2013/10/08 T.Miyamoto ------------------------------<<<<<

            // �q�ɐݒ�
            if (goodsUnitData.StockList.Count > 0)
            {
                Stock stock = new Stock();
                //stock = goodsUnitData.StockList[0];  // DEL 2011/09/01
                // ----------------- ADD 2011/09/01 ------------------- >>>>>
                foreach (Stock stockBak in goodsUnitData.StockList)
                {
                    if (stockBak.WarehouseCode == goodsUnitData.SelectedWarehouseCode)
                    {
                        stock = stockBak;
                    }
                }
                // ----------------- ADD 2011/09/01 ------------------- <<<<<

                row.Store = stock.WarehouseName;                            // �q�ɖ���
                row.ShelfNo = stock.WarehouseShelfNo;                       // �I��
                row.Stock = stock.ShipmentPosCnt;                           // ���݌�
                row.StoreCode = stock.WarehouseCode;                        // �q�ɃR�[�h

                // �݌ɏ�񃊃X�g�̍쐬
                string key = goodsUnitData.GoodsNo + "-" + goodsUnitData.GoodsMakerCd.ToString("d4");
                if (!this._storeDic.ContainsKey(key))
                {
                    ArrayList storeList = new ArrayList();
                    foreach (Stock wkStock in goodsUnitData.StockList)
                    {
                        JoinPartsUAcs.F_DATA_STORE dataStore = new JoinPartsUAcs.F_DATA_STORE();
                        dataStore.joinDestMakerCd = goodsUnitData.GoodsMakerCd;
                        dataStore.joinDestPartsNo = goodsUnitData.GoodsNo;
                        dataStore.store = wkStock.WarehouseName;
                        dataStore.shelfNo = wkStock.WarehouseShelfNo;
                        dataStore.stock = wkStock.ShipmentPosCnt;
                        dataStore.storeCode = wkStock.WarehouseCode;

                        if (!storeList.Contains(dataStore))
                        {
                            storeList.Add(dataStore);
                        }
                    }
                    this._storeDic.Add(key, storeList);
                }
            }

            // ���s�����݂��Ȃ��ꍇ�͐V�K�ɒǉ�����
            if (goodsRowNo == (this._goodsDetailDataTable.Rows.Count + 1))
            {
                this.AddGoodsDetailRow();
            }
        }

        /// <summary>
        /// �������f�[�^�Z�b�e�B���O�����i���[�J�[���ݒ�j
        /// </summary>
        /// <param name="goodsRowNo">�������s�ԍ�</param>
        /// <param name="makerUMnt">���[�J�[���e�N���X���X�g</param>
        /// <remarks>
        /// </remarks>
        private void MakerDetailRowGoodsSetSetting(int goodsRowNo, MakerUMnt makerUMnt)
        {
            GoodsSetGoodsDataSet.GoodsSetDetailRow row = this._goodsDetailDataTable.FindByNo((short)goodsRowNo);

            // �K�C�h�f�[�^�W�J
            row.MakerCode = makerUMnt.GoodsMakerCd.ToString("d04");
            row.MakerName = makerUMnt.MakerName;

            // ���[�J�[���ݒ肳�ꂽ��f�[�^�̐����������킹�邽�ߏ��i�����N���A����
            row.GoodsCode = "";
            row.GoodsName = "";
        }

        /// <summary>
        /// ���l���̓`�F�b�N����
        /// </summary>
        /// <param name="keta">����(�}�C�i�X�������܂܂�)</param>
        /// <param name="priod">�����_�ȉ�����</param>
        /// <param name="prevVal">���݂̕�����</param>
        /// <param name="key">���͂��ꂽ�L�[�l</param>
        /// <param name="selstart">�J�[�\���ʒu</param>
        /// <param name="sellength">�I�𕶎���</param>
        /// <param name="minusFlg">�}�C�i�X���͉H</param>
        /// <param name="NumberFlg">���l���͉H</param>
        /// <returns>true=���͉�,false=���͕s��</returns>
        /// <remarks>
        /// </remarks>
        private bool KeyPressNumCheck(int keta, int priod, string prevVal, char key, int selstart, int sellength, Boolean minusFlg, Boolean NumberFlg)
        {
            // ����L�[�������ꂽ�H
            if (Char.IsControl(key))
            {
                return true;
            }

            // �����ꂽ�L�[�����l�ȊO�A�����l�ȊO���͕s��
            if (!Char.IsDigit(key) && !NumberFlg)
            {
                return false;
            }

            // �L�[�������ꂽ�Ɖ��肵���ꍇ�̕�����𐶐�����B
            string _strResult = "";
            if (sellength > 0)
            {
                _strResult = prevVal.Substring(0, selstart) + prevVal.Substring(selstart + sellength, prevVal.Length - (selstart + sellength));
            }
            else
            {
                _strResult = prevVal;
            }

            // �}�C�i�X�̃`�F�b�N
            if (key == '-')
            {
                // �}�C�i�X(�����_)�����͉\���H
                if (minusFlg == false)
                {
                    return false;
                }
            }

            // �����_�̃`�F�b�N
            if (key == '.')
            {
                if (priod == 0)
                {
                    return false;
                }
                else
                {
                    // �����_�����ɑ��݂��邩�H
                    if (_strResult.Contains("."))
                    {
                        return false;
                    }
                }
            }
            else
            {
                // �����_�����ɑ��݂��邩�H
                if (_strResult.Contains("."))
                {
                    int index = _strResult.IndexOf('.');
                    string strDecimal = _strResult.Substring(index + 1);

                    if ((strDecimal.Length >= priod) && (selstart > index))
                    {
                        // �����������͉\�����ȏ�ŁA�J�[�\���ʒu�������_�ȍ~
                        return false;
                    }
                    else if (((keta - priod) < index))
                    {
                        // �������̌��������͉\�����𒴂���
                        return false;
                    }
                }
                else
                {
                    // �����_������O��ɐ������̌���������
                    if (((keta - priod) <= _strResult.Length))
                    {
                        return false;
                    }
                }
            }

            // �L�[�������ꂽ���ʂ̕�����𐶐�����B
            _strResult = prevVal.Substring(0, selstart)
                + key
                + prevVal.Substring(selstart + sellength, prevVal.Length - (selstart + sellength));

            // �����`�F�b�N�I
            if (_strResult.Length > keta)
            {
                if (_strResult[0] == '-')
                {
                    if (_strResult.Length > (keta + 1))
                    {
                        return false;
                    }
                }
                else if (_strResult.Contains("."))
                {
                    if (_strResult.Length > (keta + 1))
                    {
                        return false;
                    }
                }
                else if ((_strResult[0] == '-') && (_strResult.Contains(".")))
                {
                    if (_strResult.Length > (keta + 2))
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }

            return true;
        }

        // ADD 2008/11/17 �s��Ή�[6564] �uQTY�v�A�u�����K�i�E���L�����v�͕ҏW�\ ---------->>>>>
        /// <summary>
        /// �ҏW�\�ȃ��C�A�E�g�ݒ���s���܂��B
        /// </summary>
        /// <param name="no">
        /// �s�ԍ�<br/>
        /// ��<c>cell.Rows.Index</c>���w�肷��ꍇ�A������ -1 �����̂ŁA�n���Ƃ��� +1 ���邱�ƁB
        /// </param>
        private void SetEditableDisplayLayout(int no)
        {
            IList<string> enabledColumnNameList = new List<string>();
            {
                // �\����
                enabledColumnNameList.Add(this._goodsDetailDataTable.DisplyColumn.ColumnName);
                // �i��
                enabledColumnNameList.Add(this._goodsDetailDataTable.GoodsCodeColumn.ColumnName);
                // QTY
                enabledColumnNameList.Add(this._goodsDetailDataTable.QtyColumn.ColumnName);
                // �����K�i�E���L����
                enabledColumnNameList.Add(this._goodsDetailDataTable.SetNoteColumn.ColumnName);
            }
            foreach (string columnName in enabledColumnNameList)
            {
                bool editFlag = (bool)this.uGrid_Details.DisplayLayout.Rows[no - 1].Cells[this._goodsDetailDataTable.EditFlgColumn.ColumnName].Value;
                if (!editFlag) continue;

                this.uGrid_Details.DisplayLayout.Rows[no - 1].Cells[columnName].Activation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
                this.uGrid_Details.DisplayLayout.Rows[no - 1].Cells[columnName].TabStop = Infragistics.Win.DefaultableBoolean.True;
            }
        }
        // ADD 2008/11/17 �s��Ή�[6564] �uQTY�v�A�u�����K�i�E���L�����v�͕ҏW�\ ----------<<<<<

        #endregion

        /// <summary>
        /// �{�^��Enable�ݒ菈��
        /// </summary>
        /// <remarks>
        /// Note			: �O���b�h�őq�ɗ񂪑I�����ꂽ�ꍇ�ɑq�ɐؑփ{�^����L���ɂ���<br />
        /// Programmer		: 30415 �ēc �ύK<br />
        /// Date			: 2008/07/30<br />
        /// </remarks>
        private void SetEnable_Btn()
        {
            if (this.uGrid_Details.ActiveCell == null)
            {
                uButton_StoreChange.Enabled = false;
                uButton_RowDelete.Enabled = false;

                return;
            }

            // �q�ɗ�H
            if (
                this.uGrid_Details.ActiveCell.Column.Key == this._goodsDetailDataTable.StoreColumn.ColumnName
                // ADD 2008/11/06 �s��Ή�[6568] �q�ɃR�[�h��\�� ---------->>>>>
                    ||
                this.uGrid_Details.ActiveCell.Column.Key.Equals(this._goodsDetailDataTable.StoreCodeColumn.ColumnName)
                // ADD 2008/11/06 �s��Ή�[6568] �q�ɃR�[�h��\�� ----------<<<<<
            )
            {
                // �\�����ʗ�ƕi�ԗ񂪋�łȂ��ꍇ
                if ((this.uGrid_Details.Rows[this.uGrid_Details.ActiveRow.Index].Cells[this._goodsDetailDataTable.DisplyColumn.ColumnName].Value.ToString() != "") &&
                   (this.uGrid_Details.Rows[this.uGrid_Details.ActiveRow.Index].Cells[this._goodsDetailDataTable.GoodsCodeColumn.ColumnName].Value.ToString() != ""))
                {
                    // �q�ɐؑփ{�^���L��
                    uButton_StoreChange.Enabled = true;
                }
                else
                {
                    // �q�ɐؑփ{�^������
                    uButton_StoreChange.Enabled = false;
                }
            }
            else
            {
                // �q�ɐؑփ{�^������
                uButton_StoreChange.Enabled = false;
            }

            if (_deleteBtnFlag)
            {
                if ((this.uGrid_Details.Rows[this.uGrid_Details.ActiveRow.Index].Cells[this._goodsDetailDataTable.DisplyColumn.ColumnName].Value.ToString() != "") &&
                   (this.uGrid_Details.Rows[this.uGrid_Details.ActiveRow.Index].Cells[this._goodsDetailDataTable.GoodsCodeColumn.ColumnName].Value.ToString() != ""))
                {
                    // DEL 2009/06/22 ------>>>
                    //// �񋟃f�[�^�H
                    //if ((this.uGrid_Details.Rows[this.uGrid_Details.ActiveRow.Index].Cells[this._goodsDetailDataTable.EditFlgColumn.ColumnName].Value.ToString() != "1"))
                    // DEL 2009/06/22 ------<<<
                    // ADD 2009/06/22 ------>>>
                    // �ҏW�\�f�[�^�H
                    if (!(bool)this.uGrid_Details.Rows[this.uGrid_Details.ActiveRow.Index].Cells[this._goodsDetailDataTable.EditFlgColumn.ColumnName].Value)
                    // ADD 2009/06/22 ------<<<
                    {
                        // �폜�{�^���g�p�s��
                        uButton_RowDelete.Enabled = false;
                    }
                    else
                    {
                        // �폜�{�^���g�p��
                        uButton_RowDelete.Enabled = true;
                    }
                }
                else
                {
                    // �폜�{�^���g�p��
                    uButton_RowDelete.Enabled = true;
                }
            }
            else
            {
                // �폜�{�^���g�p�s��
                uButton_RowDelete.Enabled = false;
            }
        }

        /// <summary>
        /// ���i�A���f�[�^�p���[�J���L���b�V���擾
        /// </summary>
        /// <param name="goodsUnitDataDic">���i�A���f�[�^�p�f�B�N�V���i���[</param>
        /// <remarks>
        /// </remarks>
        public void GetLC_GoodsUnitData(out Dictionary<string, GoodsUnitData> goodsUnitDataDic)
        {
            goodsUnitDataDic = new Dictionary<string, GoodsUnitData>();

            foreach (GoodsUnitData workGoodsUnitData in _lcGoodsUnitDataList)
            {
                // ���[�U�[�o�^����Ă��Ȃ����i�A���f�[�^��ݒ�
                switch (workGoodsUnitData.OfferKubun)
                {
                    case 3:     // 3:�񋟏���
                    case 4:     // 4:�񋟗D��
                    case 5:     // 5:TBO
                    case 7:     // 7:�I���W�i��
                        {
                            // �i�Ԃƃ��[�J�[�R�[�h���L�[�Ƃ���
                            string key = workGoodsUnitData.GoodsNo + "-" + workGoodsUnitData.GoodsMakerCd.ToString("d04");
                            if (goodsUnitDataDic.ContainsKey(key))
                            {
                                goodsUnitDataDic.Remove(key);
                            }
                            goodsUnitDataDic.Add(key, workGoodsUnitData);
                            break;
                        }
                }
            }
        }

        # region ��Control Event Methods

        /// <summary>
        /// �O���b�h�Z���A�N�e�B�u�㔭���C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        private void uGrid_Details_AfterCellActivate(object sender, EventArgs e)
        {
            // �{�^��Enable�ݒ菈��
            // 2010/07/14 Add >>>
            if (this.uGrid_Details.ActiveCell == null) return;

            Infragistics.Win.UltraWinGrid.UltraGridCell cell = this.uGrid_Details.ActiveCell;

            // ���l���ڂ���̏ꍇ
            if (cell.Value is DBNull)
            {
                if ((cell.Column.DataType == typeof(Int32)) ||
                    (cell.Column.DataType == typeof(Int64)) ||
                    (cell.Column.DataType == typeof(double)))
                {
                    cell.Value = 0;
                }
            }
            if ((string.IsNullOrEmpty(this._goodsDetailDataTable[cell.Row.Index]["GoodsCode"].ToString()))
                && (string.IsNullOrEmpty(this._goodsDetailDataTable[cell.Row.Index]["MakerCode"].ToString()))
                && (Convert.ToInt32(_goodsDetailDataTable[cell.Row.Index]["Disply"]) < 100))
            {
                _deleteBtnFlag = false;
            }
            else
            {
                _deleteBtnFlag = true;
            }
            // 2010/07/14 Add <<<
            SetEnable_Btn();
        }

        /// <summary>
        /// Grid�A�N�V����������C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        private void uGrid_Details_AfterPerformAction(object sender, Infragistics.Win.UltraWinGrid.AfterUltraGridPerformActionEventArgs e)
        {
            // ADD 2008/11/20 �s��Ή�[7971] ���L�[�ɂ��Z���ړ����̕ҏW���[�h ---------->>>>>�@���R�����g�A�E�g����Ă����R�[�h�𕜊�
            switch (e.UltraGridAction)
            {
                case Infragistics.Win.UltraWinGrid.UltraGridAction.ActivateCell:
                case Infragistics.Win.UltraWinGrid.UltraGridAction.AboveCell:
                case Infragistics.Win.UltraWinGrid.UltraGridAction.BelowCell:
                case Infragistics.Win.UltraWinGrid.UltraGridAction.PrevCell:
                case Infragistics.Win.UltraWinGrid.UltraGridAction.NextCell:
                case Infragistics.Win.UltraWinGrid.UltraGridAction.PageUpCell:
                case Infragistics.Win.UltraWinGrid.UltraGridAction.PageDownCell:

                    // �A�N�e�B�u�ȃZ�������邩�H�܂��͕ҏW�\�Z�����H
                    if ((this.uGrid_Details.ActiveCell != null) && (this.uGrid_Details.ActiveCell.Column.CellActivation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit) && (this.uGrid_Details.ActiveCell.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit))
                    {
                        // �A�N�e�B�u�Z���̃X�^�C�����擾
                        switch (this.uGrid_Details.ActiveCell.StyleResolved)
                        {
                            // �G�f�B�b�g�n�X�^�C��
                            case Infragistics.Win.UltraWinGrid.ColumnStyle.Default:
                            case Infragistics.Win.UltraWinGrid.ColumnStyle.Edit:
                            case Infragistics.Win.UltraWinGrid.ColumnStyle.EditButton:
                                {
                                    // �ҏW���[�h�ɂ���H
                                    if (this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode))
                                    {
                                        if (!(this.uGrid_Details.ActiveCell.Value is System.DBNull))
                                        {
                                            // �S�I����Ԃɂ���B
                                            this.uGrid_Details.ActiveCell.SelStart = 0;
                                            this.uGrid_Details.ActiveCell.SelLength = this.uGrid_Details.ActiveCell.Text.Length;
                                        }
                                    }
                                    break;
                                }
                            default:
                                {
                                    // �G�f�B�b�g�n�ȊO�̃X�^�C���ł���΁A�ҏW��Ԃɂ���B
                                    this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                                    break;
                                }
                        }
                    }
                    break;
            }
            // ADD 2008/11/20 �s��Ή�[7971] ���L�[�ɂ��Z���ړ����̕ҏW���[�h ----------<<<<<
        }

        /// <summary>
        /// �O���b�h�Z���A�N�e�B�u���O�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        private void uGrid_Details_BeforeCellActivate(object sender, Infragistics.Win.UltraWinGrid.CancelableCellEventArgs e)
        {
            // 2009.02.09 30413 ���� �K�i���L�����̂�IME��ON >>>>>>START
            if (e.Cell.Column.Key == this._goodsDetailDataTable.SetNoteColumn.ColumnName)
            {
                // �K�i�^���L���� IME��ON
                this.uGrid_Details.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            }
            else
            {
                // ���̑� IME�𖳌�
                this.uGrid_Details.ImeMode = System.Windows.Forms.ImeMode.Disable;
            }
            // 2009.02.09 30413 ���� �K�i���L�����̂�IME��ON <<<<<<END
        }

        /// <summary>
        /// �O���b�h�Z���A�b�v�f�[�g�O�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        private void uGrid_Details_BeforeCellUpdate(object sender, Infragistics.Win.UltraWinGrid.BeforeCellUpdateEventArgs e)
        {
            return;
        }

        /// <summary>
        /// �O���b�h�f�[�^�G���[�����C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        private void uGrid_Details_CellDataError(object sender, Infragistics.Win.UltraWinGrid.CellDataErrorEventArgs e)
        {
            if (this.uGrid_Details.ActiveCell != null)
            {
                // ���l���ڂ̏ꍇ
                if ((this.uGrid_Details.ActiveCell.Column.DataType == typeof(Int32)) ||
                    (this.uGrid_Details.ActiveCell.Column.DataType == typeof(Int64)) ||
                    (this.uGrid_Details.ActiveCell.Column.DataType == typeof(double)))
                {
                    Infragistics.Win.EmbeddableEditorBase editorBase = this.uGrid_Details.ActiveCell.EditorResolved;

                    // �����͂�0�ɂ���
                    if (editorBase.CurrentEditText.Trim() == "")
                    {
                        editorBase.Value = 0;				// 0���Z�b�g
                        this.uGrid_Details.ActiveCell.Value = 0;
                    }
                    // ���l���ڂɁu-�vor�u.�v�������������ĂȂ�������ʖڂł�
                    else if ((editorBase.CurrentEditText.Trim() == "-") ||
                        (editorBase.CurrentEditText.Trim() == ".") ||
                        (editorBase.CurrentEditText.Trim() == "-."))
                    {
                        editorBase.Value = 0;				// 0���Z�b�g
                        this.uGrid_Details.ActiveCell.Value = 0;
                    }
                    // �ʏ����
                    else
                    {
                        try
                        {
                            editorBase.Value = Convert.ChangeType(editorBase.CurrentEditText.Trim(), this.uGrid_Details.ActiveCell.Column.DataType);
                            this.uGrid_Details.ActiveCell.Value = editorBase.Value;
                        }
                        catch
                        {
                            editorBase.Value = 0;
                            this.uGrid_Details.ActiveCell.Value = 0;
                        }
                    }
                    e.RaiseErrorEvent = false;			// �G���[�C�x���g�͔��������Ȃ�
                    e.RestoreOriginalValue = false;		// �Z���̒l�����ɖ߂��Ȃ�
                    e.StayInEditMode = false;			// �ҏW���[�h�͔�����
                }
            }
        }

        /// <summary>
        /// �O���b�h�G���^�[�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        private void uGrid_Details_Enter(object sender, EventArgs e)
        {
            // [������]�{�^���̃t�H�[�J�X����
            this.uButton_JoinDest.Enabled = true;   // ADD 2008/11/06 �s��Ή�[7109] ��փ}�X�^�V���\��
        }

        // ADD 2008/11/06 �s��Ή�[7109] ��փ}�X�^�V���\�� ---------->>>>>
        /// <summary>
        /// �q�F��������O���b�h��Leave�C�x���g�n���h��
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        private void uGrid_Details_Leave(object sender, EventArgs e)
        {
            // [������]�{�^���̃t�H�[�J�X����
            //this.uButton_JoinDest.Enabled = false;  // DEL gezh 2014/01/21 Redmine#41447
            // ---------- ADD gezh 2014/01/21 Redmine#41447 ------------------------>>>>>
            if (this.uButton_StoreChange.Focused || this.uButton_JoinDest.Focused)
            {
                this.uButton_JoinDest.Enabled = true;
            }
            // ---------- ADD gezh 2014/01/21 Redmine#41447 ------------------------<<<<<
        }
        // ADD 2008/11/06 �s��Ή�[7109] ��փ}�X�^�V���\�� ----------<<<<<

        /// <summary>
        /// �O���b�h�L�[�_�E���C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        private void uGrid_Details_KeyDown(object sender, KeyEventArgs e)
        {
            #region ���Z�����I������Ă���ꍇ
        if (this.uGrid_Details.ActiveCell != null)
            {
                Infragistics.Win.UltraWinGrid.UltraGridCell cell = this.uGrid_Details.ActiveCell;

                #region ��Escape�L�[
                if (e.KeyCode == Keys.Escape)
                {
                    // �Ȃɂ����Ȃ�
                }
                #endregion

                #region ��Shift�L�[
                if (e.Shift)
                {
                    switch (e.KeyCode)
                    {
                        case Keys.Down:
                            {
                                this.uGrid_Details.ActiveCell = null;
                                this.uGrid_Details.ActiveRow = cell.Row;
                                this.uGrid_Details.Selected.Rows.Clear();
                                this.uGrid_Details.Selected.Rows.Add(cell.Row);
                                break;
                            }
                        case Keys.Up:
                            {
                                this.uGrid_Details.ActiveCell = null;
                                this.uGrid_Details.ActiveRow = cell.Row;
                                this.uGrid_Details.Selected.Rows.Clear();
                                this.uGrid_Details.Selected.Rows.Add(cell.Row);
                                break;
                            }
                    }
                }
                #endregion

                #region �����̑��̃L�[
                else
                {
                    // �ҏW���ł������ꍇ
                    if (cell.IsInEditMode)
                    {
                        // �Z���̃X�^�C���ɂĔ���
                        switch (this.uGrid_Details.ActiveCell.StyleResolved)
                        {
                            #region < �e�L�X�g�{�b�N�X�E�e�L�X�g�{�b�N�X(�{�^���t) >
                            case Infragistics.Win.UltraWinGrid.ColumnStyle.Edit:
                            case Infragistics.Win.UltraWinGrid.ColumnStyle.EditButton:
                                {
                                    switch (e.KeyData)
                                    {
                                        // ���L�[
                                        case Keys.Left:
                                            if (this.uGrid_Details.ActiveCell.SelStart == 0)
                                            {
                                                this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.PrevCellByTab);
                                                e.Handled = true;
                                            }
                                            break;
                                        // ���L�[
                                        case Keys.Right:
                                            if (this.uGrid_Details.ActiveCell.SelStart >= this.uGrid_Details.ActiveCell.Text.Length)
                                            {
                                                this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.NextCellByTab);
                                                e.Handled = true;
                                            }
                                            break;
                                    }
                                    break;
                                }
                            #endregion

                            #region < ��L�ȊO�̃X�^�C�� >
                            default:
                                {
                                    switch (e.KeyData)
                                    {
                                        // ���L�[
                                        case Keys.Left:
                                            {
                                                this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.PrevCellByTab);
                                                e.Handled = true;
                                            }
                                            break;
                                        // ���L�[
                                        case Keys.Right:
                                            {
                                                this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.NextCellByTab);
                                                e.Handled = true;
                                            }
                                            break;
                                    }
                                    break;
                                }
                            #endregion
                        }
                    }

                    switch (e.KeyCode)
                    {
                        #region < Homo�L�[ >
                        case Keys.Home:
                            {
                                this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.FirstCellInGrid);
                                this.MoveNextAllowEditCell(true);
                                break;
                            }
                        #endregion

                        #region < End�L�[ >
                        case Keys.End:
                            {
                                this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.LastCellInGrid);
                                this.MoveNextAllowEditCell(true);
                                break;
                            }
                        #endregion
                    }

                    // �ŏ�ʍs�Ƀt�H�[�J�X
                    if (this.uGrid_Details.ActiveCell.Row.Index == 0)
                    {
                        #region < ���L�[ >
                        if (e.KeyCode == Keys.Up)
                        {
                            if (this.GridKeyDownTopRow != null)
                            {
                                this.GridKeyDownTopRow(this, new EventArgs());
                                e.Handled = true;
                            }
                        }
                        #endregion
                    }
                    // �ŉ��ʍs�Ƀt�H�[�J�X
                    else if (this.uGrid_Details.ActiveCell.Row.Index == this.uGrid_Details.Rows.Count - 1)
                    {
                        #region < ���L�[ >
                        if (e.KeyCode == Keys.Down)
                        {
                            if (this.GridKeyDownButtomRow != null)
                            {
                                this.GridKeyDownButtomRow(this, new EventArgs());
                                e.Handled = true;
                            }
                        }
                        #endregion
                    }
                }
                #endregion
            }
            #endregion

            #region ���񂪑I������Ă���ꍇ
            else if (this.uGrid_Details.ActiveRow != null)
            {
                Infragistics.Win.UltraWinGrid.UltraGridRow row = this.uGrid_Details.ActiveRow;

                switch (e.KeyCode)
                {
                    #region < Delete�L�[ >
                    case Keys.Delete:
                        {
                            this.uButton_RowDelete_Click(this.uButton_RowDelete, new EventArgs());
                            break;
                        }
                    #endregion
                }

                if (this.uGrid_Details.ActiveRow.Index == 0)
                {
                    #region < ���L�[ >
                    if (e.KeyCode == Keys.Up)
                    {
                        if (this.GridKeyDownTopRow != null)
                        {
                            this.GridKeyDownTopRow(this, new EventArgs());
                            e.Handled = true;
                        }
                    }
                    #endregion
                }
                else if (this.uGrid_Details.ActiveRow.Index == this.uGrid_Details.Rows.Count - 1)
                {
                    #region < ���L�[ >
                    if (e.KeyCode == Keys.Down)
                    {
                        if (this.GridKeyDownButtomRow != null)
                        {
                            this.GridKeyDownButtomRow(this, new EventArgs());
                            e.Handled = true;
                        }
                    }
                    #endregion
                }
            }
            #endregion
        }

        /// <summary>
        /// �O���b�h�L�[�v���X�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        private void uGrid_Details_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (this.uGrid_Details.ActiveCell == null) return;
            Infragistics.Win.UltraWinGrid.UltraGridCell cell = this.uGrid_Details.ActiveCell;

            // �\�����ʁH
            if (cell.Column.Key == this._goodsDetailDataTable.DisplyColumn.ColumnName)
            {
                // �ҏW���[�h���H
                if (cell.IsInEditMode)
                {
                    // ���l�ȊO�͓��͕s��
                    if (!this.KeyPressNumCheck(2, 0, cell.Text, e.KeyChar, cell.SelStart, cell.SelLength, false, false))
                    {
                        e.Handled = true;
                        return;
                    }
                }
            }

            #region ��ActiveCell�����[�J�[�R�[�h�̏ꍇ
            if (cell.Column.Key == this._goodsDetailDataTable.MakerCodeColumn.ColumnName)
            {
                // �ҏW���[�h���H
                if (cell.IsInEditMode)
                {
                    if (!this.KeyPressNumCheck(4, 0, cell.Text, e.KeyChar, cell.SelStart, cell.SelLength, false, false))
                    {
                        e.Handled = true;
                        return;
                    }
                }
            }
            #endregion

            #region DEL �i�ԃ`�F�b�N�̍폜
            // DEL 2015/10/28 ���V�� Redmine#47547 ������i�ԓ��͎��� "." ����͂ł��Ȃ����Ƃ̑Ή� ----->>>>>
            //#region ��ActiveCell�����i�R�[�h�̏ꍇ
            //else if (cell.Column.Key == this._goodsDetailDataTable.GoodsCodeColumn.ColumnName)
            //{
            //    // �ҏW���[�h���H
            //    if (cell.IsInEditMode)
            //    {
            //        if (!this.KeyPressNumCheck(24, 0, cell.Text, e.KeyChar, cell.SelStart, cell.SelLength, true, true ))
            //        {
            //            e.Handled = true;
            //            return;
            //        }
            //    }
            //}
            //#endregion
            // DEL 2015/10/28 ���V�� Redmine#47547 ������i�ԓ��͎��� "." ����͂ł��Ȃ����Ƃ̑Ή� -----<<<<<
            #endregion

            // ADD 2008/11/06 �s��Ή�[6568] �uQTY�v�A�u�����K�i�E���L�����v�͕ҏW�\ ---------->>>>>
            #region ��ActiveCell��QTY�̏ꍇ

            // QTY�̕ҏW
            else if (cell.Column.Key.Equals(this._goodsDetailDataTable.QtyColumn.ColumnName))
            {
                // �ҏW���[�h���H
                if (cell.IsInEditMode)
                {
                    if (!this.KeyPressNumCheck(5, 2, cell.Text, e.KeyChar, cell.SelStart, cell.SelLength, false, true))
                    {
                        e.Handled = true;
                        return;
                    }
                }
            }

            #endregion  // ��ActiveCell��QTY�̏ꍇ
            // ADD 2008/11/06 �s��Ή�[6568] �uQTY�v�A�u�����K�i�E���L�����v�͕ҏW�\ ----------<<<<<
        }

        /// <summary>
        /// �O���b�h�L�[�A�b�v�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        private void uGrid_Details_KeyUp(object sender, KeyEventArgs e)
        {
            if (this.uGrid_Details.ActiveCell == null) return;
        }

        private void uGrid_Details_MouseUp(object sender, MouseEventArgs e)
        {
            // �{�^��Enable�ݒ�
            //SetEnable_Btn();

            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.NoColumn.ColumnName].Header.VisiblePosition = 0;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.DisplyColumn.ColumnName].Header.VisiblePosition = 1;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.GoodsCodeColumn.ColumnName].Header.VisiblePosition = 2;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsDetailDataTable.GoodsNameColumn.ColumnName].Header.VisiblePosition = 3;
        }

        #region �� uButton �C�x���g

        /// <summary>
        /// �폜�{�^���N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        private void uButton_RowDelete_Click(object sender, EventArgs e)
        {
            this._goodsDetailDataTable.AcceptChanges();

            // �I���ς݌������s�ԍ����X�g�擾����
            List<int> selectedGoodsRowNoList = this.GetSelectedGoodsRowNoList();
            if ((selectedGoodsRowNoList == null) || (selectedGoodsRowNoList.Count == 0))
            {
                return;
            }

            int rowIdx = selectedGoodsRowNoList[0];
            GoodsSetGoodsDataSet.GoodsSetDetailRow detailRow = (GoodsSetGoodsDataSet.GoodsSetDetailRow)this._goodsDetailDataTable.Rows.Find(rowIdx);

            if (!detailRow.EditFlg)
            {
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_INFO,
                    this.Name,
                    "�o�^�ς̒񋟃f�[�^�͍폜�ł��܂���B",
                    -1,
                    MessageBoxButtons.OK);
                return;
            }

            DialogResult dialogResult = TMsgDisp.Show(
                this,
                emErrorLevel.ERR_LEVEL_QUESTION,
                this.Name,
                "�I���s���폜���Ă���낵���ł����H",
                0,
                MessageBoxButtons.YesNo,
                MessageBoxDefaultButton.Button1);

            if (dialogResult != DialogResult.Yes)
            {
                return;
            }

            // ActiveRow�C���f�b�N�X�擾����
            int rowIndex = this.GetActiveRowIndex();

            string message;
            // �폜�\�`�F�b�N����(���݂͕K��True���������Ă���)
            if (!this.CanDeleteGoodsDetailRow(selectedGoodsRowNoList, out message))
            {
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_INFO,
                    this.Name,
                    message,
                    -1,
                    MessageBoxButtons.OK);

                return;
            }

            try
            {
                this.Cursor = Cursors.WaitCursor;

                // �������s�폜����
                this.DeleteGoodsDetailRow(selectedGoodsRowNoList);

                // ���׃O���b�h�Z���ݒ菈��
                if ((this.uGrid_Details.ActiveCell == null) && (this.uGrid_Details.Rows.Count > rowIndex))
                {
                    this.uGrid_Details.ActiveCell = this.uGrid_Details.Rows[rowIndex].Cells[this._goodsDetailDataTable.GoodsCodeColumn.ColumnName];

                    if ((this.uGrid_Details.ActiveCell.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit) &&
                        (this.uGrid_Details.ActiveCell.Column.CellActivation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit))
                    {
                        this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                    }
                }

                // �����͉\�Z���ړ�����
                this.MoveNextAllowEditCell(true);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// �폜�{�^��Enabled�ύX�㔭���C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        private void uButton_RowDelete_EnabledChanged(object sender, EventArgs e)
        {
            // [����]�E�C���h�E���̃{�^���ƃc�[���{�b�N�X���̃{�^����Enabled�v���p�e�B�̓�������邽�߂̏���
            //       ����E�C���h�E��\�����Ȃ����߂��̃C�x���g���ł͏����͉����s�Ȃ�Ȃ����̂Ƃ���B
            //this._rowDeleteButton.SharedProps.Enabled = ((Infragistics.Win.Misc.UltraButton)sender).Enabled;
        }

        /// <summary>
        /// �q�Ƀ{�^���N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        private void uButton_StoreChange_Click(object sender, EventArgs e)
        {
            JoinPartsUAcs.F_DATA_STORE dataStore = new JoinPartsUAcs.F_DATA_STORE();
            int stockIndex;
            
            // �����惁�[�J�[�R�[�h
            dataStore.joinDestMakerCd = int.Parse(this.uGrid_Details.Rows[this.uGrid_Details.ActiveRow.Index].Cells[this._goodsDetailDataTable.MakerCodeColumn.ColumnName].Value.ToString());
            // ������i��
            dataStore.joinDestPartsNo = this.uGrid_Details.Rows[this.uGrid_Details.ActiveRow.Index].Cells[this._goodsDetailDataTable.GoodsCodeColumn.ColumnName].Value.ToString();
            // �q�ɖ���
            dataStore.store = this.uGrid_Details.Rows[this.uGrid_Details.ActiveRow.Index].Cells[this._goodsDetailDataTable.StoreColumn.ColumnName].Value.ToString();
            // �I��
            dataStore.shelfNo = this.uGrid_Details.Rows[this.uGrid_Details.ActiveRow.Index].Cells[this._goodsDetailDataTable.ShelfNoColumn.ColumnName].Value.ToString();
            // ���݌�
            if (this.uGrid_Details.Rows[this.uGrid_Details.ActiveRow.Index].Cells[this._goodsDetailDataTable.StockColumn.ColumnName].Value != DBNull.Value)
            {
                dataStore.stock = (double)this.uGrid_Details.Rows[this.uGrid_Details.ActiveRow.Index].Cells[this._goodsDetailDataTable.StockColumn.ColumnName].Value;
            }
            // �q�ɃR�[�h
            if (this.uGrid_Details.Rows[this.uGrid_Details.ActiveRow.Index].Cells[this._goodsDetailDataTable.StoreCodeColumn.ColumnName].Value != DBNull.Value)
            {
                dataStore.storeCode = this.uGrid_Details.Rows[this.uGrid_Details.ActiveRow.Index].Cells[this._goodsDetailDataTable.StoreCodeColumn.ColumnName].Value.ToString();
            }

            string key = dataStore.joinDestPartsNo + "-" + dataStore.joinDestMakerCd.ToString("d04");
            if (this._storeDic.ContainsKey(key))
            {
                ArrayList storeData = this._storeDic[key];

                // �Y���f�[�^Index�擾
                stockIndex = storeData.IndexOf(dataStore);

                if (stockIndex >= 0)
                {
                    // Index�ƃf�[�^���͓����H
                    if ((stockIndex + 1) >= storeData.Count)
                    {
                        // �擪�̍݌ɏ���\��
                        dataStore = (JoinPartsUAcs.F_DATA_STORE)storeData[0];
                    }
                    else
                    {
                        // Index�̎��̃f�[�^��\��
                        dataStore = (JoinPartsUAcs.F_DATA_STORE)storeData[stockIndex + 1];
                    }
                }

                // �����惁�[�J�[�R�[�h
                this.uGrid_Details.Rows[this.uGrid_Details.ActiveRow.Index].Cells[this._goodsDetailDataTable.MakerCodeColumn.ColumnName].Value = dataStore.joinDestMakerCd.ToString("d04");
                // ������i��
                this.uGrid_Details.Rows[this.uGrid_Details.ActiveRow.Index].Cells[this._goodsDetailDataTable.GoodsCodeColumn.ColumnName].Value = dataStore.joinDestPartsNo;
                // �q�ɖ���
                this.uGrid_Details.Rows[this.uGrid_Details.ActiveRow.Index].Cells[this._goodsDetailDataTable.StoreColumn.ColumnName].Value = dataStore.store;
                // �I��
                this.uGrid_Details.Rows[this.uGrid_Details.ActiveRow.Index].Cells[this._goodsDetailDataTable.ShelfNoColumn.ColumnName].Value = dataStore.shelfNo;
                // ���݌�
                this.uGrid_Details.Rows[this.uGrid_Details.ActiveRow.Index].Cells[this._goodsDetailDataTable.StockColumn.ColumnName].Value = dataStore.stock;
                // �q�ɃR�[�h
                this.uGrid_Details.Rows[this.uGrid_Details.ActiveRow.Index].Cells[this._goodsDetailDataTable.StoreCodeColumn.ColumnName].Value = dataStore.storeCode;
            }
        }

        // ADD 2008/11/06 �s��Ή�[7109] ��փ}�X�^�V���\�� ---------->>>>>
        /// <summary>
        /// ��փ}�X�^�V���\����ʗp�p�����[�^�̗񋓑�
        /// </summary>
        private enum InitialSearchDivForSubstituteMaster : int
        {
            /// <summary>������</summary>
            Dest = 0,
            /// <summary>������</summary>
            Source = 1
        }

        /// <summary>
        /// ��փ}�X�^�V���\����ʂ�\�����܂��B
        /// </summary>
        /// <param name="initialSearchDiv">�������������悩�𔻕ʂ���敪</param>
        private void ShowSubstituteMasterForm(InitialSearchDivForSubstituteMaster initialSearchDiv)
        {
            PartsInfoDataSet partsInfoDataSet;
            GoodsCndtn goodsCndtn = new GoodsCndtn();
            List<GoodsUnitData> goodsUnitDataList;
            
            goodsCndtn.EnterpriseCode = this._enterpriseCode;
            goodsCndtn.MakerName = "";
            goodsCndtn.GoodsNoSrchTyp = 0;
            // DEL 2009/06/22 ------>>>
            //goodsCndtn.GoodsMakerCd = JoinSourceMakerCode;
            //goodsCndtn.GoodsNo = JoinSourPartsNoWithH;
            // DEL 2009/06/22 ------<<<
            goodsCndtn.JoinSearchDiv = (int)GoodsCndtn.JoinSearchDivType.Search;
            goodsCndtn.IsSettingSupplier = 1;
            goodsCndtn.PriceApplyDate = DateTime.Today;
            goodsCndtn.TotalAmountDispWayCd = 0; // 0:���z�\�����Ȃ�
            goodsCndtn.ConsTaxLayMethod = 1; // 1:���ד]��
            goodsCndtn.SalesCnsTaxFrcProcCd = 0; // 0:���ʐݒ�

            // ADD 2009/06/22 ------>>>
            if (initialSearchDiv == InitialSearchDivForSubstituteMaster.Source)
            {
                // ������
                goodsCndtn.GoodsMakerCd = JoinSourceMakerCode;
                if (!string.IsNullOrEmpty(JoinSourPartsNoWithH))
                {
                    goodsCndtn.GoodsNo = JoinSourPartsNoWithH;
                }
                else
                {
                    goodsCndtn.GoodsNo = "";
                }

                // 2009/08/04 ---------------------------------------->>>
                if (goodsCndtn.GoodsMakerCd == 0 || string.IsNullOrEmpty(JoinSourPartsNoWithH))
                {
                    TMsgDisp.Show(
                            this,
                            emErrorLevel.ERR_LEVEL_EXCLAMATION,
                            this.Name,
                            "�������̏��i���w�肵�ĉ������B",
                            -1,
                            MessageBoxButtons.OK);
                    return;
                }
                // 2009/08/04 ----------------------------------------<<<

            }
            else
            {
                // ������
                // ActiveRow�C���f�b�N�X�擾����
                int rowIndex = this.GetActiveRowIndex();

                // 2009/08/04 ---------------------------------------->>>
                //goodsCndtn.GoodsMakerCd = int.Parse(this.uGrid_Details.Rows[rowIndex].Cells[this._goodsDetailDataTable.MakerCodeColumn.ColumnName].Value.ToString());

                try
                {
                    goodsCndtn.GoodsMakerCd = int.Parse(this.uGrid_Details.Rows[rowIndex].Cells[this._goodsDetailDataTable.MakerCodeColumn.ColumnName].Value.ToString());
                }
                catch
                {
                    goodsCndtn.GoodsMakerCd = 0;
                }
                // 2009/08/04 ---------------------------------------->>>

                goodsCndtn.GoodsNo = this.uGrid_Details.Rows[rowIndex].Cells[this._goodsDetailDataTable.GoodsCodeColumn.ColumnName].Value.ToString();

                // 2009/08/04 ---------------------------------------->>>
                if (goodsCndtn.GoodsMakerCd == 0 || string.IsNullOrEmpty(JoinSourPartsNoWithH))
                {
                    TMsgDisp.Show(
                            this,
                            emErrorLevel.ERR_LEVEL_EXCLAMATION,
                            this.Name,
                            "������̏��i���w�肵�ĉ������B",
                            -1,
                            MessageBoxButtons.OK);

                    return;
                }
                // 2009/08/04 ---------------------------------------<<<

            }
            // ADD 2009/06/22 ------<<<
            
            int status = this._joinPartsUAcs.SearchJoinPartsUData(goodsCndtn, out partsInfoDataSet, out goodsUnitDataList);
            if (status == 0)
            {
                // 2009/07/16 >>>>>>>>>>>>>>>>>>>>>>
                // ADD 2009/06/22 ------>>>
                // ���i��ʂ̊m�F(8:��֏��i)
                //int goodsKind = goodsUnitDataList[0].GoodsKind & 8;
                //if (goodsKind != 8)
                //{
                //    // ��֏��i�ł͖���
                //    TMsgDisp.Show(
                //            this,
                //            emErrorLevel.ERR_LEVEL_INFO,
                //            this.Name,
                //            "�����ɍ��v����f�[�^�����݂��܂���B",
                //            -1,
                //            MessageBoxButtons.OK);
                //    return;
                //}
                // ADD 2009/06/22 ------<<<
                // 2009/07/16 <<<<<<<<<<<<<<<<<<<<<<
                
                PMKEN09081U substituteMaster = new PMKEN09081U();
                substituteMaster.ShowDialog(this, goodsUnitDataList[0], (int)initialSearchDiv);

                // 2009/08/04 --------------------------------------->>>
                uGrid_Details.Focus();
                uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                // 2009/08/04 ---------------------------------------<<<
            }

        }
        // ADD 2008/11/06 �s��Ή�[7109] ��փ}�X�^�V���\�� ----------<<<<<

        /// <summary>
        /// �������{�^���N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        private void uButton_JoinSource_Click(object sender, EventArgs e)
        {
            // TODO:��փ}�X�^�V���\��
            ShowSubstituteMasterForm(InitialSearchDivForSubstituteMaster.Source);   // ADD 2008/11/06 �s��Ή�[7109] ��փ}�X�^�V���\��
        }

        /// <summary>
        /// ������{�^���N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        private void uButton_JoinDest_Click(object sender, EventArgs e)
        {
            // TODO:��փ}�X�^�V���\��
            ShowSubstituteMasterForm(InitialSearchDivForSubstituteMaster.Dest); // ADD 2008/11/06 �s��Ή�[7109] ��փ}�X�^�V���\��
        }

        #endregion

        /// <summary>
        ///	ultraGrid.AfterExitEditMode �C�x���g(Cell)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// </remarks>
        private void uGrid_Details_AfterExitEditMode(object sender, EventArgs e)
        {
            if (this.uGrid_Details.ActiveCell == null) return;

            Infragistics.Win.UltraWinGrid.UltraGridCell cell = this.uGrid_Details.ActiveCell;
            int goodsRowNo = this._goodsDetailDataTable[cell.Row.Index].No;
            int rowIndex = cell.Row.Index;

            // ���l���ڂ���̏ꍇ
            if (cell.Value is DBNull)
            {
                if ((cell.Column.DataType == typeof(Int32)) ||
                    (cell.Column.DataType == typeof(Int64)) ||
                    (cell.Column.DataType == typeof(double)))
                {
                    cell.Value = 0;
                }
            }

            #region ��ActiveCell�����i�R�[�h�̏ꍇ
            if (cell.Column.Key == this._goodsDetailDataTable.GoodsCodeColumn.ColumnName)
            {
                string goodsCode = cell.Value.ToString();

                // �ύX�t���OON
                _changeFlg = true;

                // �i�ԍX�V�敪�̏����ݒ�
                this._joinGoodNoUpdFlg = true;

                if (this._childGoodsNo == goodsCode)
                {
                    // �ҏW�O�ƕҏW�オ�����ꍇ�͏������s��Ȃ�
                    return;
                }

                if (!String.IsNullOrEmpty(goodsCode))
                {
                    #region �����͗L
                    
                    #region < ������ގ擾 >
                    int searchType = this.GetSearchType(goodsCode, out goodsCode);
                    #endregion

                    GoodsCndtn goodsCndtn = new GoodsCndtn();
                    List<GoodsUnitData> goodsUnitDataList;
                    string message;

                    goodsCndtn.EnterpriseCode = this._enterpriseCode;
                    goodsCndtn.GoodsMakerCd = 0;
                    goodsCndtn.MakerName = "";
                    goodsCndtn.GoodsNo = goodsCode;
                    goodsCndtn.GoodsNoSrchTyp = searchType;
                    goodsCndtn.PriceApplyDate = DateTime.Today;
                    goodsCndtn.IsSettingSupplier = 1; // 2009.02.09
                    
                    // �i�Ԍ����i������j
                    int status = this._joinPartsUAcs.SearchPartsFromGoodsNoNonVariousSearch(goodsCndtn, out goodsUnitDataList, out message);
                    
                    if ((status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) && (goodsUnitDataList != null) && (goodsUnitDataList.Count > 0))
                    {
                        #region -- ����擾 --
                        // ���i�}�X�^�f�[�^�N���X
                        GoodsUnitData goodsUnitData = new GoodsUnitData();
                        goodsUnitData = goodsUnitDataList[0];

                        if (this.uGrid_Details.Rows[this.uGrid_Details.ActiveRow.Index].Cells[this._goodsDetailDataTable.DisplyColumn.ColumnName].Value.ToString() != "")
                        {
                            // �\�����ݒ�
                            goodsUnitData.JoinDispOrder = int.Parse(this.uGrid_Details.Rows[this.uGrid_Details.ActiveRow.Index].Cells[this._goodsDetailDataTable.DisplyColumn.ColumnName].Value.ToString());
                        }

                        // ���i�}�X�^���ݒ菈��
                        // --- UPD 2013/10/08 T.Miyamoto ------------------------------>>>>>
                        //this.GoodsDetailRowGoodsSetSetting(goodsRowNo, goodsUnitData);
                        List<UnitPriceCalcRet> unitPriceCalcRetList = null;
                        unitPriceCalcRetList = this.CalclationUnitPrice(goodsUnitDataList); // ���P���擾

                        UnitPriceCalcRet UnitPriceCalcRet = this.SearchUnitPriceCalcRet(2, unitPriceCalcRetList, goodsUnitData);
                        this.GoodsDetailRowGoodsSetSetting(goodsRowNo, goodsUnitData, UnitPriceCalcRet);
                        // --- UPD 2013/10/08 T.Miyamoto ------------------------------<<<<<

                        // �擾�������i�A���f�[�^���L���b�V���Ƃ��ĕێ�
                        if (!_lcGoodsUnitDataList.Contains(goodsUnitData))
                        {
                            _lcGoodsUnitDataList.Add(goodsUnitData);
                        }
                        #endregion

                        // �ҏW�\�J�����̐ݒ�
                        SetEditableDisplayLayout(cell.Row.Index + 1); // ADD 2008/11/17 �s��Ή�[6564] �uQTY�v�A�u�����K�i�E���L�����v�͕ҏW�\
                    }
                    // 2009.02.09 30413 ���� �L�����Z�����̃t�H�[�J�X���� >>>>>>START
                    else if (status == -1)
                    {
                        // ����i�ԑI����ʂŃL�����Z��
                        // �Ώۍs�̃N���A
                        this._goodsDetailDataTable[cell.Row.Index].GoodsCode = "";    // ���i�R�[�h
                        this._goodsDetailDataTable[cell.Row.Index].GoodsName = "";    // ���i����
                        this._goodsDetailDataTable[cell.Row.Index].MakerCode = "";     // ���[�J�[�R�[�h
                        this._goodsDetailDataTable[cell.Row.Index].MakerName = "";    // ���[�J�[����
                        this._goodsDetailDataTable[cell.Row.Index].SetNote = "";      // �����K�i�E���L����
                        this._goodsDetailDataTable[cell.Row.Index].OfferDate = "";    // �񋟓��t
                        this._goodsDetailDataTable[cell.Row.Index][this._goodsDetailDataTable.PriceColumn.ColumnName] = DBNull.Value;   // �W�����i
                        this._goodsDetailDataTable[cell.Row.Index][this._goodsDetailDataTable.CostColumn.ColumnName] = DBNull.Value;    // ���P��
                        this._goodsDetailDataTable[cell.Row.Index].Store = "";        // �q��
                        this._goodsDetailDataTable[cell.Row.Index].ShelfNo = "";      // �I��
                        this._goodsDetailDataTable[cell.Row.Index][this._goodsDetailDataTable.StockColumn.ColumnName] = DBNull.Value;   // ���݌�

                        // �i�ԍX�V�敪�̏����ݒ�
                        this._joinGoodNoUpdFlg = false;
                    }
                    // 2009.02.09 30413 ���� �L�����Z�����̃t�H�[�J�X���� <<<<<<END
                    else
                    {
                        #region -- �擾���s --
                        TMsgDisp.Show(
                            this,
                            emErrorLevel.ERR_LEVEL_INFO,
                            this.Name,
                            "���i�R�[�h [" + goodsCode + "] �ɊY������f�[�^�����݂��܂���B",
                            -1,
                            MessageBoxButtons.OK);

                        //this._goodsDetailDataTable[cell.Row.Index].Disply = "";     // �\������
                        this._goodsDetailDataTable[cell.Row.Index].GoodsCode = "";    // ���i�R�[�h
                        this._goodsDetailDataTable[cell.Row.Index].GoodsName = "";    // ���i����
                        this._goodsDetailDataTable[cell.Row.Index].MakerCode = "";     // ���[�J�[�R�[�h
                        this._goodsDetailDataTable[cell.Row.Index].MakerName = "";    // ���[�J�[����
                        this._goodsDetailDataTable[cell.Row.Index].SetNote = "";      // �����K�i�E���L����
                        this._goodsDetailDataTable[cell.Row.Index].OfferDate = "";    // �񋟓��t
                        this._goodsDetailDataTable[cell.Row.Index][this._goodsDetailDataTable.PriceColumn.ColumnName] = DBNull.Value;   // �W�����i
                        this._goodsDetailDataTable[cell.Row.Index][this._goodsDetailDataTable.CostColumn.ColumnName] = DBNull.Value;    // ���P��
                        this._goodsDetailDataTable[cell.Row.Index].Store = "";        // �q��
                        this._goodsDetailDataTable[cell.Row.Index].ShelfNo = "";      // �I��
                        this._goodsDetailDataTable[cell.Row.Index][this._goodsDetailDataTable.StockColumn.ColumnName] = DBNull.Value;   // ���݌�

                        // �i�ԍX�V�敪�̏����ݒ�
                        this._joinGoodNoUpdFlg = false;

                        return;

                        #endregion
                    }
                    #endregion
                }
                else
                {
                    // ������
                    this._goodsDetailDataTable[cell.Row.Index].GoodsCode = "";   // ���i�R�[�h
                    this._goodsDetailDataTable[cell.Row.Index].GoodsName = "";   // ���i����
                    this._goodsDetailDataTable[cell.Row.Index].MakerCode = "";    // ���[�J�[�R�[�h
                    this._goodsDetailDataTable[cell.Row.Index].MakerName = "";   // ���[�J�[����
                    this._goodsDetailDataTable[cell.Row.Index].Qty = "";         // ADD 2008/10/21 �s��Ή�[6565]
                    this._goodsDetailDataTable[cell.Row.Index].SetNote = "";     // �����K�i�E���L����
                    this._goodsDetailDataTable[cell.Row.Index].OfferDate = "";   // �񋟓��t
                    this._goodsDetailDataTable[cell.Row.Index][this._goodsDetailDataTable.PriceColumn.ColumnName] = DBNull.Value;   // �W�����i
                    this._goodsDetailDataTable[cell.Row.Index][this._goodsDetailDataTable.CostColumn.ColumnName] = DBNull.Value;    // ���P��
                    this._goodsDetailDataTable[cell.Row.Index].Store = "";        // �q��
                    this._goodsDetailDataTable[cell.Row.Index].ShelfNo = "";      // �I��
                    this._goodsDetailDataTable[cell.Row.Index][this._goodsDetailDataTable.StockColumn.ColumnName] = DBNull.Value;   // ���݌�

                    return;
                }
            }
            #endregion

            else if (cell.Column.Key == this._goodsDetailDataTable.QtyColumn.ColumnName)
            {
                // QTY
                double qty = 0.0;
                if ((!double.TryParse(cell.Text, out qty)) || (qty == 0.0))
                {
                    // DEL 2009/06/24 ------>>>
                    //if (cell.Text != "")
                    //{
                    //    this._goodsDetailDataTable[cell.Row.Index].Qty = "0";
                    //}
                    // DEL 2009/06/24 ------<<<
                    this._goodsDetailDataTable[cell.Row.Index].Qty = "0.00";    // ADD 2009/06/24
                }
                else
                {
                    this._goodsDetailDataTable[cell.Row.Index].Qty = qty.ToString("##0.00");

                }
            }
        }

        #endregion

        /// <summary>
        ///	ultraGrid.uGrid_Details_BeforeExitEditMode �C�x���g(Cell)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// </remarks>
        private void uGrid_Details_BeforeExitEditMode(object sender, Infragistics.Win.UltraWinGrid.BeforeExitEditModeEventArgs e)
        {
            if (this.uGrid_Details.ActiveCell == null) return;

            Infragistics.Win.UltraWinGrid.UltraGridCell cell = this.uGrid_Details.ActiveCell;

            if (cell.Column.Key == this._goodsDetailDataTable.GoodsCodeColumn.ColumnName)
            {
                this._childGoodsNo = cell.Value.ToString();
            }
        }

        // --- ADD 2013/10/08 T.Miyamoto ------------------------------>>>>>
        /// <summary>
        /// �P���Z�o���W���[���ɂ��A���P�����Z�o���܂��B
        /// </summary>
        /// <param name="goodsUnitDataList">���i�A���f�[�^�I�u�W�F�N�g���X�g</param>
        /// <returns></returns>
        public List<UnitPriceCalcRet> CalclationUnitPrice(List<GoodsUnitData> goodsUnitDataList)
        {
            UnitPriceCalculation _unitPriceCalculation = new UnitPriceCalculation();

            List<UnitPriceCalcRet> unitPriceCalcRetList = new List<UnitPriceCalcRet>();
            List<UnitPriceCalcParam> unitPriceCalcParamList = new List<UnitPriceCalcParam>();
            List<GoodsUnitData> tempGoodsUnitDataList = new List<GoodsUnitData>();

            foreach (GoodsUnitData goodsUnitData in goodsUnitDataList)
            {
                GoodsUnitData tempGoodsUnitData = goodsUnitData.Clone();
                tempGoodsUnitDataList.Add(tempGoodsUnitData);

                if ((goodsUnitData.GoodsMakerCd != 0) && (!string.IsNullOrEmpty(goodsUnitData.GoodsNo)))
                {
                    UnitPriceCalcParam unitPriceCalcParam = new UnitPriceCalcParam();

                    unitPriceCalcParam.GoodsMakerCd = goodsUnitData.GoodsMakerCd;                               // ���[�J�[�R�[�h
                    unitPriceCalcParam.GoodsNo = goodsUnitData.GoodsNo;                                         // ���i�ԍ�
                    // --- DEL 2013/12/02 T.Miyamoto ------------------------------>>>>>
                    //unitPriceCalcParam.GoodsRateGrpCode = goodsUnitData.GoodsRateGrpCode;                       // ���i�|���O���[�v�R�[�h
                    //unitPriceCalcParam.GoodsRateRank = goodsUnitData.GoodsRateRank;                             // ���i�|�������N
                    // --- DEL 2013/12/02 T.Miyamoto ------------------------------<<<<<
                    unitPriceCalcParam.PriceApplyDate = DateTime.Now;                                           // �K�p��
                    unitPriceCalcParam.SectionCode = LoginInfoAcquisition.Employee.BelongSectionCode.TrimEnd(); // ���_�R�[�h

                    unitPriceCalcParamList.Add(unitPriceCalcParam);
                }
            }

            // ���P���擾
            _unitPriceCalculation.CalculateUnitCost(unitPriceCalcParamList, tempGoodsUnitDataList, out unitPriceCalcRetList);

            return unitPriceCalcRetList;
        }

        /// <summary>
        /// �P���Z�o���ʃ��X�g����Y���f�[�^����
        /// </summary>
        /// <param name="unitPriceKind">�P�����</param>
        /// <param name="unitPriceCalcRetList">�P���Z�o���ʃ��X�g</param>
        /// <param name="goodsUnitData">���i�A���f�[�^�I�u�W�F�N�g</param>
        /// <returns></returns>
        public UnitPriceCalcRet SearchUnitPriceCalcRet(int unitPriceKind, List<UnitPriceCalcRet> unitPriceCalcRetList, GoodsUnitData goodsUnitData)
        {
            UnitPriceCalcRet unitPriceCalcRet = null;

            foreach (UnitPriceCalcRet unitPriceCalcRetWk in unitPriceCalcRetList)
            {
                if ((unitPriceCalcRetWk.UnitPriceKind == ((int)unitPriceKind).ToString()) &&
                    //(unitPriceCalcRetWk.GoodsNo == unitPriceCalcParam.GoodsNo) &&
                    //(unitPriceCalcRetWk.GoodsMakerCd == unitPriceCalcParam.GoodsMakerCd))
                    // --- ADD 2013/12/02 T.Miyamoto ------------------------------>>>>>
                    (unitPriceCalcRetWk.RateSettingDivide == "6A") &&
                    // --- ADD 2013/12/02 T.Miyamoto ------------------------------<<<<<
                    (unitPriceCalcRetWk.GoodsNo       == goodsUnitData.GoodsNo) &&
                    (unitPriceCalcRetWk.GoodsMakerCd  == goodsUnitData.GoodsMakerCd))
                {
                    unitPriceCalcRet = unitPriceCalcRetWk.Clone();
                }
            }
            return unitPriceCalcRet;
        }
        // --- ADD 2013/10/08 T.Miyamoto ------------------------------<<<<<

        // ------------ ADD 杍^ 2013/12/04 --------------- >>>>
        /// <summary>
        /// ��ʂ̉�����ύX�C�x�b�g
        /// </summary>
        /// <param name="width">��ʂ̉���</param>
        /// <returns></returns>
        public void SettingGridWidth(int width, int height)
        {
            this.Width = width;
            this.panel1.Width = width;
            this.uGrid_Details.Width = width;

            this.Height = height;
            this.panel1.Height = height;
            this.uGrid_Details.Height = height;

            this.panel1.Dock = DockStyle.Fill;
            this.uGrid_Details.Dock = DockStyle.Fill;
            this.uGrid_Details.Refresh();
        }
        // ------------ ADD 杍^ 2013/12/04 --------------- <<<<

        // ADD START �����@2013/12/04 FOR Redmine#41447 ------>>>>>>
        # region [�O���b�h�J������� �ۑ��E����]
        /// <summary>
        /// �O���b�h�J�������̕ۑ�
        /// </summary>
        /// <param name="targetGrid"></param>
        /// <param name="settingList"></param>
        public void SaveGridColumnsSetting(Infragistics.Win.UltraWinGrid.UltraGrid targetGrid, out List<ColumnInfo> settingList)
        {
            settingList = new List<ColumnInfo>();
            foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn in targetGrid.DisplayLayout.Bands[0].Columns)
            {
                settingList.Add(new ColumnInfo(ultraGridColumn.Key, ultraGridColumn.Header.VisiblePosition, ultraGridColumn.Hidden, ultraGridColumn.Width, ultraGridColumn.Header.Fixed));
            }
        }
        /// <summary>
        /// �O���b�h�J�������̓ǂݍ���
        /// </summary>
        /// <param name="targetGrid"></param>
        /// <param name="settingList"></param>
        public void LoadGridColumnsSetting(ref Infragistics.Win.UltraWinGrid.UltraGrid targetGrid, List<ColumnInfo> settingList)
        {
            if (settingList == null || settingList.Count == 0) return;

            targetGrid.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.None;

            // �J�����ݒ����\�����Ń\�[�g����
            settingList.Sort(new ColumnInfoComparer());

            // ��x�A�S�ẴJ������Fixed����������
            foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn in targetGrid.DisplayLayout.Bands[0].Columns)
            {
                ultraGridColumn.Header.Fixed = false;
            }

            foreach (ColumnInfo columnInfo in settingList)
            {
                try
                {
                    Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn = targetGrid.DisplayLayout.Bands[0].Columns[columnInfo.ColumnName];
                    ultraGridColumn.Header.VisiblePosition = columnInfo.VisiblePosition;
                    ultraGridColumn.Hidden = columnInfo.Hidden;
                    ultraGridColumn.Width = columnInfo.Width;
                }
                catch
                {
                }
            }

            // ����ъ�����A�܂Ƃ߂�Fixed��ݒ肷��B
            foreach (ColumnInfo columnInfo in settingList)
            {
                try
                {
                    Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn = targetGrid.DisplayLayout.Bands[0].Columns[columnInfo.ColumnName];
                    ultraGridColumn.Header.Fixed = columnInfo.ColumnFixed;
                }
                catch
                {
                }
            }
        }
        # endregion

        #region �v���C�x�[�g�֐�
        /// <summary>
        /// �O���b�h�̃Z�b�e�B���O�𕶎��񂩂���o��
        /// </summary>
        /// <param name="patternStr"></param>
        /// <param name="gridSetting"></param>
        /// <param name="isSlip"></param>
        private void getGridSettingPattern(string patternStr, out string[] gridSetting, bool isSlip)
        {
            int count = patternStr.Length / (ct_ColumnCountLength + 1);
            gridSetting = new string[count];

            for (int i = 0; i < count; i++)
            {
                gridSetting[i] = patternStr.Substring(i * (ct_ColumnCountLength + 1), (ct_ColumnCountLength + 1));
            }
        }
        #endregion

        #region ���[�U�[�ݒ�̕ۑ��E�ǂݍ���

        /// <summary>�f�[�^�ύX�㔭���C�x���g</summary>
        public event EventHandler DataChanged;

        /// <summary>
        /// �����}�X�^�p���[�U�[�ݒ�V���A���C�Y����
        /// </summary>
        /// <remarks>
        /// <br>Note       : �����}�X�^�p���[�U�[�ݒ�̃V���A���C�Y���s���܂��B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2013/12/04</br>
        /// </remarks>
        public void Serialize()
        {
            try
            {
                UserSettingController.SerializeUserSetting(_userSetting, Path.Combine(ConstantManagement_ClientDirectory.NSCurrentDirectory, Path.Combine(ConstantManagement_ClientDirectory.UISettings, XML_FILE_NAME)));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException.Message);
            }

            if (DataChanged != null)
            {
                // �f�[�^�ύX�㔭���C�x���g���s
                DataChanged(this, new EventArgs());
            }
        }

        /// <summary>
        /// �����}�X�^�p���[�U�[�ݒ�f�V���A���C�Y����
        /// </summary>
        /// <remarks>
        /// <br>Note       : �����}�X�^�p���[�U�[�ݒ�N���X���f�V���A���C�Y���܂��B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2013/12/04</br>
        /// </remarks>
        public void Deserialize()
        {
            if (UserSettingController.ExistUserSetting(Path.Combine(ConstantManagement_ClientDirectory.NSCurrentDirectory, Path.Combine(ConstantManagement_ClientDirectory.UISettings, XML_FILE_NAME))))
            {
                try
                {
                    this._userSetting = UserSettingController.DeserializeUserSetting<IntegrateMstUserConst>(Path.Combine(ConstantManagement_ClientDirectory.NSCurrentDirectory, Path.Combine(ConstantManagement_ClientDirectory.UISettings, XML_FILE_NAME)));

                }
                catch
                {
                    this._userSetting = new IntegrateMstUserConst();
                }
            }
        }

        /// <summary>
        /// �J�������̃��X�g�擾
        /// </summary>
        /// <param name="sourceStr"></param>
        /// <param name="isSlip"></param>
        /// <returns></returns>
        public List<String> GetColumnNameList(string sourceStr, bool isSlip)
        {
            List<String> columnList;

            columnList = new List<String>();
            string[] p;
            getGridSettingPattern(sourceStr, out p, true);

            for (int i = 0; i < p.Length; i++)
            {
                columnList.Add(p[i]);
            }

            return columnList;
        }

        #endregion // ���[�U�[�ݒ�̕ۑ��E�ǂݍ���
        // ADD END �����@2013/12/04 FOR Redmine#41447 ------<<<<<<
    }

    // ADD START �����@2013/12/04 FOR Redmine#41447 ------>>>>>>
    /// <summary>
    /// �����}�X�^�p���[�U�[�ݒ�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �����}�X�^�̃��[�U�[�ݒ�����Ǘ�����N���X</br>
    /// <br>Programmer : </br>
    /// <br>Date       : </br>
    /// <br></br>
    /// </remarks>
    [Serializable]
    public class IntegrateMstUserConst
    {

        # region �v���C�x�[�g�ϐ�

        // �o�̓t�@�C����
        private string _outputFileName;

        // �o�͌`��
        private int _outputStyle;

        // �o�̓p�^�[��
        private string[] _outputPattern;

        // �I�����ꂽ�p�^�[����
        private string _selectedPatternName;

        /// <summary>���ڋ�؂蕶��</summary>
        private const string STRING_DIVIDER = "'";

        // ���׃O���b�h�J�������X�g
        private List<ColumnInfo> _detailColumnsList;

        // �s�t�B���^
        private int _allowRowFiltering;
        // �����
        private int _allowColSwapping;
        // ��Œ�
        private int _fixedHeaderIndicator;

        # endregion // �v���C�x�[�g�ϐ�

        # region �R���X�g���N�^

        /// <summary>
        /// �����}�X�^���[�U�[�ݒ���N���X
        /// </summary>
        public IntegrateMstUserConst()
        {

        }

        # endregion // �R���X�g���N�^

        # region �v���p�e�B

        /// <summary>�o�̓t�@�C����</summary>
        public string OutputFileName
        {
            get { return this._outputFileName; }
            set { this._outputFileName = value; }
        }

        /// <summary>�o�͌^��</summary>
        public int OutputStyle
        {
            get { return this._outputStyle; }
            set { this._outputStyle = value; }
        }

        /// <summary>�o�̓p�^�[��</summary>
        public string[] OutputPattern
        {
            get { return this._outputPattern; }
            set { this._outputPattern = value; }
        }

        /// <summary>�I���p�^�[����</summary>
        public string SelectedPatternName
        {
            get { return this._selectedPatternName; }
            set { this._selectedPatternName = value; }
        }

        /// <summary>��؂蕶��</summary>
        public string DIVIDER
        {
            get { return STRING_DIVIDER; }
        }

        /// <summary>���׃O���b�h�J�������X�g</summary>
        public List<ColumnInfo> DetailColumnsList
        {
            get { return this._detailColumnsList; }
            set { this._detailColumnsList = value; }
        }
        /// <summary>�s�t�B���^</summary>
        public int AllowRowFiltering
        {
            get { return _allowRowFiltering; }
            set { _allowRowFiltering = value; }
        }
        /// <summary>�����</summary>
        public int AllowColSwapping
        {
            get { return _allowColSwapping; }
            set { _allowColSwapping = value; }
        }
        /// <summary>��Œ�</summary>
        public int FixedHeaderIndicator
        {
            get { return _fixedHeaderIndicator; }
            set { _fixedHeaderIndicator = value; }
        }

        # endregion

        /// <summary>
        /// �����}�X�^���[�U�[�ݒ���N���X��������
        /// </summary>
        /// <returns>�����}�X�^���[�U�[�ݒ���N���X</returns>
        public IntegrateMstUserConst Clone()
        {
            IntegrateMstUserConst constObj = new IntegrateMstUserConst();
            return constObj;
        }

        /// <summary>
        /// �t�@�C���g���q�ϊ�����
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="selectedValue"></param>
        /// <returns></returns>
        public static string ChangeFileExtension(string fileName, string selectedValue)
        {
            string newExt = string.Empty;
            switch (selectedValue)
            {
                case "0":
                    newExt = ".CSV";
                    break;
                case "1":
                    newExt = ".TXT";
                    break;
                case "2":
                    newExt = ".PRN";
                    break;
                case "3":
                default:
                    break;
            }
            if (newExt != string.Empty)
            {
                try
                {
                    fileName = Path.ChangeExtension(fileName, newExt);
                }
                catch
                {
                }
            }
            return fileName;
        }
    }

    # region [ColumnInfo]
    /// <summary>
    /// ColumnInfo
    /// </summary>
    [Serializable]
    public struct ColumnInfo
    {
        /// <summary>��</summary>
        private string _columnName;
        /// <summary>���я�</summary>
        private int _visiblePosition;
        /// <summary>��\���t���O</summary>
        private bool _hidden;
        /// <summary>��</summary>
        private int _width;
        /// <summary>�Œ�t���O</summary>
        private bool _columnFixed;
        /// <summary>
        /// ��
        /// </summary>
        public string ColumnName
        {
            get { return _columnName; }
            set { _columnName = value; }
        }
        /// <summary>
        /// ���я�
        /// </summary>
        public int VisiblePosition
        {
            get { return _visiblePosition; }
            set { _visiblePosition = value; }
        }
        /// <summary>
        /// ��\���t���O
        /// </summary>
        public bool Hidden
        {
            get { return _hidden; }
            set { _hidden = value; }
        }
        /// <summary>
        /// ��
        /// </summary>
        public int Width
        {
            get { return _width; }
            set { _width = value; }
        }
        /// <summary>
        /// �Œ�t���O
        /// </summary>
        public bool ColumnFixed
        {
            get { return _columnFixed; }
            set { _columnFixed = value; }
        }
        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        /// <param name="columnName">��</param>
        /// <param name="visiblePosition">���я�</param>
        /// <param name="hidden">��\���t���O</param>
        /// <param name="width">��</param>
        /// <param name="columnFixed">�Œ�t���O</param>
        public ColumnInfo(string columnName, int visiblePosition, bool hidden, int width, bool columnFixed)
        {
            _columnName = columnName;
            _visiblePosition = visiblePosition;
            _hidden = hidden;
            _width = width;
            _columnFixed = columnFixed;
        }
    }

    /// <summary>
    /// ColumnInfo��r�N���X�i�\�[�g�p�j
    /// </summary>
    public class ColumnInfoComparer : IComparer<ColumnInfo>
    {
        /// <summary>
        /// ColumnInfo��r����
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public int Compare(ColumnInfo x, ColumnInfo y)
        {
            // ��\�����Ŕ�r
            int result = x.VisiblePosition.CompareTo(y.VisiblePosition);
            // ��\��������v����ꍇ�͗񖼂Ŕ�r(�ʏ�͔������Ȃ�)
            if (result == 0)
            {
                result = x.ColumnName.CompareTo(y.ColumnName);
            }
            return result;
        }
    }
    # endregion
    // ADD END �����@2013/12/04 FOR Redmine#41447 ------<<<<<<
}
