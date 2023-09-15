using System;

namespace Pattern.Models.Save
{
    public abstract class KeeperSaveAs : IChordataSave
    {
        private string nameOfFile;

        private string formatFile;

        public KeeperSaveAs(string NameOfFile, string formatFile)
        {
            this.nameOfFile = NameOfFile;
            this.formatFile = formatFile;
        }

        public virtual void SaveChordata(Chordata animal)
        {
            throw new NotImplementedException();
        }
    }
}
