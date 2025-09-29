//****************************************************************************//
// システム         : PM.NSシリーズ
// プログラム名称   : ＵＯＥ発注先アクセスクラス
// プログラム概要   : ＵＯＥ発注先アクセスを行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  10402071-00 作成担当 : 立花 裕輔
// 作 成 日  2008/05/26  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号  10902931-00 作成担当 : 譚洪
// 作 成 日  2014/03/24  修正内容 : 複数拠点の発注情報再取得の対応
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using System.Windows.Forms;
using Broadleaf.Library.Resources;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.Controller
{
	/// <summary>
	/// ＵＯＥ発注先アクセスクラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : ＵＯＥ発注先アクセスクラス</br>
	/// <br>Programmer : 96186 立花裕輔</br>
	/// <br>Date       : 2008.05.26</br>
	/// <br></br>
	/// <br>UpDate</br>
	/// <br>2008.05.26 men 新規作成</br>
	/// </remarks>
	public partial class UoeSndRcvJnlAcs
	{
		// ===================================================================================== //
		// デリゲート
		// ===================================================================================== //
		# region Delegate
		# endregion

		// ===================================================================================== //
		// イベント
		// ===================================================================================== //
		# region Event
		# endregion

		// ===================================================================================== //
		// プロパティ
		// ===================================================================================== //
		# region Properties
		# endregion

		// ===================================================================================== //
		// パブリックメソッド
		// ===================================================================================== //
		# region Public Methods

		# region 発注先マスタを取得
		/// <summary>
		/// 発注先マスタを取得
		/// </summary>
		/// <returns></returns>
		public int GetUOESupplier()
		{
			string message = "";
			return (GetUOESupplier(out message));
		}

        /// <summary>
        /// 発注可能メーカーをチェック
        /// </summary>
        /// <param name="uOESupplierCd">発注先コード</param>
        /// <param name="enableOdrMakerCdList">メーカーコード</param>
        /// <returns>ステータス</returns>
        public bool ExistUOESupplierMaker(Int32 uOESupplierCd, List<Int32> enableOdrMakerCdList)
        {
            bool returnStatus = false;

			try
			{
                foreach (Int32 enableOdrMakerCd in enableOdrMakerCdList)
                {
                    String cdString = uOESupplierCd.ToString("d9") + enableOdrMakerCd.ToString("d6");
                    if (_uoeOrderMakerSearchDictionary.ContainsKey(cdString))
                    {
                        returnStatus = true;
                        break;
                    }
                }
            }
            catch (Exception)
            {
                returnStatus = false;
            }
            return returnStatus;
        }

		/// <summary>
		/// 発注先マスタを取得
		/// </summary>
		/// <param name="para"></param>
		/// <param name="message"></param>
		/// <returns></returns>
		public int GetUOESupplier(out string message)
		{
			int status = 0;

			message = "";
			try
			{
				//発注先Dictionary初期化＜検索用＞
				if (_uoeOrderSearchDictionary == null)
				{
					_uoeOrderSearchDictionary = new Dictionary<Int32, UOESupplier	>();
				}

				//発注可能メーカーDictionary初期化＜検索用＞
                if(_uoeOrderMakerSearchDictionary == null)
                {
                    _uoeOrderMakerSearchDictionary = new Dictionary<string,string>();
                }

				if (_uoeOrderSearchDictionary.Count > 0)
				{
					return status;
				}

				ArrayList retList = new ArrayList();

				status = _uOESupplierAcs.SearchAll(out retList, _enterpriseCode, _sectionCode);

				if ((status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) && (retList is ArrayList))
				{
					foreach (UOESupplier rst in retList)
					{
						SetUoeOrderSearch(rst);
                        SetUoeOrderMakerSearch(rst);
                    }
				}
			}
			catch (Exception ex)
			{
				status = -1;
				message = ex.Message;
			}
			return status;
		}
		# endregion


        // ------------- ADD 譚洪 2014/03/24 -------- >>>>>>>>>>
        /// <summary>
        /// 発注先マスタを取得
        /// </summary>
        /// <returns></returns>
        public int GetUOESupplierForMoreSection()
        {
            string message = "";
            return (GetUOESupplierForMoreSection(out message));
        }

        /// <summary>
        /// 発注先マスタを取得
        /// </summary>
        /// <param name="para"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public int GetUOESupplierForMoreSection(out string message)
        {
            int status = 0;

            message = "";
            try
            {
                //発注先Dictionary初期化＜検索用＞
                _uoeOrderSearchDictionary = new Dictionary<Int32, UOESupplier>();

                //発注可能メーカーDictionary初期化＜検索用＞
                _uoeOrderMakerSearchDictionary = new Dictionary<string, string>();

                ArrayList retList = new ArrayList();

                status = _uOESupplierAcs.SearchAll(out retList, _enterpriseCode, _sectionCode);

                if ((status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) && (retList is ArrayList))
                {
                    foreach (UOESupplier rst in retList)
                    {
                        SetUoeOrderSearch(rst);
                        SetUoeOrderMakerSearch(rst);
                    }
                }
            }
            catch (Exception ex)
            {
                status = -1;
                message = ex.Message;
            }
            return status;
        }
        // ------------- ADD 譚洪　2014/03/24 -------- <<<<<<<<<<

		# region 発注先情報を取得＜検索用＞
		/// <summary>
		/// 発注先情報を取得＜検索用＞
		/// </summary>
		/// <param name="cd"></param>
		/// <param name="uOESupplier"></param>
		/// <returns></returns>
		public UOESupplier SearchUOESupplier(Int32 cd)
		{
			UOESupplier uOESupplier = null;

			if (_uoeOrderSearchDictionary.ContainsKey(cd))
			{
				uOESupplier = _uoeOrderSearchDictionary[cd];
			}
			return uOESupplier;
		}
		# endregion

        # region 優良仕入受信チェック
        /// <summary>
        /// 優良仕入受信チェック
        /// </summary>
        /// <param name="cd">発注先コード</param>
        /// <returns>true:あり false:なし</returns>
        public bool ChkStockSlipDtRecvDiv(Int32 cd)
        {
            bool returnBool = false;

            try
            {
                UOESupplier uOESupplier = SearchUOESupplier(cd);
                if (uOESupplier != null)
                {
                    returnBool = ChkStockSlipDtRecvDiv(uOESupplier);
                }
            }
            catch (Exception)
            {
                returnBool = false;
            }
            return returnBool;
        }

        /// <summary>
        /// 優良仕入受信チェック
        /// </summary>
        /// <param name="uOESupplier">発注先オブジェクト</param>
        /// <returns>true:あり false:なし</returns>
        public bool ChkStockSlipDtRecvDiv(UOESupplier uOESupplier)
        {
            bool returnBool = false;

            try
            {
                if (uOESupplier != null)
                {
                    if ((ChkCommAssemblyId(uOESupplier.CommAssemblyId) == false)
                    && (uOESupplier.StockSlipDtRecvDiv == 1))
                    {
                        returnBool = true;
                    }
                }
            }
            catch (Exception)
            {
                returnBool = false;
            }
            return returnBool;
        }
        # endregion

        # region 明治産業チェック
        /// <summary>
        /// 明治産業チェック
        /// </summary>
        /// <param name="cd">発注先コード</param>
        /// <returns>true:明治 false:明治以外</returns>
        public bool ChkMeiji(Int32 cd)
        {
			bool returnBool = false;

            try
            {
                UOESupplier uOESupplier = SearchUOESupplier(cd);
                if (uOESupplier != null)
                {
                    returnBool = ChkMeiji(uOESupplier);
                }
            }
            catch (Exception)
            {
                returnBool = false;
            }
			return returnBool;
        }

        /// <summary>
        /// 明治産業チェック
        /// </summary>
        /// <param name="uOESupplier">発注先オブジェクト</param>
        /// <returns>true:明治 false:明治以外</returns>
        public bool ChkMeiji(UOESupplier uOESupplier)
        {
            bool returnBool = false;

            try
            {
                if (uOESupplier != null)
                {
                    if ((uOESupplier.ReceiveCondition == 1) && (uOESupplier.StockSlipDtRecvDiv == 1))
                    {
                        returnBool = true;
                    }
                }
            }
            catch (Exception)
            {
                returnBool = false;
            }
            return returnBool;
        }
        # endregion

        # region 純正・優良判定
        /// <summary>
        /// 純正・優良判定
        /// </summary>
        /// <param name="cd">発注先コード</param>
        /// <returns>True:純正 False:優良</returns>
        public bool ChkCommAssemblyId(Int32 cd)
        {
            bool returnBool = false;

            try
            {
                UOESupplier uOESupplier = SearchUOESupplier(cd);
                if (uOESupplier != null)
                {
                    returnBool = ChkCommAssemblyId(uOESupplier.CommAssemblyId);
                }
            }
            catch (Exception)
            {
                returnBool = false;
            }
            return returnBool;
        }
        
        /// <summary>
        /// 純正・優良判定
        /// </summary>
        /// <param name="commAssemblyId">通信アセンブリID</param>
        /// <returns>True:純正 False:優良</returns>
        public bool ChkCommAssemblyId(string commAssemblyId)
        {
            bool returnBool = true;

            int cd = 0;

            try
            {
                cd = int.Parse(commAssemblyId);
            }
            catch (Exception)
            {
                cd = 0;
            }
            if (cd >= 1000) returnBool = false;
            return (returnBool);
        }
        # endregion

		# endregion

		// ===================================================================================== //
		// プライベートメソッド
		// ===================================================================================== //
		# region Private Methods
		# region 発注先情報を保存＜検索用＞
		/// <summary>
		/// 発注先情報を保存＜検索用＞
		/// </summary>
		/// <param name="uOESupplier">発注先オブジェクト</param>
		/// <returns>ステータス</returns>
		private bool SetUoeOrderSearch(UOESupplier uOESupplier)
		{
			bool status = false;
			Int32 cd = uOESupplier.UOESupplierCd;

			if((uOESupplier.LogicalDeleteCode == (int)ConstantManagement.LogicalMode.GetData0)
			&& (_uoeOrderSearchDictionary.ContainsKey(cd) != true))
			{
				_uoeOrderSearchDictionary.Add(cd, uOESupplier);
				status = true;
			}

			return status;
		}
		# endregion

		# region 発注可能メーカー情報を保存＜検索用＞
        /// <summary>
        /// 発注可能メーカー情報を保存＜検索用＞
        /// </summary>
        /// <param name="uOESupplier">発注先オブジェクト</param>
        /// <returns>ステータス</returns>
        private bool SetUoeOrderMakerSearch(UOESupplier uOESupplier)
        {
            Int32 enableOdrMakerCd = 0;

			if(uOESupplier.LogicalDeleteCode != (int)ConstantManagement.LogicalMode.GetData0)
            {
                return(false);
            }

            for(int i=0; i<6; i++)
            {
                switch(i)
                {
                    case 0:
                        enableOdrMakerCd = uOESupplier.EnableOdrMakerCd1;
                        break;
                    case 1:
                        enableOdrMakerCd = uOESupplier.EnableOdrMakerCd2;
                        break;
                    case 2:
                        enableOdrMakerCd = uOESupplier.EnableOdrMakerCd3;
                        break;
                    case 3:
                        enableOdrMakerCd = uOESupplier.EnableOdrMakerCd4;
                        break;
                    case 4:
                        enableOdrMakerCd = uOESupplier.EnableOdrMakerCd5;
                        break;
                    case 5:
                        enableOdrMakerCd = uOESupplier.EnableOdrMakerCd6;
                        break;
                }
                if(enableOdrMakerCd == 0)   continue;

        		String cdString = uOESupplier.UOESupplierCd.ToString("d9") + enableOdrMakerCd.ToString("d6");

	    		if(_uoeOrderMakerSearchDictionary.ContainsKey(cdString) != true)
                {
                    _uoeOrderMakerSearchDictionary.Add(cdString, cdString);
                }
            }
			return true;
        }
        # endregion
        # endregion
    }
}
