using System;
using System.Collections.Generic;
using System.Text;

namespace Broadleaf.Application.UIData
{
    /// <summary>
    /// �I��UI�őI���������i��q�ɏ����i�[���܂��B
    /// </summary>
    /// <remarks>
    /// <br>Update Note	: �v���p�e�B�ɑI��i�Ԃ�ǉ�</br>
    /// <br>Programmer	: 21024�@���X�� ��</br>
    /// <br>Date		: 2009/12/14</br>
    /// <br></br>
    /// <br>Update Note	: �v���p�e�B�Ɂu���R�������i�ŃZ�b�g�e��o�^�����ꍇ�v�𔻒f����t���O��ǉ�</br>
    /// <br>Programmer	: 22018�@��� ���b</br>
    /// <br>Date		: 2010/10/01</br>
    /// </remarks>
    public class SelectionInfo
    {
        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        public SelectionInfo()
        {

        }

        ///// <summary>
        ///// �R���X�g���N�^
        ///// </summary>
        ///// <param name="key"></param>
        ///// <param name="selected"></param>
        ///// <param name="rowGoods"></param>
        ///// <param name="rowStock"></param>
        //public SelectionInfo(int key, bool selected, PartsInfoDataSet.UsrGoodsInfoRow rowGoods, PartsInfoDataSet.StockRow rowStock)
        //{
        //    _key = key;
        //    _selected = selected;
        //    _rowGoods = rowGoods;
        //    _rowStock = rowStock;
        //}

        /// <summary>0:����i�ԑI��UI�^���i�I��UI 1:�����I��UI 2:�Z�b�g�I��UI</summary>
        private int _depth;
        /// <summary>�X���b�h�L�[</summary>
        private int _key;
        /// <summary>�I�����</summary>
        private bool _selected = false;
        /// <summary>�������Z�b�g���̌������̃Z�b�g�I��</summary>
        private bool _joinSet = false;
        /// <summary></summary>
        private PartsInfoDataSet.UsrGoodsInfoRow _rowGoods;
        /// <summary></summary>
        private string _warehouseCd;
        /// <summary>�q���i���X�g1</summary>
        private Dictionary<int, SelectionInfo> _lst = new Dictionary<int, SelectionInfo>();
        /// <summary>�q���i���X�g2</summary>
        private Dictionary<int, SelectionInfo> _lst2 = new Dictionary<int, SelectionInfo>();
        /// <summary>�݊����X�g</summary>
        private List<SelectionInfo> _lstPlrlSubst = new List<SelectionInfo>();
        // 2009/12/14 Add >>>
        /// <summary>�I��i��</summary>
        private string _selectedPartsNo = string.Empty;
        // 2009/12/14 Add <<<
        // --- ADD m.suzuki 2010/10/01 ---------->>>>>
        /// <summary>BL�R�[�h�������ɕ��i�I���̎��_�ŃZ�b�g�e�������ꍇ(���R�������i�ɃZ�b�g�e��o�^�����ꍇ)</summary>
        private bool _extractSetParent = false;
        // --- ADD m.suzuki 2010/10/01 ----------<<<<<

        /// <summary>����ʕ\���X�e�b�v 0:����i�ԑI��UI�^���i�I��UI 1:�����I��UI 2:�Z�b�g�I��UI</summary>
        public int Depth
        {
            get { return _depth; }
            set { _depth = value; }
        }

        /// <summary>�X���b�h�L�[</summary>
        public int Key
        {
            get { return _key; }
            set { _key = value; }
        }

        /// <summary>�I�����</summary>
        public bool Selected
        {
            get { return _selected; }
            set { _selected = value; }
        }

        /// <summary>�������Z�b�g���̌������̃Z�b�g�I��</summary>
        public bool JoinSet
        {
            get { return _joinSet; }
            set { _joinSet = value; }
        }

        /// <summary>���i���</summary>
        public PartsInfoDataSet.UsrGoodsInfoRow RowGoods
        {
            get { return _rowGoods; }
            set { _rowGoods = value; }
        }

        /// <summary>�q�ɃR�[�h</summary>
        public string WarehouseCode
        {
            get { return _warehouseCd; }
            set { _warehouseCd = value; }
        }

        /// <summary>�q���i���X�g</summary>
        public Dictionary<int, SelectionInfo> ListChildGoods
        {
            get { return _lst; }
            set { _lst = value; }
        }

        /// <summary>�q���i���X�g2(�������i�������E�Z�b�g��������ꍇ�Z�b�g�̎q�̃��X�g���i�[)</summary>
        public Dictionary<int, SelectionInfo> ListChildGoods2
        {
            get { return _lst2; }
            set { _lst2 = value; }
        }

        /// <summary>�݊����X�g</summary>
        public List<SelectionInfo> ListPlrlSubst
        {
            get { return _lstPlrlSubst; }
            set { _lstPlrlSubst = value; }
        }
        // 2009/12/14 Add >>>
        /// <summary>�I��i��</summary>
        public string SelectedPartsNo
        {
            get { return _selectedPartsNo; }
            set { _selectedPartsNo = value; }
        }
        // 2009/12/14 Add <<<
        // --- ADD m.suzuki 2010/10/01 ---------->>>>>
        /// <summary>BL�R�[�h�������ɕ��i�I���̎��_�ŃZ�b�g�e�������ꍇ(���R�������i�ɃZ�b�g�e��o�^�����ꍇ)</summary>
        public bool ExtractSetParent
        {
            get { return _extractSetParent; }
            set { _extractSetParent = value; }
        }
        // --- ADD m.suzuki 2010/10/01 ----------<<<<<

        /// <summary>
        /// �������g���͎q���X�g�ɑI�����ꂽ�̂����邩�`�F�b�N
        /// true : �I������^false�F�I���Ȃ�
        /// </summary>        
        public bool IsThereSelection
        {
            get
            {
                if (_selected)
                    return _selected;
                else
                {
                    foreach (SelectionInfo sel in _lst.Values)
                    {
                        if (sel.IsThereSelection)
                            return true;
                    }
                    foreach (SelectionInfo sel in _lst2.Values)
                    {
                        if (sel.IsThereSelection)
                            return true;
                    }
                    //foreach (SelectionInfo sel in _lstPlrlSubst)
                    //{
                    //    if (sel.IsThereSelection)
                    //        return true;
                    //}
                }
                return false;
            }
        }
    }
}
