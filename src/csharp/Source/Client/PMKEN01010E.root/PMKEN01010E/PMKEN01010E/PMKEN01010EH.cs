using System;
using System.Data;
using System.Collections;
using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;

namespace Broadleaf.Application.UIData
{
    public partial class PMKEN01010E
    {

        /// <summary>
        /// 類別車輌情報クラス
        /// </summary>
        /// <remarks>
        /// <br>Note       : 類別車輌情報を格納するデータテーブルです。</br>
        /// <br>Programmer : 30290</br>
        /// <br>Date       : 2008.05.15</br>
        /// <br></br>
        /// <br>Update Note: </br>
        /// </remarks>
        public partial class CtgyMdlLnkInfoDataTable : DataTable, IEnumerable
        {

            private DataColumn columnModelDesignationNo;

            private DataColumn columnCategoryNo;

            private DataColumn columnCarProperNo;

            private DataColumn columnFullModelFixedNo;

            private DataColumn columnSelectionState;

            /// <summary>
            /// 
            /// </summary>
            public CtgyMdlLnkInfoDataTable()
            {
                this.TableName = "CtgyMdlLnkInfo";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }


            internal CtgyMdlLnkInfoDataTable(DataTable table)
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
            protected CtgyMdlLnkInfoDataTable(global::System.Runtime.Serialization.SerializationInfo info, global::System.Runtime.Serialization.StreamingContext context)
                :
                    base(info, context)
            {
                this.InitVars();
            }

            /// <summary>
            /// 
            /// </summary>
            public DataColumn ModelDesignationNoColumn
            {
                get
                {
                    return this.columnModelDesignationNo;
                }
            }

            /// <summary>
            /// 
            /// </summary>
            public DataColumn CategoryNoColumn
            {
                get
                {
                    return this.columnCategoryNo;
                }
            }

            /// <summary>
            /// 
            /// </summary>
            public DataColumn CarProperNoColumn
            {
                get
                {
                    return this.columnCarProperNo;
                }
            }

