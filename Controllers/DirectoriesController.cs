using DirectoryViewer.Data;
using DirectoryViewer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DirectoryViewer.Controllers
{
    public class DirectoriesController : Controller
    {
        private readonly ApplicationDbContext dbContext;

        public DirectoriesController(ApplicationDbContext db)
        {
            dbContext = db;

            //DirectoryModel model = new DirectoryModel
            //{
            //    Name = "root",
            //};

            //dbContext.Directories.Add(model);

            //dbContext.SaveChanges();
        }


        [HttpGet]
        public IActionResult Index(int? id)
        {
            IndexVM indexVM = new IndexVM()
            {
                ParentDirectory = dbContext.Directories.Find(id)
            };

            if (id == null)
            {
                 indexVM.Directories = dbContext.Directories.ToList();
            }
            else
            {
                indexVM.Directories = dbContext.Directories.ToList().FindAll(i => i.ParentId==id);
            }
           
            return View(indexVM);
        }


        [HttpGet]
        public IActionResult Create()
        {
            CreateVM directoryVM = new CreateVM
            {
                DirectoryModel = new DirectoryModel(),
                Ids = dbContext.Directories.Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.DirectoryId.ToString()
                })
            };
            return View(directoryVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CreateVM directoryVm)
        { 
            dbContext.Directories.Add(directoryVm.DirectoryModel);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
            
        }

    }
}
