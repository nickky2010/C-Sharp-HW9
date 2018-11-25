namespace HW9_2.Tables
{
    class TableAllInfo : Table
    {
        public TableAllInfo(string headTable = "", params Column[] column) : base(headTable, column)
        {
        }
        public void Print(string head, ref ProcessingStruct<Sportsman> pStruct)
        {
            HeadTable = head;
            PrintHead();
            for (int i = 0, j = 0; i < pStruct.Lenght; i++)
            {
                PrintString((++j).ToString(), pStruct[i].Surname, 
                    pStruct[i].YearOfBirth.ToString(), pStruct[i].Sport, pStruct[i].Category);
            }
            PrintBottom();
        }
    }
}
