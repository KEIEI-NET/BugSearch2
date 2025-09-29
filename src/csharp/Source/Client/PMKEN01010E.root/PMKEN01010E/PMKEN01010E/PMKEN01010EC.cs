using System;
using System.Data;
using System.Collections;
using Broadleaf.Application.Common;
using System.Xml.Schema;

namespace Broadleaf.Application.UIData
{
    public partial class PMKEN01010E
    {

        /// <summary>
        /// 車種情報クラス
        /// </summary>
        /// <remarks>
        /// <br>Note       : 車種情報を格納するデータテーブルです。</br>
        /// <br>Programmer : 30290</br>
        /// <br>Date       : 2008.05.15</br>
        /// <br></br>
        /// </remarks>
        public class CarKindInfoDataTable : DataTable, IEnumerable
        {

            private DataColumn columnMakerCode;

            private DataColumn columnMakerFullName;
            private DataColumn columnMakerHalfName;

            private DataColumn columnModelCode;

            private DataColumn columnModelSubCode;

            private DataColumn columnModelFullName;
            private DataColumn columnModelHalfName;

            private DataColumn columnEngineModelNm;

            private DataColumn columnSelectionState;

            /// <summary>
            /// 
            /// </summary>
            public CarKindInfoDataTable()
            {
                this.TableName = "CarKindInfo";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            internal CarKindInfoDataTable(DataTable table)
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
            protected CarKindInfoDataTable(global::System.Runtime.Serialization.SerializationInfo info, global::System.Runtime.Serialization.StreamingContext context)
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
            public DataColumn MakerFullNameColumn
            {
                get
                {
                    return this.columnMakerFullName;
                }
            }

            /// <summary>
            /// 
            /// </summary>
            public DataColumn MakerHalfNameColumn
            {
                get
                {
                    return this.columnMakerHalfName;
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

            /// <summary>
            /// 
            /// </summary>
            public DataColumn ModelFullNameColumn
            {
                get
                {
                    return this.columnModelFullName;
                }
            }

            /// <summary>
            /// 
            /// </summary>
            public DataColumn ModelHalfNameColumn
            {
                get
                {
                    return this.columnModelHalfName;
                }
            }

            /// <summary>
            /// 
            /// </summary>
            public DataColumn EngineModelNmColumn
            {
                get
                {
                    return this.columnEngineModelNm;
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
            public CarKindInfoRow this[int index]
            {
                get
                {
                    return ((CarKindInfoRow)(this.Rows[index]));
                }
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="row"></param>
            public void AddCarKindInfoRow(CarKindInfoRow row)
            {
                this.Rows.Add(row);
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="MakerCode"></param>
            /// <param name="MakerFullName"></param>
            /// <param name="MakerHalfName"></param>
            /// <param name="ModelCode"></param>
            /// <param name="ModelSubCode"></param>
            /// <param name="ModelFullName"></param>
            /// <param name="ModelHalfName"></param>
            /// <param name="EngineModelNm"></param>
            /// <param name="SelectionState"></param>
            /// <returns></returns>
            public CarKindInfoRow AddCarKindInfoRow(int MakerCode, string MakerFullName, string MakerHalfName, int ModelCode, int ModelSubCode,
                string ModelFullName, string ModelHalfName, string EngineModelNm, bool SelectionState)
            {
                CarKindInfoRow rowCarKindInfoRow = ((CarKindInfoRow)(this.NewRow()));
                object[] columnValuesArray = new object[] {
                        MakerCode,
                        MakerFullName,
                        MakerHalfName,
                        ModelCode,
                        ModelSubCode,
                        ModelFullName,
                        ModelHalfName,
                        EngineModelNm,
                        SelectionState};
                rowCarKindInfoRow.ItemArray = columnValuesArray;
                this.Rows.Add(rowCarKindInfoRow);
                return rowCarKindInfoRow;
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
                CarKindInfoDataTable cln = ((CarKindInfoDataTable)(base.Clone()));
                cln.InitVars();
                return cln;
            }

            /// <summary>
            /// 
            /// </summary>
            /// <returns></returns>
            protected override DataTable CreateInstance()
            {
                return new CarKindInfoDataTable();
            }

            internal void InitVars()
            {
                this.columnMakerCode = base.Columns["MakerCode"];
                this.columnMakerFullName = base.Columns["MakerFullName"];
                this.columnMakerHalfName = base.Columns["MakerHalfName"];
                this.columnModelCode = base.Columns["ModelCode"];
                this.columnModelSubCode = base.Columns["ModelSubCode"];
                this.columnModelFullName = base.Columns["ModelFullName"];
                this.columnModelHalfName = base.Columns["ModelHalfName"];
                this.columnEngineModelNm = base.Columns["EngineModelNm"];
                this.columnSelectionState = base.Columns["SelectionState"];
            }

            private void InitClass()
            {
                this.columnMakerCode = new DataColumn("MakerCode", typeof(int), null, MappingType.Element);
                base.Columns.Add(this.columnMakerCode);
                this.columnMakerFullName = new DataColumn("MakerFullName", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnMakerFullName);
                this.columnMakerHalfName = new DataColumn("MakerHalfName", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnMakerHalfName);
                this.columnModelCode = new DataColumn("ModelCode", typeof(int), null, MappingType.Element);
                base.Columns.Add(this.columnModelCode);
                this.columnModelSubCode = new DataColumn("ModelSubCode", typeof(int), null, MappingType.Element);
                base.Columns.Add(this.columnModelSubCode);
                this.columnModelFullName = new DataColumn("ModelFullName", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnModelFullName);
                this.columnModelHalfName = new DataColumn("ModelHalfName", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnModelHalfName);
                this.columnEngineModelNm = new DataColumn("EngineModelNm", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnEngineModelNm);
                this.columnSelectionState = new DataColumn("SelectionState", typeof(bool), null, MappingType.Element);
                base.Columns.Add(this.columnSelectionState);

                this.columnMakerCode.AllowDBNull = false;
                this.columnMakerCode.Caption = "メーカーコード";
                this.columnMakerFullName.Caption = "メーカー名";
                this.columnMakerFullName.MaxLength = 15;
                this.columnModelCode.AllowDBNull = false;
                this.columnModelCode.Caption = "車種コード";
                this.columnModelSubCode.AllowDBNull = false;
                this.columnModelSubCode.Caption = "車種サブコード";
                this.columnModelFullName.Caption = "車種名";
                this.columnModelFullName.MaxLength = 15;
                this.columnEngineModelNm.Caption = "エンジン型式名称";
                this.columnEngineModelNm.MaxLength = 12;
                this.columnSelectionState.Caption = "選択状態";
                this.columnSelectionState.DefaultValue = false;

                this.CaseSensitive = true;
            }

            /// <summary>
            /// 
            /// </summary>
            /// <returns></returns>
            public CarKindInfoRow NewCarKindInfoRow()
            {
                return ((CarKindInfoRow)(this.NewRow()));
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="builder"></param>
            /// <returns></returns>
            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new CarKindInfoRow(builder);
            }

            /// <summary>
            /// 
            /// </summary>
            /// <returns></returns>
            protected override global::System.Type GetRowType()
            {
                return typeof(CarKindInfoRow);
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="row"></param>
            public void RemoveCarKindInfoRow(CarKindInfoRow row)
            {
                this.Rows.Remove(row);
            }

        }

        /// <summary>
        /// 
        /// </summary>
        public class CarKindInfoRow : DataRow
        {

            private CarKindInfoDataTable tableCarKindInfo;

            internal CarKindInfoRow(DataRowBuilder rb)
                :
                    base(rb)
            {
                this.tableCarKindInfo = ((CarKindInfoDataTable)(this.Table));
            }

            /// <summary>
            /// 
            /// </summary>
            public int MakerCode
            {
                get
                {
                    return ((int)(this[this.tableCarKindInfo.MakerCodeColumn]));
                }
                set
                {
                    this[this.tableCarKindInfo.MakerCodeColumn] = value;
                }
            }

            /// <summary>
            /// 
            /// </summary>
            public string MakerFullName
            {
                get
                {
                    if (this.IsMakerFullNameNull())
                    {
                        return string.Empty;
                    }
                    else
                    {
                        return ((string)(this[this.tableCarKindInfo.MakerFullNameColumn]));
                    }
                }
                set
                {
                    this[this.tableCarKindInfo.MakerFullNameColumn] = value;
                }
            }

            /// <summary>
            /// 
            /// </summary>
            public string MakerHalfName
            {
                get
                {
                    if (this.IsMakerHalfNameNull())
                    {
                        return string.Empty;
                    }
                    else
                    {
                        return ((string)(this[this.tableCarKindInfo.MakerHalfNameColumn]));
                    }
                }
                set
                {
                    this[this.tableCarKindInfo.MakerHalfNameColumn] = value;
                }
            }

            /// <summary>
            /// 
            /// </summary>
            public int ModelCode
            {
                get
                {
                    return ((int)(this[this.tableCarKindInfo.ModelCodeColumn]));
                }
                set
                {
                    this[this.tableCarKindInfo.ModelCodeColumn] = value;
                }
            }

            /// <summary>
            /// 
            /// </summary>
            public int ModelSubCode
            {
                get
                {
                    return ((int)(this[this.tableCarKindInfo.ModelSubCodeColumn]));
                }
                set
                {
                    this[this.tableCarKindInfo.ModelSubCodeColumn] = value;
                }
            }

            /// <summary>
            /// 
            /// </summary>
            public string ModelFullName
            {
                get
                {
                    if (this.IsModelFullNameNull())
                    {
                        return string.Empty;
                    }
                    else
                    {
                        return ((string)(this[this.tableCarKindInfo.ModelFullNameColumn]));
                    }
                }
                set
                {
                    this[this.tableCarKindInfo.ModelFullNameColumn] = value;
                }
            }

            /// <summary>
            /// 
            /// </summary>
            public string ModelHalfName
            {
                get
                {
                    if (this.IsModelHalfNameNull())
                    {
                        return string.Empty;
                    }
                    else
                    {
                        return ((string)(this[this.tableCarKindInfo.ModelHalfNameColumn]));
                    }
                }
                set
                {
                    this[this.tableCarKindInfo.ModelHalfNameColumn] = value;
                }
            }

            /// <summary>
            /// 
            /// </summary>
            public string EngineModelNm
            {
                get
                {
                    if (this.IsEngineModelNmNull())
                    {
                        return string.Empty;
                    }
                    else
                    {
                        return ((string)(this[this.tableCarKindInfo.EngineModelNmColumn]));
                    }
                }
                set
                {
                    this[this.tableCarKindInfo.EngineModelNmColumn] = value;
                }
            }

            /// <summary>
            /// 
            /// </summary>
            public bool SelectionState
            {
                get
                {
                    if (this.IsNull(this.tableCarKindInfo.SelectionStateColumn))
                    {
                        this[this.tableCarKindInfo.SelectionStateColumn] = false;
                    }
                    return (bool)this[this.tableCarKindInfo.SelectionStateColumn];
                }
                set
                {
                    this[this.tableCarKindInfo.SelectionStateColumn] = value;
                }
            }

            /// <summary>
            /// 
            /// </summary>
            /// <returns></returns>
            public bool IsMakerFullNameNull()
            {
                return this.IsNull(this.tableCarKindInfo.MakerFullNameColumn);
            }

            /// <summary>
            /// 
            /// </summary>
            /// <returns></returns>
            public bool IsMakerHalfNameNull()
            {
                return this.IsNull(this.tableCarKindInfo.MakerHalfNameColumn);
            }

            /// <summary>
            /// 
            /// </summary>
            public void SetMakerFullNameNull()
            {
                this[this.tableCarKindInfo.MakerFullNameColumn] = global::System.Convert.DBNull;
            }

            /// <summary>
            /// 
            /// </summary>
            /// <returns></returns>
            public bool IsModelFullNameNull()
            {
                return this.IsNull(this.tableCarKindInfo.ModelFullNameColumn);
            }

            /// <summary>
            /// 
            /// </summary>
            /// <returns></returns>
            public bool IsModelHalfNameNull()
            {
                return this.IsNull(this.tableCarKindInfo.ModelHalfNameColumn);
            }

            /// <summary>
            /// 
            /// </summary>
            public void SetModelFullNameNull()
            {
                this[this.tableCarKindInfo.ModelFullNameColumn] = global::System.Convert.DBNull;
            }

            /// <summary>
            /// 
            /// </summary>
            /// <returns></returns>
            public bool IsEngineModelNmNull()
            {
                return this.IsNull(this.tableCarKindInfo.EngineModelNmColumn);
            }

            /// <summary>
            /// 
            /// </summary>
            public void SetEngineModelNmNull()
            {
                this[this.tableCarKindInfo.EngineModelNmColumn] = global::System.Convert.DBNull;
            }
        }

    }
}
