using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using System.IO;
using System.Windows.Forms;

using Broadleaf.Application.UIData;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// 売上入力用初期値取得アクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 売上入力の初期値取得データ制御を行います。</br>
    /// </remarks>
    public class DelphiSalesSlipInputInitDataSixthAcs
    {
        # region ■コンストラクタ
        /// <summary>
        /// デフォルトコンストラクタ（Singletonデザインパターンを採用している為、privateとする）
        /// </summary>
        private DelphiSalesSlipInputInitDataSixthAcs()
        {
        }

        /// <summary>
        /// 売上入力用初期値取得アクセスクラス インスタンス取得処理
        /// </summary>
        public static DelphiSalesSlipInputInitDataSixthAcs GetInstance()
        {
            if (_delphiSalesSlipInputInitDataSixthAcs == null)
            {
                _delphiSalesSlipInputInitDataSixthAcs = new DelphiSalesSlipInputInitDataSixthAcs();
            }
            return _delphiSalesSlipInputInitDataSixthAcs;
        }
        # endregion

        #region ■プライベート変数
        private static DelphiSalesSlipInputInitDataSixthAcs _delphiSalesSlipInputInitDataSixthAcs;
        private List<PriceSelectSet> _displayDivList = null;              // 表示区分リスト
        private List<NoteGuidBd> _noteGuidList = null;              // 備考ガイド全件リスト
        #endregion

        #region ■パブリック変数
        /// <summary>ローカルDB読み込み判定</summary>
#if DEBUG
        public static readonly bool ctIsLocalDBRead = false; // true:ローカル参照 false:サーバー参照
#else
        public static readonly bool ctIsLocalDBRead = false; // true:ローカル参照 false:サーバー参照
#endif
        # endregion

        # region ■パブリックメソッド
        /// <summary>
        /// 売上入力で使用する初期データをＤＢより取得します。
        /// </summary>
        /// <param name="enterpriseCode"></param>
        /// <param name="sectionCode"></param>
        /// <returns></returns>
        public int ReadInitDataSixth(string enterpriseCode, string sectionCode)
        {
            ArrayList aList;
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            #region ●表示区分マスタ PMHNB09003A
            PriceSelectSetAcs priceSelectSetAcs = new PriceSelectSetAcs();
            status = priceSelectSetAcs.Search(out aList, enterpriseCode);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                if (aList != null) this._displayDivList = new List<PriceSelectSet>((PriceSelectSet[])aList.ToArray(typeof(PriceSelectSet))); ;
            }
            else
            {
                this._displayDivList = new List<PriceSelectSet>();
            }
            #endregion

            #region ●備考ガイドマスタアクセスクラス SFTOK09402A
            NoteGuidAcs noteGuidAcs = new NoteGuidAcs();
            noteGuidAcs.IsLocalDBRead = ctIsLocalDBRead;
            status = noteGuidAcs.SearchBody(out aList, enterpriseCode);
            this._noteGuidList = new List<NoteGuidBd>();
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                if (aList != null) this._noteGuidList = new List<NoteGuidBd>((NoteGuidBd[])aList.ToArray(typeof(NoteGuidBd)));
            }
            #endregion

            return 0;
        }
        #endregion

        public List<PriceSelectSet> GetDisplayDivList()
        {
            return this._displayDivList;
        }
        public List<NoteGuidBd> GetNoteGuidList()
        {
            return this._noteGuidList;

        }
    }
}
