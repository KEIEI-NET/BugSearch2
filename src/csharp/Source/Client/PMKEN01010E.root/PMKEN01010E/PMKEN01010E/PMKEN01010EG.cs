using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;
using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;
using Infragistics.Win;

namespace Broadleaf.Application.UIData
{
    public partial class PMKEN01010E
    {

        /// <summary>
        /// 装備情報クラス
        /// </summary>
        /// <remarks>
        /// <br>Note       : 装備情報を格納するデータテーブルです。</br>
        /// <br>Programmer : 30290</br>
        /// <br>Date       : 2008.05.15</br>
        /// <br></br>
        /// <br>Update Note: </br>
        /// </remarks>
        public partial class CEqpDefDspInfoDataTable : DataTable, IEnumerable
        {

            private DataColumn columnMakerCode;

            private DataColumn columnModelCode;

            private DataColumn columnModelSubCode;

            private DataColumn columnSystematicCode;

            private DataColumn columnEquipmentDispOrder;

            private DataColumn columnEquipmentGenreCd;

            private DataColumn columnEquipmentGenreNm;

            private DataColumn columnEquipmentCode;

            private DataColumn columnEquipmentName;

            private DataColumn columnEquipmentShortName;

            private DataColumn columnEquipmentIconCode;

            private DataColumn columnSelectionState;

            /// <summary>
            /// 
            /// </summary>
            public CEqpDefDspInfoDataTable()
            {
                this.TableName = "CEqpDefDspInfo";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }


            internal CEqpDefDspInfoDataTable(DataTable table)
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
            protected CEqpDefDspInfoDataTable(global::System.Runtime.Serialization.SerializationInfo info, global::System.Runtime.Serialization.StreamingContext context)
                :
                    base(info, context)
            {
                this.InitVars();
            }

