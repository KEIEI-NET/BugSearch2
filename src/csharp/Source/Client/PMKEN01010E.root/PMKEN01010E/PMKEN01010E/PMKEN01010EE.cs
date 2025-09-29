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
        /// カラー情報クラス
        /// </summary>
        /// <remarks>
        /// <br>Note       : カラー情報を格納するデータテーブルです。</br>
        /// <br>Programmer : 30290</br>
        /// <br>Date       : 2008.05.15</br>
        /// <br></br>
        /// <br>Update Note: </br>
        /// </remarks>
        public partial class ColorCdInfoDataTable : DataTable, IEnumerable
        {

            private DataColumn columnMakerCode;

            private DataColumn columnModelCode;

            private DataColumn columnModelSubCode;
/*
            private DataColumn columnSystematicCode;

            private DataColumn columnProduceTypeOfYearCd;
*/
            private DataColumn columnColorCode;
/*
            private DataColumn columnColorCdDupDerivedNo;
*/
            private DataColumn columnColorName1;

            private DataColumn columnSelectionState;

            /// <summary>
            /// 
            /// </summary>
            public ColorCdInfoDataTable()
            {
                this.TableName = "ColorCdInfo";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }


            internal ColorCdInfoDataTable(DataTable table)
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
            protected ColorCdInfoDataTable(global::System.Runtime.Serialization.SerializationInfo info, global::System.Runtime.Serialization.StreamingContext context)
                :
                    base(info, context)
            {
                this.InitVars();
            }

            /// <summary>
            /// 
            /// </summary>
            public DataColumn MakerCodeColumn
            {
                get
                {
                    return this.columnMakerCode;
                }
            }

            /// <summary>
            /// 
            /// </summary>
            public DataColumn ModelCodeColumn
            {
                get
                {
                    return this.columnModelCode;
                }
            }

            /// <summary>
            /// 
            /// </summary>
            public DataColumn ModelSubCodeColumn
            {
                get
                {
                    return this.columnModelSubCode;
                }
            }
/*
            /// <summary>
            /// 
            /// </summary>
            public DataColumn SystematicCodeColumn
            {
                get
                {
                    return this.columnSystematicCode;
                }
            }

            /// <summary>
            /// 
            /// </summary>
            public DataColumn ProduceTypeOfYearCdColumn
            {
                get
                {
                    return this.columnProduceTypeOfYearCd;
                }
            }
*/
            /// <summary>
            /// 
            /// </summary>
            public DataColumn ColorCodeColumn
            {
                get
                {
                    return this.columnColorCode;
                }
            }
/*
            /// <summary>
            /// 
            /// </summary>
            public DataColumn ColorCdDupDerivedNoColumn
            {
                get
                {
                    return this.columnColorCdDupDerivedNo;
                }
            }
*/
            /// <summary>
            /// 
            /// </summary>
            public DataColumn ColorName1Column
            {
                get
                {
                    return this.columnColorName1;
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
            public ColorCdInfoRow this[int index]
            {
                get
                {
                    return ((ColorCdInfoRow)(this.Rows[index]));
                }
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="row"></param>
            public void AddColorCdInfoRow(ColorCdInfoRow row)
            {
                this.Rows.Add(row);
            }
            /// <summary>
            /// 
            /// </summary>
            /// <param name="MakerCode"></param>
            /// <param name="ModelCode"></param>
            /// <param name="ModelSubCode"></param>
            /// <param name="ColorCode"></param>
            /// <param name="ColorName1"></param>
            /// <param name="SelectionState"></param>
            /// <returns></returns>
            public ColorCdInfoRow AddColorCdInfoRow(int MakerCode, int ModelCode, int ModelSubCode, 
                string ColorCode, string ColorName1, bool SelectionState)
            {
                ColorCdInfoRow rowColorCdInfoRow = ((ColorCdInfoRow)(this.NewRow()));
                object[] columnValuesArray = new object[] {
                        MakerCode,
                        ModelCode,
                        ModelSubCode,
                        ColorCode,
                        ColorName1,
                        SelectionState};
                rowColorCdInfoRow.ItemArray = columnValuesArray;
                this.Rows.Add(rowColorCdInfoRow);
                return rowColorCdInfoRow;
            }
/*
            /// <summary>
            /// 
            /// </summary>
            /// <param name="MakerCode"></param>
            /// <param name="ModelCode"></param>
            /// <param name="ModelSubCode"></param>
            /// <param name="SystematicCode"></param>
            /// <param name="ProduceTypeOfYearCd"></param>
            /// <param name="ColorCode"></param>
            /// <param name="ColorCdDupDerivedNo"></param>
            /// <param name="ColorName1"></param>
            /// <param name="SelectionState"></param>
            /// <returns></returns>
            public ColorCdInfoRow AddColorCdInfoRow(int MakerCode, int ModelCode, int ModelSubCode, int SystematicCode, int ProduceTypeOfYearCd, string ColorCode, int ColorCdDupDerivedNo, string ColorName1, bool SelectionState)
            {
                ColorCdInfoRow rowColorCdInfoRow = ((ColorCdInfoRow)(this.NewRow()));
                object[] columnValuesArray = new object[] {
                        MakerCode,
                        ModelCode,
                        ModelSubCode,
                        SystematicCode,
                        ProduceTypeOfYearCd,
                        ColorCode,
                        ColorCdDupDerivedNo,
                        ColorName1,
                        SelectionState};
                rowColorCdInfoRow.ItemArray = columnValuesArray;
                this.Rows.Add(rowColorCdInfoRow);
                return rowColorCdInfoRow;
            }
*/
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
                ColorCdInfoDataTable cln = ((ColorCdInfoDataTable)(base.Clone()));
                cln.InitVars();
                return cln;
            }

            /// <summary>
            /// 
            /// </summary>
            /// <returns></returns>
            protected override DataTable CreateInstance()
            {
                return new ColorCdInfoDataTable();
            }


            internal void InitVars()
            {
                this.columnMakerCode = base.Columns["MakerCode"];
                this.columnModelCode = base.Columns["ModelCode"];
                this.columnModelSubCode = base.Columns["ModelSubCode"];
                //this.columnSystematicCode = base.Columns["SystematicCode"];
                //this.columnProduceTypeOfYearCd = base.Columns["ProduceTypeOfYearCd"];
                this.columnColorCode = base.Columns["ColorCode"];
                //this.columnColorCdDupDerivedNo = base.Columns["ColorCdDupDerivedNo"];
                this.columnColorName1 = base.Columns["ColorName1"];
                this.columnSelectionState = base.Columns["SelectionState"];
            }

            private void InitClass()
            {
                this.columnMakerCode = new DataColumn("MakerCode", typeof(int), null, MappingType.Element);
                base.Columns.Add(this.columnMakerCode);
                this.columnModelCode = new DataColumn("ModelCode", typeof(int), null, MappingType.Element);
                base.Columns.Add(this.columnModelCode);
                this.columnModelSubCode = new DataColumn("ModelSubCode", typeof(int), null, MappingType.Element);
                base.Columns.Add(this.columnModelSubCode);
                /*this.columnSystematicCode = new DataColumn("SystematicCode", typeof(int), null, MappingType.Element);
                base.Columns.Add(this.columnSystematicCode);
                this.columnProduceTypeOfYearCd = new DataColumn("ProduceTypeOfYearCd", typeof(int), null, MappingType.Element);
                base.Columns.Add(this.columnProduceTypeOfYearCd);*/
                this.columnColorCode = new DataColumn("ColorCode", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnColorCode);
                /*this.columnColorCdDupDerivedNo = new DataColumn("ColorCdDupDerivedNo", typeof(int), null, MappingType.Element);
                base.Columns.Add(this.columnColorCdDupDerivedNo);*/
                this.columnColorName1 = new DataColumn("ColorName1", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnColorName1);
                this.columnSelectionState = new DataColumn("SelectionState", typeof(bool), null, MappingType.Element);
                base.Columns.Add(this.columnSelectionState);
                this.columnMakerCode.AllowDBNull = false;
                this.columnMakerCode.Caption = "メーカーコード";
                this.columnModelCode.AllowDBNull = false;
                this.columnModelCode.Caption = "車種コード";
                this.columnModelSubCode.AllowDBNull = false;
                this.columnModelSubCode.Caption = "車種サブコード";
                /*this.columnSystematicCode.AllowDBNull = false;
                this.columnSystematicCode.Caption = "系統コード";
                this.columnProduceTypeOfYearCd.AllowDBNull = false;
                this.columnProduceTypeOfYearCd.Caption = "生産年式コード";*/
                this.columnColorCode.AllowDBNull = false;
                this.columnColorCode.Caption = "カラーコード";
                this.columnColorCode.MaxLength = 20;
                /*this.columnColorCdDupDerivedNo.AllowDBNull = false;
                this.columnColorCdDupDerivedNo.Caption = "カラーコード重複時枝番";*/
                this.columnColorName1.Caption = "カラー名称";
                this.columnColorName1.MaxLength = 40;
                this.columnColorName1.DefaultValue = string.Empty;
                this.columnSelectionState.Caption = "選択状態";
                this.columnSelectionState.DefaultValue = false;
                this.CaseSensitive = true;
            }

            /// <summary>
            /// 
            /// </summary>
            /// <returns></returns>
            public ColorCdInfoRow NewColorCdInfoRow()
            {
                return ((ColorCdInfoRow)(this.NewRow()));
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="builder"></param>
            /// <returns></returns>
            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new ColorCdInfoRow(builder);
            }

            /// <summary>
            /// 
            /// </summary>
            /// <returns></returns>
            protected override global::System.Type GetRowType()
            {
                return typeof(ColorCdInfoRow);
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="row"></param>
            public void RemoveColorCdInfoRow(ColorCdInfoRow row)
            {
                this.Rows.Remove(row);
            }


            /// <summary>
            /// トリムデータテーブルと同一データを持つArrayListを返す。
            /// </summary>
            /// <param name="selectedRowOnly">True:[選択状態]がtrueのデータのみArrayListに入れる/False:全て</param>
            /// <returns>ArrayList[TrimCdRetWork]</returns>
            public ArrayList GetArrayList(bool selectedRowOnly)
            {
                ArrayList list = new ArrayList();
                int count = Rows.Count;
                for (int i = 0; i < count; i++)
                {
                    ColorCdInfoRow colorRow = (ColorCdInfoRow)Rows[i];
                    if (selectedRowOnly && colorRow.SelectionState == false)
                        continue;
                    ColorCdRetWork work = new ColorCdRetWork();
                    //work.MakerCode = colorRow.MakerCode;
                    //work.ModelCode = colorRow.ModelCode;
                    //work.ModelSubCode = colorRow.ModelSubCode;
                    //work.ProduceTypeOfYearCd = colorRow.ProduceTypeOfYearCd;
                    //work.SystematicCode = colorRow.SystematicCode;
                    work.ColorCode = colorRow.ColorCode;
                    //work.ColorCdDupDerivedNo = colorRow.ColorCdDupDerivedNo;
                    work.ColorName = colorRow.ColorName1;
                }

                return list;
            }

        }

        /// <summary>
        /// 
        /// </summary>
        public partial class ColorCdInfoRow : DataRow
        {

            private ColorCdInfoDataTable tableColorCdInfo;


            internal ColorCdInfoRow(DataRowBuilder rb)
                :
                    base(rb)
            {
                this.tableColorCdInfo = ((ColorCdInfoDataTable)(this.Table));
            }

            /// <summary>
            /// 
            /// </summary>
            public int MakerCode
            {
                get
                {
                    return ((int)(this[this.tableColorCdInfo.MakerCodeColumn]));
                }
                set
                {
                    this[this.tableColorCdInfo.MakerCodeColumn] = value;
                }
            }

            /// <summary>
            /// 
            /// </summary>
            public int ModelCode
            {
                get
                {
                    return ((int)(this[this.tableColorCdInfo.ModelCodeColumn]));
                }
                set
                {
                    this[this.tableColorCdInfo.ModelCodeColumn] = value;
                }
            }

            /// <summary>
            /// 
            /// </summary>
            public int ModelSubCode
            {
                get
                {
                    return ((int)(this[this.tableColorCdInfo.ModelSubCodeColumn]));
                }
                set
                {
                    this[this.tableColorCdInfo.ModelSubCodeColumn] = value;
                }
            }
/*
            /// <summary>
            /// 
            /// </summary>
            public int SystematicCode
            {
                get
                {
                    return ((int)(this[this.tableColorCdInfo.SystematicCodeColumn]));
                }
                set
                {
                    this[this.tableColorCdInfo.SystematicCodeColumn] = value;
                }
            }

            /// <summary>
            /// 
            /// </summary>
            public int ProduceTypeOfYearCd
            {
                get
                {
                    return ((int)(this[this.tableColorCdInfo.ProduceTypeOfYearCdColumn]));
                }
                set
                {
                    this[this.tableColorCdInfo.ProduceTypeOfYearCdColumn] = value;
                }
            }
*/
            /// <summary>
            /// 
            /// </summary>
            public string ColorCode
            {
                get
                {
                    return ((string)(this[this.tableColorCdInfo.ColorCodeColumn]));
                }
                set
                {
                    this[this.tableColorCdInfo.ColorCodeColumn] = value;
                }
            }
/*
            /// <summary>
            /// 
            /// </summary>
            public int ColorCdDupDerivedNo
            {
                get
                {
                    return ((int)(this[this.tableColorCdInfo.ColorCdDupDerivedNoColumn]));
                }
                set
                {
                    this[this.tableColorCdInfo.ColorCdDupDerivedNoColumn] = value;
                }
            }
*/
            /// <summary>
            /// 
            /// </summary>
            public string ColorName1
            {
                get
                {
                    if (this.IsColorName1Null())
                    {
                        return string.Empty;
                    }
                    else
                    {
                        return ((string)(this[this.tableColorCdInfo.ColorName1Column]));
                    }
                }
                set
                {
                    this[this.tableColorCdInfo.ColorName1Column] = value;
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
                        return ((bool)(this[this.tableColorCdInfo.SelectionStateColumn]));
                    }
                    catch (global::System.InvalidCastException e)
                    {
                        throw new StrongTypingException("テーブル \'ColorCdInfo\' にある列 \'SelectionState\' の値は DBNull です。", e);
                    }
                }
                set
                {
                    this[this.tableColorCdInfo.SelectionStateColumn] = value;
                }
            }

            /// <summary>
            /// 
            /// </summary>
            public bool IsColorName1Null()
            {
                return this.IsNull(this.tableColorCdInfo.ColorName1Column);
            }

            /// <summary>
            /// 
            /// </summary>
            public void SetColorName1Null()
            {
                this[this.tableColorCdInfo.ColorName1Column] = global::System.Convert.DBNull;
            }

            /// <summary>
            /// 
            /// </summary>
            public bool IsSelectionStateNull()
            {
                return this.IsNull(this.tableColorCdInfo.SelectionStateColumn);
            }

            /// <summary>
            /// 
            /// </summary>
            public void SetSelectionStateNull()
            {
                this[this.tableColorCdInfo.SelectionStateColumn] = global::System.Convert.DBNull;
            }
        }

    }
}
