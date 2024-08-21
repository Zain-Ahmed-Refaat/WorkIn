using System.ComponentModel.DataAnnotations;

namespace WorkIn.Domain.Entities
{
    [Serializable]
    public class EntityBase
    {
        [Key]
        public int Id { get; set; }

        public DateTime? CreationDate { get; set; }
        public DateTime? DeletionDate { get; set; }
        public DateTime? LastModificationDate { get; set; }

        public bool? IsDeleted { get; set; }
    }
}
