using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BattonPhotography.Controllers
{
    public class HomeController : Controller
    {
        private static Random rnd = new Random((int)DateTime.Now.Ticks);

        public ActionResult Index()
        {
            List<string> weddingPhotos = Directory.EnumerateFiles(Server.MapPath("~/Images/Wedding")).ToList();
            ViewBag.Wedding = Path.GetFileName(weddingPhotos[rnd.Next(weddingPhotos.Count)]);

            List<string> eventPhotos = Directory.EnumerateFiles(Server.MapPath("~/Images/Event")).ToList();
            ViewBag.Event = Path.GetFileName(eventPhotos[rnd.Next(eventPhotos.Count)]);

            List<string> naturePhotos = Directory.EnumerateFiles(Server.MapPath("~/Images/Nature")).ToList();
            ViewBag.Nature = Path.GetFileName(naturePhotos[rnd.Next(naturePhotos.Count)]);

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult WeddingGallery()
        {
            IEnumerable<string> weddingPhotos = Directory.EnumerateFiles(Server.MapPath("~/Images/wedding"));

            List<string> weddingPhotosList = new List<string>();

            foreach (var photo in weddingPhotos)
            {
                weddingPhotosList.Add(photo);
            }

            ViewBag.Photos = weddingPhotosList;
            ViewBag.PhotoCount = weddingPhotosList.Count();

            return View();
        }

        public ActionResult NatureGallery()
        {
            IEnumerable<string> naturePhotos = Directory.EnumerateFiles(Server.MapPath("~/Images/Nature"));

            List<string> naturePhotosList = new List<string>();

            foreach (var photo in naturePhotos)
            {
                naturePhotosList.Add(photo);
            }

            ViewBag.Photos = naturePhotosList;
            ViewBag.PhotoCount = naturePhotosList.Count();

            return View();
        }

        public ActionResult EventGallery()
        {
            IEnumerable<string> eventPhotos = Directory.EnumerateFiles(Server.MapPath("~/Images/event"));

            List<string> eventPhotosList = new List<string>();

            foreach (var photo in eventPhotos)
            {
                eventPhotosList.Add(photo);
            }

            ViewBag.Photos = eventPhotosList;
            ViewBag.PhotoCount = eventPhotosList.Count();

            return View();
        }

        public ActionResult RequestPrint(string gallery, string file)
        {
            ViewBag.Gallery = gallery;
            ViewBag.FileName = file;

            return View();
        }
    }
}