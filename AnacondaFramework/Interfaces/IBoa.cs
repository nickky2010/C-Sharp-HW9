using AnacondaFramework.Enums;

namespace AnacondaFramework.Interfaces
{
    public interface IBoa : IDisplayable
    {
        int Length { get; }
        Destination Destination { get; set; }
        void Move();
    }
}
