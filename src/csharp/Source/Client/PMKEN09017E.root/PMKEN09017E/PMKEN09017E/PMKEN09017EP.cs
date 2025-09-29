using System;
using System.Data;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Controller;

namespace Broadleaf.Application.UIData
{
    /// <summary>
	/// UI用：部品詳細（型式情報）クラス
    /// </summary>
	public class PartsDetailInfo : PartsSerchSub
    {

        # region DataTable 定義
        public const string TABLENAME_PRTDTL = "TABLENAME_MODELPARTSDETAIL";

		// 実際のメンバを記述
        public const string COL_PRTDTL_FULLMODELFIXEDNO = "FullModelFixedNo";
        public const string COL_PRTDTL_PARTS_PARTSUNIQUENO = "PartsUniqueNo";
        public const string COL_PRTDTL_DOORCOUNT = "DoorCount";
		public const string COL_PRTDTL_BODYNAME = "BodyName";
		public const string COL_PRTDTL_MODELGRADENM = "ModelGradeNm";
		public const string COL_PRTDTL_ENGINEMODELNM = "EngineModelNm";
		public const string COL_PRTDTL_ENGINEDISPLACENM = "EngineDisplaceNm";
		public const string COL_PRTDTL_EDIVNM = "EDivNm";
		public const string COL_PRTDTL_TRANSMISSIONNM = "TransmissionNm";
		public const string COL_PRTDTL_SHIFTNM = "ShiftNm";
		public const string COL_PRTDTL_ADDICARSPEC1 = "AddiCarSpec1";
		public const string COL_PRTDTL_ADDICARSPEC2 = "AddiCarSpec2";
		public const string COL_PRTDTL_ADDICARSPEC3 = "AddiCarSpec3";
		public const string COL_PRTDTL_ADDICARSPEC4 = "AddiCarSpec4";
		public const string COL_PRTDTL_ADDICARSPEC5 = "AddiCarSpec5";
		public const string COL_PRTDTL_ADDICARSPEC6 = "AddiCarSpec6";
		public const string COL_PRTDTL_ADDICARSPECTITLE1 = "AddiCarSpecTitle1";
		public const string COL_PRTDTL_ADDICARSPECTITLE2 = "AddiCarSpecTitle2";
		public const string COL_PRTDTL_ADDICARSPECTITLE3 = "AddiCarSpecTitle3";
		public const string COL_PRTDTL_ADDICARSPECTITLE4 = "AddiCarSpecTitle4";
		public const string COL_PRTDTL_ADDICARSPECTITLE5 = "AddiCarSpecTitle5";
		public const string COL_PRTDTL_ADDICARSPECTITLE6 = "AddiCarSpecTitle6";
		public const string COL_PRTDTL_PARTSMAKERCD = "PartsMakerCd";
		public const string COL_PRTDTL_PARTSNO = "PartsNo";

        public const string COL_PRTDTL_SELECTED = "Col_Selected";

		/// <summary>
        /// データテーブル作成メソッド
        /// </summary>
        /// <returns>CarKindInfo用のDataTable</returns>
        public static DataTable CreateTable(string tbl_name)
        {
			DataTable wkTable = new DataTable(tbl_name);

            wkTable.Columns.Add(CreateColumn(COL_PRTDTL_FULLMODELFIXEDNO, typeof(Int32), "フル型式固定番号"));
            wkTable.Columns.Add(CreateColumn(COL_PRTDTL_PARTS_PARTSUNIQUENO, typeof(Int64), "部品固有番号"));
            wkTable.Columns.Add(CreateColumn(COL_PRTDTL_MODELGRADENM, typeof(string), "グレード"));
            wkTable.Columns.Add(CreateColumn(COL_PRTDTL_BODYNAME, typeof(string), "ボディ"));
            wkTable.Columns.Add(CreateColumn(COL_PRTDTL_DOORCOUNT, typeof(string), "ドア"));
            wkTable.Columns.Add(CreateColumn(COL_PRTDTL_ENGINEMODELNM, typeof(string), "エンジン"));
            wkTable.Columns.Add(CreateColumn(COL_PRTDTL_ENGINEDISPLACENM, typeof(string), "排気量"));
            wkTable.Columns.Add(CreateColumn(COL_PRTDTL_EDIVNM, typeof(string), "Ｅ区分"));
            wkTable.Columns.Add(CreateColumn(COL_PRTDTL_TRANSMISSIONNM, typeof(string), "ミッション"));
            wkTable.Columns.Add(CreateColumn(COL_PRTDTL_SHIFTNM, typeof(string), "シフト"));
            wkTable.Columns.Add(CreateColumn(COL_PRTDTL_ADDICARSPEC1, typeof(string), "追加諸元1"));
            wkTable.Columns.Add(CreateColumn(COL_PRTDTL_ADDICARSPEC2, typeof(string), "追加諸元2"));
            wkTable.Columns.Add(CreateColumn(COL_PRTDTL_ADDICARSPEC3, typeof(string), "追加諸元3"));
            wkTable.Columns.Add(CreateColumn(COL_PRTDTL_ADDICARSPEC4, typeof(string), "追加諸元4"));
            wkTable.Columns.Add(CreateColumn(COL_PRTDTL_ADDICARSPEC5, typeof(string), "追加諸元5"));
            wkTable.Columns.Add(CreateColumn(COL_PRTDTL_ADDICARSPEC6, typeof(string), "追加諸元6"));
            wkTable.Columns.Add(CreateColumn(COL_PRTDTL_ADDICARSPECTITLE1, typeof(string), "追加諸元タイトル1"));
            wkTable.Columns.Add(CreateColumn(COL_PRTDTL_ADDICARSPECTITLE2, typeof(string), "追加諸元タイトル2"));
            wkTable.Columns.Add(CreateColumn(COL_PRTDTL_ADDICARSPECTITLE3, typeof(string), "追加諸元タイトル3"));
            wkTable.Columns.Add(CreateColumn(COL_PRTDTL_ADDICARSPECTITLE4, typeof(string), "追加諸元タイトル4"));
            wkTable.Columns.Add(CreateColumn(COL_PRTDTL_ADDICARSPECTITLE5, typeof(string), "追加諸元タイトル5"));
            wkTable.Columns.Add(CreateColumn(COL_PRTDTL_ADDICARSPECTITLE6, typeof(string), "追加諸元タイトル6"));

			wkTable.Columns.Add(CreateColumn(COL_PRTDTL_PARTSMAKERCD, typeof(Int32), "部品メーカーコード"));
			wkTable.Columns.Add(CreateColumn(COL_PRTDTL_PARTSNO, typeof(string), "品番"));

            return wkTable;
        }


        # endregion

    }
}
