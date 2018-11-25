using HW9_2.Extend;

namespace HW9_2.Tables
{
    class TableInfoSports : Table
    {
        public TableInfoSports(string headTable = "", params Column[] column) : base(headTable, column)
        {
        }
        public void Print(ref DictionarySports<string> ds)
        {
            PrintHead(false);
            for (int i = 0, j = 0; i < ds.Lenght; i++)
            {
                PrintString((++j).ToString(), ds.GetKey(i), ds[ds.GetKey(i)].ToString());
            }
            PrintBottom();
        }
    }
}
