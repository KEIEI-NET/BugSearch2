using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;

using Broadleaf.Library.Resources;
using Broadleaf.Library.Globarization;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;
using Broadleaf.Windows.Forms;
using Broadleaf.Application.LocalAccess;
using Broadleaf.Application.Controller.Agent;

namespace Broadleaf.Application.Controller
{
	/// <summary>
	/// 備考ガイドマスタテーブルアクセスクラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : 備考ガイドマスタテーブルのアクセス制御を行います。</br>
	/// <br>Programmer : 30462 行澤 仁美</br>
	/// <br>Date       : 2008.10.24</br>
	/// <br></br>
    /// </remarks>
	public class NoteGuidSetAcs 
	{

        private static bool _isLocalDBRead = false;

        private NoteGuidAcs _noteGuidAcs;
        private SubSectionAcs _subSectionAcs;

        private const int NULL_JOBTYPE_CODE = 0;
        private const string NULL_JOBTYPE_NAME = "";
        private const int NULL_EMPLOYMENTFORM_CODE = 0;
        private const string NULL_EMPLOYMENTFORM_NAME = "";

        /// <summary> ローカルＤＢ参照モードプロパティ</summary>
        public bool IsLocalDBRead
        {
            get { return _isLocalDBRead; }
            set { _isLocalDBRead = value; }
        }

        /// <summary>
		/// 備考ガイドマスタテーブルアクセスクラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 備考ガイドマスタテーブルアクセスクラスの新しいインスタンスを初期化します。</br>
		/// <br>Programmer : 30462 行澤 仁美</br>
        /// <br>Date       : 2008.10.24</br>
        /// </remarks>
        public NoteGuidSetAcs()
		{

            this._subSectionAcs = new SubSectionAcs();
                       		
        }

        

        /// <summary>オンラインモードの列挙型です。</summary>
		public enum OnlineMode 
		{
			/// <summary>オフライン</summary>
			Offline,
			/// <summary>オンライン</summary>
			Online 
		}

	

		/// <summary>
		/// 備考ガイドマスタ全検索処理（論理削除除く）
		/// </summary>
		/// <param name="retList">読込結果コレクション</param>
		/// <param name="enterpriseCode">企業コード</param>		
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 備考ガイドマスタの全検索処理を行います。論理削除データは抽出対象外となります。</br>
		/// <br>Programmer : 30462 行澤 仁美</br>
        /// <br>Date       : 2008.10.24</br>
		/// </remarks>
        public int Search(out ArrayList retList, string enterpriseCode, NoteGuidPrintWork noteGuidPrintWork)
		{
			bool nextData;
			int  retTotalCnt;
            return SearchProc(out retList, out retTotalCnt, out nextData, enterpriseCode, 0, 0, noteGuidPrintWork);
		}

		/// <summary>
		/// 備考ガイドマスタ検索処理（論理削除含む）
		/// </summary>
		/// <param name="retList">読込結果コレクション</param>
		/// <param name="enterpriseCode">企業コード</param>		
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 備考ガイドマスタの全検索処理を行います。論理削除データも抽出対象となります。</br>
		/// <br>Programmer : 30462 行澤 仁美</br>
        /// <br>Date       : 2008.10.24</br>
		/// </remarks>
        public int SearchAll(out ArrayList retList, string enterpriseCode, NoteGuidPrintWork noteGuidPrintWork)
		{

			bool nextData;
			int	 retTotalCnt;
            return SearchProc(out retList, out retTotalCnt, out nextData, enterpriseCode, ConstantManagement.LogicalMode.GetData01, 0, noteGuidPrintWork);
		}

		

		/// <summary>
		/// 備考ガイドマスタ検索処理
		/// </summary>
		/// <param name="retList">読込結果コレクション</param>
		/// <param name="retTotalCnt">読込対象データ総件数(prevEmployeeがnullの場合のみ戻る)</param>
		/// <param name="nextData">次データ有無</param>
		/// <param name="enterpriseCode">企業コード</param>
		/// <param name="logicalMode">論理削除有無(0:正規データのみ 1:削除データのみ 2:全データ)</param>
		/// <param name="readCnt">読込件数</param>
        /// <param name="sectionPrintWork">抽出条件</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 備考ガイドマスタの検索処理を行います。</br>
		/// <br>Programmer : 30462 行澤 仁美</br>
        /// <br>Date       : 2008.10.24</br>
        /// </remarks>
        private int SearchProc(out ArrayList retList, out int retTotalCnt, out bool nextData, string enterpriseCode, ConstantManagement.LogicalMode logicalMode, int readCnt, NoteGuidPrintWork noteGuidPrintWork)
		{

            this._noteGuidAcs = new NoteGuidAcs();

            int status = 0;
            int checkstatus = 0;

            //次データ有無初期化
            nextData = false;
            //0で初期化
            retTotalCnt = 0;

            retList = new ArrayList();
            retList.Clear();

            ArrayList HeadList = null;
            ArrayList BodyList = null;

            status = this._noteGuidAcs.SearchAllHeader(
                                out HeadList,
                                enterpriseCode);

            status = this._noteGuidAcs.SearchAllBody(
                                out BodyList,
                                enterpriseCode);


            foreach (NoteGuidHd noteGuidHd in HeadList)
            {
                // 抽出処理
                checkstatus = DataCheck(noteGuidHd, noteGuidPrintWork);
                if (checkstatus == 0)
                {
                    foreach (NoteGuidBd noteGuidBd in BodyList)
                    {
                        if (noteGuidHd.NoteGuideDivCode == noteGuidBd.NoteGuideDivCode)
                        {
                            //拠点情報クラスへメンバコピー
                            retList.Add(CopyToNoteGuidSetFromSecInfoSetWork(noteGuidHd, noteGuidBd, enterpriseCode));
                            
                        }
                    }
                }
            }


            //全件リードの場合は戻り値の件数をセット
			if (readCnt == 0) retTotalCnt = retList.Count;
				
			return status;
		}



