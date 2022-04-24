using System;



namespace com.jesusnoseq.util{
    [Serializable]
    public class RankItem {
        public string name;
        public int milliseconds;
        public string hash;

        public RankItem() {}

        public RankItem(string name, int milliseconds)
        {
            this.name = name;
            this.milliseconds = milliseconds;
        }
    }

}

