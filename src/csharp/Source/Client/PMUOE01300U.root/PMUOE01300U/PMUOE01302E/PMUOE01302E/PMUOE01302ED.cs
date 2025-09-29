//****************************************************************************//
// �V�X�e��         : �����d����M����
// �v���O��������   : �����d����M����Model
// �v���O�����T�v   : 
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �H�� �b�D
// �� �� ��  2008/11/17  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30517 �Ė� �x��
// �� �� ��  2012/08/06  �C�����e : ����̃p�^�[���ŃG���[�ɂȂ�ׁA�L�[�̍쐬���@�̕ύX
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Text;

namespace Broadleaf.Application.UIData
{
    #region <Iterator Idiom/>

    /// <summary>
    /// �W���̃C���^�[�t�F�[�X
    /// </summary>
    /// <typeparam name="T">�W���̂ƂȂ�N���X</typeparam>
    public interface IAgreegate<T> where T : class
    {
        /// <summary>
        /// �W���̂̃T�C�Y���擾���܂��B
        /// </summary>
        /// <value>�W���̂̃T�C�Y</value>
        int Size { get; }

        /// <summary>
        /// �C���f�b�N�X�ɑΉ�����v�f���擾���܂��B
        /// </summary>
        /// <param name="index">�C���f�b�N�X</param>
        /// <returns>�C���f�b�N�X�ɑΉ�����v�f</returns>
        T GetAt(int index); // HACK:�C���f�N�T�̕����]�܂����c

        /// <summary>
        /// �����q�𐶐����܂��B
        /// </summary>
        /// <returns>�����q</returns>
        IIterator<T> CreateIterator();

        /// <summary>
        /// �O���[�v�����ꂽ�܂Ƃ܂�i���X�g�j�̃}�b�v���擾���܂��B
        /// </summary>
        /// <value>�O���[�v�����ꂽ�܂Ƃ܂�i���X�g�j�̃}�b�v</value>
        IDictionary<string, IList<T>> GroupedListMap { get; }
    }

    /// <summary>
    /// �����q�C���^�[�t�F�[�X
    /// </summary>
    /// <typeparam name="T">�����q�ƂȂ�N���X</typeparam>
    public interface IIterator<T> where T : class
    {
        /// <summary>
        /// ���̔����q�����邩���肵�܂��B
        /// </summary>
        /// <returns>
        /// <c>true</c> :����<br/>
        /// <c>false</c>:�Ȃ�
        /// </returns>
        bool HasNext();

        /// <summary>
        /// ���̔����q���擾���܂��B
        /// </summary>
        /// <returns>���̔����q</returns>
        T GetNext();
    }

    /// <summary>
    /// �ȈՔ����q�N���X
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class SimpleIterator<T> : IIterator<T> where T : class
    {
        #region IIterator<T> �����o

        /// <summary>
        /// ���̔����q�����邩���肵�܂��B
        /// </summary>
        /// <returns>
        /// <c>true</c> :����<br/>
        /// <c>false</c>:�Ȃ�
        /// </returns>
        public bool HasNext()
        {
            return _nextIndex < Agreegate.Size;
        }

        /// <summary>
        /// ���̔����q���擾���܂��B
        /// </summary>
        /// <returns>���̔����q</returns>
        public T GetNext()
        {
            return Agreegate.GetAt(_nextIndex++);
        }

        #endregion

        #region <�W����/>

        /// <summary>��M�e�L�X�g�̏W����</summary>
        private readonly IAgreegate<T> _agreegate;
        /// <summary>
        /// ��M�e�L�X�g�̏W���̂��擾���܂��B
        /// </summary>
        /// <value>��M�e�L�X�g�̏W����</value>
        protected IAgreegate<T> Agreegate { get { return _agreegate; } }

        #endregion  // <�W����/>

        /// <summary>���̗v�f�̃C���f�b�N�X</summary>
        protected int _nextIndex;

        #region <Constructor/>

        /// <summary>
        /// �J�X�^���R���X�g���N�^
        /// </summary>
        /// <param name="agreegate">�W����</param>
        public SimpleIterator(IAgreegate<T> agreegate)
        {
            _agreegate = agreegate;
        }

        #endregion  // <Constructor/>
    }

