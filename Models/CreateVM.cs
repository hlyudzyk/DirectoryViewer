using Microsoft.AspNetCore.Mvc.Rendering;

namespace DirectoryViewer.Models
{
    public class CreateVM
    {
        public DirectoryModel DirectoryModel { get; set; }
        public IEnumerable<SelectListItem> Ids { get; set; }
    }
}
