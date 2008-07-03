using Lephone.Data.Definition;

namespace Lephone.Data.Common
{
    public class GroupByObject<T> : IDbObject
    {
        // set to key make it as the first column
        [DbKey(IsDbGenerate = false)]
        public T Column;

        public long Count;

        public GroupByObject() { }

        public GroupByObject(T Column, long Count)
        {
            this.Column = Column;
            this.Count = Count;
        }
    }
}