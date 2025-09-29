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
        /// 型式情報クラス
        /// </summary>
        /// <remarks>
        /// <br>Note       : 型式情報を格納するデータテーブルです。</br>
        /// <br>Programmer : 30290</br>
        /// <br>Date       : 2008.05.15</br>
        /// <br></br>
        /// <br>Update Note: 2010/04/21  22018  鈴木 正臣</br>
        /// <br>             自由検索オプション対応（自由検索型式固定番号,自由検索ソート区分の追加）</br>
        /// <br></br>
        /// <br>Update Note: 2010/06/04  22018  鈴木 正臣</br>
        /// <br>             成果物統合</br>
        /// <br>               自由検索 2010/04/21 の組込</br>
        /// <br></br>
        /// <br>Update Note: 2012/05/28 20056 對馬 大輔</br>
        /// <br>             SCM改良 No135</br>
        /// <br>Update Note: 2013/02/14 30744 湯上 千加子</br>
        /// <br>             SCM障害№10354対応 2013/03/06配信</br>
        /// <br>Update Note: 2013/02/22 30744 湯上 千加子</br>
        /// <br>             2013/03/13配信システムテスト障害№121対応</br>
        /// <br>Update Note: 2013/03/19 FSI斎藤 和宏</br>
        /// <br>           : 10900269-00 SPK車台番号文字列対応</br>
        /// <br>Update Note: 2014/02/26 脇田 靖之</br>
        /// <br>             仕掛一覧№2309対応</br>
        /// </remarks>
        public class CarModelInfoDataTable : DataTable, IEnumerable
        {
            #region [DataColumn 定義]
            private DataColumn columnMakerCode;

            private DataColumn columnMakerFullName;
            private DataColumn columnMakerHalfName;

            private DataColumn columnModelCode;

            private DataColumn columnModelSubCode;

            private DataColumn columnModelFullName;
            private DataColumn columnModelHalfName;

            private DataColumn columnSystematicCode;

            private DataColumn columnSystematicName;

            private DataColumn columnProduceTypeOfYearCd;

            private DataColumn columnProduceTypeOfYearNm;

            private DataColumn columnStProduceTypeOfYear;

            private DataColumn columnEdProduceTypeOfYear;

            private DataColumn columnStProduceYear;
            private DataColumn columnEdProduceYear;

            private DataColumn columnDoorCount;

            private DataColumn columnBodyNameCode;

            private DataColumn columnBodyName;

            private DataColumn columnCarProperNo;

            private DataColumn columnFullModelFixedNo;

            private DataColumn columnExhaustGasSign;

            private DataColumn columnSeriesModel;

            private DataColumn columnCategorySignModel;

            private DataColumn columnFullModel;

            private DataColumn columnFrameModel;

            private DataColumn columnStProduceFrameNo;

            private DataColumn columnEdProduceFrameNo;

            private DataColumn columnModelGradeNm;

            private DataColumn columnEngineModelNm;

            private DataColumn columnEngineDisplaceNm;

            private DataColumn columnEDivNm;

            private DataColumn columnTransmissionNm;

            private DataColumn columnShiftNm;

            private DataColumn columnWheelDriveMethodNm;

            private DataColumn columnAddiCarSpec1;

            private DataColumn columnAddiCarSpec2;

            private DataColumn columnAddiCarSpec3;

            private DataColumn columnAddiCarSpec4;

            private DataColumn columnAddiCarSpec5;

            private DataColumn columnAddiCarSpec6;

            private DataColumn columnAddiCarSpecTitle1;

            private DataColumn columnAddiCarSpecTitle2;

            private DataColumn columnAddiCarSpecTitle3;

            private DataColumn columnAddiCarSpecTitle4;

            private DataColumn columnAddiCarSpecTitle5;

            private DataColumn columnAddiCarSpecTitle6;

            private DataColumn columnRelevanceModel;

            private DataColumn columnSubCarNmCd;

            private DataColumn columnModelGradeSname;

            private DataColumn columnBlockIllustrationCd;

            private DataColumn columnThreeDIllustNo;

            private DataColumn columnPartsDataOfferFlag;

            private DataColumn columnSelectionState;

            // --- ADD m.suzuki 2010/04/21 ---------->>>>>
            private DataColumn columnFreeSrchMdlFxdNo;

            private DataColumn columnFreeSearchSortDiv;
            // --- ADD m.suzuki 2010/04/21 ----------<<<<<

            private DataColumn columnGradeFullName; // 2012/05/28

            // --- ADD 2013/03/19 ---------->>>>>
            private DataColumn columnDomesticForeignCode;   // 国産/外車区分
            private DataColumn columnDomesticForeignName;   // 国産/外車区分名称
            private DataColumn columnHandleInfoCd;     // ハンドル位置
            private DataColumn columnHandleInfoNm;    // ハンドル位置名称
            // --- ADD 2013/03/19 ----------<<<<<
            #endregion

            /// <summary>
            /// 
            /// </summary>
            public CarModelInfoDataTable()
            {
                this.TableName = "CarModelInfo";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            internal CarModelInfoDataTable(DataTable table)
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
            protected CarModelInfoDataTable(global::System.Runtime.Serialization.SerializationInfo info, global::System.Runtime.Serialization.StreamingContext context)
                :
                    base(info, context)
            {
                this.InitVars();
            }

            #region [ コラム ]
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
            public DataColumn SystematicNameColumn
            {
                get
                {
                    return this.columnSystematicName;
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
            /// <summary>
            /// 
            /// </summary>
            public DataColumn ProduceTypeOfYearNmColumn
            {
                get
                {
                    return this.columnProduceTypeOfYearNm;
                }
            }
            /// <summary>
            /// 
            /// </summary>
            public DataColumn StProduceTypeOfYearColumn
            {
                get
                {
                    return this.columnStProduceTypeOfYear;
                }
            }
            /// <summary>
            /// 
            /// </summary>
            public DataColumn EdProduceTypeOfYearColumn
            {
                get
                {
                    return this.columnEdProduceTypeOfYear;
                }
            }
            /// <summary>
            /// 和暦表示用
            /// </summary>
            public DataColumn StProduceYearColumn
            {
                get
                {
                    return this.columnStProduceYear;
                }
            }
            /// <summary>
            /// 和暦表示用
            /// </summary>
            public DataColumn EdProduceYearColumn
            {
                get
                {
                    return this.columnEdProduceYear;
                }
            }
            /// <summary>
            /// 
            /// </summary>
            public DataColumn DoorCountColumn
            {
                get
                {
                    return this.columnDoorCount;
                }
            }
            /// <summary>
            /// 
            /// </summary>
            public DataColumn BodyNameCodeColumn
            {
                get
                {
                    return this.columnBodyNameCode;
                }
            }
            /// <summary>
            /// 
            /// </summary>
            public DataColumn BodyNameColumn
            {
                get
                {
                    return this.columnBodyName;
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
            public DataColumn ExhaustGasSignColumn
            {
                get
                {
                    return this.columnExhaustGasSign;
                }
            }
            /// <summary>
            /// 
            /// </summary>
            public DataColumn SeriesModelColumn
            {
                get
                {
                    return this.columnSeriesModel;
                }
            }
            /// <summary>
            /// 
            /// </summary>
            public DataColumn CategorySignModelColumn
            {
                get
                {
                    return this.columnCategorySignModel;
                }
            }
            /// <summary>
            /// 
            /// </summary>
            public DataColumn FullModelColumn
            {
                get
                {
                    return this.columnFullModel;
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
            public DataColumn ModelGradeNmColumn
            {
                get
                {
                    return this.columnModelGradeNm;
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
            public DataColumn EngineDisplaceNmColumn
            {
                get
                {
                    return this.columnEngineDisplaceNm;
                }
            }
            /// <summary>
            /// 
            /// </summary>
            public DataColumn EDivNmColumn
            {
                get
                {
                    return this.columnEDivNm;
                }
            }
            /// <summary>
            /// 
            /// </summary>
            public DataColumn TransmissionNmColumn
            {
                get
                {
                    return this.columnTransmissionNm;
                }
            }
            /// <summary>
            /// 
            /// </summary>
            public DataColumn ShiftNmColumn
            {
                get
                {
                    return this.columnShiftNm;
                }
            }
            /// <summary>
            /// 
            /// </summary>
            public DataColumn WheelDriveMethodNmColumn
            {
                get
                {
                    return this.columnWheelDriveMethodNm;
                }
            }
            /// <summary>
            /// 
            /// </summary>
            public DataColumn AddiCarSpec1Column
            {
                get
                {
                    return this.columnAddiCarSpec1;
                }
            }
            /// <summary>
            /// 
            /// </summary>
            public DataColumn AddiCarSpec2Column
            {
                get
                {
                    return this.columnAddiCarSpec2;
                }
            }
            /// <summary>
            /// 
            /// </summary>
            public DataColumn AddiCarSpec3Column
            {
                get
                {
                    return this.columnAddiCarSpec3;
                }
            }
            /// <summary>
            /// 
            /// </summary>
            public DataColumn AddiCarSpec4Column
            {
                get
                {
                    return this.columnAddiCarSpec4;
                }
            }
            /// <summary>
            /// 
            /// </summary>
            public DataColumn AddiCarSpec5Column
            {
                get
                {
                    return this.columnAddiCarSpec5;
                }
            }
            /// <summary>
            /// 
            /// </summary>
            public DataColumn AddiCarSpec6Column
            {
                get
                {
                    return this.columnAddiCarSpec6;
                }
            }
            /// <summary>
            /// 
            /// </summary>
            public DataColumn AddiCarSpecTitle1Column
            {
                get
                {
                    return this.columnAddiCarSpecTitle1;
                }
            }
            /// <summary>
            /// 
            /// </summary>
            public DataColumn AddiCarSpecTitle2Column
            {
                get
                {
                    return this.columnAddiCarSpecTitle2;
                }
            }
            /// <summary>
            /// 
            /// </summary>
            public DataColumn AddiCarSpecTitle3Column
            {
                get
                {
                    return this.columnAddiCarSpecTitle3;
                }
            }
            /// <summary>
            /// 
            /// </summary>
            public DataColumn AddiCarSpecTitle4Column
            {
                get
                {
                    return this.columnAddiCarSpecTitle4;
                }
            }
            /// <summary>
            /// 
            /// </summary>
            public DataColumn AddiCarSpecTitle5Column
            {
                get
                {
                    return this.columnAddiCarSpecTitle5;
                }
            }
            /// <summary>
            /// 
            /// </summary>
            public DataColumn AddiCarSpecTitle6Column
            {
                get
                {
                    return this.columnAddiCarSpecTitle6;
                }
            }
            /// <summary>
            /// 
            /// </summary>
            public DataColumn RelevanceModelColumn
            {
                get
                {
                    return this.columnRelevanceModel;
                }
            }
            /// <summary>
            /// 
            /// </summary>
            public DataColumn SubCarNmCdColumn
            {
                get
                {
                    return this.columnSubCarNmCd;
                }
            }
            /// <summary>
            /// 
            /// </summary>
            public DataColumn ModelGradeSnameColumn
            {
                get
                {
                    return this.columnModelGradeSname;
                }
            }
            /// <summary>
            /// 
            /// </summary>
            public DataColumn BlockIllustrationCdColumn
            {
                get
                {
                    return this.columnBlockIllustrationCd;
                }
            }
            /// <summary>
            /// 
            /// </summary>
            public DataColumn ThreeDIllustNoColumn
            {
                get
                {
                    return this.columnThreeDIllustNo;
                }
            }
            /// <summary>
            /// 
            /// </summary>
            public DataColumn PartsDataOfferFlagColumn
            {
                get
                {
                    return this.columnPartsDataOfferFlag;
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
            // --- ADD m.suzuki 2010/04/21 ---------->>>>>
            /// <summary>
            /// 
            /// </summary>
            public DataColumn FreeSrchMdlFxdNoColumn
            {
                get
                {
                    return this.columnFreeSrchMdlFxdNo;
                }
            }
            /// <summary>
            /// 
            /// </summary>
            public DataColumn FreeSearchSortDivColumn
            {
                get
                {
                    return this.columnFreeSearchSortDiv;
                }
            }
            // --- ADD m.suzuki 2010/04/21 ----------<<<<<
            #endregion

            //>>>2012/05/28
            public DataColumn GradeFullNameColumn
            {
                get
                {
                    return this.columnGradeFullName;
                }
            }
            //<<<2012/05/28

            // --- ADD 2013/03/19 ---------->>>>>
            /// <summary> 国産/外車区分 </summary>
            public DataColumn DomesticForeignCodeColumn
            {
                get
                {
                    return this.columnDomesticForeignCode;
                }
            }

            /// <summary> 国産/外車区分名称 </summary>
            public DataColumn DomesticForeignNameColumn
            {
                get
                {
                    return this.columnDomesticForeignName;
                }
            }

            /// <summary> ハンドル位置 </summary>
            public DataColumn HandleInfoCdColumn
            {
                get
                {
                    return this.columnHandleInfoCd;
                }
            }

            /// <summary> ハンドル位置名称 </summary>
            public DataColumn HandleInfoNmColumn
            {
                get
                {
                    return this.columnHandleInfoNm;
                }
            }
            // --- ADD 2013/03/19 ----------<<<<<

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

            #region [ 行追加・削除 ]
            /// <summary>
            /// 
            /// </summary>
            /// <param name="row"></param>
            public void AddCarModelInfoRow(CarModelInfoRow row)
            {
                this.Rows.Add(row);
            }
            /// <summary>
            /// 
            /// </summary>
            /// <param name="row"></param>
            public CarModelInfoRow AddCarModelInfoRowCopy(CarModelInfoRow row)
            {
                CarModelInfoRow rowCarModelInfoRow = ((CarModelInfoRow)(this.NewRow()));

                //row.ItemArray.CopyTo(columnValuesArray, 0);
                rowCarModelInfoRow.ItemArray = (object[])row.ItemArray.Clone();
                this.Rows.Add(rowCarModelInfoRow);
                return rowCarModelInfoRow;
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
            /// <param name="SystematicCode"></param>
            /// <param name="SystematicName"></param>
            /// <param name="ProduceTypeOfYearCd"></param>
            /// <param name="ProduceTypeOfYearNm"></param>
            /// <param name="StProduceTypeOfYear"></param>
            /// <param name="EdProduceTypeOfYear"></param>
            /// <param name="DoorCount"></param>
            /// <param name="BodyNameCode"></param>
            /// <param name="BodyName"></param>
            /// <param name="CarProperNo"></param>
            /// <param name="FullModelFixedNo"></param>
            /// <param name="ExhaustGasSign"></param>
            /// <param name="SeriesModel"></param>
            /// <param name="CategorySignModel"></param>
            /// <param name="FullModel"></param>
            /// <param name="FrameModel"></param>
            /// <param name="StProduceFrameNo"></param>
            /// <param name="EdProduceFrameNo"></param>
            /// <param name="ModelGradeNm"></param>
            /// <param name="EngineModelNm"></param>
            /// <param name="EngineDisplaceNm"></param>
            /// <param name="EDivNm"></param>
            /// <param name="TransmissionNm"></param>
            /// <param name="ShiftNm"></param>
            /// <param name="WheelDriveMethodNm"></param>
            /// <param name="AddiCarSpec1"></param>
            /// <param name="AddiCarSpec2"></param>
            /// <param name="AddiCarSpec3"></param>
            /// <param name="AddiCarSpec4"></param>
            /// <param name="AddiCarSpec5"></param>
            /// <param name="AddiCarSpec6"></param>
            /// <param name="AddiCarSpecTitle1"></param>
            /// <param name="AddiCarSpecTitle2"></param>
            /// <param name="AddiCarSpecTitle3"></param>
            /// <param name="AddiCarSpecTitle4"></param>
            /// <param name="AddiCarSpecTitle5"></param>
            /// <param name="AddiCarSpecTitle6"></param>
            /// <param name="RelevanceModel"></param>
            /// <param name="SubCarNmCd"></param>
            /// <param name="ModelGradeSname"></param>
            /// <param name="BlockIllustrationCd"></param>
            /// <param name="ThreeDIllustNo"></param>
            /// <param name="PartsDataOfferFlag"></param>
            /// <param name="SelectionState"></param>
            /// <param name="DomesticForeignCode"></param>
            /// <param name="DomesticForeignName"></param>
            /// <param name="HandleInfoCd"></param>
            /// <param name="HandleInfoNm"></param>
            /// <returns></returns>
            public CarModelInfoRow AddCarModelInfoRow(
                        int MakerCode,
                        string MakerFullName,
                        string MakerHalfName,
                        int ModelCode,
                        int ModelSubCode,
                        string ModelFullName,
                        string ModelHalfName,
                        int SystematicCode,
                        string SystematicName,
                        int ProduceTypeOfYearCd,
                        string ProduceTypeOfYearNm,
                        int StProduceTypeOfYear,
                        int EdProduceTypeOfYear,
                        int DoorCount,
                        int BodyNameCode,
                        string BodyName,
                        int CarProperNo,
                        int FullModelFixedNo,
                        string ExhaustGasSign,
                        string SeriesModel,
                        string CategorySignModel,
                        string FullModel,
                        string FrameModel,
                        int StProduceFrameNo,
                        int EdProduceFrameNo,
                        string ModelGradeNm,
                        string EngineModelNm,
                        string EngineDisplaceNm,
                        string EDivNm,
                        string TransmissionNm,
                        string ShiftNm,
                        string WheelDriveMethodNm,
                        string AddiCarSpec1,
                        string AddiCarSpec2,
                        string AddiCarSpec3,
                        string AddiCarSpec4,
                        string AddiCarSpec5,
                        string AddiCarSpec6,
                        string AddiCarSpecTitle1,
                        string AddiCarSpecTitle2,
                        string AddiCarSpecTitle3,
                        string AddiCarSpecTitle4,
                        string AddiCarSpecTitle5,
                        string AddiCarSpecTitle6,
                        string RelevanceModel,
                        int SubCarNmCd,
                        string ModelGradeSname,
                        int BlockIllustrationCd,
                        int ThreeDIllustNo,
                        int PartsDataOfferFlag,
                        bool SelectionState,
                        // --- ADD 2013/03/19 ---------->>>>>
                        int DomesticForeignCode,
                        string DomesticForeignName,
                        int HandleInfoCd,
                        string HandleInfoNm)
                        // --- ADD 2013/03/19 ----------<<<<<
            {
                CarModelInfoRow rowCarModelInfoRow = ((CarModelInfoRow)(this.NewRow()));
                object[] columnValuesArray = new object[] {
                        MakerCode,
                        MakerFullName,
                        MakerHalfName,
                        ModelCode,
                        ModelSubCode,
                        ModelFullName,
                        ModelHalfName,
                        SystematicCode,
                        SystematicName,
                        ProduceTypeOfYearCd,
                        ProduceTypeOfYearNm,
                        StProduceTypeOfYear,
                        EdProduceTypeOfYear,
                        DoorCount,
                        BodyNameCode,
                        BodyName,
                        CarProperNo,
                        FullModelFixedNo,
                        ExhaustGasSign,
                        SeriesModel,
                        CategorySignModel,
                        FullModel,
                        FrameModel,
                        StProduceFrameNo,
                        EdProduceFrameNo,
                        ModelGradeNm,
                        EngineModelNm,
                        EngineDisplaceNm,
                        EDivNm,
                        TransmissionNm,
                        ShiftNm,
                        WheelDriveMethodNm,
                        AddiCarSpec1,
                        AddiCarSpec2,
                        AddiCarSpec3,
                        AddiCarSpec4,
                        AddiCarSpec5,
                        AddiCarSpec6,
                        AddiCarSpecTitle1,
                        AddiCarSpecTitle2,
                        AddiCarSpecTitle3,
                        AddiCarSpecTitle4,
                        AddiCarSpecTitle5,
                        AddiCarSpecTitle6,
                        RelevanceModel,
                        SubCarNmCd,
                        ModelGradeSname,
                        BlockIllustrationCd,
                        ThreeDIllustNo,
                        PartsDataOfferFlag,
                        SelectionState,
                        // --- ADD 2013/03/19 ---------->>>>>
                        DomesticForeignCode,
                        DomesticForeignName,
                        HandleInfoCd,
                        HandleInfoNm};
                        // --- ADD 2013/03/19 ----------<<<<<
                rowCarModelInfoRow.ItemArray = columnValuesArray;
                this.Rows.Add(rowCarModelInfoRow);
                return rowCarModelInfoRow;
            }

            /// <summary>
            /// 
            /// </summary>
            /// <returns></returns>
            public CarModelInfoRow NewCarModelInfoRow()
            {
                return ((CarModelInfoRow)(this.NewRow()));
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="row"></param>
            public void RemoveCarModelInfoRow(CarModelInfoRow row)
            {
                this.Rows.Remove(row);
            }

            #endregion

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
                CarModelInfoDataTable cln = ((CarModelInfoDataTable)(base.Clone()));
                cln.InitVars();
                return cln;
            }
            /// <summary>
            /// 
            /// </summary>
            /// <returns></returns>
            protected override DataTable CreateInstance()
            {
                return new CarModelInfoDataTable();
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
                this.columnSystematicCode = base.Columns["SystematicCode"];
                this.columnSystematicName = base.Columns["SystematicName"];
                this.columnProduceTypeOfYearCd = base.Columns["ProduceTypeOfYearCd"];
                this.columnProduceTypeOfYearNm = base.Columns["ProduceTypeOfYearNm"];
                this.columnStProduceTypeOfYear = base.Columns["StProduceTypeOfYear"];
                this.columnEdProduceTypeOfYear = base.Columns["EdProduceTypeOfYear"];
                this.columnStProduceYear = base.Columns["StProduceYear"];
                this.columnEdProduceYear = base.Columns["EdProduceYear"];
                this.columnDoorCount = base.Columns["DoorCount"];
                this.columnBodyNameCode = base.Columns["BodyNameCode"];
                this.columnBodyName = base.Columns["BodyName"];
                this.columnCarProperNo = base.Columns["CarProperNo"];
                this.columnFullModelFixedNo = base.Columns["FullModelFixedNo"];
                this.columnExhaustGasSign = base.Columns["ExhaustGasSign"];
                this.columnSeriesModel = base.Columns["SeriesModel"];
                this.columnCategorySignModel = base.Columns["CategorySignModel"];
                this.columnFullModel = base.Columns["FullModel"];
                this.columnFrameModel = base.Columns["FrameModel"];
                this.columnStProduceFrameNo = base.Columns["StProduceFrameNo"];
                this.columnEdProduceFrameNo = base.Columns["EdProduceFrameNo"];
                this.columnModelGradeNm = base.Columns["ModelGradeNm"];
                this.columnEngineModelNm = base.Columns["EngineModelNm"];
                this.columnEngineDisplaceNm = base.Columns["EngineDisplaceNm"];
                this.columnEDivNm = base.Columns["EDivNm"];
                this.columnTransmissionNm = base.Columns["TransmissionNm"];
                this.columnShiftNm = base.Columns["ShiftNm"];
                this.columnWheelDriveMethodNm = base.Columns["WheelDriveMethodNm"];
                this.columnAddiCarSpec1 = base.Columns["AddiCarSpec1"];
                this.columnAddiCarSpec2 = base.Columns["AddiCarSpec2"];
                this.columnAddiCarSpec3 = base.Columns["AddiCarSpec3"];
                this.columnAddiCarSpec4 = base.Columns["AddiCarSpec4"];
                this.columnAddiCarSpec5 = base.Columns["AddiCarSpec5"];
                this.columnAddiCarSpec6 = base.Columns["AddiCarSpec6"];
                this.columnAddiCarSpecTitle1 = base.Columns["AddiCarSpecTitle1"];
                this.columnAddiCarSpecTitle2 = base.Columns["AddiCarSpecTitle2"];
                this.columnAddiCarSpecTitle3 = base.Columns["AddiCarSpecTitle3"];
                this.columnAddiCarSpecTitle4 = base.Columns["AddiCarSpecTitle4"];
                this.columnAddiCarSpecTitle5 = base.Columns["AddiCarSpecTitle5"];
                this.columnAddiCarSpecTitle6 = base.Columns["AddiCarSpecTitle6"];
                this.columnRelevanceModel = base.Columns["RelevanceModel"];
                this.columnSubCarNmCd = base.Columns["SubCarNmCd"];
                this.columnModelGradeSname = base.Columns["ModelGradeSname"];
                this.columnBlockIllustrationCd = base.Columns["BlockIllustrationCd"];
                this.columnThreeDIllustNo = base.Columns["ThreeDIllustNo"];
                this.columnPartsDataOfferFlag = base.Columns["PartsDataOfferFlag"];
                this.columnSelectionState = base.Columns["SelectionState"];
                // --- ADD m.suzuki 2010/04/21 ---------->>>>>
                this.columnFreeSrchMdlFxdNo = base.Columns["FreeSrchMdlFxdNo"];
                this.columnFreeSearchSortDiv = base.Columns["FreeSearchSortDiv"];
                // --- ADD m.suzuki 2010/04/21 ----------<<<<<
                this.columnGradeFullName = base.Columns["GradeFullName"]; // 2012/05/28
                // --- ADD 2013/03/19 ---------->>>>>
                this.columnDomesticForeignCode = base.Columns["DomesticForeignCode"];
                this.columnDomesticForeignName = base.Columns["DomesticForeignName"];
                this.columnHandleInfoCd = base.Columns["HandleInfoCd"];
                this.columnHandleInfoNm = base.Columns["HandleInfoNm"];
                // --- ADD 2013/03/19 ----------<<<<<
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
                this.columnSystematicCode = new DataColumn("SystematicCode", typeof(int), null, MappingType.Element);
                base.Columns.Add(this.columnSystematicCode);
                this.columnSystematicName = new DataColumn("SystematicName", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnSystematicName);
                this.columnProduceTypeOfYearCd = new DataColumn("ProduceTypeOfYearCd", typeof(int), null, MappingType.Element);
                base.Columns.Add(this.columnProduceTypeOfYearCd);
                this.columnProduceTypeOfYearNm = new DataColumn("ProduceTypeOfYearNm", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnProduceTypeOfYearNm);
                this.columnStProduceTypeOfYear = new DataColumn("StProduceTypeOfYear", typeof(int), null, MappingType.Element);
                base.Columns.Add(this.columnStProduceTypeOfYear);
                this.columnEdProduceTypeOfYear = new DataColumn("EdProduceTypeOfYear", typeof(int), null, MappingType.Element);
                base.Columns.Add(this.columnEdProduceTypeOfYear);
                this.columnStProduceYear = new DataColumn("StProduceYear", typeof(DateTime), null, MappingType.Element);
                base.Columns.Add(this.columnStProduceYear);
                this.columnEdProduceYear = new DataColumn("EdProduceYear", typeof(DateTime), null, MappingType.Element);
                base.Columns.Add(this.columnEdProduceYear);
                this.columnDoorCount = new DataColumn("DoorCount", typeof(int), null, MappingType.Element);
                base.Columns.Add(this.columnDoorCount);
                this.columnBodyNameCode = new DataColumn("BodyNameCode", typeof(int), null, MappingType.Element);
                base.Columns.Add(this.columnBodyNameCode);
                this.columnBodyName = new DataColumn("BodyName", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnBodyName);
                this.columnCarProperNo = new DataColumn("CarProperNo", typeof(int), null, MappingType.Element);
                base.Columns.Add(this.columnCarProperNo);
                this.columnFullModelFixedNo = new DataColumn("FullModelFixedNo", typeof(int), null, MappingType.Element);
                base.Columns.Add(this.columnFullModelFixedNo);
                this.columnExhaustGasSign = new DataColumn("ExhaustGasSign", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnExhaustGasSign);
                this.columnSeriesModel = new DataColumn("SeriesModel", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnSeriesModel);
                this.columnCategorySignModel = new DataColumn("CategorySignModel", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnCategorySignModel);
                this.columnFullModel = new DataColumn("FullModel", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnFullModel);
                this.columnFrameModel = new DataColumn("FrameModel", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnFrameModel);
                this.columnStProduceFrameNo = new DataColumn("StProduceFrameNo", typeof(int), null, MappingType.Element);
                base.Columns.Add(this.columnStProduceFrameNo);
                this.columnEdProduceFrameNo = new DataColumn("EdProduceFrameNo", typeof(int), null, MappingType.Element);
                base.Columns.Add(this.columnEdProduceFrameNo);
                this.columnModelGradeNm = new DataColumn("ModelGradeNm", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnModelGradeNm);
                this.columnEngineModelNm = new DataColumn("EngineModelNm", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnEngineModelNm);
                this.columnEngineDisplaceNm = new DataColumn("EngineDisplaceNm", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnEngineDisplaceNm);
                this.columnEDivNm = new DataColumn("EDivNm", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnEDivNm);
                this.columnTransmissionNm = new DataColumn("TransmissionNm", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnTransmissionNm);
                this.columnShiftNm = new DataColumn("ShiftNm", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnShiftNm);
                this.columnWheelDriveMethodNm = new DataColumn("WheelDriveMethodNm", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnWheelDriveMethodNm);
                this.columnAddiCarSpec1 = new DataColumn("AddiCarSpec1", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnAddiCarSpec1);
                this.columnAddiCarSpec2 = new DataColumn("AddiCarSpec2", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnAddiCarSpec2);
                this.columnAddiCarSpec3 = new DataColumn("AddiCarSpec3", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnAddiCarSpec3);
                this.columnAddiCarSpec4 = new DataColumn("AddiCarSpec4", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnAddiCarSpec4);
                this.columnAddiCarSpec5 = new DataColumn("AddiCarSpec5", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnAddiCarSpec5);
                this.columnAddiCarSpec6 = new DataColumn("AddiCarSpec6", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnAddiCarSpec6);
                this.columnAddiCarSpecTitle1 = new DataColumn("AddiCarSpecTitle1", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnAddiCarSpecTitle1);
                this.columnAddiCarSpecTitle2 = new DataColumn("AddiCarSpecTitle2", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnAddiCarSpecTitle2);
                this.columnAddiCarSpecTitle3 = new DataColumn("AddiCarSpecTitle3", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnAddiCarSpecTitle3);
                this.columnAddiCarSpecTitle4 = new DataColumn("AddiCarSpecTitle4", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnAddiCarSpecTitle4);
                this.columnAddiCarSpecTitle5 = new DataColumn("AddiCarSpecTitle5", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnAddiCarSpecTitle5);
                this.columnAddiCarSpecTitle6 = new DataColumn("AddiCarSpecTitle6", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnAddiCarSpecTitle6);
                this.columnRelevanceModel = new DataColumn("RelevanceModel", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnRelevanceModel);
                this.columnSubCarNmCd = new DataColumn("SubCarNmCd", typeof(int), null, MappingType.Element);
                base.Columns.Add(this.columnSubCarNmCd);
                this.columnModelGradeSname = new DataColumn("ModelGradeSname", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnModelGradeSname);
                this.columnBlockIllustrationCd = new DataColumn("BlockIllustrationCd", typeof(int), null, MappingType.Element);
                base.Columns.Add(this.columnBlockIllustrationCd);
                this.columnThreeDIllustNo = new DataColumn("ThreeDIllustNo", typeof(int), null, MappingType.Element);
                base.Columns.Add(this.columnThreeDIllustNo);
                this.columnPartsDataOfferFlag = new DataColumn("PartsDataOfferFlag", typeof(int), null, MappingType.Element);
                base.Columns.Add(this.columnPartsDataOfferFlag);
                this.columnSelectionState = new DataColumn("SelectionState", typeof(bool), null, MappingType.Element);
                base.Columns.Add(this.columnSelectionState);
                // --- ADD m.suzuki 2010/04/21 ---------->>>>>
                this.columnFreeSrchMdlFxdNo = new DataColumn( "FreeSrchMdlFxdNo", typeof( string ), null, MappingType.Element );
                base.Columns.Add( this.columnFreeSrchMdlFxdNo );
                this.columnFreeSearchSortDiv = new DataColumn( "FreeSearchSortDiv", typeof( int ), null, MappingType.Element );
                base.Columns.Add( this.columnFreeSearchSortDiv );
                // --- ADD m.suzuki 2010/04/21 ----------<<<<<
                //>>>2012/05/28
                this.columnGradeFullName = new DataColumn("GradeFullName", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnGradeFullName);
                //<<<2012/05/28

                // --- ADD 2013/03/19 ---------->>>>>
                this.columnDomesticForeignCode = new DataColumn("DomesticForeignCode", typeof(int), null, MappingType.Element);
                base.Columns.Add(this.columnDomesticForeignCode);
                this.columnDomesticForeignName = new DataColumn("DomesticForeignName", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnDomesticForeignName);
                this.columnHandleInfoCd = new DataColumn("HandleInfoCd", typeof(int), null, MappingType.Element);
                base.Columns.Add(this.columnHandleInfoCd);
                this.columnHandleInfoNm = new DataColumn("HandleInfoNm", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnHandleInfoNm);
                // --- ADD 2013/03/19 ----------<<<<<

                this.columnMakerCode.AllowDBNull = false;
                this.columnMakerCode.Caption = "メーカーコード";
                this.columnMakerFullName.Caption = "メーカー全角名称";
                this.columnMakerFullName.MaxLength = 15;
                this.columnModelCode.AllowDBNull = false;
                this.columnModelCode.Caption = "車種コード";
                this.columnModelSubCode.AllowDBNull = false;
                this.columnModelSubCode.Caption = "車種サブコード";
                this.columnModelFullName.Caption = "車種全角名称";
                this.columnModelFullName.MaxLength = 15;
                this.columnSystematicCode.AllowDBNull = false;
                this.columnSystematicCode.Caption = "系統コード";
                this.columnSystematicName.Caption = "系統名称";
                this.columnSystematicName.MaxLength = 40;
                this.columnProduceTypeOfYearCd.AllowDBNull = false;
                this.columnProduceTypeOfYearCd.Caption = "生産年式コード";
                this.columnProduceTypeOfYearNm.Caption = "生産年式名称";
                this.columnProduceTypeOfYearNm.MaxLength = 40;
                this.columnStProduceTypeOfYear.Caption = "生産年式(開始)";
                this.columnStProduceYear.Caption = "生産年式(開始)";
                this.columnStProduceYear.DefaultValue = DateTime.MinValue;
                this.columnEdProduceYear.DefaultValue = DateTime.MinValue;
                //this.columnEdProduceTypeOfYear.Caption = "生産年式(終了)";
                this.columnDoorCount.AllowDBNull = false;
                this.columnDoorCount.Caption = "ドア";
                this.columnBodyNameCode.AllowDBNull = false;
                this.columnBodyNameCode.Caption = "ボディー名コード";
                this.columnBodyName.Caption = "ボディー";
                this.columnBodyName.MaxLength = 10;
                this.columnCarProperNo.AllowDBNull = false;
                this.columnCarProperNo.Caption = "車両固有番号";
                this.columnFullModelFixedNo.Caption = "フル型式固定番号";
                this.columnExhaustGasSign.Caption = "排ガス記号";
                this.columnSeriesModel.Caption = "シリーズ型式";
                this.columnSeriesModel.MaxLength = 20;
                this.columnCategorySignModel.Caption = "型式（類別記号）";
                this.columnCategorySignModel.MaxLength = 20;
                this.columnFullModel.AllowDBNull = false;
                this.columnFullModel.Caption = "型式";
                this.columnFullModel.MaxLength = 44;
                this.columnFrameModel.Caption = "車台型式";
                this.columnFrameModel.MaxLength = 16;
                this.columnStProduceFrameNo.Caption = "車台番号(開始)";
                this.columnEdProduceFrameNo.Caption = "車台番号(終了)";
                this.columnModelGradeNm.Caption = "グレード";
                this.columnModelGradeNm.MaxLength = 20;
                this.columnEngineModelNm.Caption = "エンジン";
                this.columnEngineModelNm.MaxLength = 12;
                this.columnEngineDisplaceNm.Caption = "排気量";
                this.columnEngineDisplaceNm.MaxLength = 8;
                this.columnEDivNm.Caption = "E区分";
                this.columnEDivNm.MaxLength = 8;
                this.columnTransmissionNm.Caption = "ミッション";
                this.columnTransmissionNm.MaxLength = 8;
                this.columnShiftNm.Caption = "ｼﾌﾄ";
                this.columnShiftNm.MaxLength = 8;
                this.columnWheelDriveMethodNm.Caption = "駆動方式";
                this.columnWheelDriveMethodNm.MaxLength = 15;
                this.columnAddiCarSpec1.Caption = "追加諸元1";
                this.columnAddiCarSpec1.MaxLength = 8;
                this.columnAddiCarSpec2.Caption = "追加諸元2";
                this.columnAddiCarSpec2.MaxLength = 8;
                this.columnAddiCarSpec3.Caption = "追加諸元3";
                this.columnAddiCarSpec3.MaxLength = 8;
                this.columnAddiCarSpec4.Caption = "追加諸元4";
                this.columnAddiCarSpec4.MaxLength = 8;
                this.columnAddiCarSpec5.Caption = "追加諸元5";
                this.columnAddiCarSpec5.MaxLength = 8;
                this.columnAddiCarSpec6.Caption = "追加諸元6";
                this.columnAddiCarSpec6.MaxLength = 8;
                this.columnAddiCarSpecTitle1.AllowDBNull = false;
                this.columnAddiCarSpecTitle1.Caption = "追加諸元タイトル1";
                this.columnAddiCarSpecTitle1.MaxLength = 8;
                this.columnAddiCarSpecTitle2.AllowDBNull = false;
                this.columnAddiCarSpecTitle2.Caption = "追加諸元タイトル2";
                this.columnAddiCarSpecTitle2.MaxLength = 8;
                this.columnAddiCarSpecTitle3.AllowDBNull = false;
                this.columnAddiCarSpecTitle3.Caption = "追加諸元タイトル3";
                this.columnAddiCarSpecTitle3.MaxLength = 8;
                this.columnAddiCarSpecTitle4.AllowDBNull = false;
                this.columnAddiCarSpecTitle4.Caption = "追加諸元タイトル4";
                this.columnAddiCarSpecTitle4.MaxLength = 8;
                this.columnAddiCarSpecTitle5.AllowDBNull = false;
                this.columnAddiCarSpecTitle5.Caption = "追加諸元タイトル5";
                this.columnAddiCarSpecTitle5.MaxLength = 8;
                this.columnAddiCarSpecTitle6.AllowDBNull = false;
                this.columnAddiCarSpecTitle6.Caption = "追加諸元タイトル6";
                this.columnAddiCarSpecTitle6.MaxLength = 8;
                this.columnRelevanceModel.Caption = "関連型式";
                this.columnRelevanceModel.MaxLength = 15;
                this.columnSubCarNmCd.Caption = "サブ車名コード";
                this.columnModelGradeSname.Caption = "型式グレード略称";
                this.columnModelGradeSname.MaxLength = 8;
                this.columnBlockIllustrationCd.Caption = "ブロックイラストコード";
                this.columnThreeDIllustNo.Caption = "3DイラストNo";
                this.columnPartsDataOfferFlag.Caption = "部品収録";
                this.columnSelectionState.Caption = "選択状態";
                this.columnSelectionState.DefaultValue = false;
                // --- ADD m.suzuki 2010/04/21 ---------->>>>>
                this.columnFreeSrchMdlFxdNo.Caption = "自由検索型式固定番号";
                this.columnFreeSearchSortDiv.Caption = "";
                // --- ADD m.suzuki 2010/04/21 ----------<<<<<
                this.columnGradeFullName.Caption = "グレード(全角)"; // 2012/05/28

                // --- ADD 2013/03/19 ---------->>>>>
                this.columnDomesticForeignCode.AllowDBNull = false;
                this.columnDomesticForeignCode.Caption = "国産/外車区分";
                this.columnDomesticForeignName.AllowDBNull = false;
                this.columnDomesticForeignName.Caption = "国産/外車区分名称";
                this.columnDomesticForeignName.MaxLength = 6;
                this.columnHandleInfoCd.AllowDBNull = false;
                this.columnHandleInfoCd.Caption = "ハンドル位置";
                this.columnHandleInfoNm.AllowDBNull = false;
                this.columnHandleInfoNm.Caption = "ハンドル位置名称";
                this.columnHandleInfoNm.MaxLength = 12;
                // --- ADD 2013/03/19 ----------<<<<<

                this.CaseSensitive = true;
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="index"></param>
            /// <returns></returns>
            public CarModelInfoRow this[int index]
            {
                get
                {
                    return ((CarModelInfoRow)(this.Rows[index]));
                }
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="builder"></param>
            /// <returns></returns>
            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new CarModelInfoRow(builder);
            }

            /// <summary>
            /// 
            /// </summary>
            /// <returns></returns>
            protected override global::System.Type GetRowType()
            {
                return typeof(CarModelInfoRow);
            }

            /// <summary>
            /// 車両管理マスタにセットするフル型式固定番号配列を作成します。
            /// </summary>
            /// <param name="selectedRowOnly">true :選択状態がtrueの行のフル型式固定番号のみ取得する / false : 全ての行</param>
            /// <returns></returns>
            // UPD 2013/02/14 SCM障害№10354対応 2013/03/06配信--------------------------------------------------->>>>>
            //public int[] GetFullModelFixedNoArray(bool selectedRowOnly)
            public int[] GetFullModelFixedNoArray(bool selectedRowOnly, string FrameNo, int ProduceTypeOfYearInput)
            // UPD 2013/02/14 SCM障害№10354対応 ---------------------------------------------------<<<<<
            {
                int rowCount = Rows.Count;
                //int[] lst = new int[rowCount];
                List<int> lst = new List<int>();
                for (int i = 0; i < rowCount; i++)
                {
                    if (selectedRowOnly && Rows[i][SelectionStateColumn].Equals(false))
                        continue;
                    // --- ADD m.suzuki 2010/04/21 ---------->>>>>
                    // 自由検索分は除外
                    if ( Rows[i][FreeSrchMdlFxdNoColumn] != null &&
                         Rows[i][FreeSrchMdlFxdNoColumn] != DBNull.Value &&
                         Rows[i][FreeSrchMdlFxdNoColumn].ToString().Trim() != string.Empty )
                    {
                        continue;
                    }
                    // --- ADD m.suzuki 2010/04/21 ----------<<<<<
                    // ADD 2013/02/14 SCM障害№10354対応 2013/03/06配信--------------------------------------------------->>>>>
                    // 年式指定時は絞込みを行う
                    if (!ProduceTypeOfYearInput.Equals(0))
                    {
                        if ((int)Rows[i][StProduceTypeOfYearColumn] > ProduceTypeOfYearInput ||
                            (int)Rows[i][EdProduceTypeOfYearColumn] < ProduceTypeOfYearInput)
                        {
                            continue;
                        }
                    }
                    // 車台番号指定時は絞込みを行う
                    if (!FrameNo.Length.Equals(0))
                    {
                        // UPD 2013/02/22 2013/03/13配信 システムテスト障害№121対応 ---------------------------->>>>>
                        //int iStCompare = string.Compare(Rows[i][StProduceFrameNoColumn].ToString(), FrameNo);
                        //int iEdCompare = string.Compare(Rows[i][EdProduceFrameNoColumn].ToString(), FrameNo);
                        //if (iStCompare > 0 || iEdCompare < 0)
                        //{
                        //    continue;
                        //}
                        // 車台番号が設定されている車輌についてのみ絞込みを行う
                        if (!Rows[i][StProduceFrameNoColumn].ToString().Equals("0") ||
                            !Rows[i][EdProduceFrameNoColumn].ToString().Equals("0"))
                        {
                            // --- UPD 2014/02/26 y.wakita ----->>>>>
                            //int iStCompare = string.Compare(Rows[i][StProduceFrameNoColumn].ToString(), FrameNo);
                            //int iEdCompare = string.Compare(Rows[i][EdProduceFrameNoColumn].ToString(), FrameNo);
                            int iStCompare = string.Compare(Rows[i][StProduceFrameNoColumn].ToString(), Convert.ToInt32(FrameNo).ToString());
                            int iEdCompare = string.Compare(Rows[i][EdProduceFrameNoColumn].ToString(), Convert.ToInt32(FrameNo).ToString());
                            // --- UPD 2014/02/26 y.wakita -----<<<<<
                            if (iStCompare > 0 || iEdCompare < 0)
                            {
                                continue;
                            }
                        }
                        // UPD 2013/02/22 2013/03/13配信 システムテスト障害№121対応 ----------------------------<<<<<
                    }
                    // ADD 2013/02/14 SCM障害№10354対応 ---------------------------------------------------<<<<<
                    if (Rows[i][FullModelFixedNoColumn].Equals(0) == false &&
                        lst.Contains((int)Rows[i][FullModelFixedNoColumn]) == false)
                        lst.Add((int)Rows[i][FullModelFixedNoColumn]);
                }
                int[] retVal = new int[lst.Count];
                lst.CopyTo(retVal);
                return retVal;
            }
            // --- ADD m.suzuki 2010/04/21 ---------->>>>>
            /// <summary>
            /// 車両管理マスタにセットするフル型式固定番号配列を作成します。
            /// </summary>
            /// <param name="selectedRowOnly">true :選択状態がtrueの行のフル型式固定番号のみ取得する / false : 全ての行</param>
            /// <param name="fullModelFixedNoArray"></param>
            /// <param name="freeSrchMdlFxdNoArray"></param>
            /// <returns></returns>
            public void GetFullModelFixedNoArrayWithFreeSrchMdlFxdNoArray( bool selectedRowOnly, out int[] fullModelFixedNoArray, out string[] freeSrchMdlFxdNoArray )
            {
                fullModelFixedNoArray = new int[0];
                freeSrchMdlFxdNoArray = new string[0];

                int rowCount = Rows.Count;
                List<int> lst = new List<int>();
                List<string> fslst = new List<string>();
                for ( int i = 0; i < rowCount; i++ )
                {
                    if ( selectedRowOnly && Rows[i][SelectionStateColumn].Equals( false ) )
                        continue;

                    // 自由検索分は除外
                    if ( Rows[i][FreeSrchMdlFxdNoColumn] != null &&
                         Rows[i][FreeSrchMdlFxdNoColumn] != DBNull.Value &&
                         Rows[i][FreeSrchMdlFxdNoColumn].ToString().Trim() != string.Empty )
                    {
                        fslst.Add( Rows[i][FreeSrchMdlFxdNoColumn].ToString().Trim() );
                    }
                    else
                    {
                        if ( Rows[i][FullModelFixedNoColumn].Equals( 0 ) == false &&
                            lst.Contains( (int)Rows[i][FullModelFixedNoColumn] ) == false )
                        {
                            lst.Add( (int)Rows[i][FullModelFixedNoColumn] );
                        }
                    }
                }

                fullModelFixedNoArray = lst.ToArray();
                freeSrchMdlFxdNoArray = fslst.ToArray();
            }
            // --- ADD m.suzuki 2010/04/21 ----------<<<<<
        }

        /// <summary>
        /// 
        /// </summary>
        public class CarModelInfoRow : DataRow
        {

            private CarModelInfoDataTable tableCarModelInfo;

            internal CarModelInfoRow(DataRowBuilder rb)
                :
                    base(rb)
            {
                this.tableCarModelInfo = ((CarModelInfoDataTable)(this.Table));
            }
            /// <summary>
            /// 
            /// </summary>
            public int MakerCode
            {
                get
                {
                    return ((int)(this[this.tableCarModelInfo.MakerCodeColumn]));
                }
                set
                {
                    this[this.tableCarModelInfo.MakerCodeColumn] = value;
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
                        return ((string)(this[this.tableCarModelInfo.MakerFullNameColumn]));
                    }
                }
                set
                {
                    this[this.tableCarModelInfo.MakerFullNameColumn] = value;
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
                        return ((string)(this[this.tableCarModelInfo.MakerHalfNameColumn]));
                    }
                }
                set
                {
                    this[this.tableCarModelInfo.MakerHalfNameColumn] = value;
                }
            }
            /// <summary>
            /// 
            /// </summary>
            public int ModelCode
            {
                get
                {
                    return ((int)(this[this.tableCarModelInfo.ModelCodeColumn]));
                }
                set
                {
                    this[this.tableCarModelInfo.ModelCodeColumn] = value;
                }
            }
            /// <summary>
            /// 
            /// </summary>
            public int ModelSubCode
            {
                get
                {
                    return ((int)(this[this.tableCarModelInfo.ModelSubCodeColumn]));
                }
                set
                {
                    this[this.tableCarModelInfo.ModelSubCodeColumn] = value;
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
                        return ((string)(this[this.tableCarModelInfo.ModelFullNameColumn]));
                    }
                }
                set
                {
                    this[this.tableCarModelInfo.ModelFullNameColumn] = value;
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
                        return ((string)(this[this.tableCarModelInfo.ModelHalfNameColumn]));
                    }
                }
                set
                {
                    this[this.tableCarModelInfo.ModelHalfNameColumn] = value;
                }
            }
            /// <summary>
            /// 
            /// </summary>
            public int SystematicCode
            {
                get
                {
                    return ((int)(this[this.tableCarModelInfo.SystematicCodeColumn]));
                }
                set
                {
                    this[this.tableCarModelInfo.SystematicCodeColumn] = value;
                }
            }
            /// <summary>
            /// 
            /// </summary>
            public string SystematicName
            {
                get
                {
                    if (this.IsSystematicNameNull())
                    {
                        return string.Empty;
                    }
                    else
                    {
                        return ((string)(this[this.tableCarModelInfo.SystematicNameColumn]));
                    }
                }
                set
                {
                    this[this.tableCarModelInfo.SystematicNameColumn] = value;
                }
            }
            /// <summary>
            /// 
            /// </summary>
            public int ProduceTypeOfYearCd
            {
                get
                {
                    return ((int)(this[this.tableCarModelInfo.ProduceTypeOfYearCdColumn]));
                }
                set
                {
                    this[this.tableCarModelInfo.ProduceTypeOfYearCdColumn] = value;
                }
            }
            /// <summary>
            /// 
            /// </summary>
            public string ProduceTypeOfYearNm
            {
                get
                {
                    if (this.IsProduceTypeOfYearNmNull())
                    {
                        return string.Empty;
                    }
                    else
                    {
                        return ((string)(this[this.tableCarModelInfo.ProduceTypeOfYearNmColumn]));
                    }
                }
                set
                {
                    this[this.tableCarModelInfo.ProduceTypeOfYearNmColumn] = value;
                }
            }
            /// <summary>
            /// 
            /// </summary>
            public int StProduceTypeOfYear
            {
                get
                {
                    try
                    {
                        return ((int)(this[this.tableCarModelInfo.StProduceTypeOfYearColumn]));
                    }
                    catch (global::System.InvalidCastException e)
                    {
                        throw new StrongTypingException("テーブル \'CarModelInfo\' にある列 \'StProduceTypeOfYear\' の値は DBNull です。", e);
                    }
                }
                set
                {
                    this[this.tableCarModelInfo.StProduceTypeOfYearColumn] = value;
                }
            }
            /// <summary>
            /// 
            /// </summary>
            public int EdProduceTypeOfYear
            {
                get
                {
                    try
                    {
                        return ((int)(this[this.tableCarModelInfo.EdProduceTypeOfYearColumn]));
                    }
                    catch (global::System.InvalidCastException e)
                    {
                        throw new StrongTypingException("テーブル \'CarModelInfo\' にある列 \'EdProduceTypeOfYear\' の値は DBNull です。", e);
                    }
                }
                set
                {
                    this[this.tableCarModelInfo.EdProduceTypeOfYearColumn] = value;
                }
            }
            /// <summary>
            /// 
            /// </summary>
            public DateTime StProduceYear
            {
                get
                {
                    try
                    {
                        return ((DateTime)(this[this.tableCarModelInfo.StProduceYearColumn]));
                    }
                    catch { return DateTime.MinValue; }
                }
                set
                {
                    this[this.tableCarModelInfo.StProduceYearColumn] = value;
                }
            }
            /// <summary>
            /// 
            /// </summary>
            public DateTime EdProduceYear
            {
                get
                {
                    try
                    {
                        return ((DateTime)(this[this.tableCarModelInfo.EdProduceYearColumn]));
                    }
                    catch { return DateTime.MinValue; }
                }
                set
                {
                    this[this.tableCarModelInfo.EdProduceYearColumn] = value;
                }
            }
            /// <summary>
            /// 
            /// </summary>
            public int DoorCount
            {
                get
                {
                    return ((int)(this[this.tableCarModelInfo.DoorCountColumn]));
                }
                set
                {
                    this[this.tableCarModelInfo.DoorCountColumn] = value;
                }
            }
            /// <summary>
            /// 
            /// </summary>
            public int BodyNameCode
            {
                get
                {
                    return ((int)(this[this.tableCarModelInfo.BodyNameCodeColumn]));
                }
                set
                {
                    this[this.tableCarModelInfo.BodyNameCodeColumn] = value;
                }
            }
            /// <summary>
            /// 
            /// </summary>
            public string BodyName
            {
                get
                {
                    if (this.IsBodyNameNull())
                    {
                        return string.Empty;
                    }
                    else
                    {
                        return ((string)(this[this.tableCarModelInfo.BodyNameColumn]));
                    }
                }
                set
                {
                    this[this.tableCarModelInfo.BodyNameColumn] = value;
                }
            }
            /// <summary>
            /// 
            /// </summary>
            public int CarProperNo
            {
                get
                {
                    return ((int)(this[this.tableCarModelInfo.CarProperNoColumn]));
                }
                set
                {
                    this[this.tableCarModelInfo.CarProperNoColumn] = value;
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
                        return ((int)(this[this.tableCarModelInfo.FullModelFixedNoColumn]));
                    }
                    catch (global::System.InvalidCastException e)
                    {
                        throw new StrongTypingException("テーブル \'CarModelInfo\' にある列 \'FullModelFixedNo\' の値は DBNull です。", e);
                    }
                }
                set
                {
                    this[this.tableCarModelInfo.FullModelFixedNoColumn] = value;
                }
            }
            /// <summary>
            /// 
            /// </summary>
            public string ExhaustGasSign
            {
                get
                {
                    if (this.IsExhaustGasSignNull())
                    {
                        return string.Empty;
                    }
                    else
                    {
                        return ((string)(this[this.tableCarModelInfo.ExhaustGasSignColumn]));
                    }
                }
                set
                {
                    this[this.tableCarModelInfo.ExhaustGasSignColumn] = value;
                }
            }
            /// <summary>
            /// 
            /// </summary>
            public string SeriesModel
            {
                get
                {
                    if (this.IsSeriesModelNull())
                    {
                        return string.Empty;
                    }
                    else
                    {
                        return ((string)(this[this.tableCarModelInfo.SeriesModelColumn]));
                    }
                }
                set
                {
                    this[this.tableCarModelInfo.SeriesModelColumn] = value;
                }
            }
            /// <summary>
            /// 
            /// </summary>
            public string CategorySignModel
            {
                get
                {
                    if (this.IsCategorySignModelNull())
                    {
                        return string.Empty;
                    }
                    else
                    {
                        return ((string)(this[this.tableCarModelInfo.CategorySignModelColumn]));
                    }
                }
                set
                {
                    this[this.tableCarModelInfo.CategorySignModelColumn] = value;
                }
            }
            /// <summary>
            /// 
            /// </summary>
            public string FullModel
            {
                get
                {
                    return ((string)(this[this.tableCarModelInfo.FullModelColumn]));
                }
                set
                {
                    this[this.tableCarModelInfo.FullModelColumn] = value;
                }
            }
            /// <summary>
            /// 
            /// </summary>
            public string FrameModel
            {
                get
                {
                    if (this.IsFrameModelNull())
                    {
                        return string.Empty;
                    }
                    else
                    {
                        return ((string)(this[this.tableCarModelInfo.FrameModelColumn]));
                    }
                }
                set
                {
                    this[this.tableCarModelInfo.FrameModelColumn] = value;
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
                        return ((int)(this[this.tableCarModelInfo.StProduceFrameNoColumn]));
                    }
                    catch (global::System.InvalidCastException e)
                    {
                        throw new StrongTypingException("テーブル \'CarModelInfo\' にある列 \'StProduceFrameNo\' の値は DBNull です。", e);
                    }
                }
                set
                {
                    this[this.tableCarModelInfo.StProduceFrameNoColumn] = value;
                }
            }
            /// <summary>
            /// 
            /// </summary>
            public int EdProduceFrameNo
            {
                get
                {
                    try
                    {
                        return ((int)(this[this.tableCarModelInfo.EdProduceFrameNoColumn]));
                    }
                    catch (global::System.InvalidCastException e)
                    {
                        throw new StrongTypingException("テーブル \'CarModelInfo\' にある列 \'EdProduceFrameNo\' の値は DBNull です。", e);
                    }
                }
                set
                {
                    this[this.tableCarModelInfo.EdProduceFrameNoColumn] = value;
                }
            }
            /// <summary>
            /// 
            /// </summary>
            public string ModelGradeNm
            {
                get
                {
                    if (this.IsModelGradeNmNull())
                    {
                        return string.Empty;
                    }
                    else
                    {
                        return ((string)(this[this.tableCarModelInfo.ModelGradeNmColumn]));
                    }
                }
                set
                {
                    this[this.tableCarModelInfo.ModelGradeNmColumn] = value;
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
                        return ((string)(this[this.tableCarModelInfo.EngineModelNmColumn]));
                    }
                }
                set
                {
                    this[this.tableCarModelInfo.EngineModelNmColumn] = value;
                }
            }
            /// <summary>
            /// 
            /// </summary>
            public string EngineDisplaceNm
            {
                get
                {
                    if (this.IsEngineDisplaceNmNull())
                    {
                        return string.Empty;
                    }
                    else
                    {
                        return ((string)(this[this.tableCarModelInfo.EngineDisplaceNmColumn]));
                    }
                }
                set
                {
                    this[this.tableCarModelInfo.EngineDisplaceNmColumn] = value;
                }
            }
            /// <summary>
            /// 
            /// </summary>
            public string EDivNm
            {
                get
                {
                    if (this.IsEDivNmNull())
                    {
                        return string.Empty;
                    }
                    else
                    {
                        return ((string)(this[this.tableCarModelInfo.EDivNmColumn]));
                    }
                }
                set
                {
                    this[this.tableCarModelInfo.EDivNmColumn] = value;
                }
            }
            /// <summary>
            /// 
            /// </summary>
            public string TransmissionNm
            {
                get
                {
                    if (this.IsTransmissionNmNull())
                    {
                        return string.Empty;
                    }
                    else
                    {
                        return ((string)(this[this.tableCarModelInfo.TransmissionNmColumn]));
                    }
                }
                set
                {
                    this[this.tableCarModelInfo.TransmissionNmColumn] = value;
                }
            }
            /// <summary>
            /// 
            /// </summary>
            public string ShiftNm
            {
                get
                {
                    if (this.IsShiftNmNull())
                    {
                        return string.Empty;
                    }
                    else
                    {
                        return ((string)(this[this.tableCarModelInfo.ShiftNmColumn]));
                    }
                }
                set
                {
                    this[this.tableCarModelInfo.ShiftNmColumn] = value;
                }
            }
            /// <summary>
            /// 
            /// </summary>
            public string WheelDriveMethodNm
            {
                get
                {
                    if (this.IsWheelDriveMethodNm())
                    {
                        return string.Empty;
                    }
                    else
                    {
                        return ((string)(this[this.tableCarModelInfo.WheelDriveMethodNmColumn]));
                    }
                }
                set
                {
                    this[this.tableCarModelInfo.WheelDriveMethodNmColumn] = value;
                }
            }
            /// <summary>
            /// 
            /// </summary>
            public string AddiCarSpec1
            {
                get
                {
                    if (this.IsAddiCarSpec1Null())
                    {
                        return string.Empty;
                    }
                    else
                    {
                        return ((string)(this[this.tableCarModelInfo.AddiCarSpec1Column]));
                    }
                }
                set
                {
                    this[this.tableCarModelInfo.AddiCarSpec1Column] = value;
                }
            }
            /// <summary>
            /// 
            /// </summary>
            public string AddiCarSpec2
            {
                get
                {
                    if (this.IsAddiCarSpec2Null())
                    {
                        return string.Empty;
                    }
                    else
                    {
                        return ((string)(this[this.tableCarModelInfo.AddiCarSpec2Column]));
                    }
                }
                set
                {
                    this[this.tableCarModelInfo.AddiCarSpec2Column] = value;
                }
            }
            /// <summary>
            /// 
            /// </summary>
            public string AddiCarSpec3
            {
                get
                {
                    if (this.IsAddiCarSpec3Null())
                    {
                        return string.Empty;
                    }
                    else
                    {
                        return ((string)(this[this.tableCarModelInfo.AddiCarSpec3Column]));
                    }
                }
                set
                {
                    this[this.tableCarModelInfo.AddiCarSpec3Column] = value;
                }
            }
            /// <summary>
            /// 
            /// </summary>
            public string AddiCarSpec4
            {
                get
                {
                    if (this.IsAddiCarSpec4Null())
                    {
                        return string.Empty;
                    }
                    else
                    {
                        return ((string)(this[this.tableCarModelInfo.AddiCarSpec4Column]));
                    }
                }
                set
                {
                    this[this.tableCarModelInfo.AddiCarSpec4Column] = value;
                }
            }
            /// <summary>
            /// 
            /// </summary>
            public string AddiCarSpec5
            {
                get
                {
                    if (this.IsAddiCarSpec5Null())
                    {
                        return string.Empty;
                    }
                    else
                    {
                        return ((string)(this[this.tableCarModelInfo.AddiCarSpec5Column]));
                    }
                }
                set
                {
                    this[this.tableCarModelInfo.AddiCarSpec5Column] = value;
                }
            }
            /// <summary>
            /// 
            /// </summary>
            public string AddiCarSpec6
            {
                get
                {
                    if (this.IsAddiCarSpec6Null())
                    {
                        return string.Empty;
                    }
                    else
                    {
                        return ((string)(this[this.tableCarModelInfo.AddiCarSpec6Column]));
                    }
                }
                set
                {
                    this[this.tableCarModelInfo.AddiCarSpec6Column] = value;
                }
            }
            /// <summary>
            /// 
            /// </summary>
            public string AddiCarSpecTitle1
            {
                get
                {
                    return ((string)(this[this.tableCarModelInfo.AddiCarSpecTitle1Column]));
                }
                set
                {
                    this[this.tableCarModelInfo.AddiCarSpecTitle1Column] = value;
                }
            }
            /// <summary>
            /// 
            /// </summary>
            public string AddiCarSpecTitle2
            {
                get
                {
                    return ((string)(this[this.tableCarModelInfo.AddiCarSpecTitle2Column]));
                }
                set
                {
                    this[this.tableCarModelInfo.AddiCarSpecTitle2Column] = value;
                }
            }
            /// <summary>
            /// 
            /// </summary>
            public string AddiCarSpecTitle3
            {
                get
                {
                    return ((string)(this[this.tableCarModelInfo.AddiCarSpecTitle3Column]));
                }
                set
                {
                    this[this.tableCarModelInfo.AddiCarSpecTitle3Column] = value;
                }
            }
            /// <summary>
            /// 
            /// </summary>
            public string AddiCarSpecTitle4
            {
                get
                {
                    return ((string)(this[this.tableCarModelInfo.AddiCarSpecTitle4Column]));
                }
                set
                {
                    this[this.tableCarModelInfo.AddiCarSpecTitle4Column] = value;
                }
            }
            /// <summary>
            /// 
            /// </summary>
            public string AddiCarSpecTitle5
            {
                get
                {
                    return ((string)(this[this.tableCarModelInfo.AddiCarSpecTitle5Column]));
                }
                set
                {
                    this[this.tableCarModelInfo.AddiCarSpecTitle5Column] = value;
                }
            }
            /// <summary>
            /// 
            /// </summary>
            public string AddiCarSpecTitle6
            {
                get
                {
                    return ((string)(this[this.tableCarModelInfo.AddiCarSpecTitle6Column]));
                }
                set
                {
                    this[this.tableCarModelInfo.AddiCarSpecTitle6Column] = value;
                }
            }
            /// <summary>
            /// 
            /// </summary>
            public string RelevanceModel
            {
                get
                {
                    if (this.IsRelevanceModelNull())
                    {
                        return string.Empty;
                    }
                    else
                    {
                        return ((string)(this[this.tableCarModelInfo.RelevanceModelColumn]));
                    }
                }
                set
                {
                    this[this.tableCarModelInfo.RelevanceModelColumn] = value;
                }
            }
            /// <summary>
            /// 
            /// </summary>
            public int SubCarNmCd
            {
                get
                {
                    try
                    {
                        return ((int)(this[this.tableCarModelInfo.SubCarNmCdColumn]));
                    }
                    catch (global::System.InvalidCastException e)
                    {
                        throw new StrongTypingException("テーブル \'CarModelInfo\' にある列 \'SubCarNmCd\' の値は DBNull です。", e);
                    }
                }
                set
                {
                    this[this.tableCarModelInfo.SubCarNmCdColumn] = value;
                }
            }
            /// <summary>
            /// 
            /// </summary>
            public string ModelGradeSname
            {
                get
                {
                    if (this.IsModelGradeSnameNull())
                    {
                        return string.Empty;
                    }
                    else
                    {
                        return ((string)(this[this.tableCarModelInfo.ModelGradeSnameColumn]));
                    }
                }
                set
                {
                    this[this.tableCarModelInfo.ModelGradeSnameColumn] = value;
                }
            }
            /// <summary>
            /// 
            /// </summary>
            public int BlockIllustrationCd
            {
                get
                {
                    try
                    {
                        return ((int)(this[this.tableCarModelInfo.BlockIllustrationCdColumn]));
                    }
                    catch (global::System.InvalidCastException e)
                    {
                        throw new StrongTypingException("テーブル \'CarModelInfo\' にある列 \'BlockIllustrationCd\' の値は DBNull です。", e);
                    }
                }
                set
                {
                    this[this.tableCarModelInfo.BlockIllustrationCdColumn] = value;
                }
            }
            /// <summary>
            /// 
            /// </summary>
            public int ThreeDIllustNo
            {
                get
                {
                    try
                    {
                        return ((int)(this[this.tableCarModelInfo.ThreeDIllustNoColumn]));
                    }
                    catch (global::System.InvalidCastException e)
                    {
                        throw new StrongTypingException("テーブル \'CarModelInfo\' にある列 \'ThreeDIllustNo\' の値は DBNull です。", e);
                    }
                }
                set
                {
                    this[this.tableCarModelInfo.ThreeDIllustNoColumn] = value;
                }
            }
            /// <summary>
            /// 
            /// </summary>
            public int PartsDataOfferFlag
            {
                get
                {
                    try
                    {
                        return ((int)(this[this.tableCarModelInfo.PartsDataOfferFlagColumn]));
                    }
                    catch (global::System.InvalidCastException e)
                    {
                        throw new StrongTypingException("テーブル \'CarModelInfo\' にある列 \'PartsDataOfferFlag\' の値は DBNull です。", e);
                    }
                }
                set
                {
                    this[this.tableCarModelInfo.PartsDataOfferFlagColumn] = value;
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
                        return ((bool)(this[this.tableCarModelInfo.SelectionStateColumn]));
                    }
                    catch (global::System.InvalidCastException e)
                    {
                        throw new StrongTypingException("テーブル \'CarModelInfo\' にある列 \'SelectionState\' の値は DBNull です。", e);
                    }
                }
                set
                {
                    this[this.tableCarModelInfo.SelectionStateColumn] = value;
                }
            }
            // --- ADD m.suzuki 2010/04/21 ---------->>>>>
            /// <summary>
            /// 
            /// </summary>
            public string FreeSrchMdlFxdNo
            {
                get
                {
                    try
                    {
                        return ((string)(this[this.tableCarModelInfo.FreeSrchMdlFxdNoColumn]));
                    }
                    catch ( global::System.InvalidCastException e )
                    {
                        throw new StrongTypingException( "テーブル \'CarModelInfo\' にある列 \'FreeSrchMdlFxdNo\' の値は DBNull です。", e );
                    }
                }
                set
                {
                    this[this.tableCarModelInfo.FreeSrchMdlFxdNoColumn] = value;
                }
            }
            /// <summary>
            /// 
            /// </summary>
            public int FreeSearchSortDiv
            {
                get
                {
                    try
                    {
                        return ((int)(this[this.tableCarModelInfo.FreeSearchSortDivColumn]));
                    }
                    catch ( global::System.InvalidCastException e )
                    {
                        throw new StrongTypingException( "テーブル \'CarModelInfo\' にある列 \'FreeSearchSortDiv\' の値は DBNull です。", e );
                    }
                }
                set
                {
                    this[this.tableCarModelInfo.FreeSearchSortDivColumn] = value;
                }
            }
            // --- ADD m.suzuki 2010/04/21 ----------<<<<<
            
            //>>>2012/05/28
            /// <summary>
            /// 
            /// </summary>
            public string GradeFullName
            {
                get
                {
                    try
                    {
                        return ((string)(this[this.tableCarModelInfo.GradeFullNameColumn]));
                    }
                    catch (global::System.InvalidCastException e)
                    {
                        throw new StrongTypingException("テーブル \'CarModelInfo\' にある列 \'GradeFullName\' の値は DBNull です。", e);
                    }
                }
                set
                {
                    this[this.tableCarModelInfo.GradeFullNameColumn] = value;
                }
            }
            //<<<2012/05/28

            // --- ADD 2013/03/19 ---------->>>>>
            /// <summary> 国産/外車区分 </summary>
            public int DomesticForeignCode
            {
                get
                {
                    return ((int)(this[this.tableCarModelInfo.DomesticForeignCodeColumn]));
                }
                set
                {
                    this[this.tableCarModelInfo.DomesticForeignCodeColumn] = value;
                }
            }

            /// <summary> 国産/外車区分名称 </summary>
            public string DomesticForeignName
            {
                get
                {
                    if (this.IsDomesticForeignNameNull())
                    {
                        return string.Empty;
                    }
                    else
                    {
                        return ((string)(this[this.tableCarModelInfo.DomesticForeignNameColumn]));
                    }
                }
                set
                {
                    this[this.tableCarModelInfo.DomesticForeignNameColumn] = value;
                }
            }

            /// <summary> ハンドル位置 </summary>
            public int HandleInfoCd
            {
                get
                {
                    return ((int)(this[this.tableCarModelInfo.HandleInfoCdColumn]));
                }
                set
                {
                    this[this.tableCarModelInfo.HandleInfoCdColumn] = value;
                }
            }

            /// <summary> ハンドル位置名称 </summary>
            public string HandleInfoNm
            {
                get
                {
                    if (this.IsHandleInfoNmNull())
                    {
                        return string.Empty;
                    }
                    else
                    {
                        return ((string)(this[this.tableCarModelInfo.HandleInfoNmColumn]));
                    }
                }
                set
                {
                    this[this.tableCarModelInfo.HandleInfoNmColumn] = value;
                }
            }
            // --- ADD 2013/03/19 ----------<<<<<

            /// <summary>
            /// 
            /// </summary>
            public bool IsMakerFullNameNull()
            {
                return this.IsNull(this.tableCarModelInfo.MakerFullNameColumn);
            }
            /// <summary>
            /// 
            /// </summary>
            public void SetMakerFullNameNull()
            {
                this[this.tableCarModelInfo.MakerFullNameColumn] = global::System.Convert.DBNull;
            }
            /// <summary>
            /// 
            /// </summary>
            /// <returns></returns>
            public bool IsMakerHalfNameNull()
            {
                return this.IsNull(this.tableCarModelInfo.MakerHalfNameColumn);
            }
            /// <summary>
            /// 
            /// </summary>
            public bool IsModelFullNameNull()
            {
                return this.IsNull(this.tableCarModelInfo.ModelFullNameColumn);
            }
            /// <summary>
            /// 
            /// </summary>
            public void SetModelFullNameNull()
            {
                this[this.tableCarModelInfo.ModelFullNameColumn] = global::System.Convert.DBNull;
            }
            /// <summary>
            /// 
            /// </summary>
            /// <returns></returns>
            public bool IsModelHalfNameNull()
            {
                return this.IsNull(this.tableCarModelInfo.ModelHalfNameColumn);
            }
            /// <summary>
            /// 
            /// </summary>
            public bool IsSystematicNameNull()
            {
                return this.IsNull(this.tableCarModelInfo.SystematicNameColumn);
            }
            /// <summary>
            /// 
            /// </summary>
            public void SetSystematicNameNull()
            {
                this[this.tableCarModelInfo.SystematicNameColumn] = global::System.Convert.DBNull;
            }
            /// <summary>
            /// 
            /// </summary>
            public bool IsProduceTypeOfYearNmNull()
            {
                return this.IsNull(this.tableCarModelInfo.ProduceTypeOfYearNmColumn);
            }
            /// <summary>
            /// 
            /// </summary>
            public void SetProduceTypeOfYearNmNull()
            {
                this[this.tableCarModelInfo.ProduceTypeOfYearNmColumn] = global::System.Convert.DBNull;
            }
            /// <summary>
            /// 
            /// </summary>
            public bool IsStProduceTypeOfYearNull()
            {
                return this.IsNull(this.tableCarModelInfo.StProduceTypeOfYearColumn);
            }
            /// <summary>
            /// 
            /// </summary>
            public void SetStProduceTypeOfYearNull()
            {
                this[this.tableCarModelInfo.StProduceTypeOfYearColumn] = global::System.Convert.DBNull;
            }
            /// <summary>
            /// 
            /// </summary>
            public bool IsEdProduceTypeOfYearNull()
            {
                return this.IsNull(this.tableCarModelInfo.EdProduceTypeOfYearColumn);
            }
            /// <summary>
            /// 
            /// </summary>
            public void SetEdProduceTypeOfYearNull()
            {
                this[this.tableCarModelInfo.EdProduceTypeOfYearColumn] = global::System.Convert.DBNull;
            }
            /// <summary>
            /// 
            /// </summary>
            public bool IsBodyNameNull()
            {
                return this.IsNull(this.tableCarModelInfo.BodyNameColumn);
            }
            /// <summary>
            /// 
            /// </summary>
            public void SetBodyNameNull()
            {
                this[this.tableCarModelInfo.BodyNameColumn] = global::System.Convert.DBNull;
            }
            /// <summary>
            /// 
            /// </summary>
            public bool IsFullModelFixedNoNull()
            {
                return this.IsNull(this.tableCarModelInfo.FullModelFixedNoColumn);
            }
            /// <summary>
            /// 
            /// </summary>
            public void SetFullModelFixedNoNull()
            {
                this[this.tableCarModelInfo.FullModelFixedNoColumn] = global::System.Convert.DBNull;
            }
            /// <summary>
            /// 
            /// </summary>
            public bool IsExhaustGasSignNull()
            {
                return this.IsNull(this.tableCarModelInfo.ExhaustGasSignColumn);
            }
            /// <summary>
            /// 
            /// </summary>
            public void SetExhaustGasSignNull()
            {
                this[this.tableCarModelInfo.ExhaustGasSignColumn] = global::System.Convert.DBNull;
            }
            /// <summary>
            /// 
            /// </summary>
            public bool IsSeriesModelNull()
            {
                return this.IsNull(this.tableCarModelInfo.SeriesModelColumn);
            }
            /// <summary>
            /// 
            /// </summary>
            public void SetSeriesModelNull()
            {
                this[this.tableCarModelInfo.SeriesModelColumn] = global::System.Convert.DBNull;
            }
            /// <summary>
            /// 
            /// </summary>
            public bool IsCategorySignModelNull()
            {
                return this.IsNull(this.tableCarModelInfo.CategorySignModelColumn);
            }
            /// <summary>
            /// 
            /// </summary>
            public void SetCategorySignModelNull()
            {
                this[this.tableCarModelInfo.CategorySignModelColumn] = global::System.Convert.DBNull;
            }
            /// <summary>
            /// 
            /// </summary>
            public bool IsFrameModelNull()
            {
                return this.IsNull(this.tableCarModelInfo.FrameModelColumn);
            }
            /// <summary>
            /// 
            /// </summary>
            public void SetFrameModelNull()
            {
                this[this.tableCarModelInfo.FrameModelColumn] = global::System.Convert.DBNull;
            }
            /// <summary>
            /// 
            /// </summary>
            public bool IsStProduceFrameNoNull()
            {
                return this.IsNull(this.tableCarModelInfo.StProduceFrameNoColumn);
            }
            /// <summary>
            /// 
            /// </summary>
            public void SetStProduceFrameNoNull()
            {
                this[this.tableCarModelInfo.StProduceFrameNoColumn] = global::System.Convert.DBNull;
            }
            /// <summary>
            /// 
            /// </summary>
            public bool IsEdProduceFrameNoNull()
            {
                return this.IsNull(this.tableCarModelInfo.EdProduceFrameNoColumn);
            }
            /// <summary>
            /// 
            /// </summary>
            public void SetEdProduceFrameNoNull()
            {
                this[this.tableCarModelInfo.EdProduceFrameNoColumn] = global::System.Convert.DBNull;
            }
            /// <summary>
            /// 
            /// </summary>
            public bool IsModelGradeNmNull()
            {
                return this.IsNull(this.tableCarModelInfo.ModelGradeNmColumn);
            }
            /// <summary>
            /// 
            /// </summary>
            public void SetModelGradeNmNull()
            {
                this[this.tableCarModelInfo.ModelGradeNmColumn] = global::System.Convert.DBNull;
            }
            /// <summary>
            /// 
            /// </summary>
            public bool IsEngineModelNmNull()
            {
                return this.IsNull(this.tableCarModelInfo.EngineModelNmColumn);
            }
            /// <summary>
            /// 
            /// </summary>
            public void SetEngineModelNmNull()
            {
                this[this.tableCarModelInfo.EngineModelNmColumn] = global::System.Convert.DBNull;
            }
            /// <summary>
            /// 
            /// </summary>
            public bool IsEngineDisplaceNmNull()
            {
                return this.IsNull(this.tableCarModelInfo.EngineDisplaceNmColumn);
            }
            /// <summary>
            /// 
            /// </summary>
            public void SetEngineDisplaceNmNull()
            {
                this[this.tableCarModelInfo.EngineDisplaceNmColumn] = global::System.Convert.DBNull;
            }
            /// <summary>
            /// 
            /// </summary>
            public bool IsEDivNmNull()
            {
                return this.IsNull(this.tableCarModelInfo.EDivNmColumn);
            }
            /// <summary>
            /// 
            /// </summary>
            public void SetEDivNmNull()
            {
                this[this.tableCarModelInfo.EDivNmColumn] = global::System.Convert.DBNull;
            }
            /// <summary>
            /// 
            /// </summary>
            public bool IsTransmissionNmNull()
            {
                return this.IsNull(this.tableCarModelInfo.TransmissionNmColumn);
            }
            /// <summary>
            /// 
            /// </summary>
            public void SetTransmissionNmNull()
            {
                this[this.tableCarModelInfo.TransmissionNmColumn] = global::System.Convert.DBNull;
            }
            /// <summary>
            /// 
            /// </summary>
            public bool IsShiftNmNull()
            {
                return this.IsNull(this.tableCarModelInfo.ShiftNmColumn);
            }
            /// <summary>
            /// 
            /// </summary>
            public void SetShiftNmNull()
            {
                this[this.tableCarModelInfo.ShiftNmColumn] = global::System.Convert.DBNull;
            }
            /// <summary>
            /// 
            /// </summary>
            /// <returns></returns>
            public bool IsWheelDriveMethodNm()
            {
                return this.IsNull(this.tableCarModelInfo.WheelDriveMethodNmColumn);
            }
            /// <summary>
            /// 
            /// </summary>
            public void SetWheelDriveMethodNmNull()
            {
                this[this.tableCarModelInfo.WheelDriveMethodNmColumn] = global::System.Convert.DBNull;
            }
            /// <summary>
            /// 
            /// </summary>
            public bool IsAddiCarSpec1Null()
            {
                return this.IsNull(this.tableCarModelInfo.AddiCarSpec1Column);
            }
            /// <summary>
            /// 
            /// </summary>
            public void SetAddiCarSpec1Null()
            {
                this[this.tableCarModelInfo.AddiCarSpec1Column] = global::System.Convert.DBNull;
            }
            /// <summary>
            /// 
            /// </summary>
            public bool IsAddiCarSpec2Null()
            {
                return this.IsNull(this.tableCarModelInfo.AddiCarSpec2Column);
            }
            /// <summary>
            /// 
            /// </summary>
            public void SetAddiCarSpec2Null()
            {
                this[this.tableCarModelInfo.AddiCarSpec2Column] = global::System.Convert.DBNull;
            }
            /// <summary>
            /// 
            /// </summary>
            public bool IsAddiCarSpec3Null()
            {
                return this.IsNull(this.tableCarModelInfo.AddiCarSpec3Column);
            }
            /// <summary>
            /// 
            /// </summary>
            public void SetAddiCarSpec3Null()
            {
                this[this.tableCarModelInfo.AddiCarSpec3Column] = global::System.Convert.DBNull;
            }
            /// <summary>
            /// 
            /// </summary>
            public bool IsAddiCarSpec4Null()
            {
                return this.IsNull(this.tableCarModelInfo.AddiCarSpec4Column);
            }
            /// <summary>
            /// 
            /// </summary>
            public void SetAddiCarSpec4Null()
            {
                this[this.tableCarModelInfo.AddiCarSpec4Column] = global::System.Convert.DBNull;
            }
            /// <summary>
            /// 
            /// </summary>
            public bool IsAddiCarSpec5Null()
            {
                return this.IsNull(this.tableCarModelInfo.AddiCarSpec5Column);
            }
            /// <summary>
            /// 
            /// </summary>
            public void SetAddiCarSpec5Null()
            {
                this[this.tableCarModelInfo.AddiCarSpec5Column] = global::System.Convert.DBNull;
            }
            /// <summary>
            /// 
            /// </summary>
            public bool IsAddiCarSpec6Null()
            {
                return this.IsNull(this.tableCarModelInfo.AddiCarSpec6Column);
            }
            /// <summary>
            /// 
            /// </summary>
            public void SetAddiCarSpec6Null()
            {
                this[this.tableCarModelInfo.AddiCarSpec6Column] = global::System.Convert.DBNull;
            }
            /// <summary>
            /// 
            /// </summary>
            public bool IsRelevanceModelNull()
            {
                return this.IsNull(this.tableCarModelInfo.RelevanceModelColumn);
            }
            /// <summary>
            /// 
            /// </summary>
            public void SetRelevanceModelNull()
            {
                this[this.tableCarModelInfo.RelevanceModelColumn] = global::System.Convert.DBNull;
            }
            /// <summary>
            /// 
            /// </summary>
            public bool IsSubCarNmCdNull()
            {
                return this.IsNull(this.tableCarModelInfo.SubCarNmCdColumn);
            }
            /// <summary>
            /// 
            /// </summary>
            public void SetSubCarNmCdNull()
            {
                this[this.tableCarModelInfo.SubCarNmCdColumn] = global::System.Convert.DBNull;
            }
            /// <summary>
            /// 
            /// </summary>
            public bool IsModelGradeSnameNull()
            {
                return this.IsNull(this.tableCarModelInfo.ModelGradeSnameColumn);
            }
            /// <summary>
            /// 
            /// </summary>
            public void SetModelGradeSnameNull()
            {
                this[this.tableCarModelInfo.ModelGradeSnameColumn] = global::System.Convert.DBNull;
            }
            /// <summary>
            /// 
            /// </summary>
            /// <returns></returns>
            public bool IsBlockIllustrationCdNull()
            {
                return this.IsNull(this.tableCarModelInfo.BlockIllustrationCdColumn);
            }
            /// <summary>
            /// 
            /// </summary>
            public void SetBlockIllustrationCdNull()
            {
                this[this.tableCarModelInfo.BlockIllustrationCdColumn] = global::System.Convert.DBNull;
            }
            /// <summary>
            /// 
            /// </summary>
            /// <returns></returns>
            public bool IsThreeDIllustNoNull()
            {
                return this.IsNull(this.tableCarModelInfo.ThreeDIllustNoColumn);
            }
            /// <summary>
            /// 
            /// </summary>
            public void SetThreeDIllustNoNull()
            {
                this[this.tableCarModelInfo.ThreeDIllustNoColumn] = global::System.Convert.DBNull;
            }
            /// <summary>
            /// 
            /// </summary>
            /// <returns></returns>
            public bool IsPartsDataOfferFlagNull()
            {
                return this.IsNull(this.tableCarModelInfo.PartsDataOfferFlagColumn);
            }
            /// <summary>
            /// 
            /// </summary>
            public void SetPartsDataOfferFlagNull()
            {
                this[this.tableCarModelInfo.PartsDataOfferFlagColumn] = global::System.Convert.DBNull;
            }
            /// <summary>
            /// 
            /// </summary>
            /// <returns></returns>
            public bool IsSelectionStateNull()
            {
                return this.IsNull(this.tableCarModelInfo.SelectionStateColumn);
            }
            /// <summary>
            /// 
            /// </summary>
            public void SetSelectionStateNull()
            {
                this[this.tableCarModelInfo.SelectionStateColumn] = global::System.Convert.DBNull;
            }

            // --- ADD m.suzuki 2010/04/21 ---------->>>>>
            /// <summary>
            /// 
            /// </summary>
            public bool IsFreeSrchMdlFxdNoNull()
            {
                return this.IsNull( this.tableCarModelInfo.FreeSrchMdlFxdNoColumn );
            }
            /// <summary>
            /// 
            /// </summary>
            public void SetFreeSrchMdlFxdNoNull()
            {
                this[this.tableCarModelInfo.FreeSrchMdlFxdNoColumn] = global::System.Convert.DBNull;
            }

            /// <summary>
            /// 
            /// </summary>
            public bool IsFreeSearchSortDivNull()
            {
                return this.IsNull( this.tableCarModelInfo.FreeSearchSortDivColumn );
            }
            /// <summary>
            /// 
            /// </summary>
            public void SetFreeSearchSortDivNull()
            {
                this[this.tableCarModelInfo.FreeSearchSortDivColumn] = global::System.Convert.DBNull;
            }
            // --- ADD m.suzuki 2010/04/21 ----------<<<<<

            //>>>2012/05/28
            /// <summary>
            /// 
            /// </summary>
            public bool IsGradeFullNameNull()
            {
                return this.IsNull(this.tableCarModelInfo.GradeFullNameColumn);
            }
            /// <summary>
            /// 
            /// </summary>
            public void SetGradeFullNameNull()
            {
                this[this.tableCarModelInfo.GradeFullNameColumn] = global::System.Convert.DBNull;
            }
            //<<<2012/05/28

            // --- ADD 2013/03/19 ---------->>>>>
            /// <summary> 国産/外車区分名称NULLチェック </summary>
            public bool IsDomesticForeignNameNull()
            {
                return this.IsNull(this.tableCarModelInfo.DomesticForeignNameColumn);
            }

            /// <summary> ハンドル位置名称NULLチェック </summary>
            public bool IsHandleInfoNmNull()
            {
                return this.IsNull(this.tableCarModelInfo.HandleInfoNmColumn);
            }
            // --- ADD 2013/03/19 ----------<<<<<

        }

    }
}
