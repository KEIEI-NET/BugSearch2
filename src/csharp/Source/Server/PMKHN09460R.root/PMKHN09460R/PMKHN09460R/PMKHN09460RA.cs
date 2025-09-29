using System;
using System.Collections;
using System.Data;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Collections;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Common;
using Broadleaf.Library;

namespace Broadleaf.Application.Common
{
	/// <summary>
	/// 商品仕入先取得クラス
	/// </summary>
	/// <remarks>
	/// <br>Note		: 商品管理情報を読み込み、仕入先の取得を行います。</br>
	/// <br>Programmer	: 22008　長内 数馬</br>
	/// <br>Date		: 2009.04.16</br>
    /// <br></br>
    /// <br>Note		: 仕入先取得の優先順位を変更[ MANTIS ID:13460]</br>
    /// <br>Programmer	: 23012　畠中 啓次朗</br>
    /// <br>Date		: 2009.06.11</br>
    /// <br>Update Note: 2013/05/06 yangyi</br>
    /// <br>管理番号   : 10801804-00 PM1301E(速度調査）</br>
    /// <br>           : Redmine#35493 　棚卸準備処理で、掛率マスタの件数が多い時に、処理時間が長く、且つサーバー負荷が高くなる(#1902)</br>
    /// </remarks>
	public class GoodsSupplierGetter
	{
        // ===================================================================================== //
        // パブリック変数
        // ===================================================================================== //
        #region ■Public Members
        /// <summary>全社指定拠点コード</summary>
        public const string ctAllDefSectionCode = "00";

		#endregion

        // ===================================================================================== //
        // プライベート変数
        // ===================================================================================== //
        # region ■Private Members

        # endregion

        // ===================================================================================== //
        // コンストラクタ
        // ===================================================================================== //
        # region ■Constracter

		/// <summary>
		/// 単価算出クラス コンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Programmer : 22008　長内 数馬</br>
		/// <br>Date       : 2009.04.16</br>
		/// </remarks>
        public GoodsSupplierGetter()
		{

        }

		# endregion

        // ===================================================================================== //
        // パブリックメソッド
        // ===================================================================================== //
        #region■Public Methods
        /// <summary>
        /// 商品仕入先情報取得
        /// </summary>
        /// <param name="goodsSupplierDataList">取得用データクラスリスト</param>
        public void GetGoodsMngInfo(ref List<GoodsSupplierDataWork> goodsSupplierDataList)
        {
            int status = 0;

            //企業コード取得
            string enterpriseCode = (goodsSupplierDataList[0] as GoodsSupplierDataWork).EnterpriseCode;

            //商品管理情報マスタ取得
            List<GoodsMngWork> goodsMngList = null;
            status = Search_GoodsMng(enterpriseCode, out goodsMngList);

            //商品管理情報が取得出来ない場合は以下の処理を行わない
            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) return;
            
            Dictionary<string, GoodsMngWork> goodsMngDic1 = null;     //拠点＋メーカー＋品番
            Dictionary<string, GoodsMngWork> goodsMngDic2 = null;     //拠点＋中分類＋メーカー＋ＢＬ
            Dictionary<string, GoodsMngWork> goodsMngDic3 = null;     //拠点＋中分類＋メーカー
            Dictionary<string, GoodsMngWork> goodsMngDic4 = null;     //拠点＋メーカー

            //商品管理情報マスタ
            MakeGoodsMngDictionary(goodsMngList, out goodsMngDic1, out goodsMngDic2, out goodsMngDic3, out goodsMngDic4);

            for (int i = 0; i < goodsSupplierDataList.Count;i++ )
            {
                GoodsSupplierDataWork goodsSupplierDataWork = goodsSupplierDataList[i];

                //商品管理情報から対象の仕入先を取得
                GetGoodsMngInfoProc(goodsMngDic1, goodsMngDic2, goodsMngDic3, goodsMngDic4, ref goodsSupplierDataWork);
            }

        }


