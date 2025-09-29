using System;
using System.Collections.Generic;
using System.Text;

namespace Broadleaf.Application.Remoting
{
    internal struct SubstChkKey
    {
        private int _makerCd;
        private int _goodsMGroup;
        private string _prmPartsNo;

        /// <summary>
        /// メーカーコード
        /// </summary>
        public int MakerCd
        {
            get { return _makerCd; }
            set { _makerCd  = value;}
        }

        /// <summary>
        /// 商品中分類
        /// </summary>
        public int GoodsMGroup
        {
            get { return _goodsMGroup; }
            set { _goodsMGroup = value; }
        }

        /// <summary>
        /// 品番
        /// </summary>
        public string PrmPartsNo
        {
            get { return _prmPartsNo; }
            set { _prmPartsNo = value; }
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="goodsMGroup">商品中分類</param>
        /// <param name="makerCd">メーカーコード</param>
        /// <param name="prmPartsNo">品番</param>
        public SubstChkKey(int goodsMGroup, int makerCd, string prmPartsNo)
        {
            _makerCd = makerCd;
            _goodsMGroup = goodsMGroup;
            _prmPartsNo = prmPartsNo;
        }

    }
}
