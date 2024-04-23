using System;


namespace Library.Entities
{
    public abstract class BaseObject
    {
        public int Id { get; set; }

        public DateTime CreatedDate { get; set; }
        public DateTime? LastModifiedDate { get; set; }

        public DateTime? DeletedDate { get; set; }
    }
}