        // --- ADD yangyi 2013/05/06 for Redmine#35493 ------->>>>>>>>>>>
        /// <summary>
        /// 商品仕入先情報取得
        /// </summary>
        public void GetGoodsMngInfo(string enterpriseCode, ref Dictionary<string, GoodsMngWork> goodsMngDic1, ref Dictionary<string, GoodsMngWork> goodsMngDic2, ref Dictionary<string, GoodsMngWork> goodsMngDic3, ref Dictionary<string, GoodsMngWork> goodsMngDic4)
        {
            int status = 0;

            //商品管理情報マスタ取得
            List<GoodsMngWork> goodsMngList = null;
            status = Search_GoodsMng(enterpriseCode, out goodsMngList);

            //商品管理情報が取得出来ない場合は以下の処理を行わない
            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) return;

            //商品管理情報マスタ
            MakeGoodsMngDictionary(goodsMngList, out goodsMngDic1, out goodsMngDic2, out goodsMngDic3, out goodsMngDic4);
        }

        public void GetSupplierInfo(ref GoodsSupplierDataWork goodsSupplierDataWork, Dictionary<string, GoodsMngWork> goodsMngDic1, Dictionary<string, GoodsMngWork> goodsMngDic2, Dictionary<string, GoodsMngWork> goodsMngDic3, Dictionary<string, GoodsMngWork> goodsMngDic4)
        {
            GetGoodsMngInfoProc(goodsMngDic1, goodsMngDic2, goodsMngDic3, goodsMngDic4, ref goodsSupplierDataWork);
        }
        // --- ADD yangyi 2013/05/06 for Redmine#35493 -------<<<<<<<<<<<

		#endregion

        // ===================================================================================== //
        // プライベートメソッド
        // ===================================================================================== //
        #region ■Private Methods
        /// <summary>
        /// 商品管理情報取得
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="goodsMngList">商品管理情報リスト</param>
        /// <returns>STATUS</returns>
        private int Search_GoodsMng(string enterpriseCode, out List<GoodsMngWork> goodsMngList)
        {
            int status = 0;

            goodsMngList = new List<GoodsMngWork>();
            GoodsMngDB goodsMngDB = new GoodsMngDB();

            GoodsMngWork paraWork = new GoodsMngWork();
            paraWork.EnterpriseCode = enterpriseCode;

            object paraobj = paraWork;
            object retobj = null;

            //商品管理情報マスタ抽出
            status = goodsMngDB.Search(out retobj, paraobj, 0, 0);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                ArrayList list = retobj as ArrayList;
                goodsMngList.AddRange((GoodsMngWork[])list.ToArray(typeof(GoodsMngWork)));
            }

            return status;
        }

        /// <summary>
        /// 商品管理情報取得
        /// </summary>
        /// <param name="goodsMngList">商品管理情報リスト</param>
        /// <param name="goodsMngDic1">拠点＋メーカー＋品番</param>
        /// <param name="goodsMngDic2">拠点＋中分類＋メーカー＋ＢＬ</param>
        /// <param name="goodsMngDic3">拠点＋中分類＋メーカー</param>
        /// <param name="goodsMngDic4">拠点＋メーカー</param>
        /// <returns>STATUS</returns>
        private void MakeGoodsMngDictionary(List<GoodsMngWork> goodsMngList, out Dictionary<string, GoodsMngWork> goodsMngDic1, out Dictionary<string, GoodsMngWork> goodsMngDic2, out Dictionary<string, GoodsMngWork> goodsMngDic3, out Dictionary<string, GoodsMngWork> goodsMngDic4)
        {

            goodsMngDic1 = new Dictionary<string, GoodsMngWork>();     //拠点＋メーカー＋品番
            goodsMngDic2 = new Dictionary<string, GoodsMngWork>();     //拠点＋中分類＋メーカー＋ＢＬ
            goodsMngDic3 = new Dictionary<string, GoodsMngWork>();     //拠点＋中分類＋メーカー
            goodsMngDic4 = new Dictionary<string, GoodsMngWork>();     //拠点＋メーカー

            StringBuilder goodsMngDic1Key = null;
            StringBuilder goodsMngDic2Key = null;
            StringBuilder goodsMngDic3Key = null;
            StringBuilder goodsMngDic4Key = null;

            for (int i = 0; i <= goodsMngList.Count - 1; i++)
            {
                goodsMngDic1Key = new StringBuilder();
                goodsMngDic2Key = new StringBuilder();
                goodsMngDic3Key = new StringBuilder();
                goodsMngDic4Key = new StringBuilder();

                goodsMngDic4Key.Append(goodsMngList[i].SectionCode.Trim().PadLeft(2, '0'));     //拠点
                goodsMngDic4Key.Append(goodsMngList[i].GoodsMakerCd.ToString("0000"));          //メーカー

                if (goodsMngList[i].GoodsNo.Trim() != string.Empty)
                {
                    goodsMngDic1Key.Append(goodsMngDic4Key.ToString());                         //拠点＋メーカー
                    goodsMngDic1Key.Append(goodsMngList[i].GoodsNo.Trim());                     //品番

                    //拠点＋メーカー＋品番
                    if (!goodsMngDic1.ContainsKey(goodsMngDic1Key.ToString()))
                    {
                       goodsMngDic1.Add(goodsMngDic1Key.ToString(), goodsMngList[i]);
                    }
                }
                else
                {
                    goodsMngDic3Key.Append(goodsMngDic4Key.ToString());                         //拠点＋メーカー
                    goodsMngDic3Key.Append(goodsMngList[i].GoodsMGroup.ToString("0000"));       //中分類

                    goodsMngDic2Key.Append(goodsMngDic3Key.ToString());                         //拠点＋メーカー＋中分類
                    goodsMngDic2Key.Append(goodsMngList[i].BLGoodsCode.ToString("00000"));      //ＢＬ

                    if (goodsMngList[i].BLGoodsCode != 0)
                    {
                        //拠点＋中分類＋メーカー＋ＢＬ
                        if (!goodsMngDic2.ContainsKey(goodsMngDic2Key.ToString()))
                        {
                            goodsMngDic2.Add(goodsMngDic2Key.ToString(), goodsMngList[i]);
                        }
                    }
                    else if (goodsMngList[i].GoodsMGroup != 0)
                    {
                        //拠点＋中分類＋メーカー
                        if (!goodsMngDic3.ContainsKey(goodsMngDic3Key.ToString()))
                        {
                            goodsMngDic3.Add(goodsMngDic3Key.ToString(), goodsMngList[i]);
                        }
                    }
                    else
                    {
                        //拠点＋メーカー
                        if (!goodsMngDic4.ContainsKey(goodsMngDic4Key.ToString()))
                        {
                            goodsMngDic4.Add(goodsMngDic4Key.ToString(), goodsMngList[i]);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 商品管理情報取得
        /// </summary>
        /// <param name="goodsSupplierData">商品連結データオブジェクト</param>
        /// <param name="goodsMngDic1">拠点＋メーカー＋品番</param>
        /// <param name="goodsMngDic2">拠点＋中分類＋メーカー＋ＢＬ</param>
        /// <param name="goodsMngDic3">拠点＋中分類＋メーカー</param>
        /// <param name="goodsMngDic4">拠点＋メーカー</param>
        private void GetGoodsMngInfoProc(Dictionary<string, GoodsMngWork> goodsMngDic1, Dictionary<string, GoodsMngWork> goodsMngDic2, Dictionary<string, GoodsMngWork> goodsMngDic3, Dictionary<string, GoodsMngWork> goodsMngDic4, ref GoodsSupplierDataWork goodsSupplierData)
        {
            GoodsMngWork retGoodsMng = null;

            try
            {
                #region DEL 2009/06/11
                /*
                StringBuilder goodsMngDic1key = new StringBuilder();
                StringBuilder goodsMngDic2key = new StringBuilder();
                StringBuilder goodsMngDic3key = new StringBuilder();
                StringBuilder goodsMngDic4key = new StringBuilder();
                StringBuilder goodsMngDic5key = new StringBuilder();
                StringBuilder goodsMngDic6key = new StringBuilder();
                StringBuilder goodsMngDic7key = new StringBuilder();
                StringBuilder goodsMngDic8key = new StringBuilder();

                goodsMngDic4key.Append(goodsSupplierData.SectionCode.Trim().PadLeft(2, '0'));    //拠点
                goodsMngDic4key.Append(goodsSupplierData.GoodsMakerCd.ToString("0000"));        //メーカー

                goodsMngDic1key.Append(goodsMngDic4key.ToString());                         //拠点＋メーカー
                goodsMngDic1key.Append(goodsSupplierData.GoodsNo.Trim());                       //品番

                goodsMngDic3key.Append(goodsMngDic4key.ToString());                         //拠点＋メーカー
                goodsMngDic3key.Append(goodsSupplierData.GoodsMGroup.ToString("0000"));         //中分類

                goodsMngDic2key.Append(goodsMngDic3key.ToString());                         //拠点＋メーカー＋中分類
                goodsMngDic2key.Append(goodsSupplierData.BLGoodsCode.ToString("00000"));        //ＢＬ

                if (goodsMngDic1.ContainsKey(goodsMngDic1key.ToString()))
                {
                    //拠点＋メーカー＋品番
                    retGoodsMng = goodsMngDic1[goodsMngDic1key.ToString()];
                }
                else if (goodsMngDic2.ContainsKey(goodsMngDic2key.ToString()))
                {
                    //拠点＋中分類＋メーカー＋ＢＬ
                    retGoodsMng = goodsMngDic2[goodsMngDic2key.ToString()];
                }
                else if (goodsMngDic3.ContainsKey(goodsMngDic3key.ToString()))
                {
                    //拠点＋中分類＋メーカー
                    retGoodsMng = goodsMngDic3[goodsMngDic3key.ToString()];
                }
                else if (goodsMngDic4.ContainsKey(goodsMngDic4key.ToString()))
                {
                    //拠点＋メーカー
                    retGoodsMng = goodsMngDic4[goodsMngDic4key.ToString()];
                }
                else
                {
                    goodsMngDic8key.Append(ctAllDefSectionCode);                            //全社
                    goodsMngDic8key.Append(goodsSupplierData.GoodsMakerCd.ToString("0000"));    //メーカー

                    goodsMngDic5key.Append(goodsMngDic8key.ToString());                     //全社＋メーカー
                    goodsMngDic5key.Append(goodsSupplierData.GoodsNo.Trim());                   //品番

                    goodsMngDic7key.Append(goodsMngDic8key.ToString());                     //全社＋メーカー
                    goodsMngDic7key.Append(goodsSupplierData.GoodsMGroup.ToString("0000"));     //中分類

                    goodsMngDic6key.Append(goodsMngDic7key.ToString());                     //全社＋メーカー＋中分類
                    goodsMngDic6key.Append(goodsSupplierData.BLGoodsCode.ToString("00000"));    //ＢＬ

                    if (goodsMngDic1.ContainsKey(goodsMngDic5key.ToString()))
                    {
                        //全社＋メーカー＋品番
                        retGoodsMng = goodsMngDic1[goodsMngDic5key.ToString()];
                    }
                    else if (goodsMngDic2.ContainsKey(goodsMngDic6key.ToString()))
                    {
                        //全社＋中分類＋メーカー＋ＢＬ
                        retGoodsMng = goodsMngDic2[goodsMngDic6key.ToString()];
                    }
                    else if (goodsMngDic3.ContainsKey(goodsMngDic7key.ToString()))
                    {
                        //全社＋中分類＋メーカー
                        retGoodsMng = goodsMngDic3[goodsMngDic7key.ToString()];
                    }
                    else if (goodsMngDic4.ContainsKey(goodsMngDic8key.ToString()))
                    {
                        //全社＋メーカー
                        retGoodsMng = goodsMngDic4[goodsMngDic8key.ToString()];
                    }
                }
                */
                #endregion

                // ---ADD 2009/06/11 優先順変更 ------------------------------------->>>>>
                //拠点＋メーカー
                StringBuilder goodsMngDic4key = new StringBuilder();
                goodsMngDic4key.Append(goodsSupplierData.SectionCode.Trim().PadLeft(2, '0'));
                goodsMngDic4key.Append(goodsSupplierData.GoodsMakerCd.ToString("0000"));
                //【拠点＋メーカー】＋品番
                StringBuilder goodsMngDic1key = new StringBuilder();
                goodsMngDic1key.Append(goodsMngDic4key.ToString());
                goodsMngDic1key.Append(goodsSupplierData.GoodsNo.Trim());

                //1.拠点＋メーカー＋品番
                if (goodsMngDic1.ContainsKey(goodsMngDic1key.ToString()))
                {
                    retGoodsMng = goodsMngDic1[goodsMngDic1key.ToString()];
                    return;
                }

                //全社＋メーカー
                StringBuilder goodsMngDic8key = new StringBuilder();
                goodsMngDic8key.Append(ctAllDefSectionCode);
                goodsMngDic8key.Append(goodsSupplierData.GoodsMakerCd.ToString("0000"));
                //【全社＋メーカー】＋品番
                StringBuilder goodsMngDic5key = new StringBuilder();
                goodsMngDic5key.Append(goodsMngDic8key.ToString());
                goodsMngDic5key.Append(goodsSupplierData.GoodsNo.Trim());

                //2.全社＋メーカー＋品番
                if (goodsMngDic1.ContainsKey(goodsMngDic5key.ToString()))
                {
                    retGoodsMng = goodsMngDic1[goodsMngDic5key.ToString()];
                    return;
                }

                //【拠点＋メーカー】＋中分類
                StringBuilder goodsMngDic3key = new StringBuilder();
                goodsMngDic3key.Append(goodsMngDic4key.ToString());
                goodsMngDic3key.Append(goodsSupplierData.GoodsMGroup.ToString("0000"));
                //【拠点＋メーカー＋中分類】＋ＢＬ
                StringBuilder goodsMngDic2key = new StringBuilder();
                goodsMngDic2key.Append(goodsMngDic3key.ToString());
                goodsMngDic2key.Append(goodsSupplierData.BLGoodsCode.ToString("00000"));

                //3.拠点＋中分類＋メーカー＋ＢＬ
                if (goodsMngDic2.ContainsKey(goodsMngDic2key.ToString()))
                {
                    retGoodsMng = goodsMngDic2[goodsMngDic2key.ToString()];
                    return;
                }

                //【全社＋メーカー】＋中分類
                StringBuilder goodsMngDic7key = new StringBuilder();
                goodsMngDic7key.Append(goodsMngDic8key.ToString());
                goodsMngDic7key.Append(goodsSupplierData.GoodsMGroup.ToString("0000"));
                //【全社＋メーカー＋中分類】＋ＢＬ
                StringBuilder goodsMngDic6key = new StringBuilder();
                goodsMngDic6key.Append(goodsMngDic7key.ToString());
                goodsMngDic6key.Append(goodsSupplierData.BLGoodsCode.ToString("00000"));

                //4.全社＋中分類＋メーカー＋ＢＬ
                if (goodsMngDic2.ContainsKey(goodsMngDic6key.ToString()))
                {
                    retGoodsMng = goodsMngDic2[goodsMngDic6key.ToString()];
                    return;
                }

                //5.拠点＋中分類＋メーカー
                if (goodsMngDic3.ContainsKey(goodsMngDic3key.ToString()))
                {
                    retGoodsMng = goodsMngDic3[goodsMngDic3key.ToString()];
                    return;
                }

                //6.全社＋中分類＋メーカー
                if (goodsMngDic3.ContainsKey(goodsMngDic7key.ToString()))
                {
                    retGoodsMng = goodsMngDic3[goodsMngDic7key.ToString()];
                    return;
                }

                //7.拠点＋メーカー
                if (goodsMngDic4.ContainsKey(goodsMngDic4key.ToString()))
                {
                    retGoodsMng = goodsMngDic4[goodsMngDic4key.ToString()];
                    return;
                }

                //8.全社＋メーカー
                if (goodsMngDic4.ContainsKey(goodsMngDic8key.ToString()))
                {
                    retGoodsMng = goodsMngDic4[goodsMngDic8key.ToString()];
                    return;
                }
                // ---ADD 2009/06/11 優先順変更 -------------------------------------<<<<<

            }
            finally
            {
                if (retGoodsMng != null)
                {
                    // 商品連結クラスへ商品管理情報セット
                    goodsSupplierData.SectionCode = retGoodsMng.SectionCode;
                    goodsSupplierData.SupplierCd = retGoodsMng.SupplierCd;
                    goodsSupplierData.SupplierLot = retGoodsMng.SupplierLot;

                }
            }
        }

		#endregion


	}

}