namespace AnacondaFramework.Interfaces
{
    public interface IArea : ISized, IDisplayable
    {
        IBox[] GetBoxes();
    }
}
