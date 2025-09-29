using System;
using System.Collections;
using System.Collections.Generic;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Controller;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// 印字位置設定 アクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 印字位置設定(ユーザーDB)マスタ更新・取得等の操作を行うアクセスクラスです。</br>
    /// <br>Programmer : 22011 柏原　頼人</br>
    /// <br>Date       : 2007.05.18</br>
    /// <br></br>
    /// <br>Update Note: 22011 柏原 頼人</br>
    /// <br>           : 2008.03.18 印字位置の削除順をサーバーの印字位置データを最初に変更</br>
    /// </remarks>
    public class SFANL08230AE
    {
        IFrePrtPSetDLDB _frePrtPSetDB;
        FrePrtPSetAcs _frePrtPSetAcs = new FrePrtPSetAcs();    //自由帳票印字位置DBアクセスクラス
        FrePrtPosLocalAcs _frePrtPosLocalAcs = new FrePrtPosLocalAcs(); //自由帳票印字位置ローカルファイルアクセスクラス

        // Image関連
        private const Int32 ctSYSTEMDIVCD = 0;
        private const Int32 ctIMAGEUSESYSTEM_CODE = 100;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public SFANL08230AE()
		{
			try
			{
				// リモートオブジェクト取得
				this._frePrtPSetDB = (IFrePrtPSetDLDB)MediationFrePrtPSetDLDB.GetFrePrtPSetDLDB();
			}
			catch (Exception)
			{
				//オフライン時はnullをセット
				this._frePrtPSetDB = null;
			}
        }

        /// <summary>
        /// 印字位置設定/抽出条件/ソート順・(背景画像)の取得を行います。
        /// </summary>
        /// <param name="frePrtPSet">印字位置データクラス</param>
        /// <param name="frePprECndLs">抽出条件データクラス</param>
        /// <param name="frePprSrtOLs">ソート順データクラス</param>
        /// <param name="errmsg">エラーメッセージ</param>
        /// <returns></returns>
        public int Read(ref FrePrtPSet frePrtPSet, out List<FrePprECnd> frePprECndLs, out List<FrePprSrtO> frePprSrtOLs, out string errmsg)
        {
            int status = 0;
            errmsg = "";
            frePprECndLs = new List<FrePprECnd>();
            frePprSrtOLs = new List<FrePprSrtO>();
            try
            {
                status = _frePrtPSetAcs.ReadDBFrePrtPSet(ref frePrtPSet, out frePprECndLs, out frePprSrtOLs);
            }
            catch (Exception ex)
            {
                status = -1;
                errmsg = ex.Message;
            }
            return status;
        }

        #region 印字位置設定情報を物理削除
        /// <summary>
        /// 印字位置設定情報を物理削除します
        /// </summary>
        /// <param name="frePrtPSetWork">印字位置設定データパラメータ(キー値のみを指定)</param>
        /// <param name="msgDiv">メッセージ有無区分</param>
        /// <param name="errmsg">エラーメッセージ文字列</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 印字位置設定情報を物理削除します</br>
        /// <br>Programmer : 22011 柏原　頼人</br>
        /// <br>Date       : 2007.05.18</br>
        /// </remarks>
        public int Delete(FrePrtPSetWork frePrtPSetWork, out bool msgDiv, out string errmsg)
        {
            errmsg = "";
            msgDiv = false;
            int status = 0;

            try
            {
                // 2008.03.18 サーバーの印字位置データを最初に削除するよう修正
                // 排他制御時、背景画像のみが消えるのを防ぐため

                // XMLへ変換し、クラスのバイナリ化
                byte[] frePrtPSetWorkByte = XmlByteSerializer.Serialize(frePrtPSetWork);
                // 印字位置設定の削除
                status = this._frePrtPSetDB.DeleteFrePrtPSet(frePrtPSetWorkByte,out msgDiv, out errmsg);

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/11/07 DEL
                //if ((int)ConstantManagement.DB_Status.ctDB_NORMAL == status)
                //{
                //    // ローカルファイル削除
                //    status = _frePrtPosLocalAcs.DeleteLocalFrePrtPSet(frePrtPSetWork.EnterpriseCode, frePrtPSetWork.OutputFormFileName, frePrtPSetWork.UserPrtPprIdDerivNo);
                //    if ((status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) && (status != (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND))
                //    {
                //        errmsg = _frePrtPosLocalAcs.ErrorMessage;
                //        return -1;
                //    }

                //    // 画像サーバの画像(背景画像)を削除
                //    ImageGroup[] imageGroupArray;
                //    ImgManage[] imgManageArray;
                //    ImageImgAcs _imageImgAcs = new ImageImgAcs();          //画像管理アクセスクラス;

                //    status = _imageImgAcs.Search(out imageGroupArray, out imgManageArray, frePrtPSetWork.EnterpriseCode, frePrtPSetWork.TakeInImageGroupCd, ctSYSTEMDIVCD, ctIMAGEUSESYSTEM_CODE, true);
                //    if ((int)ConstantManagement.DB_Status.ctDB_NOT_FOUND == status) return 0;  // 2008.03.18 ADD

                //    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                //    {
                //        if (!((imageGroupArray != null) && (imageGroupArray.Length > 0)))
                //        {
                //            status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                //        }

                //        if ((imgManageArray == null) || (imgManageArray.Length == 0))
                //        {
                //            status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                //        }
                //    }
                //    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                //    {
                //        status = _imageImgAcs.Delete(imageGroupArray[0]);
                //    }

                //    if ((status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) && (status != (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND))
                //    {
                //        errmsg = "背景画像の削除処理に失敗しました";
                //        return -1;
                //    }
                //}
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/11/07 DEL
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Exception");
                //オフライン時はnullをセット
                this._frePrtPSetDB = null;
                //通信エラーは-1を戻す
                status = -1;
                errmsg = ex.Message;
            }
            return status;
        }
        #endregion

        #region 印字位置設定検索処理(ガイド用)
        /// <summary>
		/// 印字位置設定検索処理(ガイド用)
		/// </summary>
        /// <param name="EnterpriseCode">企業コード</param>
		/// <param name="OutputFormFileName">出力ファイル名</param>
		/// <param name="frePrtPSetWorkList">検索した印字位置設定配列</param>
		/// <param name="readMode">検索区分</param>
		/// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
		/// <param name="errmsg">エラーメッセージ</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 印字位置設定情報を検索します</br>
		/// <br>           : ※出力ファイル名未指定時、全リストを取得します</br>
		/// <br>           : ※印字位置設定データ、背景画像データは取得しません</br>
		/// <br>Programmer : 22011 柏原　頼人</br>
		/// <br>Date       : 2007.05.18</br>
		/// </remarks>
		public int Search(string EnterpriseCode,string OutputFormFileName, out FrePrtPSetWork[] frePrtPSetWorkList, int readMode, ConstantManagement.LogicalMode logicalMode, out string errmsg)
		{
			errmsg = "";
			int status = 0;
			frePrtPSetWorkList = null;
            bool msgDiv = false;       //メッセージ有無区分
            string errMsg="";     //エラーメッセージ文字列

			try
			{
				byte[] frePrtPSetWorkListkByte;

				// 印字位置設定の検索
				status = this._frePrtPSetDB.Search(EnterpriseCode,OutputFormFileName, out frePrtPSetWorkListkByte, readMode, logicalMode, out msgDiv, out errMsg);
				if (status == 0)
				{
					// XMLバイト列からクラス配列へ展開
					frePrtPSetWorkList = (FrePrtPSetWork[])XmlByteSerializer.Deserialize(frePrtPSetWorkListkByte,typeof(FrePrtPSetWork[]));
				}
				else
				{
					frePrtPSetWorkList = null;
				}
			}
			catch (Exception ex)
			{
				//オフライン時はnullをセット
				this._frePrtPSetDB = null;
				//通信エラーは-1を戻す
				status = -1;
				errmsg = ex.Message;
			}
            if (msgDiv == true)
            {
                errmsg = errmsg + "\r\n\r\n*詳細 = " + errMsg;
            }
			return status;
        }
        #endregion
    }
}