            #region カラムプロパティ
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
            public DataColumn SelectionStateColumn
            {
                get
                {
                    return this.columnSelectionState;
                }
            }
            #endregion

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
            public CEqpDefDspInfoRow this[int index]
            {
                get
                {
                    return ((CEqpDefDspInfoRow)(this.Rows[index]));
                }
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="row"></param>
            public void AddCEqpDefDspInfoRow(CEqpDefDspInfoRow row)
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
            /// <param name="EquipmentDispOrder"></param>
            /// <param name="EquipmentGenreCd"></param>
            /// <param name="EquipmentGenreNm"></param>
            /// <param name="EquipmentCode"></param>
            /// <param name="EquipmentName"></param>
            /// <param name="EquipmentShortName"></param>
            /// <param name="EquipmentIconCode"></param>
            /// <param name="SelectionState"></param>
            /// <returns></returns>
            public CEqpDefDspInfoRow AddCEqpDefDspInfoRow(int MakerCode, int ModelCode, int ModelSubCode, int SystematicCode, int EquipmentDispOrder, int EquipmentGenreCd, string EquipmentGenreNm, int EquipmentCode, string EquipmentName, string EquipmentShortName, int EquipmentIconCode, bool SelectionState)
            {
                CEqpDefDspInfoRow rowCEqpDefDspInfoRow = ((CEqpDefDspInfoRow)(this.NewRow()));
                object[] columnValuesArray = new object[] {
                        MakerCode,
                        ModelCode,
                        ModelSubCode,
                        SystematicCode,
                        EquipmentDispOrder,
                        EquipmentGenreCd,
                        EquipmentGenreNm,
                        EquipmentCode,
                        EquipmentName,
                        EquipmentShortName,
                        EquipmentIconCode,
                        SelectionState};
                rowCEqpDefDspInfoRow.ItemArray = columnValuesArray;
                this.Rows.Add(rowCEqpDefDspInfoRow);
                return rowCEqpDefDspInfoRow;
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
                CEqpDefDspInfoDataTable cln = ((CEqpDefDspInfoDataTable)(base.Clone()));
                cln.InitVars();
                return cln;
            }

            /// <summary>
            /// 
            /// </summary>
            /// <returns></returns>
            protected override DataTable CreateInstance()
            {
                return new CEqpDefDspInfoDataTable();
            }

            internal void InitVars()
            {
                this.columnMakerCode = base.Columns["MakerCode"];
                this.columnModelCode = base.Columns["ModelCode"];
                this.columnModelSubCode = base.Columns["ModelSubCode"];
                this.columnSystematicCode = base.Columns["SystematicCode"];
                this.columnEquipmentDispOrder = base.Columns["EquipmentDispOrder"];
                this.columnEquipmentGenreCd = base.Columns["EquipmentGenreCd"];
                this.columnEquipmentGenreNm = base.Columns["EquipmentGenreNm"];
                this.columnEquipmentCode = base.Columns["EquipmentCode"];
                this.columnEquipmentName = base.Columns["EquipmentName"];
                this.columnEquipmentShortName = base.Columns["EquipmentShortName"];
                this.columnEquipmentIconCode = base.Columns["EquipmentIconCode"];
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
                this.columnSystematicCode = new DataColumn("SystematicCode", typeof(int), null, MappingType.Element);
                base.Columns.Add(this.columnSystematicCode);
                this.columnEquipmentDispOrder = new DataColumn("EquipmentDispOrder", typeof(int), null, MappingType.Element);
                base.Columns.Add(this.columnEquipmentDispOrder);
                this.columnEquipmentGenreCd = new DataColumn("EquipmentGenreCd", typeof(int), null, MappingType.Element);
                base.Columns.Add(this.columnEquipmentGenreCd);
                this.columnEquipmentGenreNm = new DataColumn("EquipmentGenreNm", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnEquipmentGenreNm);
                this.columnEquipmentCode = new DataColumn("EquipmentCode", typeof(int), null, MappingType.Element);
                base.Columns.Add(this.columnEquipmentCode);
                this.columnEquipmentName = new DataColumn("EquipmentName", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnEquipmentName);
                this.columnEquipmentShortName = new DataColumn("EquipmentShortName", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnEquipmentShortName);
                this.columnEquipmentIconCode = new DataColumn("EquipmentIconCode", typeof(int), null, MappingType.Element);
                base.Columns.Add(this.columnEquipmentIconCode);
                this.columnSelectionState = new DataColumn("SelectionState", typeof(bool), null, MappingType.Element);
                base.Columns.Add(this.columnSelectionState);
                this.columnMakerCode.AllowDBNull = false;
                this.columnMakerCode.Caption = "メーカーコード";
                this.columnModelCode.AllowDBNull = false;
                this.columnModelCode.Caption = "車種コード";
                this.columnModelSubCode.AllowDBNull = false;
                this.columnModelSubCode.Caption = "車種サブコード";
                this.columnSystematicCode.AllowDBNull = false;
                this.columnSystematicCode.Caption = "系統コード";
                this.columnEquipmentDispOrder.AllowDBNull = false;
                this.columnEquipmentDispOrder.Caption = "装備表示順位";
                this.columnEquipmentGenreCd.AllowDBNull = false;
                this.columnEquipmentGenreCd.Caption = "装備分類コード";
                this.columnEquipmentGenreNm.Caption = "装備分類名称";
                this.columnEquipmentGenreNm.MaxLength = 30;
                this.columnEquipmentGenreNm.DefaultValue = string.Empty;
                this.columnEquipmentCode.AllowDBNull = false;
                this.columnEquipmentCode.Caption = "装備コード";
                this.columnEquipmentName.Caption = "装備名称";
                this.columnEquipmentName.MaxLength = 60;
                this.columnEquipmentName.DefaultValue = string.Empty;
                this.columnEquipmentShortName.Caption = "装備略称";
                this.columnEquipmentShortName.MaxLength = 30;
                this.columnEquipmentShortName.DefaultValue = string.Empty;
                this.columnEquipmentIconCode.Caption = "装備ICONコード";
                this.columnEquipmentIconCode.DefaultValue = 0;
                this.columnSelectionState.Caption = "選択状態";
                this.columnSelectionState.DefaultValue = false;
                this.CaseSensitive = true;
            }

            /// <summary>
            /// 
            /// </summary>
            /// <returns></returns>
            public CEqpDefDspInfoRow NewCEqpDefDspInfoRow()
            {
                return ((CEqpDefDspInfoRow)(this.NewRow()));
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="builder"></param>
            /// <returns></returns>
            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new CEqpDefDspInfoRow(builder);
            }

            /// <summary>
            /// 
            /// </summary>
            /// <returns></returns>
            protected override global::System.Type GetRowType()
            {
                return typeof(CEqpDefDspInfoRow);
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="row"></param>
            public void RemoveCEqpDefDspInfoRow(CEqpDefDspInfoRow row)
            {
                this.Rows.Remove(row);
            }

            /// <summary>
            /// 装備情報データテーブルと同一データを持つArrayListを返す。
            /// </summary>
            /// <param name="selectedRowOnly">True:[選択状態]がtrueのデータのみArrayListに入れる/False:全て</param>
            /// <returns>ArrayList[CEquipInfoWork]</returns>
            public ArrayList GetArrayList(bool selectedRowOnly)
            {
                ArrayList list = new ArrayList();
                int count = Rows.Count;
                for (int i = 0; i < count; i++)
                {
                    CEqpDefDspInfoRow equipRow = (CEqpDefDspInfoRow)Rows[i];
                    if (selectedRowOnly && equipRow.SelectionState == false)
                        continue;
                    CEquipInfoWork work = new CEquipInfoWork();
                    //work.MakerCode = equipRow.MakerCode;
                    //work.ModelCode = equipRow.ModelCode;
                    //work.ModelSubCode = equipRow.ModelSubCode;
                    //work.SystematicCode = equipRow.SystematicCode;
                    work.EquipmentCode = equipRow.EquipmentCode;
                    work.EquipmentName = equipRow.EquipmentName;
                    work.EquipmentShortName = equipRow.EquipmentShortName;
                    work.EquipmentDispOrder = equipRow.EquipmentDispOrder;
                    work.EquipmentGenreCd = equipRow.EquipmentGenreCd;
                    work.EquipmentGenreNm = equipRow.EquipmentGenreNm;
                    //work.EquipmentIconCode = equipRow.EquipmentIconCode;
                }

                return list;
            }

            /// <summary>
            /// DB保存のためのバイト配列への変換処理を行う。
            /// </summary>
            /// <param name="selectedRowOnly">true:選択情報のみ／false:全て</param>
            /// <returns>変換されたバイト配列</returns>
            public byte[] GetByteArray(bool selectedRowOnly)
            {
                System.IO.MemoryStream ms = new System.IO.MemoryStream();
                byte[] byteArrayTemp = null;
                byte[] retBinary = null;

                int cnt = 0;

                if (selectedRowOnly)
                {
                    string filter = string.Format("{0} = True", SelectionStateColumn.ColumnName);
                    CEqpDefDspInfoRow[] rows = (CEqpDefDspInfoRow[])Select(filter);
                    cnt = rows.Length;
                }
                else
                {
                    cnt = Count;
                }
                ms.Write(BitConverter.GetBytes(cnt), 0, sizeof(int));
                for (int i = 0; i < Count; i++)
                {
                    CEqpDefDspInfoRow row = (CEqpDefDspInfoRow)Rows[i];
                    if (selectedRowOnly && row.SelectionState == false)
                        continue;
                    ms.Write(BitConverter.GetBytes(row.EquipmentCode), 0, sizeof(int));
                    ms.Write(BitConverter.GetBytes(row.EquipmentDispOrder), 0, sizeof(int));
                    ms.Write(BitConverter.GetBytes(row.EquipmentGenreCd), 0, sizeof(int));
                    byteArrayTemp = System.Text.Encoding.Default.GetBytes(row.EquipmentGenreNm);
                    ms.Write(BitConverter.GetBytes(byteArrayTemp.Length), 0, sizeof(int));
                    ms.Write(byteArrayTemp, 0, byteArrayTemp.Length);
                    ms.Write(BitConverter.GetBytes(row.EquipmentIconCode), 0, sizeof(int));
                    byteArrayTemp = System.Text.Encoding.Default.GetBytes(row.EquipmentName);
                    ms.Write(BitConverter.GetBytes(byteArrayTemp.Length), 0, sizeof(int));
                    ms.Write(byteArrayTemp, 0, byteArrayTemp.Length);
                    byteArrayTemp = System.Text.Encoding.Default.GetBytes(row.EquipmentShortName);
                    ms.Write(BitConverter.GetBytes(byteArrayTemp.Length), 0, sizeof(int));
                    ms.Write(byteArrayTemp, 0, byteArrayTemp.Length);
                    ms.Write(BitConverter.GetBytes(row.MakerCode), 0, sizeof(int));
                    ms.Write(BitConverter.GetBytes(row.ModelCode), 0, sizeof(int));
                    ms.Write(BitConverter.GetBytes(row.ModelSubCode), 0, sizeof(int));
                    ms.Write(BitConverter.GetBytes(row.SelectionState), 0, sizeof(bool));
                    ms.Write(BitConverter.GetBytes(row.SystematicCode), 0, sizeof(int));
                }
                retBinary = ms.ToArray();
                ms.Close();
                return retBinary;
            }

            /// <summary>
            /// バイト配列の装備情報をデータテーブルへセットする。（既存データはクリア）
            /// </summary>
            /// <param name="verbinary">変換対象のバイト配列</param>
            public void SetTableFromByteArray(byte[] verbinary)
            {
                int idx = 0;
                int strLen = 0;
                int rowCount = BitConverter.ToInt32(verbinary, idx);
                idx += sizeof(int);
                //Clear();
                for (int i = 0; i < Count; i++)
                {
                    this[i].SelectionState = false;
                }
                for (int i = 0; i < rowCount; i++)
                {
                    CEqpDefDspInfoRow row = NewCEqpDefDspInfoRow();
                    row.EquipmentCode = BitConverter.ToInt32(verbinary, idx);
                    idx += sizeof(int);
                    row.EquipmentDispOrder = BitConverter.ToInt32(verbinary, idx);
                    idx += sizeof(int);
                    row.EquipmentGenreCd = BitConverter.ToInt32(verbinary, idx);
                    idx += sizeof(int);
                    strLen = BitConverter.ToInt32(verbinary, idx);
                    idx += sizeof(int);
                    row.EquipmentGenreNm = System.Text.Encoding.Default.GetString(verbinary, idx, strLen);
                    idx += strLen;
                    row.EquipmentIconCode = BitConverter.ToInt32(verbinary, idx);
                    idx += sizeof(int);
                    strLen = BitConverter.ToInt32(verbinary, idx);
                    idx += sizeof(int);
                    row.EquipmentName = System.Text.Encoding.Default.GetString(verbinary, idx, strLen);
                    idx += strLen;
                    strLen = BitConverter.ToInt32(verbinary, idx);
                    idx += sizeof(int);
                    row.EquipmentShortName = System.Text.Encoding.Default.GetString(verbinary, idx, strLen);
                    idx += strLen;
                    row.MakerCode = BitConverter.ToInt32(verbinary, idx);
                    idx += sizeof(int);
                    row.ModelCode = BitConverter.ToInt32(verbinary, idx);
                    idx += sizeof(int);
                    row.ModelSubCode = BitConverter.ToInt32(verbinary, idx);
                    idx += sizeof(int);
                    row.SelectionState = BitConverter.ToBoolean(verbinary, idx);
                    idx += sizeof(bool);
                    row.SystematicCode = BitConverter.ToInt32(verbinary, idx);
                    idx += sizeof(int);

                    CEqpDefDspInfoRow[] rows;
                    string query = string.Format("{0}={1} AND {2}={3} AND {4}={5} AND {6}={7} AND {8}={9} AND {10}={11} AND {12}={13}",
                        MakerCodeColumn.ColumnName, row.MakerCode, ModelCodeColumn.ColumnName, row.ModelCode,
                        ModelSubCodeColumn.ColumnName, row.ModelSubCode, SystematicCodeColumn.ColumnName, row.SystematicCode,
                        EquipmentDispOrderColumn.ColumnName, row.EquipmentDispOrder, EquipmentGenreCdColumn.ColumnName, row.EquipmentGenreCd,
                        EquipmentCodeColumn.ColumnName, row.EquipmentCode);
                    rows = (CEqpDefDspInfoRow[])Select(query);
                    if (rows.Length > 0)
                    {
                        rows[0].SelectionState = true;
                    }
                    else
                    {
                        AddCEqpDefDspInfoRow(row);
                    }
                }
                AcceptChanges();
            }

            #region [ 装備情報UIデータ取得 ]
            /// <summary>
            /// 装備情報グリッド設定用データ取得処理
            /// </summary>
            /// <returns></returns>
            public Dictionary<string, ValueList> GetEquipUIInfo()
            {
                Dictionary<string, ValueList> lst = new Dictionary<string, ValueList>();
                List<string> equipGenreLst = new List<string>();
                ValueList vList;
                int count = Rows.Count;
                List<int> ExclusionLst = new List<int>(new int[] { 150, 151, 4, 6, 7, 3, 1, 100, 153 });
                for (int i = 0; i < count; i++)
                {
                    CEqpDefDspInfoRow equipRow = (CEqpDefDspInfoRow)Rows[i];
                    if (ExclusionLst.Contains(equipRow.EquipmentGenreCd))
                    {
                        continue;
                    }

                    if (lst.ContainsKey(equipRow.EquipmentGenreNm))
                    {
                        vList = lst[equipRow.EquipmentGenreNm];
                        ValueListItem item = new ValueListItem(equipRow.EquipmentName);
                        item.Appearance.Image = EquipmentIconResourceManagement.Equipment_ImageList16.Images[equipRow.EquipmentIconCode];
                        vList.ValueListItems.Add(item);
                        if (equipRow.SelectionState)
                        {
                            vList.SelectedItem = item;
                        }
                    }
                    else
                    {
                        vList = new ValueList();
                        vList.DisplayStyle = ValueListDisplayStyle.DataValueAndPicture;
                        vList.Key = equipRow.EquipmentGenreNm;
                        ValueListItem item = new ValueListItem(equipRow.EquipmentName);

                        item.Appearance.Image = EquipmentIconResourceManagement.Equipment_ImageList16.Images[equipRow.EquipmentIconCode];
                        vList.ValueListItems.Add(item);
                        if (equipRow.SelectionState)
                        {
                            vList.SelectedItem = item;
                        }
                        lst.Add(vList.Key, vList);
                    }
                }

                return lst;
            }
            #endregion
        }

        /// <summary>
        /// 
        /// </summary>
        public partial class CEqpDefDspInfoRow : DataRow
        {

            private CEqpDefDspInfoDataTable tableCEqpDefDspInfo;


            internal CEqpDefDspInfoRow(DataRowBuilder rb)
                :
                    base(rb)
            {
                this.tableCEqpDefDspInfo = ((CEqpDefDspInfoDataTable)(this.Table));
            }

            /// <summary>
            /// 
            /// </summary>
            public int MakerCode
            {
                get
                {
                    return ((int)(this[this.tableCEqpDefDspInfo.MakerCodeColumn]));
                }
                set
                {
                    this[this.tableCEqpDefDspInfo.MakerCodeColumn] = value;
                }
            }

            /// <summary>
            /// 
            /// </summary>
            public int ModelCode
            {
                get
                {
                    return ((int)(this[this.tableCEqpDefDspInfo.ModelCodeColumn]));
                }
                set
                {
                    this[this.tableCEqpDefDspInfo.ModelCodeColumn] = value;
                }
            }

            /// <summary>
            /// 
            /// </summary>
            public int ModelSubCode
            {
                get
                {
                    return ((int)(this[this.tableCEqpDefDspInfo.ModelSubCodeColumn]));
                }
                set
                {
                    this[this.tableCEqpDefDspInfo.ModelSubCodeColumn] = value;
                }
            }

            /// <summary>
            /// 
            /// </summary>
            public int SystematicCode
            {
                get
                {
                    return ((int)(this[this.tableCEqpDefDspInfo.SystematicCodeColumn]));
                }
                set
                {
                    this[this.tableCEqpDefDspInfo.SystematicCodeColumn] = value;
                }
            }

            /// <summary>
            /// 
            /// </summary>
            public int EquipmentDispOrder
            {
                get
                {
                    return ((int)(this[this.tableCEqpDefDspInfo.EquipmentDispOrderColumn]));
                }
                set
                {
                    this[this.tableCEqpDefDspInfo.EquipmentDispOrderColumn] = value;
                }
            }

            /// <summary>
            /// 
            /// </summary>
            public int EquipmentGenreCd
            {
                get
                {
                    return ((int)(this[this.tableCEqpDefDspInfo.EquipmentGenreCdColumn]));
                }
                set
                {
                    this[this.tableCEqpDefDspInfo.EquipmentGenreCdColumn] = value;
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
                        return ((string)(this[this.tableCEqpDefDspInfo.EquipmentGenreNmColumn]));
                    }
                }
                set
                {
                    this[this.tableCEqpDefDspInfo.EquipmentGenreNmColumn] = value;
                }
            }

            /// <summary>
            /// 
            /// </summary>
            public int EquipmentCode
            {
                get
                {
                    return ((int)(this[this.tableCEqpDefDspInfo.EquipmentCodeColumn]));
                }
                set
                {
                    this[this.tableCEqpDefDspInfo.EquipmentCodeColumn] = value;
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
                        return ((string)(this[this.tableCEqpDefDspInfo.EquipmentNameColumn]));
                    }
                }
                set
                {
                    this[this.tableCEqpDefDspInfo.EquipmentNameColumn] = value;
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
                        return ((string)(this[this.tableCEqpDefDspInfo.EquipmentShortNameColumn]));
                    }
                }
                set
                {
                    this[this.tableCEqpDefDspInfo.EquipmentShortNameColumn] = value;
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
                        return ((int)(this[this.tableCEqpDefDspInfo.EquipmentIconCodeColumn]));
                    }
                    catch (global::System.InvalidCastException e)
                    {
                        throw new StrongTypingException("テーブル \'CEqpDefDspInfo\' にある列 \'EquipmentIconCode\' の値は DBNull です。", e);
                    }
                }
                set
                {
                    this[this.tableCEqpDefDspInfo.EquipmentIconCodeColumn] = value;
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
                        return ((bool)(this[this.tableCEqpDefDspInfo.SelectionStateColumn]));
                    }
                    catch (global::System.InvalidCastException e)
                    {
                        throw new StrongTypingException("テーブル \'CEqpDefDspInfo\' にある列 \'SelectionState\' の値は DBNull です。", e);
                    }
                }
                set
                {
                    this[this.tableCEqpDefDspInfo.SelectionStateColumn] = value;
                }
            }

            /// <summary>
            /// 
            /// </summary>
            public bool IsEquipmentGenreNmNull()
            {
                return this.IsNull(this.tableCEqpDefDspInfo.EquipmentGenreNmColumn);
            }

            /// <summary>
            /// 
            /// </summary>
            public void SetEquipmentGenreNmNull()
            {
                this[this.tableCEqpDefDspInfo.EquipmentGenreNmColumn] = global::System.Convert.DBNull;
            }

            /// <summary>
            /// 
            /// </summary>
            public bool IsEquipmentNameNull()
            {
                return this.IsNull(this.tableCEqpDefDspInfo.EquipmentNameColumn);
            }

            /// <summary>
            /// 
            /// </summary>
            public void SetEquipmentNameNull()
            {
                this[this.tableCEqpDefDspInfo.EquipmentNameColumn] = global::System.Convert.DBNull;
            }

            /// <summary>
            /// 
            /// </summary>
            public bool IsEquipmentShortNameNull()
            {
                return this.IsNull(this.tableCEqpDefDspInfo.EquipmentShortNameColumn);
            }

            /// <summary>
            /// 
            /// </summary>
            public void SetEquipmentShortNameNull()
            {
                this[this.tableCEqpDefDspInfo.EquipmentShortNameColumn] = global::System.Convert.DBNull;
            }

            /// <summary>
            /// 
            /// </summary>
            public bool IsEquipmentIconCodeNull()
            {
                return this.IsNull(this.tableCEqpDefDspInfo.EquipmentIconCodeColumn);
            }

            /// <summary>
            /// 
            /// </summary>
            public void SetEquipmentIconCodeNull()
            {
                this[this.tableCEqpDefDspInfo.EquipmentIconCodeColumn] = global::System.Convert.DBNull;
            }

            /// <summary>
            /// 
            /// </summary>
            public bool IsSelectionStateNull()
            {
                return this.IsNull(this.tableCEqpDefDspInfo.SelectionStateColumn);
            }

            /// <summary>
            /// 
            /// </summary>
            public void SetSelectionStateNull()
            {
                this[this.tableCEqpDefDspInfo.SelectionStateColumn] = global::System.Convert.DBNull;
            }
        }

    }
}
