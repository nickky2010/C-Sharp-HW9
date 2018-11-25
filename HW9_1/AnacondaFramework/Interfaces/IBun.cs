namespace HW9_1.AnacondaFramework.Interfaces
{
    public interface IBun
    {
        int X { get; set; }
        int Y { get; set; }
        void Show();
        void ChangePosition(int width, int height);
    }
}
