using System;
using System.Collections;
using System.IO;
using System.Collections.Generic;

using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Resources;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// ��\����ԃN���X�R���N�V�����N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ��\����ԃN���X�̃R���N�V�����N���X�ł��B</br>
    /// <br>Programmer : 20056 ���n ���</br>
    /// <br>Date       : 2007.09.10</br>
    /// <br></br>
    /// <br>UpDate</br>
    /// <br>2007.09.10 20056 ���n ��� �V�K�쐬</br>
    /// <br>Update Note : 2010/02/26 ���n ��� </br>
    /// <br>              SCM�Ή�</br>
    /// </remarks>
    internal class ColDisplayStatusList
    {

        #region Constructor
        /// <summary>
        /// ��\����ԃN���X�R���N�V�����N���X�R���X�g���N�^
        /// </summary>
        /// <param name="colDisplayStatusList">ColDisplayStatus�N���X���X�g�̃C���X�^���X</param>
        /// <remarks>
        /// <br>Note       : ��\����ԃN���X�R���N�V�����N���X�̐V�����C���X�^���X�����������܂��B</br>
        /// <br>Programmer : 20056 ���n ���</br>
        /// <br>Date       : 2007.09.10</br>
        /// </remarks>
        public ColDisplayStatusList(List<ColDisplayStatusExp> colDisplayStatusList, SalesInputDataSet.SalesDetailDataTable salesDetailDataTable)
        {
            // �e��C���X�^���X��
            this._colDisplayStatusList = colDisplayStatusList;
            this._colDisplayStatusDictionary = new Dictionary<string, ColDisplayStatusExp>();
            this._colDisplayStatusInitDictionary = new Dictionary<string, ColDisplayStatusExp>();
            this._colDisplayStatusKeyList = new List<string>();
            this._salesDetailDataTable = salesDetailDataTable;

            // ������\����ԃ��X�g����
            List<ColDisplayStatusExp> initStatusList = new List<ColDisplayStatusExp>();

            int visiblePosition = 0;

            // �㉺�P�i
            initStatusList.Add(new ColDisplayStatusExp(this._salesDetailDataTable.SalesRowNoDisplayColumn.ColumnName, visiblePosition++, true, 44, 2, 0, 0, 44, 4, "", "",false,false,false));                                                    // ��

            // ��i
            initStatusList.Add(new ColDisplayStatusExp(this._salesDetailDataTable.BLGoodsCodeColumn.ColumnName, visiblePosition++, true, 73, 2, 44, 0, 73, 2, "GoodsNo", "GoodsName", true, false, false));                                                         // BL�R�[�h
            initStatusList.Add(new ColDisplayStatusExp(this._salesDetailDataTable.GoodsNameColumn.ColumnName, visiblePosition++, true, 430, 2, 117, 0, 430, 2, "GoodsNo", "AcceptAnOrderCntDisplay", true, false, false));                                          // �i��
            initStatusList.Add(new ColDisplayStatusExp(this._salesDetailDataTable.AcceptAnOrderCntDisplayColumn.ColumnName, visiblePosition++, true, 90, 2, 547, 0, 90, 2, "ShipmentCntDisplay", "ShipmentCntDisplay", true, false, true));                         // �󒍐�
            initStatusList.Add(new ColDisplayStatusExp(this._salesDetailDataTable.SalesCodeColumn.ColumnName, visiblePosition++, true, 140, 2, 637, 0, 140, 2, "ListPriceDisplay", "ListPriceDisplay", true, true, true));                                          // �̔��敪         // �ؑ֍���(��{)
            initStatusList.Add(new ColDisplayStatusExp(this._salesDetailDataTable.CostRateColumn.ColumnName, visiblePosition++, true, 70, 2, 777, 0, 70, 2, "SalesRate", "SalesUnitCost", true, true, true));                                                       // �d����           // �ؑ֍���(��{)
            initStatusList.Add(new ColDisplayStatusExp(this._salesDetailDataTable.SalesUnitCostColumn.ColumnName, visiblePosition++, true, 140, 2, 847, 0, 140, 2, "SalesUnPrcDisplay", "SalesRate", true, true, true));                                            // ���P��           // �ؑ֍���(��{)
            initStatusList.Add(new ColDisplayStatusExp(this._salesDetailDataTable.DummyColumn.ColumnName, visiblePosition++, true, 130, 2, 987, 0, 130, 2, "SalesMoneyDisplay", "WarehouseCode", true, false, false));                                              // �_�~�[           // �ؑ֍���(��{) ��{�����v480
            initStatusList.Add(new ColDisplayStatusExp(this._salesDetailDataTable.DtlNoteColumn.ColumnName, visiblePosition++, true, 405, 2, 1117, 0, 400, 2, "PartySlipNumDtl", "PartySlipNumDtl", true, true, true));                                             // ���l             // �ؑ֍���(�ؑ�) �␳+5
            initStatusList.Add(new ColDisplayStatusExp(this._salesDetailDataTable.CmpltSalesRowNoColumn.ColumnName, visiblePosition++, true, 84, 2, 1517, 0, 80, 2, "DeliGdsCmpltDueDate", "PartySlipNumDtl", true, true, true));                                   // �ꎮ             // �ؑ֍���(�ؑ�) �␳+4 �ؑ֍��v480
            initStatusList.Add(new ColDisplayStatusExp(this._salesDetailDataTable.SupplierCdForStockColumn.ColumnName, visiblePosition++, true, 132, 2, 1597, 0, 130, 2, "PartySalesSlipNum", "StockDate", true, true, true));                                      // �d����           // �ؑ֍���(�d��) �␳+2
            initStatusList.Add(new ColDisplayStatusExp(this._salesDetailDataTable.StockDateColumn.ColumnName, visiblePosition++, true, 166, 2, 1727, 0, 165, 2, "PartySalesSlipNum", "PartySalesSlipNum", true, true, true));                                       // �d����           // �ؑ֍���(�d��) �␳+1 �d�����v294
            initStatusList.Add(new ColDisplayStatusExp(this._salesDetailDataTable.BoCodeColumn.ColumnName, visiblePosition++, true, 40, 2, 1892, 0, 40, 2, "SupplierSnmForOrder", "SupplierCdForOrder", true, true, true));                                         // BO               // �ؑ֍���(����) 
            initStatusList.Add(new ColDisplayStatusExp(this._salesDetailDataTable.SupplierCdForOrderColumn.ColumnName, visiblePosition++, true, 120, 2, 1932, 0, 120, 2, "SupplierSnmForOrder", "AcceptAnOrderCntForOrder", true, true, true));                     // ������           // �ؑ֍���(����) 
            initStatusList.Add(new ColDisplayStatusExp(this._salesDetailDataTable.AcceptAnOrderCntForOrderColumn.ColumnName, visiblePosition++, true, 60, 2, 2052, 0, 60, 2, "SupplierSnmForOrder", "SupplierSnmForOrder", true, true, true));                      // ������           // �ؑ֍���(����) 
            initStatusList.Add(new ColDisplayStatusExp(this._salesDetailDataTable.DeliveredGoodsDivNmColumn.ColumnName, visiblePosition++, true, 130, 2, 2112, 0, 130, 2, "UOEResvdSectionNm", "FollowDeliGoodsDivNm", true, true, true));                          // �[�i�敪         // �ؑ֍���(����) 
            initStatusList.Add(new ColDisplayStatusExp(this._salesDetailDataTable.FollowDeliGoodsDivNmColumn.ColumnName, visiblePosition++, true, 130, 2, 2242, 0, 130, 2, "UOEResvdSectionNm", "UOEResvdSectionNm", true, true, true));                            // H�[�i�敪        // �ؑ֍���(����) �������v480
            initStatusList.Add(new ColDisplayStatusExp(this._salesDetailDataTable.WarehouseCodeColumn.ColumnName, visiblePosition++, true, 65, 2, 2372, 0, 65, 2, "SupplierStockDisplay", SalesSlipInputConstructionAcs.ct_StartPosittion, true, true, true));      // �q��
            initStatusList.Add(new ColDisplayStatusExp(this._salesDetailDataTable.WarehouseShelfNoColumn.ColumnName, visiblePosition++, true, 100, 2, 2437, 0, 100, 2, "SupplierStockDisplay", SalesSlipInputConstructionAcs.ct_StartPosittion, true, true, true)); // �I��
            initStatusList.Add(new ColDisplayStatusExp(this._salesDetailDataTable.SlipMemoExistColumn.ColumnName, visiblePosition++, true, 30, 2, 2537, 0, 30, 2, "SupplierSlipExist", SalesSlipInputConstructionAcs.ct_StartPosittion, true, true, true));         // �����C���[�W
            initStatusList.Add(new ColDisplayStatusExp(this._salesDetailDataTable.RecycleDivNmColumn.ColumnName, visiblePosition++, true, 301, 2, 1597, 0, 295, 2, "GoodsMngNo", "GoodsMngNo", true, true, true));                                                  // RC�敪           // �ؑ֍���(SCM) �␳ // 2010/02/26

            // ���i
            //initStatusList.Add(new ColDisplayStatusExp(this._salesDetailDataTable.GoodsNoColumn.ColumnName, visiblePosition++, true, 273, 2, 44, 2, 273, 2, "BLGoodsCode", "GoodsKindCode", true, false, false));                                                   // �i��
            initStatusList.Add(new ColDisplayStatusExp(this._salesDetailDataTable.GoodsNoColumn.ColumnName, visiblePosition++, true, 273, 2, 44, 2, 273, 2, "BLGoodsCode", "BLGoodsCode", true, false, false));                                                   // �i��
            initStatusList.Add(new ColDisplayStatusExp(this._salesDetailDataTable.GoodsKindCodeColumn.ColumnName, visiblePosition++, true, 50, 2, 317, 2, 50, 2, "GoodsName", "GoodsMakerCd", true, true, true));                                                   // ���i����(�����D��)
            initStatusList.Add(new ColDisplayStatusExp(this._salesDetailDataTable.GoodsMakerCdColumn.ColumnName, visiblePosition++, true, 80, 2, 367, 2, 80, 2, "GoodsName", "BLGoodsCode", true, true, true));                                                     // ���[�J�[
            initStatusList.Add(new ColDisplayStatusExp(this._salesDetailDataTable.SupplierCdColumn.ColumnName, visiblePosition++, true, 100, 2, 447, 2, 100, 2, "GoodsName", "SalesCode", true, true, true));                                                       // �d����
            initStatusList.Add(new ColDisplayStatusExp(this._salesDetailDataTable.ShipmentCntDisplayColumn.ColumnName, visiblePosition++, true, 90, 2, 547, 2, 90, 2, "AcceptAnOrderCntDisplay", "SupplierCd", true, false, true));                                 // �o�א�
            initStatusList.Add(new ColDisplayStatusExp(this._salesDetailDataTable.ListPriceDisplayColumn.ColumnName, visiblePosition++, true, 110, 2, 637, 2, 110, 2, "SalesCode", "CostRate", true, true, true));                                                  // �W�����i         // �ؑ֍���(��{)
            initStatusList.Add(new ColDisplayStatusExp(this._salesDetailDataTable.OpenPriceDivDisplayColumn.ColumnName, visiblePosition++, true, 30, 2, 747, 2, 30, 2, "SalesCode", "CostRate", true, true, true));                                                 // �I�[�v���C���[�W // �ؑ֍���(��{)
            initStatusList.Add(new ColDisplayStatusExp(this._salesDetailDataTable.SalesRateColumn.ColumnName, visiblePosition++, true, 70, 2, 777, 2, 70, 2, "CostRate", "SalesUnPrcDisplay", true, true, true));                                                   // ������           // �ؑ֍���(��{)
            initStatusList.Add(new ColDisplayStatusExp(this._salesDetailDataTable.SalesUnPrcDisplayColumn.ColumnName, visiblePosition++, true, 140, 2, 847, 2, 140, 2, "SalesUnitCost", SalesSlipInputConstructionAcs.ct_StartPosittion, true, true, true));        // ���P��           // �ؑ֍���(��{)
            initStatusList.Add(new ColDisplayStatusExp(this._salesDetailDataTable.SalesMoneyDisplayColumn.ColumnName, visiblePosition++, true, 130, 2, 987, 2, 130, 2, "Dummy", SalesSlipInputConstructionAcs.ct_StartPosittion, true, true, true));                // ������z         // �ؑ֍���(��{) ��{�����v480
            initStatusList.Add(new ColDisplayStatusExp(this._salesDetailDataTable.PartySlipNumDtlColumn.ColumnName, visiblePosition++, true, 285, 2, 1117, 2, 280, 2, "DtlNote", "DeliGdsCmpltDueDate", true, true, true));                                         // ���Ӑ撍��       // �ؑ֍���(�ؑ�) �␳+5
            initStatusList.Add(new ColDisplayStatusExp(this._salesDetailDataTable.DeliGdsCmpltDueDateColumn.ColumnName, visiblePosition++, true, 204, 2, 1397, 2, 200, 2, "DtlNote", SalesSlipInputConstructionAcs.ct_StartPosittion, true, true, true));           // �[�i�����\���   // �ؑ֍���(�ؑ�) �␳+4 �ؑ֕����v480
            initStatusList.Add(new ColDisplayStatusExp(this._salesDetailDataTable.PartySalesSlipNumColumn.ColumnName, visiblePosition++, true, 298, 2, 1597, 2, 295, 2, "SupplierCdForStock", SalesSlipInputConstructionAcs.ct_StartPosittion, true, true, true));  // �d���`�[�ԍ�     // �ؑ֍���(�d��) �␳+3 �d�������v294
            initStatusList.Add(new ColDisplayStatusExp(this._salesDetailDataTable.SupplierSnmForOrderColumn.ColumnName, visiblePosition++, true, 220, 2, 1892, 2, 220, 2, "BoCode", "DeliveredGoodsDivNm", true, true, true));                                      // �����於��       // �ؑ֍���(����)
            initStatusList.Add(new ColDisplayStatusExp(this._salesDetailDataTable.UOEResvdSectionNmColumn.ColumnName, visiblePosition++, true, 260, 2, 2112, 2, 260, 2, "DeliveredGoodsDivNm", "WarehouseCode", true, true, true));                                 // �w�苒�_         // �ؑ֍���(����) ���������v480
            initStatusList.Add(new ColDisplayStatusExp(this._salesDetailDataTable.SupplierStockDisplayColumn.ColumnName, visiblePosition++, true, 165, 2, 2372, 2, 165, 2, "WarehouseCode", SalesSlipInputConstructionAcs.ct_StartPosittion, true, true, true));    // ���݌ɐ�
            initStatusList.Add(new ColDisplayStatusExp(this._salesDetailDataTable.SupplierSlipExistColumn.ColumnName, visiblePosition++, true, 30, 2, 2537, 2, 30, 2, "SlipMemoExist", SalesSlipInputConstructionAcs.ct_StartPosittion, true, true, true));         // �d�����C���[�W
            initStatusList.Add(new ColDisplayStatusExp(this._salesDetailDataTable.GoodsMngNoColumn.ColumnName, visiblePosition++, true, 301, 2, 1597, 2, 295, 2, "RecycleDivNm", SalesSlipInputConstructionAcs.ct_StartPosittion, true, true, true));               // PS�Ǘ��ԍ�       // �ؑ֍���(SCM) �␳ // 2010/02/26

            // ������\����ԃ��X�g�i�[����
            foreach (ColDisplayStatusExp initStatus in initStatusList)
            {
                this._colDisplayStatusKeyList.Add(initStatus.Key);
                this._colDisplayStatusInitDictionary.Add(initStatus.Key, initStatus);
            }

            // ��\����ԃN���X���X�g�������̏ꍇ�́A������\����ԃ��X�g��ݒ�
            if ((this._colDisplayStatusList == null) || (this._colDisplayStatusList.Count == 0))
            {
                foreach (string colKey in this._colDisplayStatusKeyList)
                {
                    ColDisplayStatusExp colDisplayStatus = null;

                    try
                    {
                        colDisplayStatus = this._colDisplayStatusInitDictionary[colKey];
                    }
                    catch (KeyNotFoundException)
                    {
                        //
                    }

                    if (colDisplayStatus != null)
                    {
                        this._colDisplayStatusList.Add(colDisplayStatus);
                    }
                }

                // ��\����ԃN���X�i�[Dictionary�̒l���ŐV���ɂčĐ���
                this._colDisplayStatusDictionary = this.ToColStatusDictionaryFromColStatusList(this._colDisplayStatusList);
            }
            else
            {
                // ��\����ԃN���X�i�[Dictionary�̒l���ŐV���ɂčĐ���
                this._colDisplayStatusDictionary = this.ToColStatusDictionaryFromColStatusList(this._colDisplayStatusList);

                // ������\����ԃ��X�g�Ɨ�\����ԃN���X�i�[Dictionary�̒l���r���A�s�������[����
                foreach (string colKey in this._colDisplayStatusKeyList)
                {
                    if (!this.ContainsKey(colKey))
                    {
                        // ���݂��Ȃ���Βǉ�
                        ColDisplayStatusExp colDisplayStatus = null;

                        try
                        {
                            colDisplayStatus = this._colDisplayStatusInitDictionary[colKey]; // ������\����ԃN���X�i�[Dic���擾
                        }
                        catch (KeyNotFoundException)
                        {
                            //
                        }

                        if (colDisplayStatus != null)
                        {
                            colDisplayStatus.VisiblePosition = this._colDisplayStatusList.Count + 1;
                            this.Add(colDisplayStatus);
                        }
                    }
                    else
                    {
                        // ���݂��Ă���Ώ�����\����ԃ��X�g�̓��e�ōX�V
                        ColDisplayStatusExp colDisplayStatusInit = null;
                        ColDisplayStatusExp colDisplayStatus = null;
                        try
                        {
                            colDisplayStatus = this._colDisplayStatusDictionary[colKey]; // ��\����ԃN���X�i�[Dic���擾
                            colDisplayStatusInit = this._colDisplayStatusInitDictionary[colKey]; // ������\����ԃN���X�i�[Dic���擾
                        }
                        catch (KeyNotFoundException)
                        {
                            //
                        }

                        if (colDisplayStatus != null)
                        {
                            colDisplayStatus.OriginX = colDisplayStatusInit.OriginX;
                            colDisplayStatus.OriginY = colDisplayStatusInit.OriginY;
                            colDisplayStatus.SpanX = colDisplayStatusInit.SpanX;
                            colDisplayStatus.SpanY = colDisplayStatusInit.SpanY;
                            colDisplayStatus.Width = colDisplayStatusInit.Width;
                        }

                    }
                }
            }

            // �\���ʒu�ɂ��\�[�g����
            this.Sort();
        }
        #endregion

        #region Private Members
        /// <summary>��\����ԃN���X���X�g</summary>
        private List<ColDisplayStatusExp> _colDisplayStatusList = null;

        /// <summary>��\����ԃN���X�i�[Dictionary</summary>
        private Dictionary<string, ColDisplayStatusExp> _colDisplayStatusDictionary = null;

        /// <summary>������\����ԃN���X�i�[Dictionary</summary>
        private Dictionary<string, ColDisplayStatusExp> _colDisplayStatusInitDictionary = null;

        /// <summary>��\����ԃL�[���X�g</summary>
        private List<string> _colDisplayStatusKeyList = null;

        /// <summary>���㖾�׃f�[�^�e�[�u��</summary>
        SalesInputDataSet.SalesDetailDataTable _salesDetailDataTable;
        #endregion

        #region Public Methods
        /// <summary>
        /// ��\����ԃL�[�i�[���f����
        /// </summary>
        /// <param name="key">�Ώۗ�\����ԃL�[</param>
        /// <returns>��\����Ԃ̗L��(true:�L,false:��)</returns>
        /// <remarks>
        /// <br>Note       : ��\����ԃN���X�i�[Dictionary�ɑΏۂ̃L�[���i�[����Ă��邩�ǂ����𔻒f���܂��B</br>
        /// <br>Programmer : 20056 ���n ���</br>
        /// <br>Date       : 2007.09.10</br>
        /// </remarks>
        public bool ContainsKey(string key)
        {
            return this._colDisplayStatusDictionary.ContainsKey(key);
        }

        /// <summary>
        /// ���בւ�����
        /// </summary>
        /// <remarks>
        /// <br>Note       : ��\����ԃN���X���X�g��\���ʒu�����בւ��܂��B</br>
        /// <br>Programmer : 20056 ���n ���</br>
        /// <br>Date       : 2007.09.10</br>
        /// </remarks>
        public void Sort()
        {
            this._colDisplayStatusList.Sort();
        }

        /// <summary>
        /// ��\����ԃN���X���X�g�擾����
        /// </summary>
        /// <returns>ColDisplayStatus�N���X���X�g�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note       : ��\����ԃN���X���X�g���擾���܂��B</br>
        /// <br>Programmer : 20056 ���n ���</br>
        /// <br>Date       : 2007.09.10</br>
        /// </remarks>
        public List<ColDisplayStatusExp> GetColDisplayStatusList()
        {
            // �\���ʒu�ɂ��\�[�g����
            this.Sort();

            return this._colDisplayStatusList;
        }

        /// <summary>
        /// ������\����ԃN���X�i�[Dictionary�擾����
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : ������\����ԃN���X�i�[Dictionary���擾���܂��B</br>
        /// <br>Programmer : 20056 ���n ���</br>
        /// <br>Date       : 2007.09.10</br>
        /// </remarks>
        public Dictionary<string, ColDisplayStatusExp> GetColDisplayInitDictionary()
        {
            return this._colDisplayStatusInitDictionary;
        }

        /// <summary>
        /// ��\����ԃN���X���X�g�ݒ菈��
        /// </summary>
        /// <param name="colDisplayStatusList">�ݒ肷��ColDisplayStatus�N���X���X�g�̃C���X�^���X</param>
        /// <remarks>
        /// <br>Note       : ��\����ԃN���X���X�g��ݒ肵�܂��B</br>
        /// <br>Programmer : 20056 ���n ���</br>
        /// <br>Date       : 2007.09.10</br>
        /// </remarks>
        public void SetColDisplayStatusList(List<ColDisplayStatusExp> colDisplayStatusList)
        {
            this._colDisplayStatusList = colDisplayStatusList;

            // �\���ʒu�ɂ��\�[�g����
            this.Sort();
        }

        /// <summary>
        /// ��\����ԃN���X���X�g�V���A���C�Y����
        /// </summary>
        /// <param name="displayStatusList">�V���A���C�Y�Ώ�ColDisplayStatus�N���X���X�g�̃C���X�^���X</param>
        /// <param name="fileName">�V���A���C�Y��t�@�C������</param>
        /// <remarks>
        /// <br>Note       : ��\����ԃN���X���X�g���V���A���C�Y���܂��B</br>
        /// <br>Programmer : 20056 ���n ���</br>
        /// <br>Date       : 2007.09.10</br>
        /// </remarks>
        public static void Serialize(List<ColDisplayStatusExp> colDisplayStatusList, string fileName)
        {
            ColDisplayStatusExp[] colDisplayStatusArray = new ColDisplayStatusExp[colDisplayStatusList.Count];
            colDisplayStatusList.CopyTo(colDisplayStatusArray);

            UserSettingController.ByteSerializeUserSetting(colDisplayStatusArray, Path.Combine(ConstantManagement_ClientDirectory.UISettings_GridInfo, fileName));
        }

        /// <summary>
        /// ��\����ԃN���X���X�g�f�V���A���C�Y����
        /// </summary>
        /// <param name="fileName">�f�V���A���C�Y���t�@�C������</param>
        /// <returns>�f�V���A���C�Y���ꂽColDisplayStatus�N���X���X�g�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note       : �f�V���A���C�Y������\����ԃN���X���X�g��Ԃ��܂��B</br>
        /// <br>Programmer : 20056 ���n ���</br>
        /// <br>Date       : 2007.09.10</br>
        /// </remarks>
        public static List<ColDisplayStatusExp> Deserialize(string fileName)
        {
            List<ColDisplayStatusExp> retList = new List<ColDisplayStatusExp>();

            if (UserSettingController.ExistUserSetting(Path.Combine(ConstantManagement_ClientDirectory.UISettings_GridInfo, fileName)))
            {
                try
                {
                    ColDisplayStatusExp[] retArray = UserSettingController.ByteDeserializeUserSetting<ColDisplayStatusExp[]>(Path.Combine(ConstantManagement_ClientDirectory.UISettings_GridInfo, fileName));

                    foreach (ColDisplayStatusExp colDisplayStatus in retArray)
                    {
                        retList.Add(colDisplayStatus);
                    }
                }
                catch (System.InvalidOperationException)
                {
                    UserSettingController.DeleteUserSetting(Path.Combine(ConstantManagement_ClientDirectory.UISettings_GridInfo, fileName));
                }
            }

            return retList;
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// ��\����ԃN���X�ǉ�����
        /// </summary>
        /// <param name="colDisplayStatus">�ǉ�����ColDisplayStatus�N���X�̃C���X�^���X</param>
        /// <remarks>
        /// <br>Note       : ��\����ԃN���X���\����ԃN���X�i�[Dictionary�ɒǉ����܂��B</br>
        /// <br>Programmer : 20056 ���n ���</br>
        /// <br>Date       : 2007.09.10</br>
        /// </remarks>
        private void Add(ColDisplayStatusExp colDisplayStatus)
        {
            // ���ɓ���L�[�����݂���ꍇ�͏������Ȃ�
            if (this._colDisplayStatusDictionary.ContainsKey(colDisplayStatus.Key))
            {
                return;
            }

            this._colDisplayStatusList.Add(colDisplayStatus);
            this._colDisplayStatusDictionary.Add(colDisplayStatus.Key, colDisplayStatus);

            // �\���ʒu�ɂ��\�[�g����
            this.Sort();
        }

        /// <summary>
        /// ��\����ԃN���X�폜����
        /// </summary>
        /// <param name="colDisplayStatus">�폜����ColDisplayStatus�N���X�̃C���X�^���X</param>
        /// <remarks>
        /// <br>Note       : ��\����ԃN���X���\����ԃN���X�i�[Dictionary����폜���܂��B</br>
        /// <br>Programmer : 20056 ���n ���</br>
        /// <br>Date       : 2007.09.10</br>
        /// </remarks>
        private void Remove(ColDisplayStatusExp colDisplayStatus)
        {
            // ����L�[�����݂��Ȃ��ꍇ�͏������Ȃ�
            if (!(this._colDisplayStatusDictionary.ContainsKey(colDisplayStatus.Key)))
            {
                return;
            }

            ColDisplayStatusExp status = null;

            try
            {
                status = this._colDisplayStatusDictionary[colDisplayStatus.Key];
            }
            catch (KeyNotFoundException)
            {
                //
            }

            if (status == null)
            {
                return;
            }

            this._colDisplayStatusList.Remove(status);
            this._colDisplayStatusDictionary.Remove(colDisplayStatus.Key);

            // �\���ʒu�ɂ��\�[�g����
            this.Sort();
        }

        /// <summary>
        /// ��\����ԃN���X���X�g��Dictionary�i�[����
        /// </summary>
        /// <param name="colDisplayStatusList">�i�[����ColDisplayStatus�N���X�̃��X�g�̃C���X�^���X</param>
        /// <returns>��\����ԃN���X�i�[Dictionary�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note       : ��\����ԃN���X���\����ԃN���X�i�[Dictionary����폜���܂��B</br>
        /// <br>Programmer : 20056 ���n ���</br>
        /// <br>Date       : 2007.09.10</br>
        /// </remarks>
        private Dictionary<string, ColDisplayStatusExp> ToColStatusDictionaryFromColStatusList(List<ColDisplayStatusExp> colDisplayStatusList)
        {
            Dictionary<string, ColDisplayStatusExp> retDictionary = new Dictionary<string, ColDisplayStatusExp>();

            foreach (ColDisplayStatusExp status in colDisplayStatusList)
            {
                retDictionary.Add(status.Key, status);
            }

            return retDictionary;
        }
        #endregion
    }
}