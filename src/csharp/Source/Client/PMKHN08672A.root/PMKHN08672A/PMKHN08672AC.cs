using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;

using Broadleaf.Library.Resources;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;

namespace Broadleaf.Application.Controller
{
	/// <summary>
	/// 車種マスタテーブルアクセスクラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : 車種マスタテーブルのアクセス制御を行います。</br>
	/// <br>Programmer : 30462 行澤 仁美</br>
	/// <br>Date       : 2008.10.24</br>
    /// <br>UpdateNote  : 2008/12/02 30462 行澤仁美　バグ修正</br>
	/// <br></br>
    /// </remarks>
	public class ModelNameSetAcs 
	{

        private static bool _isLocalDBRead = false;

        private MakerAcs _makerAcs;
        private ModelNameUAcs _modelNameUAcs;

        /// <summary> ローカルＤＢ参照モードプロパティ</summary>
        public bool IsLocalDBRead
        {
            get { return _isLocalDBRead; }
            set { _isLocalDBRead = value; }
        }

        /// <summary>
		/// 車種マスタテーブルアクセスクラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 車種マスタテーブルアクセスクラスの新しいインスタンスを初期化します。</br>
		/// <br>Programmer : 30462 行澤 仁美</br>
        /// <br>Date       : 2008.10.24</br>
        /// </remarks>
        public ModelNameSetAcs()
		{

			
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
		/// 車種マスタ全検索処理（論理削除除く）
		/// </summary>
		/// <param name="retList">読込結果コレクション</param>
		/// <param name="enterpriseCode">企業コード</param>		
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 車種マスタの全検索処理を行います。論理削除データは抽出対象外となります。</br>
		/// <br>Programmer : 30462 行澤 仁美</br>
        /// <br>Date       : 2008.10.24</br>
		/// </remarks>
        public int Search(out ArrayList retList, string enterpriseCode, ModelNamePrintWork modelNamePrintWork)
		{
			bool nextData;
			int  retTotalCnt;
            return SearchProc(out retList, out retTotalCnt, out nextData, enterpriseCode, 0, 0, modelNamePrintWork);
		}

		/// <summary>
		/// 車種マスタ検索処理（論理削除含む）
		/// </summary>
		/// <param name="retList">読込結果コレクション</param>
		/// <param name="enterpriseCode">企業コード</param>		
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 車種マスタの全検索処理を行います。論理削除データも抽出対象となります。</br>
		/// <br>Programmer : 30462 行澤 仁美</br>
        /// <br>Date       : 2008.10.24</br>
		/// </remarks>
        public int SearchAll(out ArrayList retList, string enterpriseCode, ModelNamePrintWork modelNamePrintWork)
		{

			bool nextData;
			int	 retTotalCnt;
            return SearchProc(out retList, out retTotalCnt, out nextData, enterpriseCode, ConstantManagement.LogicalMode.GetData01, 0, modelNamePrintWork);
		}

		

		/// <summary>
		/// 車種マスタ検索処理
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
		/// <br>Note       : 車種マスタの検索処理を行います。</br>
		/// <br>Programmer : 30462 行澤 仁美</br>
        /// <br>Date       : 2008.10.24</br>
        /// </remarks>
        private int SearchProc(out ArrayList retList, out int retTotalCnt, out bool nextData, string enterpriseCode, ConstantManagement.LogicalMode logicalMode, int readCnt, ModelNamePrintWork modelNamePrintWork)
		{

            this._makerAcs = new MakerAcs();
            this._modelNameUAcs = new ModelNameUAcs();

            int status = 0;
            int checkstatus = 0;

            //次データ有無初期化
            nextData = false;
            //0で初期化
            retTotalCnt = 0;

            retList = new ArrayList();
            retList.Clear();

            ArrayList makerUMnts = null;
            ArrayList modelNameUs = null;
            status = this._makerAcs.SearchAll(
                                out makerUMnts,
                                enterpriseCode);

            foreach (MakerUMnt makerUMnt in makerUMnts)
            {
                checkstatus = DataCheck(makerUMnt, modelNamePrintWork);
                if (checkstatus == 0)
                {
                    modelNameUs = null;
                    status = this._modelNameUAcs.SearchAll(makerUMnt.GoodsMakerCd, out modelNameUs, enterpriseCode);

                    foreach (ModelNameU modelNameU in modelNameUs)
                    {
                        // 抽出処理
                        checkstatus = DataCheck(modelNameU, modelNamePrintWork);
                        if (checkstatus == 0)
                        {

                            //車種情報クラスへメンバコピー
                            retList.Add(CopyToMakerSetFromSecInfoSetWork(modelNameU, enterpriseCode));

                        }
                    }
                }
            }
            status = 0;

            //全件リードの場合は戻り値の件数をセット
			if (readCnt == 0) retTotalCnt = retList.Count;
				
			return status;
		}

        /// <summary>
        /// クラスメンバーコピー処理（車種マスタワーククラス⇒車種マスタクラス）
        /// </summary>
        /// <param name="secInfoSetWork">車種マスタワーククラス</param>
        /// <returns>車種マスタクラス</returns>
        /// <remarks>
        /// <br>Note       : 車種マスタワーククラスから車種マスタクラスへメンバーのコピーを行います。</br>
        /// <br>Programmer : 30462 行澤 仁美</br>
        /// <br>Date       : 2008.10.24</br>
        /// </remarks>
        private ModelNameSet CopyToMakerSetFromSecInfoSetWork(ModelNameU modelNameU, string enterpriseCode)
        {

            ModelNameSet modelNameSet = new ModelNameSet();

            modelNameSet.MakerCode = modelNameU.MakerCode;
            modelNameSet.ModelCode = modelNameU.ModelCode;
            modelNameSet.ModelSubCode = modelNameU.ModelSubCode;
            modelNameSet.ModelFullName = modelNameU.ModelFullName;
            modelNameSet.ModelHalfName = modelNameU.ModelHalfName;
            modelNameSet.ModelAliasName = modelNameU.ModelAliasName;

            return modelNameSet;
        }

        /// <summary>
        /// メーカー抽出処理
        /// </summary>
        /// <param name="makerUMnt"></param>
        /// <param name="modelNamePrintWork"></param>
        /// <returns></returns>
        private int DataCheck(MakerUMnt makerUMnt, ModelNamePrintWork modelNamePrintWork)
        {
            int status = 0;

            if (modelNamePrintWork.MakerCodeSt != 0 &&
                modelNamePrintWork.MakerCodeEd != 0)
            {
                if (makerUMnt.GoodsMakerCd < modelNamePrintWork.MakerCodeSt ||
                   makerUMnt.GoodsMakerCd > modelNamePrintWork.MakerCodeEd)
                {
                    status = -1;
                    return status;
                }
            }
            else if (modelNamePrintWork.MakerCodeSt != 0)
            {
                if (makerUMnt.GoodsMakerCd < modelNamePrintWork.MakerCodeSt)
                {
                    status = -1;
                    return status;
                }
                // ADD 2008/12/02 不具合対応[8363] ---------->>>>>
                // 車種使用メーカ以外のメーカーは対象外とする
                if (makerUMnt.GoodsMakerCd > 999)
                {
                    status = -1;
                    return status;
                }
                // ADD 2008/12/02 不具合対応[8363] ----------<<<<<

            }
            else if (modelNamePrintWork.MakerCodeEd != 0)
            {
                if (makerUMnt.GoodsMakerCd > modelNamePrintWork.MakerCodeEd)
                {
                    status = -1;
                    return status;
                }
            }
            // ADD 2008/12/02 不具合対応[8363] ---------->>>>>
            else
            {
                // 車種使用メーカ以外のメーカーは対象外とする
                if (makerUMnt.GoodsMakerCd > 999)
                {
                    status = -1;
                    return status;
                }
            }
            // ADD 2008/12/02 不具合対応[8363] ----------<<<<<

            return status;
        }

        /// <summary>
        /// 抽出処理
        /// </summary>
        /// <param name="employee"></param>
        /// <param name="sectionPrintWork"></param>
        /// <returns></returns>
        private int DataCheck(ModelNameU modelNameU, ModelNamePrintWork modelNamePrintWork)
        {
            int status = 0;

            if (modelNameU.LogicalDeleteCode != modelNamePrintWork.LogicalDeleteCode)
            {
                status = -1;
                return status;
            }


            string upDateTime = modelNameU.UpdateDateTime.Year.ToString("0000") +
                                modelNameU.UpdateDateTime.Month.ToString("00") +
                                modelNameU.UpdateDateTime.Day.ToString("00");

            if (modelNamePrintWork.LogicalDeleteCode == 1 &&
                modelNamePrintWork.DeleteDateTimeSt != 0 &&
                modelNamePrintWork.DeleteDateTimeEd != 0)
            {

                if (Int32.Parse(upDateTime) < modelNamePrintWork.DeleteDateTimeSt ||
                    Int32.Parse(upDateTime) > modelNamePrintWork.DeleteDateTimeEd)
                {
                    status = -1;
                    return status;
                }
            }
            else if (modelNamePrintWork.LogicalDeleteCode == 1 &&
                        modelNamePrintWork.DeleteDateTimeSt != 0 &&
                        modelNamePrintWork.DeleteDateTimeEd == 0)
            {
                if (Int32.Parse(upDateTime) < modelNamePrintWork.DeleteDateTimeSt)
                {
                    status = -1;
                    return status;
                }
            }
            else if (modelNamePrintWork.LogicalDeleteCode == 1 &&
                modelNamePrintWork.DeleteDateTimeSt == 0 &&
                modelNamePrintWork.DeleteDateTimeEd != 0)
            {
                if (Int32.Parse(upDateTime) > modelNamePrintWork.DeleteDateTimeEd)
                {
                    status = -1;
                    return status;
                }
            }


            if (modelNamePrintWork.MakerCodeSt != 0 &&
                modelNamePrintWork.MakerCodeEd != 0)
            {
                if (modelNameU.MakerCode < modelNamePrintWork.MakerCodeSt ||
                   modelNameU.MakerCode > modelNamePrintWork.MakerCodeEd)
                {
                    status = -1;
                    return status;
                }
            }
            else if (modelNamePrintWork.MakerCodeSt != 0)
            {
                if (modelNameU.MakerCode < modelNamePrintWork.MakerCodeSt)
                {
                    status = -1;
                    return status;
                }
            }
            else if (modelNamePrintWork.MakerCodeEd != 0)
            {
                if (modelNameU.MakerCode > modelNamePrintWork.MakerCodeEd)
                {
                    status = -1;
                    return status;
                }
            }

            if (modelNamePrintWork.ModelCodeSt != 0)
            {
                if (modelNameU.MakerCode == modelNamePrintWork.MakerCodeSt)
                {
                    if (modelNameU.ModelCode < modelNamePrintWork.ModelCodeSt)
                    {
                        status = -1;
                        return status;
                    }
                }
            }
            if (modelNamePrintWork.ModelCodeEd != 0)
            {
                if (modelNameU.MakerCode == modelNamePrintWork.MakerCodeEd)
                {
                    if (modelNameU.ModelCode > modelNamePrintWork.ModelCodeEd)
                    {
                        status = -1;
                        return status;
                    }
                }
            }

            if (modelNamePrintWork.ModelSubCodeSt != 0)
            {
                if (modelNameU.MakerCode == modelNamePrintWork.MakerCodeSt &&
                    modelNameU.ModelCode == modelNamePrintWork.ModelCodeSt)
                {
                    if (modelNameU.ModelSubCode < modelNamePrintWork.ModelSubCodeSt)
                    {
                        status = -1;
                        return status;
                    }
                }
            }
            if (modelNamePrintWork.ModelSubCodeEd != 0)
            {
                if (modelNameU.MakerCode == modelNamePrintWork.MakerCodeEd &&
                    modelNameU.ModelCode == modelNamePrintWork.ModelCodeEd)
                {
                    if (modelNameU.ModelSubCode > modelNamePrintWork.ModelSubCodeEd)
                    {
                        status = -1;
                        return status;
                    }
                }
            }
            return status;
        }
    }
}
