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
        /// 類別装備部品情報クラス
        /// </summary>
        /// <remarks>
        /// <br>Note       : 類別装備部品情報を格納するデータテーブルです。</br>
        /// <br>Programmer : 30290</br>
        /// <br>Date       : 2008.05.15</br>
        /// <br></br>
        /// <br>Update Note: </br>
        /// </remarks>
        public partial class CategoryEquipmentInfoDataTable : DataTable, IEnumerable
        {

            private DataColumn columnEquipmentGenreCd;

            private DataColumn columnEquipmentGenreNm;

            private DataColumn columnEquipmentMngCode;

            private DataColumn columnEquipmentMngName;

            private DataColumn columnEquipmentCode;

            private DataColumn columnEquipmentDispOrder;

            private DataColumn columnTbsPartsCode;

            private DataColumn columnEquipmentName;

            private DataColumn columnEquipmentShortName;

            private DataColumn columnEquipmentIconCode;

            private DataColumn columnEquipmentUnitCode;

            private DataColumn columnEquipmentUnitName;

            private DataColumn columnEquipmentCnt;

            private DataColumn columnEquipmentComment1;

            private DataColumn columnEquipmentComment2;

            private DataColumn columnSelectionState;

            /// <summary>
            /// 
            /// </summary>
            public CategoryEquipmentInfoDataTable()
            {
                this.TableName = "CategoryEquipmentInfo";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }


            internal CategoryEquipmentInfoDataTable(DataTable table)
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
            protected CategoryEquipmentInfoDataTable(global::System.Runtime.Serialization.SerializationInfo info, global::System.Runtime.Serialization.StreamingContext context)
                :
                    base(info, context)
            {
                this.InitVars();
            }

            /// <summary>
            /// 
            /// </summary>
            public DataColumn EquipmentGenreCdColumn
            {
                get
                {
                    return this.columnEquipmentGenreCd;
                }
            }

            /// <summary>
            /// 
            /// </summary>
            public DataColumn EquipmentGenreNmColumn
            {
                get
                {
                    return this.columnEquipmentGenreNm;
                }
            }

            /// <summary>
            /// 
            /// </summary>
            public DataColumn EquipmentMngCodeColumn
            {
                get
                {
                    return this.columnEquipmentMngCode;
                }
            }

            /// <summary>
            /// 
            /// </summary>
            public DataColumn EquipmentMngNameColumn
            {
                get
                {
                    return this.columnEquipmentMngName;
                }
            }

            /// <summary>
            /// 
            /// </summary>
            public DataColumn EquipmentCodeColumn
            {
                get
                {
                    return this.columnEquipmentCode;
                }
            }

            /// <summary>
            /// 
            /// </summary>
            public DataColumn EquipmentDispOrderColumn
            {
                get
                {
                    return this.columnEquipmentDispOrder;
                }
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
            public DataColumn EquipmentNameColumn
            {
                get
                {
                    return this.columnEquipmentName;
                }
            }

            /// <summary>
            /// 
            /// </summary>
            public DataColumn EquipmentShortNameColumn
            {
                get
                {
                    return this.columnEquipmentShortName;
                }
            }

            /// <summary>
            /// 
            /// </summary>
            public DataColumn EquipmentIconCodeColumn
            {
                get
                {
                    return this.columnEquipmentIconCode;
                }
            }

            /// <summary>
            /// 
            /// </summary>
            public DataColumn EquipmentUnitCodeColumn
            {
                get
                {
                    return this.columnEquipmentUnitCode;
                }
            }

            /// <summary>
            /// 
            /// </summary>
            public DataColumn EquipmentUnitNameColumn
            {
                get
                {
                    return this.columnEquipmentUnitName;
                }
            }

            /// <summary>
            /// 
            /// </summary>
            public DataColumn EquipmentCntColumn
            {
                get
                {
                    return this.columnEquipmentCnt;
                }
            }

            /// <summary>
            /// 
            /// </summary>
            public DataColumn EquipmentComment1Column
            {
                get
                {
                    return this.columnEquipmentComment1;
                }
            }

            /// <summary>
            /// 
            /// </summary>
            public DataColumn EquipmentComment2Column
            {
                get
                {
                    return this.columnEquipmentComment2;
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
            public CategoryEquipmentInfoRow this[int index]
            {
                get
                {
                    return ((CategoryEquipmentInfoRow)(this.Rows[index]));
                }
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="row"></param>
            public void AddCategoryEquipmentInfoRow(CategoryEquipmentInfoRow row)
            {
                this.Rows.Add(row);
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="EquipmentGenreCd"></param>
            /// <param name="EquipmentGenreNm"></param>
            /// <param name="EquipmentMngCode"></param>
            /// <param name="EquipmentMngName"></param>
            /// <param name="EquipmentCode"></param>
            /// <param name="EquipmentDispOrder"></param>
            /// <param name="TbsPartsCode"></param>
            /// <param name="EquipmentName"></param>
            /// <param name="EquipmentShortName"></param>
            /// <param name="EquipmentIconCode"></param>
            /// <param name="EquipmentUnitCode"></param>
            /// <param name="EquipmentUnitName"></param>
            /// <param name="EquipmentCnt"></param>
            /// <param name="EquipmentComment1"></param>
            /// <param name="EquipmentComment2"></param>
            /// <param name="SelectionState"></param>
            /// <returns></returns>
            public CategoryEquipmentInfoRow AddCategoryEquipmentInfoRow(
                        int EquipmentGenreCd,
                        string EquipmentGenreNm,
                        int EquipmentMngCode,
                        string EquipmentMngName,
                        int EquipmentCode,
                        int EquipmentDispOrder,
                        int TbsPartsCode,
                        string EquipmentName,
                        string EquipmentShortName,
                        int EquipmentIconCode,
                        int EquipmentUnitCode,
                        string EquipmentUnitName,
                        double EquipmentCnt,
                        string EquipmentComment1,
                        string EquipmentComment2,
                        bool SelectionState)
            {
                CategoryEquipmentInfoRow rowCategoryEquipmentInfoRow = ((CategoryEquipmentInfoRow)(this.NewRow()));
                object[] columnValuesArray = new object[] {
                        EquipmentGenreCd,
                        EquipmentGenreNm,
                        EquipmentMngCode,
                        EquipmentMngName,
                        EquipmentCode,
                        EquipmentDispOrder,
                        TbsPartsCode,
                        EquipmentName,
                        EquipmentShortName,
                        EquipmentIconCode,
                        EquipmentUnitCode,
                        EquipmentUnitName,
                        EquipmentCnt,
                        EquipmentComment1,
                        EquipmentComment2,
                        SelectionState};
                rowCategoryEquipmentInfoRow.ItemArray = columnValuesArray;
                this.Rows.Add(rowCategoryEquipmentInfoRow);
                return rowCategoryEquipmentInfoRow;
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
                CategoryEquipmentInfoDataTable cln = ((CategoryEquipmentInfoDataTable)(base.Clone()));
                cln.InitVars();
                return cln;
            }

            /// <summary>
            /// 
            /// </summary>
            /// <returns></returns>
            protected override DataTable CreateInstance()
            {
                return new CategoryEquipmentInfoDataTable();
            }


            internal void InitVars()
            {
                this.columnEquipmentGenreCd = base.Columns["EquipmentGenreCd"];
                this.columnEquipmentGenreNm = base.Columns["EquipmentGenreNm"];
                this.columnEquipmentMngCode = base.Columns["EquipmentMngCode"];
                this.columnEquipmentMngName = base.Columns["EquipmentMngName"];
                this.columnEquipmentCode = base.Columns["EquipmentCode"];
                this.columnEquipmentDispOrder = base.Columns["EquipmentDispOrder"];
                this.columnTbsPartsCode = base.Columns["TbsPartsCode"];
                this.columnEquipmentName = base.Columns["EquipmentName"];
                this.columnEquipmentShortName = base.Columns["EquipmentShortName"];
                this.columnEquipmentIconCode = base.Columns["EquipmentIconCode"];
                this.columnEquipmentUnitCode = base.Columns["EquipmentUnitCode"];
                this.columnEquipmentUnitName = base.Columns["EquipmentUnitName"];
                this.columnEquipmentCnt = base.Columns["EquipmentCnt"];
                this.columnEquipmentComment1 = base.Columns["EquipmentComment1"];
                this.columnEquipmentComment2 = base.Columns["EquipmentComment2"];
                this.columnSelectionState = base.Columns["SelectionState"];
            }


            private void InitClass()
            {
                this.columnEquipmentGenreCd = new DataColumn("EquipmentGenreCd", typeof(int), null, MappingType.Element);
                base.Columns.Add(this.columnEquipmentGenreCd);
                this.columnEquipmentGenreNm = new DataColumn("EquipmentGenreNm", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnEquipmentGenreNm);
                this.columnEquipmentMngCode = new DataColumn("EquipmentMngCode", typeof(int), null, MappingType.Element);
                base.Columns.Add(this.columnEquipmentMngCode);
                this.columnEquipmentMngName = new DataColumn("EquipmentMngName", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnEquipmentMngName);
                this.columnEquipmentCode = new DataColumn("EquipmentCode", typeof(int), null, MappingType.Element);
                base.Columns.Add(this.columnEquipmentCode);
                this.columnEquipmentDispOrder = new DataColumn("EquipmentDispOrder", typeof(int), null, MappingType.Element);
                base.Columns.Add(this.columnEquipmentDispOrder);
                this.columnTbsPartsCode = new DataColumn("TbsPartsCode", typeof(int), null, MappingType.Element);
                base.Columns.Add(this.columnTbsPartsCode);
                this.columnEquipmentName = new DataColumn("EquipmentName", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnEquipmentName);
                this.columnEquipmentShortName = new DataColumn("EquipmentShortName", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnEquipmentShortName);
                this.columnEquipmentIconCode = new DataColumn("EquipmentIconCode", typeof(int), null, MappingType.Element);
                base.Columns.Add(this.columnEquipmentIconCode);
                this.columnEquipmentUnitCode = new DataColumn("EquipmentUnitCode", typeof(int), null, MappingType.Element);
                base.Columns.Add(this.columnEquipmentUnitCode);
                this.columnEquipmentUnitName = new DataColumn("EquipmentUnitName", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnEquipmentUnitName);
                this.columnEquipmentCnt = new DataColumn("EquipmentCnt", typeof(double), null, MappingType.Element);
                base.Columns.Add(this.columnEquipmentCnt);
                this.columnEquipmentComment1 = new DataColumn("EquipmentComment1", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnEquipmentComment1);
                this.columnEquipmentComment2 = new DataColumn("EquipmentComment2", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnEquipmentComment2);
                this.columnSelectionState = new DataColumn("SelectionState", typeof(bool), null, MappingType.Element);
                base.Columns.Add(this.columnSelectionState);
                this.columnEquipmentGenreCd.AllowDBNull = false;
                this.columnEquipmentGenreCd.Caption = "装備分類コード";
                this.columnEquipmentGenreNm.Caption = "装備名称"; //"装備分類名称";
                this.columnEquipmentGenreNm.MaxLength = 30;
                this.columnEquipmentMngCode.AllowDBNull = false;
                this.columnEquipmentMngCode.Caption = "装備管理区分コード";
                this.columnEquipmentMngName.Caption = "区分"; //"装備管理区分名称";
                this.columnEquipmentMngName.MaxLength = 6;
                this.columnEquipmentCode.AllowDBNull = false;
                this.columnEquipmentCode.Caption = "装備コード";
                this.columnEquipmentDispOrder.AllowDBNull = false;
                this.columnEquipmentDispOrder.Caption = "装備表示順位";
                this.columnTbsPartsCode.Caption = "BLコード";
                this.columnEquipmentName.Caption = "装備名称";
                this.columnEquipmentName.MaxLength = 60;
                this.columnEquipmentShortName.Caption = "装備略称";
                this.columnEquipmentShortName.MaxLength = 30;
                this.columnEquipmentIconCode.Caption = "装備ICONコード";
                this.columnEquipmentUnitCode.Caption = "装備単位コード";
                this.columnEquipmentUnitName.Caption = "単位";//"装備単位名称";
                this.columnEquipmentUnitName.MaxLength = 10;
                this.columnEquipmentCnt.Caption = "数量"; //"装備数量";
                this.columnEquipmentComment1.Caption = "コメント"; //"装備コメント1";
                this.columnEquipmentComment1.MaxLength = 60;
                this.columnEquipmentComment2.Caption = "装備コメント2";
                this.columnEquipmentComment2.MaxLength = 60;
                this.columnSelectionState.Caption = "選択状態";
                this.columnSelectionState.DefaultValue = false;
                this.CaseSensitive = true;
            }

            /// <summary>
            /// 
            /// </summary>
            /// <returns></returns>
            public CategoryEquipmentInfoRow NewCategoryEquipmentInfoRow()
            {
                return ((CategoryEquipmentInfoRow)(this.NewRow()));
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="builder"></param>
            /// <returns></returns>
            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new CategoryEquipmentInfoRow(builder);
            }

            /// <summary>
            /// 
            /// </summary>
            /// <returns></returns>
            protected override global::System.Type GetRowType()
            {
                return typeof(CategoryEquipmentInfoRow);
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="row"></param>
            public void RemoveCategoryEquipmentInfoRow(CategoryEquipmentInfoRow row)
            {
                this.Rows.Remove(row);
            }

        }

        /// <summary>
        /// 
        /// </summary>
        public partial class CategoryEquipmentInfoRow : DataRow
        {

            private CategoryEquipmentInfoDataTable tableCategoryEquipmentInfo;


            internal CategoryEquipmentInfoRow(DataRowBuilder rb)
                :
                    base(rb)
            {
                this.tableCategoryEquipmentInfo = ((CategoryEquipmentInfoDataTable)(this.Table));
            }

            /// <summary>
            /// 
            /// </summary>
            public int EquipmentGenreCd
            {
                get
                {
                    return ((int)(this[this.tableCategoryEquipmentInfo.EquipmentGenreCdColumn]));
                }
                set
                {
                    this[this.tableCategoryEquipmentInfo.EquipmentGenreCdColumn] = value;
                }
            }

            /// <summary>
            /// 
            /// </summary>
            public string EquipmentGenreNm
            {
                get
                {
                    if (this.IsEquipmentGenreNmNull())
                    {
                        return string.Empty;
                    }
                    else
                    {
                        return ((string)(this[this.tableCategoryEquipmentInfo.EquipmentGenreNmColumn]));
                    }
                }
                set
                {
                    this[this.tableCategoryEquipmentInfo.EquipmentGenreNmColumn] = value;
                }
            }

            /// <summary>
            /// 
            /// </summary>
            public int EquipmentMngCode
            {
                get
                {
                    return ((int)(this[this.tableCategoryEquipmentInfo.EquipmentMngCodeColumn]));
                }
                set
                {
                    this[this.tableCategoryEquipmentInfo.EquipmentMngCodeColumn] = value;
                }
            }

            /// <summary>
            /// 
            /// </summary>
            public string EquipmentMngName
            {
                get
                {
                    if (this.IsEquipmentMngNameNull())
                    {
                        return string.Empty;
                    }
                    else
                    {
                        return ((string)(this[this.tableCategoryEquipmentInfo.EquipmentMngNameColumn]));
                    }
                }
                set
                {
                    this[this.tableCategoryEquipmentInfo.EquipmentMngNameColumn] = value;
                }
            }

            /// <summary>
            /// 
            /// </summary>
            public int EquipmentCode
            {
                get
                {
                    return ((int)(this[this.tableCategoryEquipmentInfo.EquipmentCodeColumn]));
                }
                set
                {
                    this[this.tableCategoryEquipmentInfo.EquipmentCodeColumn] = value;
                }
            }

            /// <summary>
            /// 
            /// </summary>
            public int EquipmentDispOrder
            {
                get
                {
                    return ((int)(this[this.tableCategoryEquipmentInfo.EquipmentDispOrderColumn]));
                }
                set
                {
                    this[this.tableCategoryEquipmentInfo.EquipmentDispOrderColumn] = value;
                }
            }

            /// <summary>
            /// 
            /// </summary>
            public int TbsPartsCode
            {
                get
                {
                    try
                    {
                        return ((int)(this[this.tableCategoryEquipmentInfo.TbsPartsCodeColumn]));
                    }
                    catch (global::System.InvalidCastException e)
                    {
                        throw new StrongTypingException("テーブル \'CategoryEquipmentInfo\' にある列 \'TbsPartsCode\' の値は DBNull です。", e);
                    }
                }
                set
                {
                    this[this.tableCategoryEquipmentInfo.TbsPartsCodeColumn] = value;
                }
            }

            /// <summary>
            /// 
            /// </summary>
            public string EquipmentName
            {
                get
                {
                    if (this.IsEquipmentNameNull())
                    {
                        return string.Empty;
                    }
                    else
                    {
                        return ((string)(this[this.tableCategoryEquipmentInfo.EquipmentNameColumn]));
                    }
                }
                set
                {
                    this[this.tableCategoryEquipmentInfo.EquipmentNameColumn] = value;
                }
            }

            /// <summary>
            /// 
            /// </summary>
            public string EquipmentShortName
            {
                get
                {
                    if (this.IsEquipmentShortNameNull())
                    {
                        return string.Empty;
                    }
                    else
                    {
                        return ((string)(this[this.tableCategoryEquipmentInfo.EquipmentShortNameColumn]));
                    }
                }
                set
                {
                    this[this.tableCategoryEquipmentInfo.EquipmentShortNameColumn] = value;
                }
            }

            /// <summary>
            /// 
            /// </summary>
            public int EquipmentIconCode
            {
                get
                {
                    try
                    {
                        return ((int)(this[this.tableCategoryEquipmentInfo.EquipmentIconCodeColumn]));
                    }
                    catch (global::System.InvalidCastException e)
                    {
                        throw new StrongTypingException("テーブル \'CategoryEquipmentInfo\' にある列 \'EquipmentIconCode\' の値は DBNull です。", e);
                    }
                }
                set
                {
                    this[this.tableCategoryEquipmentInfo.EquipmentIconCodeColumn] = value;
                }
            }

            /// <summary>
            /// 
            /// </summary>
            public int EquipmentUnitCode
            {
                get
                {
                    try
                    {
                        return ((int)(this[this.tableCategoryEquipmentInfo.EquipmentUnitCodeColumn]));
                    }
                    catch (global::System.InvalidCastException e)
                    {
                        throw new StrongTypingException("テーブル \'CategoryEquipmentInfo\' にある列 \'EquipmentUnitCode\' の値は DBNull です。", e);
                    }
                }
                set
                {
                    this[this.tableCategoryEquipmentInfo.EquipmentUnitCodeColumn] = value;
                }
            }

            /// <summary>
            /// 
            /// </summary>
            public string EquipmentUnitName
            {
                get
                {
                    if (this.IsEquipmentUnitNameNull())
                    {
                        return string.Empty;
                    }
                    else
                    {
                        return ((string)(this[this.tableCategoryEquipmentInfo.EquipmentUnitNameColumn]));
                    }
                }
                set
                {
                    this[this.tableCategoryEquipmentInfo.EquipmentUnitNameColumn] = value;
                }
            }

            /// <summary>
            /// 
            /// </summary>
            public double EquipmentCnt
            {
                get
                {
                    try
                    {
                        return ((double)(this[this.tableCategoryEquipmentInfo.EquipmentCntColumn]));
                    }
                    catch (global::System.InvalidCastException e)
                    {
                        throw new StrongTypingException("テーブル \'CategoryEquipmentInfo\' にある列 \'EquipmentCnt\' の値は DBNull です。", e);
                    }
                }
                set
                {
                    this[this.tableCategoryEquipmentInfo.EquipmentCntColumn] = value;
                }
            }

            /// <summary>
            /// 
            /// </summary>
            public string EquipmentComment1
            {
                get
                {
                    if (this.IsEquipmentComment1Null())
                    {
                        return string.Empty;
                    }
                    else
                    {
                        return ((string)(this[this.tableCategoryEquipmentInfo.EquipmentComment1Column]));
                    }
                }
                set
                {
                    this[this.tableCategoryEquipmentInfo.EquipmentComment1Column] = value;
                }
            }

            /// <summary>
            /// 
            /// </summary>
            public string EquipmentComment2
            {
                get
                {
                    if (this.IsEquipmentComment2Null())
                    {
                        return string.Empty;
                    }
                    else
                    {
                        return ((string)(this[this.tableCategoryEquipmentInfo.EquipmentComment2Column]));
                    }
                }
                set
                {
                    this[this.tableCategoryEquipmentInfo.EquipmentComment2Column] = value;
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
                        return ((bool)(this[this.tableCategoryEquipmentInfo.SelectionStateColumn]));
                    }
                    catch (global::System.InvalidCastException e)
                    {
                        throw new StrongTypingException("テーブル \'CategoryEquipmentInfo\' にある列 \'SelectionState\' の値は DBNull です。", e);
                    }
                }
                set
                {
                    this[this.tableCategoryEquipmentInfo.SelectionStateColumn] = value;
                }
            }

            /// <summary>
            /// 
            /// </summary>
            /// <returns></returns>
            public bool IsEquipmentGenreNmNull()
            {
                return this.IsNull(this.tableCategoryEquipmentInfo.EquipmentGenreNmColumn);
            }

            /// <summary>
            /// 
            /// </summary>
            public void SetEquipmentGenreNmNull()
            {
                this[this.tableCategoryEquipmentInfo.EquipmentGenreNmColumn] = global::System.Convert.DBNull;
            }

            /// <summary>
            /// 
            /// </summary>
            /// <returns></returns>
            public bool IsEquipmentMngNameNull()
            {
                return this.IsNull(this.tableCategoryEquipmentInfo.EquipmentMngNameColumn);
            }

            /// <summary>
            /// 
            /// </summary>
            public void SetEquipmentMngNameNull()
            {
                this[this.tableCategoryEquipmentInfo.EquipmentMngNameColumn] = global::System.Convert.DBNull;
            }

            /// <summary>
            /// 
            /// </summary>
            /// <returns></returns>
            public bool IsTbsPartsCodeNull()
            {
                return this.IsNull(this.tableCategoryEquipmentInfo.TbsPartsCodeColumn);
            }

            /// <summary>
            /// 
            /// </summary>
            public void SetTbsPartsCodeNull()
            {
                this[this.tableCategoryEquipmentInfo.TbsPartsCodeColumn] = global::System.Convert.DBNull;
            }

            /// <summary>
            /// 
            /// </summary>
            /// <returns></returns>
            public bool IsEquipmentNameNull()
            {
                return this.IsNull(this.tableCategoryEquipmentInfo.EquipmentNameColumn);
            }

            /// <summary>
            /// 
            /// </summary>
            public void SetEquipmentNameNull()
            {
                this[this.tableCategoryEquipmentInfo.EquipmentNameColumn] = global::System.Convert.DBNull;
            }

            /// <summary>
            /// 
            /// </summary>
            /// <returns></returns>
            public bool IsEquipmentShortNameNull()
            {
                return this.IsNull(this.tableCategoryEquipmentInfo.EquipmentShortNameColumn);
            }

            /// <summary>
            /// 
            /// </summary>
            public void SetEquipmentShortNameNull()
            {
                this[this.tableCategoryEquipmentInfo.EquipmentShortNameColumn] = global::System.Convert.DBNull;
            }

            /// <summary>
            /// 
            /// </summary>
            /// <returns></returns>
            public bool IsEquipmentIconCodeNull()
            {
                return this.IsNull(this.tableCategoryEquipmentInfo.EquipmentIconCodeColumn);
            }

            /// <summary>
            /// 
            /// </summary>
            public void SetEquipmentIconCodeNull()
            {
                this[this.tableCategoryEquipmentInfo.EquipmentIconCodeColumn] = global::System.Convert.DBNull;
            }

            /// <summary>
            /// 
            /// </summary>
            /// <returns></returns>
            public bool IsEquipmentUnitCodeNull()
            {
                return this.IsNull(this.tableCategoryEquipmentInfo.EquipmentUnitCodeColumn);
            }

            /// <summary>
            /// 
            /// </summary>
            public void SetEquipmentUnitCodeNull()
            {
                this[this.tableCategoryEquipmentInfo.EquipmentUnitCodeColumn] = global::System.Convert.DBNull;
            }

            /// <summary>
            /// 
            /// </summary>
            /// <returns></returns>
            public bool IsEquipmentUnitNameNull()
            {
                return this.IsNull(this.tableCategoryEquipmentInfo.EquipmentUnitNameColumn);
            }

            /// <summary>
            /// 
            /// </summary>
            public void SetEquipmentUnitNameNull()
            {
                this[this.tableCategoryEquipmentInfo.EquipmentUnitNameColumn] = global::System.Convert.DBNull;
            }

            /// <summary>
            /// 
            /// </summary>
            /// <returns></returns>
            public bool IsEquipmentCntNull()
            {
                return this.IsNull(this.tableCategoryEquipmentInfo.EquipmentCntColumn);
            }

            /// <summary>
            /// 
            /// </summary>
            public void SetEquipmentCntNull()
            {
                this[this.tableCategoryEquipmentInfo.EquipmentCntColumn] = global::System.Convert.DBNull;
            }

            /// <summary>
            /// 
            /// </summary>
            /// <returns></returns>
            public bool IsEquipmentComment1Null()
            {
                return this.IsNull(this.tableCategoryEquipmentInfo.EquipmentComment1Column);
            }

            /// <summary>
            /// 
            /// </summary>
            public void SetEquipmentComment1Null()
            {
                this[this.tableCategoryEquipmentInfo.EquipmentComment1Column] = global::System.Convert.DBNull;
            }

            /// <summary>
            /// 
            /// </summary>
            /// <returns></returns>
            public bool IsEquipmentComment2Null()
            {
                return this.IsNull(this.tableCategoryEquipmentInfo.EquipmentComment2Column);
            }

            /// <summary>
            /// 
            /// </summary>
            public void SetEquipmentComment2Null()
            {
                this[this.tableCategoryEquipmentInfo.EquipmentComment2Column] = global::System.Convert.DBNull;
            }

            /// <summary>
            /// 
            /// </summary>
            /// <returns></returns>
            public bool IsSelectionStateNull()
            {
                return this.IsNull(this.tableCategoryEquipmentInfo.SelectionStateColumn);
            }

            /// <summary>
            /// 
            /// </summary>
            public void SetSelectionStateNull()
            {
                this[this.tableCategoryEquipmentInfo.SelectionStateColumn] = global::System.Convert.DBNull;
            }
        }
    }
}
