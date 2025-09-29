//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 明治産業品番変換一括処理変換条件
// プログラム概要   : 条件を満たしたデータをテキストファイルへ出力する
//----------------------------------------------------------------------------//
//                (c)Copyright  2015 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  11003519-00 作成担当 : 陳永康
// 作 成 日  2015/01/26  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号  11003519-00  作成担当 : 時シン
// 作 成 日  2015/03/16   修正内容 : Redmine#44209 優良設定マスタ変換の仕様変更の対応
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Data;
using Broadleaf.Library.Data.SqlTypes;
using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Common;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Microsoft.Win32;
using System.IO;
using System.Runtime.InteropServices;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 品番変換一括処理DBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 品番変換一括処理の実データ操作を行うクラスです。</br>
    /// <br>Programmer : 陳永康</br>
    /// <br>Date       : 2015/01/26</br>
    /// </remarks>
    [Serializable]
    public class MeijiGoodsChgAllDB : RemoteDB, IMeijiGoodsChgAllDB
    {
        /// <summary>
        /// 品番変換一括処理DBリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特になし</br>
        /// <br>Programmer : 陳永康</br>
        /// <br>Date       : 2015/01/26</br>
        /// </remarks>
        public MeijiGoodsChgAllDB()
        {
        }

        #region [品番変換マスタ]
        /// <summary>
        /// 指定された条件の品番変換マスタ情報LISTを戻します
        /// </summary>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の品番変換マスタ情報LISTを戻します</br>
        /// <br>Programmer : 陳永康</br>
        /// <br>Date       : 2015/01/26</br>
        public int GoodsChangeMst(object goodsChangeAllCndWorkWork, out object addUpdWorkObj, out object dataObjectList, out int readCnt, out int loadCnt, out int errCnt, out string errMsg)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            GoodsChangeAllCndWorkWork cndWork = goodsChangeAllCndWorkWork as GoodsChangeAllCndWorkWork;
            addUpdWorkObj = null;
            dataObjectList = null;
            readCnt = 0;
            loadCnt = 0;
            errCnt = 0;
            errMsg = string.Empty;

            // 品番変換マスタ
            MeijiGoodsChgMstDB meijiGoodsChgMstDB = new MeijiGoodsChgMstDB();
            status = meijiGoodsChgMstDB.ImportFile(goodsChangeAllCndWorkWork, out addUpdWorkObj, out dataObjectList, out readCnt, out loadCnt, out errCnt, out errMsg);
            
            return status;
        }
        #endregion

        #region [商品在庫マスタ]
        /// <summary>
        /// 指定された条件の商品在庫マスタ情報LISTを戻します
        /// </summary>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 指定された条件の品商品在庫マスタ情報LISTを戻します</br>
        /// <br>Programmer : 陳永康</br>
        /// <br>Date       : 2015/01/26</br>
        /// <br>UpdateNote : 2015/03/02 時シン </br>
        /// <br>           : Redmine#44209 商品マスタ、在庫マスタ、価格マスタのログを１つに集約して出力する対応</br>
        /// </remarks>
        //----- DEL 2015/03/02 時シン Redmine#44209 「仕様変更」商品マスタ、在庫マスタ、価格マスタのログを１つに集約して出力する対応----->>>>>
        //public int GoodsChangeGoodsStock(object goodsChangeAllCndWorkWork, out object goodsSucObj, out object goodsErrObj, out object priceSucObj, out object priceErrObj,
        //    out object stockSucObj, out object stockErrObj, out int goodsReadCnt, out Int32 priceReadCnt, out Int32 stockReadCnt)
        //----- DEL 2015/03/02 時シン Redmine#44209 「仕様変更」商品マスタ、在庫マスタ、価格マスタのログを１つに集約して出力する対応------<<<<<
        //----- ADD 2015/03/02 時シン Redmine#44209 「仕様変更」商品マスタ、在庫マスタ、価格マスタのログを１つに集約して出力する対応------>>>>>
        public int GoodsChangeGoodsStock(object goodsChangeAllCndWorkWork, out object goodsSucObj, out object goodsErrObj, out int goodsReadCnt, out int priceReadCnt, out int stockReadCnt)
        //----- ADD 2015/03/02 時シン Redmine#44209 「仕様変更」商品マスタ、在庫マスタ、価格マスタのログを１つに集約して出力する対応------<<<<<
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            GoodsChangeAllCndWorkWork cndWork = goodsChangeAllCndWorkWork as GoodsChangeAllCndWorkWork;
            goodsSucObj = null;
            goodsErrObj = null;
            //----- DEL 2015/03/02 時シン Redmine#44209 「仕様変更」商品マスタ、在庫マスタ、価格マスタのログを１つに集約して出力する対応----->>>>>
            //priceSucObj = null;
            //priceErrObj = null;
            //stockSucObj = null;
            //stockErrObj = null;
            //----- DEL 2015/03/02 時シン Redmine#44209 「仕様変更」商品マスタ、在庫マスタ、価格マスタのログを１つに集約して出力する対応------<<<<<
            goodsReadCnt = 0;
            priceReadCnt = 0;
            stockReadCnt = 0;

            // 商品在庫マスタ
            MeijiGoodsStockDB meijiGoodsStockDB = new MeijiGoodsStockDB();
            //----- DEL 2015/03/02 時シン Redmine#44209 「仕様変更」商品マスタ、在庫マスタ、価格マスタのログを１つに集約して出力する対応----->>>>>
            //status = meijiGoodsStockDB.WriteGoods(out goodsSucObj, out goodsErrObj, out priceSucObj, out priceErrObj, out stockSucObj, out stockErrObj, out goodsReadCnt, out priceReadCnt,
            //    out stockReadCnt, cndWork.ChangeDiv, cndWork.EnterpriseCode, cndWork);
            //----- DEL 2015/03/02 時シン Redmine#44209 「仕様変更」商品マスタ、在庫マスタ、価格マスタのログを１つに集約して出力する対応------<<<<<
            //----- ADD 2015/03/02 時シン Redmine#44209 「仕様変更」商品マスタ、在庫マスタ、価格マスタのログを１つに集約して出力する対応------>>>>>
            status = meijiGoodsStockDB.WriteGoods(out goodsSucObj, out goodsErrObj, out goodsReadCnt, out priceReadCnt, out stockReadCnt, cndWork.ChangeDiv, cndWork.EnterpriseCode, cndWork);
            //----- ADD 2015/03/02 時シン Redmine#44209 「仕様変更」商品マスタ、在庫マスタ、価格マスタのログを１つに集約して出力する対応------<<<<<
            return status;
        }
        #endregion

        #region [商品管理情報マスタ]
        /// <summary>
        /// 指定された条件の商品管理情報マスタ情報LISTを戻します
        /// </summary>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の商品管理情報マスタ情報LISTを戻します</br>
        /// <br>Programmer : 陳永康</br>
        /// <br>Date       : 2015/01/26</br>
        public int GoodsChangeGoodsMng(object goodsChangeAllCndWorkWork, out object addUpdWorkObj, out object dataObjectList, out int readCnt)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            GoodsChangeAllCndWorkWork cndWork = goodsChangeAllCndWorkWork as GoodsChangeAllCndWorkWork;
            addUpdWorkObj = null;
            dataObjectList = null;
            readCnt = 0;

            // 商品管理情報マスタ
            MeijiGoodsMngDB meijiGoodsMngDB = new MeijiGoodsMngDB();
            status = meijiGoodsMngDB.WriteIn(out addUpdWorkObj, out dataObjectList, out readCnt, cndWork.ChangeDiv, cndWork.EnterpriseCode);

            return status;
        }
        #endregion

        #region [掛率マスタ]
        /// <summary>
        /// 指定された条件の掛率マスタ情報LISTを戻します
        /// </summary>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の掛率マスタ情報LISTを戻します</br>
        /// <br>Programmer : 陳永康</br>
        /// <br>Date       : 2015/01/26</br>
        public int GoodsChangeRate(object goodsChangeAllCndWorkWork, out object addUpdWorkObj, out object dataObjectList, out int readCnt)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            GoodsChangeAllCndWorkWork cndWork = goodsChangeAllCndWorkWork as GoodsChangeAllCndWorkWork;
            addUpdWorkObj = null;
            dataObjectList = null;
            readCnt = 0;

            // 掛率マスタ
            MeijiRateDB meijiRateDB = new MeijiRateDB();
            status = meijiRateDB.WriteIn(out addUpdWorkObj, out dataObjectList, out readCnt, cndWork.ChangeDiv, cndWork.EnterpriseCode);
            return status;
        }
        #endregion

        #region [結合マスタ]
        /// <summary>
        /// 指定された条件の結合マスタ情報LISTを戻します
        /// </summary>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の結合マスタ情報LISTを戻します</br>
        /// <br>Programmer : 陳永康</br>
        /// <br>Date       : 2015/01/26</br>
        public int GoodsChangeJoin(object goodsChangeAllCndWorkWork, out object addUpdWorkObj, out object dataObjectList, out int readCnt)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            GoodsChangeAllCndWorkWork cndWork = goodsChangeAllCndWorkWork as GoodsChangeAllCndWorkWork;
            addUpdWorkObj = null;
            dataObjectList = null;
            readCnt = 0;

            // 結合マスタ
            MeijiJoinPartsDB meijiJoinPartsDB =  new MeijiJoinPartsDB();
            status = meijiJoinPartsDB.ReadIn(out addUpdWorkObj, out dataObjectList, out readCnt, cndWork.ChangeDiv, cndWork.EnterpriseCode);
            
            return status;
        }
        #endregion    
            
        #region [代替マスタ]
        /// <summary>
        /// 指定された条件の代替マスタ情報LISTを戻します
        /// </summary>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の代替マスタ情報LISTを戻します</br>
        /// <br>Programmer : 陳永康</br>
        /// <br>Date       : 2015/01/26</br>
        public int GoodsChangeParts(object goodsChangeAllCndWorkWork, out object addUpdWorkObj, out object dataObjectList, out int readCnt)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            GoodsChangeAllCndWorkWork cndWork = goodsChangeAllCndWorkWork as GoodsChangeAllCndWorkWork;
            addUpdWorkObj = null;
            dataObjectList = null;
            readCnt = 0;

            // 代替マスタ
            MeijiPartsSubstDB meijiPartsSubstDB = new MeijiPartsSubstDB();
            status = meijiPartsSubstDB.WriteIn(out addUpdWorkObj, out dataObjectList, out readCnt, cndWork.ChangeDiv, cndWork.EnterpriseCode);
            
            return status;
        }
        #endregion

        #region [セットマスタ]
        /// <summary>
        /// 指定された条件のセットマスタ情報LISTを戻します
        /// </summary>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件のセットマスタ情報LISTを戻します</br>
        /// <br>Programmer : 陳永康</br>
        /// <br>Date       : 2015/01/26</br>
        public int GoodsChangeSet(object goodsChangeAllCndWorkWork, out object addUpdWorkObj, out object dataObjectList, out int readCnt)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            GoodsChangeAllCndWorkWork cndWork = goodsChangeAllCndWorkWork as GoodsChangeAllCndWorkWork;
            addUpdWorkObj = null;
            dataObjectList = null;
            readCnt = 0;

            // セットマスタ
            MeijiGoodsSetChgDB meijigoodsSetChgDB = new MeijiGoodsSetChgDB();
            status = meijigoodsSetChgDB.ReadIn(out addUpdWorkObj, out dataObjectList, out readCnt, cndWork.ChangeDiv, cndWork.EnterpriseCode);
            
            return status;
        }
        #endregion   
 
        //----- ADD 2015/02/27 陳永康 Redmine#44209 優良設定マスタ変換処理の機能追加----->>>>>
        #region [優良設定マスタ]
        /// <summary>
        /// 指定された条件の優良設定マスタ情報LISTを戻します
        /// </summary>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の優良設定マスタ情報LISTを戻します</br>
        /// <br>Programmer : 陳永康</br>
        /// <br>Date       : 2015/01/26</br>
        //public int PrmSettingChange(object goodsChangeAllCndWorkWork, out object sucObjectList, out object errObjectList, out int readCnt, out int loginCnt, out string errMsg, out bool csvErr)// DEL 2015/03/16 時シン Redmine#44209 優良設定マスタ変換の仕様変更の対応
        public int PrmSettingChange(object goodsChangeAllCndWorkWork, Dictionary<string, PrmSettingWork> offerPrmDic, out object sucObjectList, out object errObjectList, // ADD 2015/03/16 時シン Redmine#44209 優良設定マスタ変換の仕様変更の対応 
            out int readCnt, out int loginCnt, out string errMsg, out bool csvErr)// ADD 2015/03/16 時シン Redmine#44209 優良設定マスタ変換の仕様変更の対応    
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            GoodsChangeAllCndWorkWork cndWork = goodsChangeAllCndWorkWork as GoodsChangeAllCndWorkWork;
            sucObjectList = null;
            errObjectList = null;
            readCnt = 0;
            loginCnt = 0;
            errMsg = string.Empty;
            csvErr = false;

            // 優良設定マスタ
            MeijiPrmSettingDB meijiPrmSettingDB = new MeijiPrmSettingDB();
            //status = meijiPrmSettingDB.PrmSettingChange(goodsChangeAllCndWorkWork, out sucObjectList, out errObjectList, out readCnt, out loginCnt, out errMsg, out csvErr);// DEL 2015/03/16 時シン Redmine#44209 優良設定マスタ変換の仕様変更の対応
            status = meijiPrmSettingDB.PrmSettingChange(goodsChangeAllCndWorkWork, offerPrmDic, out sucObjectList, out errObjectList, out readCnt, out loginCnt, out errMsg, out csvErr);// ADD 2015/03/16 時シン Redmine#44209 優良設定マスタ変換の仕様変更の対応

            return status;
        }
        #endregion
        //----- ADD 2015/02/27 陳永康 Redmine#44209 優良設定マスタ変換処理の機能追加-----<<<<<

        #region [貸出変換処理]
        /// <summary>
        /// 指定された条件の貸出データ情報LISTを戻します
        /// </summary>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の貸出データ情報LISTを戻します</br>
        /// <br>Programmer : 陳永康</br>
        /// <br>Date       : 2015/01/26</br>
        public int ShipmentChange(object goodsChangeAllCndWorkWork, out object sucObjectList, out object errObjectList, out int readCnt)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            GoodsChangeAllCndWorkWork cndWork = goodsChangeAllCndWorkWork as GoodsChangeAllCndWorkWork;
            sucObjectList = null;
            errObjectList = null;
            readCnt = 0;

            // 貸出データ更新処理
            ShipmentChangeDB shipmentChangeDB = new ShipmentChangeDB();
            status = shipmentChangeDB.ShipmentChange(cndWork, out sucObjectList, out errObjectList, out readCnt);

            return status;
        }
        #endregion        
        
    }
}
