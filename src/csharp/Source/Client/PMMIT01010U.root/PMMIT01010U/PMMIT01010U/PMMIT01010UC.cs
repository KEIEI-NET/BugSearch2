using System;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Application.Controller;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// �������� ���񏉊��ݒ�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ����̏����ݒ���s���N���X�ł��B</br>
    /// <br>Programmer : 21024 ���X�� ��</br>
    /// <br>Date       : 2008.07.10</br>
    /// <br></br>
    /// <br>UpDate</br>
    /// <br>2009.06.18 21024 ���X�� �� MANTIS[0013553] ���D�Δ�\��(�݌�)�̏����l�ŁA�D�ǂ̌��݌ɐ����\�������悤�ɏC��</br>
    /// </remarks>
    internal class EstimateInputColInfoInitialSetting
    {
        // ===================================================================================== //
        // �R���X�g���N�^
        // ===================================================================================== //
        #region ��Constructor
        /// <summary>
        /// �R���X�g���N�^�iSingleton�f�U�C���p�^�[�����̗p���Ă���ׁAprivate�j
        /// </summary>
        private EstimateInputColInfoInitialSetting()
        {
            this._estimateInputConstructionAcs = EstimateInputConstructionAcs.GetInstance();
            this._estimateInputDataSet = new EstimateInputDataSet();
            this._estimateDetailDataTable = this._estimateInputDataSet.EstimateDetail;

            this.CreateDefaultDetailPattern();
            this._estimateInputConstructionAcs.EstimateDetailPatternInfoDetaultList = this._estimateDetailPatternInfoList;
            this._estimateInputConstructionAcs.ColDisplayBasicInfoList = this._colDisplayInfoList;
            this._estimateInputConstructionAcs.ColDisplayAddInfoDictionary = this._colDisplayAddInfoDictionary;
        }

        /// <summary>
        /// �C���X�^���X�擾����
        /// </summary>
        /// <returns>�������� ���񏉊��ݒ�C���X�^���X</returns>
        public static EstimateInputColInfoInitialSetting GetInstance()
        {
            if (_estimateInputColInfoInitialSetting == null)
            {
                _estimateInputColInfoInitialSetting = new EstimateInputColInfoInitialSetting();
            }

            return _estimateInputColInfoInitialSetting;
        }

        #endregion


        // ===================================================================================== //
        // �v���C�x�[�g�ϐ�
        // ===================================================================================== //
        #region ��Private Member
        private static EstimateInputColInfoInitialSetting _estimateInputColInfoInitialSetting;

        private EstimateInputDataSet _estimateInputDataSet;
        private EstimateInputDataSet.EstimateDetailDataTable _estimateDetailDataTable;
        private EstimateInputConstructionAcs _estimateInputConstructionAcs;
        private List<ColDisplayBasicInfo> _colDisplayInfoList;
        private Dictionary<EstmDtlPtnInfo.SearchType, List<ColDisplayAddInfo>> _colDisplayAddInfoDictionary;
        private List<EstmDtlPtnInfo> _estimateDetailPatternInfoList;
        private Dictionary<string, ColDisplayBasicInfo> _colDisplayInfoBasicInfoDictionary;
        #endregion

        // ===================================================================================== //
        // �񋓑�
        // ===================================================================================== //
        #region ��Enums

        #endregion

        // ===================================================================================== //
        // �p�u���b�N���\�b�h
        // ===================================================================================== //
        #region ��Public Methods

        /// <summary>
        /// �J�����̑����擾
        /// </summary>
        /// <param name="key">�L�[</param>
        /// <returns>����</returns>
        public ColDisplayBasicInfo.DataAttribute GetAttr(string key)
        {
            try
            {
                return this._colDisplayInfoBasicInfoDictionary[key].Attr;
            }
            catch (Exception)
            {
                return ColDisplayBasicInfo.DataAttribute.None;
            }
        }

        #endregion

        // ===================================================================================== //
        // �v���C�x�[�g���\�b�h
        // ===================================================================================== //
        #region ��Private Methods

        private void CreateDefaultDetailPattern()
        {
            int visiblePosition = 1;

            this._colDisplayInfoList = new List<ColDisplayBasicInfo>();
            this._colDisplayAddInfoDictionary = new Dictionary<EstmDtlPtnInfo.SearchType, List<ColDisplayAddInfo>>();

            // �\�����鍀�ڂ̃��X�g(�\�����ڂ�ǉ�����ꍇ�͂����ɒǉ�)
            this._colDisplayInfoList = new List<ColDisplayBasicInfo>();
            //-----<< ������� >>-----//
            this._colDisplayInfoList.Add(new ColDisplayBasicInfo(this._estimateDetailDataTable.BLGoodsCodeColumn.ColumnName, this._estimateDetailDataTable.BLGoodsCodeColumn.Caption, false, ColDisplayBasicInfo.DataAttribute.PureParts));                                 // BL�R�[�h
            this._colDisplayInfoList.Add(new ColDisplayBasicInfo(this._estimateDetailDataTable.GoodsNameColumn.ColumnName, this._estimateDetailDataTable.GoodsNameColumn.Caption, false, ColDisplayBasicInfo.DataAttribute.PureParts));                                     // �i��
            this._colDisplayInfoList.Add(new ColDisplayBasicInfo(this._estimateDetailDataTable.GoodsNoColumn.ColumnName, this._estimateDetailDataTable.GoodsNoColumn.Caption, false, ColDisplayBasicInfo.DataAttribute.PureParts));                                         // �i��
            this._colDisplayInfoList.Add(new ColDisplayBasicInfo(this._estimateDetailDataTable.ShipmentCntColumn.ColumnName, this._estimateDetailDataTable.ShipmentCntColumn.Caption, false, ColDisplayBasicInfo.DataAttribute.PureParts));                                 // QTY
            this._colDisplayInfoList.Add(new ColDisplayBasicInfo(this._estimateDetailDataTable.ListPriceDisplayColumn.ColumnName, this._estimateDetailDataTable.ListPriceDisplayColumn.Caption, false, ColDisplayBasicInfo.DataAttribute.PureParts));                       // �艿
            this._colDisplayInfoList.Add(new ColDisplayBasicInfo(this._estimateDetailDataTable.OpenPriceDivDisplayColumn.ColumnName, this._estimateDetailDataTable.OpenPriceDivDisplayColumn.Caption, false, ColDisplayBasicInfo.DataAttribute.PureParts));                 // OP
            this._colDisplayInfoList.Add(new ColDisplayBasicInfo(this._estimateDetailDataTable.GoodsMakerCdColumn.ColumnName, this._estimateDetailDataTable.GoodsMakerCdColumn.Caption, false, ColDisplayBasicInfo.DataAttribute.PureParts));                               // ���[�J�[�R�[�h
            this._colDisplayInfoList.Add(new ColDisplayBasicInfo(this._estimateDetailDataTable.MakerNameColumn.ColumnName, this._estimateDetailDataTable.MakerNameColumn.Caption, false, ColDisplayBasicInfo.DataAttribute.PureParts));                                     // ���[�J�[����
            this._colDisplayInfoList.Add(new ColDisplayBasicInfo(this._estimateDetailDataTable.WarehouseCodeColumn.ColumnName, this._estimateDetailDataTable.WarehouseCodeColumn.Caption, false, ColDisplayBasicInfo.DataAttribute.PureParts));                             // �q��
            this._colDisplayInfoList.Add(new ColDisplayBasicInfo(this._estimateDetailDataTable.WarehouseShelfNoColumn.ColumnName, this._estimateDetailDataTable.WarehouseShelfNoColumn.Caption, true, ColDisplayBasicInfo.DataAttribute.PureParts));                        // �I��
            this._colDisplayInfoList.Add(new ColDisplayBasicInfo(this._estimateDetailDataTable.ShipmentPosCntColumn.ColumnName, this._estimateDetailDataTable.ShipmentPosCntColumn.Caption, true, ColDisplayBasicInfo.DataAttribute.PureParts));                            // ���݌ɐ�
            this._colDisplayInfoList.Add(new ColDisplayBasicInfo(this._estimateDetailDataTable.ExistSetInfoDisplayColumn.ColumnName, this._estimateDetailDataTable.ExistSetInfoDisplayColumn.Caption, true, ColDisplayBasicInfo.DataAttribute.PureParts));                  // �Z�b�g
            this._colDisplayInfoList.Add(new ColDisplayBasicInfo(this._estimateDetailDataTable.SupplierCdColumn.ColumnName, this._estimateDetailDataTable.SupplierCdColumn.Caption, false, ColDisplayBasicInfo.DataAttribute.PureParts));                                   // �d����
            this._colDisplayInfoList.Add(new ColDisplayBasicInfo(this._estimateDetailDataTable.PrintSelectColumn.ColumnName, this._estimateDetailDataTable.PrintSelectColumn.Caption, false, ColDisplayBasicInfo.DataAttribute.PureParts));                                 // ���
            this._colDisplayInfoList.Add(new ColDisplayBasicInfo(this._estimateDetailDataTable.OrderSelectColumn.ColumnName, this._estimateDetailDataTable.OrderSelectColumn.Caption, true, ColDisplayBasicInfo.DataAttribute.PureParts));                                  // ����
            //-----<< �D�Ǐ�� >>-----//
            this._colDisplayInfoList.Add(new ColDisplayBasicInfo(this._estimateDetailDataTable.BLGoodsCode_PrimeColumn.ColumnName, this._estimateDetailDataTable.BLGoodsCode_PrimeColumn.Caption, false, ColDisplayBasicInfo.DataAttribute.PrimeParts));                    // BL�R�[�h�i�D�ǁj
            this._colDisplayInfoList.Add(new ColDisplayBasicInfo(this._estimateDetailDataTable.GoodsName_PrimeColumn.ColumnName, this._estimateDetailDataTable.GoodsName_PrimeColumn.Caption, false, ColDisplayBasicInfo.DataAttribute.PrimeParts));                        // �i���i�D�ǁj
            this._colDisplayInfoList.Add(new ColDisplayBasicInfo(this._estimateDetailDataTable.GoodsNo_PrimeColumn.ColumnName, this._estimateDetailDataTable.GoodsNo_PrimeColumn.Caption, false, ColDisplayBasicInfo.DataAttribute.PrimeParts));                            // �i�ԁi�D�ǁj
            this._colDisplayInfoList.Add(new ColDisplayBasicInfo(this._estimateDetailDataTable.ShipmentCnt_PrimeColumn.ColumnName, this._estimateDetailDataTable.ShipmentCnt_PrimeColumn.Caption, false, ColDisplayBasicInfo.DataAttribute.PrimeParts));                    // QTY�i�D�ǁj
            this._colDisplayInfoList.Add(new ColDisplayBasicInfo(this._estimateDetailDataTable.ListPriceDisplay_PrimeColumn.ColumnName, this._estimateDetailDataTable.ListPriceDisplay_PrimeColumn.Caption, false, ColDisplayBasicInfo.DataAttribute.PrimeParts));          // �艿�i�D�ǁj
            this._colDisplayInfoList.Add(new ColDisplayBasicInfo(this._estimateDetailDataTable.OpenPriceDivDisplay_PrimeColumn.ColumnName, this._estimateDetailDataTable.OpenPriceDivDisplay_PrimeColumn.Caption, false, ColDisplayBasicInfo.DataAttribute.PrimeParts));    // OP�i�D�ǁj
            this._colDisplayInfoList.Add(new ColDisplayBasicInfo(this._estimateDetailDataTable.GoodsMakerCd_PrimeColumn.ColumnName, this._estimateDetailDataTable.GoodsMakerCd_PrimeColumn.Caption, false, ColDisplayBasicInfo.DataAttribute.PrimeParts));                  // ���[�J�[�R�[�h�i�D�ǁj
            this._colDisplayInfoList.Add(new ColDisplayBasicInfo(this._estimateDetailDataTable.MakerName_PrimeColumn.ColumnName, this._estimateDetailDataTable.MakerName_PrimeColumn.Caption, false, ColDisplayBasicInfo.DataAttribute.PrimeParts));                        // ���[�J�[���́i�D�ǁj
            this._colDisplayInfoList.Add(new ColDisplayBasicInfo(this._estimateDetailDataTable.WarehouseCode_PrimeColumn.ColumnName, this._estimateDetailDataTable.WarehouseCode_PrimeColumn.Caption, false, ColDisplayBasicInfo.DataAttribute.PrimeParts));                // �q�Ɂi�D�ǁj
            this._colDisplayInfoList.Add(new ColDisplayBasicInfo(this._estimateDetailDataTable.WarehouseShelfNo_PrimeColumn.ColumnName, this._estimateDetailDataTable.WarehouseShelfNo_PrimeColumn.Caption, true, ColDisplayBasicInfo.DataAttribute.PrimeParts));           // �I�ԁi�D�ǁj
            this._colDisplayInfoList.Add(new ColDisplayBasicInfo(this._estimateDetailDataTable.ShipmentPosCnt_PrimeColumn.ColumnName, this._estimateDetailDataTable.ShipmentPosCnt_PrimeColumn.Caption, true, ColDisplayBasicInfo.DataAttribute.PrimeParts));               // ���݌ɐ��i�D�ǁj
            this._colDisplayInfoList.Add(new ColDisplayBasicInfo(this._estimateDetailDataTable.ExistSetInfoDisplay_PrimeColumn.ColumnName, this._estimateDetailDataTable.ExistSetInfoDisplay_PrimeColumn.Caption, true, ColDisplayBasicInfo.DataAttribute.PrimeParts));     // �Z�b�g�i�D�ǁj
            this._colDisplayInfoList.Add(new ColDisplayBasicInfo(this._estimateDetailDataTable.SupplierCd_PrimeColumn.ColumnName, this._estimateDetailDataTable.SupplierCd_PrimeColumn.Caption, false, ColDisplayBasicInfo.DataAttribute.PrimeParts));                      // �d����i�D�ǁj
            this._colDisplayInfoList.Add(new ColDisplayBasicInfo(this._estimateDetailDataTable.PrintSelect_PrimeColumn.ColumnName, this._estimateDetailDataTable.PrintSelect_PrimeColumn.Caption, false, ColDisplayBasicInfo.DataAttribute.PrimeParts));                    // ����i�D�ǁj
            this._colDisplayInfoList.Add(new ColDisplayBasicInfo(this._estimateDetailDataTable.OrderSelect_PrimeColumn.ColumnName, this._estimateDetailDataTable.OrderSelect_PrimeColumn.Caption, true, ColDisplayBasicInfo.DataAttribute.PrimeParts));                     // �����i�D�ǁj
            //-----<< ���̑� >>-----//
            this._colDisplayInfoList.Add(new ColDisplayBasicInfo(this._estimateDetailDataTable.JoinSourPartsNoWithHColumn.ColumnName, this._estimateDetailDataTable.JoinSourPartsNoWithHColumn.Caption, true, ColDisplayBasicInfo.DataAttribute.None));                     // �������i��
            this._colDisplayInfoList.Add(new ColDisplayBasicInfo(this._estimateDetailDataTable.CtlgPartsNoColumn.ColumnName, this._estimateDetailDataTable.CtlgPartsNoColumn.Caption, true, ColDisplayBasicInfo.DataAttribute.None));                                       // �J�^���O�i��
            this._colDisplayInfoList.Add(new ColDisplayBasicInfo(this._estimateDetailDataTable.StandardNameColumn.ColumnName, this._estimateDetailDataTable.StandardNameColumn.Caption, true, ColDisplayBasicInfo.DataAttribute.None));                                     // �K�i
            this._colDisplayInfoList.Add(new ColDisplayBasicInfo(this._estimateDetailDataTable.SpecialNoteColumn.ColumnName, this._estimateDetailDataTable.SpecialNoteColumn.Caption, true, ColDisplayBasicInfo.DataAttribute.None));                                       // ���L����


            this._colDisplayInfoBasicInfoDictionary = new Dictionary<string, ColDisplayBasicInfo>();
            foreach (ColDisplayBasicInfo colDisplayBasicInfo in this._colDisplayInfoList)
            {
                _colDisplayInfoBasicInfoDictionary.Add(colDisplayBasicInfo.Key, colDisplayBasicInfo);
            }

            // �������i�u�����v�̍��ڐ��䃊�X�g(���̃��X�g�Ɋ܂܂�Ȃ��ꍇ�́A�\���A�Œ�A�ړ��̓`�F�b�N����)
            List<ColDisplayAddInfo> colDisplayInfoList_Pure = new List<ColDisplayAddInfo>();
            visiblePosition = 1;
            colDisplayInfoList_Pure.Add(new ColDisplayAddInfo(this._estimateDetailDataTable.BLGoodsCodeColumn.ColumnName, visiblePosition++, true, true, true));                    // BL�R�[�h
            colDisplayInfoList_Pure.Add(new ColDisplayAddInfo(this._estimateDetailDataTable.GoodsNameColumn.ColumnName, visiblePosition++, true, true, true));                      // �i��
            colDisplayInfoList_Pure.Add(new ColDisplayAddInfo(this._estimateDetailDataTable.GoodsNoColumn.ColumnName, visiblePosition++, true, true, true));                        // �i��
            colDisplayInfoList_Pure.Add(new ColDisplayAddInfo(this._estimateDetailDataTable.ShipmentCntColumn.ColumnName, visiblePosition++, false, true, true));                   // QTY
            colDisplayInfoList_Pure.Add(new ColDisplayAddInfo(this._estimateDetailDataTable.ListPriceDisplayColumn.ColumnName, visiblePosition++, false, true, true));              // �W�����i
            colDisplayInfoList_Pure.Add(new ColDisplayAddInfo(this._estimateDetailDataTable.OpenPriceDivDisplayColumn.ColumnName, visiblePosition++, false, true, false));          // OP
            colDisplayInfoList_Pure.Add(new ColDisplayAddInfo(this._estimateDetailDataTable.GoodsMakerCdColumn.ColumnName, visiblePosition++, false, true, true));                  // ���[�J�[�R�[�h
            colDisplayInfoList_Pure.Add(new ColDisplayAddInfo(this._estimateDetailDataTable.MakerNameColumn.ColumnName, visiblePosition++, false, true, false));                    // ���[�J�[����
            colDisplayInfoList_Pure.Add(new ColDisplayAddInfo(this._estimateDetailDataTable.WarehouseCodeColumn.ColumnName, visiblePosition++, false, true, true));                 // �q�ɃR�[�h
            colDisplayInfoList_Pure.Add(new ColDisplayAddInfo(this._estimateDetailDataTable.WarehouseShelfNoColumn.ColumnName, visiblePosition++, false, true, false));             // �I��
            colDisplayInfoList_Pure.Add(new ColDisplayAddInfo(this._estimateDetailDataTable.ShipmentPosCntColumn.ColumnName, visiblePosition++, false, true, false));               // ���݌ɐ�
            colDisplayInfoList_Pure.Add(new ColDisplayAddInfo(this._estimateDetailDataTable.SupplierCdColumn.ColumnName, visiblePosition++, false, true, true));                    // �d����R�[�h
            colDisplayInfoList_Pure.Add(new ColDisplayAddInfo(this._estimateDetailDataTable.PrintSelectColumn.ColumnName, visiblePosition++, false, true, true));                   // ���
            colDisplayInfoList_Pure.Add(new ColDisplayAddInfo(this._estimateDetailDataTable.ExistSetInfoDisplayColumn.ColumnName, visiblePosition++, false, true, false));          // �Z�b�g
            colDisplayInfoList_Pure.Add(new ColDisplayAddInfo(this._estimateDetailDataTable.OrderSelectColumn.ColumnName, visiblePosition++, false, true, false));                  // ����


            // �������i�u�D�ǁv�̍��ڐ��䃊�X�g(���̃��X�g�Ɋ܂܂�Ȃ��ꍇ�́A�\���A�Œ�A�ړ��̓`�F�b�N����)
            List<ColDisplayAddInfo> colDisplayInfoList_Prime = new List<ColDisplayAddInfo>();
            visiblePosition = 1;
            colDisplayInfoList_Prime.Add(new ColDisplayAddInfo(this._estimateDetailDataTable.BLGoodsCode_PrimeColumn.ColumnName, visiblePosition++, true, true, true));             // BL�R�[�h�i�D�ǁj
            colDisplayInfoList_Prime.Add(new ColDisplayAddInfo(this._estimateDetailDataTable.GoodsName_PrimeColumn.ColumnName, visiblePosition++, true, true, true));               // �i���i�D�ǁj
            colDisplayInfoList_Prime.Add(new ColDisplayAddInfo(this._estimateDetailDataTable.GoodsNo_PrimeColumn.ColumnName, visiblePosition++, true, true, true));                 // �i�ԁi�D�ǁj
            colDisplayInfoList_Prime.Add(new ColDisplayAddInfo(this._estimateDetailDataTable.ShipmentCnt_PrimeColumn.ColumnName, visiblePosition++, false, true, true));            // QTY�i�D�ǁj
            colDisplayInfoList_Prime.Add(new ColDisplayAddInfo(this._estimateDetailDataTable.ListPriceDisplay_PrimeColumn.ColumnName, visiblePosition++, false, true, true));       // �W�����i�i�D�ǁj
            colDisplayInfoList_Prime.Add(new ColDisplayAddInfo(this._estimateDetailDataTable.OpenPriceDivDisplay_PrimeColumn.ColumnName, visiblePosition++, false, true, false));   // OP�i�D�ǁj
            colDisplayInfoList_Prime.Add(new ColDisplayAddInfo(this._estimateDetailDataTable.GoodsMakerCd_PrimeColumn.ColumnName, visiblePosition++, false, true, true));           // ���[�J�[�R�[�h�i�D�ǁj
            colDisplayInfoList_Prime.Add(new ColDisplayAddInfo(this._estimateDetailDataTable.MakerName_PrimeColumn.ColumnName, visiblePosition++, false, true, false));             // ���[�J�[���́i�D�ǁj
            colDisplayInfoList_Prime.Add(new ColDisplayAddInfo(this._estimateDetailDataTable.WarehouseCode_PrimeColumn.ColumnName, visiblePosition++, false, true, true));          // �q�ɃR�[�h�i�D�ǁj
            colDisplayInfoList_Prime.Add(new ColDisplayAddInfo(this._estimateDetailDataTable.WarehouseShelfNo_PrimeColumn.ColumnName, visiblePosition++, false, true, false));      // �I�ԁi�D�ǁj
            colDisplayInfoList_Prime.Add(new ColDisplayAddInfo(this._estimateDetailDataTable.ShipmentPosCnt_PrimeColumn.ColumnName, visiblePosition++, false, true, false));        // ���݌ɐ��i�D�ǁj
            colDisplayInfoList_Prime.Add(new ColDisplayAddInfo(this._estimateDetailDataTable.SupplierCd_PrimeColumn.ColumnName, visiblePosition++, false, true, true));             // �d����R�[�h�i�D�ǁj
            colDisplayInfoList_Prime.Add(new ColDisplayAddInfo(this._estimateDetailDataTable.PrintSelect_PrimeColumn.ColumnName, visiblePosition++, false, true, true));            // ����i�D�ǁj
            colDisplayInfoList_Prime.Add(new ColDisplayAddInfo(this._estimateDetailDataTable.ExistSetInfoDisplay_PrimeColumn.ColumnName, visiblePosition++, false, true, false));   // �Z�b�g�i�D�ǁj
            colDisplayInfoList_Prime.Add(new ColDisplayAddInfo(this._estimateDetailDataTable.OrderSelect_PrimeColumn.ColumnName, visiblePosition++, false, true, false));           // �����i�D�ǁj

            // �������i�u����(�\���̂�)�v�̍��ڐ��䃊�X�g
            List<ColDisplayAddInfo> colDisplayInfoList_None = new List<ColDisplayAddInfo>();

            this._colDisplayAddInfoDictionary.Add(EstmDtlPtnInfo.SearchType.Pure, colDisplayInfoList_Pure);
            this._colDisplayAddInfoDictionary.Add(EstmDtlPtnInfo.SearchType.Prime, colDisplayInfoList_Prime);
            this._colDisplayAddInfoDictionary.Add(EstmDtlPtnInfo.SearchType.None, colDisplayInfoList_None);

            int patternOrder = 1;

            // ���׃p�^�[���̏����l
            //-----<< ���� >>-----//
            List<EstmDtlColInfo> estimateDetailColInfo_pure = new List<EstmDtlColInfo>();
            visiblePosition = 1;
            estimateDetailColInfo_pure.Add(new EstmDtlColInfo(this._estimateDetailDataTable.BLGoodsCodeColumn.ColumnName, visiblePosition++, true, true, true));                    // BL�R�[�h
            estimateDetailColInfo_pure.Add(new EstmDtlColInfo(this._estimateDetailDataTable.GoodsNameColumn.ColumnName, visiblePosition++, true, true, true));                      // �i��
            estimateDetailColInfo_pure.Add(new EstmDtlColInfo(this._estimateDetailDataTable.GoodsNoColumn.ColumnName, visiblePosition++, true, true, true));                        // �i��
            estimateDetailColInfo_pure.Add(new EstmDtlColInfo(this._estimateDetailDataTable.ShipmentCntColumn.ColumnName, visiblePosition++, true, false, true));                   // QTY
            estimateDetailColInfo_pure.Add(new EstmDtlColInfo(this._estimateDetailDataTable.ListPriceDisplayColumn.ColumnName, visiblePosition++, true, false, true));              // �W�����i
            estimateDetailColInfo_pure.Add(new EstmDtlColInfo(this._estimateDetailDataTable.OpenPriceDivDisplayColumn.ColumnName, visiblePosition++, true, false, false));          // OP
            estimateDetailColInfo_pure.Add(new EstmDtlColInfo(this._estimateDetailDataTable.GoodsMakerCdColumn.ColumnName, visiblePosition++, true, false, true));                  // ���[�J�[�R�[�h
            estimateDetailColInfo_pure.Add(new EstmDtlColInfo(this._estimateDetailDataTable.MakerNameColumn.ColumnName, visiblePosition++, true, false, false));                    // ���[�J�[����
            estimateDetailColInfo_pure.Add(new EstmDtlColInfo(this._estimateDetailDataTable.WarehouseCodeColumn.ColumnName, visiblePosition++, true, false, true));                 // �q�ɃR�[�h
            estimateDetailColInfo_pure.Add(new EstmDtlColInfo(this._estimateDetailDataTable.WarehouseShelfNoColumn.ColumnName, visiblePosition++, true, false, false));             // �I��
            estimateDetailColInfo_pure.Add(new EstmDtlColInfo(this._estimateDetailDataTable.ShipmentPosCntColumn.ColumnName, visiblePosition++, true, false, false));               // ���݌ɐ�
            estimateDetailColInfo_pure.Add(new EstmDtlColInfo(this._estimateDetailDataTable.ExistSetInfoDisplayColumn.ColumnName, visiblePosition++, true, false, false));          // �Z�b�g
            estimateDetailColInfo_pure.Add(new EstmDtlColInfo(this._estimateDetailDataTable.SupplierCdColumn.ColumnName, visiblePosition++, true, false, true));                    // �d����R�[�h
            estimateDetailColInfo_pure.Add(new EstmDtlColInfo(this._estimateDetailDataTable.PrintSelectColumn.ColumnName, visiblePosition++, true, false, true));                   // ���
            estimateDetailColInfo_pure.Add(new EstmDtlColInfo(this._estimateDetailDataTable.OrderSelectColumn.ColumnName, visiblePosition++, true, false, false));                  // ����

            EstmDtlPtnInfo estimateDetailPatternInfo_Pure = new EstmDtlPtnInfo(Guid.NewGuid(), "�����\��", patternOrder++, EstmDtlPtnInfo.SearchType.Pure, estimateDetailColInfo_pure);

            //-----<< �D�� >>-----//
            List<EstmDtlColInfo> estimateDetailColInfo_prime = new List<EstmDtlColInfo>();
            visiblePosition = 1;
            estimateDetailColInfo_prime.Add(new EstmDtlColInfo(this._estimateDetailDataTable.BLGoodsCode_PrimeColumn.ColumnName, visiblePosition++, true, true, true));             // BL�R�[�h�i�D�ǁj
            estimateDetailColInfo_prime.Add(new EstmDtlColInfo(this._estimateDetailDataTable.GoodsName_PrimeColumn.ColumnName, visiblePosition++, true, true, true));               // �i���i�D�ǁj
            estimateDetailColInfo_prime.Add(new EstmDtlColInfo(this._estimateDetailDataTable.GoodsNo_PrimeColumn.ColumnName, visiblePosition++, true, true, true));                 // �i�ԁi�D�ǁj
            estimateDetailColInfo_prime.Add(new EstmDtlColInfo(this._estimateDetailDataTable.ShipmentCnt_PrimeColumn.ColumnName, visiblePosition++, true, false, true));            // QTY�i�D�ǁj
            estimateDetailColInfo_prime.Add(new EstmDtlColInfo(this._estimateDetailDataTable.ListPriceDisplay_PrimeColumn.ColumnName, visiblePosition++, true, false, true));       // �W�����i�i�D�ǁj
            estimateDetailColInfo_prime.Add(new EstmDtlColInfo(this._estimateDetailDataTable.OpenPriceDivDisplay_PrimeColumn.ColumnName, visiblePosition++, true, false, false));   // OP�i�D�ǁj
            estimateDetailColInfo_prime.Add(new EstmDtlColInfo(this._estimateDetailDataTable.GoodsMakerCd_PrimeColumn.ColumnName, visiblePosition++, true, false, true));           // ���[�J�[�R�[�h�i�D�ǁj
            estimateDetailColInfo_prime.Add(new EstmDtlColInfo(this._estimateDetailDataTable.MakerName_PrimeColumn.ColumnName, visiblePosition++, true, false, false));             // ���[�J�[���́i�D�ǁj
            estimateDetailColInfo_prime.Add(new EstmDtlColInfo(this._estimateDetailDataTable.WarehouseCode_PrimeColumn.ColumnName, visiblePosition++, true, false, true));          // �q�ɃR�[�h�i�D�ǁj
            estimateDetailColInfo_prime.Add(new EstmDtlColInfo(this._estimateDetailDataTable.WarehouseShelfNo_PrimeColumn.ColumnName, visiblePosition++, true, false, false));      // �I�ԁi�D�ǁj
            estimateDetailColInfo_prime.Add(new EstmDtlColInfo(this._estimateDetailDataTable.ShipmentPosCnt_PrimeColumn.ColumnName, visiblePosition++, true, false, false));        // ���݌ɐ��i�D�ǁj
            estimateDetailColInfo_prime.Add(new EstmDtlColInfo(this._estimateDetailDataTable.ExistSetInfoDisplay_PrimeColumn.ColumnName, visiblePosition++, true, false, false));   // �Z�b�g�i�D�ǁj
            estimateDetailColInfo_prime.Add(new EstmDtlColInfo(this._estimateDetailDataTable.SupplierCd_PrimeColumn.ColumnName, visiblePosition++, true, false, true));             // �d����R�[�h�i�D�ǁj
            estimateDetailColInfo_prime.Add(new EstmDtlColInfo(this._estimateDetailDataTable.PrintSelect_PrimeColumn.ColumnName, visiblePosition++, true, false, true));            // ����i�D�ǁj
            estimateDetailColInfo_prime.Add(new EstmDtlColInfo(this._estimateDetailDataTable.OrderSelect_PrimeColumn.ColumnName, visiblePosition++, true, false, false));           // �����i�D�ǁj

            EstmDtlPtnInfo estimateDetailPatternInfo_Prime = new EstmDtlPtnInfo(Guid.NewGuid(), "�D�Ǖ\��", patternOrder++, EstmDtlPtnInfo.SearchType.Prime, estimateDetailColInfo_prime);

            //-----<< ���E�D�Δ�i�i�ԁj >>-----//
            List<EstmDtlColInfo> estimateDetailColInfo_CompareGoodsNo = new List<EstmDtlColInfo>();
            visiblePosition = 1;
            estimateDetailColInfo_CompareGoodsNo.Add(new EstmDtlColInfo(this._estimateDetailDataTable.BLGoodsCodeColumn.ColumnName, visiblePosition++, true, true, true));                  // BL�R�[�h
            estimateDetailColInfo_CompareGoodsNo.Add(new EstmDtlColInfo(this._estimateDetailDataTable.GoodsNameColumn.ColumnName, visiblePosition++, true, true, true));                    // �i��
            estimateDetailColInfo_CompareGoodsNo.Add(new EstmDtlColInfo(this._estimateDetailDataTable.GoodsNoColumn.ColumnName, visiblePosition++, true, true, true));                      // �i��
            estimateDetailColInfo_CompareGoodsNo.Add(new EstmDtlColInfo(this._estimateDetailDataTable.ShipmentCntColumn.ColumnName, visiblePosition++, true, false, true));                 // QTY
            estimateDetailColInfo_CompareGoodsNo.Add(new EstmDtlColInfo(this._estimateDetailDataTable.ListPriceDisplayColumn.ColumnName, visiblePosition++, true, false, true));            // �W�����i
            estimateDetailColInfo_CompareGoodsNo.Add(new EstmDtlColInfo(this._estimateDetailDataTable.OpenPriceDivDisplayColumn.ColumnName, visiblePosition++, true, false, false));        // OP
            estimateDetailColInfo_CompareGoodsNo.Add(new EstmDtlColInfo(this._estimateDetailDataTable.PrintSelectColumn.ColumnName, visiblePosition++, true, false, true));                 // ���
            estimateDetailColInfo_CompareGoodsNo.Add(new EstmDtlColInfo(this._estimateDetailDataTable.GoodsNo_PrimeColumn.ColumnName, visiblePosition++, true, false, true));               // �i�ԁi�D�ǁj
            estimateDetailColInfo_CompareGoodsNo.Add(new EstmDtlColInfo(this._estimateDetailDataTable.ShipmentCnt_PrimeColumn.ColumnName, visiblePosition++, true, false, true));           // QTY�i�D�ǁj
            estimateDetailColInfo_CompareGoodsNo.Add(new EstmDtlColInfo(this._estimateDetailDataTable.ListPriceDisplay_PrimeColumn.ColumnName, visiblePosition++, true, false, true));      // �W�����i�i�D�ǁj
            estimateDetailColInfo_CompareGoodsNo.Add(new EstmDtlColInfo(this._estimateDetailDataTable.OpenPriceDivDisplay_PrimeColumn.ColumnName, visiblePosition++, true, false, false));  // OP�i�D�ǁj
            estimateDetailColInfo_CompareGoodsNo.Add(new EstmDtlColInfo(this._estimateDetailDataTable.PrintSelect_PrimeColumn.ColumnName, visiblePosition++, true, false, true));           // ����i�D�ǁj

            EstmDtlPtnInfo estimateDetailPatternInfo_CompareGoodsNo = new EstmDtlPtnInfo(Guid.NewGuid(), "���E�D�Δ�i�i�ԁj", patternOrder++, EstmDtlPtnInfo.SearchType.Pure, estimateDetailColInfo_CompareGoodsNo);

            //-----<< ���E�D�Δ�i�݌Ɂj >>-----//
            List<EstmDtlColInfo> estimateDetailColInfo_CompareStock = new List<EstmDtlColInfo>();
            visiblePosition = 1;
            estimateDetailColInfo_CompareStock.Add(new EstmDtlColInfo(this._estimateDetailDataTable.BLGoodsCodeColumn.ColumnName, visiblePosition++, true, true, true));                    // BL�R�[�h
            estimateDetailColInfo_CompareStock.Add(new EstmDtlColInfo(this._estimateDetailDataTable.GoodsNameColumn.ColumnName, visiblePosition++, true, true, true));                      // �i��
            estimateDetailColInfo_CompareStock.Add(new EstmDtlColInfo(this._estimateDetailDataTable.GoodsNoColumn.ColumnName, visiblePosition++, true, true, true));                        // �i��
            estimateDetailColInfo_CompareStock.Add(new EstmDtlColInfo(this._estimateDetailDataTable.ShipmentPosCntColumn.ColumnName, visiblePosition++, true, false, false));               // ���݌ɐ�
            estimateDetailColInfo_CompareStock.Add(new EstmDtlColInfo(this._estimateDetailDataTable.WarehouseShelfNoColumn.ColumnName, visiblePosition++, true, false, false));             // �I��
            estimateDetailColInfo_CompareStock.Add(new EstmDtlColInfo(this._estimateDetailDataTable.PrintSelectColumn.ColumnName, visiblePosition++, true, false, true));                   // ���
            estimateDetailColInfo_CompareStock.Add(new EstmDtlColInfo(this._estimateDetailDataTable.GoodsNo_PrimeColumn.ColumnName, visiblePosition++, true, false, true));                 // �i�ԁi�D�ǁj
            // 2009.06.18 >>>
            //estimateDetailColInfo_CompareStock.Add(new EstmDtlColInfo(this._estimateDetailDataTable.ShipmentCnt_PrimeColumn.ColumnName, visiblePosition++, true, false, false));            // ���݌ɐ��i�D�ǁj
            estimateDetailColInfo_CompareStock.Add(new EstmDtlColInfo(this._estimateDetailDataTable.ShipmentPosCnt_PrimeColumn.ColumnName, visiblePosition++, true, false, false));            // ���݌ɐ��i�D�ǁj
            // 2009.06.18 <<<
            estimateDetailColInfo_CompareStock.Add(new EstmDtlColInfo(this._estimateDetailDataTable.WarehouseShelfNo_PrimeColumn.ColumnName, visiblePosition++, true, false, false));       // �I�ԁi�D�ǁj
            estimateDetailColInfo_CompareStock.Add(new EstmDtlColInfo(this._estimateDetailDataTable.PrintSelect_PrimeColumn.ColumnName, visiblePosition++, true, false, true));             // ����i�D�ǁj

            EstmDtlPtnInfo estimateDetailPatternInfo_CompareStock = new EstmDtlPtnInfo(Guid.NewGuid(), "���E�D�Δ�i�݌Ɂj", patternOrder++, EstmDtlPtnInfo.SearchType.Pure, estimateDetailColInfo_CompareStock);

            //-----<< ���E�D�Δ�i���[�J�[�j >>-----//
            List<EstmDtlColInfo> estimateDetailColInfo_CompareMaker = new List<EstmDtlColInfo>();
            visiblePosition = 1;
            estimateDetailColInfo_CompareMaker.Add(new EstmDtlColInfo(this._estimateDetailDataTable.BLGoodsCodeColumn.ColumnName, visiblePosition++, true, true, true));                    // BL�R�[�h
            estimateDetailColInfo_CompareMaker.Add(new EstmDtlColInfo(this._estimateDetailDataTable.GoodsNameColumn.ColumnName, visiblePosition++, true, true, true));                      // �i��
            estimateDetailColInfo_CompareMaker.Add(new EstmDtlColInfo(this._estimateDetailDataTable.GoodsNoColumn.ColumnName, visiblePosition++, true, true, true));                        // �i��
            estimateDetailColInfo_CompareMaker.Add(new EstmDtlColInfo(this._estimateDetailDataTable.ShipmentCntColumn.ColumnName, visiblePosition++, true, false, true));                   // QTY
            estimateDetailColInfo_CompareMaker.Add(new EstmDtlColInfo(this._estimateDetailDataTable.GoodsMakerCdColumn.ColumnName, visiblePosition++, true, false, true));                  // ���[�J�[�R�[�h
            estimateDetailColInfo_CompareMaker.Add(new EstmDtlColInfo(this._estimateDetailDataTable.MakerNameColumn.ColumnName, visiblePosition++, true, false, false));                    // ���[�J�[����
            estimateDetailColInfo_CompareMaker.Add(new EstmDtlColInfo(this._estimateDetailDataTable.PrintSelectColumn.ColumnName, visiblePosition++, true, false, true));                   // ���
            estimateDetailColInfo_CompareMaker.Add(new EstmDtlColInfo(this._estimateDetailDataTable.GoodsNo_PrimeColumn.ColumnName, visiblePosition++, true, false, true));                 // �i�ԁi�D�ǁj
            estimateDetailColInfo_CompareMaker.Add(new EstmDtlColInfo(this._estimateDetailDataTable.ShipmentCnt_PrimeColumn.ColumnName, visiblePosition++, true, false, true));             // QTY�i�D�ǁj
            estimateDetailColInfo_CompareMaker.Add(new EstmDtlColInfo(this._estimateDetailDataTable.GoodsMakerCd_PrimeColumn.ColumnName, visiblePosition++, true, false, true));            // ���[�J�[�R�[�h�i�D�ǁj
            estimateDetailColInfo_CompareMaker.Add(new EstmDtlColInfo(this._estimateDetailDataTable.MakerName_PrimeColumn.ColumnName, visiblePosition++, true, false, false));              // ���[�J�[���́i�D�ǁj
            estimateDetailColInfo_CompareMaker.Add(new EstmDtlColInfo(this._estimateDetailDataTable.PrintSelect_PrimeColumn.ColumnName, visiblePosition++, true, false, true));             // ���(�D��)

            EstmDtlPtnInfo estimateDetailPatternInfo_CompareMaker = new EstmDtlPtnInfo(Guid.NewGuid(), "���E�D�Δ�i���[�J�[�j", patternOrder++, EstmDtlPtnInfo.SearchType.Pure, estimateDetailColInfo_CompareMaker);


            //-----<< ������� >>-----//
            List<EstmDtlColInfo> estimateDetailColInfo_PartsJoinInfo = new List<EstmDtlColInfo>();
            visiblePosition = 1;
            estimateDetailColInfo_PartsJoinInfo.Add(new EstmDtlColInfo(this._estimateDetailDataTable.BLGoodsCodeColumn.ColumnName, visiblePosition++, true, true, false));                  // BL�R�[�h
            estimateDetailColInfo_PartsJoinInfo.Add(new EstmDtlColInfo(this._estimateDetailDataTable.GoodsNameColumn.ColumnName, visiblePosition++, true, true, false));                    // �i��
            estimateDetailColInfo_PartsJoinInfo.Add(new EstmDtlColInfo(this._estimateDetailDataTable.GoodsNo_PrimeColumn.ColumnName, visiblePosition++, true, true, false));                // �D�Ǖi��
            estimateDetailColInfo_PartsJoinInfo.Add(new EstmDtlColInfo(this._estimateDetailDataTable.JoinSourPartsNoWithHColumn.ColumnName, visiblePosition++, true, true, false));         // �������i��
            estimateDetailColInfo_PartsJoinInfo.Add(new EstmDtlColInfo(this._estimateDetailDataTable.CtlgPartsNoColumn.ColumnName, visiblePosition++, true, true, false));                  // �J�^���O�i��


            EstmDtlPtnInfo estimateDetailPatternInfo_PartsJoinInfo = new EstmDtlPtnInfo(Guid.NewGuid(), "�������", patternOrder++, EstmDtlPtnInfo.SearchType.None, estimateDetailColInfo_PartsJoinInfo);

            //-----<< �I�v�V����/�K�i >>-----//
            List<EstmDtlColInfo> estimateDetailColInfo_OptionInfo = new List<EstmDtlColInfo>();
            visiblePosition = 1;
            estimateDetailColInfo_OptionInfo.Add(new EstmDtlColInfo(this._estimateDetailDataTable.BLGoodsCodeColumn.ColumnName, visiblePosition++, true, true, false));                     // BL�R�[�h
            estimateDetailColInfo_OptionInfo.Add(new EstmDtlColInfo(this._estimateDetailDataTable.GoodsNameColumn.ColumnName, visiblePosition++, true, true, false));                       // �i��
            estimateDetailColInfo_OptionInfo.Add(new EstmDtlColInfo(this._estimateDetailDataTable.GoodsNoColumn.ColumnName, visiblePosition++, true, true, false));                         // �i��
            estimateDetailColInfo_OptionInfo.Add(new EstmDtlColInfo(this._estimateDetailDataTable.ShipmentCntColumn.ColumnName, visiblePosition++, true, true, false));                     // QTY
            estimateDetailColInfo_OptionInfo.Add(new EstmDtlColInfo(this._estimateDetailDataTable.ListPriceDisplayColumn.ColumnName, visiblePosition++, true, true, false));                // �W�����i
            estimateDetailColInfo_OptionInfo.Add(new EstmDtlColInfo(this._estimateDetailDataTable.OpenPriceDivDisplayColumn.ColumnName, visiblePosition++, true, true, false));             // OP
            estimateDetailColInfo_OptionInfo.Add(new EstmDtlColInfo(this._estimateDetailDataTable.SpecialNoteColumn.ColumnName, visiblePosition++, true, false, false));                    // ���L����
            estimateDetailColInfo_OptionInfo.Add(new EstmDtlColInfo(this._estimateDetailDataTable.StandardNameColumn.ColumnName, visiblePosition++, true, false, false));                   // �K�i

            EstmDtlPtnInfo estimateDetailPatternInfo_OptionInfo = new EstmDtlPtnInfo(Guid.NewGuid(), "�K�i/�I�v�V�������", patternOrder++, EstmDtlPtnInfo.SearchType.None, estimateDetailColInfo_OptionInfo);


            this._estimateDetailPatternInfoList = new List<EstmDtlPtnInfo>();
            this._estimateDetailPatternInfoList.Add(estimateDetailPatternInfo_Pure);
            this._estimateDetailPatternInfoList.Add(estimateDetailPatternInfo_Prime);
            this._estimateDetailPatternInfoList.Add(estimateDetailPatternInfo_CompareGoodsNo);
            this._estimateDetailPatternInfoList.Add(estimateDetailPatternInfo_CompareStock);
            this._estimateDetailPatternInfoList.Add(estimateDetailPatternInfo_CompareMaker);
            this._estimateDetailPatternInfoList.Add(estimateDetailPatternInfo_PartsJoinInfo);
            this._estimateDetailPatternInfoList.Add(estimateDetailPatternInfo_OptionInfo);
        }

        #endregion
    }
}
