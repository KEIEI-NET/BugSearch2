using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;

namespace Broadleaf.Application.UIData
{
    public partial class PMKEN01010E
    {

        /// <summary>
        /// 生産年式情報クラス
        /// </summary>
        /// <remarks>
        /// <br>Note       : 生産年式情報を格納するデータテーブルです。</br>
        /// <br>Programmer : 30290</br>
        /// <br>Date       : 2008.05.15</br>
        /// <br></br>
        /// <br>Update Note: </br>
        /// </remarks>
        public partial class PrdTypYearInfoDataTable : DataTable, IEnumerable
        {

            private DataColumn columnMakerCode;

            private DataColumn columnFrameModel;

            private DataColumn columnStProduceFrameNo;

            private DataColumn columnEdProduceFrameNo;

            private DataColumn columnProduceTypeOfYear;

            private DataColumn columnSelectionState;

            /// <summary>
            /// 
            /// </summary>
            public PrdTypYearInfoDataTable()
            {
                this.TableName = "PrdTypYearInfo";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }


            internal PrdTypYearInfoDataTable(DataTable table)
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
            protected PrdTypYearInfoDataTable(global::System.Runtime.Serialization.SerializationInfo info, global::System.Runtime.Serialization.StreamingContext context)
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
            public DataColumn FrameModelColumn
            {
                get
                {
                    return this.columnFrameModel;
                }
            }

            /// <summary>
            /// 
            /// </summary>
            public DataColumn StProduceFrameNoColumn
            {
                get
                {
                    return this.columnStProduceFrameNo;
                }
            }

            /// <summary>
            /// 
            /// </summary>
            public DataColumn EdProduceFrameNoColumn
            {
                get
                {
                    return this.columnEdProduceFrameNo;
                }
            }