    #endregion  // <Iterator Idiom/>

    /// <summary>
    /// ��M�e�L�X�g�i�d���v���d���̉����j�̏W���̃N���X
    /// </summary>
    public sealed class ReceivedTextAgreegate : IAgreegate<ReceivedText>
    {
        #region <IAgreegate<ReceivedText> �����o/>

        /// <summary>
        /// �W���̂̃T�C�Y���擾���܂��B
        /// </summary>
        /// <value>�W���̂̃T�C�Y</value>
        public int Size
        {
            get { return ReceivedTextList.Count; }
        }

        /// <summary>
        /// �C���f�b�N�X�ɑΉ�����v�f���擾���܂��B
        /// </summary>
        /// <param name="index">�C���f�b�N�X</param>
        /// <returns>�C���f�b�N�X�ɑΉ�����v�f</returns>
        public ReceivedText GetAt(int index)
        {
            return ReceivedTextList[index];
        }

        /// <summary>
        /// �����q�𐶐����܂��B
        /// </summary>
        /// <returns>�����q</returns>
        public IIterator<ReceivedText> CreateIterator()
        {
            return new SimpleIterator<ReceivedText>(this);
        }

        /// <summary>
        /// �O���[�v�����ꂽ�܂Ƃ܂�i���X�g�j�̃}�b�v���擾���܂��B
        /// </summary>
        /// <value>�O���[�v�����ꂽ�܂Ƃ܂�i���X�g�j�̃}�b�v</value>
        public IDictionary<string, IList<ReceivedText>> GroupedListMap
        {
            get { return ReceivedTextListMap; }
        }

        #endregion  // <IAgreegate<ReceivedText> �����o/>

        #region <UOE��M����/>

        /// <summary>UOE��M���ʁi�w�b�_�[�j</summary>
        private readonly UoeRecHed _uoeReceivedResult;
        /// <summary>
        /// UOE��M���ʁi�w�b�_�[�j���擾���܂��B
        /// </summary>
        /// <value>UOE��M���ʁi�w�b�_�[�j</value>
        private UoeRecHed UOEReceivedResult { get { return _uoeReceivedResult; } }

        #endregion  // <UOE��M����/>

        #region <��M�e�L�X�g/>

        /// <summary>��M�e�L�X�g�}�b�v�i�����p�j</summary>
        private readonly IDictionary<string, ReceivedText> _receivedTextMap;
        /// <summary>
        /// ��M�e�L�X�g�}�b�v�i�����p�j���擾���܂��B
        /// </summary>
        /// <value>��M�e�L�X�g�}�b�v�i�����p�j</value>
        private IDictionary<string, ReceivedText> ReceivedTextMap { get { return _receivedTextMap; } } 

        // TODO:�}�b�v�݂̂Ƃ������c
        /// <summary>��M�e�L�X�g���X�g�i�����p�j</summary>
        private readonly IList<ReceivedText> _receivedTextList;
        /// <summary>
        /// ��M�e�L�X�g���X�g�i�����p�j���擾���܂��B
        /// </summary>
        /// <value>��M�e�L�X�g���X�g�i�����p�j</value>
        private IList<ReceivedText> ReceivedTextList { get { return _receivedTextList; } }

        /// <summary>�o�ד`�[�ԍ��ʂ̎�M�e�L�X�g���X�g�̃}�b�v</summary>
        private readonly IDictionary<string, IList<ReceivedText>> _receivedTextListMap;
        /// <summary>
        /// �o�ד`�[�ԍ��ʂ̎�M�e�L�X�g���X�g�̃}�b�v���擾���܂��B
        /// </summary>
        /// <value>�o�ד`�[�ԍ��ʂ̎�M�e�L�X�g���X�g�̃}�b�v</value>
        private IDictionary<string, IList<ReceivedText>> ReceivedTextListMap { get { return _receivedTextListMap; } }

        #endregion  // <��M�e�L�X�g/>

