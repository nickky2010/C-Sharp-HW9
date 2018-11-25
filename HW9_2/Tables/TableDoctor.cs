namespace HW8_3.Extend
{
    class TableDoctor : Table
    {
        public TableDoctor(string headTable = "", params Column[] column) : base(headTable, column)
        {
        }

        public void Print(Doctor doctor, Patient[] patients)
        {
            HeadTable = "Врач "+doctor.Surname+" кабинет № "+doctor.CabinetNumber;
            PrintHead();
            for (int i = 0, j = 0; i < patients.Length; i++)
            {
                if (patients[i].CabinetNumber == doctor.CabinetNumber)
                {
                    PrintString((++j).ToString(), patients[i].Surname, patients[i].DateReception,
                        patients[i].Diagnoz.ToString());
                }
            }
            PrintBottom();
        }
    }
}
