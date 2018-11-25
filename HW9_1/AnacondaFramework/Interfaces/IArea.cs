namespace AnacondaFramework.Interfaces
{
    public interface IArea : ISized, IDisplayable
    {
        IBox[] GetBoxes();
        void CreatBox(int count);
        void ShowBox();
    }
}
