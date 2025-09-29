//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 車輌出荷部品表示
// プログラム概要   : 車輌出荷部品表示を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 譚洪
// 作 成 日  2009/09/10  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日              修正内容 : 
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Library.Resources;


namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// 車輌出荷部品表示処理スクラス
    /// </summary>
    /// <remarks>
    /// Note       : 車輌出荷部品表示処理です。<br />
    /// Programmer : 譚洪<br />
    /// Date       : 2009.09.10<br />
    /// </remarks>
    public class CarPartDisplayAcs
    {
        // ===================================================================================== //
        // コンストラクタ
        // ===================================================================================== //
        # region ■Constructor

        /// <summary>
        /// デフォルトコンストラクタ（Singletonデザインパターンを採用している為、privateとする）
        /// </summary>
        private CarPartDisplayAcs()
        {

        }
        #endregion

        // ===================================================================================== //
        // プロパティ
        // ===================================================================================== //
        # region ■Properties
        /// <summary>
        /// 車輌出荷部品表示処理
        /// </summary>
        /// <returns>仕入先変換設定アクセスクラス インスタンス</returns>
        /// <remarks>
        /// Note       : 車輌出荷部品表示処理です。<br />
        /// Programmer : 譚洪<br />
        /// Date       : 2009.09.10<br />
        /// </remarks>
        public static CarPartDisplayAcs GetInstance()
        {
            if (_carPartDisplayAcs == null)
            {
                _carPartDisplayAcs = new CarPartDisplayAcs();
            }

            return _carPartDisplayAcs;
        }
        # endregion

        // ===================================================================================== //
        // プライベート変数
        // ===================================================================================== //
        # region ■Private Members
        private static CarPartDisplayAcs _carPartDisplayAcs;
        ICarManagementDB _iCarManagementDB;
        ICarShipmentPartsDispDB _iCarShipmentPartsDispDB;
        # endregion

        // ===================================================================================== //
        // パブリックイベートメソッド
        // ===================================================================================== //
        #region ■public Methods
        /// <summary>
        /// 車輌検索表示処理
        /// </summary>
        /// <param name="carMngWorkObj">検索条件</param>
        /// <param name="carMngWorkListObj">検索結果</param>
        /// <returns>STATUS</returns>
        /// <remarks>		
        /// <br>Note		: 車輌検索表示処理を行う。</br>
        /// <br>Programmer	: 譚洪</br>	
        /// <br>Date		: 2009.09.10</br>
        /// </remarks>
        public int CarInfoSearch(object carMngWorkObj, ref object carMngWorkListObj)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

            if (this._iCarManagementDB == null)
            {
                this._iCarManagementDB = MediationCarManagementDB.GetCarManagementDB();
            }

            status = this._iCarManagementDB.Search(ref carMngWorkListObj, carMngWorkObj, 0, ConstantManagement.LogicalMode.GetData0);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
            }

            return status;
        }

        /// <summary>
        /// 車輌部品検索表示処理
        /// </summary>
        /// <param name="carInfoConditionWorkWorkObj">検索条件</param>
        /// <param name="carMngWorkList">検索結果</param>
        /// <returns>STATUS</returns>
        /// <remarks>		
        /// <br>Note		: 車輌部品検索表示処理を行う。</br>
        /// <br>Programmer	: 譚洪</br>	
        /// <br>Date		: 2009.09.10</br>
        /// </remarks>
        public int CarPartsInfoSearch(object carInfoConditionWorkWorkObj, ref ArrayList carMngWorkList)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

            if (this._iCarShipmentPartsDispDB == null)
            {
                this._iCarShipmentPartsDispDB = MediationCarShipmentPartsDispDB.GetCarShipmentPartsDispDB();
            }

            status = this._iCarShipmentPartsDispDB.CarInfoSearch(ref carMngWorkList, carInfoConditionWorkWorkObj);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
            }

            return status;
        }
        #endregion
    }
}
