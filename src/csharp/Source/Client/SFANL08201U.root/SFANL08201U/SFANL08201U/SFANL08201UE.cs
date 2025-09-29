using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;

using Broadleaf.Library.Resources;
using Broadleaf.Library.Globarization;
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;


namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// 最終抽出条件のI/Oクラスです
    /// </summary>
	class FPprECndAcs
	{
        /// <summary>ＸＭＬファイル名を設定(自由帳票抽出条件)</summary>
        private string _fileNameGr;
        /// <summary>ＸＭＬファイルパス(自由帳票抽出条件)</summary>
        private string _filePathGr;
        /// <summary>ＸＭＬファイル名を設定(自由帳票抽出条件明細)</summary>
        private string _fileNameDt;
        /// <summary>ＸＭＬファイルパス(自由帳票抽出条件明細)</summary>
        private string _filePathDt;

        /// <summary>データバッファ(自由帳票抽出条件)</summary>
        private static List<FrePprECnd> _buff_FrePprECnd = null;
        /// <summary>データバッファ(自由帳票抽出条件明細)</summary>
        private static List<FrePExCndD> _buff_FrePExCndD = null;


        // ===================================================================================== //
        // コンストラクタ
        // ===================================================================================== //
        #region constructor
        /// <summary>
		/// 自由帳票前回抽出条件アクセスクラスコンストラクタ
		/// </summary>
		/// <remarks>
        /// <br>Note       : 自由帳票前回抽出条件アクセスクラスコンストラクタ</br>
		/// <br>Programmer : 22011 柏原 頼人</br>
		/// <br>Date       : 2007.04.17</br>
		/// </remarks>
        public FPprECndAcs()
		{
			try
			{
                // ＸＭＬファイル名を設定(自由帳票抽出条件)
				this._fileNameGr = "FrePprECnd.xml";
                // ＸＭＬファイルパス(自由帳票抽出条件)
                this._filePathGr = ConstantManagement_ClientDirectory.LocalApplicationData_AppSettingData + "\\" + _fileNameGr;
                // ＸＭＬファイル名を設定(自由帳票抽出条件明細)
                this._fileNameDt = "FrePprECndDt.xml";
                // ＸＭＬファイルパス(自由帳票抽出条件明細)
                this._filePathDt = ConstantManagement_ClientDirectory.LocalApplicationData_AppSettingData + "\\" + _fileNameDt;
            }
			catch (Exception)
			{
			}
        }
        #endregion

        #region public Methods

        #region 自由帳票抽出条件読み込み処理(Read)
        /// <summary>
        /// 自由帳票抽出条件読み込み処理
        /// </summary>
        /// <param name="frePprECndLs">自由帳票抽出条件オブジェクトのコレクション</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="outputFormFileName">出力ファイル名</param>
        /// <param name="userPrtPprIdDerivNo">ユーザー帳票ID枝番</param>
        /// <returns>自由帳票抽出条件クラス</returns>
        /// <remarks>
        /// <br>Note       : 自由帳票抽出条件情報を読み込みます。印字位置設定マスタ１レコード単位で関連する情報を取得します。</br>
        /// <br>Programmer : 22011 柏原 頼人</br>
        /// <br>Date       : 2007.04.17</br>
        /// </remarks>
        public int Read(out List<FrePprECnd> frePprECndLs, string enterpriseCode, string outputFormFileName, int userPrtPprIdDerivNo)
        {
            frePprECndLs = new List<FrePprECnd>();
            
            try
            {
                int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

                // データ比較用パラメータ
                FrePprECnd frePprECndPara = new FrePprECnd();
                frePprECndPara.EnterpriseCode = enterpriseCode;
                frePprECndPara.OutputFormFileName = outputFormFileName;
                frePprECndPara.UserPrtPprIdDerivNo = userPrtPprIdDerivNo;

                // ＸＭＬの読み込み
                FrePprECnd[] frePprECnds = XmlDeserialize();

                foreach (FrePprECnd frePprECndTemp in frePprECnds)
                {
                    // 念のため企業コードもチェック
                    if ((frePprECndTemp.EnterpriseCode == frePprECndPara.EnterpriseCode) &&
                        (frePprECndTemp.OutputFormFileName == frePprECndPara.OutputFormFileName) &&
                        (frePprECndTemp.UserPrtPprIdDerivNo == frePprECndPara.UserPrtPprIdDerivNo))
                    {
                        frePprECndLs.Add(frePprECndTemp.Clone());
                    }
                }

                if ((frePprECndLs.Count == 0) || (frePprECndLs == null))
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                }

                return status;
            }
            catch (System.IO.FileNotFoundException)
            {
                return (int)ConstantManagement.DB_Status.ctDB_EOF;
            }
            catch (Exception)
            {
                frePprECndLs = null;
                // エラーは-1を戻す
                return -1;
            }
        }
        #endregion

        #region 自由帳票抽出条件登録・更新処理(Write)
        /// <summary>
        /// 自由帳票抽出条件登録・更新処理
        /// </summary>
        /// <param name="frePprECndLs">自由帳票抽出条件クラス</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 自由帳票抽出条件情報の登録・更新を行います。</br>
        /// <br>Programmer : 22011 柏原 頼人</br>
        /// <br>Date       : 2007.04.17</br>
        /// </remarks>
        public int Write(ref List<FrePprECnd> frePprECndLs)
        {
            ArrayList frePprECndList = new ArrayList();

            // ステータスを ctDB_NOT_FOUND にしておく
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            try
            {
                // ＸＭＬの読み込み
                FrePprECnd[] frePprECnds = XmlDeserialize();

                //アレイリストに格納
                foreach(FrePprECnd frePprECnd in frePprECnds)
                {
                    frePprECndList.Add(frePprECnd);
                }

                bool addFlg = false; 

                foreach(FrePprECnd newFrePprECnd in frePprECndLs)
                {
                    addFlg = false;
                    for (int ix = 0; ix < frePprECnds.Length; ix++)
                    {
                        if((frePprECnds[ix].EnterpriseCode == newFrePprECnd.EnterpriseCode) &&
                           (frePprECnds[ix].OutputFormFileName == newFrePprECnd.OutputFormFileName) &&
                           (frePprECnds[ix].UserPrtPprIdDerivNo == newFrePprECnd.UserPrtPprIdDerivNo) &&
                           (frePprECnds[ix].FrePrtPprExtraCondCd == newFrePprECnd.FrePrtPprExtraCondCd))
                        {
                            //キー一致：更新
                            newFrePprECnd.CreateDateTime = frePprECnds[ix].CreateDateTime;	        // 作成日時
                            newFrePprECnd.UpdateDateTime = DateTime.Now;　　                        // 更新日時更新
                            newFrePprECnd.FileHeaderGuid = frePprECnds[ix].FileHeaderGuid;          // GUID
                            newFrePprECnd.EnterpriseCode = frePprECnds[ix].EnterpriseCode;          // 企業コード
                            frePprECndList[ix] = newFrePprECnd;
                            addFlg = true;
                            break;
                        }        
                    }

                    if (addFlg == false) // 追加されていないとき
                    {
                        //キー不一致：新規登録
                        newFrePprECnd.CreateDateTime = DateTime.Now;	                        // 作成日時
                        newFrePprECnd.UpdateDateTime = DateTime.Now;                            // 更新日時更新
                        newFrePprECnd.FileHeaderGuid = System.Guid.NewGuid();	                // GUID
                        newFrePprECnd.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;     // 企業コード
                        frePprECndList.Add(newFrePprECnd);
                    }
                }
            
                // ステータスをチェック
                
                // KEYで並び替える
                frePprECndList.Sort();
                // ＸＭＬの書き込み（自由帳票抽出条件Listシリアライズ処理）
                this.ListSerialize(frePprECndList, this._fileNameGr);
                


                if (_buff_FrePprECnd != null)
                {
                    SortedList sortList = new SortedList();

                    //キャッシュ更新
                    foreach (FrePprECnd frePprECndwk in frePprECndList)
                    {
                        sortList.Add(frePprECndwk.DisplayOrder, frePprECndwk);
                    }
                    _buff_FrePprECnd.Clear();

                    foreach (FrePprECnd frePprECndwk in sortList.Values)
                    {
                        _buff_FrePprECnd.Add(frePprECndwk);
                    }                    
                }
                
            }
            catch (Exception)
            {
                // エラー！
                status = -1;
            }

            return status;
        }
        #endregion
    
        #region 自由帳票抽出条件検索処理(SearchAll)
        /// <summary>
        /// 自由帳票抽出条件検索処理（論理削除含む）
        /// </summary>
        /// <param name="retList">読込結果コレクション</param>
        /// <param name="enterpriseCode">企業コード</param>		
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 自由帳票抽出条件の全検索処理を行います。論理削除データも抽出対象となります。</br>
        /// <br>Programmer : 22011 柏原 頼人</br>
        /// <br>Date       : 2007.04.17</br>
        /// </remarks>
        public int SearchAll(out List<FrePprECnd> retList, string enterpriseCode)
        {
            retList = new List<FrePprECnd>();
            
            int status = 0;
            try
            {
                // ＸＭＬの読み込み
                FrePprECnd[] frePprECnds = XmlDeserialize();

                for (int ix = 0; ix < frePprECnds.Length; ix++)
                {
                    // 読込結果コレクションに追加
                    if (frePprECnds[ix].LogicalDeleteCode == 0)
                        retList.Add(frePprECnds[ix]);
                }

                // 読込結果なしの場合はEOFを返す
                if (retList.Count <= 0)
                    status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            }
            catch (System.IO.FileNotFoundException)
            {
                return (int)ConstantManagement.DB_Status.ctDB_EOF;
            }
            catch (Exception)
            {
                // エラー！
                return -1;
            }
            return status;
        }
          #endregion

        #region キャッシュ取得処理
        /// <summary>
        /// キャッシュ取得処理
        /// </summary>
        /// <param name="retList">データバッファ</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="mode">0:論理削除を除く,1:論理削除を含む</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : データバッファを取得します</br>
        /// <br>Programmer : 22011 柏原 頼人</br>
        /// <br>Date       : 2007.04.17</br>
        /// </remarks>
        public int GetBuff(out List<FrePprECnd> retList, string enterpriseCode, int mode)
        {
            int status = 0;

            // ガイド用バッファにデータが無ければリモートより取得する
            if ((_buff_FrePprECnd == null) || (_buff_FrePprECnd.Count == 0))
            {
                if (_buff_FrePprECnd == null) { _buff_FrePprECnd = new List<FrePprECnd>(); }
                _buff_FrePprECnd.Clear();

                List<FrePprECnd> frePprECndLs = new List<FrePprECnd>();
                status = SearchAll(out frePprECndLs, enterpriseCode);

                foreach (FrePprECnd frePprECnd in frePprECndLs)
                {
                    if (frePprECnd.LogicalDeleteCode == 0)
                    {
                        _buff_FrePprECnd.Add(frePprECnd);
                    }
                    //_logicalBuff_FrePprECnd.Add(frePprECnd);
                }
            }
            if (mode == 0)
            {
                retList = _buff_FrePprECnd;
            }
            else
            {
                // 空の状態で返す
                retList = new List<FrePprECnd>();
            }

            return status;
        }
        #endregion

        #region 自由帳票抽出条件読み込み処理(キャッシュから)
        /// <summary>
        /// 自由帳票抽出条件読み込み処理(キャッシュから)
        /// </summary>
        /// <param name="frePprECnd">自由帳票抽出条件オブジェクト</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="outputFormFileName">出力ファイル名</param>
        /// <param name="userPrtPprIdDerivNo">ユーザー帳票ID枝番</param>
        /// <returns>自由帳票抽出条件クラス</returns>
        /// <remarks>
        /// <br>Note       : 自由帳票抽出条件情報をキャッシュから読み込みます。</br>
        /// <br>Programmer : 22011 柏原　頼人</br>
        /// <br>Date       : 2007.04.17</br>
        /// </remarks>
        public int SearchStaticMemory(out List<FrePprECnd> frePprECnd, string enterpriseCode, string outputFormFileName, int userPrtPprIdDerivNo)
        {
            frePprECnd = new List<FrePprECnd>();

            try
            {
                int status = 0;

                // バッファにデータが無ければXMLより取得する
                if ((_buff_FrePprECnd == null) || (_buff_FrePprECnd.Count == 0))
                {
                    if (_buff_FrePprECnd == null)
                    {
                        _buff_FrePprECnd = new List<FrePprECnd>();
                    }
                    _buff_FrePprECnd.Clear();

                    List<FrePprECnd> frePprECndLs = new List<FrePprECnd>();
                    status = SearchAll(out frePprECndLs, enterpriseCode);

                    foreach (FrePprECnd prtMng in frePprECndLs)
                    {
                        if (prtMng.LogicalDeleteCode == 0)
                        {
                            _buff_FrePprECnd.Add(prtMng);
                        }
                    }
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        return status;
                    }
                }
                else
                {
                    frePprECnd = _buff_FrePprECnd;
                }
                return status;
            }
            catch (Exception)
            {
                frePprECnd = null;
                // エラーは-1を戻す
                return -1;
            }
        }
        #endregion

        #region 自由帳票抽出条件読み込み処理(Read)
        /// <summary>
        /// 自由帳票抽出条件明細読み込み処理
        /// </summary>
        /// <param name="frePExCndDLs">自由帳票抽出条件明細オブジェクトのコレクション</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="extraCondDatailGrpCd">抽出条件明細グループコード</param>
        /// <returns>自由帳票抽出条件クラス</returns>
        /// <remarks>
        /// <br>Note       : 自由帳票抽出条件明細情報を読み込みます。印字位置設定マスタ１レコード単位で関連する情報を取得します。</br>
        /// <br>Programmer : 22011 柏原 頼人</br>
        /// <br>Date       : 2007.04.17</br>
        /// </remarks>
        public int ReadDtl(out List<FrePExCndD> frePExCndDLs, string enterpriseCode, int extraCondDatailGrpCd)
        {
            frePExCndDLs = new List<FrePExCndD>();

            try
            {
                int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

                // データ比較用パラメータ
                FrePExCndD frePExCndDPara = new FrePExCndD();
                frePExCndDPara.EnterpriseCode = enterpriseCode;
                frePExCndDPara.ExtraCondDetailGrpCd = extraCondDatailGrpCd;
                
                // ＸＭＬの読み込み
                FrePExCndD[] frePExCndDs = XmlDeserializeDtl();

                foreach (FrePExCndD frePExCndDTemp in frePExCndDs)
                {
                    // 念のため企業コードもチェック
                    if ((frePExCndDTemp.EnterpriseCode == frePExCndDPara.EnterpriseCode) &&
                        (frePExCndDTemp.ExtraCondDetailCode == frePExCndDPara.ExtraCondDetailCode))
                    {
                        frePExCndDLs.Add(frePExCndDTemp.Clone());
                    }
                }

                if ((frePExCndDLs.Count == 0) || (frePExCndDLs == null))
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                }

                return status;
            }
            catch (System.IO.FileNotFoundException)
            {
                return (int)ConstantManagement.DB_Status.ctDB_EOF;
            }
            catch (Exception)
            {
                frePExCndDLs = null;
                // エラーは-1を戻す
                return -1;
            }
        }
        #endregion

        #region 自由帳票抽出条件明細 登録・更新処理(Write)
        /// <summary>
        /// 自由帳票抽出条件明細登録・更新処理
        /// </summary>
        /// <param name="frePExCndDLs">自由帳票抽出条件明細クラス</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 自由帳票抽出条件明細情報の登録・更新を行います。</br>
        /// <br>Programmer : 22011 柏原 頼人</br>
        /// <br>Date       : 2007.04.17</br>
        /// </remarks>
        public int WriteDtl(ref List<FrePExCndD> frePExCndDLs)
        {
            ArrayList frePExCndDList = new ArrayList();

            // ステータスを ctDB_NOT_FOUND にしておく
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            try
            {
                // ＸＭＬの読み込み
                FrePExCndD[] frePExCndDs = XmlDeserializeDtl();

                //アレイリストに格納
                foreach (FrePExCndD frePExCndD in frePExCndDs)
                {
                    frePExCndDList.Add(frePExCndD);
                }

                bool addFlg = false;

                foreach (FrePExCndD newFrePExCndD in frePExCndDLs)
                {
                    addFlg = false;
                    for (int ix = 0; ix < frePExCndDs.Length; ix++)
                    {
                        if ((frePExCndDs[ix].EnterpriseCode == newFrePExCndD.EnterpriseCode) &&
                           (frePExCndDs[ix].ExtraCondDetailCode == newFrePExCndD.ExtraCondDetailCode) &&
                           (frePExCndDs[ix].ExtraCondDetailCode == newFrePExCndD.ExtraCondDetailCode))
                        {
                            //キー一致：更新
                            newFrePExCndD.CreateDateTime = frePExCndDs[ix].CreateDateTime;	        // 作成日時
                            newFrePExCndD.UpdateDateTime = DateTime.Now;　　                        // 更新日時更新
                            newFrePExCndD.FileHeaderGuid = frePExCndDs[ix].FileHeaderGuid;          // GUID
                            newFrePExCndD.EnterpriseCode = frePExCndDs[ix].EnterpriseCode;          // 企業コード
                            frePExCndDList[ix] = newFrePExCndD;
                            addFlg = true;
                            break;
                        }
                    }

                    if (addFlg == false) // 追加されていないとき
                    {
                        //キー不一致：新規登録
                        newFrePExCndD.CreateDateTime = DateTime.Now;	                        // 作成日時
                        newFrePExCndD.UpdateDateTime = DateTime.Now;                            // 更新日時更新
                        newFrePExCndD.FileHeaderGuid = System.Guid.NewGuid();	                // GUID
                        newFrePExCndD.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;     // 企業コード
                        frePExCndDList.Add(newFrePExCndD);
                    }
                }

                // ステータスをチェック

                // KEYで並び替える
                frePExCndDList.Sort();
                // ＸＭＬの書き込み（自由帳票抽出条件Listシリアライズ処理）
                this.ListSerialize(frePExCndDList, this._fileNameDt);



                if (_buff_FrePExCndD != null)
                {
                    SortedList sortList = new SortedList();

                    //キャッシュ更新
                    foreach (FrePExCndD frePExCndDwk in frePExCndDList)
                    {
                        sortList.Add(frePExCndDwk.ExtraCondDetailCode, frePExCndDwk);
                    }
                    _buff_FrePExCndD.Clear();

                    foreach (FrePExCndD frePExCndDwk in sortList.Values)
                    {
                        _buff_FrePExCndD.Add(frePExCndDwk);
                    }
                }

            }
            catch (Exception)
            {
                // エラー！
                status = -1;
            }
            return status;
        }
        #endregion


        #endregion

        #region private Methods

        #region 自由帳票抽出条件Listシリアライズ処理
        /// <summary>
        /// 自由帳票抽出条件Listシリアライズ処理
        /// </summary>
        /// <param name="frePprECndList">シリアライズ対象自由帳票抽出条件Listクラス</param>
        /// <param name="fileName">シリアライズファイル名</param>
        /// <remarks>
        /// <br>Note       : 自由帳票抽出条件List情報のシリアライズを行います。</br>
        /// <br>Programmer : 22011 柏原 頼人</br>
        /// <br>Date       : 2007.04.17</br>
        /// </remarks>
        private void ListSerialize(ArrayList frePprECndList, string fileName)
        {
            // ArrayListから配列を生成
            FrePprECnd[] frePprECnds = (FrePprECnd[])frePprECndList.ToArray(typeof(FrePprECnd));
            //格納ディレクトリがなければ作成
            if (System.IO.Directory.Exists(ConstantManagement_ClientDirectory.LocalApplicationData_AppSettingData) == false)
            {
                System.IO.Directory.CreateDirectory(ConstantManagement_ClientDirectory.LocalApplicationData_AppSettingData);
            }

            UserSettingController.SerializeUserSetting(frePprECnds, _filePathGr);
        }
        #endregion

        #region 自由帳表抽出条件デシリアライズ処理
        /// <summary>
        /// XMLから自由帳表抽出条件クラスへデシリアライズします
        /// </summary>
        /// <returns>自由帳表抽出条件配列</returns>
        private FrePprECnd[] XmlDeserialize()
        {
            return (FrePprECnd[])UserSettingController.DeserializeUserSetting(this._filePathGr, typeof(FrePprECnd[]));
        }
        #endregion

        #region 自由帳票抽出条件明細Listシリアライズ処理
        /// <summary>
        /// 自由帳票抽出条件Listシリアライズ処理
        /// </summary>
        /// <param name="frePExCndDList">シリアライズ対象自由帳票抽出条件Listクラス</param>
        /// <param name="fileName">シリアライズファイル名</param>
        /// <remarks>
        /// <br>Note       : 自由帳票抽出条件List情報のシリアライズを行います。</br>
        /// <br>Programmer : 22011 柏原 頼人</br>
        /// <br>Date       : 2007.04.17</br>
        /// </remarks>
        private void ListSerializeDtl(ArrayList frePExCndDList, string fileName)
        {
            // ArrayListから配列を生成
            FrePExCndD[] frePExCndDs = (FrePExCndD[])frePExCndDList.ToArray(typeof(FrePExCndD));
            //格納ディレクトリがなければ作成
            if (System.IO.Directory.Exists(ConstantManagement_ClientDirectory.LocalApplicationData_AppSettingData) == false)
            {
                System.IO.Directory.CreateDirectory(ConstantManagement_ClientDirectory.LocalApplicationData_AppSettingData);
            }

            UserSettingController.SerializeUserSetting(frePExCndDs, _filePathDt);
        }
        #endregion

        #region 自由帳表抽出条件明細デシリアライズ処理
        /// <summary>
        /// XMLから自由帳表抽出条件クラスへデシリアライズします
        /// </summary>
        /// <returns>自由帳表抽出条件配列</returns>
        private FrePExCndD[] XmlDeserializeDtl()
        {
            return (FrePExCndD[])UserSettingController.DeserializeUserSetting(this._filePathDt, typeof(FrePExCndD[]));
        }
        #endregion

        #endregion

    }
}