            /// <summary>
            /// 
            /// </summary>
            public DataColumn FullModelFixedNoColumn
            {
                get
                {
                    return this.columnFullModelFixedNo;
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
            /// <param name="index"></param>
            /// <returns></returns>
            public CtgyMdlLnkInfoRow this[int index]
            {
                get
                {
                    return ((CtgyMdlLnkInfoRow)(this.Rows[index]));
                }
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="row"></param>
            public void AddCtgyMdlLnkInfoRow(CtgyMdlLnkInfoRow row)
            {
                this.Rows.Add(row);
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="ModelDesignationNo"></param>
            /// <param name="CategoryNo"></param>
            /// <param name="CarProperNo"></param>
            /// <param name="FullModelFixedNo"></param>
            /// <param name="SelectionState"></param>
            /// <returns></returns>
            public CtgyMdlLnkInfoRow AddCtgyMdlLnkInfoRow(int ModelDesignationNo, int CategoryNo, int CarProperNo, int FullModelFixedNo, bool SelectionState)
            {
                CtgyMdlLnkInfoRow rowCtgyMdlLnkInfoRow = ((CtgyMdlLnkInfoRow)(this.NewRow()));
                object[] columnValuesArray = new object[] {
                        ModelDesignationNo,
                        CategoryNo,
                        CarProperNo,
                        FullModelFixedNo,
                        SelectionState};
                rowCtgyMdlLnkInfoRow.ItemArray = columnValuesArray;
                this.Rows.Add(rowCtgyMdlLnkInfoRow);
                return rowCtgyMdlLnkInfoRow;
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
                CtgyMdlLnkInfoDataTable cln = ((CtgyMdlLnkInfoDataTable)(base.Clone()));
                cln.InitVars();
                return cln;
            }

            /// <summary>
            /// 
            /// </summary>
            /// <returns></returns>
            protected override DataTable CreateInstance()
            {
                return new CtgyMdlLnkInfoDataTable();
            }


            internal void InitVars()
            {
                this.columnModelDesignationNo = base.Columns["ModelDesignationNo"];
                this.columnCategoryNo = base.Columns["CategoryNo"];
                this.columnCarProperNo = base.Columns["CarProperNo"];
                this.columnFullModelFixedNo = base.Columns["FullModelFixedNo"];
                this.columnSelectionState = base.Columns["SelectionState"];
            }


            private void InitClass()
            {
                this.columnModelDesignationNo = new DataColumn("ModelDesignationNo", typeof(int), null, MappingType.Element);
                base.Columns.Add(this.columnModelDesignationNo);
                this.columnCategoryNo = new DataColumn("CategoryNo", typeof(int), null, MappingType.Element);
                base.Columns.Add(this.columnCategoryNo);
                this.columnCarProperNo = new DataColumn("CarProperNo", typeof(int), null, MappingType.Element);
                base.Columns.Add(this.columnCarProperNo);
                this.columnFullModelFixedNo = new DataColumn("FullModelFixedNo", typeof(int), null, MappingType.Element);
                base.Columns.Add(this.columnFullModelFixedNo);
                this.columnSelectionState = new DataColumn("SelectionState", typeof(bool), null, MappingType.Element);
                base.Columns.Add(this.columnSelectionState);
                this.columnModelDesignationNo.AllowDBNull = false;
                this.columnModelDesignationNo.Caption = "型式指定番号";
                this.columnCategoryNo.AllowDBNull = false;
                this.columnCategoryNo.Caption = "類別番号";
                this.columnCarProperNo.AllowDBNull = false;
                this.columnCarProperNo.Caption = "車輌固有番号";
                this.columnFullModelFixedNo.Caption = "フル型式固定番号";
                this.columnSelectionState.Caption = "選択状態";
                this.columnSelectionState.DefaultValue = false;
                this.CaseSensitive = true;
            }

            /// <summary>
            /// 
            /// </summary>
            /// <returns></returns>
            public CtgyMdlLnkInfoRow NewCtgyMdlLnkInfoRow()
            {
                return ((CtgyMdlLnkInfoRow)(this.NewRow()));
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="builder"></param>
            /// <returns></returns>
            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new CtgyMdlLnkInfoRow(builder);
            }

            /// <summary>
            /// 
            /// </summary>
            /// <returns></returns>
            protected override global::System.Type GetRowType()
            {
                return typeof(CtgyMdlLnkInfoRow);
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="row"></param>
            public void RemoveCtgyMdlLnkInfoRow(CtgyMdlLnkInfoRow row)
            {
                this.Rows.Remove(row);
            }

        }

        /// <summary>
        /// 
        /// </summary>
        public partial class CtgyMdlLnkInfoRow : DataRow
        {

            private CtgyMdlLnkInfoDataTable tableCtgyMdlLnkInfo;


            internal CtgyMdlLnkInfoRow(DataRowBuilder rb)
                :
                    base(rb)
            {
                this.tableCtgyMdlLnkInfo = ((CtgyMdlLnkInfoDataTable)(this.Table));
            }

            /// <summary>
            /// 
            /// </summary>
            public int ModelDesignationNo
            {
                get
                {
                    return ((int)(this[this.tableCtgyMdlLnkInfo.ModelDesignationNoColumn]));
                }
                set
                {
                    this[this.tableCtgyMdlLnkInfo.ModelDesignationNoColumn] = value;
                }
            }

            /// <summary>
            /// 
            /// </summary>
            public int CategoryNo
            {
                get
                {
                    return ((int)(this[this.tableCtgyMdlLnkInfo.CategoryNoColumn]));
                }
                set
                {
                    this[this.tableCtgyMdlLnkInfo.CategoryNoColumn] = value;
                }
            }

            /// <summary>
            /// 
            /// </summary>
            public int CarProperNo
            {
                get
                {
                    return ((int)(this[this.tableCtgyMdlLnkInfo.CarProperNoColumn]));
                }
                set
                {
                    this[this.tableCtgyMdlLnkInfo.CarProperNoColumn] = value;
                }
            }

            /// <summary>
            /// 
            /// </summary>
            public int FullModelFixedNo
            {
                get
                {
                    try
                    {
                        return ((int)(this[this.tableCtgyMdlLnkInfo.FullModelFixedNoColumn]));
                    }
                    catch (global::System.InvalidCastException e)
                    {
                        throw new StrongTypingException("テーブル \'CtgyMdlLnkInfo\' にある列 \'FullModelFixedNo\' の値は DBNull です。", e);
                    }
                }
                set
                {
                    this[this.tableCtgyMdlLnkInfo.FullModelFixedNoColumn] = value;
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
                        return ((bool)(this[this.tableCtgyMdlLnkInfo.SelectionStateColumn]));
                    }
                    catch (global::System.InvalidCastException e)
                    {
                        throw new StrongTypingException("テーブル \'CtgyMdlLnkInfo\' にある列 \'SelectionState\' の値は DBNull です。", e);
                    }
                }
                set
                {
                    this[this.tableCtgyMdlLnkInfo.SelectionStateColumn] = value;
                }
            }

            /// <summary>
            /// 
            /// </summary>
            public bool IsFullModelFixedNoNull()
            {
                return this.IsNull(this.tableCtgyMdlLnkInfo.FullModelFixedNoColumn);
            }

            /// <summary>
            /// 
            /// </summary>
            public void SetFullModelFixedNoNull()
            {
                this[this.tableCtgyMdlLnkInfo.FullModelFixedNoColumn] = global::System.Convert.DBNull;
            }

            /// <summary>
            /// 
            /// </summary>
            public bool IsSelectionStateNull()
            {
                return this.IsNull(this.tableCtgyMdlLnkInfo.SelectionStateColumn);
            }

            /// <summary>
            /// 
            /// </summary>
            public void SetSelectionStateNull()
            {
                this[this.tableCtgyMdlLnkInfo.SelectionStateColumn] = global::System.Convert.DBNull;
            }
        }

    }
}
