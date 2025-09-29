using System.Collections.Generic;

namespace Broadleaf.Library.Windows.Forms 
{
    partial class TBO
    {
        partial class StockDataTable
        {
        }

        partial class TBOInfoDataTable
        {
            /// <summary>
            /// 収録している部品の装備コード一覧を返す
            /// </summary>
            /// <returns></returns>
            public List<int> GetEquipCdList()
            {
                List<int> lst = new List<int>();
                for ( int i = 0; i < Count; i++ )
                {
                    int blCd = (int)Rows[i][EquipGenreCodeColumn];
                    if ( lst.Contains( blCd ) == false )
                    {
                        lst.Add( blCd );
                    }
                }
                return lst;
            }
        }
    }
}

