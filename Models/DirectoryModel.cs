using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DirectoryViewer.Models
{
    [Table("Directories")]
    public class DirectoryModel
    {
        [Key]
        [Required]
        public int DirectoryId { get; set; }

        [Required]
        public string Name { get; set; }
        public int? ParentId { get; set; } = null;


        [ForeignKey("ParentId")]
        public DirectoryModel? ParentDirectory { get; set; }

        public List<DirectoryModel>? ChildDirectories { get; set; }

        public DirectoryModel()
        {
            ChildDirectories = new List<DirectoryModel>();
        }
        public override string ToString()
        {
            return $"{DirectoryId}    {Name}     {ParentId}";
        }

    }
}