            /// <summary>
            /// 
            /// </summary>
            public DataColumn ProduceTypeOfYearColumn
            {
                get
                {
                    return this.columnProduceTypeOfYear;
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
            public PrdTypYearInfoRow this[int index]
            {
                get
                {
                    return ((PrdTypYearInfoRow)(this.Rows[index]));
                }
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="row"></param>
            public void AddPrdTypYearInfoRow(PrdTypYearInfoRow row)
            {
                this.Rows.Add(row);
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="MakerCode"></param>
            /// <param name="FrameModel"></param>
            /// <param name="StProduceFrameNo"></param>
            /// <param name="EdProduceFrameNo"></param>
            /// <param name="ProduceTypeOfYear"></param>
            /// <param name="SelectionState"></param>
            /// <returns></returns>
            public PrdTypYearInfoRow AddPrdTypYearInfoRow(int MakerCode, string FrameModel, int StProduceFrameNo, int EdProduceFrameNo, int ProduceTypeOfYear, bool SelectionState)
            {
                PrdTypYearInfoRow rowPrdTypYearInfoRow = ((PrdTypYearInfoRow)(this.NewRow()));
                object[] columnValuesArray = new object[] {
                        MakerCode,
                        FrameModel,
                        StProduceFrameNo,
                        EdProduceFrameNo,
                        ProduceTypeOfYear,
                        SelectionState};
                rowPrdTypYearInfoRow.ItemArray = columnValuesArray;
                this.Rows.Add(rowPrdTypYearInfoRow);
                return rowPrdTypYearInfoRow;
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
                PrdTypYearInfoDataTable cln = ((PrdTypYearInfoDataTable)(base.Clone()));
                cln.InitVars();
                return cln;
            }

            /// <summary>
            /// 
            /// </summary>
            /// <returns></returns>
            protected override DataTable CreateInstance()
            {
                return new PrdTypYearInfoDataTable();
            }


            internal void InitVars()
            {
                this.columnMakerCode = base.Columns["MakerCode"];
                this.columnFrameModel = base.Columns["FrameModel"];
                this.columnStProduceFrameNo = base.Columns["StProduceFrameNo"];
                this.columnEdProduceFrameNo = base.Columns["EdProduceFrameNo"];
                this.columnProduceTypeOfYear = base.Columns["ProduceTypeOfYear"];
                this.columnSelectionState = base.Columns["SelectionState"];
            }


            private void InitClass()
            {
                this.columnMakerCode = new DataColumn("MakerCode", typeof(int), null, MappingType.Element);
                base.Columns.Add(this.columnMakerCode);
                this.columnFrameModel = new DataColumn("FrameModel", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnFrameModel);
                this.columnStProduceFrameNo = new DataColumn("StProduceFrameNo", typeof(int), null, MappingType.Element);
                base.Columns.Add(this.columnStProduceFrameNo);
                this.columnEdProduceFrameNo = new DataColumn("EdProduceFrameNo", typeof(int), null, MappingType.Element);
                base.Columns.Add(this.columnEdProduceFrameNo);
                this.columnProduceTypeOfYear = new DataColumn("ProduceTypeOfYear", typeof(int), null, MappingType.Element);
                base.Columns.Add(this.columnProduceTypeOfYear);
                this.columnSelectionState = new DataColumn("SelectionState", typeof(bool), null, MappingType.Element);
                base.Columns.Add(this.columnSelectionState);
                this.columnMakerCode.AllowDBNull = false;
                this.columnMakerCode.Caption = "メーカーコード";
                this.columnFrameModel.AllowDBNull = false;
                this.columnFrameModel.Caption = "車台型式";
                this.columnFrameModel.MaxLength = 16;
                this.columnStProduceFrameNo.Caption = "生産車台番号開始";
                this.columnEdProduceFrameNo.AllowDBNull = false;
                this.columnEdProduceFrameNo.Caption = "生産車台番号終了";
                this.columnProduceTypeOfYear.Caption = "生産年式";
                this.columnSelectionState.Caption = "選択状態";
                this.columnSelectionState.DefaultValue = false;
                this.CaseSensitive = true;
            }

            /// <summary>
            /// 
            /// </summary>
            /// <returns></returns>
            public PrdTypYearInfoRow NewPrdTypYearInfoRow()
            {
                return ((PrdTypYearInfoRow)(this.NewRow()));
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="builder"></param>
            /// <returns></returns>
            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new PrdTypYearInfoRow(builder);
            }

            /// <summary>
            /// 
            /// </summary>
            /// <returns></returns>
            protected override global::System.Type GetRowType()
            {
                return typeof(PrdTypYearInfoRow);
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="row"></param>
            public void RemovePrdTypYearInfoRow(PrdTypYearInfoRow row)
            {
                this.Rows.Remove(row);
            }

            private struct _FrmNo
            {
                public int stProduceFrameNo;
                public int edProduceFrameNo;
            };
            /// <summary>
            /// データセットの車の車台番号の範囲を取得します。
            /// </summary>
            /// <returns>車台番号範囲</returns>
            public string GetFrameNoRange()//out int stFrameNo, out int edFrameNo)
            {
                string ret = string.Empty;
                if (Count == 0)
                    return ret;

                //stFrameNo = 0;
                //edFrameNo = 0;
                List<_FrmNo> lst = new List<_FrmNo>();
                _FrmNo frmNo = new _FrmNo();
                frmNo.stProduceFrameNo = ((PrdTypYearInfoRow)Rows[0]).StProduceFrameNo;
                frmNo.edProduceFrameNo = ((PrdTypYearInfoRow)Rows[0]).EdProduceFrameNo;
                for (int i = 1; i < Count; i++)
                {
                    PrdTypYearInfoRow row = (PrdTypYearInfoRow)Rows[i];
                    if (frmNo.stProduceFrameNo > row.StProduceFrameNo &&
                        row.EdProduceFrameNo + 1 == frmNo.stProduceFrameNo)
                    {
                        frmNo.stProduceFrameNo = row.StProduceFrameNo;
                    }
                    else if (frmNo.edProduceFrameNo < row.EdProduceFrameNo &&
                        row.StProduceFrameNo - 1 == frmNo.edProduceFrameNo)
                    {
                        frmNo.edProduceFrameNo = row.EdProduceFrameNo;
                    }
                    else
                    {
                        lst.Add(frmNo);
                        frmNo = new _FrmNo();
                        frmNo.stProduceFrameNo = row.StProduceFrameNo;
                        frmNo.edProduceFrameNo = row.EdProduceFrameNo;
                    }
                }
                lst.Add(frmNo);
                //if (stProduceFrameNo != 999999 || edProduceFrameNo != 0)
                for (int i = 0; i < lst.Count; i++)
                {
                    ret += string.Format("{0} - {1}", lst[i].stProduceFrameNo, lst[i].edProduceFrameNo);
                    if (i != lst.Count - 1)
                        ret += " / ";
                }
                //stFrameNo = stProduceFrameNo;
                //edFrameNo = edProduceFrameNo;
                return ret;
            }

        }

        /// <summary>
        /// 
        /// </summary>
        public partial class PrdTypYearInfoRow : DataRow
        {

            private PrdTypYearInfoDataTable tablePrdTypYearInfo;


            internal PrdTypYearInfoRow(DataRowBuilder rb)
                :
                    base(rb)
            {
                this.tablePrdTypYearInfo = ((PrdTypYearInfoDataTable)(this.Table));
            }

            /// <summary>
            /// 
            /// </summary>
            public int MakerCode
            {
                get
                {
                    return ((int)(this[this.tablePrdTypYearInfo.MakerCodeColumn]));
                }
                set
                {
                    this[this.tablePrdTypYearInfo.MakerCodeColumn] = value;
                }
            }

            /// <summary>
            /// 
            /// </summary>
            public string FrameModel
            {
                get
                {
                    return ((string)(this[this.tablePrdTypYearInfo.FrameModelColumn]));
                }
                set
                {
                    this[this.tablePrdTypYearInfo.FrameModelColumn] = value;
                }
            }

            /// <summary>
            /// 
            /// </summary>
            public int StProduceFrameNo
            {
                get
                {
                    try
                    {
                        return ((int)(this[this.tablePrdTypYearInfo.StProduceFrameNoColumn]));
                    }
                    catch (global::System.InvalidCastException e)
                    {
                        throw new StrongTypingException("テーブル \'PrdTypYearInfo\' にある列 \'StProduceFrameNo\' の値は DBNull です。", e);
                    }
                }
                set
                {
                    this[this.tablePrdTypYearInfo.StProduceFrameNoColumn] = value;
                }
            }

            /// <summary>
            /// 
            /// </summary>
            public int EdProduceFrameNo
            {
                get
                {
                    return ((int)(this[this.tablePrdTypYearInfo.EdProduceFrameNoColumn]));
                }
                set
                {
                    this[this.tablePrdTypYearInfo.EdProduceFrameNoColumn] = value;
                }
            }

            /// <summary>
            /// 
            /// </summary>
            public int ProduceTypeOfYear
            {
                get
                {
                    try
                    {
                        return ((int)(this[this.tablePrdTypYearInfo.ProduceTypeOfYearColumn]));
                    }
                    catch (global::System.InvalidCastException e)
                    {
                        throw new StrongTypingException("テーブル \'PrdTypYearInfo\' にある列 \'ProduceTypeOfYear\' の値は DBNull です。", e);
                    }
                }
                set
                {
                    this[this.tablePrdTypYearInfo.ProduceTypeOfYearColumn] = value;
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
                        return ((bool)(this[this.tablePrdTypYearInfo.SelectionStateColumn]));
                    }
                    catch (global::System.InvalidCastException e)
                    {
                        throw new StrongTypingException("テーブル \'PrdTypYearInfo\' にある列 \'SelectionState\' の値は DBNull です。", e);
                    }
                }
                set
                {
                    this[this.tablePrdTypYearInfo.SelectionStateColumn] = value;
                }
            }

            /// <summary>
            /// 
            /// </summary>
            public bool IsStProduceFrameNoNull()
            {
                return this.IsNull(this.tablePrdTypYearInfo.StProduceFrameNoColumn);
            }

            /// <summary>
            /// 
            /// </summary>
            public void SetStProduceFrameNoNull()
            {
                this[this.tablePrdTypYearInfo.StProduceFrameNoColumn] = global::System.Convert.DBNull;
            }

            /// <summary>
            /// 
            /// </summary>
            public bool IsProduceTypeOfYearNull()
            {
                return this.IsNull(this.tablePrdTypYearInfo.ProduceTypeOfYearColumn);
            }

            /// <summary>
            /// 
            /// </summary>
            public void SetProduceTypeOfYearNull()
            {
                this[this.tablePrdTypYearInfo.ProduceTypeOfYearColumn] = global::System.Convert.DBNull;
            }

            /// <summary>
            /// 
            /// </summary>
            public bool IsSelectionStateNull()
            {
                return this.IsNull(this.tablePrdTypYearInfo.SelectionStateColumn);
            }

            /// <summary>
            /// 
            /// </summary>
            public void SetSelectionStateNull()
            {
                this[this.tablePrdTypYearInfo.SelectionStateColumn] = global::System.Convert.DBNull;
            }
        }

    }
}