        /// <summary>�o�ד`�[�ԍ��ʂ̎�M�f�[�^�̃J�E���^�}�b�v</summary>
        private readonly IDictionary<string, int> _innerIndexCounterMap = new Dictionary<string, int>();
        /// <summary>
        /// �o�ד`�[�ԍ��ʂ̎�M�f�[�^�̃J�E���^�}�b�v
        /// </summary>
        private IDictionary<string, int> InnerIndexCounterMap { get { return _innerIndexCounterMap; } }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="slipNo">�o�ד`�[�ԍ�</param>
        /// <returns></returns>
        private int GetInnerIndexNo(string slipNo)
        {
            if (!InnerIndexCounterMap.ContainsKey(slipNo))
            {
                InnerIndexCounterMap.Add(slipNo, 0);
            }
            int nextInnerIndex = ++InnerIndexCounterMap[slipNo];
            InnerIndexCounterMap[slipNo] = nextInnerIndex;

            return nextInnerIndex;
        }

        #region <Constructor/>

        /// <summary>
        /// �J�X�^���R���X�g���N�^
        /// </summary>
        /// <param name="uoeReceivedResult">UOE��M���ʁi�w�b�_�[�j</param>
        public ReceivedTextAgreegate(UoeRecHed uoeReceivedResult)
        {
            _uoeReceivedResult = uoeReceivedResult;

            _receivedTextMap    = new Dictionary<string, ReceivedText>();
            _receivedTextList   = new List<ReceivedText>();
            _receivedTextListMap= new Dictionary<string, IList<ReceivedText>>();

            foreach (UoeRecDtl uoeRecDtl in uoeReceivedResult.UoeRecDtlList)
            {
                InitializeReceivedTextCollection(uoeRecDtl);
            }
        }

        /// <summary>
        /// ��M�e�L�X�g�R���N�V���������������܂��B
        /// </summary>
        /// <param name="stockRequestAnswer">�d���v���̉���</param>
        private void InitializeReceivedTextCollection(UoeRecDtl stockRequestAnswer)
        {
            // �J�ǁ^�Ǔd���̉����͖���
            if (stockRequestAnswer.UOESalesOrderNo.Equals(0)) return;

            int answerCount = stockRequestAnswer.RecTelegram.Length / ReceivedText.TELEGRAM_LENGTH;
            for (int iAnswer = 0; iAnswer < answerCount; iAnswer++)
            {
                int beginIndex = iAnswer * ReceivedText.TELEGRAM_LENGTH;
                ReceivedText receivedText = new ReceivedText(stockRequestAnswer.RecTelegram, beginIndex, iAnswer + 1);

                // �o�ד`�[�ԍ��ŃO���[�v��
                string slipNo = ReceivedText.FormatUOESectionSlipNo(receivedText.UOESectionSlipNo);
                receivedText.InnerIndex = GetInnerIndexNo(slipNo);

                if (!ReceivedTextListMap.ContainsKey(slipNo))
                {
                    ReceivedTextListMap.Add(slipNo, new List<ReceivedText>());
                }
                ReceivedTextListMap[slipNo].Add(receivedText);

                // �����p�}�b�v�Ƒ����p���X�g
                // upd 2012/08/06 >>>
                //string key = ReceivedText.GetKey(receivedText);
                string key = ReceivedText.GetKey(receivedText, receivedText.InnerIndex);
                // upd 2012/08/06 <<<
                if (!ReceivedTextMap.ContainsKey(key))
                {
                    ReceivedTextMap.Add(key, receivedText);
                    ReceivedTextList.Add(receivedText);
                }
            }
        }

        #endregion  // <Constructor/>

        #region <Override/>

        /// <summary>
        /// ������ɕϊ����܂��B
        /// </summary>
        /// <returns>������</returns>
        public override string ToString()
        {
            StringBuilder str = new StringBuilder();

            for (int i = 0; i < ReceivedTextList.Count; i++)
            {
                str.Append("��M�e�L�X�g[").Append(i).Append("]").Append(Environment.NewLine);
                str.Append(ReceivedTextList[i].ToString()).Append(Environment.NewLine);
                str.Append(Environment.NewLine);
            }

            return str.ToString();
        }

        #endregion  // <Override/>
    }
}