        /// <summary>
        /// クラスメンバーコピー処理（備考ガイドマスタワーククラス⇒備考ガイドマスタクラス）
        /// </summary>
        /// <param name="secInfoSetWork">備考ガイドマスタワーククラス</param>
        /// <returns>備考ガイドマスタクラス</returns>
        /// <remarks>
        /// <br>Note       : 備考ガイドマスタワーククラスから備考ガイドマスタクラスへメンバーのコピーを行います。</br>
        /// <br>Programmer : 30462 行澤 仁美</br>
        /// <br>Date       : 2008.10.24</br>
        /// </remarks>
        private NoteGuidSet CopyToNoteGuidSetFromSecInfoSetWork(NoteGuidHd noteGuidHd,NoteGuidBd noteGuidBd, string enterpriseCode)
        {

            NoteGuidSet noteGuidSet = new NoteGuidSet();

            noteGuidSet.NoteGuideDivCode = noteGuidHd.NoteGuideDivCode;
            noteGuidSet.NoteGuideDivName = noteGuidHd.NoteGuideDivName;
            noteGuidSet.NoteGuideCode = noteGuidBd.NoteGuideCode;
            noteGuidSet.NoteGuideName = noteGuidBd.NoteGuideName;
            
            return noteGuidSet;
        }


        /// <summary>
        /// 抽出処理
        /// </summary>
        /// <param name="employee"></param>
        /// <param name="sectionPrintWork"></param>
        /// <returns></returns>
        private int DataCheck(NoteGuidHd noteGuidHd, NoteGuidPrintWork noteGuidPrintWork)
        {
            int status = 0;

            if (noteGuidHd.LogicalDeleteCode != noteGuidPrintWork.LogicalDeleteCode)
            {
                status = -1;
                return status;
            }


            string upDateTime = noteGuidHd.UpdateDateTime.Year.ToString("0000") +
                                noteGuidHd.UpdateDateTime.Month.ToString("00") +
                                noteGuidHd.UpdateDateTime.Day.ToString("00");

            if (noteGuidPrintWork.LogicalDeleteCode == 1 &&
                noteGuidPrintWork.DeleteDateTimeSt != 0 &&
                noteGuidPrintWork.DeleteDateTimeEd != 0)
            {

                if (Int32.Parse(upDateTime) < noteGuidPrintWork.DeleteDateTimeSt ||
                    Int32.Parse(upDateTime) > noteGuidPrintWork.DeleteDateTimeEd)
                {
                    status = -1;
                    return status;
                }
            }
            else if (noteGuidPrintWork.LogicalDeleteCode == 1 &&
                        noteGuidPrintWork.DeleteDateTimeSt != 0 &&
                        noteGuidPrintWork.DeleteDateTimeEd == 0)
            {
                if (Int32.Parse(upDateTime) < noteGuidPrintWork.DeleteDateTimeSt)
                {
                    status = -1;
                    return status;
                }
            }
            else if (noteGuidPrintWork.LogicalDeleteCode == 1 &&
             noteGuidPrintWork.DeleteDateTimeSt == 0 &&
             noteGuidPrintWork.DeleteDateTimeEd != 0)
            {
                if (Int32.Parse(upDateTime) > noteGuidPrintWork.DeleteDateTimeEd)
                {
                    status = -1;
                    return status;
                }
            }


            if (noteGuidPrintWork.NoteGuideDivCodeSt != 0 &&
                noteGuidPrintWork.NoteGuideDivCodeEd != 0)
            {
                if (noteGuidHd.NoteGuideDivCode < noteGuidPrintWork.NoteGuideDivCodeSt ||
                   noteGuidHd.NoteGuideDivCode > noteGuidPrintWork.NoteGuideDivCodeEd)
                {
                    status = -1;
                    return status;
                }
            }
            else if (noteGuidPrintWork.NoteGuideDivCodeSt != 0)
            {
                if (noteGuidHd.NoteGuideDivCode < noteGuidPrintWork.NoteGuideDivCodeSt)
                {
                    status = -1;
                    return status;
                }
            }
            else if (noteGuidPrintWork.NoteGuideDivCodeEd != 0)
            {
                if (noteGuidHd.NoteGuideDivCode > noteGuidPrintWork.NoteGuideDivCodeEd)
                {
                    status = -1;
                    return status;
                }
            }

            return status;
        }
    }
}
