namespace CleanArchitecture.Domain.Entities;
public abstract class BaseEntity
{
    [Key]
    public int Id { get; set; }

    //public override bool Equals(object? obj)
    //{
    //    if (obj == null || obj.GetType() != this.GetType())
    //    {
    //        return false;
    //    }

    //    BaseEntity other = (BaseEntity)obj;
    //    return Id == other.Id;
    //}

    //public override int GetHashCode() => Id.GetHashCode();

    //// Check if the entity is transient (i.e., has not been persisted to the database yet)
    //public bool IsTransient() => Id == default;
}