using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;

using Broadleaf.Windows.Forms;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Text;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Remoting.Adapter;
//using Broadleaf.Application.LocalAccess;	2007.10.04 sasaki
// 2008.02.08 96012 ローカルＤＢ参照対応 Begin
using Broadleaf.Application.LocalAccess;
// 2008.02.08 96012 ローカルＤＢ参照対応 end

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// 備考ガイドテーブルアクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 備考ガイドテーブルのアクセス制御を行います。</br>
    /// <br>Programmer : 三崎 貴史</br>
    /// <br>Date       : 2005.10.14</br>
    /// <br></br>
    /// <br>Update Note: 2007.02.27 22022 段上 知子</br>
    /// <br>			 ・SF版を流用し携帯版を作成</br>
    /// <br>Update Note: 2007.04.04 980023 飯谷 耕平</br>
    /// <br>			 ・Read、ガイドのSearch の処理をローカルDBからの読込に変更</br>
    /// <br>Update Note: 2007.05.21 18322 木村 武正</br>
    /// <br>			 ・Read、ガイドのSearch の処理をローカルDBからの読込に変更(NoteGuidWorkList対応)</br>
	/// <br>Update Note: 2007.10.04 21024 佐々木 健</br>
	/// <br>			 ・DC.NS用にローカル対応を削除</br>
    /// -----------------------------------------------------------------------
    /// <br>UpdateNote : 2008.02.08 96012　日色 馨</br>
    /// <br>           : ローカルＤＢ参照対応</br>
    /// <br>-------------------------------------------------------</br>
    /// <br>Update Note : オフライン対応 </br>
    /// <br>			: 22008 長内 数馬</br>
    /// <br>			: 2010/05/25</br>
    /// <br>-------------------------------------------------------</br>
    /// </remarks>
    public class NoteGuidAcs : IGeneralGuideData
    {
        #region Private Members
        /// <summary>リモートオブジェクト格納バッファ</summary>
        private INoteGuidBdDB _iNoteGuidBdDB = null;
		// 2007.10.04 sasaki >>
		///// <summary>ローカルDBオブジェクト格納バッファ</summary>
		//private NoteGuidBdLcDB _noteGuidBdLcDB = null;  // iitani a
		// 2007.10.04 sasaki <<
		/// <summary>ガイド用データバッファ</summary>
        // 2008.02.08 96012 ローカルＤＢ参照対応 Begin
        // <summary>ローカルDBオブジェクト格納バッファ</summary>
        private NoteGuidBdLcDB _noteGuidBdLcDB = null;
        private static bool _isLocalDBRead = false;
        // 2008.02.08 96012 ローカルＤＢ参照対応 end
        private static Hashtable _guidBuff_NoteGdBd;
        /// <summary>備考ガイド（ヘッダ）クラスStatic</summary>
        private static Hashtable _noteGdHdTable_Stc = null;
        #endregion

        // 2008.02.08 96012 ローカルＤＢ参照対応 Begin
        #region Properties
        /// <summary> ローカルＤＢ参照モードプロパティ</summary>
        public bool IsLocalDBRead
        {
            get { return _isLocalDBRead; }
            set { _isLocalDBRead = value; }
        }
        #endregion
        // 2008.02.08 96012 ローカルＤＢ参照対応 end

        #region Constructor
        /// <summary>
        /// 備考ガイドテーブルアクセスクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 備考ガイドテーブルアクセスクラスの新しいインスタンスを初期化します。</br>
        /// <br>Programmer : 三崎 貴史</br>
        /// <br>Date       : 2005.10.14</br>
        /// -----------------------------------------------------------------------
        /// <br>UpdateNote : 2008.02.08 96012　日色 馨</br>
        /// <br>           : ローカルＤＢ参照対応</br>
        /// </remarks>
        public NoteGuidAcs()
        {
            // 備考ガイド（ヘッダ）Static
            if (_noteGdHdTable_Stc == null)
            {
                _noteGdHdTable_Stc = new Hashtable();
            }

            // ログイン部品で通信状態を確認
            // -- UPD 2010/05/25 ------------------->>>
            //if (LoginInfoAcquisition.OnlineFlag)
            //{
            //    try
            //    {
            //        // リモートオブジェクト取得
            //        this._iNoteGuidBdDB = (INoteGuidBdDB)MediationNoteGuidBdDB.GetNoteGuidBdDB();
            //    }
            //    catch (Exception)
            //    {
            //        //オフライン時はnullをセット
            //        this._iNoteGuidBdDB = null;
            //    }
            //}
            //else
            //{
            //    // オフライン時のデータ読み込み
            //    this.SearchOfflineData();
            //}

            try
            {
                // リモートオブジェクト取得
                this._iNoteGuidBdDB = (INoteGuidBdDB)MediationNoteGuidBdDB.GetNoteGuidBdDB();
            }
            catch (Exception)
            {
                //オフライン時はnullをセット
                this._iNoteGuidBdDB = null;
            }
            // -- UPD 2010/05/25 -------------------<<<

            // ローカルDBアクセスオブジェクト取得
			// 2007.10.04 sasaki >>
            //this._noteGuidBdLcDB = new NoteGuidBdLcDB();   // iitani a
			// 2007.10.04 sasaki <<
            // 2008.02.08 96012 ローカルＤＢ参照対応 Begin
            // ローカルDBアクセスオブジェクト取得
            this._noteGuidBdLcDB = new NoteGuidBdLcDB();
            // 2008.02.08 96012 ローカルＤＢ参照対応 end
        }
        #endregion

        /// <summary>
        /// オンラインモード取得処理
        /// </summary>
        /// <returns>OnlineMode</returns>
        /// <remarks>
        /// <br>Note       : オンラインモードを取得します。</br>
        /// <br>Programmer : 三崎 貴史</br>
        /// <br>Date       : 2005.10.14</br>
        /// </remarks>
        public int GetOnlineMode()
        {
            if (this._iNoteGuidBdDB == null)
            {
                return (int)ConstantManagement.OnlineMode.Offline;
            }
            else
            {
                return (int)ConstantManagement.OnlineMode.Online;
            }
        }

        /// <summary>
        /// 備考ガイド（ヘッダ）Staticメモリ全件取得処理
        /// </summary>
        /// <param name="retList">備考ガイド（ヘッダ）List</param>
        /// <returns>ステータス(0:正常終了, -1:エラー, 9:データ無し)</returns>
        /// <remarks>
        /// <br>Note       : 備考ガイド（ヘッダ）Staticメモリの全件を取得します。</br>
        /// <br>Programer  : 22033  三崎  貴史</br>
        /// <br>Date       : 2006.04.25</br>
        /// </remarks>
        public int SearchStaticMemory(out ArrayList retList)
        {
            retList = new ArrayList();
            retList.Clear();

            if (_noteGdHdTable_Stc == null)
            {
                return -1;
            }
            else if (_noteGdHdTable_Stc.Count == 0)
            {
                return 9;
            }

            SortedList sortedList = new SortedList();
            foreach (NoteGuidHd wkNoteGuidHd in _noteGdHdTable_Stc.Values)
            {
                sortedList.Add(wkNoteGuidHd.NoteGuideDivCode, wkNoteGuidHd);
            }

            retList.AddRange(sortedList.Values);

            return 0;
        }

        /// <summary>
        /// 備考ガイド（ヘッダ）取得処理
        /// </summary>
        /// <param name="noteGuidHd">備考ガイド（ヘッダ）クラス</param>
        /// <param name="noteGuideDivCode">備考ガイド区分コード</param>
        /// <returns>ステータス(0:正常終了, -1:エラー, 4:データ無し)</returns>
        /// <remarks>
        /// <br>Note       : 備考ガイド（ヘッダ）メモリを検索します。</br>
        /// <br>Programer  : 22033  三崎  貴史</br>
        /// <br>Date       : 2006.04.25</br>
        /// </remarks>
        public int ReadStaticMemory(out NoteGuidHd noteGuidHd, int noteGuideDivCode)
        {
            noteGuidHd = new NoteGuidHd();

            if (_noteGdHdTable_Stc == null)
            {
                return -1;
            }

            // Staticから検索
            if (_noteGdHdTable_Stc[noteGuideDivCode] == null)
            {
                return 4;
            }
            else
            {
                noteGuidHd = (NoteGuidHd)_noteGdHdTable_Stc[noteGuideDivCode];
            }

            return 0;
        }

        /// <summary>
        /// 備考ガイド（ヘッダ）Staticメモリ情報オフライン書き込み処理
        /// </summary>
        /// <param name="sender">object（呼出元オブジェクト）</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 備考ガイド（ヘッダ）Staticメモリの情報をローカルファイルに保存します。</br>
        /// <br>Programer  : 22033  三崎  貴史</br>
        /// <br>Date       : 2006.04.25</br>
        /// </remarks>
        public int WriteOfflineData(object sender)
        {
            // オフラインシリアライズデータ作成部品I/O
            OfflineDataSerializer offlineDataSerializer = new OfflineDataSerializer();
            int status = 9;

            if (_noteGdHdTable_Stc.Count != 0)
            {
                // KeyList設定
                string[] noteGuidHdKeys = new string[1];
                noteGuidHdKeys[0] = LoginInfoAcquisition.EnterpriseCode;

                ArrayList noteGuidHdWorkList = new ArrayList();
                foreach (NoteGuidHd noteGuidHd in _noteGdHdTable_Stc.Values)
                {
                    // クラス ⇒ ワーカークラス
                    noteGuidHdWorkList.Add(CopyToNoteGuidHdWorkFromNoteGuidHd(noteGuidHd));
                }

                status = offlineDataSerializer.Serialize(this.ToString(), noteGuidHdKeys, noteGuidHdWorkList);
            }

            return status;
        }

        /// <summary>
        /// 備考ガイド（ヘッダ）テーブル読み込み処理
        /// </summary>
        /// <param name="noteGuidHd">備考ガイド（ヘッダ）オブジェクト</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="noteGuideDivCode">備考ガイド区分</param>
        /// <returns>備考ガイド（ヘッダ）クラス</returns>
        /// <remarks>
        /// <br>Note       : 備考ガイド（ヘッダ）テーブルのRead処理です。</br>
        /// <br>Programmer : 三崎 貴史</br>
        /// <br>Date       : 2005.10.14</br>
        /// -----------------------------------------------------------------------
        /// <br>UpdateNote : 2008.02.08 96012　日色 馨</br>
        /// <br>           : ローカルＤＢ参照対応</br>
        /// </remarks>
        public int Read(out NoteGuidHd noteGuidHd, string enterpriseCode, int noteGuideDivCode)
        {
            try
            {
                int status = 0;

                // オンライン時はリモート取得
                // -- DEL 2010/05/25 ---------------------->>>
                //if (LoginInfoAcquisition.OnlineFlag)
                //{
                // -- DEL 2010/05/25 ----------------------<<<
                    noteGuidHd = null;
                    NoteGuidHdWork noteGuidHdWork = new NoteGuidHdWork();
                    noteGuidHdWork.EnterpriseCode = enterpriseCode;
                    noteGuidHdWork.NoteGuideDivCode = noteGuideDivCode;

                    // 2008.02.08 96012 ローカルＤＢ参照対応 Begin
                    //// XMLへ変換し、文字列のバイナリ化
                    //byte[] parabyte = XmlByteSerializer.Serialize(noteGuidHdWork);
                    //
                    //// 備考マスタ読み込み(ローカルDB)
                    //status = this._iNoteGuidBdDB.ReadHeader(ref parabyte, 0);
                    //
                    //if (status == 0)
                    //{
                    //    // XMLの読み込み 
                    //    noteGuidHdWork = (NoteGuidHdWork)XmlByteSerializer.Deserialize(parabyte, typeof(NoteGuidHdWork));
                    //    // クラス内メンバコピー
                    //    noteGuidHd = CopyToNoteGuidHdFromNoteGuidHdWork(noteGuidHdWork);
                    //}
                    if (_isLocalDBRead)
                    {
                        // 備考マスタ読み込み(ローカルDB) 
                        status = this._noteGuidBdLcDB.ReadHeader(ref noteGuidHdWork, 0);
                        if (status == 0)
                        {
                            // クラス内メンバコピー
                            noteGuidHd = CopyToNoteGuidHdFromNoteGuidHdWork(noteGuidHdWork);
                        }
                    }
                    else
                    {
                        // XMLへ変換し、文字列のバイナリ化
                        byte[] parabyte = XmlByteSerializer.Serialize(noteGuidHdWork);
                        // 備考マスタ読み込み(ローカルDB)
                        status = this._iNoteGuidBdDB.ReadHeader(ref parabyte, 0);
                        if (status == 0)
                        {
                            // XMLの読み込み 
                            noteGuidHdWork = (NoteGuidHdWork)XmlByteSerializer.Deserialize(parabyte, typeof(NoteGuidHdWork));
                            // クラス内メンバコピー
                            noteGuidHd = CopyToNoteGuidHdFromNoteGuidHdWork(noteGuidHdWork);
                        }
                    }
                    // 2008.02.08 96012 ローカルＤＢ参照対応 end
                // -- DEL 2010/05/25 ---------------------->>>
                //}
                //else	// オフライン時はキャッシュから取得
                //{
                //    status = ReadStaticMemory(out noteGuidHd, noteGuideDivCode);
                //}
                // -- DEL 2010/05/25 ----------------------<<<

                return status;
            }
            catch (Exception)
            {
                //通信エラーは-1を戻す
                noteGuidHd = null;
                //オフライン時はnullをセット
                this._iNoteGuidBdDB = null;
                return -1;
            }
        }

        #region [削除]
        // 2007.10.04 sasaki >>
		/*
        /// <summary>
        /// 備考ガイド（ヘッダ）テーブルローカルDB読み込み処理
        /// </summary>
        /// <param name="noteGuidHd">備考ガイド（ヘッダ）オブジェクト</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="noteGuideDivCode">備考ガイド区分</param>
        /// <returns>備考ガイド（ヘッダ）クラス</returns>
        /// <remarks>
        /// <br>Note       : 備考ガイド（ヘッダ）テーブルのローカルDB Read処理です。</br>
        /// <br>Programmer : 飯谷 耕平</br>
        /// <br>Date       : 2007.04.09</br>
        /// </remarks>
        public int ReadLocalDB(out NoteGuidHd noteGuidHd, string enterpriseCode, int noteGuideDivCode)
        {
            try
            {
                int status = 0;

                // オンライン時はリモート取得
                if (LoginInfoAcquisition.OnlineFlag)
                {
                    noteGuidHd = null;
                    NoteGuidHdWork noteGuidHdWork = new NoteGuidHdWork();
                    noteGuidHdWork.EnterpriseCode = enterpriseCode;
                    noteGuidHdWork.NoteGuideDivCode = noteGuideDivCode;

                    // 備考マスタ読み込み(ローカルDB) 
                    status = this._noteGuidBdLcDB.ReadHeader(ref noteGuidHdWork, 0);

                    if (status == 0)
                    {
                        // クラス内メンバコピー
                        noteGuidHd = CopyToNoteGuidHdFromNoteGuidHdWork(noteGuidHdWork);
                    }
                }
                else	// オフライン時はキャッシュから取得
                {
                    status = ReadStaticMemory(out noteGuidHd, noteGuideDivCode);
                }

                return status;
            }
            catch (Exception)
            {
                //通信エラーは-1を戻す
                noteGuidHd = null;
                //オフライン時はnullをセット
                this._iNoteGuidBdDB = null;
                return -1;
            }
        }
		*/
        // 2007.10.04 sasaki <<
        #endregion

        /// <summary>
        /// 備考ガイド（ボディ）テーブル読み込み処理
        /// </summary>
        /// <param name="noteGuidBd">備考ガイド（ボディ）オブジェクト</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="noteGuideDivCode">備考ガイド区分</param>
        /// <param name="noteGuideCode">備考ガイドコード</param>
        /// <returns>備考ガイド（ボディ）クラス</returns>
        /// <remarks>
        /// <br>Note       : 備考ガイド（ボディ）テーブルのRead処理です。</br>
        /// <br>Programmer : 三崎 貴史</br>
        /// <br>Date       : 2005.10.14</br>
        /// -----------------------------------------------------------------------
        /// <br>UpdateNote : 2008.02.08 96012　日色 馨</br>
        /// <br>           : ローカルＤＢ参照対応</br>
        /// </remarks>
        public int Read(out NoteGuidBd noteGuidBd, string enterpriseCode, int noteGuideDivCode, int noteGuideCode)
        {
            try
            {
                noteGuidBd = null;
                NoteGuidBdWork noteGuidBdWork = new NoteGuidBdWork();
                noteGuidBdWork.EnterpriseCode = enterpriseCode;
                noteGuidBdWork.NoteGuideDivCode = noteGuideDivCode;
                noteGuidBdWork.NoteGuideCode = noteGuideCode;

                // 2008.02.08 96012 ローカルＤＢ参照対応 Begin
                //// XMLへ変換し、文字列のバイナリ化
                //byte[] parabyte = XmlByteSerializer.Serialize(noteGuidBdWork);
                //
                //int status = this._iNoteGuidBdDB.ReadBody(ref parabyte, 0);
                //
                //if (status == 0)
                //{
                //    // XMLの読み込み
                //    noteGuidBdWork = (NoteGuidBdWork)XmlByteSerializer.Deserialize(parabyte, typeof(NoteGuidBdWork));
                //    // クラス内メンバコピー
                //    noteGuidBd = CopyToNoteGuidBdFromNoteGuidBdWork(noteGuidBdWork);
                //}
                int status = 0;
                if (_isLocalDBRead)
                {
                    // ローカルDBからの読込
                    status = this._noteGuidBdLcDB.ReadBody(ref noteGuidBdWork, 0);
                    if (status == 0)
                    {
                        // クラス内メンバコピー
                        noteGuidBd = CopyToNoteGuidBdFromNoteGuidBdWork(noteGuidBdWork);
                    }
                }
                else
                {
                    // XMLへ変換し、文字列のバイナリ化
                    byte[] parabyte = XmlByteSerializer.Serialize(noteGuidBdWork);
                    status = this._iNoteGuidBdDB.ReadBody(ref parabyte, 0);
                    if (status == 0)
                    {
                        // XMLの読み込み
                        noteGuidBdWork = (NoteGuidBdWork)XmlByteSerializer.Deserialize(parabyte, typeof(NoteGuidBdWork));
                        // クラス内メンバコピー
                        noteGuidBd = CopyToNoteGuidBdFromNoteGuidBdWork(noteGuidBdWork);
                    }
                }
                // 2008.02.08 96012 ローカルＤＢ参照対応 end
                return status;
            }
            catch (Exception)
            {
                //通信エラーは-1を戻す
                noteGuidBd = null;
                //オフライン時はnullをセット
                this._iNoteGuidBdDB = null;
                return -1;
            }
        }

		// 2007.10.04 sasaki >>
		/*
        /// <summary>
        /// 備考ガイド（ボディ）テーブルローカルDB読み込み処理
        /// </summary>
        /// <param name="noteGuidBd">備考ガイド（ボディ）オブジェクト</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="noteGuideDivCode">備考ガイド区分</param>
        /// <param name="noteGuideCode">備考ガイドコード</param>
        /// <returns>備考ガイド（ボディ）クラス</returns>
        /// <remarks>
        /// <br>Note       : 備考ガイド（ボディ）テーブルのローカルDB Read処理です。</br>
        /// <br>Programmer : 飯谷 耕平</br>
        /// <br>Date       : 2007.04.09</br>
        /// </remarks>
        public int ReadLocalDB(out NoteGuidBd noteGuidBd, string enterpriseCode, int noteGuideDivCode, int noteGuideCode)
        {
            try
            {
                noteGuidBd = null;
                NoteGuidBdWork noteGuidBdWork = new NoteGuidBdWork();
                noteGuidBdWork.EnterpriseCode = enterpriseCode;
                noteGuidBdWork.NoteGuideDivCode = noteGuideDivCode;
                noteGuidBdWork.NoteGuideCode = noteGuideCode;

                // ローカルDBからの読込
                int status = this._noteGuidBdLcDB.ReadBody(ref noteGuidBdWork, 0);

                if (status == 0)
                {
                    // クラス内メンバコピー
                    noteGuidBd = CopyToNoteGuidBdFromNoteGuidBdWork(noteGuidBdWork);
                }
                return status;
            }
            catch (Exception)
            {
                //通信エラーは-1を戻す
                noteGuidBd = null;
                //オフライン時はnullをセット
                this._iNoteGuidBdDB = null;
                return -1;
            }
        }
		*/
		// 2007.10.04 sasaki <<

        /// <summary>
        /// 備考ガイド（ヘッダ）テーブル登録・更新処理
        /// </summary>
        /// <param name="noteGuidHd">備考ガイド（ヘッダ）クラス</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 備考ガイド（ヘッダ）テーブルの登録・更新を行います。</br>
        /// <br>Programmer : 三崎 貴史</br>
        /// <br>Date       : 2005.10.14</br>
        /// </remarks>
        public int Write(ref NoteGuidHd noteGuidHd)
        {
            //クラスからワーカークラスにメンバコピー
            NoteGuidHdWork noteGuidHdWork = CopyToNoteGuidHdWorkFromNoteGuidHd(noteGuidHd);

            // XMLへ変換し、文字列のバイナリ化
            byte[] parabyte = XmlByteSerializer.Serialize(noteGuidHdWork);

            int status = 0;

            try
            {
                //書き込み
                status = this._iNoteGuidBdDB.WriteHeader(ref parabyte);

                if (status == 0)
                {
                    // ファイル名を渡してワーククラスをデシリアライズする
                    noteGuidHdWork = (NoteGuidHdWork)XmlByteSerializer.Deserialize(parabyte, typeof(NoteGuidHdWork));
                    // クラス内メンバコピー
                    noteGuidHd = CopyToNoteGuidHdFromNoteGuidHdWork(noteGuidHdWork);
                }
            }
            catch (Exception)
            {
                // オフライン時はnullをセット
                this._iNoteGuidBdDB = null;
                // 通信エラーは-1を戻す
                status = -1;
            }

            return status;
        }

        /// <summary>
        /// 備考ガイド（ボディ）テーブル登録・更新処理
        /// </summary>
        /// <param name="noteGuidBd">備考ガイド（ボディ）クラス</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 備考ガイド（ボディ）テーブルの登録・更新を行います。</br>
        /// <br>Programmer : 三崎 貴史</br>
        /// <br>Date       : 2005.10.14</br>
        /// </remarks>
        public int Write(ref NoteGuidBd noteGuidBd)
        {
            //クラスからワーカークラスにメンバコピー
            NoteGuidBdWork noteGuidBdWork = CopyToNoteGuidBdWorkFromNoteGuidBd(noteGuidBd);

            // XMLへ変換し、文字列のバイナリ化
            byte[] parabyte = XmlByteSerializer.Serialize(noteGuidBdWork);

            int status = 0;

            try
            {
                //書き込み
                status = this._iNoteGuidBdDB.WriteBody(ref parabyte);

                if (status == 0)
                {
                    // ファイル名を渡してワーククラスをデシリアライズする
                    noteGuidBdWork = (NoteGuidBdWork)XmlByteSerializer.Deserialize(parabyte, typeof(NoteGuidBdWork));
                    // クラス内メンバコピー
                    noteGuidBd = CopyToNoteGuidBdFromNoteGuidBdWork(noteGuidBdWork);
                }
            }
            catch (Exception)
            {
                // オフライン時はnullをセット
                this._iNoteGuidBdDB = null;
                // 通信エラーは-1を戻す
                status = -1;
            }

            return status;
        }

        /// <summary>
        /// 備考ガイド（ヘッダ）テーブル論理削除処理
        /// </summary>
        /// <param name="noteGuidHd">備考ガイド（ヘッダ）クラス</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 備考ガイド（ヘッダ）の論理削除を行います。</br>
        /// <br>Programmer : 三崎 貴史</br>
        /// <br>Date       : 2005.10.14</br>
        /// </remarks>
        public int LogicalDelete(ref NoteGuidHd noteGuidHd)
        {
            try
            {
                NoteGuidHdWork noteGuidHdWork = new NoteGuidHdWork();

                noteGuidHdWork = CopyToNoteGuidHdWorkFromNoteGuidHd(noteGuidHd);

                // XMLへ変換し、文字列のバイナリ化
                byte[] parabyte = XmlByteSerializer.Serialize(noteGuidHdWork);
                // 論理削除
                int status = this._iNoteGuidBdDB.LogicalDeleteHeader(ref parabyte);

                if (status == 0)
                {
                    // ファイル名を渡してワーククラスをデシリアライズ
                    noteGuidHdWork = (NoteGuidHdWork)XmlByteSerializer.Deserialize(parabyte, typeof(NoteGuidHdWork));

                    // クラス内でメンバコピー
                    noteGuidHd = CopyToNoteGuidHdFromNoteGuidHdWork(noteGuidHdWork);
                }
                return status;
            }
            catch (Exception)
            {
                //オフライン時はnullをセット
                this._iNoteGuidBdDB = null;
                //通信エラーは-1を戻す
                return -1;
            }
        }

        /// <summary>
        /// 備考ガイド（ボディ）テーブル論理削除処理
        /// </summary>
        /// <param name="noteGuidBd">備考ガイド（ボディ）クラス</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 備考ガイド（ボディ）の論理削除を行います。</br>
        /// <br>Programmer : 三崎 貴史</br>
        /// <br>Date       : 2005.10.14</br>
        /// </remarks>
        public int LogicalDelete(ref NoteGuidBd noteGuidBd)
        {
            try
            {
                NoteGuidBdWork noteGuidBdWork = new NoteGuidBdWork();

                noteGuidBdWork = CopyToNoteGuidBdWorkFromNoteGuidBd(noteGuidBd);

                // XMLへ変換し、文字列のバイナリ化
                byte[] parabyte = XmlByteSerializer.Serialize(noteGuidBdWork);
                // 論理削除
                int status = this._iNoteGuidBdDB.LogicalDeleteBody(ref parabyte);

                if (status == 0)
                {
                    // ファイル名を渡してワーククラスをデシリアライズ
                    noteGuidBdWork = (NoteGuidBdWork)XmlByteSerializer.Deserialize(parabyte, typeof(NoteGuidBdWork));

                    // クラス内でメンバコピー
                    noteGuidBd = CopyToNoteGuidBdFromNoteGuidBdWork(noteGuidBdWork);
                }
                return status;
            }
            catch (Exception)
            {
                //オフライン時はnullをセット
                this._iNoteGuidBdDB = null;
                //通信エラーは-1を戻す
                return -1;
            }
        }

        /// <summary>
        /// 備考ガイド（ヘッダ）テーブル物理削除処理
        /// </summary>
        /// <param name="noteGuidHd">備考ガイド（ヘッダ）クラス</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 備考ガイド（ヘッダ）の物理削除を行います。</br>
        /// <br>Programmer : 三崎 貴史</br>
        /// <br>Date       : 2005.10.14</br>
        /// </remarks>
        public int Delete(NoteGuidHd noteGuidHd)
        {
            try
            {
                NoteGuidHdWork noteGuidHdWork = new NoteGuidHdWork();

                noteGuidHdWork = CopyToNoteGuidHdWorkFromNoteGuidHd(noteGuidHd);

                // XMLに変換し文字列のバイナリ化
                byte[] parabyte = XmlByteSerializer.Serialize(noteGuidHdWork);
                // 物理削除
                int status = this._iNoteGuidBdDB.DeleteHeader(parabyte);

                return status;
            }
            catch (Exception)
            {
                //オフライン時はnullをセット
                this._iNoteGuidBdDB = null;

                //通信エラーは-1を戻す
                return -1;
            }
        }

        /// <summary>
        /// 備考ガイド（ボディ）テーブル物理削除処理
        /// </summary>
        /// <param name="noteGuidBd">備考ガイド（ボディ）クラス</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 備考ガイド（ボディ）の物理削除を行います。</br>
        /// <br>Programmer : 三崎 貴史</br>
        /// <br>Date       : 2005.10.14</br>
        /// </remarks>
        public int Delete(NoteGuidBd noteGuidBd)
        {
            try
            {
                NoteGuidBdWork noteGuidBdWork = new NoteGuidBdWork();

                noteGuidBdWork = CopyToNoteGuidBdWorkFromNoteGuidBd(noteGuidBd);

                // XMLに変換し文字列のバイナリ化
                byte[] parabyte = XmlByteSerializer.Serialize(noteGuidBdWork);
                // 物理削除
                int status = this._iNoteGuidBdDB.DeleteBody(parabyte);

                return status;
            }
            catch (Exception)
            {
                //オフライン時はnullをセット
                this._iNoteGuidBdDB = null;

                //通信エラーは-1を戻す
                return -1;
            }
        }

        /// <summary>
        /// 備考ガイド（ヘッダ）テーブル検索処理（論理削除除く）
        /// </summary>
        /// <param name="retList">読込結果コレクション</param>
        /// <param name="enterpriseCode">企業コード</param>		
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 備考ガイド（ヘッダ）の全検索処理を行います。論理削除データは抽出対象外となります。</br>
        /// <br>Programmer : 三崎 貴史</br>
        /// <br>Date       : 2005.10.14</br>
        /// </remarks>
        public int SearchHeader(out ArrayList retList, string enterpriseCode)
        {
            return SearchNoteGuidHdProc(out retList, enterpriseCode, 0);
        }

        /// <summary>
        /// 備考ガイド（ボディ）テーブル検索処理（論理削除除く）
        /// </summary>
        /// <param name="retList">読込結果コレクション</param>
        /// <param name="enterpriseCode">企業コード</param>		
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 備考ガイド（ボディ）の全検索処理を行います。論理削除データは抽出対象外となります。</br>
        /// <br>Programmer : 三崎 貴史</br>
        /// <br>Date       : 2005.10.14</br>
        /// </remarks>
        public int SearchBody(out ArrayList retList, string enterpriseCode)
        {
            return SearchNoteGuidBdProc(out retList, enterpriseCode, 0);
        }

        /// <summary>
        /// 備考ガイド（ヘッダ）テーブル全検索処理（論理削除含む）
        /// </summary>
        /// <param name="retList">読込結果コレクション</param>
        /// <param name="enterpriseCode">企業コード</param>		
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 備考ガイド（ヘッダ）の全検索処理を行います。論理削除データも抽出対象となります。</br>
        /// <br>Programmer : 三崎 貴史</br>
        /// <br>Date       : 2005.10.14</br>
        /// </remarks>
        public int SearchAllHeader(out ArrayList retList, string enterpriseCode)
        {
            return SearchNoteGuidHdProc(out retList, enterpriseCode, ConstantManagement.LogicalMode.GetData01);
        }

        /// <summary>
        /// 備考ガイド（ボディ）テーブル全検索処理（論理削除含む）
        /// </summary>
        /// <param name="retList">読込結果コレクション</param>
        /// <param name="enterpriseCode">企業コード</param>		
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 備考ガイド（ボディ）の全検索処理を行います。論理削除データも抽出対象となります。</br>
        /// <br>Programmer : 三崎 貴史</br>
        /// <br>Date       : 2005.10.14</br>
        /// </remarks>
        public int SearchAllBody(out ArrayList retList, string enterpriseCode)
        {
            return SearchNoteGuidBdProc(out retList, enterpriseCode, ConstantManagement.LogicalMode.GetData01);
        }

        /// <summary>
        /// 備考ガイド（ボディ）テーブル区分指定検索処理（論理削除除く）
        /// </summary>
        /// <param name="retList">読込結果コレクション</param>
        /// <param name="enterpriseCode">企業コード</param>		
        /// <param name="noteGuidDivCode">備考ガイド区分</param>		
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 指定された区分の備考ガイド（ボディ）の検索処理を行います。
        ///					 論理削除データは抽出対象外となります。</br>
        /// <br>Programmer : 三崎 貴史</br>
        /// <br>Date       : 2005.10.14</br>
        /// -----------------------------------------------------------------------
        /// <br>UpdateNote : 2008.02.08 96012　日色 馨</br>
        /// <br>           : ローカルＤＢ参照対応</br>
        /// </remarks>
        public int SearchDivCodeBody(out ArrayList retList, string enterpriseCode, int noteGuidDivCode)
        {
            NoteGuidBdWork noteGuidBdWork = new NoteGuidBdWork();
            noteGuidBdWork.EnterpriseCode = enterpriseCode;
            noteGuidBdWork.NoteGuideDivCode = noteGuidDivCode;

            retList = new ArrayList();
            retList.Clear();

            object paraObj = noteGuidBdWork as Object;
            object retObj;

            // 2008.02.08 96012 ローカルＤＢ参照対応 Begin
            //// 備考ガイド（ボディ）検索
            //int status = this._iNoteGuidBdDB.SearchGuideDivCode(out retObj, paraObj, 0, ConstantManagement.LogicalMode.GetData01);
            //
            //if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            //{
            //    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            //    {
            //        ArrayList noteGuidBdWorkList = retObj as ArrayList;
            //
            //        for (int i = 0; i < noteGuidBdWorkList.Count; i++)
            //        {
            //            // クラス内メンバコピー
            //            retList.Add(CopyToNoteGuidBdFromNoteGuidBdWork((NoteGuidBdWork)noteGuidBdWorkList[i]));
            //        }
            //
            //        if (retList.Count == 0)
            //        {
            //            status = 9;
            //        }
            //    }
            //}
            int status = 0;
            if (_isLocalDBRead)
            {
                // 備考ガイド（ボディ）検索
                List<NoteGuidBdWork> workList = new List<NoteGuidBdWork>();
                List<NoteGuidBdWork> paraList = new List<NoteGuidBdWork>();
                paraList.Add(noteGuidBdWork);
                status = this._noteGuidBdLcDB.SearchGuideDivCode(out workList, paraList, 0, ConstantManagement.LogicalMode.GetData01);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        if (workList.Count == 0)
                        {
                            status = 9;
                        }
                    }
                }
            }
            else
            {
                // 備考ガイド（ボディ）検索
                status = this._iNoteGuidBdDB.SearchGuideDivCode(out retObj, paraObj, 0, ConstantManagement.LogicalMode.GetData01);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        ArrayList noteGuidBdWorkList = retObj as ArrayList;
                        for (int i = 0; i < noteGuidBdWorkList.Count; i++)
                        {
                            // クラス内メンバコピー
                            retList.Add(CopyToNoteGuidBdFromNoteGuidBdWork((NoteGuidBdWork)noteGuidBdWorkList[i]));
                        }
                        if (retList.Count == 0)
                        {
                            status = 9;
                        }
                    }
                }
            }
            // 2008.02.08 96012 ローカルＤＢ参照対応 end
            return status;
        }

        /// <summary>
        /// 備考ガイド（ヘッダ）テーブル論理削除復活処理
        /// </summary>
        /// <param name="noteGuidHd">備考ガイド（ヘッダ）オブジェクト</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 備考ガイド（ヘッダ）の復活を行います。</br>
        /// <br>Programmer : 三崎 貴史</br>
        /// <br>Date       : 2005.10.14</br>
        /// </remarks>
        public int Revival(ref NoteGuidHd noteGuidHd)
        {
            try
            {
                NoteGuidHdWork noteGuidHdWork = new NoteGuidHdWork();

                noteGuidHdWork = CopyToNoteGuidHdWorkFromNoteGuidHd(noteGuidHd);

                // XMLへ変換し文字列のバイナリ化
                byte[] parabyte = XmlByteSerializer.Serialize(noteGuidHdWork);
                // 復活処理
                int status = this._iNoteGuidBdDB.RevivalLogicalDeleteHeader(ref parabyte);

                if (status == 0)
                {
                    // ファイル名を渡してワーククラスをデシリアライズ
                    noteGuidHdWork = (NoteGuidHdWork)XmlByteSerializer.Deserialize(parabyte, typeof(NoteGuidHdWork));
                    // クラス内メンバコピー
                    noteGuidHd = CopyToNoteGuidHdFromNoteGuidHdWork(noteGuidHdWork);
                }
                return status;
            }
            catch (Exception)
            {
                //オフライン時はnullをセット
                this._iNoteGuidBdDB = null;
                //通信エラーは-1を戻す
                return -1;
            }
        }

        /// <summary>
        /// 備考ガイド（ボディ）テーブル論理削除復活処理
        /// </summary>
        /// <param name="noteGuidBd">備考ガイド（ボディ）オブジェクト</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 備考ガイド（ボディ）の復活を行います。</br>
        /// <br>Programmer : 三崎 貴史</br>
        /// <br>Date       : 2005.10.14</br>
        /// </remarks>
        public int Revival(ref NoteGuidBd noteGuidBd)
        {
            try
            {
                NoteGuidBdWork noteGuidBdWork = new NoteGuidBdWork();

                noteGuidBdWork = CopyToNoteGuidBdWorkFromNoteGuidBd(noteGuidBd);

                // XMLへ変換し文字列のバイナリ化
                byte[] parabyte = XmlByteSerializer.Serialize(noteGuidBdWork);
                // 復活処理
                int status = this._iNoteGuidBdDB.RevivalLogicalDeleteBody(ref parabyte);

                if (status == 0)
                {
                    // ファイル名を渡してワーククラスをデシリアライズ
                    noteGuidBdWork = (NoteGuidBdWork)XmlByteSerializer.Deserialize(parabyte, typeof(NoteGuidBdWork));
                    // クラス内メンバコピー
                    noteGuidBd = CopyToNoteGuidBdFromNoteGuidBdWork(noteGuidBdWork);
                }
                return status;
            }
            catch (Exception)
            {
                //オフライン時はnullをセット
                this._iNoteGuidBdDB = null;
                //通信エラーは-1を戻す
                return -1;
            }
        }

        /// <summary>
        /// 備考ガイド（ヘッダ）テーブル検索処理
        /// </summary>
        /// <param name="retList">読込結果コレクション</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="logicalMode">論理削除有無(0:正規データのみ 1:削除データのみ 2:全データ)</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 備考ガイド（ヘッダ）の検索処理を行います。</br>
        /// <br>Programmer : 三崎 貴史</br>
        /// <br>Date       : 2005.10.14</br>
        /// -----------------------------------------------------------------------
        /// <br>UpdateNote : 2008.02.08 96012　日色 馨</br>
        /// <br>           : ローカルＤＢ参照対応</br>
        /// </remarks>
        private int SearchNoteGuidHdProc(out ArrayList retList, string enterpriseCode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = 0;
            NoteGuidHdWork noteGuidHdWork = new NoteGuidHdWork();
            noteGuidHdWork.EnterpriseCode = enterpriseCode;

            retList = new ArrayList();
            retList.Clear();

            // 2008.02.08 96012 ローカルＤＢ参照対応 Begin
            //// オンライン時はリモート取得
            //if (LoginInfoAcquisition.OnlineFlag)
            //{
            //    object paraObj = noteGuidHdWork as Object;
            //    object retObj;
            //
            //    // 備考ガイド（ヘッダ）検索
            //    status = this._iNoteGuidBdDB.SearchHeader(out retObj, paraObj, 0, logicalMode);
            //
            //    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            //    {
            //        ArrayList noteGuidHdWorkList = retObj as ArrayList;
            //
            //        for (int i = 0; i < noteGuidHdWorkList.Count; i++)
            //        {
            //            // クラス内メンバコピー
            //            retList.Add(CopyToNoteGuidHdFromNoteGuidHdWork((NoteGuidHdWork)noteGuidHdWorkList[i]));
            //            // 備考ガイド（ヘッダ）クラス ⇒ Static転記処理
            //            CopyToStaticFromDataClass(CopyToNoteGuidHdFromNoteGuidHdWork((NoteGuidHdWork)noteGuidHdWorkList[i]));
            //        }
            //    }
            //}
            //else
            //{
            //    status = this.SearchStaticMemory(out retList);
            //}
            if (_isLocalDBRead)
            {
                NoteGuidHdWork paraObj = noteGuidHdWork;
                // 備考ガイド（ヘッダ）検索
                List<NoteGuidHdWork> workList = new List<NoteGuidHdWork>();
                status = this._noteGuidBdLcDB.SearchHeader(out workList, noteGuidHdWork, 0, logicalMode);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    for (int i = 0; i < workList.Count; i++)
                    {
                        // クラス内メンバコピー
                        retList.Add(CopyToNoteGuidHdFromNoteGuidHdWork(workList[i]));
                        // 備考ガイド（ヘッダ）クラス ⇒ Static転記処理
                        CopyToStaticFromDataClass(CopyToNoteGuidHdFromNoteGuidHdWork(workList[i]));
                    }
                }
            }
            else
            {
                // -- DEL 2010/05/25 ------------------->>>
                // オンライン時はリモート取得
                //if (LoginInfoAcquisition.OnlineFlag)
                //{
                // -- DEL 2010/05/25 ------------------->>>
                    object paraObj = noteGuidHdWork as Object;
                    object retObj;

                    // 備考ガイド（ヘッダ）検索
                    status = this._iNoteGuidBdDB.SearchHeader(out retObj, paraObj, 0, logicalMode);

                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        ArrayList noteGuidHdWorkList = retObj as ArrayList;

                        for (int i = 0; i < noteGuidHdWorkList.Count; i++)
                        {
                            // クラス内メンバコピー
                            retList.Add(CopyToNoteGuidHdFromNoteGuidHdWork((NoteGuidHdWork)noteGuidHdWorkList[i]));
                            // 備考ガイド（ヘッダ）クラス ⇒ Static転記処理
                            CopyToStaticFromDataClass(CopyToNoteGuidHdFromNoteGuidHdWork((NoteGuidHdWork)noteGuidHdWorkList[i]));
                        }
                    }
                // -- DEL 2010/05/25 ------------------->>>
                //}
                //else
                //{
                //    status = this.SearchStaticMemory(out retList);
                //}
                // -- DEL 2010/05/25 ------------------->>>
            }
            // 2008.02.08 96012 ローカルＤＢ参照対応 end

            return status;
        }

        /// <summary>
        /// 備考ガイド（ボディ）テーブル検索処理
        /// </summary>
        /// <param name="retList">読込結果コレクション</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="logicalMode">論理削除有無(0:正規データのみ 1:削除データのみ 2:全データ)</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 備考ガイド（ボディ）の検索処理を行います。</br>
        /// <br>Programmer : 三崎 貴史</br>
        /// <br>Date       : 2005.10.14</br>
        /// -----------------------------------------------------------------------
        /// <br>UpdateNote : 2008.02.08 96012　日色 馨</br>
        /// <br>           : ローカルＤＢ参照対応</br>
        /// </remarks>
        private int SearchNoteGuidBdProc(out ArrayList retList, string enterpriseCode, ConstantManagement.LogicalMode logicalMode)
        {
            NoteGuidBdWork noteGuidBdWork = new NoteGuidBdWork();
            noteGuidBdWork.EnterpriseCode = enterpriseCode;

            retList = new ArrayList();
            retList.Clear();

            // 2008.02.08 96012 ローカルＤＢ参照対応 Begin
            //object paraObj = noteGuidBdWork as Object;
            //object retObj;
            //
            //// 備考ガイド（ボディ）検索
            //int status = this._iNoteGuidBdDB.SearchBody(out retObj, paraObj, 0, logicalMode);
            //
            //if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            //{
            //    ArrayList noteGuidBdWorkList = retObj as ArrayList;
            //
            //    for (int i = 0; i < noteGuidBdWorkList.Count; i++)
            //    {
            //        // クラス内メンバコピー
            //        retList.Add(CopyToNoteGuidBdFromNoteGuidBdWork((NoteGuidBdWork)noteGuidBdWorkList[i]));
            //    }
            //}
            int status = 0;
            if (_isLocalDBRead)
            {
                // 備考ガイド（ボディ）検索
                List<NoteGuidBdWork> workList = new List<NoteGuidBdWork>();
                status = this._noteGuidBdLcDB.SearchBody(out workList, noteGuidBdWork, 0, logicalMode);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    for (int i = 0; i < workList.Count; i++)
                    {
                        // クラス内メンバコピー
                        retList.Add(CopyToNoteGuidBdFromNoteGuidBdWork(workList[i]));
                    }
                }
            }
            else
            {
                object paraObj = noteGuidBdWork as Object;
                object retObj;
                // 備考ガイド（ボディ）検索
                status = this._iNoteGuidBdDB.SearchBody(out retObj, paraObj, 0, logicalMode);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    ArrayList noteGuidBdWorkList = retObj as ArrayList;
                    for (int i = 0; i < noteGuidBdWorkList.Count; i++)
                    {
                        // クラス内メンバコピー
                        retList.Add(CopyToNoteGuidBdFromNoteGuidBdWork((NoteGuidBdWork)noteGuidBdWorkList[i]));
                    }
                }
            }
            // 2008.02.08 96012 ローカルＤＢ参照対応 end
            return status;
        }

        /// <summary>
        /// 備考ガイド（ヘッダ）テーブル検索処理（DataSet用）
        /// </summary>
        /// <param name="ds">取得結果格納用DataSet</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 備考ガイド（ヘッダ）の検索処理を行い、取得結果をDataSetで返します。</br>
        /// <br>Programmer : 三崎 貴史</br>
        /// <br>Date       : 2005.10.14</br>
        /// -----------------------------------------------------------------------
        /// <br>UpdateNote : 2008.02.08 96012　日色 馨</br>
        /// <br>           : ローカルＤＢ参照対応</br>
        /// </remarks>
        public int SearchHeaderDS(ref DataSet ds, string enterpriseCode)
        {
            NoteGuidHdWork noteGuidHdWork = new NoteGuidHdWork();
            noteGuidHdWork.EnterpriseCode = enterpriseCode;

            // サーチ用リスト初期化
            ArrayList paraList = new ArrayList();
            paraList.Clear();

            object paraobj = noteGuidHdWork;
            object retobj = null;

            // 2008.02.08 96012 ローカルＤＢ参照対応 Begin
            //// 車販ガイドマスタ（ヘッダ）検索
            //int status = this._iNoteGuidBdDB.SearchHeader(out retobj, paraobj, 0, 0);
            //
            //if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            //{
            //    paraList = retobj as ArrayList;
            //
            //    NoteGuidHdWork[] Byte_noteGuidHdWork = new NoteGuidHdWork[paraList.Count];
            //    for (int ix = 0; ix < paraList.Count; ix++)
            //    {
            //        Byte_noteGuidHdWork[ix] = (NoteGuidHdWork)paraList[ix];
            //    }
            //
            //    // XMLへ変換し、文字列のバイナリ化
            //    byte[] retbyte = XmlByteSerializer.Serialize(Byte_noteGuidHdWork);
            //    XmlByteSerializer.ReadXml(ref ds, retbyte);
            //}
            int status = 0;
            if (_isLocalDBRead)
            {
                NoteGuidHdWork paraObj = noteGuidHdWork;
                // 備考ガイド（ヘッダ）検索
                List<NoteGuidHdWork> workList = new List<NoteGuidHdWork>();
                workList.Clear();
                status = this._noteGuidBdLcDB.SearchHeader(out workList, paraObj, 0, 0);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    NoteGuidHdWork[] Byte_noteGuidHdWork = new NoteGuidHdWork[workList.Count];
                    for (int ix = 0; ix < workList.Count; ix++)
                    {
                        Byte_noteGuidHdWork[ix] = (NoteGuidHdWork)workList[ix];
                    }
                    // XMLへ変換し、文字列のバイナリ化
                    byte[] retbyte = XmlByteSerializer.Serialize(Byte_noteGuidHdWork);
                    XmlByteSerializer.ReadXml(ref ds, retbyte);
                }
            }
            else
            {
                // 車販ガイドマスタ（ヘッダ）検索
                status = this._iNoteGuidBdDB.SearchHeader(out retobj, paraobj, 0, 0);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    paraList = retobj as ArrayList;
                    NoteGuidHdWork[] Byte_noteGuidHdWork = new NoteGuidHdWork[paraList.Count];
                    for (int ix = 0; ix < paraList.Count; ix++)
                    {
                        Byte_noteGuidHdWork[ix] = (NoteGuidHdWork)paraList[ix];
                    }
                    // XMLへ変換し、文字列のバイナリ化
                    byte[] retbyte = XmlByteSerializer.Serialize(Byte_noteGuidHdWork);
                    XmlByteSerializer.ReadXml(ref ds, retbyte);
                }
            }
            // 2008.02.08 96012 ローカルＤＢ参照対応 end
            return status;
        }

        /// <summary>
        /// 備考ガイド（ボディ）テーブル検索処理（DataSet用）
        /// </summary>
        /// <param name="ds">取得結果格納用DataSet</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 備考ガイド（ボディ）の検索処理を行い、取得結果をDataSetで返します。</br>
        /// <br>Programmer : 三崎 貴史</br>
        /// <br>Date       : 2005.10.14</br>
        /// -----------------------------------------------------------------------
        /// <br>UpdateNote : 2008.02.08 96012　日色 馨</br>
        /// <br>           : ローカルＤＢ参照対応</br>
        /// </remarks>
        public int SearchBodyDS(ref DataSet ds, string enterpriseCode)
        {
            NoteGuidBdWork noteGuidBdWork = new NoteGuidBdWork();
            noteGuidBdWork.EnterpriseCode = enterpriseCode;

            // サーチ用リスト初期化
            ArrayList paraList = new ArrayList();
            paraList.Clear();

            object paraobj = noteGuidBdWork;
            object retobj = null;

            // 2008.02.08 96012 ローカルＤＢ参照対応 Begin
            //// 車販ガイドマスタ（ヘッダ）検索
            //int status = this._iNoteGuidBdDB.SearchBody(out retobj, paraobj, 0, 0);
            //
            //if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            //{
            //    paraList = retobj as ArrayList;
            //
            //    NoteGuidBdWork[] Byte_noteGuidBdWork = new NoteGuidBdWork[paraList.Count];
            //    for (int ix = 0; ix < paraList.Count; ix++)
            //    {
            //        Byte_noteGuidBdWork[ix] = (NoteGuidBdWork)paraList[ix];
            //    }
            //
            //    // XMLへ変換し、文字列のバイナリ化
            //    byte[] retbyte = XmlByteSerializer.Serialize(Byte_noteGuidBdWork);
            //    XmlByteSerializer.ReadXml(ref ds, retbyte);
            //}
            int status = 0;
            if (_isLocalDBRead)
            {
                // 備考ガイド（ボディ）検索
                List<NoteGuidBdWork> workList = new List<NoteGuidBdWork>();
                status = this._noteGuidBdLcDB.SearchBody(out workList, noteGuidBdWork, 0, 0);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    NoteGuidBdWork[] Byte_noteGuidBdWork = new NoteGuidBdWork[workList.Count];
                    for (int ix = 0; ix < workList.Count; ix++)
                    {
                        Byte_noteGuidBdWork[ix] = (NoteGuidBdWork)workList[ix];
                    }
                    // XMLへ変換し、文字列のバイナリ化
                    byte[] retbyte = XmlByteSerializer.Serialize(Byte_noteGuidBdWork);
                    XmlByteSerializer.ReadXml(ref ds, retbyte);
                }
            }
            else
            {
                // 車販ガイドマスタ（ヘッダ）検索
                status = this._iNoteGuidBdDB.SearchBody(out retobj, paraobj, 0, 0);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    paraList = retobj as ArrayList;
                    NoteGuidBdWork[] Byte_noteGuidBdWork = new NoteGuidBdWork[paraList.Count];
                    for (int ix = 0; ix < paraList.Count; ix++)
                    {
                        Byte_noteGuidBdWork[ix] = (NoteGuidBdWork)paraList[ix];
                    }
                    // XMLへ変換し、文字列のバイナリ化
                    byte[] retbyte = XmlByteSerializer.Serialize(Byte_noteGuidBdWork);
                    XmlByteSerializer.ReadXml(ref ds, retbyte);
                }
            }
            // 2008.02.08 96012 ローカルＤＢ参照対応 end
            return status;
        }

		// 2007.10.04 sasaki >>
		/*
        /// <summary>
        /// 備考ガイド（ボディ）テーブルローカルDB検索処理（NoteGuidBdWorkリスト用）
        /// </summary>
        /// <param name="noteGuidBdWorkListResult">取得結果格納用NoteGuidBdWorkリスト</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="noteGuideDivCode">備考ガイド区分</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 備考ガイド（ボディ）のローカルDB検索処理を行い、取得結果をDataSetで返します。</br>
        /// <br>Programmer : 木村 武正</br>
        /// <br>Date       : 2007.05.21</br>
        /// </remarks>
        public int SearchBodyLocalDB(out List<NoteGuidBdWork> noteGuidBdWorkListResult, string enterpriseCode, int noteGuideDivCode)
        {
            noteGuidBdWorkListResult = new List<NoteGuidBdWork>();

            NoteGuidBdWork noteGuidBdWork = new NoteGuidBdWork();
            noteGuidBdWork.EnterpriseCode = enterpriseCode;

            // サーチ用リスト初期化
            ArrayList paraList = new ArrayList();
            paraList.Clear();

            ArrayList ar = new ArrayList();

            List<NoteGuidBdWork> noteGuidBdWorkList = new List<NoteGuidBdWork>();

            // 車販ガイドマスタ（ヘッダ）検索
            int status = this._noteGuidBdLcDB.SearchBody(out noteGuidBdWorkList, noteGuidBdWork, 0, 0);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                //NoteGuidBdWork[] Byte_noteGuidBdWork = new NoteGuidBdWork[noteGuidBdWorkList.Count];
                for (int ix = 0; ix < noteGuidBdWorkList.Count; ix++)
                {
                    // 備考ガイド区分が一致するもののみ取得
                    if (noteGuideDivCode == noteGuidBdWorkList[ix].NoteGuideDivCode)
                    {
                        ar.Add((NoteGuidBdWork)noteGuidBdWorkList[ix]);
                        //Byte_noteGuidBdWork[ix] = (NoteGuidBdWork)noteGuidBdWorkList[ix];
                    }
                }

                ArrayList wkList = ar.Clone() as ArrayList;
                SortedList wkSort = new SortedList();

                // --- [全て] --- //
                // そのまま全件返す
                foreach (NoteGuidBdWork wkNoteGuidBdWork in wkList)
                {
                    if (wkNoteGuidBdWork.LogicalDeleteCode == 0)
                    {
                        wkSort.Add(wkNoteGuidBdWork.NoteGuideDivCode.ToString("0000") + wkNoteGuidBdWork.NoteGuideCode.ToString("0000"), wkNoteGuidBdWork);
                    }
                }

                // データを元に戻す
                for (int i = 0; i < wkSort.Count; i++)
                {
                    noteGuidBdWorkListResult.Add((NoteGuidBdWork)wkSort.GetByIndex(i));
                }
            }
            return status;
        }
		*/
		// 2007.10.04 sasaki <<

		// 2007.10.04 sasaki >>
		/*
        /// <summary>
        /// 備考ガイド（ボディ）テーブルローカルDB検索処理（DataSet用）
        /// </summary>
        /// <param name="ds">取得結果格納用DataSet</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="noteGuideDivCode">備考ガイド区分</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 備考ガイド（ボディ）のローカルDB検索処理を行い、取得結果をDataSetで返します。</br>
        /// <br>Programmer : 飯谷 耕平</br>
        /// <br>Date       : 2007.04.09</br>
        /// </remarks>
        public int SearchBodyLocalDB(ref DataSet ds, string enterpriseCode, int noteGuideDivCode)
        {

            List<NoteGuidBdWork> noteGuidBdWorkList;

            // 備考ガイド(ボディ)を取得
            int status = this.SearchBodyLocalDB(out noteGuidBdWorkList
                                               ,    enterpriseCode
                                               ,    noteGuideDivCode);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // XMLへ変換し、文字列のバイナリ化
                byte[] retbyte = XmlByteSerializer.Serialize(noteGuidBdWorkList);
                XmlByteSerializer.ReadXml(ref ds, retbyte);
            }

            // ↓ 20070521 18322 d ロジックを変更した為削除
            #region ロジックを変更した為削除
            //NoteGuidBdWork noteGuidBdWork = new NoteGuidBdWork();
            //noteGuidBdWork.EnterpriseCode = enterpriseCode;
            //
            //// サーチ用リスト初期化
            //ArrayList paraList = new ArrayList();
            //paraList.Clear();
            //
            //ArrayList ar = new ArrayList();
            //
            //List<NoteGuidBdWork> noteGuidBdWorkList = new List<NoteGuidBdWork>();
            //
            //// 車販ガイドマスタ（ヘッダ）検索
            //int status = this._noteGuidBdLcDB.SearchBody(out noteGuidBdWorkList, noteGuidBdWork, 0, 0);
            //
            //if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            //{
            //    //NoteGuidBdWork[] Byte_noteGuidBdWork = new NoteGuidBdWork[noteGuidBdWorkList.Count];
            //    for (int ix = 0; ix < noteGuidBdWorkList.Count; ix++)
            //    {
            //        // 備考ガイド区分が一致するもののみ取得
            //        if (noteGuideDivCode == noteGuidBdWorkList[ix].NoteGuideDivCode)
            //        {
            //            ar.Add((NoteGuidBdWork)noteGuidBdWorkList[ix]);
            //            //Byte_noteGuidBdWork[ix] = (NoteGuidBdWork)noteGuidBdWorkList[ix];
            //        }
            //    }
            //
            //    ArrayList wkList = ar.Clone() as ArrayList;
            //    SortedList wkSort = new SortedList();
            //
            //    // --- [全て] --- //
            //    // そのまま全件返す
            //    foreach (NoteGuidBdWork wkNoteGuidBdWork in wkList)
            //    {
            //        if (wkNoteGuidBdWork.LogicalDeleteCode == 0)
            //        {
            //            wkSort.Add(wkNoteGuidBdWork.NoteGuideDivCode.ToString("0000") + wkNoteGuidBdWork.NoteGuideCode.ToString("0000"), wkNoteGuidBdWork);
            //        }
            //    }
            //
            //    NoteGuidBdWork[] noteGuidBdWorks = new NoteGuidBdWork[wkSort.Count];
            //
            //    // データを元に戻す
            //    for (int i = 0; i < wkSort.Count; i++)
            //    {
            //        noteGuidBdWorks[i] = (NoteGuidBdWork)wkSort.GetByIndex(i);
            //    }
            //
            //    // XMLへ変換し、文字列のバイナリ化
            //    byte[] retbyte = XmlByteSerializer.Serialize(noteGuidBdWorks);
            //    XmlByteSerializer.ReadXml(ref ds, retbyte);
            //}
            #endregion
            // ↑ 20070521 18322 d

            return status;
        }
		*/
		// 2007.10.04 sasaki <<


        /// <summary>
        /// クラスメンバーコピー処理（備考ガイド（ヘッダ）ワーククラス⇒備考ガイド（ヘッダ）クラス）
        /// </summary>
        /// <param name="noteGuidHdWork">備考ガイド（ヘッダ）ワーククラス</param>
        /// <returns>備考ガイド（ヘッダ）クラス</returns>
        /// <remarks>
        /// <br>Note       : 備考ガイド（ヘッダ）ワーククラスから備考ガイド（ヘッダ）クラスへメンバーのコピーを行います。</br>
        /// <br>Programmer : 三崎 貴史</br>
        /// <br>Date       : 2005.10.14</br>
        /// </remarks>
        private NoteGuidHd CopyToNoteGuidHdFromNoteGuidHdWork(NoteGuidHdWork noteGuidHdWork)
        {
            NoteGuidHd noteGuidHd = new NoteGuidHd();

            noteGuidHd.CreateDateTime = noteGuidHdWork.CreateDateTime;
            noteGuidHd.UpdateDateTime = noteGuidHdWork.UpdateDateTime;
            noteGuidHd.EnterpriseCode = noteGuidHdWork.EnterpriseCode;
            noteGuidHd.FileHeaderGuid = noteGuidHdWork.FileHeaderGuid;
            noteGuidHd.UpdEmployeeCode = noteGuidHdWork.UpdEmployeeCode;
            noteGuidHd.UpdAssemblyId1 = noteGuidHdWork.UpdAssemblyId1;
            noteGuidHd.UpdAssemblyId2 = noteGuidHdWork.UpdAssemblyId2;
            noteGuidHd.LogicalDeleteCode = noteGuidHdWork.LogicalDeleteCode;

            noteGuidHd.NoteGuideDivCode = noteGuidHdWork.NoteGuideDivCode;
            noteGuidHd.NoteGuideDivName = noteGuidHdWork.NoteGuideDivName;

            return noteGuidHd;
        }

        /// <summary>
        /// クラスメンバーコピー処理（備考ガイド（ボディ）ワーククラス⇒備考ガイド（ボディ）クラス）
        /// </summary>
        /// <param name="noteGuidBdWork">備考ガイド（ボディ）ワーククラス</param>
        /// <returns>備考ガイド（ボディ）クラス</returns>
        /// <remarks>
        /// <br>Note       : 備考ガイド（ボディ）ワーククラスから備考ガイド（ボディ）クラスへメンバーのコピーを行います。</br>
        /// <br>Programmer : 三崎 貴史</br>
        /// <br>Date       : 2005.10.14</br>
        /// </remarks>
        public NoteGuidBd CopyToNoteGuidBdFromNoteGuidBdWork(NoteGuidBdWork noteGuidBdWork)
        {
            NoteGuidBd noteGuidBd = new NoteGuidBd();

            noteGuidBd.CreateDateTime = noteGuidBdWork.CreateDateTime;
            noteGuidBd.UpdateDateTime = noteGuidBdWork.UpdateDateTime;
            noteGuidBd.EnterpriseCode = noteGuidBdWork.EnterpriseCode;
            noteGuidBd.FileHeaderGuid = noteGuidBdWork.FileHeaderGuid;
            noteGuidBd.UpdEmployeeCode = noteGuidBdWork.UpdEmployeeCode;
            noteGuidBd.UpdAssemblyId1 = noteGuidBdWork.UpdAssemblyId1;
            noteGuidBd.UpdAssemblyId2 = noteGuidBdWork.UpdAssemblyId2;
            noteGuidBd.LogicalDeleteCode = noteGuidBdWork.LogicalDeleteCode;

            noteGuidBd.NoteGuideDivCode = noteGuidBdWork.NoteGuideDivCode;
            noteGuidBd.NoteGuideCode = noteGuidBdWork.NoteGuideCode;
            noteGuidBd.NoteGuideName = noteGuidBdWork.NoteGuideName;

            return noteGuidBd;
        }

        /// <summary>
        /// クラスメンバーコピー処理（備考ガイド（ヘッダ）クラス⇒備考ガイド（ヘッダ）ワーククラス）
        /// </summary>
        /// <param name="noteGuidHd">備考ガイド（ヘッダ）クラス</param>
        /// <returns>備考ガイド（ヘッダ）ワーククラス</returns>
        /// <remarks>
        /// <br>Note       : 備考ガイド（ヘッダ）クラスから備考ガイド（ヘッダ）ワーククラスへメンバーのコピーを行います。</br>
        /// <br>Programmer : 三崎 貴史</br>
        /// <br>Date       : 2005.10.14</br>
        /// </remarks>
        private NoteGuidHdWork CopyToNoteGuidHdWorkFromNoteGuidHd(NoteGuidHd noteGuidHd)
        {
            NoteGuidHdWork noteGuidHdWork = new NoteGuidHdWork();

            noteGuidHdWork.CreateDateTime = noteGuidHd.CreateDateTime;
            noteGuidHdWork.UpdateDateTime = noteGuidHd.UpdateDateTime;
            noteGuidHdWork.EnterpriseCode = noteGuidHd.EnterpriseCode;
            noteGuidHdWork.FileHeaderGuid = noteGuidHd.FileHeaderGuid;
            noteGuidHdWork.UpdEmployeeCode = noteGuidHd.UpdEmployeeCode;
            noteGuidHdWork.UpdAssemblyId1 = noteGuidHd.UpdAssemblyId1;
            noteGuidHdWork.UpdAssemblyId2 = noteGuidHd.UpdAssemblyId2;
            noteGuidHdWork.LogicalDeleteCode = noteGuidHd.LogicalDeleteCode;

            noteGuidHdWork.NoteGuideDivCode = noteGuidHd.NoteGuideDivCode;
            noteGuidHdWork.NoteGuideDivName = noteGuidHd.NoteGuideDivName;

            return noteGuidHdWork;
        }

        /// <summary>
        /// クラスメンバーコピー処理（備考ガイド（ボディ）クラス⇒備考ガイド（ボディ）ワーククラス）
        /// </summary>
        /// <param name="noteGuidBd">備考ガイド（ボディ）クラス</param>
        /// <returns>備考ガイド（ボディ）ワーククラス</returns>
        /// <remarks>
        /// <br>Note       : 備考ガイド（ヘッダ）クラスから備考ガイド（ボディ）ワーククラスへメンバーのコピーを行います。</br>
        /// <br>Programmer : 三崎 貴史</br>
        /// <br>Date       : 2005.10.14</br>
        /// </remarks>
        private NoteGuidBdWork CopyToNoteGuidBdWorkFromNoteGuidBd(NoteGuidBd noteGuidBd)
        {
            NoteGuidBdWork noteGuidBdWork = new NoteGuidBdWork();

            noteGuidBdWork.CreateDateTime = noteGuidBd.CreateDateTime;
            noteGuidBdWork.UpdateDateTime = noteGuidBd.UpdateDateTime;
            noteGuidBdWork.EnterpriseCode = noteGuidBd.EnterpriseCode;
            noteGuidBdWork.FileHeaderGuid = noteGuidBd.FileHeaderGuid;
            noteGuidBdWork.UpdEmployeeCode = noteGuidBd.UpdEmployeeCode;
            noteGuidBdWork.UpdAssemblyId1 = noteGuidBd.UpdAssemblyId1;
            noteGuidBdWork.UpdAssemblyId2 = noteGuidBd.UpdAssemblyId2;
            noteGuidBdWork.LogicalDeleteCode = noteGuidBd.LogicalDeleteCode;

            noteGuidBdWork.NoteGuideDivCode = noteGuidBd.NoteGuideDivCode;
            noteGuidBdWork.NoteGuideCode = noteGuidBd.NoteGuideCode;
            noteGuidBdWork.NoteGuideName = noteGuidBd.NoteGuideName;

            return noteGuidBdWork;
        }

        /// <summary>
        /// ガイド呼び出し
        /// </summary>
        /// <param name="noteGuidBd">取得備考ガイド情報</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="noteGuideDivCode">備考ガイド区分</param>
        /// <returns>STATUS[0:選択 1:キャンセル -1:エラー]</returns>
        /// <remarks>
        /// <br>Note       : 備考ガイド(Body)を表示</br>
        /// <br>Programmer : 22033 三崎  貴史</br>
        /// <br>Date       : 2005.10.17</br>
        /// </remarks>
        public int ExecuteGuide(out NoteGuidBd noteGuidBd, string enterpriseCode, int noteGuideDivCode)
        {
            int status = -1;
            noteGuidBd = new NoteGuidBd();

            TableGuideParent tblGuid = new TableGuideParent("NOTEGUIDEPARENT.XML");
            Hashtable inObj = new Hashtable();
            Hashtable outObj = new Hashtable();
            inObj.Add("EnterpriseCode", enterpriseCode);
            inObj.Add("NoteGuideDivCode", noteGuideDivCode);

            if (tblGuid.Execute(0, inObj, ref outObj))
            {
                object noteGuidBdObj = (object)new NoteGuidBd();
                TableGuideParent.HashTableToClassProperty(outObj, ref noteGuidBdObj);
                noteGuidBd = (NoteGuidBd)noteGuidBdObj;
                status = 0;
            }
            else
            {
                status = 1;
            }

            return status;
        }

        /// <summary>
        /// ガイド表示データ取得
        /// </summary>
        /// <param name="noteGdBdList">ガイド表示データリスト</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="noteGuideDivCode">備考ガイド区分</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ガイドに表示するデータを検索</br>
        /// <br>Programmer : 22033 三崎  貴史</br>
        /// <br>Date       : 2005.10.17</br>
        /// </remarks>
        private int SearchGuideList(out SortedList noteGdBdList, string enterpriseCode, int noteGuideDivCode)
        {
            int status = 0;
            noteGdBdList = new SortedList();

            // Bufferが無い場合
            if ((_guidBuff_NoteGdBd == null) ||
                (_guidBuff_NoteGdBd.Count == 0))
            {
                // ガイドデータ取得
                status = GetNoteGdBdDataBuffer(enterpriseCode);

                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    return status;
                }
            }

            // 表示データ設定
            foreach (NoteGuidBd noteGuidBd in _guidBuff_NoteGdBd.Values)
            {
                if (noteGuidBd.NoteGuideDivCode == noteGuideDivCode)
                    // リストにデータを追加
                    noteGdBdList.Add(noteGuidBd.NoteGuideCode, noteGuidBd);
            }
            return status;
        }

        /// <summary>
        /// ガイド用データ読込
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ガイド用データバッファに備考ガイドデータを読込む</br>
        /// <br>Programmer : 22033 三崎  貴史</br>
        /// <br>Date       : 2005.10.17</br>
        /// </remarks>
        private int GetNoteGdBdDataBuffer(string enterpriseCode)
        {
            if (_guidBuff_NoteGdBd == null)
            {
                _guidBuff_NoteGdBd = new Hashtable();
            }
            _guidBuff_NoteGdBd.Clear();

            ArrayList noteGdBdList;
            int status = SearchBody(out noteGdBdList, enterpriseCode);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                string hashKey;
                foreach (NoteGuidBd noteGuidBd in noteGdBdList)
                {
                    hashKey = noteGuidBd.NoteGuideDivCode.ToString() + "_" + noteGuidBd.NoteGuideCode.ToString();
                    _guidBuff_NoteGdBd.Add(hashKey, noteGuidBd);
                }
            }
            return status;
        }

        #region IGeneralGuideData メンバ
        /// <summary>
        /// ガイド表示データ取得
        /// </summary>
        /// <param name="mode">モード</param>
        /// <param name="inParm">条件</param>
        /// <param name="guideList">表示データ</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ガイドに表示するデータを取得する</br>
        /// <br>Programmer : 22033 三崎  貴史</br>
        /// <br>Date       : 2005.10.17</br>
        /// </remarks>
        public int GetGuideData(int mode, Hashtable inParm, ref DataSet guideList)
        {
            int status = 0;

            // 条件を取得
            // 企業コード
            string enterpriseCode = "";
            if (inParm.ContainsKey("EnterpriseCode"))
            {
                enterpriseCode = inParm["EnterpriseCode"].ToString();
            }
            else
            {
                // ありえないのでエラー
                status = -1;
                return status;
            }

            // 備考ガイド区分
            int noteGuideDivCode = 0;
            if (inParm.ContainsKey("NoteGuideDivCode"))
            {
                noteGuideDivCode = TStrConv.StrToIntDef(inParm["NoteGuideDivCode"].ToString(), 0);
            }

			// 2007.10.04 sasaki >>
			/*
            // 備考ガイドデータ取得(ローカルDBからの取得に変更) iitani c
            //status = SearchGuideList(out sortList, enterpriseCode, noteGuideDivCode);
            status = SearchBodyLocalDB(ref guideList, enterpriseCode, noteGuideDivCode);

            // iitani c
            //if (status == 0)
            //{
            //    NoteGuidBd[] noteGuidBds = new NoteGuidBd[sortList.Count];

            //    foreach (NoteGuidBd	noteGuidBd in sortList.Values)
            //    {
            //        byte[] retByte = XmlByteSerializer.Serialize(noteGuidBd);
            //        XmlByteSerializer.ReadXml(ref guideList,retByte);
            //    }
            //}
			*/

            _guidBuff_NoteGdBd = null;

			// サーバーデータ取得
			SortedList sortList;
			status = SearchGuideList(out sortList, enterpriseCode, noteGuideDivCode);

			if (status == 0)
			{
				NoteGuidBd[] noteGuidBds = new NoteGuidBd[sortList.Count];

				foreach (NoteGuidBd noteGuidBd in sortList.Values)
				{
					byte[] retByte = XmlByteSerializer.Serialize(noteGuidBd);
					XmlByteSerializer.ReadXml(ref guideList, retByte);
				}
			}
			// 2007.10.04 sasaki <<
			switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    break;
                case (int)ConstantManagement.DB_Status.ctDB_EOF:
                    {
                        status = 4;
                        break;
                    }
                default:
                    status = -1;
                    break;
            }

            return status;
        }

        /// <summary>
        /// 備考ガイド（ヘッダ）クラス ⇒ UIクラス変換処理
        /// </summary>
        /// <param name="noteGuidHd">備考ガイド（ヘッダ）クラス</param>
        /// <remarks>
        /// <br>Note       : 備考ガイド（ヘッダ）クラスをStaticメモリに保持します。</br>
        /// <br>Programer  : 22033  三崎  貴史</br>
        /// <br>Date       : 2006.04.25</br>
        /// </remarks>
        private void CopyToStaticFromDataClass(NoteGuidHd noteGuidHd)
        {
            // --- HashKey : 区分コード --- //

            NoteGuidHd wkNoteGuidHd = new NoteGuidHd();

            wkNoteGuidHd.CreateDateTime = noteGuidHd.CreateDateTime;
            wkNoteGuidHd.UpdateDateTime = noteGuidHd.UpdateDateTime;
            wkNoteGuidHd.LogicalDeleteCode = noteGuidHd.LogicalDeleteCode;

            wkNoteGuidHd.NoteGuideDivCode = noteGuidHd.NoteGuideDivCode;
            wkNoteGuidHd.NoteGuideDivName = noteGuidHd.NoteGuideDivName;

            _noteGdHdTable_Stc[wkNoteGuidHd.NoteGuideDivCode] = wkNoteGuidHd;
        }

        /// <summary>
        /// 備考ガイド（ヘッダ）ワーカークラス ⇒ UIクラス変換 ＋ Static展開処理
        /// </summary>
        /// <param name="noteGuidHdWork">備考ガイド（ヘッダ）ワーカークラス</param>
        /// <remarks>
        /// <br>Note       : 備考ガイド（ヘッダ）クラスをStaticメモリに保持します。</br>
        /// <br>Programer  : 22033  三崎  貴史</br>
        /// <br>Date       : 2006.04.25</br>
        /// </remarks>
        private void CopyToStaticFromWork(NoteGuidHdWork noteGuidHdWork)
        {
            // --- HashKey : 区分コード --- //

            NoteGuidHd wkNoteGuidHd = new NoteGuidHd();

            wkNoteGuidHd.CreateDateTime = noteGuidHdWork.CreateDateTime;
            wkNoteGuidHd.UpdateDateTime = noteGuidHdWork.UpdateDateTime;
            wkNoteGuidHd.FileHeaderGuid = noteGuidHdWork.FileHeaderGuid;
            wkNoteGuidHd.LogicalDeleteCode = noteGuidHdWork.LogicalDeleteCode;

            wkNoteGuidHd.NoteGuideDivCode = noteGuidHdWork.NoteGuideDivCode;	// 備考ガイド区分コード
            wkNoteGuidHd.NoteGuideDivName = noteGuidHdWork.NoteGuideDivName;	// 備考ガイド区分名称

            _noteGdHdTable_Stc[wkNoteGuidHd.NoteGuideDivCode] = wkNoteGuidHd;
        }

        /// <summary>
        /// ローカルファイル読込み処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : ローカルファイルを読込んで、情報をStaticに保持します。</br>
        /// <br>Programer  : 22033  三崎  貴史</br>
        /// <br>Date       : 2006.04.25</br>
        /// </remarks>
        private void SearchOfflineData()
        {
            // オフラインシリアライズデータ作成部品I/O
            OfflineDataSerializer offlineDataSerializer = new OfflineDataSerializer();

            // KeyList設定
            string[] noteGdHdKeys = new string[1];
            noteGdHdKeys[0] = LoginInfoAcquisition.EnterpriseCode;
            // ローカルファイル読込み処理
            object wkObj = offlineDataSerializer.DeSerialize(this.ToString(), noteGdHdKeys);
            // ArrayListにセット
            ArrayList wkList = wkObj as ArrayList;

            if ((wkList != null) &&
                (wkList.Count != 0))
            {
                foreach (NoteGuidHdWork noteGuidHdWork in wkList)
                {
                    // 備考ガイド（ヘッダ）ワーカークラス ⇒ Static変換処理
                    CopyToStaticFromWork(noteGuidHdWork);
                }
            }
        }
        #endregion
    }
}