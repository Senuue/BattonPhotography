using System;
using System.IO;
using System.Linq;
using System.Web.Mvc;

namespace BattonPhotography.Controllers
{
    public class HomeController : Controller
    {
        private static readonly Random Rnd = new Random((int) DateTime.Now.Ticks);

        public ActionResult Index()
        {
            var weddingPhotos = Directory.EnumerateFiles(Server.MapPath("~/Images/Wedding/Fullsize")).ToList();
            ViewBag.Wedding = Path.GetFileName(weddingPhotos[Rnd.Next(weddingPhotos.Count)]);

            var eventPhotos = Directory.EnumerateFiles(Server.MapPath("~/Images/Event/Fullsize")).ToList();
            ViewBag.Event = Path.GetFileName(eventPhotos[Rnd.Next(eventPhotos.Count)]);

            var naturePhotos = Directory.EnumerateFiles(Server.MapPath("~/Images/Nature/Fullsize")).ToList();
            ViewBag.Nature = Path.GetFileName(naturePhotos[Rnd.Next(naturePhotos.Count)]);

            return View();
        }

        public ActionResult WeddingGallery(int? pageNumber)
        {
            if (pageNumber == null)
            {
                pageNumber = 0;
            }

            var naturePhotos = Directory.EnumerateFiles(Server.MapPath("~/Images/Wedding/FullSize")).ToList();

            ViewBag.PageCount = (naturePhotos.Count + 16 - 1)/16;

            var pagedResults = naturePhotos
                .Skip(16*pageNumber.Value)
                .Take(16);

            ViewBag.Photos = pagedResults;

            ViewBag.CurrentPage = pageNumber.Value;

            ViewBag.NextPageUrl = GetNextUrl(ViewBag.PageCount, pageNumber.Value, "WeddingGallery");
            ViewBag.PreviousUrl = GetPreviousUrl(ViewBag.PageCount, pageNumber.Value, "WeddingGallery");

            return View();
        }

        public ActionResult NatureGallery(int? pageNumber)
        {
            if (pageNumber == null)
            {
                pageNumber = 0;
            }

            var naturePhotos = Directory.EnumerateFiles(Server.MapPath("~/Images/Nature/FullSize")).ToList();

            ViewBag.PageCount = (naturePhotos.Count + 16 - 1)/16;

            var pagedResults = naturePhotos
                .Skip(16*pageNumber.Value)
                .Take(16);

            ViewBag.Photos = pagedResults;

            ViewBag.CurrentPage = pageNumber.Value;

            ViewBag.NextPageUrl = GetNextUrl(ViewBag.PageCount, pageNumber.Value, "NatureGallery");
            ViewBag.PreviousUrl = GetPreviousUrl(ViewBag.PageCount, pageNumber.Value, "NatureGallery");

            return View();
        }

        public ActionResult EventGallery(int? pageNumber)
        {
            if (pageNumber == null)
            {
                pageNumber = 0;
            }

            var naturePhotos = Directory.EnumerateFiles(Server.MapPath("~/Images/Event/FullSize")).ToList();

            ViewBag.PageCount = (naturePhotos.Count + 16 - 1)/16;

            var pagedResults = naturePhotos
                .Skip(16*pageNumber.Value)
                .Take(16);

            ViewBag.Photos = pagedResults;

            ViewBag.CurrentPage = pageNumber.Value;

            ViewBag.NextPageUrl = GetNextUrl(ViewBag.PageCount, pageNumber.Value, "EventGallery");
            ViewBag.PreviousUrl = GetPreviousUrl(ViewBag.PageCount, pageNumber.Value, "EventGallery");

            return View();
        }

        private string GetPreviousUrl(int pageCount, int currentPage, string pageName)
        {
            if (currentPage == 0)
            {
                return Url.Action(pageName, "Home", new {pageNumber = pageCount - 1});
            }

            return Url.Action(pageName, "Home", new {pageNumber = currentPage - 1});
        }

        public string GetNextUrl(int pageCount, int currentPage, string pageName)
        {
            if ((currentPage + 1) == pageCount)
            {
                return Url.Action(pageName, "Home", new {pageNumber = 0});
            }

            return Url.Action(pageName, "Home", new {pageNumber = currentPage + 1});
        }
    }
}