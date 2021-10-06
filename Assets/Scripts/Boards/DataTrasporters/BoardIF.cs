

namespace Assets.Scripts.Boards.DataTrasporters
{
    public class BoardIf 
    {
        public int Id;
        public int Level;
        public int Target;
       
        public  BoardLineIf[] Lines;
        private int[] _sorteds;
        public int[] SortedNumbers
        {
            get { return _sorteds; }
            set
            {
                _sorteds = value;
                foreach (var x in Lines)
                {
                    x.Target = Target;
                    x.Sorteds = _sorteds;
                }
            }

        }
    }
    public class BoardIfCopy
    {
        public int Id;
        public int Level;
        public int Target;

        public LevelBoardline[] Lines;
      
    }
}
