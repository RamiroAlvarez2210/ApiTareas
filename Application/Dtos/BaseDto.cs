namespace Application.Dtos
{
    public abstract class BaseDto
    {
        public Guid PublicId { get; set; } // = Guid.NewGuid();
    }
}