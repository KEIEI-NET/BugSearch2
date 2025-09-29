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
    /// ��\����ԃN���X�R���N�V����
    /// </summary>
    /// <remarks>
    /// <br>Note       : ��\����ԃN���X�̃R���N�V�����N���X�ł��B</br>
    /// <br>Programmer : �Ɠc �M�u</br>
    /// <br>Date       : 2008/09/04</br>
    /// </remarks>
    internal class ColDisplayStatusList
    {
        // ===================================================================================== //
        // �p�u���b�N�ϐ�
        // ===================================================================================== //
        public static readonly int KBN_HEADER = 1;
        public static readonly int KBN_DETAIL = 2;

        // ===================================================================================== //
        // �v���C�x�[�g�ϐ�
        // ===================================================================================== //
        private List<ColDisplayStatus> _colDisplayStatusList = null;                            // ��\����ԃN���X���X�g
        private List<string> _colDisplayStatusKeyList = null;                                   // ��\����ԃL�[���X�g
        private Dictionary<string, ColDisplayStatus> _colDisplayStatusDictionary = null;        // ��\����ԃN���X�i�[Dictionary
        private Dictionary<string, ColDisplayStatus> _colDisplayStatusInitDictionary = null;    // ������\����ԃN���X�i�[Dictionary

        // ===================================================================================== //
        // �R���X�g���N�^
        // ===================================================================================== //
        #region ��Constructor
        /// <summary>
        /// ��\����ԃN���X�R���N�V�����N���X�R���X�g���N�^
        /// </summary>
        /// <param name="colDisplayStatusList">ColDisplayStatus�N���X���X�g�̃C���X�^���X</param>
        /// <param name="kbn">1�F�w�b�_�[�O���b�h�p�A2�F���׃O���b�h�p</param>
        /// <remarks>
        /// <br>Note       : ��\����ԃN���X�R���N�V�����N���X�̐V�����C���X�^���X�����������܂��B</br>
        /// <br>Programmer : �Ɠc �M�u</br>
        /// <br>Date       : 2008/09/04</br>
        /// </remarks>
        public ColDisplayStatusList(List<ColDisplayStatus> colDisplayStatusList,int kbn)
        {
            int visiblePosition = 0;
            
            // �e��C���X�^���X��
            this._colDisplayStatusList = colDisplayStatusList;
            this._colDisplayStatusDictionary = new Dictionary<string, ColDisplayStatus>();
            this._colDisplayStatusInitDictionary = new Dictionary<string, ColDisplayStatus>();
            this._colDisplayStatusKeyList = new List<string>();

            // ������\����ԃ��X�g����
            List<ColDisplayStatus> initStatusList = new List<ColDisplayStatus>();

            if (kbn == 1)
            {
                // �w�b�_�[�O���b�h�p
                HeaderGridDataSet.HeaderTableDataTable headerTable = new HeaderGridDataSet.HeaderTableDataTable();
                initStatusList.Add(new ColDisplayStatus(headerTable.NoColumn.ColumnName, visiblePosition++, false, 10));                    // No(��\������)
                initStatusList.Add(new ColDisplayStatus(headerTable.DivCdColumn.ColumnName, visiblePosition++, true, 56));                  // �敪
                initStatusList.Add(new ColDisplayStatus(headerTable.SlipNoColumn.ColumnName, visiblePosition++, false, 112));               // �`�[�ԍ�
                initStatusList.Add(new ColDisplayStatus(headerTable.RemarkColumn.ColumnName, visiblePosition++, false, 88));                // ���}�[�N
                initStatusList.Add(new ColDisplayStatus(headerTable.TotalColumn.ColumnName, visiblePosition++, false, 104));                // ���v
            }
            else if (kbn == 2)
            {
                // ���׃O���b�h�p
                DetailGridDataSet.DetailTableDataTable detailTable = new DetailGridDataSet.DetailTableDataTable();
                initStatusList.Add(new ColDisplayStatus(detailTable.NoColumn.ColumnName, visiblePosition++, false, 10));                        // No(��\������)
                initStatusList.Add(new ColDisplayStatus(detailTable.DivCdColumn.ColumnName, visiblePosition++, true, 56));                      // �敪
                initStatusList.Add(new ColDisplayStatus(detailTable.InputEnterCntColumn.ColumnName, visiblePosition++, false, 42));             // ����
                initStatusList.Add(new ColDisplayStatus(detailTable.InputAnswerSalesUnitCostColumn.ColumnName, visiblePosition++, false, 88));  // �񓚌����P��
                initStatusList.Add(new ColDisplayStatus(detailTable.GoodsNameColumn.ColumnName, visiblePosition++, false, 126));                // �i��
                initStatusList.Add(new ColDisplayStatus(detailTable.GoodsNoColumn.ColumnName, visiblePosition++, false, 126));                  // �i��
                initStatusList.Add(new ColDisplayStatus(detailTable.WarehouseCodeColumn.ColumnName, visiblePosition++, false, 58));             // �q��
                initStatusList.Add(new ColDisplayStatus(detailTable.WarehouseShelfNoColumn.ColumnName, visiblePosition++, false, 72));          // �I��
                initStatusList.Add(new ColDisplayStatus(detailTable.SectionCntColumn.ColumnName, visiblePosition++, false, 40));                // ��
                initStatusList.Add(new ColDisplayStatus(detailTable.BOCntColumn.ColumnName, visiblePosition++, false, 40));                     // BO��
                initStatusList.Add(new ColDisplayStatus(detailTable.EnterCntColumn.ColumnName, visiblePosition++, false, 10));                  // ���ɐ�(��\������)
                initStatusList.Add(new ColDisplayStatus(detailTable.AnswerSalesUnitCostColumn.ColumnName, visiblePosition++, false, 88));       // �񓚌��P��(��\������)
                initStatusList.Add(new ColDisplayStatus(detailTable.SalesUnitCostColumn.ColumnName, visiblePosition++, false, 88));             // ���P��(��\������)
                initStatusList.Add(new ColDisplayStatus(detailTable.SubstPartsNoColumn.ColumnName, visiblePosition++, false, 10));              // ��֕i��(��\������)
                initStatusList.Add(new ColDisplayStatus(detailTable.AnswerPartsNoColumn.ColumnName, visiblePosition++, false, 10));             // �񓚕i��(��\������)
                initStatusList.Add(new ColDisplayStatus(detailTable.SupplierCdColumn.ColumnName, visiblePosition++, false, 10));                // �d����R�[�h(��\������)
                initStatusList.Add(new ColDisplayStatus(detailTable.SlipNoColumn.ColumnName, visiblePosition++, false, 10));                    // �`�[�ԍ�(��\������)
                initStatusList.Add(new ColDisplayStatus(detailTable.OnlineNoColumn.ColumnName, visiblePosition++, false, 10));                  // �I�����C���ԍ�(��\������)
                initStatusList.Add(new ColDisplayStatus(detailTable.OnlineRowNoColumn.ColumnName, visiblePosition++, false, 10));               // �I�����C���s�ԍ�(��\������)
                initStatusList.Add(new ColDisplayStatus(detailTable.StockExistsColumn.ColumnName, visiblePosition++, false, 10));               // �݌ɗL��(��\������)
            }

            // ������\����ԃ��X�g�i�[����
            foreach (ColDisplayStatus initStatus in initStatusList)
            {
                this._colDisplayStatusKeyList.Add(initStatus.Key);
                this._colDisplayStatusInitDictionary.Add(initStatus.Key, initStatus);
            }

            // ��\����ԃN���X���X�g�������̏ꍇ�́A������\����ԃ��X�g��ݒ�
            if ((this._colDisplayStatusList == null) || (this._colDisplayStatusList.Count == 0))
            {
                foreach (string colKey in this._colDisplayStatusKeyList)
                {
                    if (this._colDisplayStatusInitDictionary.ContainsKey(colKey))
                    {
                        this._colDisplayStatusList.Add(this._colDisplayStatusInitDictionary[colKey]);
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
                        if (this._colDisplayStatusInitDictionary.ContainsKey(colKey))
                        {
                            ColDisplayStatus colDisplayStatus = null;
                            colDisplayStatus = this._colDisplayStatusInitDictionary[colKey];

                            colDisplayStatus.VisiblePosition = this._colDisplayStatusList.Count + 1;
                            this.Add(colDisplayStatus);
                        }
                    }
                }
            }

            // �\���ʒu�ɂ��\�[�g����
            this.Sort();
        }
        #endregion

        // ===================================================================================== //
        // �p�u���b�N
        // ===================================================================================== //
        #region ��GetColDisplayStatusList(��\����ԃN���X���X�g-�擾)
        /// <summary>
        /// ��\����ԃN���X���X�g�擾����
        /// </summary>
        /// <returns>ColDisplayStatus�N���X���X�g�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note       : ��\����ԃN���X���X�g���擾���܂��B</br>
        /// <br>Programmer : �Ɠc �M�u</br>
        /// <br>Date       : 2008/09/04</br>
        /// </remarks>
        public List<ColDisplayStatus> GetColDisplayStatusList()
        {
            // �\���ʒu�ɂ��\�[�g����
            this.Sort();

            return this._colDisplayStatusList;
        }
        #endregion

        #region ��SetColDisplayStatusList(��\����ԃN���X���X�g-�ݒ�)
        /// <summary>
        /// ��\����ԃN���X���X�g�ݒ菈��
        /// </summary>
        /// <param name="colDisplayStatusList">�ݒ肷��ColDisplayStatus�N���X���X�g�̃C���X�^���X</param>
        /// <remarks>
        /// <br>Note       : ��\����ԃN���X���X�g��ݒ肵�܂��B</br>
        /// <br>Programmer : �Ɠc �M�u</br>
        /// <br>Date       : 2008/09/04</br>
        /// </remarks>
        public void SetColDisplayStatusList(List<ColDisplayStatus> colDisplayStatusList)
        {
            this._colDisplayStatusList = colDisplayStatusList;

            // �\���ʒu�ɂ��\�[�g����
            this.Sort();
        }
        #endregion

        #region ��Serialize(��\����ԃN���X���X�g-�V���A���C�Y)
        /// <summary>
        /// ��\����ԃN���X���X�g�V���A���C�Y����
        /// </summary>
        /// <param name="displayStatusList">�V���A���C�Y�Ώ�ColDisplayStatus�N���X���X�g�̃C���X�^���X</param>
        /// <param name="fileName">�V���A���C�Y��t�@�C������</param>
        /// <remarks>
        /// <br>Note       : ��\����ԃN���X���X�g���V���A���C�Y���܂��B</br>
        /// <br>Programmer : �Ɠc �M�u</br>
        /// <br>Date       : 2008/09/04</br>
        /// </remarks>
        public static void Serialize(List<ColDisplayStatus> colDisplayStatusList, string fileName)
        {
            ColDisplayStatus[] colDisplayStatusArray = new ColDisplayStatus[colDisplayStatusList.Count];
            colDisplayStatusList.CopyTo(colDisplayStatusArray);

            UserSettingController.ByteSerializeUserSetting(colDisplayStatusArray, Path.Combine(ConstantManagement_ClientDirectory.UISettings_GridInfo, fileName));
        }
        #endregion

        #region ��Deserialize(��\����ԃN���X���X�g-�f�V���A���C�Y)
        /// <summary>
        /// ��\����ԃN���X���X�g�f�V���A���C�Y����
        /// </summary>
        /// <param name="fileName">�f�V���A���C�Y���t�@�C������</param>
        /// <returns>�f�V���A���C�Y���ꂽColDisplayStatus�N���X���X�g�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note       : �f�V���A���C�Y������\����ԃN���X���X�g��Ԃ��܂��B</br>
        /// <br>Programmer : �Ɠc �M�u</br>
        /// <br>Date       : 2008/09/04</br>
        /// </remarks>
        public static List<ColDisplayStatus> Deserialize(string fileName)
        {
            List<ColDisplayStatus> retList = new List<ColDisplayStatus>();

            if (UserSettingController.ExistUserSetting(Path.Combine(ConstantManagement_ClientDirectory.UISettings_GridInfo, fileName)))
            {
                try
                {
                    ColDisplayStatus[] retArray = UserSettingController.ByteDeserializeUserSetting<ColDisplayStatus[]>(Path.Combine(ConstantManagement_ClientDirectory.UISettings_GridInfo, fileName));

                    foreach (ColDisplayStatus colDisplayStatus in retArray)
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

        // ===================================================================================== //
        // �v���C�x�[�g
        // ===================================================================================== //
        #region ��Add(��\����ԃN���X����\����ԃN���X�i�[Dicrionary�ǉ�)
        /// <summary>
        /// ��\����ԃN���X�ǉ�����
        /// </summary>
        /// <param name="colDisplayStatus">�ǉ�����ColDisplayStatus�N���X�̃C���X�^���X</param>
        /// <remarks>
        /// <br>Note       : ��\����ԃN���X���\����ԃN���X�i�[Dictionary�ɒǉ����܂��B</br>
        /// <br>Programmer : �Ɠc �M�u</br>
        /// <br>Date       : 2008/09/04</br>
        /// </remarks>
        private void Add(ColDisplayStatus colDisplayStatus)
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
        #endregion

        #region ��ContainsKey(��\����ԃN���X�i�[Dictionary-�ΏۃL�[�L������)
        /// <summary>
        /// ��\����ԃL�[�i�[���f����
        /// </summary>
        /// <param name="key">�Ώۗ�\����ԃL�[</param>
        /// <returns>��\����Ԃ̗L��(true:�L,false:��)</returns>
        /// <remarks>
        /// <br>Note       : ��\����ԃN���X�i�[Dictionary�ɑΏۂ̃L�[���i�[����Ă��邩�ǂ����𔻒f���܂��B</br>
        /// <br>Programmer : �Ɠc �M�u</br>
        /// <br>Date       : 2008/09/04</br>
        /// </remarks>
        private bool ContainsKey(string key)
        {
            return this._colDisplayStatusDictionary.ContainsKey(key);
        }
        #endregion

        #region ��Sort(��\����ԃN���X���X�g-���בւ�)
        /// <summary>
        /// ���בւ�����
        /// </summary>
        /// <remarks>
        /// <br>Note       : ��\����ԃN���X���X�g��\���ʒu�����בւ��܂��B</br>
        /// <br>Programmer : �Ɠc �M�u</br>
        /// <br>Date       : 2008/09/04</br>
        /// </remarks>
        private void Sort()
        {
            this._colDisplayStatusList.Sort();
        }
        #endregion

        #region ��ToColStatusDictionaryFromColStatusList(��\����ԃN���X���X�g��Dictionary�f�[�^�R�s�[)
        /// <summary>
        /// ��\����ԃN���X���X�g��Dictionary�R�s�[����
        /// </summary>
        /// <param name="colDisplayStatusList">�i�[����ColDisplayStatus�N���X�̃��X�g�̃C���X�^���X</param>
        /// <returns>��\����ԃN���X�i�[Dictionary�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note       : ��\����ԃN���X���X�g�̃f�[�^��Dictionary�ɃR�s�[���܂��B</br>
        /// <br>Programmer : �Ɠc �M�u</br>
        /// <br>Date       : 2008/09/04</br>
        /// </remarks>
        private Dictionary<string, ColDisplayStatus> ToColStatusDictionaryFromColStatusList(List<ColDisplayStatus> colDisplayStatusList)
        {
            Dictionary<string, ColDisplayStatus> retDictionary = new Dictionary<string, ColDisplayStatus>();

            foreach (ColDisplayStatus status in colDisplayStatusList)
            {
                retDictionary.Add(status.Key, status);
            }

            return retDictionary;
        }
        #endregion
    }
}
