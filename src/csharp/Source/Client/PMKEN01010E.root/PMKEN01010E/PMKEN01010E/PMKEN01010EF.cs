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
        /// トリム情報クラス
        /// </summary>
        /// <remarks>
        /// <br>Note       : トリム情報を格納するデータテーブルです。</br>
        /// <br>Programmer : 30290</br>
        /// <br>Date       : 2008.05.15</br>
        /// <br></br>
        /// <br>Update Note: </br>
        /// </remarks>
        public partial class TrimCdInfoDataTable : DataTable, IEnumerable
        {

            private DataColumn columnMakerCode;

            private DataColumn columnModelCode;

            private DataColumn columnModelSubCode;

/*            private DataColumn columnSystematicCode;

            private DataColumn columnProduceTypeOfYearCd;*/

            private DataColumn columnTrimCode;

            private DataColumn columnTrimName;

            private DataColumn columnSelectionState;

            /// <summary>
            /// 
            /// </summary>
            public TrimCdInfoDataTable()
            {
                this.TableName = "TrimCdInfo";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }


            internal TrimCdInfoDataTable(DataTable table)
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
            protected TrimCdInfoDataTable(global::System.Runtime.Serialization.SerializationInfo info, global::System.Runtime.Serialization.StreamingContext context)
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

/*            /// <summary>
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
            }*/

            /// <summary>
            /// 
            /// </summary>
            public DataColumn TrimCodeColumn
            {
                get
                {
                    return this.columnTrimCode;
                }
            }

            /// <summary>
            /// 
            /// </summary>
            public DataColumn TrimNameColumn
            {
                get
                {
                    return this.columnTrimName;
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
            public TrimCdInfoRow this[int index]
            {
                get
                {
                    return ((TrimCdInfoRow)(this.Rows[index]));
                }
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="row"></param>
            public void AddTrimCdInfoRow(TrimCdInfoRow row)
            {
                this.Rows.Add(row);
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="MakerCode"></param>
            /// <param name="ModelCode"></param>
            /// <param name="ModelSubCode"></param>
            /// <param name="SystematicCode"></param>
            /// <param name="ProduceTypeOfYearCd"></param>
            /// <param name="TrimCode"></param>
            /// <param name="TrimName"></param>
            /// <param name="SelectionState"></param>
            /// <returns></returns>
            public TrimCdInfoRow AddTrimCdInfoRow(int MakerCode, int ModelCode, int ModelSubCode, int SystematicCode, int ProduceTypeOfYearCd, string TrimCode, string TrimName, bool SelectionState)
            {
                TrimCdInfoRow rowTrimCdInfoRow = ((TrimCdInfoRow)(this.NewRow()));
                object[] columnValuesArray = new object[] {
                        MakerCode,
                        ModelCode,
                        ModelSubCode,
                        SystematicCode,
                        ProduceTypeOfYearCd,
                        TrimCode,
                        TrimName,
                        SelectionState};
                rowTrimCdInfoRow.ItemArray = columnValuesArray;
                this.Rows.Add(rowTrimCdInfoRow);
                return rowTrimCdInfoRow;
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
                TrimCdInfoDataTable cln = ((TrimCdInfoDataTable)(base.Clone()));
                cln.InitVars();
                return cln;
            }

            /// <summary>
            /// 
            /// </summary>
            /// <returns></returns>
            protected override DataTable CreateInstance()
            {
                return new TrimCdInfoDataTable();
            }

            internal void InitVars()
            {
                this.columnMakerCode = base.Columns["MakerCode"];
                this.columnModelCode = base.Columns["ModelCode"];
                this.columnModelSubCode = base.Columns["ModelSubCode"];
                //this.columnSystematicCode = base.Columns["SystematicCode"];
                //this.columnProduceTypeOfYearCd = base.Columns["ProduceTypeOfYearCd"];
                this.columnTrimCode = base.Columns["TrimCode"];
                this.columnTrimName = base.Columns["TrimName"];
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
                //this.columnSystematicCode = new DataColumn("SystematicCode", typeof(int), null, MappingType.Element);
                //base.Columns.Add(this.columnSystematicCode);
                //this.columnProduceTypeOfYearCd = new DataColumn("ProduceTypeOfYearCd", typeof(int), null, MappingType.Element);
                //base.Columns.Add(this.columnProduceTypeOfYearCd);
                this.columnTrimCode = new DataColumn("TrimCode", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnTrimCode);
                this.columnTrimName = new DataColumn("TrimName", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnTrimName);
                this.columnSelectionState = new DataColumn("SelectionState", typeof(bool), null, MappingType.Element);
                base.Columns.Add(this.columnSelectionState);
                this.columnMakerCode.AllowDBNull = false;
                this.columnMakerCode.Caption = "メーカーコード";
                this.columnModelCode.AllowDBNull = false;
                this.columnModelCode.Caption = "車種コード";
                this.columnModelSubCode.AllowDBNull = false;
                this.columnModelSubCode.Caption = "車種サブコード";
                //this.columnSystematicCode.AllowDBNull = false;
                //this.columnSystematicCode.Caption = "系統コード";
                //this.columnProduceTypeOfYearCd.AllowDBNull = false;
                //this.columnProduceTypeOfYearCd.Caption = "生産年式コード";
                this.columnTrimCode.AllowDBNull = false;
                this.columnTrimCode.Caption = "トリムコード";
                this.columnTrimCode.MaxLength = 15;
                this.columnTrimName.Caption = "トリム名称";
                this.columnTrimName.MaxLength = 40;
                this.columnTrimName.DefaultValue = string.Empty;
                this.columnSelectionState.Caption = "選択状態";
                this.columnSelectionState.DefaultValue = false;
                this.CaseSensitive = true;
            }

            /// <summary>
            /// 
            /// </summary>
            /// <returns></returns>
            public TrimCdInfoRow NewTrimCdInfoRow()
            {
                return ((TrimCdInfoRow)(this.NewRow()));
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="builder"></param>
            /// <returns></returns>
            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new TrimCdInfoRow(builder);
            }

            /// <summary>
            /// 
            /// </summary>
            /// <returns></returns>
            protected override global::System.Type GetRowType()
            {
                return typeof(TrimCdInfoRow);
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="row"></param>
            public void RemoveTrimCdInfoRow(TrimCdInfoRow row)
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
                    TrimCdInfoRow trimRow = (TrimCdInfoRow)Rows[i];
                    if (selectedRowOnly && trimRow.SelectionState == false)
                        continue;
                    TrimCdRetWork work = new TrimCdRetWork();
                    //work.MakerCode = trimRow.MakerCode;
                    //work.ModelCode = trimRow.ModelCode;
                    //work.ModelSubCode = trimRow.ModelSubCode;
                    //work.ProduceTypeOfYearCd = trimRow.ProduceTypeOfYearCd;
                    work.TrimCode = trimRow.TrimCode;
                    work.TrimName = trimRow.TrimName;
                }

                return list;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public partial class TrimCdInfoRow : DataRow
        {

            private TrimCdInfoDataTable tableTrimCdInfo;


            internal TrimCdInfoRow(DataRowBuilder rb)
                :
                    base(rb)
            {
                this.tableTrimCdInfo = ((TrimCdInfoDataTable)(this.Table));
            }

            /// <summary>
            /// 
            /// </summary>
            public int MakerCode
            {
                get
                {
                    return ((int)(this[this.tableTrimCdInfo.MakerCodeColumn]));
                }
                set
                {
                    this[this.tableTrimCdInfo.MakerCodeColumn] = value;
                }
            }

            /// <summary>
            /// 
            /// </summary>
            public int ModelCode
            {
                get
                {
                    return ((int)(this[this.tableTrimCdInfo.ModelCodeColumn]));
                }
                set
                {
                    this[this.tableTrimCdInfo.ModelCodeColumn] = value;
                }
            }

            /// <summary>
            /// 
            /// </summary>
            public int ModelSubCode
            {
                get
                {
                    return ((int)(this[this.tableTrimCdInfo.ModelSubCodeColumn]));
                }
                set
                {
                    this[this.tableTrimCdInfo.ModelSubCodeColumn] = value;
                }
            }

/*            /// <summary>
            /// 
            /// </summary>
            public int SystematicCode
            {
                get
                {
                    return ((int)(this[this.tableTrimCdInfo.SystematicCodeColumn]));
                }
                set
                {
                    this[this.tableTrimCdInfo.SystematicCodeColumn] = value;
                }
            }

            /// <summary>
            /// 
            /// </summary>
            public int ProduceTypeOfYearCd
            {
                get
                {
                    return ((int)(this[this.tableTrimCdInfo.ProduceTypeOfYearCdColumn]));
                }
                set
                {
                    this[this.tableTrimCdInfo.ProduceTypeOfYearCdColumn] = value;
                }
            }*/

            /// <summary>
            /// 
            /// </summary>
            public string TrimCode
            {
                get
                {
                    return ((string)(this[this.tableTrimCdInfo.TrimCodeColumn]));
                }
                set
                {
                    this[this.tableTrimCdInfo.TrimCodeColumn] = value;
                }
            }

            /// <summary>
            /// 
            /// </summary>
            public string TrimName
            {
                get
                {
                    if (this.IsTrimNameNull())
                    {
                        return string.Empty;
                    }
                    else
                    {
                        return ((string)(this[this.tableTrimCdInfo.TrimNameColumn]));
                    }
                }
                set
                {
                    this[this.tableTrimCdInfo.TrimNameColumn] = value;
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
                        return ((bool)(this[this.tableTrimCdInfo.SelectionStateColumn]));
                    }
                    catch (global::System.InvalidCastException e)
                    {
                        throw new StrongTypingException("テーブル \'TrimCdInfo\' にある列 \'SelectionState\' の値は DBNull です。", e);
                    }
                }
                set
                {
                    this[this.tableTrimCdInfo.SelectionStateColumn] = value;
                }
            }

            /// <summary>
            /// 
            /// </summary>
            public bool IsTrimNameNull()
            {
                return this.IsNull(this.tableTrimCdInfo.TrimNameColumn);
            }

            /// <summary>
            /// 
            /// </summary>
            public void SetTrimNameNull()
            {
                this[this.tableTrimCdInfo.TrimNameColumn] = global::System.Convert.DBNull;
            }

            /// <summary>
            /// 
            /// </summary>
            public bool IsSelectionStateNull()
            {
                return this.IsNull(this.tableTrimCdInfo.SelectionStateColumn);
            }

            /// <summary>
            /// 
            /// </summary>
            public void SetSelectionStateNull()
            {
                this[this.tableTrimCdInfo.SelectionStateColumn] = global::System.Convert.DBNull;
            }
        }

    }
}
