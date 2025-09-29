using System;
using System.Data;
using System.Collections;
using Broadleaf.Application.UIData;

namespace Broadleaf.Application.UIData
{

    /// <summary>
    /// 
    /// </summary>
    public partial class BLInfoDataTable : DataTable, IEnumerable
    {

        private DataColumn columnTbsPartsCode;

        private DataColumn columnTbsPartsFullName;

        private DataColumn columnTbsPartsHalfName;

        private DataColumn columnEquipGenreCode;

        private DataColumn columnBLGroupCode;

        private DataColumn columnGoodsMGroup;

        private DataColumn columnTbsPartsCdDerivedNo;

        private DataColumn columnPrimeSearchFlg;

        private DataColumn columnSelectionState;

        /// <summary>
        /// 
        /// </summary>
        public BLInfoDataTable()
        {
            this.TableName = "BLInfo";
            this.BeginInit();
            this.InitClass();
            this.EndInit();
        }


        internal BLInfoDataTable(DataTable table)
        {
            this.TableName = table.TableName;
            if ((table.CaseSensitive != table.DataSet.CaseSensitive))
            {
                this.CaseSensitive = table.CaseSensitive;
            }
            if ((table.Locale.ToString() != table.DataSet.Locale.ToString()))
            {
                this.Locale = table.Locale;
            }
            if ((table.Namespace != table.DataSet.Namespace))
            {
                this.Namespace = table.Namespace;
            }
            this.Prefix = table.Prefix;
            this.MinimumCapacity = table.MinimumCapacity;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        protected BLInfoDataTable(global::System.Runtime.Serialization.SerializationInfo info, global::System.Runtime.Serialization.StreamingContext context)
            :
                base(info, context)
        {
            this.InitVars();
        }

        /// <summary>
        /// 
        /// </summary>
        public DataColumn TbsPartsCodeColumn
        {
            get
            {
                return this.columnTbsPartsCode;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public DataColumn TbsPartsFullNameColumn
        {
            get
            {
                return this.columnTbsPartsFullName;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public DataColumn TbsPartsHalfNameColumn
        {
            get
            {
                return this.columnTbsPartsHalfName;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public DataColumn EquipGenreCodeColumn
        {
            get
            {
                return this.columnEquipGenreCode;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public DataColumn BLGroupCodeColumn
        {
            get
            {
                return this.columnBLGroupCode;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public DataColumn GoodsMGroupColumn
        {
            get
            {
                return this.columnGoodsMGroup;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public DataColumn TbsPartsCdDerivedNoColumn
        {
            get
            {
                return this.columnTbsPartsCdDerivedNo;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public DataColumn PrimeSearchFlgColumn
        {
            get
            {
                return this.columnPrimeSearchFlg;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public DataColumn SelectionStateColumn
        {
            get
            {
                return this.columnSelectionState;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public int Count
        {
            get
            {
                return this.Rows.Count;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public BLInfoRow this[int index]
        {
            get
            {
                return ((BLInfoRow)(this.Rows[index]));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="row"></param>
        public void AddBLInfoRow(BLInfoRow row)
        {
            this.Rows.Add(row);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="TbsPartsCode"></param>
        /// <param name="TbsPartsFullName"></param>
        /// <param name="TbsPartsHalfName"></param>
        /// <param name="EquipGenreCode"></param>
        /// <param name="BLGroupCode"></param>
        /// <param name="GoodsMGroup"></param>
        /// <param name="TbsPartsCdDerivedNo"></param>
        /// <param name="PrimeSearchFlg"></param>
        /// <param name="SelectionState"></param>
        /// <returns></returns>
        public BLInfoRow AddBLInfoRow(int TbsPartsCode, string TbsPartsFullName, string TbsPartsHalfName, int EquipGenreCode, int BLGroupCode, int GoodsMGroup, int TbsPartsCdDerivedNo, int PrimeSearchFlg, bool SelectionState)
        {
            BLInfoRow rowBLInfoRow = ((BLInfoRow)(this.NewRow()));
            object[] columnValuesArray = new object[] {
                        TbsPartsCode,
                        TbsPartsFullName,
                        TbsPartsHalfName,
                        EquipGenreCode,
                        BLGroupCode,
                        GoodsMGroup,
                        TbsPartsCdDerivedNo,
                        PrimeSearchFlg,
                        SelectionState};
            rowBLInfoRow.ItemArray = columnValuesArray;
            this.Rows.Add(rowBLInfoRow);
            return rowBLInfoRow;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerator GetEnumerator()
        {
            return this.Rows.GetEnumerator();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override DataTable Clone()
        {
            BLInfoDataTable cln = ((BLInfoDataTable)(base.Clone()));
            cln.InitVars();
            return cln;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected override DataTable CreateInstance()
        {
            return new BLInfoDataTable();
        }


        internal void InitVars()
        {
            this.columnTbsPartsCode = base.Columns["TbsPartsCode"];
            this.columnTbsPartsFullName = base.Columns["TbsPartsFullName"];
            this.columnTbsPartsHalfName = base.Columns["TbsPartsHalfName"];
            this.columnEquipGenreCode = base.Columns["EquipGenreCode"];
            this.columnBLGroupCode = base.Columns["BLGroupCode"];
            this.columnGoodsMGroup = base.Columns["GoodsMGroup"];
            this.columnTbsPartsCdDerivedNo = base.Columns["TbsPartsCdDerivedNo"];
            this.columnPrimeSearchFlg = base.Columns["PrimeSearchFlg"];
            this.columnSelectionState = base.Columns["SelectionState"];
        }


        private void InitClass()
        {
            this.columnTbsPartsCode = new DataColumn("TbsPartsCode", typeof(int), null, MappingType.Element);
            base.Columns.Add(this.columnTbsPartsCode);
            this.columnTbsPartsFullName = new DataColumn("TbsPartsFullName", typeof(string), null, MappingType.Element);
            base.Columns.Add(this.columnTbsPartsFullName);
            this.columnTbsPartsHalfName = new DataColumn("TbsPartsHalfName", typeof(string), null, MappingType.Element);
            base.Columns.Add(this.columnTbsPartsHalfName);
            this.columnEquipGenreCode = new DataColumn("EquipGenreCode", typeof(int), null, MappingType.Element);
            base.Columns.Add(this.columnEquipGenreCode);
            this.columnBLGroupCode = new DataColumn("BLGroupCode", typeof(int), null, MappingType.Element);
            base.Columns.Add(this.columnBLGroupCode);
            this.columnGoodsMGroup = new DataColumn("GoodsMGroup", typeof(int), null, MappingType.Element);
            base.Columns.Add(this.columnGoodsMGroup);
            this.columnTbsPartsCdDerivedNo = new DataColumn("TbsPartsCdDerivedNo", typeof(int), null, MappingType.Element);
            base.Columns.Add(this.columnTbsPartsCdDerivedNo);
            this.columnPrimeSearchFlg = new DataColumn("PrimeSearchFlg", typeof(int), null, MappingType.Element);
            base.Columns.Add(this.columnPrimeSearchFlg);
            this.columnSelectionState = new DataColumn("SelectionState", typeof(bool), null, MappingType.Element);
            base.Columns.Add(this.columnSelectionState);
            this.columnTbsPartsCode.AllowDBNull = false;
            this.columnTbsPartsCode.Caption = "BLコード";
            this.columnTbsPartsFullName.AllowDBNull = false;
            this.columnTbsPartsFullName.Caption = "BLコード名称（全角）";
            this.columnTbsPartsFullName.MaxLength = 60;
            this.columnTbsPartsHalfName.AllowDBNull = false;
            this.columnTbsPartsHalfName.Caption = "BLコード名称（半角）";
            this.columnTbsPartsHalfName.MaxLength = 60;
            this.columnEquipGenreCode.AllowDBNull = false;
            this.columnEquipGenreCode.Caption = "装備分類";
            this.columnBLGroupCode.AllowDBNull = false;
            this.columnBLGroupCode.Caption = "グループコード";
            this.columnGoodsMGroup.AllowDBNull = false;
            this.columnGoodsMGroup.Caption = "中分類コード";
            this.columnTbsPartsCdDerivedNo.AllowDBNull = false;
            this.columnTbsPartsCdDerivedNo.Caption = "BLコード枝番";
            this.columnPrimeSearchFlg.AllowDBNull = false;
            this.columnPrimeSearchFlg.Caption = "優良検索区分";
            this.columnSelectionState.Caption = "選択状態";
            this.CaseSensitive = true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public BLInfoRow NewBLInfoRow()
        {
            return ((BLInfoRow)(this.NewRow()));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="builder"></param>
        /// <returns></returns>
        protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
        {
            return new BLInfoRow(builder);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected override global::System.Type GetRowType()
        {
            return typeof(BLInfoRow);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="row"></param>
        public void RemoveBLInfoRow(BLInfoRow row)
        {
            this.Rows.Remove(row);
        }

    }

    /// <summary>
    /// 
    /// </summary>
    public partial class BLInfoRow : DataRow
    {

        private BLInfoDataTable tableBLInfo;


        internal BLInfoRow(DataRowBuilder rb)
            :
                base(rb)
        {
            this.tableBLInfo = ((BLInfoDataTable)(this.Table));
        }

        /// <summary>
        /// 
        /// </summary>
        public int TbsPartsCode
        {
            get
            {
                return ((int)(this[this.tableBLInfo.TbsPartsCodeColumn]));
            }
            set
            {
                this[this.tableBLInfo.TbsPartsCodeColumn] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public string TbsPartsFullName
        {
            get
            {
                return ((string)(this[this.tableBLInfo.TbsPartsFullNameColumn]));
            }
            set
            {
                this[this.tableBLInfo.TbsPartsFullNameColumn] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public string TbsPartsHalfName
        {
            get
            {
                return ((string)(this[this.tableBLInfo.TbsPartsHalfNameColumn]));
            }
            set
            {
                this[this.tableBLInfo.TbsPartsHalfNameColumn] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public int EquipGenreCode
        {
            get
            {
                return ((int)(this[this.tableBLInfo.EquipGenreCodeColumn]));
            }
            set
            {
                this[this.tableBLInfo.EquipGenreCodeColumn] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public int BLGroupCode
        {
            get
            {
                return ((int)(this[this.tableBLInfo.BLGroupCodeColumn]));
            }
            set
            {
                this[this.tableBLInfo.BLGroupCodeColumn] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public int GoodsMGroup
        {
            get
            {
                return ((int)(this[this.tableBLInfo.GoodsMGroupColumn]));
            }
            set
            {
                this[this.tableBLInfo.GoodsMGroupColumn] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public int TbsPartsCdDerivedNo
        {
            get
            {
                return ((int)(this[this.tableBLInfo.TbsPartsCdDerivedNoColumn]));
            }
            set
            {
                this[this.tableBLInfo.TbsPartsCdDerivedNoColumn] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public int PrimeSearchFlg
        {
            get
            {
                return ((int)(this[this.tableBLInfo.PrimeSearchFlgColumn]));
            }
            set
            {
                this[this.tableBLInfo.PrimeSearchFlgColumn] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public bool SelectionState
        {
            get
            {
                try
                {
                    return ((bool)(this[this.tableBLInfo.SelectionStateColumn]));
                }
                catch (global::System.InvalidCastException e)
                {
                    throw new StrongTypingException("テーブル \'BLInfo\' にある列 \'SelectionState\' の値は DBNull です。", e);
                }
            }
            set
            {
                this[this.tableBLInfo.SelectionStateColumn] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public bool IsSelectionStateNull()
        {
            return this.IsNull(this.tableBLInfo.SelectionStateColumn);
        }

        /// <summary>
        /// 
        /// </summary>
        public void SetSelectionStateNull()
        {
            this[this.tableBLInfo.SelectionStateColumn] = global::System.Convert.DBNull;
        }
    }

}
