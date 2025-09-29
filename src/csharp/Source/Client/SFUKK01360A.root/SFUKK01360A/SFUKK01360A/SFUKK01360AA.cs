//**********************************************************************//
// System			:	Partsman     									//
// Sub System		:													//
// Program name		:	入金更新アクセスクラス							//
//					:	DepsitMainAcs.DLL								//
// Name Space		:	Broadleaf.Application.Controller				//
// Programmer		:	徳永　誠										//
// Date				:	2005.08.09										//
// Note				:													//
//----------------------------------------------------------------------//
// Update Note		:	2008/06/26 30414 忍 幸史                		//
//                  :   Partsman用に変更                                //
//----------------------------------------------------------------------//
//					(c)Copyright  2008 Broadleaf Co,. Ltd				//
//**********************************************************************//
using System;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Xml.Serialization;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// 入金更新アクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 入金データの更新操作を行うアクセスクラスです。</br>
    /// <br>Programmer : 95089 徳永　誠</br>
    /// <br>Date       : 2005.08.11</br>
    /// <br>Update Note : 2010.05.06 gejun</br>
    /// <br>              M1007A-支払手形データ更新追加</br>
    /// <br>Update Note : 2011.08.01 qijh</br>
    /// <br>              SCM対応 - 拠点管理(10704767-00)
    /// <br>              送信済みのチェックメッセージを出力できるように改修</br>
    /// </remarks>
    public class DepsitMainAcs
    {
        // ADD 2011/08/01 qijh SCM対応 - 拠点管理(10704767-00) --------->>>>>>>
        /// <summary>
        /// 送信済チェック失敗のステータス
        /// </summary>
        private const int STATUS_CHK_SEND_ERR = -1001;

        /// <summary>
        /// 送信済チェック失敗のエラーメッセージ
        /// </summary>
        private const string CHK_SEND_ERR_MSG = "送信済みのデータの為、更新できません。";
        // ADD 2011/08/01 qijh SCM対応 - 拠点管理(10704767-00) ---------<<<<<<<

        IDepsitMainDB _depsitMainDB;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : コンストラクタ</br>
        /// <br>Programmer : 18322 T.Kimura</br>
        /// <br>Date       : 2007.05.18</br>
        /// </remarks>
        public DepsitMainAcs()
        {
            try
            {
                // リモートオブジェクト取得
                this._depsitMainDB = (IDepsitMainDB)MediationDepsitMainDB.GetDepsitMainDB();
            }
            catch (Exception)
            {
                //オフライン時はnullをセット
                this._depsitMainDB = null;
            }
        }

        /// <summary>
        /// 入金更新処理
        /// </summary>
        /// <param name="depsitDataWork">入金情報ワーク</param>
        /// <param name="depositAlwWorkList">入金引当情報ワーク</param>
        /// <param name="errmsg">エラーメッセージ</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 入金情報・入金引当情報を元にデータ更新を行います</br>
        /// <br>           : 入金番号無しの時、新規入金作成とします</br>
        /// <br>           : 論理削除を立てた場合、削除処理を行います</br>
        /// <br>           : 入金引当の削除を行う場合は削除したい引当レコードのみ論理削除を立てます</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/06/26</br>
        /// </remarks>
        public int WriteDB(ref DepsitDataWork depsitDataWork, ref DepositAlwWork[] depositAlwWorkList, out string errmsg)
        {

            // XMLへ変換し、クラスのバイナリ化
            byte[] depsitDataWorkByte = XmlByteSerializer.Serialize(depsitDataWork);
            byte[] depositAlwWorkListByte = XmlByteSerializer.Serialize(depositAlwWorkList);

            errmsg = "";
            int status = 0;
            try
            {
                // 入金データ書き込み
                status = this._depsitMainDB.Write(ref depsitDataWorkByte, ref depositAlwWorkListByte);
                if (status == 0)
                {
                    depsitDataWork = (DepsitDataWork)XmlByteSerializer.Deserialize(depsitDataWorkByte, typeof(DepsitDataWork));
                    depositAlwWorkList = (DepositAlwWork[])XmlByteSerializer.Deserialize(depositAlwWorkListByte, typeof(DepositAlwWork[]));
                }
                // ADD 2011/08/01 qijh SCM対応 - 拠点管理(10704767-00) --------->>>>>>>
                if (STATUS_CHK_SEND_ERR == status)
                    errmsg = CHK_SEND_ERR_MSG;
                // ADD 2011/08/01 qijh SCM対応 - 拠点管理(10704767-00) ---------<<<<<<<
            }
            catch (Exception ex)
            {
                //オフライン時はnullをセット
                this._depsitMainDB = null;
                //通信エラーは-1を戻す
                status = -1;

                errmsg = ex.Message;
            }
            return status;
        }

        // --------------- ADD START 2010.05.06 gejun FOR M1007A-M1007A-支払手形データ更新追加------->>>>
        /// <summary>
        /// 入金更新処理(手形データも連れる)
        /// </summary>
        /// <param name="depsitDataWork">入金情報ワーク</param>
        /// <param name="depositAlwWorkList">入金引当情報ワーク</param>
        /// <param name="errmsg">エラーメッセージ</param>
        /// <param name="rcvDraftDataWorkUpd">手形データ（更新用）ワーク</param>
        /// <param name="rcvDraftDataWorkDel">手形データ（削除用）ワーク</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 入金情報・入金引当情報・手形情報を元にデータ更新を行います</br>
        /// <br>           : 入金番号無しの時、新規入金作成とします</br>
        /// <br>           : 論理削除を立てた場合、削除処理を行います</br>
        /// <br>           : 入金引当の削除を行う場合は削除したい引当レコードのみ論理削除を立てます</br>
        /// <br>Note　　　  : 手形情報の更新処理も行います。</br>
        /// <br>Programmer  : 葛軍</br>
        /// <br>Date        : 2010/05/06</br>
        /// </remarks>
        public int WriteDBWithDraftData(ref DepsitDataWork depsitDataWork, ref DepositAlwWork[] depositAlwWorkList, out string errmsg, RcvDraftDataWork rcvDraftDataWorkUpd, RcvDraftDataWork rcvDraftDataWorkDel)
        {

            // XMLへ変換し、クラスのバイナリ化
            byte[] depsitDataWorkByte = XmlByteSerializer.Serialize(depsitDataWork);
            byte[] depositAlwWorkListByte = XmlByteSerializer.Serialize(depositAlwWorkList);

            byte[] rcvDraftDataWorkUpdByte;
            if (rcvDraftDataWorkUpd != null)
               rcvDraftDataWorkUpdByte = XmlByteSerializer.Serialize(rcvDraftDataWorkUpd);
            else
               rcvDraftDataWorkUpdByte = null;

           byte[] rcvDraftDataWorkDelByte;
           if (rcvDraftDataWorkDel != null)
               rcvDraftDataWorkDelByte = XmlByteSerializer.Serialize(rcvDraftDataWorkDel);
           else
               rcvDraftDataWorkDelByte = null;

            errmsg = "";
            int status = 0;
            try
            {
                // 入金データ書き込み
                status = this._depsitMainDB.WriteWithDraftData(ref depsitDataWorkByte, ref depositAlwWorkListByte, rcvDraftDataWorkUpdByte, rcvDraftDataWorkDelByte);
                if (status == 0)
                {
                    depsitDataWork = (DepsitDataWork)XmlByteSerializer.Deserialize(depsitDataWorkByte, typeof(DepsitDataWork));
                    depositAlwWorkList = (DepositAlwWork[])XmlByteSerializer.Deserialize(depositAlwWorkListByte, typeof(DepositAlwWork[]));
                }
                // ADD 2011/08/01 qijh SCM対応 - 拠点管理(10704767-00) --------->>>>>>>
                if (STATUS_CHK_SEND_ERR == status)
                    errmsg = CHK_SEND_ERR_MSG;
                // ADD 2011/08/01 qijh SCM対応 - 拠点管理(10704767-00) ---------<<<<<<<
            }
            catch (Exception ex)
            {
                //オフライン時はnullをセット
                this._depsitMainDB = null;
                //通信エラーは-1を戻す
                status = -1;

                errmsg = ex.Message;
            }

            return status;
        }
        // --------------- ADD END 2010.05.06 gejun FOR M1007A-M1007A-支払手形データ更新追加------->>>>

        /// <summary>
        /// 入金読込処理
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="depositSlipNo">入金番号</param>
        /// <param name="acptAnOdrStatus">受注ステータス(10:見積　20:受注　30:売上　40:出荷)</param>
        /// <param name="depsitDataWork">入金情報</param>
        /// <param name="depositAlwWorkList">入金引当情報</param>
        /// <param name="errmsg">エラーメッセージ</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 入金情報・入金引当情報を入金番号を元にデータ取得を行います</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/06/26</br>
        /// </remarks>
        public int ReadDB(string enterpriseCode, 
                          int depositSlipNo, 
                          int acptAnOdrStatus, 
                          out DepsitDataWork depsitDataWork, 
                          out DepositAlwWork[] depositAlwWorkList, 
                          out string errmsg)
        {

            byte[] depsitDataWorkByte = null;
            byte[] depositAlwWorkListByte = null;

            depsitDataWork = null;
            depositAlwWorkList = null;
            errmsg = "";

            int status = 0;
            try
            {
                // 入金データ読込み
                status = this._depsitMainDB.Read(enterpriseCode, depositSlipNo, acptAnOdrStatus, out depsitDataWorkByte, out depositAlwWorkListByte);
                if (status == 0)
                {
                    depsitDataWork = (DepsitDataWork)XmlByteSerializer.Deserialize(depsitDataWorkByte, typeof(DepsitDataWork));
                    depositAlwWorkList = (DepositAlwWork[])XmlByteSerializer.Deserialize(depositAlwWorkListByte, typeof(DepositAlwWork[]));
                }
            }
            catch (Exception ex)
            {
                //オフライン時はnullをセット
                this._depsitMainDB = null;
                //通信エラーは-1を戻す
                status = -1;

                errmsg = ex.Message;
            }

            return status;
        }

        #region 2008/06/26 DEL Partsman用に変更
        /* --- DEL 2008/06/26 --------------------------------------------------------------------->>>>>
		/// <summary>
		/// 入金更新処理
		/// </summary>
		/// <param name="depsitMainWork">入金情報ワーク</param>
		/// <param name="depositAlwWorkList">入金引当情報ワーク</param>
		/// <param name="errmsg">エラーメッセージ</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 入金情報・入金引当情報を元にデータ更新を行います</br>
		/// <br>           : 入金番号無しの時、新規入金作成とします</br>
		/// <br>           : 論理削除を立てた場合、削除処理を行います</br>
		/// <br>           : 入金引当の削除を行う場合は削除したい引当レコードのみ論理削除を立てます</br>
		/// <br>Programmer : 95089 徳永　誠</br>
		/// <br>Date       : 2005.08.11</br>
		/// </remarks>
		public int WriteDB(ref DepsitMainWork depsitMainWork,  ref DepositAlwWork[] depositAlwWorkList, out string errmsg)
		{

			// XMLへ変換し、クラスのバイナリ化
			byte[] depsitMainWorkByte = XmlByteSerializer.Serialize(depsitMainWork);
			byte[] depositAlwWorkListByte = XmlByteSerializer.Serialize(depositAlwWorkList);

			errmsg = "";
			int status = 0;
			try
			{
				// 入金データ書き込み
				status = this._depsitMainDB.Write(ref depsitMainWorkByte, ref depositAlwWorkListByte);
				if (status == 0)
				{
					depsitMainWork = (DepsitMainWork)XmlByteSerializer.Deserialize(depsitMainWorkByte,typeof(DepsitMainWork));
					depositAlwWorkList = (DepositAlwWork[])XmlByteSerializer.Deserialize(depositAlwWorkListByte,typeof(DepositAlwWork[]));
				}
			}
			catch (Exception ex)
			{
				//オフライン時はnullをセット
				this._depsitMainDB = null;
				//通信エラーは-1を戻す
				status = -1;

				errmsg = ex.Message;
			}

			return status;
		}
        
        /// <summary>
		/// 入金読込処理
		/// </summary>
		/// <param name="EnterpriseCode">企業コード</param>
		/// <param name="DepositSlipNo">入金番号</param>
		/// <param name="depsitMainWork">入金情報</param>
		/// <param name="depositAlwWorkList">入金引当情報</param>
		/// <param name="errmsg">エラーメッセージ</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 入金情報・入金引当情報を入金番号を元にデータ取得を行います</br>
		/// <br>Programmer : 95089 徳永　誠</br>
		/// <br>Date       : 2005.08.11</br>
		/// </remarks>

		public int ReadDB(string EnterpriseCode, int DepositSlipNo, out DepsitMainWork depsitMainWork,  out DepositAlwWork[] depositAlwWorkList, out string errmsg)
		{

			byte[] depsitMainWorkByte = null;
			byte[] depositAlwWorkListByte = null;

			depsitMainWork = null;
			depositAlwWorkList = null;
			errmsg = "";

			int status = 0;
			try
			{
				// 入金データ読込み
				status = this._depsitMainDB.Read(EnterpriseCode, DepositSlipNo, out depsitMainWorkByte, out depositAlwWorkListByte);
				if (status == 0)
				{
					depsitMainWork = (DepsitMainWork)XmlByteSerializer.Deserialize(depsitMainWorkByte,typeof(DepsitMainWork));
					depositAlwWorkList = (DepositAlwWork[])XmlByteSerializer.Deserialize(depositAlwWorkListByte,typeof(DepositAlwWork[]));
				}
			}
			catch (Exception ex)
			{
				//オフライン時はnullをセット
				this._depsitMainDB = null;
				//通信エラーは-1を戻す
				status = -1;

				errmsg = ex.Message;
			}

			return status;
		}
           --- DEL 2008/06/26 ---------------------------------------------------------------------<<<<<*/
        #endregion 2008/06/26 DEL Partsman用に変更

        /// <summary>
        /// 入金一括作成処理（受注指定型）
        /// </summary>
        /// <param name="EnterpriseCode">企業コード</param>
        /// <param name="createDepsitMainWorkList">入金更新データパラメータ(受注指定型)</param>
        /// <param name="depositSlipNoList">更新した入金データの入金番号配列</param>
        /// <param name="errmsg">エラーメッセージ</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 一括作成用パラメータから指定受注への引当更新・入金新規作成処理を行います</br>
        /// <br>           : 受注指定型専用であり、新規入金・引当のみ行えます</br>
        /// <br>Programmer : 95089 徳永　誠</br>
        /// <br>Date       : 2005.08.11</br>
        /// </remarks>
        public int WriteDB(string EnterpriseCode, CreateDepsitMainWork[] createDepsitMainWorkList, out int[] depositSlipNoList, out string errmsg)
        {
            depositSlipNoList = null;

            // XMLへ変換し、クラスのバイナリ化
            byte[] createDepsitMainWorkListByte = XmlByteSerializer.Serialize(createDepsitMainWorkList);

            errmsg = "";
            int status = 0;
            try
            {
                // 入金データ書き込み
                status = this._depsitMainDB.Write(EnterpriseCode, createDepsitMainWorkListByte, out depositSlipNoList);
                if (status == 0)
                {

                }
                // ADD 2011/08/01 qijh SCM対応 - 拠点管理(10704767-00) --------->>>>>>>
                if (STATUS_CHK_SEND_ERR == status)
                    errmsg = CHK_SEND_ERR_MSG;
                // ADD 2011/08/01 qijh SCM対応 - 拠点管理(10704767-00) ---------<<<<<<<
            }
            catch (Exception ex)
            {
                //オフライン時はnullをセット
                this._depsitMainDB = null;
                //通信エラーは-1を戻す
                status = -1;

                errmsg = ex.Message;
            }

            return status;
        }

        /// <summary>
        /// 入金削除処理
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="depositSlipNo">入金番号</param>
        /// <param name="acptAnOdrStatus">受注ステータス(10:見積　20:受注　30:売上　40:出荷)</param>
        /// <param name="errmsg">エラーメッセージ</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 指定した入金番号の入金情報・入金引当情報削除を行います</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/06/26</br>
        /// </remarks>
        public int DeleteDB(string enterpriseCode, int depositSlipNo, int acptAnOdrStatus, out string errmsg)
        {
            errmsg = "";

            int status = 0;
            try
            {
                // ADD 2009/05/01 コメント追記
                // 物理削除メソッドを使用しているが、リモート側で論理削除処理に変更している
                // 入金削除処理
                status = this._depsitMainDB.Delete(enterpriseCode, depositSlipNo, acptAnOdrStatus);
                // ADD 2011/08/01 qijh SCM対応 - 拠点管理(10704767-00) --------->>>>>>>
                if (STATUS_CHK_SEND_ERR == status)
                    errmsg = CHK_SEND_ERR_MSG;
                // ADD 2011/08/01 qijh SCM対応 - 拠点管理(10704767-00) ---------<<<<<<<
            }
            catch (Exception ex)
            {
                //オフライン時はnullをセット
                this._depsitMainDB = null;

                //通信エラーは-1を戻す
                status = -1;

                errmsg = ex.Message;
            }

            return (status);
        }

        /// <summary>
        /// 入金削除処理
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="depositSlipNo">入金番号</param>
        /// <param name="acptAnOdrStatus">受注ステータス(10:見積　20:受注　30:売上　40:出荷)</param>
        /// <param name="errmsg">エラーメッセージ</param>
        /// <param name="retDepsitDataWork">更新入金データ(赤削除時の元黒レコード)</param>
        /// <param name="retDepositAlwWorkList">更新入金引当データ(赤削除時の元黒引当レコード)</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 指定した入金番号の入金情報・入金引当情報削除を行います</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/06/26</br>
        /// </remarks>
        public int DeleteDB(string enterpriseCode, 
                            int depositSlipNo, 
                            int acptAnOdrStatus,
                            out DepsitDataWork retDepsitDataWork, 
                            out DepositAlwWork[] retDepositAlwWorkList, 
                            out string errmsg)
        {
            retDepsitDataWork = null;
            retDepositAlwWorkList = null;
            byte[] depsitDataWorkByte = null;
            byte[] depositAlwWorkListByte = null;

            errmsg = "";

            int status = 0;
            try
            {
                // ADD 2009/05/01 コメント追記
                // 物理削除メソッドを使用しているが、リモート側で論理削除処理に変更している
                // 入金削除処理
                status = this._depsitMainDB.Delete(enterpriseCode, 
                                                   depositSlipNo, 
                                                   acptAnOdrStatus, 
                                                   out depsitDataWorkByte, 
                                                   out depositAlwWorkListByte);
                if (status == 0)
                {
                    if (depsitDataWorkByte != null)
                    {
                        retDepsitDataWork = (DepsitDataWork)XmlByteSerializer.Deserialize(depsitDataWorkByte, typeof(DepsitDataWork));
                    }
                    if (depositAlwWorkListByte != null)
                    {
                        retDepositAlwWorkList = (DepositAlwWork[])XmlByteSerializer.Deserialize(depositAlwWorkListByte, typeof(DepositAlwWork[]));
                    }
                }
                // ADD 2011/08/01 qijh SCM対応 - 拠点管理(10704767-00) --------->>>>>>>
                if (STATUS_CHK_SEND_ERR == status)
                    errmsg = CHK_SEND_ERR_MSG;
                // ADD 2011/08/01 qijh SCM対応 - 拠点管理(10704767-00) ---------<<<<<<<
            }
            catch (Exception ex)
            {
                //オフライン時はnullをセット
                this._depsitMainDB = null;
                //通信エラーは-1を戻す
                status = -1;

                errmsg = ex.Message;
            }

            return status;
        }

        #region 2008/06/26 DEL Partsman用に変更
        /* --- DEL 2008/06/26 --------------------------------------------------------------------->>>>>
        
        /// <summary>
        /// 入金削除処理
        /// </summary>
        /// <param name="EnterpriseCode">企業コード</param>
        /// <param name="DepositSlipNo">入金番号</param>
        /// <param name="errmsg">エラーメッセージ</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 指定した入金番号の入金情報・入金引当情報削除を行います</br>
        /// <br>Programmer : 95089 徳永　誠</br>
        /// <br>Date       : 2005.08.11</br>
        /// </remarks>
        public int DeleteDB(string EnterpriseCode, int DepositSlipNo, out string errmsg)
        {

            errmsg = "";

            int status = 0;
            try
            {
                // 入金削除処理
                status = this._depsitMainDB.Delete(EnterpriseCode, DepositSlipNo);
                if (status == 0)
                {

                }
            }
            catch (Exception ex)
            {
                //オフライン時はnullをセット
                this._depsitMainDB = null;
                //通信エラーは-1を戻す
                status = -1;

                errmsg = ex.Message;
            }

            return status;
        }
        
		/// <summary>
		/// 入金削除処理
		/// </summary>
		/// <param name="EnterpriseCode">企業コード</param>
		/// <param name="DepositSlipNo">入金番号</param>
		/// <param name="errmsg">エラーメッセージ</param>
		/// <param name="RetDepsitMainWork">更新入金データ(赤削除時の元黒レコード)</param>
		/// <param name="RetDepositAlwWorkList">更新入金引当データ(赤削除時の元黒引当レコード)</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 指定した入金番号の入金情報・入金引当情報削除を行います</br>
		/// <br>Programmer : 95089 徳永　誠</br>
		/// <br>Date       : 2005.09.20</br>
		/// </remarks>
		public int DeleteDB(string EnterpriseCode, int DepositSlipNo, out DepsitMainWork RetDepsitMainWork,  out DepositAlwWork[] RetDepositAlwWorkList, out string errmsg)
		{
			RetDepsitMainWork = null;
			RetDepositAlwWorkList = null;
			byte[] depsitMainWorkByte = null;
			byte[] depositAlwWorkListByte = null;

			errmsg = "";

			int status = 0;
			try
			{
				// 入金削除処理
				status = this._depsitMainDB.Delete(EnterpriseCode, DepositSlipNo, out depsitMainWorkByte, out depositAlwWorkListByte);
				if (status == 0)
				{
					if (depsitMainWorkByte != null)
						RetDepsitMainWork = (DepsitMainWork)XmlByteSerializer.Deserialize(depsitMainWorkByte,typeof(DepsitMainWork));
					if (depositAlwWorkListByte != null)
						RetDepositAlwWorkList = (DepositAlwWork[])XmlByteSerializer.Deserialize(depositAlwWorkListByte,typeof(DepositAlwWork[]));
				}
			}
			catch (Exception ex)
			{
				//オフライン時はnullをセット
				this._depsitMainDB = null;
				//通信エラーは-1を戻す
				status = -1;

				errmsg = ex.Message;
			}

			return status;
		}
        
        /// <summary>
        /// 赤入金作成処理
        /// </summary>
        /// <param name="mode">0:赤入金作成 1:赤入金・新黒入金作成</param>
        /// <param name="EnterpriseCode">企業コード</param>
        /// <param name="DepositCd">預り金区分</param>
        /// <param name="UpdateSecCd">更新拠点コード</param>
        /// <param name="DepositAgentCode">入金担当者コード</param>
        /// <param name="DepositAgentNm">入金担当者名</param>
        /// <param name="AddUpADate">計上日</param>
        /// <param name="DepositSlipNo">入金番号</param>
        /// <param name="errmsg">エラーメッセージ</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 指定した入金番号の赤入金作成処理を行います</br>
        /// <br>Programmer : 95089 徳永　誠</br>
        /// <br>Date       : 2005.08.29</br>
        /// <br>Update Note: 2007.01.25 18322 T.Kimura 引数を変更</br>
        /// </remarks>
        // ↓ 20070125 18322 c MA.NS用に変更
        //public int RedCreate(int mode, string EnterpriseCode, int DepositCd, string UpdateSecCd, string DepositAgentCode, DateTime AddUpADate, int DepositSlipNo, out string errmsg )
        public int RedCreate(int mode, string EnterpriseCode, int DepositCd, string UpdateSecCd, string DepositAgentCode, string DepositAgentNm, DateTime AddUpADate, int DepositSlipNo, out string errmsg)
        // ↑ 20070125 18322 c
        {
            errmsg = "";

            int status = 0;
            try
            {
                // ↓ 20070125 18322 c MA.NS用に変更
                //// 赤入金作成処理
                //status = this._depsitMainDB.RedCreate(mode, EnterpriseCode, DepositCd, UpdateSecCd, DepositAgentCode, AddUpADate, DepositSlipNo);

                // 赤入金作成処理
                status = this._depsitMainDB.RedCreate(mode
                                                     , EnterpriseCode
                                                     , DepositCd
                                                     , UpdateSecCd
                                                     , DepositAgentCode
                                                     , DepositAgentNm
                                                     , AddUpADate
                                                     , DepositSlipNo
                                                     );
                // ↑ 20070125 18322 c 
                if (status == 0)
                {

                }
            }
            catch (Exception ex)
            {
                //オフライン時はnullをセット
                this._depsitMainDB = null;
                //通信エラーは-1を戻す
                status = -1;

                errmsg = ex.Message;
            }

            return status;

        }
           --- DEL 2008/06/26 ---------------------------------------------------------------------<<<<<*/
        #endregion 2008/06/26 DEL Partsman用に変更

        /// <summary>
        /// 赤入金作成処理
        /// </summary>
        /// <param name="mode">0:赤入金作成 1:赤入金・新黒入金作成</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="depositCd">預り金区分</param>
        /// <param name="updateSecCd">更新拠点コード</param>
        /// <param name="depositAgentCode">入金担当者コード</param>
        /// <param name="depositAgentNm">入金担当者名</param>
        /// <param name="addUpADate">計上日</param>
        /// <param name="depositSlipNo">入金番号</param>
        /// <param name="acptAnOdrStatus">受注ステータス(10:見積　20:受注　30:売上　40:出荷)</param>
        /// <param name="errmsg">エラーメッセージ</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 指定した入金番号の赤入金作成処理を行います</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/06/26</br>
        /// </remarks>
        public int RedCreate(int mode, 
                             string enterpriseCode, 
                             int depositCd, 
                             string updateSecCd, 
                             string depositAgentCode, 
                             string depositAgentNm, 
                             DateTime addUpADate, 
                             int depositSlipNo, 
                             int acptAnOdrStatus,
                             out string errmsg)
        {
            errmsg = "";

            int status = 0;
            try
            {
                // 赤入金作成処理
                status = this._depsitMainDB.RedCreate(mode,
                                                      enterpriseCode,
                                                      updateSecCd,
                                                      depositAgentCode,
                                                      depositAgentNm,
                                                      addUpADate,
                                                      depositCd,
                                                      acptAnOdrStatus);
                // ADD 2011/08/01 qijh SCM対応 - 拠点管理(10704767-00) --------->>>>>>>
                if (STATUS_CHK_SEND_ERR == status)
                    errmsg = CHK_SEND_ERR_MSG;
                // ADD 2011/08/01 qijh SCM対応 - 拠点管理(10704767-00) ---------<<<<<<<
            }
            catch (Exception ex)
            {
                //オフライン時はnullをセット
                this._depsitMainDB = null;

                //通信エラーは-1を戻す
                status = -1;

                errmsg = ex.Message;
            }

            return (status);

        }

        /// <summary>
        /// 赤入金作成処理
        /// </summary>
        /// <param name="mode">0:赤入金作成 1:赤入金・新黒入金作成</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="depositCd">預り金区分</param>
        /// <param name="updateSecCd">更新拠点コード</param>
        /// <param name="depositAgentCode">入金担当者コード</param>
        /// <param name="depositAgentNm">入金担当者名</param>
        /// <param name="addUpADate">計上日</param>
        /// <param name="depositSlipNo">入金番号</param>
        /// <param name="acptAnOdrStatus">受注ステータス(10:見積　20:受注　30:売上　40:出荷)</param>
        /// <param name="retDepsitDataWorkList">入金マスタ</param>
        /// <param name="retDepositAlwWorkList">入金引当マスタ</param>
        /// <param name="errmsg">エラーメッセージ</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 指定した入金番号の赤入金作成処理を行います</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/06/26</br>
        /// </remarks>
        public int RedCreate(int mode,
                             string enterpriseCode,
                             int depositCd,
                             string updateSecCd,
                             string depositAgentCode,
                             string depositAgentNm,
                             DateTime addUpADate,
                             int depositSlipNo,
                             int acptAnOdrStatus,
                             out DepsitDataWork[] retDepsitDataWorkList,
                             out DepositAlwWork[] retDepositAlwWorkList,
                             out string errmsg)
        {
            errmsg = "";

            int status = 0;

            byte[] RetDepsitDataWorkListByte;
            byte[] RetDepositAlwWorkListByte;

            retDepsitDataWorkList = null;
            retDepositAlwWorkList = null;

            try
            {
                // DEL 2011/08/01 qijh SCM対応 - 拠点管理(10704767-00) --------->>>>>>>
                // 赤入金作成処理
                //this._depsitMainDB.RedCreate(mode, 
                //                             enterpriseCode,
                //                             updateSecCd,
                //                             depositAgentCode,
                //                             depositAgentNm,
                //                             addUpADate,
                //                             depositSlipNo,
                //                             acptAnOdrStatus,
                //                             out RetDepsitDataWorkListByte,
                //                             out RetDepositAlwWorkListByte);
                // DEL 2011/08/01 qijh SCM対応 - 拠点管理(10704767-00) ---------<<<<<<<
                // ADD 2011/08/01 qijh SCM対応 - 拠点管理(10704767-00) --------->>>>>>>
                // 変更内容：[status = ]を追加
                status = this._depsitMainDB.RedCreate(mode,
                                               enterpriseCode,
                                               updateSecCd,
                                               depositAgentCode,
                                               depositAgentNm,
                                               addUpADate,
                                               depositSlipNo,
                                               acptAnOdrStatus,
                                               out RetDepsitDataWorkListByte,
                                               out RetDepositAlwWorkListByte);
                // ADD 2011/08/01 qijh SCM対応 - 拠点管理(10704767-00) ---------<<<<<<<

                if (status == 0)
                {
                    retDepsitDataWorkList = (DepsitDataWork[])XmlByteSerializer.Deserialize(RetDepsitDataWorkListByte, typeof(DepsitDataWork[]));
                    retDepositAlwWorkList = (DepositAlwWork[])XmlByteSerializer.Deserialize(RetDepositAlwWorkListByte, typeof(DepositAlwWork[]));
                }
                // ADD 2011/08/01 qijh SCM対応 - 拠点管理(10704767-00) --------->>>>>>>
                if (STATUS_CHK_SEND_ERR == status)
                    errmsg = CHK_SEND_ERR_MSG;
                // ADD 2011/08/01 qijh SCM対応 - 拠点管理(10704767-00) ---------<<<<<<<
            }
            catch (Exception ex)
            {
                //オフライン時はnullをセット
                this._depsitMainDB = null;

                //通信エラーは-1を戻す
                status = -1;

                errmsg = ex.Message;
            }

            return status;

        }

        #region 2008/06/26 DEL Partsman用に変更
        /* --- DEL 2008/06/26 --------------------------------------------------------------------->>>>>
		/// <summary>
		/// 赤入金作成処理
		/// </summary>
		/// <param name="mode">0:赤入金作成 1:赤入金・新黒入金作成</param>
		/// <param name="EnterpriseCode">企業コード</param>
		/// <param name="DepositCd">預り金区分</param>
		/// <param name="UpdateSecCd">更新拠点コード</param>
		/// <param name="DepositAgentCode">入金担当者コード</param>
		/// <param name="DepositAgentNm">入金担当者名</param>
		/// <param name="AddUpADate">計上日</param>
		/// <param name="DepositSlipNo">入金番号</param>
		/// <param name="RetDepsitMainWorkList">入金マスタ</param>
		/// <param name="RetDepositAlwWorkList">入金引当マスタ</param>
		/// <param name="errmsg">エラーメッセージ</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 指定した入金番号の赤入金作成処理を行います</br>
		/// <br>Programmer : 95089 徳永　誠</br>
		/// <br>Date       : 2005.08.29</br>
		/// <br>Update Note: 2007.01.25 T.Kimura 引数を変更</br>
		/// </remarks>
        // ↓ 20070125 18322 c MA.NS用に変更
        //public int RedCreate(int mode, string EnterpriseCode, int DepositCd, string UpdateSecCd, string DepositAgentCode, DateTime AddUpADate, int DepositSlipNo, out DepsitMainWork[] RetDepsitMainWorkList, out DepositAlwWork[] RetDepositAlwWorkList, out string errmsg )
        public int RedCreate(int mode, string EnterpriseCode, int DepositCd, string UpdateSecCd, string DepositAgentCode, string DepositAgentNm, DateTime AddUpADate, int DepositSlipNo, out DepsitMainWork[] RetDepsitMainWorkList, out DepositAlwWork[] RetDepositAlwWorkList, out string errmsg )
        // ↑ 20070125 18322 c
		{
			errmsg = "";

			int status = 0;

			byte[] RetDepsitMainWorkListByte;
			byte[] RetDepositAlwWorkListByte;

			RetDepsitMainWorkList = null;
			RetDepositAlwWorkList = null;

			try
			{
                // ↓ 20070125 18322 c MA.NS用に変更
				//// 赤入金作成処理
				//status = this._depsitMainDB.RedCreate(mode, EnterpriseCode, DepositCd, UpdateSecCd, DepositAgentCode, AddUpADate, DepositSlipNo, out RetDepsitMainWorkListByte, out RetDepositAlwWorkListByte);

				// 赤入金作成処理
				status = this._depsitMainDB.RedCreate( mode
                                                     , EnterpriseCode
                                                     , DepositCd
                                                     , UpdateSecCd
                                                     , DepositAgentCode
                                                     , DepositAgentNm
                                                     , AddUpADate
                                                     , DepositSlipNo
                                                     , out RetDepsitMainWorkListByte
                                                     , out RetDepositAlwWorkListByte);
                // ↑ 20070125 18322 c
				if (status == 0)
				{
					
					RetDepsitMainWorkList = (DepsitMainWork[])XmlByteSerializer.Deserialize(RetDepsitMainWorkListByte,typeof(DepsitMainWork[]));
					RetDepositAlwWorkList = (DepositAlwWork[])XmlByteSerializer.Deserialize(RetDepositAlwWorkListByte,typeof(DepositAlwWork[]));

				}
			}
			catch (Exception ex)
			{
				//オフライン時はnullをセット
				this._depsitMainDB = null;
				//通信エラーは-1を戻す
				status = -1;

				errmsg = ex.Message;
			}

			return status;

		}
           --- DEL 2008/06/26 ---------------------------------------------------------------------<<<<<*/
        #endregion 2008/06/26 DEL Partsman用に変更

        // ↓ 20070518 18322 d テスト用のモジュールなので削除
        #region 請求売上読込処理(仮)
        // ↓ 20070124 18322 c MA.NS用に変更
        /////// <summary>
        /////// 請求売上読込処理(仮)
        /////// </summary>
        ////public int ReadDmdSalesDB(string EnterpriseCode, int ClaimCode, out DmdSalesWork[] dmdSalesWorkList, out string errmsg)
        //
        ///// <summary>
        ///// 請求売上読込処理(仮)
        ///// </summary>
        //public int ReadDmdSalesDB(string EnterpriseCode, int ClaimCode, out SalesSlipWork[] dmdSalesWorkList, out string errmsg)
        //// ↑ 20070124 18322 c
        //{
        //
        //	byte[] dmdSalesWorkListByte = null;
        //
        //	dmdSalesWorkList = null;
        //	errmsg = "";
        //
        //	int status = 0;
        //	try
        //	{
        //		// 請求売上マスタデータ読込み
        //		status = this._depsitMainDB.ReadDmdSalesRec(EnterpriseCode, ClaimCode, out dmdSalesWorkListByte);
        //		if (status == 0)
        //		{
        //            // ↓ 20070125 18322 c MA.NS用に変更（MA.NSでは請求売上の変わりに売上データを使用）
        //			//dmdSalesWorkList = (DmdSalesWork[])XmlByteSerializer.Deserialize(dmdSalesWorkListByte,typeof(DmdSalesWork[]));
        //	
        //			dmdSalesWorkList = (SalesSlipWork[])XmlByteSerializer.Deserialize(dmdSalesWorkListByte,typeof(SalesSlipWork[]));
        //            // ↑ 20070125 18322 c
        //		}
        //	}
        //	catch (Exception ex)
        //	{
        //		//オフライン時はnullをセット
        //		this._depsitMainDB = null;
        //		//通信エラーは-1を戻す
        //		status = -1;
        //	
        //		errmsg = ex.Message;
        //	}
        //	
        //	return status;
        //}
        #endregion
        // ↑ 20070518 18322 d

    }
}
